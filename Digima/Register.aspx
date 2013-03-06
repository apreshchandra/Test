<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="DigiMa.Register" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>SoNetReach Registration</title>
    <meta http-equiv="X-UA-Compatible" content="IE=edge,chrome=1" />
    <link rel="stylesheet" href="Styles/Chrome.css" type="text/chrome/safari" />
    <link rel="stylesheet" type="text/css" media="all" href="Styles/niceforms-default.css" />
    <%--<link href="Styles/master_style1.css" rel="stylesheet" type="text/css" />--%>
    <script src="http://ajax.googleapis.com/ajax/libs/jquery/1.7.1/jquery.min.js"></script>
    <%--<script src="ScriptsSonetReach/jquery-1.7.1.full.js" type="text/javascript"></script>--%>
    <script type="text/javascript" src="ScriptsSonetReach/login.js"></script>
    <script type="text/javascript" src="ScriptsSonetReach/RegisterValidation.js"></script>
    <link rel="stylesheet" type="text/css" href="Styles/master_style.css" />
    <link href="Styles/style_new_menu.css" rel="stylesheet" type="text/css" />
    <link href="Styles/menu_style.css" rel="stylesheet" type="text/css" />
    <link rel="shortcut icon" href="Images/sonetreachicon.ico" />
    <script src="ScriptsSonetReach/slides.min.jquery.js" type="text/javascript"></script>
    <link href="Styles/style1.css" rel="stylesheet" type="text/css" />
    <!--[if IE ]>
	<link rel="stylesheet" type="text/css" href="Styles/ie7.css" />
