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
    public partial class CanvasAreaPromoVideo : System.Web.UI.Page
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
        private const string TEMPLATE_PAGE = "EditCanvasAreaPromoVideo.aspx";
        private string CDID = string.Empty;
        string methodName;
        string className;
        string pathToCreate = string.Empty;
        string appCode = string.Empty;
        string appID = string.Empty;
        string appSecret = string.Empty;

        string templateID;
        int varCount = 0;
        int errCount = 0;
        string iframecontent;
        private const string Promo = "PROMO";
        private const string Video = "VIDEO";
        private const string Coupon = "COUPON";
        private const string Sweepstakes = "SWEEPSTAKES";
        private string ActiveURL;
        private const int ONE_MB = 1048576;


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
            if (!string.IsNullOrEmpty(Request["CDID"].ToString()))
            {
                CDID = Request["CDID"].ToString();

                //create session based on CDID
                if (SessionData.Customer.CustomerID == null || SessionData.Customer.CustomerID == "")
                {
                    SessionData.Customer = new AppCustomer();
                    SessionData.Customer = canv.GetCustomerInfo(null, CDID, false);
                }
            }
            if (!string.IsNullOrEmpty(Request["TID"].ToString()))
            {
                templateID = Request["TID"].ToString();
                //tdLogout.Visible = true;
                //tdLogin.Visible = false;
                //tdSignup.Visible = false;
            }

            if (hdnTabStatus.Value.Equals(STEP_TWO_COMPLETE))
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
                framePage.Attributes.Add("src", "SelectPage.aspx?code=" + hdnCode.Value + "&app_id=" + hdnAppid.Value);
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
                    int windowCountKeeper =0;
                    StringBuilder oSBPageSElector = new StringBuilder();
                    oSBPageSElector.Append("window.open('http://www.facebook.com/dialog/permissions.request?app_id=");
                    oSBPageSElector.Append(SessionData.Config.AppID + "&redirect_uri=" + ActiveURL + SessionData.Config.AppID + "&response_type=code&perms=user_birthday,user_location,email,manage_pages\','name','height=570,width=960,menubar=0,toolbar=0,statusbar=0,scrollbars=0,resizable=0');");
                    litLogin.Text = oSBPageSElector.ToString();
                    windowCountKeeper++;
                    // added a comment to test Jira_Test
                }
            }
            catch (Exception ex)
            {
                commonUtil.SendErrorMail(ex.Message, ex.StackTrace, System.Reflection.MethodBase.GetCurrentMethod().Name.ToString(), System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.ToString(), SessionData.Customer.CustomerID);
            }
        }

        public string GetNewDIDWithPrefix()
        {
            return GetNewDID("AP");
        }

        public string GetNewDID(string sPrefixValue)
        {
            StringBuilder sb = new StringBuilder(20);

            if (sPrefixValue.Length > 0) sb.Append(sPrefixValue);
            sb.Append(GetNewUID());

            return sb.ToString();
        }

        private string GetNewUID()
        {
            char[] BASE31DIGITS = "0123456789BCDFGHJKLMNPQRSTVWXYZ".ToCharArray();
            int N_BASESIZE = 31;
            Guid newGUID = System.Guid.NewGuid();
            byte[] guidBytes = newGUID.ToByteArray();

            Int64 n1 = default(Int64);
            StringBuilder didSB = new StringBuilder(18);

            //put bytes in an int64 like C++ code
            n1 = n1 | guidBytes[7];
            n1 = n1 << 8;
            n1 = n1 | guidBytes[6];
            n1 = n1 << 8;
            n1 = n1 | guidBytes[5];
            //reversed from my other code, big-endian vs little
            n1 = n1 << 8;
            n1 = n1 | guidBytes[4];
            //5 was here before
            n1 = n1 << 8;
            n1 = n1 | guidBytes[3];
            n1 = n1 << 8;
            n1 = n1 | guidBytes[2];
            n1 = n1 << 8;
            n1 = n1 | guidBytes[1];
            n1 = n1 << 8;
            n1 = n1 | guidBytes[0];

            //convert to base31
            long longresult = 0;
            while (n1 > 0)
            {
                Math.DivRem(n1, Convert.ToInt64(N_BASESIZE), out longresult);
                didSB.Insert(0, Convert.ToString(BASE31DIGITS[Convert.ToInt32(longresult)]));
                n1 /= N_BASESIZE; //division not right here
            }

            //left pad with 0's to 13 chars
            while (didSB.Length < 11)
            {
                didSB.Insert(0, "0");
            }

            n1 = guidBytes[8];
            n1 = n1 & 31; //strip high 3 bits
            //CByte("&H1f") 'same as 31
            n1 <<= 8; //shift left 8 bits
            n1 = n1 | guidBytes[9];

            //convert to base31
            while (n1 > 0)
            {
                Math.DivRem(n1, Convert.ToInt64(N_BASESIZE), out longresult);
                didSB.Insert(0, Convert.ToString(BASE31DIGITS[Convert.ToInt32(longresult)]));
                n1 /= N_BASESIZE;
                // / division not right here
            }

            //left pad with 0's to 16 chars
            while (didSB.Length < 16)
            {
                didSB.Insert(0, "0");
            }

            //now append MachineID prefix.
            didSB.Insert(0, "00");
            return didSB.ToString();
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
                SessionData.Product = new AppProduct();
                SessionData.Product.DID = GetNewDIDWithPrefix();

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
                        if (filePromoVideoLogo.FileBytes.Length < ONE_MB)
                        {
                            string filenamePromo2Logo = Path.GetFileName(filePromoVideoLogo.FileName);

                            Bitmap sourceImage = new Bitmap(filePromoVideoLogo.PostedFile.InputStream);
                            SaveImageFile(sourceImage, Server.MapPath(pathToCreate + "/Logo" + filenamePromo2Logo), 111, 74);
                            hdnFooterLogo.Value = filenamePromo2Logo;
                            SessionData.Product.ProductLogo = filenamePromo2Logo;
                        }
                        else
                        {

                        }
                    }
                    else
                    {

                    }
                }


                //Fetch Template Data
                dsTemplateData = canv.GetTempData(Convert.ToInt32(templateID)); //REVISIT
                hdnTrmplateID.Value = templateID;

                hdnPDID.Value = SessionData.Product.DID;
                hdnfield.Value = CDID;
                if (!Directory.Exists(Server.MapPath(pathToCreate)))
                {
                    Directory.CreateDirectory(Server.MapPath(pathToCreate));
                }

                //Custom Tab Name
                if (!txtCustomTabNamePromoVid.Text.Trim().Equals(string.Empty))
                {

                    SessionData.Config.SCustomtTabName = txtCustomTabNamePromoVid.Text.Trim();
                }


                //Header Banner Image
                if (imgBanner.HasFile)
                {
                    if (imgBanner.PostedFile.ContentType == "image/jpeg" || imgBanner.PostedFile.ContentType == "image/png" || imgBanner.PostedFile.ContentType == "image/jpg" || imgBanner.PostedFile.ContentType == "image/pjpeg")
                    {
                        if (imgBanner.FileBytes.Length < ONE_MB)
                        {
                            string imgBannerPromo2 = Path.GetFileName(imgBanner.FileName);

                            Bitmap sourceImage = new Bitmap(imgBanner.PostedFile.InputStream);
                            if (SessionData.Product.CanvasHeight == string.Empty)
                            {
                                SaveImageFile(sourceImage, Server.MapPath(pathToCreate + "/Banner" + imgBannerPromo2), Convert.ToInt32(SessionData.Product.CanvasWidth), 700);
                            }
                            else if (SessionData.Product.CanvasWidth == string.Empty)
                            {
                                SaveImageFile(sourceImage, Server.MapPath(pathToCreate + "/Banner" + imgBannerPromo2), 500, Convert.ToInt32(SessionData.Product.CanvasHeight));
                            }
                            else if (SessionData.Product.CanvasHeight == string.Empty && SessionData.Product.CanvasWidth == string.Empty)
                            {
                                SaveImageFile(sourceImage, Server.MapPath(pathToCreate + "/Banner" + imgBannerPromo2), 500, 700);
                            }
                            else
                            {
                                SaveImageFile(sourceImage, Server.MapPath(pathToCreate + "/Banner" + imgBannerPromo2), 500, 100);
                            }
                            hdnBanner.Value = imgBannerPromo2;

                            //NOW SAVE TO PRODUCT TABLE------> PRODUCTFOOTER
                        }
                    }
                }

                //Caption
                if (!string.IsNullOrEmpty(txtHeaderText.Text))
                {
                    SessionData.Product.AppCaption = txtHeaderText.Text;
                }

                //Start Date, Expiry Date
                FacebookBizProcess fbBiz = new FacebookBizProcess();
                if (fbBiz.IsAppCreationAllowed(SessionData.Customer.CustomerID)) //check if user is allowed to create Promos etc under his current plan *****************************************************************
                {
                    SessionData.Config = fbBiz.GetAvailableConfig(CDID);


                    //Add Inquiry Data
                    if (!(string.IsNullOrEmpty(txtInquiryEmail.Text.Trim())))
                    {
                        SessionData.Config.SInquiryEmail = txtInquiryEmail.Text.Trim();
                    }

                    SessionData.Config.STemplatePage = TEMPLATE_PAGE;




                    if (!(SessionData.Config == null))
                    {
                        //Apply Campaign Dates to Config
                        if (datepickerStart.Value != "")
                        {
                            SessionData.Config.SAppStartDT = SQLSafeDates(datepickerStart.Value, true);
                            SessionData.Config.AppExpiryDT = SQLSafeDates(HiddenField1.Value, true);
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
                dsTemplateData = canv.GetTempData(Convert.ToInt32(templateID)); //REVISIT
                hdnTrmplateID.Value = templateID;

                //Save Widgets info and Cust Tab name, then move to FB tab
                //Custom Tab Name
                if (!txtCustomTabNamePromoVid.Text.Trim().Equals(string.Empty))
                {

                    SessionData.Config.SCustomtTabName = txtCustomTabNamePromoVid.Text.Trim();
                }


                //Widgets
                if (chkShareButton.Checked)
                {
                    SessionData.Product.ShareWidgetAdded = "Y";

                }
                if (chkInquiry.Checked)
                {
                    SessionData.Product.InquiryWidgetAdded = "Y";
                }
                if (chkRecc.Checked)
                {
                    SessionData.Product.ReccWidgetAdded = "Y";
                }
                if (chkComment.Checked)
                {
                    SessionData.Product.CommentsWidgetAdded = "Y";
                }
                if (chkLike.Checked)
                {
                    SessionData.Product.LikeWidgetAdded = "Y";
                }
                if (chkTweeter.Checked)
                {
                    SessionData.Product.TwitterWidgetAdded = "Y";

                }

                //Like Gateway
                if (chkLikeGateway.Checked)
                {
                    SessionData.Product.LikeGatewayAdded = "Y";
                    //Save LikeGateway Image
                    if (filePromo2LikeGateWayImage.HasFile)
                    {
                        if (filePromo2LikeGateWayImage.PostedFile.ContentType == "image/jpeg" || filePromo2LikeGateWayImage.PostedFile.ContentType == "image/png" || filePromo2LikeGateWayImage.PostedFile.ContentType == "image/jpg" || filePromo2LikeGateWayImage.PostedFile.ContentType == "image/pjpeg")
                        {
                            if (filePromo2LikeGateWayImage.FileBytes.Length < ONE_MB)
                            {
                                string filenamePromo2Logo = Path.GetFileName(filePromo2LikeGateWayImage.FileName);

                                Bitmap sourceImage = new Bitmap(filePromo2LikeGateWayImage.PostedFile.InputStream);
                                SaveImageFile(sourceImage, Server.MapPath(pathToCreate + "/LikeGateway" + filenamePromo2Logo), 111, 74);
                                hdnFooterLogo.Value = filenamePromo2Logo;
                                SessionData.Product.ProductLogo = filenamePromo2Logo;

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
                }

                FacebookBizProcess fbBiz = new FacebookBizProcess();

                FaceBook ofacebook = new FaceBook();
                AppUser oAppUser = new AppUser();

                if ((Regex.IsMatch(txtVideoURL.Text.Trim(), @"(http|https)://([\w-]+\.)+[\w-]+(/[\w- ./?%&=]*)?")) && (txtVideoURL.Text.Trim().Contains("youtube")))
                {
                    iframecontent = ofacebook.GetEmbedURL(txtVideoURL.Text.Trim(), oAppUser);
                    string fixedURL = FixVideoURL(iframecontent);
                    //Now save the Video details
                    fbBiz.InsertVideoShareData(SessionData.Config.DID, txtVideoURL.Text.Trim(), fixedURL, txtDescription.Text.Trim());

                    if (!iframecontent.Equals(string.Empty))
                    {
                        string[] newEmbedURL = iframecontent.Split(' ');
                        string finalURL = newEmbedURL[3].Remove(0, 4);
                        if (!txtVideoURL.Text.Contains("autoplay"))
                        {
                            if (!txtVideoURL.Text.Contains("?"))
                            {
                                string tempData6 = dsTemplateData.Tables[0].Rows[0]["thtml"].ToString();

                                //Fill up Preview Data
                                string HeaderBannerURLReplaced = tempData6.Replace(" <a id=\"aHeadBanner\" href=\"\" target=\"_blank\">", "<a id=\"aHeadBanner\" href=" + txtBannerURL.Text + " target=\"_blank\" >"); // Replace Banner URL
                                string HeaderBannerReplaced = HeaderBannerURLReplaced.Replace("<img id=\"imgBanner\" alt=\"\" src=\"\" style=\"width: 500px; height: 100px;\" />", "<img id=\"imgBanner\" alt=\"\" src=\"Images/" + SessionData.Product.DID + "/" + "Banner" + hdnBanner.Value + "\" style=\"width: 500px; height: 100px;\"/>"); // Replace Banner Image

                                string ParamAdded = HeaderBannerReplaced.Replace("<paramss>", "<param name=\"movie\" value=\"" + finalURL + "?autoplay=0\">");
                                string ObjectAdded = ParamAdded.Replace("<iframe>", fixedURL);
                                string DescriptionAdded = ObjectAdded.Replace("</span>", txtDescription.Text.Trim().Replace("'", "''") + "</span>");
                                using (CanvasBizProcess canvasBiz = new CanvasBizProcess())
                                {
                                    canvasBiz.InsertPreviewHTML(DescriptionAdded, SessionData.Customer.CustomerID, SessionData.Product.DID);

                                }
                                varCount++;
                            }
                            else
                            {
                                string tempData6 = dsTemplateData.Tables[0].Rows[0]["thtml"].ToString();


                                //Fill up Preview Data
                                string HeaderBannerURLReplaced = tempData6.Replace(" <a id=\"aHeadBanner\" href=\"\" target=\"_blank\">", "<a id=\"aHeadBanner\" href=" + txtBannerURL.Text + " target=\"_blank\" >"); // Replace Banner URL
                                string HeaderBannerReplaced = HeaderBannerURLReplaced.Replace("<img id=\"imgBanner\" alt=\"\" src=\"\" style=\"width: 500px; height: 100px;\" />", "<img id=\"imgBanner\" alt=\"\" src=\"Images/" + SessionData.Product.DID + "/" + "Banner" + hdnBanner.Value + "\" style=\"width: 500px; height: 100px;\"/>"); // Replace Banner Image
                                string ParamAdded = HeaderBannerReplaced.Replace("<paramss>", "<param name=\"movie\" value=" + "\"" + finalURL + "&autoplay=0\">");
                                string ObjectAdded = ParamAdded.Replace("<iframe>", fixedURL);
                                string DescriptionAdded = ObjectAdded.Replace("NIOTPESRIC", txtDescription.Text.Trim().Replace("'", "''"));
                                using (CanvasBizProcess canvasBiz = new CanvasBizProcess())
                                {
                                    canvasBiz.InsertPreviewHTML(DescriptionAdded, SessionData.Customer.CustomerID, SessionData.Product.DID);
                                }
                                varCount++;
                            }
                        }
                        else
                        {
                            string tempData6 = dsTemplateData.Tables[0].Rows[0]["thtml"].ToString();

                            //Fill up Preview Data
                            string HeaderBannerURLReplaced = tempData6.Replace(" <a id=\"aHeadBanner\" href=\"\" target=\"_blank\">", "<a id=\"aHeadBanner\" href=" + txtBannerURL.Text + " target=\"_blank\" >"); // Replace Banner URL
                            string HeaderBannerReplaced = HeaderBannerURLReplaced.Replace("<img id=\"imgBanner\" alt=\"\" src=\"\" style=\"width: 500px; height: 100px;\" />", "<img id=\"imgBanner\" alt=\"\" src=\"Images/" + SessionData.Product.DID + "/" + "Banner" + hdnBanner.Value + "\" style=\"width: 500px; height: 100px;\"/>"); // Replace Banner Image
                            string ParamAdded = HeaderBannerReplaced.Replace("<paramss>", "<param name=\"movie\" value=\"" + finalURL + "\">");
                            string ObjectAdded = ParamAdded.Replace("<iframe>", iframecontent);
                            string DescriptionAdded = ObjectAdded.Replace("NIOTPESRIC", txtDescription.Text.Trim().Replace("'", "''"));

                            //make all videos play automatically
                            string autoPlayed = DescriptionAdded.Replace("autoplay=0", "autoplay=0");
                            using (CanvasBizProcess canvasBiz = new CanvasBizProcess())
                            {
                                canvasBiz.InsertPreviewHTML(autoPlayed, SessionData.Customer.CustomerID, SessionData.Product.DID);
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

                // Set Header Banner URL and Header Image in Product
                SessionData.Product.SHeaderBannerURL = txtBannerURL.Text;
                SessionData.Product.SHeaderBannerImg = hdnBanner.Value;
                SessionData.Product.ProductLogo = "https://www.sonetreach.com/Images/" + SessionData.Product.DID + "/Logo" + SessionData.Product.ProductLogo;
                SessionData.Product.SProductContentImage = "Body" + hdnContent.Value;


                if (!(SessionData.Config == null))
                {
                    //Apply Campaign Dates to Config
                    if (datepickerStart.Value != "")
                    {
                        SessionData.Config.SAppStartDT = SQLSafeDates(datepickerStart.Value, true);
                        SessionData.Config.AppExpiryDT = SQLSafeDates(datepickerEnd.Value, true);
                    }
                    //Now fill up the Config and get Product data.
                    SessionData.Config.SCampaignType = Video;
                    if (fbBiz.SetNewConfigDetails(SessionData.Config, SessionData.Config.SCustomtTabName,Video))
                    {
                        ////********If user comes here we know we should set up a Product Info, So, create a row in AppProduct and assign these values to SessionData********

                        SessionData.Product.AppConfigDID = SessionData.Config.DID;
                        SessionData.Product.ProductName = SessionData.Config.AppName;
                        SessionData.Product.ProductHTML = canv.FetchFinalHTML(SessionData.Product.DID, CDID);
                        fbBiz.SetNewProductDetails(SessionData.Product);

                        SessionData.Product = fbBiz.GetAppProductDetails();

                        // Now Enable the Facebook Tab

                    }
                }
                else
                {
                    //No configs allowed
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "myCloseScript", "alert(\"Config Not Available. Please Contact HELPDESK.\")", true);
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