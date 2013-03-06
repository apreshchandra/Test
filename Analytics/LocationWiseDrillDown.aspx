<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LocationWiseDrillDown.aspx.cs"
    Inherits="DigiMa.Analytics.LocationWiseDrillDown" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../Styles/style.css" rel="stylesheet" type="text/css" />
    <link href="../Styles/style_new_menu.css" rel="stylesheet" type="text/css" />
    <link href="../Styles/menu_style.css" rel="stylesheet" type="text/css" />
    <style>
        body
        {
            font-family: "Lucida Grande" , "Lucida Sans Unicode" , "Helvetica";
            font-size: 12px;
            line-height: 20px;
            font-weight: normal;
            color: #333333;
            background-color: #1b1b1b;
            text-align: left;
            padding: 0px;
            margin: 0px;
        }
        .menusubinsidepages
        {
            margin-top: 68px;
            width: 710px;
            height: 50px;
            position: relative;
            float: left;
            background: url('../images/submenubg.png');
            background-repeat: no-repeat;
            margin-left: 100PX;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div class="leftdivinsidePages">
        <div class="menusubinsidepages">
            <div>
                <div id="ddtopmenubar" class="mattblackmenu">
                    <ul>
                        <li><a href="../Home.aspx" class="select">Home</a></li>
                        <li><a href="../About.aspx">About us</a></li>
                        <li><a href="../ProductSuite.aspx" rel="ddsubmenu5">Product Suite</a></li>
                        <li><a href="../Contact.aspx" rel="ddsubmenu8">Contact us</a></li>
                    </ul>
                </div>
            </div>
        </div>
        <table align="center" style="margin-left: 100px;">
            <tr>
                <td>
                    <asp:Chart ID="Chart1" runat="server" Width="1000px" Height="296px" borderlinestyle="Solid"
                        BorderlineWidth="2" BorderlineColor="180, 26, 59, 105" ImageUrl="~/TempImages/ChartPic_#SEQ(300,3)"
                        Palette="None" BorderlineDashStyle="Solid" PaletteCustomColors="DarkOliveGreen; MenuHighlight; Orange; DarkBlue">
                        <Titles>
                            <asp:Title ShadowColor="32, 0, 0, 0" Font="Lucida Grande, 15px, style=Regular" ShadowOffset="3"
                                Text="Demography Wise" Alignment="TopCenter" ForeColor="26, 59, 105">
                            </asp:Title>
                        </Titles>
                        <Legends>
                            <asp:Legend Enabled="False" Name="Default" BackColor="Transparent" Font="Lucida Grande, 12px, style=Regular">
                                <Position Y="21" Height="22" Width="18" X="73"></Position>
                            </asp:Legend>
                        </Legends>
                        <BorderSkin SkinStyle="None"></BorderSkin>
                        <Series>
                            <asp:Series Name="Series1" BorderColor="180, 26, 59, 105" ChartType="Bar" IsValueShownAsLabel="true"
                                Font="Lucida Grande, 12px, style=Regular" LabelBackColor="Transparent">
                            </asp:Series>
                        </Series>
                        <ChartAreas>
                            <asp:ChartArea Name="Default" BorderColor="64, 64, 64, 64" BorderDashStyle="Solid"
                                BackSecondaryColor="White" BackColor="White" ShadowColor="Transparent" BackGradientStyle="TopBottom">
                                <AxisY LineColor="Black" ArrowStyle="Triangle" IsLabelAutoFit="False">
                                    <LabelStyle Font="Lucida Grande, 11px, style=Regular"></LabelStyle>
                                    <MajorGrid LineColor="64, 64, 64, 64" Interval="Auto" IntervalOffset="Auto" LineDashStyle="DashDot">
                                    </MajorGrid>
                                </AxisY>
                                <AxisX LineColor="Black" ArrowStyle="Triangle" IsLabelAutoFit="False" Interval="1"
                                    IntervalType="Number">
                                    <LabelStyle Font="Lucida Grande, 11px, style=Regular"></LabelStyle>
                                    <MajorGrid LineColor="64, 64, 64, 64" LineDashStyle="DashDot"></MajorGrid>
                                </AxisX>
                            </asp:ChartArea>
                        </ChartAreas>
                    </asp:Chart>
                </td>
            </tr>
        </table>
        <table align="center" style="margin-left: 100px;">
            <tr>
                <td>
                    <asp:Chart ID="Chart2" runat="server" Width="332px" Height="277px" ImageUrl="~/TempImages/ChartPic_#SEQ(300,3)"
                        BorderlineDashStyle="Solid" BorderWidth="2px" BorderColor="#B54001" Style="margin-top: 0px"
                        Palette="None" BackImageTransparentColor="224, 224, 224" BackImageWrapMode="Scaled"
                        BackSecondaryColor="White" BorderlineColor="180, 26, 59, 105" BorderlineWidth="2"
                        PaletteCustomColors="242, 160, 32; RoyalBlue">
                        <Titles>
                            <asp:Title ShadowColor="32, 0, 0, 0" Font="Lucida Grande, 15px, style=Regular" ShadowOffset="3"
                                Text="Gender Wise" Name="Title1" ForeColor="26, 59, 105">
                            </asp:Title>
                        </Titles>
                        <Series>
                            <asp:Series Name="Default" IsValueShownAsLabel="true" Font="Lucida Grande, 11px, style=Regular"
                                ChartType="Doughnut">
                            </asp:Series>
                        </Series>
                        <Legends>
                            <asp:Legend BackColor="Transparent" Font="Lucida Grande, 12px, style=Regular" IsTextAutoFit="False"
                                Enabled="true">
                            </asp:Legend>
                        </Legends>
                        <BorderSkin SkinStyle="None"></BorderSkin>
                        <ChartAreas>
                            <asp:ChartArea Name="ChartArea1" BorderColor="" BackColor="White" ShadowColor="Transparent"
                                BackGradientStyle="TopBottom" AlignmentOrientation="Horizontal">
                                <Area3DStyle Rotation="10" Perspective="10" Inclination="15" IsRightAngleAxes="False"
                                    WallWidth="0" />
                                <AxisY LineColor="64, 64, 64, 64" IsLabelAutoFit="False" ArrowStyle="Triangle">
                                    <LabelStyle Font="Lucida Grande, 11px, style=Regular" Format="#" />
                                    <MajorGrid LineColor="64, 64, 64, 64" />
                                </AxisY>
                                <AxisX LineColor="64, 64, 64, 64" IsLabelAutoFit="False" ArrowStyle="Triangle" Interval="1"
                                    IntervalType="Number">
                                    <LabelStyle Font="Lucida Grande, 11px, style=Regular" IsStaggered="True" Interval="1" />
                                    <MajorGrid LineColor="64, 64, 64, 64" />
                                </AxisX>
                            </asp:ChartArea>
                        </ChartAreas>
                    </asp:Chart>
                </td>
                <td>
                    <asp:Chart ID="Chart3" runat="server" Width="332px" Height="277px" ImageUrl="~/TempImages/ChartPic_#SEQ(300,3)"
                        BorderlineDashStyle="Solid" BorderWidth="2px" BorderColor="#B54001" Style="margin-top: 0px"
                        Palette="None" BackImageTransparentColor="224, 224, 224" BackImageWrapMode="Scaled"
                        BackSecondaryColor="White" BorderlineColor="180, 26, 59, 105" BorderlineWidth="2"
                        PaletteCustomColors="Teal; SaddleBrown">
                        <Titles>
                            <asp:Title ShadowColor="32, 0, 0, 0" Font="Lucida Grande, 15px, style=Regular" ShadowOffset="3"
                                Text="Age Wise" Name="Title1" ForeColor="26, 59, 105">
                            </asp:Title>
                        </Titles>
                        <%-- <Series>
                            <asp:Series Name="" IsValueShownAsLabel="true"  
                                Font="Lucida Grande, 11px, style=Regular" ChartType="Column">
                            </asp:Series>
                        </Series>     --%>
                        <Legends>
                            <asp:Legend BackColor="Transparent" Font="Lucida Grande, 12px, style=Regular" IsTextAutoFit="False"
                                Enabled="true" Name="Age">
                            </asp:Legend>
                        </Legends>
                        <BorderSkin SkinStyle="None"></BorderSkin>
                        <ChartAreas>
                            <asp:ChartArea Name="ChartArea1" BorderColor="" BackColor="White" ShadowColor="Transparent"
                                BackGradientStyle="TopBottom" AlignmentOrientation="Horizontal">
                                <Area3DStyle Rotation="10" Perspective="10" Inclination="15" IsRightAngleAxes="False"
                                    WallWidth="0" IsClustered="False"></Area3DStyle>
                                <AxisY LineColor="Black" IsLabelAutoFit="False" ArrowStyle="Triangle" TitleFont="Lucida Grande, 11px"
                                    IsStartedFromZero="False">
                                    <LabelStyle Font="Lucida Grande, 11px, style=Regular" Format="#" />
                                    <MajorGrid LineColor="64, 64, 64, 64" Interval="Auto" LineDashStyle="DashDot" />
                                    <MajorTickMark Interval="1" Enabled="False" />
                                </AxisY>
                                <AxisX LineColor="Black" IsLabelAutoFit="False" ArrowStyle="Triangle" Interval="1"
                                    IntervalType="Number" TitleFont="Lucida Grande, 11px">
                                    <LabelStyle Font="Lucida Grande, 11px, style=Regular" IsStaggered="True" Interval="1" />
                                    <MajorGrid LineColor="64, 64, 64, 64" LineDashStyle="DashDot" Interval="Auto" />
                                    <MajorTickMark Interval="1" Enabled="False" />
                                </AxisX>
                            </asp:ChartArea>
                        </ChartAreas>
                    </asp:Chart>
                </td>
                <td>
                    <asp:Chart ID="Chart4" runat="server" Width="332px" Height="277px" ImageUrl="~/TempImages/ChartPic_#SEQ(300,3)"
                        BorderlineDashStyle="Solid" BorderWidth="2px" BorderColor="#B54001" Style="margin-top: 0px"
                        Palette="None" BackImageTransparentColor="224, 224, 224" BackImageWrapMode="Scaled"
                        BackSecondaryColor="White" BorderlineColor="180, 26, 59, 105" BorderlineWidth="2"
                        PaletteCustomColors="MenuHighlight; DarkGoldenrod">
                        <Titles>
                            <asp:Title ShadowColor="32, 0, 0, 0" Font="Lucida Grande, 15px, style=Regular" ShadowOffset="3"
                                Text="Notification Wise" Name="Title1" ForeColor="26, 59, 105">
                            </asp:Title>
                        </Titles>
                        <Legends>
                            <asp:Legend BackColor="Transparent" Font="Lucida Grande, 12px, style=Regular" IsTextAutoFit="False"
                                Enabled="true" Name="NotifierType">
                            </asp:Legend>
                        </Legends>
                        <BorderSkin SkinStyle="None"></BorderSkin>
                        <ChartAreas>
                            <asp:ChartArea Name="ChartArea1" BorderColor="" BackColor="White" ShadowColor="Transparent"
                                BackGradientStyle="TopBottom" AlignmentOrientation="Horizontal">
                                <Area3DStyle Rotation="10" Perspective="10" Inclination="15" IsRightAngleAxes="False"
                                    WallWidth="0" />
                                <AxisY LineColor="Black" IsLabelAutoFit="False" ArrowStyle="Triangle">
                                    <LabelStyle Font="Lucida Grande, 11px, style=Regular" Format="#" />
                                    <MajorGrid LineColor="64, 64, 64, 64" LineDashStyle="DashDot" />
                                </AxisY>
                                <AxisX LineColor="Black" IsLabelAutoFit="False" ArrowStyle="Triangle" Interval="1"
                                    IntervalType="Number">
                                    <LabelStyle Font="Lucida Grande, 11px, style=Regular" IsStaggered="True" Interval="1" />
                                    <MajorGrid LineColor="64, 64, 64, 64" LineDashStyle="DashDot" />
                                </AxisX>
                            </asp:ChartArea>
                        </ChartAreas>
                    </asp:Chart>
                </td>
            </tr>
        </table>
    </div>
    <style type="text/css">
        .fadingTooltip
        {
            border-right: darkgray 1px outset;
            border-top: darkgray 1px outset;
            font-size: 10pt;
            border-left: darkgray 1px outset;
            width: auto;
            color: black;
            border-bottom: darkgray 1px outset;
            height: auto;
            background-color: #FFFACD;
            margin: 3px 3px 3px 3px;
            padding: 3px 3px 3px 3px;
            border-bottom-width: 3px 3px 3px 3px;
        }
    </style>
    <div class="fadingTooltip" id="fadingTooltip" style="z-index: 999; visibility: hidden;
        position: absolute">
    </div>
    <script type="text/javascript">
        var fadingTooltip;
        var wnd_height, wnd_width;
        var tooltip_height, tooltip_width;
        var tooltip_shown = false;
        var transparency = 100;
        var timer_id = 1;
        var tooltiptext;

        // override events
        window.onload = WindowLoading;
        window.onresize = UpdateWindowSize;
        document.onmousemove = AdjustToolTipPosition;

        function DisplayTooltip(tooltip_text) {
            fadingTooltip.innerHTML = tooltip_text;
            tooltip_shown = (tooltip_text != "") ? true : false;
            if (tooltip_text != "") {
                // Get tooltip window height
                tooltip_height = (fadingTooltip.style.pixelHeight) ? fadingTooltip.style.pixelHeight : fadingTooltip.offsetHeight;
                transparency = 0;
                ToolTipFading();
            }
            else {
                clearTimeout(timer_id);
                fadingTooltip.style.visibility = "hidden";
            }
        }

        function AdjustToolTipPosition(e) {
            if (tooltip_shown) {
                // Depending on IE/Firefox, find out what object to use to find mouse position
                var ev;
                if (e)
                    ev = e;
                else
                    ev = event;

                fadingTooltip.style.visibility = "visible";
                offset_y = (ev.clientY + tooltip_height - document.body.scrollTop + 30 >= wnd_height) ? -15 - tooltip_height : 20;
                fadingTooltip.style.left = Math.min(wnd_width - tooltip_width - 10, Math.max(3, ev.clientX + 6)) + document.body.scrollLeft + 'px';
                fadingTooltip.style.top = ev.clientY + offset_y + document.body.scrollTop + 'px';
            }
        }

        function WindowLoading() {
            fadingTooltip = document.getElementById('fadingTooltip');

            // Get tooltip  window width				
            tooltip_width = (fadingTooltip.style.pixelWidth) ? fadingTooltip.style.pixelWidth : fadingTooltip.offsetWidth;

            // Get tooltip window height
            tooltip_height = (fadingTooltip.style.pixelHeight) ? fadingTooltip.style.pixelHeight : fadingTooltip.offsetHeight;

            UpdateWindowSize();
        }

        function ToolTipFading() {
            if (transparency <= 100) {
                fadingTooltip.style.filter = "alpha(opacity=" + transparency + ")";
                fadingTooltip.style.opacity = transparency / 100;
                transparency += 5;
                timer_id = setTimeout('ToolTipFading()', 35);
            }
        }

        function UpdateWindowSize() {
            wnd_height = document.body.clientHeight;
            wnd_width = document.body.clientWidth;
        }
    </script>
    </form>
    <div>
        <img src="~/images/spacer.png" height="5" width="100%" alt="" /></div>
</body>
</html>
