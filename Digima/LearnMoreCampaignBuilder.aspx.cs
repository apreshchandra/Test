using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DigiMa.Data;
using System.Web.UI;
using DigiMa.BizProcess;
using System.Web.UI.WebControls;
using DigiMa.Common;

namespace DigiMa
{
    public partial class LearnMoreCampaignBuilder : System.Web.UI.Page
    {
        CanvasBizProcess canvBiz = null;

        protected void Page_Load(object sender, EventArgs e)
        {

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
                //objCommonUtil.SendErrorMail(ex.Message, ex.StackTrace, System.Reflection.MethodBase.GetCurrentMethod().Name.ToString(), System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.ToString(), SessionData.Customer.CustomerID);

            }
        }
    }
}