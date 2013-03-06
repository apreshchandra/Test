using System;
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
using System.Drawing;
using Newtonsoft;
using Newtonsoft.Json.Linq;
using System.Drawing.Imaging;
using System.Text.RegularExpressions;
using System.IO;


namespace DigiMa
{
    public partial class EditCanvasAreaPromoVideo : System.Web.UI.Page
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
        VideoShareData oVidShareData = new VideoShareData();
        //Wizard wzd = new Wizard();
        private const string EMPTYSTRING = "";
        private const string PROMOTIONS = "";
        private const string LIKE_GATEWAY = "LIKE_GATEWAY";
        private const string TAB_LOGO = "TAB_LOGO";
        private const string APP_EXPIRY_IMAGE = "APP_EXPIRY_IMAGE";
        private const string STEP_THREE_COMPLETE = "step_three_complete";
        private const string STEP_TWO_COMPLETE = "step_two_complete";
        private const string STEP_ONE_COMPLETE = "step_one_complete";
        private const string TEMPLATE_PAGE = "EditCanvasAreaPromoVideo.aspx";
        private const string SIX = "6";
        private const string TRUE = "Y";
        private const string HASFILE = "has file";
        private string CDID = string.Empty;
        string methodName;
        string className;
        string pathToCreate = string.Empty;
        string appCode = string.Empty;
        string appID = string.Empty;
        string appSecret = string.Empty;
        private const int ONE_MB = 1048576;
        private const int COUPON_HEIGHT = 100;
        private const int COUPON_WIDTH = 500;
        string templateID;
        string maint;
        int varCount = 0;
        int errCount = 0;
        string iframecontent;
        string iframecontentOld;
        string HeaderReplaced;
        string ContentReplaced;
        string FinalHTML;
        private string ActiveURL;
        string HeaderBannerReplaced;
        string HeaderBannerURLReplaced;


        protected void Page_Load(object sender, EventArgs e)
        {
            btnRefresh.Click += new EventHandler(btnRefresh_Click);
            Response.Cache.SetCacheability(HttpCacheability.Private);
            ActiveURL = ConfigurationSettings.AppSettings["ActiveURL"];
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
                //tdLogout.Visible = true;
                //tdLogin.Visible = false;
                //tdSignup.Visible = false;
            }
            if (Request["Maint"] != null)
            {
                maint = Request["Maint"].ToString();
            }
            if (Request["CustomerName"] != null)
            {
                SessionData.Customer.SCustomerUserName = Convert.ToString(Request["CustomerName"]);
            }



