<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ProductSuite.aspx.cs" Inherits="DigiMa.ProductSuite"
    MasterPageFile="~/MasterPage.master" %>

<asp:Content runat="server" ContentPlaceHolderID="head" ID="cphHead">
    <%--<link href="Styles/master_style.css" rel="stylesheet" type="text/css" />--%>
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.7.1/jquery.min.js"></script>
    <%--<script src="ScriptsSonetReach/jquery-1.7.1.full.js" type="text/javascript"></script>--%>
    <script type="text/javascript" src="ScriptsSonetReach/login.js"></script>
    <link rel="stylesheet" type="text/css" href="Styles/master_style.css" />
    <link rel="stylesheet" type="text/css" href="Styles/style.css" />
    <link href="Styles/style1.css" rel="stylesheet" type="text/css" />
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
            border: 1px solid #7C7C77;
            border-radius: 13px 13px 13px 13px;
            margin-left: 8px;
            margin-top: 30px;
        }
        .divContentPP
        {
            color: White;
            padding: 20px 20px 20px 20px;
        }
        .divFooter
        {
            color: #939393;
            font-size: 11px;
            margin: 50px auto 15px;
            text-align: center;
        }
        .divInfo
        {
            background-position: center top;
            font-family: "Lucida Grande" , "Lucida Sans Unicode" , "Helvetica";
            font-size: 14px;
            font-weight: bold;
            padding-left: 25px;
        }
        .lblHeader
        {
            color: #F6BF4B;
            font-size: 25px;
            padding-left: 320px;
            text-align: center;
            text-decoration: underline;
        }
        .boldIT
        {
            font-weight: bold;
            font-size: 18px;
            color: #f7c458;
        }
        .boldITSmall
        {
            font-weight: bold;
            font-size: 16px;
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
        #Campaigns
        {
            height: 380px;
            width: 450px;
            border: 2px solid #5fcdf6;
            border-radius: 8px;
        }
        #learnAnalytics
        {
            background-image: url('Images/learnmore.png');
            width: 149px;
            height: 33px;
            display: block;
            border: 0 none;
            background-color: transparent;
            cursor: pointer;
        }
        #learnCampaign
        {
            background-color: transparent;
            background-image: url("Images/learnmore.png");
            border: 0 none;
            display: block;
            height: 33px;
            width: 149px;
            cursor: pointer;
        }
        #mainContent
        {
            font-family: "Lucida Grande" , "Lucida Sans Unicode" , "Helvetica";
            width: 950px;
            margin: 0 auto;
            margin-top: -16px;
            background-image: url('Images/subpage_bannerbg.png');
            background-repeat: repeat-x, repeat-y;
            color: White;
            height: auto;
        }
        .PSTables
        {
            font-family: "Lucida Grande" , "Lucida Sans Unicode" , "Helvetica";
            font-size: 14px;
            color: Silver;
        }
        #tblchildContent
        {
            color: White;
        }
        .masterbody
        {
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
            margin-top: 8px;
            position: relative;
            width: 710px;
        }
        
        
        .logo
        {
            display: block;
            float: left;
            margin-bottom: 1px;
            margin-left: 101px;
            margin-top: 2px;
            width: 250px;
        }
        .table
        {
            margin-top: 10px;
        }
        .leftdivinsidePages
        {
            float: left;
            margin-top: -20px;
            position: absolute;
            width: 720px;
        }
    </style>
    <script type="text/javascript">
        $(document).ready(function () {
            $("#slides").slides({
                preload: true,
                preloadImage: '/images/loading.gif',
                play: 5000,
                pause: 500,
                hoverPause: true
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
</asp:Content>
<asp:Content runat="server" ContentPlaceHolderID="body" ID="body">
    <table width="100%">
        <tr>
            <td>
                <span style="font-size: font-size: 14px; font-weight: bold; color: #8f1313">The rich
                    features of SoNetReach give any social media strategy a thrust that ensures our
                    clients can get the best value from this platform. SM Netserv also has the experience
                    of creating customized social media solutions to meet the unique business needs
                    of different clients and leveraging social networks for their business purposes</span>
            </td>
        </tr>
        <tr align="left">
            <td colspan="3" align="left">
                <br />
                <br />
            </td>
        </tr>
        <tr align="left">
            <%--<td colspan="1">
                            <asp:Image ID="tollsnglobe" runat="server" ImageUrl="~/Images/toolsnglobe.png" />
                        </td>    --%>
            <td colspan="2">
                <br />
                <span style="font-size: large; font-weight: bold; color: #8f1313">Campaign Builder</span>
                <br />
                <br />
                <span style="font-size: 14px; color: #8f1313">SoNetReach platform helps you to create
                    rich and interactive Campaigns in minutes to different Social Channels without aid
                    of experts or professionals. Automated workflows and process. Publish, Manage, Measure
                    and Engage - All through single SoNetReach Window</span>
            </td>
        </tr>
        <tr align="right">
            <td colspan="3">
                <br />
                <%--<asp:Button ID="learnCampaign" runat="server" OnClick="learnCampaign_Click" />--%>
            </td>
        </tr>
        <tr align="left">
            <td colspan="3" align="left">
                <br />
                <br />
            </td>
        </tr>
        <tr align="left">
            <%--<td colspan="1">
                            <asp:Image ID="Image1" runat="server" ImageUrl="~/Images/3barsanalytics.png" />
                        </td>--%>
            <td colspan="2">
                <br />
                <span style="font-size: large; font-weight: bold; color: #8f1313">Analytics</span>
                <br />
                <br />
                <span style="font-size: 14px; color: #8f1313">Reporting and measurement through online
                    analytics and dashboards. Measure your Campaign Success. Identify key performance
                    Indicators required for your Market Research.</span>
            </td>
        </tr>
        <tr align="right">
            <td colspan="3">
                <br />
                <%--<asp:Button ID="learnAnalytics" runat="server" OnClick="learnAnalytics_Click" />--%>
            </td>
        </tr>
    </table>
    </table>
</asp:Content>
