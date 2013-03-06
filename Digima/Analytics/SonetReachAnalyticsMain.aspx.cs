using System;
using System.Collections;
using System.Collections.Generic;
using DigiMa.BizProcess;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Drawing.Imaging;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.IO;
using System.Web.UI.WebControls;
using DigiMa.Common;
using System.Web.UI.HtmlControls;
using System.Web.UI.DataVisualization.Charting;
using System.Data.SqlClient;
using System.Text;
using System.Net;
using System.Net.Mail;
using System.Configuration;
using System.Web.UI.DataVisualization.Charting.Utilities;
using DigiMa.Data;
using System.Web.Security;
using System.Linq;
using System.Collections.Specialized;
using System.Xml.Linq;

namespace DigiMa.Analytics
{
    public partial class SonetReachAnalyticsMain : System.Web.UI.Page
    {
        AnalyticsBizProcess analyticsBiz = new AnalyticsBizProcess();
        DataSet dsAnalytics = null;
        DataTable dt = new DataTable();
        string CustomerName;
        string AppName;
        private string SMTypeFB = "FB";
        private string SMTypeTW = "TW";

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {

                if (Request["CustomerName"] != null)
                {

                    CustomerName = Request["CustomerName"].ToString();
                }
                if (Request["AppName"] != null)
                {
                    AppName = Request["AppName"].ToString();
                }

                GetTotalActions3();
                ///*End of totalactions3*/


                GetTotalActions3SMTW();
                ///*End of GetTotalTweetActions*/

                GetTotalActions3SMFB();
                ///*End of GetTotalFBActions*/

                GetUniquevisitors1();
                ///*End of Uniquevisitors1*/
                ///
                GetUniquevisitors1FB();
                ///*End of Uniquevisitors1SM*/
                ///
                GetUniquevisitors1TW();
                ///*End of Uniquevisitors1SM*/

                Getlevelwisequery1();
                ///*End of levelwisequery1*/

                Geteyeballcount1();
                ///*End of eyeballcount1*/

                // Geteyeballcount2();
                ///*End of eyeballcount2*/
                ///
                GeteyeballcountTweet();

                GeteyeballcountFB();

                GetTotalActions1();
                ///*End of GetTotalActions1*/

                //GetTotalActions1SM();
                ///*End of GetTotalActionsTweet*/

                GetGetGenderWiseActions1();
                /*End of GetGetGenderWiseActions1*/


                //GenderWiseActionsSM();
                /*End of GetGetGenderWiseActions1*/

                GetLocationWise1();
                /*End of  public GetLocationWise1*/


                GetLocationWise1FB();
                /*End of  public GetLocationWise1*/

                GetLocationWise1TW();
                /*End of  public GetLocationWise1*/


                GetAppwiseActionsChart1();
                /*End of GetAppwiseActionsChart1*/


                GetPlatformWiseActions1();
                /*End of GetGetGenderWiseActions1*/

                GetGoogleAnalyticsForMicrosite();
            }

            catch (Exception ex)
            {
                SendErrorMail(ex.Message, ex.StackTrace, System.Reflection.MethodBase.GetCurrentMethod().Name.ToString(), System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.ToString(), "");
            }
        }

