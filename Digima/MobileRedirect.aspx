<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MobileRedirect.aspx.cs"
    Inherits="DigiMa.MobileRedirect" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" xmlns:fb="https://www.facebook.com/2008/fbml">
<head id="Head1" runat="server">
    <title></title>
    <script src="ScriptsSonetReach/jquery-1.4.1.min.js" type="text/javascript"></script>
    <asp:Literal runat="server" ID="litOGTags"></asp:Literal>
    <script type="text/javascript" src="https://ajax.googleapis.com/ajax/libs/jquery/1.5.0/jquery.min.js"></script>
    <script type="text/javascript" src="ScriptsSonetReach/jquery-ui-1.8.17.custom.min.js"></script>
    <script src="ScriptsSonetReach/jquery.watermark.js" type="text/javascript"></script>
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
                        //                        alert('Successfully stored notifier.');
                    }
                }
            };
            xmlhttp.send(null);
            // -->
        }

        

    </script>
    <style type="text/css">
        .defaultFacebookButtonGeorgiaAquarium
        {
            background-position: 0 0;
            background-image: url("Images/bgloginajax.jpg");
            background: #ebebeb;
            border-width: 2px;
            cursor: pointer;
            padding: 7px 7px;
            -moz-border-radius: 2px;
            -webkit-border-radius: 2px;
            -khtml-border-radius: 2px;
            text-decoration: none;
            text-align: justify;
            font-weight: bold;
            padding-left: 7px;
            padding-right: 7px;
            padding-top: 7px;
            padding-bottom: 7px;
            border: 1px solid #000000;
            border-radius: 4px;
        }
        .FB_Share
        {
            background-image: url('Images/SNR_facebook.png');
            width: 133px;
            height: 33px;
            display: block;
        }
        .FB_Inquiry
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
        .FB_Recommend
        {
            background-image: url('Images/SNR_recommend.png');
            width: 133px;
            height: 33px;
            display: block;
        }
        .FB_Enter
        {
            background-image: url('Images/FB_Enter.png');
            width: 133px;
            height: 33px;
            display: block;
        }
        .FB_Like
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
        .FB_Print
        {
            background-image: url('Images/print.png');
            width: 133px;
            height: 33px;
            display: block;
        }
        .FB_Email
        {
            background-image: url('Images/email.png');
            width: 133px;
            height: 33px;
            display: block;
            cursor: pointer;
        }
        #divCouponDetails
        {
            background-image: url('Images/coupon_scissor_border_edit1.png');
            display: block;
            height: 417px;
            width: 550px;
        }
        
        #Like
        {
            border: none;
            width: 47px;
            height: 24px;
        }
        
        #tblTemplateFive
        {
            empty-cells: hide;
        }
        /*.ie #Like
        {
            border: none;
            width: 47px;
            height: 24px; 
            padding-top:20px;
        }*/
        .SpanLike
        {
            float: right;
            font-family: Calibri;
            font-size: 15px;
            font-weight: normal;
            height: 14px;
            margin-top: -22px;
            padding-right: 42px;
        }
        /* .ie .SpanLike
        {
            float: left;
            margin-top: -22px;
            margin-left: 58px;
            font-size: 15px;
            font-family: Calibri; /*font-family: "lucida grande" ,tahoma,verdana,arial,sans-serif;*/
        /* font-weight: normal;
            height: 14px;
        }*/
        .divLike
        {
            float: right;
            font-family: Calibri;
            font-size: 15px;
            font-weight: normal;
            height: 14px;
            margin-top: -22px;
            padding-right: 7px;
        }
        
        /*.ie .divLike
        {
            float: right;
            font-family: Calibri;
            font-size: 15px;
            font-weight: normal;
            height: 14px;
            margin-top: -22px;
            padding-right: 24px;
        }*/
        
        
        .defaultFacebookButtonLike
        {
            color: #fff;
            cursor: pointer;
            -moz-border-radius: 2px;
            -webkit-border-radius: 2px;
            -khtml-border-radius: 2px;
            padding-left: 7px;
            padding-right: 7px;
            padding-top: 7px;
            padding-bottom: 7px;
            border-radius: 4px;
        }
        
        .defaultFacebookButtonLikeSpan
        {
            border-color: #000000;
            border-width: 1.5px;
            color: #fff;
            cursor: pointer;
            -moz-border-radius: 2px;
            -webkit-border-radius: 2px;
            -khtml-border-radius: 2px;
            border-radius: 4px;
            width: 40px;
            height: 25px;
            position: absolute;
            margin-top: -2px;
        }
        #lblLoaded
        {
            font-size: 16px;
            font-family: Segoe UI,Tahoma,Arial,Verdana,sans-serif;
        }
        .watermark
        {
            font-family: Arial;
            font-size: 0.7em;
            font-weight: bold;
            color: #808080;
        }
        #popupContact
        {
            display: none;
            position: fixed;
            color: Black;
            _position: absolute; /* hack for internet explorer 6*/
            height: 76px;
            width: 250px;
            background: url("Images/background fill gray.png");
            border: 2px solid #cecece;
            z-index: 2;
            padding: 12px;
            font-size: 14px;
            font-family: Verdana;
            border-radius: 4px;
            border: 1px solid #60cdf6;
            margin-left: 400px;
            margin-top: 200px;
        }
        #popupContactLIKE
        {
            background: url("Images/background fill gray.png") repeat scroll 0 0 transparent;
            border: 1px solid #60CDF6;
            border-radius: 4px 4px 4px 4px;
            color: Black;
            display: block;
            font-family: Verdana;
            font-size: 14px;
            height: 76px;
            margin-top: 110px;
            padding: 12px;
            position: fixed;
            width: 480px;
            z-index: 2;
        }
        #backgroundPopup
        {
            display: none;
            position: fixed;
            _position: absolute; /* hack for internet explorer 6*/
            height: 100%;
            width: 100%;
            top: 0;
            left: 0;
            background: #000000;
            border: 1px solid #cecece;
            z-index: 1;
        }
        #backgroundPopupLIKE
        {
            display: none;
            position: fixed;
            _position: absolute; /* hack for internet explorer 6*/
            height: 100%;
            width: 100%;
            top: 0;
            left: 0;
            background: #000000;
            border: 1px solid #cecece;
            z-index: 1;
        }
        #popupContact h1
        {
            text-align: left;
            color: #6FA5FD;
            font-size: 22px;
            font-weight: 700;
            border-bottom: 1px dotted #D3D3D3;
            padding-bottom: 2px;
            margin-bottom: 20px;
        }
        #popupContactClose
        {
            font-size: 14px;
            line-height: 14px;
            right: 6px;
            top: 4px;
            position: absolute;
            color: #6fa5fd;
            font-weight: 700;
            display: block;
            cursor: pointer;
        }
        #popupContactClosed
        {
            font-size: 14px;
            line-height: 14px;
            right: 6px;
            top: 4px;
            position: absolute;
            color: #6fa5fd;
            font-weight: 700;
            display: block;
            cursor: pointer;
        }
        #lnkLikeUs
        {
            background-position: 0 0;
            background: #ebebeb;
            border-width: 2px;
            color: Black;
            cursor: pointer;
            padding: 7px 7px;
            font-size: 11px;
            font-family: Segoe UI,Tahoma,Arial,Verdana,sans-serif;
            -moz-border-radius: 2px;
            -webkit-border-radius: 2px;
            -khtml-border-radius: 2px;
            text-decoration: none;
            text-align: justify;
            font-weight: bold;
            padding-left: 7px;
            padding-right: 7px;
            padding-top: 7px;
            padding-bottom: 7px;
            border: 1px solid #000000;
            border-radius: 4px;
            width: 170px;
            display: block;
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
    </style>
    <script type="text/C#">
    
    <asp:Literal ID="litOGT" runat="server"></asp:Literal>
   
    </script>
    <script type="text/javascript">
        $(document).ready(function () {
            $("temp1ContentMain").css('background-color', 'White');
            $("temp1Head").css('display', 'none');
            $("#TandC").css('font-family', 'Verdana');
            $("#TandC").css('font-size', '13px');
            $("#PrivPol").css('font-family', 'Verdana');
            $("#PrivPol").css('font-size', '13px');
            $("#OffRul").css('font-family', 'Verdana');
            $("#OffRul").css('font-size', '13px');
            //            if ($("#fbcommentsDiv").html().indexOf("\n") == -1) {
            //                $("#fbcommentsDiv").css('display', 'block');
            //            }
            //            else {
            //                $("#fbcommentsDiv").css('display', 'none');
            //            }

            $("#TandC").click(function () {
                window.open("https://www.sonetreach.com/Mobile/Mobile/FBPopUpUtil.aspx?Typ=TERMSCOND&Loader=" + document.getElementById("hdnAppConfigD").value, "TC", " height = 400, width = 400, menubar = 0, toolbar = 0, statusbar = 0, scrollbars = 1, resizable = 0");
            });

            $("#PrivPol").click(function () {
                window.open("https://www.sonetreach.com/Mobile/Mobile/FBPopUpUtil.aspx?Typ=PRIVACY&Loader=" + document.getElementById("hdnAppConfigD").value, "PP", " height = 400, width = 400, menubar = 0, toolbar = 0, statusbar = 0, scrollbars = 1, resizable = 0");
            });

            $("#OffRul").click(function () {
                window.open("https://www.sonetreach.com/Mobile/Mobile/FBPopUpUtil.aspx?Typ=RULES&Loader=" + document.getElementById("hdnAppConfigD").value, "Rul", " height = 400, width = 400, menubar = 0, toolbar = 0, statusbar = 0, scrollbars = 1, resizable = 0");
            });
            $("#tblTermsPrivAbout").css('font-family', '"Segoe UI",Arial,Helvetica,sans-serif');
            $("#tblTermsPrivAbout").css('align', 'left');
            $("#tblWidgets").css('font-family', '"Segoe UI",Arial,Helvetica,sans-serif');
            $("#tblCouponDetails").css('font-family', '"Segoe UI",Arial,Helvetica,sans-serif');
            $("#tblCouponDetails").css('margin-left', '10px');
            $("#tblCouponDetails").css('padding-top', '25px');
            $("#tblActionButtonsAndRedemption").css('width', '100%');
            $("#tblActionButtonsAndRedemption").css('font-family', '"Segoe UI",Arial,Helvetica,sans-serif');

        });  
    </script>
    <script type="text/javascript">
        //        $(document).ready(function () {
        //            if (document.getElementById("hdnStatus").value == "SHOW") {
        //                centerPopup(); loadPopup();
        //            }
        //        });
        var popupStatus = 0;
        //centering popup
        function centerPopup() {
            //request data for centering
            var windowWidth = $(window).width();
            var windowHeight = $(window).height();
            var popupHeight = $("#popupContact").height();
            var popupWidth = $("#popupContact").width();
            //centering
            $("#popupContact").css({
                "position": "absolute",
                "top": (windowHeight / 2 - popupHeight / 2) - 80,
                "left": (windowWidth / 2 - popupWidth / 2) + 5
            });
            //only need force for IE6

            $("#backgroundPopup").css({
                "height": windowHeight
            });

        }
        //loading popup with jQuery magic!
        function loadPopup() {
            //loads popup only if it is disabled
            if (popupStatus == 0) {
                $("#backgroundPopup").css({
                    "opacity": "0.7"
                });
                $("#backgroundPopup").fadeIn("slow");
                $("#popupContact").fadeIn("slow");
                popupStatus = 1;
            }
        }
        //disabling popup with jQuery magic!
        function disablePopup() {
            //disables popup only if it is enabled
            if (popupStatus == 1) {
                $("#backgroundPopup").fadeOut("slow");
                $("#popupContact").fadeOut("slow");
                popupStatus = 0;

            }
        }
    </script>
</head>
<body>
    <!-- Load the Facebook JavaScript SDK -->
    <div id="fb-root">
    </div>
    <script type="text/javascript">
    <asp:Literal ID="litEnableFBJS" runat="server"></asp:Literal>
        // Initialize the Facebook JavaScript SDK
        //        FB.init({
        //            appId: '295889527140091',
        //            xfbml: true,
        //            status: true,
        //            cookie: true
        //        });


        // Check if the current user is logged in and has authorized the app
        window.setTimeout(function () {

            FB.getLoginStatus(checkLoginStatus);
        }, 500);
        // Login in the current user via Facebook and ask for email permission
        function authUser() {
            FB.login(checkLoginStatus, { scope: 'email' });
        }

        // Check the result of the user status and display login button if necessary
         var posted=0;
        function checkLoginStatus(response) {
       
            if (response && response.status == 'connected') {
            
                //alert('User is authorized');
                document.getElementById('hdnSignedRequest').value = response.authResponse.signedRequest;
                document.getElementById('hdnAuthToken').value = response.authResponse.accessToken;
                //console.log(response.authResponse.accessToken);
                document.cookie=response.authResponse.accessToken;
               document.forms= response.authResponse.userID;
               //alert(document.cookie.toString());
                //alert(response.authResponse.userID);
                document.getElementById('hdnUserID').value = response.authResponse.userID;
                // Hide the login button
                document.getElementById('loginButton').style.display = 'none';
                
               if(document.getElementById('hdnUserID').value=='' || posted==0){
               document.getElementById("btnRefresh").click(); posted=1;
               }
                
            } else {
                //alert('User is not authorized');

                // Display the login button
                document.getElementById('loginButton').style.display = 'block';
            }
        }
       
    </script>
    <form id="aspnetForm" runat="server">
    <div id="divTemplate" style="overflow: hidden; height: auto;" runat="server">
        <asp:Literal ID="litHTML" runat="server"></asp:Literal>
        <asp:HiddenField ID="hdnSignedRequest" runat="server" />
        <asp:HiddenField ID="hdnAuthToken" runat="server" />
        <asp:HiddenField ID="hdnUserID" runat="server" />
        <asp:HiddenField ID="hdnLike" runat="server" />
    </div>
    <input id="loginButton" type="button" value="Login with Facebook!!" onclick="authUser();" />
    <div style="display: none">
        <asp:Button ID="btnRefresh" runat="server" UseSubmitBehavior="false" />
    </div>
    </form>
</body>
</html>
