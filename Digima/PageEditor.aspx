<%@ Page Language="C#" AutoEventWireup="true" ValidateRequest="false" Inherits="DigiMa.PageEditor"
    MaintainScrollPositionOnPostback="True" CodeBehind="~/PageEditor.aspx.cs" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajax" %>
<%@ Register Assembly="CKEditor.NET" Namespace="CKEditor.NET" TagPrefix="CKEditor" %>
<%--<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">--%>
<!DOCTYPE html>
<%@ Register Assembly="FreeTextBox" Namespace="FreeTextBoxControls" TagPrefix="FTB" %>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Page Editor</title>
    <meta name="SKYPE_TOOLBAR" content="SKYPE_TOOLBAR_PARSER_COMPATIBLE" />
    <script src="ScriptsSonetReach/jquery-1.8.2.min.js" type="text/javascript"></script>
    <script src="ckeditor/ckeditor.js" type="text/javascript"></script>
    <script src="ScriptsSonetReach/jquery-1.5.1.js" type="text/javascript"></script>
    <script src="ScriptsSonetReach/jqDnR.js" type="text/javascript"></script>
    <script src="ScriptsSonetReach/jquery.colorPicker.js" type="text/javascript"></script>
    <script src="ScriptsSonetReach/PageEditor.js?dh" type="text/javascript"></script>
    <link id="menuRstores" rel="stylesheet" href="" type="text/css" runat="server" />
    <link id="pageEditorStyle" runat="server" href="Styles/FacebookStyles.css" rel="stylesheet"
        type="text/css" />
    <script src="ScriptsSonetReach/jquery.fancybox.js" type="text/javascript"></script>
    <link href="CSS/jquery.fancybox.css" rel="stylesheet" type="text/css" />
    <link rel="stylesheet" href="/resources/demos/style.css" />
