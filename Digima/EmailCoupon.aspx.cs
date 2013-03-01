using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DigiMa.Data;
using DigiMa.BizProcess;
using System.Text;
using HtmlAgilityPack;
using System.Net.Mail;
using DigiMa.Common;
using System.Data;
using System.Configuration;
using System.IO;
using System.Text.RegularExpressions;

namespace DigiMa
{
    public partial class EmailCoupon : DigiMa.sNBBPage
    {
        AppProduct oAppProduct = new AppProduct();
        SiteDetails oSiteDetails = new SiteDetails();
        SweepStakesData sweep = new SweepStakesData();
        AppUser oDCAppUser = new AppUser();
        FacebookBizProcess ofbBiz = new FacebookBizProcess();
        CommonUtility commUtil = new CommonUtility();
        private string imgSRC;
        string fullPath = "https://www.sonetreach.com/"; //This will change based on hosted location.
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected override void OnPreRender(EventArgs e)
        {
            base.OnPreRender(e);
            //Initialize API Core
            FaceBook oFacebook = new FaceBook();

            //Initialize KOKO
            SonetPie osonetpie = new SonetPie();
            osonetpie.QSvarsString = GetQsVarsCollection();
            osonetpie.AbsolutePath = AbsolutePagePath;

            //Load app settings

            oDCAppUser = ofbBiz.GetAppUser(osonetpie, QSVars["ADID"].ToString(), QSVars["user_id"].ToString());


            //Prefill Email id
            if (oDCAppUser != null) txtLeadEmailID.Text = oDCAppUser.EmailID;
            GetSiteDetails();
            string strUrl = Server.MapPath(oSiteDetails.FolderPathTool) + "\\index.html";

            HtmlDocument doc = new HtmlDocument();
            doc.Load(strUrl, Encoding.UTF8); //load the HTML located at strURL

            //now take out HTML where class="row-2" as this is the html we want User to print/email
            //var divToEmail = from myHTML in doc.DocumentNode.SelectNodes("//div[@class='row-2']") select myHTML;

            HtmlNode node = doc.DocumentNode.SelectSingleNode("//div[starts-with(@class, 'row-2')]");
            var images = node.SelectNodes("//img/@src").ToList();

            string final = images[6].OuterHtml;
            string[] splitFinal = final.Split('"');

            imgSRC = splitFinal[3].ToString();
            Session["imgSRC"] = oSiteDetails.FolderPathTool+ imgSRC;
            string[] filenameSplit = imgSRC.Split('/');
            string filename = filenameSplit[1].ToString();

            litEmailbody.Text = node.InnerHtml.Replace(imgSRC,"images1/"+oSiteDetails.SiteID+"/"+filename);
            litEmailbody.Text = litEmailbody.Text.Replace("~/Template/Amalgam v1.0/", "");
        }

        public string CreateEmailbody(string rules, string image, string expirydate)
        {
            try
            {
                string PDID = Convert.ToString(QSVars["PDID"]);
                string ADID = Convert.ToString(QSVars["ADID"]);

                //Now fetch PRoduct html and split only to get coupon  table

                string prodHTML = ofbBiz.GetProductHTML(PDID);
                Regex regex = new Regex(@"\brow-2\b");
                string[] substrings = regex.Split(prodHTML);

                //substring[1] contains the HTML that we require. 
                // Replace Img src with full path to display image in email
                string matchString = Regex.Match(substrings[1].ToString(), "<img.+?src=[\"'](.+?)[\"'].+?>", RegexOptions.IgnoreCase).Groups[1].Value;
                string ImgFullPath = fullPath + matchString;

                string input = substrings[1].ToString();
                Regex ImgReplace = new Regex("(<img(.+?)id=\"imgHeader\"(.+?))src=\"([^\"]+)\"");

                //Replace src with the new url and append it to html
                string output = ImgReplace.Replace(input, match => match.Groups[1].Value + "src=\"" + ImgFullPath + "\"");

                string tableStart = "<table id=\"tblCouponDetails\" class=\"";
                string tableREquired = tableStart + output;


                Regex regexUSefulString = new Regex(@"\b</div>\b");
                string[] usefulSubstrings = regexUSefulString.Split(tableREquired);

                string divRemovedHTML = usefulSubstrings[0].Replace("</div>", "");
                string tableRemovedHTML = divRemovedHTML.Replace("<table id=\"tblActionButtonsAndRedemption\" class=\"", "");

                return tableRemovedHTML;
            }
            catch (Exception ex)
            {
            }
            return string.Empty;
        }


