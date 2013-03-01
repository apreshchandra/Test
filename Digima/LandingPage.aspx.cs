using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using DigiMa.Data;
using System.Web.Services;
using DigiMa.Common;
using System.Net.Mail;
using System.Net;
using DigiMa.BizProcess;
using System.IO;
using System.Text;
using System.Web.Security;


namespace DigiMa
{
    public partial class LandingPage : System.Web.UI.Page
    {
        string username = "";
        string pwd = "";
        static bool isLoggedIN;
        string id = "";

        protected TextBox txtemail;
        protected TextBox txtpassword;
        protected HtmlContainerControl loginBox;
        protected HtmlContainerControl diverrorlabel;
        protected HtmlContainerControl divContainerMain;
        protected HtmlContainerControl loginForm;
        protected Label lblError;
        protected Button login;
        protected HtmlGenericControl username_warning;
        protected HtmlGenericControl password_warning;
        protected HtmlSelect ddlApresh;
        CanvasBizProcess canvBiz = null;
        AppCustomer oAppCust = null;
        protected HtmlInputCheckBox checkbox;
        protected TextBox txtpasswordnew;
        protected TextBox txtpasswordsec;
        protected HtmlContainerControl newFrm;
        protected HtmlContainerControl Div1;
        protected HtmlAnchor signup;
        protected LinkButton logout;
        protected Literal litLogin;
        protected HtmlContainerControl divLandingContent;
        protected HtmlContainerControl AllDioo;
        protected HtmlContainerControl PromotionsDioo;
        protected HtmlContainerControl VideoShareDioo;
        protected HtmlContainerControl SweepDioo;
        protected HtmlContainerControl ContestDioo;
        protected HtmlContainerControl DealsDioo;
        protected HtmlContainerControl GrDealsDioo;
        protected HtmlContainerControl CouponsDioo;
        protected HtmlContainerControl spnUserInfo;
        protected HtmlAnchor anchorContactUs;
        FacebookBizProcess fbBiz = new FacebookBizProcess();


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (SessionData.Customer.CustomerID.Equals(string.Empty))
                {
                    Response.Redirect("Home.aspx");
                }
                else
                {
                    //load Customer grid for Analytics
                    canvBiz = new CanvasBizProcess();
                    grdAnalytics.DataSource = canvBiz.FetchConfigDataForLoggedInUser(SessionData.Customer.CustomerID);
                    grdAnalytics.DataBind();
                }
            }
        }

        protected void Page_Init(object Sender, EventArgs e)
        {
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.Cache.SetExpires(DateTime.Now.AddSeconds(-1));
            Response.Cache.SetNoStore();
        }

        //protected void IMGca_Click(object sender, ImageClickEventArgs e)
        //{
        //    if (fbBiz.IsAppCreationAllowed(SessionData.Customer.CustomerID))
        //    {
        //        Response.Redirect("CanvasAreaPromoTwo.aspx?CDID=" + SessionData.Customer.CustomerID);
        //    }
        //    else
        //    {
        //        Page.ClientScript.RegisterStartupScript(this.GetType(), "myCloseScript", "alert(\"You can only create 3 Campaigns with a Trial Account ! Contact sales@smnetserv.com for more details.\")", true);
        //    }
        //}

        //protected void imgSweepstakes_Click(object sender, ImageClickEventArgs e)
        //{
        //    if (fbBiz.IsAppCreationAllowed(SessionData.Customer.CustomerID))
        //    {
        //        Response.Redirect("CanvasAreaSweepstakes.aspx?CDID=" + SessionData.Customer.CustomerID + "&TID=4");
        //    }
        //    else
        //    {
        //        Page.ClientScript.RegisterStartupScript(this.GetType(), "myCloseScript", "alert(\"You can only create 3 Campaigns with a Trial Account ! Contact sales@smnetserv.com for more details.\")", true);
        //    }
        //}

        protected void logout_Click(object sender, EventArgs e)
        {
            Session.Abandon();
            Response.Redirect("~/LandingPage.aspx");
        }

        protected void promo1_Click(object sender, ImageClickEventArgs e)
        {
            //TemplateID=3
            if (fbBiz.IsAppCreationAllowed(SessionData.Customer.CustomerID))
            {
                Response.Redirect("CanvasAreaPromoOne.aspx?CDID=" + SessionData.Customer.CustomerID + "&TID=3");
            }
            else
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "myCloseScript", "alert(\"You can only create 3 Campaigns with a Trial Account ! Contact sales@smnetserv.com for more details.\")", true);
            }
        }
        protected void sweep1_Click(object sender, ImageClickEventArgs e)
        {
            if (fbBiz.IsAppCreationAllowed(SessionData.Customer.CustomerID))
            {
                Response.Redirect("CanvasAreaSweepstakes.aspx?CDID=" + SessionData.Customer.CustomerID + "&TID=4");
            }
            else
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "myCloseScript", "alert(\"You can only create 3 Campaigns with a Trial Account ! Contact Us for more details.\")", true);
            }
        }

        protected void Coupon_Click(object sender, ImageClickEventArgs e)
        {
            if (fbBiz.IsAppCreationAllowed(SessionData.Customer.CustomerID))
            {
                Response.Redirect("CanvasAreaCoupon.aspx?CDID=" + SessionData.Customer.CustomerID + "&TID=7");
            }
            else
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "myCloseScript", "alert(\"You can only create 3 Campaigns with a Trial Account ! Contact Us for more details.\")", true);
            }
        }

        protected void GridView_RowCommand(Object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName.Equals("Analytics")) //Analytics
            {
                FacebookBizProcess fbBiz = new FacebookBizProcess();
                Response.Redirect("Analytics/SonetReachAnalyticsMain.aspx?CustomerName=" + SessionData.Customer.SCustomerUserName + "&Appname=" + fbBiz.GetAppName(e.CommandArgument.ToString()));
            }
            else //Edit a Campaign
            {
                //Determine type of Campaign- TemplatePage
                FacebookBizProcess fbBiz = new FacebookBizProcess();

                string templatePageToCall = string.Empty;
                string appName = fbBiz.GetAppName(e.CommandArgument.ToString());
                templatePageToCall = fbBiz.GetTemplatePage(appName);

                Response.Redirect(templatePageToCall + "?CustomerName=" + SessionData.Customer.SCustomerUserName + "&Appname=" + appName + "&Maint=T");
            }
        }

        protected void loginButton_Click(object sender, EventArgs e)
        {
            //Logout

            SessionData.Customer = null;
            Session.Abandon();
            Response.Redirect("Home.aspx");
        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            SessionData.Customer = null;
            SessionData.Config = null;
            SessionData.Product = null;

            Session.Abandon();
            Response.Redirect("Home.aspx");
        }

        protected void btnCreationCentral_Click(object sender, EventArgs e)
        {
            //Navigate to Creation Central
            Response.Redirect("SiteCreation.aspx?CDID=" + SessionData.Customer.CustomerID, false);
        }
    }


}
