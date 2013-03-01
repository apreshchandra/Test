<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PrintCoupon.aspx.cs" Inherits="DigiMa.PrintCoupon" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <script src="ScriptsSonetReach/jquery-1.4.1.js" type="text/javascript"></script>
    <style >
        #divprint
        {
            display: block;
            font-family: "Segoe UI" ,Arial,Helvetica,sans-serif;
            height: 394px;
            padding-top: 22px;
            width: 550px;
        }
    </style>
    <style media="print">
        .hide_print
        {
            display: none;
        }
        #divprint
        {
            background-image: url("Images/coupon_scissor_border_edit1.png");
            display: block;
            font-family: "Segoe UI" ,Arial,Helvetica,sans-serif;
            height: 394px;
            padding-top: 22px;
            width: 550px;
        }
    </style>
    <script>
        $(document).ready(function () {
            $("#imgMain").css('height', '285px');
            $("#imgMain").css('width', '585px');
            $(".ActionImg").hide();
        });
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div id="divprint" align="center">
        <asp:Literal ID="litPRinter" runat="server"></asp:Literal>
    </div>
    <div>
        <table>
            <tr align="center">
                <td colspan="2" align="center">
                    <span class="hide_print">
                        <asp:Button ID="Button1" runat="server" OnClick="btnPrint" Style="margin-left: 250px;
                            margin-top: 25px; background-image: url('Images/print.png'); width: 95px; height: 25px;
                            display: block; border: 0 none; cursor: pointer;" />
                    </span>
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
