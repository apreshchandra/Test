using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DigiMa.Common;
using DigiMa.Data;
using DigiMa.BizProcess;
using System.Text;
using System.Configuration;

namespace DigiMa
{
    public partial class MobileRedirect : DigiMa.sNBBPMobile
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
        private const string TRUE = "Y";
        private static string VALUE = "N";
        string NotifyURL;

        int PageStatus = 1;
        SonetPie osonetpie = new SonetPie();
        AppUser oDCAppUser = new AppUser();
        CanvasBizProcess canv = new CanvasBizProcess();
        FacebookBizProcess fbBiz = new FacebookBizProcess();
        AppLeadData oAppLead = new AppLeadData();

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                btnRefresh.Click += new EventHandler(btnRefresh_Click);
                litEnableFBJS.Text = GetInitializedJS();
                litOGTags.Text = GetOGMetaTags();
                string access_token = hdnAuthToken.Value;
                string signedrequest = hdnSignedRequest.Value;
                string userid = hdnUserID.Value;
                string Liked = hdnLike.Value;


                NotifyURL = ConfigurationSettings.AppSettings["NotifyURL"];

                if (Request.UrlReferrer != null)
                {
                    if (Request.UrlReferrer.Query.Length > 5 && Request.UrlReferrer.Query.Contains("NTYP"))
                    {
                        //notification happened
                        string fullRef = Request.UrlReferrer.Query.ToString();
                        string[] fragment = fullRef.Split('&');

                        string ShareCheck = fragment[1].ToString();
                        string[] ShareCheckSpilt = ShareCheck.Split('=');
                        string IsShare = ShareCheckSpilt[1].ToString(); //USE this value


                        string ProdDID = fragment[2].ToString();
                        string[] ProdDIDSplit = ProdDID.Split('=');
                        string ISPDID = ProdDIDSplit[1].ToString();


                        string NotDID = fragment[3].ToString();
                        string[] NotIDSplit = NotDID.Split('=');
                        string IsNOTIFDID = NotIDSplit[1].ToString();


                        string FBUserID = fragment[4].ToString();
                        string[] FBUserIDSplit = FBUserID.Split('=');
                        if (FBUserIDSplit.Length > 1)
                        {
                            oDCAppUser.SonetID = FBUserIDSplit[1].ToString();
                            Session["SonetID"] = oDCAppUser.SonetID;
                        }

                        //get UserDID
                        string ConfigDID = fbBiz.GetConfigDEED(Convert.ToString(Request["app_id"].ToString())); string UDID;
                        if (string.IsNullOrEmpty(oDCAppUser.SonetID))
                        {
                            UDID = fbBiz.GetUserDID(ConfigDID, Session["SonetID"].ToString());
                        }
                        else
                        {
                            UDID = fbBiz.GetUserDID(ConfigDID, oDCAppUser.SonetID);
                        }

                        //Now Send Notifier to DB
                        if (fbBiz.RaiseAppNotifier(oDCAppUser, IsShare, UDID, ISPDID, IsNOTIFDID, oAppLead, string.Empty))
                        {
                            //do something

                        }
                    }
                    else
                    {
                        if (Request.QueryString["app_id"] != null)
                        {
                            if (!string.IsNullOrEmpty(access_token) || !string.IsNullOrEmpty(userid))
                            {
                                Response.Redirect(NotifyURL + "SonetReachPDA.aspx?acc_tok=" + access_token + "&uID=" + userid + "&app_id=" + Convert.ToString(Request["app_id"]),false);
                            }

                        }
                    }
                }

                else
                {
                    if (Request.QueryString["app_id"] != null)
                    {
                        if (!string.IsNullOrEmpty(access_token) || !string.IsNullOrEmpty(userid))
                        {
                            Response.Redirect(NotifyURL + "SonetReachPDA.aspx?acc_tok=" + access_token + "&uID=" + userid + "&app_id=" + Convert.ToString(Request["app_id"]),false);
                        }
                    }
                }


            }
            catch (Exception ex)
            {
                CommonUtility commUtil = new CommonUtility();
                commUtil.SendErrorMail(ex.Message, ex.StackTrace, System.Reflection.MethodBase.GetCurrentMethod().Name.ToString(), System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.ToString(), SessionData.Customer.CustomerID);
            }

        }

        void btnRefresh_Click(object sender, EventArgs e)
        {
            string values = hdnAuthToken.Value;
        }
        private void Page_PreRender(object sender, System.EventArgs e)
        {

        }

        private string GetOGMetaTags()
        {
            FacebookBizProcess fbBizProc = new FacebookBizProcess();
            StringBuilder sbOGTags = new StringBuilder();
            sbOGTags.Append("<meta property=\"fb:app_id\" content=\"" + Convert.ToString(Request["app_id"]) + "\" />" + Environment.NewLine);
            sbOGTags.Append("<meta property=\"og:type\" content=\"website\" />" + Environment.NewLine);
            sbOGTags.Append("<meta property=\"og:title\" content=\"Welocme to Sonetreach\" />" + Environment.NewLine);
            sbOGTags.Append("<meta property=\"og:image\" content=\"https://www.sonetreach.com/images/sonet_watermark.png\" />" + Environment.NewLine);
            sbOGTags.Append("<meta property=\"og:description\" content=\"Social Media Marketing Software\" />" + Environment.NewLine);
            sbOGTags.Append("<meta property=\"og:url\" content=\"" + fbBizProc.GetAppPath(Convert.ToString(Request["app_id"])) + "\">" + Environment.NewLine);
            sbOGTags.Append("<meta property=\"fb:admins\" content=\"\" />" + Environment.NewLine);
            sbOGTags.Append(" <script src=\"https://ajax.googleapis.com/ajax/libs/jquery/1.6.1/jquery.min.js\"></script>" + Environment.NewLine);
            sbOGTags.Append("<script src=\"https://connect.facebook.net/en_US/all.js#appId=" + Convert.ToString(Request["app_id"]) + "&amp;xfbml=1\"></script>" + Environment.NewLine);
            return sbOGTags.ToString();
        }


        protected string GetInitializedJS()
        {
            FacebookBizProcess _fbBiz = new FacebookBizProcess();

            if (true)//REVISIT
            {
                StringBuilder oFBJSBuilder = new StringBuilder();
                ////Intitialize FBJS for widgets on page load            

                oFBJSBuilder.Append("FB.init({");
                oFBJSBuilder.Append("appId: '" + Convert.ToString(Request["app_id"]) + "',");
                oFBJSBuilder.Append("xfbml: true,");
                oFBJSBuilder.Append("status: true,");
                oFBJSBuilder.Append(" cookie: true");
                oFBJSBuilder.Append("});");

                return oFBJSBuilder.ToString();
            }
            else
            {
                return string.Empty;
            }
        }
    }
}