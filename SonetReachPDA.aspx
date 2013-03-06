<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SonetReachPDA.aspx.cs"
    Inherits="DigiMa.SonetReachPDA" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" xmlns:fb="https://www.facebook.com/2008/fbml">
<head>
    <title>SonetReachPDA</title>
    <script src="https://connect.facebook.net/en_US/all.js\" type="text/javascript"></script>
    <script src="ScriptsSonetReach/jquery-1.4.1.min.js" type="text/javascript"></script>
    <script type="text/javascript" src="https://ajax.googleapis.com/ajax/libs/jquery/1.5.0/jquery.min.js"></script>
    <link href="Styles/StyleSheet2.css" rel="stylesheet" type="text/css" />
    <link href="ScriptsSonetReach/Facebookstyles.css" id="facebookIDStyleSheets" rel="stylesheet"
        type="text/css" runat="server" />
    <asp:Literal runat="server" ID="litOGTags"></asp:Literal>
    <script type="text/javascript">
        function AsycRequest(sURL) {
            // <!--
            //alert(sURL);
            var xmlhttp = false;
            // JScript gives us Conditional compilation, we can cope with old IE versions.
            // and security blocked creation of the objects.
            /*@cc_on@*/
            /*@if (@_jscript_version >= 5)
            try {
                xmlhttp = new ActiveXObject("Msxml2.XMLHTTP");
            } catch (e) {
                try {
                    xmlhttp = new ActiveXObject("Microsoft.XMLHTTP");
                } catch (E) {
                    xmlhttp = false;
                }
            }
            @end@*/
            if (!xmlhttp && typeof XMLHttpRequest != 'undefined') {
                try {
                    xmlhttp = new XMLHttpRequest();
                } catch (e) {
                    xmlhttp = false;
                }
            }
            if (!xmlhttp && window.createRequest) {
                try {
                    xmlhttp = window.createRequest();
                } catch (e) {
                    xmlhttp = false;
                }
            }

            xmlhttp.open("GET", sURL, true);
            xmlhttp.onreadystatechange = function () {
                if (xmlhttp.readyState == 4) {
                    var tagtext = xmlhttp.responseText;
                    //                    alert(tagtext);
                    if (tagtext == 'true') {
                        alert('Successfully stored notifier.');
                    }
                }
            };
            xmlhttp.send(null);
            // -->
        }

        

    </script>
    <style>
        #spanNoitpac
        {
            padding: 2px;
            font-size: medium;
            text-align: center;
            padding: 2px;
            width: 100%;
            height: 100%;
            font-family: "Segoe UI" ,Arial,Helvetica,sans-serif;
            font-weight: bold;
        }
        .FB_Share
        {
            background-image: url('Images/SNR_facebook.png');
            width: 23px;
            height: 23px;
            display: block;
        }
        .FB_Recommend
        {
            background-image: url('Images/SNR_recommend.png');
            width: 23px;
            height: 22px;
            display: block;
        }
        #btnShare
        {
            display: block;
        }
        .FB_Like
        {
            background-image: url('Images/fb-like-button.png');
            width: 47px;
            height: 24px;
            display: block;
            cursor: pointer;
            background-color
        }
        #headRow
        {
            height:35px;
            color:White;
            padding: 2px;
            font-size: medium;
            text-align: left;
            padding: 2px;
            width: 100%;
            height: 100%;
            font-family: "Segoe UI" ,Arial,Helvetica,sans-serif;
            font-weight: bold;
        }
    </style>
    <script type="text/javascript">
        $(document).ready(function () {
            $("#headRow").css('background-color', '#35619f');
            //$("#mainRow").css('background-color', '#f2f7fc');
            $("#template5").css('margin-left', '10px');
            $("#template6").css('margin-left', '10px');

        });
    </script>
</head>
<body>
    <div id="fb-root">
    </div>
    <script src="https://connect.facebook.net/en_US/all.js"></script>
    <script type="text/C#">
    <asp:Literal ID="litEnableFBJS" runat="server"></asp:Literal>
   
    </script>
    <form id="Form1" runat="server">
    <div id="divTemplate" style="overflow: hidden; height: auto;" runat="server">
        <table style="margin-left: 200px;">
            <tr id="headRow" runat="server">
                <td>
                    <a id="hrefMessage" target="_blank" href="http://m.facebook.com">
                        <img src="Images/facebook-logo-small.jpg" /></a>
                </td>
            </tr>
            <tr id="mainRow" runat="server">
                <td>
                    <asp:Literal ID="litHTML" runat="server"></asp:Literal>
                </td>
            </tr>
        </table>
        <asp:HiddenField ID="hdnLiked" runat="server" />
        <asp:HiddenField ID="hiddenReqUSersLit" runat="server" />
        <div id="Div1">
        </div>
        <script>            (function (d, s, id) {
                var js, fjs = d.getElementsByTagName(s)[0];
                if (d.getElementById(id)) return;
                js = d.createElement(s); js.id = id;
                js.src = "//connect.facebook.net/en_US/all.js#xfbml=1&appId=140608429396924";
                fjs.parentNode.insertBefore(js, fjs);
            } (document, 'script', 'facebook-jssdk'));</script>
    </div>
    </form>
</body>
</html>
