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
    public partial class FromLacationgenderDrillDown : System.Web.UI.Page
    {
        AnalyticsBizProcess analyticsBiz = new AnalyticsBizProcess();
        DataSet dsAnalytics = null;
        DataTable dt = new DataTable();
        string CustomerName;
        string AppName;
        string Gender;
        string Country;
        String Count_Country;
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
            Gender = (String)Request.QueryString["Gender"];
            Country = (string)Request.QueryString["Country"];
            Count_Country = (string)Request.QueryString["Count_Country"];
           
            dsAnalytics = new DataSet();
            dsAnalytics = analyticsBiz.GetLocationDrillDown_Gender1(CustomerName, AppName, Country,Gender);          
            try
            {
                GridView1.DataSource = Cache["DsGender"] = dsAnalytics.Tables[0].DefaultView;
                GridView1.DataBind();
            }
            finally
            {
             
            }
        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            GridView1.DataSource = Cache["DsGender"];
            GridView1.DataBind();
        }
        protected void vid_Click(object sender, EventArgs e)
        {
            Response.Redirect("LocationWiseDrillDown.aspx?CustomerName=" + CustomerName + "&AppName=" + AppName +"&Country=" +Country +"&Gender=" +Gender +"&Count=" +Count_Country);
        }
        }
    }
