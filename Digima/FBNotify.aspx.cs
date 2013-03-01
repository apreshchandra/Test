using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DigiMa.Data;
using DigiMa.BizProcess;
using DigiMa.Common;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DigiMa
{
    public partial class FBNotify : DigiMa.sNBBPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected override void OnInit(EventArgs e)
        {
            EnableAppUser = true;
            base.OnInit(e);
        }

        protected override void OnPreLoad(EventArgs e)
        {
            string PDID = string.Empty;
            string NDID = string.Empty;
            string ADID = string.Empty;
            string UDID = string.Empty;
            string NTYP = string.Empty;
            string user_id = string.Empty;
            string TO_id = string.Empty;
            try
            {
                base.OnPreLoad(e);
                //Initialize KOKO
                SonetPie osonetpie = new SonetPie();
                osonetpie.QSvarsString = GetQsVarsCollection();
                osonetpie.AbsolutePath = AbsolutePagePath;

                //Call Service to load app settings
                AppUser oAppUser = new AppUser();
                AppLeadData oAppLead = new AppLeadData();
                FacebookBizProcess ofbBiz = new FacebookBizProcess();
                SonetPieBizProcess sonetpiebiz = new SonetPieBizProcess();

                //CHeck if User has Liked. Using Jquery AJAX we will get Params in Request.Form
                if (Request.HttpMethod == "POST")
                {
                    PDID = Request.Form["PDID"];
                    NDID = Request.Form["NDID"];
                    ADID = Request.Form["ADID"];
                    UDID = Request.Form["UDID"];
                    NTYP = Request.Form["NTYP"];
                    user_id = Request.Form["user_id"];

                    oAppUser = ofbBiz.GetAppUser(osonetpie, ADID, user_id);

                    if (NTYP != null && UDID != null && PDID != null)
                    {
                        if (ofbBiz.RaiseAppNotifier(oAppUser, NTYP, UDID, PDID, NDID, oAppLead, string.Empty))
                            litRunTimeHTMLContent.Text = "Successfully raised notifier.";
                        else
                            litRunTimeHTMLContent.Text = "Unable to raise notifier.";
                    }
                    else litRunTimeHTMLContent.Text = "In-Complete information.";
                }
                else
                {
                    if (QSVars["NTYP"].ToString().Equals("MPOST"))
                    {
                        if (!QSVars.Contains("UDID"))
                        {
                            UDID = ofbBiz.GetUserDID(QSVars["ADID"].ToString(), Request["userID"].ToString());
                            if (Request.Cookies.AllKeys[0] != null)
                            {
                                TO_id = Request.Cookies.AllKeys[0];
                                if (TO_id.Contains(","))
                                {
                                    string[] allFriends = TO_id.Split(',');
                                    for (int i = 0; i < allFriends.Length; i++)
                                    {
                                        if (ofbBiz.RaiseAppNotifier(oAppUser, Convert.ToString(QSVars["NTYP"]), UDID, Convert.ToString(QSVars["PDID"]), "", oAppLead, allFriends[i]))
                                            litRunTimeHTMLContent.Text = "Successfully raised notifier.";
                                        else
                                            litRunTimeHTMLContent.Text = "Unable to raise notifier.";
                                    }
                                }
                                else
                                {
                                    if (ofbBiz.RaiseAppNotifier(oAppUser, Convert.ToString(QSVars["NTYP"]), UDID, Convert.ToString(QSVars["PDID"]), "", oAppLead, TO_id))
                                        litRunTimeHTMLContent.Text = "Successfully raised notifier.";
                                    else
                                        litRunTimeHTMLContent.Text = "Unable to raise notifier.";
                                }
                            }
                        }

                        if (ofbBiz.RaiseAppNotifier(oAppUser, Convert.ToString(QSVars["NTYP"]), UDID, Convert.ToString(QSVars["PDID"]), "", oAppLead, TO_id))
                            litRunTimeHTMLContent.Text = "Successfully raised notifier.";
                        else
                            litRunTimeHTMLContent.Text = "Unable to raise notifier.";

                    }
                    else
                    {
                        bool CheckLikeNotify = ofbBiz.CheckLikeNotify(QSVars["UDID"].ToString());
                        if (CheckLikeNotify != true)
                        {
                            oAppUser = ofbBiz.GetAppUser(osonetpie, QSVars["ADID"].ToString(), QSVars["user_id"].ToString());

                            //Load AppUser from DB Based on user_id
                            if (QSVars.Contains("NTYP") && QSVars.Contains("UDID") && QSVars.Contains("PDID"))
                            {
                                if (ofbBiz.RaiseAppNotifier(oAppUser, Convert.ToString(QSVars["NTYP"]), Convert.ToString(QSVars["UDID"]), Convert.ToString(QSVars["PDID"]), Convert.ToString(QSVars["NDID"]), oAppLead, string.Empty))
                                    litRunTimeHTMLContent.Text = "Successfully raised notifier.";
                                else
                                    litRunTimeHTMLContent.Text = "Unable to raise notifier.";
                            }
                            else litRunTimeHTMLContent.Text = "In-Complete information.";
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                DigiMa.Common.CommonUtility objCommon = new CommonUtility();
                objCommon.SendErrorMail(ex.Message, ex.StackTrace, System.Reflection.MethodBase.GetCurrentMethod().Name.ToString(), System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.ToString(), "");
            }
        }
    }//EOC
}//EONs