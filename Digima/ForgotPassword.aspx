<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ForgotPassword.aspx.cs"
    Inherits="DigiMa.ForgotPassword" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Forgot Password</title>
    <link href="Styles/master_style.css" rel="stylesheet" type="text/css" />
    <link href="Styles/stylesheet1.css" rel="Stylesheet" type="text/css" />
    <link href="Styles/style_new_menu.css" rel="stylesheet" type="text/css" />
    <link href="Styles/style.css" rel="stylesheet" type="text/css" />
    <link href="Styles/menu_style.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="ScriptsSonetReach/jquery-1.4.1.js"></script>
    <link rel="shortcut icon" href="Images/sonetreachicon.ico" />
    <!--[if IE ]>
	<link rel="stylesheet" type="text/css" href="Styles/ie7.css" />
<![endif]-->

    <style type="text/css">
        .logo
        {
            float: left;
            width: 250px;
            margin-bottom:2px;
            margin-left: 1px;
            margin-top: 3px;
            display:block;
        }
        .menusubinsidepages
        {
            background: url("Images/submenubg.png") no-repeat scroll 0 0 transparent;
            float: left;
            height: 50px;
            margin-left: 245px;
            margin-top: 49px;
            position: relative;
            width: 710px;
        }
        .mattblackmenu
        {
            left: 76px;
            position: absolute;
            top: 5px;
        }
         .mattblackmenu
        {
            left: 76px;
            position: absolute;
            top: 5px;
        }
        
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
        .button
        {
            width: auto;
            -webkit-border-radius: .5em;
            -moz-border-radius: .5em;
            border-radius: .5em;
        }
        .button:visited, .button:hover
        {
            width: auto;
        }
        .button:active
        {
            width: auto;
            top: 1px;
        }
        input, select
        {
            font-family: Verdana;
        }
        .regcolour
        {
            color: Red;
        }
        .Click
        {
            text-decoration: none;
            color: #0C6E9F; /*0C6E9F*/
        }
        .Click:hover
        {
            text-decoration: underline;
        }
        #lblMail
        {
            /*font-family: "CenturyGothicRegular" , "Century Gothic" , Arial, Helvetica, sans-serif;*/
            font-size: 14px;
            color: #899CAA;
        }
        #divCaptchaMain
        {
            /*border: 15px solid #F6BF4B;
            margin-left: 240px;
            margin-right: 225px;
            font-family: "CenturyGothicRegular" , "Century Gothic" , Arial, Helvetica, sans-serif;
            font-size: 14px;
            color: #899CAA;
            margin-top: 50px;*/
            background: none repeat scroll 0 0 #ECECEC; /*font-family: "CenturyGothicRegular" , "Century Gothic" , Arial, Helvetica, sans-serif;*/
            border: 5px solid #8F1313;
            border-radius: 3px 3px 3px 3px;
            height: 390px;
            margin-left: 240px;
            margin-top: 50px;
            margin-right: 225px;
            width: 515px;
        }
        #divCaptcha
        {
            padding-left: 20px;
            padding-bottom: 55px;
        }
        #lblEmail
        {
            padding-left: 20px;
            padding-top: 15px;
        }
        #divButtons
        {
            padding-top: 20px;
            padding-left: 63px;
        }
        #divSecurity
        {
            margin-left: 62px;
        }
        .divSubmit
        {
            margin-bottom: 1px;
            margin-left: -50px;
            padding-top: 40px;
            position: absolute;
            width: 370px;
        }
        .aligndiv
        {
            font-size: 14px; /*font-weight: bold;*/
            padding: 20px 0 4px 4px; /*text-align: left;*/
        }
        .footer
        {
            color: #939393;
            font-size: 11px;
            margin: 50px auto 15px;
            text-align: center;
        }
        .hidevalueto
        {
            margin-left: 62px;
            margin-top: -28px;
        }
        .FPButtons
        {
            background: none repeat scroll 0 0 #8F1313;
            border: medium none;
            border-radius: 13px 13px 13px 13px;
            color: White;
            cursor: pointer;
            display: block;
            font-family: Microsoft YaHei;
            font-size: 14px;
            font-weight: bold;
            height: 28px;
            line-height: 28px;
            margin: 0;
            text-align: center;
            text-decoration: none;
            vertical-align: middle;
            width: 95px;
        }
    </style>
  <script type="text/javascript">
       $(document).ready(function () {

            $("#logohide").hide();
        });
  </script>
    <script type="text/javascript" language="javascript">
        function reloadCaptcha(obj) {
            if (obj) {
                document.getElementById('captcha').src = document.getElementById('captcha').src + '?captcha=new';
                document.getElementById('<%= CodeNumberTextBox.ClientID %>').value = '';
            }
        }
    </script>
    <script type="text/javascript">
        $(document).ready(function () {
            $('.button').mousedown(function () {
                $('.hide').hide();
                $('.hidevalueto').hide();
            });
        });
    </script>
