

var g_obj = "";
var tag = "";
var tagClass = "";
var obj1 = "";
var ClickTag = "";
function endsWith(str, suffix) {
    return str.indexOf(suffix, str.length - suffix.length) !== -1;
}
function ClickValidate(obj) {

    $(obj).find("a").not("#divNotesContainer a").click(    //:not(#divNotesContainer)
        function (event) {
            g_obj = this;
            tag = $(this).get(0).nodeName;
            tagRedirection(this, tag);
            return false;
        });
    $(obj).find("li").click(
        function (event) {
            g_obj = this;
            tag = $(this).get(0).nodeName;
            tagRedirection(this, tag);
            return false;
        })
        $(obj).find("img").click(
        function (event) {
            var classname = this.className;
            if (classname == "dynamic") {  //If You want to restrict a Image not to change
                tagRedirection(this, 'dynamic');
                return false;
            }
            if (classname == 'ActionImg') {
                tagRedirection(this, 'ActionImg');
                return false;
            }
            if (this.parentNode.nodeName.toLowerCase() == "a") {//If a Image is inside an anchor tag
                if (event.ctrlKey) {  //Give option to change the link
                    //document.getElementById('facebookid').parentNode.nodeName.toLowerCase()
                    g_obj = this.parentNode;
                    tag = $(this).get(0).parentNode.nodeName + '>' + 'IMG'
                    tagRedirection(this.parentNode, tag);
                    return false;
                }
            }
            g_obj = this;
            tag = $(this).get(0).nodeName;
            tagRedirection(this, tag);
            return false;
        })
    $(obj).find(".img").click(
            function (event) {
                g_obj = this;
                tag = "BackImg";
                tagRedirection(this, tag);
                return false;
            })
    $(obj).find("span").click(
        function (event) {
            g_obj = this;
            tag = $(this).get(0).nodeName;
            tagRedirection(this, tag);
            return false;
        })
    $(obj).find("p").click(
        function (event) {
            g_obj = this;
            tag = $(this).get(0).nodeName;
            tagRedirection(this, tag);
            return false;
        })
    $(obj).find("h1").click(
        function (event) {
            g_obj = this;
            tag = $(this).get(0).nodeName;
            tagRedirection(this, tag);
            return false;
        })
    $(obj).find("h2").click(
        function (event) {
            g_obj = this;
            tag = $(this).get(0).nodeName;
            tagRedirection(this, tag);
            return false;
        })
    $(obj).find("h3").click(
        function (event) {
            g_obj = this;
            tag = $(this).get(0).nodeName;
            tagRedirection(this, tag);
            return false;
        })
    $(obj).find("h4").click(
        function (event) {
            g_obj = this;
            tag = $(this).get(0).nodeName;
            tagRedirection(this, tag);
            return false;
        })
    $(obj).find("h5").click(
        function (event) {
            g_obj = this;
            tag = $(this).get(0).nodeName;
            tagRedirection(this, tag);
            return false;
        })
    //    $(obj).find("div").click(
    //        function (event) {
    //            g_obj = this;
    //            tag = $(this).get(0).nodeName;
    //            tagRedirection(this, tag);
    //            return false;
    //        })
    $(obj).find("h6").click(
        function (event) {
            g_obj = this;
            tag = $(this).get(0).nodeName;
            tagRedirection(this, tag);
            return false;
        })
    $(obj).find("b").click(
        function (event) {
            g_obj = this;
            tag = $(this).get(0).nodeName;
            tagRedirection(this, tag);
            return false;
        })
    $(obj).find("dt").click(
        function (event) {
            g_obj = this;
            tag = $(this).get(0).nodeName;
            tagRedirection(this, tag);
            return false;
        })
    $(obj).find("dd").click(
        function (event) {
            g_obj = this;
            tag = $(this).get(0).nodeName;
            tagRedirection(this, tag);
            return false;
        })
    $(obj).find(".txt1").click(
            function (event) {
                g_obj = this;
                tag = "DIV";
                tagRedirection(this, tag);
                return false;
            })
    $(obj).find(".img-box1").click(
            function (event) {
                g_obj = this;
                tag = "IFRAME";
                tagRedirection(this, tag);
                return false;
            })
    $(obj).find(".colorblock").bind('colorblockclicked',
            function (event) {
                g_obj = this;
                tag = "DIVcolorblock";
                tagRedirection(this, tag);
                return false;
            })
    $("body").bind('BODYclicked',
            function (event) {
                g_obj = this;
                tag = "BODYcolor";
                tagRedirection(this, tag);
                return false;
            })

            $("#btnBackgroundSubmit").click(function () {
                //Validations
                debugger;
                if (!($('#txtBackgroundColor').val().match('^([A-Fa-f0-9]{6}|[A-Fa-f0-9]{3})$') || $('#txtBackgroundColor').val() == 'transparent')) {
                    $('#spanErrormsgBackgroundColor').html('Color code not valid');
                    return false
                }

                var htmldiv = $('#divSitePages').html();
                $('#hdnReplacedDivHelp').val(htmldiv);

                var newcolorHex = '#' + $('#txtBackgroundColor').val();
                $(g_obj).css('background-color', newcolorHex);
                $(g_obj).css('background-color', newcolorHex);
                $(g_obj).css('background-repeat', $('#ddlBackgroundRepeat').val());
                $(g_obj).css('background-position', $('#ddlBackgroundPositionX').val() + ' ' + $('#ddlBackgroundPositionY').val());


                if ($('#FileUploadForBackground').val().length > 0) {
                    var sUrl;

                    var ImageURL = $('#FileUploadForBackground').val().split('/');
                    $('#hdnImageName').val(ImageURL);
                    sUrl = 'url(\"' + $('#hdnImagesPathForSite').val() + '/images/' + $("#FileUploadForBackground").val().replace(/C:\\fakepath\\/i, '') + '\")';
                    //                    if (document.getElementById('header').style.backgroundImage == '') {
                    //                        sUrl = 'url(\"' + $('#hdnImagesPathForSite').val() + '/images/' + $("#FileUploadForBackground").val().replace(/C:\\fakepath\\/i, '') + '\")';
                    //                        //url("Sites/Tool/103/images/cake.jpg")
                    //                    }
                    //                    else {
                    //                        var ImageURL = new Array();
                    //                        var ImageURL = $(g_obj).css('background-image').replace('url(', '').replace(')', '').split('/');      // g_obj.src.split('/');
                    //                        var ImageURLCount = ImageURL.length - 1;
                    //                        var ImageName = ImageURL[ImageURLCount];
                    //                        $('#hdnReplacedDivHelp').val(htmldiv);
                    //                        //var ht = htmldiv.replace(ImageName, $("#FileUpload1").val().replace(/C:\\fakepath\\/i, ''));   //$('input[type=file]').val().replace(/C:\\fakepath\\/i, '')
                    //                        sUrl = document.getElementById(g_obj.id).style.backgroundImage.replace(ImageName.replace('\"', ''), $("#FileUploadForBackground").val().replace(/C:\\fakepath\\/i, ''));
                    //                    }

                    $('#hdnBodyStyleToSaveHelp').val($("body").attr('style'));
                    $(g_obj).css('background-image', sUrl);
                    //Removing the absolute path and making it as relative path
                    $(g_obj).attr('style', $(g_obj).attr('style').replace($(g_obj).attr('style').substring($(g_obj).attr('style').indexOf('http'), $(g_obj).attr('style').indexOf('/Sites') + 1), ''));

                    var ht = $('#divSitePages').html();
                    //$('#divSitePages').html(ht);
                    $('#hdnReplacedDiv').val(ht);

                    if (tag == 'BODYcolor') {
                        $('#hdnBodyStyleToSave').val($("body").attr('style'));
                    }
                    $('#hdnReplacedDiv').val($('#divSitePages').html());
                }
                else {
                    if (tag == 'BODYcolor') {
                        $('#hdnBodyStyleToSave').val($("body").attr('style'));
                    }
                    $('#hdnReplacedDiv').val($('#divSitePages').html());
                    closechangepopup();
                    return false;
                }
            })



    $('#anchorClearImage').click(function () {
        if (confirm('Click OK to remove image')) {
            $(g_obj).css('background-image', 'none');
            $('.BackgroundImageProperties').each(function () {
                $(this).attr('disabled', 'disabled');
            })
            //$('#idImageProperties').hide();
        }
    })
    $('#anchorClearColor').click(function () {
        if (confirm('Click OK to remove color')) {
            $(g_obj).css('background-color', 'transparent');
            if ($(g_obj).css('background-color') == 'transparent' || $(g_obj).css('background-color') == 'rgba(0, 0, 0, 0)')
                $('#txtBackgroundColor').val('transparent');
            else
                $('#txtBackgroundColor').val(rgb2hex($(g_obj).css('background-color')));
            $('body').css('background-color',$('#txtBackgroundColor').val());
        }
    })


    //////            if ($('#FileUploadForBackground').val().length > 0) {
    //////                //alert($("#FileUpload1").val());
    //////                var htmldiv = $('#divSitePages').html();
    //////                var ImageURL = new Array();
    //////                debugger;
    //////                var ImageURL = $(g_obj).css('background-image').replace('url(', '').replace(')', '').split('/');      // g_obj.src.split('/');
    //////                var ImageURLCount = ImageURL.length - 1;
    //////                var ImageName = ImageURL[ImageURLCount];
    //////                $('#hdnReplacedDivHelp').val(htmldiv);

    //////                var ht = htmldiv.replace(ImageName, $("#FileUploadForBackground").val().replace(/C:\\fakepath\\/i, ''));   //$('input[type=file]').val().replace(/C:\\fakepath\\/i, '')
    //////                //$(g_obj).css('background-image',  $(g_obj).css('background-image').replace(ImageName, $("#FileUploadForBackground").val().replace(/C:\\fakepath\\/i, '')));

    //////                var ht = $('#divSitePages').html();
    //////                $('#divSitePages').html(ht);
    //////                $('#hdnReplacedDiv').val(ht);
    //////            }
    //////            //Apply the rest baackground properties
    //////            //For setting the Image background
    //////            //css('backgroundImage','url:('+options+')');
    //////            //                $(g_obj).css('background-color', $('#txtBackgroundColor').val());
    //////            //                $(g_obj).css('background-color', $('#txtBackgroundColor').val());
    //////            //                $(g_obj).css('background-repeat', $('#ddlBackgroundRepeat').val());
    //////            //                $(g_obj).css('background-position', $('#ddlBackgroundPositionX').val() + ' ' + $('#ddlBackgroundPositionY').val());
    //////            //                closechangepopup();
    $("#btnImageSubmit").click(
        function (event) {
            if ($('#FileUpload1').val().length > 0) {
                switch (tag) {
                    case 'IMG':
                        //alert($("#FileUpload1").val());
                        var htmldiv = $('#divSitePages').html();
                        var ImageURL = new Array();
                        var ImageURL = g_obj.src.split('/');
                        var ImageURLCount = ImageURL.length - 1;
                        var ImageName = ImageURL[ImageURLCount];
                        $('#hdnImageName').val(ImageName);
                        $('#hdnReplacedDivHelp').val(htmldiv);
                        var ht = htmldiv.replace(ImageName, $("#FileUpload1").val().replace(/C:\\fakepath\\/i, ''));   //$('input[type=file]').val().replace(/C:\\fakepath\\/i, '')
                        var djkb = $('#divSitePages').html();
                        $('#divSitePages').html(ht);
                        $('#hdnReplacedDiv').val(ht);
                        closechangepopup();
                        break;
                    case 'BackImg':
                        var htmldiv = $('#divSitePages').html();
                        var ImageURL = new Array();
                        var ImageURL = $(g_obj).css("background-image").split('/');
                        var ImageURLCount = ImageURL.length - 1;
                        var ImageName = ImageURL[ImageURLCount];
                        $('#hdnImageName').val(ImageName);
                        $('#hdnReplacedDiv').val(htmldiv);
                        closechangepopup();
                        break;
                    case 'OBJECT':
                        var htmldiv = $('#divSitePages').html();
                        var ImageURL = new Array();
                        var ImageURL = g_obj.$("embed").src.split('/');
                        var ImageURLCount = ImageURL.length - 1;
                        var ImageName = ImageURL[ImageURLCount];
                        $('#hdnReplacedDivHelp').val(htmldiv);
                        var ht = htmldiv.replace(ImageName, $("#FileUpload1").val().replace(/C:\\fakepath\\/i, ''));   //$('input[type=file]').val().replace(/C:\\fakepath\\/i, '')
                        var djkb = $('#divSitePages').html();
                        $('#divSitePages').html(ht);
                        $('#hdnReplacedDiv').val(ht);
                        closechangepopup();
                }
            }
            else {
                closechangepopup();
                return false;
            }
        })

    //Added by Apresh for delete 02 Jan2013
    $("#btnDelete").click(
        function (event) {
            //            if ($('#FileUpload1').val().length > 0) {
            switch (tag) {
                case 'IMG':
                    var conf = confirm("Are you sure you want to delete this element? You will not be able to add this back!");
                    if (conf == true) {

                        var htmldiv = $('#divSitePages').html();
                        var ImageURL = new Array();
                        var ImageClass = g_obj.className;
                        var ImageURL = g_obj.src.split('/');
                        var ImageURLCount = ImageURL.length - 1;
                        var ImageClassCount = ImageClass.length - 1;
                        var ImageName = ImageURL[ImageURLCount];
                        $('#hdnImageName').val(ImageName);
                        $('#hdnImageClass').val(ImageClass);
                        $('#hdnReplacedDivHelp').val(htmldiv);

                        var ht = htmldiv.replace(ImageName, '');   //$('input[type=file]').val().replace(/C:\\fakepath\\/i, '')
                        var djkb = $('#divSitePages').html();
                        $('#divSitePages').html(ht);
                        $('#hdnReplacedDiv').val(ht);
                        closechangepopup();
                    }
                    else {
                        closechangepopup();
                    }
                    break;
                case 'IFRAME':
                    var conf = confirm("Are you sure you want to delete this element? You will not be able to add this back!");
                    if (conf == true) {

                        var htmldiv = $('#divSitePages').html();
//                        var ImageURL = new Array();
//                        var ImageClass = g_obj.className;
//                        var ImageURL = g_obj.src.split('/');
//                        var ImageURLCount = ImageURL.length - 1;
//                        var ImageClassCount = ImageClass.length - 1;
//                        var ImageName = ImageURL[ImageURLCount];
//                        $('#hdnImageName').val(ImageName);
//                        $('#hdnImageClass').val(ImageClass);
                        $('#hdnReplacedDivHelp').val(htmldiv);

                        var ht = htmldiv.replace(ImageName, '');   //$('input[type=file]').val().replace(/C:\\fakepath\\/i, '')
                        var djkb = $('#divSitePages').html();
                        $('#divSitePages').html(ht);
                        $('#hdnReplacedDiv').val(ht);
                        closechangepopup();
                    }
                    else {
                        closechangepopup();
                    }
                    break;

            } //end of switch
        })

    $("#btnSubmit").click(
        function (event) {
            switch (tag) {

                case 'SPAN':
                    //                    if ($("#txtSpanContent").val() != null && $("#txtSpanContent").val() != "") {
                    //                        $(g_obj).html($("#txtSpanContent").val());
                    if (getCKEditor().getData() != null && getCKEditor().getData() != "") {

                        $(g_obj).html(getCKEditor().getData());
                        $('#hdnReplacedDiv').val($('#divSitePages').html());
                        closechangepopup();
                    }
                    break;
                case 'H1':
                case 'H2':
                case 'H3':
                case 'H4':
                case 'H5':
                case 'H6':
                case 'P':
                case 'B':
                case 'DT':
                case 'DD':
                case "DIV":
                    //                    if ($("#txtSpanContent").val() != null && $("#txtSpanContent").val() != "") {
                    //                        $(g_obj).html($("#txtSpanContent").val());
                    if (getCKEditor().getData() != null && getCKEditor().getData() != "") {

                        $(g_obj).html(getCKEditor().getData());
                        $('#hdnReplacedDiv').val($('#divSitePages').html());
                        bindEventsAgain(obj);
                        closechangepopup();
                    }
                    break;
                case 'LI':
                    //                    if ($("#txtContent").val() != null && $("#txtContent").val() != "") {
                    //                        $(g_obj).html($("#txtContent").val());
                    if (getCKEditor().getData() != null && getCKEditor().getData() != "") {

                        $(g_obj).html(getCKEditor().getData());
                        $('#hdnReplacedDiv').val($('#divSitePages').html());
                        closechangepopup();
                    }
                    break;
                case 'A':
                    //                    if ($("#txtContent").val() != null && $("#txtContent").val() != "" && $("#txthref").val() != null && $("#txthref").val() != "") {
                    //                        $(g_obj).html($("#txtContent").val());
                    if (getCKEditor().getData() != null && getCKEditor().getData() != "" && $("#txthref").val() != null && $("#txthref").val() != "") {

                        $(g_obj).html(getCKEditor().getData());
                        $(g_obj).attr("href", $("#txthref").val());
                        $('#hdnReplacedDiv').val($('#divSitePages').html());
                        closechangepopup();
                    }
                    break;
                case 'A>IMG':
                    {
                        if (getCKEditor().getData() != null && getCKEditor().getData() != "" && $("#txthref").val() != null && $("#txthref").val() != "") {

                            $(g_obj).html(getCKEditor().getData());
                            $(g_obj).attr("href", $("#txthref").val());
                            $('#hdnReplacedDiv').val($('#divSitePages').html());
                            bindEventsAgain(obj);
                            closechangepopup();
                        }
                    }
                    break;
                case 'IFRAME':
                    if ($("#txtYoutubeURL").val() != null && $("#txtYoutubeURL").val() != "") {
                        //the take the youtube URL, check if it contains embed, if not format the URL
                        var video_id = $("#txtYoutubeURL").val().split('v=')[1];
                        var ampersandPosition = video_id.indexOf('&');
                        if (ampersandPosition != -1) {
                            video_id = video_id.substring(0, ampersandPosition);
                        }

                        $('iframe').attr("src", ""); //clear existing values before replacing with new URL
                        var final_URL = "http://www.youtube.com/embed/" + video_id + "?wmode=opaque";
                        $('iframe').attr("src", "http://www.youtube.com/embed/" + video_id + "?wmode=opaque");

                        $('#hdnReplacedDiv').val($('#divSitePages').html());
                        closechangepopup();
                    }
                    break;
            }
        })
}
function tagRedirection(obj, tag) {
    switch (tag) {
        case 'LI':
            $("#btnImageSubmit").hide();
            $("#btnSubmit").show();
            $("#trUpload").hide();
            //$("#trContent").hide();
            $("#trCKEditor").show();
            $("#trLink").show();
            //FTB_API['txtContent'].SetHtml($(obj).html())
            getCKEditor().setData($(obj).html());
            $("#PassChangeForm").css("visibility", "visible");
            $("#trBackgroundSetting").hide();
            $("#btnBackgroundSubmit").hide();
            $("#trYoutubeStuff").hide();
            $("#trInformational").hide();
            $("#trBackgroundColorSp").hide();
            $("#trBackgroundColorMain").hide();
            break;

        case 'A':
            $("#btnImageSubmit").hide();
            $("#btnSubmit").show();
            $("#trUpload").hide();
            //$("#trContent").hide();
            $("#trCKEditor").show();
            $("#btnDelete").hide();
            $("#trLink").show();
            $("#trLink").show();
            $("#trHref").show();
            //FTB_API['txtContent'].SetHtml($(obj).html())
            getCKEditor().setData($(obj).html());
            $("#txthref").val($(obj).attr("href"));
            $("#PassChangeForm").css("visibility", "visible");
            $("#trBackgroundSetting").hide();
            $("#btnBackgroundSubmit").hide();
            $("#trYoutubeStuff").hide();
            $("#trInformational").hide();
            $("#trBackgroundColorSp").hide();
            $("#trBackgroundColorMain").hide();
            break;
        case 'A>IMG': //For changing the Facebook link
            $("#btnImageSubmit").hide();
            $("#btnSubmit").show();
            $("#trUpload").hide();
            //$("#trContent").hide();
            $("#trCKEditor").hide();
            $("#btnDelete").hide();
            $("#trLink").show();
            $("#trLink").show();
            $("#trHref").show();
            //FTB_API['txtContent'].SetHtml($(obj).html())
            getCKEditor().setData($(obj).html());
            $("#txthref").val($(obj).attr("href"));
            $("#PassChangeForm").css("visibility", "visible");
            $("#trBackgroundSetting").hide();
            $("#btnBackgroundSubmit").hide();
            $("#trYoutubeStuff").hide();
            $("#trInformational").hide();
            $("#trBackgroundColorSp").hide();
            $("#trBackgroundColorMain").hide();
            break;
        case 'H1':
        case 'H2':
        case 'H3':
        case 'H4':
        case 'H5':
        case 'H6':
        case 'P':
        case 'B':
        case 'DT':
        case 'DD':
        case 'DIV':
            $("#btnImageSubmit").hide();
            $("#btnSubmit").show();
            $("#trUpload").hide();
            $("#trLink").hide();
            $("#trHref").hide();
            $("#btnDelete").hide();
            //$("#trContent").show();
            $("#trCKEditor").show();
            //FTB_API['txtSpanContent'].SetHtml($(obj).html())
            getCKEditor().setData($(obj).html());
            $("#PassChangeForm").css("visibility", "visible");
            $("#trBackgroundSetting").hide();
            $("#btnBackgroundSubmit").hide();
            $("#trYoutubeStuff").hide();
            $("#trInformational").hide();
            $("#trBackgroundColorSp").hide();
            $("#trBackgroundColorMain").hide();
            break;

        case 'DIVcolorblock':
            //            $("#btnImageSubmit").hide();
            //            $("#btnSubmit").hide();
            //            $("#trUpload").hide();
            //            $("#trLink").hide();
            //            $("#trHref").hide();
            //            //$("#trContent").show();
            //            $("#trCKEditor").hide();
            //            $("#PassChangeForm").css("visibility", "visible");
            //            $("#trBackgroundSetting").show();
            //            //show the new controls
            //            break;
        case 'BODYcolor':
            $("#btnImageSubmit").hide();
            $("#btnSubmit").hide();
            $("#trUpload").hide();
            $("#trLink").hide();
            $("#trHref").hide();
            //$("#trContent").show();
            $("#trCKEditor").hide();
            $("#PassChangeForm").css("visibility", "visible");
            $("#trBackgroundSetting").hide();
            $("#btnBackgroundSubmit").show();
            $("#trYoutubeStuff").hide();
            $("#trInformational").hide();
            $("#btnDelete").hide();
            $("#trBackgroundColorSp").show();
            $("#trBackgroundColorMain").show();
            $("#passchangeInnerTable").css('height', '100px');
            //show the new control           
            break;
        case 'SPAN':
            $("#btnImageSubmit").hide();
            $("#btnSubmit").show();
            $("#trUpload").hide();
            $("#trLink").hide();
            $("#trHref").hide();
            $("#btnDelete").hide();
            //$("#trContent").show();
            $("#trCKEditor").show();
            //FTB_API['txtSpanContent'].SetHtml($(obj).html())
            getCKEditor().setData($(obj).html());
            $("#PassChangeForm").css("visibility", "visible");
            $("#trBackgroundSetting").hide();
            $("#btnBackgroundSubmit").hide();
            $("#trYoutubeStuff").hide();
            $("#trInformational").hide();
            $("#trBackgroundColorSp").hide();
            $("#trBackgroundColorMain").hide();
            break;
        case 'IMG':
            if (endsWith(g_obj.src, 'Images/')) {
                $("#PassChangeForm").show();
                $("#btnImageSubmit").hide(); //
                $("#btnSubmit").hide();
                $("#trUpload").hide();
                //$("#trContent").hide();
                $("#trCKEditor").hide();
                $("#trLink").hide();
                $("#trHref").hide();
                $("#PassChangeForm").css("visibility", "visible");
                $("#trBackgroundSetting").hide();
                $("#btnBackgroundSubmit").hide();
                $("#trYoutubeStuff").hide();
                $("#trInformational").show();
                $("#btnDelete").hide();
            }
            else {
                $("#btnImageSubmit").show(); //
                $("#btnSubmit").hide();
                $("#trUpload").show();
                //$("#trContent").hide();
                $("#trCKEditor").hide();
                $("#trLink").hide();
                $("#trHref").hide();
                $("#PassChangeForm").css("visibility", "visible");
                $("#trBackgroundSetting").hide();
                $("#btnBackgroundSubmit").hide();
                $("#trYoutubeStuff").hide();
                $("#trInformational").hide();
                $("#btnDelete").show();
            }
        case 'BackImg':
            if (endsWith(g_obj.src, 'Images/')) {
                $("#PassChangeForm").show();
                $("#btnImageSubmit").hide(); //
                $("#btnSubmit").hide();
                $("#trUpload").hide();
                //$("#trContent").hide();
                $("#trCKEditor").hide();
                $("#trLink").hide();
                $("#trHref").hide();
                $("#PassChangeForm").css("visibility", "visible");
                $("#trBackgroundSetting").hide();
                $("#btnBackgroundSubmit").hide();
                $("#trYoutubeStuff").hide();
                $("#trInformational").show();
                $("#btnDelete").hide();
                $("#trBackgroundColorSp").hide();
                $("#trBackgroundColorMain").hide();
            }
            else {
                $("#btnImageSubmit").show(); //
                $("#btnSubmit").hide();
                $("#trUpload").show();
                //$("#trContent").hide();
                $("#trCKEditor").hide();
                $("#trLink").hide();
                $("#trHref").hide();
                $("#PassChangeForm").css("visibility", "visible");
                $("#trBackgroundSetting").hide();
                $("#btnBackgroundSubmit").hide();
                $("#trYoutubeStuff").hide();
                $("#trInformational").hide();
                $("#btnDelete").show();
                $("#trBackgroundColorSp").hide();
                $("#trBackgroundColorMain").hide();
            }
            break;
        case 'IFRAME':
            $("#btnImageSubmit").hide(); //
            $("#btnSubmit").show();
            $("#trUpload").hide();
            //$("#trContent").hide();
            $("#trCKEditor").hide();
            $("#trLink").hide();
            $("#trHref").hide();
            $("#PassChangeForm").css("visibility", "visible");
            $("#trBackgroundSetting").hide();
            $("#btnBackgroundSubmit").hide();
            $("#trYoutubeStuff").show();
            $("#trInformational").hide();
            $("#trBackgroundColorSp").hide();
            $("#trBackgroundColorMain").hide();
            $("#btnDelete").show();
            break;
        case 'dynamic':
            alert('Facebook Widgets cannot be modified !');
            break;
        case 'ActionImg':
            alert('This element cannot be modified !');
    }
}

