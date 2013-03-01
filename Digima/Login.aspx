<%@ Page Language="c#" CodeFile="Login.aspx.cs" AutoEventWireup="True" Inherits="DigiMa.Login" %>

<html>
<head>
    <title>DigiMa</title>
    <meta name="Generator" content="EditPlus">
    <meta name="Author" content="">
    <meta name="Keywords" content="">
    <meta name="Description" content="">
    <link rel="stylesheet" type="text/css" href="Styles/style.css" />
    <link rel="stylesheet" href="Styles/menu_style.css" type="text/css" />
    <script type="text/javascript" src="Scripts/menu.js"></script>
    <script type="text/javascript">
        ddlevelsmenu.setup("ddtopmenubar", "topbar") //ddlevelsmenu.setup("mainmenuid", "topbar|sidebar")
    </script>
    <script>
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
        };
    </script>
</head>
<body>
    <div id="wrapper">
        <div class="leftdiv">
            <div class="logo">
                <img src="images/logo.png" /></div>
            <div class="menubg">
                <div>
                    <div id="ddtopmenubar" class="mattblackmenu">
                        <ul>
                            <li><a href="index.html" class="select">Home</a></li>
                            <li><a href="#.html">About us</a></li>
                            <li><a href="#.html" rel="ddsubmenu5">Services</a></li>
                            <li><a href="#" rel="ddsubmenu8">Contact us</a></li>
                        </ul>
                    </div>
                </div>
                <div class="banner">
                    &nbsp;&nbsp;&nbsp;&nbsp;Slide
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
                    <li><a href="#" class="fb">Facebook </a></li>
                    <li><a href="#" class="ms">Microsite </a></li>
                    <li><a href="#" class="ws">Website </a></li>
                    <li><a href="#" class="yt">Youtube </a></li>
                </ul>
            </div>
        </div>
        <div class="rightdiv">
            <input type="button" value="Login" class="buttons" />
            <input type="button" value="Sign Up" class="buttons" />
            <br />
            <br />
            <br />
            <div>
                <img src="images/right_banner.png" border="0" /></div>
            <h1>
                "Build your brand leveraging
                <br />
                the power of DigiMa"
            </h1>
        </div>
    </div>
    <div class="clr">
        <asp:Panel ID="loginPanel" DefaultButton="Sign" runat="server">
            <div id="loginBox" style="display: none;" runat="server" visible="true">
                <div id="loginForm" runat="server">
                    <table id="tblLogin">
                        <tr id="trError" runat="server" visible="false">
                            <td>
                                <asp:Label ID="lblLoginErrorMessage" Style="color: red" runat="server">Email ID/Password is incorrect!</asp:Label>
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
    </div>
    <br />
    <div>
        <img src="images/footer_bg.png" border="0" width="100%" height="1" /></div>
    <div class="footer">
        <ul>
            <li><a href="#" />Home</a></li>
            <li><a href="#" />About us</a></li>
            <li><a href="#" />Services</a></li>
        </ul>
    </div>
    <br />
</body>
</html>
