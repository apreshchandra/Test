using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using DigiMa.Data;
using DigiMa.Common;
using DigiMa.BizProcess;
using System.Net.Mail;
using System.Text;

namespace DigiMa
{
    public partial class Register : System.Web.UI.Page
    {
        bool flag = false;
        CanvasBizProcess canvBiz = null;
        EncryptionUtilities _oEncryptionUtilities = new EncryptionUtilities();
        CommonUtility objCommonUtil = new CommonUtility();
        //private static log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Getcountrytobind();
                this.Session["CaptchaImageText"] = GenerateRandomCode();
                errorlblsecurity.Style.Add("display", "none");
            }
            else
            {
                errorlblsecurity.Style.Add("display", "none");
                if (!CodeNumberTextBox.Text.Trim().Equals(string.Empty))
                {
                    // On a postback, check the user input.
                    if (this.CodeNumberTextBox.Text == this.Session["CaptchaImageText"].ToString())
                    {
                        flag = true;
                    }
                    else
                    {
                        createnewcaptcha();
                    }
                }
            }
        }

        private void Getcountrytobind()
        {
            CanvasBizProcess canvBiz = new CanvasBizProcess();
            DataSet dsCountryList = canvBiz.GetCountryList();
            ddlCountry.DataSource = dsCountryList;
            ddlCountry.DataTextField = "countryname";
            ddlCountry.DataValueField = "countryid";
            ddlCountry.DataBind();
            ddlCountry.Items.Insert(0, new ListItem("Select Country", ""));
            ViewState["countrylist"] = dsCountryList;
        }

        private string GenerateRandomCode()
        {
            int size = 6;
            try
            {
                char[] cr = "0123456789abcdefghijklmnopqrstuvwxyz".ToCharArray();
                string result = string.Empty;
                Random r = new Random();
                for (int i = 0; i < size; i++)
                {
                    result += cr[r.Next(0, cr.Length - 1)].ToString();
                }
                return result;
            }
            catch (Exception ex)
            {
                objCommonUtil.SendErrorMail(ex.Message, ex.StackTrace, System.Reflection.MethodBase.GetCurrentMethod().Name.ToString(), System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.ToString(), SessionData.Customer.CustomerID);
            }
            return string.Empty;
        }

        private void createnewcaptcha()
        {
            this.Session["CaptchaImageText"] = GenerateRandomCode();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            CanvasBizProcess canvBiz = new CanvasBizProcess();
            try
            {
                if (txtEmailid.Text.Contains(">") || txtEmailid.Text.Contains("<") || txtEmailid.Text.Contains("'") || txtEmailid.Text.Contains("--") || txtEmailid.Text.Contains("%"))
                {
                    txtEmailid.Text = "";
                }
                else
                {
                    string temppass = "tempPass";
                    AppCustomer oAppCustomer = new AppCustomer();
                    oAppCustomer.CustomerID = oAppCustomer.GetNewDIDWithPrefix();
                    oAppCustomer.SCompanyName = txtOrganization.Text.Trim();
                    oAppCustomer.SCustomerCountry = Convert.ToInt32(ddlCountry.SelectedValue);
                    oAppCustomer.SCustomerEmail = txtEmailid.Text.Trim();
                    oAppCustomer.SCustomerPWD = temppass;
                    oAppCustomer.SCustomerStatus = "1"; //Remove hardcoding
                    oAppCustomer.SCustomerUserName = txtFullName.Text.Trim();
                    oAppCustomer.SfpStatus = "0";
                    oAppCustomer.SAddress = txtAddress.Text.Trim();

                    //Check if Privacy policy check-box is checked
                    if (flag)
                    {
                        if (checkTC.Checked == true)
                        {
                            canvBiz.InsertNewCustomer(oAppCustomer);

                            int mailstatus = MailTrigger(txtEmailid.Text);
                            if (mailstatus == 1)
                            {
                                string script = "alert('A verification Email has been sent to you.');" + "location.href='Home.aspx?';";
                                this.ClientScript.RegisterStartupScript(typeof(Page), "Redirect", script, true);
                            }
                        }
                        else
                        {
                            string script = "alert('Kindly accept the T&C and Privacy Policy')";
                            this.ClientScript.RegisterStartupScript(typeof(Page), "Redirect", script, true);
                            CodeNumberTextBox.Text = "";
                            this.Session["CaptchaImageText"] = GenerateRandomCode();
                        }

                    }
                    else
                    {
                        CodeNumberTextBox.Text = "";
                        errorlblsecurity.Style.Add("display", "block");
                        StringBuilder sErrorMsg = new StringBuilder();
                        sErrorMsg.Append("The Characters Don't Match.</br>");
                        sErrorMsg.Append("Please Try Again.");
                        errorlblsecurity.Text = sErrorMsg.ToString();
                        CodeNumberTextBox.Focus();
                        this.Session["CaptchaImageText"] = GenerateRandomCode();
                    }
                }
            }
            catch (Exception ex)
            {
                objCommonUtil.SendErrorMail(ex.Message, ex.StackTrace, System.Reflection.MethodBase.GetCurrentMethod().Name.ToString(), System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.ToString(), SessionData.Customer.CustomerID);
            }
        }

        private int MailTrigger(string txtEmailid)
        {
            try
            {
                canvBiz = new CanvasBizProcess();
                string uid = canvBiz.GetCustId(txtEmailid);
                AppCustomer oAppCustomer = new AppCustomer();
                oAppCustomer = canvBiz.GetCustomerInfo(txtEmailid, uid, false);
                MailMessage mail = new MailMessage();
                //string adminid = txtmailid;
                string adminid = "support@sonetreach.com";//ConfigurationManager.AppSettings["usermailid"];
                string admpass = "S0netsupp0rt";// ConfigurationManager.AppSettings["userpassword"];
                System.Net.NetworkCredential auth = new System.Net.NetworkCredential(adminid, admpass);
                mail.From = new MailAddress(adminid);//TODO: Put actual sender email address
                mail.To.Add(new MailAddress(txtEmailid));
                mail.Subject = "Welcome to SonetReach!";    // Mail Subject
                mail.IsBodyHtml = true;
                mail.Priority = MailPriority.High; //Mail Priority

                StringBuilder strBody = new StringBuilder();

                strBody.Append("<div><center><table border=\"2px black\" width=\"800px\" style=\"height:200px;\">");
                strBody.Append("<tr><td style=\"background-color: #8BCD98; height: 40px; width: 400px;\">");
                strBody.Append("<center><span style=\"color: #0D6DA0; font-family: Verdana; font-size: large;\">");
                strBody.Append("SONETREACH");
                strBody.Append("</span></center></td></tr><tr><td>");
                strBody.Append("<span style=\"font-family: Verdana;\">");
                strBody.Append("<br/>");
                strBody.Append("Hello");
                strBody.Append("<br>");
                strBody.Append("<br>");
                strBody.Append("Thank you for registering with SONETREACH .To complete registration, Please follow this link.<br /><br/>");

                strBody.Append("https://www.testsonetreach.com/Confirmation.aspx?nu=1&id=" + HttpUtility.UrlEncode(CommonUtility.Encrypt(uid)) + "");
                strBody.Append("<br><br>");
                strBody.Append("User Name: &nbsp;");
                strBody.Append(txtEmailid);
                strBody.Append("<br><br><br>");
                strBody.Append("Thanks,");
                strBody.Append("<br><br>");
                strBody.Append("DigiMa Team");
                strBody.Append("</span></td></tr></tr></table></center></div>");

                mail.Body = strBody.ToString();
                SmtpClient mSMTPClient = new SmtpClient("smtpauth.net4india.com", 25);
                mSMTPClient.EnableSsl = false;
                mSMTPClient.UseDefaultCredentials = true;
                mSMTPClient.Credentials = auth;
                mSMTPClient.Port = 25; // PORT NUMBER
                mSMTPClient.Host = "smtpauth.net4india.com";
                mSMTPClient.Send(mail);
                return 1;
            }
            catch (Exception ex)
            {
                objCommonUtil.SendErrorMail(ex.Message, ex.StackTrace, System.Reflection.MethodBase.GetCurrentMethod().Name.ToString(), System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.ToString(), SessionData.Customer.CustomerID);
            }
            return 0; //for failure if try is not executed
        }

        protected void txtEmailID_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(txtEmailid.Text.ToString()))
                {
                    CanvasBizProcess canvBiz = new CanvasBizProcess();
                    canvBiz = new CanvasBizProcess();
                    if (txtEmailid.Text.Contains(">") || txtEmailid.Text.Contains("<") || txtEmailid.Text.Contains("'") || txtEmailid.Text.Contains("--") || txtEmailid.Text.Contains("%"))
                    {
                        txtEmailid.Text = "";
                    }
                    else
                    {
                        int result = canvBiz.CheckUserEmail(txtEmailid.Text.TrimStart(' ').TrimEnd(' '));
                        if (result == 0)
                        {
                            txtOrganization.Focus();
                        }
                        else
                        {
                            string alertScript = "alert('This e-mail ID already exists!');";
                            ScriptManager.RegisterStartupScript(this, GetType(), "Key", alertScript, true);
                            txtEmailid.Focus();
                            txtEmailid.Text = "";

                        }
                    }
                }
            }
            catch (Exception ex)
            {
                objCommonUtil.SendErrorMail(ex.Message, ex.StackTrace, System.Reflection.MethodBase.GetCurrentMethod().Name.ToString(), System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.ToString(), SessionData.Customer.CustomerID);
            }
        }

        protected void reset_click(object sender, EventArgs e)
        {
            txtFullName.Text = "";
            txtEmailid.Text = "";
            txtOrganization.Text = "";
            txtAddress.Text = "";
            txtZip.Text = "";
            CodeNumberTextBox.Text = "";
            Getcountrytobind();
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
               
            }
        }
    }
}