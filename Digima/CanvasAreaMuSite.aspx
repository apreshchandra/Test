<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CanvasAreaMuSite.aspx.cs"
    Inherits="DigiMa.CanvasAreaMuSite" MasterPageFile="~/MasterPage.master" %>

<asp:Content runat="server" ContentPlaceHolderID="head" ID="cphHead">
    <meta http-equiv="X-UA-Compatible" content="IE=9" />
    <script src="ScriptsSonetReach/jquery-1.5.1.js" type="text/javascript"></script>
    <script src="ScriptsSonetReach/jquery.watermark.js" type="text/javascript"></script>
    <script src="ScriptsSonetReach/jquery.watermark.min.js" type="text/javascript"></script>
    <script type="text/javascript" src="https://ajax.googleapis.com/ajax/libs/jqueryui/1.8.16/jquery-ui.js"></script>
    <script src="ScriptsSonetReach/jquery.simplemodal.js" type="text/javascript"></script>
    <script src="ScriptsSonetReach/osx.js" type="text/javascript"></script>
    <link href="Styles/osx.css" rel="stylesheet" type="text/css" />
    <link href="ScriptsSonetReach/jquery.fancybox-1.3.4.css" rel="stylesheet" type="text/css" />
    <link href="Styles/calendrical.css" rel="stylesheet" type="text/css" />
    <script src="ScriptsSonetReach/sliding.form.js" type="text/javascript"></script>
    <link href="Styles/Coupon.css" rel="stylesheet" type="text/css" />
    <script src="ScriptsSonetReach/tabs.js" type="text/javascript"></script>
    <link href="Styles/CouponTab.css" rel="stylesheet" type="text/css" />
    <script src="ScriptsSonetReach/jquery.calendrical.js" type="text/javascript"></script>
    <link href="Styles/style_new_menu.css" rel="stylesheet" type="text/css" />
    <link href="Styles/menu_style.css" rel="stylesheet" type="text/css" />
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
        .buttonPageBackgroudn
        {
            background-image: url("Images/FW_start_again.png");
            background-repeat: no-repeat;
            border: 0 none;
            cursor: pointer;
            display: block;
            height: 25px;
            line-height: 25px;
            margin: 0;
            text-align: center;
            text-decoration: none;
            vertical-align: middle;
            width: 97px;
            border-radius: 8px;
        }
        .logo
        {
            margin-bottom: 20px;
            margin-left: 164px;
            margin-top: -20px;
            padding: 22px 0 0 1px;
        }
        table
        {
            table-layout: fixed;
            width: 100%;
            word-wrap: break-word;
        }
        td
        {
            width: 50px;
        }
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
            $("#body_txtSubDomainName").blur(function () {
                var txtvalue = document.getElementById('<%=txtSubDomainName.ClientID %>').value;

                var splcharacter = "!@#$%^&*()+=-[]\\\';,./{}|\":<>?";

                for (var i = 0; i < txtvalue.length; i++) {
                    if (splcharacter.indexOf(txtvalue.charAt(i)) != -1) {
                        alert("Special characters are not allowed.\n");
                        return false;
                    }
                }
            });


            $("#body_txtCustomTabNamePromoVid").blur(function () {
                var txtvalue = document.getElementById('<%=txtCustomTabNamePromoVid.ClientID %>').value;

                var splcharacter = "!@#$%^&*()+=-[]\\\';,./{}|\":<>?";

                for (var i = 0; i < txtvalue.length; i++) {
                    if (splcharacter.indexOf(txtvalue.charAt(i)) != -1) {
                        alert("Special characters are not allowed.\n");
                        return false;
                    }
                }
            });
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
    <link href="Styles/demo.css" rel="stylesheet" type="text/css" />
    <link href="Styles/osx.css" rel="stylesheet" type="text/css" />
    <link href="Styles/master_style.css" rel="stylesheet" type="text/css" />
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
            background: none repeat scroll 0 0 Grey;
            border: 1px solid #901414;
            color: White;
            width: 239px;
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
        function FixTabs(tabStrip) {
            tabStrip.get_selectedTab().scrollIntoView();
        }

    </script>
    <style>
        .labelStyle
        {
            font-family: "Lucida Grande" , "Lucida Sans Unicode" , "Helvetica" , "Arial,Verdana" , "sans-serif";
            font-size: 18px;
            color: #828386;
            font-weight: bold;
        }
        body
        {
            background: url('../../images/body_bg.jpg');
            background-color: #fff;
            background-repeat: repeat-x;
            background-position: top;
        }
        
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
            margin: 5px 0 5px 5px;
            padding: 10px;
            width: 595px;
        }
        .tblYoutube
        {
            background-color: #F4F4F4;
            border: 1px solid #FFFFFF;
            border-radius: 5px 5px 5px 5px;
            box-shadow: 0 0 3px #AAAAAA;
            clear: both;
            float: left;
            margin: 5px 0 5px 5px;
            padding: 10px;
            width: 595px;
        }
        .tblMicrosite
        {
            background-color: #F4F4F4;
            border: 1px solid #FFFFFF;
            border-radius: 5px 5px 5px 5px;
            box-shadow: 0 0 3px #AAAAAA;
            clear: both;
            float: left;
            margin: 5px 0 5px 5px;
            padding: 10px;
            width: 57%;
        }
        #divPageSelect
        {
            margin: 6px auto;
            text-align: center;
            width: 750px;
            position: relative;
            height: 580px;
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
            margin-top: -7px;
            position: relative;
            width: 710px;
        }
    </style>
