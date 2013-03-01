using System;
using AjaxControlToolkit;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data;
using System.Web.UI.HtmlControls;
using DigiMa.BizProcess;
using System.Collections;
using System.IO;
using System.Text;
using DigiMa.Common;
using DigiMa.Data;
using System.Web.UI.WebControls;
using System.Net;
using System.Drawing.Imaging;
using Newtonsoft;
using Newtonsoft.Json.Linq;
using System.Drawing;
using System.Text.RegularExpressions;
using System.IO;



namespace DigiMa
{
    public partial class EditCanvasAreaPromoOne : System.Web.UI.Page
    {
        DataSet dsPage = new DataSet();
        DataTable dtPage = new DataTable("Page");
        CanvasBizProcess canv = new CanvasBizProcess();
        StringBuilder sbTemplateHTML = new StringBuilder();
        DataSet dsTemplateData = new DataSet();
        Hashtable hashTemplateData = new Hashtable();
        Hashtable hashErrorCollection = new Hashtable();
        AppConfiguration oAppConfig = new AppConfiguration();
        CommonUtility commonUtil = new CommonUtility();
        FacebookBizProcess fbBiz = new FacebookBizProcess();
        //Wizard wzd = new Wizard();
        private const string EMPTYSTRING = "";
        private const string PROMOTIONS = "";
        private const string LIKE_GATEWAY = "LIKE_GATEWAY";
        private const string TAB_LOGO = "TAB_LOGO";
        private const string APP_EXPIRY_IMAGE = "APP_EXPIRY_IMAGE";
        private const string STEP_THREE_COMPLETE = "step_three_complete";
        private const string STEP_TWO_COMPLETE = "step_two_complete";
        private const string STEP_ONE_COMPLETE = "step_one_complete";
        private const string TEMPLATE_PAGE = "EditCanvasAreaPromoOne.aspx";
        private const string THREE = "3";
        private const string TRUE = "Y";
        private const string HASFILE = "has file";


        private string CDID = string.Empty;
        string methodName;
        string className;
        string pathToCreate = string.Empty;
        string appCode = string.Empty;
        string appID = string.Empty;
        string appSecret = string.Empty;
        string templateID = THREE;
        string maint;
        int varCount = 0;
        int errCount = 0;
        string iframecontent;
        string htmlToEdit;
        string HeaderReplaced;
        string ContentReplaced;
        string FinalHTML;


