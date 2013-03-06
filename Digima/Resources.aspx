<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Resources.aspx.cs" Inherits="DigiMa.Resources" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script src="http://ajax.googleapis.com/ajax/libs/jquery/1.7.1/jquery.min.js"></script>
    <%--<script src="ScriptsSonetReach/jquery-1.7.1.full.js" type="text/javascript"></script>--%>
    <script type="text/javascript" src="ScriptsSonetReach/login.js"></script>
    <link rel="stylesheet" type="text/css" href="Styles/master_style.css" />
    <link href="Styles/style1.css" rel="stylesheet" type="text/css" />
    <script src="ScriptsSonetReach/jquery.betterTooltip.js" type="text/javascript"></script>
    <script src="ScriptsSonetReach/Menuhover.js" type="text/javascript"></script>
    <link rel="shortcut icon" href="Images/sonetreachicon.ico" />
    <link href="Styles/format.css" rel="stylesheet" type="text/css" />
    <link href="Styles/style_new_menu.css" rel="stylesheet" type="text/css" />
    <link href="Styles/menu_style.css" rel="stylesheet" type="text/css" />
    <script src="ScriptsSonetReach/slides.min.jquery.js" type="text/javascript"></script>
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
    <style>
        #QRBottom
        {
            margin-top: 220px;
            margin-left: 183px;
        }
        .QRFTBottom
        {
            background-image: url("images/try-button.png");
            background-repeat: no-repeat;
            background-position: 6px 9px;
            height: 42px;
            width: 152px;
            display: inline-block;
            float: left;
            text-indent: -9999px;
            cursor: pointer;
        }
        .divFooterReSources
        {
            color: #939393;
            font-size: 11px;
            margin: 50px auto 15px;
            text-align: center;
        }
        
        .divOuter
        {
            border: 1px solid #7C7C77;
            border-radius: 13px 13px 13px 13px;
            margin-left: 8px;
            margin-top: 30px;
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
        .divInfo
        {
            background-position: center top;
            font-family: "Lucida Grande" , "Lucida Sans Unicode" , "Helvetica";
            font-size: 14px;
            font-weight: bold;
            padding-left: 25px;
        }
        .lblHeader
        {
            color: #F6BF4B;
            font-size: 25px;
            padding-left: 320px;
            text-align: center;
            text-decoration: underline;
        }
        .boldIT
        {
            font-weight: bold;
            font-size: 18px;
            color: #f7c458;
        }
        .boldITSmall
        {
            font-weight: bold;
            font-size: 16px;
        }
        .smnet
        {
            text-decoration: underline;
            color: #151515;
            padding-bottom: 0px;
        }
        .smnet:hover
        {
            text-decoration: none;
            color: #151515;
        }
        
        .line
        {
            background-image: url('../images/line.jpg');
            background-image: repeat-x;
            height: 1px;
            margin: 10px 30px 10px 0px;
        }
        #mainContent
        {
            font-family: "Lucida Grande" , "Lucida Sans Unicode" , "Helvetica";
            width: 950px;
            margin: 0 auto;
            margin-top: -16px;
            background-image: url('Images/subpage_bannerbg.png');
            background-repeat: repeat-x, repeat-y;
            color: White;
            height: 200px;
            text-align: center;
        }
        .DownloadBrochure
        {
            background-image: url('Images/download.png');
            background-repeat: no-repeat;
            background-color: transparent;
            border: 0 none;
            cursor: pointer;
            display: block;
            height: 33px;
            width: 140px;
        }
        .HeadingText
        {
            color: #74CCEF;
            margin-left: 8px;
            margin-top: 30px;
            margin-left: 8px;
            margin-top: 30px;
            font-size: 13px;
            font-weight: bold;
        }
        .QRFT
        {
            background-image: url("images/try-button.png");
            background-repeat: no-repeat;
            background-position: 6px 9px;
            height: 22px;
            width: 152px;
            display: inline-block;
            float: left;
            text-indent: -9999px;
            cursor: pointer;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
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
                            <li><a href="QuickRegister.aspx">Signup</a></li>
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
                        <li><a href="#"><span>
                            <img src="images/nav_sep.png" border="0" /></a></span></li>
                        <li><a href="QuickRegister.aspx" class="QRFT"></a></li>
                    </ul>
                </div>
            </div>
        </div>
        <div id="mainContent">
            <table width="100%">
                <tr align="left" valign="middle">
                    <td>
                        <p class="HeadingText">
                            Brochure</p>
                    </td>
                </tr>
                <tr align="left" valign="middle">
                    <td style="width: 36%;">
                        <img src="Images/Brochure_Design.png" />
                    </td>
                    <td>
                        <asp:Button ID="btnDownload" runat="server" CssClass="DownloadBrochure" OnClick="btnDownload_Click" />
                    </td>
                </tr>
            </table>
        </div>
        <div id="QRBottom">
            <a href="QuickRegister.aspx" class="QRFTBottom"></a>
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
                    <li><a href="QuickRegister.aspx">Register</a></li>
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
    </div>
    </form>
</body>
</html>
