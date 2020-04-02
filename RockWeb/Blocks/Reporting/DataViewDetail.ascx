﻿<%@ Control Language="C#" AutoEventWireup="true" CodeFile="DataViewDetail.ascx.cs" Inherits="RockWeb.Blocks.Reporting.DataViewDetail" %>
<asp:UpdatePanel ID="upDataView" runat="server">
    <ContentTemplate>

        <asp:Panel ID="pnlDetails" runat="server" Visible="false">
            <asp:HiddenField ID="hfDataViewId" runat="server" />

            <div id="pnlEditDetails" class="panel panel-block" runat="server">

                <div class="panel-heading">
                    <h1 class="panel-title"><i class="fa fa-filter"></i> <asp:Literal ID="lActionTitle" runat="server" /></h1>

                    <div class="panel-labels">
                        <Rock:HighlightLabel ID="hlblEditDataViewId" runat="server" />
                        <div class="label label-primary"><asp:LinkButton ID="lbCreateReport" runat="server" OnClick="lbCreateReport_Click" ><i class="fa fa-plus"></i> Create Report</asp:LinkButton></div>
                    </div>
                </div>
                <div class="panel-body">

                    <asp:ValidationSummary ID="vsDetails" runat="server" HeaderText="Please correct the following:" CssClass="alert alert-validation" />

                    <fieldset>

                        <div class="row">
                            <div class="col-md-6">
                                <Rock:DataTextBox ID="tbName" runat="server" SourceTypeName="Rock.Model.DataView, Rock" PropertyName="Name" CssClass="" />
                                <Rock:DataTextBox ID="tbDescription" runat="server" SourceTypeName="Rock.Model.DataView, Rock" PropertyName="Description" TextMode="MultiLine" Rows="4" />
                                <Rock:EntityTypePicker ID="etpEntityType" runat="server" Label="Applies To" OnSelectedIndexChanged="etpEntityType_SelectedIndexChanged" AutoPostBack="true" EnhanceForLongLists="true" Required="true" />
                            </div>
                            <div class="col-md-6">
                                <Rock:RockDropDownList ID="ddlTransform" runat="server" Label="Post-filter Transformation" />
                                <Rock:CategoryPicker ID="cpCategory" runat="server" EntityTypeName="Rock.Model.DataView" Label="Category" Required="true" />
                                <Rock:RockCheckBox ID="cbIncludeDeceased" runat="server" Label="Include Deceased" Visible="false" />

                                <%-- Persistence Schedule Settings --%>
                                <asp:UpdatePanel runat="server" UpdateMode="Conditional">
                                    <ContentTemplate>
                                        <h5>Speed Settings</h5>
                                        <Rock:Switch ID="swPersistDataView" runat="server" Text="Enable Persistence" BoldText="true" AutoPostBack="true" OnCheckedChanged="swPersistDataView_CheckedChanged" Help="Persisting this dataview may improve performance, especially for complex filters. The results of a persisted dataview are stored and re-used until the scheduled interval has elapsed."  />
                                        
                                        <asp:Panel runat="server" ID="pnlSpeedSettings">
                                            <Rock:RangeSlider ID="rsPersistedScheduleInterval" runat="server" Label="Persistence Interval" MaxValue="24" MinValue="1" SelectedValue="12" />
                                            <Rock:ButtonGroup ID="bgPersistedScheduleUnit" runat="server" CssClass="pull-right margin-b-md" UnselectedItemClass="btn btn-xs btn-default" SelectedItemClass="btn btn-xs btn-primary" AutoPostBack="true" OnSelectedIndexChanged="bgPersistedScheduleUnit_SelectedIndexChanged">
                                                <asp:ListItem Text="Mins" Value="1" />
                                                <asp:ListItem Text="Hours" Value="2" Selected="True" />
                                                <asp:ListItem Text="Days" Value="3" />
                                            </Rock:ButtonGroup>
                                        </asp:Panel>
                                    </ContentTemplate>
                                </asp:UpdatePanel>

                            </div>
                        </div>

                    </fieldset>

                    <asp:PlaceHolder ID="phFilters" runat="server"></asp:PlaceHolder>

                    <Rock:NotificationBox ID="nbPersistError" runat="server" NotificationBoxType="Warning" />

                    <div class="actions">
                        <asp:LinkButton ID="btnSave" runat="server" AccessKey="s" ToolTip="Alt+s" Text="Save" CssClass="btn btn-primary" OnClick="btnSave_Click" />
                        <asp:LinkButton ID="btnCancel" runat="server" AccessKey="c" ToolTip="Alt+c" Text="Cancel" CssClass="btn btn-link" CausesValidation="false" OnClick="btnCancel_Click" />
                        <asp:LinkButton ID="btnPreview" runat="server" Text="Preview" CssClass="btn btn-default pull-right" CausesValidation="false" OnClick="btnPreview_Click" />
                    </div>

                </div>

            </div>

            <div id="pnlViewDetails" runat="server">
                <div class="panel panel-block" runat="server">
                    <div class="panel-heading">
                        <h1 class="panel-title"><i class="fa fa-filter"></i> <asp:Literal ID="lReadOnlyTitle" runat="server" /></h1>
                        <div class="panel-labels">
                             <Rock:HighlightLabel ID="hlblDataViewId" runat="server" />
                             <Rock:HighlightLabel ID="hlblPersisted" LabelType="Info" Text="Persisted" Visible="false" runat="server" />
                            <div class="label label-primary"><asp:LinkButton ID="lbViewCreateReport" runat="server" OnClick="lbCreateReport_Click" ><i class="fa fa-plus"></i> Create Report</asp:LinkButton></div>
                        </div>
                    </div>
                    <Rock:PanelDrawer ID="pdAuditDetails" runat="server"></Rock:PanelDrawer>
                    <div class="panel-body">

                        <fieldset>

                            <div class="description">
                                <asp:Literal ID="lDescription" runat="server"></asp:Literal>
                            </div>

                            <div class="row">
                                <div class="col-md-6">
                                    <asp:Literal ID="lblMainDetails" runat="server" />
                                </div>
                                <div class="col-md-6">
                                    <asp:Literal ID="lFilters" runat="server" />
                                    <asp:Literal ID="lPersisted" runat="server" />
                                    <asp:Literal ID="lDataViews" runat="server" />
                                    <asp:Literal ID="lReports" runat="server" />
                                    <asp:Literal ID="lGroups" runat="server" />
                                </div>
                            </div>

                            <Rock:NotificationBox ID="nbEditModeMessage" runat="server" NotificationBoxType="Warning" />

                            <div class="actions">
                                <asp:LinkButton ID="btnEdit" runat="server" AccessKey="m" ToolTip="Alt+m" Text="Edit" CssClass="btn btn-primary" OnClick="btnEdit_Click" />
                                <asp:LinkButton ID="btnDelete" runat="server" Text="Delete" CssClass="btn btn-link" OnClick="btnDelete_Click" />
                                <div class="pull-right">
                                    <asp:LinkButton ID="btnCopy" runat="server" Tooltip="Copy Data View" CssClass="btn btn-default btn-sm fa fa-clone" OnClick="btnCopy_Click" />
                                    <Rock:SecurityButton ID="btnSecurity" runat="server" class="btn btn-sm btn-security" />
                                </div>
                                <Rock:ModalAlert ID="mdDeleteWarning" runat="server" />
                            </div>

                        </fieldset>
                    </div>

                </div>

                <div class="panel panel-block">
                    <div class="panel-heading">
                        <h1 class="panel-title"><i class="fa fa-table"></i> Results</h1>
                        <div class="panel-labels">
                            <asp:LinkButton ID="btnToggleResults" runat="server" CssClass="btn btn-default btn-xs" OnClick="btnToggleResults_Click" />
                        </div>
                    </div>
                    <asp:Panel ID="pnlResultsGrid" runat="server">
                        <div class="panel-body">
                            <Rock:NotificationBox ID="nbGridError" runat="server" NotificationBoxType="Warning" />
                            <div class="grid grid-panel">
                                <Rock:Grid ID="gReport" runat="server" AllowSorting="true" EmptyDataText="No Results" />
                            </div>
                        </div>
                    </asp:Panel>
                </div>
            </div>

            <Rock:ModalDialog ID="modalPreview" runat="server" Title="Preview (top 15 rows )" ValidationGroup="Preview">
                <Content>
                    <Rock:NotificationBox ID="nbPreviewError" runat="server" NotificationBoxType="Warning" />
                    <div class="grid"><Rock:Grid ID="gPreview" runat="server" AllowSorting="true" EmptyDataText="No Results" ShowActionRow="false" DisplayType="Light" /></div>
                </Content>
            </Rock:ModalDialog>

        </asp:Panel>
    </ContentTemplate>
</asp:UpdatePanel>
