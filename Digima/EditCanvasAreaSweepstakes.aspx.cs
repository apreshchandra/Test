using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data;
using System.Web.UI;
using DigiMa.BizProcess;
using System.Collections;
using System.IO;
using System.Text;
using DigiMa.Common;
using DigiMa.Data;
using System.Web.UI.WebControls;
using System.Drawing;
using System.Drawing.Imaging;
using System.Text.RegularExpressions;
using System.Web.UI.HtmlControls;
using System.Net;

namespace DigiMa
{
    public partial class EditCanvasAreaSweepstakes : System.Web.UI.Page
    {
        int tempID;
        int status = 0;
        string sweepstakeHTML;
        string CDID;
        int varCount = 0;
        int errCount = 0;
        int SweepWinners = 0;
        string templateID;
        string maint;
        string Sdate;
        string Edate;
        string Exdate;
        string SdateReplaced;
        string EdateReplaced;
        string ExdateReplaced;
        private const string SWEEPSTAKES = "SWEEPSTAKES";
        private const string TRUE = "Y";
        private const string HASFILE = "has file";
        AppProduct oAppProduct = new AppProduct();
        SweepStakesData sweep = new SweepStakesData();
        EncryptionUtilities decUtil = new EncryptionUtilities();
        CommonUtility commonUtil = new CommonUtility();
        CanvasBizProcess canv = new CanvasBizProcess();
        DataSet dsTemplateData = new DataSet();
        string pathToCreate = string.Empty;
        private const string EMPTYSTRING = "";
        private const string PROMOTIONS = "";
        private const string LIKE_GATEWAY = "LIKE_GATEWAY";
        private const string TAB_LOGO = "TAB_LOGO";
        private const string APP_EXPIRY_IMAGE = "APP_EXPIRY_IMAGE";
        private const string STEP_THREE_COMPLETE = "step_three_complete";
        private const string STEP_TWO_COMPLETE = "step_two_complete";
        private const string STEP_ONE_COMPLETE = "step_one_complete";
        private const string TEMPLATE_PAGE = "EditCanvasAreaSweepstakes.aspx";
        private const int COUPON_HEIGHT = 100;
        private const int COUPON_WIDTH = 500;
        private const int ONE_MB = 1048576;

        string HeaderReplaced;
        string ContentReplaced;
        string FinalHTML;
        string HeaderBannerReplaced;
        string HeaderBannerURLReplaced;

        string DetailsReplaced;
        string DescReplaced;
        string EligibilityReplaced;
        string CodeReplaced;
        string ReedemReplaced;
        string StartDateReplaced;
        string ValidTillDateReplaced;
        string ExpiryDate;
        private string ActiveURL;

