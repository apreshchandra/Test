<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AppBuilder.aspx.cs" Inherits="DigiMa.AppBuilder" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>CONFIGURE FACEBOOK</title>
    <link href="Styles/Site.css" rel="stylesheet" type="text/css" />
</head>
<body style="background: url(Images/Main_body_BG.png) repeat-x; color: White;">
    <form id="form1" runat="server">
    <div>
    <h2>SETTING UP FACEBOOK APP</h2>
        <table style="margin-left: 400px; border: 1px solid #fff;" cellpadding="2" cellspacing="2">
            <tr>
                <td>
                    Enter App ID
                </td>
                <td>
                    <asp:TextBox ID="txtAppID" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    Enter App Key
                </td>
                <td>
                    <asp:TextBox ID="txtAppKey" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    Enter AppSecret
                </td>
                <td>
                    <asp:TextBox ID="txtAppSecret" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    Enter App Name
                </td>
                <td>
                    <asp:TextBox ID="txtAppName" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    Enter App Path
                </td>
                <td>
                    <asp:TextBox ID="txtAppPath" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr align="center">
                <td colspan="2">
                    <asp:Button ID="btnSubmit" runat="server" Text="Submit" OnClick="btnSubmit_Click"
                        CssClass="canvasButtons"></asp:Button>
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
