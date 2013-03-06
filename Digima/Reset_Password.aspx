<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Reset_Password.aspx.cs"
    Inherits="DigiMa.Reset_Password" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Reset Password</title>
    <script src="http://ajax.googleapis.com/ajax/libs/jquery/1.4.2/jquery.min.js?ver=1.4.2"></script>
    <link href="Styles/master_style.css" rel="stylesheet" type="text/css" />
    <link href="Styles/style1.css" rel="stylesheet" type="text/css" />
    <link href="Styles/stylesheet1.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="ScriptsSonetReach/jquery-1.4.1.min.js"></script>
    <script type="text/javascript" src="ScriptsSonetReach/login.js"></script>
    <link rel="shortcut icon" href="Images/sonetreachicon.ico" />
    <link href="Styles/Chrome.css" rel="stylesheet" type="text/css" />
    <!--[if IE ]>
	<link rel="stylesheet" type="text/css" href="Styles/ie7.css" />
<![endif]-->
    <script type="text/javascript">
        $.noConflict()
        $(document).ready(function () {

            window.onload = function () {
                $("#txtpasswordnew").val('');
                $("#txtpasswordsec").val('');
            };
            //                $("#trError").css("style", "display:none");
            //                $("#txtemail").focus();
            //                // $("#trError").hide();

            //            var button = $('#loginButton');
            //            var box = $('#loginBox');
            //            var form = $('#loginForm');
            //            var email = $("#txtemail").val();
            //            var pwd = $("#txtpassword").val();
            //            var button_previous = $("#btnclose");
            //            var popupOpen = false;
            //            var btncloseclick = false;
            //            //var e = jQuery.Event("click");

            //            box.load(function () {
            //                $("#txtemail").val('');
            //                $("#txtpassword").val('');
            //                $("#trError").addClass("style", "display:none");
            //            });

            //            button.click(function () {
            //                box.toggle();
            //                button.toggleClass('active');
            //                //$('#loginForm').addClass("style", "display:block");
            //                $("#txtemail").val('');
            //                $("#txtpassword").val('');
            //                $("#txtemail").focus();
            //                $("#username_warn").empty();
            //                $("#password_warn").empty();
            //                $("#lblError").empty();
            //            });


            //            $("#btnclose").bind('click', function () {
            //                //$('#btnclose').unbind('click', fireClick);
            //                popupOpen = true;
            //                btncloseclick = true;
            //                $("#username_warn").empty();
            //                $("#password_warn").empty();
            //                $("#lblError").empty();
            //                box.hide();
            //            });



            //            $("#txtemail").keydown(function () {

            //                var username_length;
            //                username_length = $("#txtemail").val().length;
            //                $("#username_warn").empty();


            //                if (username_length < 1) //|| (!button_previous.click)
            //                    $("#username_warn").append("Email ID is required !");

            //            });

            //            $("#txtpassword").keydown(function () {
            //                var password_length;

            //                password_length = $("#txtpassword").val().length;
            //                $("#password_warn").empty();

            //                if (password_length < 1)
            //                    $("#password_warn").append("Password is required !");

            //            });

            $("#imgAnalytics").mouseover(function () {
                $("#imgAnalytics").css('background-color', 'fffff');
            });

            // Close login form on click of esc button
            window.onkeyup = function (event) {
                if (event.keyCode == 27) {
                    box.hide();
                }

            }


        });
        function show() {
            document.getElementById('newFrm').style.display = 'Block';
        }
        $(document).ready(function () {
            $('.button').mousedown(function () {
                $('.errspan').hide();
            });
        });
        //       

    </script>
    <style type="text/css">
        .classdis
        {
            padding-top: 20px;
            padding-left: 175px;
        }
        .aligndiv
        {
            font-size: 14px; /*font-weight: bold;*/
            padding: 20px 0 4px 4px; /*text-align: left;*/
        }
        .diverroruser
        {
            font-size: 16px;
            margin-left: 444px;
            margin-right: 225px;
            margin-top: 8px;
            height: 480px;
            width: 600px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div class="masterbody">
        <div class="masterwrapper">
            <div class="sonetlogo">
                <img src="images/logo.png" border="0" alt="SonetReach" /></div>
        </div>
        <div class="clr">
        </div>
        <div style="padding-top: 10px;">
            <img src="images/greytop_border.png" height="4" width="100%" alt="" /></div>
        <div id="divBackBtn" runat="server" class="backwrapper" style="display: none;">
            <a href="Home.aspx" class="backlink">Back</a></div>
    </div>
    <div class="masterbody">
        <div class="masterwrapper">
            <div class="diverroruser">
                <asp:Label runat="server" ID="lblLoginuser" ForeColor="#f7c458"></asp:Label>
            </div>
        </div>
        <div align="center" id="newFrm" class="hidden" runat="server">
            <div class="adminlolginpopup">
                <div class="aligndiv">
                    <%--class="loginfield loginfieldArticle"--%>
                    <table cellspacing="0px" cellpadding="3px">
                        <tr>
                            <td colspan="2">
                                <span style="color: #0081C1; font-size: 13pt; font-weight: bold; padding-left: 25px;">
                                    Please Change Your Password </span>
                                <br />
                                <br />
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                <asp:ValidationSummary ID="ValidationSummary2" CssClass="valsumry" runat="server"
                                    ValidationGroup="password" ForeColor="#FF5050" />
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 130px; height: 25px;">
                                New Password
                            </td>
                            <td>
                                <asp:TextBox ID="txtpasswordnew" CssClass="txtbox" runat="server" MaxLength="15"
                                    TextMode="Password"> </asp:TextBox><br />
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="Password Required"
                                    ValidationGroup="password" CssClass="colour" Display="None" ControlToValidate="txtpasswordnew"></asp:RequiredFieldValidator>
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator6" ValidationGroup="password"
                                    runat="server" ErrorMessage="Numbers,Characters Allowed (Minimum Length 8)" ControlToValidate="txtpasswordnew"
                                    CssClass="colour" Display="None" ValidationExpression="\w{8,32}"></asp:RegularExpressionValidator>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 130px; height: 25px;">
                                Confirm Password
                            </td>
                            <td>
                                <asp:TextBox ID="txtpasswordsec" CssClass="txtbox" runat="server" MaxLength="15"
                                    TextMode="Password"> </asp:TextBox>
                                <asp:CompareValidator ID="CompareValidator1" CssClass="colour" runat="server" ErrorMessage="Password Mismatch"
                                    ControlToCompare="txtpasswordnew" Display="None" ControlToValidate="txtpasswordsec"
                                    ValidationGroup="password"></asp:CompareValidator>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" CssClass="colour" runat="server"
                                    ErrorMessage="Confirmation Password Required" ValidationGroup="password" Display="None"
                                    ControlToValidate="txtpasswordsec"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2" class="classdis">
                                <asp:Button ID="submitbtn" CssClass="toplink" OnClick="ChangePasswordUser_click"
                                    ValidationGroup="password" runat="server" Text="Save" />
                            </td>
                        </tr>
                    </table>
                </div>
            </div>
        </div>
    </div>
    </form>
    <div>
        <img src="images/spacer.png" height="5" width="100%" alt="" /></div>
    <div class="footercopy">
        Copyright <a href="http://www.smnetserv.com/" target="_blank" class="url" style="text-decoration: underline;">
            SM NetServ Technologies Pvt Ltd</a> 2012 - Offshore Software Development Company,
        India</div>
</body>
</html>
