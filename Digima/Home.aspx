<%@ Page Language="C#" AutoEventWireup="True" CodeBehind="Home.aspx.cs" Inherits="DigiMa.Home" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>SoNetReach - Home</title>
    <meta charset="utf8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge,chrome=1">
    <meta name="description" content="Digital Marketing tool for Social Media.">
    <meta name="keywords" content="HTML, HTML help, meta tags, promotion, web sites, social media, sonetreach,digital marketing,campaigns, deals, coupons, group deals, KPI, analytics">
    <meta http-equiv="Content-Type" content="text/html; charset=ISO-8859-1">
    <meta name="author" content="SM NETSERV" />
    <meta name="robots" content="noindex">
    <meta name="copyright" content="April 2012">
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.7.1/jquery.min.js"></script>
    <link href="Styles/style1.css" rel="stylesheet" type="text/css" />
    <script src="ScriptsSonetReach/jquery-1.7.1.min.js" type="text/javascript"></script>
    <script type="text/javascript" src="ScriptsSonetReach/login.js"></script>
    <link href="Styles/style.css" rel="stylesheet" type="text/css" />
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
                preloadImage: 'Images/loading.gif',
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
            $("#signUp").click(function () {
                $("#ancSignUp").trigger("click");
            });

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
        #imgRegNow
        {
            height: 56px;
            width: 312px;
            display: block;
            background: transparent;
            -moz-box-shadow: 5px 5px 7px #888;
            -moz-border-radius-bottomright: 15px;
            -webkit-box-shadow: 5px 5px 7px #888;
            -webkit-border-bottom-right-radius: 15px;
        }
        .menubg
        {
            margin-top: 3px;
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
        .slides_container
        {
            width: 950px;
            height: 392px;
            margin-top: 10px;
        }
        .slides_container div
        {
            width: 950px;
            height: 270px;
            display: block;
        }
        .pagination
        {
            float: right;
            list-style: none outside none;
            margin: -6px 417px 0;
        }
        .pagination li a
        {
            background-image: url("images/pagination.png");
            background-position: 0 0;
            display: block;
            float: left;
            height: 0;
            overflow: hidden;
            padding-top: 13px;
            width: 13px;
        }
        .pagination li
        {
            float: left;
            margin: 0 1px;
        }
        .pagination li.current a, .pagination li.current a:hover
        {
            background-position: 0 -13px;
        }
        .pagination li a:hover
        {
            background-position: 0 -26px;
        }
        #slides
        {
            margin-top: -10px;
            margin-left: -10px;
        }
        .txtLoginTextboxes
        {
            background: none repeat scroll 0 0 Grey;
            border: 1px solid #901414;
            color: White;
            width: 239px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div id="wrapper">
        <div class="leftdiv">
            <div class="logo">
                <img src="Images/logo_SNR.png" /></div>
            <div class="menubg">
                <div>
                    <div id="ddtopmenubar" class="mattblackmenu">
                        <ul>
                            <li><a href="Home.aspx" class="select">Home</a></li>
                            <li><a href="About.aspx">About us</a></li>
                            <li><a href="ProductSuite.aspx" rel="ddsubmenu5">Product Suite</a></li>
                            <li><a href="Contact.aspx" rel="ddsubmenu8">Contact us</a></li>
                        </ul>
                    </div>
                </div>
                <div class="banner">
                    <div id="slides">
                        <div class="slides_container">
                            <img width="572px" height="300px" style="padding-top: 25px; padding-left: 11px;"
                                border="0" src="Images/slider_brand.jpg" alt="" data-transition="slideInLeft" />
                            <img width="572px" height="300px" style="padding-top: 25px; padding-left: 11px;"
                                src="Images/slider_build_engagemnt.jpg" alt="" data-transition="slideInLeft" />
                            <img width="572px" height="300px" style="padding-top: 25px; padding-left: 11px;"
                                src="Images/slider_monitize.jpg" alt="" data-transition="slideInLeft" />
                            <img width="572px" height="300px" style="padding-top: 25px; padding-left: 11px;"
                                src="Images/slider_redefine.jpg" alt="" data-transition="slideInLeft" />
                            <img width="572px" height="300px" style="padding-top: 25px; padding-left: 11px;"
                                src="Images/slider_analytics.jpg" alt="" data-transition="slideInLeft" />
                        </div>
                    </div>
                </div>
            </div>
            <div class="clr">
            </div>
            <div class="txt">
                <ul>
                    <li>Facebook </li>
                    <li>Microsite </li>
                    <li>&nbsp;Website </li>
                    <li>&nbsp;Youtube </li>
                </ul>
            </div>
            <div class="social">
                <ul>
                    <li><a href="#" class="fb">Social Media </a></li>
                    <li><a href="#" class="ms">Microsite </a></li>
                    <li><a href="#" class="ws">Website </a></li>
                    <li><a href="#" class="yt">Youtube </a></li>
                </ul>
            </div>
        </div>
        <div class="rightdiv">
            <input type="button" value="Login" class="buttons" id="loginButton" />
            <asp:Button Text="Sign Up" runat="server" ID="btnSignUp" OnClick="btnSignUp_Click"
                class="buttons" />
            <%-- <input id="signUp" type="button" value="Sign Up" class="buttons"/>--%>
            <br />
            <br />
            <br />
            <div>
                <img src="images/right_banner.png" border="0" /></div>
            <h1>
                "Build your brand leveraging
                <br />
                the power of SonetReach"
            </h1>
            <a id="ancRegNow" href="QuickRegister.aspx">
                <img id="imgRegNow" alt="Register Now!" src="Images/RegisterNow_BlueBold.png" /></a>
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
                            <asp:TextBox runat="server" ID="txtemail" TextMode="SingleLine" CssClass="txtLoginTextboxes"></asp:TextBox>
                            <span id="username_warn" style="color: red" runat="server"></span>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label runat="server" ID="lblpwd">
                                        Password</asp:Label>
                            <asp:TextBox runat="server" ID="txtpassword" TextMode="Password" CssClass="txtLoginTextboxes"></asp:TextBox>
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
    </form>
</body>
</html>
