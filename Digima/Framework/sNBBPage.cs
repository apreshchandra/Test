using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.IO;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DigiMa.Common;
using System.Collections;
using System.Text;
using System.Collections.Specialized;
using DigiMa.BizProcess;
using DigiMa.Data;
using System.Data;
using System.Runtime;
using Newtonsoft;
using Newtonsoft.Json.Linq;
using System.Configuration;
using System.Web.UI.HtmlControls;

namespace DigiMa
{
    public class sNBBPage : Page
    {
        string AppID = string.Empty;
        string PageNAme = string.Empty;
        string page_access_token = string.Empty;
        FacebookBizProcess ofbBiz = new FacebookBizProcess();
        AppWallPost _oDCAppWallPost = new AppWallPost();
        SonetPie osonetpie = new SonetPie();
        FaceBook facebook = new FaceBook();
        static bool pageRefreshed;
        private string NotifyURL;

        //TODO : MAke sure we remove the port 8000 while building URL when soNet is hosted.
        #region Properties/Attributes

        public static int flagCount { get; set; }

        private AppConfiguration _oDCAppConfiguration;
        public AppConfiguration AppConfig
        {
            get { return _oDCAppConfiguration; }
        }

        private AppUser _oDCAppUser;
        public AppUser AppUser
        {
            get { return _oDCAppUser; }
        }

        private AppCustomer _oDCAppCustomer;
        public AppCustomer AppCustomer
        {
            get { return _oDCAppCustomer; }
        }

        private Boolean _bHasAuthorization = true;
        public Boolean HasAuthorization
        {
            get { return _bHasAuthorization; }
            set { _bHasAuthorization = value; }
        }

        private Boolean _bEnableAppUser = false;
        public Boolean EnableAppUser
        {
            get { return _bEnableAppUser; }
            set { _bEnableAppUser = value; }
        }

        private Boolean _bEnableAppServices = true;
        public Boolean EnableAppServices
        {
            get { return _bEnableAppServices; }
            set { _bEnableAppServices = value; }
        }

        private Boolean _bHideBranding = false;
        public Boolean HideBranding
        {
            get { return _bHideBranding; }
            set { _bHideBranding = value; }
        }

        private string _sAbsolutePagePath;
        public string AbsolutePagePath
        {
            get { return _sAbsolutePagePath; }
        }

        private Hashtable _qsVars = new Hashtable();
        public Hashtable QSVars
        {
            get { return _qsVars; }
        }

        private Hashtable _frmVars = new Hashtable();
        public Hashtable FormVars
        {
            get { return _frmVars; }
        }

        private List<string> _persistQSVars = new List<string>();
        public List<string> PersistQSVars
        {
            get { return _persistQSVars; }
        }
        #endregion

        #region PageEvents

