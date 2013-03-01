using System;
using System.Collections.Generic;
using DigiMa.Common;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Text;
using DigiMa.Common;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Net;
using System.IO;
using System.Text.RegularExpressions;
using DigiMa.BizProcess;
using DigiMa.Data;
using Twitterizer;

namespace DigiMa
{
    public partial class SMTweet : System.Web.UI.Page
    {
        private AppUser _oDCAppUser;
        public AppUser AppUser
        {
            get { return _oDCAppUser; }
        }
        string sArticleTitle = string.Empty;
        string sArticleSource = string.Empty;
        private string NotifyURL = ConfigurationManager.AppSettings["NotifyURL"];
        AppUser oDCAppUser = new AppUser();
        string app_id;
        FacebookBizProcess ofbBiz = new FacebookBizProcess();

        AppProduct oAppProduct = new AppProduct();

        protected void Page_Load(object sender, EventArgs e)
        {
            CanvasBizProcess ocanbiz = new CanvasBizProcess();
            TwitterBizProcess Twbiz = new TwitterBizProcess();
            Twitter otittwr = new Twitter();

            string oauthverifier = Request.QueryString["oauth_verifier"].ToString();
            string oauthtoken = (Request.QueryString["oauth_token"].ToString());
            string userid = otittwr.CreateCachedAccessToken(oauthtoken, oauthverifier);

            //string ADID = SessionData.Product.AppConfigDID;
            //string app_id = SessionData.Config.AppID;
            string ADID = Request.QueryString["ADID"];
            string app_id = Request.QueryString["app_id"];
            String SMType = "TW";


            //First Check whether User Exsist

            oDCAppUser = ocanbiz.GetTwitterTokens(ADID, SMType, userid);
            if (oDCAppUser != null)
            {
                string token = oDCAppUser.Token;
                string tokensecret = oDCAppUser.TokenSecret;
                if (otittwr.CheckAppAuthorized(token, tokensecret) == true)
                {

                    UpdateStatus(token, tokensecret);
                    ClientScript.RegisterStartupScript(typeof(Page), "RedirectArticle", "alert('Tweeted Successfully ! ! ! ');", true);
                    ClientScript.RegisterStartupScript(typeof(Page), "closePage", "window.close('Test.aspx');", true);

                    //Tweet();
                    //ScriptManager.RegisterStartupScript(this, typeof(string), "OPEN_WINDOW", "var Mleft = (screen.width/2)-(760/2);var Mtop = (screen.height/2)-(700/2);window.open( '" + URL + "', null, 'height=700,width=760,status=yes,toolbar=no,scrollbars=yes,menubar=no,location=no,top=\'+Mtop+\', left=\'+Mleft+\'' );", true);

                    //this.ClientScript.RegisterStartupScript(this.GetType(), "navigate", "window.location = $('#aTwitterBtn').attr('href');", true);

                    //this.ClientScript.RegisterStartupScript(this.GetType(),"navigate","window.onload = function() {window.location.hash='#message';}",
                    //                    true);


                }
            }
            else
            {

                AppUser oAppuser = new AppUser();
                oAppuser.AppConfigDID = ADID;
                oAppuser.EmailID = "NULL";
                oAppuser.SonetID = userid;
                oAppuser.SonetSRC = "FBSRC";
                oAppuser.UserStatus = "Active";
                oAppuser.SMType = "TW";
                oAppuser.Token = SessionData.TwitterData.TokenKey;
                oAppuser.TokenSecret = SessionData.TwitterData.TokenSecretKey;
                oAppuser = otittwr.GetUserDetail(userid, oAppuser);

                //Insert in AppUser when Brand Tweets the Campaign 
                if (!Twbiz.IsUserCreatedForTwitter(oAppuser.SonetID, oAppuser.AppConfigDID))
                {
                    if (Twbiz.SetAppUserAuthorize(oAppuser, ADID)) oDCAppUser = oAppuser;
                }

                UpdateStatus(SessionData.TwitterData.TokenKey, SessionData.TwitterData.TokenSecretKey);

                //Close this page since all info is available.
                ClientScript.RegisterStartupScript(typeof(Page), "RedirectArticle", "alert('Tweeted Successfully ! ! ! ');", true);
                ClientScript.RegisterStartupScript(typeof(Page), "closePage", "window.close('Test.aspx');", true);
            }

        }

        public bool UpdateStatus(string token, string SecretKey)
        {
            try
            {
                var consumerKey = ConfigurationManager.AppSettings["TwitterConsumerKey"];
                var consumerSecret = ConfigurationManager.AppSettings["TwitterConsumerSecret"];
                string ADID = Request.QueryString["ADID"];



                OAuthTokens accessToken = new OAuthTokens();
                accessToken.AccessToken = token;
                accessToken.AccessTokenSecret = SecretKey;
                accessToken.ConsumerKey = consumerKey;
                accessToken.ConsumerSecret = consumerSecret;

                string postcontent = "Tweeted via " + ofbBiz.GetAppPath(Convert.ToString(Request.QueryString["app_id"]));

                // string postcontent = "Tweeted via " + ofbBiz.GetAppPath(Convert.ToString(Request.QueryString["app_id"]));

                TwitterResponse<TwitterStatus> tweetResponse = TwitterStatus.Update(accessToken, postcontent);
                if (tweetResponse.Result == RequestResult.Success)
                {
                    //Tweeted Successfully
                    SonetPie osonetpie = new SonetPie();
                    AppLeadData oAppLeadData = new AppLeadData();
                    AppProduct dAppproduct = new AppProduct();
                    dAppproduct = ofbBiz.GetAppProduct(ADID);
                    string PDID = dAppproduct.DID;

                    string _sNotifierDID = new AppNotifier().GetNewDIDWithPrefix();
                    string NDID = _sNotifierDID;
                    //Load app settings

                    oDCAppUser = ofbBiz.GetAppUser(osonetpie, ADID, SessionData.TwitterData.CachedUserId1);


                    oAppProduct = ofbBiz.GetAppProductDetails(osonetpie, PDID);

                    ofbBiz.RaiseAppNotifier(oDCAppUser, "TWEET", oDCAppUser.DID, PDID, NDID, oAppLeadData, string.Empty);

                }
                else
                {
                    // Something bad happened
                }
                return true;
            }
            catch (Exception ex)
            {

            }
            return false;

        }
    }
}