<![endif]-->
    <script type="text/javascript">
        var _gaq = _gaq || [];
        _gaq.push(['_setAccount', 'UA-33450544-1']);
        _gaq.push(['_trackPageview']);

        (function () {
            var ga = document.createElement('script'); ga.type = 'text/javascript'; ga.async = true;
            ga.src = ('https:' == document.location.protocol ? 'https://ssl' : 'http://www') + '.google-analytics.com/ga.js';
            var s = document.getElementsByTagName('script')[0]; s.parentNode.insertBefore(ga, s);
        })();
    </script>
    <script type="text/javascript">
        function reloadCaptcha() {
            document.getElementById('captcha').src = document.getElementById('captcha').src + '?captcha=new';
            document.getElementById('<%= CodeNumberTextBox.ClientID %>').value = '';
        }
        $(document).ready(function () {
            $('.button').mousedown(function () {
                $('.hide').hide();

            });
            window.onload = function () {
                $("#txtFullName").focus();
                //                $("#txtFullName").val('');
                //                $("#txtEmailid").val('');
                //                $("#txtPassword").val('');
                //                $("#txtRePassword").val('');
                //                $("#txtOrganization").val('');
                //                $("#txtAddress").val('');
                //                $("#txtCity").val('');
                //                $("#txtState").val('');
                //                $("#txtZip").val('');
                //                $("#txtTelephone").val('');
                //                $("#txtMobile").val('');
                //                $("#txtAppname").val('');
                //                $("#txtAppname").val('');
                //                $("#ddlGender").val("-1");
                //                $("#ddlCountry").val("-1");
            };


        });
        function BrowserHidden_onclick() {

        }           

    </script>
    <script type="text/javascript">
        $(document).ready(function () {
            $("#slides").slides({
                preload: true,
                preloadImage: '/images/loading.gif',
                play: 5000,
                pause: 500,
                hoverPause: true
            });


            window.onload = function () {
                $("#txtemail").val('');
                $("#txtpassword").val('');
                $("#trError").css("style", "display:none");
                $("#txtemail").focus();
                // $("#trError").hide();
            };
            var button = $('#loginButton');
            var box = $('#loginBox');
            var form = $('#loginForm');
            var email = $("#txtemail").val();
            var pwd = $("#txtpassword").val();
            var button_previous = $("#btnclose");
            var popupOpen = false;
            var btncloseclick = false;
            //var e = jQuery.Event("click");

            box.load(function () {
                $("#txtemail").val('');
                $("#txtpassword").val('');
                $("#trError").addClass("style", "display:none");
            });

            button.click(function () {
                box.toggle();
                button.toggleClass('active');
                //$('#loginForm').addClass("style", "display:block");
                $("#txtemail").val('');
                $("#txtpassword").val('');
                $("#txtemail").focus();
                $("#username_warn").empty();
                $("#password_warn").empty();
                $("#lblError").empty();
            });


            $("#btnclose").bind('click', function () {
                //$('#btnclose').unbind('click', fireClick);

                popupOpen = true;
                btncloseclick = true;
                $("#username_warn").empty();
                $("#password_warn").empty();
                $("#lblError").empty();
                box.hide();
            });



            $("#txtemail").keydown(function () {

                var username_length;
                username_length = $("#txtemail").val().length;
                $("#username_warn").empty();
                $("#lblError").empty();

                if ((username_length == 0) || (username_length < 1)) //|| (!button_previous.click)
                    $("#username_warn").append("Username is required !");

            });

            $("#txtpassword").keydown(function () {
                var password_length;

                password_length = $("#txtpassword").val().length;
                $("#password_warn").empty();
                $("#lblError").empty();
                if (password_length < 1)
                    $("#password_warn").append("Password is required !");

            });

            $("#imgAnalytics").mouseover(function () {
                $("#imgAnalytics").css('background-color', 'fffff');
            });

            // Close login form on click of esc button
            window.onkeyup = function (event) {
                if (event.keyCode == 27) {
                    box.hide();
                }

            }

            $("#loginButton").css('cursor', 'pointer');

        });

        function show() {
            document.getElementById('newFrm').style.display = 'Block';
        }
        $(document).ready(function () {
            $('.button').mousedown(function () {
                $('.errspan').hide();
            });
        });
        function resetfun() {
            document.getElementById('<%= txtemail.ClientID %>').value = '';
            document.getElementById('<%= txtpassword.ClientID %>').value = '';
        }  
    </script>
    <!--[if IE]>

     <style type="text/css"> 
     .NFTextarea
    {
    padding-right:0px;
    padding-bottom: 0;  background-color:#fff; width:201px;}  </style>

<![endif]-->
    <style type="text/css">
        #tdSignup
        {
            visibility: hidden;
        }
        #tdLogin
        {
            visibility: hidden;
        }
    </style>
    <style type="text/css">
        .divOuter
        {
            border: 1px solid #5fcdf6;
            border-radius: 8px;
            margin-left: 8px;
            margin-top: 30px;
            width: 450px;
            margin-left: 290px;
        }
        .divContentPP
        {
            color: White;
            padding: 20px 20px 20px 20px;
        }
        .divFooter
        {
            color: #939393;
            font-size: 11px;
            margin: 50px auto 15px;
            text-align: center;
        }
    </style>
    <style>
        .clsHeader
        {
            /*font-family: CenturyGothicRegular, "Century Gothic" , Arial, Helvetica, sans-serif;*/
            font-family: Verdana;
            font-size: 13px;
            font-weight: 500;
        }
        .divHeading
        {
            /*font-family: CenturyGothicRegular, "Century Gothic" , Arial, Helvetica, sans-serif;*/
            font-family: "Lucida Grande" , "Lucida Sans Unicode" , "Helvetica";
            font-size: 14px;
            font-weight: bold;
            text-decoration: underline;
            color: #5fcdf6;
        }
        .lblHeader
        {
            color: #5fcdf6;
            font-size: 25px;
            padding-left: 438px;
            text-align: center;
            text-decoration: underline;
        }
        .masterbody
        {
            height: auto;
            background-color: #1b1b1b;
        }
        .body
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
        #btnSubmit
        {
            background-image: url('Images/signin_final.png');
            width: 97px;
            height: 33px;
            cursor: pointer;
            display: block;
            background-color: transparent;
            border: 0 none; /*margin-left: 35px;*/
            border-radius: 13px 13px 13px 13px;
        }
        #Reset
        {
            background-image: url('Images/reset.png');
            width: 81px;
            height: 33px;
            cursor: pointer;
            display: block;
            background-color: transparent;
            border: 0 none; /*margin-left: 35px;*/
            border-radius: 13px 13px 13px 13px;
        }
    </style>
    <script type="text/javascript">
        $(document).ready(function () {
            $(document).bind("contextmenu", function (e) {
                return false;
            });
        });
        function Button3_onclick() {

        }

    </script>
</head>
<body>
    <%--<div id="container">--%>
    <form id="form1" class="niceform" runat="server">
    <asp:ScriptManager ID="scrmgr" runat="server">
    </asp:ScriptManager>
    <div class="masterbody">
        <div id="toparea">
            <div class="top">
                <div class="logo" style="padding: 0px;">
                    <img src="images/logo.png" /></div>
                <div class="loginarea">
                    <div>
                        <img src="images/spacer.png" height="10" /></div>
                    <div>
                        <h2>
                            Stay Connected <a href="https://www.facebook.com/pages/SoNetReach/484323984929972/"
                                target="_blank">
                                <image src="images/facebook_btn.png"></image>
                            </a>
                        </h2>
                    </div>
                    <div id="login">
                        <ul>
                            <li><a href="Register.aspx">Signup</a></li>
                            <li>| </li>
                            <li><a href="#" id="loginButton">Login</a></li>
                        </ul>
                    </div>
                </div>
            </div>
            <div class="clr">
            </div>
        </div>
        <asp:Panel ID="loginPanel" DefaultButton="Sign" runat="server">
            <div id="loginBox" style="display: none;" runat="server" visible="true">
                <div id="loginForm" runat="server">
                    <table id="tblLogin">
                        <tr id="trError" runat="server" visible="false">
                            <td>
                                <asp:Label ID="lblError" Style="color: red" runat="server">Email ID/Password is incorrect!</asp:Label>
                            </td>
                        </tr>
                        <tr align="center">
                            <td>
                                <asp:Label runat="server" ID="lblemail">
                                        Email ID</asp:Label>
                                <asp:TextBox runat="server" ID="txtemail" TextMode="SingleLine" Width="227px"></asp:TextBox>
                                <span id="username_warn" style="color: red" runat="server"></span>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label runat="server" ID="lblpwd">
                                        Password</asp:Label>
                                <asp:TextBox runat="server" ID="txtpassword" TextMode="Password" Width="227px"></asp:TextBox>
                                <span id="password_warn" style="color: red" runat="server"></span>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <div style="float: left;">
                                    <asp:Button ID="Sign" runat="server" OnClick="login_Click" CssClass="toplink" UseSubmitBehavior="false" />
                                </div>
                                <div style="float: left; padding-left: 10px;">
                                    <a id="btnclose" class="close"></a>
                                </div>
                            </td>
                        </tr>
                    </table>
                    <span><a href="ForgotPassword.aspx">Forgot your Password?</a></span>
                </div>
            </div>
        </asp:Panel>
        <div class="menubg">
            <div class="menu_bg">
                <div id="ddtopmenubar" class="mattblackmenu">
                    <ul>
                        <li><a class="homenav" href="Home.aspx"></a></li>
                        <li><a href=""><span>
                            <img src="images/nav_sep.png" border="0" /></a></span></li>
                        <li><a href="ProductSuite.aspx">Product Suite</a></li>
                        <li><a href="#"><span>
                            <img src="images/nav_sep.png" border="0" /></a></span></li>
                        <li><a href="Pricing.aspx">Plans &amp; Pricing</a></li>
                        <li><a href="#"><span>
                            <img src="images/nav_sep.png" border="0" /></a></span></li>
                        <li><a href="Resources.aspx">Resources</a></li>
                        <li><a href="#"><span>
                            <img src="images/nav_sep.png" border="0" /></a></span></li>
                        <li><a href="AboutUs.aspx">About Us</a></li>
                        <li><a href="#"><span>
                            <img src="images/nav_sep.png" border="0" /></a></span></li>
                        <li><a href="Contact.aspx">Contact Us</a></li>
                    </ul>
                </div>
            </div>
        </div>
        <div class="PersonalInfo">
            <table cellpadding="6px" border="0px">
                <tr>
                    <td colspan="2" class="HeaderRegister">
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Registration Form<span style="margin-left: 61px;">
                            <img height="80px" width="100px" src="Images/60days6.png" style="position: absolute;
                            margin-left: -25px; margin-top: -10px;" alt="Trial 60 days" />
                        </span>
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        <asp:ValidationSummary ID="ValidationSummary1" runat="server" ValidationGroup="val"
                            ShowMessageBox="true" ShowSummary="false" Class="valSummary" />
                    </td>
                </tr>
                <tr>
                    <td colspan="2" class="regcolour">
                        Note: All fields are Mandatory
                    </td>
                </tr>
                <tr>
                    <td align="left" colspan="1">
                        Full Name:
                    </td>
                    <td colspan="1">
                        <asp:TextBox ID="txtFullName" CssClass="txtbox" runat="server" MaxLength="40" EnableViewState="true"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Name Required."
                            SetFocusOnError="True" ControlToValidate="txtFullName" ValidationGroup="val"
                            ValidationExpression="[a-zA-Z]+" Display="None"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td colspan="1">
                        Email ID:
                    </td>
                    <td colspan="1">
                        <asp:UpdatePanel ID="updtpanel" runat="server" RenderMode="Inline" UpdateMode="Conditional">
                            <Triggers>
                                <asp:AsyncPostBackTrigger ControlID="txtEmailid" EventName="TextChanged" />
                            </Triggers>
                            <ContentTemplate>
                                <asp:TextBox ID="txtEmailid" CssClass="txtbox" runat="server" MaxLength="40" AutoPostBack="true"
                                    OnTextChanged="txtEmailID_TextChanged" ViewStateMode="Disabled" EnableViewState="true"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="rqtxtEmail" runat="server" ErrorMessage="EmailID Required."
                                    ControlToValidate="txtEmailID" ValidationGroup="val" Display="None" SetFocusOnError="True"></asp:RequiredFieldValidator>
                                <asp:RegularExpressionValidator ID="rgexptxtEmailID" runat="server" ErrorMessage="Please enter valid Email ID"
                                    ControlToValidate="txtEmailID" ValidationGroup="val" Display="None" SetFocusOnError="True"
                                    ValidationExpression="^[\w\.\-]+@[a-zA-Z0-9\-]+(\.[a-zA-Z0-9\-]{1,})*(\.[a-zA-Z]{2,3}){1,2}$"></asp:RegularExpressionValidator>
                                <%--<asp:Label ID="lblText" runat="server" ForeColor="Red" Visible="false"></asp:Label>--%>
                                <%--<span id="errorspan" runat="server" visible="false" style="position: absolute; left: 752px;">
                                            EmailID already exist...!</span>--%>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </td>
                </tr>
                <tr>
                    <td colspan="1">
                        Company:
                    </td>
                    <td colspan="1">
                        <asp:TextBox ID="txtOrganization" CssClass="txtbox" runat="server" TextMode="SingleLine"
                            MaxLength="50" EnableViewState="true"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Company Name Required."
                            SetFocusOnError="True" ControlToValidate="txtOrganization" ValidationGroup="val"
                            Display="None"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td colspan="1">
                        Address:
                    </td>
                    <td colspan="1">
                        <%--<textarea cols="24" rows="5" id="txtAddress" runat="server" class="txtarea"></textarea>--%>
                        <asp:TextBox ID="txtAddress" ViewStateMode="Disabled" MaxLength="250" runat="server"
                            TextMode="MultiLine" Height="100px" Width="194px" EnableViewState="False"></asp:TextBox>
                        &nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ErrorMessage="Address Required"
                            ValidationGroup="val" Display="None" ControlToValidate="txtaddress"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <%--<tr>
                <td>
                    Gender:<span class="regcolour">
                        <img src="images/required.png" /></span>
                </td>
                <td>
                    <asp:DropDownList ID="ddlGender" runat="server" CssClass="dropbox">
                        <asp:ListItem Value="Select">Select&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</asp:ListItem>
                        <asp:ListItem Value="Male">Male</asp:ListItem>
                        <asp:ListItem Value="Female">Female</asp:ListItem>
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Select Gender."
                        InitialValue="Select" SetFocusOnError="True" ControlToValidate="ddlGender" ValidationGroup="val"
                        Display="None"></asp:RequiredFieldValidator>
                </td>
                
            </tr>--%>
                <tr>
                    <td colspan="1">
                        Country:
                    </td>
                    <td colspan="1">
                        <asp:DropDownList ID="ddlCountry" runat="server" Width="200px">
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="Select Country."
                            SetFocusOnError="True" ControlToValidate="ddlCountry" ValidationGroup="val" Display="None">
                        </asp:RequiredFieldValidator>
                    </td>
                </tr>
                <%--<tr>
                <td>
                    City:
                </td>
                <td>
                    <asp:TextBox ID="txtCity" runat="server" CssClass="txtbox" TextMode="SingleLine"></asp:TextBox>
                </td>
            </tr>--%>
                <tr>
                    <td colspan="1">
                        Zip Code:
                    </td>
                    <td colspan="1">
                        <asp:TextBox ID="txtZip" CssClass="txtbox" runat="server" TextMode="SingleLine" MaxLength="10"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="Zipcode Required."
                            SetFocusOnError="True" ControlToValidate="txtZip" ValidationGroup="val" ValidationExpression="\d+"
                            Display="None"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="captcha" colspan="1">
                        <span class="regcolour">Enter The Letters Below </span>
                        <br>
                            <img id="captcha" src="Captcha.aspx"></br>
                        <span style="text-align: left; padding: 0 0 0 02px; margin: 0px;">Generate New?<span
                            onclick="javascript:reloadCaptcha();" class="Click" style="cursor: pointer" id="refreshcaptcha">&nbsp;Click
                            Here</span><br>
                        </span>
                    </td>
                    <td colspan="1">
                        <asp:TextBox ID="CodeNumberTextBox" ViewStateMode="Disabled" EnableViewState="False"
                            runat="server"></asp:TextBox>
                        <asp:Label ID="errorlblsecurity" CssClass="regcolour" runat="server"></asp:Label>
                        <asp:RequiredFieldValidator ID="rqtxtCodeNor" ControlToValidate="CodeNumberTextBox"
                            ValidationGroup="val" SetFocusOnError="true" runat="server" ErrorMessage="The characters you entered didn't match the word verification."
                            Display="None"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        <asp:CheckBox ID="checkTC" runat="server" />
                        <asp:Label runat="server"> I have accepted the <a href="TermsConditions.aspx" target="_blank" style="text-decoration: none;">
                        Terms & Conditions</a> and <a href="PrivacyPolicy.aspx" target="_blank" style="text-decoration: none;">
                            Privacy Policy</a> <br />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;of SM NetServ Technologies Pvt Ltd</asp:Label>
                        <div style="display: none;" id="validate_mycheckbox">
                            <span>You must accept the T&C and Privacy policy.</span>
                        </div>
                    </td>
                </tr>
                <tr>
                    <td colspan="2" class="divForgotpasswordbtn">
                        <table cellpadding="0" cellspacing="0" border="0" align="">
                            <tr>
                                <td>
                                    <%--<asp:Button ID="Button1" CssClass="toplink regcolour" runat="server" Text="Submit" />--%>
                                    <asp:Button ID="btnSubmit" runat="server" OnClick="Button1_Click" ValidationGroup="val"
                                        CausesValidation="true" ViewStateMode="Disabled" EnableViewState="False" />
                                    <%--OnClick="Button1_Click" --%>
                                </td>
                                <td>
                                    <img src="Images/spacer.png" width="3" alt="" />
                                </td>
                                <td>
                                    <asp:Button ID="Reset" runat="server" OnClick="reset_click" />
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
        </div>
    </div>
    <div id="footerKM">
        <div class="sitelink1KM">
            <ul>
                <li><b>Site Links</b></li>
                <li><a href="Home.aspx">Home</a></li>
                <li><a href="ProductSuite.aspx">Product Suite</a></li>
                <li><a href="LearnMoreCampaignBuilder.aspx">Campaign Builder</a></li>
                <li><a href="LearnMoreAnalytics.aspx">Powerful Analytics</a></li>
            </ul>
        </div>
        <div class="sitelink2KM">
            <ul>
                <li><b>Knowledge Base</b></li>
                <li><a href="Pricing.aspx">Plans & Pricing</a></li>
                <li><a href="Resources.aspx">Resources</a></li>
            </ul>
        </div>
        <div class="sitelink3KM">
            <ul>
                <li><b>Register</b></li>
                <li><a href="Register.aspx">Register</a></li>
            </ul>
        </div>
        <div class="sitelink5KM">
            <ul>
                <li><b>Company</b></li>
                <li><a href="AboutUs.aspx">About Us</a></li>
                <li><a href="Contact.aspx">Contact Us</a></li>
            </ul>
        </div>
        <div class="sitelink6KM">
            <ul>
                <li><b>Stay Connected</b></li>
                <li><a href="https://www.facebook.com/pages/SoNetReach/484323984929972/" target="_blank">
                    <img src="images/facebook_btn.png" /></a></li>
            </ul>
        </div>
        <div class="clr">
        </div>
        <div class="line">
            &nbsp;</div>
        <div class="policy">
            <p>
                <a href="TermsConditions.aspx">Terms of Service</a> | <a href="PrivacyPolicy.aspx">Privacy
                    Policy</a> | © 2012 <a href="http://smnetserv.com/index.html" target="_blank" class="smnet" />
                SM Netserv Technologies Pvt ltd.</a> All Rights Reserved.</p>
        </div>
    </div>
    </form>
</body>
</html>