        protected override void OnPreLoad(EventArgs e)
        {
            try
            {
                base.OnPreLoad(e);
                FacebookBizProcess fbBiz = new FacebookBizProcess();
                FaceBook oFBUtility = new FaceBook();
                SonetPieBizProcess sonetpiebiz = new SonetPieBizProcess();
                SonetPie sonetpie = new SonetPie();
                NotifyURL = ConfigurationSettings.AppSettings["NotifyURL"];
                pageRefreshed = false;

                if (QSVars.Contains("user_id"))
                {
                    Session["facebook_user_id"] = QSVars["user_id"].ToString();
                }
                if (QSVars.Contains("UDID"))
                {
                    Session["sr_user_did"] = QSVars["UDID"].ToString();
                }
                if (QSVars.Contains("PDID"))
                {
                    Session["sr_product_did"] = QSVars["PDID"].ToString();
                }

                if (Request.Url.Query.Contains("request") && !(Request.Url.Query.Contains("fb_source"))) //AppRequest callback, now save to notifiers
                {

                    for (int i = 0; i < Request.QueryString.Count - 2; i++)
                    {
                        //every Request["to[i]"] has a userID for AppNotifier
                        string fbUID = Request["to[" + i + "]"].ToString();
                        string _sNotifierDID = new AppNotifier().GetNewDIDWithPrefix();
                        string facebook_user_id = Convert.ToString(Session["facebook_user_id"]);
                        string UDID = Convert.ToString(Session["sr_user_did"]);
                        if (QSVars.Contains("NDID"))
                            QSVars["NDID"] = _sNotifierDID;
                        else
                            QSVars.Add("NDID", _sNotifierDID);

                        //Build DCAppWallPost for each user

                        AppUser oDCAppUser = new AppUser();
                        string ConfigDID = fbBiz.GetConfigDEED(Convert.ToString(QSVars["app_id"]));
                        if (!QSVars.Contains("ADID"))
                        {
                            QSVars.Add("ADID", ConfigDID);
                        }
                        if (!QSVars.Contains("PDID"))
                        {
                            QSVars.Add("PDID", Convert.ToString(Session["sr_product_did"]));
                        }
                        oDCAppUser = ofbBiz.GetAppUser(osonetpie, QSVars["ADID"].ToString(), facebook_user_id);

                        _oDCAppWallPost.FromUserID = Convert.ToString(QSVars["user_id"]);
                        _oDCAppWallPost.ToUserID = fbUID;
                        _oDCAppWallPost.Name = ofbBiz.GetCustomTabName(QSVars["app_id"].ToString());
                        _oDCAppWallPost.Source = Convert.ToString(QSVars["user_id"]);
                        AppLeadData oAppLead = new AppLeadData();

                        if (Request.Browser.IsMobileDevice == true || Request.UserAgent.ToLower().Contains("iphone") || Request.UserAgent.ToLower().Contains("android"))
                        {
                            if (fbBiz.RaiseAppNotifier(oDCAppUser, "MPOST", UDID, Convert.ToString(QSVars["PDID"]), "", fbUID))
                            {

                            }
                        }
                        else
                        {
                            if (fbBiz.RaiseAppNotifier(oDCAppUser, "POST", UDID, Convert.ToString(QSVars["PDID"]), "", fbUID))
                            {

                            }
                        }
                    }
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "myCloseScript", "window.close();", true);
                }

                if (Request["code"] == null)
                {
                    if ((Request.QueryString.Count > 0) && !(Request["LIKED"] != null))
                    {
                        //ParseRequest & set values to qsvars
                        if (!(Request.QueryString).AllKeys[0].ToString().Contains("tabs_added"))
                        {
                            //REVISIT

                            sonetpie.QSvarsString = GetQsVarsCollection();
                            sonetpie.FormvarsString = GetFormVarsCollection();
                            sonetpie.AbsolutePath = AbsolutePagePath;

                            if (Request.Form.ToString() != string.Empty)
                            {
                                FormVars.Add("signed_request", Request.Form.Get(0).ToString());
                            }

                            //Init Biz
                            //SonetPieBizProcess sonetpiebiz = new SonetPieBizProcess();

                            if (QSVars.Contains("app_id"))
                            {

                                if (EnableAppServices) _oDCAppConfiguration = sonetpiebiz.GetAppConfiguration("", QSVars["app_id"].ToString());
                                SessionData.Config.DID = _oDCAppConfiguration.DID;
                                //DigiMa.Common.FaceBook oFBUtility1 = new DigiMa.Common.FaceBook();

                                //check AppConfig got loaded 
                                if (AppConfig != null)
                                {
                                    //Add CDID to Load customer
                                    if (QSVars.Contains("CDID"))
                                        QSVars["CDID"] = AppConfig.AppCustomerDID;
                                    else
                                        QSVars.Add("CDID", AppConfig.AppCustomerDID);

                                    //Add ADID to Load customer
                                    if (QSVars.Contains("ADID"))
                                        QSVars["ADID"] = AppConfig.DID;
                                    else
                                        QSVars.Add("ADID", AppConfig.DID);

                                    //Reset KOKO QSVars
                                    sonetpie.QSvarsString = GetQsVarsCollection();
                                    _oDCAppCustomer = fbBiz.GetAppCustomer(Convert.ToString(QSVars["CDID"]));

                                    //ParseSigned Request
                                    if ((!QSVars.Contains("oauth_token")))
                                    {
                                        oFBUtility.ParseSignedRequest(ref _qsVars, ref _frmVars, AppConfig);
                                    }

                                    if (QSVars.Contains("oauth_token"))
                                    {
                                        Session["oauth_token"] = Convert.ToString(QSVars["oauth_token"]);
                                    }

                                    if (QSVars.Contains("user_id"))
                                    {
                                        Session["user_id"] = Convert.ToString(QSVars["user_id"]);
                                    }

                                    //call graph to get page_Acc_tok
                                    if (QSVars.Contains("oauth_token") && (_oDCAppConfiguration.SAppCustomNameAdded == null || _oDCAppConfiguration.SAppCustomNameAdded == ""))
                                    {
                                        page_access_token = facebook.GetPageAccessToken(QSVars["oauth_token"].ToString());
                                        System.Web.Script.Serialization.JavaScriptSerializer _oJavaScriptSerializer = new System.Web.Script.Serialization.JavaScriptSerializer();
                                        JObject obj = JObject.Parse(page_access_token);
                                        IEnumerable<string> query = from res in (Newtonsoft.Json.Linq.JArray)obj["data"]
                                                                    let reso = res as JObject
                                                                    where ((string)reso["id"]).ToLower() == _oDCAppConfiguration.SPageID
                                                                    select (string)reso["access_token"];

                                        //fetch the logo of this Campaign from AppProduct and pass to CallPages

                                        if (facebook.CallPages(_oDCAppConfiguration.SPageID, query.ToList()[0].ToString(), "app_" + QSVars["app_id"].ToString(), _oDCAppConfiguration.SCustomtTabName, fbBiz.FetchAppLogo(QSVars["app_id"].ToString())))
                                        {
                                            //update custom_updated to Y
                                            fbBiz.UpdateCustomTabNAme(_oDCAppConfiguration.DID);
                                            ClientScript.RegisterStartupScript(this.GetType(), "scriptid", "window.parent.location.href='" + _oDCAppConfiguration.SAppPagePath + "'", true);
                                        }

                                    }

                                    //parse the JSON
                                    if (HasAuthorization)
                                    {
                                        if (!QSVars.Contains("oauth_token"))
                                        {
                                            //Set Authorization stamp on redirect url
                                            AppConfig.AppPath += "?soNETSrc=";
                                            if (QSVars.Contains("NDID"))
                                                AppConfig.AppPath += Convert.ToString(QSVars["NDID"]);
                                            else
                                                AppConfig.AppPath += "NULL";

                                            //oFBUtility.GetAccessToken(QSVars["code"].ToString(), "user_location,email,friends_location,publish_stream",AppConfig.AppPath,AppConfig);

                                            // CHeck if Request is coming from Mobile device, then open Standalone
                                            if (Request.Browser.IsMobileDevice == true || Request.UserAgent.ToLower().Contains("iphone") || Request.UserAgent.ToLower().Contains("android"))
                                            {
                                                //oFBUtility.AuthorizeMob(this, "user_location,email,friends_location,user_birthday", AppConfig);
                                            }
                                            else
                                            {
                                                oFBUtility.Authorize(this, "user_location,email,friends_location,user_birthday", AppConfig);
                                            }

                                        }
                                        else
                                        {
                                            //Insert user into DB
                                            if (true)
                                            {
                                                //Call service to store into DB
                                                AppUser oDCAppUser = new AppUser();
                                                oDCAppUser.AppConfigDID = AppConfig.DID;
                                                oDCAppUser.EmailID = "NULL";
                                                oDCAppUser.SonetID = Convert.ToString(QSVars["user_id"]);
                                                oDCAppUser.SonetSRC = Convert.ToString(QSVars["soNETSrc"]);
                                                oDCAppUser.UserStatus = "Active";
                                                oDCAppUser.SMType = "FB";
                                                oDCAppUser = oFBUtility.GetUserDetail(Convert.ToString(QSVars["user_id"]), Convert.ToString(QSVars["oauth_token"]), oDCAppUser);

                                                //Save to DB
                                                if (!fbBiz.IsUserCreatedForFacebook(oDCAppUser.SonetID, oDCAppUser.AppConfigDID))
                                                {
                                                    if (fbBiz.SetAppUserAuthorize(oDCAppUser, Convert.ToString(QSVars["ADID"]))) _oDCAppUser = oDCAppUser;
                                                }
                                            }
                                        }
                                    }
                                }

                                //refrsh to get tab name
                                //fbBiz.UpdateCustomTabNAme(_oDCAppConfiguration.DID);
                                //ClientScript.RegisterStartupScript(this.GetType(), "scriptid", "window.parent.location.href='" + _oDCAppConfiguration.SAppPagePath + "'", true);

                                //Load AppUser based on property
                                if (_bEnableAppUser && _qsVars.Contains("user_id"))
                                {
                                    sonetpie.QSvarsString = GetQsVarsCollection();
                                    _oDCAppUser = fbBiz.GetAppUser(sonetpie, Convert.ToString(QSVars["ADID"]), Convert.ToString(QSVars["user_id"]));
                                    if (_oDCAppUser != null)
                                    {
                                        if (!_qsVars.Contains("UDID")) _qsVars.Add("UDID", _oDCAppUser.DID); else _qsVars["UDID"] = _oDCAppUser.DID;
                                        if (QSVars.Count < 8)
                                        {
                                            ClientScript.RegisterStartupScript(this.GetType(), "scriptid", "window.parent.location.href='" + _oDCAppConfiguration.SAppPagePath + "'", true);//To ensure all QSVARS are loaded from facebook
                                        }
                                    }
                                }

                                //Update Notifier count based on NDID or soNETSrc
                                if (QSVars.Contains("soNETSrc") || QSVars.Contains("NDID"))
                                {
                                    AppNotifier oAppNotifier = new AppNotifier();
                                    if (QSVars.Contains("soNETSrc")) oAppNotifier.DID = Convert.ToString(QSVars["soNETSrc"]);
                                    if (QSVars.Contains("NDID")) oAppNotifier.DID = Convert.ToString(QSVars["NDID"]);
                                    if (!string.IsNullOrEmpty(oAppNotifier.DID)) fbBiz.EditAppNotifierDetails(oAppNotifier);
                                }
                            }
                        }

                    }
                    else
                    {
                        //
                    }
                }

                else
                {

                    //Here redirect user to Page path
                    if (QSVars.Contains("app_id") && QSVars.Contains("soNETSrc"))
                    {
                        //string pageToRedirect = fbBiz.GetAppPagePath(Convert.ToString(QSVars["app_id"]));
                        //Response.Redirect(pageToRedirect,true);

                    }

                }


            }
            catch (Exception ex)
            {
                CommonUtility commUtil = new CommonUtility();
                commUtil.SendErrorMail(ex.Message, ex.StackTrace, System.Reflection.MethodBase.GetCurrentMethod().Name.ToString(), System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.ToString(), SessionData.Customer.CustomerID);
            }
        }