        protected void Page_Load(object sender, EventArgs e)
        {
            btnRefresh.Click += new EventHandler(btnRefresh_Click);
            Response.Cache.SetCacheability(HttpCacheability.Private);
            if (!IsPostBack)
            {
                if (SessionData.Customer.CustomerID.Equals(string.Empty))
                {
                    Response.Redirect("Home.aspx");
                }

            }
            if (Request["CDID"] != null)
            {
                CDID = Request["CDID"].ToString();

                //create session based on CDID
                if (SessionData.Customer.CustomerID == null || SessionData.Customer.CustomerID == "")
                {
                    SessionData.Customer = new AppCustomer();
                    SessionData.Customer = canv.GetCustomerInfo(null, CDID, false);
                }
            }
            if (Request["TID"] != null)
            {
                templateID = Request["TID"].ToString();
            }


            if (Request["Maint"] != null)
            {
                maint = Request["Maint"].ToString();
            }
            if (Request["CustomerName"] != null)
            {
                SessionData.Customer.SCustomerUserName = Convert.ToString(Request["CustomerName"]);
            }

            if (Request["Appname"] != null)
            {
                if (string.IsNullOrEmpty(SessionData.Config.AppID))
                {
                    SessionData.Config = new AppConfiguration();
                    SessionData.Config.AppName = Convert.ToString(Request["Appname"]);
                }
            }

            if (!IsPostBack)
            {
                if (Request["Maint"] != null)
                {
                    //Fetch Campaign Info from AppConfiguration and AppProduct       
                    SessionData.Config = fbBiz.GetAppConfiguration(SessionData.Config.AppName, "");
                    hdnAppid.Value = SessionData.Config.AppID;
                    SessionData.Product = fbBiz.GetActiveAppProduct(null, SessionData.Config.DID);


                    //Now prefill all the values

                    //Canvas Settings Tab
                    txtCanvasHeight.Text = SessionData.Product.CanvasHeight;
                    txtCanvasWidth.Text = SessionData.Product.CanvasWidth;



                    //Sweepstakes Details tab
                    txtHeaderText.Text = SessionData.Product.AppCaption;
                    txtCustomTabNamePromo2.Text = SessionData.Config.SCustomtTabName;
                    if (SessionData.Product.ShareWidgetAdded.Equals(TRUE))
                    {
                        chkShareButton.Checked = true;
                    }
                    if (SessionData.Product.ReccWidgetAdded.Equals(TRUE))
                    {
                        chkRecc.Checked = true;
                    }
                    if (SessionData.Product.InquiryWidgetAdded.Equals(TRUE))
                    {
                        chkInquiry.Checked = true;
                    }
                    if (SessionData.Product.CommentsWidgetAdded.Equals(TRUE))
                    {
                        chkComment.Checked = true;
                    }
                    if (SessionData.Product.LikeWidgetAdded.Equals(TRUE))
                    {
                        chkLike.Checked = true;
                    }

                    if (SessionData.Product.LikeGatewayAdded.Equals(TRUE))
                    {
                        chkLikeGateway.Checked = true;
                        filePromo2LikeGateWayImage.Visible = true;
                    }
                    if (SessionData.Product.TwitterWidgetAdded.Equals(TRUE))
                    {
                        chkTweeter.Checked = true;

                    }
                }
            }


            if (hdnTabStatus.Value.Equals(STEP_ONE_COMPLETE))
            {

                HtmlGenericControl camp = new HtmlGenericControl();
                camp = (HtmlGenericControl)MainList.FindControl("CampDetails");
                camp.Style.Add("display", "block");


                HtmlGenericControl fbook = new HtmlGenericControl();
                fbook = (HtmlGenericControl)MainList.FindControl("FacebookDet");
                fbook.Style.Add("display", "none");

                HtmlGenericControl fbookShow = new HtmlGenericControl();
                fbookShow = (HtmlGenericControl)MainList.FindControl("Widgets");
                fbookShow.Style.Add("display", "none");

                StringBuilder oSBLastTab = new StringBuilder();
                oSBLastTab.Append(" $(document).ready(function () {");
                oSBLastTab.Append("$(\"#campDetLinker\").trigger('click')");
                oSBLastTab.Append("});");


                Page.ClientScript.RegisterStartupScript(this.GetType(), "myCloseScript", oSBLastTab.ToString(), true);
            }
            else if (hdnTabStatus.Value.Equals(STEP_TWO_COMPLETE))
            {
                //Step two complete, 
                HtmlGenericControl fbook = new HtmlGenericControl();
                fbook = (HtmlGenericControl)MainList.FindControl("FacebookDet");

                HtmlGenericControl camp = new HtmlGenericControl();
                camp = (HtmlGenericControl)MainList.FindControl("CampDetails");
                camp.Style.Add("display", "block");


                fbook.Style.Add("display", "none");

                HtmlGenericControl fbookShow = new HtmlGenericControl();
                fbookShow = (HtmlGenericControl)MainList.FindControl("Widgets");
                fbookShow.Style.Add("display", "block");

                StringBuilder oSBLastTab = new StringBuilder();
                oSBLastTab.Append(" $(document).ready(function () {");
                oSBLastTab.Append("$(\"#widgetLinker\").trigger('click')");
                oSBLastTab.Append("});");


                Page.ClientScript.RegisterStartupScript(this.GetType(), "myCloseScript", oSBLastTab.ToString(), true);
            }
            else if (hdnTabStatus.Value.Equals(STEP_THREE_COMPLETE))
            {
                HtmlGenericControl fbook = new HtmlGenericControl();
                fbook = (HtmlGenericControl)MainList.FindControl("FacebookDet");

                HtmlGenericControl camp = new HtmlGenericControl();
                camp = (HtmlGenericControl)MainList.FindControl("CampDetails");
                camp.Style.Add("display", "block");


                fbook.Style.Add("display", "block");

                HtmlGenericControl fbookShow = new HtmlGenericControl();
                fbookShow = (HtmlGenericControl)MainList.FindControl("Widgets");
                fbookShow.Style.Add("display", "block");

                StringBuilder oSBLastTab = new StringBuilder();
                oSBLastTab.Append(" $(document).ready(function () {");
                oSBLastTab.Append("$(\"#fbLinker\").trigger('click')");
                oSBLastTab.Append("});");

                Page.ClientScript.RegisterStartupScript(this.GetType(), "myCloseScript", oSBLastTab.ToString(), true);
            }
            else
            {
                HtmlGenericControl camp = new HtmlGenericControl();
                camp = (HtmlGenericControl)MainList.FindControl("CampDetails");
                camp.Style.Add("display", "none");


                HtmlGenericControl fbook = new HtmlGenericControl();
                fbook = (HtmlGenericControl)MainList.FindControl("FacebookDet");
                fbook.Style.Add("display", "none");

                HtmlGenericControl fbookShow = new HtmlGenericControl();
                fbookShow = (HtmlGenericControl)MainList.FindControl("Widgets");
                fbookShow.Style.Add("display", "none");
            }


            if (!string.IsNullOrEmpty(hdnCode.Value))
            {
                //Select page call
                Page.ClientScript.RegisterStartupScript(this.GetType(), "myCloseScript", "window.close();", true);
                framePage.Attributes.Add("src", "SelectPage.aspx?code=" + hdnCode.Value + "&app_id=" + hdnAppid.Value + "&Twitter=" + hdnTweetEnabled.Value);
            }

        }
        void btnRefresh_Click(object sender, EventArgs e)
        {

        }
        protected override void OnPreRender(EventArgs e)
        {
            base.OnPreRender(e);
        }

