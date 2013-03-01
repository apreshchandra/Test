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
    public partial class LocationWiseDrillDown : System.Web.UI.Page
    {
        AnalyticsBizProcess analyticsBiz = new AnalyticsBizProcess();
        DataSet dsAnalytics = null;
        DataTable dt = new DataTable();
        string CustomerName;
        string AppName;
        string Country = "";
        string Count = "";
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
            if (this.Page.Request["Country"] != null)
            {
                Country = (String)this.Page.Request["Country"];
                Count = (string)this.Page.Request["Count"];
                Chart1.Titles[0].Text = Country; // +" - Total Actions -" + Count;
            }

            GetGetLocationDrillDown();
            /*End of LocationDrillDown_State*/
            GetLocationDrillDownGender();
            /* end of  LocationDrillDown_Gender*/

            GetLocationDrillDown_Age();
            /*End of LocationDrillDown_Age*/

            GetLocationDrillDown_Actions();
            /*End Of LocationDrillDown_NotifieType */

        }
        public void GetGetLocationDrillDown()
        {
            dsAnalytics = new DataSet();
            dsAnalytics = analyticsBiz.GetLocationDrillDown(CustomerName, AppName, Country);
            if (dsAnalytics.Tables.Count > 0)
            {
                if (dsAnalytics.Tables[0].Rows.Count > 0)
                {
                    int statecount = dsAnalytics.Tables[0].Rows.Count;
                    for (int i = 0; i < statecount; i++)
                    {
                        Chart1.Series["Series1"].Points.AddXY(dsAnalytics.Tables[0].Rows[i]["State"], dsAnalytics.Tables[0].Rows[i]["Count"]);                        
                        UpdateAttrib1();
                    }
                }
            }

        }
        public void GetLocationDrillDownGender()
        {
            dsAnalytics = new DataSet();
            dsAnalytics = analyticsBiz.GetLocationDrillDownGender(CustomerName, AppName, Country);
            {
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
        }
        public void GetLocationDrillDown_Age()
        {            
            dsAnalytics = new DataSet();
            dsAnalytics = analyticsBiz.GetLocationDrillDown_Age(CustomerName, AppName, Country);
            DataTableReader reader = dsAnalytics.CreateDataReader();
            //Chart3.DataBindCrossTable(reader, "Gender", "Age", "NotifierTypeCount", "Label=NotifierTypeCount");
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
        public void GetLocationDrillDown_Actions()
        {
          //  IEnumerable<string> analyticDataList;
            dsAnalytics = new DataSet();
            dsAnalytics = analyticsBiz.GetLocationDrillDown_Actions(CustomerName, AppName, Country);
            DataTableReader reader = dsAnalytics.CreateDataReader();
            Chart4.DataBindCrossTable(reader, "Gender", "NotifierType", "NotifierTypeCount", "Label=NotifierTypeCount");

            GenderDrill();
        }
        public void UpdateAttrib1()
        {

            // Set series tooltips
            foreach (Series series in Chart1.Series)
            {
                for (int pointIndex = 0; pointIndex < series.Points.Count; pointIndex++)
                {
                    //string toolTip = "";

                    //toolTip = "<img src=LocationWiseToolTip1.aspx?State=" + series.Points[pointIndex].AxisLabel+ " />";
                    //series.Points[pointIndex].MapAreaAttributes = "onmouseover=\"DisplayTooltip('" + toolTip + "');\" onmouseout=\"DisplayTooltip('');\"";
                    series.Points[pointIndex].Url = "LocationWiseDrillDown1.aspx?State=" + series.Points[pointIndex].AxisLabel + "&Count=" + series.Points[pointIndex].YValues[0] + "&AppName=" + AppName + "&CustomerName=" + CustomerName +"&Country="+Country+"&Count_Country="+Count;
                }
            }


        }
        public void GenderDrill()
        {
            foreach (Series series in Chart2.Series)
            {
                for (int pointIndex = 0; pointIndex < series.Points.Count; pointIndex++)
                {
                    series.Points[pointIndex].Url = "FromLacationgenderDrillDown.aspx?Gender=" + series.Points[pointIndex].AxisLabel + "&Country=" + Request.QueryString["Country"] + "&AppName=" + AppName + "&CustomerName=" + CustomerName + "&Count_Country=" + Count;
                }
            }
        }
        protected void Back_Click(object sender, EventArgs e)
        {
            Response.Redirect("SonetReachAnalyticsMain.aspx?CustomerName=" + CustomerName + "&AppName=" + AppName);
        }


        protected void vid_Click(object sender, EventArgs e)
        {
            Response.Redirect("SonetReachAnalyticsMain.aspx?CustomerName=" + CustomerName + "&AppName=" + AppName);
        }
    }
}