using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using DigiMa.DataAccess;
using DigiMa.Common;
using DigiMa.Data;
using System.Collections.Generic;
using DigiMa.BizProcess;

namespace DigiMa
{
    public partial class Login : System.Web.UI.Page
    {

        protected System.Web.UI.WebControls.Label lblErrorMessage;
        WebHutBizClass oWebHutBizClass;
        TextBox txtUsername = new TextBox();
        TextBox txtPassword = new TextBox();
        TextBox hdnURL = new TextBox();
        string strConnection;
        CanvasBizProcess canvBiz = null;
        AppCustomer oAppCust = null;
        protected TextBox txtemail;
        protected TextBox txtpassword;
        protected Label lblLoginuser;
        protected HtmlTableRow trError;
        protected HtmlContainerControl loginForm;
        protected HtmlContainerControl loginBox;
        protected HtmlTableCell tdSignup;
        protected HtmlTableCell tdLogin;
        protected HtmlTableCell tdBack;
        protected HtmlTableCell tdLogout;
        protected HtmlAnchor RegisterNew;
        CommonUtility objCommonUtil = new CommonUtility();

        #region Class Level Variables
        private string strUserName;
        private string strUserQuery;
        private DataSet dsIndex;
        private Hashtable htIndexData;
        private DataRow[] drRecord;
        #endregion

        private void ShowMessage(string strMessage)
        {
            #region Method Body
            //lblErrorMessage.Visible = true;
            //lblErrorMessage.Text = strMessage;
            #endregion
        }


        protected void Page_Load(object sender, System.EventArgs e)
        {
            try
            {
                try
                {
                    if (Session["UserData"] != null)
                    {
                        //hdnState.Text = "Login";
                        Response.Redirect("Dashboard.aspx");
                    }
                    else
                    {
                        // hdnState.Text = "Logout";
                    }
                }
                catch (Exception ex)
                {
                    ShowMessage(ex.Message);
                }

                //hlForgotPassword.Attributes.Add("onclick", "fnForgotPassword();");
                if (Session["ErrorMessage"] != null)
                {
                    ShowMessage(Session["ErrorMessage"].ToString());
                }
            }
            catch (Exception ex)
            {

            }
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


        protected void ibtnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                if ((txtUsername.Text != "") && (txtPassword.Text != ""))
                {
                    CheckLogin();
                }
                else
                {
                    Session["ErrorMessage"] = "Please Enter the UserId and Password";
                    Session["UserData"] = null;
                    Response.Redirect(hdnURL.Text);

                }
            }
            catch (Exception ex)
            {
                
            }
        }


        
        public void CheckLogin()
        {
            try
            {
                int intExist = 0;
                string[] UserDetails = new string[1];
                string strFullName;

                UserDetails[0] = "User";
                strUserName = txtUsername.Text;
                strConnection = System.Configuration.ConfigurationSettings.AppSettings["WebHut"];
                DataSet dsCustomer = new DataSet();
                DataSet dsPassword = new DataSet();
                SimpleAES oSimpleAES = new SimpleAES();
                //strUserQuery = "select U.UserId,U.RoleId,CD.CustomerID,R.[Create],R.Edit,R.[View],R.Assign,R.Finish from Users as U "
                //+ "inner join Customer_details as CD on U.UserId=CD.UserId "
                //+ "inner join Roles R on R.RoleId=U.RoleId "
                //+ "where U.UserName='" + txtUsername.Text + "' and U.Password='" + txtPassword.Text + "'";

                UserAction oUserDetails = new UserAction();
                oWebHutBizClass = new WebHutBizClass();
                oUserDetails = oWebHutBizClass.GetUserDetails(txtUsername.Text, txtPassword.Text);

                if (oUserDetails != null)
                {
                    Session["UserData"] = oUserDetails;
                    Response.Redirect("Dashboard.aspx", false);
                }
                else
                {
                    
                }
            }
            catch (Exception ex)
            {
               
            }
        }


        public void CheckUserPassword(DataSet dsIndex)
        {
            try
            {
                string strPasswordQuery;

                DataRow[] drPasswordRecord;
                drPasswordRecord = dsIndex.Tables["User"].Select("User_Password ='" + txtPassword.Text + "'");
                if (drPasswordRecord.Length != 0)
                {
                    try
                    {
                        if (drRecord[0]["Group_ID"].ToString() == "1")
                        {
                            Response.Redirect("dashboard.aspx", false);
                        }
                        else if (drRecord[0]["Group_ID"].ToString() == "2")
                        {
                            Response.Redirect("CallCenterAdmin.aspx", false);
                        }
                        else if (drRecord[0]["Group_ID"].ToString() == "3")
                        {
                            Response.Redirect("DashboardAdmin.aspx", false);
                        }
                        else if (drRecord[0]["Group_ID"].ToString() == "4")
                        {
                            Response.Redirect("SRITAdmin.aspx", false);
                        }
                        else
                        {
                            Response.Redirect("ViewSales.aspx", false);
                        }
                        Session["ErrorMessage"] = null;
                    }
                    catch (Exception ex)
                    {
                    }
                }
                else
                {
                    Session["ErrorMessage"] = "Enter a valid Password";
                    Session["UserData"] = null;
                    Response.Redirect(hdnURL.Text);
                }
            }
            catch (Exception ex)
            {
                ShowMessage(ex.Message);
            }
        }



    }
}
