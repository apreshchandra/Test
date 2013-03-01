<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CreateApp.aspx.cs" Inherits="DigiMa.CreateApp" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd" >
<html xmlns="http://www.w3.org/1999/xhtml" xmlns:fb="https://www.facebook.com/2008/fbml">
<head id="Head1" runat="server">
    <script src="https://connect.facebook.net/en_US/all.js" type="text/javascript"></script>
    <title></title>
    <script src="ScriptsSonetReach/jquery-1.4.1.min.js" type="text/javascript"></script>
    <asp:Literal runat="server" ID="litOGTags"></asp:Literal>
    <asp:Literal runat="server" ID="litNotifyLIKE"></asp:Literal>
    <script src="https://connect.facebook.net/en_US/all.js\" type="text/javascript"></script>
    <link href="ScriptsSonetReach/Facebookstyles.css" id="facebookIDStyleSheet" rel="stylesheet"
        type="text/css" runat="server" />
    <script type="text/javascript" src="https://ajax.googleapis.com/ajax/libs/jquery/1.5.0/jquery.min.js"></script>
    <script type="text/javascript" src="ScriptsSonetReach/jquery-ui-1.8.17.custom.min.js"></script>
    <script src="ScriptsSonetReach/jquery.watermark.js" type="text/javascript"></script>
    <!--[if IE]>
          
          <![endif]-->
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
        #imgLGateway
        {
            margin-left: 140px;
        }
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
            background-repeat: no-repeat;
            width: 22px;
            height: 33px;
            display: block;
        }
        .FB_Inquiry
        {
            background-image: url('Images/SNR_inquiry.png');
            background-repeat: no-repeat;
            width: 133px;
            height: 33px;
            display: block;
        }
        .FB_Invite
        {
            background-image: url('Images/FB_Invite.jpg');
            background-repeat: no-repeat;
            width: 133px;
            height: 33px;
            display: block;
        }
        .FB_Recommend
        {
            background-image: url('Images/SNR_recommend.png');
            background-repeat: no-repeat;
            width: 22px;
            height: 33px;
            display: block;
        }
        .FB_Enter
        {
            background-image: url('Images/FB_Enter.png');
            background-repeat: no-repeat;
            width: 133px;
            height: 33px;
            display: block;
        }
        .FB_Like
        {
            background-image: url('Images/fb-like-button.png');
            background-repeat: no-repeat;
            width: 50px;
            height: 22px;
            display: block;
            cursor: pointer;
        }
        .FB_HideLike
        {
            background-image: url('Images/fb-like-button.png');
            background-repeat: no-repeat;
            width: 47px;
            height: 24px;
            display: block;
            cursor: default;
        }
        .FBLogoImg
        {
            width: 33px;
            height: 33px;
        }
        .FB_Print
        {
            background-image: url('Images/print.png');
            background-repeat: no-repeat;
            width: 133px;
            height: 33px;
            display: block;
        }
        .FB_Email
        {
            background-image: url('Images/email.png');
            background-repeat: no-repeat;
            width: 133px;
            height: 33px;
            cursor: pointer;
            display: block;
        }
        .TW_Share
        {
            background-image: url('Images/SNR_twitter.png');
            background-repeat: no-repeat;
            width: 22px;
            height: 33px;
            display: block;
            background-repeat: no-repeat;
            padding: 0px 10px 0px 0px;
        }
        #divCouponDetails
        {
            background-image: url('Images/coupon_scissor_border_edit1.png');
            background-repeat: no-repeat;
            display: block;
            height: 417px;
            width: 550px;
        }
        
       #Like {
        border: medium none;
        height: 22px;
        margin-bottom: -16px;
        width: 50px;
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
       .SpanLike {
               float: right;
               font-family: Calibri;
               font-size: 15px;
               font-weight: normal;
               height: 14px;
               margin-bottom: -15px;
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
        #AppExpired
        {
            display: block;
            position: fixed;
            color: Black;
            _position: absolute; /* hack for internet explorer 6*/
            height: 76px;
            width: 300px;
            background: url("Images/background fill gray.png");
            border: 2px solid #cecece;
            z-index: 2;
            padding: 12px;
            font-size: 14px;
            font-family: Verdana;
            border-radius: 4px;
            border: 1px solid #60cdf6;
            margin-left: 255px;
            margin-top: 200px;
            text-align: center;
        }
        .Winnerdate
        {
            border-radius: 10px;
            font-size: 20px;
            font-family: Segoe UI,Tahoma,Arial,Verdana,sans-serif;
        }
        a
        {
            outline: 0;
            margin-bottom:-10px;
        }
    </style>
    <script type="text/javascript">
        $(document).ready(function () {
            $("#divTemplate").css('background-color', '');
            $("#businessimagediv").CSS('height', '800px');
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
                window.open("https://www.testsonetreach.com/FBPopUpUtil.aspx?Typ=TERMSCOND&Loader=" + document.getElementById("hdnAppConfigD").value, "TC", " height = 400, width = 400, menubar = 0, toolbar = 0, statusbar = 0, scrollbars = 1, resizable = 0");
            });

            $("#PrivPol").click(function () {
                window.open("https://www.testsonetreach.com/FBPopUpUtil.aspx?Typ=PRIVACY&Loader=" + document.getElementById("hdnAppConfigD").value, "PP", " height = 400, width = 400, menubar = 0, toolbar = 0, statusbar = 0, scrollbars = 1, resizable = 0");
            });

            $("#OffRul").click(function () {
                window.open("https://www.testsonetreach.com/FBPopUpUtil.aspx?Typ=RULES&Loader=" + document.getElementById("hdnAppConfigD").value, "Rul", " height = 400, width = 400, menubar = 0, toolbar = 0, statusbar = 0, scrollbars = 1, resizable = 0");
            });
            $("#tblTermsPrivAbout").css('font-family', '"Segoe UI",Arial,Helvetica,sans-serif');
            $("#tblTermsPrivAbout").css('align', 'left');
            $("#tblWidgets").css('font-family', '"Segoe UI",Arial,Helvetica,sans-serif');
            $("#tblCouponDetails").css('font-family', '"Segoe UI",Arial,Helvetica,sans-serif');
            $("#tblCouponDetails").css('margin-left', '10px');
            $("#tblCouponDetails").css('padding-top', '25px');
            $("#tblActionButtonsAndRedemption").css('width', '100%');
            $("#tblActionButtonsAndRedemption").css('font-family', '"Segoe UI",Arial,Helvetica,sans-serif');



            //            $("#menuIndexpage").click(function () {
            //                document.getElementById("hdnStatus").value = "home.html";
            //            });
        });  
    </script>
    <script type="text/javascript">
        $(document).ready(function () {
            if (document.getElementById("hdnStatus").value == "SHOW") {
                centerPopup(); loadPopup();
            }


        });
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
    <%--Script to align Template--%>
    <script type="text/javascript">

        function centerPopup() {
            var windowWidth = 520; //document.documentElement.clientWidth;
            var windowHeight = 800; //document.documentElement.clientHeight;
            var setmiddle = (800 - 520) / 2;


        }

        $(document).ready(function () {
            centerPopup();
            if ($("#fbcommentsDiv").html() != null) {
                if ($("#fbcommentsDiv").html().indexOf("fb-comments") == -1) {
                    $("#fbcommentsDiv").remove();
                    $("#fbcommentsDiv").css('border', 'none');
                }
                else {


                }
            }
            if ($("#fbcommentsDiv").html() != null) {
                if ($("#fbcommentsDiv").html().indexOf("fb-comments") == -1) {
                    $("#fbcommentsDiv").remove();
                    $("#fbcommentsDiv").css('border', 'none');
                }
                else {
                }
            }
            if ($("#tdShare").html() != null) {
                if ($("#tdShare").html().indexOf("FB_Share") == -1) {
                    $("#tdShare").remove();
                }
                else {
                }
            }

            if ($("#tdPosters").html() != null) {
                if ($("#tdPosters").html().indexOf("FB_Recommend") == -1) {
                    $("#tdPosters").remove();
                }
                else {
                }
            }
            if ($("#tdInkuiry").html() != null) {
                if ($("#tdInkuiry").html().indexOf("FB_Inquiry") == -1) {
                    $("#tdInkuiry").remove();
                }
                else {
                }
            }

            if ($("#tdrettiwT").html() != null) {
                if ($("#tdrettiwT").html().indexOf("TW_Share") == -1) {
                    $("#tdrettiwT").remove();
                }
                else {
                }
            }

            $("#tdShare").attr('title', 'Share with your friends');
            $("#tdPosters").attr('title', 'Recommend to your friends');
            $("#tdInkuiry").attr('title', 'Inquire about this Promotion');
        });        
    </script>
    <asp:Literal ID="litHeadBannerCount" runat="server"></asp:Literal>
