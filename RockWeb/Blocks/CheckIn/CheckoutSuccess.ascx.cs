﻿// <copyright>
// Copyright by the Spark Development Network
//
// Licensed under the Rock Community License (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
// http://www.rockrms.com/license
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// </copyright>
//
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text.RegularExpressions;
using System.Web.UI;
using System.Web.UI.HtmlControls;

using Rock;
using Rock.Attribute;
using Rock.CheckIn;
using Rock.Data;
using Rock.Model;
using Rock.Web.UI;

namespace RockWeb.Blocks.CheckIn
{
    /// <summary>
    /// 
    /// </summary>
    [DisplayName( "Check Out Success" )]
    [Category( "Check-in" )]
    [Description( "Displays the details of a successful check out." )]

    [TextField( "Title", "Title to display.", false, "Checked Out", "Text", 5 )]
    [TextField( "Detail Message", "The message to display indicating person has been checked out. Use {0} for person, {1} for group, {2} for location, and {3} for schedule.", false,
        "{0} was checked out of {1} in {2} at {3}.", "Text", 6 )]

    public partial class CheckoutSuccess : CheckInBlock
    {
        /// <summary>
        /// Raises the <see cref="E:System.Web.UI.Control.Init" /> event.
        /// </summary>
        /// <param name="e">An <see cref="T:System.EventArgs" /> object that contains the event data.</param>
        protected override void OnInit( EventArgs e )
        {
            base.OnInit( e );

            RockPage.AddScriptLink( "~/Scripts/CheckinClient/cordova-2.4.0.js", false );
            RockPage.AddScriptLink( "~/Scripts/CheckinClient/ZebraPrint.js" );
            RockPage.AddScriptLink( "~/Scripts/CheckinClient/checkin-core.js" );

            var bodyTag = this.Page.Master.FindControl( "bodyTag" ) as HtmlGenericControl;
            if ( bodyTag != null )
            {
                bodyTag.AddCssClass( "checkin-checkoutsuccess-bg" );
            }
        }

        /// <summary>
        /// Raises the <see cref="E:System.Web.UI.Control.Load" /> event.
        /// </summary>
        /// <param name="e">The <see cref="T:System.EventArgs" /> object that contains the event data.</param>
        protected override void OnLoad( EventArgs e )
        {
            base.OnLoad( e );

            if ( CurrentWorkflow == null || CurrentCheckInState == null )
            {
                NavigateToHomePage();
            }
            else
            {
                if ( !Page.IsPostBack )
                {
                    try
                    {
                        lTitle.Text = GetAttributeValue( "Title" );

                        var printFromClient = new List<CheckInLabel>();
                        var printFromServer = new List<CheckInLabel>();

                        using ( var rockContext = new RockContext() )
                        {
                            var attendanceService = new AttendanceService( rockContext );

                            var now = RockDateTime.Now;

                            // Print the labels
                            foreach ( var family in CurrentCheckInState.CheckIn.Families.Where( f => f.Selected ) )
                            {
                                foreach ( var person in family.CheckOutPeople.Where( p => p.Selected ) )
                                {
                                    foreach ( var attendance in attendanceService.Queryable()
                                        .Where( a => person.AttendanceIds.Contains( a.Id ) )
                                        .ToList() )
                                    {
                                        attendance.EndDateTime = now;

                                        if ( attendance.Occurrence.Group != null &&
                                            attendance.Occurrence.Location != null &&
                                            attendance.Occurrence.Schedule != null )
                                        {
                                            var li = new HtmlGenericControl( "li" );
                                            li.InnerText = string.Format( GetAttributeValue( "DetailMessage" ),
                                                person.ToString(), attendance.Occurrence.Group.ToString(), attendance.Occurrence.Location.ToString(), attendance.Occurrence.Schedule.Name );

                                            phResults.Controls.Add( li );
                                        }

                                    }

                                    if ( person.Labels != null && person.Labels.Any() )
                                    {
                                        printFromClient.AddRange( person.Labels.Where( l => l.PrintFrom == Rock.Model.PrintFrom.Client ) );
                                        printFromServer.AddRange( person.Labels.Where( l => l.PrintFrom == Rock.Model.PrintFrom.Server ) );
                                    }
                                }
                            }

                            rockContext.SaveChanges();
                        }

                        if ( printFromClient.Any() )
                        {
                            var urlRoot = string.Format( "{0}://{1}", Request.Url.Scheme, Request.Url.Authority );
                            printFromClient
                                .OrderBy( l => l.PersonId )
                                .ThenBy( l => l.Order )
                                .ToList()
                                .ForEach( l => l.LabelFile = urlRoot + l.LabelFile );
                            AddLabelScript( printFromClient.ToJson() );
                        }

                        if ( printFromServer.Any() )
                        {
                            Socket socket = null;
                            string currentIp = string.Empty;

                            foreach ( var label in printFromServer
                                .OrderBy( l => l.PersonId )
                                .ThenBy( l => l.Order ) )
                            {
                                var labelCache = KioskLabel.Get( label.FileGuid );
                                if ( labelCache != null )
                                {
                                    if ( !string.IsNullOrWhiteSpace( label.PrinterAddress ) )
                                    {
                                        if ( label.PrinterAddress != currentIp )
                                        {
                                            if ( socket != null && socket.Connected )
                                            {
                                                socket.Shutdown( SocketShutdown.Both );
                                                socket.Close();
                                            }

                                            currentIp = label.PrinterAddress;
                                            var printerIp = new IPEndPoint( IPAddress.Parse( currentIp ), 9100 );

                                            socket = new Socket( AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp );
                                            IAsyncResult result = socket.BeginConnect( printerIp, null, null );
                                            bool success = result.AsyncWaitHandle.WaitOne( 5000, true );
                                        }

                                        string printContent = labelCache.FileContent;
                                        foreach ( var mergeField in label.MergeFields )
                                        {
                                            if ( !string.IsNullOrWhiteSpace( mergeField.Value ) )
                                            {
                                                printContent = Regex.Replace( printContent, string.Format( @"(?<=\^FD){0}(?=\^FS)", mergeField.Key ), ZebraFormatString( mergeField.Value ) );
                                            }
                                            else
                                            {
                                                // Remove the box preceding merge field
                                                printContent = Regex.Replace( printContent, string.Format( @"\^FO.*\^FS\s*(?=\^FT.*\^FD{0}\^FS)", mergeField.Key ), string.Empty );
                                                // Remove the merge field
                                                printContent = Regex.Replace( printContent, string.Format( @"\^FD{0}\^FS", mergeField.Key ), "^FD^FS" );
                                            }
                                        }

                                        if ( socket.Connected )
                                        {
                                            var ns = new NetworkStream( socket );
                                            byte[] toSend = System.Text.Encoding.ASCII.GetBytes( printContent );
                                            ns.Write( toSend, 0, toSend.Length );
                                        }
                                        else
                                        {
                                            phResults.Controls.Add( new LiteralControl( "<br/>NOTE: Could not connect to printer!" ) );
                                        }
                                    }
                                }
                            }

                            if ( socket != null && socket.Connected )
                            {
                                socket.Shutdown( SocketShutdown.Both );
                                socket.Close();
                            }
                        }

                    }
                    catch ( Exception ex )
                    {
                        LogException( ex );
                    }
                }
            }
        }

