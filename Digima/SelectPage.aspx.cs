using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Net;
using System.Data;
using Newtonsoft;
using System.IO;
using Newtonsoft.Json.Linq;
using DigiMa.BizProcess;
using System.Text;
using System.Configuration;
using DigiMa.Common;
using System.Web.UI.WebControls;
using System.Diagnostics;

namespace DigiMa
{
    public partial class SelectPage : System.Web.UI.Page
    {
        DataSet dsPage = new DataSet();
        DataTable dtPage = new DataTable("Page");
        string appCode = string.Empty;
        string appID = string.Empty;
        string appSecret = string.Empty;
        private string ActiveURL;
        bool bEnableTwitter = false;

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    ActiveURL = ConfigurationSettings.AppSettings["ActiveURL"];
                    if (Request["app_id"] != null)
                    {
                        appID = Request["app_id"].ToString();
                    }
                    if (Request["code"] != null)
                    {
                        Dictionary<string, string> token = new Dictionary<string, string>();

                        //fetch secret key for app_id
                        FacebookBizProcess fbBiz = new FacebookBizProcess();
                        appSecret = fbBiz.GetAppSecret(appID);

                        token = GetAccessToken(Request["code"].ToString(), "manage_pages,publish_stream", ActiveURL + appID, appID, appSecret);

                        //Get List of Pages
                        FaceBook fb = new FaceBook();
                        string sPages = fb.GetPageAccessToken(token["access_token"].ToString());
                        SessionData.Config = fbBiz.GetAppConfiguration("", appID);
                        string pagetab = string.Empty;

                        DataColumn[] dcPage = new DataColumn[3];

                        dcPage[0] = new DataColumn("pid", System.Type.GetType("System.String"));
                        dtPage.Columns.Add(dcPage[0]);
                        dcPage[1] = new DataColumn("pname", System.Type.GetType("System.String"));
                        dtPage.Columns.Add(dcPage[1]);
                        dcPage[2] = new DataColumn("pacctoken", System.Type.GetType("System.String"));
                        dtPage.Columns.Add(dcPage[2]);

                        System.Web.Script.Serialization.JavaScriptSerializer _oJavaScriptSerializerJason = new System.Web.Script.Serialization.JavaScriptSerializer();
                        JObject objJason = JObject.Parse(sPages);
                        foreach (var i in objJason["data"].Children())
                        {
                            if ((i["category"].ToString().Replace("\"", "")) != "Application")
                            {
                                DataRow drPage = dtPage.NewRow();
                                drPage["pid"] = i["id"].ToString().Replace("\"", "");
                                drPage["pname"] = i["name"].ToString().Replace("\"", "");
                                drPage["pacctoken"] = i["access_token"].ToString().Replace("\"", "");
                                dtPage.Rows.Add(drPage);
                            }
                        }

                        dsPage.Tables.Add(dtPage);


                        //now bind all pages to drop down
                        if (dtPage.Rows.Count > 0)
                        {
                            foreach (DataRow dr in dtPage.Rows)
                            {
                                ddlPageSelect.Items.Add(new ListItem(dr["pname"].ToString(), dr["pacctoken"].ToString()));
                            }
                            Cache["PageDetails"] = dtPage;
                            ddlPageSelect.DataTextField = "pname";
                            ddlPageSelect.DataValueField = "pacctoken";
                        }
                        else
                        {
                            pageSelect.Visible = false;
                            noPageFound.Visible = true;
                            lblNoPage.Text = "You are not admin of any pages";
                        }
                    }
                }