</head>
<body>
    <form id="form1" runat="server">
    <script language="javascript" type="text/C#">
            <asp:literal runat="server" id="litLogin"></asp:literal>
    </script>
    <script type="text/C#">
    <asp:Literal ID="litEnableFBJS" runat="server"></asp:Literal>
    </script>
    <div id="divTemplate" style="overflow: hidden; background-color: none; height: auto;"
        runat="server">
        <asp:Literal ID="litAppHTML" runat="server"></asp:Literal>
        <asp:Literal ID="MainJavaScriptContent" runat="server"></asp:Literal>
        <asp:Button ID="btnPageSelector" runat="server" Visible="false" />
        <asp:HiddenField ID="hdnAppID" runat="server" />
        <asp:HiddenField ID="hdnStatus" runat="server" Value="SHOW" />
        <asp:HiddenField ID="hdnAppConfigD" runat="server" />
        <asp:HiddenField ID="hdnUserID" runat="server" />
    </div>
    <div id="AppExpired" runat="server" visible="false">
        <a id="aAppExpired" runat="server" target="_blank" style="margin-left: 2px; color: White;">
            Oops!! Looks like the content you are looking for is no longer available.</a>
    </div>
    <div id="popupContact" runat="server">
        <a id="popupContactClose">x</a> <a id="apppathLink" runat="server" target="_blank"
            style="margin-left: 2px; color: White;">Loading Campaign..........</a>
    </div>
    <div id="backgroundPopup" runat="server">
    </div>
    <div id="LinkForUSer">
        <a target="_blank" id="lnkAppLocation" href=""><span id="spnURL" runat="server"></span>
        </a>
    </div>
    <asp:HiddenField runat="server" ID="hdnAccessTok" />
    <asp:HiddenField runat="server" ID="hdnPageToLoad" />
    <asp:Button runat="server" ID="btnNavigate" Visible="false" />
    </form>
</body>
</html>
