<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="QuickRegister.aspx.cs"
    Inherits="DigiMa.QuickRegister" MasterPageFile="~/MasterPage.master" %>

<asp:Content runat="server" ContentPlaceHolderID="head" ID="cphHead">
    <meta http-equiv="X-UA-Compatible" content="IE=edge,chrome=1" />
    <link rel="stylesheet" href="Styles/Chrome.css" type="text/chrome/safari" />
    <link rel="stylesheet" type="text/css" media="all" href="Styles/niceforms-default.css" />
    <%--<link href="Styles/master_style1.css" rel="stylesheet" type="text/css" />--%>
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.7.1/jquery.min.js"></script>
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

        });
        function BrowserHidden_onclick() {

        }           

    </script>
    <script type="text/javascript">
        $(document).ready(function () {

            $("#logohide").hide();
        });
    </script>
    <%--<script type="text/javascript">
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
    </script>--%>
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
        .leftdivinsidePages
        {
            float: left;
            position: absolute;
            width: 720px;
            margin-top: -25px;
        }
        .logo
        {
            float: left;
            margin-top: 8px;
            width: 250px;
            display: block;
            margin-left: 167px;
        }
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
    <style type="text/css">
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
        #body_btnSubmit
        {
            background-image: url('Images/digima_syubmit.png');
            width: 97px;
            height: 27px;
            cursor: pointer;
            display: block;
            background-color: transparent;
            border: 0 none; /*margin-left: 35px;*/
            border-radius: 13px 13px 13px 13px;
        }
        #body_Reset
        {
            background-image: url('Images/backbuttonNew.png');
            width: 97px;
            height: 27px;
            cursor: pointer;
            display: block;
            background-color: transparent;
            border: 0 none;
            margin-left: 5px;
            border-radius: 13px 13px 13px 13px;
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
        .mattblackmenu
        {
            left: 76px;
            position: absolute;
            top: 5px;
        }
        .menusubinsidepages
        {
            background: url("Images/submenubg.png") no-repeat scroll 0 0 transparent;
            float: left;
            height: 50px;
            margin-left: 245px;
            margin-top: 7px;
            position: relative;
            width: 710px;
        }
        table
        {
            color: #8f1313;
            margin-left: 94px;
            margin-top: 10px;
        }
        .style1
        {
            color: Red;
            vertical-align: top;
            padding-top: 0px;
            margin: 0px;
            height: 46px;
        }
        .style3
        {
            text-align: left;
            position: relative;
            left: -4px;
            top: 182px;
            height: 74px;
            width: 296px;
        }
        .style4
        {
            height: 74px;
        }
        .style5
        {
            height: 22px;
        }
        .style6
        {
            height: 22px;
            width: 189px;
        }
        .style7
        {
            width: 189px;
            padding-left: 99px;
            position: absolute;
        }
        .style8
        {
            height: 22px;
            width: 189px;
            right: 4px;
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
</asp:Content>
<asp:Content runat="server" ContentPlaceHolderID="body" ID="body">
    <table width="90%">
        <tr>
            <td colspan="2" class="HeaderRegister">
                &nbsp;&nbsp;&nbsp;&nbsp;Registration Form<span style="margin-left: 61px;">
                    <img height="80px" width="100px" src="Images/60days6.png" style="position: absolute;
                        margin-left: -25px; margin-top: -10px;" alt="Trial 60 days" />
                </span>
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:ValidationSummary ID="ValidationSummary1" runat="server" ValidationGroup="val"
                    ShowMessageBox="true" ShowSummary="false" Class="valSummary" Height="40px" />
            </td>
        </tr>
        <tr>
            <td colspan="2" class="style1">
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Note: All
                fields are Mandatory
            </td>
        </tr>
        <tr>
            <td align="left" colspan="1" class="style8">
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Full Name:
            </td>
            <td colspan="1" class="style5">
                <asp:TextBox ID="txtFullName" CssClass="txtbox" runat="server" MaxLength="40" EnableViewState="true"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Name Required."
                    SetFocusOnError="True" ControlToValidate="txtFullName" ValidationGroup="val"
                    ValidationExpression="[a-zA-Z]+" Display="None"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td colspan="1" class="style6">
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Email ID:
            </td>
            <td colspan="1" class="style5">
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
            <td class="style3" colspan="1">
                <span class="regcolour">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    Enter The Letters Below </span>
                <br />
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<img
                    id="captcha" src="Captcha.aspx" /><br />
                <span style="text-align: left; padding: 0 0 0 02px; margin: 0px;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    Generate New?<span onclick="javascript:reloadCaptcha();" class="Click" style="cursor: pointer"
                        id="refreshcaptcha">&nbsp;Click Here</span><br />
                </span>
            </td>
            <td colspan="1" class="style4">
                <asp:TextBox ID="CodeNumberTextBox" ViewStateMode="Disabled" EnableViewState="False"
                    runat="server"></asp:TextBox>
                <asp:Label ID="errorlblsecurity" CssClass="regcolour" runat="server"></asp:Label>
                <asp:RequiredFieldValidator ID="rqtxtCodeNor" ControlToValidate="CodeNumberTextBox"
                    ValidationGroup="val" SetFocusOnError="true" runat="server" ErrorMessage="The characters you entered didn't match the word verification."
                    Display="None"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td colspan="2" align="justify">
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:CheckBox ID="checkTC" runat="server" />
                <asp:Label ID="Label1" runat="server"> I have accepted the <a href="TermsConditions.aspx" target="_blank" style="text-decoration: none;">
                        Terms & Conditions</a> and <a href="PrivacyPolicy.aspx" target="_blank" style="text-decoration: none;">
                            Privacy Policy</a> <br />&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;of SM NetServ Technologies Pvt Ltd</asp:Label>
                &nbsp;<div style="display: none;" id="validate_mycheckbox">
                    <span>You must accept the T&C and Privacy policy.</span>
                </div>
            </td>
        </tr>
        <tr>
            <td colspan="1" class="style7">
                <asp:Button ID="btnSubmit" runat="server" OnClick="Button1_Click" ValidationGroup="val"
                    CausesValidation="true" ViewStateMode="Disabled" EnableViewState="False" />
            </td>
            <td align="left" colspan="1" class="divForgotpasswordbtn">
                <asp:Button ID="Reset" runat="server" OnClick="reset_click" />
            </td>
        </tr>
    </table>
</asp:Content>
