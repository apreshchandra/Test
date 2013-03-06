<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="GenderWiseDrillDown.aspx.cs"
    Inherits="DigiMa.Analytics.GenderWiseDrillDown" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajax" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../Styles/style.css" rel="stylesheet" type="text/css" />
    <link href="../Styles/style_new_menu.css" rel="stylesheet" type="text/css" />
    <link href="../Styles/menu_style.css" rel="stylesheet" type="text/css" />
    <style>
        body
        {
            font-family: "Lucida Grande" , "Lucida Sans Unicode" , "Helvetica";
            font-size: 12px;
            line-height: 20px;
            font-weight: normal;
            color: #333333;
            background-color: #1b1b1b;
            text-align: left;
            padding: 0px;
            margin: 0px;
        }
        .menusubinsidepages
        {
            margin-top: 68px;
            width: 710px;
            height: 50px;
            position: relative;
            float: left;
            background: url('../images/submenubg.png');
            background-repeat: no-repeat;
            margin-left:100PX;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <div class="leftdivinsidePages">
            <div class="menusubinsidepages">
                <div>
                    <div id="ddtopmenubar" class="mattblackmenu">
                        <ul>
                            <li><a href="../Home.aspx" class="select">Home</a></li>
                            <li><a href="../About.aspx">About us</a></li>
                            <li><a href="../ProductSuite.aspx" rel="ddsubmenu5">Product Suite</a></li>
                            <li><a href="../Contact.aspx" rel="ddsubmenu8">Contact us</a></li>
                        </ul>
                    </div>
                </div>
            </div>
            <table align="center" style="margin-left:100px;">
                <tr align="center">
                    <td align="center">
                        <asp:GridView ID="GridView1" runat="server" AllowPaging="true" ForeColor="black"
                            BackColor="#E6E6FA" AlternatingRowStyle-BackColor="White" HeaderStyle-BackColor="#607C6E"
                            HeaderStyle-ForeColor="Black" Width="1000px" HeaderStyle-Height="25px" RowStyle-Height="20px"
                            OnPageIndexChanging="GridView1_PageIndexChanging" PageSize="20" BorderColor="Black"
                            BorderStyle="Solid" BorderWidth="1px" Font-Names="Lucida Grande" Font-Size="9pt">
                            <AlternatingRowStyle />
                            <HeaderStyle BackColor="#607C6E" ForeColor="White" Font-Names="Lucida Grande" Font-Size="10pt"
                                Height="25px"></HeaderStyle>
                            <RowStyle Height="20px" />
                        </asp:GridView>
                    </td>
                </tr>
            </table>
        </div>
    </form>
    <div>
        <img src="~/images/spacer.png" height="5" width="100%" alt="" /></div>
</body>
</html>