</head>
<body onload="check()">
    <script type="text/javascript">
        $(document).ready(function () {
            $("#divSitePages").css('text-align', 'center');
            (function ($, F) {
                F.transitions.dropOut = function () {
                    document.getElementById('<%=btnRebindPages.ClientID%>').click();
                    $.fancybox.close();
                };
            } (jQuery, jQuery.fancybox));

            $('.fancybox').fancybox({
                autoSize: false,
                width: 700,
                height: 300,
                closeMethod: 'dropOut'
            });
        });
        function closeFancyPopup() {
            $.fancybox.close();
        }
    </script>
    <script type="text/javascript">
        function getCKEditor() {
            editor = CKEDITOR.instances['<%=CKEditor1.ClientID%>'];
            return editor;
        }

    </script>
    <style type="text/css">
        div.colorPicker-picker
        {
            height: 16px;
            width: 16px;
            padding: 0 !important;
            border: 1px solid #ccc;
            background: url(arrow.gif) no-repeat top right;
            cursor: pointer;
            line-height: 16px;
        }
        div.colorPicker-palette
        {
            width: 110px;
            position: absolute;
            border: 1px solid #598FEF;
            background-color: #EFEFEF;
            padding: 2px;
            z-index: 9999;
        }
        div.colorPicker_hexWrap
        {
            width: 100%;
            float: left;
        }
        div.colorPicker_hexWrap label
        {
            font-size: 95%;
            color: #2F2F2F;
            margin: 5px 2px;
            width: 25%;
        }
        div.colorPicker_hexWrap input
        {
            margin: 5px 2px;
            padding: 0;
            font-size: 95%;
            border: 1px solid #000;
            width: 65%;
        }
        div.colorPicker-swatch
        {
            height: 12px;
            width: 12px;
            border: 1px solid #000;
            margin: 2px;
            float: left;
            cursor: pointer;
            line-height: 12px;
        }
        
        
        .TopNav
        {
            float: right;
            margin-top: 19px;
        }
        .TopNav ul
        {
            margin: 0;
            padding: 0px 0 0 0;
        }
        .TopNav ul li
        {
            list-style-type: none;
            float: left;
            display: inline;
            text-align: center;
            padding: 0px 0 0 10px;
            font-size: 12px;
        }
        .TopNav ul li a
        {
            color: #fff;
            text-decoration: none;
        }
        .TopNav ul li a:hover
        {
            color: #fff;
            text-decoration: underline;
        }
        
        
        
        .save
        {
            background-image: url("Images/FW_save.png");
            background-repeat: no-repeat;
            border: 0 none;
            border-radius: 8PX;
            cursor: pointer;
            display: block;
            height: 25px;
            line-height: 25px;
            margin: 0;
            text-align: center;
            text-decoration: none;
            vertical-align: middle;
            width: 88px;
        }
        .continue
        {
            background-image: url("Images/FW_continue.png");
            background-repeat: no-repeat;
            border: 0 none;
            border-radius: 8px;
            cursor: pointer;
            display: block;
            height: 25px;
            line-height: 25px;
            margin: 0;
            text-align: center;
            text-decoration: none;
            vertical-align: middle;
            width: 88px;
        }
        #controlOptions, .colorOptionsCloned
        {
            z-index: 1000;
            position: absolute;
            top: 0;
            left: 0;
            display: none;
            background-color: #ffc;
            border: 0px solid #ddd;
            margin: 0;
        }
        #controlOptions span, .colorOptionsCloned span
        {
            font-family: Calibri;
            margin: 0 5px;
        }
    </style>
    <script type="text/javascript">
        function pageLoad() {
            $(document).ready(function () {
                //            $('.colorblock').hover(function () {
                //                $('#colorOptions').css('top', $(this).offset().top);
                //                $('#colorOptions').css('left', $(this).offset().left);
                //                $('#colorOptions').css('display', 'block');

                //            })



                $('.block').hover(
                function () {

                    //Sets the position first

                    $('#controlOptions').css('top', $(this).offset().top);
                    $('#controlOptions').css('left', $(this).offset().left);
                    $('#controlOptions').css('display', 'block');

                    var parentTag = this;

                    //                    //Empty block
                    //                    $('#idRemoveBlock').unbind('click').click(function () {
                    //                        if (confirm('Click OK to Empty the block')) {
                    //                            $('#controlOptions').css('display', 'none');
                    //                            $(parentTag).html('<br><strong>Enter block text</strong>');
                    //                        }
                    //                        return false;
                    //                    })

                    //Delete block
                    $('#idDeleteBlock').unbind('click').click(function () {
                        if (confirm('Click OK to delete the block')) {
                            $('#controlOptions').css('display', 'none');
                            $(parentTag).remove();
                            $('#hdnReplacedDiv').val($('#divSitePages').html());

                            putColoorBlockOptios();

                        }
                        return false;
                    })

                    //Editing the Content
                    $('#idEditBlock').unbind('click').click(function () {
                        $(parentTag).trigger('click');
                        return false;
                    })

                } //   function () { $(this).css('background-color', 'Black'); }
            );




                //Check runthrough the notes and run all scripts
                if ($('#divNotesContainer').length > 0) {
                    var NotesCount = parseInt($('#hdnPageNotesNumber').val());
                    $("[id^=stickynoteNumber]").each(function () {
                        if ($(this).find("[id^=hdnScriptForNote]").length == 1) {
                            eval($(this).find("[id^=hdnScriptForNote]").val());
                        }

                    })
                }


                $('#imgOpenProperty').click(function () {
                    document.getElementById('idShowProp').style.display = 'none';
                    document.getElementById('tblProperties').style.display = '';
                })

                $('#imgCloseProperty').click(function () {
                    document.getElementById('tblProperties').style.display = 'none';
                    document.getElementById('idShowProp').style.display = '';
                })

                document.getElementById('<%=hdnCommonHTMLs.ClientID%>').value = "";
                ClickValidate(document.getElementById("divSitePages"));

                function rgb2hex(rgb) {
                    rgb = rgb.match(/^rgba?[\s+]?\([\s+]?(\d+)[\s+]?,[\s+]?(\d+)[\s+]?,[\s+]?(\d+)[\s+]?/i);

                    return (rgb && rgb.length === 4) ? "#" +
                              ("0" + parseInt(rgb[1], 10).toString(16)).slice(-2) +
                              ("0" + parseInt(rgb[2], 10).toString(16)).slice(-2) +
                              ("0" + parseInt(rgb[3], 10).toString(16)).slice(-2) : '';
                }


                // Need this to be executed on page load
                if ($('#hdnBodyStyleToSave').val() != '') {
                    $("body").attr('style', $('#hdnBodyStyleToSave').val());
                }


                $('#btnBodyBackground').click(function () {
                    debugger;
                    //get the background style
                    //Bind the popup controls according to the style
                    //   $(parentTag).css()
                    //                    if ($('body').css('background-color') == 'transparent' || $('body').css('background-color') == 'rgba(0, 0, 0, 0)')
                    //                        $('#txtBackgroundColor').val('transparent');
                    //                    else {
                    //                        if ($('#txtBackgroundColor').text.length == 0) {

                    //                        }
                    //                        else {
                    //                            $('#txtBackgroundColor').colorPicker();
                    //                        }
                    //                    }
                    //                        $('#txtBackgroundColor').val(rgb2hex($('body').css('background-color')));

                    if ($('body').css('background-image') != 'none') {
                        $('.BackgroundImageProperties').each(function () {
                            $(this).removeAttr('disabled');
                        })
                        //$('#idImageProperties').show();
                        $('#ddlBackgroundPositionX').val($('body').css('background-position').split(' ')[0]);
                        $('#ddlBackgroundPositionY').val($('body').css('background-position').split(' ')[1]);
                        $('#ddlBackgroundRepeat').val($('body').css('background-repeat'));
                    }
                    else {
                        $('.BackgroundImageProperties').each(function () {
                            $(this).attr('disabled', 'disabled');
                        })
                        //$('#idImageProperties').hide();
                        //Hide the image related properties
                    }

                    $('#spanErrormsgBackgroundColor').html('');
                    $('body').trigger('BODYclicked');
                })

                putColoorBlockOptios();
                function putColoorBlockOptios() {
                    $('.colorOptionsCloned').remove();
                    $('.colorblock').each(function () {
                        var oDiv = $(".colorOptions").clone();
                        $(oDiv).css({
                            "position": "absolute",
                            "top": $(this).offset().top,
                            "left": $(this).offset().left,
                            "display": "block"
                        }).attr('class', 'colorOptionsCloned').appendTo($('#controlOptionsContainer'));


                        var parentTag = this;

                        $(oDiv).find('.delete').unbind('click').click(function () {
                            if (confirm('Click OK to delete the block')) {
                                $(oDiv).remove();
                                $(parentTag).remove();
                                $('#hdnReplacedDiv').val($('#divSitePages').html());

                                putColoorBlockOptios();
                            }
                            return false;
                        });


                        $(oDiv).find('.color').unbind('click').click(function () {
                            //get the background style
                            //Bind the popup controls according to the style
                            //   $(parentTag).css()

                            //                            if ($(parentTag).css('background-color') == 'transparent' || $(parentTag).css('background-color') == 'rgba(0, 0, 0, 0)')
                            //                                $('#txtBackgroundColor').val('transparent');
                            //                            else {
                            //                                if ($('#txtBackgroundColor').text.length == 0) {

                            //                                }
                            //                                else {
                            //                                    $('#txtBackgroundColor').colorPicker();
                            //                                }
                            //                            }

                            if ($(parentTag).css('background-image') != 'none') {
                                $('.BackgroundImageProperties').each(function () {
                                    $(this).removeAttr('disabled');
                                })
                                //$('#idImageProperties').show();
                                $('#ddlBackgroundPositionX').val($(parentTag).css('background-position').split(' ')[0]);
                                $('#ddlBackgroundPositionY').val($(parentTag).css('background-position').split(' ')[1]);
                                $('#ddlBackgroundRepeat').val($(parentTag).css('background-repeat'));
                            }
                            else {
                                $('.BackgroundImageProperties').each(function () {
                                    $(this).attr('disabled', 'disabled');
                                })
                                //$('#idImageProperties').hide();
                                //Hide the image related properties
                            }

                            $('#spanErrormsgBackgroundColor').html('');
                            $(parentTag).trigger('colorblockclicked');
                            return false;
                        })

                        //                    $(oDiv).find('.clear').unbind('click').click(function () {
                        //                        alert('clear clicked');
                        //                        return false;
                        //                    })
                    })
                }


                //            $('#ddlBackgroundPositionX').change(function () {
                //                if ($(this).val() == 'custom')
                //                    $('#txtBackgroundPositionX').show();
                //                else
                //                    $('#txtBackgroundPositionX').hide();
                //            })

                //            $('#ddlBackgroundPositionY').change(function () {
                //                if ($(this).val() == 'custom')
                //                    $('#txtBackgroundPositionY').show();
                //                else
                //                    $('#txtBackgroundPositionY').hide();
                //            })

                $('#btnAddNote').click(
            function () {
                if ($('#divNotesContainer').length > 0) {
                    var noteNumberTemp = $('#hdnPageNotesNumber').val();
                    noteNumberTemp = parseInt(noteNumberTemp) + 1;
                    $('#hdnPageNotesNumber').val(noteNumberTemp);

                    //For each note
                    var noteNameID = 'stickynoteNumber' + noteNumberTemp;
                    var noteContentID = 'stickynoteContent' + noteNumberTemp;
                    var noteHiddenForScriptID = 'hdnScriptForNote' + noteNumberTemp;
                    var anchorForDeleteNoteID = 'stickynoteDelete' + noteNumberTemp;

                    $('#divNotesContainer').append("<div id=\"" + noteNameID + "\" class=\"jqDnR\" style=\"width: 406px; height: 115px;left: 0px; top: " + window.pageYOffset + "px; \">"
                                        + "<table width=\"100%\" cellpadding=\"0\" cellspacing=\"0\">"
                                        + "   <tr>"
                                        + "      <td colspan=\"2\">"
                                        + "      <input type=\"hidden\" id=\"" + noteHiddenForScriptID + "\" value=\"\"/>"
                                        + "         <div class=\"jqHandle jqDrag\" style=\"height: 10px; background-color: #FAF9AF\">"
                                        + "        </div>"
                                        + "       <div id=\"" + noteContentID + "\" style=\"height:100%;font-family:Segoe Print;font-size: small ;overflow:hidden;line-height: normal;\">"//font-family:Calibri;
                                        + "          Double click to add text"
                                        + "     </div>"
                                        + "</td>"
                                        + "<td style=\"width: 8px; font-size: small; color: Black;\" valign=\"top\">"
                                        + "   <a id=\"" + anchorForDeleteNoteID + "\"  href=\"javascript:void(0)\" style=\"color: Black; text-decoration: none;font-family:Segoe Print;\">"
                                        + "       x</a>"
                                        + "</td>"
                                        + "</tr>"
                                        + "<tr>"
                                        + "  <td valign=\"bottom\">"
                                        + "       <div class=\"jqHandle jqResize\">"
                                        + "       </div>"
                                        + "  </td>"
                                        + "</tr>"
                                        + "</table>"
                                        + "</div>");

                    //Dragging and resizing event binding
                    $('#' + noteHiddenForScriptID).val("$('#" + noteNameID + "').jqDrag('.jqDrag').jqResize('.jqResize');");

                    //Double click and add text event binding
                    $('#' + noteHiddenForScriptID).val($('#' + noteHiddenForScriptID).val() + "$('#" + noteContentID + "').dblclick(function () {"
                    + "  $('#" + noteContentID + "').attr('contenteditable', 'true');"
                    + "  $('#" + noteContentID + "').css('background-color', 'white');"
                    + "  if ($('#" + noteContentID + "').html().trim() == 'Double click to add text')"
                    + "       $('#" + noteContentID + "').html('');"
                    + "  $('#" + noteContentID + "').focus();"
                    + "});");

                    //Focus out and style change event and also page save flag activate
                    $('#' + noteHiddenForScriptID).val($('#' + noteHiddenForScriptID).val() + "$('#" + noteContentID + "').focusout(function () {"
                    + "    $('#" + noteContentID + "').attr('contenteditable', 'false');"
                    + "    $('#" + noteContentID + "').css('background-color', '#FCFBBA');"
                    + "    if ($('#" + noteContentID + "').html().trim().replace(/&nbsp;/g, '').trim().replace(/<br>/g, '').trim() == '')"
                    + "         $('#" + noteContentID + "').html('Double click to add text');"
                    + "    $('#hdnReplacedDiv').val($('#divSitePages').html());"
                    + "});");


                    //For delete note event binding
                    $('#' + noteHiddenForScriptID).val($('#' + noteHiddenForScriptID).val() + "$('#" + anchorForDeleteNoteID + "').click(function () {"
                    + "      if(confirm('Do you really want to delete the Note'))"
                    + "          $('#" + noteNameID + "').remove();"
                    + "      $('#hdnReplacedDiv').val($('#divSitePages').html());"
                    + "});");

                    eval($('#' + noteHiddenForScriptID).val());

                    $('#hdnReplacedDiv').val($('#divSitePages').html());
                }
            })
            });
            //                                check();
        }        
    </script>
    <script type="text/javascript">
        function colorChanged(sender) {
            sender.get_element().style.color = "#" + sender.get_selectedColor();
        }
    </script>
    <script type="text/javascript">
        function check() {

            if (document.getElementById('<%=hdnErrorPopup.ClientID%>').value != "") {
                alert(document.getElementById('<%=hdnErrorPopup.ClientID%>').value);
                document.getElementById('<%=hdnErrorPopup.ClientID%>').value = '';
            }
        }
        //        $(document).ready(function () {
        //            document.getElementById('<%=hdnCommonHTMLs.ClientID%>').value = "";
        //            ClickValidate(document.getElementById("divSitePages"));

        //        });
        function get_users() {
            //Check if some changes happened first
            if ($('#hdnReplacedDiv').val() != '') {
                if (confirm('Do you want to save the current page before proceed ?')) {
                    $('#hdnDropDownStatus').val('SAVE');
                    __doPostBack('ddlPagesList', '');
                }
                else {
                    //Don't save but change the page    
                    $('#hdnDropDownStatus').val('DISCARD');
                    __doPostBack('ddlPagesList', '');
                }
            }
            else {
                //change the page
                $('#hdnDropDownStatus').val('DISCARD');
                __doPostBack('ddlPagesList', '');
            }

        }
    </script>
    <style type="text/css">
        .jqHandle
        {
            background: red;
            height: 15px;
        }
        
        .jqDrag
        {
            width: 100%;
            cursor: move;
        }
        
        .jqResize
        {
            width: 15px;
            position: absolute;
            bottom: 0;
            right: 0;
            cursor: se-resize;
        }
        
        .jqDnR
        {
            z-index: 3;
            position: absolute;
            width: 180px;
            font-size: 0.77em;
            color: #618d5e;
            margin: 5px 10px 10px 10px;
            padding: 8px;
            padding-top: 0px;
            background-color: #FCFBBA;
            border: 1px solid #CCC;
        }
        #cke_CKEditor1
        {
            width: 850px;
        }
    </style>
    <style type="text/css">
        .buttons
        {
            background-color: #12488e;
            border: 1px solid #ADD8E6;
            border-radius: 13px 13px 13px 13px;
            color: White;
            font-family: Trebuchet MS;
            font-size: smaller;
            width: 86px;
        }
        .buttonPageBackgroudn
        {
            background-image: url('Images/FW_page_background.png');
            background-repeat: no-repeat;
            border: 0 none;
            border-radius: 8px;
            cursor: pointer;
            display: block;
            height: 25px;
            line-height: 25px;
            margin: 0;
            text-align: center;
            text-decoration: none;
            vertical-align: middle;
            width: 142px;
            color: White;
        }
        .backButton
        {
            background-image: url('Images/FW_back.png');
            background-repeat: no-repeat;
            border: 0 none;
            border-radius: 8px;
            cursor: pointer;
            display: block;
            height: 25px;
            line-height: 25px;
            margin: 0;
            text-align: center;
            text-decoration: none;
            vertical-align: middle;
            width: 88px;
            color: White;
        }
        .hide
        {
            display: none;
        }
        .common:hover
        {
            /*background-color: rgba(204,204,0,0.5) !important;*/
        }
        .commonmenu:hover
        {
            background-color: rgba(204,204,0,0.4);
        }
        .block:hover
        {
            background-color: rgba(245,245,245,0.6);
            background: rgba(235,235,235,0.6);
        }
        .link
        {
            font-family: Segoe UI,Tahoma,Arial,Verdana,sans-serif;
            color: Black;
            text-decoration: none;
            font-size: 13px;
        }
        .text
        {
            font-family: Segoe UI,Tahoma,Arial,Verdana,sans-serif;
            color: Black;
            font-size: 13px;
        }
    </style>
    <script type="text/javascript">
        function example_reset_html(id) {
            $('#' + id).html($('#' + id).html());
        }
        function SaveCommonHTMLs() {
            //            if ($('#divNotesContainer').length > 0)
            //                $('#divNotesContainer').hide();
            $('.common').each(function (i, obj) {
                if (document.getElementById('<%=hdnCommonHTMLs.ClientID%>').value != '')
                    document.getElementById('<%=hdnCommonHTMLs.ClientID%>').value = document.getElementById('<%=hdnCommonHTMLs.ClientID%>').value + '~';
                document.getElementById('<%=hdnCommonHTMLs.ClientID%>').value = document.getElementById('<%=hdnCommonHTMLs.ClientID%>').value + obj.id;
            });
            //            alert(document.getElementById('<%=hdnCommonHTMLs.ClientID%>').value);
        }
    </script>
    <script type="text/javascript">
        function colorChanged(sender) {
            sender.get_element().style.color = "#" + sender.get_selectedColor();
        }
        

    </script>
    <style>
        #divSitePages
        {
            text-align: center;
        }
        
        #ddlPagesList
        {
            background-color: #8F1315;
            border-radius: 4px 4px 4px 4px;
            color: White;
            font-size: 11px;
            padding: 3px;
            width: 350px;
        }
    </style>
    <form id="form1" runat="server">
    <ajax:ToolkitScriptManager ID="ScriptManager1" runat="server">
    </ajax:ToolkitScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <div id="controlOptionsContainer">
                <div id="controlOptions" style="display: none; font-size: 12px">
                    <span><a href="" id="idEditBlock">Edit</a></span> <span><a href="" id="idDeleteBlock">
                        Delete</a></span>
                </div>
            </div>
            <div class="colorOptions" style="display: none; width: 120px; padding: 0; font-size: 12px">
                <span><a href="" class="color">Background</a></span><span><a href="" class="delete">
                    Delete</a></span>
            </div>
            <table width="100%" cellpadding="0" cellspacing="0">
                <tr>
                    <td>
                        <center id="FullPageBody">
                            <table align="center" style="width: 100%" cellpadding="0" cellspacing="0">
                                <tr id="EditPages" runat="server" align="center" visible="false">
                                    <td colspan="2" align="center">
                                        <table align="center" style="width: 100%" cellpadding="0" cellspacing="0">
                                            <tr>
                                                <td>
                                                    <asp:Button ID="btnRebindPages" runat="server" OnClick="btnRebindPages_OnClick" CssClass="hide" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <div id="divSitePages" runat="server">
                                                    </div>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                            </table>
                        </center>
                    </td>
                    <td id="tblProperties" style="position: fixed; right: 0px; top: 0px; height: 100%;
                        width: 250px; vertical-align: top; display: none; z-index: 2000;">
                        <%--  <td id="tblProperties" style="background: #E3EAF4; position: fixed; right: 0px; top: 0px;
                        height: 100%; width: 250px; vertical-align: top; display: none; z-index: 2000;">--%>
                        <table width="90%" style="background: url('Images1/background_slider.png');">
                            <caption>
                                <br />
                                <tr align="center" style="background-color: #bc0602;">
                                    <td align="center" colspan="2">
                                        <span style="color: White; font-family: Helvetica; font-weight: bold;">TOOLBOX</span>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <a href="javascript:void(0);">
                                            <img id="imgCloseProperty" src="Images1/HideProperties.png" />
                                        </a>
                                    </td>
                                    <td align="right">
                                        <%--<asp:Button ID="btnNextPage" runat="server" OnClientClick=" return confirm('all pages design is done?');"
                                Text="Next >>" OnClick="btnNextPage_Click" />--%>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2">
                                        <asp:Button ID="btnBack" runat="server" class="backButton" OnClick="btnBack_Click"
                                            Text="" />
                                    </td>
                                </tr>
                                <tr>
                                    <td align="center" colspan="2">
                                        <table>
                                            <tr align="center">
                                                <td style="text-align: left; font-weight: bold; color: Black; font-size: 13px; width: 80px;">
                                                    Pages
                                                </td>
                                                <td style="text-align: left; font-weight: bold; color: Black; font-size: 13px;">
                                                    &nbsp;:&nbsp;
                                                </td>
                                                <td style="text-align: left">
                                                    <asp:DropDownList ID="ddlPagesList" runat="server" AutoPostBack="true" onchange="return get_users()"
                                                        OnSelectedIndexChanged="ddlPagesList_SelectedIndexChanged" Width="100%">
                                                    </asp:DropDownList>
                                                </td>
                                            </tr>
                                            <%--<tr>
                                            <td colspan="3">
                                                <asp:LinkButton runat="server" ID="lbUndoAll" CssClass="link" OnClick="lbUndoAll_OnClick"
                                                    Text="Undo All Changes"></asp:LinkButton>
                                            </td>
                                        </tr>--%>
                                            <tr>
                                                <td colspan="3">
                                                    <a id="ancPreviewPage" runat="server" class="link" target="_blank">Preview current Page</a>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="3">
                                                    <input type="button" id="btnBodyBackground" class="buttonPageBackgroudn" onclick="return btnBodyBackground_onclick()" />
                                                    <asp:HiddenField ID="hdnBodyStyleToSave" runat="server" />
                                                    <asp:HiddenField ID="hdnBodyStyleToSaveHelp" runat="server" />
                                                </td>
                                            </tr>
                                            <tr align="left">
                                                <td>
                                                </td>
                                                <td style="padding-top: 25px">
                                                    <asp:Button ID="btnSave" runat="server" class="save" OnClick="btnSave_OnClick" OnClientClick="return SaveCommonHTMLs()" />
                                                    <asp:HiddenField ID="hdnCommonHTMLs" runat="server" />
                                                </td>
                                                <td style="padding-top: 25px">
                                                    <asp:Button ID="btnComplete" runat="server" class="continue" OnClick="btnComplete_Click" />
                                                    <asp:HiddenField ID="hdnComplete" runat="server" />
                                                </td>
                                            </tr>
                                        </table>
                                        <%--<input type="hidden" runat="server" id="hdnCurrentActionPage" />--%>
                                    </td>
                                </tr>
                            </caption>
                        </table>
                    </td>
                    <td id="idShowProp" style="position: fixed; right: 10px; top: 0px; width: 30PX; z-index: 2000;">
                        <a href="javascript:void(0);">
                            <img src="Images1/ShowProperties.png" id="imgOpenProperty" /></a>
                    </td>
                </tr>
            </table>
            <table id="PassChangeForm" style="z-index: 3000; top: 0px; left: 0px; position: fixed;
                visibility: hidden; width: 100%; height: 100%; background-repeat: repeat; background-image: url('Images1/TransparentImage.png');">
                <tr>
                    <td align="center">
                        <br />
                        <br />
                        <br />
                        <br />
                        <table style="width: 150px; height: 200px; background-color: White; -moz-border-radius: 7px 7px 7px 7px;
                            -webkit-border-radius: 7px;" cellpadding="0" cellspacing="0" id="passchangeInnerTable">
                            <tr>
                                <td align="center" style="padding: 10px 10px 10px 10px">
                                    <table width="500px" height="200px" id="popup" bgcolor="#ADD8E6">
                                        <tr id="trUpload" runat="server">
                                            <td style="color: Black">
                                                Browse
                                            </td>
                                            <td>
                                                <b>:</b>&nbsp;&nbsp;&nbsp;&nbsp;
                                                <asp:FileUpload ID="FileUpload1" runat="server" />
                                                <asp:HiddenField ID="hdnImageName" runat="server" />
                                                <asp:HiddenField runat="server" ID="hdnDropDownStatus" />
                                                <asp:HiddenField runat="server" ID="hdnErrorPopup" />
                                                <asp:HiddenField runat="server" ID="hdnImagesPathForSite" />
                                            </td>
                                        </tr>
                                        <tr id="trHref" runat="server">
                                            <td style="color: Black">
                                                Href
                                            </td>
                                            <td>
                                                <b>:</b>&nbsp;&nbsp;&nbsp;&nbsp;
                                                <asp:TextBox ID="txthref" runat="server"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr id="trCKEditor">
                                            <td style="color: Black">
                                                Content
                                            </td>
                                            <td>
                                                <CKEditor:CKEditorControl ID="CKEditor1" runat="server" Width="850px" Height="200px"></CKEditor:CKEditorControl>
                                                <%--<script type="text/javascript">
                                            CKEDITOR.replace('CKEditor1',
				                            {
                                            
                                                filebrowserBrowseUrl :'ckeditor/filemanager/browser/default/browser.html?Connector=http://localhost:54505/WebHutNew/ckeditor/filemanager/connectors/php/connector.php',
//                                              filebrowserImageBrowseUrl : 'js/ckeditor/filemanager/browser/default/browser.html?Type=Image&Connector=http://kodemaster.co.cc/filemanager_in_ckeditor/js/ckeditor/filemanager/connectors/php/connector.php',                                                
//					                            filebrowserUploadUrl  :'http://kodemaster.co.cc/filemanager_in_ckeditor/js/ckeditor/filemanager/connectors/php/upload.php?Type=File',
//					                            filebrowserImageUploadUrl : 'http://kodemaster.co.cc/filemanager_in_ckeditor/js/ckeditor/filemanager/connectors/php/upload.php?Type=Image',

					                            //filebrowserFlashUploadUrl : 'http://kodemaster.co.cc/filemanager_in_ckeditor/js/ckeditor/filemanager/connectors/php/upload.php?Type=Flash',
                                                //filebrowserFlashBrowseUrl :'js/ckeditor/filemanager/browser/default/browser.html?Type=Flash&Connector=http://kodemaster.co.cc/filemanager_in_ckeditor/js/ckeditor/filemanager/connectors/php/connector.php',


//				                                extraPlugins: 'uicolor',
//				                                toolbar:
//					                            [
//						                            { name: 'document', items: ['Source'] },
//	                                                { name: 'clipboard', items: ['Cut', 'Copy', 'Paste', 'PasteText', 'PasteFromWord', '-', 'Undo', 'Redo'] },
//	                                                { name: 'editing', items: ['Find', 'Replace', '-', 'SelectAll', '-', 'SpellChecker', 'Scayt'] },
//	                                                { name: 'basicstyles', items: ['Bold', 'Italic', 'Underline', 'Strike', 'Subscript', 'Superscript', '-', 'RemoveFormat'] },
//	                                                { name: 'paragraph', items: ['NumberedList', 'BulletedList', '-', 'Outdent', 'Indent', '-', 'Blockquote', 'CreateDiv','-', 'JustifyLeft', 'JustifyCenter', 'JustifyRight', 'JustifyBlock', '-', 'BidiLtr', 'BidiRtl']},
//	                                                { name: 'links', items: ['Link', 'Unlink', 'Anchor'] },
//	                                                { name: 'styles', items: ['Styles', 'Format', 'Font', 'FontSize'] },
//	                                                { name: 'colors', items: ['TextColor', 'BGColor'] }
//					                            ]
				                            });
                                        </script>--%>
                                            </td>
                                        </tr>
                                        <tr id="trBackgroundSetting">
                                            <td colspan="2">
                                                <table>
                                                    <tr>
                                                        <td id="tdFileUploadForBackground" colspan="2">
                                                            <asp:FileUpload ID="FileUploadForBackground" runat="server" />
                                                            <input type="button" onclick="example_reset_html('tdFileUploadForBackground');" value="Clear">
                                                        </td>
                                                    </tr>
                                                    <tr id="idImageProperties">
                                                        <td colspan="2">
                                                            <table>
                                                                <tr>
                                                                    <td style="font-weight: bold">
                                                                        Background Image: <a id="anchorClearImage" style="font-weight: normal; text-decoration: underline;
                                                                            color: Blue" href="javascript:void(0)"><span>Clear Image</span></a>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td>
                                                                        Image Position-X
                                                                    </td>
                                                                    <td>
                                                                        <asp:DropDownList runat="server" ID="ddlBackgroundPositionX" CssClass="BackgroundImageProperties">
                                                                            <asp:ListItem Text="Left" Value="0%"></asp:ListItem>
                                                                            <asp:ListItem Text="Right" Value="100%"></asp:ListItem>
                                                                            <asp:ListItem Text="Center" Value="50%"></asp:ListItem>
                                                                        </asp:DropDownList>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td>
                                                                        Image Position-Y
                                                                    </td>
                                                                    <td>
                                                                        <asp:DropDownList runat="server" ID="ddlBackgroundPositionY" CssClass="BackgroundImageProperties">
                                                                            <asp:ListItem Text="Top" Value="0%"></asp:ListItem>
                                                                            <asp:ListItem Text="Bottom" Value="100%"></asp:ListItem>
                                                                            <asp:ListItem Text="Center" Value="50%"></asp:ListItem>
                                                                        </asp:DropDownList>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td>
                                                                        Image repeat
                                                                    </td>
                                                                    <td>
                                                                        <asp:DropDownList runat="server" ID="ddlBackgroundRepeat" CssClass="BackgroundImageProperties">
                                                                            <asp:ListItem Text="Yes" Value="repeat"></asp:ListItem>
                                                                            <asp:ListItem Text="No" Value="no-repeat"></asp:ListItem>
                                                                            <asp:ListItem Text="X-Direction" Value="repeat-x"></asp:ListItem>
                                                                            <asp:ListItem Text="Y-Direction" Value="repeat-y"></asp:ListItem>
                                                                        </asp:DropDownList>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                        <tr id="trBackgroundColorSp">
                                            <td style="font-weight: bold" align="center" colspan="2">
                                                Background Color:
                                            </td>
                                        </tr>
                                        <tr id="trBackgroundColorMain">
                                            <td colspan="1" align="center">
                                                <a id="anchorClearColor" style="font-weight: normal; text-decoration: underline;
                                                    color: Blue" href="javascript:void(0)"><span>Clear Color</span></a>
                                            </td>
                                            <td colspan="1" align="center">
                                                <asp:TextBox runat="server" ID="txtBackgroundColor"></asp:TextBox><span id="spanErrormsgBackgroundColor"
                                                    style="color: Red;"></span>
                                                <ajax:ColorPickerExtender ID="defaultCPE" runat="server" OnClientColorSelectionChanged="colorChanged"
                                                    TargetControlID="txtBackgroundColor">
                                                </ajax:ColorPickerExtender>
                                            </td>
                                        </tr>
                                        <tr id="trYoutubeStuff">
                                            <td>
                                                Add youtube URL :
                                            </td>
                                            <td>
                                                <asp:TextBox runat="server" ID="txtYoutubeURL"></asp:TextBox><span id="span1" style="color: Red;"></span>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="3" align="center">
                                                <b></b>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                                <input type="button" id="btnSubmit" value="Submit" class="buttons" />
                                                <asp:Button ID="btnImageSubmit" runat="server" OnClick="btnImageSubmit_Click" Text="Submit"
                                                    CssClass="buttons" />
                                                <asp:Button ID="btnBackgroundSubmit" runat="server" OnClick="btnBackgroundSubmit_Click"
                                                    Text="Submit" CssClass="buttons" />
                                                <asp:Button ID="btnDelete" runat="server" OnClick="btnDelete_Click" Text="Delete"
                                                    CssClass="buttons" />
                                                <asp:HiddenField ID="hdnReplacedDiv" runat="server" />
                                                <asp:HiddenField ID="hdnReplacedDivHelp" runat="server" />
                                                <asp:HiddenField ID="hdnImageClass" runat="server" />
                                                <asp:HiddenField ID="hdnYoutubeURL" runat="server" />
                                                <input type="button" id="temp" onclick="closechangepopup()" value="Cancel" class="buttons" />
                                            </td>
                                        </tr>
                                        <tr id="trInformational">
                                            <td>
                                                This element has been deleted! Expand the TOOLBOX and click Back to start again.
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                        </table>
                        <br />
                        <br />
                        <br />
                        <br />
                        <br />
                        <br />
                        <br />
                        <br />
                        <br />
                        <br />
                    </td>
                </tr>
            </table>
        </ContentTemplate>
        <Triggers>
            <asp:PostBackTrigger ControlID="btnImageSubmit" />
            <asp:PostBackTrigger ControlID="btnBackgroundSubmit" />
            <asp:PostBackTrigger ControlID="btnDelete" />
        </Triggers>
    </asp:UpdatePanel>
    </form>
</body>
</html>
