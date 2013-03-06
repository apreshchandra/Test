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
    public partial class QuickRegister : System.Web.UI.Page
    {
        bool flag = false;
        CanvasBizProcess canvBiz = null;
        EncryptionUtilities _oEncryptionUtilities = new EncryptionUtilities();
        CommonUtility objCommonUtil = new CommonUtility();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

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
                    oAppCustomer.SCompanyName = string.Empty;
                    oAppCustomer.SCustomerCountry = -1;
                    oAppCustomer.SCustomerEmail = txtEmailid.Text.Trim();
                    oAppCustomer.SCustomerPWD = temppass;
                    oAppCustomer.SCustomerStatus = "1"; //Remove hardcoding
                    oAppCustomer.SCustomerUserName = txtFullName.Text.Trim();
                    oAppCustomer.SfpStatus = "0";
                    oAppCustomer.SAddress = string.Empty;

                    //Check if Privacy policy check-box is checked
                    if (flag)
                    {
                        if (checkTC.Checked == true)
                        {
                            canvBiz.InsertNewCustomer(oAppCustomer);

                            int mailstatus = MailTrigger(txtEmailid.Text);
                            int paraMailStatus = MailTriggerToSonetREachAdmin(txtEmailid.Text);
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

                strBody.Append("https://www.sonetreach.com/Confirmation.aspx?nu=1&id=" + HttpUtility.UrlEncode(CommonUtility.Encrypt(uid)) + "");
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
        private int MailTriggerToSonetREachAdmin(string txtEmailid)
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
                mail.To.Add(new MailAddress("support@sonetreach.com"));
                mail.Subject = "New Registration"; // Mail Subject
                mail.IsBodyHtml = true;
                mail.Priority = MailPriority.High; //Mail Priority

                mail.Body = txtEmailid + " has just registered with SonetReach !";
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
                            //txtFullName.Focus(); ****Commented by ACHANDRA
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
            CodeNumberTextBox.Text = "";
        }


    }
}