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
using System.Linq;
using System.Text.RegularExpressions;
using Rock.Data;
using Rock.Model;
using Rock.Web.Cache;
using UAParser;

namespace Rock.Transactions
{
    /// <summary>
    /// Tracks when a page is viewed.
    /// </summary>
    public class PageViewTransaction : ITransaction
    {
        /// <summary>
        /// Gets or sets the Page Id.
        /// </summary>
        /// <value>
        /// Page Id.
        /// </value>
        public int? PageId { get; set; }

        /// <summary>
        /// Gets or sets the Site Id.
        /// </summary>
        /// <value>
        /// Site Id.
        /// </value>
        public int? SiteId { get; set; }

        /// <summary>
        /// Gets or sets the Person Id.
        /// </summary>
        /// <value>
        /// Person Id.
        /// </value>
        public int? PersonAliasId { get; set; }

        /// <summary>
        /// Gets or sets the DateTime the page was viewed.
        /// </summary>
        /// <value>
        /// Date Viewed.
        /// </value>
        public DateTime DateViewed { get; set; }

        /// <summary>
        /// Gets or sets the IP address that requested the page.
        /// </summary>
        /// <value>
        /// IP Address.
        /// </value>
        public string IPAddress { get; set; }

        /// <summary>
        /// Gets or sets the browser vendor and version.
        /// </summary>
        /// <value>
        /// IP Address.
        /// </value>
        public string UserAgent { get; set; }

        /// <summary>
        /// Gets or sets the session id.
        /// </summary>
        /// <value>
        /// Session Id.
        /// </value>
        public string SessionId { get; set; }

        /// <summary>
        /// Gets or sets the query string.
        /// </summary>
        /// <value>
        /// Query String.
        /// </value>
        public string Url { get; set; }

        /// <summary>
        /// Gets or sets the page title.
        /// </summary>
        /// <value>
        /// Page Title.
        /// </value>
        public string PageTitle { get; set; }

        /// <summary>
        /// The ua parser
        /// </summary>
        private static Parser uaParser = Parser.GetDefault();

