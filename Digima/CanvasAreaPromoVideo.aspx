<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CanvasAreaPromoVideo.aspx.cs"
    Inherits="DigiMa.CanvasAreaPromoVideo" %>

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
    <link href="Styles/calendrical.css" rel="stylesheet" type="text/css" />
    <%--<script src="ScriptsSonetReach/fileuploader.js" type="text/javascript"></script>--%>
    <script src="ScriptsSonetReach/sliding.form.js" type="text/javascript"></script>
    <link href="Styles/Coupon.css" rel="stylesheet" type="text/css" />
    <script src="ScriptsSonetReach/tabs.js" type="text/javascript"></script>
    <link href="Styles/CouponTab.css" rel="stylesheet" type="text/css" />
    <script src="ScriptsSonetReach/jquery.calendrical.js" type="text/javascript"></script>
    <link href="Styles/style_new_menu.css" rel="stylesheet" type="text/css" />
    <link href="Styles/menu_style.css" rel="stylesheet" type="text/css" />
    <script src="ScriptsSonetReach/Fancybox/jquery.watermark.min.js" type="text/javascript"></script>
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

        function CheckInquiry(source, args) {
            if (document.getElementById('<%=chkInquiry.ClientID %>').checked) {
                if (document.getElementById('<%=txtInquiryEmail.ClientID %>').value == '') {
                    args.IsValid = false;
                }
                else {
                    args.IsValid = true;
                }
            }
        }
        $(document).ready(function () {
            $("#filePromo2LikeGateWayImage").css("display", "none");
            $("#divwrapper").css('height', '550px');
            $("#divwrapper").css('overflow-x', 'none');
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
            $("#datepickerEnd").focusout(function () {
                CompareDates();
                ValidateEndDate();
                //ValidateThirtyDays();
            });
            if ($("#chkTweeter").is(':checked')) {
                document.getElementById('hdnTweetEnabled').value = "Enabled";  // checked
            }
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
            if (document.getElementById('<%=chkInquiry.ClientID %>').checked) {
                if (document.getElementById('<%=txtInquiryEmail.ClientID %>').value == '') {

                }
            }
        }
        function SetTabStatus2() {
            document.getElementById('hdnTabStatus').value = "step_two_complete";

            //            if (document.getElementById('datepickerStart').value == '') {
            //                alert("Start Date is a mandatory field!");
            //                return false;
            //            }

            //            if (document.getElementById('datepickerExpiry').value == '') {
            //                alert("Expiry Date is a mandatory field!");
            //                return false;
            //            }
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
            $("#txtInquiryEmail").watermark('Enter Email for Inquiry');
            $("#txtBannerURL").watermark('http://www.yourwebsite.com');
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
            background-color: #dddddd;
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
                alert("The End Date cannot be earlier than the Start Date!");
                document.getElementById('datepickerEnd').value = '';
                return false;
            }
        }

        function ValidateThirtyDays() {
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

            if ((date2 - date1) > 30) {
                alert("The Campaign cannot extend for more than 30 days !");
                document.getElementById('datepickerEnd').value = '';
                return false;
            }
        }

        function ValidateEndDate() {
            var sDate = $("#datepickerStart").calendricalDate().getDate();
            var allowedDate = sDate.setDate(sDate.getDate() + 30);
            if ($("#datepickerEnd").calendricalDate().getDate() > allowedDate) {
                alert("The Campaign cannot extend for more than 30 days !");
                document.getElementById('datepickerEnd').value = '';
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
            $('input:checkbox').css('float', 'none');
            $('input:checkbox').css('width', '20px');
            if ($("#fbcommentsDiv").html() == 'CommBox') {

                $("#fbcommentsDiv").hide();
            }
            $('#tblTemplateFive th').each(function (i) {
                var remove = 0;

                var tds = $(this).parents('table').find('tr td:nth-child(' + (i + 1) + ')')
                tds.each(function (j) { if (this.innerHTML == '') remove++; });

                if (remove == ($('#tblTemplateFive tr').length - 1)) {
                    $(this).hide();
                    tds.hide();
                }
            });
        });

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
            width: 595px;
        }
        #divPageSelect
        {
            margin: 6px auto;
            text-align: center;
            width: 750px;
            position: relative;
            height: 580px;
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
                    <tr valign="middle" align>
                        <td align="left" colspan="1">
                            <a href="CreationCentral.aspx" style="color: White;">Back</a>
                        </td>
                        <td align="right" colspan="1" style="width: 20px;">
                            <span style="color: White;">|</span>
                        </td>
                        <td align="left" colspan="1">
                            <a id="btnLogout" runat="server" class="toplink" onclick="btnLogout_Click" href="Home.aspx?lo=T">
                                Logout</a>
                        </td>
                    </tr>
                </table>
            </div>
        </div>
        <div class="clr">
        </div>
        <div id="contents" runat="server">
            <input id="btnPreviewCampaign" type="button" onclick="callModalPopUp('PreviewApp.aspx?TDID=3&PDID='); return false;"
                style="margin-left: 679px;" value="Preview" runat="server" disabled="disabled" />
            <div id="divwrapper" runat="server">
                <div id="navigation" style="display: none;" runat="server">
                    <ul id="MainList" runat="server">
                        <li runat="server" id="CampDetails"><a href="#" id="campDetLinker">Campaign Details</a>
                        </li>
                        <li runat="server" id="Widgets"><a href="#" id="widgetLinker">Widgets</a> </li>
                        <li runat="server" id="FacebookDet"><a href="#" id="fbLinker">Facebook</a></li>
                    </ul>
                </div>
                <div id="steps" runat="server">
                    <form id="formElem" runat="server">
                    <fieldset class="step">
                        <legend>Campaign Details</legend>
                        <table id="tblPromo2Step2" cellspacing="8" class="tblNEWUI">
                            <tr valign="middle" class="d0">
                                <td align="left" colspan="1">
                                    Banner Image :
                                </td>
                                <td align="left">
                                    <asp:FileUpload ID="imgBanner" runat="server" CssClass="textboxesPromo" />
                                </td>
                            </tr>
                            <tr valign="middle" class="d0">
                                <td align="left" colspan="1">
                                    Banner URL :
                                </td>
                                <td align="left" colspan="2">
                                    <asp:TextBox ID="txtBannerURL" runat="server" Width="200px" title="for example : http://www.your-website.com"/> 
                                </td>
                            </tr>
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
                                    Video URL :<span style="color: Red">*</span>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtVideoURL" runat="server" CssClass="textboxesPromo" Width="400px"></asp:TextBox><asp:RequiredFieldValidator
                                        ID="rfvVideoUrl" ControlToValidate="txtVideoURL" runat="server" ErrorMessage="Video URL is a mandatory field!"
                                        ValidationGroup="vGRoupVideo" Display="None"></asp:RequiredFieldValidator><asp:RegularExpressionValidator
                                            ID="RegularExpressionValidator1" runat="server" ValidationExpression="^(?:https?:\/\/)?(?:www\.)?youtube\.com\/watch\?(?=.*v=((\w|-){11}))(?:\S+)?$"
                                            ErrorMessage="Incorrect Youtube URL !" ControlToValidate="txtVideoURL" ValidationGroup="vGRoupVideo"
                                            Display="None"></asp:RegularExpressionValidator>
                                </td>
                            </tr>
                            <tr>
                                <td align="left">
                                    Description :<span style="color: Red">*</span>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtDescription" runat="server" TextMode="MultiLine" Width="400px"
                                        Font-Size="Small" Font-Names="MS Shell Dlg"></asp:TextBox><asp:RequiredFieldValidator
                                            ID="rfvDescription" ControlToValidate="txtDescription" runat="server" ErrorMessage="Video Description is a mandatory field!"
                                            ValidationGroup="vGRoupVideo" Display="None"></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr valign="middle" class="d0">
                                <td align="left" colspan="1">
                                    Campaign Logo :
                                </td>
                                <td align="left" colspan="2">
                                    <asp:FileUpload ID="filePromoVideoLogo" runat="server" />
                                    Choose Only .png/.jpg/.jpeg images.
                                </td>
                            </tr>
                            <tr valign="middle" class="d1">
                                <td align="left" colspan="1">
                                    <label for="startDate">
                                        Start Date :<span style="color: Red">*</span></label>
                                </td>
                                <td align="left" colspan="2">
                                    <input type="text" id="datepickerStart" class="textboxesCalender" runat="server"
                                        readonly="readonly" /><asp:RequiredFieldValidator ID="rfvStart" ControlToValidate="datepickerStart"
                                            runat="server" ErrorMessage="Start Date is a mandatory field!" ValidationGroup="vGRoupVideo"
                                            Display="None"></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr valign="middle" class="d0">
                                <td align="left" colspan="1">
                                    <label for="endDate">
                                        End Date :<span style="color: Red">*</span></label>
                                </td>
                                <td align="left" colspan="2">
                                    <input type="text" id="datepickerEnd" class="textboxesCalender" runat="server" readonly="readonly" /><asp:RequiredFieldValidator
                                        ID="rfvEnd" ControlToValidate="datepickerEnd" runat="server" ErrorMessage="End Date is a mandatory field!"
                                        ValidationGroup="vGRoupVideo" Display="None"></asp:RequiredFieldValidator>
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
                                        OnClientClick="SetTabStatus2()" CssClass="btnSavenContinue" ValidationGroup="vGRoupVideo"
                                        EnableViewState="false" ViewStateMode="Disabled"></asp:Button>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:ValidationSummary ID="ValidationSummary2" runat="server" ValidationGroup="vGRoupVideo"
                                        ShowMessageBox="true" ShowSummary="false" Class="valSummaryVideo" />
                                </td>
                            </tr>
                        </table>
                    </fieldset>
                    <fieldset class="step">
                        <legend>Widgets</legend>
                        <table class="tblNEWUI" cellspacing="3">
                            <tr class="d0" valign="middle" align="left">
                                <td align="left" colspan="1">
                                    Custom Tab Name<span style="color: Red">*</span>
                                </td>
                                <td align="left" colspan="3">
                                    <asp:TextBox ID="txtCustomTabNamePromoVid" runat="server" MaxLength="20" CssClass="textboxesPromo"></asp:TextBox><asp:RequiredFieldValidator
                                        ID="rfvFilePRomo2" ControlToValidate="txtCustomTabNamePromoVid" runat="server"
                                        ErrorMessage="Custom Tab Name is a mandatory field!" ValidationGroup="vGRoupBody"
                                        Display="None"></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr align="left" valign="middle" class="d0">
                                <td align="left" colspan="1">
                                    <asp:CheckBox ID="chkShareButton" Text="Share" runat="server" TextAlign="Right" />
                                </td>
                                <td align="center" colspan="1">
                                    <asp:CheckBox ID="chkLike" Text="Like" runat="server" />
                                </td>
                                <td align="right" colspan="1">
                                    <asp:CheckBox ID="chkComment" Text="User Comments" runat="server" />
                                </td>
                                <td align="right" colspan="1">
                                    <asp:CheckBox ID="chkRecc" Text="Recommend" runat="server" />
                                </td>
                            </tr>
                            <tr align="left" valign="middle" class="d0">
                                <td align="left" colspan="1">
                                    <asp:CheckBox ID="chkTweeter" Text="Tweet" runat="server" TextAlign="Right" />
                                </td>
                            </tr>
                            <tr align="left" valign="middle" class="d1">
                                <td align="left" colspan="1">
                                    <asp:CheckBox ID="chkInquiry" Text="Inquiry" runat="server" />
                                </td>
                                <td align="left" colspan="3">
                                    <asp:TextBox ID="txtInquiryEmail" runat="server" /><asp:CustomValidator ID="inquiryCustValidator"
                                        runat="server" ClientValidationFunction="CheckInquiry" ValidationGroup="vGRoupBody"
                                        Display="None" ErrorMessage="Inquiry Email is required if selected!"></asp:CustomValidator><asp:RegularExpressionValidator
                                            ID="RegularExpressionValidatorInquiry" runat="server" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
                                            ControlToValidate="txtInquiryEmail" ErrorMessage="Input valid email address!"
                                            ValidationGroup="vGRoupBody" Display="None">  
                                        </asp:RegularExpressionValidator>
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
                                        OnClientClick="SetTabStatus3()" CssClass="btnSavenContinue" ValidationGroup="vGRoupBody"
                                        EnableViewState="false" ViewStateMode="Disabled"></asp:Button>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:ValidationSummary ID="ValidationSummary1" runat="server" ValidationGroup="vGRoupBody"
                                        ShowMessageBox="true" ShowSummary="false" Class="valSummaryBody" />
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
                    <asp:HiddenField ID="hdnTweetEnabled" runat="server" />
                    <asp:HiddenField ID="hdnBanner" runat="server" />
                    <div style="display: none">
                        <asp:Button ID="btnRefresh" runat="server" UseSubmitBehavior="false" />
                    </div>
                    </form>
                </div>
                <div id="newapproachCenter">
                    <div id="Promo3" runat="server" visible="false">
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
                </div>
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