        protected void btnPublish_Click(object sender, EventArgs e)
        {
            try
            {
                if (SessionData.Config.SAppPageTabSelected == null)
                {
                    StringBuilder oSBPageSElector = new StringBuilder();
                    oSBPageSElector.Append("window.open('http://www.facebook.com/dialog/permissions.request?app_id=");
                    oSBPageSElector.Append(SessionData.Config.AppID + "&redirect_uri=https://www.testsonetreach.com/CreateApp.aspx?app_id=" + SessionData.Config.AppID + "&response_type=code&perms=user_birthday,user_location,email,manage_pages,publish_stream\','name','height=570,width=960,menubar=0,toolbar=0,statusbar=0,scrollbars=0,resizable=0');");
                    litLogin.Text = oSBPageSElector.ToString();
                }
            }
            catch (Exception ex)
            {
                commonUtil.SendErrorMail(ex.Message, ex.StackTrace, System.Reflection.MethodBase.GetCurrentMethod().Name.ToString(), System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.ToString(), SessionData.Customer.CustomerID);
            }
        }


        public static void SaveImageFile(Bitmap sourceImage, String saveImagePath, int maxImageWidth, int newImageHeight)
        {
            // Resize if source image width is greater than the max:            
            Bitmap resizedImage = new Bitmap(maxImageWidth, newImageHeight);
            Graphics gr = Graphics.FromImage(resizedImage);
            gr.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
            gr.DrawImage(sourceImage, 0, 0, maxImageWidth, newImageHeight);
            // Save the resized image:
            resizedImage.Save(saveImagePath, FileExtensionToImageFormat(saveImagePath));
        }

        private static ImageFormat FileExtensionToImageFormat(String filePath)
        {
            String ext = Path.GetExtension(filePath).ToLower();
            ImageFormat result = ImageFormat.Jpeg;
            switch (ext)
            {
                case ".gif":
                    result = ImageFormat.Gif;
                    break;
                case ".png":
                    result = ImageFormat.Png;
                    break;
                case ".jpg":
                    result = ImageFormat.Jpeg;
                    break;
            }
            return result;
        }

        public static string[] GetStringInBetween(string strBegin, string strEnd, string strSource, bool includeBegin, bool includeEnd)
        {
            string[] result = { "", "" };

            int iIndexOfBegin = strSource.IndexOf(strBegin);

            if (iIndexOfBegin != -1)
            {
                // include the Begin string if desired 

                if (includeBegin)

                    iIndexOfBegin -= strBegin.Length;

                strSource = strSource.Substring(iIndexOfBegin

                    + strBegin.Length);

                int iEnd = strSource.IndexOf(strEnd);

                if (iEnd != -1)
                {

                    // include the End string if desired 

                    if (includeEnd)

                        iEnd += strEnd.Length;

                    result[0] = strSource.Substring(0, iEnd);

                    // advance beyond this segment 

                    if (iEnd + strEnd.Length < strSource.Length)

                        result[1] = strSource.Substring(iEnd

                            + strEnd.Length);
                }
            }
            else
                // stay where we are 

                result[1] = strSource;

            return result;

        }

        public string FixVideoURL(string content)
        {
            try
            {
                string[] video = content.Split(' ');



                StringBuilder oSBURLMaker = new StringBuilder();
                oSBURLMaker.Append(video[0]);
                oSBURLMaker.Append(" ");
                oSBURLMaker.Append(video[1]);
                oSBURLMaker.Append(" ");
                oSBURLMaker.Append(video[2]);
                oSBURLMaker.Append(" ");
                oSBURLMaker.Append(video[3].Remove(video[3].Length - 1));
                oSBURLMaker.Append("&autoplay=0" + "\" ");
                oSBURLMaker.Append(video[4]);
                oSBURLMaker.Append(" ");
                oSBURLMaker.Append(video[5]);

                return oSBURLMaker.ToString();
            }
            catch (Exception ex)
            {
                commonUtil.SendErrorMail(ex.Message, ex.StackTrace, System.Reflection.MethodBase.GetCurrentMethod().Name.ToString(), System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.ToString(), SessionData.Customer.CustomerID);
            }
            return "";
        }
        private void PageCaller(string code, string appID, string secretKey, string red_uri)
        {

            PRomo1.Visible = false;
            Promo2.Visible = false;
            Promo3.Visible = false;
        }

