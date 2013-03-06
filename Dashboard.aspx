<%@ Page Language="C#" AutoEventWireup="true" Inherits="DigiMa.Dashboard" CodeBehind="Dashboard.aspx.cs" %>

<html>
<head>
    <title></title>
    <script src="Scripts/jquery-1.5.1.js" type="text/javascript"></script>
    <script src="Scripts/jquery.fancybox.js" type="text/javascript"></script>
    <link href="CSS/GrigStyles.css" rel="stylesheet" type="text/css" />
    <link href="CSS/jquery.fancybox.css" rel="stylesheet" type="text/css" />
    <link href="Styles/style.css" rel="stylesheet" type="text/css" />
    <link href="Styles/menu_style.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript">
        $(document).ready(function () {
            (function ($, F) {
                F.transitions.dropOut = function () {
                    document.getElementById('<%=btnRefreshGrid.ClientID%>').click();
                    $.fancybox.close();
                };
            } (jQuery, jQuery.fancybox));



            $('.fancybox').fancybox({
                autoSize: false,
                width: 700,
                height: 300,
                closeMethod: 'dropOut'
            });
        });
        function closeFancyPopup() {
            $.fancybox.close();
        }
    </script>
    <style type="text/css">
        .menubg
        {
            margin-top: 0px;
            width: 710px;
            height: 400px;
            position: relative;
            float: left;
            background: url('../images/submenubg.png');
            background-repeat: no-repeat;
        }
        .hide
        {
            display: none;
        }
        .pageheader
        {
            font-family: Segoe UI Light,Segoe UI,Tahoma,Arial,Verdana,sans-serif;
            font-size: 26px;
            color: #828386;
            font-weight: bold;
        }
        .heading
        {
            font-family: Segoe UI Light,Segoe UI,Tahoma,Arial,Verdana,sans-serif;
            font-size: 20px;
            color: #4F4F4F;
            text-decoration: underline;
            margin-left: -10px;
        }
        .text
        {
            font-family: Segoe UI,Tahoma,Arial,Verdana,sans-serif;
            color: Black;
            font-size: 13px;
        }
        .link
        {
            font-family: Segoe UI,Tahoma,Arial,Verdana,sans-serif;
            color: #0060A6;
            text-decoration: none;
            font-size: 13px;
        }
        .link:hover
        {
            text-decoration: underline;
        }
        .emptydatatext
        {
            font-family: Segoe UI,Tahoma,Arial,Verdana,sans-serif;
            color: Black;
            font-size: 16px;
            padding-top: 30px;
            height: 120px;
            vertical-align: bottom;
        }
    </style>
