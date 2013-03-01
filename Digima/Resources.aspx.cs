using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DigiMa.Data;
using System.Web.UI;
using DigiMa.BizProcess;
using System.Web.UI.WebControls;
using DigiMa.Common;
using System.IO;
using System.Text;

namespace DigiMa
{
    public partial class Resources : System.Web.UI.Page
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

        protected void btnDownload_Click(object sender, EventArgs e)
        {
            DownloadSoNetBrochure();
        }
        private bool DownloadSoNetBrochure()
        {
            //File Path and File Name
            string filePath = Server.MapPath("~/Resources");
            string _DownloadableProductFileName = "brochure_snr.jpg";

            System.IO.FileInfo FileName = new System.IO.FileInfo(filePath + "\\" + _DownloadableProductFileName);
            FileStream myFile = new FileStream(filePath + "\\" + _DownloadableProductFileName, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);

            //Reads file as binary values
            BinaryReader _BinaryReader = new BinaryReader(myFile);

            //Check whether file exists in specified location
            if (FileName.Exists)
            {
                try
                {
                    long startBytes = 0;
                    string lastUpdateTiemStamp = File.GetLastWriteTimeUtc(filePath).ToString("r");
                    string _EncodedData = HttpUtility.UrlEncode(_DownloadableProductFileName, Encoding.UTF8) + lastUpdateTiemStamp;

                    Response.Clear();
                    Response.Buffer = false;
                    Response.AddHeader("Accept-Ranges", "bytes");
                    Response.AppendHeader("ETag", "\"" + _EncodedData + "\"");
                    Response.AppendHeader("Last-Modified", lastUpdateTiemStamp);
                    Response.ContentType = "application/octet-stream";
                    Response.AddHeader("Content-Disposition", "attachment;filename=" + FileName.Name);
                    Response.AddHeader("Content-Length", (FileName.Length - startBytes).ToString());
                    Response.AddHeader("Connection", "Keep-Alive");
                    Response.ContentEncoding = Encoding.UTF8;

                    //Send data
                    _BinaryReader.BaseStream.Seek(startBytes, SeekOrigin.Begin);

                    //Dividing the data in 1024 bytes package
                    int maxCount = (int)Math.Ceiling((FileName.Length - startBytes + 0.0) / 1024);

                    //Download in block of 1024 bytes
                    int i;
                    for (i = 0; i < maxCount && Response.IsClientConnected; i++)
                    {
                        Response.BinaryWrite(_BinaryReader.ReadBytes(1024));
                        Response.Flush();
                    }
                    //if blocks transfered not equals total number of blocks
                    if (i < maxCount)
                        return false;
                    return true;
                }
                catch
                {
                    return false;
                }
                finally
                {
                    Response.End();
                    _BinaryReader.Close();
                    myFile.Close();
                }
            }
            else
            {
                System.Web.UI.ScriptManager.RegisterStartupScript(this, GetType(),
                   "FileNotFoundWarning", "alert('File is not available now, please try later.')", true);
            }
            return false;
        }


    }

}