        private string SQLSafeDates(string inoputDate, bool flag)
        {
            if (flag)
            {
                string[] dates = inoputDate.Split('/');

                string month = dates[1];

                string date = dates[0];
                string year = dates[2].Substring(0, 4);
                string timePart = "00:00:00";


                return year + "-" + month + "-" + date + " " + timePart;
            }
            else
            {
                string[] dates = inoputDate.Split('/');

                string month = dates[1];

                string date = dates[0];
                string year = dates[2].Substring(0, 4);
                string timePart = "23:59:59";


                return year + "-" + month + "-" + date + " " + timePart;
            }
        }

        protected void btnStep1Complete_Click(object sender, EventArgs e)
        {
            try
            {
                //assign Canvas data to AppProduct

                SessionData.Product.CanvasHeight = txtCanvasHeight.Text.Trim();
                SessionData.Product.CanvasWidth = txtCanvasWidth.Text.Trim();

                //Prepare file system directory to store Images
                string pathToCreate = "~/Images/" + SessionData.Product.DID;

                //Logo Image
                if (filePromo2Logo.HasFile)
                {
                    if (filePromo2Logo.PostedFile.ContentType == "image/jpeg" || filePromo2Logo.PostedFile.ContentType == "image/png" || filePromo2Logo.PostedFile.ContentType == "image/jpg" || filePromo2Logo.PostedFile.ContentType == "image/pjpeg")
                    {
                        if (filePromo2Logo.FileBytes.Length < 1048576)
                        {
                            string filenamePromo2Logo = Path.GetFileName(filePromo2Logo.FileName);
                            if (chkPromo2.Checked)
                            {
                                Bitmap sourceImage = new Bitmap(filePromo2Logo.PostedFile.InputStream);
                                SaveImageFile(sourceImage, Server.MapPath(pathToCreate + "/Logo" + filenamePromo2Logo), 111, 74);
                                hdnFooterLogo.Value = filenamePromo2Logo;
                                SessionData.Product.ProductLogo = filenamePromo2Logo;
                            }
                            else
                            {
                                filePromo2Logo.PostedFile.SaveAs(Server.MapPath("~/Images/" + SessionData.Product.DID + "/Logo" + filenamePromo2Logo));
                                hdnFooterLogo.Value = filenamePromo2Logo;
                                SessionData.Product.ProductLogo = filenamePromo2Logo;
                            }
                        }
                        else
                        {
                            span1.InnerHtml = "File size should not be greater than 1 MB"; spnErrorPromo2Head.Style.Add("color", "Red");
                            errCount++;
                        }
                    }
                    else
                    {
                        spnErrorPromo2Head.InnerHtml = "Upload status: Only JPEG, PNG files are accepted!"; spnErrorPromo2Head.Style.Add("color", "Red");
                        errCount++;
                    }
                }
                else
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "myCloseScript", "alert(\"Please upload Logo!\")", true);
                    errCount++;
                }
                hdnTabStatus.Value = STEP_ONE_COMPLETE;
            }
            catch (Exception ex)
            {
                commonUtil.SendErrorMail(ex.Message, ex.StackTrace, System.Reflection.MethodBase.GetCurrentMethod().Name.ToString(), System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.ToString(), SessionData.Customer.CustomerID);
            }
        }

        protected void btnStep2Complete_Click(object sender, EventArgs e)
        {
            try
            {
                //Prepare file system directory to store Images
                string pathToCreate = "~/Images/" + SessionData.Product.DID;

                hdnPDID.Value = SessionData.Product.DID;
                hdnfield.Value = CDID;
                if (!Directory.Exists(Server.MapPath(pathToCreate)))
                {
                    Directory.CreateDirectory(Server.MapPath(pathToCreate));
                }

                //Header Image
                if (fileHead.HasFile)
                {
                    hdnFileHeaderHasFile.Value = HASFILE;
                    if (fileHead.PostedFile.ContentType == "image/jpeg" || fileHead.PostedFile.ContentType == "image/png" || fileHead.PostedFile.ContentType == "image/jpg" || fileHead.PostedFile.ContentType == "image/pjpeg")
                    {
                        if (fileHead.FileBytes.Length < 1048576)
                        {
                            string filenamePromo1Head = Path.GetFileName(fileHead.FileName);
                            if (chkPromo1Head.Checked)
                            {
                                Bitmap sourceImage = new Bitmap(fileHead.PostedFile.InputStream);
                                if (SessionData.Product.CanvasHeight == string.Empty)
                                {
                                    SaveImageFile(sourceImage, Server.MapPath(pathToCreate + "/Header" + filenamePromo1Head), Convert.ToInt32(SessionData.Product.CanvasWidth), 700);
                                }
                                else if (SessionData.Product.CanvasWidth == string.Empty)
                                {
                                    SaveImageFile(sourceImage, Server.MapPath(pathToCreate + "/Header" + filenamePromo1Head), 500, Convert.ToInt32(SessionData.Product.CanvasHeight));
                                }
                                else if (SessionData.Product.CanvasHeight == string.Empty && SessionData.Product.CanvasWidth == string.Empty)
                                {
                                    SaveImageFile(sourceImage, Server.MapPath(pathToCreate + "/Header" + filenamePromo1Head), 500, 700);
                                }
                                else
                                {
                                    SaveImageFile(sourceImage, Server.MapPath(pathToCreate + "/Header" + filenamePromo1Head), Convert.ToInt32(SessionData.Product.CanvasHeight), Convert.ToInt32(SessionData.Product.CanvasWidth));
                                }
                                hdnHeader.Value = filenamePromo1Head;
                            }
                            else
                            {
                                fileHead.PostedFile.SaveAs(Server.MapPath("~/Images/" + SessionData.Product.DID + "/Header" + filenamePromo1Head));
                                hdnHeader.Value = filenamePromo1Head;
                            }
                            //NOW SAVE TO PRODUCT TABLE------> PRODUCTFOOTER
                        }
                        else
                        {
                            spnErrorPromo2Head.InnerHtml = "File size should not be greater than 1 MB"; spnErrorPromo2Head.Style.Add("color", "Red");
                            errCount++;
                        }
                    }
                    else
                    {
                        spnErrorPromo2Head.InnerHtml = "Upload status: Only JPEG, PNG files are accepted!"; spnErrorPromo2Head.Style.Add("color", "Red");
                        errCount++;
                    }
                }

                //Body Image
                if (fileBody.HasFile)
                {
                    hdnFileContentHasFile.Value = HASFILE;
                    if (fileBody.PostedFile.ContentType == "image/jpeg" || fileBody.PostedFile.ContentType == "image/png" || fileBody.PostedFile.ContentType == "image/jpg" || fileBody.PostedFile.ContentType == "image/pjpeg")
                    {
                        if (fileBody.FileBytes.Length < 1048576)
                        {
                            string filenamePromo2 = Path.GetFileName(fileBody.FileName);
                            if (chkPromo2.Checked)
                            {
                                Bitmap sourceImage = new Bitmap(fileBody.PostedFile.InputStream);
                                if (SessionData.Product.CanvasHeight == string.Empty)
                                {
                                    SaveImageFile(sourceImage, Server.MapPath(pathToCreate + "/Content" + filenamePromo2), Convert.ToInt32(SessionData.Product.CanvasWidth), 700);
                                }
                                else if (SessionData.Product.CanvasWidth == string.Empty)
                                {
                                    SaveImageFile(sourceImage, Server.MapPath(pathToCreate + "/Content" + filenamePromo2), 500, Convert.ToInt32(SessionData.Product.CanvasHeight));
                                }
                                else if (SessionData.Product.CanvasHeight == string.Empty && SessionData.Product.CanvasWidth == string.Empty)
                                {
                                    SaveImageFile(sourceImage, Server.MapPath(pathToCreate + "/Content" + filenamePromo2), 500, 700);
                                }
                                else
                                {
                                    SaveImageFile(sourceImage, Server.MapPath(pathToCreate + "/Content" + filenamePromo2), Convert.ToInt32(SessionData.Product.CanvasHeight), Convert.ToInt32(SessionData.Product.CanvasWidth));
                                }
                                hdnContent.Value = filenamePromo2;
                            }
                            else
                            {
                                fileBody.PostedFile.SaveAs(Server.MapPath("~/Images/" + SessionData.Product.DID + "/Content" + filenamePromo2));
                                hdnContent.Value = filenamePromo2;
                            }
                            //NOW SAVE TO PRODUCT TABLE------> PRODUCTFOOTER
                        }
                        else
                        {
                            spnErrorPromo2Head.InnerHtml = "File size should not be greater than 1 MB"; spnErrorPromo2Head.Style.Add("color", "Red");
                            errCount++;
                        }
                    }
                    else
                    {
                        spnErrorPromo2Head.InnerHtml = "Upload status: Only JPEG, PNG files are accepted!"; spnErrorPromo2Head.Style.Add("color", "Red");
                        errCount++;
                    }
                }

                //Footer Image
                if (fileFoot.HasFile)
                {
                    hdnFileFooterHasFile.Value = HASFILE;
                    if (fileFoot.PostedFile.ContentType == "image/jpeg" || fileFoot.PostedFile.ContentType == "image/png" || fileFoot.PostedFile.ContentType == "image/jpg" || fileFoot.PostedFile.ContentType == "image/pjpeg")
                    {
                        if (fileFoot.FileBytes.Length < 1048576)
                        {
                            string filenamePromo1Foot = Path.GetFileName(fileFoot.FileName);
                            if (chkPromo1Foot.Checked)
                            {
                                Bitmap sourceImage = new Bitmap(fileFoot.PostedFile.InputStream);
                                if (SessionData.Product.CanvasHeight == string.Empty)
                                {
                                    SaveImageFile(sourceImage, Server.MapPath(pathToCreate + "/Footer" + filenamePromo1Foot), Convert.ToInt32(SessionData.Product.CanvasWidth), 700);
                                }
                                else if (SessionData.Product.CanvasWidth == string.Empty)
                                {
                                    SaveImageFile(sourceImage, Server.MapPath(pathToCreate + "/Footer" + filenamePromo1Foot), 500, Convert.ToInt32(SessionData.Product.CanvasHeight));
                                }
                                else if (SessionData.Product.CanvasHeight == string.Empty && SessionData.Product.CanvasWidth == string.Empty)
                                {
                                    SaveImageFile(sourceImage, Server.MapPath(pathToCreate + "/Footer" + filenamePromo1Foot), 500, 700);
                                }
                                else
                                {
                                    SaveImageFile(sourceImage, Server.MapPath(pathToCreate + "/Footer" + filenamePromo1Foot), Convert.ToInt32(SessionData.Product.CanvasHeight), Convert.ToInt32(SessionData.Product.CanvasWidth));
                                }
                                hdnFooter.Value = filenamePromo1Foot;
                            }
                            else
                            {
                                fileFoot.PostedFile.SaveAs(Server.MapPath("~/Images/" + SessionData.Product.DID + "/Footer" + filenamePromo1Foot));
                                hdnFooter.Value = filenamePromo1Foot;
                            }
                        }
                        else
                        {
                            spnErrorPromo2Head.InnerHtml = "File size should not be greater than 1 MB"; spnErrorPromo2Head.Style.Add("color", "Red");
                            errCount++;
                        }
                    }
                    else
                    {
                        spnErrorPromo2Head.InnerHtml = "Upload status: Only JPEG, PNG files are accepted!"; spnErrorPromo2Head.Style.Add("color", "Red");
                        errCount++;
                    }
                }
                else
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "myCloseScript", "alert(\"Please upload all Images!\")", true);

                    errCount++;
                }

                //Caption
                if (!string.IsNullOrEmpty(txtHeaderText.Text))
                {
                    SessionData.Product.AppCaption = txtHeaderText.Text;
                }

                HtmlGenericControl fbookShow = new HtmlGenericControl();
                fbookShow = (HtmlGenericControl)MainList.FindControl("Widgets");
                fbookShow.Style.Add("display", "block");
                hdnTabStatus.Value = STEP_TWO_COMPLETE;
            }
            catch (Exception ex)
            {
                commonUtil.SendErrorMail(ex.Message, ex.StackTrace, System.Reflection.MethodBase.GetCurrentMethod().Name.ToString(), System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.ToString(), SessionData.Customer.CustomerID);
            }
        }

        protected void btnStep3Complete_Click(object sender, EventArgs e)
        {
            try
            {
                //Fetch Template Data
                FacebookBizProcess fbBiz = new FacebookBizProcess();
                string createdHTML = fbBiz.GetProductHTML(SessionData.Product.DID); //REVISIT
                hdnTrmplateID.Value = templateID;

                //Save Widgets info and Cust Tab name, then move to FB tab
                //Custom Tab Name
                if (!txtCustomTabNamePromo2.Text.Trim().Equals(string.Empty))
                {

                    SessionData.Product.SCustomeTabName = txtCustomTabNamePromo2.Text.Trim();
                }
                else
                {
                    spanErrorCustTabNamePromo2.InnerHtml = "Custom Tab Name is required!";
                    errCount++;
                }

                //Widgets
                if (chkShareButton.Checked)
                {
                    SessionData.Product.ShareWidgetAdded = "Y";

                }
                else
                {
                    SessionData.Product.ShareWidgetAdded = "N";
                }
                if (chkInquiry.Checked)
                {
                    SessionData.Product.InquiryWidgetAdded = "Y";
                }
                else
                {
                    SessionData.Product.InquiryWidgetAdded = "N";
                }
                if (chkRecc.Checked)
                {
                    SessionData.Product.ReccWidgetAdded = "Y";
                }
                else
                {
                    SessionData.Product.ReccWidgetAdded = "N";
                }
                if (chkComment.Checked)
                {
                    SessionData.Product.CommentsWidgetAdded = "Y";
                }
                else
                {
                    SessionData.Product.CommentsWidgetAdded = "N";
                }
                if (chkLike.Checked)
                {
                    SessionData.Product.LikeWidgetAdded = "Y";
                }
                else
                {
                    SessionData.Product.LikeWidgetAdded = "N";
                }
                if (chkTweeter.Checked)
                {
                    SessionData.Product.TwitterWidgetAdded = "Y";

                }
                else
                {
                    SessionData.Product.TwitterWidgetAdded = "N";
                }
                //Like Gateway
                if (chkLikeGateway.Checked)
                {
                    SessionData.Product.LikeGatewayAdded = "Y";
                    //Save LikeGateway Image
                    if (filePromo2LikeGateWayImage.PostedFile.ContentType == "image/jpeg" || filePromo2LikeGateWayImage.PostedFile.ContentType == "image/png" || filePromo2LikeGateWayImage.PostedFile.ContentType == "image/jpg" || filePromo2LikeGateWayImage.PostedFile.ContentType == "image/pjpeg")
                    {
                        if (filePromo2LikeGateWayImage.FileBytes.Length < 1048576)
                        {
                            string filenamePromo2Logo = Path.GetFileName(filePromo2LikeGateWayImage.FileName);
                            if (chkPromo2.Checked)
                            {
                                Bitmap sourceImage = new Bitmap(filePromo2LikeGateWayImage.PostedFile.InputStream);
                                SaveImageFile(sourceImage, Server.MapPath(pathToCreate + "/LikeGateway" + filenamePromo2Logo), 111, 74);
                                hdnFooterLogo.Value = filenamePromo2Logo;
                                SessionData.Product.ProductLogo = filenamePromo2Logo;
                            }
                            else
                            {
                                filePromo2LikeGateWayImage.PostedFile.SaveAs(Server.MapPath("~/Images/" + SessionData.Product.DID + "/Logo" + filenamePromo2Logo));
                                hdnFooterLogo.Value = filenamePromo2Logo;
                                SessionData.Product.ProductLogo = filenamePromo2Logo;
                            }
                            //NOW SAVE TO PRODUCT TABLE------> PRODUCTFOOTER
                        }
                        else
                        {
                            spnErrorfileLikeGateWayImage.InnerHtml = "File size should not be greater than 1 MB"; spnErrorfileLikeGateWayImage.Style.Add("color", "Red");
                            errCount++;
                        }
                    }
                    else
                    {
                        spnErrorfileLikeGateWayImage.InnerHtml = "Upload status: Only JPEG, PNG files are accepted!"; spnErrorfileLikeGateWayImage.Style.Add("color", "Red");
                        errCount++;
                    }
                }


                if (fbBiz.IsAppCreationAllowed(SessionData.Customer.CustomerID)) //check if user is allowed to create Promos etc under his current plan *****************************************************************
                {

                    //Add Inquiry Data
                    if (!(string.IsNullOrEmpty(txtInquiryEmail.Text.Trim())))
                    {
                        SessionData.Config.SInquiryEmail = txtInquiryEmail.Text.Trim();
                    }


                    hdnWidthStatus.Value = SessionData.Product.CanvasWidth;
                    hdnHeightStatus.Value = SessionData.Product.CanvasHeight;
                    //Add TemplatePage Data

                    SessionData.Config.STemplatePage = TEMPLATE_PAGE;
                    string pathToCreate = "~/Images/" + SessionData.Product.DID;


                    //Fill up Preview Data
                    if (hdnFileHeaderHasFile.Value.Equals(HASFILE)) //New image was chosen, then do normal replace, else, bring new image
                    {
                        HeaderReplaced = createdHTML.Replace("<img id=\"imgHeader\" alt=\"\" src=\"\" />", "<img id=\"imgHeader\" src=\"Images/" + SessionData.Product.DID + "/" + "Header" + hdnHeader.Value + "\"  alt=\"\" />");

                    }
                    else
                    {
                        if (Convert.ToInt32(SessionData.Product.CanvasWidth) != Convert.ToInt32(hdnWidthStatus.Value))
                        {
                            //resize existing image by adding width and height to <img> 
                            HeaderReplaced = createdHTML.Replace("<img id=\"imgHeader\" alt=\"\" src=\"Images/" + SessionData.Product.DID + "/" + SessionData.Product.SProductHeaderImage + "\" />", "<img id=\"imgHeader\" src=\"Images/" + SessionData.Product.DID + "/" + "Header" + hdnHeader.Value + "\"  alt=\"\" width=\"" + SessionData.Product.CanvasWidth + "\" height=\"" + SessionData.Product.CanvasHeight + "/>");

                        }
                        else //dont add anything
                        {
                            HeaderReplaced = createdHTML.Replace("<img id=\"imgHeader\" alt=\"\" src=\"Images/" + SessionData.Product.DID + "/" + SessionData.Product.SProductHeaderImage + "\" />", "<img id=\"imgHeader\" src=\"Images/" + SessionData.Product.DID + "/" + "Header" + hdnHeader.Value + "\"  alt=\"\" />");
                        }

                        //check if canvas settings have changed, if so, need to resize existing image 
                    }

                    if (hdnFileContentHasFile.Value.Equals(HASFILE))
                    {
                        ContentReplaced = HeaderReplaced.Replace("<img id=\"imgContentMain\" alt=\"\" src=\"\"", "<img id=\"imgContentMain\" src=\"Images/" + SessionData.Product.DID + "/" + "Content" + hdnContent.Value + "\"  alt=\"\" />");
                    }
                    else
                    {
                        ContentReplaced = HeaderReplaced;
                    }
                    if (hdnFileFooterHasFile.Value.Equals(HASFILE))
                    {
                        FinalHTML = ContentReplaced.Replace("<img id=\"imgFooter\" alt=\"\" src=\"\" />", "<img id=\"imgFooter\" src=\"Images/" + SessionData.Product.DID + "/" + "Footer" + hdnFooter.Value + "\"  alt=\"\" />");
                    }
                    else
                    {
                        FinalHTML = ContentReplaced;
                    }
                    SessionData.Product.ProductLogo = "https://www.testsonetreach.com/Images/" + SessionData.Product.DID + "/Logo" + SessionData.Product.ProductLogo;
                    if (hdnFileHeaderHasFile.Value.Equals(HASFILE))
                    {
                        SessionData.Product.SProductHeaderImage = "Header" + hdnHeader.Value;
                    }
                    if (hdnFileContentHasFile.Value.Equals(HASFILE))
                    {
                        SessionData.Product.SProductContentImage = "Content" + hdnContent.Value;
                    }
                    if (hdnFileFooterHasFile.Value.Equals(HASFILE))
                    {
                        SessionData.Product.SProductFooterImage = "Footer" + hdnFooter.Value;
                    }
                    using (CanvasBizProcess canvasBiz = new CanvasBizProcess())
                    {
                        spnErrorPromo2Head.InnerHtml = "";
                        canvasBiz.UpdatePreviewHTML(FinalHTML, SessionData.Customer.CustomerID, SessionData.Product.DID);
                    }
                    varCount++;

                    if (!(SessionData.Config == null))
                    {
                        //Apply Campaign Dates to Config
                        if (datepickerStart.Value != "")
                        {
                            SessionData.Config.SAppStartDT = SQLSafeDates(datepickerStart.Value, true);
                            SessionData.Config.AppExpiryDT = SQLSafeDates(HiddenField1.Value, true);
                        }
                        //Now fill up the Config and get Product data.
                        if (fbBiz.UpdateConfigDetails(SessionData.Config, PROMOTIONS, SessionData.Config.SCustomtTabName))
                        {
                            ////********If user comes here we know we should set up a Product Info, So, create a row in AppProduct and assign these values to SessionData********

                            SessionData.Product.AppConfigDID = SessionData.Config.DID;
                            SessionData.Product.ProductName = SessionData.Config.AppName;
                            SessionData.Product.ProductHTML = canv.FetchFinalHTML(SessionData.Product.DID, SessionData.Customer.CustomerID);
                            fbBiz.UpdateProductDetails(SessionData.Product);
                        }
                    }
                    else
                    {
                        //No configs allowed
                        Page.ClientScript.RegisterStartupScript(this.GetType(), "myCloseScript", "alert(\"Config Not Available. Please Contact HELPDESK.\")", true);
                    }
                }
                else
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "myCloseScript", "alert(\"You can only create 3 Campaigns with a TRIAL account !\")", true);
                }

                HtmlGenericControl fbookShow = new HtmlGenericControl();
                fbookShow = (HtmlGenericControl)MainList.FindControl("FacebookDet");
                fbookShow.Style.Add("display", "block");
                hdnTabStatus.Value = STEP_THREE_COMPLETE;
            }
            catch (Exception ex)
            {
                commonUtil.SendErrorMail(ex.Message, ex.StackTrace, System.Reflection.MethodBase.GetCurrentMethod().Name.ToString(), System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.ToString(), SessionData.Customer.CustomerID);
            }
        }

    }//eoc
}//eons