using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using Google.GData.Analytics;
using Google.GData.Client;
using System.Web.UI.WebControls;

namespace Digima
{
    public partial class YoutubeAnalytc : System.Web.UI.Page
    {
        public static string username { get; set; }

        public static string password { get; set; }

        public static AnalyticsService Service { get; set; }

        public static string AccountsFeedUrl { get; set; }

        public static string DataFeedUrl { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            username = "sonetreach123@gmail.com";
            password = "sonetreach123";
            AccountsFeedUrl =
               "https://www.google.com/analytics/feeds/accounts/default";

            Service = new AnalyticsService("AnalyticsSampleApp");
            Service.setUserCredentials(username, password);

            AccountQuery AccountsQuery = new AccountQuery(AccountsFeedUrl);
            AccountFeed AccountsFeed = Service.Query(AccountsQuery);

            List<AtomEntry> Accounts = AccountsFeed.Entries.ToList();
            foreach (AtomEntry Account in Accounts)
                if (Account.Title.Text.Equals("www.sonetreach.com"))
                {
                    GetPageViews(Account);
                }
        }

        private static void GetPageViews(AtomEntry Account)
        {
            string ProfileID = Account.Id.AbsoluteUri.Substring(47);
            DataFeedUrl = "https://www.google.com/analytics/feeds/data";

            DataQuery PageViewQuery = new DataQuery(DataFeedUrl)
            {
                Ids = ProfileID,
                Dimensions = "ga:date",
                Metrics = "ga:pageviews",
                Sort = "ga:date",
                GAStartDate = (DateTime.Now).AddDays(-7).ToString("yyyy-MM-dd"),
                GAEndDate = (DateTime.Now).ToString("yyyy-MM-dd")
            };

            DataFeed Results = Service.Query(PageViewQuery);

            foreach (AtomEntry Result in Results.Entries)
            {
                DataEntry Entry = (DataEntry)Result;

                Console.WriteLine(String.Format("{0}\t{1}",
                    Entry.Title.Text.Split('=')[1],
                    Entry.Metrics[0].Value));
            }
        }

    }
}