</asp:Content>
<asp:Content runat="server" ContentPlaceHolderID="body" ID="body">
    <div style="width: 905px; padding: 20px;">
        <table cellpadding="0" cellspacing="0" border="0">
            <tr>
                <td colspan="4" align="right">
                    <asp:Button ID="btnStartAgain" runat="server" OnClick="btnStartAgain_Click" CssClass="buttonPageBackgroudn" />
                </td>
            </tr>
            <tr id="trYoutube" runat="server" visible="false">
                <td align="left" colspan="2">
                    <span class="labelStyle">Upload Video :</span>
                </td>
                <td align="left" colspan="2">
                    <asp:FileUpload ID="fileYoutubeVideo" runat="server" />
                </td>
            </tr>
            <tr>
                <td colspan="4">
                    &nbsp;
                </td>
            </tr>
            <tr id="trMicrosite" runat="server" visible="false">
                <td align="left" colspan="2">
                    <span class="labelStyle">Microsite Name :</span>
                </td>
                <td align="left" colspan="2">
                    <asp:UpdatePanel ID="updtpanel" runat="server" RenderMode="Inline" UpdateMode="Conditional">
                        <Triggers>
                            <asp:AsyncPostBackTrigger ControlID="txtSubDomainName" EventName="TextChanged" />
                        </Triggers>
                        <ContentTemplate>
                            <asp:TextBox ID="txtSubDomainName" runat="server" CssClass="textboxesPromo" OnTextChanged="txtSubDomainName_TextChanged"
                                AutoPostBack="true" ViewStateMode="Disabled" EnableViewState="true"></asp:TextBox>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </td>
            </tr>
            <tr>
                <td colspan="4">
                    &nbsp;
                </td>
            </tr>
            <tr class="d0" valign="middle" align="left">
                <td align="left" colspan="2">
                    <span class="labelStyle">Custom Tab Name<span style="color: Red">*</span> :</span>
                </td>
                <td align="left" colspan="2">
                    <asp:TextBox ID="txtCustomTabNamePromoVid" runat="server" MaxLength="20" CssClass="textboxesPromo"></asp:TextBox><asp:RequiredFieldValidator
                        ID="rfvFilePRomo2" ControlToValidate="txtCustomTabNamePromoVid" runat="server"
                        ErrorMessage="Custom Tab Name is a mandatory field!" ValidationGroup="vGRoupBody"
                        Display="None"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr class="d0">
                <td>
                </td>
                <td align="left" colspan="3">
                    <br />
                    <asp:Button ID="btnPromoPublish" runat="server" OnClick="btnPublish_Click" CssClass="btnPublishToFacebook" />
                </td>
            </tr>
            <tr>
                <td colspan="4">
                    &nbsp;
                </td>
            </tr>
            <tr class="d1">
                <td align="left" colspan="1">
                    <iframe runat="server" id="framePage" width="550px" height="280px" frameborder="0"
                        scrolling="no"></iframe>
                </td>
                <td align="left" colspan="3">
                </td>
            </tr>
            <tr>
                <td colspan="4">
                    <asp:ValidationSummary ID="ValidationSummary2" runat="server" ValidationGroup="vGRoupBody"
                        ShowMessageBox="true" ShowSummary="false" Class="valSummaryCT" />
                </td>
            </tr>
        </table>
    </div>
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
    <div id="divPageSelect" runat="server" visible="false">
    </div>
    </div>
</asp:Content>
