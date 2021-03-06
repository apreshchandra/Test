﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CanvasAreaPromoOne.aspx.cs"
    Inherits="DigiMa.CanvasAreaPromoOne" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" xmlns:og="http://ogp.me/ns#" xmlns:fb="http://www.facebook.com/2008/fbml">
<head id="Head1" runat="server">
    <title>CANVAS AREA</title>
    <meta http-equiv="X-UA-Compatible" content="IE=9" />
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.7.2/jquery.js" type="text/javascript"></script>
    <script type="text/javascript" src="ScriptsSonetReach/jquery-1.4.1.min.js"></script>
    <script type="text/javascript" src="https://ajax.googleapis.com/ajax/libs/jqueryui/1.8.16/jquery-ui.js"></script>
    <%-- <script type="text/javascript" src="ScriptsSonetReach/jquery-ui-1.8.17.custom.min.js"></script>
    <script src="ScriptsSonetReach/jquery.js" type="text/javascript"></script>
    <script src="ScriptsSonetReach/jquery.fancybox-1.3.4.pack.js" type="text/javascript"></script>
    <script src="ScriptsSonetReach/Fancybox/jquery.fancybox-1.3.4.js" type="text/javascript"></script>--%>
    <script src="ScriptsSonetReach/jquery.simplemodal.js" type="text/javascript"></script>
    <script src="ScriptsSonetReach/osx.js" type="text/javascript"></script>
    <link href="Styles/osx.css" rel="stylesheet" type="text/css" />
    <script src="http://code.jquery.com/jquery-latest.js" type="text/javascript"></script>
    <link href="ScriptsSonetReach/Fancybox/jquery.fancybox-1.3.4.css" rel="stylesheet"
        type="text/css" />
    <link rel="shortcut icon" href="Images/sonetreachicon.ico" />
    <script src="ScriptsSonetReach/jquery-1.5.0.min.js" type="text/javascript"></script>
    <link href="Styles/calendrical.css" rel="stylesheet" type="text/css" />
    <script src="ScriptsSonetReach/fileuploader.js" type="text/javascript"></script>
    <script src="ScriptsSonetReach/sliding.form.js" type="text/javascript"></script>
    <link href="Styles/Coupon.css" rel="stylesheet" type="text/css" />
    <script src="ScriptsSonetReach/tabs.js" type="text/javascript"></script>
    <link href="Styles/CouponTab.css" rel="stylesheet" type="text/css" />
    <script src="ScriptsSonetReach/jquery.calendrical.js" type="text/javascript"></script>
    <script src="ScriptsSonetReach/Fancybox/jquery.watermark.min.js" type="text/javascript"></script>
    <style type="text/css">
        .checkboxesCampON
        {
            color: Gray;
            text-shadow: 1px 1px 1px Gray;
        }
        .checkboxesCampOFF
        {
            color: Gray;
            text-shadow: none;
        }
        #wzd
        {
            margin-left: 180px;
            width: 990px;
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
        #popupContact
        {
            display: none;
            position: fixed;
            color: White;
            position: absolute; /* hack for internet explorer 6*/
            height: 150px;
            width: 250px;
            background: url("Images/bg_fil_gray_CustTAB.png");
            border: 2px solid #cecece;
            z-index: 2;
            padding: 12px;
            font-size: 14px;
            font-family: Verdana;
            border-radius: 4px;
            border: 1px solid #60cdf6;
            background-repeat: repeat-y;
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
            color: Black;
            font-weight: 700;
            display: block;
            cursor: pointer;
        }
        .modal-overlay
        {
            position: fixed;
            top: 0;
            right: 0;
            bottom: 0;
            left: 0;
            height: 100%;
            width: 100%;
            margin: 0;
            padding: 0;
            background: #fff;
            opacity: .75;
            filter: alpha(opacity=75);
            -moz-opacity: 0.75;
            z-index: 101;
        }
        .modal-window
        {
            position: fixed;
            top: 50%;
            left: 50%;
            margin: 0;
            padding: 0;
            z-index: 102;
        }
        .close-window
        {
            position: absolute;
            width: 32px;
            height: 32px;
            right: 8px;
            top: 8px;
            background: transparent url('/examples/modal-simple/close-button.png') no-repeat scroll right top;
            text-indent: -99999px;
            overflow: hidden;
            cursor: pointer;
            opacity: .5;
            filter: alpha(opacity=50);
            -moz-opacity: 0.5;
        }
        .close-window:hover
        {
            opacity: .99;
            filter: alpha(opacity=99);
            -moz-opacity: 0.99;
        }
    </style>
    <script type="text/javascript">
        $(document).ready(function () {
            $("#divwrapper").css('overflow-y', 'scroll');
            $("#divwrapper").css('height', '550px');
            $("#divwrapper").css('overflow-x', 'none');
            $("#filePromo2LikeGateWayImage").css("display", "none");
            $("#spnInquiryLabel").css("display", "none");
            $("#txtInquiryEmail").css("display", "none");
            $('#chkLikeGateway').click(function () {
                var checked = $(this).attr('checked');
                if (checked) {
                    $("#filePromo2LikeGateWayImage").css("display", "block");
                } else {
                    $("#filePromo2LikeGateWayImage").css("display", "none");
                }

            });

            $('#chkInquiry').click(function () {
                var checked = $(this).attr('checked');
                if (checked) {
                    $("#spnInquiryLabel").css("display", "block");
                    $("#txtInquiryEmail").css("display", "block");
                } else {
                    $("#spnInquiryLabel").css("display", "none");
                    $("#txtInquiryEmail").css("display", "none");
                }

            });

            $("#datepickerStart").focusout(function () {
                //CompareDates();
                CalculateEndDate();
            });
        });

        function tabSelection(obj) {

            document.getElementById('hdnCode').value = obj.code;
            document.getElementById('hdnAppid').value = obj.app_id;
            if (document.getElementById('hdnPostBackStatus').value == "") {
                document.getElementById('hdnPostBackStatus').value = "DONE";
                document.getElementById("btnRefresh").click();
                //__doPostBack('hdnCode', obj.code);
                //window.close();
            }
        }

        function SetTabStatus3() {
            document.getElementById('hdnTabStatus').value = "step_three_complete";
        }
        function SetTabStatus2() {
            document.getElementById('hdnTabStatus').value = "step_two_complete";
        }

        function SetTabStatus1() {
            document.getElementById('hdnTabStatus').value = "step_one_complete";
        }
        function callModalPopUp(pageName) {
            //HideModalTable();
            document.getElementById('iFrameModal').src = pageName + document.getElementById('hdnPDID').value + "&CDID=" + document.getElementById('hdnfield').value;
            document.getElementById('btnModal').click();
        }

        function closeModalExtender() {
            $("#hlnModalClose").trigger("click");
        }


        $(document).ready(function () {
            jQuery('#temp1Head').mouseover(function () {
                $('#temp1Head').css('background-color', '#C0D9D9');
            });

            jQuery('#temp1Head').mouseout(function () {
                $('#temp1Head').css('background-color', '#84bce6');
            });
        });

        $(document).ready(function () {
            jQuery('#temp1ContentMain').mouseover(function () {
                $('#temp1ContentMain').css('background-color', '#C0D9D9');
            });

            jQuery('#temp1ContentMain').mouseout(function () {
                $('#temp1ContentMain').css('background-color', '#39b7cd');
            });
        });


        $(document).ready(function () {
            jQuery('#btnPreview').mouseover(function () {
                $('#btnPreview').css('background-color', '#336699');
            });

            jQuery('#btnPreview').mouseout(function () {
                $('#btnPreview').css('background-color', '#00adef');
            });


            jQuery('#tblUploadTemplate1').mouseover(function () {
                $('#tblUploadTemplate1').css('background-color', '#336699');
            });
            jQuery('#tblUploadTemplate1').mouseout(function () {
                $('#tblUploadTemplate1').css('background-color', '#cddd56');
            });

            jQuery('#tblUpload2').mouseover(function () {
                $('#tblUpload2').css('background-color', '#336699');
            });
            jQuery('#tblUpload2').mouseout(function () {
                $('#tblUpload2').css('background-color', '#cddd56');
            });

            jQuery('#tblUpload3').mouseover(function () {
                $('#tblUpload3').css('background-color', '#336699');
            });
            jQuery('#tblUpload3').mouseout(function () {
                $('#tblUpload3').css('background-color', '#cddd56');
            });


            jQuery('#temp1Foot p').css('text-align', 'center');
            jQuery('#temp1Foot p').css('font-family', 'Courier');
            jQuery('#temp1Foot p').css('color', 'White');
            jQuery('#temp1ContentMain a').css('color', 'White');

            jQuery('#btnPublish').mouseover(function () {
                $('#btnPublish').css('background-color', '#336699');
            });

            jQuery('#btnPublish').mouseout(function () {
                $('#btnPublish').css('background-color', '#00adef');
            });
        });

        $(document).ready(function () {
            $('#temp1Head').click(function () {
                $("#dial").dialog();
            });
            $("#datepickerStart").calendricalDate({ usa: false });
            //$("#datepickerEnd").calendricalDate({ usa: false });
        });

        function showAlert() {
            alert("Thank you! We will send you an email with your App details shortly!");
        }
    </script>
    <script type="text/javascript">
        $(document).ready(function () {
            var ie7 = !!(window['ActiveXObject'] && window['XMLHttpRequest']);
            document.getElementById('hdnBrowserMode').value = ie7;
            $("#whatsCTab1").click(function () {
                $("#para1").text("What is a Custom Tab Name?");
                $("#para").text("If you're a page admin and you've developed a custom app for your page, then you can create a custom page tab to host it with this CUSTOM TAB NAME.");
                centerPopup(); loadPopup();
            });

            $("#whatsCTab2").click(function () {
                $("#para1").text("What is a Custom Tab Name?");
                $("#para").text("If you're a page admin and you've developed a custom app for your page, then you can create a custom page tab to host it with this CUSTOM TAB NAME.");
                centerPopup(); loadPopup();
            });

            $("#whatsCTab3").click(function () {
                $("#para1").text("What is a Custom Tab Name?");
                $("#para").text("If you're a page admin and you've developed a custom app for your page, then you can create a custom page tab to host it with this CUSTOM TAB NAME.");
                centerPopup(); loadPopup();
            });
        });
        var popupStatus = 0;
        //centering popup
        function centerPopup() {
            //request data for centering
            var windowWidth = document.documentElement.clientWidth;
            var windowHeight = document.documentElement.clientHeight;
            var popupHeight = $("#popupContact").height();
            var popupWidth = $("#popupContact").width();
            //centering
            $("#popupContact").css({
                "position": "absolute",
                "top": windowHeight / 2 - popupHeight / 2,
                "left": windowWidth / 2 - popupWidth / 2
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
    <link href="Styles/demo.css" rel="stylesheet" type="text/css" />
    <link href="Styles/osx.css" rel="stylesheet" type="text/css" />
    <link href="Styles/master_style.css" rel="stylesheet" type="text/css" />
    <link rel="stylesheet" type="text/css" href="Styles/stylesheet.css" />
    <style type="text/css">
        #newapproachLeft
        {
            font-family: "Segoe UI" ,Arial,Helvetica,sans-serif;
            height: 208px;
            width: 183px;
            margin-left: 169px;
            margin-top: 10px;
        }
        #wrapDivs
        {
            height: 630px;
            width: 985px;
        }
        #newapproachCenter
        {
            /*font-family: "CenturyGothicRegular" , "Century Gothic" , Arial, Helvetica, sans-serif;*/
            font-family: "Segoe UI" ,Arial,Helvetica,sans-serif border-radius: 4px;
            margin-left: 589px;
            margin-top: -210px;
        }
        .canvasButtons
        {
            background: #00adef;
            color: White;
            padding: 10px;
            font-family: "Segoe UI" ,Arial,Helvetica,sans-serif;
            font-size: 14px;
            -moz-border-radius: 2px;
            -webkit-border-radius: 2px;
            -khtml-border-radius: 2px;
            border: 1px solid #fff;
            border-radius: 10px;
            cursor: pointer;
            margin-left: 0px;
        }
        #lblError
        {
            font-family: "Segoe UI" ,Arial,Helvetica,sans-serif;
            font-size: 13px;
        }
        #tblPromotions
        {
            border: 1px solid #d9d8dd;
            background-color: #aeaeaa;
            color: Black;
            width: 100%; /*font-family: "CenturyGothicRegular" , "Century Gothic" , Arial, Helvetica, sans-serif;*/
            font-family: Verdana;
            font-size: 13px;
            height: 100%;
            empty-cells: show;
        }
        
        #tblStepOne
        {
            border: 1px solid #d9d8dd;
            background-color: White;
            color: Black;
            width: 100%; /*font-family: "CenturyGothicRegular" , "Century Gothic" , Arial, Helvetica, sans-serif;*/
            font-family: "Segoe UI" ,Arial,Helvetica,sans-serif;
            font-size: 13px;
            height: 100%;
            border-radius: 8px;
        }
        #tblStep2
        {
            background-color: Gray;
            color: #e0e2cb; /*font-family: "CenturyGothicRegular" , "Century Gothic" , Arial, Helvetica, sans-serif;*/
            font-family: "Segoe UI" ,Arial,Helvetica,sans-serif;
            font-size: 13px;
            border-radius: 0px 0px 8px 8px;
            height: 430px;
        }
        #tblPromo3
        {
            border: 1px solid #d9d8dd;
            background-color: #aeaeaa;
            color: Black;
            width: 100%; /*font-family: "CenturyGothicRegular" , "Century Gothic" , Arial, Helvetica, sans-serif;*/
            font-family: "Segoe UI" ,Arial,Helvetica,sans-serif;
            font-size: 13px;
            height: 100%;
        }
        .Files
        {
            border: 1px solid #60CDF6;
            box-shadow: inset 0 5px 10px yellow, 0 1px 1px #D9D8DD;
            -o-box-shadow: inset 0 5px 10px yellow, 0 1px 1px #D9D8DD;
            -webkit-box-shadow: inset 0 5px 10px yellow, 0 1px 1px #D9D8DD;
            -moz-box-shadow: inset 0 5px 10px yellow, 0 1px 1px #D9D8DD;
        }
        .textboxesPromo
        {
            background-color: Yellow;
        }
        #btnPreviewCampaign
        {
            background-image: url("images/preview_button.png");
            background-color: transparent;
            background-repeat: no-repeat;
            border: medium none;
            color: #D2F522;
            cursor: pointer;
            display: block;
            font-size: 13px;
            font-weight: bold;
            height: 27px;
            line-height: 24px;
            margin: 0;
            text-align: center;
            text-decoration: none;
            vertical-align: middle;
            width: 83px;
        }
        .btnSavenContinue
        {
            background-image: url("images/save_continue.png");
            height: 33px;
            width: 166px;
            border: 0px;
            border-radius: 13px;
            cursor: pointer;
            background-color: transparent;
        }
        .btnPublishToFacebook
        {
            background-image: url("images/facebook-login-button.png");
            height: 22px;
            width: 154px;
            border: 0px;
            cursor: pointer;
            background-color: transparent;
        }
        #btnUploadPromo2
        {
            background-image: url("images/upload_F.png");
            height: 28px;
            width: 90px;
            border-radius: 13px;
            border: 0px;
            cursor: pointer;
            background-color: transparent;
        }
        #btnPreviewPromo2
        {
            background-image: url("images/preview_F.png");
            height: 28px;
            width: 98px;
            border: 0px;
            border-radius: 13px;
            cursor: pointer;
            background-color: transparent;
        }
        #btnUploadPromo3
        {
            background-image: url("images/upload_F.png");
            height: 28px;
            width: 90px;
            border-radius: 13px;
            border: 0px;
            cursor: pointer;
            background-color: transparent;
        }
        #btnPublishPromo3
        {
            background-image: url("images/pub_facebook_F.png");
            height: 28px;
            width: 175px;
            border: 0px;
            border-radius: 13px;
            cursor: pointer;
            background-color: transparent;
        }
        #btnPreviewPromo3
        {
            background-image: url("images/preview_F.png");
            height: 28px;
            width: 98px;
            border: 0px;
            border-radius: 13px;
            cursor: pointer;
            background-color: transparent;
        }
        .footercopy
        {
            font-size: 11px;
            text-align: left;
            color: #939393;
            text-align: center;
            background-image: url(Images/master_bg.png);
        }
        body
        {
            font-family: "Segoe UI" ,Arial,Helvetica,sans-serif;
            font-size: 13px;
            background-image: url(../Images/master_bg.png);
            background-position: top;
        }
        
        .multiPage
        {
            position: absolute;
            left: 590px;
        }
        
        .multiPage p
        {
            margin-left: 40px;
        }
        
        .multiPage ul
        {
            list-style: none;
            width: 520px;
        }
        .multiPage label
        {
            float: left;
            width: 120px;
            padding-left: 16px;
        }
        
        .multiPage li
        {
            line-height: 23px;
        }
        .multiPage .pageViewEducation label
        {
            width: 220px;
        }
        
        .multiPage .riLabel
        {
            width: 115px;
        }
        
        .multiPage .rcbLabel
        {
            width: 109px;
        }
    </style>
    <script type="text/javascript">
 <asp:literal runat="server" id="litLogin"></asp:literal>
    </script>
    <script type="text/javascript">
        function CompareDates() {
            
            var str1 = document.getElementById("datepickerStart").value;
            var str2 = document.getElementById("datepickerEnd").value;
            var dt1 = parseInt(str1.substring(0, 2), 10);
            if (dt1.toString().length != 2) {
                dt1 = "0" + dt1;
                var mon1 = parseInt(str1.substring(2, 5), 10);
            }
            else {
                var mon1 = parseInt(str1.substring(3, 5), 10);
            }

            var yr1 = parseInt(str1.substring(6, 10), 10);
            var dt2 = parseInt(str2.substring(0, 2), 10);
            if (dt2.toString().length != 2) {
                dt2 = "0" + dt2;
                var mon2 = parseInt(str2.substring(2, 5), 10);
            }
            else {
                var mon2 = parseInt(str2.substring(3, 5), 10);
            }


            var yr2 = parseInt(str2.substring(6, 10), 10);
            var date1 = new Date(yr1, mon1, dt1);
            var date2 = new Date(yr2, mon2, dt2);

            if (date2 < date1) {
                alert("Start date cannot be greater than End date !");
                return false;
            }
        }

        function CalculateEndDate() {
            var sDate = $("#datepickerStart").calendricalDate().getDate();
            sDate.setDate(sDate.getDate() + 30)
            $("#datepickerEnd").calendricalDate().setDate(sDate);
            document.getElementById('HiddenField1').value = document.getElementById('datepickerEnd').value;
        }

        $(document).ready(function () {
            $("#txtInquiryEmail").watermark('Enter Email for Inquiry');
        }); 
    </script>
    <script type="text/javascript">
        function FixTabs(tabStrip) {
            tabStrip.get_selectedTab().scrollIntoView();
        }
    </script>
    <style>
        .wrapperCoupon
        {
            color: #FFFFFF;
            margin: 0 auto;
        }
        span.reference
        {
            position: fixed;
            left: 5px;
            top: 5px;
            font-size: 10px;
            text-shadow: 1px 1px 1px #fff;
        }
        span.reference a
        {
            color: #555;
            text-decoration: none;
            text-transform: uppercase;
        }
        span.reference a:hover
        {
            color: #000;
        }
        h1
        {
            color: #ccc;
            font-size: 36px;
            text-shadow: 1px 1px 1px #fff;
            padding-bottom: 10px;
        }
        textarea
        {
            resize: none;
        }
        .lblchoice
        {
            padding-left: 110px;
        }
        #lblTCdesc
        {
            padding: 5px 5px 5px 5px;
        }
        #fstPolicy
        {
            /*height: 340px;*/ /* overflow: scroll;*/ /*overflow: scroll;*/
        }
        /* .classPolicy
        {
            height: 450px;
            overflow: scroll;
            overflow-y: scroll;
            overflow-x: hidden;
        }*/
        
        .tblNEWUI
        {
            background-color: #F4F4F4;
            border: 1px solid #FFFFFF;
            border-radius: 5px 5px 5px 5px;
            box-shadow: 0 0 3px #AAAAAA;
            clear: both;
            float: left;
            margin: 5px 0 5px 85px;
            padding: 10px;
            width: 590px;
        }
        #divPageSelect
        {
            margin: 6px auto;
            text-align: center;
            width: 750px;
            position: relative;
            height: 580px;
        }
        #spanShareCheckBoxImage
        {
            background-image: url("images/share_step3.png");
            display: block;
            height: 42px;
            margin-left: 24px;
            margin-top: -30px;
            width: 122px;
        }
        #spanLikeCheckBoxImage
        {
            background-image: url("images/like_step3.png");
            display: block;
            height: 42px;
            margin-left: 24px;
            margin-top: -30px;
            width: 105px;
        }
        #spanCommentCheckBoxImage
        {
            background-image: url("images/usercomments_step3.png");
            display: block;
            height: 42px;
            margin-left: 24px;
            margin-top: -30px;
            width: 220px;
        }
        #spanReccCheckBoxImage
        {
            background-image: url("images/recommend_step3.png");
            display: block;
            height: 42px;
            margin-left: 24px;
            margin-top: -30px;
            width: 179px;
        }
        #spanInquiryCheckBoxImage
        {
            background-image: url("images/inquiry_step3.png");
            display: block;
            height: 42px;
            margin-left: 24px;
            margin-top: -30px;
            width: 111px;
        }
    </style>
</head>
<body>
    <div class="masterbody">
        <div class="masterwrapper">
            <div class="sonetlogo">
                <a id="A1" href="#" runat="server">
                    <img src="images/logo.png" border="0" alt="SonetReach" /></a></div>
            <div class="topright">
                <table cellpadding="0" cellspacing="0" border="0" align="right">
                    <tr>
                        <td>
                            <a id="btnLogout" runat="server" class="toplink" onclick="btnLogout_Click" href="Home.aspx?lo=T">
                                Logout</a>
                        </td>
                    </tr>
                </table>
            </div>
        </div>
        <div class="clr">
        </div>
        <div style="padding-top: 10px;">
            <img src="images/greytop_border.png" height="4" width="100%" alt="" /></div>
        <div class="backwrapper">
            <a href="LandingPage.aspx" class="backlink">Back</a></div>
        <div id="contents" runat="server">
            <input id="btnPreviewCampaign" type="button" onclick="callModalPopUp('PreviewApp.aspx?TDID=3&PDID='); return false;"
                style="margin-left: 679px;" value="Preview" />
            <div id="divwrapper" runat="server">
                <div id="navigation" style="display: none;" runat="server">
                    <ul id="MainList" runat="server">
                        <li class="selected"><a href="#">Canvas Settings</a> </li>
                        <li runat="server" id="CampDetails"><a href="#" id="campDetLinker">Campaign Details</a>
                        </li>
                        <li runat="server" id="Widgets"><a href="#" id="widgetLinker">Widgets</a> </li>
                        <li runat="server" id="FacebookDet"><a href="#" id="fbLinker">Facebook</a></li>
                    </ul>
                </div>
                <div id="steps" runat="server">
                    <form id="formElem" runat="server">
                    <fieldset class="step">
                        <legend>Canvas Settings </legend>
                        <table id="tblStep1" class="tblNEWUI" cellspacing="8">
                            <tr align="left" class="d0">
                                <td>
                                    Height :
                                </td>
                                <td>
                                    <asp:TextBox ID="txtCanvasHeight" runat="server"></asp:TextBox>
                                </td>
                            </tr>
                            <tr align="left" class="d1">
                                <td>
                                    Width :
                                </td>
                                <td>
                                    <asp:TextBox ID="txtCanvasWidth" runat="server"></asp:TextBox>
                                </td>
                            </tr>
                            <tr valign="middle" class="d0">
                                <td align="left" colspan="1">
                                    Campaign Logo :
                                </td>
                                <td align="left" colspan="2">
                                    <asp:FileUpload ID="filePromo2Logo" runat="server" />
                                    <span id="span1" runat="server"></span>
                                </td>
                            </tr>
                            <tr align="center" valign="middle" class="d0">
                                <td colspan="3">
                                    <asp:Button ID="btnStep1Complete" runat="server" CssClass="btnSavenContinue" OnClick="btnStep1Complete_Click"
                                        OnClientClick="SetTabStatus1()" />
                                </td>
                            </tr>
                        </table>
                    </fieldset>
                    <fieldset class="step">
                        <legend>Campaign Details</legend>
                        <table id="tblPromo2Step2" cellspacing="8" class="tblNEWUI">
                            <tr valign="middle" class="d0">
                                <td align="left" colspan="1">
                                    Header Caption :
                                </td>
                                <td align="left" colspan="2">
                                    <asp:TextBox ID="txtHeaderText" runat="server" Width="400px" />
                                    <span id="errtxtHeaderText" runat="server"></span>
                                </td>
                            </tr>
                            <tr>
                                <td align="left">
                                    Header Image :
                                </td>
                                <td align="left">
                                    <asp:FileUpload ID="fileHead" runat="server" CssClass="textboxesPromo" /><span id="spnErrorPromo1Head"
                                        runat="server"></span>
                                </td>
                                <td align="left">
                                    <asp:CheckBox ID="chkPromo1Head" runat="server" Checked="true" Text="Auto Resize" />
                                </td>
                            </tr>
                            <tr align="left" class="d1">
                                <td align="left">
                                    Body Image :
                                </td>
                                <td align="left">
                                    <asp:FileUpload ID="fileBody" runat="server" CssClass="textboxesPromo" /><span id="spnErrorPromo2Head"
                                        runat="server"></span>
                                </td>
                                <td>
                                    <asp:CheckBox ID="chkPromo2" runat="server" Checked="true" Text="Auto Resize" />
                                </td>
                            </tr>
                            <tr>
                                <td align="left">
                                    Footer Image :
                                </td>
                                <td align="left">
                                    <asp:FileUpload ID="fileFoot" runat="server" CssClass="textboxesPromo" /><span id="spnErrorPromo1Foot"
                                        runat="server"></span>
                                </td>
                                <td align="left">
                                    <asp:CheckBox ID="chkPromo1Foot" runat="server" Checked="true" Text="Auto Resize" />
                                </td>
                            </tr>
                            <tr valign="middle" class="d1">
                                <td align="left" colspan="1">
                                    <label for="startDate">
                                        Start Date :<span style="color: Red">*</span></label>
                                </td>
                                <td align="left" colspan="2">
                                    <input type="text" id="datepickerStart" class="textboxesCalender" runat="server" />
                                </td>
                            </tr>
                            <tr valign="middle" class="d0">
                                <td align="left" colspan="1">
                                    <label for="endDate">
                                        End Date :<span style="color: Red">*</span></label>
                                </td>
                                <td align="left" colspan="2">
                                    <input type="text" id="datepickerEnd" class="textboxesCalender" runat="server" disabled="disabled" />
                                </td>
                            </tr>
                            <tr valign="middle" class="d1">
                                <td align="left" colspan="1">
                                    App Expiry Image :
                                </td>
                                <td align="left" colspan="2">
                                    <asp:FileUpload ID="filePromo2AppExpiryImage" runat="server" />
                                    <span id="spanErrorfileAppExpiryImage" runat="server"></span>
                                </td>
                            </tr>
                            <tr align="center" valign="middle" class="d1">
                                <td colspan="3">
                                    <asp:Button ID="btnStep2Complete" runat="server" OnClick="btnStep2Complete_Click"
                                        OnClientClick="SetTabStatus2()" CssClass="btnSavenContinue"></asp:Button>
                                </td>
                            </tr>
                        </table>
                    </fieldset>
                    <fieldset class="step">
                        <legend>Widgets</legend>
                        <table class="tblNEWUI" cellspacing="25">
                            <tr class="d0" valign="middle" align="left">
                                <td align="left" colspan="1">
                                    Custom Tab Name<span style="color: Red">*</span><a id="whatsCTab2" href="#" style="color: Black;">[?]</a>
                                </td>
                                <td align="left" colspan="3">
                                    <asp:TextBox ID="txtCustomTabNamePromo2" runat="server" MaxLength="20" CssClass="textboxesPromo"></asp:TextBox><span
                                        id="span3" runat="server" style="color: Red"></span><span id="spanErrorCustTabNamePromo2"
                                            runat="server" style="color: Red"></span>
                                </td>
                            </tr>
                            <tr align="left" valign="middle" class="d0">
                                <td align="left" colspan="1">
                                    <asp:CheckBox ID="chkShareButton" runat="server" Text="Share" />
                                </td>
                                <td align="right" colspan="1">
                                    <asp:CheckBox ID="chkComment" Text="User Comments" runat="server" />
                                </td>
                                <td align="center" colspan="1">
                                    <asp:CheckBox ID="chkLike" Text="Like" runat="server" />
                                </td>
                                <td align="right" colspan="1">
                                    <asp:CheckBox ID="chkRecc" Text="Recommend" runat="server" />
                                </td>
                            </tr>
                            <tr align="left" valign="middle" class="d1">
                                <td align="left" colspan="1">
                                    <asp:CheckBox ID="chkInquiry" Text="Inquiry" runat="server" /><span id="spanInquiryCheckBoxImage"
                                        runat="server"></span>
                                </td>
                                <td align="left" colspan="3">
                                    <asp:TextBox ID="txtInquiryEmail" runat="server" />
                                </td>
                            </tr>
                            <tr align="left" valign="middle" class="d0">
                                <td align="left" colspan="1">
                                    <asp:CheckBox ID="chkLikeGateway" Text="Like Gateway ?" runat="server" />
                                </td>
                                <td align="left" colspan="3">
                                    <asp:FileUpload ID="filePromo2LikeGateWayImage" runat="server" Width="300px" Enabled="false" />
                                    <span id="spnErrorfileLikeGateWayImage" runat="server"></span>
                                </td>
                            </tr>
                            <tr align="center" valign="middle" class="d1">
                                <td colspan="4">
                                    <asp:Button ID="btnStep3Complete" runat="server" OnClick="btnStep3Complete_Click"
                                        OnClientClick="SetTabStatus3()" CssClass="btnSavenContinue"></asp:Button>
                                </td>
                            </tr>
                        </table>
                    </fieldset>
                    <fieldset class="step">
                        <legend>Facebook details</legend>
                        <table class="tblNEWUI">
                            <tr class="d0">
                                <td>
                                    <asp:Button ID="btnPromoPublish" runat="server" OnClick="btnPublish_Click" CssClass="btnPublishToFacebook" />
                                </td>
                            </tr>
                            <tr class="d1">
                                <td>
                                    <iframe runat="server" id="framePage" width="550px" height="280px" frameborder="0"
                                        scrolling="no"></iframe>
                                </td>
                            </tr>
                        </table>
                    </fieldset>
                    <asp:HiddenField ID="hdnTrmplateID" runat="server" />
                    <asp:HiddenField ID="hdnAppNAme" runat="server" />
                    <asp:HiddenField ID="hdnfield" runat="server" />
                    <asp:HiddenField ID="hdnHeader" runat="server" />
                    <asp:HiddenField ID="hdnContent" runat="server" />
                    <asp:HiddenField ID="hdnFooter" runat="server" />
                    <asp:HiddenField ID="hdnPDID" runat="server" />
                    <asp:HiddenField ID="hdnBrowserMode" runat="server" />
                    <asp:HiddenField ID="hdnFooterLogo" runat="server" />
                    <asp:HiddenField ID="hdnTabStatus" runat="server" />
                    <asp:HiddenField ID="hdnCode" runat="server" />
                    <asp:HiddenField ID="hdnAppid" runat="server" />
                    <asp:HiddenField ID="hdnPostBackStatus" runat="server" />
                    <asp:HiddenField ID="HiddenField1" runat="server" />
                    <div style="display: none">
                        <asp:Button ID="btnRefresh" runat="server" UseSubmitBehavior="false" />
                    </div>
                    </form>
                </div>
                <%--<div id="newapproachCenter">
                    <div id="PRomo1" runat="server" visible="false">
                        <table id="tblPromotions" cellspacing="9">
                            <tr align="center" valign="middle">
                                <td colspan="3">
                                    <strong>Promotion 1</strong>
                                </td>
                            </tr>
                            <tr>
                                <td class="style345">
                                    Custom Tab Name<span style="color: Red">*</span><a id="whatsCTab1" href="#">[?]</a>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtCustomTabNamePromo1" runat="server" MaxLength="20"></asp:TextBox><span
                                        id="spanErrorPromo1CustTabName" style="color: Red" runat="server"></span>
                                </td>
                            </tr>
                            <tr align="center">
                                <td colspan="2">
                                    <asp:Button ID="btnUploadFiles" runat="server" />
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2">
                                    <asp:Label ID="lblError" runat="server" ForeColor="Red" Visible="true"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2">
                                    <table id="tblPrevPub" runat="server" visible="false">
                                        <tr align="center">
                                            <td colspan="2">
                                                <p>
                                                    Upload Successful ! Click to see a Preview.</p>
                                            </td>
                                            <td colspan="1">
                                                <asp:Button ID="btnPreview" runat="server" OnClientClick="callModalPopUp('PreviewApp.aspx?TDID=3&PDID='); return false;" />
                                            </td>
                                        </tr>
                                        <tr align="center" id="rowOr">
                                            <td align="left">
                                                <p>
                                                    <strong>OR</strong></p>
                                            </td>
                                        </tr>
                                        <tr align="center" id="rowPublishButton">
                                            <td colspan="2" align="left" class="style3">
                                                <p>
                                                    Publish your Campaign to Facebook</p>
                                            </td>
                                            <td colspan="1">
                                                <asp:Button ID="btnPublish" runat="server" OnClick="btnPublish_Click" />
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                        </table>
                    </div>
                    <div id="Promo2" runat="server" visible="false">
                    </div>
                    <div id="Promo3" runat="server" visible="false">
                        <table id="tblPromo3" cellspacing="4">
                            <tr align="center" valign="middle">
                                <td colspan="3">
                                    <strong>Video Share</strong>
                                </td>
                            </tr>
                            <tr>
                                <td class="style2">
                                    Video URL
                                </td>
                                <td>
                                    <asp:TextBox ID="txtVideoURL" runat="server" CssClass="textboxesPromo"></asp:TextBox>&nbsp;<span
                                        id="spanErrVid" runat="server"></span>
                                </td>
                            </tr>
                            <tr>
                                <td class="style2">
                                    Description
                                </td>
                                <td>
                                    <asp:TextBox ID="txtDescription" runat="server" TextMode="MultiLine" CssClass="textboxesPromo"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td class="style345">
                                    Custom Tab Name<span style="color: Red">*</span><a id="whatsCTab3" href="#" style="color: Black;">[?]</a>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtCustomTabNamePromo3" runat="server" MaxLength="20" CssClass="textboxesPromo"></asp:TextBox><span
                                        id="spanErrorCustTabNamePromo3" runat="server" style="color: Red"></span>
                                </td>
                            </tr>
                            <tr align="center">
                                <td colspan="2">
                                    <asp:Button ID="btnUploadPromo3" runat="server" />
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2">
                                    <table id="tblPromo3Inner" runat="server" visible="false">
                                        <tr align="center">
                                            <td colspan="2">
                                                <p>
                                                    Upload Successful ! Click to see a Preview.</p>
                                            </td>
                                            <td colspan="1">
                                                <asp:Button ID="btnPreviewPromo3" runat="server" OnClientClick="callModalPopUp('PreviewApp.aspx?TDID=3&PDID='); return false;" />
                                            </td>
                                        </tr>
                                        <tr align="center" id="Tr3">
                                            <td align="left">
                                                <p>
                                                    <strong>OR</strong></p>
                                            </td>
                                        </tr>
                                        <tr align="center" id="Tr4">
                                            <td colspan="2" align="left" class="style3">
                                                <p>
                                                    Publish your Campaign to Facebook</p>
                                            </td>
                                            <td colspan="1">
                                                <asp:Button ID="btnPublishPromo3" runat="server" OnClick="btnPublish_Click" />
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2">
                                    <asp:Label ID="lblErrorPromo3" runat="server"></asp:Label>
                                </td>
                            </tr>
                        </table>
                    </div>
                    <div id="pageSelected" runat="server" visible="false">
                        <table>
                            <tr>
                                <td>
                                    <span>Page tab loaded successfully</span>
                                </td>
                            </tr>
                        </table>
                    </div>
                </div>--%>
            </div>
        </div>
        <div id="divPageSelect" runat="server" visible="false">
        </div>
    </div>
    <div class="footercopy">
        Copyright <a href="http://www.smnetserv.com/" target="_blank" class="url">SM NetServ
            Technologies Pvt Ltd</a> 2012 - Offshore Software Development Company, India</div>
    <input type='button' name='osx' value='Demo' class='osx demo' id="btnModal" style="display: none;" />
    <div id="osx-modal-content">
        <div id="osx-modal-title">
            Campaign Preview
        </div>
        <div class="close">
            <a href="#" id="hlnModalClose" class="simplemodal-close">Close[x]</a></div>
        <div id="osx-modal-data">
            <iframe style="border: 0px; min-height: 350px; height: 800px; max-height: 100%; width: 100%;
                overflow: scroll" id="iFrameModal"></iframe>
        </div>
    </div>
</body>
</html>