        public string CallWebRequest(string Method, string Url, string PostData)
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

        private void Page_PreRender(object sender, System.EventArgs e)
        {
            try
            {

                if (AppConfig != null)
                {

                    //Initialize Facebook JS ScriptsSonetReach
                    Literal oLitJavaScript = new Literal();
                    Control oMainJavaScriptContent = this.Controls[0].FindControl("MainJavaScriptContent");
                    if (oMainJavaScriptContent != null) oMainJavaScriptContent.Controls.Add(oLitJavaScript);
                }
            }
            catch (Exception ex)
            {
                CommonUtility commUtil = new CommonUtility();
                commUtil.SendErrorMail(ex.Message, ex.StackTrace, System.Reflection.MethodBase.GetCurrentMethod().Name.ToString(), System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.ToString(), SessionData.Customer.CustomerID);
            }
        }

        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);

            //Format request url & set it
            _sAbsolutePagePath = Request.Url.AbsolutePath;

            //Format all incoming qsvars
            for (int iCounter = 0; iCounter < Request.QueryString.Count; iCounter++)
            {
                _qsVars.Add(Request.QueryString.GetKey(iCounter), Request.QueryString.GetValues(iCounter)[0]);
            }

            //Format all incoming formvars
            if (this.IsPostBack)
            {
                for (int iCounter = 0; iCounter < Request.Form.Count; iCounter++)
                {
                    //Request is expected to have param like "ctl00$MainBodyContent$BtnPost"
                    _frmVars.Add(Request.Form.GetKey(iCounter).Replace("ctl00$MainBodyContent$", ""), Request.Form.GetValues(iCounter)[0]);
                }
            }

            //Add persist qsvars which are must for framework
            _persistQSVars.Add("expires");
            _persistQSVars.Add("issued_at");
            _persistQSVars.Add("user");
            _persistQSVars.Add("country");
            _persistQSVars.Add("algorithm");
            _persistQSVars.Add("user_id");
            _persistQSVars.Add("oauth_token");
            _persistQSVars.Add("AppName");
            _persistQSVars.Add("ADID");
            _persistQSVars.Add("CDID");
            _persistQSVars.Add("UDID");
            _persistQSVars.Add("code");
            _persistQSVars.Add("stat");
            _persistQSVars.Add("SFName");
            _persistQSVars.Add("pageID");
            _persistQSVars.Add("app_id");
            _persistQSVars.Add("appSecret");

            //_persistQSVars.Add("user_id");   // 03/12/2010 Apresh:added user_id: need this to pass [user_src]
        }
        #endregion

        #region Helper Methods
        public string GetQsVarsCollection()
        {
            StringBuilder _sStringBuilder = new StringBuilder();
            foreach (DictionaryEntry item in _qsVars)
            {
                _sStringBuilder.Append(item.Key + "$:$" + item.Value + "$;$");
            }
            return _sStringBuilder.ToString();
        }

        public string GetFormVarsCollection()
        {
            StringBuilder _sStringBuilder = new StringBuilder();
            foreach (DictionaryEntry item in _frmVars)
            {
                _sStringBuilder.Append(item.Key + "$:$" + item.Value + "$;$");
            }
            return _sStringBuilder.ToString();
        }

        public string GetNavigationURL(string sURL)
        {
            return GetNavigationURL(sURL, true);
        }

        public string GetNavigationURL(string sURL, bool bPersistQSVars)
        {
            StringBuilder oSBNavigatorURL = new StringBuilder();
            if (!sURL.StartsWith("http")) oSBNavigatorURL.Append("http://" + Request.Url.Host);
            oSBNavigatorURL.Append(sURL);
            if (!sURL.EndsWith("?") && (sURL.EndsWith(".aspx") || sURL.EndsWith("/"))) oSBNavigatorURL.Append("?");

            if (bPersistQSVars)
            {
                foreach (string item in PersistQSVars)
                {
                    if (QSVars.Contains(item))
                    {
                        if (!oSBNavigatorURL.ToString().EndsWith("?")) oSBNavigatorURL.Append("&");
                        oSBNavigatorURL.Append(item + "=" + Convert.ToString(QSVars[item]));
                    }
                }
            }

            return oSBNavigatorURL.ToString();
        }

        public string GetNewshare(string sProductID, string sProductName, string sProductLogo, string sProductDescitpion, string AppID, string TabNAme)
        {
            StringBuilder oSBShareButton = new StringBuilder();

            string _sAppPathLink = ofbBiz.GetAppPagePath(AppID);
            string logoLocation = " ";
            string _sNotifierDID = new AppNotifier().GetNewDIDWithPrefix();
            if (!_sAppPathLink.EndsWith("?")) _sAppPathLink += "&";
            //Build NotifierDID & pass it to link
            _sAppPathLink += "NDID=" + _sNotifierDID;
            oSBShareButton.Append("<a class=\"defaultFacebookButtonGeorgiaAquarium\" href=\"#\" onclick=\"javascript:" + sProductID + "share(); return false;\">Share</a>" + Environment.NewLine);
            oSBShareButton.Append("<script type=\"text/javascript\">");
            oSBShareButton.Append("function " + sProductID + "share() {" + Environment.NewLine);
            oSBShareButton.Append("var publish = {");
            oSBShareButton.Append("method: 'feed',");
            oSBShareButton.Append("message: 'getting educated about Facebook Connect',");
            oSBShareButton.Append("name: 'Connect',");
            oSBShareButton.Append("caption: 'The Facebook Connect JavaScript SDK',");
            oSBShareButton.Append("description: (");
            oSBShareButton.Append("  'A small JavaScript library that allows you to harness ' ");

            oSBShareButton.Append("),");
            oSBShareButton.Append("link: '" + _sAppPathLink + "',");
            oSBShareButton.Append("picture: '',");
            oSBShareButton.Append("actions: [");
            oSBShareButton.Append(" { name: 'fbrell', link: '" + _sAppPathLink + "' }");
            oSBShareButton.Append("],");
            oSBShareButton.Append("user_message_prompt: 'Share your thoughts about RELL'");
            oSBShareButton.Append(" };");
            oSBShareButton.Append("}" + Environment.NewLine);

            oSBShareButton.Append("FB.ui(publish, Log.info.bind('feed callback'));");
            oSBShareButton.Append("</script>");

            return oSBShareButton.ToString();
        }

        public string GetShareButton(string sProductID, string sProductName, string sProductLogo, string sProductDescitpion, string AppID, string TabNAme)
        {
            StringBuilder oSBShareButton = new StringBuilder();

            string _sAppPathLink = ofbBiz.GetAppPagePath(AppID);
            //string _sAppPathLink = ofbBiz.GetAppPath(AppID);
            string customLogoLocation = ofbBiz.GetCustomLogo(sProductID);
            string logoLocation = "https://www.testsonetreach.com/Images/sonet_watermark.png";
            string _sNotifierDID = new AppNotifier().GetNewDIDWithPrefix();
            if (!_sAppPathLink.EndsWith("?")) _sAppPathLink += "&";
            //Build NotifierDID & pass it to link
            _sAppPathLink += "NDID=" + _sNotifierDID;
            oSBShareButton.Append("<a class=\"FB_Share\" href=\"#\" onclick=\"javascript:" + sProductID + "SHARE(); return false;\"></a>" + Environment.NewLine);

            oSBShareButton.Append("<script type=\"text/javascript\">" + Environment.NewLine);
            oSBShareButton.Append("function " + sProductID + "SHARE() {" + Environment.NewLine);
            oSBShareButton.Append("FB.ui({" + Environment.NewLine);
            oSBShareButton.Append("method: 'feed'," + Environment.NewLine);
            oSBShareButton.Append("display: 'popup'," + Environment.NewLine);
            oSBShareButton.Append("message: 'check out this event!'," + Environment.NewLine);
            oSBShareButton.Append("attachment: {" + Environment.NewLine);
            oSBShareButton.Append("name: '" + TabNAme + "'," + Environment.NewLine);
            oSBShareButton.Append("app_id: '" + AppID + "'," + Environment.NewLine);
            oSBShareButton.Append("caption: '" + TabNAme + "'," + Environment.NewLine);
            //oSBShareButton.Append("redirect_uri: '" + ofbBiz.GetAppPath(AppID) + "'," + Environment.NewLine);
            oSBShareButton.Append("redirect_uri: '" + ofbBiz.GetAppPagePath(AppID) + "'," + Environment.NewLine);
            oSBShareButton.Append("next: '" + "null" + "'," + Environment.NewLine);
            oSBShareButton.Append("description: '" + "" + "'," + Environment.NewLine);
            oSBShareButton.Append("link: '" + ofbBiz.GetAppPagePath(AppID) + "'," + Environment.NewLine);
            oSBShareButton.Append("media: [{" + Environment.NewLine);
            oSBShareButton.Append("type: 'image'," + Environment.NewLine);
            //oSBShareButton.Append("link: '" + ofbBiz.GetAppPagePath(AppID) + "'," + Environment.NewLine);
            //oSBShareButton.Append("link: '" + ofbBiz.GetAppPath(AppID) + "'," + Environment.NewLine);

            if (string.IsNullOrEmpty(customLogoLocation))
            {
                oSBShareButton.Append("src: '" + logoLocation + "'" + Environment.NewLine);
            }
            else
            {
                oSBShareButton.Append("src: '" + customLogoLocation + "'" + Environment.NewLine);
            }
            oSBShareButton.Append("}]" + Environment.NewLine);
            oSBShareButton.Append("}" + Environment.NewLine);
            //TO post on Fanpage add actor_id = Page id
            if (QSVars.Contains("admin"))
            {
                if (QSVars["admin"].ToString().Equals("true"))
                {
                    string pageid = ofbBiz.GetPageID(AppID);
                    oSBShareButton.Append(",actor_id:'" + pageid + "'" + Environment.NewLine);
                }
            }
            oSBShareButton.Append("}," + Environment.NewLine);
            oSBShareButton.Append("function (response) {" + Environment.NewLine);
            oSBShareButton.Append("if (response && response.post_id) {" + Environment.NewLine);
            oSBShareButton.Append("AsycRequest('" + GetNavigationURL(NotifyURL + "FBNotify.aspx?NTYP=SHARE&PDID=" + sProductID + "&NDID=" + _sNotifierDID, true) + "');" + Environment.NewLine);
            oSBShareButton.Append("}" + Environment.NewLine);
            oSBShareButton.Append("});" + Environment.NewLine);
            oSBShareButton.Append("}" + Environment.NewLine);
            oSBShareButton.Append("</script>" + Environment.NewLine);

            return oSBShareButton.ToString();
        }


        public string GetInviteButton(string sProductID, string sProductName, string sProductLogo, string sProductDescitpion, string AppID)
        {
            StringBuilder oSBShareButton = new StringBuilder();

            oSBShareButton.Append("<a class=\"FB_Invite\" href=\"#\" onclick=\"javascript:" + "METHOD" + sProductID + "Invite(); return false;\"></a>" + Environment.NewLine);
            oSBShareButton.Append("<script type=\"text/javascript\">" + Environment.NewLine);
            oSBShareButton.Append("function " + "METHOD" + sProductID + "Invite() {" + Environment.NewLine);
            oSBShareButton.Append("window.open('" + GetNavigationURL(NotifyURL + "NewPost.aspx?PDID=" + sProductID) + "', '', 'height=700,width=800,menubar=0,toolbar=0,statusbar=0,scrollbars=0,resizable=0');" + Environment.NewLine);
            oSBShareButton.Append("} </script>" + Environment.NewLine);

            return oSBShareButton.ToString();
        }

        public string GetRecommendButton(string sProductID, string sProductName, string sProductLogo, string sProductDescitpion, string AppID)
        {
            StringBuilder oSBShareButton = new StringBuilder();
            string _sAppPathLink = ofbBiz.GetAppPagePath(AppID);
            string _sNotifierDID = new AppNotifier().GetNewDIDWithPrefix();
            if (!_sAppPathLink.EndsWith("?")) _sAppPathLink += "&";
            //Build NotifierDID & pass it to link
            _sAppPathLink += "NDID=" + _sNotifierDID;
            oSBShareButton.Append("<a class=\"FB_Recommend\" href=\"#\" onclick=\"javascript:" + "METHOD" + sProductID + "Reco(); return false;\"></a>" + Environment.NewLine);
            oSBShareButton.Append("<script type=\"text/javascript\">" + Environment.NewLine);
            oSBShareButton.Append("function " + "METHOD" + sProductID + "Reco() {" + Environment.NewLine);
            oSBShareButton.Append("window.open('" + GetNavigationURL(NotifyURL + "NewPost.aspx?PDID=" + sProductID) + "', '', 'height=650,width=780,menubar=0,toolbar=0,statusbar=0,scrollbars=0,resizable=0');" + Environment.NewLine);
            oSBShareButton.Append("} </script>" + Environment.NewLine);
            return oSBShareButton.ToString();
        }


        public string GetLeadButton(string sProductID, string sProductName, string sProductLogo, string sProductDescitpion, string AppID)
        {
            StringBuilder oSBShareButton = new StringBuilder();
            if (AppConfig != null && AppCustomer != null)
            {
                oSBShareButton.Append("<a class=\"FB_Inquiry\" href=\"#\" onclick=\"javascript:" + sProductID + "Lead(); return false;\"></a>" + Environment.NewLine);
                oSBShareButton.Append("<script type=\"text/javascript\">" + Environment.NewLine);
                oSBShareButton.Append("function " + sProductID + "Lead() {" + Environment.NewLine);
                oSBShareButton.Append("window.open('" + GetNavigationURL(NotifyURL + "FBEnquiry.aspx?PDID=" + sProductID) + "', '', 'height=500,width=800,menubar=0,toolbar=0,statusbar=0,scrollbars=0,resizable=0');" + Environment.NewLine);
                oSBShareButton.Append("} </script>" + Environment.NewLine);
            }
            return oSBShareButton.ToString();
        }

        public string GetLikePlugin(string sProductID, string sProductName, string sProductLogo, string sProductDescitpion, string AppID)
        {
            StringBuilder oSBShareButton = new StringBuilder();
            int NoOfVisits = ofbBiz.GetLikeCount(sProductID);
            bool CheckLikeNotify = ofbBiz.CheckLikeNotify(QSVars["UDID"].ToString());
            string _sAppPathLink = ofbBiz.GetAppPagePath(AppID);
            string _sNotifierDID = new AppNotifier().GetNewDIDWithPrefix();
            if (!_sAppPathLink.EndsWith("?")) _sAppPathLink += "&";
            //Build NotifierDID & pass it to link
            _sAppPathLink += "NDID=" + _sNotifierDID;

            string sADID = QSVars["ADID"].ToString();
            string suser_id = QSVars["user_id"].ToString();
            string sUDiD = QSVars["UDID"].ToString();

            //oSBShareButton.Append("<fb:like href=" + _sAppPathLink + " send=\"false\" width=\"450\" show_faces=\"false\"></fb:like>" + Environment.NewLine);
            oSBShareButton.Append("<button class=\"FB_Like\" id=\"Like\"></button>&nbsp;&nbsp;&nbsp;&nbsp;<div id=\"output\" class=\"SpanLike\">" + NoOfVisits + "</div><div class=\"divLike\">Likes</div>" + Environment.NewLine);

            // CHeck if user is coming first time else disable LIKE button
            oSBShareButton.Append("<script type=\"text/javascript\">" + Environment.NewLine);
            oSBShareButton.Append("$(document).ready(function () {" + Environment.NewLine);
            oSBShareButton.Append("window.onload = function () {" + Environment.NewLine);
            if (CheckLikeNotify == true)
            {
                oSBShareButton.Append("$(\"#Like\").attr(\"disabled\", \"disabled\");" + Environment.NewLine);
                oSBShareButton.Append("$(\"#Like\").css({ opacity: 0.5 });" + Environment.NewLine);
                oSBShareButton.Append("$(\"#Like\").addClass(\"FB_HideLike\");" + Environment.NewLine);
            }
            else
            {
                oSBShareButton.Append("$('.FB_Like').click(function () {" + Environment.NewLine);
                oSBShareButton.Append("$.ajax({" + Environment.NewLine);
                oSBShareButton.Append("url: \"FBNotify.aspx\"," + Environment.NewLine);
                oSBShareButton.Append("type: \"post\"," + Environment.NewLine);
                oSBShareButton.Append("data:'PDID=" + sProductID + "&NDID=" + _sNotifierDID + "&ADID=" + sADID + "&user_id=" + suser_id + "&UDID=" + sUDiD + "&NTYP=LIKE', " + Environment.NewLine);
                // callback handler that will be called on success
                oSBShareButton.Append("success: function (response, textStatus, jqXHR) {" + Environment.NewLine);
                // log a message to the console                        
                oSBShareButton.Append("AsycRequest('" + GetNavigationURL(NotifyURL + "FBNotify.aspx?NTYP=LIKE&PDID=" + sProductID + "&NDID=" + _sNotifierDID, true) + "');" + Environment.NewLine); //Notifier call to ASYNC function                
                oSBShareButton.Append("}" + Environment.NewLine);
                oSBShareButton.Append("});" + Environment.NewLine);
                oSBShareButton.Append("var lb = '';" + Environment.NewLine);
                oSBShareButton.Append("var int = $('#output').html();" + Environment.NewLine);
                oSBShareButton.Append("if (lb == '') {" + Environment.NewLine);
                oSBShareButton.Append("lb = parseInt(int) + 1;" + Environment.NewLine);
                oSBShareButton.Append("$('#output').html(lb);" + Environment.NewLine);
                oSBShareButton.Append("$(this).fadeTo(\"fast\", .5);" + Environment.NewLine);
                oSBShareButton.Append("$(\"#Like\").addClass(\"FB_HideLike\");" + Environment.NewLine);
                oSBShareButton.Append("jQuery('#Like').attr('disabled', true)" + Environment.NewLine);
                oSBShareButton.Append("return false;" + Environment.NewLine);
                oSBShareButton.Append("}" + Environment.NewLine);
                oSBShareButton.Append("else {" + Environment.NewLine);
                oSBShareButton.Append("lb = parseInt(lb) + 1;" + Environment.NewLine);
                oSBShareButton.Append("$('#output').html(lb);" + Environment.NewLine);
                oSBShareButton.Append("$(this).fadeTo(\"fast\", .5);" + Environment.NewLine);
                oSBShareButton.Append("$(\"#Like\").addClass(\"FB_HideLike\");" + Environment.NewLine);
                oSBShareButton.Append("return false;" + Environment.NewLine);
                oSBShareButton.Append("jQuery('#Like').attr('disabled', true)" + Environment.NewLine);
                oSBShareButton.Append("}" + Environment.NewLine);
                oSBShareButton.Append("});" + Environment.NewLine);
            }
            oSBShareButton.Append("};" + Environment.NewLine);
            oSBShareButton.Append("});" + Environment.NewLine);
            oSBShareButton.Append("</script>" + Environment.NewLine);

            return oSBShareButton.ToString();
        }

        public string GetCommentPlugin(string sProductID, string sProductName, string sProductLogo, string sProductDescitpion, string AppID, string _sAppPathLink)
        {
            StringBuilder oSBShareButton = new StringBuilder();
            oSBShareButton.Append("<div class=\"fb-comments\" data-href=\"" + _sAppPathLink + "\" data-send=\"false\" data-width=\"520\" data-show-faces=\"false\" style=\"padding-top: 20px;\"></div>" + Environment.NewLine);
            return oSBShareButton.ToString();
        }

        public string GetPrint(string sProductID, string sProductName, string sProductLogo, string sProductDescitpion, string AppID)
        {
            StringBuilder oSBShareButton = new StringBuilder();
            string _sAppPathLink = ofbBiz.GetAppPagePath(AppID);
            string _sNotifierDID = new AppNotifier().GetNewDIDWithPrefix();
            if (!_sAppPathLink.EndsWith("?")) _sAppPathLink += "&";
            //Build NotifierDID & pass it to link
            _sAppPathLink += "NDID=" + _sNotifierDID;
            oSBShareButton.Append("<a class=\"FB_Print\" href=\"#\" onclick=\"javascript:" + "METHOD" + sProductID + "Print(); return false;\"></a>" + Environment.NewLine);
            oSBShareButton.Append("<script type=\"text/javascript\">" + Environment.NewLine);
            oSBShareButton.Append("function " + "METHOD" + sProductID + "Print() {" + Environment.NewLine);
            oSBShareButton.Append("window.open('" + GetNavigationURL(NotifyURL + "PrintCoupon.aspx?PDID=" + sProductID) + "', 'mywindow', 'height=520,width=660,menubar=0,toolbar=0,statusbar=0,scrollbars=0,resizable=0,fullscreen=no');" + Environment.NewLine);
            oSBShareButton.Append("} </script>" + Environment.NewLine);
            return oSBShareButton.ToString();
        }

        public string GetEmail(string sProductID, string sProductName, string sProductLogo, string sProductDescitpion, string AppID)
        {
            StringBuilder oSBShareButton = new StringBuilder();
            string _sAppPathLink = ofbBiz.GetAppPagePath(AppID);
            string _sNotifierDID = new AppNotifier().GetNewDIDWithPrefix();
            if (!_sAppPathLink.EndsWith("?")) _sAppPathLink += "&";
            //Build NotifierDID & pass it to link
            _sAppPathLink += "NDID=" + _sNotifierDID;
            oSBShareButton.Append("<a class=\"FB_Email\" href=\"#\" onclick=\"javascript:" + "METHOD" + sProductID + "Email(); return false;\"></a>" + Environment.NewLine);
            oSBShareButton.Append("<script type=\"text/javascript\">" + Environment.NewLine);
            oSBShareButton.Append("function " + "METHOD" + sProductID + "Email() {" + Environment.NewLine);
            oSBShareButton.Append("window.open('" + GetNavigationURL(NotifyURL + "EmailCoupon.aspx?PDID=" + sProductID) + "', 'mywindow', 'height=640,width=1145,menubar=0,toolbar=0,statusbar=0,scrollbars=0,resizable=0,fullscreen=no');" + Environment.NewLine);
            oSBShareButton.Append("} </script>" + Environment.NewLine);
            return oSBShareButton.ToString();
        }

        public string GetGraphShare(string sProductID, string sProductName, string sProductLogo, string sProductDescitpion)
        {
            StringBuilder oSBShareButtonGraph = new StringBuilder();
            if (AppConfig != null && AppCustomer != null)
            {
                oSBShareButtonGraph.Append("http://www.facebook.com/dialog/feed?");
                oSBShareButtonGraph.Append("app_id=156921294422921&");
                oSBShareButtonGraph.Append("link=http://developers.facebook.com/docs/reference/dialogs/&");
                oSBShareButtonGraph.Append("picture=http://fbrell.com/f8.jpg&");
                oSBShareButtonGraph.Append("name=Facebook%20Dialogs&");
                oSBShareButtonGraph.Append("caption=Reference%20Documentation&");
                oSBShareButtonGraph.Append("description=Using%20Dialogs%20to%20interact%20with%20users.&");
                oSBShareButtonGraph.Append("message=Facebook%20Dialogs%20are%20so%20easy!&");
                oSBShareButtonGraph.Append("redirect_uri=https://www.testsonetreach.com/CreateApp.aspx/");
            }
            return oSBShareButtonGraph.ToString();
        }

        public string GetEntryForm(string sProductID, string sProductName, string sProductLogo, string sProductDescitpion, string appConfigDID, string sonetID)
        {
            StringBuilder oSBShareButton = new StringBuilder();
            if (AppConfig != null && AppCustomer != null)
            {
                oSBShareButton.Append("<a class=\"FB_Enter\" href=\"#\" onclick=\"javascript:" + sProductID + "Enter(); return false;\"></a>" + Environment.NewLine);
                oSBShareButton.Append("<script type=\"text/javascript\">" + Environment.NewLine);
                oSBShareButton.Append("function " + sProductID + "Enter() {" + Environment.NewLine);
                oSBShareButton.Append("window.open('" + GetNavigationURL(NotifyURL + "EntrySweepStake.aspx?AppDID=" + appConfigDID) + "&SonetID=" + sonetID + "', '', 'height=570,width=960,menubar=0,toolbar=0,statusbar=0,scrollbars=0,resizable=0');" + Environment.NewLine);
                oSBShareButton.Append("} </script>" + Environment.NewLine);
            }
            return oSBShareButton.ToString();
        }

        public string GetTwitterShareURL(string sProductID, string sProductName, string sProductLogo, string sProductDescitpion, string AppID)
        {
            string sADID = QSVars["ADID"].ToString();
            string suser_id = QSVars["user_id"].ToString();
            string sUDiD = QSVars["UDID"].ToString();
            string sArticleTitle = "Check out this App!";
            string _sAppPathLink = ofbBiz.GetAppPagePath(AppID);
            string sArticleSource = "http://www.testsonetreach.com";//sAppPathLink;
            string app_id = QSVars["app_id"].ToString();



            string customLogoLocation = ofbBiz.GetCustomLogo(sProductID);
            string logoLocation = "https://www.testsonetreach.com/Images/sonet_watermark.png";
            string _sNotifierDID = new AppNotifier().GetNewDIDWithPrefix();
            if (!_sAppPathLink.EndsWith("?")) _sAppPathLink += "&";

            //Build NotifierDID & pass it to link
            _sAppPathLink += "NDID=" + _sNotifierDID + "&NTYP=TWEET";

            //Auth User to get Twitter Details
            Twitter otittwr = new Twitter();
            string AuthTwitter = otittwr.GetTwitterAuthURL(sADID, app_id, sProductID);

            StringBuilder oSBTweetButton = new StringBuilder();
            oSBTweetButton.Append("<a class=\"TW_Share\" href=\"#\" onclick=\"javascript:" + "METHOD" + sProductID + "Twitter(); return false;\" ></a>" + Environment.NewLine);
            oSBTweetButton.Append("<script type=\"text/javascript\">" + Environment.NewLine);
            oSBTweetButton.Append("function " + "METHOD" + sProductID + "Twitter() {" + Environment.NewLine);
            oSBTweetButton.Append("window.open('" + AuthTwitter + "', 'mywindow', 'height=470,width=660,menubar=0,toolbar=0,statusbar=0,scrollbars=0,resizable=0,fullscreen=no');" + Environment.NewLine);
            oSBTweetButton.Append("} </script>" + Environment.NewLine);
            return oSBTweetButton.ToString();

        }

        public string CallPageTabs(string PageID)
        {
            //now we have page_id, redirect user to PAGE URL
            string PageName = string.Empty;
            //use FQL to get page name etc
            StringBuilder oSBPgaeCaller = new StringBuilder();
            oSBPgaeCaller.Append("https://api.facebook.com/method/fql.query?");
            oSBPgaeCaller.Append("query=SELECT name FROM page WHERE page_id = " + PageID);
            //oSBPgaeCaller.Append("&access_token=" + Session["user_access_token"].ToString());
            oSBPgaeCaller.Append("&format=JSON");
            FaceBook objFB = new FaceBook();
            //Parse json to get MXDBAppUser
            string _sUserInfoJson = objFB.CallWebRequest("GET", oSBPgaeCaller.ToString(), string.Empty);
            object[] oUserLocationDataRow = new object[5];
            //Convert Json to JsonDictionary <of String, object>
            System.Web.Script.Serialization.JavaScriptSerializer _oJavaScriptSerializer = new System.Web.Script.Serialization.JavaScriptSerializer();
            object _oJSONObject = _oJavaScriptSerializer.DeserializeObject(_sUserInfoJson);
            int i = 0;
            for (i = 0; i <= ((object[])_oJSONObject).Length - 1; i++)
            {
                Dictionary<string, object> _ojsonUserDetails = (Dictionary<string, object>)((object[])_oJSONObject)[i];
                foreach (KeyValuePair<string, object> _oKeyjsonUserDetailsItem in _ojsonUserDetails)
                {
                    switch (_oKeyjsonUserDetailsItem.Key)
                    {
                        case "name": //set Email
                            PageName = Convert.ToString(_oKeyjsonUserDetailsItem.Value);
                            break;
                    }
                }
            }
            return PageName;
        }

        #endregion

    }//End of Class
}
