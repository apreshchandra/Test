using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using DigiMa.Data;
using System.Collections;
using System.IO;
using DigiMa.BizProcess;
using DigiMa.Common;

namespace DigiMa
{

    public partial class SiteCreation : BaseClass
    {

        UserAction oUserDetails = new UserAction();

        TextBox txtSiteName = new TextBox();

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    oUserDetails.CustomerId = SessionData.Customer.CustomerID;
                    BindTemplatesLibraryList();
                }
            }
            catch (Exception ex)
            {

            }
        }
        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("LandingPage.aspx?CDID=" + SessionData.Customer.CustomerID, false);
        }

        private void BindTemplatesLibraryList()
        {
            try
            {
                string strConnection = System.Configuration.ConfigurationSettings.AppSettings["SoConn"];
                DataSet dsTemplates = new DataSet();
                string Query = "select TemplatesId,TemplateName,ImagePath from Templates where TemplatesId in (12,13,14) ";
                SqlHelper.FillDataset(strConnection, CommandType.Text, Query, dsTemplates, new string[] { "TemplateLibrary" });



                string strTemplatesImagePaths = null;
                string strTemplatesNames = null;
                for (int i = 0; i < dsTemplates.Tables["TemplateLibrary"].Rows.Count; i++)
                {

                    //if (i == 0)
                    //{
                    //    imgPreview1.ImageUrl = dsTemplates.Tables["TemplateLibrary"].Rows[0]["ImagePath"].ToString();
                    //}
                    //else if (i == 1)
                    //{
                    //    imgPreview2.ImageUrl = dsTemplates.Tables["TemplateLibrary"].Rows[1]["ImagePath"].ToString();

                    //}
                    //else if(i==2)
                    //{
                    //    imgPreview3.ImageUrl = "Template/RealEstate.jpg";
                    //}

                    if (string.IsNullOrEmpty(strTemplatesImagePaths))
                    {
                        strTemplatesImagePaths = dsTemplates.Tables["TemplateLibrary"].Rows[i]["ImagePath"].ToString();
                        strTemplatesNames = dsTemplates.Tables["TemplateLibrary"].Rows[i]["TemplateName"].ToString() + "+" + dsTemplates.Tables["TemplateLibrary"].Rows[i]["TemplatesId"].ToString();
                    }
                    else
                    {
                        strTemplatesImagePaths = strTemplatesImagePaths + "~" + dsTemplates.Tables["TemplateLibrary"].Rows[i]["ImagePath"].ToString();
                        strTemplatesNames = strTemplatesNames + "~" + dsTemplates.Tables["TemplateLibrary"].Rows[i]["TemplateName"].ToString() + "+" + dsTemplates.Tables["TemplateLibrary"].Rows[i]["TemplatesId"].ToString();
                    }
                }

                hdnTemplatesImagePaths.Value = strTemplatesImagePaths;
                hdnTemplateNamesWithIds.Value = strTemplatesNames;


            }
            catch (Exception ex)
            {

            }
        }



        protected void btnCreateSite_OnClick(object sender, EventArgs e)
        {
            try
            {
                string prefernceId = preferenceDropDown.SelectedValue;
                //get the id of chosen element from Dropdwonlist

                //ASSUMPTION
                //id we get is 6

                //fetch PReference data for id 6
                CanvasBizProcess canvBiz = new CanvasBizProcess();
                SessionData.PrefData = new PreferenceData();
                SessionData.PrefData = canvBiz.GetPReferenceDataForUserPreference(prefernceId); //REMOVE HARDCODE
                SessionData.PrefData.PrefID1 = prefernceId;

                if (SessionData.PrefData.TaskOne1.Equals("F"))
                {
                    //make user chose templates , edit templates and publish to Facebook
                    SessionData.PrefData.CurrentTask1 = "F";

                    //   Response.Redirect("SiteCreation.aspx?CDID=" + SessionData.Customer.CustomerID + "&TID="+prefernceId, false);
                }
                else if (SessionData.PrefData.TaskOne1.Equals("Y"))
                {
                    //only Youtube
                    SessionData.PrefData.CurrentTask1 = "Y";
                    //Response.Redirect("SiteCreation.aspx?CDID=" + SessionData.Customer.CustomerID + "&TID=" + prefernceId, false);
                }
                int TemplateID = int.Parse(hdnCurrentTemplateId.Value.ToString().Trim());
                //int TemplateID = 11; //HARDCODED REMOVE


                SessionData.UserAction = oUserDetails;
                if (oUserDetails.TemplateId == 0)
                    oUserDetails.TemplateId = TemplateID;// UserDataDetails.Add("TemplateId", TemplateID);
                else if (oUserDetails.TemplateId != TemplateID)
                    oUserDetails.TemplateId = TemplateID;


                string sCustomerId, Query;
                sCustomerId = SessionData.Customer.CustomerID;
                string strConnection = System.Configuration.ConfigurationSettings.AppSettings["SoConn"];


                if (string.IsNullOrEmpty(oUserDetails.CustomerId))
                    sCustomerId = oUserDetails.CustomerId.ToString();

                SessionData.UserAction.CustomerId = SessionData.Customer.CustomerID;

                int CustomerId;

                Query = "Insert into Sites values(" + "'" + SessionData.Customer.CustomerID + "','" + txtSiteName.Text.Trim() + "','P','',null,''," + oUserDetails.TemplateId + ",'index.html'," + "'" + SessionData.Customer.CustomerID + "','','','')";

                string sSiteId = SqlHelper.ExecuteScalar(strConnection, CommandType.Text, Query + ";Select @@Identity").ToString();
                CreateSitePhysically(oUserDetails.TemplateId.ToString(), sSiteId);

                Query = "update  Sites set FolderPath='SiteImages/'+'" + sSiteId + "',FolderPathTool='Sites/Tool/'+'" + sSiteId + "',FolderPathFinal='Sites/Final/'+'" + sSiteId + "' where SiteId=" + sSiteId;
                SqlHelper.ExecuteNonQuery(strConnection, CommandType.Text, Query);

                SessionData.PrefData.TemplateID1 = Convert.ToInt32(hdnCurrentTemplateId.Value);

                //if (TemplateID == 12)
                //{
                Response.Redirect("PageEditor.aspx?SiteId=" + sSiteId);
                //}
                //else
                //{
                //    Response.Redirect("PageEditorVar.aspx?SiteId=" + sSiteId);

                //}


            }
            catch (Exception ex)
            {

            }
        }



        private void CreateSitePhysically(string TemplateId, string SiteId)
        {
            try
            {
                string strTemplateFolderName = "";
                ////string strFolder = Server.MapPath("./SiteImages/" + SiteId);

                string strSiteFolderTool = Server.MapPath("./Sites/Tool/" + SiteId);
                string strSiteFolderReal = Server.MapPath("./Sites/Final/" + SiteId);

                ////if (!Directory.Exists(strFolder))
                if (!Directory.Exists(strSiteFolderTool) && !Directory.Exists(strSiteFolderReal))
                {
                    //From the template ID get the template folder path
                    string strConnection = System.Configuration.ConfigurationSettings.AppSettings["SoConn"];
                    //DataSet dsCustomerList = new DataSet();
                    string Query = "select FolderPath from Templates where TemplatesId=" + TemplateId;
                    string sfolderPath = SqlHelper.ExecuteScalar(strConnection, CommandType.Text, Query).ToString();

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
                                string strItemName = strSiteFolderTool + "\\" + FolderName;
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
                            FilesSave(strItem, strSiteFolderTool);
                            FilesSave(strItem, strSiteFolderReal);
                        }

                    }
                }

                if (SessionData.PrefData.TaskTwo1.Equals("M"))
                {

                }

            }
            catch (Exception ex)
            {

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

            }
        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            SessionData.Customer = null;
            SessionData.PrefData = null;
        }

        protected void imgButtonClick1(object sender, ImageClickEventArgs e)
        {
            hdnCurrentTemplateId.Value = "12";
            sitecreation();
        }

        public void sitecreation()
        {
            try
            {
                string prefernceId = preferenceDropDown.SelectedValue;
                //get the id of chosen element from Dropdwonlist

                //ASSUMPTION
                //id we get is 6

                //fetch PReference data for id 6
                CanvasBizProcess canvBiz = new CanvasBizProcess();
                SessionData.PrefData = new PreferenceData();
                SessionData.PrefData = canvBiz.GetPReferenceDataForUserPreference(prefernceId); //REMOVE HARDCODE
                SessionData.PrefData.PrefID1 = prefernceId;

                if (SessionData.PrefData.TaskOne1.Equals("F"))
                {
                    //make user chose templates , edit templates and publish to Facebook
                    SessionData.PrefData.CurrentTask1 = "F";

                    //   Response.Redirect("SiteCreation.aspx?CDID=" + SessionData.Customer.CustomerID + "&TID="+prefernceId, false);
                }
                else if (SessionData.PrefData.TaskOne1.Equals("Y"))
                {
                    //only Youtube
                    SessionData.PrefData.CurrentTask1 = "Y";
                    //Response.Redirect("SiteCreation.aspx?CDID=" + SessionData.Customer.CustomerID + "&TID=" + prefernceId, false);
                }

                int TemplateID = int.Parse(hdnCurrentTemplateId.Value.ToString().Trim());
                //int TemplateID = 11; //HARDCODED REMOVE


                SessionData.UserAction = oUserDetails;
                if (oUserDetails.TemplateId == 0)
                    oUserDetails.TemplateId = TemplateID;// UserDataDetails.Add("TemplateId", TemplateID);
                else if (oUserDetails.TemplateId != TemplateID)
                    oUserDetails.TemplateId = TemplateID;


                string sCustomerId, Query;
                sCustomerId = SessionData.Customer.CustomerID;
                string strConnection = System.Configuration.ConfigurationSettings.AppSettings["SoConn"];


                //if (string.IsNullOrEmpty(oUserDetails.CustomerId))
                //    sCustomerId = oUserDetails.CustomerId.ToString();

                SessionData.UserAction.CustomerId = SessionData.Customer.CustomerID;

                int CustomerId;

                Query = "Insert into Sites values(" + "'" + SessionData.Customer.CustomerID + "','" + txtSiteName.Text.Trim() + "','P','',null,''," + oUserDetails.TemplateId + ",'index.html'," + "'" + SessionData.Customer.CustomerID + "','','','')";

                string sSiteId = SqlHelper.ExecuteScalar(strConnection, CommandType.Text, Query + ";Select @@Identity").ToString();
                CreateSitePhysically(oUserDetails.TemplateId.ToString(), sSiteId);

                Query = "update  Sites set FolderPath='SiteImages/'+'" + sSiteId + "',FolderPathTool='Sites/Tool/'+'" + sSiteId + "',FolderPathFinal='Sites/Final/'+'" + sSiteId + "' where SiteId=" + sSiteId;
                SqlHelper.ExecuteNonQuery(strConnection, CommandType.Text, Query);

                SessionData.PrefData.TemplateID1 = Convert.ToInt32(hdnCurrentTemplateId.Value);

                //if (TemplateID == 12)
                //{
                Response.Redirect("PageEditor.aspx?SiteId=" + sSiteId, false);
                //}
                //else
                //{
                //    Response.Redirect("PageEditorVar.aspx?SiteId=" + sSiteId);

                //}


            }
            catch (Exception ex)
            {

            }

        }

        protected void imgButtonClick2(object sender, ImageClickEventArgs e)
        {
            hdnCurrentTemplateId.Value = "13";
            sitecreation();
            //Page.ClientScript.RegisterStartupScript(this.GetType(), "myCloseScript", "alert(\"This template is currently under maintainance.\");", true);
        }

        protected void imgButtonClick3(object sender, ImageClickEventArgs e)
        {
            hdnCurrentTemplateId.Value = "14";
            sitecreation();
        }

        protected void imgPreviewCoupons_Click(object sender, ImageClickEventArgs e)
        {
            hdnCurrentTemplateId.Value = "11";
            sitecreation();
        }
        protected void imgPreviewPFrame_Click(object sender, ImageClickEventArgs e)

        {
            hdnCurrentTemplateId.Value = "15";
            sitecreation();
        }

        protected void imgPreviewRestaurant_Click(object sender, ImageClickEventArgs e)
        {
            hdnCurrentTemplateId.Value = "16";
            sitecreation();
        }

        protected void imgPreviewEducational_Click(object sender, ImageClickEventArgs e)
        {
            hdnCurrentTemplateId.Value = "17";
            sitecreation();
        }
    }
}