            if (!IsPostBack)
            {
                if (Request["Appname"] != null)
                {
                    SessionData.Config = new AppConfiguration();
                    SessionData.Config.AppName = Convert.ToString(Request["Appname"]);
                }

                if (Request["Maint"] != null)
                {
                    //Fetch Campaign Info from AppConfiguration and AppProduct
                    FacebookBizProcess oFBBiz = new FacebookBizProcess();
                    SessionData.Config = oFBBiz.GetAppConfiguration(SessionData.Config.AppName, "");
                    SessionData.Product = oFBBiz.GetActiveAppProduct(null, SessionData.Config.DID);

                    oVidShareData = fbBiz.GetVideoShareData(SessionData.Config.DID);

                    //Now prefill all the values

                    txtCustomTabNamePromo2.Text = SessionData.Config.SCustomtTabName;

                    //Sweepstakes Details tab
                    txtHeaderText.Text = SessionData.Product.AppCaption;
                    txtVideoURL.Text = oVidShareData.SVideoShareURL;
                    txtDescription.Text = oVidShareData.SVideoShareDesc;
                    txtBannerURL.Text = SessionData.Product.SHeaderBannerURL;

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
                        txtInquiryEmail.Visible = true;
                        txtInquiryEmail.Text = SessionData.Config.SInquiryEmail;
                    }
                    if (SessionData.Product.CommentsWidgetAdded.Equals(TRUE))
                    {
                        chkComment.Checked = true;
                    }
                    if (SessionData.Product.LikeWidgetAdded.Equals(TRUE))
                    {
                        chkLike.Checked = true;
                    }

                    string startDate = SessionData.Config.SAppStartDT;
                    string endDate = SessionData.Config.AppExpiryDT;

                    if (!string.IsNullOrEmpty(startDate))
                    {
                        DateTime sd = DateTime.Parse(startDate);
                        datepickerStart.Value = sd.ToString("dd/MM/yyyy");
                    }

                    if (!string.IsNullOrEmpty(endDate))
                    {
                        DateTime end = DateTime.Parse(endDate);
                        datepickerEnd.Value = end.ToString("dd/MM/yyyy");
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
                btnPreviewCampaign.Disabled = false;

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
                camp.Style.Add("display", "block");


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
                    oSBPageSElector.Append(SessionData.Config.AppID + "&redirect_uri=" + ActiveURL + SessionData.Config.AppID + "&response_type=code&perms=user_birthday,user_location,email,manage_pages,publish_stream\','name','height=570,width=960,menubar=0,toolbar=0,statusbar=0,scrollbars=0,resizable=0');");
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

                //Prepare file system directory to store Images
                string pathToCreate = "~/Images/" + SessionData.Product.DID;
                if (!Directory.Exists(Server.MapPath(pathToCreate)))
                {
                    Directory.CreateDirectory(Server.MapPath(pathToCreate));
                }

                //Logo Image
                if (filePromoVideoLogo.HasFile)
                {
                    if (filePromoVideoLogo.PostedFile.ContentType == "image/jpeg" || filePromoVideoLogo.PostedFile.ContentType == "image/png" || filePromoVideoLogo.PostedFile.ContentType == "image/jpg" || filePromoVideoLogo.PostedFile.ContentType == "image/pjpeg")
                    {
                        if (filePromoVideoLogo.FileBytes.Length < 1048576)
                        {
                            string filenamePromo2Logo = Path.GetFileName(filePromoVideoLogo.FileName);

                            Bitmap sourceImage = new Bitmap(filePromoVideoLogo.PostedFile.InputStream);
                            SaveImageFile(sourceImage, Server.MapPath(pathToCreate + "/Logo" + filenamePromo2Logo), 111, 74);
                            hdnFooterLogo.Value = filenamePromo2Logo;
                            SessionData.Product.ProductLogo = filenamePromo2Logo;
                        }
                        else
                        {
                            spnErrorPromoVid.InnerHtml = "File size should not be greater than 1 MB"; spnErrorPromoVid.Style.Add("color", "Red");
                            errCount++;
                        }
                    }
                    else
                    {
                        spnErrorPromoVid.InnerHtml = "Upload status: Only JPEG, PNG files are accepted!"; spnErrorPromoVid.Style.Add("color", "Red");
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
                //Fetch Template Data
                dsTemplateData = canv.GetTempData(Convert.ToInt32(templateID)); //REVISIT
                hdnTrmplateID.Value = templateID;


                //Prepare file system directory to store Images
                string pathToCreate = "~/Images/" + SessionData.Product.DID;

                hdnPDID.Value = SessionData.Product.DID;
                hdnfield.Value = CDID;
                if (!Directory.Exists(Server.MapPath(pathToCreate)))
                {
                    Directory.CreateDirectory(Server.MapPath(pathToCreate));
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
                            string filenamePromoVidLG = Path.GetFileName(filePromo2LikeGateWayImage.FileName);

                            Bitmap sourceImage = new Bitmap(filePromo2LikeGateWayImage.PostedFile.InputStream);
                            SaveImageFile(sourceImage, Server.MapPath(pathToCreate + "/LikeGateway" + filenamePromoVidLG), Convert.ToInt32(SessionData.Product.CanvasHeight), Convert.ToInt32(SessionData.Product.CanvasWidth));
                            hdnFooterLogo.Value = filenamePromoVidLG;
                            SessionData.Product.ProductLogo = filenamePromoVidLG;
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


                //Header Banner Image
                if (imgBanner.HasFile)
                {
                    hdnFileBannerHasFile.Value = HASFILE;
                    if (imgBanner.PostedFile.ContentType == "image/jpeg" || imgBanner.PostedFile.ContentType == "image/png" || imgBanner.PostedFile.ContentType == "image/jpg" || imgBanner.PostedFile.ContentType == "image/pjpeg")
                    {
                        if (imgBanner.FileBytes.Length < ONE_MB)
                        {
                            string imgBannerPromo2 = Path.GetFileName(imgBanner.FileName);

                            Bitmap sourceImage = new Bitmap(imgBanner.PostedFile.InputStream);
                            SaveImageFile(sourceImage, Server.MapPath(pathToCreate + "/Banner" + imgBannerPromo2), COUPON_HEIGHT, COUPON_WIDTH);
                            hdnBanner.Value = imgBannerPromo2;

                        }
                    }
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

                    SessionData.Config.SCustomtTabName = txtCustomTabNamePromo2.Text.Trim();
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
                oVidShareData = fbBiz.GetVideoShareData(SessionData.Config.DID);

                //Like Gateway
                if (chkLikeGateway.Checked)
                {
                    SessionData.Product.LikeGatewayAdded = "Y";
                    //Save LikeGateway Image
                    if (filePromo2LikeGateWayImage.HasFile)
                    {
                        if (filePromo2LikeGateWayImage.PostedFile.ContentType == "image/jpeg" || filePromo2LikeGateWayImage.PostedFile.ContentType == "image/png" || filePromo2LikeGateWayImage.PostedFile.ContentType == "image/jpg" || filePromo2LikeGateWayImage.PostedFile.ContentType == "image/pjpeg")
                        {
                            if (filePromo2LikeGateWayImage.FileBytes.Length < 1048576)
                            {
                                string filenamePromo2Logo = Path.GetFileName(filePromo2LikeGateWayImage.FileName);

                                Bitmap sourceImage = new Bitmap(filePromo2LikeGateWayImage.PostedFile.InputStream);
                                SaveImageFile(sourceImage, Server.MapPath(pathToCreate + "/LikeGateway" + filenamePromo2Logo), 111, 74);
                                hdnFooterLogo.Value = filenamePromo2Logo;
                                SessionData.Product.ProductLogo = filenamePromo2Logo;

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
                }
                if (fbBiz.IsAppCreationAllowed(SessionData.Customer.CustomerID))
                {
                    FaceBook ofacebook = new FaceBook();
                    AppUser oAppUser = new AppUser();

                    if ((Regex.IsMatch(txtVideoURL.Text.Trim(), @"(http|https)://([\w-]+\.)+[\w-]+(/[\w- ./?%&=]*)?")) && (txtVideoURL.Text.Trim().Contains("youtube")))
                    {
                        iframecontent = ofacebook.GetEmbedURL(txtVideoURL.Text.Trim(), oAppUser);
                        iframecontentOld = ofacebook.GetEmbedURL(oVidShareData.SVideoShareURL, oAppUser);

                        string fixedURL = FixVideoURL(iframecontent);
                        string fixedUrlOld = FixVideoURL(iframecontentOld);
                        //Now update VideoShareData
                        fbBiz.UpdateVideoShareData(SessionData.Config.DID, txtVideoURL.Text.Trim(), fixedURL, txtDescription.Text.Trim());

                        if (!iframecontent.Equals(string.Empty))
                        {
                            string[] newEmbedURL = iframecontent.Split(' ');
                            string finalURL = newEmbedURL[3].Remove(0, 4);

                            string[] oldEmbedURL = iframecontentOld.Split(' ');
                            string oldfinalURL = oldEmbedURL[3].Remove(0, 4);
                            if (!txtVideoURL.Text.Contains("autoplay"))
                            {
                                if (!txtVideoURL.Text.Contains("?"))
                                {
                                    if (!(string.IsNullOrEmpty(txtBannerURL.Text.Trim()))) //New image was chosen, then do normal replace, else, bring new image 
                                    //SessionData.Product.SHeaderBannerURL != txtBannerURL.Text
                                    {
                                        HeaderBannerURLReplaced = createdHTML.Replace(SessionData.Product.SHeaderBannerURL, txtBannerURL.Text);
                                    }
                                    else
                                    {
                                        HeaderBannerURLReplaced = createdHTML.Replace(" <a id=\"aHeadBanner\" href=\"\" target=\"_blank\">", "<a id=\"aHeadBanner\" href=" + SessionData.Product.SHeaderBannerURL + " target=\"_blank\" >"); // Replace Banner URL
                                    }


                                    if (hdnFileBannerHasFile.Value.Equals(HASFILE)) //New image was chosen, then do normal replace, else, bring new image
                                    {
                                        HeaderBannerReplaced = HeaderBannerURLReplaced.Replace(SessionData.Product.SHeaderBannerImg, hdnBanner.Value);
                                    }
                                    else
                                    {

                                        HeaderBannerReplaced = HeaderBannerURLReplaced.Replace("<img id=\"imgBanner\" alt=\"\" src=\"Images/" + SessionData.Product.DID + "/" + SessionData.Product.SHeaderBannerImg + "\" style=\"width: 500px; height: 100px;\" />", "<img id=\"imgBanner\" alt=\"\" src=\"Images/" + SessionData.Product.DID + "/" + "Banner" + hdnBanner.Value + "\"  style=\"width: 500px; height: 100px;\" />");

                                        //check if canvas settings have changed, if so, need to resize existing image 
                                    }
                                    string ParamAdded = HeaderBannerReplaced.Replace(oldfinalURL, finalURL);
                                    string ObjectAdded = ParamAdded.Replace(fixedUrlOld, fixedURL);
                                    string DescriptionAdded = ObjectAdded.Replace(oVidShareData.SVideoShareDesc, txtDescription.Text.Trim().Replace("'", "''"));
                                    using (CanvasBizProcess canvasBiz = new CanvasBizProcess())
                                    {
                                        canvasBiz.UpdatePreviewHTML(DescriptionAdded, SessionData.Customer.CustomerID, SessionData.Product.DID);

                                    }
                                    varCount++;
                                }
                                else
                                {
                                    if (!(string.IsNullOrEmpty(txtBannerURL.Text.Trim()))) //New image was chosen, then do normal replace, else, bring new image 
                                    //SessionData.Product.SHeaderBannerURL != txtBannerURL.Text
                                    {
                                        HeaderBannerURLReplaced = createdHTML.Replace(SessionData.Product.SHeaderBannerURL, txtBannerURL.Text);
                                    }
                                    else
                                    {
                                        HeaderBannerURLReplaced = createdHTML.Replace(" <a id=\"aHeadBanner\" href=\"\" target=\"_blank\">", "<a id=\"aHeadBanner\" href=" + SessionData.Product.SHeaderBannerURL + " target=\"_blank\" >"); // Replace Banner URL
                                    }


                                    if (hdnFileBannerHasFile.Value.Equals(HASFILE)) //New image was chosen, then do normal replace, else, bring new image
                                    {
                                        HeaderBannerReplaced = HeaderBannerURLReplaced.Replace(SessionData.Product.SHeaderBannerImg, hdnBanner.Value);
                                    }
                                    else
                                    {

                                        HeaderBannerReplaced = HeaderBannerURLReplaced.Replace("<img id=\"imgBanner\" alt=\"\" src=\"Images/" + SessionData.Product.DID + "/" + SessionData.Product.SHeaderBannerImg + "\" style=\"width: 500px; height: 100px;\" />", "<img id=\"imgBanner\" alt=\"\" src=\"Images/" + SessionData.Product.DID + "/" + "Banner" + hdnBanner.Value + "\"  style=\"width: 500px; height: 100px;\" />");

                                        //check if canvas settings have changed, if so, need to resize existing image 
                                    }
                                    string ParamAdded = HeaderBannerReplaced.Replace(oldfinalURL, finalURL);
                                    string ObjectAdded = ParamAdded.Replace(fixedUrlOld, fixedURL);
                                    string DescriptionAdded = ObjectAdded.Replace(oVidShareData.SVideoShareDesc, txtDescription.Text.Trim().Replace("'", "''"));
                                    using (CanvasBizProcess canvasBiz = new CanvasBizProcess())
                                    {
                                        canvasBiz.UpdatePreviewHTML(DescriptionAdded, SessionData.Customer.CustomerID, SessionData.Product.DID);
                                    }
                                    varCount++;
                                }
                            }
                            else
                            {
                                if (!(string.IsNullOrEmpty(txtBannerURL.Text.Trim()))) //New image was chosen, then do normal replace, else, bring new image 
                                {
                                    HeaderBannerURLReplaced = createdHTML.Replace(SessionData.Product.SHeaderBannerURL, txtBannerURL.Text);
                                }
                                else
                                {
                                    HeaderBannerURLReplaced = createdHTML.Replace(" <a id=\"aHeadBanner\" href=\"\" target=\"_blank\">", "<a id=\"aHeadBanner\" href=" + SessionData.Product.SHeaderBannerURL + " target=\"_blank\" >"); // Replace Banner URL
                                }


                                if (hdnFileBannerHasFile.Value.Equals(HASFILE)) //New image was chosen, then do normal replace, else, bring new image
                                {
                                    HeaderBannerReplaced = HeaderBannerURLReplaced.Replace(SessionData.Product.SHeaderBannerImg, hdnBanner.Value);
                                }
                                else
                                {

                                    HeaderBannerReplaced = HeaderBannerURLReplaced.Replace("<img id=\"imgBanner\" alt=\"\" src=\"Images/" + SessionData.Product.DID + "/" + SessionData.Product.SHeaderBannerImg + "\" style=\"width: 500px; height: 100px;\" />", "<img id=\"imgBanner\" alt=\"\" src=\"Images/" + SessionData.Product.DID + "/" + "Banner" + hdnBanner.Value + "\"  style=\"width: 500px; height: 100px;\" />");

                                    //check if canvas settings have changed, if so, need to resize existing image 
                                }
                                string ParamAdded = HeaderBannerReplaced.Replace(oldfinalURL, finalURL);
                                string ObjectAdded = ParamAdded.Replace(fixedUrlOld, fixedURL);
                                string DescriptionAdded = ObjectAdded.Replace(oVidShareData.SVideoShareDesc, txtDescription.Text.Trim().Replace("'", "''"));

                                //make all videos play automatically
                                string autoPlayed = DescriptionAdded.Replace("autoplay=0", "autoplay=0");
                                using (CanvasBizProcess canvasBiz = new CanvasBizProcess())
                                {
                                    canvasBiz.UpdatePreviewHTML(autoPlayed, SessionData.Customer.CustomerID, SessionData.Product.DID);
                                }
                                varCount++;
                            }
                        }
                        else
                        {

                        }
                    }
                    else
                    {

                    }

                    if (hdnFileBannerHasFile.Value.Equals(HASFILE))
                    {
                        SessionData.Product.SHeaderBannerImg = hdnBanner.Value;
                    }

                    // Add Banner URL
                    if (!(string.IsNullOrEmpty(txtBannerURL.Text.Trim())))
                    {
                        SessionData.Product.SHeaderBannerURL = txtBannerURL.Text.Trim();
                    }

                    if (!(SessionData.Config == null))
                    {
                        if (datepickerStart.Value != "")
                        {
                            SessionData.Config.SAppStartDT = SQLSafeDates(datepickerStart.Value, true);
                            SessionData.Config.AppExpiryDT = SQLSafeDates(datepickerEnd.Value, true);
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
    }
}