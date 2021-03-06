﻿using System;
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
    public partial class Confirmation : System.Web.UI.Page
    {
        CanvasBizProcess canvBiz = null;
        AppCustomer oAppCust = null;
        string id = string.Empty;


        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    canvBiz = new CanvasBizProcess();
                    if (Request.QueryString["nu"] != null && Request.QueryString["nu"].Contains("1"))
                    {
                        if (Request.QueryString["nu"].Contains("1") && Request.QueryString["id"] != null)
                        {
                            // Check if user is using the same link again to reset his password
                            id = HttpUtility.UrlDecode(CommonUtility.Decrypt(Request["id"].ToString()));
                            int fpStatus = canvBiz.ConfirmResetPassword(id.TrimStart(' ').TrimEnd(' '));
                            if (fpStatus != 0)
                            {
                                newFrm.Attributes.Add("style", "display:block");
                            }
                            else
                            {
                                newFrm.Attributes.Add("style", "display:none");
                                lblLoginuser.Visible = true;
                                lblLoginuser.Text = "This link is expired.";
                            }
                        }
                    }
                    else
                    {
                        lblLoginuser.Visible = true;
                        lblLoginuser.Text = "Oops !!! Something went wrong.";
                    }
                }
            }
            catch (Exception ex)
            {
                DigiMa.Common.CommonUtility objCommon = new CommonUtility();
                objCommon.SendErrorMail(ex.Message, ex.StackTrace, System.Reflection.MethodBase.GetCurrentMethod().Name.ToString(), System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.ToString(), "");
            }
        }

        protected void ChangePasswordUser_click(object sender, EventArgs e)
        {
            try
            {
                canvBiz = new CanvasBizProcess();


                if (Request.QueryString["nu"] != null && !string.IsNullOrEmpty(Request["id"]))
                {
                    if (Request.QueryString["nu"].Contains("1") && Request.QueryString["id"] != null)
                    {
                        string cid = Request["id"].ToString();
                        id = HttpUtility.UrlDecode(CommonUtility.Decrypt(Request["id"].ToString()));
                        int status = canvBiz.ChangePasswordUser(id, txtpasswordnew.Text.TrimStart(' ').TrimEnd(' '));
                        string script = string.Empty;
                        if (status != 0)
                        {
                            if (Request.QueryString["cmp"] != null)
                            {
                                script = "alert('Password Changed Successfully... ');" + "location.href='Home.aspx?cmp=" + HttpUtility.UrlEncode(Request.QueryString["cmp"]) + "'";
                            }
                            else
                            {
                                canvBiz.UpdatefpStatus(id, 0);
                                script = "alert('Password Changed Successfully... ');" + "location.href='Home.aspx?cp=1';";
                            }

                            this.ClientScript.RegisterStartupScript(typeof(Page), "RedirectArticle", script, true);
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
    }//end of class
}//end of namespace