        protected void BtnSubmit_Click(object sender, EventArgs e)
        {
            SonetPie osonetpie = new SonetPie();

            osonetpie.QSvarsString = GetQsVarsCollection();
            osonetpie.AbsolutePath = AbsolutePagePath;
            string _sNotifierDID = new AppNotifier().GetNewDIDWithPrefix();
            if (QSVars.Contains("NDID"))
                QSVars["NDID"] = _sNotifierDID;
            else
                QSVars.Add("NDID", _sNotifierDID);
            //Load app settings

            oDCAppUser = ofbBiz.GetAppUser(osonetpie, QSVars["ADID"].ToString(), QSVars["user_id"].ToString());


            oAppProduct = ofbBiz.GetAppProductDetails(osonetpie, QSVars["PDID"].ToString());
            SendCouponEmail();
            Page.ClientScript.RegisterStartupScript(this.GetType(), "myCloseScript", "window.close()", true);
            ofbBiz.RaiseAppNotifier(oDCAppUser, "EMAIL", Convert.ToString(QSVars["UDID"]), Convert.ToString(QSVars["PDID"]), Convert.ToString(QSVars["NDID"]));

        }

        public bool SendCouponEmail()
        {
            try
            {
                MailMessage mail = new MailMessage();
                //string adminid = txtmailid;
                string adminid = "support@sonetreach.com";
                string admpass = "S0netsupp0rt";
                System.Net.NetworkCredential auth = new System.Net.NetworkCredential(adminid, admpass);
                mail.From = new MailAddress(adminid);
                //mail.To.Add(new MailAddress(oAppProduct.Email));
                mail.To.Add(new MailAddress(txtLeadEmailID.Text));
                mail.Subject = "Claim your Coupon !!";  // Mail Subject        
                mail.IsBodyHtml = true;
                mail.Priority = MailPriority.High; //Mail Priority
                string body = "<!DOCTYPE HTML PUBLIC \"-//W3C//DTD HTML 4.0 Transitional//EN\">";
                body += "<HTML><HEAD><META http-equiv=Content-Type content=\"text/html; charset=iso-8859-1\">";
                body += "</HEAD><BODY><DIV><FONT face=Arial color=#ff0000 size=2>Your Coupon is attached with this email !";
                body += "</FONT></DIV><br/></BODY></HTML>";
                mail.Body = body;
                mail.Body += litEmailbody.Text;
                string Attachments = Server.MapPath("./Template/Amalgam v1.0/" + Convert.ToString(Session["imgSRC"]));
                if ((Attachments != null) && (Attachments.Length > 0))
                {

                    if (string.IsNullOrEmpty(Attachments))
                    {
                        // Intentionally left blank
                    }
                    else
                    {
                        if (File.Exists(Server.MapPath("./Template/Amalgam v1.0/" + Convert.ToString(Session["imgSRC"]))))
                        {
                            Attachment newAttachment;
                            newAttachment = new Attachment(Server.MapPath("./Template/Amalgam v1.0/" + Convert.ToString(Session["imgSRC"])));
                            mail.Attachments.Add(newAttachment);
                        }
                    }

                }
                mail.Priority = MailPriority.Normal;
                System.Net.Mime.ContentType contenttypeObj = new System.Net.Mime.ContentType("text/html");
                AlternateView view = AlternateView.CreateAlternateViewFromString(mail.Body, null, System.Net.Mime.MediaTypeNames.Text.Html);
                string imgFile = Server.MapPath("./Template/Amalgam v1.0/" + Convert.ToString(Session["imgSRC"]));
                LinkedResource resource = null;
                if (File.Exists(imgFile))
                {
                    resource = new LinkedResource(imgFile);
                    resource.ContentId = "imgMain";
                    view.LinkedResources.Add(resource);
                    mail.AlternateViews.Add(view);
                }

                //Need to link up Image with embedded content TODO
                
                SmtpClient mSMTPClient = new SmtpClient("smtpauth.net4india.com", 25);
                mSMTPClient.UseDefaultCredentials = true;
                mSMTPClient.EnableSsl = false;
                mSMTPClient.Credentials = auth;

                mSMTPClient.Send(mail);
                return true;


            }
            catch (Exception ex)
            {

            }

            return false;
        }

