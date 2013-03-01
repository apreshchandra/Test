<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Contact.aspx.cs" Inherits="DigiMa.Contact"
    MasterPageFile="~/MasterPage.master" %>

<asp:Content runat="server" ContentPlaceHolderID="head" ID="cphHead">
    <script src="http://ajax.googleapis.com/ajax/libs/jquery/1.7.1/jquery.min.js"></script>
    <%--<script src="ScriptsSonetReach/jquery-1.7.1.full.js" type="text/javascript"></script>--%>
    <script type="text/javascript" src="ScriptsSonetReach/login.js"></script>
    <link rel="stylesheet" type="text/css" href="Styles/master_style.css" />
    <link href="Styles/style1.css" rel="stylesheet" type="text/css" />
    <script src="ScriptsSonetReach/jquery.betterTooltip.js" type="text/javascript"></script>
    <script src="ScriptsSonetReach/Menuhover.js" type="text/javascript"></script>
    <link rel="shortcut icon" href="Images/sonetreachicon.ico" />
    <link href="Styles/format.css" rel="stylesheet" type="text/css" />
    <link href="Styles/style_new_menu.css" rel="stylesheet" type="text/css" />
    <link href="Styles/menu_style.css" rel="stylesheet" type="text/css" />
    <script src="ScriptsSonetReach/slides.min.jquery.js" type="text/javascript"></script>
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
    <script type="text/javascript">
        $(document).ready(function () {
            $("#slides").slides({
                preload: true,
                preloadImage: '/images/loading.gif',
                play: 5000,
                pause: 500,
                hoverPause: true
            });

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
    <script type="text/javascript">
        $(document).ready(function () {
            $("#logohide").hide();
        });
    </script>
    <style type="text/css">
        #QRBottom
        {
            margin-top: 220px;
            margin-left: 183px;
        }
        .QRFTBottom
        {
            background-image: url("images/try-button.png");
            background-repeat: no-repeat;
            background-position: 6px 9px;
            height: 42px;
            width: 152px;
            display: inline-block;
            float: left;
            text-indent: -9999px;
            cursor: pointer;
        }
        .divOuter
        {
            border-radius: 8px;
            margin-left: 8px;
            margin-top: 30px;
            width: 450px;
            margin-left: 290px;
        }
        .divContentPP
        {
            color: Silver;
            padding: 20px 20px 20px 20px;
        }
        .divFooter
        {
            color: #939393;
            font-size: 11px;
            margin: 50px auto 15px;
            text-align: center;
        }
        
        .smnet
        {
            text-decoration: underline;
            color: #151515;
            padding-bottom: 0px;
        }
        .smnet:hover
        {
            text-decoration: none;
            color: #151515;
        }
        
        .line
        {
            background-image: url('../images/line.jpg');
            background-image: repeat-x;
            height: 1px;
            margin: 10px 30px 10px 0px;
        }
        
        .slider-wrapper
        {
            width: 80%;
            margin: 20px auto;
        }
        
        .theme-default #slider
        {
            margin: 100px auto 0 auto;
        }
        .theme-pascal.slider-wrapper, .theme-orman.slider-wrapper
        {
            margin-top: 150px;
        }
    </style>
    <style>
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
            margin-left: 245px;
            margin-top: 2px;
            position: relative;
            width: 710px;
        }


        .logo
        {
             display: block;
    float: left;
    margin-bottom: 2px;
    margin-left: 116px;
    margin-top: -17px;
    width: 250px;
        }
        .clsHeader
        {
            /*font-family: CenturyGothicRegular, "Century Gothic" , Arial, Helvetica, sans-serif;*/
            font-family: "Lucida Grande" , "Lucida Sans Unicode" , "Helvetica";
            font-size: 14px;
            font-weight: 500;
        }
        .divHeading
        {
            /*font-family: CenturyGothicRegular, "Century Gothic" , Arial, Helvetica, sans-serif;*/
            font-family: "Lucida Grande" , "Lucida Sans Unicode" , "Helvetica";
            font-size: large;
            font-weight: bolder;
            color: Silver;
            text-decoration: underline;
            color: #8F1313;
        }
        .lblHeader
        {
            color: Silver;
            font-size: 25px;
            padding-left: 438px;
            text-align: center;
            text-decoration: underline;
        }
        #mainContent
        {
            font-family: "Lucida Grande" , "Lucida Sans Unicode" , "Helvetica";
            width: 950px;
            margin: 0 auto;
            margin-top: -76px;
            background-image: url('Images/subpage_bannerbg.png');
            background-repeat: repeat-x, repeat-y;
            color: Silver;
            height: auto;
        }
        .QRFT
        {
            background-image: url("images/try-button.png");
            background-repeat: no-repeat;
            background-position: 6px 9px;
            height: 22px;
            width: 152px;
            display: inline-block;
            float: left;
            text-indent: -9999px;
            cursor: pointer;
        }
         .leftdivinsidePages
        {
           float: left;
    margin-top: 2px;
    position: absolute;
    width: 720px;
        }
    </style>
</asp:Content>
<asp:Content runat="server" ContentPlaceHolderID="body" ID="body">
    <table width="100%" style="color: #8F1313;margin-left:10px;">
        <tr>
            <td>
                <div class="divHeading">
                    India Office</div>
                <br />
                <p class="clsHeader">
                    SM NETSERV Technologies Pvt. Ltd.,<br />
                    #147 First Floor, Anjaneya Techno Park, Old Airport<br />
                    Road, Bangalore - 560 008,<br />
                    India
                    <br />
                    Phone : +91-80-40400800<br />
                    VoIP : 4045512713, 4045675284, 4045675283, 4045675252
                    <br />
                    Fax : +91-80-40400805<br />
                    e-Mail : <a href="mailto:sales@smnetserv.com" style="color: #8F1313;;">sales@smnetserv.com</a>
                    , <a href="mailto:support@smnetserv.com" style="color: #8F1313;;">support@smnetserv.com</a><br />
                    URL : <a href="http://www.smnetserv.com" target="_blank" style="color: #8F1313;;">www.smnetserv.com</a><br />
                </p>
                <br />
                <br />
                <div class="divHeading">
                    US Office</div>
                <br />
                <p class="clsHeader">
                    Netserv Applications Inc
                    <br />
                    11545 Park Woods Circle,Suite D
                    <br />
                    Alpharetta, GA , 30005<br />
                    Phone : +1 678-339-0366<br />
                    Fax : +1 678-339-0363<br />
                    Mobile: 770-713-5700
                    <br />
                    URL : <a href="http://www.netserv-appl.com" target="_blank" style="color: #8F1313;;">www.netserv-appl.com</a>
                </p>
            </td>
        </tr>
    </table>
</asp:Content>
