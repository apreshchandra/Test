using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DigiMa;
using DigiMa.Common;
using DigiMa.BizProcess;
using System.Net.Mail;
using System.Configuration;
using System.Text;
using DigiMa.Data;
using System.Web.UI.HtmlControls;

namespace DigiMa
{
    public partial class ForgotPassword : System.Web.UI.Page
    {
        CanvasBizProcess canvBiz = null;
        EncryptionUtilities _oEncryptionUtilities = new EncryptionUtilities();

        private Random random = new Random();
        bool flag = false;

        protected void Page_Load(object sender, EventArgs e)
        {
            //divBackBtn.Attributes.Add("style","display:block");
            try
            {
                if (!IsPostBack)
                {
                    this.Session["CaptchaImageText"] = GenerateRandomCode();
                    errorlblsecurity.Style.Add("display", "none");
                    CodeNumberTextBox.Text = "";
                    //tdLogin.Visible = false;
                    //tdSignup.Visible = false;
                }
                else
                {
                    if (this.CodeNumberTextBox.Text.TrimStart(' ').TrimEnd(' ') == this.Session["CaptchaImageText"].ToString())
                    {
                        flag = true;
                    }
                    else
                    {
                        //wrong
                        this.Session["CaptchaImageText"] = GenerateRandomCode();
                    }
                }
                txtmailid.Focus();
            }
            catch (Exception ex)
            {
                CommonUtility objCommon = new CommonUtility();
                objCommon.SendErrorMail(ex.Message, ex.StackTrace, System.Reflection.MethodBase.GetCurrentMethod().Name.ToString(), System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.ToString(), "");
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
                DigiMa.Common.CommonUtility objCommon = new CommonUtility();
                objCommon.SendErrorMail(ex.Message, ex.StackTrace, System.Reflection.MethodBase.GetCurrentMethod().Name.ToString(), System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.ToString(), "");
            }
            return string.Empty;
        }

        protected void submibmail_Click(object sender, EventArgs e)
        {
            canvBiz = new CanvasBizProcess();
            AppCustomer oAppCustomer = new AppCustomer();

            string uid = canvBiz.GetCustId(txtmailid.Text.TrimStart(' ').TrimEnd(' '));
            try
            {
                if (txtmailid.Text.Contains(">") || txtmailid.Text.Contains("<") || txtmailid.Text.Contains("'") || txtmailid.Text.Contains("--") || txtmailid.Text.Contains("%"))
                {
                    txtmailid.Text = "";
                }
                else
                {
                    if (flag)
                    {
                        string NewTempPass = GenerateNewPassword(8);
                        string temppass = _oEncryptionUtilities.getEncryptedCode(NewTempPass);
                        int chkavalible = canvBiz.VerifyEmailInsertNewPassword(txtmailid.Text.TrimStart(' ').TrimEnd(' '), temppass);

                        if (chkavalible == 1)
                        {
                            int mailstatus = MailTrigger(txtmailid.Text);
                            if (mailstatus == 1)
                            {
                                string script = "alert('Password Sent To Email.');" + "location.href='Home.aspx?';";
                                this.ClientScript.RegisterStartupScript(typeof(Page), "Redirect", script, true);
                                CanvasBizProcess canvasBiz = new CanvasBizProcess();
                                //UPdate fpStatus to 1 as user has requested reset password
                                canvasBiz.UpdatefpStatus(uid, 1);
                                //canvBiz.UpdateTempPwd(txtmailid.Text, temppass);

                            }
                        }
                        else
                        {
                            maillbl.Visible = true;
                            maillbl.Text = " Invalid Email Id /Please Check Email Id Again.";
                            CodeNumberTextBox.Text = "";
                            this.Session["CaptchaImageText"] = GenerateRandomCode();
                            errorlblsecurity.Text = string.Empty;
                        }
                    }
                    else
                    {
                        errorlblsecurity.Style.Add("display", "block");
                        errorlblsecurity.Text = "The Characters Doesn't Match. Please Try Again.";
                        CodeNumberTextBox.Text = "";
                        errorlblsecurity.Focus();
                    }

                }
            }

            catch (Exception ex)
            {
                DigiMa.Common.CommonUtility objCommon = new CommonUtility();
                objCommon.SendErrorMail(ex.Message, ex.StackTrace, System.Reflection.MethodBase.GetCurrentMethod().Name.ToString(), System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.ToString(), "");
            }
        }

        public int MailTrigger(string txtmailid)
        {

            try
            {
                string uid = canvBiz.GetCustId(txtmailid);
                AppCustomer oAppCustomer = new AppCustomer();
                oAppCustomer = canvBiz.GetCustomerInfo(txtmailid, uid, false);
                MailMessage mail = new MailMessage();
                //string adminid = txtmailid;
                string adminid = "support@sonetreach.com";//ConfigurationManager.AppSettings["usermailid"];
                string admpass = "S0netsupp0rt";// ConfigurationManager.AppSettings["userpassword"];
                System.Net.NetworkCredential auth = new System.Net.NetworkCredential(adminid, admpass);
                mail.From = new MailAddress(adminid);//TODO: Put actual sender email address
                mail.To.Add(new MailAddress(txtmailid));
                mail.Subject = "Reset your sonetreach password";    // Mail Subject
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
                strBody.Append("You recently asked for your SONETREACH Password.To complete your request, Please follow this link to reset your password.<br /><br/>");

                strBody.Append("https://www.sonetreach.com/Reset_Password.aspx?fp=1&id=" + HttpUtility.UrlEncode(CommonUtility.Encrypt(uid)) + "");
                strBody.Append("<br><br>");
                strBody.Append("User Name: &nbsp;");
                strBody.Append(txtmailid);
                strBody.Append("<br><br>");
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
                DigiMa.Common.CommonUtility objCommon = new CommonUtility();
                objCommon.SendErrorMail(ex.Message, ex.StackTrace, System.Reflection.MethodBase.GetCurrentMethod().Name.ToString(), System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.ToString(), "");
            }
            return 0;
        }

        private string GenerateNewPassword(int size)
        {
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
                DigiMa.Common.CommonUtility objCommon = new CommonUtility();
                objCommon.SendErrorMail(ex.Message, ex.StackTrace, System.Reflection.MethodBase.GetCurrentMethod().Name.ToString(), System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.ToString(), "");
            }
            return string.Empty;
        }


    }
}