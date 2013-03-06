<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Confirmation.aspx.cs" Inherits="DigiMa.Confirmation" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Confirmation</title>
    <script src="http://ajax.googleapis.com/ajax/libs/jquery/1.4.2/jquery.min.js?ver=1.4.2"></script>
    <link href="Styles/style1.css" rel="stylesheet" type="text/css" />
    <link href="Styles/stylesheet1.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="ScriptsSonetReach/jquery-1.4.1.min.js"></script>
    <script type="text/javascript" src="ScriptsSonetReach/login.js"></script>
    <link href="Styles/style_new_menu.css" rel="stylesheet" type="text/css" />
    <link href="Styles/menu_style.css" rel="stylesheet" type="text/css" />
    <link href="Styles/Chrome.css" rel="stylesheet" type="text/css" />
    <!--[if IE 7]>
	<link rel="stylesheet" type="text/css" href="Styles/ie7.css">
<![endif]-->
    <script type="text/javascript">
        $.noConflict()
        $(document).ready(function () {

            window.onload = function () {
                $("#txtpasswordnew").val('');
                $("#txtpasswordsec").val('');
            };
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
      
    </script>
    <style type="text/css">
        #newFrm
        {
            left: -36px;
            margin-top: -7px;
            position: absolute;
            top: 0;
            vertical-align: middle;
            z-index: 100;
        }
        .leftdivinsidePages
        {
            float: left;
            margin-top: -20px;
            position: absolute;
            width: 720px;
        }
        .menusubinsidepages
        {
            background: url("Images/submenubg.png") no-repeat scroll 0 0 transparent;
            float: left;
            height: 50px;
            margin-left: 245px;
            margin-top: 8px;
            position: relative;
            width: 710px;
        }
        
        
        .logo
        {
            display: block;
            float: left;
            margin-bottom: 1px;
            margin-left: 101px;
            margin-top: 2px;
            width: 250px;
        }
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
        .divReturnHome
        {
            margin: -240px 28px 0;
            padding-left: 375px;
            text-align: center;
            width: 250px;
        }
    </style>
</head>
<body style="background: url('Images/body_bg.jpg'); background-color: #fff; background-repeat: repeat-x;
    background-position: top;">
    <form id="form1" runat="server">
    <%-- </div>
    <div class="masterbody">--%>
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
                                ValidationGroup="password" runat="server" />
                        </td>
                    </tr>
                </table>
            </div>
        </div>
    </div>
    </form>
    <div>
        <img src="images/spacer.png" height="5" width="100%" alt="" /></div>
</body>
</html>
