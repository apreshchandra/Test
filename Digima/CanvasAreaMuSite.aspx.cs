using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
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
using Google.GData.Client;
using Google.GData.YouTube;
using Google.GData.Extensions;
using Google.GData.Extensions.MediaRss;
using Google.YouTube;
using Newtonsoft.Json.Linq;
using System.Drawing.Imaging;
using System.Text.RegularExpressions;
using HtmlAgilityPack;
using System.DirectoryServices;
using Microsoft.Web.Administration;


namespace DigiMa
{
    public partial class CanvasAreaMuSite : System.Web.UI.Page
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
        private const string WH_CREATED = "WebHutColl.";
        private const string YOUTUBE = "Y";
        private const string MICROSITE = "M";
        private string CDID = string.Empty;
        string SiteID;
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
        private const string Promo = "PROMO-WH";
        private const string Video = "VIDEO-WH";
        private const string Coupon = "COUPON-WH";
        private const string Sweepstakes = "SWEEPSTAKES-WH";
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

                if (SessionData.PrefData.TaskTwo1.Equals(MICROSITE))
                {
                    trMicrosite.Visible = true;
                }

                if (SessionData.PrefData.TaskTwo1.Equals(YOUTUBE))
                {
                    trYoutube.Visible = true;
                }

            }
            if (!string.IsNullOrEmpty(Request["CDID"].ToString()))
            {
                CDID = Request["CDID"].ToString();

                ////create session based on CDID
                //if (SessionData.Customer.CustomerID == null || SessionData.Customer.CustomerID == "")
                //{
                //    SessionData.Customer = new AppCustomer();
                //    SessionData.Customer = canv.GetCustomerInfo(null, CDID, false);
                //}
            }


            if (!string.IsNullOrEmpty(Request["SiteID"].ToString()))
            {
                SiteID = Request["SiteID"].ToString();
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

        private void CopyToMicrosites(string SiteId, string microSiteName)
        {
            try
            {
                string strTemplateFolderName = "";
                ////string strFolder = Server.MapPath("./SiteImages/" + SiteId);

                string strSiteFolderMS = Server.MapPath("./MicroSites/" + microSiteName);
                string strSiteFolderReal = Server.MapPath("./Sites/Tool/" + SiteId);

                ////if (!Directory.Exists(strFolder))
                if (!Directory.Exists(strSiteFolderMS))
                {

                    string sfolderPath = strSiteFolderReal;

                    //string[] strTemplate = (hdnSelectedTemplate.Value).Split('.');

                    strTemplateFolderName = Server.MapPath("Sites/Final/" + SiteId);
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
                        }

                    }
                }
                //Send Email to user with path
                string path = "https://www.sonetreach.com/Microsites/";
                StringBuilder oInfoEmailSB = new StringBuilder();
                oInfoEmailSB.Append("Hello ! We have processed your MicroSite. Please follow the following link: " + path + microSiteName + "/index.html");

                String style;
                //clean up Microsite pages
                if (SessionData.PrefData.TemplateID1 == 12)
                {
                    style = "/CSS/RStore_style.css";
                }
                else if (SessionData.PrefData.TemplateID1 == 13)
                {
                    style = "/CSS/FabrikStyle.css";
                }
                else if (SessionData.PrefData.TemplateID1 == 11)
                {
                    style = "/CSS/CouponsStyle.css";
                }
                else if (SessionData.PrefData.TemplateID1 == 14)
                {
                    style = "/CSS/realestate_styles.css";
                }
                else if (SessionData.PrefData.TemplateID1 == 16)
                {
                    style = "/CSS/Restaurantstyle.css";
                }
                else if (SessionData.PrefData.TemplateID1 == 17)
                {
                    style = "/CSS/Educationalstyle.css";
                }
                else
                {
                    style = "/CSS/PFstyle.css";
                }


                System.IO.StreamReader StreamReader1 =
new System.IO.StreamReader(Server.MapPath("./Microsites/" + microSiteName + style));
                string ReadStyle = StreamReader1.ReadToEnd();
                StreamReader1.Close();

                string CleanedUpCSS = ReadStyle.Replace(".dynamic{}", ".dynamic{display:none}");


                System.IO.StreamWriter StreamWriter1 =
new System.IO.StreamWriter(Server.MapPath("./Microsites/" + microSiteName + style));
                StreamWriter1.WriteLine(CleanedUpCSS);
                StreamWriter1.Close();
                commonUtil.SendInfoMail(oInfoEmailSB.ToString(), "Your new Microsite", "", SessionData.Customer.SCustomerEmail);

                SessionData.UserAction.TaskComplete = MICROSITE;

                //now save this data to DB
                fbBiz.InsertMicrositesData(SessionData.Customer.CustomerID, microSiteName);


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

            }
        }


        protected void btnPublish_Click(object sender, EventArgs e)
        {
            try
            {
                //SessionData.Config = new AppConfiguration();
                if (SessionData.PrefData.TaskTwo1.Equals(MICROSITE))
                {
                    CopyToMicrosites(SessionData.UserAction.SiteID1, txtSubDomainName.Text.Trim());
                }

                if (SessionData.PrefData.TaskTwo1.Equals(YOUTUBE))
                {
                    //ask for uploading video and save in Userfiles
                    if (fileYoutubeVideo.HasFile)
                    {
                        string filename = fileYoutubeVideo.FileName;
                        string path = Server.MapPath("./Youtube/" + SessionData.UserAction.SiteID1);

                        if (!Directory.Exists(path))
                        {
                            Directory.CreateDirectory(path);
                        }
                        string strFinalFileName = Path.GetFileName(fileYoutubeVideo.FileName);
                        long FileLength = fileYoutubeVideo.PostedFile.ContentLength;

                        fileYoutubeVideo.PostedFile.SaveAs(path + "/" + filename);

                        if (UploadToYoutube(filename))
                        {
                            //Page.ClientScript.RegisterStartupScript(this.GetType(), "myCloseScript", "alert(\"Youtube video uploaded !\")", true);
                            SessionData.UserAction.TaskComplete = YOUTUBE;
                        }
                    }
                }

                SessionData.Product = new AppProduct();
                SessionData.Product.DID = GetNewDIDWithPrefix();

                //Prepare file system directory to store Images
                string pathToCreate = "~/Images/" + SessionData.Product.DID;
                if (!Directory.Exists(Server.MapPath(pathToCreate)))
                {
                    Directory.CreateDirectory(Server.MapPath(pathToCreate));
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


                //Caption
                //if (!string.IsNullOrEmpty(txtHeaderText.Text))
                //{
                //    SessionData.Product.AppCaption = txtHeaderText.Text;
                //}

                SessionData.Product.ProductCategory = WH_CREATED;
                //Start Date, Expiry Date
                FacebookBizProcess fbBiz = new FacebookBizProcess();
                if (fbBiz.IsAppCreationAllowed(SessionData.Customer.CustomerID)) //check if user is allowed to create Promos etc under his current plan *****************************************************************
                {
                    SessionData.Config = new AppConfiguration();
                    AppConfiguration oAppAvaila = new AppConfiguration();
                    oAppAvaila = fbBiz.GetAvailableConfig(CDID);
                    SessionData.Config = oAppAvaila;
                    SessionData.Config.DID = GetNewDID("AN");

                    //Custom Tab Name
                    if (!txtCustomTabNamePromoVid.Text.Trim().Equals(string.Empty))
                    {
                        SessionData.Config.SCustomtTabName = txtCustomTabNamePromoVid.Text.Trim();
                        SessionData.UserAction.CustomTabName1 = txtCustomTabNamePromoVid.Text.Trim();
                    }
                    SessionData.Config.STemplatePage = TEMPLATE_PAGE;
                }
                else
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "myCloseScript", "alert(\"You can only create 3 Campaigns with a TRIAL account !\")", true);
                }

                FaceBook ofacebook = new FaceBook();
                AppUser oAppUser = new AppUser();

                SessionData.Config.SSiteID = SiteID;
                SessionData.Config.STemplateID = SessionData.PrefData.TemplateID1;

                SessionData.Product.ProductLogo = "https://www.sonetreach.com/Images/" + SessionData.Product.DID + "/Logo" + SessionData.Product.ProductLogo;
                SessionData.Product.SProductContentImage = "Body" + hdnContent.Value;


                if (!(SessionData.Config == null))
                {

                    //Now fill up the Config and get Product data.
                    SessionData.Config.SCampaignType = Video;
                    if (fbBiz.SetNewConfigDetails(SessionData.Config, SessionData.Config.SCustomtTabName, Video))
                    {
                        //Update expiry date
                        fbBiz.UpdateConfigExpiryForWH(SessionData.Config.DID);

                        ////********If user comes here we know we should set up a Product Info, So, create a row in AppProduct and assign these values to SessionData********

                        SessionData.Product.AppConfigDID = SessionData.Config.DID;
                        SessionData.Product.ProductName = SessionData.Config.AppName;
                        SessionData.Product.ProductHTML = "";


                        fbBiz.SetNewProductDetails(SessionData.Product);

                        SessionData.Product = fbBiz.GetAppProductDetails();
                    }
                }
                else
                {
                    //No configs allowed
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "myCloseScript", "alert(\"Config Not Available. Please Contact HELPDESK.\");", true);
                }


                if (SessionData.Config.SAppPageTabSelected == null)
                {

                    StringBuilder oSBPageSElector = new StringBuilder();
                    oSBPageSElector.Append("window.open('http://www.facebook.com/dialog/permissions.request?app_id=");
                    oSBPageSElector.Append(SessionData.Config.AppID + "&redirect_uri=" + ActiveURL + SessionData.Config.AppID + "&response_type=code&perms=user_birthday,user_location,email,manage_pages\','name','height=140,width=790,menubar=0,toolbar=0,statusbar=0,scrollbars=0,resizable=0');");
                    litLogin.Text = oSBPageSElector.ToString();
                }
            }
            catch (Exception ex)
            {
                //commonUtil.SendErrorMail(ex.Message, ex.StackTrace, System.Reflection.MethodBase.GetCurrentMethod().Name.ToString(), System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.ToString(), SessionData.Customer.CustomerID);
                throw ex;
            }
        }


        private bool UploadToYoutube(string filename)
        {
            try
            {
                YouTubeRequestSettings ytsettings = new YouTubeRequestSettings("SonetReach", "AI39si4bVFP9AaDQuM12V5xTGF-pj87bxWApjm3KReLJFl67kkFfq3Jn32DikSJzRrqGo8mYY7Ww7XXD9JZDCezjMd9jUMtFCA", "sonetreach123@gmail.com", "sonetreach123");
                ytsettings.Timeout = -1;
                YouTubeRequest ytReq = new YouTubeRequest(ytsettings);
                ((GDataRequestFactory)ytReq.Service.RequestFactory).Timeout = 60 * 60 * 1000;
                Video video = new Video();
                video.Title = "SonetReach";
                video.Description = "Uploaded by SonetReach";
                video.Tags.Add(new MediaCategory("Sports", YouTubeNameTable.CategorySchema));
                video.YouTubeEntry.Private = false;
                video.YouTubeEntry.MediaSource = new MediaFileSource(Server.MapPath("./Youtube/" + SessionData.UserAction.SiteID1 + "/" + filename), "video/mp4");
                Video createdVideo = ytReq.Upload(video);
                string videoID = createdVideo.VideoId;
                string youtubelink = "http://www.youtube.com/watch?v=" + videoID;
                commonUtil.SendInfoMail("Your Youtube video is uploaded at :" + youtubelink, "Your Youtube Video", "", SessionData.Customer.SCustomerEmail);

                return true;
            }
            catch (Exception ex)
            {
                commonUtil.SendErrorMail(ex.Message, ex.StackTrace, System.Reflection.MethodBase.GetCurrentMethod().Name.ToString(), System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.ToString(), SessionData.Customer.CustomerID);
            }
            return true;
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

            }
            catch (Exception ex)
            {
                commonUtil.SendErrorMail(ex.Message, ex.StackTrace, System.Reflection.MethodBase.GetCurrentMethod().Name.ToString(), System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.ToString(), SessionData.Customer.CustomerID);
            }
        }

        protected void btnStartAgain_Click(object sender, EventArgs e)
        {
            Response.Redirect("LandingPage.aspx?CDID=" + SessionData.Customer.CustomerID);
        }

        protected void txtSubDomainName_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(txtSubDomainName.Text.ToString()))
                {
                    FacebookBizProcess oFBiz = new FacebookBizProcess();
                    if (txtSubDomainName.Text.Contains(">") || txtSubDomainName.Text.Contains("<") || txtSubDomainName.Text.Contains("'") || txtSubDomainName.Text.Contains("--") || txtSubDomainName.Text.Contains("%"))
                    {
                        txtSubDomainName.Text = "";
                    }
                    else
                    {
                        int result = fbBiz.CheckMicroSiteName(txtSubDomainName.Text.TrimStart(' ').TrimEnd(' '));
                        if (result != 0)
                        {
                            string alertScript = "alert('This MicroSite name already exists! Please choose another.');";
                            ScriptManager.RegisterStartupScript(this, GetType(), "Key", alertScript, true);
                            txtSubDomainName.Focus();
                            txtSubDomainName.Text = "";

                        }
                    }
                }
            }
            catch (Exception ex)
            {
                commonUtil.SendErrorMail(ex.Message, ex.StackTrace, System.Reflection.MethodBase.GetCurrentMethod().Name.ToString(), System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.ToString(), SessionData.Customer.CustomerID);
            }
        }
    }
}