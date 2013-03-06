using System;
using System.Collections;
using System.Collections.Generic;
using DigiMa.BizProcess;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Drawing.Imaging;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.IO;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Web.UI.DataVisualization.Charting;
using System.Data.SqlClient;
using System.Text;
using System.Net;
using System.Net.Mail;
using System.Configuration;
using System.Web.UI.DataVisualization.Charting.Utilities;
using DigiMa.Data;

namespace DigiMa.Analytics
{
    public partial class LocationWiseDrillDown1 : System.Web.UI.Page
    {
        AnalyticsBizProcess analyticsBiz = new AnalyticsBizProcess();
        DataSet dsAnalytics = null;
        DataTable dt = new DataTable();
        string CustomerName;
        string AppName;
        String State="";
        string Count="";
        String Country="";
        string Count_Country="";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request["CustomerName"] != null)
            {
                CustomerName = Request["CustomerName"].ToString();
            }
            if (Request["AppName"] != null)
            {
                AppName = Request["AppName"].ToString();
            }
            if (this.Page.Request["State"] != null)
            {
                State = ((String)this.Page.Request["State"]);
                Count = (string)this.Page.Request["Count"];
                Country = ((string)this.Page.Request["Country"]);
                Count_Country = ((string)this.Page.Request["Count_Country"]);
                Chart1.Titles[0].Text = State; // +" - Total Actions -" + Count;
            }

            GetLocationDrillDown1_City();
            /*End of LocationDrillDown1_City*/
            GetLocationDrillDown1_Gender();
            /*End of LocationDrillDown1_Gender*/
            GetLocationDrillDown1_Age();
            /*End Of LocationDrillDown1_Age*/
            GetLocationDrillDown1_Actions();
            /*End of LocationDrillDown1_Actions*/
        
        }
        public void GetLocationDrillDown1_City()
        {
            dsAnalytics = new DataSet();
            dsAnalytics = analyticsBiz.GetLocationDrillDown1_City(CustomerName, AppName, State);
            if (dsAnalytics.Tables.Count > 0)
            {
                if (dsAnalytics.Tables[0].Rows.Count > 0)
                {
                    int cityCount = dsAnalytics.Tables[0].Rows.Count;
                    for (int i = 0; i < cityCount; i++)
                    {
                        Chart1.Series["Series1"].Points.AddXY(dsAnalytics.Tables[0].Rows[i]["City"], dsAnalytics.Tables[0].Rows[i]["Count"]);
                        //Chart1.Series["Series1"].MarkerStyle = MarkerStyle.Star10;
                        //Chart1.Series["Series1"].MarkerSize = 8;
                        //Chart1.Series["Series1"].MarkerColor = Color.Magenta;
                        CityDrilDown();
                    }
                }
            }
        }
        public void GetLocationDrillDown1_Gender()
        {
            dsAnalytics = new DataSet();
            dsAnalytics = analyticsBiz.GetLocationDrillDown1_Gender(CustomerName, AppName, State);
            if (dsAnalytics.Tables.Count > 0)
            {
                if (dsAnalytics.Tables[0].Rows.Count > 0)
                {
                    int gendercount = dsAnalytics.Tables[0].Rows.Count;
                    for (int i = 0; i < gendercount; i++)
                    {
                        Chart2.Series["Default"].Points.AddXY(dsAnalytics.Tables[0].Rows[i]["Gender"], dsAnalytics.Tables[0].Rows[i]["NotifierTypeCount"]);
                        Chart2.Series["Default"].ChartType = SeriesChartType.Doughnut;
                        GenderDrill();
                    }
                }
            }
        }
        public void GetLocationDrillDown1_Age()
        {
            //IEnumerable<string> analyticDataList;
            dsAnalytics = new DataSet();
            dsAnalytics = analyticsBiz.GetLocationDrillDown1_Age(CustomerName, AppName, State);
            DataTableReader reader = dsAnalytics.CreateDataReader();
            Chart3.DataBindCrossTable(reader, "Gender", "Age", "NotifierTypeCount", "Label=NotifierTypeCount");
            foreach (Series ser in Chart3.Series)
            {
                ser.ShadowOffset = 0;
                ser.BorderWidth = 2;

                ser.ChartType = SeriesChartType.StackedColumn;

                //ser.MarkerSize = 5;
                //ser.MarkerStyle = marker;
                ser.MarkerBorderColor = Color.FromArgb(64, 64, 64);
                ser.Font = new Font("Lucida Grande", 8, FontStyle.Regular);
                //marker++;
            }
            GenderDrill();

        }
        public void GetLocationDrillDown1_Actions()
        {
            //IEnumerable<string> analyticDataList;
            dsAnalytics = new DataSet();
            dsAnalytics = analyticsBiz.GetLocationDrillDown1_Actions(CustomerName, AppName, State);
            DataTableReader reader=dsAnalytics.CreateDataReader();
            Chart4.DataBindCrossTable(reader, "Gender", "NotifierType", "NotifierTypeCount", "Label=NotifierTypeCount");
            GenderDrill();
        }

        public void GenderDrill()
        {
            foreach (Series series in Chart2.Series)
            {
                for (int pointIndex = 0; pointIndex < series.Points.Count; pointIndex++)
                {
                    series.Points[pointIndex].Url = "FromLocationgenderDrillDown1.aspx?Gender=" + series.Points[pointIndex].AxisLabel + "&State=" + Request.QueryString["State"] + "&AppName=" + AppName + "&CustomerName=" + CustomerName + "&Count_State=" + Count + "&Country=" + Country + "&Count_Country=" + Count_Country;
                }
            }
        }
        public void CityDrilDown()
        {
            foreach (Series series in Chart1.Series)
            {
                for (int pointIndex = 0; pointIndex < series.Points.Count; pointIndex++)
                {
                    series.Points[pointIndex].Url = "LocationWiseDrillDown2.aspx?City=" + series.Points[pointIndex].AxisLabel + "&Count=" + series.Points[pointIndex].YValues[0] + "&AppName=" + AppName + "&CustomerName=" + CustomerName + "&State=" + State + "&Count_State=" + Count + "&Country=" + Country + "&Count_Country=" + Count_Country;
                }
            }
        }
        protected void vid_Click(object sender, EventArgs e)
        {
            Response.Redirect("LocationWiseDrillDown.aspx?CustomerName=" + CustomerName + "&AppName=" + AppName +"&State="+State+"&Country=" + Country + "&Count="+ Count_Country);
            //series.Points[pointIndex].Url = "LocationWiseDrillDown1.aspx?State=" + series.Points[pointIndex].AxisLabel + "&Count=" + series.Points[pointIndex].YValues[0] + "&AppName=" + AppName + "&CustomerName=" + CustomerName;
            //series.Points[pointIndex].Url = "LocationWiseDrillDown.aspx?Country=" + series.Points[pointIndex].AxisLabel + "&Count=" + series.Points[pointIndex].YValues[0] + "&AppName=" + AppName + "&CustomerName=" + CustomerName;

        }
    }
}