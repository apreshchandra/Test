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
    public partial class DateWiseDrillDown : System.Web.UI.Page
    {
        AnalyticsBizProcess analyticsBiz = new AnalyticsBizProcess();
        DataSet dsAnalytics = null;
        DataTable dt = new DataTable();
        string CustomerName;
        string AppName;
        string YearMonth;
        protected void Page_Load(object sender, EventArgs e)
        {
            
            YearMonth = (String)Request.QueryString["YearMonth"];
            if (Request["CustomerName"] != null)
            {
                CustomerName = Request["CustomerName"].ToString();
            }
            if (Request["AppName"] != null)
            {
                AppName = Request["AppName"].ToString();
            }

            GetPeriodDrillDown();
        }
        public void GetPeriodDrillDown()
        {
            //IEnumerable<string> analyticDataList;
            dsAnalytics = new DataSet();
            //analyticDataList = analyticsBiz.GetPeriodDrillDown(AppName,YearMonth); 
            dsAnalytics = analyticsBiz.GetPeriodDrillDown(AppName, YearMonth);
            DataTableReader reader = dsAnalytics.CreateDataReader();
            Chart8.DataBindCrossTable(reader, "NotifierType", "YearMonth", "NotifierTypeCount", "Label=NotifierTypeCount");
            //Chart8.ChartAreas["ChartArea1"].Area3DStyle.Enable3D = true;
            //MarkerStyle marker = MarkerStyle.Square;
            foreach (Series ser in Chart8.Series)
            {
                ser.ShadowOffset = 0;
                ser.BorderWidth = 2;
                ser.ChartType = SeriesChartType.StackedBar;
                //ser.MarkerSize = 5;
                //ser.MarkerStyle = marker;
                ser.MarkerBorderColor = Color.FromArgb(64, 64, 64);
                ser.Font = new Font("Lucida Grande", 8, FontStyle.Regular);                
                //marker++;
            }
        }
        protected void vid_Click(object sender, EventArgs e)
        {
            Response.Redirect("SonetReachAnalyticsMain.aspx?CustomerName=" + CustomerName + "&AppName=" + AppName);
        }                       
    }
}