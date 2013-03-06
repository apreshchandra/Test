using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using DigiMa.Common;
using DigiMa.BizProcess;
using System.Web.UI.WebControls;
using DigiMa.Data;

namespace DigiMa
{
    public partial class CreationCentral : System.Web.UI.Page
    {
        FacebookBizProcess fbBiz = new FacebookBizProcess();
        private AppCustomer _oDCAppCustomer;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (SessionData.Customer.CustomerID.Equals(string.Empty))
                {
                    //Response.Redirect("Home.aspx");

                    //*************SARANYA
                    //bind the dropdown to PReferenceMAster table.
                }
                else
                {
                    //Enable Promos on basis of DB value

                    AppCustomer oAppCustomer = new AppCustomer();
                    string CustId = SessionData.Customer.CustomerID;
                    oAppCustomer = fbBiz.GetAppCustomer(CustId);
                    string iscoupon = oAppCustomer.IsCoupon.ToString();
                    string issweep = oAppCustomer.IsSweepStakes.ToString();

                    // If Coupon = 1, enable for user 
                    

                }
            }
        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            SessionData.Customer = null;
            SessionData.Config = null;
            SessionData.Product = null;

            Session.Abandon();
            Response.Redirect("Home.aspx");
        }

        protected void imgPromo_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                if (fbBiz.IsAppCreationAllowed(SessionData.Customer.CustomerID))
                {
                    Response.Redirect("CanvasAreaPromoTwo.aspx?CDID=" + SessionData.Customer.CustomerID + "&TID=5", false);
                }
                else
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "myCloseScript", "alert(\"You have used up 4 free Campaigns OR your trial period has expired! Please contact sales@smnetserv.com\")", true);
                }
            }
            catch (Exception ex)
            {
                DigiMa.Common.CommonUtility objCommon = new CommonUtility();
                objCommon.SendErrorMail(ex.Message, ex.StackTrace, System.Reflection.MethodBase.GetCurrentMethod().Name.ToString(), System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.ToString(), SessionData.Customer.CustomerID);

            }
        }

        protected void imgSweep_Click(object sender, ImageClickEventArgs e)
        {
            if (fbBiz.IsAppCreationAllowed(SessionData.Customer.CustomerID))
            {
                Response.Redirect("CanvasAreaSweepstakes.aspx?CDID=" + SessionData.Customer.CustomerID + "&TID=4");
            }
            else
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "myCloseScript", "alert(\"You have used up 4 free Campaigns OR your trial period has expired!\")", true);
            }
        }

        protected void imgCoupon_Click(object sender, ImageClickEventArgs e)
        {
            if (fbBiz.IsAppCreationAllowed(SessionData.Customer.CustomerID))
            {
                Response.Redirect("CanvasAreaCoupon.aspx?CDID=" + SessionData.Customer.CustomerID + "&TID=7");
            }
            else
            {
                //***COMMENTING as Coupon and Sweep are only available for CASH
                Page.ClientScript.RegisterStartupScript(this.GetType(), "myCloseScript", "alert(\"You have used up 4 free Campaigns OR your trial period has expired!\")", true);
            }
        }

        protected void imgVidShare_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                if (fbBiz.IsAppCreationAllowed(SessionData.Customer.CustomerID))
                {
                    Response.Redirect("CanvasAreaPromoVideo.aspx?CDID=" + SessionData.Customer.CustomerID + "&TID=6", false);
                }
                else
                {
                    //***COMMENTING as Coupon and Sweep are only available for CASH
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "myCloseScript", "alert(\"You have used up 4 free Campaigns OR your trial period has expired! Please contact sales@smnetserv.com\")", true);
                }
            }
            catch (Exception ex)
            {
                DigiMa.Common.CommonUtility objCommon = new CommonUtility();
                objCommon.SendErrorMail(ex.Message, ex.StackTrace, System.Reflection.MethodBase.GetCurrentMethod().Name.ToString(), System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.ToString(), SessionData.Customer.CustomerID);

            }
        }

        protected void btnCreate_Click(object sender, EventArgs e)
        {
            int count=0;

            //get the id of chosen element from Dropdwonlist

            //ASSUMPTION
            //id we get is 6

            //fetch PReference data for id 6
            CanvasBizProcess canvBiz = new CanvasBizProcess();
            SessionData.PrefData  = new PreferenceData();
            SessionData.PrefData = canvBiz.GetPReferenceDataForUserPreference("6"); //REMOVE HARDCODE

            if (SessionData.PrefData.TaskOne1.Equals("F"))
            {
                //make user chose templates , edit templates and publish to Facebook
                SessionData.PrefData.CurrentTask1 = "F";
                Response.Redirect("SiteCreation.aspx?CDID=" + SessionData.Customer.CustomerID + "&TID=6", false);
            }
            else if(SessionData.PrefData.TaskOne1.Equals("Y"))
            {
                //only Youtube
            }

        }
    }
}