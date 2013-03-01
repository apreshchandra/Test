<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SonetReachAnalyticsMain.aspx.cs"
    Inherits="DigiMa.Analytics.SonetReachAnalyticsMain" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajax" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <%--<link href="~/Styles/Site.css" rel="stylesheet" type="text/css" />--%>
    <link href="../Styles/style.css" rel="stylesheet" type="text/css" />
    <link href="../Styles/menu_style.css" rel="stylesheet" type="text/css" />
    <script src="../ScriptsSonetReach/jquery-1.5.1.js" type="text/javascript"></script>
    <style>
        .backButton
        {
            background-image: url('../Images/FW_back.png');
            background-repeat: no-repeat;
            border: 0 none;
            border-radius: 13px 13px 13px 13px;
            color: White;
            cursor: pointer;
            display: block;
            height: 25px;
            line-height: 25px;
            margin-bottom: 0;
            margin-left: 0;
            margin-right: 0;
            margin-top: 10px;
            padding-top: 10px;
            text-align: center;
            text-decoration: none;
            vertical-align: middle;
            width: 88px;
        }
        .mattblackmenu
        {
            left: 76px;
            position: absolute;
        }
        .menusubinsidepages
        {
            background: url("../Images/submenubg.png") no-repeat scroll 0 0 transparent;
            float: left;
            height: 50px;
            margin-left: 180px;
            margin-top: -13px;
            position: relative;
            width: 710px;
        }
        body
        {
            font-family: "" Lucida Grande "," Lucida Sans Unicode ",Helvetica,Arial,Verdana,sans-serif";
            font-size: 12px;
            line-height: 20px;
            font-weight: normal;
            color: #333333;
            background-color: #1b1b1b;
            text-align: left;
            padding: 0px;
            margin: 0px;
        }
        #divGoogleAnalytics
        {
            background: none repeat scroll 0 0 #e5e5e5;
            color: Blue;
            width: 999px;
        }
        
        #divGoogleAnalytics
        {
            color: #8f1313;
            font-size: 12px;
        }
        
        #TabCtr1
        {
            font-family: "Lucida Grande" , "Lucida Sans Unicode" , "Helvetica" , "Arial,Verdana" , "sans-serif";
            margin-left: 185px;
        }
        #TabCtr1_Tab6_tblGoogleAnalytics
        {
            margin-left: 335px;
            width: 300px;
            margin-top: 15px;
        }
        
        .ajax__tab_default .ajax__tab_tab
        {
            color: #000000;
            font-size: 11px;
            line-height: 17px;
            text-align: center;
        }
        
        #divGoogleAnalytics
        {
            background: none repeat scroll 0 0 #fff;
        }
        .logo
        {
            float: left;
            margin-bottom: 20px;
            margin-left: 164px;
            margin-top: -24px;
            width: 250px;
        }
    </style>
    <script type="text/javascript">

        var _gaq = _gaq || [];
        _gaq.push(['_setAccount', 'UA-33450544-1']);
        _gaq.push(['_trackPageview']);

        (function () {
            var ga = document.createElement('script'); ga.type = 'text/javascript'; ga.async = true;
            ga.src = ('https:' == document.location.protocol ? 'https://ssl' : 'http://www') + '.google-analytics.com/ga.js';
            var s = document.getElementsByTagName('script')[0]; s.parentNode.insertBefore(ga, s);
        })();


        $(document).ready(function () {
            $("#TabCtr1_Tab6_tblGoogleAnalytics").hide();
        });
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <ajax:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
    </ajax:ToolkitScriptManager>
    <div>
        <div style="margin-left: 1080px; height: 4px;">
            <asp:Button ID="btnBack" runat="server" class="backButton" OnClick="btnBack_Click" /></div>
        <div style="margin-left: -300px; margin-top: -5px;">
            <ajax:TabContainer ID="TabCtr1" ActiveTabIndex="0" runat="server" Width="1010px"
                BorderColor="White" Font-Bold="True" BorderWidth="0px" Style="margin-left: 464px;
                margin-top: 79px; overflow-x: scroll;" Font-Overline="False" Font-Size="10pt"
                ForeColor="Black">
                <ajax:TabPanel ID="Tab1" HeaderText="Summary" runat="server" Font-Bold="false" Font-Size="Medium"
                    ForeColor="Red" BorderColor="White" BorderWidth="0px">
                    <ContentTemplate>
                        <table cellpadding="0" align="center" border="0px;">
                            &nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;
                            <tr>
                                <td colspan="2">
                                    <table cellpadding="0" align="center" border="0px" width="70%">
                                        <tr>
                                            <td valign="top" style="width: 120px; height: 92px; text-align: center; padding-top: 0px;"
                                                colspan="1">
                                                <div style="border: 2px solid Coral; width: 184px; height: 50px; padding: 10px 5px 10px 10px;
                                                    border-color: #8f1313; background-color: #8f1313">
                                                    <asp:Label ID="lbl1" runat="server" Font-Names="Lucida Grande" ForeColor="White"
                                                        Font-Size="15px"></asp:Label>
                                                    <br />
                                                    <span style="color: White;">
                                                        <asp:Label ID="lbl2" runat="server" Font-Names="Lucida Grande" Font-Size="15px"></asp:Label>
                                                        &nbsp;</span> &nbsp;</div>
                                            </td>
                                            <td valign="top" style="width: 120px; height: 92px; text-align: center; padding-top: 0px;"
                                                colspan="1">
                                                <div style="border: 2px solid Coral; width: 184px; height: 50px; padding: 10px 5px 10px 10px;
                                                    border-color: #8f1313; background-color: #8f1313">
                                                    <asp:Label ID="lbl3" runat="server" Font-Names="Lucida Grande" ForeColor="White"
                                                        Font-Size="15px"></asp:Label>
                                                    <br />
                                                    <span style="color: White">
                                                        <asp:Label ID="lbl4" runat="server" Font-Names="Lucida Grande" Font-Size="15px"></asp:Label>
                                                        &nbsp;</span>
                                                </div>
                                            </td>
                                            <td valign="top" style="width: 120px; height: 92px; text-align: center; padding-top: 0px;"
                                                align="right" colspan="1">
                                                <div style="border: 2px solid Coral; width: 184px; height: 50px; padding: 10px 5px 10px 10px;
                                                    border-color: #8f1313; background-color: #8f1313">
                                                    <asp:Label ID="lbl5" runat="server" Font-Names="Lucida Grande" ForeColor="White"
                                                        Font-Size="15px"></asp:Label>
                                                    <br />
                                                    <span style="color: White">
                                                        <asp:Label ID="lbl6" runat="server" Font-Names="Lucida Grande" Font-Size="15px"></asp:Label>
                                                        &nbsp;</span>
                                                </div>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                                &nbsp;&nbsp;&nbsp;
                            </tr>
                            &nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;
                            <tr>
                                <td align="left" style="padding-left: 2px;" colspan="1">
                                    <asp:Chart ID="Chart5" runat="server" Height="325px" BorderlineDashStyle="Solid"
                                        BorderWidth="2px" BorderColor="#F6BF4B" Palette="None" ImageUrl="~/TempImages/ChartPic_#SEQ(300,3)"
                                        BorderlineColor="#8f1313" BorderlineWidth="2" PaletteCustomColors="#e6e6e6; MenuHighlight; Orange; red"
                                        Width="485px" BackImageTransparentColor="White" BackSecondaryColor="White">
                                        <Series>
                                            <asp:Series Name="Series1" ChartType="Funnel" IsValueShownAsLabel="True" XValueType="Double"
                                                CustomProperties="PyramidPointGap=2, FunnelMinPointHeight=1" BorderColor="180, 26, 59, 105"
                                                Color="220, 65, 140, 240" LabelFormat="F1" YValueType="Double" ChartArea="ChartArea1"
                                                Legend="NotifierType" YValuesPerPoint="6" Font="Lucida Grande">
                                            </asp:Series>
                                        </Series>
                                        <ChartAreas>
                                            <asp:ChartArea Name="ChartArea1" BorderColor="64, 64, 64, 64" BackSecondaryColor="White"
                                                BackColor="White" ShadowColor="Transparent" BackGradientStyle="TopBottom" AlignmentOrientation="Horizontal">
                                                <AxisY LineColor="64, 64, 64, 64" IsLabelAutoFit="False" ArrowStyle="Triangle">
                                                    <MajorGrid LineColor="64, 64, 64, 64"></MajorGrid>
                                                    <LabelStyle Font="Lucida Grande, 10px" TruncatedLabels="True"></LabelStyle>
                                                </AxisY>
                                                <AxisX LineColor="64, 64, 64, 64" IsLabelAutoFit="False" ArrowStyle="Triangle" Interval="1"
                                                    IntervalType="Number">
                                                    <MajorGrid LineColor="64, 64, 64, 64"></MajorGrid>
                                                    <LabelStyle Font="Lucida Grande, 10px" IsStaggered="True" Interval="1"></LabelStyle>
                                                </AxisX>
                                                <Area3DStyle Rotation="10" Inclination="15" IsRightAngleAxes="False" WallWidth="0"
                                                    Enable3D="True"></Area3DStyle>
                                            </asp:ChartArea>
                                        </ChartAreas>
                                        <Legends>
                                            <asp:Legend BackColor="Transparent" Font="Lucida Grande, 12px" IsTextAutoFit="False"
                                                Name="NotifierType">
                                            </asp:Legend>
                                        </Legends>
                                        <Titles>
                                            <asp:Title ShadowColor="32, 0, 0, 0" Font="Lucida Grande, 15px" ShadowOffset="3"
                                                Text="Actions Funnel" Name="Title1" ForeColor="#8f1313">
                                            </asp:Title>
                                        </Titles>
                                    </asp:Chart>
                                </td>
                                <td align="right" style="padding-left: 2px;" colspan="1">
                                    <asp:Chart ID="Chart7" runat="server" Width="485px" Height="325px" BorderlineDashStyle="Solid"
                                        BorderWidth="2px" BorderColor="#B54001" Palette="Excel" ImageUrl="~/TempImages/ChartPic_#SEQ(300,3)"
                                        BorderlineColor="#8f1313" BorderlineWidth="2" PaletteCustomColors="242, 160, 32; RoyalBlue; 0, 183, 74; 219, 80, 136"
                                        BackImageTransparentColor="Silver" BackSecondaryColor="White" Font="Lucida Grande, 10px, style=Regular">
                                        <Series>
                                            <asp:Series Name="Series1" IsValueShownAsLabel="True" ChartType="Doughnut" ChartArea="ChartArea1"
                                                Legend="Gender" Font="Lucida Grande, 10px">
                                            </asp:Series>
                                        </Series>
                                        <ChartAreas>
                                            <asp:ChartArea Name="ChartArea1" BorderColor="64, 64, 64, 64" BackSecondaryColor="White"
                                                BackColor="White" ShadowColor="Transparent" BackGradientStyle="TopBottom" AlignmentOrientation="Horizontal">
                                                <AxisY LineColor="64, 64, 64, 64" IsLabelAutoFit="False" ArrowStyle="Triangle">
                                                    <MajorGrid LineColor="64, 64, 64, 64"></MajorGrid>
                                                    <LabelStyle Font="Lucida Grande, 10px" Format="#"></LabelStyle>
                                                </AxisY>
                                                <AxisX LineColor="64, 64, 64, 64" IsLabelAutoFit="False" ArrowStyle="Triangle" Interval="1"
                                                    IntervalType="Number">
                                                    <MajorGrid LineColor="64, 64, 64, 64"></MajorGrid>
                                                    <LabelStyle Font="Lucida Grande, 10px" IsStaggered="True" Interval="1"></LabelStyle>
                                                </AxisX>
                                                <Area3DStyle Rotation="10" Perspective="10" Inclination="15" IsRightAngleAxes="False"
                                                    WallWidth="0"></Area3DStyle>
                                            </asp:ChartArea>
                                        </ChartAreas>
                                        <Legends>
                                            <asp:Legend BackColor="Transparent" Font="Lucida Grande, 12px" IsTextAutoFit="False"
                                                Name="Gender">
                                            </asp:Legend>
                                        </Legends>
                                        <Titles>
                                            <asp:Title ShadowColor="32, 0, 0, 0" Font="Lucida Grande, 15px" ShadowOffset="3"
                                                Text="Gender Wise" Name="Title1" ForeColor="#8f1313">
                                            </asp:Title>
                                        </Titles>
                                    </asp:Chart>
                                </td>
                                &nbsp;&nbsp;&nbsp;
                            </tr>
                            &nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;
                            <tr>
                                <td colspan="2" align="left" valign="top" style="padding-left: 2px;">
                                    <asp:Chart ID="Chart6" runat="server" Width="974px" Height="277px" BorderlineDashStyle="Solid"
                                        BorderWidth="2px" BorderColor="#B54001" Palette="None" ImageUrl="~/TempImages/ChartPic_#SEQ(300,3)"
                                        BorderlineColor="#8f1313" BorderlineWidth="2" PaletteCustomColors="0, 183, 74">
                                        <Series>
                                            <asp:Series Name="Series1" IsValueShownAsLabel="True" ChartType="Bubble" CustomProperties="LabelStyle=Bottom"
                                                BorderColor="180, 26, 59, 105" LabelFormat="#" ChartArea="ChartArea1" Legend="Legend1"
                                                YValuesPerPoint="2" Font="Lucida Grande, 12px">
                                            </asp:Series>
                                        </Series>
                                        <ChartAreas>
                                            <asp:ChartArea Name="ChartArea1" BorderColor="64, 64, 64, 64" BackSecondaryColor="White"
                                                BackColor="White" ShadowColor="Transparent" BackGradientStyle="TopBottom" AlignmentOrientation="Horizontal">
                                                <AxisY IsLabelAutoFit="False" ArrowStyle="Triangle" TitleFont="Lucida Grande, 14px"
                                                    InterlacedColor="Black" TitleForeColor="139, 10, 80">
                                                    <MajorGrid LineColor="64, 64, 64, 64" LineDashStyle="DashDot"></MajorGrid>
                                                    <LabelStyle Font="Lucida Grande, 11px" Format="#" ForeColor="0, 63, 135"></LabelStyle>
                                                </AxisY>
                                                <AxisX IsLabelAutoFit="False" ArrowStyle="Triangle" Interval="1" IntervalType="Number"
                                                    InterlacedColor="Black" TitleForeColor="139, 10, 80" TitleFont="Lucida Grande, 14px">
                                                    <MajorGrid LineColor="64, 64, 64, 64" LineDashStyle="DashDot"></MajorGrid>
                                                    <LabelStyle Font="Lucida Grande, 11px" IsStaggered="True" Interval="1" ForeColor="0, 63, 135">
                                                    </LabelStyle>
                                                </AxisX>
                                                <Area3DStyle Rotation="10" Perspective="10" Inclination="15" IsRightAngleAxes="False"
                                                    WallWidth="0"></Area3DStyle>
                                            </asp:ChartArea>
                                        </ChartAreas>
                                        <Legends>
                                            <asp:Legend BackColor="Transparent" Font="Lucida Grande, 12px" IsTextAutoFit="False"
                                                Enabled="False" Name="Legend1">
                                            </asp:Legend>
                                        </Legends>
                                        <Titles>
                                            <asp:Title ShadowColor="32, 0, 0, 0" Font="Lucida Grande, 15px" ShadowOffset="3"
                                                Text="Location Wise" Name="Title1" ForeColor="#8f1313">
                                            </asp:Title>
                                        </Titles>
                                    </asp:Chart>
                                </td>
                                &nbsp;&nbsp;&nbsp;
                            </tr>
                            &nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;
                        </table>
                        &nbsp;&nbsp;&nbsp; &nbsp; &nbsp;&nbsp;&nbsp;
                    </ContentTemplate>
                </ajax:TabPanel>
                <ajax:TabPanel ID="Tab2" runat="server" HeaderText="Levels Reached" Font-Bold="true"
                    Font-Size="Medium" ForeColor="OrangeRed" BorderColor="White" BorderWidth="0px">
                    <ContentTemplate>
                        &nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;
                        <table align="center">
                            &nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;
                            <tr>
                                <%-- <td>
                                <asp:Chart ID="Chart1" runat="server" Height="277px" BorderlineDashStyle="Solid"
                                    BorderWidth="2px" BorderColor="#B54001" Palette="None" ImageUrl="~/TempImages/ChartPic_#SEQ(300,3)"
                                    Width="410px" BorderlineColor="Coral" BorderlineWidth="2" PaletteCustomColors="#3399ff">
                                    <Titles>
                                        <asp:Title ShadowColor="32, 0, 0, 0" Font="Trebuchet MS, 10pt, style=Bold" ShadowOffset="3"
                                            Text="Unique Visitors" Name="Title1" ForeColor="26, 59, 105">
                                        </asp:Title>
                                    </Titles>
                                    <Legends>
                                        <asp:Legend BackColor="Transparent" Font="Trebuchet MS, 8.25pt, style=Bold" IsTextAutoFit="False"
                                            Enabled="False" Name="Default">
                                        </asp:Legend>
                                    </Legends>
                                    <Series>
                                        <asp:Series Name="Series1" IsValueShownAsLabel="True" ChartType="Pie" Font="Microsoft Sans Serif, 10pt, style=Bold"
                                            YValuesPerPoint="2" ChartArea="ChartArea1" Legend="Default">
                                        </asp:Series>
                                    </Series>
                                    <ChartAreas>
                                        <asp:ChartArea Name="ChartArea1" BorderColor="64, 64, 64, 64" BackSecondaryColor="White"
                                            BackColor="White" ShadowColor="Transparent" BackGradientStyle="TopBottom" AlignmentOrientation="Horizontal">
                                            <Area3DStyle Rotation="10" Perspective="10" Inclination="15" IsRightAngleAxes="False"
                                                WallWidth="0" />
                                            <AxisY LineColor="64, 64, 64, 64" IsLabelAutoFit="False" ArrowStyle="Triangle" TitleFont="Microsoft Sans Serif, 8pt, style=Bold">
                                                <LabelStyle Font="Trebuchet MS, 8.25pt, style=Bold" Format="#" />
                                                <MajorGrid LineColor="64, 64, 64, 64" />
                                            </AxisY>
                                            <AxisX LineColor="64, 64, 64, 64" IsLabelAutoFit="False" ArrowStyle="Triangle" Interval="1"
                                                IntervalType="Number">
                                                <LabelStyle Font="Trebuchet MS, 8.25pt, style=Bold" IsStaggered="True" Interval="1" />
                                                <MajorGrid LineColor="64, 64, 64, 64" />
                                            </AxisX>
                                        </asp:ChartArea>
                                    </ChartAreas>
                                </asp:Chart>
                            </td>--%>
                                <td>
                                    <asp:Chart ID="Chart3" runat="server" Height="277px" BorderlineDashStyle="Solid"
                                        BorderWidth="2px" BorderColor="#8f1313" Palette="None" ImageUrl="~/TempImages/ChartPic_#SEQ(300,3)"
                                        Width="974px" BorderlineColor="#8f1313" BorderlineWidth="2" PaletteCustomColors="#3399ff">
                                        <Titles>
                                            <asp:Title ShadowColor="32, 0, 0, 0" Font="Lucida Grande, 15px, style=Regular" ShadowOffset="3"
                                                Text="Levels Reached" Name="Title1" ForeColor="26, 59, 105">
                                            </asp:Title>
                                        </Titles>
                                        <Legends>
                                            <asp:Legend BackColor="Transparent" Font="Lucida Grande, 12px, style=Regular" IsTextAutoFit="False"
                                                Enabled="False" Name="Default">
                                            </asp:Legend>
                                        </Legends>
                                        <Series>
                                            <asp:Series Name="Series1" IsValueShownAsLabel="True" ChartType="StepLine" Font="Lucida Grande, 10px, style=Regular"
                                                YValuesPerPoint="2" ChartArea="ChartArea1" Legend="Default">
                                            </asp:Series>
                                        </Series>
                                        <ChartAreas>
                                            <asp:ChartArea Name="ChartArea1" BorderColor="64, 64, 64, 64" BackSecondaryColor="White"
                                                BackColor="White" ShadowColor="Transparent" BackGradientStyle="TopBottom" AlignmentOrientation="Horizontal">
                                                <Area3DStyle Rotation="10" Perspective="10" Inclination="15" IsRightAngleAxes="False"
                                                    WallWidth="0" />
                                                <AxisY LineColor="64, 64, 64, 64" IsLabelAutoFit="False" ArrowStyle="Triangle" IntervalType="Number"
                                                    TitleFont="Lucida Grande, 14px, style=Regular">
                                                    <LabelStyle Font="Lucida Grande, 11px, style=Regular" Format="#" />
                                                    <MajorGrid LineColor="64, 64, 64, 64" LineDashStyle="DashDot" />
                                                </AxisY>
                                                <AxisX LineColor="64, 64, 64, 64" IsLabelAutoFit="False" ArrowStyle="Triangle" Interval="1"
                                                    IntervalType="Number" Title="Levels" TitleFont="Lucida Grande, 14px, style=Regular">
                                                    <LabelStyle Font="Lucida Grande, 11px, style=Regular" IsStaggered="True" Interval="1" />
                                                    <MajorGrid LineColor="64, 64, 64, 64" LineDashStyle="DashDot" />
                                                </AxisX>
                                            </asp:ChartArea>
                                        </ChartAreas>
                                    </asp:Chart>
                                </td>
                                &nbsp;&nbsp;&nbsp;
                            </tr>
                            &nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;
                        </table>
                        &nbsp;&nbsp;&nbsp; &nbsp; &nbsp;&nbsp;&nbsp;
                    </ContentTemplate>
                </ajax:TabPanel>
                <ajax:TabPanel ID="Tab3" runat="server" HeaderText="PeriodWise Details" Font-Bold="true"
                    Font-Size="Medium" ForeColor="OrangeRed" BorderColor="White" BorderWidth="0px">
                    <ContentTemplate>
                        &nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;
                        <table align="center">
                            &nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;
                            <tr>
                                <td>
                                    <asp:Chart ID="Chart8" runat="server" Height="277px" BorderlineDashStyle="Solid"
                                        BorderWidth="2px" BorderColor="#8f1313" Palette="None" ImageUrl="~/TempImages/ChartPic_#SEQ(300,3)"
                                        Width="974px" PaletteCustomColors="RoyalBlue; DarkOrange; ForestGreen; Tomato"
                                        BorderlineColor="#8f1313" BorderlineWidth="2">
                                        <ChartAreas>
                                            <asp:ChartArea Name="ChartArea1" BorderColor="64, 64, 64, 64" BackSecondaryColor="White"
                                                BackColor="White" ShadowColor="Transparent" BackGradientStyle="TopBottom" AlignmentOrientation="Horizontal">
                                                <AxisY IsLabelAutoFit="False" ArrowStyle="Triangle" InterlacedColor="Black" TitleFont="Lucida Grande, 14px"
                                                    TitleForeColor="139, 10, 80">
                                                    <MajorGrid LineColor="64, 64, 64, 64" LineDashStyle="DashDot"></MajorGrid>
                                                    <LabelStyle Font="Lucida Grande, 11px" IsStaggered="True" Format="#" ForeColor="0, 63, 135">
                                                    </LabelStyle>
                                                </AxisY>
                                                <AxisX IsLabelAutoFit="False" ArrowStyle="Triangle" Interval="1" IntervalType="Number"
                                                    InterlacedColor="Black" TitleFont="Lucida Grande, 14px" TitleForeColor="139, 10, 80">
                                                    <MajorGrid LineColor="64, 64, 64, 64" LineDashStyle="DashDot"></MajorGrid>
                                                    <LabelStyle Font="Lucida Grande, 11px" IsStaggered="True" Interval="1" ForeColor="0, 63, 135">
                                                    </LabelStyle>
                                                </AxisX>
                                                <Area3DStyle Rotation="10" Perspective="10" Inclination="15" IsRightAngleAxes="False"
                                                    WallWidth="0"></Area3DStyle>
                                            </asp:ChartArea>
                                        </ChartAreas>
                                        <Legends>
                                            <asp:Legend BackColor="Transparent" Font="Lucida Grande, 12px" IsTextAutoFit="False"
                                                LegendItemOrder="SameAsSeriesOrder" Name="Legend1">
                                            </asp:Legend>
                                        </Legends>
                                        <Titles>
                                            <asp:Title ShadowColor="32, 0, 0, 0" Font="Lucida Grande, 15px" ShadowOffset="3"
                                                Text="PeriodWise Actions" Name="Title1" ForeColor="#8f1313">
                                            </asp:Title>
                                        </Titles>
                                    </asp:Chart>
                                </td>
                                &nbsp;&nbsp;&nbsp;
                            </tr>
                            &nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;
                        </table>
                        &nbsp;&nbsp;&nbsp; &nbsp; &nbsp;&nbsp;&nbsp;
                    </ContentTemplate>
                </ajax:TabPanel>
                <ajax:TabPanel ID="Tab4" runat="server" HeaderText="Social Channels" Font-Bold="true"
                    Font-Size="Medium" ForeColor="OrangeRed" BorderColor="White" BorderWidth="0px"
                    Width="">
                    <ContentTemplate>
                        &nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;
                        <table cellpadding="0" align="center" border="0px;" style="height: 280px;" cellspacing="1">
                            <tr>
                                <td colspan="2" style="width: 100%; height: 92px; text-align: center; padding-top: 0px;"
                                    valign="top">
                                    <div style="border: 2px solid #8f1313; width: 965px; height: 118px; padding: 10px 10px 10px 10px;
                                        border-color: Gray; background-color: #8f1313">
                                        <table cellpadding="4" border="0" cellspacing="1" width="100%" style="background-color: #8f1313;">
                                            <tr>
                                                <td align="left" bgcolor="#fff">
                                                    <asp:Label ID="lbActions" runat="server" Font-Names="Lucida Grande" Font-Size="15px"
                                                        ForeColor="#8f1313" Text="Actions"></asp:Label>
                                                </td>
                                                <td align="center" bgcolor="#fff">
                                                    <asp:Label ID="lblFacebook" runat="server" Font-Names="Lucida Grande" Font-Size="15px"
                                                        ForeColor="#8f1313" Text="Facebook"></asp:Label>
                                                </td>
                                                <td align="center" bgcolor="#fff">
                                                    <asp:Label ID="lblTwitter" runat="server" Font-Names="Lucida Grande" Font-Size="15px"
                                                        ForeColor="#8f1313" Text="Twitter"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left" bgcolor="#fff">
                                                    <asp:Label ID="Label1" runat="server" Font-Names="Lucida Grande" Font-Size="15px"
                                                        ForeColor="#8f1313" Text="Impressions"></asp:Label>
                                                </td>
                                                <td align="center" bgcolor="#fff">
                                                    <asp:Label ID="lblFBImpressions" runat="server" Font-Names="Lucida Grande" Font-Size="15px"
                                                        ForeColor="#8f1313"></asp:Label>
                                                </td>
                                                <td align="center" bgcolor="#fff">
                                                    <asp:Label ID="lblTWImpressions" runat="server" Font-Names="Lucida Grande" Font-Size="15px"
                                                        ForeColor="#8f1313"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left" bgcolor="#fff">
                                                    <asp:Label ID="Label4" runat="server" Font-Names="Lucida Grande" Font-Size="15px"
                                                        ForeColor="#8f1313" Text="Unique Visitors"></asp:Label>
                                                </td>
                                                <td align="center" bgcolor="#fff">
                                                    <asp:Label ID="lblFBUnique" runat="server" Font-Names="Lucida Grande" Font-Size="15px"
                                                        ForeColor="#8f1313"></asp:Label>
                                                </td>
                                                <td align="center" bgcolor="#fff">
                                                    <asp:Label ID="lblTWUnique" runat="server" Font-Names="Lucida Grande" Font-Size="15px"
                                                        ForeColor="#8f1313"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left" bgcolor="#fff">
                                                    <asp:Label ID="Label7" runat="server" Font-Names="Lucida Grande" Font-Size="15px"
                                                        ForeColor="#8f1313" Text="Total Actions"></asp:Label>
                                                </td>
                                                <td align="center" bgcolor="#fff">
                                                    <asp:Label ID="lblFBActions" runat="server" Font-Names="Lucida Grande" Font-Size="15px"
                                                        ForeColor="#8f1313"></asp:Label>
                                                </td>
                                                <td align="center" bgcolor="#fff">
                                                    <asp:Label ID="lblTWActions" runat="server" Font-Names="Lucida Grande" Font-Size="15px"
                                                        ForeColor="#8f1313"></asp:Label>
                                                </td>
                                            </tr>
                                        </table>
                                        <%--<table cellpadding="4" border="0" cellspacing="1" width="100%" style="background-color: #ffffff;">
                                        <tr>
                                            <td align="left" bgcolor="#236B8E">
                                                <asp:Label ID="Label2" runat="server" Font-Names="Lucida Grande" Font-Size="15px"
                                                    ForeColor="White" Text="Page Views"></asp:Label>
                                            </td>
                                            <td align="center" bgcolor="#236B8E">
                                                <asp:Label ID="Label3" runat="server" Font-Names="Lucida Grande" Font-Size="15px"
                                                    ForeColor="White" Text="Google"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="left" bgcolor="#236B8E">
                                                <asp:Label ID="Label6" runat="server" Font-Names="Lucida Grande" Font-Size="15px"
                                                    ForeColor="White" Text="Impressions"></asp:Label>
                                            </td>
                                            <td align="center" bgcolor="#236B8E">
                                                <asp:Label ID="Label8" runat="server" Font-Names="Lucida Grande" Font-Size="15px"
                                                    ForeColor="White"></asp:Label>
                                            </td>
                                            <td align="center" bgcolor="#236B8E">
                                                <asp:Label ID="Label9" runat="server" Font-Names="Lucida Grande" Font-Size="15px"
                                                    ForeColor="White"></asp:Label>
                                            </td>
                                        </tr>
                                    </table>--%>
                                </td>
                                <td colspan="1">
                                </td>
                                <%--<td colspan="1" style="width: 120px; height: 92px; text-align: center; padding-top: 0px;
                                padding-right: 280px;" valign="top">
                                <div style="border: 2px solid Coral; width: 184px; height: 75px; padding: 10px 5px 10px 10px;
                                    border-color: Gray; background-color: #236B8E">
                                    <asp:Label ID="lblTweet31" runat="server" Font-Names="Lucida Grande" Font-Size="15px"
                                        ForeColor="White"></asp:Label>
                                    <br />
                                    <br />
                                    <span style="color: White">
                                        <asp:Label ID="lblTweet32" runat="server" Font-Names="Lucida Grande" Font-Size="15px"></asp:Label>
                                        &nbsp;</span>
                                </div>
                            </td>--%>
                            </tr>
                            &nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;
                            <%--<tr>
                            <td align="left" style="padding-left: 2px;" colspan="1">
                                <asp:Chart ID="Chart9" runat="server" Height="325px" BorderlineDashStyle="Solid"
                                    BorderWidth="2px" BorderColor="#F6BF4B" Palette="None" ImageUrl="~/TempImages/ChartPic_#SEQ(300,3)"
                                    BorderlineColor="Gray" BorderlineWidth="2" PaletteCustomColors="DarkOliveGreen; MenuHighlight; Orange; DarkBlue"
                                    Width="485px" BackImageTransparentColor="White" BackSecondaryColor="White">
                                    <Series>
                                        <asp:Series Name="Series1" ChartType="Funnel" IsValueShownAsLabel="True" XValueType="Double"
                                            CustomProperties="PyramidPointGap=2, FunnelMinPointHeight=1" BorderColor="180, 26, 59, 105"
                                            Color="220, 65, 140, 240" LabelFormat="F1" YValueType="Double" ChartArea="ChartArea1"
                                            Legend="NotifierType" YValuesPerPoint="6" Font="Lucida Grande, 10px">
                                        </asp:Series>
                                    </Series>
                                    <ChartAreas>
                                        <asp:ChartArea Name="ChartArea1" BorderColor="64, 64, 64, 64" BackSecondaryColor="White"
                                            BackColor="White" ShadowColor="Transparent" BackGradientStyle="TopBottom" AlignmentOrientation="Horizontal">
                                            <AxisY LineColor="64, 64, 64, 64" IsLabelAutoFit="False" ArrowStyle="Triangle">
                                                <MajorGrid LineColor="64, 64, 64, 64"></MajorGrid>
                                                <LabelStyle Font="Lucida Grande, 10px" TruncatedLabels="True"></LabelStyle>
                                            </AxisY>
                                            <AxisX LineColor="64, 64, 64, 64" IsLabelAutoFit="False" ArrowStyle="Triangle" Interval="1"
                                                IntervalType="Number">
                                                <MajorGrid LineColor="64, 64, 64, 64"></MajorGrid>
                                                <LabelStyle Font="Lucida Grande, 10px" IsStaggered="True" Interval="1"></LabelStyle>
                                            </AxisX>
                                            <Area3DStyle Rotation="10" Inclination="15" IsRightAngleAxes="False" WallWidth="0"
                                                Enable3D="True"></Area3DStyle>
                                        </asp:ChartArea>
                                    </ChartAreas>
                                    <Legends>
                                        <asp:Legend BackColor="Transparent" Font="Lucida Grande, 12px" IsTextAutoFit="False"
                                            Name="NotifierType">
                                        </asp:Legend>
                                    </Legends>
                                    <Titles>
                                        <asp:Title ShadowColor="32, 0, 0, 0" Font="Lucida Grande, 15px" ShadowOffset="3"
                                            Text="Actions Funnel" Name="Title1" ForeColor="26, 59, 105">
                                        </asp:Title>
                                    </Titles>
                                </asp:Chart>
                            </td>
                            <td align="right" style="padding-left: 2px;" colspan="1">
                                <asp:Chart ID="Chart10" runat="server" Width="485px" Height="325px" BorderlineDashStyle="Solid"
                                    BorderWidth="2px" BorderColor="#B54001" Palette="None" ImageUrl="~/TempImages/ChartPic_#SEQ(300,3)"
                                    BorderlineColor="Gray" BorderlineWidth="2" PaletteCustomColors="242, 160, 32; RoyalBlue; 0, 183, 74; 219, 80, 136"
                                    BackImageTransparentColor="Silver" BackSecondaryColor="White" Font="Lucida Grande, 10px, style=Regular">
                                    <Series>
                                        <asp:Series Name="Series1" IsValueShownAsLabel="True" ChartType="Doughnut" ChartArea="ChartArea1"
                                            Legend="Gender" Font="Lucida Grande, 10px">
                                        </asp:Series>
                                    </Series>
                                    <ChartAreas>
                                        <asp:ChartArea Name="ChartArea1" BorderColor="64, 64, 64, 64" BackSecondaryColor="White"
                                            BackColor="White" ShadowColor="Transparent" BackGradientStyle="TopBottom" AlignmentOrientation="Horizontal">
                                            <AxisY LineColor="64, 64, 64, 64" IsLabelAutoFit="False" ArrowStyle="Triangle">
                                                <MajorGrid LineColor="64, 64, 64, 64"></MajorGrid>
                                                <LabelStyle Font="Lucida Grande, 10px" Format="#"></LabelStyle>
                                            </AxisY>
                                            <AxisX LineColor="64, 64, 64, 64" IsLabelAutoFit="False" ArrowStyle="Triangle" Interval="1"
                                                IntervalType="Number">
                                                <MajorGrid LineColor="64, 64, 64, 64"></MajorGrid>
                                                <LabelStyle Font="Lucida Grande, 10px" IsStaggered="True" Interval="1"></LabelStyle>
                                            </AxisX>
                                            <Area3DStyle Rotation="10" Perspective="10" Inclination="15" IsRightAngleAxes="False"
                                                WallWidth="0"></Area3DStyle>
                                        </asp:ChartArea>
                                    </ChartAreas>
                                    <Legends>
                                        <asp:Legend BackColor="Transparent" Font="Lucida Grande, 12px" IsTextAutoFit="False"
                                            Name="Gender">
                                        </asp:Legend>
                                    </Legends>
                                    <Titles>
                                        <asp:Title ShadowColor="32, 0, 0, 0" Font="Lucida Grande, 15px" ShadowOffset="3"
                                            Text="Gender Wise" Name="Title1" ForeColor="26, 59, 105">
                                        </asp:Title>
                                    </Titles>
                                </asp:Chart>
                            </td>
                            &nbsp;&nbsp;&nbsp;
                        </tr>--%>
                            &nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;
                            <tr>
                                <td colspan="1" align="left" valign="top">
                                    <asp:Chart ID="Chart11" runat="server" Width="500px" Height="277px" BorderlineDashStyle="Solid"
                                        BorderWidth="2px" BorderColor="#B54001" Palette="None" ImageUrl="~/TempImages/ChartPic_#SEQ(300,3)"
                                        BorderlineColor="#8f1313" BorderlineWidth="2" PaletteCustomColors="0, 183, 74">
                                        <Series>
                                            <asp:Series Name="Series1" IsValueShownAsLabel="True" ChartType="Bubble" CustomProperties="LabelStyle=Bottom"
                                                BorderColor="180, 26, 59, 105" LabelFormat="#" ChartArea="ChartArea1" Legend="Legend1"
                                                YValuesPerPoint="2" Font="Lucida Grande, 12px">
                                            </asp:Series>
                                        </Series>
                                        <ChartAreas>
                                            <asp:ChartArea Name="ChartArea1" BorderColor="#8f1313" BackSecondaryColor="White"
                                                BackColor="White" ShadowColor="Transparent" BackGradientStyle="TopBottom" AlignmentOrientation="Horizontal">
                                                <AxisY IsLabelAutoFit="False" ArrowStyle="Triangle" TitleFont="Lucida Grande, 14px"
                                                    InterlacedColor="Black" TitleForeColor="139, 10, 80">
                                                    <MajorGrid LineColor="64, 64, 64, 64" LineDashStyle="DashDot"></MajorGrid>
                                                    <LabelStyle Font="Lucida Grande, 11px" Format="#" ForeColor="0, 63, 135"></LabelStyle>
                                                </AxisY>
                                                <AxisX IsLabelAutoFit="False" ArrowStyle="Triangle" Interval="1" IntervalType="Number"
                                                    InterlacedColor="Black" TitleForeColor="139, 10, 80" TitleFont="Lucida Grande, 14px">
                                                    <MajorGrid LineColor="64, 64, 64, 64" LineDashStyle="DashDot"></MajorGrid>
                                                    <LabelStyle Font="Lucida Grande, 11px" IsStaggered="True" Interval="1" ForeColor="0, 63, 135">
                                                    </LabelStyle>
                                                </AxisX>
                                                <Area3DStyle Rotation="10" Perspective="10" Inclination="15" IsRightAngleAxes="False"
                                                    WallWidth="0"></Area3DStyle>
                                            </asp:ChartArea>
                                        </ChartAreas>
                                        <Legends>
                                            <asp:Legend BackColor="Transparent" Font="Lucida Grande, 12px" IsTextAutoFit="False"
                                                Enabled="False" Name="Legend1">
                                            </asp:Legend>
                                        </Legends>
                                        <Titles>
                                            <asp:Title ShadowColor="32, 0, 0, 0" Font="Lucida Grande, 15px" ShadowOffset="3"
                                                Text="Location Wise - Facebook" Name="Title1" ForeColor="#8f1313">
                                            </asp:Title>
                                        </Titles>
                                    </asp:Chart>
                                </td>
                                &nbsp;&nbsp;&nbsp;
                                <td colspan="1" align="left" valign="top">
                                    <asp:Chart ID="Chart12" runat="server" Width="489px" Height="277px" BorderlineDashStyle="Solid"
                                        BorderWidth="2px" BorderColor="#8f1313" Palette="None" ImageUrl="~/TempImages/ChartPic_#SEQ(300,3)"
                                        BorderlineColor="#8f1313" BorderlineWidth="2" PaletteCustomColors="0, 183, 74">
                                        <Series>
                                            <asp:Series Name="Series1" IsValueShownAsLabel="True" ChartType="Bubble" CustomProperties="LabelStyle=Bottom"
                                                BorderColor="180, 26, 59, 105" LabelFormat="#" ChartArea="ChartArea1" Legend="Legend1"
                                                YValuesPerPoint="2" Font="Lucida Grande, 12px">
                                            </asp:Series>
                                        </Series>
                                        <ChartAreas>
                                            <asp:ChartArea Name="ChartArea1" BorderColor="64, 64, 64, 64" BackSecondaryColor="White"
                                                BackColor="White" ShadowColor="Transparent" BackGradientStyle="TopBottom" AlignmentOrientation="Horizontal">
                                                <AxisY IsLabelAutoFit="False" ArrowStyle="Triangle" TitleFont="Lucida Grande, 14px"
                                                    InterlacedColor="Black" TitleForeColor="139, 10, 80">
                                                    <MajorGrid LineColor="64, 64, 64, 64" LineDashStyle="DashDot"></MajorGrid>
                                                    <LabelStyle Font="Lucida Grande, 11px" Format="#" ForeColor="0, 63, 135"></LabelStyle>
                                                </AxisY>
                                                <AxisX IsLabelAutoFit="False" ArrowStyle="Triangle" Interval="1" IntervalType="Number"
                                                    InterlacedColor="Black" TitleForeColor="139, 10, 80" TitleFont="Lucida Grande, 14px">
                                                    <MajorGrid LineColor="64, 64, 64, 64" LineDashStyle="DashDot"></MajorGrid>
                                                    <LabelStyle Font="Lucida Grande, 11px" IsStaggered="True" Interval="1" ForeColor="0, 63, 135">
                                                    </LabelStyle>
                                                </AxisX>
                                                <Area3DStyle Rotation="10" Perspective="10" Inclination="15" IsRightAngleAxes="False"
                                                    WallWidth="0"></Area3DStyle>
                                            </asp:ChartArea>
                                        </ChartAreas>
                                        <Legends>
                                            <asp:Legend BackColor="Transparent" Font="Lucida Grande, 12px" IsTextAutoFit="False"
                                                Enabled="False" Name="Legend1">
                                            </asp:Legend>
                                        </Legends>
                                        <Titles>
                                            <asp:Title ShadowColor="32, 0, 0, 0" Font="Lucida Grande, 15px" ShadowOffset="3"
                                                Text="Location Wise - Twitter" Name="Title1" ForeColor="#8f1313">
                                            </asp:Title>
                                        </Titles>
                                    </asp:Chart>
                                </td>
                            </tr>
                            &nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;
                        </table>
                    </ContentTemplate>
                </ajax:TabPanel>
                <ajax:TabPanel ID="Tab5" runat="server" HeaderText="Platform" Font-Bold="true" Font-Size="Medium"
                    ForeColor="OrangeRed" BorderColor="White" BorderWidth="0px" Width="">
                    <ContentTemplate>
                        &nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;
                        <table cellpadding="0" align="center" border="0px;" style="height: 280px;" cellspacing="0">
                            <tr>
                                <td align="right" style="padding-left: 2px;" colspan="1">
                                    <asp:Chart ID="Chart13" runat="server" Width="485px" Height="325px" BorderlineDashStyle="Solid"
                                        BorderWidth="2px" BorderColor="#8f1313" Palette="None" ImageUrl="~/TempImages/ChartPic_#SEQ(300,3)"
                                        BorderlineColor="#8f1313" BorderlineWidth="2" PaletteCustomColors="242, 160, 32; RoyalBlue; 0, 183, 74; 219, 80, 136"
                                        BackImageTransparentColor="Silver" BackSecondaryColor="White" Font="Lucida Grande, 10px, style=Regular">
                                        <Series>
                                            <asp:Series Name="Series1" IsValueShownAsLabel="True" ChartType="Doughnut" ChartArea="ChartArea1"
                                                Legend="Platform" Font="Lucida Grande, 10px">
                                            </asp:Series>
                                        </Series>
                                        <ChartAreas>
                                            <asp:ChartArea Name="ChartArea1" BorderColor="64, 64, 64, 64" BackSecondaryColor="White"
                                                BackColor="White" ShadowColor="Transparent" BackGradientStyle="TopBottom" AlignmentOrientation="Horizontal">
                                                <AxisY LineColor="64, 64, 64, 64" IsLabelAutoFit="False" ArrowStyle="Triangle">
                                                    <MajorGrid LineColor="64, 64, 64, 64"></MajorGrid>
                                                    <LabelStyle Font="Lucida Grande, 10px" Format="#"></LabelStyle>
                                                </AxisY>
                                                <AxisX LineColor="64, 64, 64, 64" IsLabelAutoFit="False" ArrowStyle="Triangle" Interval="1"
                                                    IntervalType="Number">
                                                    <MajorGrid LineColor="64, 64, 64, 64"></MajorGrid>
                                                    <LabelStyle Font="Lucida Grande, 10px" IsStaggered="True" Interval="1"></LabelStyle>
                                                </AxisX>
                                                <Area3DStyle Rotation="10" Perspective="10" Inclination="15" IsRightAngleAxes="False"
                                                    WallWidth="0"></Area3DStyle>
                                            </asp:ChartArea>
                                        </ChartAreas>
                                        <Legends>
                                            <asp:Legend BackColor="Transparent" Font="Lucida Grande, 12px" IsTextAutoFit="False"
                                                Name="Platform">
                                            </asp:Legend>
                                        </Legends>
                                        <Titles>
                                            <asp:Title ShadowColor="32, 0, 0, 0" Font="Lucida Grande, 15px" ShadowOffset="3"
                                                Text="Platform Wise" Name="Title1" ForeColor="#8f1313">
                                            </asp:Title>
                                        </Titles>
                                    </asp:Chart>
                                </td>
                                &nbsp;&nbsp;&nbsp;
                                <%--   <td align="right" style="padding-left: 2px;" colspan="1">
                                <asp:Chart ID="Chart14" runat="server" Width="485px" Height="325px" BorderlineDashStyle="Solid"
                                    BorderWidth="2px" BorderColor="#B54001" Palette="None" ImageUrl="~/TempImages/ChartPic_#SEQ(300,3)"
                                    BorderlineColor="Gray" BorderlineWidth="2" PaletteCustomColors="242, 160, 32; RoyalBlue; 0, 183, 74; 219, 80, 136"
                                    BackImageTransparentColor="Silver" BackSecondaryColor="White" Font="Lucida Grande, 10px, style=Regular">
                                    <Series>
                                        <asp:Series Name="Series1" IsValueShownAsLabel="True" ChartType="Doughnut" ChartArea="ChartArea1"
                                            Legend="Platform" Font="Lucida Grande, 10px">
                                        </asp:Series>
                                    </Series>
                                    <ChartAreas>
                                        <asp:ChartArea Name="ChartArea1" BorderColor="64, 64, 64, 64" BackSecondaryColor="White"
                                            BackColor="White" ShadowColor="Transparent" BackGradientStyle="TopBottom" AlignmentOrientation="Horizontal">
                                            <AxisY LineColor="64, 64, 64, 64" IsLabelAutoFit="False" ArrowStyle="Triangle">
                                                <MajorGrid LineColor="64, 64, 64, 64"></MajorGrid>
                                                <LabelStyle Font="Lucida Grande, 10px" Format="#"></LabelStyle>
                                            </AxisY>
                                            <AxisX LineColor="64, 64, 64, 64" IsLabelAutoFit="False" ArrowStyle="Triangle" Interval="1"
                                                IntervalType="Number">
                                                <MajorGrid LineColor="64, 64, 64, 64"></MajorGrid>
                                                <LabelStyle Font="Lucida Grande, 10px" IsStaggered="True" Interval="1"></LabelStyle>
                                            </AxisX>
                                            <Area3DStyle Rotation="10" Perspective="10" Inclination="15" IsRightAngleAxes="False"
                                                WallWidth="0"></Area3DStyle>
                                        </asp:ChartArea>
                                    </ChartAreas>
                                    <Legends>
                                        <asp:Legend BackColor="Transparent" Font="Lucida Grande, 12px" IsTextAutoFit="False"
                                            Name="Platform">
                                        </asp:Legend>
                                    </Legends>
                                    <Titles>
                                        <asp:Title ShadowColor="32, 0, 0, 0" Font="Lucida Grande, 15px" ShadowOffset="3"
                                            Text="Mobile Platform " Name="Title1" ForeColor="26, 59, 105">
                                        </asp:Title>
                                    </Titles>
                                </asp:Chart>
                            </td>
                            &nbsp;&nbsp;&nbsp;--%>
                            </tr>
                        </table>
                    </ContentTemplate>
                </ajax:TabPanel>
                <ajax:TabPanel ID="Tab6" runat="server" HeaderText="Google Analytics" Font-Bold="true"
                    Font-Size="Medium" ForeColor="OrangeRed" BorderColor="White" BorderWidth="0px"
                    Width="400px" Visible="false">
                    <ContentTemplate>
                        <div id="divGoogleAnalytics">
                            <table id="tblGoogleAnalytics" runat="server" border="0" cellspacing="1" bgcolor="#ccc">
                                <tr id="Tr1" runat="server">
                                    <td colspan="1" align="center">
                                        Page Path
                                    </td>
                                    <td colspan="1" align="center">
                                        Views
                                    </td>
                                </tr>
                            </table>
                        </div>
                    </ContentTemplate>
                </ajax:TabPanel>
            </ajax:TabContainer>
        </div>
    </div>
    </form>
</body>
</html>