</head>
<body style="background:url('Images/body_bg.jpg');background-color:#fff; background-repeat:repeat-x; background-position:top";>
<form id="form1" runat="server">
    <div class="masterHead">
    <div class="logo">
      <img src="Images/logo_SNR.png" id="logohide">
    </div>
    <div class="menusubinsidepages">
       <div>
            <div id="ddtopmenubar" class="mattblackmenu">
              <ul>
                  <li>
                     <a class="select" href="Home.aspx">Home</a>
                  </li>
                  <li>
                     <a href="About.aspx">About us</a>
                  </li>
                  <li>
                     <a rel="ddsubmenu5" href="ProductSuite.aspx">Product Suite</a>
                  </li>
                  <li>
                     <a rel="ddsubmenu8" href="Contact.aspx">Contact us</a>
                  </li>
              </ul>
           </div>
      </div>
   </div>
        <div class="masterwrapper">
        </div>
        <div class="clr">
        </div>
    </div>
    <div class="masterbody">
        <div class="masterwrapper">
            <div id="divCaptchaMain">
                <div class="aligndiv">
                    <table cellspacing="0px" cellpadding="3px">
                        <tr>
                            <td colspan="2">
                                <span style="color:#8F1313; font-size: 13pt; font-weight: bold; padding-left: 178px;">
                                    Forgot Password </span>
                                <br />
                                <br />
                            </td>
                        </tr>
                        <tr style="height: 5px;">
                            <td>
                                <asp:ValidationSummary ID="ValidationSummary1" CssClass="valsumry" runat="server"
                                    ValidationGroup="forgot" ForeColor="#FF5050" Style="padding-left: 46px;" />
                            </td>
                        </tr>
                    </table>
                </div>
                <div id="lblEmail">
                    <asp:Label ID="lblMail" runat="server" Text="Email Id" ForeColor="Black"></asp:Label>
                    &nbsp;<asp:TextBox ID="txtmailid" runat="server" MaxLength="40" Width="400px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="txtmailid"
                        ValidationGroup="forgot" CssClass="regcolour" runat="server" Display="None" ErrorMessage="Enter Email Id."></asp:RequiredFieldValidator><br />
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" ValidationGroup="forgot"
                        Display="None" CssClass="regcolour" ValidationExpression="[0-9a-zA-Z]([-.\w]*[0-9a-zA-Z])*@([0-9a-zA-Z][-\w]*[0-9a-zA-Z]\.)+[a-zA-Z]{2,9}"
                        runat="server" ControlToValidate="txtmailid" ErrorMessage="Enter Valid Email Id."></asp:RegularExpressionValidator>
                </div>
                <br />
                <div id="divCaptcha">
                    <div id="divSecurity">
                        <span class="regcolour">Enter The Letters Below </span>
                        <br />
                        <img src="Captcha.aspx" id="captcha">Generate New?    <span id="refreshcaptcha" style="cursor: pointer"
                            class="Click" onclick="javascript:reloadCaptcha(true);">Click Here</span><br />
                        <asp:TextBox ID="CodeNumberTextBox" ViewStateMode="Disabled" runat="server"></asp:TextBox>
                        <div id="Div1" runat="server" style="padding-top: 10px;">
                            <asp:Label ID="errorlblsecurity" CssClass="regcolour" runat="server"></asp:Label>
                        </div>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator8" ControlToValidate="CodeNumberTextBox"
                            ValidationGroup="forgot" CssClass="regcolour" Display="None" runat="server" ErrorMessage="Enter The Letters Shown."></asp:RequiredFieldValidator>
                    </div>
                    <div class="divSubmit">
                        <table cellpadding="0" cellspacing="0" border="0" align="right">
                            <tr>
                                <td>
                                    <asp:Button ID="Button1" ValidationGroup="forgot" runat="server" class="FPButtons"
                                        OnClick="submibmail_Click" Text="Submit" />
                                </td>
                                <td>
                                    <img src="Images/spacer.png" width="3" alt="" />
                                </td>
                                <td>
                                    <input id="Button2" onclick="location.href='Home.aspx'" runat="server" type="button"
                                        class="FPButtons" value="Cancel" />
                                </td>
                            </tr>
                        </table>
                        <%--<asp:Button ID="submitbt" ValidationGroup="forgot" runat="server" CssClass="toplink"
                            OnClick="submibmail_Click" Text="Submit" />
                        &nbsp;&nbsp;
                        <input onclick="location.href='LandingPage.aspx'" runat="server" type="button" class="toplink"
                            value="Cancel" />--%>
                        <%--<button href="" runat="server" CssClass="canvasButtons" Text="Cancel" />--%>
                    </div>
                    <br />
                    &nbsp;<div id="Div2" class="hidevalueto" runat="server">
                        <asp:Label ID="maillbl" Visible="false" CssClass="regcolour" runat="server"></asp:Label></div>
                </div>
            </div>
        </div>
    </div>
    </form>
    <div>
        <img src="images/spacer.png" height="5" width="100%" alt="" /></div>
    <div class="footer">
        Copyright <a href="http://www.smnetserv.com/" target="_blank" class="url" style="text-decoration: underline;">
            SM NetServ Technologies Pvt Ltd</a> 2012 - Offshore Software Development Company,
        India</div>
        
</body>
</html>
