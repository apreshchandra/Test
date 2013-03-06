<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FAQ.aspx.cs" Inherits="DigiMa.FAQ" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>FAQ</title>
    <%--<link href="Styles/master_style1.css" rel="stylesheet" type="text/css" />--%>
    <script type="text/javascript" src="ScriptsSonetReach/jquery-1.4.1.min.js"></script>
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
    </style>
    <!--[if IE ]> <link rel="stylesheet" type="text/css" href="Styles/ie7.css">
<![endif]-->
    <!--[if IE ]> <script type="text/javascript" src="ScriptsSonetReach/MenuHoverIE.js"></script>
<![endif]-->
    <style>
        .divMatter
        {
            font-family: Verdana;
            font-size: 13px;
        }
        .lblHeader
        {
            color: #F6BF4B;
            font-size: 25px;
            padding-left: 465px;
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
            <asp:Label ID="Label1" runat="server" Text="FAQ's" CssClass="lblHeader"> </asp:Label>
            <div class="divOuter">
                <div class="divContentPP">
                    <div class="divMatter">
                        <p>
                            <span style="font-weight: bold">Q. Can I post to Twitter, LinkedIn and MySpace as well?
                            </span>
                            <br />
                            A. Currently SoNetReach supports Marketing Campaigns publishing to Facebook only.
                            <br />
                            <br />
                            <span style="font-weight: bold">Q. Can I use this license to run on my desktop and notebook?</span><br />
                            A. Yes. SoNetReach is built on SAAS [Software as a Service] Model. Hence you can
                            log-in from any locale.
                            <br />
                            <br />
                            <span style="font-weight: bold">Q. Do I get automatic upgrades of SoNetReach every time
                                a new version is released? </span>
                            <br />
                            A. Yes. Once you log-in there will be a notification of the new features and fixes
                            provided.
                            <br />
                            <br />
                            <span style="font-weight: bold">Q. I am using a trial version of SoNetReach. Now, I
                                am unable to create new campaigns. What should I do? </span>
                            <br />
                            A. You will be able to create any 3 Marketing Campaigns in your trial version. You
                            now need to Purchase the software license. Please contact <a href="mailto:sales@smnetserv.com"
                                style="color: White;">sales@smnetserv.com</a>
                            <br />
                            <br />
                            <span style="font-weight: bold">Q. Is my primary email information the only way I can
                                log in to SoNetReach?</span><br />
                            A. Yes.
                        </p>
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
