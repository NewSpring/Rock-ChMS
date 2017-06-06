﻿<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ModelMap.ascx.cs" Inherits="RockWeb.Blocks.Examples.ModelMap" %>

<asp:UpdatePanel ID="upPanel" runat="server">
    <ContentTemplate>
        <div class="panel panel-block">
            <div class="panel-heading">
                <h1 class="panel-title"><i class="fa fa-object-ungroup"></i> Model Map</h1>
            </div>
            <div class="panel-body">
                <div class="list-as-blocks clearfix">
                    <ul>
                        <asp:Repeater ID="rptCategory" runat="server">
                            <ItemTemplate>
                                <li class='<%# GetCategoryClass( Eval("Guid") ) %>'>
                                    <asp:LinkButton ID="lbCategory" runat="server" CommandArgument='<%# Eval("Guid") %>' CommandName="Display">
                                        <i class='<%# Eval("IconCssClass") %>'></i>
                                        <h3><%# Eval("Name") %> </h3>
                                    </asp:LinkButton>
                                </li>
                            </ItemTemplate>
                        </asp:Repeater>
                    </ul>
                </div>
            </div>


        </div>

        <div class="row">
            <div class="col-md-4">
                <asp:Panel ID="pnlModels" runat="server" CssClass="panel panel-default" Visible="false" >
                    <div class="panel-heading">
                        <h4>
                            <asp:Literal ID="lCategoryName" runat="server" /></h4>
                    </div>
                    <div class="panel-body">
                        <ul class="list-unstyled">
                            <asp:Repeater ID="rptModel" runat="server">
                                <ItemTemplate>
                                    <li class='<%# GetEntityClass( Eval("Id") ) %>'>
                                        <asp:LinkButton ID="lbModel" runat="server" CommandArgument='<%# Eval("Id") %>' CommandName="Display">
                                            <%# Eval("FriendlyName") %> 
                                        </asp:LinkButton>
                                    </li>
                                </ItemTemplate>
                            </asp:Repeater>
                        </ul>
                    </div>
                </asp:Panel>
            </div>
            <div class="col-md-8">

                <asp:Literal ID="lClasses" runat="server" ViewStateMode="Disabled"></asp:Literal>
                
                <asp:Panel ID="pnlKey" runat="server" CssClass="panel panel-default" Visible="false" >
                    <div class="panel-heading">
                        <h4>Key</h4>
                    </div>
                    <div class="panel-body">
                        <div class="row">
                            <div class="col-xs-5 col-sm-3 col-md-2 text-center"><strong class="text-danger">*</strong></div>
                            <div class="col-xs-7 col-sm-9 col-md-10">A required field.</div>
                        </div>
                        <hr />
                        <div class="row">
                            <div class="col-xs-5 col-sm-3 col-md-2 text-center"><span class="fa-stack small"><i class="fa fa-database fa-stack-1x"></i><i class="fa fa-ban fa-stack-2x text-danger"></i></span></div>
                            <div class="col-xs-7 col-sm-9 col-md-10">Not mapped to the database.  These fields are computed and are only available in the object.</div>
                        </div>
                        <hr />
                        <div class="row">
                            <div class="col-xs-5 col-sm-3 col-md-2 text-center"><small><span class="tip tip-lava"></span></small></div>
                            <div class="col-xs-7 col-sm-9 col-md-10">These fields are available where Lava is supported.</div>
                        </div>
                    </div>
                </asp:Panel>

            </div>
        </div>



        <script type="text/javascript">
            Sys.Application.add_load(function () {
                // Hide and unhide inherited properties and methods
                $('.js-model-inherited').on('click', function () {
                    $(this).find('i.js-model-check').toggleClass('fa-check-square-o fa-square-o');
                    $(this).parent().find('li.js-model').toggleClass('non-hidden hidden ');
                });

            });
        </script>
    </ContentTemplate>
</asp:UpdatePanel>

