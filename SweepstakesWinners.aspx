<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SweepstakesWinners.aspx.cs"
    Inherits="DigiMa.SweepstakesWinners" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style>
        .WinnerTable
        {
            background-image: url(Images/backgroundimg.png);
            background-repeat:no-repeat;
            text-align: center;
            width: 95%;          
            height:625px;
         
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <table id="tblMain" align="center" class="WinnerTable">
        <tr>
            <td>
                Winners of Sweepstakes are :
            </td>
        </tr>
        <tr>
            <td align="center" valign="top">
                <div>
                    <asp:Repeater ID="rptSweepWinners" runat="server" OnItemDataBound="rptSweepWinners_ItemDataBound">
                        <ItemTemplate>
                         
                            <table bgcolor="#cccccc" cellpadding="4" cellspacing="1">
                                <tr>
                                    <td colspan="1" style="text-align: center; background-color: #fff;">
                                        <asp:Label runat="server">Position</asp:Label>
                                    </td>
                                    <td colspan="1" style="text-align: center; background-color: #fff;">    
                                        <asp:Label runat="server">Photo</asp:Label>
                                    </td>
                                    <td colspan="1" style="text-align: center; background-color: #fff;">
                                        <asp:Label runat="server">Name </asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="background-color: #fff;text-align:center;">
                                        <asp:Label ID="lblCount" runat="server" />
                                    </td>
                                    <td  style="background-color: #fff;">
                                        <asp:Image ID="imgThumb" runat="server" />
                                    </td>
                                    <td  style="background-color: #fff;">
                                        <asp:Label ID="lblName" runat="server" />
                                    </td>
                                </tr> 
                            </table>
                        </ItemTemplate>
                    </asp:Repeater>
                </div>
            </td>
        </tr>
    </table>
    </form>
</body>
</html>
