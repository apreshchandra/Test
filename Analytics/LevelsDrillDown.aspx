<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LevelsDrillDown.aspx.cs"
    Inherits="DigiMa.Analytics.LevelsDrillDown" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="stylesheet" type="text/css" href="~/Styles/master_style.css" />
    <style type="text/css">
        .style1
        {
            width: 301px;
        }
        
    </style>
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
            <tr>
                <td>
                </td>
                <td align="center" style="background-color: White">
                    <asp:Label ID="lbllevels" runat="server" Font-Bold="true" ForeColor="26, 59, 105"
                        Font-Size="18px"></asp:Label>
                </td>
                <td>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Chart ID="Chart1" runat="server" Height="277px" BorderlineDashStyle="Solid"
                        BorderWidth="2px" BorderColor="#B54001" Palette="None" ImageUrl="~/TempImages/ChartPic_#SEQ(300,3)"
                        Width="320px" BorderlineColor="Coral" BorderlineWidth="2" PaletteCustomColors="0, 183, 74;118, 8, 170; 219, 80, 136; 242, 160, 32">
                        <Titles>
                            <asp:Title ShadowColor="32, 0, 0, 0" Font="Lucida Grande, 15px, style=Regular" ShadowOffset="3"
                                Name="Title1" ForeColor="26, 59, 105">
                            </asp:Title>
                        </Titles>
                        <Legends>
                            <asp:Legend TitleFont="Lucida Grande, 12px, style=Regular" BackColor="Transparent"
                                Font="Lucida Grande, 12px, style=Regular" IsTextAutoFit="false" LegendItemOrder="SameAsSeriesOrder"
                                Enabled="false">
                            </asp:Legend>
                        </Legends>
                        <Series>
                            <asp:Series Name="Default" IsValueShownAsLabel="true" Font="Lucida Grande, 12px, style=Regular">
                            </asp:Series>
                        </Series>
                        <BorderSkin SkinStyle="None"></BorderSkin>
                        <ChartAreas>
                            <asp:ChartArea Name="ChartArea1" BorderColor="64, 64, 64, 64" BackSecondaryColor="White"
                                BackColor="White" ShadowColor="Transparent" BackGradientStyle="TopBottom" AlignmentOrientation="Horizontal">
                                <Area3DStyle Rotation="10" Perspective="10" Inclination="15" IsRightAngleAxes="False"
                                    WallWidth="0" IsClustered="False" />
                                <AxisY LineColor="64, 64, 64, 64" IsLabelAutoFit="False" ArrowStyle="Triangle" TitleFont="Lucida Grande, 15px, style=Regular">
                                    <LabelStyle Font="Lucida Grande, 11px, style=Regular" Format="#" />
                                    <MajorGrid LineColor="64, 64, 64, 64" LineDashStyle="DashDot"/>
                                </AxisY>
                                <AxisX LineColor="64, 64, 64, 64" IsLabelAutoFit="false" ArrowStyle="Triangle" Interval="1"
                                    IntervalType="Number" TitleFont="Lucida Grande, 11px, style=Regular">
                                    <LabelStyle Font="Lucida Grande, 11px, style=Regular" IsStaggered="True" Interval="1" />
                                    <MajorGrid LineColor="64, 64, 64, 64" LineDashStyle="DashDot"/>
                                </AxisX>
                            </asp:ChartArea>
                        </ChartAreas>
                    </asp:Chart>
                </td>
                <td>
                    <asp:Chart ID="Chart2" runat="server" Height="277px" BorderlineDashStyle="Solid"
                        BorderWidth="2px" BorderColor="#B54001" Palette="None" ImageUrl="~/TempImages/ChartPic_#SEQ(300,3)"
                        Width="320px" BorderlineColor="Coral" BorderlineWidth="2" 
                        PaletteCustomColors="219, 80, 136; 0, 183, 74; 118, 8, 170; 242, 160, 32">
                        <Titles>
                            <asp:Title ShadowColor="32, 0, 0, 0" Font="Lucida Grande, 15px, style=Regular" ShadowOffset="3"
                                Name="Title1" ForeColor="26, 59, 105">
                            </asp:Title>
                        </Titles>
                        <Legends>
                            <asp:Legend TitleFont="Lucida Grande, 12px, style=Regular" BackColor="Transparent"
                                Font="Lucida Grande, 12px, style=Regular" IsTextAutoFit="false" LegendItemOrder="SameAsSeriesOrder"
                                Enabled="false">
                            </asp:Legend>
                        </Legends>
                        <Series>
                            <asp:Series Name="Default" IsValueShownAsLabel="true" Font="Lucida Grande, 12px, style=Regular">
                            </asp:Series>
                        </Series>
                        <BorderSkin SkinStyle="None"></BorderSkin>
                        <ChartAreas>
                            <asp:ChartArea Name="ChartArea1" BorderColor="64, 64, 64, 64" BackSecondaryColor="White"
                                BackColor="White" ShadowColor="Transparent" BackGradientStyle="TopBottom" AlignmentOrientation="Horizontal">
                                <Area3DStyle Rotation="10" Perspective="10" Inclination="15" IsRightAngleAxes="False"
                                    WallWidth="0" IsClustered="False" />
                                <AxisY LineColor="64, 64, 64, 64" IsLabelAutoFit="False" ArrowStyle="Triangle" TitleFont="Lucida Grande, 11px, style=Regular">
                                    <LabelStyle Font="Lucida Grande, 11px, style=Regular" Format="#" />
                                    <MajorGrid LineColor="64, 64, 64, 64" LineDashStyle="DashDot" />
                                </AxisY>
                                <AxisX LineColor="64, 64, 64, 64" IsLabelAutoFit="false" ArrowStyle="Triangle" Interval="1"
                                    IntervalType="Number" TitleFont="Lucida Grande, 11px, style=Regular">
                                    <LabelStyle Font="Lucida Grande, 11px, style=Regular" IsStaggered="True" Interval="1" />
                                    <MajorGrid LineColor="64, 64, 64, 64" LineDashStyle="DashDot" />
                                </AxisX>
                            </asp:ChartArea>
                        </ChartAreas>
                    </asp:Chart>
                </td>
                <td>
                    <asp:Chart ID="Chart4" runat="server" Height="277px" BorderlineDashStyle="Solid"
                        BorderWidth="2px" BorderColor="#B54001" Palette="None" ImageUrl="~/TempImages/ChartPic_#SEQ(300,3)"
                        Width="320px" BorderlineColor="Coral" BorderlineWidth="2" 
                        PaletteCustomColors="MenuHighlight; 118, 8, 170; 219, 80, 136; 242, 160, 32">
                        <Titles>
                            <asp:Title ShadowColor="32, 0, 0, 0" Font="Lucida Grande, 15px, style=Regular" ShadowOffset="3"
                                Name="Title1" ForeColor="26, 59, 105">
                            </asp:Title>
                        </Titles>
                        <Legends>
                            <asp:Legend TitleFont="Lucida Grande, 15px, style=Regular" BackColor="Transparent"
                                Font="Lucida Grande, 12px, style=Regular" IsTextAutoFit="false" LegendItemOrder="SameAsSeriesOrder"
                                Enabled="false">
                            </asp:Legend>
                        </Legends>
                        <Series>
                            <asp:Series Name="Default" IsValueShownAsLabel="true" Font="Lucida Grande, 12px, style=Regular">
                            </asp:Series>
                        </Series>
                        <BorderSkin SkinStyle="None"></BorderSkin>
                        <ChartAreas>
                            <asp:ChartArea Name="ChartArea1" BorderColor="64, 64, 64, 64" BackSecondaryColor="White"
                                BackColor="White" ShadowColor="Transparent" BackGradientStyle="TopBottom" AlignmentOrientation="Horizontal">
                                <Area3DStyle Rotation="10" Perspective="10" Inclination="15" IsRightAngleAxes="False"
                                    WallWidth="0" IsClustered="False" />
                                <AxisY LineColor="64, 64, 64, 64" IsLabelAutoFit="False" ArrowStyle="Triangle" TitleFont="Lucida Grande, 11px, style=Regular">
                                    <LabelStyle Font="Lucida Grande, 11px, style=Regular" Format="#" />
                                    <MajorGrid LineColor="64, 64, 64, 64" LineDashStyle="DashDot"/>
                                </AxisY>
                                <AxisX LineColor="64, 64, 64, 64" IsLabelAutoFit="false" ArrowStyle="Triangle" Interval="1"
                                    IntervalType="Number" TitleFont="Lucida Grande, 11px, style=Regular">
                                    <LabelStyle Font="Lucida Grande, 11px, style=Regular" IsStaggered="True" Interval="1" />
                                    <MajorGrid LineColor="64, 64, 64, 64" LineDashStyle="DashDot"/>
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
                    <asp:Chart ID="Chart3" runat="server" Height="277px" BorderlineDashStyle="Solid"
                        BorderWidth="2px" BorderColor="#B54001" Palette="None" ImageUrl="~/TempImages/ChartPic_#SEQ(300,3)"
                        Width="974px" BorderlineColor="Coral" BorderlineWidth="2" 
                        PaletteCustomColors="242, 160, 32; 0, 183, 74; 118, 8, 170; 219, 80, 136">
                        <Titles>
                            <asp:Title ShadowColor="32, 0, 0, 0" Font="Lucida Grande, 15px, style=Regular" ShadowOffset="3"
                                Name="Title1" ForeColor="26, 59, 105">
                            </asp:Title>
                        </Titles>
                        <Legends>
                            <asp:Legend TitleFont="Lucida Grande, 12px, style=Regular" BackColor="Transparent"
                                Font="Lucida Grande, 12px, style=Regular" IsTextAutoFit="false" LegendItemOrder="SameAsSeriesOrder"
                                Enabled="false">
                            </asp:Legend>
                        </Legends>
                        <Series>
                            <asp:Series Name="Default" IsValueShownAsLabel="true" Font="Lucida Grande, 12px, style=Regular">
                            </asp:Series>
                        </Series>
                        <BorderSkin SkinStyle="None"></BorderSkin>
                        <ChartAreas>
                            <asp:ChartArea Name="ChartArea1" BorderColor="64, 64, 64, 64" BackSecondaryColor="White"
                                BackColor="White" ShadowColor="Transparent" BackGradientStyle="TopBottom" AlignmentOrientation="Horizontal">
                                <Area3DStyle Rotation="10" Perspective="10" Inclination="15" IsRightAngleAxes="False"
                                    WallWidth="0" IsClustered="False" />
                                <AxisY LineColor="64, 64, 64, 64" IsLabelAutoFit="False" ArrowStyle="Triangle" TitleFont="Lucida Grande, 11px, style=Regular">
                                    <LabelStyle Font="Lucida Grande, 11px, style=Regular" Format="#" />
                                    <MajorGrid LineColor="64, 64, 64, 64" LineDashStyle="DashDot"/>
                                </AxisY>
                                <AxisX LineColor="64, 64, 64, 64" IsLabelAutoFit="false" ArrowStyle="Triangle" Interval="1"
                                    IntervalType="Number" TitleFont="Lucida Grande, 11px, style=Regular">
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