        /// <summary>
        /// Execute method to write transaction to the database.
        /// </summary>
        public void Execute()
        {
            using ( var rockContext = new RockContext() )
            {
                
                var userAgent = (this.UserAgent ?? string.Empty).Trim();
                if ( userAgent.Length > 450 )
                {
                    userAgent = userAgent.Substring( 0, 450 ); // trim super long useragents to fit in pageViewUserAgent.UserAgent
                }

                // get user agent info
                var clientType = InteractionDeviceType.GetClientType( userAgent );

                // don't log visits from crawlers
                if ( clientType != "Crawler" )
                {
                    InteractionChannelService interactionChannelService = new InteractionChannelService( rockContext );
                    InteractionComponentService interactionComponentService = new InteractionComponentService( rockContext );
                    InteractionDeviceTypeService interactionDeviceTypeService = new InteractionDeviceTypeService( rockContext );
                    InteractionSessionService interactionSessionService = new InteractionSessionService( rockContext );
                    InteractionService interactionService = new InteractionService( rockContext );

                    ClientInfo client = uaParser.Parse( userAgent );
                    var clientOs = client.OS.ToString();
                    var clientBrowser = client.UserAgent.ToString();

                    // lookup the interactionDeviceType, and create it if it doesn't exist
                    var interactionDeviceTypeId = interactionDeviceTypeService.Queryable().Where( a => a.Application == clientBrowser
                                                && a.OperatingSystem == clientOs && a.ClientType == clientType )
                                                .Select( a => (int?)a.Id )
                                                .FirstOrDefault();

                    if ( !interactionDeviceTypeId.HasValue )
                    {
                        var interactionDeviceType = new InteractionDeviceType();
                        interactionDeviceType.DeviceTypeData = userAgent;
                        interactionDeviceType.ClientType = clientType;
                        interactionDeviceType.OperatingSystem = clientOs;
                        interactionDeviceType.Application = clientBrowser;
                        interactionDeviceType.Name = string.Format( "{0} - {1}", clientOs, clientBrowser );
                        interactionDeviceTypeService.Add( interactionDeviceType );
                        rockContext.SaveChanges();
                        interactionDeviceTypeId = interactionDeviceType.Id;
                    }

                    // lookup interactionSession, and create it if it doesn't exist
                    Guid sessionId = this.SessionId.AsGuid();
                    int? interactionSessionId = interactionSessionService.Queryable()
                                                    .Where( 
                                                        a => a.DeviceTypeId == interactionDeviceTypeId.Value 
                                                        && a.Guid == sessionId )
                                                    .Select( a => (int?)a.Id )
                                                    .FirstOrDefault();


                    if ( !interactionSessionId.HasValue )
                    {
                        var interactionSession = new InteractionSession();
                        interactionSession.DeviceTypeId = interactionDeviceTypeId.Value;
                        interactionSession.IpAddress = this.IPAddress;
                        interactionSession.Guid = sessionId;
                        interactionSessionService.Add( interactionSession );
                        rockContext.SaveChanges();
                        interactionSessionId = interactionSession.Id;
                    }

                    int componentEntityTypeId = EntityTypeCache.Read<Rock.Model.Page>().Id;
                    string siteName = SiteCache.Read( SiteId ?? 1 ).Name;

                    // lookup the interaction channel, and create it if it doesn't exist
                    int channelMediumTypeValueId = DefinedValueCache.Read( SystemGuid.DefinedValue.INTERACTIONCHANNELTYPE_WEBSITE.AsGuid() ).Id;

                    // check that the site exists as a channel
                    var interactionChannelId = interactionChannelService.Queryable()
                                                        .Where( a => 
                                                            a.ChannelTypeMediumValueId == channelMediumTypeValueId 
                                                            && a.ChannelEntityId == this.SiteId )
                                                        .Select( a => (int?)a.Id )
                                                        .FirstOrDefault();

                    if ( !interactionChannelId.HasValue )
                    {
                        var interactionChannel = new InteractionChannel();
                        interactionChannel.Name = siteName;
                        interactionChannel.ChannelTypeMediumValueId = channelMediumTypeValueId;
                        interactionChannel.ChannelEntityId = this.SiteId;
                        interactionChannel.ComponentEntityTypeId = componentEntityTypeId;
                        interactionChannelService.Add( interactionChannel );
                        rockContext.SaveChanges();
                        interactionChannelId = interactionChannel.Id;
                    }

                    // check that the page exists as a component
                    var interactionComponentId = interactionComponentService.Queryable()
                                                        .Where( a => 
                                                            a.EntityId == PageId 
                                                            && a.ChannelId == interactionChannelId.Value )
                                                            .Select( a => (int?)a.Id )
                                                        .FirstOrDefault();

                    if ( !interactionComponentId.HasValue )
                    {
                        var interactionComponent = new InteractionComponent();
                        interactionComponent.Name = PageTitle;
                        interactionComponent.EntityId = PageId;
                        interactionComponent.ChannelId = interactionChannelId.Value;
                        interactionComponentService.Add( interactionComponent );
                        rockContext.SaveChanges();
                        interactionComponentId = interactionComponent.Id;
                    }
                                      
                    // add the interaction
                    Interaction interaction = new Interaction();
                    interactionService.Add( interaction );

                    // obfuscate rock magic token
                    Regex rgx = new Regex( @"rckipid=([^&]*)" );
                    string cleanUrl = rgx.Replace( this.Url, "rckipid=XXXXXXXXXXXXXXXXXXXXXXXXXXXX" );

                    interaction.InteractionData = cleanUrl;
                    interaction.Operation = "View";
                    interaction.PersonAliasId = this.PersonAliasId;
                    interaction.InteractionDateTime = this.DateViewed;
                    interaction.InteractionSessionId = interactionSessionId;
                    interaction.InteractionComponentId = interactionComponentId.Value;
                    rockContext.SaveChanges();
                }
            }
        }
    }
}