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
    public partial class CanvasAreaSweepstakes : System.Web.UI.Page
    {
        int tempID;
        int status = 0;
        int SweepWinners = 0;
        string sweepstakeHTML;
        string CDID;
        int varCount = 0;
        string templateID;
        string maint;
        int errCount = 0;
        string couponHTML;
        private const string SWEEPSTAKES = "SWEEPSTAKES";
        AppProduct oAppProduct = new AppProduct();
        SweepStakesData sweep = new SweepStakesData();
        EncryptionUtilities decUtil = new EncryptionUtilities();
        CommonUtility commonUtil = new CommonUtility();
        CanvasBizProcess canv = new CanvasBizProcess();
        DataSet dsTemplateData = new DataSet();
        string pathToCreate = string.Empty;
        private const string EMPTYSTRING = "";

        private const string LIKE_GATEWAY = "LIKE_GATEWAY";
        private const string TAB_LOGO = "TAB_LOGO";
        private const string APP_EXPIRY_IMAGE = "APP_EXPIRY_IMAGE";
        private const string STEP_THREE_COMPLETE = "step_three_complete";
        private const string STEP_TWO_COMPLETE = "step_two_complete";
        private const string STEP_ONE_COMPLETE = "step_one_complete";
        private const string TEMPLATE_PAGE = "EditCanvasAreaSweepstakes.aspx";
        private const int COUPON_HEIGHT = 100;
        private const int COUPON_WIDTH = 500;
        private string ActiveURL;
        private const int ONE_MB = 1048576;
        private const int MAX_DB_LEN = 7999;

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


                //Fetch Campaign Info from AppConfiguration and AppProduct
                //FacebookBizProcess oFBBiz = new FacebookBizProcess();
                //SessionData.Config = oFBBiz.GetAppConfiguration(SessionData.Config.AppName, "");
                //SessionData.Product = oFBBiz.GetActiveAppProduct(null, SessionData.Config.DID);
                //SweepStakesData oSweepDataRetrieved = new SweepStakesData();
                //oSweepDataRetrieved = oFBBiz.GetSweepDataForEditing(SessionData.Config.DID);

                //Now prefill all the values

                //Canvas Settings Tab
                //txtCanvasHeight.Text = SessionData.Product.CanvasHeight;
                //txtCanvasWidth.Text = SessionData.Product.CanvasWidth;

                //Sweepstakes Details tab
                //txtHeaderText.Text = SessionData.Product.AppCaption;

            }

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
                SessionData.Config.AppName = Convert.ToString(Request["Appname"]);
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

        private string GetConvertedHTML(string defaultHTML)
        {

            //replace Coupon Details
            //string HeaderReplaced = defaultHTML.Replace("spanHeader", txtPrizeDetails.Text.Trim().Replace("'", "''"));

            // Replace Banner URL
            string HeaderBannerURLReplaced = defaultHTML.Replace(" <a id=\"aHeadBanner\" href=\"\" target=\"_blank\">", "<a id=\"aHeadBanner\" href=" + txtBannerURL.Text + " target=\"_blank\" >");

            // Replace Banner Image
            string HeaderBannerReplaced = HeaderBannerURLReplaced.Replace("<img id=\"imgBanner\" alt=\"\" src=\"\" style=\"width: 500px; height: 100px;\" />", "<img id=\"imgBanner\" alt=\"\" src=\"Images/" + SessionData.Product.DID + "/" + "Banner" + hdnBanner.Value + "\" style=\"width: 500px; height: 100px;\"/>");


            //replace Header banner
            string HeaderIamgeReplaced = HeaderBannerReplaced.Replace("<img id=\"imgHeader\" alt=\"\" src=\"\" style=\"width: 500px; height: 100px;\" />", "<img id=\"imgHeader\" src=\"Images/" + SessionData.Product.DID + "/" + "Head" + hdnHeaderBanner.Value + "\"  alt=\"\" style=\"width: 500px; height: 100px;\" />");

            string PrizeReplaced = HeaderIamgeReplaced.Replace("<span id=\"spanPrice\" style=\"height: 200px; width: 230px; overflow: hidden;\">", txtPrizeDetails.Text.Trim().Replace("'", "''"));


            //replace Eligibility details
            string EligibilityReplaced = PrizeReplaced.Replace("<span id=\"spanElig\" style=\"height: 200px; width: 230px; overflow: hidden;\">", txtEligibility.Text.Trim().Replace("'", "''"));

            string startdate = datepickerStart.Value;

            string StartDate = EligibilityReplaced.Replace("spanStartDate", startdate);

            string enddate = HiddenField1.Value;
            string winnerdate = datepickerExpiry.Value;

            //replace start and End dates

            string EndDate = StartDate.Replace("spanEndDate", enddate);

            string WinnerDate = EndDate.Replace("WinnerDate", winnerdate);

            return WinnerDate;
        }
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
                if (string.IsNullOrEmpty(maint)) //Normal Flow
                {
                    SessionData.Product = new AppProduct();
                    SessionData.Product.DID = GetNewDIDWithPrefix();


                    //Prepare file system directory to store Images
                    string pathToCreate = "~/Images/" + SessionData.Product.DID;

                    hdnPDID.Value = SessionData.Product.DID;
                    hdnfield.Value = CDID;
                    if (!Directory.Exists(Server.MapPath(pathToCreate)))
                    {
                        Directory.CreateDirectory(Server.MapPath(pathToCreate));
                    }


                    //Header Image
                    if (fileSweepStakeHeader.PostedFile.ContentType == "image/jpeg" || fileSweepStakeHeader.PostedFile.ContentType == "image/png" || fileSweepStakeHeader.PostedFile.ContentType == "image/jpg" || filePromo2LikeGateWayImage.PostedFile.ContentType == "image/pjpeg")
                    {
                        if (fileSweepStakeHeader.FileBytes.Length < ONE_MB)
                        {
                            string filenameSweep = Path.GetFileName(fileSweepStakeHeader.FileName);

                            Bitmap sourceImage = new Bitmap(fileSweepStakeHeader.PostedFile.InputStream);
                            SaveImageFile(sourceImage, Server.MapPath(pathToCreate + "/Head" + filenameSweep), COUPON_HEIGHT, COUPON_WIDTH);
                            hdnHeaderBanner.Value = filenameSweep;
                            SessionData.Product.ProductLogo = filenameSweep;

                            //NOW SAVE TO PRODUCT TABLE------> PRODUCTFOOTER
                        }

                    }

                    //Caption
                    if (!string.IsNullOrEmpty(txtPrizeDetails.Text))
                    {
                        SessionData.Product.AppCaption = txtPrizeDetails.Text;
                    }

                    //Enable other tabs

                    HtmlGenericControl campEnab = new HtmlGenericControl();
                    campEnab = (HtmlGenericControl)MainList.FindControl("CampDetails");
                    campEnab.Style.Add("display", "block");
                    hdnTabStatus.Value = STEP_ONE_COMPLETE;
                }

            }
            catch (Exception ex)
            {
                commonUtil.SendErrorMail(ex.Message, ex.StackTrace, System.Reflection.MethodBase.GetCurrentMethod().Name.ToString(), System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.ToString(), SessionData.Customer.CustomerID);
            }
        }

        protected void btnStep2Complete_Click(object sender, EventArgs e)
        {

            //Prepare file system directory to store Images
            string pathToCreate = "~/Images/" + SessionData.Product.DID;

            hdnPDID.Value = SessionData.Product.DID;
            hdnfield.Value = CDID;
            if (!Directory.Exists(Server.MapPath(pathToCreate)))
            {
                Directory.CreateDirectory(Server.MapPath(pathToCreate));
            }

            //Logo Image
            if (filePromo2Logo.HasFile)
            {
                if (filePromo2Logo.PostedFile.ContentType == "image/jpeg" || filePromo2Logo.PostedFile.ContentType == "image/png" || filePromo2Logo.PostedFile.ContentType == "image/jpg" || filePromo2Logo.PostedFile.ContentType == "image/pjpeg")
                {
                    if (filePromo2Logo.FileBytes.Length < ONE_MB)
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

            //Check How many winners are seletced

            if (ddlSelectWinner.SelectedItem.Value.Equals("1"))
            {
                SweepWinners = 1;
            }
            else if (ddlSelectWinner.SelectedItem.Value.Equals("2"))
            {
                SweepWinners = 2;
            }



            FacebookBizProcess fbBiz = new FacebookBizProcess();
            SessionData.Config = fbBiz.GetAvailableConfig(CDID);
            //Save the sweepstakes data
            sweep.SSweepAboutUs = null;
            sweep.SSweepConfigDID = SessionData.Config.DID;
            sweep.SSweepStartDate = SQLSafeDates(datepickerStart.Value, true);
            sweep.SSweepEndDate = SQLSafeDates(HiddenField1.Value, false);
            sweep.SSweepTerms = txtTandC.Text.Trim().Replace("'", "''");
            sweep.SSweepPrivacy = txtPrivacy.Text.Trim().Replace("'", "''");
            sweep.SSweeprules = txtOffRules.Text.Trim().Replace("'", "''");
            sweep.SPRizeDetails = txtPrizeDetails.Text.Trim().Replace("'", "''");
            sweep.SCouponReedem = null;
            sweep.SCouponCode = null;
            sweep.SCouponDesc = null;
            sweep.SSweepExpiryDate = SQLSafeDates(datepickerExpiry.Value, false);
            sweep.SEligibility = txtEligibility.Text.Trim().Replace("'", "''");
            sweep.SSweepWinners = SweepWinners;



            //Save this Data
            if (sweep.SSweepTerms.Length < MAX_DB_LEN && sweep.SSweepPrivacy.Length < MAX_DB_LEN && sweep.SSweeprules.Length < MAX_DB_LEN)
            {
                using (CanvasBizProcess canvasBiz = new CanvasBizProcess())
                {
                    canvasBiz.SaveCouponData(sweep);
                }
            }

            //Now enable Facebook tab
            HtmlGenericControl fbookShow = new HtmlGenericControl();
            fbookShow = (HtmlGenericControl)MainList.FindControl("Widgets");
            fbookShow.Style.Add("display", "block");
            hdnTabStatus.Value = STEP_TWO_COMPLETE;

        }

        protected void btnPublish_Click(object sender, EventArgs e)
        {
            try
            {
                if (SessionData.Config.SAppPageTabSelected == null)
                {
                    StringBuilder oSBPageSElector = new StringBuilder();
                    oSBPageSElector.Append("window.open('http://www.facebook.com/dialog/permissions.request?app_id=");
                    oSBPageSElector.Append(SessionData.Config.AppID + "&redirect_uri=" + ActiveURL + SessionData.Config.AppID + "&response_type=code&perms=user_birthday,user_location,email,manage_pages\','name','height=570,width=960,menubar=0,toolbar=0,statusbar=0,scrollbars=0,resizable=0');");
                    litLogin.Text = oSBPageSElector.ToString();
                }
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
                if (!txtCustomTabNamePromo2.Text.Trim().Equals(string.Empty))
                {
                    SessionData.Config.SCustomtTabName = txtCustomTabNamePromo2.Text.Trim();
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

                //Start Date, Expiry Date
                FacebookBizProcess fbBiz = new FacebookBizProcess();
                if (fbBiz.IsAppCreationAllowed(SessionData.Customer.CustomerID)) //check if user is allowed to create Promos etc under his current plan *****************************************************************
                {


                    //Add Inquiry Data
                    if (!(string.IsNullOrEmpty(txtInquiryEmail.Text.Trim())))
                    {
                        SessionData.Config.SInquiryEmail = txtInquiryEmail.Text.Trim();
                    }
                    //Apply Campaign Dates to Config

                    if (datepickerStart.Value != "")
                    {
                        SessionData.Config.SAppStartDT = SQLSafeDates(datepickerStart.Value, true);
                        SessionData.Config.AppExpiryDT = SQLSafeDates(datepickerEnd.Value, true);
                    }
                    //Add TemplatePage Data

                    SessionData.Config.STemplatePage = TEMPLATE_PAGE;



                    using (CanvasBizProcess canvBiz = new CanvasBizProcess())
                    {
                        couponHTML = canvBiz.GetTempData(Convert.ToInt32(templateID)).Tables[0].Rows[0]["thtml"].ToString();
                    }

                    //Fill up Preview Data
                    string FinalHTML = GetConvertedHTML(couponHTML);
                    SessionData.Product.ProductLogo = "https://www.sonetreach.com/Images/" + SessionData.Product.DID + "/Logo" + SessionData.Product.ProductLogo;
                    using (CanvasBizProcess canvasBiz = new CanvasBizProcess())
                    {
                        canvasBiz.InsertPreviewHTML(FinalHTML, SessionData.Customer.CustomerID, SessionData.Product.DID);
                    }
                    varCount++;

                    if (!(SessionData.Config == null))
                    {
                        SessionData.Config.SCampaignType = SWEEPSTAKES;
                        //Now fill up the Config and get Product data.
                        if (fbBiz.SetNewConfigDetails(SessionData.Config, SessionData.Config.SCustomtTabName,SWEEPSTAKES))
                        {
                            ////********If user comes here we know we should set up a Product Info, So, create a row in AppProduct and assign these values to SessionData********
                            SessionData.Product.AppConfigDID = SessionData.Config.DID;
                            SessionData.Product.ProductName = SessionData.Config.AppName;
                            SessionData.Product.ProductHTML = canv.FetchFinalHTML(SessionData.Product.DID, CDID);
                            SessionData.Product.SProductContentImage = hdnHeaderBanner.Value;
                            SessionData.Product.SHeaderBannerURL = txtBannerURL.Text;
                            SessionData.Product.SHeaderBannerImg = hdnBanner.Value;
                            fbBiz.SetNewProductDetails(SessionData.Product);

                            SessionData.Product = fbBiz.GetAppProductDetails();
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