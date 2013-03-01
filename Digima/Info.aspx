<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Info.aspx.cs" Inherits="DigiMa.Info" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Redirecting...</title>
    <link rel="shortcut icon" href="Images/sonetreachicon.ico" />
    <link href="Styles/master_style.css" rel="stylesheet" type="text/css" />
    <style>
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
            font-family: Verdana;
            font-size: 20px;
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
        <div class="masterbody">
            <div class="masterwrapper">
                <br />
                <asp:Label ID="Label1" runat="server" Text="What can Sonetreach do for you?" CssClass="lblHeader"> </asp:Label>
                <div class="divOuter">
                    <div class="divContentPP">
                        <div class="divInfo">
                            • Seed your Marketing Campaigns with Promotions, Video Shares,
                            <br />
                            &nbsp;&nbsp;&nbsp;Sweepstakes, Contests and many more
                            <br />
                            <br />
                            • DIY friendly software for Creating Marketing Campaigns in minutes
                            <br />
                            <br />
                            • Automated Workflows & Processes
                            <br />
                            <br />
                            • Enables Loyalty Programs and Results tracking
                            <br />
                            <br />
                            • Controlled & Targeted access to network members
                            <br />
                            <br />
                            • Get complete Insights of your Marketing Campaigns
                            <br />
                            <br />
                            • Manage your Marketing Research with these Insights
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