        public void GetGoogleAnalyticsForMicrosite()
        {
            WebClient webClient = new WebClient();
            NameValueCollection data = new NameValueCollection();
            data.Add("accountType", "GOOGLE");
            data.Add("Email", "sonetreach123@gmail.com");
            data.Add("Passwd", "sonetreach123");//Passwd, not a misspell.
            data.Add("service", "analytics");
            data.Add("source", "xxxx-xxxx-xx");//Could be anything.

            byte[] bytes = webClient.UploadValues("https://www.google.com/accounts/ClientLogin", "POST", data);
            string tokens = Encoding.UTF8.GetString(bytes);
            string authToken = extractAuthToken(tokens);

            //-------------- Get page views -------------------

            string feed = "https://www.google.com/analytics/feeds/data";

        Required:
            string ids = "ga:65907309";
            string metrics = "ga:pageviews";
            string startDate = "2011-06-25";
            string endDate = "2012-12-25";

        Optional:
            string dimensions = "ga:pagePath";
            string sort = "-ga:pageviews";

            string feedUrl = string.Format("{0}?ids={1}&dimensions={2}&metrics={3}&sort={4}&start-date={5}&end-date={6}",
                feed, ids, dimensions, metrics, sort, startDate, endDate);

            webClient.Headers.Add("Authorization", "GoogleLogin " + authToken);
            string result = webClient.DownloadString(feedUrl);

            //-------------- Extract data from xml -------------------

            XDocument xml = XDocument.Parse(result);
            var ns1 = "{http://www.w3.org/2005/Atom}";
            var ns2 = "{http://schemas.google.com/analytics/2009}";

            var q = from entry in xml.Descendants()
                    where entry.Name == ns1 + "entry"
                    select new
                    {
                        PagePath = entry.Element(ns2 + "dimension").Attribute("value").Value,
                        Views = entry.Element(ns2 + "metric").Attribute("value").Value
                    };

            //-------------- Do something with data -------------------
            var liste = new List<Dictionary<string, string>>();


            Dictionary<string, string> dict = new Dictionary<string, string>();
            foreach (var Page in q)
            {
                if (!(Page.PagePath.Length == 1))
                {
                    HtmlTableRow tr = new HtmlTableRow();
                    HtmlTableCell tdPagePath = new HtmlTableCell();
                    tdPagePath.ColSpan = 1;
                    tdPagePath.Align = "center";
                    tr.BgColor = "#fff";
                    tr.Cells.Add(tdPagePath);
                    tr.Cells[0].InnerHtml = Page.PagePath;

                    HtmlTableCell tdViewws = new HtmlTableCell();
                    tdViewws.ColSpan = 1;
                    tdViewws.Align = "center";
                    tr.Cells.Add(tdViewws);
                    tr.Cells[1].InnerHtml = Page.Views;
                    tblGoogleAnalytics.Rows.Add(tr);
                }
            }
            if (tblGoogleAnalytics.Rows.Count == 1)
            {
                //add a dummy Row for index.html
                HtmlTableRow trDummy = new HtmlTableRow();
                HtmlTableCell tdPagePathDummy = new HtmlTableCell();
                tdPagePathDummy.ColSpan = 1;
                tdPagePathDummy.Align = "center";
                trDummy.Cells.Add(tdPagePathDummy);
                trDummy.Cells[0].InnerHtml = "index.html";

                HtmlTableCell tdViewwsDummy = new HtmlTableCell();
                tdViewwsDummy.ColSpan = 1;
                tdViewwsDummy.Align = "center";
                trDummy.Cells.Add(tdViewwsDummy);
                trDummy.Cells[1].InnerHtml = "1";
                tblGoogleAnalytics.Rows.Add(trDummy);
            }

        }

        //-------------- Help Method -------------------
        private string extractAuthToken(string data)
        {
            var tokens = data.Split(new string[] { "\n" }, StringSplitOptions.RemoveEmptyEntries);
            return tokens.Where(token => token.StartsWith("Auth=")).Single();
        }


        public void UpdateAttrib()
        {

            // Set series tooltips
            foreach (Series series in Chart6.Series)
            {
                for (int pointIndex = 0; pointIndex < series.Points.Count; pointIndex++)
                {
                    //string toolTip = "";

                    //toolTip = "<img src=LocationWiseToolTip.aspx?Country=" + series.Points[pointIndex].AxisLabel.Replace(" ","_") + " />";
                    //series.Points[pointIndex].MapAreaAttributes = "onmouseover=\"DisplayTooltip('" + toolTip + "');\" onmouseout=\"DisplayTooltip('');\"";
                    series.Points[pointIndex].Url = "LocationWiseDrillDown.aspx?Country=" + series.Points[pointIndex].AxisLabel + "&Count=" + series.Points[pointIndex].YValues[0] + "&AppName=" + AppName + "&CustomerName=" + CustomerName;
                }
            }

        }

