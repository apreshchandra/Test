<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SelectPage.aspx.cs" Inherits="DigiMa.SelectPage" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script type="text/javascript" src="ScriptsSonetReach/jquery-1.4.1.min.js"></script>
    <script type="text/javascript" src="ScriptsSonetReach/jquery-ui-1.8.17.custom.min.js"></script>
    <script type="text/javascript" src="https://ajax.googleapis.com/ajax/libs/jqueryui/1.8.16/jquery-ui.js"></script>
    <style>
        .labels
        {
            color: White;
            text-shadow: 1px 1px 1px #fff;
            font-weight: bold;
            padding: 5px 5px 5px 10px;
            font-family: Helvetica;
        }
        #pageSelect
        {
            text-align: center;
            background-color: #8f1313;
            color: #FFFFFF;
            font-size: 24px;
            text-shadow: 1px 1px 1px #fff;
            font-weight: bold;
            float: left;
            width: 745px;
            padding: 5px 5px 5px 10px;
            margin: 1px 0px;
            border-bottom: 1px solid #fff;
            border-top: 1px solid #d9d9d9;
            font-family: "Segoe UI" ,Arial,Helvetica,sans-serif;
        }
        #btnPageSelect
        {
            background-image: url("images/publish_to_facebook.png");
            background-repeat: no-repeat;
            border: 0 none;
            border-radius: 8px;
            cursor: pointer;
            display: block;
            height: 25px;
            line-height: 25px;
            margin: 0;
            text-align: center;
            text-decoration: none;
            vertical-align: middle;
            width: 152px;
        }
        .dropdowns
        {
            color: White;
            background-color: #8F1313;
            border-radius: 4px;
            font-family: Microsoft YaHei;
            width: 200px;
        }
        #lblNoPage
        {
            background-color: #f0f0f0;
            color: #666;
            text-shadow: 1px 1px 1px #fff;
            font-weight: bold;
            padding: 5px 5px 5px 10px;
            font-family: "Segoe UI" ,Arial,Helvetica,sans-serif;
        }
        .Tweeter
        {
            background-image: url("Images/tweet.jpg");
            margin-right: 30px;
            padding-left: 20px;
            padding-right: 12px;
            padding-top: 21px;
            background-repeat: no-repeat;
            display: block;
        }
        .lblTwitter
        {
            background-color: #F0F0F0;
            color: #666666;
            font-family: "Segoe UI" ,Arial,Helvetica,sans-serif;
            font-weight: bold;
            padding: 5px 5px 5px 10px;
            text-shadow: 1px 1px 1px #FFFFFF;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server" style="background-color: #e5e5e5;">
    <div style="text-align: center;">
        <div id="pageSelect" runat="server" style="text-align: center; margin-left: 10PX;">
            <table id="tblPageSelect" runat="server" cellpadding="2" width="70%">
                <tr align="center">
                    <td colspan="4">
                        Select the Page to host your Campaign
                    </td>
                </tr>
                <tr align="center">
                    <td align="center" colspan="1">
                        <asp:DropDownList ID="ddlPageSelect" runat="server" AutoPostBack="True" CssClass="dropdowns"
                            CausesValidation="False">
                            <asp:ListItem Text="Select Page" Selected="True" Value="">
                            </asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <td align="center" colspan="1">
                        <asp:RequiredFieldValidator ID="rfvSelectPage" ControlToValidate="ddlPageSelect"
                            runat="server" Display="None" ErrorMessage="Please select a Page Name!" ValidationGroup="vGRoupBody"></asp:RequiredFieldValidator>
                    </td>
                    <td align="center" colspan="1">
                        <asp:Button ID="btnPageSelect" runat="server" OnClick="btnPageSelect_Click" ValidationGroup="vGRoupBody" />
                    </td>
                    <td align="center" colspan="1">
                        <asp:ValidationSummary ID="ValidationSummary1" runat="server" ValidationGroup="vGRoupBody"
                            ShowMessageBox="true" ShowSummary="false" Class="valSummaryBody" />
                    </td>
                </tr>
            </table>
            <table id="tblResult" runat="server" visible="false" style="color: #f7c357; width: 70%;
                margin-left: 96px;">
                <tr>
                    <td colspan="4">
                        <asp:Label ID="lblResult" runat="server" CssClass="labels"></asp:Label>
                        <a id="linkToCamp" runat="server" target="_blank" style="color: palegreen;">HERE</a>
                    </td>
                </tr>
                <tr>
                    <td colspan="4">
                        <asp:Label ID="lblInformation" runat="server" CssClass="labels"></asp:Label>
                    </td>
                </tr>
            </table>
            <table id="tblTweet" runat="server" visible="false" style="color: #f7c357; width: 70%;">
                <tr>
                    <td colspan="4">
                        <asp:Label ID="Label1" CssClass="lblTwitter" runat="server">Tweet on your Twitter Profile</asp:Label>
                    </td>
                    <td align="center" colspan="1">
                        <asp:Button ID="btnTweet" runat="server" ValidationGroup="vGRoupBody" OnClick="btnTweet_Click"
                            CssClass="Tweeter" />
                    </td>
                </tr>
            </table>
        </div>
        <div id="noPageFound" runat="server" style="text-align: center; margin-left: -10PX;"
            visible="false">
            <asp:Label ID="lblNoPage" runat="server"></asp:Label>
        </div>
    </div>
    </form>
</body>
</html>
