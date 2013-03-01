using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using DigiMa.DataAccess;
using System.Data;
using DigiMa.Data;
using System.Web.UI.HtmlControls;
using DigiMa.BizProcess;
using System.Collections;
using DigiMa.Common;

namespace DigiMa
{

    public partial class Dashboard : BaseClass
    {
        //GridView grdUnCompletedSites = new GridView();
        //GridView grdCompletedSites = new GridView();
        //HtmlTable tblFinishedSites = new HtmlTable();
        //HtmlTable tblCreateSite = new HtmlTable();
        //CanvasBizProcess canvBiz = null;
        //GridView grdAnalytics = new GridView();

        //protected override void OnPreInit(EventArgs e)
        //{
        //    base.OnPreInit(e);
        //}
        //UserDetails oUserDetails = new UserDetails();

        //protected void Page_Load(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        //throw new System.InvalidOperationException("Logfile cannot be read-only"); 
        //        oUserDetails = (UserDetails)Session["UserData"];

        //        ExecutePermissions();
        //        //BindTemplatesLibraryList();
        //        if (!IsPostBack)
        //        {
        //            BindGrids();
        //            canvBiz = new CanvasBizProcess();
        //            grdAnalytics.DataSource = canvBiz.FetchConfigDataForLoggedInUser(SessionData.Customer.CustomerID);
        //            grdAnalytics.DataBind();
        //        }
        //    }
        //    catch (Exception ex)
        //    {

        //    }
        //}

        //private void BindGrids()
        //{
        //    try
        //    {
        //        string strConnection = System.Configuration.ConfigurationSettings.AppSettings["WebHut"];
        //        DataSet dsUnCompletedSites = new DataSet();
        //        string Query = "select s.SiteId,s.SiteName,t.TemplateName,s.FolderPath,'Popup/AssignTo.aspx?SiteId='+convert(varchar,s.SiteId) as AssignTo,'DownloadSite.ashx?SiteId='+convert(varchar,s.SiteId) DownloadWay,s.FolderPathFinal+'/'+isnull(s.DefaultPage,'') as PreviewPath, 'PageEditor.aspx?SiteId='+convert(varchar,s.SiteId) as TemplateEditPath from Sites s inner join Templates t on s.TemplateID=t.TemplatesId where UserId=" + oUserDetails.UserID + " and Status='P'"; //'U'  for uncompleted 
        //        SqlHelper.FillDataset(strConnection, CommandType.Text, Query, dsUnCompletedSites, new string[] { "UnCompletedSites" });


        //        grdUnCompletedSites.DataSource = dsUnCompletedSites.Tables["UnCompletedSites"];
        //        grdUnCompletedSites.DataBind();


        //        DataSet dsCompletedSites = new DataSet();
        //        Query = "select s.SiteId,s.SiteName,t.TemplateName,'DownloadSite.ashx?SiteId='+convert(varchar,s.SiteId) DownloadWay,s.FolderPathFinal+'/'+isnull(s.DefaultPage,'') as PreviewPath from Sites s inner join Templates t on s.TemplateID=t.TemplatesId where UserId=" + oUserDetails.UserID + " and Status='F'";
        //        SqlHelper.FillDataset(strConnection, CommandType.Text, Query, dsCompletedSites, new string[] { "UnCompletedSites" });


        //        grdCompletedSites.DataSource = dsCompletedSites.Tables["UnCompletedSites"];
        //        grdCompletedSites.DataBind();
        //    }
        //    catch (Exception ex)
        //    {

        //    }

        //}

        //protected void grdUnCompletedSites_RowCommand(object sender, GridViewCommandEventArgs e)
        //{
        //    try
        //    {
        //        if (e.CommandName.ToUpper() == "DELETESITE")
        //        {
        //            int SiteId = int.Parse(((LinkButton)e.CommandSource).ValidationGroup.ToString());

        //            string strConnection = System.Configuration.ConfigurationSettings.AppSettings["WebHut"];
        //            DataSet dsTemplates = new DataSet();
        //            string Query = "Update Sites set Status='D' where SiteId=" + SiteId + " and UserId=" + oUserDetails.UserID;
        //            SqlHelper.ExecuteNonQuery(strConnection, CommandType.Text, Query);

        //            BindGrids();
        //        }
        //        if (e.CommandName.ToUpper() == "FINISHSITE")
        //        {
        //            int SiteId = int.Parse(((LinkButton)e.CommandSource).ValidationGroup.ToString());

        //            string strConnection = System.Configuration.ConfigurationSettings.AppSettings["WebHut"];
        //            DataSet dsTemplates = new DataSet();
        //            string Query = "Update Sites set Status='F' where SiteId=" + SiteId + " and UserId=" + oUserDetails.UserID;
        //            SqlHelper.ExecuteNonQuery(strConnection, CommandType.Text, Query);

        //            BindGrids();
        //        }
        //    }
        //    catch (Exception ex)
        //    {

        //    }
        //}



        //private void ExecutePermissions()
        //{
        //    try
        //    {
        //        //Hashtable htUserData = ((System.Collections.Hashtable)Session["UserData"]);

        //        foreach (DataControlField column in grdUnCompletedSites.Columns)
        //        {
        //            if (column.SortExpression == "Edit" && oUserDetails.Edit == false)
        //            {
        //                grdUnCompletedSites.Columns[grdUnCompletedSites.Columns.IndexOf(column)].Visible = false;
        //            }
        //            if (column.SortExpression == "View" && oUserDetails.View == false)
        //            {
        //                grdUnCompletedSites.Columns[grdUnCompletedSites.Columns.IndexOf(column)].Visible = false;
        //            }
        //            if (column.SortExpression == "Finish" && oUserDetails.Finish == false)
        //            {
        //                grdUnCompletedSites.Columns[grdUnCompletedSites.Columns.IndexOf(column)].Visible = false;
        //                tblFinishedSites.Visible = false;
        //            }
        //            if (column.SortExpression == "Assign" && oUserDetails.Assign == false)
        //            {
        //                grdUnCompletedSites.Columns[grdUnCompletedSites.Columns.IndexOf(column)].Visible = false;
        //            }
        //        }
        //        if (oUserDetails.Create == false)
        //        {
        //            tblCreateSite.Visible = false;
        //            //btnCreateCustomer.Visible = false;
        //            //Hide the Create Customer button
        //        }
        //    }
        //    catch (Exception ex)
        //    {

        //    }
        //}


        //protected void btnRefreshGrid_OnClick(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        //Refreshes the grid
        //        BindGrids();
        //    }
        //    catch (Exception ex)
        //    {

        //    }
        //}

        //protected void grdUnCompletedSites_OnPageIndexChanging(object sender, GridViewPageEventArgs e)
        //{
        //    try
        //    {
        //        ((GridView)sender).PageIndex = e.NewPageIndex;
        //        BindGrids();
        //    }
        //    catch (Exception ex)
        //    {

        //    }
        //}
    }
}