        public void UpdateAttribFB()
        {

            // Set series tooltips
            foreach (Series series in Chart11.Series)
            {
                for (int pointIndex = 0; pointIndex < series.Points.Count; pointIndex++)
                {
                    //string toolTip = "";

                    //toolTip = "<img src=LocationWiseToolTip.aspx?Country=" + series.Points[pointIndex].AxisLabel.Replace(" ","_") + " />";
                    //series.Points[pointIndex].MapAreaAttributes = "onmouseover=\"DisplayTooltip('" + toolTip + "');\" onmouseout=\"DisplayTooltip('');\"";
                    series.Points[pointIndex].Url = "LocationWiseDrillDown.aspx?Country=" + series.Points[pointIndex].AxisLabel + "&Count=" + series.Points[pointIndex].YValues[0] + "&AppName=" + AppName + "&CustomerName=" + CustomerName + "&SMType=FB";
                }
            }

        }

        public void UpdateAttribTweet()
        {

            // Set series tooltips
            foreach (Series series in Chart12.Series)
            {
                for (int pointIndex = 0; pointIndex < series.Points.Count; pointIndex++)
                {
                    //string toolTip = "";

                    //toolTip = "<img src=LocationWiseToolTip.aspx?Country=" + series.Points[pointIndex].AxisLabel.Replace(" ","_") + " />";
                    //series.Points[pointIndex].MapAreaAttributes = "onmouseover=\"DisplayTooltip('" + toolTip + "');\" onmouseout=\"DisplayTooltip('');\"";
                    series.Points[pointIndex].Url = "LocationWiseDrillDown.aspx?Country=" + series.Points[pointIndex].AxisLabel + "&Count=" + series.Points[pointIndex].YValues[0] + "&AppName=" + AppName + "&CustomerName=" + CustomerName + "&SMType=TW";
                }
            }

        }

        public void GenderDrill()
        {
            foreach (Series series in Chart7.Series)
            {
                for (int pointIndex = 0; pointIndex < series.Points.Count; pointIndex++)
                {
                    series.Points[pointIndex].Url = "GenderWiseDrillDown.aspx?Gender=" + series.Points[pointIndex].AxisLabel + "&AppName=" + AppName + "&CustomerName=" + CustomerName;
                }
            }
        }

        public void LevelViseDrill()
        {
            foreach (Series series in Chart3.Series)
            {
                for (int pointIndex = 0; pointIndex < series.Points.Count; pointIndex++)
                {
                    series.Points[pointIndex].Url = "LevelsDrillDown.aspx?Level=" + series.Points[pointIndex].AxisLabel + "&Count=" + series.Points[pointIndex].YValues[0] + "&AppName=" + AppName + "&CustomerName=" + CustomerName;
                }
            }
        }
        public void PeriodViseDrill()
        {
            foreach (Series series in Chart8.Series)
            {
                for (int pointIndex = 0; pointIndex < series.Points.Count; pointIndex++)
                {
                    series.Points[pointIndex].Url = "DateWiseDrillDown.aspx?YearMonth=" + series.Points[pointIndex].AxisLabel + "&AppName=" + AppName + "&CustomerName=" + CustomerName;
                }
            }
        }

        public string Properties { get; set; }


