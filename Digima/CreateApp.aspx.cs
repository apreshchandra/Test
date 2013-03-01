using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DigiMa.Data;
using DigiMa.BizProcess;
using System.Text;
using System.Web.UI;
using System.Net;
using System.Data;
using System.Web.UI.HtmlControls;
using System.IO;
using Newtonsoft;
using System.DirectoryServices;
using Newtonsoft.Json.Linq;
using DigiMa.Common;
using System.Configuration;
using HtmlAgilityPack;
using System.Web.UI.WebControls;

namespace DigiMa
{
    public partial class CreateApp : DigiMa.sNBBPage
    {
        Dictionary<string, string> tokenRecvd = new Dictionary<string, string>();
        FacebookBizProcess ofbBiz = new FacebookBizProcess();

        string PageNAme = "";
        string addCOMMENT = string.Empty;
        string addSHARE = string.Empty;
        string addPOST = string.Empty;
        string addEntry = string.Empty;
        string addLIKE = string.Empty;
        string addLead = string.Empty;
        string addCaption = string.Empty;
        string addTwitter = string.Empty;
        private string NotifyURL;
        private const string TRUE = "Y";
        string ActiveURL;
        private static bool isLoaded = false;
        string _sNotifierDID = string.Empty;
        static string pageToLoad;
        static bool LoadComplete = false;
        private string SiteID;
        private int TemplateID;

        protected void Page_Load(object sender, EventArgs e)
        {
            btnNavigate.Click += new EventHandler(btnNavigate_Click);
            litOGTags.Text = GetOGMetaTags();
            litNotifyLIKE.Text = GetNotifyLIKE(SessionData.Product.DID);
            litEnableFBJS.Text = GetInitializedJS();


        }
        protected override void OnInit(EventArgs e)
        {
            try
            {
                base.OnInit(e);
                HideBranding = false;
                EnableAppUser = true;
                NotifyURL = ConfigurationManager.AppSettings["NotifyURL"];
                ActiveURL = ConfigurationSettings.AppSettings["ActiveURL"];

                HttpCookie exampleCookie = Request.Cookies["ExampleCookie"];
                if (exampleCookie != null)
                {
                    pageToLoad = exampleCookie["pagetoload"];
                }
            }
            catch (Exception ex)
            {
                CommonUtility commUtil = new CommonUtility();
                commUtil.SendErrorMail(ex.Message, ex.StackTrace, System.Reflection.MethodBase.GetCurrentMethod().Name.ToString(), System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.ToString(), SessionData.Customer.CustomerID);
            }
        }

        void btnNavigate_Click(object sender, EventArgs e)
        {

        }

        private string GetOGMetaTags()
        {
            FacebookBizProcess fbBizProc = new FacebookBizProcess();
            StringBuilder sbOGTags = new StringBuilder();
            sbOGTags.Append("<meta property=\"fb:app_id\" content=\"" + QSVars["app_id"].ToString() + "\" />" + Environment.NewLine);
            sbOGTags.Append("<meta property=\"og:type\" content=\"website\" />" + Environment.NewLine);
            sbOGTags.Append("<meta property=\"og:title\" content=\"Welocme to Sonetreach\" />" + Environment.NewLine);
            sbOGTags.Append("<meta property=\"og:image\" content=\"https://www.testsonetreach.com/images/sonet_watermark.png\" />" + Environment.NewLine);
            sbOGTags.Append("<meta property=\"og:description\" content=\"Social Media Marketing Software\" />" + Environment.NewLine);
            sbOGTags.Append("<meta property=\"og:url\" content=\"" + fbBizProc.GetAppPagePath(Convert.ToString(QSVars["app_id"])) + "\">" + Environment.NewLine);
            sbOGTags.Append("<meta property=\"fb:admins\" content=\"\" />" + Environment.NewLine);
            sbOGTags.Append(" <script src=\"https://ajax.googleapis.com/ajax/libs/jquery/1.6.1/jquery.min.js\"></script>" + Environment.NewLine);
            sbOGTags.Append("<script src=\"http://connect.facebook.net/en_US/all.js#appId=" + QSVars["app_id"].ToString() + "&amp;xfbml=1\"></script>" + Environment.NewLine);
            return sbOGTags.ToString();
        }

        private string GetHeadBannerURL(string sProductID)
        {
            string NotifierDID = ofbBiz.GetNotifierDID(sProductID);
            if (string.IsNullOrEmpty(NotifierDID))
            {
                _sNotifierDID = new AppNotifier().GetNewDIDWithPrefix();
            }
            else
            {
                _sNotifierDID = NotifierDID;
            }


            StringBuilder sbBannerURL = new StringBuilder();
            sbBannerURL.Append("<script type=\"text/javascript\">" + Environment.NewLine);
            sbBannerURL.Append("$(document).ready(function () {" + Environment.NewLine);
            sbBannerURL.Append("$(\"#aHeadBanner\").click(function () {" + Environment.NewLine);
            sbBannerURL.Append("AsycRequest('" + GetNavigationURL(NotifyURL + "FBNotify.aspx?NTYP=CLICK&PDID=" + sProductID + "&NDID=" + _sNotifierDID, true) + "');" + Environment.NewLine);
            sbBannerURL.Append("});" + Environment.NewLine);
            sbBannerURL.Append("});" + Environment.NewLine);
            sbBannerURL.Append("</script>" + Environment.NewLine);

            return sbBannerURL.ToString();
        }

        private string GetNotifyLIKE(string sProductID)
        {
            string _sAppPathLink = ofbBiz.GetAppPagePath(QSVars["app_id"].ToString());
            string _sNotifierDID = new AppNotifier().GetNewDIDWithPrefix();
            if (!_sAppPathLink.EndsWith("?")) _sAppPathLink += "&";
            //Build NotifierDID & pass it to link
            _sAppPathLink += "NDID=" + _sNotifierDID;
            AppProduct oAppProduct = new AppProduct();
            StringBuilder sbNotifyLIKE = new StringBuilder();
            sbNotifyLIKE.Append("<script>" + Environment.NewLine);
            sbNotifyLIKE.Append("$(\"document\").ready(function () {" + Environment.NewLine);
            //catch like event
            sbNotifyLIKE.Append("FB.Event.subscribe('edge.create', function (href, widget) {" + Environment.NewLine);
            sbNotifyLIKE.Append("AsycRequest('" + GetNavigationURL("https://www.testsonetreach.com/FBNotify.aspx?NTYP=LIKE&PDID=" + sProductID + "&NDID=" + _sNotifierDID, true) + "');" + Environment.NewLine);
            sbNotifyLIKE.Append("});" + Environment.NewLine);
            //catch unlike event
            sbNotifyLIKE.Append("FB.Event.subscribe('edge.remove', function (href, widget) {" + Environment.NewLine);
            //sbNotifyLIKE.Append("alert('You just unliked ' + href);" + Environment.NewLine);
            sbNotifyLIKE.Append("});" + Environment.NewLine);
            sbNotifyLIKE.Append("});" + Environment.NewLine);
            sbNotifyLIKE.Append("</script>" + Environment.NewLine);

            return sbNotifyLIKE.ToString();
        }


        protected string GetInitializedJS()
        {
            if (QSVars.Contains("app_id"))
            {
                StringBuilder oFBJSBuilder = new StringBuilder();
                //Intitialize FBJS for widgets on page load            
                oFBJSBuilder.Append("<div id=\"fb-root\"></div>" + Environment.NewLine);
                oFBJSBuilder.Append("<script src=\"//connect.facebook.net/en_US/all.js\"></script>" + Environment.NewLine);
                oFBJSBuilder.Append("<script>" + Environment.NewLine);
                oFBJSBuilder.Append("FB.init({" + Environment.NewLine);
                oFBJSBuilder.Append("appId: '" + QSVars["app_id"].ToString() + "'," + Environment.NewLine);
                oFBJSBuilder.Append("//channelUrl: '//WWW.YOUR_DOMAIN.COM/channel.html', // Channel File" + Environment.NewLine);
                oFBJSBuilder.Append("status: true, // check login status" + Environment.NewLine);
                oFBJSBuilder.Append("cookie: true, // enable cookies to allow the server to access the session" + Environment.NewLine);
                oFBJSBuilder.Append("xfbml: true,  // parse XFBML" + Environment.NewLine);
                oFBJSBuilder.Append("frictionlessRequests : true" + Environment.NewLine);
                oFBJSBuilder.Append("});" + Environment.NewLine);
                oFBJSBuilder.Append("FB.Canvas.setAutoGrow(100);");
                //oFBJSBuilder.Append("window.onload = function() {FB.Canvas.setAutoGrow(100);}");
                oFBJSBuilder.Append("</script>" + Environment.NewLine);

                return oFBJSBuilder.ToString();
            }
            else
            {
                return string.Empty;
            }
        }

        public string CallWebRequest(string Method, string Url, string PostData)
        {
            try
            {
                string ResponseString = "";

                // setup request object
                HttpWebRequest Request = (HttpWebRequest)WebRequest.Create(Url);
                Request.Method = Method;
                Request.ServicePoint.Expect100Continue = false;
                Request.UserAgent = "soNET";
                Request.Timeout = 20000;

                // add post data
                if (Method == "POST")
                {
                    Request.ContentType = "application/x-www-form-urlencoded";
                    Stream RequestStream = Request.GetRequestStream();
                    if (RequestStream != null)
                    {
                        StreamWriter RequestWriter = new StreamWriter(RequestStream);
                        RequestWriter.Write(PostData);
                        RequestWriter.Close();
                    }
                }

                WebResponse Response = Request.GetResponse();
                if (Response != null)
                {
                    System.IO.Stream Stream = Response.GetResponseStream();
                    if (Stream != null)
                    {
                        StreamReader Reader = new StreamReader(Stream);
                        ResponseString = Reader.ReadToEnd();
                        Reader.Close();
                        Stream.Close();
                    }
                }

                return ResponseString;
            }
            catch (Exception ex)
            {
                CommonUtility commUtil = new CommonUtility();
                commUtil.SendErrorMail(ex.Message, ex.StackTrace, System.Reflection.MethodBase.GetCurrentMethod().Name.ToString(), System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.ToString(), SessionData.Customer.CustomerID);
            }
            return string.Empty;
        }

