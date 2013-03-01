<%@ WebHandler Language="C#" Class="DownloadSite" %>

using System;
using System.Web;
using System.Data;
using Ionic.Zlib;
using Ionic.Zip;
using WebHut.DataAccess;

public class DownloadSite : IHttpHandler
{

    public void ProcessRequest(HttpContext context)
    {

        //context.Response.ContentType = "text/plain";
        //context.Response.Write("Hello World");

        //Check UserID  and the siteId then convert with the random name  and save.
        //then save the path to the DB
        //Thensend for downloading

        //string strConnection = System.Configuration.ConfigurationSettings.AppSettings["WebHut"];
        ////DataSet dsDownloadPath = new DataSet();
        //string Query = "select DownloadPath from Sites where SiteId=" + SiteId;
        //SqlHelper.FillDataset(strConnection, CommandType.Text, Query, dsDownloadPath, new string[] { "DownloadPath" });


        //ZipFile zip = new ZipFile();

        //zip.AddDirectory(context.Server.MapPath(""));
        //zip.Comment = "This zip was created at " + System.DateTime.Now.ToString("G");
        //zip.Save(@"D:\myzipfile.zip");



        try
        {



            int SiteId = 0;
            if (context.Request.QueryString["SiteId"] != null)
                SiteId = int.Parse(context.Request.QueryString["SiteId"].ToString());

            string strConnection = System.Configuration.ConfigurationSettings.AppSettings["WebHut"];
            DataSet dsDownloadPath = new DataSet();
            string Query = "select DownloadPath from Sites where SiteId=" + SiteId;
            SqlHelper.FillDataset(strConnection, CommandType.Text, Query, dsDownloadPath, new string[] { "DownloadPath" });




            string DownloadPath = "";
            string Filename = "";
            if (dsDownloadPath != null && dsDownloadPath.Tables.Count > 0 && dsDownloadPath.Tables[0].Rows.Count > 0 && dsDownloadPath.Tables[0].Rows[0][0].ToString().Trim() != "")
            {
                DownloadPath = dsDownloadPath.Tables[0].Rows[0]["DownloadPath"].ToString();
                Filename = DownloadPath.Replace("Download/", "");
                //Update the file aneme here also
            }
            else
            {
                strConnection = System.Configuration.ConfigurationSettings.AppSettings["WebHut"];
                DataSet dsSiteDetail = new DataSet();
                Query = "select SiteId,SiteName from Sites where SiteId=" + SiteId;
                SqlHelper.FillDataset(strConnection, CommandType.Text, Query, dsSiteDetail, new string[] { "SiteDetail" });

                if (dsSiteDetail != null && dsSiteDetail.Tables.Count > 0 && dsSiteDetail.Tables[0].Rows.Count > 0 && dsSiteDetail.Tables[0].Rows[0][0].ToString().Trim() != "")
                {
                    ZipFile zip = new ZipFile();

                    zip.AddDirectory(context.Server.MapPath("Sites/Final/" + SiteId));
                    //                context.Server.MapPath("Download/")+dsSiteDetail.Tables["SiteDetail"].Rows[0]["SiteId"].ToString() + "_" + dsSiteDetail.Tables["SiteDetail"].Rows[0]["SiteName"].ToString().Replace(" ", "")+".zip"
                    //"D:\\WebHutNew\\WebHutNew\\Download\\"

                    zip.Save(context.Server.MapPath("Download/") + dsSiteDetail.Tables["SiteDetail"].Rows[0]["SiteId"].ToString() + "_" + dsSiteDetail.Tables["SiteDetail"].Rows[0]["SiteName"].ToString().Replace(" ", "") + ".zip");

                    Filename = dsSiteDetail.Tables["SiteDetail"].Rows[0]["SiteId"].ToString() + "_" + dsSiteDetail.Tables["SiteDetail"].Rows[0]["SiteName"].ToString().Replace(" ", "") + ".zip";
                    DownloadPath = "Download/" + Filename;// +dsSiteDetail.Tables["SiteDetail"].Rows[0]["SiteId"].ToString() + "_" + dsSiteDetail.Tables["SiteDetail"].Rows[0]["SiteName"].ToString().Replace(" ", "") + ".zip";

                    strConnection = System.Configuration.ConfigurationSettings.AppSettings["WebHut"];
                    Query = "update Sites set DownloadPath='" + DownloadPath + "' where SiteId=" + SiteId;
                    SqlHelper.ExecuteNonQuery(strConnection, CommandType.Text, Query);



                    //DownloadPath = dsSiteDetail.Tables["SiteDetail"].Rows[0]["SiteId"].ToString() + "_" + dsSiteDetail.Tables["SiteDetail"].Rows[0]["SiteName"].ToString().Replace(" ", "");
                }
            }



            context.Response.Buffer = true;
            context.Response.Clear();
            context.Response.AddHeader("content-disposition", "attachment; filename=" + Filename);
            context.Response.ContentType = "application/zip";
            context.Response.WriteFile(DownloadPath);
        }
        catch (Exception ex)
        {
            WebHutCommon.ExceptionHandler.ErrorMode(WebHutCommon.Layer.UI, ex);
        }
        
        
    }

    public bool IsReusable
    {
        get
        {
            return false;
        }
    }

}