        public void SendErrorMail(string exMessage, string exStackTrace, string methodName, string className, string userID)
        {
            MailMessage mail = new MailMessage();
            //string adminid = txtmailid;
            string adminid = "support@sonetreach.com";//ConfigurationManager.AppSettings["usermailid"];
            string admpass = "S0netsupp0rt";// ConfigurationManager.AppSettings["userpassword"];
            System.Net.NetworkCredential auth = new System.Net.NetworkCredential(adminid, admpass);
            mail.From = new MailAddress(adminid);//TODO: Put actual sender email address
            mail.To.Add(new MailAddress("apresh.chandra@smnetserv.com"));
            mail.Subject = "Exception in SonetReach - " + exMessage;    // Mail Subject
            mail.IsBodyHtml = true;
            mail.Priority = MailPriority.High; //Mail Priority

            StringBuilder strBody = new StringBuilder();

            strBody.Append("<div><center><table border=\"2px black\" width=\"800px\" style=\"height:200px;\">");
            strBody.Append("<tr><td style=\"background-color: Black; height: 40px; width: 400px;\">");
            strBody.Append("<center><span style=\"color: Red; font-family: Lucida Grande; font-size: 10;\">");
            strBody.Append("SONETREACH Exception ");
            strBody.Append("</span></center></td></tr><tr><td>");
            strBody.Append("<span style=\"font-family: Lucida Grande;\">");
            strBody.Append("<br/>");
            strBody.Append("Hello");
            strBody.Append("<br>");
            strBody.Append("<br>");
            strBody.Append("Please have a look at : <br /><br/>");

            strBody.Append("<br><br>");
            strBody.Append("Exception Message :");
            strBody.Append(exMessage);
            strBody.Append("<br><br>");
            strBody.Append("In Class: &nbsp;");
            strBody.Append(className);
            strBody.Append("<br>");
            strBody.Append("<br>");
            strBody.Append("In Method: ");
            strBody.Append(methodName);
            strBody.Append("<br>");
            strBody.Append("<br>");
            strBody.Append("Incident Occurred at: ");
            strBody.Append(DateTime.Now.ToString() + " IST  ");
            strBody.Append("<br>");
            strBody.Append("For Customer ID: ");
            strBody.Append(userID);
            strBody.Append("<br>");
            strBody.Append("<br>");
            strBody.Append("Stack Trace Detail:");
            strBody.Append("<br>");
            strBody.Append(exStackTrace);
            strBody.Append("</span></td></tr></tr></table></center></div>");

            mail.Body = strBody.ToString();
            SmtpClient mSMTPClient = new SmtpClient("smtpauth.net4india.com", 25);
            mSMTPClient.EnableSsl = false;
            mSMTPClient.UseDefaultCredentials = true;
            mSMTPClient.Credentials = auth;
            mSMTPClient.Port = 25; // PORT NUMBER
            mSMTPClient.Host = "smtpauth.net4india.com";
            mSMTPClient.Send(mail);
        }

        public void GetTotalActions3()
        {
            dsAnalytics = new DataSet();
            dsAnalytics = analyticsBiz.GetTotalActions3(CustomerName, AppName);
            if (dsAnalytics.Tables.Count > 0)
            {
                if (dsAnalytics.Tables[0].Rows.Count > 0)
                {
                    lbl3.Text = "Total Actions";
                    lbl4.Text = dsAnalytics.Tables[0].Rows[0]["Count"].ToString();
                }
            }
        }

        public void GetTotalActions3SMTW()
        {
            dsAnalytics = new DataSet();
            dsAnalytics = analyticsBiz.TotalActions3SM(AppName, CustomerName, SMTypeTW);
            if (dsAnalytics.Tables.Count > 0)
            {
                if (dsAnalytics.Tables[0].Rows.Count > 0)
                {

                    lblTWActions.Text = dsAnalytics.Tables[0].Rows[0]["Count"].ToString();
                }
            }
        }

        public void GetTotalActions3SMFB()
        {
            dsAnalytics = new DataSet();
            dsAnalytics = analyticsBiz.TotalActions3SM(AppName, CustomerName, SMTypeFB);
            if (dsAnalytics.Tables.Count > 0)
            {
                if (dsAnalytics.Tables[0].Rows.Count > 0)
                {

                    lblFBActions.Text = dsAnalytics.Tables[0].Rows[0]["Count"].ToString();
                }
            }
        }

        public void GetUniquevisitors1()
        {
            dsAnalytics = new DataSet();
            dsAnalytics = analyticsBiz.GetUniquevisitors1(CustomerName, AppName);
            if (dsAnalytics.Tables.Count > 0)
            {
                if (dsAnalytics.Tables[0].Rows.Count > 0)
                {
                    lbl5.Text = "Unique Visitors";
                    lbl6.Text = dsAnalytics.Tables[0].Rows[0]["UniqueUserCount"].ToString();
                }
            }
        }

        public void GetUniquevisitors1FB()
        {
            dsAnalytics = new DataSet();
            dsAnalytics = analyticsBiz.GetUniquevisitors1SM(CustomerName, AppName, SMTypeFB);
            if (dsAnalytics.Tables.Count > 0)
            {
                if (dsAnalytics.Tables[0].Rows.Count > 0)
                {
                    //lbl5.Text = "Unique Visitors";
                    lblFBUnique.Text = dsAnalytics.Tables[0].Rows[0]["UniqueUserCount"].ToString();
                }
            }
        }

