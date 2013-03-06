<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LocationWiseDrillDown1.aspx.cs"
    Inherits="DigiMa.Analytics.LocationWiseDrillDown1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="stylesheet" type="text/css" href="~/Styles/master_style.css" />
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
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <div class="masterwrapper">
            <div class="sonetlogo">
                <a id="A1" href="../LandingPage.aspx" runat="server">
                    <img src="../Images/logo.png" border="0" alt="SonetReach" /></a></div>
        </div>
        <div class="clr">
        </div>
        <div style="padding-top: 10px;">
            <img src="../images/greytop_border.png" height="4" width="100%" alt="" /></div>
          <div class="backwrapper">
            <%--<a href="LocationWiseDrillDown.aspx" class="backlink">Back</a></div>--%>
        <asp:LinkButton ID="lnkBack" runat="server" Text="Back" OnClick="vid_Click" CssClass="backlink"></asp:LinkButton></div>
        <table align="center">
            <tr>
                <td>
                    <asp:Chart ID="Chart1" runat="server" Width="1000px" Height="296px" borderlinestyle="Solid"
                        BorderlineWidth="2" BorderlineColor="180, 26, 59, 105" ImageUrl="~/TempImages/ChartPic_#SEQ(300,3)"
                        Palette="None" BorderlineDashStyle="Solid" 
                        PaletteCustomColors="DarkOliveGreen">
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
                            <asp:Series Name="Series1" BorderColor="180, 26, 59, 105" ChartType="Bar" IsValueShownAsLabel="True"
                                Font="Lucida Grande, 10px, style=Regular">
                            </asp:Series>
                        </Series>
                        <ChartAreas>
                            <asp:ChartArea Name="Default" BorderColor="64, 64, 64, 64" BorderDashStyle="Solid"
                                BackSecondaryColor="White" BackColor="White" ShadowColor="Transparent" BackGradientStyle="TopBottom">
                                <AxisY LineColor="Black" IsLabelAutoFit="False" ArrowStyle="Triangle">
                                    <LabelStyle Font="Lucida Grande, 11px, style=Regular"></LabelStyle>
                                    <MajorGrid LineColor="64, 64, 64, 64" Interval="Auto" IntervalOffset="Auto" LineDashStyle="DashDot"></MajorGrid>
                                </AxisY>
                                <AxisX LineColor="Black" IsLabelAutoFit="False" Interval="1" IntervalType="Number" ArrowStyle="Triangle">
                                    <LabelStyle Font="Lucida Grande, 11px, style=Regular"></LabelStyle>
                                    <MajorGrid LineColor="64, 64, 64, 64" LineDashStyle="DashDot"></MajorGrid>
                                </AxisX>
                            </asp:ChartArea>
                        </ChartAreas>
                    </asp:Chart>
                </td>
            </tr>
        </table>
        <table align="center">
            <tr>
                <td>
                    <asp:Chart ID="Chart2" runat="server" Width="332px" Height="277px" ImageUrl="~/TempImages/ChartPic_#SEQ(300,3)"
                        BorderlineDashStyle="Solid" BorderWidth="2px" BorderColor="#B54001" Style="margin-top: 0px"
                        Palette="None" BackImageTransparentColor="224, 224, 224" BackImageWrapMode="Scaled"
                        BackSecondaryColor="White" BorderlineColor="180, 26, 59, 105" 
                        BorderlineWidth="2" PaletteCustomColors="242, 160, 32; RoyalBlue">
                        <Titles>
                            <asp:Title ShadowColor="32, 0, 0, 0" Font="Lucida Grande, 15px, style=Regular" ShadowOffset="3"
                                Text="Gender Wise" Name="Title1" ForeColor="26, 59, 105">
                            </asp:Title>
                        </Titles>
                        <Series>
                            <asp:Series Name="Default" IsValueShownAsLabel="true" 
                                Font="Lucida Grande, 10px, style=Regular" ChartType="Doughnut">
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
                                <AxisY LineColor="Black" IsLabelAutoFit="False" ArrowStyle="Triangle">
                                    <LabelStyle Font="Lucida Grande, 11px, style=Regular" Format="#" />
                                    <MajorGrid LineColor="64, 64, 64, 64" />
                                </AxisY>
                                <AxisX LineColor="Black" IsLabelAutoFit="False" ArrowStyle="Triangle" Interval="1"
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
                        BackSecondaryColor="White" BorderlineColor="180, 26, 59, 105" 
                        BorderlineWidth="2" PaletteCustomColors="Teal; SaddleBrown">
                        <Titles>
                            <asp:Title ShadowColor="32, 0, 0, 0" Font="Lucida Grande, 15px, style=Regular" ShadowOffset="3"
                                Text="Age Wise" Name="Title1" ForeColor="26, 59, 105">
                            </asp:Title>
                        </Titles>
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
                                    WallWidth="0" />
                                <AxisY LineColor="Black" IsLabelAutoFit="False" ArrowStyle="Triangle">
                                    <LabelStyle Font="Lucida Grande, 11px, style=Regular" Format="#" />
                                    <MajorGrid LineColor="64, 64, 64, 64" LineDashStyle="DashDot"/>
                                </AxisY>
                                <AxisX LineColor="Black" IsLabelAutoFit="False" ArrowStyle="Triangle" Interval="1"
                                    IntervalType="Number">
                                    <LabelStyle Font="Lucida Grande, 11px, style=Regular" IsStaggered="True" Interval="1" />
                                    <MajorGrid LineColor="64, 64, 64, 64" LineDashStyle="DashDot"/>
                                </AxisX>
                            </asp:ChartArea>
                        </ChartAreas>
                    </asp:Chart>
                </td>
                <td>
                    <asp:Chart ID="Chart4" runat="server" Width="332px" Height="277px" ImageUrl="~/TempImages/ChartPic_#SEQ(300,3)"
                        BorderlineDashStyle="Solid" BorderWidth="2px" BorderColor="#B54001" Style="margin-top: 0px"
                        Palette="None" BackImageTransparentColor="224, 224, 224" BackImageWrapMode="Scaled"
                        BackSecondaryColor="White" BorderlineColor="180, 26, 59, 105" 
                        BorderlineWidth="2" PaletteCustomColors="MenuHighlight; DarkGoldenrod">
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
                                    <MajorGrid LineColor="64, 64, 64, 64" LineDashStyle="DashDot"/>
                                </AxisY>
                                <AxisX LineColor="Black" IsLabelAutoFit="False" ArrowStyle="Triangle" Interval="1"
                                    IntervalType="Number">
                                    <LabelStyle Font="Lucida Grande, 11px, style=Regular" IsStaggered="True" Interval="1" />
                                    <MajorGrid LineColor="64, 64, 64, 64" LineDashStyle="DashDot"/>
                                </AxisX>
                            </asp:ChartArea>
                        </ChartAreas>
                    </asp:Chart>
                </td>
            </tr>
        </table>
    </div>
    </form>
    <div>
        <img src="~/images/spacer.png" height="5" width="100%" alt="" /></div>
    <div class="footercopy">
        Copyright <a href="http://www.smnetserv.com/" target="_blank" class="url">SM NetServ
            Technologies Pvt Ltd</a> 2012 - Offshore Software Development Company, India</div>
</body>
</html>
