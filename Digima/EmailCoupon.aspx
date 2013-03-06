<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EmailCoupon.aspx.cs" Inherits="DigiMa.EmailCoupon" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <script src="ScriptsSonetReach/jquery-1.4.1.js" type="text/javascript"></script>
    <script src="ScriptsSonetReach/jquery-1.7.1.min.js" type="text/javascript"></script>
    <script src="ScriptsSonetReach/jquery-ui-1.8.17.custom.min.js" type="text/javascript"></script>
    <title>Email Coupon</title>
    <style type="text/css">
        .snBBBody
        {
            width: 380px;
            border: 0px solid Red;
        }
        .defaultPageStyle
        {
            font-family: "Segoe UI" ,Arial,Helvetica,sans-serif;
            font-size: 11px;
            border: 1px solid black;
            width: 100%;
            background-color: #d5e7f5;
        }
        .defaultFacebookButtonGeorgiaAquarium
        {
            background-image: url("../images/tab_1.png");
            background-position: 0 0;
            background: #0066cc;
            border-color: #000000;
            border-width: 2px;
            color: #fff;
            cursor: pointer;
            padding: 7px 7px;
            font-size: 11px;
            font-family: "Segoe UI" ,Arial,Helvetica,sans-serif;
            -moz-border-radius: 2px;
            -webkit-border-radius: 2px;
            -khtml-border-radius: 2px;
            text-decoration: none;
            text-align: justify;
            font-weight: bold;
            padding-left: 7px;
            padding-right: 7px;
            padding-top: 7px;
            padding-bottom: 7px;
            border: 1px solid #fff;
            border-radius: 4px;
        }
        .defaultFacebookButtonGeorgiaAquariumCancelButtonLink
        {
            background-position: 0 0;
            background: #E3CF57;
            border-color: #000000;
            border-width: 2px;
            color: #000080;
            cursor: pointer;
            font-size: 12px;
            font-family: Tahoma;
            text-decoration: none;
            text-align: justify;
            font-weight: bold;
            padding-left: 6px;
            padding-right: 6px;
            padding-top: 3px;
            padding-bottom: 3px;
            height: 40px;
        }
        .defaultPostContetPageStyle
        {
            font-family: "Segoe UI" ,Arial,Helvetica,sans-serif;
            font-size: 11px;
            border: 0px solid black;
            width: 360px;
        }
        
        .defaultSeeAllProductsStyle
        {
            width: 100%;
            background-color: #3B5998;
            color: White;
            padding: 5px;
            font-size: 14px;
            font-weight: bold;
        }
        .ActionLinks
        {
            float: right;
            padding-bottom: 5px;
        }
        .defaultFacebookButton
        {
            background-position: 0 0;
            background: #923030 none repeat scroll 0 0;
            border-color: #3B5998 #5973A9;
            border-style: solid;
            border-width: 1px;
            color: #FFFF00;
            cursor: pointer;
            font-size: 13px;
            font-family: Tahoma;
            text-decoration: none;
            padding-left: 6px;
            padding-right: 6px;
            padding-top: 3px;
            padding-bottom: 3px;
        }
        .defaultHeadingLabelStyle
        {
            background-color: #D2D9E6;
            color: #3B5998;
            padding: 5px;
            font-size: 12px;
        }
        .defaultActionButtonsContentStyle
        {
            height: 34px;
            text-align: right;
            padding-right: 5px;
        }
        .defaultFacebookButton
        {
            background-position: 0 0;
            background: #923030 none repeat scroll 0 0;
            border-color: #3B5998 #5973A9;
            border-style: solid;
            border-width: 1px;
            color: #FFFF00;
            cursor: pointer;
            font-size: 13px;
            font-family: Tahoma;
            text-decoration: none;
            padding-left: 6px;
            padding-right: 6px;
            padding-top: 3px;
            padding-bottom: 3px;
        }
        .defaultPostTextTitleStyle
        {
            color: #3B5998;
            font-weight: bold;
        }
        .defaultPostTextCaptionStyle
        {
            color: #808080;
        }
        .defaultPostTextContentStyle
        {
            color: #808080;
            text-align: justify;
        }
        .defaultTextBoxStyle
        {
            width: 100%;
        }
        .defaultLabelStyle
        {
            width: 80px;
            vertical-align: top;
            font-size: 11px;
            padding-left: 5px;
            padding-top: 5px;
        }
        .defaultValueStyle
        {
            padding-top: 5px;
        }
        .defaultErrorMessage
        {
            color: Red;
            font-size: 11px;
        }
        #txtLeadEmailID
        {
            background: none repeat scroll 0 0 #FFFFFF;
            border: 1px solid #DDDDDD;
            border-radius: 3px 3px 3px 3px;
            outline: medium none;
            padding: 5px;
        }
    </style>
    <script type="text/javascript">
        function CloseMe() {
            window.close();
            return false;
        }


        $(document).ready(function () {
            $("#imgMain").attr('height', '285px');
            $("#imgMain").attr('width', '585px');
            $(".ActionImg").hide();
        });
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div id="mainBody">
        <table class="defaultPageStyle" cellpadding="0" cellspacing="0">
            <tr>
                <td class="defaultSeeAllProductsStyle">
                    Email Coupon
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Literal ID="litEmailbody" runat="server"></asp:Literal>
                </td>
            </tr>
            <tr>
                <td>
                    <b>Send Coupon To Email :</b>
                    <asp:TextBox ID="txtLeadEmailID" runat="server" Width="220px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td colspan="2" class="defaultActionButtonsContentStyle">
                    <asp:Button CssClass="defaultFacebookButtonGeorgiaAquarium" ID="BtnSubmit" runat="server"
                        Text="Send & Close" OnClick="BtnSubmit_Click" />
                    <input type="button" id="BtnCancel" onclick="CloseMe()" value="Cancel" class="defaultFacebookButtonGeorgiaAquarium" />
                    <%--<a href="#" class="defaultFacebookButtonGeorgiaAquariumCancelButtonLink" id="BtnCancel" onclick="javascript:window.close(); return false;">Cancel</a>--%>
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