        /// <summary>
        /// Handles the Click event of the lbDone control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
        protected void lbDone_Click( object sender, EventArgs e )
        {
            NavigateToHomePage();
        }

        private string ZebraFormatString( string input, bool isJson = false )
        {
            if ( isJson )
            {
                return input.Replace( "é", @"\\82" );  // fix acute e
            }
            else
            {
                return input.Replace( "é", @"\82" );  // fix acute e
            }
        }

        /// <summary>
        /// Adds the label script.
        /// </summary>
        /// <param name="jsonObject">The json object.</param>
        private void AddLabelScript( string jsonObject )
        {
            string script = string.Format( @"

        // setup deviceready event to wait for cordova
	    if (navigator.userAgent.match(/(iPhone|iPod|iPad)/)) {{
            document.addEventListener('deviceready', onDeviceReady, false);
        }} else {{
            $( document ).ready(function() {{
                onDeviceReady();
            }});
        }}

	    // label data
        var labelData = {0};

		function onDeviceReady() {{
            try {{			
                printLabels();
            }} 
            catch (err) {{
                console.log('An error occurred printing labels: ' + err);
            }}
		}}
		
		function alertDismissed() {{
		    // do something
		}}
		
		function printLabels() {{
		    ZebraPrintPlugin.printTags(
            	JSON.stringify(labelData), 
            	function(result) {{ 
			        console.log('Tag printed');
			    }},
			    function(error) {{   
				    // error is an array where:
				    // error[0] is the error message
				    // error[1] determines if a re-print is possible (in the case where the JSON is good, but the printer was not connected)
			        console.log('An error occurred: ' + error[0]);
                    navigator.notification.alert(
                        'An error occurred while printing the labels.' + error[0],  // message
                        alertDismissed,         // callback
                        'Error',            // title
                        'Ok'                  // buttonName
                    );
			    }}
            );
	    }}
", ZebraFormatString( jsonObject, true ) );
            ScriptManager.RegisterStartupScript( this, this.GetType(), "addLabelScript", script, true );
        }

    }
}