                if (Request["Twitter"] != null)
                {
                    bEnableTwitter = true;
                    //litEnableTweet.Text = GetTwitterShareURL();
                }
            }
            catch (Exception ex)
            {
                CommonUtility commUtil = new CommonUtility();
                commUtil.SendErrorMail(ex.Message, ex.StackTrace, System.Reflection.MethodBase.GetCurrentMethod().Name.ToString(), System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.ToString(), SessionData.Customer.CustomerID);
            }
        }

        private Dictionary<string, string> GetAccessToken(string code, string scope, string redirectUrl, string appID, string appSecret)
        {
            string url = string.Empty;
            try
            {
                Dictionary<string, string> tokens = new Dictionary<string, string>();
                string clientId = appID;
                string clientSecret = appSecret;
                url = string.Format("https://graph.facebook.com/oauth/access_token?client_id=" + appID + "&redirect_uri=" + redirectUrl + "&client_secret=" + appSecret + "&code=" + code + "&scope=" + scope,
                                clientId, redirectUrl, clientSecret, code, scope);
                HttpWebRequest request = WebRequest.Create(url) as HttpWebRequest;
                using (HttpWebResponse response = request.GetResponse() as HttpWebResponse)
                {
                    StreamReader reader = new StreamReader(response.GetResponseStream());
                    string retVal = reader.ReadToEnd();

                    foreach (string token in retVal.Split('&'))
                    {
                        tokens.Add(token.Substring(0, token.IndexOf("=")),
                            token.Substring(token.IndexOf("=") + 1, token.Length - token.IndexOf("=") - 1));
                    }
                }
                return tokens;
            }
            catch (Exception ex)
            {
                CommonUtility commUtil = new CommonUtility();
                commUtil.SendErrorMail(ex.Message, ex.StackTrace, System.Reflection.MethodBase.GetCurrentMethod().Name.ToString(), System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.ToString(), SessionData.Customer.CustomerID);
            }

            return GetAccessToken(code, scope, redirectUrl, appID, appSecret);
        }

        protected void btnPageSelect_Click(object sender, EventArgs e)
        {

            try
            {


                DataTable dtNewPages = new DataTable();
                DataColumn[] dcPage = new DataColumn[3];

                dcPage[0] = new DataColumn("pid", System.Type.GetType("System.String"));
                dtNewPages.Columns.Add(dcPage[0]);
                dcPage[1] = new DataColumn("pname", System.Type.GetType("System.String"));
                dtNewPages.Columns.Add(dcPage[1]);
                dcPage[2] = new DataColumn("pacctoken", System.Type.GetType("System.String"));
                dtNewPages.Columns.Add(dcPage[2]);

                dtNewPages = (DataTable)(Cache["PageDetails"]);


                DataView dv;
                dv = new DataView((DataTable)(Cache["PageDetails"]));
                dv.RowFilter = "pname= '" + ddlPageSelect.SelectedItem.ToString() + "'";


                //fetch the custom tab name 
                FacebookBizProcess fbBiz = new FacebookBizProcess();
                string custTabName = fbBiz.GetCustomTabName(SessionData.Config.AppID);
                StringBuilder _sbPostToWallPostData = new StringBuilder();
                _sbPostToWallPostData.Append("custom_name=" + custTabName);


                string pagetab = "https://graph.facebook.com/" + dv[0]["pid"].ToString().Replace("\"", "") + "/tabs?method=POST&app_id=" + SessionData.Config.AppID + "&access_token=" + ddlPageSelect.SelectedValue.ToString().Replace("\"", "");
                FaceBook fabo = new FaceBook();
                fabo.CallWebRequest("POST", pagetab, _sbPostToWallPostData.ToString());


                //generate URL for page tab
                //string pageName = CallPageTabs(dv[0]["pid"].ToString());
                StringBuilder oSBAppPath = new StringBuilder();
                oSBAppPath.Append("https://www.facebook.com/pages/");
                oSBAppPath.Append(ddlPageSelect.SelectedItem.ToString() + "/");
                oSBAppPath.Append(dv[0]["pid"].ToString() + "/");
                oSBAppPath.Append("?sk=app_" + SessionData.Config.AppID);
                lblResult.Text = "Campaign uploaded. Click";

                if (SessionData.UserAction.TaskComplete.Equals("M"))
                {
                    lblInformation.Text = "Your Microsite has been processed ! Please find the details in your Email inbox.";
                }
                else if (SessionData.UserAction.TaskComplete.Equals("Y"))
                {
                    lblInformation.Text = "Your Microsite has been processed ! Please find the details in your Email inbox.";
                }
                else
                {
                    lblInformation.Text = string.Empty;
                }
                fbBiz.UpdateAppPagePath(oSBAppPath.ToString(), SessionData.Config.AppID, dv[0]["pid"].ToString());
                linkToCamp.HRef = oSBAppPath.ToString();
                tblPageSelect.Visible = false;
                tblResult.Visible = true;
                if (bEnableTwitter == true)
                {
                    tblTweet.Visible = true;
                }
                //Response.Redirect("CanvasArea.aspx?CDID=" + SessionData.Customer.CustomerID+"&pageSelected=T&TID=0",true);

            }
            catch (Exception ex)
            {

                CommonUtility commUtil = new CommonUtility();
                commUtil.SendErrorMail(ex.Message, ex.StackTrace, System.Reflection.MethodBase.GetCurrentMethod().Name.ToString(), System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.ToString(), SessionData.Customer.CustomerID);

            }
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

        protected void btnTweet_Click(object sender, EventArgs e)
        {
            string ADID = SessionData.Product.AppConfigDID;
            string app_id = SessionData.Config.AppID;
            string PDID = SessionData.Product.DID;

            //Auth User to get Twitter Details
            Twitter otittwr = new Twitter();
            string AuthTwitter = otittwr.GetTwitterAuthURL(ADID, app_id, PDID);
            ScriptManager.RegisterStartupScript(this, typeof(string), "OPEN_WINDOW", "var Mleft = (screen.width/2)-(760/2);var Mtop = (screen.height/2)-(700/2);window.open( '" + AuthTwitter + "', null, 'height=700,width=760,status=yes,toolbar=no,scrollbars=yes,menubar=no,location=no,top=\'+Mtop+\', left=\'+Mleft+\'' );", true);
            //Response.Redirect(otittwr.GetTwitterAuthURL());



        }

    }//EOC
}//EONs