        public void GetUniquevisitors1TW()
        {
            dsAnalytics = new DataSet();
            dsAnalytics = analyticsBiz.GetUniquevisitors1SM(CustomerName, AppName, SMTypeTW);
            if (dsAnalytics.Tables.Count > 0)
            {
                if (dsAnalytics.Tables[0].Rows.Count > 0)
                {
                    //lbl5.Text = "Unique Visitors";
                    lblTWUnique.Text = dsAnalytics.Tables[0].Rows[0]["UniqueUserCount"].ToString();
                }
            }
        }
        public void Getlevelwisequery1()
        {
            dsAnalytics = new DataSet();
            dsAnalytics = analyticsBiz.Getlevelwisequery1(CustomerName, AppName);
            if (dsAnalytics.Tables.Count > 0)
            {
                if (dsAnalytics.Tables[0].Rows.Count > 0)
                {
                    int levCount = dsAnalytics.Tables[0].Rows.Count;
                    for (int i = 0; i < levCount; i++)
                    {
                        Chart3.Series["Series1"].Points.AddXY(Convert.ToString(dsAnalytics.Tables[0].Rows[i]["Level"]), dsAnalytics.Tables[0].Rows[i]["Count"]);
                        Chart3.Series["Series1"].MarkerStyle = MarkerStyle.Circle;
                        Chart3.Series["Series1"].MarkerSize = 8;
                        Chart3.Series["Series1"].MarkerColor = Color.Magenta;
                        //Chart3.Series["Series1"].Points[2].MarkerImage = "~/Images/smiley.bmp";
                        //Chart3.Series["Series1"].Points[2].MarkerImageTransparentColor = Color.White;
                        LevelViseDrill();
                    }
                }
            }
        }
        public void Geteyeballcount1()
        {
            dsAnalytics = new DataSet();
            dsAnalytics = analyticsBiz.Geteyeballcount1(CustomerName, AppName);
            if (dsAnalytics.Tables.Count > 0)
            {
                if (dsAnalytics.Tables[0].Rows.Count > 0)
                {
                    lbl1.Text = "Total Impressions";
                    lbl2.Text = dsAnalytics.Tables[0].Rows[0]["EYEBALLS"].ToString();
                    //Chart4.Series["Series1"].Points.AddY(Convert.ToDecimal(sqladptr3["EYEBALLS"]));
                    //Chart4.Series["Series1"]["LabelStyle"] = "Center";
                }
            }
        }

        //public void Geteyeballcount2()
        //{
        //    dsAnalytics = new DataSet();
        //    dsAnalytics = analyticsBiz.Geteyeballcount1(CustomerName, AppName, SMTypeTW);
        //    if (dsAnalytics.Tables.Count > 0)
        //    {
        //        if (dsAnalytics.Tables[0].Rows.Count > 0)
        //        {
        //            lblTwitter1.Text = "Twitter Impressions";
        //            lblTwitter2.Text = dsAnalytics.Tables[0].Rows[0]["EYEBALLS"].ToString();
        //            //Chart4.Series["Series1"].Points.AddY(Convert.ToDecimal(sqladptr3["EYEBALLS"]));
        //            //Chart4.Series["Series1"]["LabelStyle"] = "Center";
        //        }
        //    }
        //}

        public void GeteyeballcountTweet()
        {
            dsAnalytics = new DataSet();
            dsAnalytics = analyticsBiz.Geteyeballcount1SM(CustomerName, AppName, SMTypeTW);
            if (dsAnalytics.Tables.Count > 0)
            {
                if (dsAnalytics.Tables[0].Rows.Count > 0)
                {
                    //lblTweet21.Text = "Twitter Impressions";
                    lblTWImpressions.Text = dsAnalytics.Tables[0].Rows[0]["EYEBALLS"].ToString();
                    //Chart4.Series["Series1"].Points.AddY(Convert.ToDecimal(sqladptr3["EYEBALLS"]));
                    //Chart4.Series["Series1"]["LabelStyle"] = "Center";
                }
            }
        }

