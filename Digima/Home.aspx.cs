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
    public partial class Home : System.Web.UI.Page
    {
        CanvasBizProcess canvBiz = null;
        AppCustomer oAppCust = null;
        protected Label lblLoginuser;
        protected HtmlTableCell tdSignup;
        protected HtmlTableCell tdLogin;
        protected HtmlTableCell tdBack;
        protected HtmlTableCell tdLogout;
        protected HtmlAnchor RegisterNew;
        CommonUtility objCommonUtil = new CommonUtility();


        protected void Page_PreInit(object sender, EventArgs e)
        {

        }


        protected void Page_Load(object sender, EventArgs e)
        {
            string username = "";
            string pwd = "";

            if (!Request.IsSecureConnection)
            {
                string redirectUrl = Request.Url.ToString().Replace("http:", "https:");
                Response.Redirect(redirectUrl);
            }


            if (!IsPostBack)
            {
                oAppCust = new AppCustomer();

                if (Request.QueryString["fp"] != null && Request.QueryString["fp"].Contains("1") ||
                     (Request.QueryString["nu"] != null && Request.QueryString["nu"].Contains("1")))
                {
                    if (Request.QueryString["fp"] != null && Request.QueryString["id"] != null)
                    {
                        if (Request.QueryString["fp"].Contains("1") && Request.QueryString["id"] != null)
                        {
                            lblLoginuser.Visible = true;
                            lblLoginuser.Text = "Reset Your Password by logging with the temprary password";
                        }
                    }
                }
                else
                {
                    if (Request["lo"] != null)
                    {
                        SessionData.Config = null;
                        SessionData.Product = null;
                        Session.Abandon();
                    }
                    if (SessionData.Customer != null)
                    {
                        if (Request["err"] != null)
                        {

                        }
                        if (Request["cp"] != null || Request["rp"] != null)//(SessionData.Customer.CustomerID.Equals(string.Empty) ||
                        {
                            //Need to login

                        }
                        else
                            if (Request["lp"] != null)
                            {
                                //Need to Logout User
                                Response.Redirect("Home.aspx", true);
                            }
                            else
                                if ((Request["sp"] != null) && (!SessionData.Customer.CustomerID.Equals(string.Empty)))
                                {
                                    //Need to Logout User

                                    RegisterNew.HRef = "LandingPage.aspx?CDID=" + SessionData.Customer.CustomerID;
                                }
                    }
                    else
                    {
                        //Need to login
                        tdLogin.Visible = true;
                        tdSignup.Visible = true;
                    }
                }
            }
        }

        protected void Page_Init(object Sender, EventArgs e)
        {
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.Cache.SetExpires(DateTime.Now.AddSeconds(-1));
            Response.Cache.SetNoStore();
        }
        protected void login_Click(object sender, EventArgs e)
        {
            try
            {
                if (HttpContext.Current.Session != null)
                {
                    string pwdencoded;
                    canvBiz = new CanvasBizProcess();
                    string un = txtemail.Text;
                    string pwd = txtpassword.Text;
                    EncryptionUtilities _oEncryptionUtilities = new EncryptionUtilities();
                    if (txtemail.Text.Contains(">") || txtemail.Text.Contains("<") || txtemail.Text.Contains("'") || txtemail.Text.Contains("--") || txtemail.Text.Contains("%") || txtpassword.Text.Contains(">") || txtpassword.Text.Contains("<") || txtpassword.Text.Contains("'") || txtpassword.Text.Contains("--") || txtpassword.Text.Contains("%"))
                    {
                        txtpassword.Text = "";
                        txtemail.Text = "";
                        loginBox.Style.Add("display", "block");
                        trError.Visible = true;
                    }
                    else
                    {
                        string password = txtpassword.Text;
                        string userName = txtemail.Text;
                        string encrypwd = string.Empty;
                        string cid = canvBiz.GetCustId(userName.TrimStart(' ').TrimEnd(' '));
                        Dictionary<string, string> lgnDetails = canvBiz.DoLogin(userName.TrimStart(' ').TrimEnd(' '), password.TrimStart(' ').TrimEnd(' '));

                        if (!lgnDetails["pass"].ToString().Equals("ERROR") && !cid.ToString().Equals("ERROR"))
                        {
                            pwdencoded = lgnDetails["pass"].ToString();
                            encrypwd = _oEncryptionUtilities.getEncryptedCode(password);

                            if (pwdencoded.Equals(encrypwd))
                            {
                                //Login SUCCESS, Now get customer details and assign to Session
                                SessionData.Customer = new AppCustomer();
                                SessionData.Customer = canvBiz.GetCustomerInfo(userName, cid, true);



                                if ((Request.QueryString["fp"] != null && !string.IsNullOrEmpty(Request["id"])) ||
                                   (Request.QueryString["nu"] != null && !string.IsNullOrEmpty(Request["id"])))
                                {
                                    if (Request.QueryString["fp"] != null)
                                    {
                                        if (Request.QueryString["fp"].Contains("1") && Request.QueryString["id"] != null)
                                        {

                                        }
                                    }
                                    else

                                        if (Request.QueryString["nu"].Contains("1") && Request.QueryString["id"] != null)
                                        {

                                        }
                                        else
                                        {

                                        }

                                }
                                else
                                {
                                    //Login is a SUCCESS so Enable content DIV 

                                    //*******************Now remove Login button, Add LOGOUT, WELCOME*******************

                                    //lblLoginuser.Visible = false;
                                    Response.Redirect("LandingPage.aspx?CDID=" + SessionData.Customer.CustomerID, false);
                                }
                            }
                            else
                            {
                                loginBox.Style.Add("display", "block");
                                trError.Visible = true;
                            }
                        }
                        else
                        {
                            loginBox.Style.Add("display", "block");
                            trError.Visible = true;
                            if ((txtemail.Text == string.Empty) && (txtpassword.Text == string.Empty))
                            {
                                lblError.Text = "Please provide both Username and Password to login";
                            }
                        }
                    }
                }
                else
                {
                    Response.Redirect("home.aspx");
                }
            }

            catch (Exception ex)
            {
                objCommonUtil.SendErrorMail(ex.Message, ex.StackTrace, System.Reflection.MethodBase.GetCurrentMethod().Name.ToString(), System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.ToString(), SessionData.Customer.CustomerID);
            }
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            if (SessionData.Customer.CustomerID.Equals(string.Empty))
            {
                // Force user to Login

            }
            else
            {
                Response.Redirect("LandingPage.aspx?CDID=" + SessionData.Customer.CustomerID);
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

        protected void home_click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("Info.aspx?CDID=" + SessionData.Customer.CustomerID);
        }

        protected void feature_click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("FeatureList.aspx?CDID=" + SessionData.Customer.CustomerID);
        }

        protected void faq_click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("FAQ.aspx?CDID=" + SessionData.Customer.CustomerID);
        }

        protected void contact_click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("Contact.aspx?CDID=" + SessionData.Customer.CustomerID);
        }

        protected void about_click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("AboutUs.aspx?CDID=" + SessionData.Customer.CustomerID);
        }

        protected void btnSignUp_Click(object sender, EventArgs e)
        {
            Response.Redirect("QuickRegister.aspx");
        }
    }
}