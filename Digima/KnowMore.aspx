<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="KnowMore.aspx.cs" Inherits="DigiMa.KnowMore" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="Styles/master_style.css" rel="stylesheet" type="text/css" />
    <link rel="stylesheet" type="text/css" href="Styles/stylesheet.css" />
    <link href="Styles/style_new_menu.css" rel="stylesheet" type="text/css" />
    <link href="Styles/menu_style.css" rel="stylesheet" type="text/css" />
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
            font-family: "Segoe UI" ,Arial,Helvetica,sans-serif;
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
        .boldITLeft
        {
            font-weight: bold;
            font-size: 16px;
        }
        
       
        
        
        .policy
        {
            font-size: 11px;
            margin-left: 280px;
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
        #mainContent
        {
            width: 900px;
            height: 100px;
            margin-left: 200px;
            font-family: "Segoe UI" ,Arial,Helvetica,sans-serif;
            margin-top:21px;
        }
        #HEAD
        {
           text-align:center;
        }
        #DIY
        {
            height: 230px;
            width: 450px;
            border: 2px solid #5fcdf6;
            border-radius: 8px;
            margin-top:10px;
          
        }
        #WHATSGOOD
        {
            height: 230px;
            width: 440px;
            margin-left:460px;
            border: 2px solid #5fcdf6;
            margin-top: -234px;
            border-radius: 8px;
         
        }
        #ANALYTICS
        {
            height: 150px;
            width: 900px;
            border: 2px solid #5fcdf6;  
            border-radius: 8px; 
            margin-top:10px;        
            
        }
        .PSTables
        {
            font-family: "Lucida Grande","Lucida Sans Unicode","Helvetica";
            font-size: 14px;
            color: Silver;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div id="masterbody">
        <div class="masterwrapper">
            <div class="sonetlogo">
                <a id="A1" href="#" runat="server">
                    <img src="images/logo.png" border="0" alt="SonetReach" /></a></div>
                    <div class="loginarea">
                        <div>
                            <img src="images/spacer.png" height="10" /></div>
                        <a href="https://www.facebook.com/pages/SoNetReach/484323984929972/" class="connect"
                            target="_blank">
                            <h2 class="fb">
                                Stay Connected</h2>
                        </a>
                        <div id="login">
                            <ul>
                                <li><a href="Register.aspx">Signup</a></li>
                                <li>| </li>
                                <li><a href="#" id="loginButton">Login</a></li>
                            </ul>
                        </div>
                    </div>
        </div>
        <div class="clr">
        </div>
        
        <div>
            <div class="menubg">
                <div class="menu_bg">
                    <div id="ddtopmenubar" class="mattblackmenu">
                       <ul>
                    <li class="homenav"><a href="Home.aspx"></a></li>
                    <li><a href=""><span>
                                    <img src="images/nav_sep.png" border="0" /></a></span></li>
                    <li><a href="KnowMore.aspx">Know More</a></li>
                    <li><a href=""><span>
                        <img src="images/nav_sep.png" border="0" /></a></span></li>
                    <li><a href="ProductSuite.aspx">Product Suite</a></li>
                    <li><a href="#"><span>
                        <img src="images/nav_sep.png" border="0" /></a></span></li>
                    <li><a href="Pricing.aspx">Plans &amp; Pricing</a></li>
                    <li><a href="#"><span>
                        <img src="images/nav_sep.png" border="0" /></a></span></li>
                    <li><a href="Resources.aspx">Resources</a></li>
                    <li><a href="#"><span>
                        <img src="images/nav_sep.png" border="0" /></a></span></li>
                    <li><a href="AboutUs.aspx">About Us</a></li>
                    <li><a href="#"><span>
                        <img src="images/nav_sep.png" border="0" /></a></span></li>
                    <li><a href="Contact.aspx">Contact Us</a></li>
                </ul>
                    </div>
                </div>
            </div>
            <div id="mainContent">
                <div id="HEAD">
                <br />
                   <h3> <span style="font-size: 20px;color: Silver;font-family: "Segoe UI" ,Arial,Helvetica,sans-serif;">The rich features of SoNetReach give any social media strategy a thrust that ensures
                                            our clients can get the best value from this platform. SM Netserv also has the experience
                                            of creating customized social media solutions, to meet the unique business needs
                                            of different clients, and leveraging social networks for their business purposes</span></h3>
                                            <br />
                                            <br />
                </div>
                <div id="DIY">
                 <p style="color: #5fcdf6;font-weight: bold;  height: 40px; text-align: center;
                    font-size: 18px;font-family: "Segoe UI" ,Arial,Helvetica,sans-serif;">It's DIY !</p>
                    <table class="PSTables">
                     <tr><td><span style="font-size: 14px;color: Silver;font-family: "Lucida Grande","Lucida Sans Unicode","Helvetica";">SoNetReach is a Do It Yourself [DIY,] Social Marketing Platform that enables,
                                            planning and auto-launching of multiple campaigns. Powerful tracking and listening
                                            skills of SoNetReach, ensures targeted campaigns to chosen social profile. Full
                                            compliance with the privacy and confidentiality policies of any social network Automated
                                            workflows and process Publish, Manage, Measure and Engage - All through single SoNetReach
                                            Window</span></td></tr></table>
                </div>
                <div id="WHATSGOOD">
                <p style="color: #5fcdf6;font-weight: bold;  height: 40px; text-align: center;
                    font-size: 18px;font-family: "Segoe UI" ,Arial,Helvetica,sans-serif;">What's good here ?</p>
                    <table class="PSTables">
                    <tr><td align="left"><span>SoNetReach’s DIY suite helps you to easily build and publish your Campaigns in
                                            minutes to different Social Channels without aid of experts or professionals</span></td></tr>
                                            <tr><td align="left"><span>Controlled and targeted approach for connecting with desired network members Enhanced
                                            engagement with customers</span></td></tr>
                                            <tr><td align="left"><span>Loyalty, Referral Programs, Coupon Management and Sweepstakes Functionalities
                                            offers tremendous scope for increasing sales revenue.</span></td></tr>
                    </table>
                </div>
                <div id="ANALYTICS">
                 <p style="color: #5fcdf6;font-weight: bold;  height: 40px; text-align: center;
                    font-size: 18px;font-family: "Segoe UI" ,Arial,Helvetica,sans-serif;">Analytics</p>
                     <table class="PSTables">
                     <tr><td>
                    <span style="font-size: 14px;color: Silver;font-family:"Lucida Grande","Lucida Sans Unicode","Helvetica";">Improved reporting and measurement through online analytics and dashboards Automatic
                                            tracking of flow of information, across the network, provides you with valuable
                                            data points for analysis, review and informed decision making. Better management
                                            of market research Complete view of information flow path provides better assessment
                                            of the campaign participation and response .</span>
                                            </td></tr></table>
                </div>
            </div>
        </div>
        <div id="footerKM">
        <div class="sitelink1KM">
            <ul>
                <li><b>Site Links</b></li>
                <li><a href="KnowMore.aspx">Know More</a></li>
                <li><a href="ProductSuite.aspx">Product Suite</a></li>
                <li><a href="Pricing.aspx">Plans &amp; Pricing</a></li>
                <li><a href="Resources.aspx">Resources</a></li>
            </ul>
        </div>
        <div class="sitelink2KM">
            <ul>
                <li><b>Company</b></li>
                <li><a href="AboutUs.aspx">About Us</a></li>
                <li><a href="Contact.aspx">Contact Us</a></li>
            </ul>
        </div>
        
        <div class="clr">
        </div>
        <div class="line">
            &nbsp;</div>
        <div class="policy">
            <p>
                Terms of Service | Privacy Policy | © 2012 <a href="http://smnetserv.com/index.html"
                    target="_blank" class="smnet" />SM Netserv Technologies Pvt ltd.</a> All Rights
                Reserved.</p>
        </div>
    </div>
    </div>
    </form>
</body>
</html>
