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
    public partial class LocationWiseDrillDown2 : System.Web.UI.Page
    {
        AnalyticsBizProcess analyticsBiz = new AnalyticsBizProcess();
        DataSet dsAnalytics = null;
        DataTable dt = new DataTable();
        string CustomerName;
        string AppName;
        String City = "";
        string Count = "";
        string State = "";
        string Count_State = "";
        string Country = "";
        string Count_Country = "";
        protected void Page_Load(object sender, EventArgs e)
        {

            City = ((String)Request.QueryString["City"]);
            Count = (string)Request.QueryString["Count"];
            State = (String)Request.QueryString["State"];
            Count_State = (String)Request.QueryString["Count_State"];
            Country = (string)Request.QueryString["Country"];
            Count_Country = (string)Request.QueryString["Count_Country"];
            if (Request["CustomerName"] != null)
            {
                CustomerName = Request["CustomerName"].ToString();
            }
            if (Request["AppName"] != null)
            {
                AppName = Request["AppName"].ToString();
            }
            lblheader.Text = City; // +"- Total Actions : " + Count;


            GetLocationDrillDown2_Gender();
            /*end of LocationDrillDown2_Gender*/

            GetLocationDrillDown2_Age();
            /*end of LocationDrillDown2_Age*/

            GetLocationDrillDown2_Actions();          
            
            /*end of LocationDrillDown2_Actions*/

        }
        public void GetLocationDrillDown2_Gender()
        {
            dsAnalytics = new DataSet();
            dsAnalytics = analyticsBiz.GetLocationDrillDown2_Gender(CustomerName, AppName, City);
            if (dsAnalytics.Tables.Count > 0)
            {
                if (dsAnalytics.Tables[0].Rows.Count > 0)
                {
                    int gendercount = dsAnalytics.Tables[0].Rows.Count;
                    for (int i = 0; i < gendercount; i++)
                    {
                        Chart2.Series["Default"].Points.AddXY(dsAnalytics.Tables[0].Rows[i]["Gender"], dsAnalytics.Tables[0].Rows[i]["NotifierTypeCount"]);
                        Chart2.Series["Default"].ChartType = SeriesChartType.Doughnut;
                        Chart2.Titles[0].Text = "Gender Wise"; //:" + City + " - Total Actions -" + Count;
                        GenderDrill();
                    }
                }
            }
        }
        public void GetLocationDrillDown2_Age()
        {
           // IEnumerable<string> analyticDataList;
            dsAnalytics = new DataSet();
            dsAnalytics = analyticsBiz.GetLocationDrillDown2_Age(CustomerName, AppName, City);
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
            Chart3.Titles[0].Text = "Age Wise"; // :" + City + " - Total Actions -" + Count;
        }
        public void GetLocationDrillDown2_Actions()
        {
           // IEnumerable<string> analyticDataList;
            dsAnalytics = new DataSet();
            dsAnalytics = analyticsBiz.GetLocationDrillDown2_Actions(CustomerName, AppName, City);
            DataTableReader reader = dsAnalytics.CreateDataReader();
            Chart4.DataBindCrossTable(reader, "Gender", "NotifierType", "NotifierTypeCount", "Label=NotifierTypeCount");
            GenderDrill();
            Chart4.Titles[0].Text = "Notification Wise"; // :" + City + " - Total Actions -" + Count;
        }
        public void GenderDrill()
        {
            foreach (Series series in Chart2.Series)
            {
                for (int pointIndex = 0; pointIndex < series.Points.Count; pointIndex++)
                {
                    series.Points[pointIndex].Url = "FromLacationgenderDrillDown2.aspx?Gender=" + series.Points[pointIndex].AxisLabel + "&City=" + Request.QueryString["City"] + "&AppName=" + AppName + "&CustomerName=" + CustomerName + "&State=" + State + "&Count_State=" + Count_State + "&Count_Country=" + Count_Country + "&Country=" + Country+"&Count="+Count;
                }
            }
        }
        protected void vid_Click(object sender, EventArgs e)
        {
            Response.Redirect("LocationWiseDrillDown1.aspx?CustomerName=" + CustomerName + "&AppName=" + AppName + "&City=" + City + "&State=" + State + "&Count=" + Count_State+"&Count_Country="+Count_Country+"&Country="+Country);
        }
    }
}