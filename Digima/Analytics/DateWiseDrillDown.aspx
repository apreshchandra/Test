<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DateWiseDrillDown.aspx.cs"
    Inherits="DigiMa.Analytics.DateWiseDrillDown" %>

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
                    <asp:Chart ID="Chart8" runat="server" Height="277px" BorderlineDashStyle="Solid"
                        BorderWidth="2px" BorderColor="#B54001" Palette="None" ImageUrl="~/TempImages/ChartPic_#SEQ(300,3)"
                        Width="974px" BorderlineColor="180, 26, 59, 105" BorderlineWidth="2" PaletteCustomColors="Highlight; 255, 128, 0; OliveDrab; 128, 64, 64">
                        <Titles>
                            <asp:Title ShadowColor="32, 0, 0, 0" Font="Lucida Grande, 15px, style=Regular" ShadowOffset="3"
                                Text="PeriodWise Actions" Name="Title1" ForeColor="26, 59, 105">
                            </asp:Title>
                        </Titles>
                        <Legends>
                            <asp:Legend TitleFont="Lucida Grande, 12px, style=Regular" BackColor="Transparent"
                                Font="Lucida Grande, 12px, style=Regular" IsTextAutoFit="false" LegendItemOrder="SameAsSeriesOrder"
                                Enabled="true">
                            </asp:Legend>
                        </Legends>
                        <%--  <Series>
                        <asp:Series Name="" ChartType="Line"></asp:Series>
                        </Series>--%>
                        <BorderSkin SkinStyle="None"></BorderSkin>
                        <ChartAreas>
                            <asp:ChartArea Name="ChartArea1" BorderColor="64, 64, 64, 64" BackSecondaryColor="White"
                                BackColor="White" ShadowColor="Transparent" BackGradientStyle="TopBottom" AlignmentOrientation="Horizontal">
                                <Area3DStyle Rotation="10" Perspective="10" Inclination="15" IsRightAngleAxes="False"
                                    WallWidth="0" IsClustered="False" />
                                <AxisY LineColor="Black" IsLabelAutoFit="False" ArrowStyle="Triangle" Title="Actions"
                                    TitleFont="Lucida Grande, 12px, style=Regular">
                                    <LabelStyle Font="Lucida Grande, 11px, style=Regular" Format="#" />
                                    <MajorGrid LineColor="64, 64, 64, 64" LineDashStyle="DashDot" />
                                </AxisY>
                                <AxisX LineColor="Black" IsLabelAutoFit="false" ArrowStyle="Triangle" Interval="1"
                                    IntervalType="Number" Title="Date" TitleFont="Lucida Grande, 12px, style=Regular">
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
    </form>
    <div>
        <img src="~/images/spacer.png" height="5" width="100%" alt="" /></div>
</body>
</html>
