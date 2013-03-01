<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PreviewApp.aspx.cs" Inherits="DigiMa.PreviewApp" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>PREVIEW</title>
    <style type="text/css">
        .modalBackground
        {
            text-align: center;
            background-color: White;
            height: 1600px;
        }
    </style>
    <script src="ScriptsSonetReach/jquery-1.4.1.min.js" type="text/javascript"></script>
    <script type="text/javascript" src="https://ajax.googleapis.com/ajax/libs/jquery/1.5.0/jquery.min.js"></script>
    <script type="text/javascript" src="ScriptsSonetReach/jquery-ui-1.8.17.custom.min.js"></script>
    <script src="ScriptsSonetReach/jquery.simplemodal.js" type="text/javascript"></script>
    <style type="text/css">
        .simplemodal-wrap
        {
            height:400px;
        }
        .style1
        {
            width: 240px;
            height: 340px;
            border-radius: 10px;
            font-size: 16px;
            font-family: Segoe UI,Tahoma,Arial,Verdana,sans-serif;
        }
        .style2
        {
            width: 230px;
            height: 90px;
            border-radius: 10px;
            font-size: 16px;
            font-family: Segoe UI,Tahoma,Arial,Verdana,sans-serif;
        }
        .textboxesSweepStakes
        {
            border-radius: 5px;
            background-color: #e5e3e3;
            height: 204px;
            width: 200px;
            margin-top: 0px;
            word-wrap: break-word;
        }
        #AppPreview
        {
            background: url("Images/Preview_New.png");
            width: 1500px;
            height: 1400px;
            position: absolute;
        }
        #imgComment
        {
            background: url("Images/fb-comment_Preview.jpg");
            height:100%;
            width:100%;
        }
        #spanNoitpac
        {
            padding: 2px;
            font-size: xx-large;
            text-align: center;
            padding: 2px;
            width: 100%;
            height: 100%;
            font-family: "Segoe UI" ,Arial,Helvetica,sans-serif;
            font-weight: bold;
        }
        #ShareButton
        {
            background-image: url('Images/SNR_facebook.png');
            width: 32px;
            height: 32px;
            display: block;
        }
        #LeadButton
        {
            background-image: url('Images/SNR_inquiry.png');
            width: 133px;
            height: 33px;
            display: block;
        }
        .FB_Invite
        {
            background-image: url('Images/FB_Invite.jpg');
            width: 133px;
            height: 33px;
            display: block;
        }
        #ReccoButton
        {
            background-image: url('Images/SNR_recommend.png');
            width: 32px;
            height: 32px;
            display: block;
        }
        .FB_Enter
        {
            background-image: url('Images/FB_Enter.png');
            width: 133px;
            height: 33px;
            display: block;
        }
        #LikeButton
        {
            background-image: url('Images/fb-like-button.png');
            width: 47px;
            height: 24px;
            display: block;
            cursor: pointer;
        }
        .FB_HideLike
        {
            background-image: url('Images/fb-like-button.png');
            width: 47px;
            height: 24px;
            display: block;
            cursor: default;
        }
        #printButton
        {
            background-image: url('Images/print.png');
            width: 33px;
            height: 33px;
            display: block;
        }
        #emailButton
        {
            background-image: url('Images/email.png');
            width: 33px;
            height: 33px;
            display: block;
            cursor: pointer;
        }
        #TwiButton
        {
            background-image: url('Images/SNR_twitter.png');
            width: 32px;
            height: 32px;
            display: block;
            background-repeat: no-repeat;
        }
        #osx-container
        {
            height:444px;
        }
    </style>
    <link href="Styles/Site.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript">
        $(document).ready(function () {
            $("temp1ContentMain").css('background-color', 'White');
            $("#template5").css('margin-left', '0px');
            $("#TandC").click(function () {
                return false;
            });

            $("#PrivPol").click(function () {
                return false;
            });
            $("#OffRul").click(function () {
                return false;
            });

            $("h2 ").css('font-family', 'Verdana');
            $("h2 ").css('color', 'Black');
            $("#osx-container").css('height', '444px');

        });


       
    </script>
</head>
<body style="background-color: White; text-align: center; height: 800px;">
    <form id="form1" runat="server">
    <div id="AppPreview" title="Use F11 key to view preview better">
        <table align="center" style="margin-left: 250px; margin-top: 90px;">
            <tr align="center">
                <td>
                    <asp:Literal ID="litPreview" runat="server"></asp:Literal>
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