        public void GeteyeballcountFB()
        {
            dsAnalytics = new DataSet();
            dsAnalytics = analyticsBiz.Geteyeballcount1SM(CustomerName, AppName, SMTypeFB);
            if (dsAnalytics.Tables.Count > 0)
            {
                if (dsAnalytics.Tables[0].Rows.Count > 0)
                {
                    //lbl7.Text = "Facebook Impressions";
                    //lbl8.Text = dsAnalytics.Tables[0].Rows[0]["EYEBALLS"].ToString();
                    lblFBImpressions.Text = dsAnalytics.Tables[0].Rows[0]["EYEBALLS"].ToString();
                    //Chart4.Series["Series1"].Points.AddY(Convert.ToDecimal(sqladptr3["EYEBALLS"]));
                    //Chart4.Series["Series1"]["LabelStyle"] = "Center";
                }
            }
        }

        public void GetTotalActions1()
        {
            dsAnalytics = new DataSet();
            dsAnalytics = analyticsBiz.GetTotalActions1(CustomerName, AppName);
            if (dsAnalytics.Tables.Count > 0)
            {
                if (dsAnalytics.Tables[0].Rows.Count > 0)
                {
                    int notcount = dsAnalytics.Tables[0].Rows.Count;
                    for (int i = 0; i < notcount; i++)
                    {
                        Chart5.Series["Series1"].Points.AddXY(dsAnalytics.Tables[0].Rows[i]["NotifierType"], dsAnalytics.Tables[0].Rows[i]["Count"]);
                    }
                }
            }
        }

        //public void GetTotalActions1SM()
        //{
        //    dsAnalytics = new DataSet();
        //    dsAnalytics = analyticsBiz.GetTotalActionsSM(CustomerName, AppName, SMTypeTW);
        //    if (dsAnalytics.Tables.Count > 0)
        //    {
        //        if (dsAnalytics.Tables[0].Rows.Count > 0)
        //        {
        //            int notcount = dsAnalytics.Tables[0].Rows.Count;
        //            for (int i = 0; i < notcount; i++)
        //            {
        //                Chart9.Series["Series1"].Points.AddXY(dsAnalytics.Tables[0].Rows[i]["NotifierType"], dsAnalytics.Tables[0].Rows[i]["Count"]);
        //            }
        //        }
        //    }
        //}

        public void GetGetGenderWiseActions1()
        {
            dsAnalytics = new DataSet();
            dsAnalytics = analyticsBiz.GetGetGenderWiseActions1(CustomerName, AppName);
            if (dsAnalytics.Tables.Count > 0)
            {
                if (dsAnalytics.Tables[0].Rows.Count > 0)
                {
                    int genCount = dsAnalytics.Tables[0].Rows.Count;
                    for (int i = 0; i < genCount; i++)
                    {
                        Chart7.Series["Series1"].Points.AddXY(dsAnalytics.Tables[0].Rows[i]["Gender"], Convert.ToDecimal(dsAnalytics.Tables[0].Rows[i]["NotifierTypeCount"]));
                        GenderDrill();
                    }
                }
            }
        }

        public void GetPlatformWiseActions1()
        {
            dsAnalytics = new DataSet();
            dsAnalytics = analyticsBiz.GetPlatformWiseActions1(CustomerName, AppName);
            if (dsAnalytics.Tables.Count > 0)
            {
                if (dsAnalytics.Tables[0].Rows.Count > 0)
                {
                    int genCount = dsAnalytics.Tables[0].Rows.Count;
                    for (int i = 0; i < genCount; i++)
                    {
                        Chart13.Series["Series1"].Points.AddXY(dsAnalytics.Tables[0].Rows[i]["NotifyPlatform"], Convert.ToDecimal(dsAnalytics.Tables[0].Rows[i]["CountofPlatform"]));
                        //GenderDrill();
                    }
                }
            }
        }
        //public void GenderWiseActionsSM()
        //{
        //    dsAnalytics = new DataSet();
        //    dsAnalytics = analyticsBiz.GenderWiseActionsSM(CustomerName, AppName, SMTypeTW);
        //    if (dsAnalytics.Tables.Count > 0)
        //    {
        //        if (dsAnalytics.Tables[0].Rows.Count > 0)
        //        {
        //            int genCount = dsAnalytics.Tables[0].Rows.Count;
        //            for (int i = 0; i < genCount; i++)
        //            {
        //                Chart10.Series["Series1"].Points.AddXY(dsAnalytics.Tables[0].Rows[i]["Gender"], Convert.ToDecimal(dsAnalytics.Tables[0].Rows[i]["NotifierTypeCount"]));
        //                GenderDrillSM();
        //            }
        //        }
        //    }
        //}

