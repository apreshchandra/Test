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
    public partial class SonetReachPDA : System.Web.UI.Page
    {
        string ADID = "";
        string CDID = "";
        string app_id = "";
        string PageNAme = "";

        string addCOMMENT = string.Empty;
        string addSHARE = string.Empty;
        string addPOST = string.Empty;
        string addEntry = string.Empty;
        string addLIKE = string.Empty;
        string addLead = string.Empty;
        string addCaption = string.Empty;
        string addTwitter = string.Empty;
        private const string TRUE = "Y";
        private const string MOBILE_USER = "MOBILE";
        private const string TAB_USER = "TAB";
        private static string VALUE = "N";
        string access_tok;
        string userID;
        string NotifyURL;
        static string pageToLoad;
        static bool LoadComplete;
        private string SiteID;
        int PageStatus = 0;
        SonetPie osonetpie = new SonetPie();
        AppUser oDCAppUser = new AppUser();
        CanvasBizProcess canv = new CanvasBizProcess();
        FacebookBizProcess fbBiz = new FacebookBizProcess();


        protected void Page_Load(object sender, EventArgs e)
        {
            //litOGTags.Text = GetOGMetaTags();
            NotifyURL = ConfigurationSettings.AppSettings["NotifyURL"];

            if (Request["acc_tok"] != null)
            {
                access_tok = Request["acc_tok"].ToString();
            }


            if (Request["uID"] != null)
            {
                userID = Request["uID"].ToString();
            }
            if (Request["app_id"] != null)
            {
                app_id = Request["app_id"].ToString();
            }
            litEnableFBJS.Text = GetInitializedJS();
            //string id = hdnUserID.Value;
            FaceBook facebook = new FaceBook();

            if (!string.IsNullOrEmpty(access_tok))
            {
                oDCAppUser = facebook.GetUserDetail(userID, access_tok, oDCAppUser);
            }

            oDCAppUser.AppConfigDID = fbBiz.GetConfigDEED(app_id);
            ADID = oDCAppUser.AppConfigDID;
            //Now INSERT User details to AppUser table
            if (Request.UserAgent.ToLower().Contains("iphone") || Request.UserAgent.ToLower().Contains("android"))
            {
                oDCAppUser.SonetSRC = MOBILE_USER;
            }
            else
            {
                oDCAppUser.SonetSRC = TAB_USER;
                if (Request.UserAgent.ToLower().Contains("ipad"))
                {
                    //modify css to suit width

                }
            }

            if (string.IsNullOrEmpty(oDCAppUser.SonetID))
            {
                oDCAppUser.SonetID = userID;
            }

            if (!fbBiz.IsAppUserExistMobile(oDCAppUser))
            {
                if (fbBiz.SetAppUserAuthorize(oDCAppUser, ADID)) //
                {
                }
            }

            bool ISPageLiked;
            if (!string.IsNullOrEmpty(access_tok))
            {
                ISPageLiked = facebook.IsPageLiked("314911595222628", access_tok);
            }
            else
            {
                ISPageLiked = false;
            }


            //show HTML, LIKE gatewat
            if (!fbBiz.IsLikeGatewayAdded(app_id)) // If Already liked show page else Force user to like, iff like gateway was selected
            {

                SessionData.Config = new AppConfiguration();
                SessionData.Config.DID = fbBiz.GetConfigDEED(app_id);
                //check if configuration is still good- that means not EXPIRED
                if (!fbBiz.IsConfigurationExpired(SessionData.Config.DID))
                {
                    //populate the AppProduct encapsulation based on app that is loaded
                    AppProduct oAppProduct = new AppProduct();


                    oAppProduct = fbBiz.GetActiveAppProduct(osonetpie, SessionData.Config.DID);
                    string HTML = oAppProduct.ProductHTML;

                    //Get Custom Tab name
                    string CustTabNAme = fbBiz.GetCustomTabName(app_id);



                    //Get Share Button for this Product
                    string CommentBox = GetCommentPlugin(oAppProduct.DID, oAppProduct.ProductName, oAppProduct.ProductLogo, oAppProduct.ProductShortDesc, app_id, fbBiz.GetAppPagePath(app_id));
                    string ShareButton = GetShareButton(oAppProduct.DID, oAppProduct.ProductName, oAppProduct.ProductLogo, oAppProduct.ProductShortDesc, app_id, CustTabNAme);
                    string InviteButton = GetInviteButton(oAppProduct.DID, oAppProduct.ProductName, oAppProduct.ProductLogo, oAppProduct.ProductShortDesc, app_id);
                    string RecommendButton = GetRecommendButtonForMobile(oAppProduct.DID, oAppProduct.ProductName, oAppProduct.ProductLogo, oAppProduct.ProductShortDesc, app_id);
                    string LikePlugin = GetLikePlugin(oAppProduct.DID, oAppProduct.ProductName, oAppProduct.ProductLogo, oAppProduct.ProductShortDesc, app_id);
                    string PrintButton = GetPrint(oAppProduct.DID, oAppProduct.ProductName, oAppProduct.ProductLogo, oAppProduct.ProductShortDesc, app_id);
                    string EmailButton = GetEmail(oAppProduct.DID, oAppProduct.ProductName, oAppProduct.ProductLogo, oAppProduct.ProductShortDesc, app_id);
                    //string TwitterButton = GetTwitterShareURL(oAppProduct.DID, oAppProduct.ProductName, oAppProduct.ProductLogo, oAppProduct.ProductShortDesc, app_id);
                    // Get the HTML to be shown
                    if (!oAppProduct.ProductCategory.Equals("WebHutColl."))
                    {

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
                        if (oAppProduct.ReccWidgetAdded.Equals(TRUE))
                        {
                            if (canv.IsConfigForSweepstakes(oAppProduct.AppConfigDID))
                            {
                                addCaption = addSHARE.Replace("ReButton", InviteButton);
                            }
                            else
                            {
                                addCaption = addSHARE.Replace("ReButton", RecommendButton);
                            }
                        }
                        else
                        {
                            addCaption = addSHARE.Replace("ReButton", "");
                        }

                        addLead = addCaption.Replace("Lead", "");
                        addLIKE = addLead.Replace("Like", LikePlugin);
                        addPOST = addLIKE.Replace("Caption", oAppProduct.AppCaption);
                        addTwitter = addPOST.Replace("TwButton", "");

                        litHTML.Text = addTwitter;
                    }
                    else
                    {
                        headRow.Style.Remove("background-color");
                        mainRow.Style.Remove("background-color");
                        //render Webhut template

                        SiteID = fbBiz.GetSiteIDForConfig(Convert.ToString(ADID));
                        SessionData.Config = new AppConfiguration();
                        SessionData.Config.SSiteID = SiteID;
                        int TemplateID = fbBiz.GetTemplateIDForConfig(Convert.ToString(ADID));


                        pageToLoad = "index.html";
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

                            text = text.Replace("<img class=\"dynamic\" src=\"images/SNR_twitter.png\">", "");

                            if (TemplateID == 11)
                            {
                                text = text.Replace("<img class=\"ActionImg\" src=\"Images/email.png\" />", EmailButton);
                                text = text.Replace("<img class=\"ActionImg\" src=\"Images/print.png\" />", PrintButton);
                            }
                        }
                        else
                        {
                            text = text.Replace("<img class=\"dynamic\" src=\"images/SNR_facebook.png\" />", ShareButton);

                            text = text.Replace("<img class=\"dynamic\" src=\"images/SNR_recommend.png\" />", RecommendButton);

                            text = text.Replace("<img class=\"dynamic\" src=\"images/fb-like-button.png\" />", LikePlugin);

                            text = text.Replace("<img class=\"dynamic\" src=\"images/SNR_twitter.png\" />", "");
                            if (TemplateID == 11)
                            {
                                text = text.Replace("<img class=\"ActionImg\" src=\"Images/email.png\" />", EmailButton);
                                text = text.Replace("<img class=\"ActionImg\" src=\"Images/print.png\" />", PrintButton);
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

                            SessionData.PrefData.TemplateID1 = TemplateID;
                        }
                        else if (TemplateID == 11)
                        {
                            style = "/CSS/CouponsStyle.css";

                            SessionData.PrefData.TemplateID1 = TemplateID;
                        }
                        else if (TemplateID == 14)
                        {
                            style = "/css/realestate_styles.css";
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
                            HtmlLink linking = Page.FindControl("facebookIDStyleSheets") as HtmlLink;
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


                        litHTML.Text = imagesReplaced;

                        if (TemplateID == 13)
                        {
                            litHTML.Text = litHTML.Text.Replace("<link href=\"CSS/FabrikStyle.css\" rel=\"stylesheet\" type=\"text/css\">", "");
                        }
                        else if (TemplateID == 11)
                        {
                            litHTML.Text = litHTML.Text.Replace("<link href=\"CSS/CouponsStyle.css\" rel=\"stylesheet\" type=\"text/css\" />", "");
                        }
                    }
                }
            }
            else
            {
                if (ISPageLiked)
                {
                    SessionData.Config = new AppConfiguration();
                    SessionData.Config.DID = fbBiz.GetConfigDEED(app_id);
                    //check if configuration is still good- that means not EXPIRED
                    if (!fbBiz.IsConfigurationExpired(SessionData.Config.DID))
                    {
                        //populate the AppProduct encapsulation based on app that is loaded
                        AppProduct oAppProduct = new AppProduct();


                        oAppProduct = fbBiz.GetActiveAppProduct(osonetpie, SessionData.Config.DID);
                        // Get the HTML to be shown

                        string HTML = oAppProduct.ProductHTML;

                        //Get Custom Tab name
                        string CustTabNAme = fbBiz.GetCustomTabName(app_id);



                        //Get Share Button for this Product
                        string CommentBox = GetCommentPlugin(oAppProduct.DID, oAppProduct.ProductName, oAppProduct.ProductLogo, oAppProduct.ProductShortDesc, app_id, fbBiz.GetAppPagePath(app_id));
                        string ShareButton = GetShareButton(oAppProduct.DID, oAppProduct.ProductName, oAppProduct.ProductLogo, oAppProduct.ProductShortDesc, app_id, CustTabNAme);
                        string InviteButton = GetInviteButton(oAppProduct.DID, oAppProduct.ProductName, oAppProduct.ProductLogo, oAppProduct.ProductShortDesc, app_id);
                        string RecommendButton = GetRecommendButtonForMobile(oAppProduct.DID, oAppProduct.ProductName, oAppProduct.ProductLogo, oAppProduct.ProductShortDesc, app_id);
                        string LikePlugin = GetLikePlugin(oAppProduct.DID, oAppProduct.ProductName, oAppProduct.ProductLogo, oAppProduct.ProductShortDesc, app_id);
                        //string EntryFormPlug = GetEntryForm(oAppProduct.DID, oAppProduct.ProductName, oAppProduct.ProductLogo, oAppProduct.ProductShortDesc, QSVars["ADID"].ToString(), QSVars["user_id"].ToString());
                        //string LeadPlugin = GetLeadButton(oAppProduct.DID, oAppProduct.ProductName, oAppProduct.ProductLogo, oAppProduct.ProductShortDesc, QSVars["AppID"].ToString());
                        //string PrintButton = GetPrint(oAppProduct.DID, oAppProduct.ProductName, oAppProduct.ProductLogo, oAppProduct.ProductShortDesc, QSVars["AppID"].ToString());
                        //string EmailButton = GetEmail(oAppProduct.DID, oAppProduct.ProductName, oAppProduct.ProductLogo, oAppProduct.ProductShortDesc, QSVars["AppID"].ToString());
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
                        if (oAppProduct.ReccWidgetAdded.Equals(TRUE))
                        {
                            if (canv.IsConfigForSweepstakes(oAppProduct.AppConfigDID))
                            {
                                addCaption = addSHARE.Replace("ReButton", InviteButton);
                            }
                            else
                            {
                                addCaption = addSHARE.Replace("ReButton", RecommendButton);
                            }
                        }
                        else
                        {
                            addCaption = addSHARE.Replace("ReButton", "");
                        }

                        addLead = addCaption.Replace("Lead", "");
                        addLIKE = addLead.Replace("Like", LikePlugin);
                        addPOST = addLIKE.Replace("Caption", oAppProduct.AppCaption);
                        addTwitter = addPOST.Replace("TwButton", "");
                        litHTML.Text = addTwitter;
                    }
                    else
                    {
                        litHTML.Text = "Oops! Looks like your aplication expired. Please buy credits to continue.";
                    }
                }
                else
                {
                    if ((Request.QueryString.Count == 1 && Request.QueryString["app_id"] != null) || (!string.IsNullOrEmpty(access_tok)))
                    {
                        //string pagePath = fbBiz.GetAppPath(Request["app_id"].ToString());
                        //Page.ClientScript.RegisterStartupScript(this.GetType(), "myCloseScript", "window.parent.location.href='" + pagePath + "'", true);
                    }
                    else
                    {
                        litHTML.Text = " <div class=\"fb-like\" data-href=\"https://www.testsonetreach.com/MobileRedirect.aspx?app_id=295889527140091\" data-send=\"false\" data-width=\"400\" data-show-faces=\"true\"></div>";
                    }
                }
            }



        }


        public string GetShareButton(string sProductID, string sProductName, string sProductLogo, string sProductDescitpion, string AppID, string TabNAme)
        {
            StringBuilder oSBShareButton = new StringBuilder();

            string _sAppPathLink = fbBiz.GetAppPagePath(AppID);
            string customLogoLocation = fbBiz.GetCustomLogo(sProductID);
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
            oSBShareButton.Append("message: 'check out this event!'," + Environment.NewLine);
            oSBShareButton.Append("name: '" + TabNAme + "'," + Environment.NewLine);
            oSBShareButton.Append("caption: '" + TabNAme + "'," + Environment.NewLine);
            oSBShareButton.Append("description:'" + "SonetReach" + "'," + Environment.NewLine);
            oSBShareButton.Append("picture:'" + logoLocation + "'," + Environment.NewLine);
            oSBShareButton.Append("display:'touch'," + Environment.NewLine);
            oSBShareButton.Append("app_id: '" + AppID + "'," + Environment.NewLine);
            oSBShareButton.Append("link: 'https://www.sonetreach.com/MobileRedirect.aspx?app_id=" + AppID + "'," + Environment.NewLine);
            oSBShareButton.Append("redirect_uri: 'https://www.sonetreach.com/MobileRedirect.aspx?app_id=" + AppID + "&NTYP=MSHARE&PDID=" + sProductID + "&NDID=" + _sNotifierDID + "&user_id=" + userID + "'" + Environment.NewLine);


            oSBShareButton.Append("}," + Environment.NewLine);
            oSBShareButton.Append("function (response) {" + Environment.NewLine);
            oSBShareButton.Append("if (response && response.post_id) {" + Environment.NewLine);
            oSBShareButton.Append("AsycRequest('" + GetNavigationURL("https://www.sonetreach.com/FBNotify.aspx?NTYP=MSHARE&PDID=" + sProductID + "&NDID=" + _sNotifierDID, true) + "');" + Environment.NewLine);
            oSBShareButton.Append("}" + Environment.NewLine);
            oSBShareButton.Append("});" + Environment.NewLine);
            oSBShareButton.Append("}" + Environment.NewLine);
            oSBShareButton.Append("</script>" + Environment.NewLine);

            return oSBShareButton.ToString();
        }

        public string GetCommentPlugin(string sProductID, string sProductName, string sProductLogo, string sProductDescitpion, string AppID, string _sAppPathLink)
        {
            StringBuilder oSBShareButton = new StringBuilder();
            oSBShareButton.Append("<div class=\"fb-comments\" data-href=\"" + _sAppPathLink + "\" data-send=\"false\" data-width=\"520\" data-show-faces=\"false\" style=\"padding-top: 20px;\"></div>" + Environment.NewLine);
            return oSBShareButton.ToString();
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



            return oSBNavigatorURL.ToString();
        }

        protected string GetInitializedJS()
        {
            FacebookBizProcess _fbBiz = new FacebookBizProcess();

            if (true)//REVISIT
            {
                StringBuilder oFBJSBuilder = new StringBuilder();
                ////Intitialize FBJS for widgets on page load            
                //oFBJSBuilder.Append("<div id=\"fb-root\"></div>" + Environment.NewLine);
                //oFBJSBuilder.Append("<script src=\"//connect.facebook.net/en_US/all.js\"></script>" + Environment.NewLine);
                //oFBJSBuilder.Append("<script>" + Environment.NewLine);
                oFBJSBuilder.Append("window.fbAsyncInit = function () {" + Environment.NewLine);
                oFBJSBuilder.Append("FB.init({" + Environment.NewLine);
                oFBJSBuilder.Append("appId: '" + app_id + "'," + Environment.NewLine);
                oFBJSBuilder.Append("//channelUrl: '//WWW.YOUR_DOMAIN.COM/channel.html', // Channel File" + Environment.NewLine);
                oFBJSBuilder.Append("status: true, // check login status" + Environment.NewLine);
                oFBJSBuilder.Append("cookie: true, // enable cookies to allow the server to access the session" + Environment.NewLine);
                oFBJSBuilder.Append("xfbml: true  // parse XFBML" + Environment.NewLine);
                oFBJSBuilder.Append("});" + Environment.NewLine);
                oFBJSBuilder.Append("};" + Environment.NewLine);
                //FBJSBuilder.Append("FB.Canvas.setAutoGrow(100);");
                //oFBJSBuilder.Append("window.onload = function() {FB.Canvas.setAutoGrow(100);}");
                oFBJSBuilder.Append("</script>" + Environment.NewLine);

                return oFBJSBuilder.ToString();
            }
            else
            {
                return string.Empty;
            }
        }
        public string GetRecommendButtonForMobile(string sProductID, string sProductName, string sProductLogo, string sProductDescitpion, string AppID)
        {
            StringBuilder oSBShareButton = new StringBuilder();
            string _sAppPathLink = fbBiz.GetAppPagePath(AppID);
            string _sNotifierDID = new AppNotifier().GetNewDIDWithPrefix();
            if (!_sAppPathLink.EndsWith("?")) _sAppPathLink += "&";
            //Build NotifierDID & pass it to link
            _sAppPathLink += "NDID=" + _sNotifierDID;

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
            oSBShareButton.Append("document.cookie=myStringArray;");
            oSBShareButton.Append("AsycRequest('" + GetNavigationURL(NotifyURL + "FBNotify.aspx?NTYP=MPOST&PDID=" + sProductID + "&NDID=" + _sNotifierDID + "&ADID=" + oDCAppUser.AppConfigDID + "&userID=" + userID, true) + "');" + Environment.NewLine);
            oSBShareButton.Append("}");


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
        protected void Share_Click(object sender, EventArgs e)
        {

        }

        public string GetLikePlugin(string sProductID, string sProductName, string sProductLogo, string sProductDescitpion, string AppID)
        {
            StringBuilder oSBShareButton = new StringBuilder();
            int NoOfVisits = fbBiz.GetLikeCount(sProductID);
            string configDID = fbBiz.GetConfigDEED(AppID);
            if (!string.IsNullOrEmpty(userID))
            {
                string UDID = fbBiz.GetUserDID(configDID, userID);
                bool CheckLikeNotify = fbBiz.CheckLikeNotify(UDID);
                string _sAppPathLink = fbBiz.GetAppPath(AppID);
                string _sNotifierDID = new AppNotifier().GetNewDIDWithPrefix();
                if (!_sAppPathLink.EndsWith("?")) _sAppPathLink += "&";
                //Build NotifierDID & pass it to link
                _sAppPathLink += "NDID=" + _sNotifierDID;



                //oSBShareButton.Append("<fb:like href=" + _sAppPathLink + " send=\"false\" width=\"450\" show_faces=\"false\"></fb:like>" + Environment.NewLine);
                oSBShareButton.Append("<button class=\"FB_Like\" id=\"Like\"></button><div id=\"output\" class=\"SpanLike\">" + NoOfVisits + "</div><div class=\"divLike\">Likes</div>" + Environment.NewLine);

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
                    oSBShareButton.Append("url:'" + NotifyURL + "FBNotify.aspx'," + Environment.NewLine);
                    oSBShareButton.Append("type: \"post\"," + Environment.NewLine);
                    oSBShareButton.Append("data:'PDID=" + sProductID + "&NDID=" + _sNotifierDID + "&ADID=" + configDID + "&user_id=" + userID + "&UDID=" + UDID + "&NTYP=LIKE', " + Environment.NewLine);
                    // callback handler that will be called on success
                    oSBShareButton.Append("success: function (response, textStatus, jqXHR) {" + Environment.NewLine);
                    // log a message to the console                        
                    oSBShareButton.Append("AsycRequest('" + GetNavigationURL(NotifyURL + "FBNotify.aspx?NTYP=MLIKE&PDID=" + sProductID + "&NDID=" + _sNotifierDID, true) + "');" + Environment.NewLine); //Notifier call to ASYNC function                
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
            else
            {
                return "";
            }
        }

        private string GetOGMetaTags()
        {
            FacebookBizProcess fbBizProc = new FacebookBizProcess();
            StringBuilder sbOGTags = new StringBuilder();
            sbOGTags.Append("<meta property=\"fb:app_id\" content=\"" + app_id + "\" />" + Environment.NewLine);
            sbOGTags.Append("<meta property=\"og:type\" content=\"website\" />" + Environment.NewLine);
            sbOGTags.Append("<meta property=\"og:title\" content=\"Welocme to Sonetreach\" />" + Environment.NewLine);
            sbOGTags.Append("<meta property=\"og:image\" content=\"https://www.testsonetreach.com/images/sonet_watermark.png\" />" + Environment.NewLine);
            sbOGTags.Append("<meta property=\"og:description\" content=\"Social Media Marketing Software\" />" + Environment.NewLine);
            sbOGTags.Append("<meta property=\"og:url\" content=\"" + fbBizProc.GetAppPagePath(app_id) + "\">" + Environment.NewLine);
            sbOGTags.Append("<meta property=\"fb:admins\" content=\"\" />" + Environment.NewLine);
            sbOGTags.Append(" <script src=\"https://ajax.googleapis.com/ajax/libs/jquery/1.6.1/jquery.min.js\"></script>" + Environment.NewLine);
            sbOGTags.Append("<script src=\"https://connect.facebook.net/en_US/all.js#appId=" + app_id + "&amp;xfbml=1\"></script>" + Environment.NewLine);
            return sbOGTags.ToString();
        }

        public string GetGatewayLikeButton(string sProductID, string sProductName, string sProductLogo, string sProductDescitpion, string AppID)
        {

            StringBuilder oSBLikeGateway = new StringBuilder();


            oSBLikeGateway.Append("<div id=\"fb-root\"></div>");
            oSBLikeGateway.Append("<script>(function(d, s, id) {");
            oSBLikeGateway.Append("var js, fjs = d.getElementsByTagName(s)[0];");
            oSBLikeGateway.Append("if (d.getElementById(id)) return;");
            oSBLikeGateway.Append("js = d.createElement(s); js.id = id;");
            oSBLikeGateway.Append(" js.src =");
            oSBLikeGateway.Append("fjs.parentNode.insertBefore(js, fjs);");
            oSBLikeGateway.Append("}(document, 'script', 'facebook-jssdk'));</script>");

            return oSBLikeGateway.ToString();
        }
        public string GetPrint(string sProductID, string sProductName, string sProductLogo, string sProductDescitpion, string AppID)
        {
            StringBuilder oSBShareButton = new StringBuilder();
            string _sAppPathLink = fbBiz.GetAppPagePath(AppID);
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
            string _sAppPathLink = fbBiz.GetAppPagePath(AppID);
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

        
    }
}