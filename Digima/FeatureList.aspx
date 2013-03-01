<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FeatureList.aspx.cs" Inherits="DigiMa.FeatureList" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Feature List</title>
    <script type="text/javascript" src="ScriptsSonetReach/jquery-1.7.1.min.js"></script>
    <link rel="shortcut icon" href="Images/sonetreachicon.ico" />
    <link href="Styles/master_style.css" rel="stylesheet" type="text/css" />
    <style>
        .divOuter
        {
            border: 1px solid #7C7C77;
            border-radius: 13px 13px 13px 13px;
            margin-left: 8px;
            margin-right: 40px;
            margin-top: 30px;
        }
        .divContentPP
        {
            color: White;
            padding-left: 102px;
        }
        .divFooter
        {
            color: #939393;
            font-size: 11px;
            margin: 50px auto 15px;
            text-align: center;
            padding-bottom: 25px;
        }
    </style>
    <style>
        .clsHeader
        {
            /*font-family: CenturyGothicRegular, "Century Gothic" ,Arial,Helvetica,sans-serif;*/
            font-family: Verdana;
            font-size: 14px;
            font-style: normal;
            font-weight: bold;
        }
        .divMatter
        {
            padding-top: 5px;
            padding-bottom: 45px;
            font-family: Verdana;
            font-size: 13px; /*font-family: CenturyGothicRegular, "Century Gothic" ,Arial,Helvetica,sans-serif;*/
        }
        .lblHeader
        {
            color: #F6BF4B;
            font-size: 25px;
            padding-left: 430px;
            text-align: center;
            text-decoration: underline;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div class="masterbody">
        <div class="masterwrapper">
            <div class="sonetlogo">
                <img src="images/logo.png" border="0" alt="SonetReach" /></div>
        </div>
        <div class="clr">
            <div style="padding-top: 10px;">
                <img src="Images/greytop_border.png" height="4" width="100%" alt="" /></div>
        </div>
        <div class="backwrapper" style="display: block;">
            <a href="Home.aspx?sp=1" class="backlink">Back</a>
        </div>
    </div>
    <div class="masterbody">
        <div class="masterwrapper">
            <br />
            <asp:Label ID="Label1" runat="server" Text="Feature List" CssClass="lblHeader"> </asp:Label>
            <div class="divOuter">
                <div class="divContentPP">
                    <div id="container">
                        <img src="Images/1.png" />
                        <div class="clsHeader" style="margin-bottom: 50px; margin-top: -65px; padding-left: 100px;">
                            &nbsp &nbsp
                            <label style="text-decoration: underline">
                                Marketing Promotions</label>
                        </div>
                        <div class="divMatter">
                            All that you had thought of managing your Marketing programs in Social Media is
                            now at your finger tips.<br />
                            <br />
                            - Build user engagement using Promotions/Campaigns/Sweepstakes/Contest/Deals and
                            many more<br />
                            - Showcase your latest Ads with Video Shares<br />
                            - Incentivize users using Sweepstakes, Deals and Group Deals etc<br />
                            - Run a Contest
                        </div>
                        <img src="Images/2.png" />
                        <div class="clsHeader" style="margin-bottom: 50px; margin-top: -65px; padding-left: 100px;">
                            &nbsp &nbsp
                            <label style="text-decoration: underline">
                                Matter of Time</label>
                        </div>
                        <div class="divMatter">
                            - Get your Marketing Activities up and running in Minutes<br />
                            - You need not be a tech savvy person to build your Promotions
                        </div>
                        <div class="clsHeader" style="margin-bottom: -68px; margin-top: 42px; padding-left: 110px;">
                            &nbsp &nbsp
                            <label style="text-decoration: underline">
                                SEO Friendly</label>
                        </div>
                        <img src="Images/3.png" />
                        <div class="divMatter">
                            We understand your needs<br />
                            <br />
                            - SoNetReach is a SEO friendly tool<br />
                            - Drive users to your Website and Facebook Pages
                        </div>
                        <img src="Images/Graph-icon.png" height="100" width="100" />
                        <div class="clsHeader" style="margin-bottom: 50px; margin-top: -65px; padding-left: 100px;">
                            &nbsp &nbsp
                            <label style="text-decoration: underline">
                                Key Insights</label>
                        </div>
                        <div class="divMatter">
                            Rate your Marketing Promotions Success<br />
                            <br />
                            - Use SoNetReach’s meaningful insights to manage your Market Research<br />
                            - Get to know about your audience<br />
                            - How are users connecting with your Brand/Products<br />
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <div>
            <img src="Images/spacer.png" height="5" width="100%" alt="" /></div>
    </div>
    <div class="divFooter">
        Copyright <a href="http://www.smnetserv.com/" target="_blank" class="url" style="text-decoration: underline;">
            SM NetServ Technologies Pvt Ltd</a> 2012 - Offshore Software Development Company,
        India</div>
    </form>
</body>
</html>