        public void GetLocationWise1()
        {
            dsAnalytics = new DataSet();
            dsAnalytics = analyticsBiz.GetLocationWise1(CustomerName, AppName);
            if (dsAnalytics.Tables.Count > 0)
            {
                if (dsAnalytics.Tables[0].Rows.Count > 0)
                {
                    int cntryCount = dsAnalytics.Tables[0].Rows.Count;

                    for (int i = 0; i < cntryCount; i++)
                    {
                        Chart6.Series["Series1"].Points.AddXY(dsAnalytics.Tables[0].Rows[i]["Country"], dsAnalytics.Tables[0].Rows[i]["Count"]);
                        Chart6.Series["Series1"].MarkerStyle = MarkerStyle.Circle;
                        Chart6.Series["Series1"].MarkerSize = 3;
                        Chart6.Series["Series1"].MarkerColor = Color.Red;
                        UpdateAttrib();
                    }
                }
            }
        }

        public void GetLocationWise1FB()
        {
            dsAnalytics = new DataSet();
            dsAnalytics = analyticsBiz.GetLocationWise1SM(CustomerName, AppName, SMTypeFB);
            if (dsAnalytics.Tables.Count > 0)
            {
                if (dsAnalytics.Tables[0].Rows.Count > 0)
                {
                    int cntryCount = dsAnalytics.Tables[0].Rows.Count;

                    for (int i = 0; i < cntryCount; i++)
                    {
                        Chart11.Series["Series1"].Points.AddXY(dsAnalytics.Tables[0].Rows[i]["City"], dsAnalytics.Tables[0].Rows[i]["Count"]);
                        Chart11.Series["Series1"].MarkerStyle = MarkerStyle.Circle;
                        Chart11.Series["Series1"].MarkerSize = 3;
                        Chart11.Series["Series1"].MarkerColor = Color.Red;
                        //UpdateAttribFB();
                    }
                }
            }
        }

        public void GetLocationWise1TW()
        {
            dsAnalytics = new DataSet();
            dsAnalytics = analyticsBiz.GetLocationWise1SM(CustomerName, AppName, SMTypeTW);
            if (dsAnalytics.Tables.Count > 0)
            {
                if (dsAnalytics.Tables[0].Rows.Count > 0)
                {
                    int cntryCount = dsAnalytics.Tables[0].Rows.Count;

                    for (int i = 0; i < cntryCount; i++)
                    {
                        Chart12.Series["Series1"].Points.AddXY(dsAnalytics.Tables[0].Rows[i]["City"], dsAnalytics.Tables[0].Rows[i]["Count"]);
                        Chart12.Series["Series1"].MarkerStyle = MarkerStyle.Circle;
                        Chart12.Series["Series1"].MarkerSize = 3;
                        Chart12.Series["Series1"].MarkerColor = Color.Red;
                        //UpdateAttribTweet();
                    }
                }
            }
        }


        public void GetAppwiseActionsChart1()
        {
            try
            {
                //BindingList<string> analyticDataList;
                dsAnalytics = new DataSet();
                dsAnalytics = analyticsBiz.GetAppwiseActionsChart1(CustomerName, AppName);

                DataTableReader reader = dsAnalytics.CreateDataReader();


                Chart8.DataBindCrossTable(reader, "NotifierType", "YearMonth", "NotifierTypeCount", "Label=NotifierTypeCount");

                PeriodViseDrill();
                foreach (Series ser in Chart8.Series)
                {
                    ser.ShadowOffset = 0;
                    ser.BorderWidth = 2;
                    ser.ChartType = SeriesChartType.StackedBar;

                    //ser.MarkerSize = 5;
                    //ser.MarkerStyle = marker;
                    ser.MarkerBorderColor = Color.FromArgb(64, 64, 64);
                    ser.Font = new Font("Lucida Grande", 8, FontStyle.Regular);
                    //marker++;                   
                }

            }
            catch (Exception ex)
            {
                throw;
            }

        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/LandingPage.aspx?CDID=" + SessionData.Customer.CustomerID, false);
        }
    }
}