<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AboutUs.aspx.cs" Inherits="DigiMa.AboutUs"
    MasterPageFile="~/MasterPage.master"  %>
  

<asp:Content runat="server" ContentPlaceHolderID="head" ID="cphHead">
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
        .divOuter
        {
            padding: 10px;
            border-radius: 8px;
            margin-left: 8px;
            margin-top: 30px;
            font-family: "Lucida Grande" , "Lucida Sans Unicode" , "Helvetica";
            font-size: 14px;
            color: Silver;
        }
        .divContentPP
        {
            color: Silver;
            padding: 20px 20px 20px 20px;
        }
         .mattblackmenu
        {
            left: 76px;
            position: absolute;
        }
        .menusubinsidepages
        {
            background: url("Images/submenubg.png") no-repeat scroll 0 0 transparent;
            float: left;
            height: 50px;
            margin-left: 180px;
            margin-top: -13px;
            position: relative;
            width: 710px;
        }
        .divFooter
        {
            color: #939393;
            font-size: 11px;
            margin: 115px auto 15px;
            text-align: center;
        }
        .lblHeader
        {
            color: #F6BF4B;
            font-size: 25px;
            padding-left: 450px;
            text-align: center;
            text-decoration: underline;
        }
        .masterbody
        {
            height: auto;
        }
        #mainContent
        {
            font-family: "Lucida Grande" , "Lucida Sans Unicode" , "Helvetica";
            width: 950px;
            margin: 0 auto;
            margin-top: -76px;
            background-image: url('Images/subpage_bannerbg.png');
            background-repeat: repeat-x, repeat-y;
            color: White;
            height: 200px;
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
</asp:Content>
<asp:Content runat="server" ContentPlaceHolderID="body" ID="body">
    <table width="100%">
        <tr>
            <td>
                <a href="Http://www.smnetserv.com" target="_blank" style="text-decoration: none;
                    color: Silver">SM Netserv Technologies Pvt Ltd</a> is a global software solutions
                provider with the goal of delivering technology solutions, offerings lasting strategic
                value to our clients.
                <br />
                <br />
                We provide compelling value to our clients by employing proven quality processes,
                excellence in project management, flexible project models and a blended global delivery
                model that leverages our strengths in US and Indian operations.
                <br />
                <br />
                Our services include B2B & B2C Portal Solutions, Mobile Software Development, ERP
                Application Development, Client Server Solutions, Business Intelligence & Data Warehousing
                Services and Software Testing.
                <br />
                <br />
                As a business intent on meeting objectives and goals, you have to overcome limitations
                of time, technology and resources. Helping you in your quest is SM NetServ, provider
                of qualitative and cost effective software solutions.
            </td>
        </tr>
    </table>
</asp:Content>
