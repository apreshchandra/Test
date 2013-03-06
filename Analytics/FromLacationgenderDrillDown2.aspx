<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FromLacationgenderDrillDown2.aspx.cs"
    Inherits="DigiMa.Analytics.FromLocationDrillDown2" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="stylesheet" type="text/css" href="~/Styles/master_style.css" />
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
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <div class="masterwrapper">
            <div class="sonetlogo">
                <a id="A1" href="../LandingPage.aspx" runat="server">
                    <img src="../Images/logo.png" border="0" alt="SonetReach" /></a></div>
        </div>
        <div class="clr">
        </div>
        <div style="padding-top: 10px;">
            <img src="../images/greytop_border.png" height="4" width="100%" alt="" /></div>
         <div class="backwrapper">
            <%--<a href="#" class="backlink" onclick="Back_Click" runat="server">Back</a></div>--%>
            <asp:LinkButton ID="lnkBack" runat="server" Text="Back" OnClick="vid_Click" CssClass="backlink"></asp:LinkButton></div>
        <table align="center">
            <tr align="center">
                <td align="center">
                    <%--<asp:GridView ID="GridView1" runat="server" AllowPaging="true" ForeColor="black"
                        BackColor="White" AlternatingRowStyle-BackColor="#DDBFF5" HeaderStyle-BackColor="#8709B5"
                        HeaderStyle-ForeColor="White" Width="1000px" OnPageIndexChanging="GridView1_PageIndexChanging">
                        <AlternatingRowStyle />
                    </asp:GridView>--%>
                    <asp:GridView ID="GridView1" runat="server" AllowPaging="true" ForeColor="black"
                        BackColor="#E6E6FA" AlternatingRowStyle-BackColor="White" HeaderStyle-BackColor="#607C6E"
                        HeaderStyle-ForeColor="Black" Width="1000px" HeaderStyle-Height="25px" RowStyle-Height="20px"
                        OnPageIndexChanging="GridView1_PageIndexChanging" PageSize="20" 
                        BorderColor="Black" BorderStyle="Solid" BorderWidth="1px" 
                        Font-Names="Lucida Grande" Font-Size="9pt">
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
    <div class="footercopy">
        Copyright <a href="http://www.smnetserv.com/" target="_blank" class="url">SM NetServ
            Technologies Pvt Ltd</a> 2012 - Offshore Software Development Company, India</div>
</body>
</html>