</head>
<body>
    <form runat="server">
    <asp:AdRotator ID="adRot" runat="server" />
    <div id="wrapper">
        <div class="leftdiv">
            <div class="logo">
                <img src="images/logo.png" /></div>
            <div class="menubg">
                <div>
                    <div id="ddtopmenubar" class="mattblackmenu">
                        <ul>
                            <li><a href="Home.aspx" class="select">Home</a></li>
                            <li><a href="AboutUs.aspx">About us</a></li>
                            <li><a href="ProductSuite.aspx" rel="ddsubmenu5">Product Suite</a></li>
                            <li><a href="Contact.aspx" rel="ddsubmenu8">Contact us</a></li>
                        </ul>
                    </div>
                </div>
                <asp:UpdatePanel runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                        <table width="100%">
                            <tr>
                                <td style="padding-top: 10px; padding-left: 30px">
                                    <span class="pageheader">Dashboard:</span>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Button ID="btnRefreshGrid" runat="server" CssClass="hide" />
                                </td>
                            </tr>
                            <tr>
                                <td align="center">
                                    <br />
                                    <table width="700px">
                                        <tr>
                                            <td>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <span class="heading">List of Sites:</span>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="height: 285px; vertical-align: top; text-align: center">
                                                <asp:GridView ID="grdUnCompletedSites" runat="server" GridLines="None" HorizontalAlign="Center"
                                                    Width="800px" CellPadding="4" AutoGenerateColumns="false" AllowPaging="True"
                                                    AllowSorting="true" PageSize="5" OnRowCommand="grdUnCompletedSites_RowCommand"
                                                    OnPageIndexChanging="grdUnCompletedSites_OnPageIndexChanging" EmptyDataText="No Sites available">
                                                    <AlternatingRowStyle CssClass="GridAlternatingRowStyle" HorizontalAlign="Left" />
                                                    <EmptyDataRowStyle CssClass="emptydatatext" />
                                                    <Columns>
                                                        <asp:TemplateField HeaderText="Site Name" ItemStyle-Width="100px" ItemStyle-Height="20px"
                                                            SortExpression="SiteName" ItemStyle-HorizontalAlign="Left" HeaderStyle-CssClass="GridHeader">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblFirstName" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "SiteName")%>'
                                                                    CssClass="text" ToolTip='<%# String.Format("{0} aiis",Eval("SiteName")) %>'></asp:Label>
                                                            </ItemTemplate>
                                                            <ItemStyle HorizontalAlign="Left" Height="20px" Width="100px"></ItemStyle>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Template Used" ItemStyle-Width="100px" ItemStyle-Height="20px"
                                                            SortExpression="Template Used" ItemStyle-HorizontalAlign="Left" HeaderStyle-CssClass="GridHeader">
                                                            <ItemTemplate>
                                                                <asp:Label runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "TemplateName")%>'
                                                                    CssClass="text"></asp:Label>
                                                            </ItemTemplate>
                                                            <ItemStyle HorizontalAlign="Left" Height="20px" Width="100px"></ItemStyle>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="" ItemStyle-Width="100px" ItemStyle-Height="20px"
                                                            SortExpression="View" ItemStyle-HorizontalAlign="Left" HeaderStyle-CssClass="GridHeader">
                                                            <ItemTemplate>
                                                                <a href='<%# DataBinder.Eval(Container.DataItem, "PreviewPath")%>' target="_blank"
                                                                    class="link">Preview</a>
                                                            </ItemTemplate>
                                                            <ItemStyle HorizontalAlign="Left" Height="20px" Width="100px"></ItemStyle>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="" ItemStyle-Width="100px" ItemStyle-Height="20px"
                                                            SortExpression="Edit" ItemStyle-HorizontalAlign="Left" HeaderStyle-CssClass="GridHeader">
                                                            <ItemTemplate>
                                                                <a href='<%# DataBinder.Eval(Container.DataItem, "TemplateEditPath")%>' class="link">
                                                                    Edit</a>
                                                            </ItemTemplate>
                                                            <ItemStyle HorizontalAlign="Left" Height="20px" Width="100px"></ItemStyle>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="" ItemStyle-Width="100px" ItemStyle-Height="20px"
                                                            SortExpression="Delete" ItemStyle-HorizontalAlign="Left" HeaderStyle-CssClass="GridHeader">
                                                            <ItemTemplate>
                                                                <asp:LinkButton runat="server" ValidationGroup='<%# DataBinder.Eval(Container.DataItem, "SiteId")%>'
                                                                    CssClass="link" CommandName="DELETESITE" Text="Delete" OnClientClick=" return confirm('Are you sure want to Delete the site- '+this.parentNode.childNodes[3].innerHTML.trim())"></asp:LinkButton>
                                                                <span id="spanSiteName" style="display: none">
                                                                    <%# DataBinder.Eval(Container.DataItem, "SiteName")%></span>
                                                            </ItemTemplate>
                                                            <ItemStyle HorizontalAlign="Left" Height="20px" Width="100px"></ItemStyle>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="" ItemStyle-Width="100px" ItemStyle-Height="20px"
                                                            SortExpression="DownloadWay" ItemStyle-HorizontalAlign="Left" HeaderStyle-CssClass="GridHeader">
                                                            <ItemTemplate>
                                                                <a href='<%# DataBinder.Eval(Container.DataItem, "DownloadWay")%>' class="link">Download</a>
                                                            </ItemTemplate>
                                                            <ItemStyle HorizontalAlign="Left" Height="20px" Width="100px"></ItemStyle>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="" ItemStyle-Width="100px" ItemStyle-Height="20px"
                                                            SortExpression="Assign" ItemStyle-HorizontalAlign="Left" HeaderStyle-CssClass="GridHeader">
                                                            <ItemTemplate>
                                                                <a href="<%# DataBinder.Eval(Container.DataItem, "AssignTo")%>" class="fancybox fancybox.iframe link">
                                                                    <span>Assign To</span></a>
                                                            </ItemTemplate>
                                                            <ItemStyle HorizontalAlign="Left" Height="20px" Width="100px"></ItemStyle>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="" ItemStyle-Width="100px" ItemStyle-Height="20px"
                                                            SortExpression="Finish" ItemStyle-HorizontalAlign="Left" HeaderStyle-CssClass="GridHeader">
                                                            <ItemTemplate>
                                                                <asp:LinkButton runat="server" ValidationGroup='<%# DataBinder.Eval(Container.DataItem, "SiteId")%>'
                                                                    CssClass="link" CommandName="FINISHSITE" Text="Finish" OnClientClick=" return confirm('Are you sure want to Finish the site- '+this.parentNode.childNodes[3].innerHTML.trim())"></asp:LinkButton>
                                                                <span id="spanSiteName" style="display: none">
                                                                    <%# DataBinder.Eval(Container.DataItem, "SiteName")%></span>
                                                            </ItemTemplate>
                                                            <ItemStyle HorizontalAlign="Left" Height="20px" Width="100px"></ItemStyle>
                                                        </asp:TemplateField>
                                                    </Columns>
                                                    <EditRowStyle CssClass="GridEditRowStyle" HorizontalAlign="Left" />
                                                    <FooterStyle CssClass="GridFooterStyle" />
                                                    <HeaderStyle CssClass="GridHeaderStyle" VerticalAlign="Middle" HorizontalAlign="Left" />
                                                    <PagerStyle CssClass="GridPagerStyle" HorizontalAlign="Right" Wrap="false" />
                                                    <RowStyle CssClass="GridRowStyle" HorizontalAlign="Left" />
                                                    <SelectedRowStyle CssClass="GridSelectedRawStyle" />
                                                    <SortedAscendingCellStyle CssClass="GridSortedAscendingCellStyle" />
                                                    <SortedAscendingHeaderStyle CssClass="GridSortedAscendingHeaderStyle" />
                                                    <SortedDescendingCellStyle CssClass="GridSortedDescendingCellStyle" />
                                                    <SortedDescendingHeaderStyle CssClass="GridSortedDescendingHeaderStyle" />
                                                </asp:GridView>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <table cellpadding="0" cellspacing="0" width="100%" runat="server" id="tblFinishedSites">
                                                    <tr>
                                                        <td>
                                                            <span class="heading">Facebook Apps:</span>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="text-align: center">
                                                            <asp:GridView ID="grdAnalytics" runat="server" AutoGenerateColumns="false" GridLines="None"
                                                                BorderStyle="Solid" BorderColor="#5FCDF6" OnRowCommand="GridView_RowCommand"
                                                                CssClass="mGrid" AlternatingRowStyle-HorizontalAlign="Center" RowStyle-HorizontalAlign="Center"
                                                                AlternatingRowStyle-VerticalAlign="Middle" RowStyle-VerticalAlign="Middle" ShowHeaderWhenEmpty="true"
                                                                EmptyDataText="No Data to display" Width="98%" PageSize="5">
                                                                <Columns>
                                                                    <asp:BoundField DataField="CustomTabName" HeaderText="App Name" ItemStyle-Width="100px" />
                                                                    <asp:BoundField DataField="CreatedDT" HeaderText="Created On" DataFormatString="{0:dd-MM-yyyy}"
                                                                        HtmlEncode="false" />
                                                                    <asp:BoundField DataField="AppStatus" HeaderText="Status" />
                                                                    <asp:BoundField DataField="AppExpiryDT" HeaderText="Expires On" DataFormatString="{0:dd-MM-yyyy}"
                                                                        HtmlEncode="false" />
                                                                    <asp:TemplateField>
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton ID="showAnalytics" runat="server" CommandName="Analytics" CommandArgument='<%#Eval("AppID") %>'
                                                                                Text="View Analytics" Width="140px" Font-Underline="true" ForeColor="#5FCDF6">
                                                                            </asp:LinkButton>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField>
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton ID="editCampaign" runat="server" CommandName="Edit" CommandArgument='<%#Eval("AppID") %>'
                                                                                Text="Edit" Width="140px" Font-Underline="true" ForeColor="#5FCDF6">
                                                                            </asp:LinkButton>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                </Columns>
                                                                <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" ForeColor="#f7c357" />
                                                                <AlternatingRowStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                                                <RowStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                                            </asp:GridView>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:Button ID="btnCreate" runat="server" Text="Create" />
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                        </table>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
        </div>
    </div>
    </form>
</body>
</html>
