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
    public partial class LevelsDrillDown : System.Web.UI.Page
    {
        AnalyticsBizProcess analyticsBiz = new AnalyticsBizProcess();
        DataSet dsAnalytics = null;
        DataTable dt = new DataTable();
        string CustomerName;
        string AppName; 
        int Level;
        string Count;
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
            Level =Convert.ToInt32(Request.QueryString["Level"]);
            Count = (string)Request.QueryString["Count"];
            lbllevels.Text = "Level - " + Level + " Actions";


            GetLevelsDrillDown_Actions();        
            /*end of LevelsDrillDown_Actions*/

            GetLevelsDrillDown_Gender();
            /*End of LevelsDrillDown_Gender*/

            GetLevelsDrillDown_Location();
            /*end of LevelsDrillDown_Location*/

            GetLevelsDrillDown_Age();           
            /*End of LevelsDrillDown_Age*/
        }
       public void GetLevelsDrillDown_Actions()
       {
           dsAnalytics = new DataSet();
           dsAnalytics=analyticsBiz.GetLevelsDrillDown_Actions(AppName,Level);
           if (dsAnalytics.Tables.Count > 0)
           {
               if (dsAnalytics.Tables[0].Rows.Count > 0)
               {
                   int Notcount = dsAnalytics.Tables[0].Rows.Count;
                   for (int i = 0; i < Notcount; i++)
                   {
                       Chart1.Series["Default"].Points.AddXY(dsAnalytics.Tables[0].Rows[i]["NotifierType"], dsAnalytics.Tables[0].Rows[i]["NotifierCount"]);
                       Chart1.Series["Default"].IsValueShownAsLabel = true;
                       Chart1.Titles[0].Text = "Notification Wise";
                   }
               }
           }

       }
       public void GetLevelsDrillDown_Gender()
       {
           dsAnalytics = new DataSet();
           dsAnalytics = analyticsBiz.GetLevelsDrillDown_Gender(AppName, Level);
           if (dsAnalytics.Tables.Count > 0)
           {
               if (dsAnalytics.Tables[0].Rows.Count > 0)
               {
                   int gencount = dsAnalytics.Tables[0].Rows.Count;
                   for (int i = 0; i < gencount; i++)
                   {
                       Chart2.Series["Default"].Points.AddXY(dsAnalytics.Tables[0].Rows[i]["Gender"], dsAnalytics.Tables[0].Rows[i]["NotifierCount"]);
                       Chart2.Series["Default"].IsValueShownAsLabel = true;
                       Chart2.Titles[0].Text = "Gender Wise";
                   }
               }
           }

       }
       public void GetLevelsDrillDown_Location()
       {
           dsAnalytics = new DataSet();
           dsAnalytics = analyticsBiz.GetLevelsDrillDown_Location(AppName, Level);
           if (dsAnalytics.Tables.Count > 0)
           {
               if (dsAnalytics.Tables[0].Rows.Count > 0)
               {
                   int loccount = dsAnalytics.Tables[0].Rows.Count;
                   for (int i = 0; i < loccount; i++)
                   {
                       Chart3.Series["Default"].Points.AddXY(dsAnalytics.Tables[0].Rows[i]["City1"], dsAnalytics.Tables[0].Rows[i]["NotifierCount"]);
                       Chart3.Series["Default"].IsValueShownAsLabel = true;
                       Chart3.Titles[0].Text = "Location Wise";
                   }
               }
           }

       }
       public void GetLevelsDrillDown_Age()
       {
           dsAnalytics = new DataSet();
           dsAnalytics = analyticsBiz.GetLevelsDrillDown_Age(AppName, Level);
           if (dsAnalytics.Tables.Count > 0)
           {
               if (dsAnalytics.Tables[0].Rows.Count > 0)
               {
                   int agecount = dsAnalytics.Tables[0].Rows.Count;
                   for(int i=0;i<agecount;i++)
                   {
                       Chart4.Series["Default"].Points.AddXY(dsAnalytics.Tables[0].Rows[i]["Age"], dsAnalytics.Tables[0].Rows[i]["Count"]);
                       Chart4.Series["Default"].IsValueShownAsLabel = true;
                       Chart4.Titles[0].Text = "Age Wise";
                   }
               }
           }

       }
       protected void vid_Click(object sender, EventArgs e)
       {
           Response.Redirect("SonetReachAnalyticsMain.aspx?CustomerName=" + CustomerName + "&AppName=" + AppName);
       }
    }
}