        private void Page_PreRender(object sender, System.EventArgs e)
        {
            SonetPie osonetpie = new SonetPie();
            AppUser oDCAppUser = new AppUser();
            CanvasBizProcess ocanvBiz = new CanvasBizProcess();
            FacebookBizProcess fbBizProc = new FacebookBizProcess();
            try
            {

                if (Request.Browser.IsMobileDevice == true || Request.UserAgent.ToLower().Contains("iphone") || Request.UserAgent.ToLower().Contains("android") || Request.UserAgent.ToLower().Contains("ipad"))
                {
                    if (QSVars.Contains("oauth_token") && QSVars.Contains("oauth_token"))
                    {
                        Response.Redirect(NotifyURL + "MobileRedirect.aspx?app_id=" + QSVars["app_id"].ToString() + "&access_tok=" + QSVars["oauth_token"].ToString() + "&user_id=" + QSVars["user_id"], false);
                    }
                    else
                    {
                        Response.Redirect(NotifyURL + "MobileRedirect.aspx?app_id=" + QSVars["app_id"].ToString() + "&access_tok=" + Convert.ToString(Session["oauth_token"]) + "&user_id=" + Convert.ToString(Session["user_id"]), false);
                    }
                }


                MainJavaScriptContent.Text = GetInitializedJS();

                //NEW VERSION 13-April-2012
                //Use the response_type=code to generate the access token            
                if (Request.QueryString.Count == 2)
                {


                    //close and redirect to SelectPage
                    StringBuilder oSBWindowScript = new StringBuilder();

                    string pageCaller = "{code:\"" + Convert.ToString(QSVars["code"]) + "\",app_id:\"" + Convert.ToString(QSVars["app_id"]) + "\"}";
                    oSBWindowScript.Append("window.opener.tabSelection(" + pageCaller + ");");
                    oSBWindowScript.Append("window.close();");



                    Page.ClientScript.RegisterStartupScript(this.GetType(), "myCloseScript", oSBWindowScript.ToString(), true);

                    Response.Redirect("SelectPage.aspx?app_id=" + Convert.ToString(QSVars["app_id"]) + "&code=" + Convert.ToString(QSVars["code"]), false);



                }

                if (Request.QueryString.Count == 1)
                {
                    osonetpie.QSvarsString = GetQsVarsCollection();
                    osonetpie.AbsolutePath = AbsolutePagePath;



                    if (QSVars.Count > 6)
                    {

                        oDCAppUser.AppConfigDID = QSVars["ADID"].ToString();
                        hdnAppConfigD.Value = oDCAppUser.AppConfigDID;
                        oDCAppUser.SonetID = QSVars["user_id"].ToString();
                        hdnUserID.Value = oDCAppUser.SonetID;
                        hdnAppID.Value = QSVars["app_id"].ToString();
                        Session["UserID"] = hdnUserID.Value;
                        Session["AppID"] = hdnAppID.Value;
                        Session["ADID"] = oDCAppUser.AppConfigDID;
                        oDCAppUser = ofbBiz.GetAppUser(osonetpie, QSVars["ADID"].ToString(), QSVars["user_id"].ToString());

                        if (QSVars.Contains("liked"))
                        {
                            if (QSVars["liked"].Equals("true") && !ofbBiz.IsLikeGatewayAdded(QSVars["ADID"].ToString())) // If Already liked show page else Force user to like, iff like gateway was selected
                            {
                                //check if configuration is still good- that means not EXPIRED
                                if (!ofbBiz.IsConfigurationExpired(QSVars["ADID"].ToString()))
                                {
                                    //populate the AppProduct encapsulation based on app that is loaded
                                    AppProduct oAppProduct = new AppProduct();
                                    FaceBook facebook = new FaceBook();

                                    oAppProduct = ofbBiz.GetActiveAppProduct(osonetpie, QSVars["ADID"].ToString());
                                    litHeadBannerCount.Text = GetHeadBannerURL(oAppProduct.DID);
                                    // Get the HTML to be shown



                                    //Get Custom Tab name
                                    string CustTabNAme = fbBizProc.GetCustomTabName(Session["AppID"].ToString());

                                    //Get Share Button for this Product
                                    string CommentBox = GetCommentPlugin(oAppProduct.DID, oAppProduct.ProductName, oAppProduct.ProductLogo, oAppProduct.ProductShortDesc, QSVars["app_id"].ToString(), fbBizProc.GetAppPagePath(Convert.ToString(QSVars["app_id"])));
                                    string ShareButton = GetShareButton(oAppProduct.DID, oAppProduct.ProductName, oAppProduct.ProductLogo, oAppProduct.ProductShortDesc, QSVars["app_id"].ToString(), CustTabNAme);
                                    string InviteButton = GetInviteButton(oAppProduct.DID, oAppProduct.ProductName, oAppProduct.ProductLogo, oAppProduct.ProductShortDesc, QSVars["app_id"].ToString());
                                    string RecommendButton = GetRecommendButton(oAppProduct.DID, oAppProduct.ProductName, oAppProduct.ProductLogo, oAppProduct.ProductShortDesc, QSVars["app_id"].ToString());
                                    string LikePlugin = GetLikePlugin(oAppProduct.DID, oAppProduct.ProductName, oAppProduct.ProductLogo, oAppProduct.ProductShortDesc, QSVars["app_id"].ToString());
                                    string EntryFormPlug = GetEntryForm(oAppProduct.DID, oAppProduct.ProductName, oAppProduct.ProductLogo, oAppProduct.ProductShortDesc, QSVars["ADID"].ToString(), QSVars["user_id"].ToString());
                                    string LeadPlugin = GetLeadButton(oAppProduct.DID, oAppProduct.ProductName, oAppProduct.ProductLogo, oAppProduct.ProductShortDesc, QSVars["app_id"].ToString());
                                    string PrintButton = GetPrint(oAppProduct.DID, oAppProduct.ProductName, oAppProduct.ProductLogo, oAppProduct.ProductShortDesc, QSVars["app_id"].ToString());
                                    string EmailButton = GetEmail(oAppProduct.DID, oAppProduct.ProductName, oAppProduct.ProductLogo, oAppProduct.ProductShortDesc, QSVars["app_id"].ToString());
                                    string TwitterButton = GetTwitterShareURL(oAppProduct.DID, oAppProduct.ProductName, oAppProduct.ProductLogo, oAppProduct.ProductShortDesc, QSVars["app_id"].ToString());
                                    string LinkedInButton = "<script src=\"//platform.linkedin.com/in.js\" type=\"text/javascript\"></script><script type=\"IN/Share\" data-counter=\"right\" data-url=\"" + ofbBiz.GetAppPath(Convert.ToString(Request.QueryString["app_id"])) + "\"  data-onSuccess=\"LIShare\"></script><script type=\"text/javascript\">            function LIShare() { AsycRequest('" + GetNavigationURL(NotifyURL + "FBNotify.aspx?NTYP=LISHARE&PDID=" + oAppProduct.DID + "&NDID=" + _sNotifierDID, true) + "');  }</script>";
                                    if (!oAppProduct.ProductCategory.Equals("WebHutColl."))
                                    {

                                        litHeadBannerCount.Text = GetHeadBannerURL(oAppProduct.DID);
                                        // Get the HTML to be shown

                                        string HTML = oAppProduct.ProductHTML;

                                        //Get Share Button for this Product

                                        if (oAppProduct.CommentsWidgetAdded.Equals(TRUE))
                                        {
                                            addCOMMENT = HTML.Replace("CommBox", CommentBox);
                                        }
                                        else
                                        {
                                            addCOMMENT = HTML.Replace("CommBox", "");
                                        }

                                        if (oAppProduct.ShareWidgetAdded.Equals(TRUE))
                                        {
                                            addSHARE = addCOMMENT.Replace("ShButton", ShareButton);
                                        }
                                        else
                                        {
                                            addSHARE = addCOMMENT.Replace("ShButton", "");
                                        }
                                        if (oAppProduct.TwitterWidgetAdded.Equals(TRUE))
                                        {
                                            addTwitter = addSHARE.Replace("TwButton", TwitterButton);
                                        }
                                        else
                                        {
                                            addTwitter = addSHARE.Replace("TwButton", string.Empty);
                                        }


                                        if (ocanvBiz.IsConfigForSweepstakes(oAppProduct.AppConfigDID))
                                        {
                                            if (oAppProduct.ReccWidgetAdded.Equals(TRUE))
                                            {
                                                addPOST = addTwitter.Replace("ReButton", InviteButton);
                                            }
                                            else
                                            {
                                                addPOST = addTwitter.Replace("ReButton", "");
                                            }
                                            //if HTML contains LIKE
                                            addEntry = addPOST.Replace("Entry", EntryFormPlug);

                                            if (string.IsNullOrEmpty(oAppProduct.AppCaption))
                                            {
                                                addCaption = addEntry.Replace("Caption", "");
                                            }
                                            else
                                            {
                                                addCaption = addEntry.Replace("Caption", oAppProduct.AppCaption);
                                            }

                                            if (oAppProduct.InquiryWidgetAdded.Equals(TRUE))
                                            {
                                                addLead = addCaption.Replace("Lead", LeadPlugin);
                                            }
                                            else
                                            {
                                                addLead = addCaption.Replace("Lead", "");
                                            }

                                            if (oAppProduct.LikeWidgetAdded.Equals(TRUE))
                                            {
                                                addLIKE = addLead.Replace("Like", LikePlugin);
                                            }
                                            else
                                            {
                                                addLIKE = addLead.Replace("Like", "");
                                            }

                                            litAppHTML.Text = addLIKE;
                                            hdnStatus.Value = "HIDE";
                                            apppathLink.Visible = false;
                                        }
                                        else
                                        {

                                            if (oAppProduct.ReccWidgetAdded.Equals(TRUE))
                                            {
                                                addPOST = addTwitter.Replace("ReButton", RecommendButton);
                                            }
                                            else
                                            {
                                                addPOST = addTwitter.Replace("ReButton", "");
                                            }

                                            if (oAppProduct.LikeWidgetAdded.Equals(TRUE))
                                            {
                                                addLIKE = addPOST.Replace("Like", LikePlugin);
                                            }
                                            else
                                            {
                                                addLIKE = addPOST.Replace("Like", "");
                                            }

                                            //if HTML contains LIKE
                                            addEntry = addLIKE.Replace("Entry", EntryFormPlug);

                                            if (oAppProduct.InquiryWidgetAdded.Equals(TRUE))
                                            {
                                                addLead = addEntry.Replace("Lead", LeadPlugin);
                                            }
                                            else
                                            {
                                                addLead = addEntry.Replace("Lead", "");
                                            }

                                            if (string.IsNullOrEmpty(oAppProduct.AppCaption))
                                            {
                                                addCaption = addLead.Replace("Caption", "");
                                            }
                                            else
                                            {
                                                addCaption = addLead.Replace("Caption", oAppProduct.AppCaption);
                                            }
                                            string addPrint = addCaption.Replace("Print", PrintButton);
                                            string addEmail = addPrint.Replace("Email", EmailButton);
                                            addTwitter = addEmail.Replace("TwButton", TwitterButton);
                                            litAppHTML.Text = addEmail;
                                            hdnStatus.Value = "HIDE";
                                            apppathLink.Visible = false;
                                        }
                                    }
                                    else
                                    {

                                        pageToLoad = "index.html";

                                        SiteID = fbBizProc.GetSiteIDForConfig(Convert.ToString(QSVars["ADID"]));
                                        SessionData.Config = new AppConfiguration();
                                        SessionData.Config.SSiteID = SiteID;
                                        TemplateID = fbBizProc.GetTemplateIDForConfig(Convert.ToString(QSVars["ADID"]));


                                        hdnPageToLoad.Value = pageToLoad;
                                        StreamReader streamReader = new StreamReader(Server.MapPath("Sites\\Final\\" + SiteID + "\\" + pageToLoad));
                                        string text = streamReader.ReadToEnd();
                                        streamReader.Close();


                                        //check for DirtyPage
                                        string Query = "select DirtyPage from Sites where SiteId=" + SiteID;

                                        DataSet oDataSet = new DataSet();
                                        SqlHelper.FillDataset(ConfigurationSettings.AppSettings["SoConn"].ToString(), CommandType.Text, Query, oDataSet, new string[] { "SiteDetails" });

                                        string isDirty = Convert.ToString(oDataSet.Tables["SiteDetails"].Rows[0]["DirtyPage"]);

                                        if (isDirty.Equals("Y"))
                                        {
                                            text = text.Replace("<img class=\"dynamic\" src=\"images/SNR_facebook.png\">", ShareButton);

                                            text = text.Replace("<img class=\"dynamic\" src=\"images/SNR_recommend.png\">", RecommendButton);

                                            text = text.Replace("<img class=\"dynamic\" src=\"images/fb-like-button.png\">", LikePlugin);

                                            text = text.Replace("<img class=\"dynamic\" src=\"images/SNR_twitter.png\">", TwitterButton);
                                            text = text.Replace("<img class=\"dynamic\" src=\"images/SNR_linkedIn.png\">", LinkedInButton);

                                            if (TemplateID == 11)
                                            {
                                                text = text.Replace("<img class=\"ActionImg\" src=\"images/email.png\">", EmailButton);
                                                text = text.Replace("<img class=\"ActionImg\" src=\"images/print.png\">", PrintButton);
                                            }
                                        }
                                        else
                                        {
                                            text = text.Replace("<img class=\"dynamic\" src=\"images/SNR_facebook.png\" />", ShareButton);

                                            text = text.Replace("<img class=\"dynamic\" src=\"images/SNR_recommend.png\" />", RecommendButton);

                                            text = text.Replace("<img class=\"dynamic\" src=\"images/fb-like-button.png\" />", LikePlugin);

                                            text = text.Replace("<img class=\"dynamic\" src=\"images/SNR_twitter.png\" />", TwitterButton);
                                            text = text.Replace("<img class=\"dynamic\" src=\"images/SNR_linkedIn.png\">", LinkedInButton);
                                            if (TemplateID == 11)
                                            {
                                                text = text.Replace("<img class=\"ActionImg\" src=\"Images/email.png\">", EmailButton);
                                                text = text.Replace("<img class=\"ActionImg\" src=\"Images/print.png\">", PrintButton);
                                            }
                                        }

                                        //fix all Image tags
                                        string imagesReplaced = text.Replace("images", "images1/" + SiteID);

                                        String style;

                                        if (TemplateID == 12)
                                        {
                                            style = "/CSS/RStore_style.css";
                                            SessionData.PrefData.TemplateID1 = TemplateID;
                                        }
                                        else if (TemplateID == 13)
                                        {
                                            style = "/CSS/FabrikStyle.css";
                                            popupContact.Visible = false;
                                            SessionData.PrefData.TemplateID1 = TemplateID;
                                        }
                                        else if (TemplateID == 11)
                                        {
                                            style = "/CSS/CouponsStyle.css";
                                            popupContact.Visible = false;
                                            SessionData.PrefData.TemplateID1 = TemplateID;
                                        }
                                        else if (TemplateID == 14)
                                        {
                                            style = "/CSS/realestate_styles.css";
                                            SessionData.PrefData.TemplateID1 = TemplateID;

                                        }
                                        else if (TemplateID == 16)
                                        {
                                            style = "/CSS/Restaurantstyle.css";
                                            SessionData.PrefData.TemplateID1 = TemplateID;

                                        }
                                        else if (TemplateID == 17)
                                        {
                                            style = "/CSS/Educationalstyle.css";
                                            SessionData.PrefData.TemplateID1 = TemplateID;

                                        }
                                        else
                                        {
                                            style = "/CSS/PFstyle.css";
                                            SessionData.PrefData.TemplateID1 = TemplateID;

                                        }


                                        //get all the Images, Styles in 
                                        System.IO.StreamReader StreamReader1 =
new System.IO.StreamReader(Server.MapPath("./Sites/Final/" + SiteID + style));
                                        string ReadStyle = StreamReader1.ReadToEnd();
                                        StreamReader1.Close();

                                        if (TemplateID == 14)
                                        {
                                            HtmlLink linking = Page.FindControl("facebookIDStyleSheet") as HtmlLink;
                                            linking.Href = "./Sites/Final/" + SiteID + style;
                                        }

                                        System.IO.StreamReader StreamReader2 =
new System.IO.StreamReader(Server.MapPath("./ScriptsSonetReach/Facebookstyles.css"));
                                        string CleanStyle = StreamReader2.ReadToEnd();
                                        CleanStyle = string.Empty;
                                        StreamReader2.Close();

                                        System.IO.StreamWriter StreamWriter2 =
                        new System.IO.StreamWriter(Server.MapPath("./ScriptsSonetReach/Facebookstyles.css"));
                                        StreamWriter2.WriteLine(CleanStyle);
                                        StreamWriter2.Close();

                                        System.IO.StreamWriter StreamWriter1 =
                        new System.IO.StreamWriter(Server.MapPath("./ScriptsSonetReach/Facebookstyles.css"));
                                        StreamWriter1.WriteLine(ReadStyle);
                                        StreamWriter1.Close();

                                        ////saranya

                                        //System.IO.StreamReader sr = new System.IO.StreamReader(Server.MapPath("./ScriptsSonetReach/Facebookstyles.css"));
                                        //String fileContents = sr.ReadToEnd();
                                        //sr.Close();

                                        //System.IO.StreamWriter sw = new System.IO.StreamWriter(Server.MapPath("./ScriptsSonetReach/Facebookstyles.css"));
                                        //fileContents = fileContents.Replace("images", "images1/" + SiteID + "");
                                        //sw.WriteLine(fileContents);
                                        //sw.Close();


                                        ///NOW process all the images
                                        string imagePath = Server.MapPath("./Sites/Final/" + SiteID + "/Images/");
                                        string[] files = System.IO.Directory.GetFiles(imagePath);


                                        if (!Directory.Exists(Server.MapPath("./Images1/" + SiteID)))
                                        {
                                            Directory.CreateDirectory(Server.MapPath("./Images1/" + SiteID));
                                        }

                                        foreach (string file in files)
                                        {
                                            if (!System.IO.File.Exists(Server.MapPath("./Images1/" + SiteID + "/" + System.IO.Path.GetFileName(file))))
                                            {
                                                System.IO.File.Copy(file, System.IO.Path.Combine(Server.MapPath("./Images1/" + SiteID), System.IO.Path.GetFileName(file)));
                                            }
                                        }
                                        LoadComplete = true;


                                        litAppHTML.Text = imagesReplaced;

                                        if (TemplateID == 13)
                                        {
                                            litAppHTML.Text = litAppHTML.Text.Replace("<link href=\"CSS/FabrikStyle.css\" rel=\"stylesheet\" type=\"text/css\">", "");
                                        }
                                        else if (TemplateID == 11)
                                        {
                                            litAppHTML.Text = litAppHTML.Text.Replace("<link href=\"CSS/CouponsStyle.css\" rel=\"stylesheet\" type=\"text/css\" />", "");
                                        }
                                        backgroundPopup.Visible = false;
                                    }

                                }
                                else if (ofbBiz.IsSweepstakesAppModel(QSVars["ADID"].ToString()) == "SWEEPSTAKES") // Check if Sweepstake Appmodal
                                {
                                    if (ofbBiz.IsSweepstakesWinnerDay(QSVars["ADID"].ToString()))// Check if Sweepstake Date is today, redirect to Show Winners
                                    {
                                        Response.Redirect("SweepstakesWinners.aspx?ADID=" + Convert.ToString(QSVars["ADID"]), false);
                                    }
                                    else
                                    {
                                        string Enddate = ofbBiz.GetSweepstakesEndDate(QSVars["ADID"].ToString());
                                        if (!string.IsNullOrEmpty(Enddate))
                                        {
                                            DateTime sd = DateTime.Parse(Enddate);
                                            Enddate = sd.ToString("dd/M/yyyy");
                                        }
                                        //litAppHTML.Text = "Sweepstakes Contest is over. Results will be shown on ...";
                                        apppathLink.InnerText = "Sweepstakes Contest is over. Winners will be announced on " + Enddate;
                                        popupContact.Style.Add("margin-left", "250px");
                                    }

                                }
                                else
                                {
                                    AppExpired.Visible = true;
                                    litAppHTML.Text = "";
                                    popupContact.Visible = false;
                                }
                            }
                            else
                            {
                                if (ofbBiz.IsLikeGatewayAdded(QSVars["ADID"].ToString()))
                                {
                                    //means app page is liked and now user shud be shown app
                                    if (QSVars["liked"].Equals("true"))
                                    {
                                        if (!ofbBiz.IsConfigurationExpired(QSVars["ADID"].ToString()))
                                        {
                                            //populate the AppProduct encapsulation based on app that is loaded
                                            AppProduct oAppProduct = new AppProduct();
                                            FaceBook facebook = new FaceBook();

                                            oAppProduct = ofbBiz.GetActiveAppProduct(osonetpie, QSVars["ADID"].ToString());
                                            litHeadBannerCount.Text = GetHeadBannerURL(oAppProduct.DID);
                                            // Get the HTML to be shown

                                            string HTML = oAppProduct.ProductHTML;

                                            //Get Custom Tab name
                                            string CustTabNAme = fbBizProc.GetCustomTabName(Session["AppID"].ToString());

                                            //Get Share Button for this Product
                                            string CommentBox = GetCommentPlugin(oAppProduct.DID, oAppProduct.ProductName, oAppProduct.ProductLogo, oAppProduct.ProductShortDesc, QSVars["app_id"].ToString(), fbBizProc.GetAppPagePath(Convert.ToString(QSVars["app_id"])));
                                            string ShareButton = GetShareButton(oAppProduct.DID, oAppProduct.ProductName, oAppProduct.ProductLogo, oAppProduct.ProductShortDesc, QSVars["app_id"].ToString(), CustTabNAme);
                                            string InviteButton = GetInviteButton(oAppProduct.DID, oAppProduct.ProductName, oAppProduct.ProductLogo, oAppProduct.ProductShortDesc, QSVars["app_id"].ToString());
                                            string RecommendButton = GetRecommendButton(oAppProduct.DID, oAppProduct.ProductName, oAppProduct.ProductLogo, oAppProduct.ProductShortDesc, QSVars["app_id"].ToString());
                                            string LikePlugin = GetLikePlugin(oAppProduct.DID, oAppProduct.ProductName, oAppProduct.ProductLogo, oAppProduct.ProductShortDesc, QSVars["app_id"].ToString());
                                            string EntryFormPlug = GetEntryForm(oAppProduct.DID, oAppProduct.ProductName, oAppProduct.ProductLogo, oAppProduct.ProductShortDesc, QSVars["ADID"].ToString(), QSVars["user_id"].ToString());
                                            string LeadPlugin = GetLeadButton(oAppProduct.DID, oAppProduct.ProductName, oAppProduct.ProductLogo, oAppProduct.ProductShortDesc, QSVars["app_id"].ToString());
                                            string PrintButton = GetPrint(oAppProduct.DID, oAppProduct.ProductName, oAppProduct.ProductLogo, oAppProduct.ProductShortDesc, QSVars["app_id"].ToString());
                                            string EmailButton = GetEmail(oAppProduct.DID, oAppProduct.ProductName, oAppProduct.ProductLogo, oAppProduct.ProductShortDesc, QSVars["app_id"].ToString());
                                            string TwitterButton = GetTwitterShareURL(oAppProduct.DID, oAppProduct.ProductName, oAppProduct.ProductLogo, oAppProduct.ProductShortDesc, QSVars["app_id"].ToString());
                                            if (oAppProduct.CommentsWidgetAdded.Equals(TRUE))
                                            {
                                                addCOMMENT = HTML.Replace("CommBox", CommentBox);
                                            }
                                            else
                                            {
                                                addCOMMENT = HTML.Replace("CommBox", "");
                                            }

                                            if (oAppProduct.ShareWidgetAdded.Equals(TRUE))
                                            {
                                                addSHARE = addCOMMENT.Replace("ShButton", ShareButton);
                                            }
                                            else
                                            {
                                                addSHARE = addCOMMENT.Replace("ShButton", "");
                                            }

                                            if (oAppProduct.TwitterWidgetAdded.Equals(TRUE))
                                            {
                                                addTwitter = addSHARE.Replace("TwButton", TwitterButton);
                                            }
                                            else
                                            {
                                                addTwitter = addSHARE.Replace("TwButton", string.Empty);
                                            }


                                            if (ocanvBiz.IsConfigForSweepstakes(oAppProduct.AppConfigDID))
                                            {
                                                if (oAppProduct.ReccWidgetAdded.Equals(TRUE))
                                                {
                                                    addPOST = addTwitter.Replace("ReButton", InviteButton);
                                                }
                                                else
                                                {
                                                    addPOST = addTwitter.Replace("ReButton", "");
                                                }
                                                //if HTML contains LIKE
                                                addEntry = addPOST.Replace("Entry", EntryFormPlug);

                                                if (string.IsNullOrEmpty(oAppProduct.AppCaption))
                                                {
                                                    addCaption = addEntry.Replace("Caption", "");
                                                }
                                                else
                                                {
                                                    addCaption = addEntry.Replace("Caption", oAppProduct.AppCaption);
                                                }

                                                if (oAppProduct.InquiryWidgetAdded.Equals(TRUE))
                                                {
                                                    addLead = addCaption.Replace("Lead", LeadPlugin);
                                                }
                                                else
                                                {
                                                    addLead = addCaption.Replace("Lead", "");
                                                }

                                                if (oAppProduct.LikeWidgetAdded.Equals(TRUE))
                                                {
                                                    addLIKE = addLead.Replace("Like", LikePlugin);
                                                }
                                                else
                                                {
                                                    addLIKE = addLead.Replace("Like", "");
                                                }

                                                litAppHTML.Text = addLIKE;
                                                hdnStatus.Value = "HIDE";
                                                apppathLink.Visible = false;
                                            }
                                            else
                                            {

                                                if (oAppProduct.ReccWidgetAdded.Equals(TRUE))
                                                {
                                                    addPOST = addTwitter.Replace("ReButton", RecommendButton);
                                                }
                                                else
                                                {
                                                    addPOST = addTwitter.Replace("ReButton", "");
                                                }

                                                if (oAppProduct.LikeWidgetAdded.Equals(TRUE))
                                                {
                                                    addLIKE = addPOST.Replace("Like", LikePlugin);
                                                }
                                                else
                                                {
                                                    addLIKE = addPOST.Replace("Like", "");
                                                }

                                                if (oAppProduct.InquiryWidgetAdded.Equals(TRUE))
                                                {
                                                    addLead = addLIKE.Replace("Lead", LeadPlugin);
                                                }
                                                else
                                                {
                                                    addLead = addLIKE.Replace("Lead", "");
                                                }

                                                if (string.IsNullOrEmpty(oAppProduct.AppCaption))
                                                {
                                                    addCaption = addLead.Replace("Caption", "");
                                                }
                                                else
                                                {
                                                    addCaption = addLead.Replace("Caption", oAppProduct.AppCaption);
                                                }
                                                string addPrint = addCaption.Replace("Print", PrintButton);
                                                string addEmail = addPrint.Replace("Email", EmailButton);
                                                litAppHTML.Text = addEmail;
                                                hdnStatus.Value = "HIDE";
                                                apppathLink.Visible = false;
                                            }
                                        }
                                        else if (ofbBiz.IsSweepstakesAppModel(QSVars["ADID"].ToString()) == "SWEEPSTAKES") // Check if Sweepstake Appmodal
                                        {
                                            if (ofbBiz.IsSweepstakesWinnerDay(QSVars["ADID"].ToString()))// Check if Sweepstake Date is today, redirect to Show Winners
                                            {
                                                Response.Redirect("SweepstakesWinners.aspx?ADID=" + Convert.ToString(QSVars["ADID"]), false);
                                            }
                                            else
                                            {
                                                string Enddate = ofbBiz.GetSweepstakesEndDate(QSVars["ADID"].ToString());
                                                if (!string.IsNullOrEmpty(Enddate))
                                                {
                                                    DateTime sd = DateTime.Parse(Enddate);
                                                    Enddate = sd.ToString("dd/M/yyyy");
                                                }
                                                //litAppHTML.Text = "Sweepstakes Contest is over. Results will be shown on ...";
                                                apppathLink.InnerText = "Sweepstakes Contest is over. Winners will be announced on " + Enddate;
                                                popupContact.Style.Add("margin-left", "250px");
                                            }

                                        }
                                        else
                                        {
                                            AppExpired.Visible = true;
                                            litAppHTML.Text = "";
                                            popupContact.Visible = false;
                                        }
                                    }
                                    else
                                    {
                                        if (!QSVars["admin"].Equals("true"))
                                        {
                                            litAppHTML.Text = " <img id=\"imgLGateway\" src=\"Images/like_us_to_proceed.jpg\"/>";
                                            popupContact.Visible = false;
                                            backgroundPopup.Visible = false;
                                        }
                                        else
                                        {
                                            if (!ofbBiz.IsConfigurationExpired(QSVars["ADID"].ToString()))
                                            {
                                                //populate the AppProduct encapsulation based on app that is loaded
                                                AppProduct oAppProduct = new AppProduct();
                                                FaceBook facebook = new FaceBook();

                                                oAppProduct = ofbBiz.GetActiveAppProduct(osonetpie, QSVars["ADID"].ToString());
                                                litHeadBannerCount.Text = GetHeadBannerURL(oAppProduct.DID);
                                                // Get the HTML to be shown

                                                string HTML = oAppProduct.ProductHTML;

                                                //Get Custom Tab name
                                                string CustTabNAme = fbBizProc.GetCustomTabName(Session["AppID"].ToString());

                                                //Get Share Button for this Product
                                                string CommentBox = GetCommentPlugin(oAppProduct.DID, oAppProduct.ProductName, oAppProduct.ProductLogo, oAppProduct.ProductShortDesc, QSVars["app_id"].ToString(), fbBizProc.GetAppPagePath(Convert.ToString(QSVars["app_id"])));
                                                string ShareButton = GetShareButton(oAppProduct.DID, oAppProduct.ProductName, oAppProduct.ProductLogo, oAppProduct.ProductShortDesc, QSVars["app_id"].ToString(), CustTabNAme);
                                                string InviteButton = GetInviteButton(oAppProduct.DID, oAppProduct.ProductName, oAppProduct.ProductLogo, oAppProduct.ProductShortDesc, QSVars["app_id"].ToString());
                                                string RecommendButton = GetRecommendButton(oAppProduct.DID, oAppProduct.ProductName, oAppProduct.ProductLogo, oAppProduct.ProductShortDesc, QSVars["app_id"].ToString());
                                                string LikePlugin = GetLikePlugin(oAppProduct.DID, oAppProduct.ProductName, oAppProduct.ProductLogo, oAppProduct.ProductShortDesc, QSVars["app_id"].ToString());
                                                string EntryFormPlug = GetEntryForm(oAppProduct.DID, oAppProduct.ProductName, oAppProduct.ProductLogo, oAppProduct.ProductShortDesc, QSVars["ADID"].ToString(), QSVars["user_id"].ToString());
                                                string LeadPlugin = GetLeadButton(oAppProduct.DID, oAppProduct.ProductName, oAppProduct.ProductLogo, oAppProduct.ProductShortDesc, QSVars["app_id"].ToString());
                                                string PrintButton = GetPrint(oAppProduct.DID, oAppProduct.ProductName, oAppProduct.ProductLogo, oAppProduct.ProductShortDesc, QSVars["app_id"].ToString());
                                                string EmailButton = GetEmail(oAppProduct.DID, oAppProduct.ProductName, oAppProduct.ProductLogo, oAppProduct.ProductShortDesc, QSVars["app_id"].ToString());
                                                string TwitterButton = GetTwitterShareURL(oAppProduct.DID, oAppProduct.ProductName, oAppProduct.ProductLogo, oAppProduct.ProductShortDesc, QSVars["app_id"].ToString());
                                                if (oAppProduct.CommentsWidgetAdded.Equals(TRUE))
                                                {
                                                    addCOMMENT = HTML.Replace("CommBox", CommentBox);
                                                }
                                                else
                                                {
                                                    addCOMMENT = HTML.Replace("CommBox", "");
                                                }

                                                if (oAppProduct.ShareWidgetAdded.Equals(TRUE))
                                                {
                                                    addSHARE = addCOMMENT.Replace("ShButton", ShareButton);
                                                }
                                                else
                                                {
                                                    addSHARE = addCOMMENT.Replace("ShButton", "");
                                                }

                                                if (oAppProduct.TwitterWidgetAdded.Equals(TRUE))
                                                {
                                                    addTwitter = addSHARE.Replace("TwButton", TwitterButton);
                                                }
                                                else
                                                {
                                                    addTwitter = addSHARE.Replace("TwButton", string.Empty);
                                                }


                                                if (ocanvBiz.IsConfigForSweepstakes(oAppProduct.AppConfigDID))
                                                {
                                                    if (oAppProduct.ReccWidgetAdded.Equals(TRUE))
                                                    {
                                                        addPOST = addTwitter.Replace("ReButton", InviteButton);
                                                    }
                                                    else
                                                    {
                                                        addPOST = addTwitter.Replace("ReButton", "");
                                                    }
                                                    //if HTML contains LIKE
                                                    addEntry = addPOST.Replace("Entry", EntryFormPlug);

                                                    if (string.IsNullOrEmpty(oAppProduct.AppCaption))
                                                    {
                                                        addCaption = addEntry.Replace("Caption", "");
                                                    }
                                                    else
                                                    {
                                                        addCaption = addEntry.Replace("Caption", oAppProduct.AppCaption);
                                                    }

                                                    if (oAppProduct.InquiryWidgetAdded.Equals(TRUE))
                                                    {
                                                        addLead = addCaption.Replace("Lead", LeadPlugin);
                                                    }
                                                    else
                                                    {
                                                        addLead = addCaption.Replace("Lead", "");
                                                    }

                                                    if (oAppProduct.LikeWidgetAdded.Equals(TRUE))
                                                    {
                                                        addLIKE = addLead.Replace("Like", LikePlugin);
                                                    }
                                                    else
                                                    {
                                                        addLIKE = addLead.Replace("Like", "");
                                                    }

                                                    litAppHTML.Text = addLIKE;
                                                    hdnStatus.Value = "HIDE";
                                                    apppathLink.Visible = false;
                                                }
                                                else
                                                {

                                                    if (oAppProduct.ReccWidgetAdded.Equals(TRUE))
                                                    {
                                                        addPOST = addTwitter.Replace("ReButton", RecommendButton);
                                                    }
                                                    else
                                                    {
                                                        addPOST = addTwitter.Replace("ReButton", "");
                                                    }

                                                    if (oAppProduct.LikeWidgetAdded.Equals(TRUE))
                                                    {
                                                        addLIKE = addPOST.Replace("Like", LikePlugin);
                                                    }
                                                    else
                                                    {
                                                        addLIKE = addPOST.Replace("Like", "");
                                                    }

                                                    if (oAppProduct.InquiryWidgetAdded.Equals(TRUE))
                                                    {
                                                        addLead = addLIKE.Replace("Lead", LeadPlugin);
                                                    }
                                                    else
                                                    {
                                                        addLead = addLIKE.Replace("Lead", "");
                                                    }

                                                    if (string.IsNullOrEmpty(oAppProduct.AppCaption))
                                                    {
                                                        addCaption = addLead.Replace("Caption", "");
                                                    }
                                                    else
                                                    {
                                                        addCaption = addLead.Replace("Caption", oAppProduct.AppCaption);
                                                    }
                                                    string addPrint = addCaption.Replace("Print", PrintButton);
                                                    string addEmail = addPrint.Replace("Email", EmailButton);
                                                    litAppHTML.Text = addEmail;
                                                    hdnStatus.Value = "HIDE";
                                                    apppathLink.Visible = false;
                                                }
                                            }
                                            else if (ofbBiz.IsSweepstakesAppModel(QSVars["ADID"].ToString()) == "SWEEPSTAKES") // Check if Sweepstake Appmodal
                                            {
                                                if (ofbBiz.IsSweepstakesWinnerDay(QSVars["ADID"].ToString()))// Check if Sweepstake Date is today, redirect to Show Winners
                                                {
                                                    Response.Redirect("SweepstakesWinners.aspx?ADID=" + Convert.ToString(QSVars["ADID"]), false);
                                                }
                                                else
                                                {
                                                    string Enddate = ofbBiz.GetSweepstakesEndDate(QSVars["ADID"].ToString());
                                                    if (!string.IsNullOrEmpty(Enddate))
                                                    {
                                                        DateTime sd = DateTime.Parse(Enddate);
                                                        Enddate = sd.ToString("dd/M/yyyy");
                                                    }
                                                    //litAppHTML.Text = "Sweepstakes Contest is over. Results will be shown on ...";
                                                    apppathLink.InnerText = "Sweepstakes Contest is over. Winners will be announced on " + Enddate;
                                                    popupContact.Style.Add("margin-left", "250px");
                                                }

                                            }
                                            else
                                            {
                                                AppExpired.Visible = true;
                                                litAppHTML.Text = "";
                                                popupContact.Visible = false;
                                            }
                                        }
                                    }
                                }
                                else
                                {
                                    if (!ofbBiz.IsConfigurationExpired(QSVars["ADID"].ToString()))
                                    {
                                        //populate the AppProduct encapsulation based on app that is loaded
                                        AppProduct oAppProduct = new AppProduct();
                                        oAppProduct.DID = ofbBiz.GetProductDID(Convert.ToString(QSVars["ADID"]));
                                        FaceBook facebook = new FaceBook();
                                        //Get Custom Tab name
                                        string CustTabNAme = fbBizProc.GetCustomTabName(Session["AppID"].ToString());
                                        string CommentBox = GetCommentPlugin(oAppProduct.DID, oAppProduct.ProductName, oAppProduct.ProductLogo, oAppProduct.ProductShortDesc, QSVars["app_id"].ToString(), fbBizProc.GetAppPagePath(Convert.ToString(QSVars["app_id"])));
                                        string ShareButton = GetShareButton(oAppProduct.DID, oAppProduct.ProductName, oAppProduct.ProductLogo, oAppProduct.ProductShortDesc, QSVars["app_id"].ToString(), CustTabNAme);
                                        string InviteButton = GetInviteButton(oAppProduct.DID, oAppProduct.ProductName, oAppProduct.ProductLogo, oAppProduct.ProductShortDesc, QSVars["app_id"].ToString());
                                        string RecommendButton = GetRecommendButton(oAppProduct.DID, oAppProduct.ProductName, oAppProduct.ProductLogo, oAppProduct.ProductShortDesc, QSVars["app_id"].ToString());
                                        string LikePlugin = GetLikePlugin(oAppProduct.DID, oAppProduct.ProductName, oAppProduct.ProductLogo, oAppProduct.ProductShortDesc, QSVars["app_id"].ToString());
                                        string EntryFormPlug = GetEntryForm(oAppProduct.DID, oAppProduct.ProductName, oAppProduct.ProductLogo, oAppProduct.ProductShortDesc, QSVars["ADID"].ToString(), QSVars["user_id"].ToString());
                                        string LeadPlugin = GetLeadButton(oAppProduct.DID, oAppProduct.ProductName, oAppProduct.ProductLogo, oAppProduct.ProductShortDesc, QSVars["app_id"].ToString());
                                        string PrintButton = GetPrint(oAppProduct.DID, oAppProduct.ProductName, oAppProduct.ProductLogo, oAppProduct.ProductShortDesc, QSVars["app_id"].ToString());
                                        string EmailButton = GetEmail(oAppProduct.DID, oAppProduct.ProductName, oAppProduct.ProductLogo, oAppProduct.ProductShortDesc, QSVars["app_id"].ToString());
                                        string TwitterButton = GetTwitterShareURL(oAppProduct.DID, oAppProduct.ProductName, oAppProduct.ProductLogo, oAppProduct.ProductShortDesc, QSVars["app_id"].ToString());
                                        string LinkedInButton = "<script src=\"//platform.linkedin.com/in.js\" type=\"text/javascript\"></script><script type=\"IN/Share\" data-url=\"" + ofbBiz.GetAppPath(Convert.ToString(Request.QueryString["app_id"])) + "\"  data-onSuccess=\"LIShare\"></script><script type=\"text/javascript\">            function LIShare() { AsycRequest('" + GetNavigationURL(NotifyURL + "FBNotify.aspx?NTYP=LISHARE&PDID=" + oAppProduct.DID + "&NDID=" + _sNotifierDID, true) + "');  }</script>";
                                        oAppProduct = ofbBiz.GetActiveAppProduct(osonetpie, QSVars["ADID"].ToString());
                                        if (!oAppProduct.ProductCategory.Equals("WebHutColl."))
                                        {

                                            litHeadBannerCount.Text = GetHeadBannerURL(oAppProduct.DID);
                                            // Get the HTML to be shown

                                            string HTML = oAppProduct.ProductHTML;

                                            //Get Share Button for this Product

                                            if (oAppProduct.CommentsWidgetAdded.Equals(TRUE))
                                            {
                                                addCOMMENT = HTML.Replace("CommBox", CommentBox);
                                            }
                                            else
                                            {
                                                addCOMMENT = HTML.Replace("CommBox", "");
                                            }

                                            if (oAppProduct.ShareWidgetAdded.Equals(TRUE))
                                            {
                                                addSHARE = addCOMMENT.Replace("ShButton", ShareButton);
                                            }
                                            else
                                            {
                                                addSHARE = addCOMMENT.Replace("ShButton", "");
                                            }
                                            if (oAppProduct.TwitterWidgetAdded.Equals(TRUE))
                                            {
                                                addTwitter = addSHARE.Replace("TwButton", TwitterButton);
                                            }
                                            else
                                            {
                                                addTwitter = addSHARE.Replace("TwButton", string.Empty);
                                            }


                                            if (ocanvBiz.IsConfigForSweepstakes(oAppProduct.AppConfigDID))
                                            {
                                                if (oAppProduct.ReccWidgetAdded.Equals(TRUE))
                                                {
                                                    addPOST = addTwitter.Replace("ReButton", InviteButton);
                                                }
                                                else
                                                {
                                                    addPOST = addTwitter.Replace("ReButton", "");
                                                }
                                                //if HTML contains LIKE
                                                addEntry = addPOST.Replace("Entry", EntryFormPlug);

                                                if (string.IsNullOrEmpty(oAppProduct.AppCaption))
                                                {
                                                    addCaption = addEntry.Replace("Caption", "");
                                                }
                                                else
                                                {
                                                    addCaption = addEntry.Replace("Caption", oAppProduct.AppCaption);
                                                }

                                                if (oAppProduct.InquiryWidgetAdded.Equals(TRUE))
                                                {
                                                    addLead = addCaption.Replace("Lead", LeadPlugin);
                                                }
                                                else
                                                {
                                                    addLead = addCaption.Replace("Lead", "");
                                                }

                                                if (oAppProduct.LikeWidgetAdded.Equals(TRUE))
                                                {
                                                    addLIKE = addLead.Replace("Like", LikePlugin);
                                                }
                                                else
                                                {
                                                    addLIKE = addLead.Replace("Like", "");
                                                }

                                                litAppHTML.Text = addLIKE;
                                                hdnStatus.Value = "HIDE";
                                                apppathLink.Visible = false;
                                            }
                                            else
                                            {

                                                if (oAppProduct.ReccWidgetAdded.Equals(TRUE))
                                                {
                                                    addPOST = addTwitter.Replace("ReButton", RecommendButton);
                                                }
                                                else
                                                {
                                                    addPOST = addTwitter.Replace("ReButton", "");
                                                }

                                                if (oAppProduct.LikeWidgetAdded.Equals(TRUE))
                                                {
                                                    addLIKE = addPOST.Replace("Like", LikePlugin);
                                                }
                                                else
                                                {
                                                    addLIKE = addPOST.Replace("Like", "");
                                                }

                                                //if HTML contains LIKE
                                                addEntry = addLIKE.Replace("Entry", EntryFormPlug);

                                                if (oAppProduct.InquiryWidgetAdded.Equals(TRUE))
                                                {
                                                    addLead = addEntry.Replace("Lead", LeadPlugin);
                                                }
                                                else
                                                {
                                                    addLead = addEntry.Replace("Lead", "");
                                                }

                                                if (string.IsNullOrEmpty(oAppProduct.AppCaption))
                                                {
                                                    addCaption = addLead.Replace("Caption", "");
                                                }
                                                else
                                                {
                                                    addCaption = addLead.Replace("Caption", oAppProduct.AppCaption);
                                                }
                                                string addPrint = addCaption.Replace("Print", PrintButton);
                                                string addEmail = addPrint.Replace("Email", EmailButton);
                                                addTwitter = addEmail.Replace("TwButton", TwitterButton);
                                                litAppHTML.Text = addEmail;
                                                hdnStatus.Value = "HIDE";
                                                apppathLink.Visible = false;
                                            }
                                        }
                                        else
                                        {

                                            pageToLoad = "index.html";

                                            SiteID = fbBizProc.GetSiteIDForConfig(Convert.ToString(QSVars["ADID"]));
                                            SessionData.Config = new AppConfiguration();
                                            SessionData.Config.SSiteID = SiteID;
                                            TemplateID = fbBizProc.GetTemplateIDForConfig(Convert.ToString(QSVars["ADID"]));


                                            hdnPageToLoad.Value = pageToLoad;
                                            StreamReader streamReader = new StreamReader(Server.MapPath("Sites\\Final\\" + SiteID + "\\" + pageToLoad));
                                            string text = streamReader.ReadToEnd();
                                            streamReader.Close();


                                            //check for DirtyPage
                                            string Query = "select DirtyPage from Sites where SiteId=" + SiteID;

                                            DataSet oDataSet = new DataSet();
                                            SqlHelper.FillDataset(ConfigurationSettings.AppSettings["SoConn"].ToString(), CommandType.Text, Query, oDataSet, new string[] { "SiteDetails" });

                                            string isDirty = Convert.ToString(oDataSet.Tables["SiteDetails"].Rows[0]["DirtyPage"]);

                                            if (isDirty.Equals("Y"))
                                            {
                                                text = text.Replace("<img class=\"dynamic\" src=\"images/SNR_facebook.png\">", ShareButton);

                                                text = text.Replace("<img class=\"dynamic\" src=\"images/SNR_recommend.png\">", RecommendButton);

                                                text = text.Replace("<img class=\"dynamic\" src=\"images/fb-like-button.png\">", LikePlugin);

                                                text = text.Replace("<img class=\"dynamic\" src=\"images/SNR_twitter.png\">", TwitterButton);
                                                text = text.Replace("<img class=\"dynamic\" src=\"images/SNR_linkedIn.png\">", LinkedInButton);

                                                if (TemplateID == 11)
                                                {
                                                    text = text.Replace("<img class=\"ActionImg\" src=\"images/email.png\">", EmailButton);
                                                    text = text.Replace("<img class=\"ActionImg\" src=\"images/print.png\">", PrintButton);
                                                }
                                            }
                                            else
                                            {
                                                text = text.Replace("<img class=\"dynamic\" src=\"images/SNR_facebook.png\" />", ShareButton);

                                                text = text.Replace("<img class=\"dynamic\" src=\"images/SNR_recommend.png\" />", RecommendButton);

                                                text = text.Replace("<img class=\"dynamic\" src=\"images/fb-like-button.png\" />", LikePlugin);

                                                text = text.Replace("<img class=\"dynamic\" src=\"images/SNR_twitter.png\" />", TwitterButton);
                                                text = text.Replace("<img class=\"dynamic\" src=\"images/SNR_linkedIn.png\" />", LinkedInButton);
                                                if (TemplateID == 11)
                                                {
                                                    text = text.Replace("<img class=\"ActionImg\" src=\"Images/email.png\">", EmailButton);
                                                    text = text.Replace("<img class=\"ActionImg\" src=\"Images/print.png\">", PrintButton);
                                                }
                                            }

                                            //fix all Image tags
                                            string imagesReplaced = text.Replace("images", "images1/" + SiteID);

                                            String style;

                                            if (TemplateID == 12)
                                            {
                                                style = "/CSS/RStore_style.css";
                                                SessionData.PrefData.TemplateID1 = TemplateID;
                                            }
                                            else if (TemplateID == 13)
                                            {
                                                style = "/CSS/FabrikStyle.css";
                                                popupContact.Visible = false;
                                                SessionData.PrefData.TemplateID1 = TemplateID;
                                            }
                                            else if (TemplateID == 11)
                                            {
                                                style = "/CSS/CouponsStyle.css";
                                                popupContact.Visible = false;
                                                SessionData.PrefData.TemplateID1 = TemplateID;
                                            }
                                            else if (TemplateID == 14)
                                            {
                                                style = "/css/realestate_styles.css";
                                                SessionData.PrefData.TemplateID1 = TemplateID;

                                            }
                                            else if (TemplateID == 16)
                                            {
                                                style = "/CSS/Restaurantstyle.css";
                                                SessionData.PrefData.TemplateID1 = TemplateID;

                                            }
                                            else if (TemplateID == 17)
                                            {
                                                style = "/CSS/Educationalstyle.css";
                                                SessionData.PrefData.TemplateID1 = TemplateID;

                                            }

                                            else
                                            {
                                                style = "/css/PFstyle.css";
                                                SessionData.PrefData.TemplateID1 = TemplateID;

                                            }


                                            //get all the Images, Styles in 
                                            System.IO.StreamReader StreamReader1 =
new System.IO.StreamReader(Server.MapPath("./Sites/Final/" + SiteID + style));
                                            string ReadStyle = StreamReader1.ReadToEnd();
                                            StreamReader1.Close();

                                            if (TemplateID == 14)
                                            {
                                                HtmlLink linking = Page.FindControl("facebookIDStyleSheet") as HtmlLink;
                                                linking.Href = "./Sites/Final/" + SiteID + style;
                                            }

                                            System.IO.StreamReader StreamReader2 =
new System.IO.StreamReader(Server.MapPath("./ScriptsSonetReach/Facebookstyles.css"));
                                            string CleanStyle = StreamReader2.ReadToEnd();
                                            CleanStyle = string.Empty;
                                            StreamReader2.Close();

                                            System.IO.StreamWriter StreamWriter2 =
                            new System.IO.StreamWriter(Server.MapPath("./ScriptsSonetReach/Facebookstyles.css"));
                                            StreamWriter2.WriteLine(CleanStyle);
                                            StreamWriter2.Close();

                                            System.IO.StreamWriter StreamWriter1 =
                            new System.IO.StreamWriter(Server.MapPath("./ScriptsSonetReach/Facebookstyles.css"));
                                            StreamWriter1.WriteLine(ReadStyle);
                                            StreamWriter1.Close();

                                            ////saranya

                                            //System.IO.StreamReader sr = new System.IO.StreamReader(Server.MapPath("./ScriptsSonetReach/Facebookstyles.css"));
                                            //String fileContents = sr.ReadToEnd();
                                            //sr.Close();

                                            //System.IO.StreamWriter sw = new System.IO.StreamWriter(Server.MapPath("./ScriptsSonetReach/Facebookstyles.css"));
                                            //fileContents = fileContents.Replace("images", "images1/" + SiteID + "");
                                            //sw.WriteLine(fileContents);
                                            //sw.Close();


                                            ///NOW process all the images
                                            string imagePath = Server.MapPath("./Sites/Final/" + SiteID + "/Images/");
                                            string[] files = System.IO.Directory.GetFiles(imagePath);


                                            if (!Directory.Exists(Server.MapPath("./Images1/" + SiteID)))
                                            {
                                                Directory.CreateDirectory(Server.MapPath("./Images1/" + SiteID));
                                            }

                                            foreach (string file in files)
                                            {
                                                if (!System.IO.File.Exists(Server.MapPath("./Images1/" + SiteID + "/" + System.IO.Path.GetFileName(file))))
                                                {
                                                    System.IO.File.Copy(file, System.IO.Path.Combine(Server.MapPath("./Images1/" + SiteID), System.IO.Path.GetFileName(file)));
                                                }
                                            }
                                            LoadComplete = true;


                                            litAppHTML.Text = imagesReplaced;

                                            if (TemplateID == 13)
                                            {
                                                litAppHTML.Text = litAppHTML.Text.Replace("<link href=\"CSS/FabrikStyle.css\" rel=\"stylesheet\" type=\"text/css\">", "");
                                            }
                                            else if (TemplateID == 11)
                                            {
                                                litAppHTML.Text = litAppHTML.Text.Replace("<link href=\"CSS/CouponsStyle.css\" rel=\"stylesheet\" type=\"text/css\" />", "");
                                            }
                                            backgroundPopup.Visible = false;
                                        }
                                    }
                                    else if (ofbBiz.IsSweepstakesAppModel(QSVars["ADID"].ToString()) == "SWEEPSTAKES") // Check if Sweepstake CampaignType
                                    {
                                        if (ofbBiz.IsSweepstakesWinnerDay(QSVars["ADID"].ToString()))// Check if Sweepstake Date is today, redirect to Show Winners
                                        {
                                            Response.Redirect("SweepstakesWinners.aspx?ADID=" + Convert.ToString(QSVars["ADID"]), false);
                                        }
                                        else
                                        {
                                            string Enddate = ofbBiz.GetSweepstakesEndDate(QSVars["ADID"].ToString());
                                            if (!string.IsNullOrEmpty(Enddate))
                                            {
                                                DateTime sd = DateTime.Parse(Enddate);
                                                Enddate = sd.ToString("dd/M/yyyy");
                                            }
                                            //litAppHTML.Text = "Sweepstakes Contest is over. Results will be shown on ...";
                                            apppathLink.InnerText = "Sweepstakes Contest is over. Winners will be announced on " + Enddate;
                                            popupContact.Style.Add("margin-left", "250px");
                                        }

                                    }
                                    else
                                    {
                                        AppExpired.Visible = true;
                                        litAppHTML.Text = "";
                                        popupContact.Visible = false;
                                    }
                                }
                            }
                        }
                        else
                        {
                            if (!ofbBiz.IsConfigurationExpired(QSVars["ADID"].ToString()))
                            {
                                //populate the AppProduct encapsulation based on app that is loaded
                                AppProduct oAppProduct = new AppProduct();
                                FaceBook facebook = new FaceBook();
                                //Get Custom Tab name
                                string CustTabNAme = fbBizProc.GetCustomTabName(Session["AppID"].ToString());
                                string CommentBox = GetCommentPlugin(oAppProduct.DID, oAppProduct.ProductName, oAppProduct.ProductLogo, oAppProduct.ProductShortDesc, QSVars["app_id"].ToString(), fbBizProc.GetAppPagePath(Convert.ToString(QSVars["app_id"])));
                                string ShareButton = GetShareButton(oAppProduct.DID, oAppProduct.ProductName, oAppProduct.ProductLogo, oAppProduct.ProductShortDesc, QSVars["app_id"].ToString(), CustTabNAme);
                                string InviteButton = GetInviteButton(oAppProduct.DID, oAppProduct.ProductName, oAppProduct.ProductLogo, oAppProduct.ProductShortDesc, QSVars["app_id"].ToString());
                                string RecommendButton = GetRecommendButton(oAppProduct.DID, oAppProduct.ProductName, oAppProduct.ProductLogo, oAppProduct.ProductShortDesc, QSVars["app_id"].ToString());
                                string LikePlugin = GetLikePlugin(oAppProduct.DID, oAppProduct.ProductName, oAppProduct.ProductLogo, oAppProduct.ProductShortDesc, QSVars["app_id"].ToString());
                                string EntryFormPlug = GetEntryForm(oAppProduct.DID, oAppProduct.ProductName, oAppProduct.ProductLogo, oAppProduct.ProductShortDesc, QSVars["ADID"].ToString(), QSVars["user_id"].ToString());
                                string LeadPlugin = GetLeadButton(oAppProduct.DID, oAppProduct.ProductName, oAppProduct.ProductLogo, oAppProduct.ProductShortDesc, QSVars["app_id"].ToString());
                                string PrintButton = GetPrint(oAppProduct.DID, oAppProduct.ProductName, oAppProduct.ProductLogo, oAppProduct.ProductShortDesc, QSVars["app_id"].ToString());
                                string EmailButton = GetEmail(oAppProduct.DID, oAppProduct.ProductName, oAppProduct.ProductLogo, oAppProduct.ProductShortDesc, QSVars["app_id"].ToString());
                                string TwitterButton = GetTwitterShareURL(oAppProduct.DID, oAppProduct.ProductName, oAppProduct.ProductLogo, oAppProduct.ProductShortDesc, QSVars["app_id"].ToString());
                                string LinkedInButton = "<script src=\"//platform.linkedin.com/in.js\" type=\"text/javascript\"></script><script type=\"IN/Share\" data-counter=\"right\" data-url=\"" + ofbBiz.GetAppPath(Convert.ToString(Request.QueryString["app_id"])) + "\"  data-onSuccess=\"LIShare\"></script><script type=\"text/javascript\">            function LIShare() { AsycRequest('" + GetNavigationURL(NotifyURL + "FBNotify.aspx?NTYP=LISHARE&PDID=" + oAppProduct.DID + "&NDID=" + _sNotifierDID, true) + "');  }</script>";
                                oAppProduct = ofbBiz.GetActiveAppProduct(osonetpie, QSVars["ADID"].ToString());
                                if (!oAppProduct.ProductCategory.Equals("WebHutColl."))
                                {

                                    litHeadBannerCount.Text = GetHeadBannerURL(oAppProduct.DID);
                                    // Get the HTML to be shown

                                    string HTML = oAppProduct.ProductHTML;

                                    //Get Share Button for this Product

                                    if (oAppProduct.CommentsWidgetAdded.Equals(TRUE))
                                    {
                                        addCOMMENT = HTML.Replace("CommBox", CommentBox);
                                    }
                                    else
                                    {
                                        addCOMMENT = HTML.Replace("CommBox", "");
                                    }

                                    if (oAppProduct.ShareWidgetAdded.Equals(TRUE))
                                    {
                                        addSHARE = addCOMMENT.Replace("ShButton", ShareButton);
                                    }
                                    else
                                    {
                                        addSHARE = addCOMMENT.Replace("ShButton", "");
                                    }
                                    if (oAppProduct.TwitterWidgetAdded.Equals(TRUE))
                                    {
                                        addTwitter = addSHARE.Replace("TwButton", TwitterButton);
                                    }
                                    else
                                    {
                                        addTwitter = addSHARE.Replace("TwButton", string.Empty);
                                    }


                                    if (ocanvBiz.IsConfigForSweepstakes(oAppProduct.AppConfigDID))
                                    {
                                        if (oAppProduct.ReccWidgetAdded.Equals(TRUE))
                                        {
                                            addPOST = addTwitter.Replace("ReButton", InviteButton);
                                        }
                                        else
                                        {
                                            addPOST = addTwitter.Replace("ReButton", "");
                                        }
                                        //if HTML contains LIKE
                                        addEntry = addPOST.Replace("Entry", EntryFormPlug);

                                        if (string.IsNullOrEmpty(oAppProduct.AppCaption))
                                        {
                                            addCaption = addEntry.Replace("Caption", "");
                                        }
                                        else
                                        {
                                            addCaption = addEntry.Replace("Caption", oAppProduct.AppCaption);
                                        }

                                        if (oAppProduct.InquiryWidgetAdded.Equals(TRUE))
                                        {
                                            addLead = addCaption.Replace("Lead", LeadPlugin);
                                        }
                                        else
                                        {
                                            addLead = addCaption.Replace("Lead", "");
                                        }

                                        if (oAppProduct.LikeWidgetAdded.Equals(TRUE))
                                        {
                                            addLIKE = addLead.Replace("Like", LikePlugin);
                                        }
                                        else
                                        {
                                            addLIKE = addLead.Replace("Like", "");
                                        }

                                        litAppHTML.Text = addLIKE;
                                        hdnStatus.Value = "HIDE";
                                        apppathLink.Visible = false;
                                    }
                                    else
                                    {

                                        if (oAppProduct.ReccWidgetAdded.Equals(TRUE))
                                        {
                                            addPOST = addTwitter.Replace("ReButton", RecommendButton);
                                        }
                                        else
                                        {
                                            addPOST = addTwitter.Replace("ReButton", "");
                                        }

                                        if (oAppProduct.LikeWidgetAdded.Equals(TRUE))
                                        {
                                            addLIKE = addPOST.Replace("Like", LikePlugin);
                                        }
                                        else
                                        {
                                            addLIKE = addPOST.Replace("Like", "");
                                        }

                                        //if HTML contains LIKE
                                        addEntry = addLIKE.Replace("Entry", EntryFormPlug);

                                        if (oAppProduct.InquiryWidgetAdded.Equals(TRUE))
                                        {
                                            addLead = addEntry.Replace("Lead", LeadPlugin);
                                        }
                                        else
                                        {
                                            addLead = addEntry.Replace("Lead", "");
                                        }

                                        if (string.IsNullOrEmpty(oAppProduct.AppCaption))
                                        {
                                            addCaption = addLead.Replace("Caption", "");
                                        }
                                        else
                                        {
                                            addCaption = addLead.Replace("Caption", oAppProduct.AppCaption);
                                        }
                                        string addPrint = addCaption.Replace("Print", PrintButton);
                                        string addEmail = addPrint.Replace("Email", EmailButton);
                                        addTwitter = addEmail.Replace("TwButton", TwitterButton);
                                        litAppHTML.Text = addEmail;
                                        hdnStatus.Value = "HIDE";
                                        apppathLink.Visible = false;
                                    }
                                }
                                else
                                {

                                    pageToLoad = "index.html";

                                    SiteID = fbBizProc.GetSiteIDForConfig(Convert.ToString(QSVars["ADID"]));
                                    SessionData.Config = new AppConfiguration();
                                    SessionData.Config.SSiteID = SiteID;
                                    TemplateID = fbBizProc.GetTemplateIDForConfig(Convert.ToString(QSVars["ADID"]));

                                    hdnPageToLoad.Value = pageToLoad;
                                    StreamReader streamReader = new StreamReader(Server.MapPath("Sites\\Final\\" + SiteID + "\\" + pageToLoad));
                                    string text = streamReader.ReadToEnd();
                                    streamReader.Close();


                                    //check for DirtyPage
                                    string Query = "select DirtyPage from Sites where SiteId=" + SiteID;
                                    DataSet oDataSet = new DataSet();
                                    SqlHelper.FillDataset(ConfigurationSettings.AppSettings["SoConn"].ToString(), CommandType.Text, Query, oDataSet, new string[] { "SiteDetails" });

                                    string isDirty = Convert.ToString(oDataSet.Tables["SiteDetails"].Rows[0]["DirtyPage"]);

                                    if (isDirty.Equals("Y"))
                                    {
                                        text = text.Replace("<img class=\"dynamic\" src=\"images/SNR_facebook.png\">", ShareButton);

                                        text = text.Replace("<img class=\"dynamic\" src=\"images/SNR_recommend.png\">", RecommendButton);

                                        text = text.Replace("<img class=\"dynamic\" src=\"images/fb-like-button.png\">", LikePlugin);

                                        text = text.Replace("<img class=\"dynamic\" src=\"images/SNR_twitter.png\">", TwitterButton);
                                        text = text.Replace("<img class=\"dynamic\" src=\"images/SNR_linkedIn.png\">", LinkedInButton);
                                        if (TemplateID == 11)
                                        {
                                            text = text.Replace("<img class=\"ActionImg\" src=\"images/email.png\">", EmailButton);
                                            text = text.Replace("<img class=\"ActionImg\" src=\"images/email.png\">", PrintButton);
                                        }
                                    }
                                    else
                                    {
                                        text = text.Replace("<img class=\"dynamic\" src=\"images/SNR_facebook.png\" />", ShareButton);

                                        text = text.Replace("<img class=\"dynamic\" src=\"images/SNR_recommend.png\" />", RecommendButton);

                                        text = text.Replace("<img class=\"dynamic\" src=\"images/fb-like-button.png\" />", LikePlugin);

                                        text = text.Replace("<img class=\"dynamic\" src=\"images/SNR_twitter.png\" />", TwitterButton);
                                        text = text.Replace("<img class=\"dynamic\" src=\"images/SNR_linkedIn.png\">", LinkedInButton);
                                        if (TemplateID == 11)
                                        {
                                            text = text.Replace("<img class=\"ActionImg\" src=\"images/email.png\">", EmailButton);
                                            text = text.Replace("<img class=\"ActionImg\" src=\"images/email.png\">", PrintButton);
                                        }
                                    }

                                    //fix all Image tags
                                    string imagesReplaced = text.Replace("images", "images1/" + SiteID);

                                    String style;

                                    if (TemplateID == 12)
                                    {
                                        style = "/CSS/RStore_style.css";

                                    }
                                    else if (TemplateID == 13)
                                    {
                                        style = "/CSS/FabrikStyle.css";
                                        popupContact.Visible = false;
                                    }
                                    else if (TemplateID == 11)
                                    {
                                        style = "/CSS/CouponsStyle.css";
                                        popupContact.Visible = false;
                                    }
                                    else if (TemplateID == 16)
                                    {
                                        style = "/CSS/Restaurantstyle.css";
                                        SessionData.PrefData.TemplateID1 = TemplateID;

                                    }

                                    else if (TemplateID == 17)
                                    {
                                        style = "/CSS/Educationalstyle.css";
                                        SessionData.PrefData.TemplateID1 = TemplateID;

                                    }
                                    else
                                    {
                                        style = "/CSS/realestate_styles.css";

                                    }

                                    //get all the Images, Styles in 
                                    System.IO.StreamReader StreamReader1 =
new System.IO.StreamReader(Server.MapPath("./Sites/Final/" + SiteID + style));
                                    string ReadStyle = StreamReader1.ReadToEnd();
                                    StreamReader1.Close();

                                    if (TemplateID == 14)
                                    {

                                        HtmlLink linking = Page.FindControl("facebookIDStyleSheet") as HtmlLink;
                                        linking.Href = "./Sites/Final/" + SiteID + style;

                                    }

                                    System.IO.StreamReader StreamReader2 =
new System.IO.StreamReader(Server.MapPath("./ScriptsSonetReach/Facebookstyles.css"));
                                    string CleanStyle = StreamReader2.ReadToEnd();
                                    CleanStyle = string.Empty;
                                    StreamReader2.Close();

                                    System.IO.StreamWriter StreamWriter2 =
                    new System.IO.StreamWriter(Server.MapPath("./ScriptsSonetReach/Facebookstyles.css"));
                                    StreamWriter2.WriteLine(CleanStyle);
                                    StreamWriter2.Close();

                                    System.IO.StreamWriter StreamWriter1 =
                    new System.IO.StreamWriter(Server.MapPath("./ScriptsSonetReach/Facebookstyles.css"));
                                    StreamWriter1.WriteLine(ReadStyle);
                                    StreamWriter1.Close();

                                    //saranya

                                    System.IO.StreamReader sr = new System.IO.StreamReader(Server.MapPath("./ScriptsSonetReach/Facebookstyles.css"));
                                    String fileContents = sr.ReadToEnd();
                                    sr.Close();

                                    System.IO.StreamWriter sw = new System.IO.StreamWriter(Server.MapPath("./ScriptsSonetReach/Facebookstyles.css"));
                                    fileContents = fileContents.Replace("images", "images1/" + SiteID + "");
                                    sw.WriteLine(fileContents);
                                    sw.Close();


                                    ///NOW process all the images
                                    string imagePath = Server.MapPath("./Sites/Final/" + SiteID + "/Images/");
                                    string[] files = System.IO.Directory.GetFiles(imagePath);


                                    if (!Directory.Exists(Server.MapPath("./Images1/" + SiteID)))
                                    {
                                        Directory.CreateDirectory(Server.MapPath("./Images1/" + SiteID));
                                    }

                                    foreach (string file in files)
                                    {
                                        if (!System.IO.File.Exists(Server.MapPath("./Images1/" + SiteID + "/" + System.IO.Path.GetFileName(file))))
                                        {
                                            System.IO.File.Copy(file, System.IO.Path.Combine(Server.MapPath("./Images1/" + SiteID), System.IO.Path.GetFileName(file)));
                                        }
                                    }
                                    LoadComplete = true;


                                    litAppHTML.Text = imagesReplaced;


                                    litAppHTML.Text = litAppHTML.Text.Replace("<link href=\"CSS/FabrikStyle.css\" rel=\"stylesheet\" type=\"text/css\">", "");
                                    //litAppHTML.Text = litAppHTML.Text.Replace("<link href=\"css/realestate_styles.css\" rel=\"stylesheet\" type=\"text/css\">", "");

                                    backgroundPopup.Visible = false;
                                }
                            }
                            else if (ofbBiz.IsSweepstakesAppModel(QSVars["ADID"].ToString()) == "SWEEPSTAKES") // Check if Sweepstake CampaignType
                            {
                                if (ofbBiz.IsSweepstakesWinnerDay(QSVars["ADID"].ToString()))// Check if Sweepstake Date is today, redirect to Show Winners
                                {
                                    Response.Redirect("SweepstakesWinners.aspx?ADID=" + Convert.ToString(QSVars["ADID"]), false);
                                }
                                else
                                {
                                    string Enddate = ofbBiz.GetSweepstakesEndDate(QSVars["ADID"].ToString());
                                    if (!string.IsNullOrEmpty(Enddate))
                                    {
                                        DateTime sd = DateTime.Parse(Enddate);
                                        Enddate = sd.ToString("dd/M/yyyy");
                                    }
                                    //litAppHTML.Text = "Sweepstakes Contest is over. Results will be shown on ...";
                                    apppathLink.InnerText = "Sweepstakes Contest is over. Winners will be announced on " + Enddate;
                                    popupContact.Style.Add("margin-left", "250px");
                                }

                            }
                            else
                            {
                                AppExpired.Visible = true;
                                litAppHTML.Text = "";
                                popupContact.Visible = false;
                            }
                        }
                    }
                    else
                    {
                        oDCAppUser.AppConfigDID = Session["ADID"].ToString();
                        hdnAppConfigD.Value = oDCAppUser.AppConfigDID;
                        oDCAppUser.SonetID = Session["UserID"].ToString();
                        hdnUserID.Value = oDCAppUser.SonetID;
                        hdnAppID.Value = Session["AppID"].ToString();
                        Session["UserID"] = hdnUserID.Value;
                        Session["AppID"] = hdnAppID.Value;
                        oDCAppUser = ofbBiz.GetAppUser(osonetpie, Session["ADID"].ToString(), Session["UserID"].ToString());
                        //populate the AppProduct encapsulation based on app that is loaded
                        AppProduct oAppProduct = new AppProduct();
                        FaceBook facebook = new FaceBook();

                        oAppProduct = ofbBiz.GetActiveAppProduct(osonetpie, Session["ADID"].ToString());
                        litHeadBannerCount.Text = GetHeadBannerURL(oAppProduct.DID);
                        // Get the HTML to be shown


                        string HTML = oAppProduct.ProductHTML;
                        // Fill up Config and Custome
                        //Get Custom Tab name
                        string CustTabNAme = fbBizProc.GetCustomTabName(Session["AppID"].ToString());
                        //Get Share Button for this Product

                        string CommentBox = GetCommentPlugin(oAppProduct.DID, oAppProduct.ProductName, oAppProduct.ProductLogo, oAppProduct.ProductShortDesc, QSVars["app_id"].ToString(), fbBizProc.GetAppPagePath(Convert.ToString(QSVars["app_id"])));
                        string ShareButton = GetShareButton(oAppProduct.DID, oAppProduct.ProductName, oAppProduct.ProductLogo, oAppProduct.ProductShortDesc, Session["AppID"].ToString(), CustTabNAme);
                        string InviteButton = GetInviteButton(oAppProduct.DID, oAppProduct.ProductName, oAppProduct.ProductLogo, oAppProduct.ProductShortDesc, Session["AppID"].ToString());
                        string RecommendButton = GetRecommendButton(oAppProduct.DID, oAppProduct.ProductName, oAppProduct.ProductLogo, oAppProduct.ProductShortDesc, Session["AppID"].ToString());
                        string LikePlugin = GetLikePlugin(oAppProduct.DID, oAppProduct.ProductName, oAppProduct.ProductLogo, oAppProduct.ProductShortDesc, Session["AppID"].ToString());
                        string EntryFormPlug = GetEntryForm(oAppProduct.DID, oAppProduct.ProductName, oAppProduct.ProductLogo, oAppProduct.ProductShortDesc, Session["ADID"].ToString(), Session["UserID"].ToString().ToString());
                        string LeadPlugin = GetLeadButton(oAppProduct.DID, oAppProduct.ProductName, oAppProduct.ProductLogo, oAppProduct.ProductShortDesc, QSVars["app_id"].ToString());
                        string TwitterButton = GetTwitterShareURL(oAppProduct.DID, oAppProduct.ProductName, oAppProduct.ProductLogo, oAppProduct.ProductShortDesc, QSVars["app_id"].ToString());
                        //if HTML contains SHARE and Widgets are present

                        if (oAppProduct.CommentsWidgetAdded.Equals(TRUE))
                        {
                            addCOMMENT = HTML.Replace("CommBox", CommentBox);
                        }
                        else
                        {
                            addCOMMENT = HTML.Replace("CommBox", "");
                        }

                        if (oAppProduct.ShareWidgetAdded.Equals(TRUE))
                        {
                            addSHARE = addCOMMENT.Replace("ShButton", ShareButton);
                        }
                        else
                        {
                            addSHARE = addCOMMENT.Replace("ShButton", "");
                        }
                        if (oAppProduct.TwitterWidgetAdded.Equals(TRUE))
                        {
                            addTwitter = addSHARE.Replace("TwButton", TwitterButton);
                        }
                        else
                        {
                            addTwitter = addSHARE.Replace("TwButton", string.Empty);
                        }


                        if (ocanvBiz.IsConfigForSweepstakes(oAppProduct.AppConfigDID))
                        {
                            if (oAppProduct.ReccWidgetAdded.Equals(TRUE))
                            {
                                addPOST = addTwitter.Replace("ReButton", InviteButton);
                            }
                            else
                            {
                                addPOST = addTwitter.Replace("ReButton", "");
                            }
                            //if HTML contains LIKE
                            addEntry = addPOST.Replace("Like", EntryFormPlug);

                            litAppHTML.Text = addEntry;
                            hdnStatus.Value = "HIDE";
                            apppathLink.Visible = false;
                        }
                        else
                        {

                            if (oAppProduct.ReccWidgetAdded.Equals(TRUE))
                            {
                                addPOST = addTwitter.Replace("ReButton", InviteButton);
                            }
                            else
                            {
                                addPOST = addTwitter.Replace("ReButton", "");
                            }

                            if (oAppProduct.LikeWidgetAdded.Equals(TRUE))
                            {
                                addLIKE = addPOST.Replace("Like", LikePlugin);
                            }
                            else
                            {
                                addLIKE = addPOST.Replace("Like", "");
                            }

                            if (oAppProduct.InquiryWidgetAdded.Equals(TRUE))
                            {
                                addLead = addLIKE.Replace("Lead", LeadPlugin);
                            }
                            else
                            {
                                addLead = addLIKE.Replace("Lead", "");
                            }
                            litAppHTML.Text = addLead;
                            hdnStatus.Value = "HIDE";
                            apppathLink.Visible = false;
                        }
                    }
                }
                else if (Request.QueryString.AllKeys.Contains("request_ids"))
                {
                    apppathLink.HRef = fbBizProc.GetAppPagePath(Convert.ToString(QSVars["app_id"]));
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "myCloseScript", "window.parent.location.href='" + apppathLink.HRef.ToString() + "'", true);
                }
                else
                {
                    //Nothing to load , show error screen
                    if (QSVars["app_id"] == null)
                    {
                        Server.Transfer("Error.aspx");
                    }
                    else
                    {
                        apppathLink.HRef = fbBizProc.GetAppPagePath(Convert.ToString(QSVars["app_id"]));
                        if (QSVars.Contains("soNETSrc"))
                        {
                            if (!(Convert.ToString(QSVars["soNETSrc"].ToString()).Equals("NULL")))
                            {
                                Page.ClientScript.RegisterStartupScript(this.GetType(), "myCloseScript", "window.parent.close();", true);
                            }
                            else
                            {
                                Page.ClientScript.RegisterStartupScript(this.GetType(), "myCloseScript", "window.parent.location.href='" + apppathLink.HRef.ToString() + "'", true);
                            }
                        }
                    }

                    if (Request.Url.Query.Contains("fb_source"))
                    {
                        Page.ClientScript.RegisterStartupScript(this.GetType(), "myCloseScript", "window.parent.location.href='" + apppathLink.HRef.ToString() + "'", true);
                    }
                }


                //saranya
                if (Request.QueryString.AllKeys.Contains("request_ids"))
                {
                    apppathLink.HRef = fbBizProc.GetAppPagePath(Convert.ToString(QSVars["app_id"]));
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "myCloseScript", "window.parent.location.href='" + apppathLink.HRef.ToString() + "'", true);
                }
            }
            catch (Exception ex)
            {
                CommonUtility commUtil = new CommonUtility();
                commUtil.SendErrorMail(ex.Message, ex.StackTrace, System.Reflection.MethodBase.GetCurrentMethod().Name.ToString(), System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.ToString(), SessionData.Customer.CustomerID);
            }
        }



        protected override void OnLoad(EventArgs e)
        {
            try
            {
                //do nothing here

            }

                //now using graph, get user info and redirect to pageURL

            catch (Exception ex)
            {
                throw ex;
            }
        }

        private string GetAppRequestButton(string sProductID, string sProductName, string sProductLogo, string sProductDescitpion, string AppID)
        {
            string _sAppPathLink = ofbBiz.GetAppPagePath(AppID);
            string customLogoLocation = ofbBiz.GetCustomLogo(sProductID);
            string logoLocation = "https://www.sonetreach.com/Images/sonet_watermark.png";
            string _sNotifierDID = new AppNotifier().GetNewDIDWithPrefix();
            if (!_sAppPathLink.EndsWith("?")) _sAppPathLink += "&";
            //Build NotifierDID & pass it to link
            _sAppPathLink += "NDID=" + _sNotifierDID;

            StringBuilder oSBShareButton = new StringBuilder();
            oSBShareButton.Append("<a class=\"FB_Recommend\" href=\"#\" onclick=\"javascript:" + sProductID + "AppReq(); return false;\"></a>" + Environment.NewLine);
            oSBShareButton.Append("<div id=\"fb-root\"></div>");
            oSBShareButton.Append("<script src=\"http://connect.facebook.net/en_US/all.js\"></script>");
            oSBShareButton.Append("<script type=\"text/javascript\">" + Environment.NewLine);
            oSBShareButton.Append("function " + sProductID + "AppReq() {" + Environment.NewLine);
            oSBShareButton.Append("FB.init({");
            oSBShareButton.Append("appId  : '" + AppID + "',");
            oSBShareButton.Append("status : true,");
            oSBShareButton.Append("cookie : true,");
            oSBShareButton.Append("oauth: true");
            oSBShareButton.Append("});");
            oSBShareButton.Append("FB.ui({method: 'apprequests',");
            oSBShareButton.Append("message: 'My Great Request' ,");
            oSBShareButton.Append("link: '" + _sAppPathLink + "'");
            oSBShareButton.Append("},");
            oSBShareButton.Append("function requestCallback(response) {");

            oSBShareButton.Append("var myStringArray = response.to;");
            oSBShareButton.Append("for (var i = 0; i < myStringArray.length; i++) {");
            //oSBShareButton.Append("alert(myStringArray[i]);");//Works perfect
            oSBShareButton.Append("document.getElementById('hiddenReqUSersLit').value=myStringArray[i];");
            oSBShareButton.Append("document.cookie=document.getElementById('hiddenReqUSersLit').value;");
            oSBShareButton.Append("AsycRequest('" + GetNavigationURL(NotifyURL + "FBNotify.aspx?NTYP=APPREQ&PDID=" + sProductID + "&NDID=" + _sNotifierDID, true) + "');" + Environment.NewLine);
            oSBShareButton.Append("}");


            oSBShareButton.Append("});" + Environment.NewLine);
            oSBShareButton.Append("}" + Environment.NewLine);
            oSBShareButton.Append("</script>" + Environment.NewLine);

            return oSBShareButton.ToString();
        }







    }


}