        protected void Page_Load(object sender, EventArgs e)
        {
            btnRefresh.Click += new EventHandler(btnRefresh_Click);
            Response.Cache.SetCacheability(HttpCacheability.Private);
            ActiveURL = ConfigurationSettings.AppSettings["ActiveURL"];

            if (Request["CDID"] != null)
            {
                CDID = Request["CDID"].ToString();
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
                if (SessionData.Customer.CustomerID.Equals(string.Empty))
                {
                    Response.Redirect("Home.aspx");
                }
                //Fetch Campaign Info from AppConfiguration and AppProduct
                FacebookBizProcess oFBBiz = new FacebookBizProcess();
                SessionData.Config = oFBBiz.GetAppConfiguration(SessionData.Config.AppName, "");
                SessionData.Product = oFBBiz.GetActiveAppProduct(null, SessionData.Config.DID);
                SweepStakesData oSweepDataRetrieved = new SweepStakesData();
                oSweepDataRetrieved = oFBBiz.GetSweepDataForEditing(SessionData.Config.DID);


                //Now prefill all the values
                txtPrizeDetails.Text = oSweepDataRetrieved.SPRizeDetails;
                txtEligibility.Text = oSweepDataRetrieved.SEligibility;
                txtOffRules.Text = oSweepDataRetrieved.SSweeprules;
                txtPrivacy.Text = oSweepDataRetrieved.SSweepPrivacy;
                txtTandC.Text = oSweepDataRetrieved.SSweepTerms;
                ddlSelectWinner.SelectedValue = Convert.ToString(oSweepDataRetrieved.SSweepWinners);
                txtBannerURL.Text = SessionData.Product.SHeaderBannerURL;
                string stdt = oSweepDataRetrieved.SSweepStartDate;
                string edt = oSweepDataRetrieved.SSweepEndDate;
                string exdt = oSweepDataRetrieved.SSweepExpiryDate;

                if (!string.IsNullOrEmpty(stdt))
                {
                    DateTime sd = DateTime.Parse(stdt);
                    datepickerStart.Value = sd.ToString("dd/M/yyyy");
                }

                if (!string.IsNullOrEmpty(edt))
                {
                    DateTime end = DateTime.Parse(edt);
                    datepickerEnd.Value = end.ToString("dd/M/yyyy");
                }

                if (!string.IsNullOrEmpty(exdt))
                {
                    DateTime et = DateTime.Parse(exdt);
                    datepickerExpiry.Value = et.ToString("dd/M/yyyy");
                }

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


                //Sweepstakes Details tab
                txtHeaderText.Text = SessionData.Product.AppCaption;

            }
            if (hdnTabStatus.Value.Equals(STEP_ONE_COMPLETE))
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

                StringBuilder oSBLastTab = new StringBuilder();
                oSBLastTab.Append(" $(document).ready(function () {");
                oSBLastTab.Append("$(\"#campDetLinker\").trigger('click')");
                oSBLastTab.Append("});");


                Page.ClientScript.RegisterStartupScript(this.GetType(), "myStepOneScript", oSBLastTab.ToString(), true);
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


                Page.ClientScript.RegisterStartupScript(this.GetType(), "myStepTwoDesc", oSBLastTab.ToString(), true);
            }
            else if (hdnTabStatus.Value.Equals(STEP_THREE_COMPLETE))
            {

                //Step two complete, 
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


                Page.ClientScript.RegisterStartupScript(this.GetType(), "myStepTthree", oSBLastTab.ToString(), true);

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

        //private string GetConvertedHTML(string defaultHTML)
        //{
        //    //replace Header banner
        //    string HeaderReplaced = defaultHTML.Replace("<img id=\"imgHeader\" alt=\"\" src=\"\" />", "<img id=\"imgHeader\" src=\"Images/" + SessionData.Product.DID + "/" + "Header" + hdnHeaderBanner.Value + "\"  alt=\"\" />");

        //    //replace Prize Details
        //    string PrizeReplaced = HeaderReplaced.Replace("<span id=\"spanPrice\" style=\"height: 200px; width: 230px;overflow: hidden;\">", "<span id=\"spanPrice\" style=\"height: 200px; width: 230px;overflow: hidden;\">" + txtPrizeDetails.Text.Trim().Replace("'", "''"));

        //    //replace Eligibility details
        //    string EligibilityReplaced = PrizeReplaced.Replace("<span id=\"spanElig\" style=\"height: 200px; width: 230px;overflow: hidden;\">", "<span id=\"spanElig\" style=\"height: 200px; width: 230px;overflow: hidden;\">" + txtEligibility.Text.Trim().Replace("'", "''"));

        //    //format dates
        //    string startedDate = FormatDate(datepickerStart.Value) + " 12:00 AM";
        //    string endDate = FormatDate(datepickerEnd.Value) + " 11:59 PM";

        //    //replace start and End dates
        //    string StartDateReplaced = EligibilityReplaced.Replace("<span id=\"spanStartDate\">", "<span id=\"spanStartDate\">" + startedDate);
        //    string EndDateReplaced = StartDateReplaced.Replace("<span id=\"spanEndDate\">", "<span id=\"spanEndDate\">" + endDate);


        //    return EndDateReplaced;
        //}
        public string FormatDate(string sUnformattedDate)
        {
            string[] dates = sUnformattedDate.Split('/');

            string month = GetMonthString(dates[1]);

            string date = dates[0];
            string year = dates[2].Substring(0, 4);

            return month + " " + date + " ," + year;
        }

        public string GetMonthString(string sMonth)
        {
            switch (sMonth)
            {
                case "1": return "January";

                case "2": return "February";

                case "3": return "March";

                case "4": return "April";

                case "5": return "May";

                case "6": return "June";

                case "7": return "July";

                case "8": return "August";

                case "9": return "September";

                case "10": return "October";

                case "11": return "November";

                case "12": return "December";
                default: return "";
            }
        }

        protected void btnPreview_Click(object sender, EventArgs e)
        {

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

        protected void logout_Click(object sender, EventArgs e)
        {
            Session.Abandon();
            Response.Redirect("~/LandingPage.aspx");
            //tdLogout.Visible = false;
        }

        protected void btnStep1Complete_Click(object sender, EventArgs e)
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

                //Body Image
                if (fileSweepStakeHeader.HasFile)
                {
                    hdnFileContentHasFile.Value = HASFILE;
                    if (fileSweepStakeHeader.PostedFile.ContentType == "image/jpeg" || fileSweepStakeHeader.PostedFile.ContentType == "image/png" || fileSweepStakeHeader.PostedFile.ContentType == "image/jpg" || filePromo2LikeGateWayImage.PostedFile.ContentType == "image/pjpeg")
                    {
                        if (fileSweepStakeHeader.FileBytes.Length < 1048576)
                        {
                            string filenameSweep = Path.GetFileName(fileSweepStakeHeader.FileName);

                            Bitmap sourceImage = new Bitmap(fileSweepStakeHeader.PostedFile.InputStream);
                            SaveImageFile(sourceImage, Server.MapPath(pathToCreate + "/Head" + filenameSweep), COUPON_HEIGHT, COUPON_WIDTH);
                            hdnHeaderBanner.Value = filenameSweep;
                            SessionData.Product.ProductLogo = filenameSweep;
                            //NOW SAVE TO PRODUCT TABLE------> PRODUCTFOOTER
                        }
                    }
                }

                //Caption
                if (!string.IsNullOrEmpty(txtPrizeDetails.Text))
                {
                    SessionData.Product.AppCaption = txtPrizeDetails.Text;
                }
                HtmlGenericControl campEnab = new HtmlGenericControl();
                campEnab = (HtmlGenericControl)MainList.FindControl("CampDetails");
                campEnab.Style.Add("display", "block");
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

                //Logo Image
                if (filePromo2Logo.HasFile)
                {
                    if (filePromo2Logo.PostedFile.ContentType == "image/jpeg" || filePromo2Logo.PostedFile.ContentType == "image/png" || filePromo2Logo.PostedFile.ContentType == "image/jpg" || filePromo2Logo.PostedFile.ContentType == "image/pjpeg")
                    {
                        if (filePromo2Logo.FileBytes.Length < 1048576)
                        {
                            string filenamePromo2Logo = Path.GetFileName(filePromo2Logo.FileName);
                            if (chkSweepImage.Checked)
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
                            span1.InnerHtml = "File size should not be greater than 1 MB";

                        }
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

                            imgBanner.PostedFile.SaveAs(Server.MapPath("~/Images/" + SessionData.Product.DID + "/Banner" + imgBannerPromo2));
                            hdnBanner.Value = imgBannerPromo2;
                            //SessionData.Product.SHeaderBannerImg = imgBannerPromo2;
                        }
                    }

                }

                //Caption
                if (!string.IsNullOrEmpty(txtHeaderText.Text))
                {
                    SessionData.Product.AppCaption = txtHeaderText.Text;
                }

                //Now enable Facebook tab
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
                else
                {
                    //spanErrorCustTabNamePromo2.InnerHtml = "Custom Tab Name is required!";  // Added RequiredfirldValidator to avoid Post **7/4/2012**
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

                //Start Date, Expiry Date                
                if (fbBiz.IsAppCreationAllowed(SessionData.Customer.CustomerID)) //check if user is allowed to create Promos etc under his current plan *****************************************************************
                {


                    //Add Inquiry Data
                    if (!(string.IsNullOrEmpty(txtInquiryEmail.Text.Trim())))
                    {
                        SessionData.Config.SInquiryEmail = txtInquiryEmail.Text.Trim();
                    }



                    //Add TemplatePage Data

                    SessionData.Config.STemplatePage = TEMPLATE_PAGE;
                    string pathToCreate = "~/Images/" + SessionData.Product.DID;

                    //Replace New Header Image and anchor tag
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

                    //Fill up Preview Data
                    if (hdnFileContentHasFile.Value.Equals(HASFILE)) //New image was chosen, then do normal replace, else, bring new image
                    {

                        HeaderReplaced = HeaderBannerReplaced.Replace(SessionData.Product.SProductContentImage, hdnHeaderBanner.Value);

                    }
                    else
                    {
                        HeaderReplaced = HeaderBannerReplaced.Replace("<img id=\"imgHeader\" src=\"Images/" + SessionData.Product.DID + "/" + SessionData.Product.SProductContentImage + "\" alt=\"\" style=\"width: 500px; height: 100px;\" />", "<img id=\"imgHeader\" src=\"Images/" + SessionData.Product.DID + "/" + "Header" + hdnHeader.Value + "\"  alt=\"\" alt=\"\" style=\"width: 500px; height: 100px;\" />");

                        //check if canvas settings have changed, if so, need to resize existing image 
                    }


                    //fetch Sweepstakes data to create html, till now we have only replaced HeaderImage
                    SweepStakesData oOldSweepObj = new SweepStakesData();
                    oOldSweepObj = fbBiz.GetSweepDataForEditing(SessionData.Product.AppConfigDID);

                    if (!oOldSweepObj.SPRizeDetails.Equals(txtPrizeDetails.Text.Trim()))
                    {
                        DetailsReplaced = HeaderReplaced.Replace(oOldSweepObj.SPRizeDetails, txtPrizeDetails.Text.Trim());
                    }
                    else
                    {
                        DetailsReplaced = HeaderReplaced;
                    }



                    if (!oOldSweepObj.SEligibility.Equals(txtEligibility.Text.Trim()))
                    {
                        //replace Eligibility details
                        EligibilityReplaced = DetailsReplaced.Replace(oOldSweepObj.SEligibility, txtEligibility.Text.Trim().Replace("'", "''"));
                    }
                    else
                    {
                        EligibilityReplaced = DetailsReplaced;
                    }



                    ////format dates
                    string startedDate = SQLSafeDates(datepickerStart.Value, true);
                    string endDate = SQLSafeDates(datepickerEnd.Value, true);
                    string validDate = SQLSafeDates(datepickerExpiry.Value, true);

                    if (!string.IsNullOrEmpty(startedDate))
                    {
                        DateTime sd = DateTime.Parse(startedDate);
                        SdateReplaced = sd.ToString("d/M/yyyy");
                    }
                    if (!string.IsNullOrEmpty(endDate))
                    {
                        DateTime sd = DateTime.Parse(endDate);
                        EdateReplaced = sd.ToString("d/M/yyyy");
                    }
                    if (!string.IsNullOrEmpty(validDate))
                    {
                        DateTime sd = DateTime.Parse(validDate);
                        ExdateReplaced = sd.ToString("d/M/yyyy");
                    }
                    //replace start and End dates
                    //    string StartDateReplaced = EligibilityReplaced.Replace("<span id=\"spanStartDate\">", "<span id=\"spanStartDate\">" + startedDate);
                    //    string EndDateReplaced = StartDateReplaced.Replace("<span id=\"spanEndDate\">", "<span id=\"spanEndDate\">" + endDate);
                    string startdt = oOldSweepObj.SSweepStartDate;
                    string endt = oOldSweepObj.SSweepEndDate;
                    string expirydt = oOldSweepObj.SSweepExpiryDate;

                    if (!string.IsNullOrEmpty(startdt))
                    {
                        DateTime sd = DateTime.Parse(startdt);
                        Sdate = sd.ToString("d/M/yyyy");
                    }

                    if (!string.IsNullOrEmpty(endt))
                    {
                        DateTime sd = DateTime.Parse(endt);
                        Edate = sd.ToString("d/M/yyyy");
                    }
                    if (!string.IsNullOrEmpty(expirydt))
                    {
                        DateTime sd = DateTime.Parse(expirydt);
                        Exdate = sd.ToString("d/M/yyyy");
                    }

                    //replace Start date
                    if (!Sdate.Equals(datepickerStart.Value))
                    {
                        StartDateReplaced = EligibilityReplaced.Replace(Sdate, SdateReplaced);

                    }
                    else
                    {
                        StartDateReplaced = EligibilityReplaced;
                    }

                    //replace End date
                    if (!Edate.Equals(HiddenField1.Value))
                    {
                        ValidTillDateReplaced = StartDateReplaced.Replace(Edate, EdateReplaced);

                    }
                    else
                    {
                        ValidTillDateReplaced = StartDateReplaced;
                    }

                    //replace Winner date
                    if (!Exdate.Equals(datepickerExpiry.Value))
                    {
                        ExpiryDate = ValidTillDateReplaced.Replace(Exdate, ExdateReplaced);

                    }
                    else
                    {
                        ExpiryDate = ValidTillDateReplaced;
                    }


                    if (!oOldSweepObj.SSweepWinners.Equals(ddlSelectWinner.SelectedItem.Value))
                    {
                        if (ddlSelectWinner.SelectedItem.Value.Equals("1"))
                        {
                            SweepWinners = 1;
                        }
                        else if (ddlSelectWinner.SelectedItem.Value.Equals("2"))
                        {
                            SweepWinners = 2;
                        }
                    }



                    SessionData.Product.ProductLogo = "https://www.sonetreach.com/Images/" + SessionData.Product.DID + "/Logo" + SessionData.Product.ProductLogo;
                    if (hdnFileContentHasFile.Value.Equals(HASFILE))
                    {
                        SessionData.Product.SProductContentImage = "Content" + hdnContent.Value;
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

                    using (CanvasBizProcess canvasBiz = new CanvasBizProcess())
                    {

                        canvasBiz.UpdatePreviewHTML(ExpiryDate, SessionData.Customer.CustomerID, SessionData.Product.DID);
                    }
                    varCount++;

                    //CanvasBizProcess cbiz = new CanvasBizProcess();
                    //string Id = cbiz.GetCustId(Request["CustomerName"]);
                    //string Cdid = cbiz.GetAppConfigDid(Id);
                    //SessionData.Config.DID = Cdid;
                    CDID = SessionData.Customer.CustomerID;
                    //Save the sweepstakes data
                    sweep.SSweepAboutUs = null;
                    sweep.SSweepConfigDID = SessionData.Config.DID;
                    sweep.SSweepStartDate = SQLSafeDates(datepickerStart.Value, true);
                    sweep.SSweepEndDate = SQLSafeDates(datepickerEnd.Value, true);
                    sweep.SSweepTerms = txtTandC.Text.Trim().Replace("'", "''");
                    sweep.SSweepPrivacy = txtPrivacy.Text.Trim().Replace("'", "''");
                    sweep.SSweeprules = txtOffRules.Text.Trim().Replace("'", "''");
                    sweep.SPRizeDetails = txtPrizeDetails.Text.Trim().Replace("'", "''");
                    sweep.SCouponReedem = null;
                    sweep.SCouponCode = null;
                    sweep.SCouponDesc = null;
                    sweep.SSweepExpiryDate = SQLSafeDates(datepickerExpiry.Value, true);
                    sweep.SEligibility = txtEligibility.Text.Trim().Replace("'", "''");
                    sweep.SSweepWinners = SweepWinners;



                    //Save this Data
                    if (sweep.SSweepTerms.Length < 7999 && sweep.SSweepPrivacy.Length < 7999 && sweep.SSweeprules.Length < 7999)
                    {
                        using (CanvasBizProcess canvasBiz = new CanvasBizProcess())
                        {
                            canvasBiz.UpdateSweepStakesData(sweep);
                        }
                    }

                    if (!(SessionData.Config == null))
                    {

                        //Apply Campaign Dates to Config
                        if (datepickerStart.Value != "")
                        {
                            SessionData.Config.SAppStartDT = SQLSafeDates(datepickerStart.Value, true);
                            SessionData.Config.AppExpiryDT = SQLSafeDates(datepickerExpiry.Value, true);
                        }
                        //Now fill up the Config and get Product data.
                        if (fbBiz.UpdateConfigDetails(SessionData.Config, SWEEPSTAKES, SessionData.Config.SCustomtTabName))
                        {
                            ////********If user comes here we know we should set up a Product Info, So, create a row in AppProduct and assign these values to SessionData********
                            CanvasBizProcess cbiz = new CanvasBizProcess();
                            //string Id = cbiz.GetCustId(Request["CustomerName"]);
                            //string Cdid = cbiz.GetAppConfigDid(Id);
                            //SessionData.Config.DID = Cdid;
                            CDID = SessionData.Customer.CustomerID;
                            SessionData.Product.AppConfigDID = SessionData.Config.DID;
                            SessionData.Product.ProductName = SessionData.Config.AppName;
                            SessionData.Product.ProductHTML = canv.FetchFinalHTML(SessionData.Product.DID, CDID);
                            SessionData.Product.SCouponImgPath = "<img id=\"imgHeader\" src=\"Images/" + SessionData.Product.DID + "/" + "Head" + hdnHeaderBanner.Value + "\"  alt=\"\" style=\"width: 250px; height: 250px;\" />";
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


    }
}