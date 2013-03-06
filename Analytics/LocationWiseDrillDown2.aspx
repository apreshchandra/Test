<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LocationWiseDrillDown2.aspx.cs"
    Inherits="DigiMa.Analytics.LocationWiseDrillDown2" %>

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
            <%--<a href="#" class="backlink" onclick="Back_Click" runat="server">Back</a></div>--%>
            <asp:LinkButton ID="lnkBack" runat="server" Text="Back" OnClick="vid_Click" CssClass="backlink"></asp:LinkButton></div>
        <table align="center">
            <tr align="center" style="background-color: White">
                <td>
                </td>
                <td align="center">
                    <asp:Label ID="lblheader" runat="server" ForeColor="#1A3B69" 
                        Font-Size="15px" Font-Names="Lucida Grande" Font-Bold="True"></asp:Label>
                </td>
                <td>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Chart ID="Chart2" runat="server" Width="332px" Height="277px" ImageUrl="~/TempImages/ChartPic_#SEQ(300,3)"
                        BorderlineDashStyle="Solid" BorderWidth="2px" BorderColor="#B54001" Style="margin-top: 0px"
                        Palette="None" BackImageTransparentColor="224, 224, 224" BackImageWrapMode="Scaled"
                        BackSecondaryColor="White" BorderlineColor="180, 26, 59, 105" 
                        BorderlineWidth="2" PaletteCustomColors="242, 160, 32; RoyalBlue">
                        <Series>
                            <asp:Series Name="Default" IsValueShownAsLabel="True" 
                                Font="Lucida Grande, 11px" ChartArea="ChartArea1" Legend="Legend1" 
                                ChartType="Doughnut">
                            </asp:Series>
                        </Series>
                        <ChartAreas>
                            <asp:ChartArea Name="ChartArea1" BorderColor="" BackColor="White" ShadowColor="Transparent"
                                BackGradientStyle="TopBottom" AlignmentOrientation="Horizontal">
                                <AxisY ArrowStyle="Triangle" IsLabelAutoFit="False" LineColor="64, 64, 64, 64">
                                    <MajorGrid LineColor="64, 64, 64, 64" />
                                    <LabelStyle Font="Lucida Grande, 11px" Format="#" />
                                </AxisY>
                                <AxisX ArrowStyle="Triangle" Interval="1" IntervalType="Number" 
                                    IsLabelAutoFit="False" LineColor="64, 64, 64, 64">
                                    <MajorGrid LineColor="64, 64, 64, 64" />
                                    <LabelStyle Font="Lucida Grande, 11px" Interval="1" IsStaggered="True" />
                                </AxisX>
                                <Area3DStyle Rotation="10" Perspective="10" Inclination="15" IsRightAngleAxes="False"
                                    WallWidth="0" />
                            </asp:ChartArea>
                        </ChartAreas>
                        <Legends>
                            <asp:Legend BackColor="Transparent" Font="Lucida Grande, 12px" 
                                IsTextAutoFit="False" Name="Legend1">
                            </asp:Legend>
                        </Legends>
                        <Titles>
                            <asp:Title Font="Lucida Grande, 15px" ForeColor="26, 59, 105" Name="Title1" 
                                ShadowColor="32, 0, 0, 0" ShadowOffset="3" Text="GenderWise">
                            </asp:Title>
                        </Titles>
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
                                Text="AgeWise" Name="Title1" ForeColor="26, 59, 105">
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
                                <AxisY LineColor="64, 64, 64, 64" IsLabelAutoFit="False" ArrowStyle="Triangle">
                                    <LabelStyle Font="Lucida Grande, 11px, style=Regular" Format="#" />
                                    <MajorGrid LineColor="64, 64, 64, 64" LineDashStyle="DashDot"/>
                                </AxisY>
                                <AxisX LineColor="64, 64, 64, 64" IsLabelAutoFit="False" ArrowStyle="Triangle" Interval="1"
                                    IntervalType="Number">
                                    <LabelStyle Font="Lucida Grande, 11px, style=Regular" IsStaggered="True" Interval="1" />
                                    <MajorGrid LineColor="64, 64, 64, 64" LineDashStyle="DashDot" />
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
                                Text="NotificationsWise" Name="Title1" ForeColor="26, 59, 105">
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
                                <AxisY LineColor="64, 64, 64, 64" IsLabelAutoFit="False" ArrowStyle="Triangle">
                                    <LabelStyle Font="Lucida Grande, 11px, style=Regular" Format="#" />
                                    <MajorGrid LineColor="64, 64, 64, 64" LineDashStyle="DashDot"/>
                                </AxisY>
                                <AxisX LineColor="64, 64, 64, 64" IsLabelAutoFit="False" ArrowStyle="Triangle" Interval="1"
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