function closechangepopup() {
    $("#PassChangeForm").css("visibility", "hidden");

}

function bindEventsAgain(obj) {
    $(obj).find("a").click(
        function (event) {
            g_obj = this;
            tag = $(this).get(0).nodeName;
            tagRedirection(this, tag);
            return false;
        })
    $(obj).find("li").click(
        function (event) {
            g_obj = this;
            tag = $(this).get(0).nodeName;
            tagRedirection(this, tag);
            return false;
        })
    $(obj).find("img").click(
        function (event) {
            var classname = this.className;
            if (classname == "dynamic") {  //If You want to restrict a Image not to change  //Currently it is no more using
                tagRedirection(this, 'dynamic');
                return false;
            }
             if (classname == 'ActionImg') {
                tagRedirection(this, 'ActionImg');
                return false;
            }
            if (this.parentNode.nodeName.toLowerCase() == "a") {//If a Image is inside an anchor tag
                if (event.ctrlKey) {  //Give option to change the link
                    //document.getElementById('facebookid').parentNode.nodeName.toLowerCase()
                    g_obj = this.parentNode;
                    tag = $(this).get(0).parentNode.nodeName + '>' + 'IMG'
                    tagRedirection(this.parentNode, tag);
                    return false;
                }
            }
            g_obj = this;
            tag = $(this).get(0).nodeName;
            tagRedirection(this, tag);
            return false;
        })
    $(obj).find(".img").click(
            function (event) {
                g_obj = this;
                tag = "BackImg";
                tagRedirection(this, tag);
                return false;
            })
    $(obj).find("span").click(
        function (event) {
            g_obj = this;
            tag = $(this).get(0).nodeName;
            tagRedirection(this, tag);
            return false;
        })
    $(obj).find("p").click(
        function (event) {
            g_obj = this;
            tag = $(this).get(0).nodeName;
            tagRedirection(this, tag);
            return false;
        })
    $(obj).find("h1").click(
        function (event) {
            g_obj = this;
            tag = $(this).get(0).nodeName;
            tagRedirection(this, tag);
            return false;
        })
    $(obj).find("h2").click(
        function (event) {
            g_obj = this;
            tag = $(this).get(0).nodeName;
            tagRedirection(this, tag);
            return false;
        })
    $(obj).find("h3").click(
        function (event) {
            g_obj = this;
            tag = $(this).get(0).nodeName;
            tagRedirection(this, tag);
            return false;
        })
    $(obj).find("h4").click(
        function (event) {
            g_obj = this;
            tag = $(this).get(0).nodeName;
            tagRedirection(this, tag);
            return false;
        })
    $(obj).find("h5").click(
        function (event) {
            g_obj = this;
            tag = $(this).get(0).nodeName;
            tagRedirection(this, tag);
            return false;
        })
    $(obj).find("h6").click(
        function (event) {
            g_obj = this;
            tag = $(this).get(0).nodeName;
            tagRedirection(this, tag);
            return false;
        })
    $(obj).find("b").click(
        function (event) {
            g_obj = this;
            tag = $(this).get(0).nodeName;
            tagRedirection(this, tag);
            return false;
        })
    $(obj).find("dt").click(
        function (event) {
            g_obj = this;
            tag = $(this).get(0).nodeName;
            tagRedirection(this, tag);
            return false;
        })
    $(obj).find("dd").click(
        function (event) {
            g_obj = this;
            tag = $(this).get(0).nodeName;
            tagRedirection(this, tag);
            return false;
        })
    $(obj).find("object").click(
        function (event) {
            var classname = this.className;
            if (classname == "BLOGGER-youtube-video") {  //If You want to restrict a Image not to change  //Currently it is no more using
                tagRedirection(this, 'OBJECT');
                return false;
            }
            g_obj = this;
            tag = $(this).get(0).nodeName;
            tagRedirection(this, tag);
            return false;
        })

}