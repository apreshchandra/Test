using System;
using AjaxControlToolkit;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;
using System.Configuration;
using DigiMa.DataAccess;
using System.IO;
using System.Linq;
using System.Web.UI.WebControls.WebParts;
using System.Text;
using HtmlAgilityPack;
using CKEditor.NET;
using DigiMa.Common;
using DigiMa.Data;
using DigiMa.BizProcess;
using mshtml;

namespace DigiMa
{
    public partial class PageEditor : BaseClass
    {
        SiteDetails oSiteDetails = new SiteDetails();
        UserAction oUserDetails = new UserAction();
        CommonUtility objCommonUtil = new CommonUtility();
        FacebookBizProcess oFBBiz = new FacebookBizProcess();
        private static bool isSaveClicked = false;

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {

                oUserDetails = SessionData.UserAction;
                CKEditor1.config.enterMode = EnterMode.BR;
                GetSiteDetails();
                Bind_ddlPagesList();
                BindTemplatePages(ddlPagesList.SelectedValue);
               
            }
            catch (Exception ex)
            {
                objCommonUtil.SendErrorMail(ex.Message, ex.StackTrace, System.Reflection.MethodBase.GetCurrentMethod().Name.ToString(), System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.ToString(), SessionData.Customer.CustomerID);
            }
        }


        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("LandingPage.aspx?CDID=" + SessionData.Customer.CustomerID, false);
        }


        private void GetSiteDetails()
        {
            try
            {
                int SiteId = 0;
                if (Request.QueryString["SiteId"] != null)
                    SiteId = int.Parse(Request.QueryString["SiteId"].ToString());
                else if (Session["SiteDetails"] != null)
                    SiteId = ((SiteDetails)Session["SiteDetails"]).SiteID;


                //string Query = "select SiteId,SiteName,FolderPath from Sites where SiteId=" + SiteId + " and UserId=" + int.Parse(oUserData["UserId"].ToString());
                string Query = "select S.SiteId,S.SiteName,S.FolderPath,S.FolderPathTool,S.FolderPathFinal,S.DefaultPage from Sites S"
                                + " where S.SiteId=" + SiteId + " and S.UserId=" + "'" + SessionData.UserAction.CustomerId + "'";
                DataSet oDataSet = new DataSet();
                SqlHelper.FillDataset(ConfigurationSettings.AppSettings["SoConn"].ToString(), CommandType.Text, Query, oDataSet, new string[] { "SiteDetails" });

                oSiteDetails.SiteID = int.Parse(oDataSet.Tables["SiteDetails"].Rows[0]["SiteId"].ToString());
                oSiteDetails.SiteName = oDataSet.Tables["SiteDetails"].Rows[0]["SiteName"].ToString();

                oSiteDetails.FolderPath = oDataSet.Tables["SiteDetails"].Rows[0]["FolderPath"].ToString();
                oSiteDetails.FolderPathTool = oDataSet.Tables["SiteDetails"].Rows[0]["FolderPathTool"].ToString(); //Added
                oSiteDetails.FolderPathFinal = oDataSet.Tables["SiteDetails"].Rows[0]["FolderPathFinal"].ToString(); //Added

                //oSiteDetails.CustomerName = oDataSet.Tables["SiteDetails"].Rows[0]["CustomerName"].ToString();
                oSiteDetails.DefaultPage = oDataSet.Tables["SiteDetails"].Rows[0]["DefaultPage"].ToString();
                oSiteDetails.CurrentPage = oSiteDetails.DefaultPage;

                string[] PagesWithPath = Directory.GetFiles(Server.MapPath(oSiteDetails.FolderPathTool), "*.htm*", SearchOption.TopDirectoryOnly);
                List<string> listPages = new List<string>();
                foreach (string PageWithPath in PagesWithPath)
                {
                    listPages.Add(Path.GetFileName(PageWithPath));
                }
                oSiteDetails.Pages = listPages;
                Session["SiteDetails"] = oSiteDetails;

                if (SessionData.PrefData.TemplateID1 == 12)
                {
                    HtmlLink linking = Page.FindControl("menuRstores") as HtmlLink;
                    linking.Href = "Styles/menu_style.css";
                }
                else if (SessionData.PrefData.TemplateID1 == 13)
                {
                    HtmlLink linking = Page.FindControl("pageEditorStyle") as HtmlLink;
                    linking.Href = "Template/FabrikFactory/CSS/FabrikStyle.css";
                }
                else if (SessionData.PrefData.TemplateID1 == 14)
                {
                    HtmlLink linking = Page.FindControl("pageEditorStyle") as HtmlLink;
                    linking.Href = "Template/RealEstate/CSS/realestate_styles.css";
                }
                else if (SessionData.PrefData.TemplateID1 == 11)
                {
                    HtmlLink linking = Page.FindControl("pageEditorStyle") as HtmlLink;
                    linking.Href = "Template/Amalgam v1.0/CSS/CouponsStyle.css";
                }
                else if (SessionData.PrefData.TemplateID1 == 15)
                {
                    HtmlLink linking = Page.FindControl("pageEditorStyle") as HtmlLink;
                    linking.Href = "Template/PFrame/CSS/PFStyle.css";
                }
                else if (SessionData.PrefData.TemplateID1 == 16)
                {
                    HtmlLink linking = Page.FindControl("pageEditorStyle") as HtmlLink;
                    linking.Href = "Template/Restaurant/CSS/Restaurantstyle.css";
                }

                else if (SessionData.PrefData.TemplateID1 == 17)
                {
                    HtmlLink linking = Page.FindControl("pageEditorStyle") as HtmlLink;
                    linking.Href = "Template/Educational/CSS/Educationalstyle.css";
                }
            }
            catch (Exception ex)
            {
                objCommonUtil.SendErrorMail(ex.Message, ex.StackTrace, System.Reflection.MethodBase.GetCurrentMethod().Name.ToString(), System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.ToString(), SessionData.Customer.CustomerID);
            }
        }
        private void Bind_ddlPagesList()
        {
            try
            {
                if (oSiteDetails.Pages.Count > 0)
                {
                    //ddlPagesList.DataTextField = "PageName";
                    ddlPagesList.DataSource = oSiteDetails.Pages;
                    ddlPagesList.DataBind();
                    ddlPagesList.SelectedValue = oSiteDetails.DefaultPage;

                }
            }
            catch (Exception ex)
            {

            }
        }
        protected void btnBackgroundSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                if (FileUploadForBackground.HasFile)
                {
                    if (!string.IsNullOrEmpty(hdnImageName.Value))
                    {
                        //string strSavePath;

                        string strSavePathTool = Server.MapPath(oSiteDetails.FolderPathTool + "/images/"); //"D:/Webhut-Clean/sitepages/SiteImages/1/images/";
                        string strSavePathFinal = Server.MapPath(oSiteDetails.FolderPathFinal + "/images/");
                        if (!Directory.Exists(strSavePathTool))
                        {
                            Directory.CreateDirectory(strSavePathTool);
                        }
                        if (!Directory.Exists(strSavePathFinal))
                        {
                            Directory.CreateDirectory(strSavePathFinal);
                        }
                        string imag = Path.GetFileName(FileUploadForBackground.PostedFile.FileName);
                        //check if a file with the same filename already exists
                        try
                        {
                            if (System.IO.File.Exists(strSavePathTool + imag))
                            {
                                hdnErrorPopup.Value = "A file with the same name already exists. Please rename the file and try again";
                                divSitePages.InnerHtml = hdnReplacedDivHelp.Value;
                                hdnReplacedDiv.Value = divSitePages.InnerHtml;
                                hdnReplacedDivHelp.Value = "";

                                hdnBodyStyleToSave.Value = hdnBodyStyleToSaveHelp.Value;
                                hdnBodyStyleToSaveHelp.Value = "";
                            }
                            else
                            {
                                try
                                {
                                    FileUploadForBackground.PostedFile.SaveAs(strSavePathTool + imag);
                                    FileUploadForBackground.PostedFile.SaveAs(strSavePathFinal + imag);
                                    FileUploadForBackground.PostedFile.InputStream.Dispose();
                                    FileUploadForBackground.Dispose();
                                }
                                catch (Exception exex) { }
                                if (!string.IsNullOrEmpty(hdnReplacedDiv.Value))
                                {
                                    divSitePages.InnerHtml = hdnReplacedDiv.Value;
                                }
                                //BindTemplatePages(oSiteDetails.CurrentPage);
                            }
                        }
                        catch (Exception ex) { objCommonUtil.SendErrorMail(ex.Message, ex.StackTrace, System.Reflection.MethodBase.GetCurrentMethod().Name.ToString(), System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.ToString(), SessionData.Customer.CustomerID); }
                    }
                }
            }
            catch (Exception ex)
            {
                objCommonUtil.SendErrorMail(ex.Message, ex.StackTrace, System.Reflection.MethodBase.GetCurrentMethod().Name.ToString(), System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.ToString(), SessionData.Customer.CustomerID);
            }
        }

        protected void btnImageSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                if (FileUpload1.HasFile)
                {
                    if (!string.IsNullOrEmpty(hdnImageName.Value))
                    {
                        string strSavePathTool = Server.MapPath(oSiteDetails.FolderPathTool + "/Images/"); //"D:/Webhut-Clean/sitepages/SiteImages/1/images/";
                        string strSavePathFinal = Server.MapPath(oSiteDetails.FolderPathFinal + "/Images/");
                        if (!Directory.Exists(strSavePathTool))
                        {
                            Directory.CreateDirectory(strSavePathTool);
                        }
                        if (!Directory.Exists(strSavePathFinal))
                        {
                            Directory.CreateDirectory(strSavePathFinal);
                        }
                        string imag = Path.GetFileName(FileUpload1.PostedFile.FileName);
                        //check if a file with the same filename already exists
                        try
                        {
                            if (System.IO.File.Exists(strSavePathTool + imag))
                            {
                                hdnErrorPopup.Value = "There is a file with the same name already exists. Please rename the file and try again";
                                divSitePages.InnerHtml = hdnReplacedDivHelp.Value;
                                hdnReplacedDiv.Value = divSitePages.InnerHtml;
                                hdnReplacedDivHelp.Value = "";
                            }
                            else
                            {
                                try
                                {
                                    FileUpload1.PostedFile.SaveAs(strSavePathTool + imag);
                                    FileUpload1.PostedFile.SaveAs(strSavePathFinal + imag);
                                    FileUpload1.PostedFile.InputStream.Dispose();
                                    FileUpload1.Dispose();
                                }
                                catch (Exception exex) { }
                                if (!string.IsNullOrEmpty(hdnReplacedDiv.Value))
                                {
                                    divSitePages.InnerHtml = hdnReplacedDiv.Value;
                                }
                            }
                        }
                        catch (Exception ex) { }

                        //if (!string.IsNullOrEmpty(hdnReplacedDiv.Value))
                        //{
                        //    divSitePages.InnerHtml = hdnReplacedDiv.Value;
                        //    string strd1 = hdnReplacedDiv.Value;
                        //}
                    }
                }
            }
            catch (Exception ex)
            {
                objCommonUtil.SendErrorMail(ex.Message, ex.StackTrace, System.Reflection.MethodBase.GetCurrentMethod().Name.ToString(), System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.ToString(), SessionData.Customer.CustomerID);
            }
        }
        private void BindTemplatePages(string strPageName)
        {
            try
            {
                if (!string.IsNullOrEmpty(strPageName))
                {
                    oSiteDetails.CurrentPage = strPageName;

                    //PageList oPageList = (PageList)Session["Pages"];
                    //oPageList.SelectedPage = strPageName;
                    //Session["Pages"] = oPageList;
                    hdnImagesPathForSite.Value = oSiteDetails.FolderPathTool;
                    ancPreviewPage.HRef = oSiteDetails.FolderPathFinal + "/" + oSiteDetails.CurrentPage;
                    //lblCustomer.Text = oSiteDetails.CustomerName;



                    string strUrl = Server.MapPath(oSiteDetails.FolderPathTool) + "\\" + oSiteDetails.CurrentPage;

                    HtmlDocument doc = new HtmlDocument();
                    doc.Load(strUrl, Encoding.UTF8);

                    //IHTMLDocument2 htmlDoc = new HTMLDocumentClass();                   

                    //System.Runtime.InteropServices.UCOMIPersistFile pf = (System.Runtime.InteropServices.UCOMIPersistFile)htmlDoc;
                    //pf.Load(strUrl, 1);




                    //FileStream fsSource = new FileStream(strUrl, FileMode.Open, FileAccess.Read);
                    //byte[] bytes = new byte[fsSource.Length];
                    //int numBytesToRead = (int)fsSource.Length;
                    //int numBytesRead = 0;
                    //while (numBytesToRead > 0)
                    //{
                    //    // Read may return anything from 0 to numBytesToRead.
                    //    int n = fsSource.Read(bytes, numBytesRead, numBytesToRead);

                    //    // Break when the end of the file is reached.
                    //    if (n == 0)
                    //        break;

                    //    numBytesRead += n;
                    //    numBytesToRead -= n;
                    //}
                    //numBytesToRead = bytes.Length;
                    //fsSource.Close();
                    //fsSource.Dispose();
                    string strStylePathRef, strStyleSitePathRef, strImagePathRef, strImage2PathRef, strImageSitePathRef, strJQueryPathRef, strJQuerySitePathRef, strImage2SitePathRef;
                    strStylePathRef = "css/";
                    strImagePathRef = "images/";
                    strJQueryPathRef = "js/";
                    strImage2PathRef = "Temp/Images/";

                    strStyleSitePathRef = oSiteDetails.FolderPathTool + "/css/";
                    strImageSitePathRef = oSiteDetails.FolderPathTool + "/Images/";
                    strJQuerySitePathRef = oSiteDetails.FolderPathTool + "/js/";
                    strImage2SitePathRef = oSiteDetails.FolderPathTool + "/Temp/Images/";


                    //Get the body style into hidden field
                    //if (doc.DocumentNode.SelectSingleNode("//body").GetAttributeValue("style", "EMPTY") != "EMPTY")
                    //    hdnBodyStyleToSave.Value = doc.DocumentNode.SelectSingleNode("//body").GetAttributeValue("style", "EMPTY").Replace(strImagePathRef, strImageSitePathRef);


                    //Update the stickynote container if doesn't exists
                    if (doc.DocumentNode.SelectSingleNode("//body") != null)
                    {
                        if (doc.GetElementbyId("divNotesContainer") == null)
                        {
                            doc.DocumentNode.SelectSingleNode("//body").InnerHtml = doc.DocumentNode.SelectSingleNode("//body").InnerHtml
                                                                                    + "<!--NOT_FOR_FINAL_START-->"
                                                                                    + "<div id=\"divNotesContainer\" style=\"position: absolute; top: 0; left: 0\">"
                                                                                    + "    <input type=\"hidden\" id=\"hdnPageNotesNumber\" value=\"0\" />"
                                                                                    + "    <input type=\"hidden\" id=\"hdnScriptsForNotes\" value=\"\" />"
                                                                                    + "</div>"
                                                                                    + "<!--NOT_FOR_FINAL_END-->";
                        }
                    }

                    if (doc.GetElementbyId("divNotesContainer") != null)
                    {
                        //docCurentPage.GetElementbyId("divNotesContainer").SetAttributeValue("style", "Diaslay:none");
                        doc.GetElementbyId("divNotesContainer").SetAttributeValue("style", "left: 0px; top: 0px; position: absolute;");

                    }



                    string strHTMLRender = doc.DocumentNode.InnerHtml;     // new System.Text.ASCIIEncoding().GetString(bytes);

                    string doctype, html_start, html_end, body_start, body_end, head_start, head_end;
                    //Case sensitivity not checked
                    doctype = strHTMLRender.Substring(strHTMLRender.IndexOf("<!DOCTYPE"), strHTMLRender.IndexOf('>', strHTMLRender.IndexOf("<!DOCTYPE")) - strHTMLRender.IndexOf("<!DOCTYPE") + 1);
                    html_start = strHTMLRender.Substring(strHTMLRender.IndexOf("<html"), strHTMLRender.IndexOf('>', strHTMLRender.IndexOf("<html")) - strHTMLRender.IndexOf("<html") + 1);
                    html_end = "</html>";
                    head_start = strHTMLRender.Substring(strHTMLRender.IndexOf("<head"), strHTMLRender.IndexOf('>', strHTMLRender.IndexOf("<head")) - strHTMLRender.IndexOf("<head") + 1); ;
                    head_end = "</head>";
                    body_start = strHTMLRender.Substring(strHTMLRender.IndexOf("<body"), strHTMLRender.IndexOf('>', strHTMLRender.IndexOf("<body")) - strHTMLRender.IndexOf("<body") + 1); ;
                    body_end = "</body>";

                    string[] temp = { doctype, html_start, head_start, head_end, body_start, body_end, html_end };
                    oSiteDetails.PageTags = temp;
                    //Session["temp"] = temp;



                    strHTMLRender = strHTMLRender.Replace(doctype, "");
                    strHTMLRender = strHTMLRender.Replace(html_start, "<!--html_start-->");
                    strHTMLRender = strHTMLRender.Replace(html_end, "<!--html_end-->");
                    strHTMLRender = strHTMLRender.Replace(body_start, "<!--body_start-->");
                    strHTMLRender = strHTMLRender.Replace(body_end, "");
                    strHTMLRender = strHTMLRender.Replace(head_start, "");
                    strHTMLRender = strHTMLRender.Replace(head_end, "");






                    strHTMLRender = strHTMLRender.Replace(strStylePathRef, strStyleSitePathRef);

                    strHTMLRender = strHTMLRender.Replace(strImagePathRef, strImageSitePathRef);

                    strHTMLRender = strHTMLRender.Replace(strJQueryPathRef, strJQuerySitePathRef);
                    strHTMLRender = strHTMLRender.Replace(strImage2PathRef, strImage2SitePathRef);

                    strHTMLRender = strHTMLRender.Replace("???", "");

                    strHTMLRender = strHTMLRender.Replace("<form", "<div");
                    strHTMLRender = strHTMLRender.Replace("method=\"post\"", "");

                    EditPages.Visible = true;

                    divSitePages.InnerHtml = "<!--" + oSiteDetails.CurrentPage + "-->" + strHTMLRender;

                }
            }
            catch (Exception ex)
            {
                objCommonUtil.SendErrorMail(ex.Message, ex.StackTrace, System.Reflection.MethodBase.GetCurrentMethod().Name.ToString(), System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.ToString(), SessionData.Customer.CustomerID);
            }
        }

        protected void ddlPagesList_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (hdnDropDownStatus.Value == "SAVE")
                {
                    SavePage();
                    hdnDropDownStatus.Value = "";
                }
                else if (hdnDropDownStatus.Value == "DISCARD")
                {
                    hdnReplacedDiv.Value = "";
                    hdnDropDownStatus.Value = "";
                }
                BindTemplatePages(ddlPagesList.SelectedValue);
            }
            catch (Exception ex)
            {
                objCommonUtil.SendErrorMail(ex.Message, ex.StackTrace, System.Reflection.MethodBase.GetCurrentMethod().Name.ToString(), System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.ToString(), SessionData.Customer.CustomerID);
            }
        }


        protected void btnSave_OnClick(object sender, EventArgs e)
        {
            try
            {
                isSaveClicked = true;
                SavePage();
                BindTemplatePages(oSiteDetails.CurrentPage);
            }
            catch (Exception ex)
            {
                objCommonUtil.SendErrorMail(ex.Message, ex.StackTrace, System.Reflection.MethodBase.GetCurrentMethod().Name.ToString(), System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.ToString(), SessionData.Customer.CustomerID);
            }
        }

        private void SavePage()
        {
            try
            {
                if (!string.IsNullOrEmpty(hdnReplacedDiv.Value) && !string.IsNullOrEmpty(oSiteDetails.CurrentPage))
                {
                    if (hdnReplacedDiv.Value.Contains("<!--" + oSiteDetails.CurrentPage + "-->"))
                    {
                        hdnReplacedDiv.Value = hdnReplacedDiv.Value.Replace("<!--" + oSiteDetails.CurrentPage + "-->", "");
                        string strUrlTool = Server.MapPath(oSiteDetails.FolderPathTool) + "\\" + oSiteDetails.CurrentPage;
                        string strUrlFinal = Server.MapPath(oSiteDetails.FolderPathFinal) + "\\" + oSiteDetails.CurrentPage;
                        string strFinalPage = hdnReplacedDiv.Value;
                        string strStylePathRef, strStyleSitePathRef, strImagePathRef, strImage2PathRef, strImageSitePathRef, strJQueryPathRef, strJQuerySitePathRef, strImage2SitePathRef;
                        strStylePathRef = "css/";
                        strImagePathRef = "images/";
                        strJQueryPathRef = "js/";
                        strImage2PathRef = "Temp/images/";


                        strStyleSitePathRef = oSiteDetails.FolderPathTool + "/css/";
                        strImageSitePathRef = oSiteDetails.FolderPathTool + "/Images/";
                        strJQuerySitePathRef = oSiteDetails.FolderPathTool + "/js/";
                        strImage2SitePathRef = oSiteDetails.FolderPathTool + "/Temp/images/";


                        strFinalPage = strFinalPage.Replace(strStyleSitePathRef, strStylePathRef);
                        strFinalPage = strFinalPage.Replace(strImageSitePathRef, strImagePathRef);
                        strFinalPage = strFinalPage.Replace(strJQuerySitePathRef, strJQueryPathRef);
                        strFinalPage = strFinalPage.Replace(strImage2SitePathRef, strImage2PathRef);  //Temporary

                        string[] PageTags = oSiteDetails.PageTags;
                        strFinalPage = strFinalPage.Replace("<!--html_start-->", PageTags[0] + PageTags[1] + PageTags[2]);
                        strFinalPage = strFinalPage.Replace("<!--body_start-->", PageTags[3] + PageTags[4]);
                        strFinalPage = strFinalPage.Replace("<!--html_end-->", PageTags[5] + PageTags[6]);

                        //alter image links
                        //strFinalPage = strFinalPage.Replace("<img class=\"dynamic\" src=\"images/SNR_facebook.png\">", "<img class=\"dynamic\" src=\"images/SNR_facebook.png\" />");
                        //strFinalPage = strFinalPage.Replace("<img class=\"dynamic\" src=\"images/SNR_recommend.png\">", "<img class=\"dynamic\" src=\"images/SNR_recommend.png\" />");
                        //strFinalPage = strFinalPage.Replace("<img class=\"dynamic\" src=\"images/fb-like-button.png\">", "<img class=\"dynamic\" src=\"images/fb-like-button.png\" />");

                        //here page is dirty
                        string QueryUpdate = "update Sites set DirtyPage='Y' where SiteId=" + oSiteDetails.SiteID;
                        DataSet oDataSet = new DataSet();
                        SqlHelper.FillDataset(ConfigurationSettings.AppSettings["SoConn"].ToString(), CommandType.Text, QueryUpdate, oDataSet, new string[] { "SiteDetails" });


                        // Different copy of code
                        string ToolHTML, FinalHTML;

                        ToolHTML = strFinalPage;
                        //Final code don't need Note Container
                        FinalHTML = strFinalPage.Replace(strFinalPage.Substring(strFinalPage.IndexOf("<!--NOT_FOR_FINAL_START-->"), strFinalPage.IndexOf("<!--NOT_FOR_FINAL_END-->", strFinalPage.IndexOf("<!--NOT_FOR_FINAL_START-->")) + "<!--NOT_FOR_FINAL_END-->".Length - 1 - strFinalPage.IndexOf("<!--NOT_FOR_FINAL_START-->") + 1), string.Empty);

                        HtmlDocument docCurentPage = new HtmlDocument();


                        docCurentPage.LoadHtml(ToolHTML);


                        //Update the changed body style
                        if (!string.IsNullOrEmpty(hdnBodyStyleToSave.Value))
                        {
                            docCurentPage.DocumentNode.SelectSingleNode("//body").SetAttributeValue("style", hdnBodyStyleToSave.Value.Replace("\"", "'"));
                        }


                        docCurentPage.Save(strUrlTool, Encoding.UTF8);



                        docCurentPage.LoadHtml(FinalHTML);
                        //Update the changed body style
                        if (!string.IsNullOrEmpty(hdnBodyStyleToSave.Value))
                        {
                            docCurentPage.DocumentNode.SelectSingleNode("//body").SetAttributeValue("style", hdnBodyStyleToSave.Value.Replace("\"", "'"));
                        }




                        docCurentPage.Save(strUrlFinal, Encoding.UTF8);
                        //File.WriteAllText(strUrl, str.ToString());




                        //if (docCurentPage != null)
                        //{
                        //    //PageList oPageListTemp = (PageList)Session["Pages"];
                        //    for (int i = 0; i < hdnCommonHTMLs.Value.Split('~').Length; i++)
                        //    {
                        //        for (int j = 0; j < oSiteDetails.Pages.Count; j++)
                        //        {
                        //            //Exclude the current page for updation
                        //            if (oSiteDetails.CurrentPage.ToUpper() == oSiteDetails.Pages[j].ToUpper())
                        //                continue;
                        //            HtmlDocument docTemp = new HtmlDocument();
                        //            {
                        //                string strUrlTemp = Server.MapPath(oSiteDetails.FolderPathTool) + "\\" + oSiteDetails.Pages[j];
                        //                docTemp.Load(strUrlTemp, Encoding.UTF8);

                        //                docTemp.GetElementbyId(hdnCommonHTMLs.Value.Split('~')[i]).InnerHtml = docCurentPage.GetElementbyId(hdnCommonHTMLs.Value.Split('~')[i]).InnerHtml;
                        //                docTemp.Save(strUrlTemp, Encoding.UTF8);
                        //            }
                        //            {
                        //                string strUrlTemp = Server.MapPath(oSiteDetails.FolderPathFinal) + "\\" + oSiteDetails.Pages[j];
                        //                docTemp.Load(strUrlTemp, Encoding.UTF8);

                        //                docTemp.GetElementbyId(hdnCommonHTMLs.Value.Split('~')[i]).InnerHtml = docCurentPage.GetElementbyId(hdnCommonHTMLs.Value.Split('~')[i]).InnerHtml;
                        //                docTemp.Save(strUrlTemp, Encoding.UTF8);
                        //            }
                        //        }
                        //    }
                        //}

                    }
                    hdnReplacedDiv.Value = "";

                    //Update 

                    string strConnection = System.Configuration.ConfigurationSettings.AppSettings["SoConn"];
                    DataSet dsTemplates = new DataSet();
                    string Query = "update  Sites set DownloadPath=NULL where SiteId=" + oSiteDetails.SiteID;
                    SqlHelper.ExecuteNonQuery(strConnection, CommandType.Text, Query);
                }
                //else if (hdnReplacedDivHelp.Value != null)
                //{
                //    if (hdnReplacedDivHelp.Value.Contains("<!--" + oSiteDetails.CurrentPage + "-->"))
                //    {
                //        hdnReplacedDivHelp.Value = hdnReplacedDivHelp.Value.Replace("<!--" + oSiteDetails.CurrentPage + "-->", "");
                //        string strUrlTool = Server.MapPath(oSiteDetails.FolderPathTool) + "\\" + oSiteDetails.CurrentPage;
                //        string strUrlFinal = Server.MapPath(oSiteDetails.FolderPathFinal) + "\\" + oSiteDetails.CurrentPage;
                //        string strFinalPage = hdnReplacedDivHelp.Value;
                //        string strStylePathRef, strStyleSitePathRef, strImagePathRef, strImage2PathRef, strImageSitePathRef, strJQueryPathRef, strJQuerySitePathRef, strImage2SitePathRef;
                //        strStylePathRef = "css/";
                //        strImagePathRef = "images/";
                //        strJQueryPathRef = "js/";
                //        strImage2PathRef = "Temp/images/";


                //        strStyleSitePathRef = oSiteDetails.FolderPathTool + "/css/";
                //        strImageSitePathRef = oSiteDetails.FolderPathTool + "/Images/";
                //        strJQuerySitePathRef = oSiteDetails.FolderPathTool + "/js/";
                //        strImage2SitePathRef = oSiteDetails.FolderPathTool + "/Temp/images/";


                //        strFinalPage = strFinalPage.Replace(strStyleSitePathRef, strStylePathRef);
                //        strFinalPage = strFinalPage.Replace(strImageSitePathRef, strImagePathRef);
                //        strFinalPage = strFinalPage.Replace(strJQuerySitePathRef, strJQueryPathRef);
                //        strFinalPage = strFinalPage.Replace(strImage2SitePathRef, strImage2PathRef);  //Temporary

                //        string[] PageTags = oSiteDetails.PageTags;
                //        strFinalPage = strFinalPage.Replace("<!--html_start-->", PageTags[0] + PageTags[1] + PageTags[2]);
                //        strFinalPage = strFinalPage.Replace("<!--body_start-->", PageTags[3] + PageTags[4]);
                //        strFinalPage = strFinalPage.Replace("<!--html_end-->", PageTags[5] + PageTags[6]);

                //        //alter image links
                //        //strFinalPage = strFinalPage.Replace("<img class=\"dynamic\" src=\"images/SNR_facebook.png\">", "<img class=\"dynamic\" src=\"images/SNR_facebook.png\" />");
                //        //strFinalPage = strFinalPage.Replace("<img class=\"dynamic\" src=\"images/SNR_recommend.png\">", "<img class=\"dynamic\" src=\"images/SNR_recommend.png\" />");
                //        //strFinalPage = strFinalPage.Replace("<img class=\"dynamic\" src=\"images/fb-like-button.png\">", "<img class=\"dynamic\" src=\"images/fb-like-button.png\" />");

                //        //here page is dirty
                //        string QueryUpdate = "update Sites set DirtyPage='Y' where SiteId=" + oSiteDetails.SiteID;
                //        DataSet oDataSet = new DataSet();
                //        SqlHelper.FillDataset(ConfigurationSettings.AppSettings["SoConn"].ToString(), CommandType.Text, QueryUpdate, oDataSet, new string[] { "SiteDetails" });


                //        // Different copy of code
                //        string ToolHTML, FinalHTML;

                //        ToolHTML = strFinalPage;
                //        //Final code don't need Note Container
                //        FinalHTML = strFinalPage.Replace(strFinalPage.Substring(strFinalPage.IndexOf("<!--NOT_FOR_FINAL_START-->"), strFinalPage.IndexOf("<!--NOT_FOR_FINAL_END-->", strFinalPage.IndexOf("<!--NOT_FOR_FINAL_START-->")) + "<!--NOT_FOR_FINAL_END-->".Length - 1 - strFinalPage.IndexOf("<!--NOT_FOR_FINAL_START-->") + 1), string.Empty);

                //        HtmlDocument docCurentPage = new HtmlDocument();


                //        docCurentPage.LoadHtml(ToolHTML);


                //        //Update the changed body style
                //        if (!string.IsNullOrEmpty(hdnBodyStyleToSave.Value))
                //        {
                //            docCurentPage.DocumentNode.SelectSingleNode("//body").SetAttributeValue("style", hdnBodyStyleToSave.Value.Replace("\"", "'"));
                //        }
                //        docCurentPage.Save(strUrlTool, Encoding.UTF8);



                //        docCurentPage.LoadHtml(FinalHTML);

                //        docCurentPage.Save(strUrlFinal, Encoding.UTF8);
                //        //File.WriteAllText(strUrl, str.ToString());




                //        //if (docCurentPage != null)
                //        //{
                //        //    //PageList oPageListTemp = (PageList)Session["Pages"];
                //        //    for (int i = 0; i < hdnCommonHTMLs.Value.Split('~').Length; i++)
                //        //    {
                //        //        for (int j = 0; j < oSiteDetails.Pages.Count; j++)
                //        //        {
                //        //            //Exclude the current page for updation
                //        //            if (oSiteDetails.CurrentPage.ToUpper() == oSiteDetails.Pages[j].ToUpper())
                //        //                continue;
                //        //            HtmlDocument docTemp = new HtmlDocument();
                //        //            {
                //        //                string strUrlTemp = Server.MapPath(oSiteDetails.FolderPathTool) + "\\" + oSiteDetails.Pages[j];
                //        //                docTemp.Load(strUrlTemp, Encoding.UTF8);

                //        //                docTemp.GetElementbyId(hdnCommonHTMLs.Value.Split('~')[i]).InnerHtml = docCurentPage.GetElementbyId(hdnCommonHTMLs.Value.Split('~')[i]).InnerHtml;
                //        //                docTemp.Save(strUrlTemp, Encoding.UTF8);
                //        //            }
                //        //            {
                //        //                string strUrlTemp = Server.MapPath(oSiteDetails.FolderPathFinal) + "\\" + oSiteDetails.Pages[j];
                //        //                docTemp.Load(strUrlTemp, Encoding.UTF8);

                //        //                docTemp.GetElementbyId(hdnCommonHTMLs.Value.Split('~')[i]).InnerHtml = docCurentPage.GetElementbyId(hdnCommonHTMLs.Value.Split('~')[i]).InnerHtml;
                //        //                docTemp.Save(strUrlTemp, Encoding.UTF8);
                //        //            }
                //        //        }
                //        //    }
                //        //}

                //    }
                //    hdnReplacedDivHelp.Value = "";

                //    //Update 

                //    string strConnection = System.Configuration.ConfigurationSettings.AppSettings["SoConn"];
                //    DataSet dsTemplates = new DataSet();
                //    string Query = "update  Sites set DownloadPath=NULL where SiteId=" + oSiteDetails.SiteID;
                //    SqlHelper.ExecuteNonQuery(strConnection, CommandType.Text, Query);
                //}
            }
            catch (Exception ex)
            {
                objCommonUtil.SendErrorMail(ex.Message, ex.StackTrace, System.Reflection.MethodBase.GetCurrentMethod().Name.ToString(), System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.ToString(), SessionData.Customer.CustomerID);
            }
        }


        private void CopyToMicrosites(string SiteId)
        {
            try
            {
                string strTemplateFolderName = "";
                ////string strFolder = Server.MapPath("./SiteImages/" + SiteId);

                string strSiteFolderMS = Server.MapPath("./MicroSites/" + SiteId);
                string strSiteFolderReal = Server.MapPath("./Sites/Final/" + SiteId);

                ////if (!Directory.Exists(strFolder))
                if (!Directory.Exists(strSiteFolderMS) && !Directory.Exists(strSiteFolderReal))
                {

                    string sfolderPath = strSiteFolderReal;

                    //string[] strTemplate = (hdnSelectedTemplate.Value).Split('.');

                    strTemplateFolderName = Server.MapPath(sfolderPath);
                    string[] sarFolder = Directory.GetDirectories(strTemplateFolderName);
                    if (sarFolder.Length > 0)
                    {
                        foreach (string strFolderName in sarFolder)
                        {
                            string[] FolderNameList = strFolderName.Split('\\');
                            string FolderName = FolderNameList[FolderNameList.Length - 1];

                            {
                                string strItemName = strSiteFolderMS + "\\" + FolderName;
                                if (!Directory.Exists(strItemName))
                                {
                                    Directory.CreateDirectory(strItemName);
                                }
                                string[] strFolderFiles = Directory.GetFiles(strFolderName);
                                foreach (string strFolderItem in strFolderFiles)
                                {
                                    FilesSave(strFolderItem, strItemName);
                                }
                            }
                            {
                                string strItemName = strSiteFolderReal + "\\" + FolderName;
                                if (!Directory.Exists(strItemName))
                                {
                                    Directory.CreateDirectory(strItemName);
                                }
                                string[] strFolderFiles = Directory.GetFiles(strFolderName);
                                foreach (string strFolderItem in strFolderFiles)
                                {
                                    FilesSave(strFolderItem, strItemName);
                                }
                            }
                        }
                    }



                    string[] sarFiles = Directory.GetFiles(strTemplateFolderName);
                    if (sarFiles.Length > 0)
                    {
                        foreach (string strItem in sarFiles)
                        {
                            FilesSave(strItem, strSiteFolderMS);
                            FilesSave(strItem, strSiteFolderReal);
                        }

                    }
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        private void FilesSave(string strItem, string strFolder)
        {
            try
            {
                string[] strFile = strItem.Split('\\');
                FileStream fsSource = new FileStream(strItem, FileMode.Open, FileAccess.Read);
                byte[] bytes = new byte[fsSource.Length];
                int numBytesToRead = (int)fsSource.Length;
                int numBytesRead = 0;
                while (numBytesToRead > 0)
                {
                    // Read may return anything from 0 to numBytesToRead.
                    int n = fsSource.Read(bytes, numBytesRead, numBytesToRead);

                    // Break when the end of the file is reached.
                    if (n == 0)
                        break;

                    numBytesRead += n;
                    numBytesToRead -= n;
                }
                numBytesToRead = bytes.Length;

                string strNewFile = strFolder + "\\" + strFile[strFile.Length - 1];
                string[] strFileExtensionls = strFile[strFile.Length - 1].Split('.');
                //htStep1Data = new Hashtable();
                //htStep1Data = GetUserData();
                if (strFileExtensionls[strFileExtensionls.Length - 1].ToUpper() == "HTML" || strFileExtensionls[strFileExtensionls.Length - 1].ToUpper() == "HTM")
                {
                    strNewFile = strFolder + "\\" + strFileExtensionls[0] + ".html";
                    //// oalPages.Add(strFileExtensionls[0] + ".html");
                    ////Session["Pages"] = oalPages;
                    //ArrayList oArrayList = new ArrayList();
                    //Hashtable oHashtable = (Hashtable)Session["UserData"];
                    //if (oHashtable.Contains("Pages"))
                    //{
                    //    oArrayList = (ArrayList)oHashtable["Pages"];
                    //    oArrayList.Add(strFileExtensionls[0] + ".html");

                    //    Session["UserData"] = htStep1Data;
                    //}
                    //else
                    //{

                    //}
                    string strHTMLRender = new System.Text.ASCIIEncoding().GetString(bytes);
                    //string strQuery = "insert into SitePage(OrderId,PageName,PageHtml) values('" + ((Hashtable)Session["UserData"])["OrderId"].ToString() + "','" + strFileExtensionls[0] + ".html" + "','" + strHTMLRender + "')";
                    //string strQuery = "insert into SitePage(OrderId,PageName) values('" + ((Hashtable)Session["UserData"])["OrderId"].ToString() + "','" + strFileExtensionls[0] + ".html" + "')";
                    //SqlHelper.ExecuteNonQuery(ConfigurationSettings.AppSettings["WebHut"].ToString(), CommandType.Text, strQuery);
                }

                FileStream fsWrite = new FileStream(strNewFile, FileMode.Create, FileAccess.Write);
                fsWrite.Write(bytes, 0, numBytesToRead);
                fsSource.Close();
                fsSource.Dispose();
                fsWrite.Close();
                fsWrite.Dispose();
            }
            catch (Exception ex)
            {
                objCommonUtil.SendErrorMail(ex.Message, ex.StackTrace, System.Reflection.MethodBase.GetCurrentMethod().Name.ToString(), System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.ToString(), SessionData.Customer.CustomerID);
            }
        }

        protected void btnRebindPages_OnClick(object sender, EventArgs e)
        {
            try
            {
                Bind_ddlPagesList();
            }
            catch (Exception ex)
            {
                objCommonUtil.SendErrorMail(ex.Message, ex.StackTrace, System.Reflection.MethodBase.GetCurrentMethod().Name.ToString(), System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.ToString(), SessionData.Customer.CustomerID);
            }

        }

        protected void btnComplete_Click(object sender, EventArgs e)
        {
            //Now html is Ready. Pick html from Sites/Final/"SiteId"
            SessionData.UserAction.YoutubeURL1 = hdnYoutubeURL.Value;
            SessionData.UserAction.SiteID1 = Request.QueryString["SiteId"].ToString();
            SessionData.UserAction.PreferenceID1 = SessionData.PrefData.PrefID1;
            FacebookBizProcess fbBiz = new FacebookBizProcess();

            //create Row in UserAction table
            if (fbBiz.SetUserAction(SessionData.UserAction))
            {
                Response.Redirect("CanvasAreaMuSite.aspx?SiteID=" + SessionData.UserAction.SiteID1 + "&CDID=" + SessionData.Customer.CustomerID);
            }
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            // get the tag of the element to be deleted. then find that node in the html and Call the Save function
            try
            {
                if (!FileUpload1.HasFile) //for image/ iframe /
                {
                    if (!string.IsNullOrEmpty(hdnImageName.Value)) //
                    {
                        //string SiteID= oFBBiz.GetSiteIDForConfig(
                        string strSavePathTool = Server.MapPath("./Sites/Final/" + Convert.ToString(Request["SiteID"]) + "/Images/"); //"D:/Webhut-Clean/sitepages/SiteImages/1/images/";
                        string strSavePathFinal = Server.MapPath("./Sites/Final/" + Convert.ToString(Request["SiteID"]) + "/Images/");

                        //form the fullpath of the Image to be deleted
                        File.Delete(strSavePathTool + hdnImageName.Value);
                        File.Delete(strSavePathFinal + hdnImageName.Value);
                        if (!string.IsNullOrEmpty(hdnReplacedDiv.Value))
                        {
                            divSitePages.InnerHtml = hdnReplacedDiv.Value;
                            if (SessionData.PrefData.TemplateID1 == 11)
                            {
                                string finalCoupons = ReplaceDeletedImageBySpanCoupons(divSitePages.InnerHtml);
                                divSitePages.InnerHtml = finalCoupons;
                            }
                            else if (SessionData.PrefData.TemplateID1 == 14)
                            {
                                string finalRealEstate = ReplaceDeletedImageBySpanRealEstate(divSitePages.InnerHtml);
                                divSitePages.InnerHtml = finalRealEstate;
                            }
                            else if (SessionData.PrefData.TemplateID1 == 13)
                            {
                                string finalFabrik= ReplaceDeletedImageBySpanFabrikFactory(divSitePages.InnerHtml);
                                divSitePages.InnerHtml = finalFabrik;
                            }
                            else //RStores
                            {
                                
                            }
                        }
                    }
                    else
                    {
                        //this has to be an Iframe
                        divSitePages.InnerHtml = hdnReplacedDiv.Value;
                        string locoPoco = ReplaceDeletedIframeBySpan(divSitePages.InnerHtml);
                        divSitePages.InnerHtml = locoPoco;
                    }
                }
            }
            catch (Exception ex)
            {
                objCommonUtil.SendErrorMail(ex.Message, ex.StackTrace, System.Reflection.MethodBase.GetCurrentMethod().Name.ToString(), System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.ToString(), SessionData.Customer.CustomerID);
            }
        }

        public string ReplaceDeletedImageBySpanCoupons(string htmlContent)
        {
            HtmlDocument doc = new HtmlDocument();
            doc.LoadHtml(htmlContent);

            foreach (HtmlNode img in doc.DocumentNode.SelectNodes("//img[@class='" + hdnImageClass.Value + "']"))
            {
                string value = img.Attributes.Contains("value") ? img.Attributes["value"].Value : "&nbsp;";
                HtmlNode lbl = doc.CreateElement("span");
                lbl.Attributes.Add("class", hdnImageClass.Value);
                lbl.InnerHtml = value;

                img.ParentNode.ReplaceChild(lbl, img);
            }
            return doc.DocumentNode.OuterHtml;
        }


        public string ReplaceDeletedImageBySpanFabrikFactory(string htmlContent)
        {
            HtmlDocument doc = new HtmlDocument();
            doc.LoadHtml(htmlContent);

            foreach (HtmlNode img in doc.DocumentNode.SelectNodes("//img[@class='" + hdnImageClass.Value + "']"))
            {
                string value = img.Attributes.Contains("value") ? img.Attributes["value"].Value : "&nbsp;";
                HtmlNode lbl = doc.CreateElement("span");
                lbl.Attributes.Add("class", hdnImageClass.Value);
                lbl.InnerHtml = value;

                img.ParentNode.ReplaceChild(lbl, img);
            }
            return doc.DocumentNode.OuterHtml;
        }
        public string ReplaceDeletedImageBySpanRealEstate(string htmlContent)
        {
            HtmlDocument doc = new HtmlDocument();
            doc.LoadHtml(htmlContent);

            foreach (HtmlNode img in doc.DocumentNode.SelectNodes("//img[@class='" + hdnImageClass.Value + "']"))
            {
                string value = img.Attributes.Contains("value") ? img.Attributes["value"].Value : "&nbsp;";
                HtmlNode lbl = doc.CreateElement("span");
                lbl.Attributes.Add("class", hdnImageClass.Value);
                lbl.InnerHtml = value;

                img.ParentNode.ReplaceChild(lbl, img);
            }
            return doc.DocumentNode.OuterHtml;
        }

        public string ReplaceDeletedIframeBySpan(string htmlContent)
        {
            HtmlDocument doc = new HtmlDocument();
            doc.LoadHtml(htmlContent);

            foreach (HtmlNode img in doc.DocumentNode.SelectNodes("//iframe"))
            {
               
                HtmlNode lbl = doc.CreateElement("span");
                lbl.Attributes.Add("class", "IF");
                lbl.Attributes.Add("height", "187");
                lbl.Attributes.Add("width", "240");
               

                img.ParentNode.ReplaceChild(lbl, img);
            }
            return doc.DocumentNode.OuterHtml;
        }
    }
}