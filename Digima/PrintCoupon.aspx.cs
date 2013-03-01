using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DigiMa.Data;
using DigiMa.BizProcess;
using HtmlAgilityPack;
using DigiMa.Common;
using System.Text;
using System.Data;
using System.Configuration;
using System.IO;
using System.Text.RegularExpressions;

namespace DigiMa
{
    public partial class PrintCoupon : DigiMa.sNBBPage
    {
        AppProduct oAppProduct = new AppProduct();
        SweepStakesData sweep = new SweepStakesData();
        SiteDetails oSiteDetails = new SiteDetails();
        AppUser oDCAppUser = new AppUser();
        FacebookBizProcess ofbBiz = new FacebookBizProcess();
        string imgSRC;

        protected void Page_Load(object sender, EventArgs e)
        {
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
            Session["imgSRC"] = oSiteDetails.FolderPathTool + imgSRC;
            string[] filenameSplit = imgSRC.Split('/');
            string filename = filenameSplit[1].ToString();

            litPRinter.Text = node.InnerHtml.Replace(imgSRC, "images1/" + oSiteDetails.SiteID + "/" + filename);
            litPRinter.Text = litPRinter.Text.Replace("~/Template/Amalgam v1.0/", "");
        }

        protected void btnPrint(object sender, EventArgs e)
        {
            //Initialize API Core
            FaceBook oFacebook = new FaceBook();

            //Initialize KOKO
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

            Page.ClientScript.RegisterStartupScript(this.GetType(), "myCloseScript", "window.print();", true);

            ofbBiz.RaiseAppNotifier(oDCAppUser, "PRINT", Convert.ToString(QSVars["UDID"]), Convert.ToString(QSVars["PDID"]), Convert.ToString(QSVars["NDID"]));
        }

        public string CreateHtmlbody(string rules, string image, string expirydate)
        {
            try
            {
                string PDID = Convert.ToString(QSVars["PDID"]);
                string prodHTML = ofbBiz.GetProductHTML(PDID);
                Regex regex = new Regex(@"\brow-2\b");
                string[] substrings = regex.Split(prodHTML);

                //substring[1] contains the HTML that we require. 

                string tableStart = "<table id=\"tblCouponDetails\" class=\"";
                string tableREquired = tableStart + substrings[1].ToString();


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