        private void GetSiteDetails()
        {
            try
            {
                int SiteId = 0;

                SiteId = Convert.ToInt32(SessionData.Config.SSiteID);


                if (Session["SiteDetails"] == null || (Session["SiteDetails"] != null && ((SiteDetails)Session["SiteDetails"]).SiteID != SiteId))
                {
                    //string Query = "select SiteId,SiteName,FolderPath from Sites where SiteId=" + SiteId + " and UserId=" + int.Parse(oUserData["UserId"].ToString());
                    string Query = "select S.SiteId,S.SiteName,S.FolderPath,S.FolderPathTool,S.FolderPathFinal,S.DefaultPage from Sites S"
                                    + " where S.SiteId=" + SiteId + " and S.UserId=" + "'" + QSVars["CDID"].ToString() + "'";
                    DataSet oDataSet = new DataSet();
                    SqlHelper.FillDataset(ConfigurationSettings.AppSettings["SoConn"].ToString(), CommandType.Text, Query, oDataSet, new string[] { "SiteDetails" });

                    oSiteDetails.SiteID = int.Parse(oDataSet.Tables["SiteDetails"].Rows[0]["SiteId"].ToString());
                    oSiteDetails.SiteName = oDataSet.Tables["SiteDetails"].Rows[0]["SiteName"].ToString();

                    oSiteDetails.FolderPath = oDataSet.Tables["SiteDetails"].Rows[0]["FolderPath"].ToString();
                    oSiteDetails.FolderPathTool = oDataSet.Tables["SiteDetails"].Rows[0]["FolderPathTool"].ToString(); //Added
                    oSiteDetails.FolderPathFinal = oDataSet.Tables["SiteDetails"].Rows[0]["FolderPathFinal"].ToString(); //Added

                    //oSiteDetails.CustomerName = oDataSet.Tables["SiteDetails"].Rows[0]["CustomerName"].ToString();
                    oSiteDetails.DefaultPage = oDataSet.Tables["SiteDetails"].Rows[0]["DefaultPage"].ToString();
                    //oSiteDetails.ToolCodePath = "./Sites/Tool/" + oSiteDetails.SiteID; //Added
                    //oSiteDetails.FinalCodePath = "./Sites/Final/"+oSiteDetails.SiteID;  //Added



                    //string strFolderName = Server.MapPath("./Template/");
                    string[] PagesWithPath = Directory.GetFiles(Server.MapPath(oSiteDetails.FolderPathTool), "*.htm*", SearchOption.TopDirectoryOnly);
                    List<string> listPages = new List<string>();
                    foreach (string PageWithPath in PagesWithPath)
                    {
                        //Path.GetFileName("D:\\WebHutNew\\WebHutNew\\SiteImages\\5\\about.html");
                        listPages.Add(Path.GetFileName(PageWithPath));
                    }
                    oSiteDetails.Pages = listPages;
                    Session["SiteDetails"] = oSiteDetails;
                }
                else
                {
                    oSiteDetails = (SiteDetails)Session["SiteDetails"];
                }
            }
            catch (Exception ex)
            {

            }
        }
    }
}