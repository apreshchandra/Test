using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DigiMa.Data
{
    public class UserAction
    {
        public string UserName { get; set; }
        public string Password { get; set; }

        public int TemplateId { get; set; }
        public string CustomerId { get; set; }

        public int RoleID { get; set; }
        public string RoleName { get; set; }
        public bool Create { get; set; }
        public bool Edit { get; set; }
        public bool View { get; set; }
        public bool Assign { get; set; }
        public bool Finish { get; set; }
        private string taskComplete;

        public string TaskComplete
        {
            get { return taskComplete; }
            set { taskComplete = value; }
        }
        private string PreferenceID;

        public string PreferenceID1
        {
            get { return PreferenceID; }
            set { PreferenceID = value; }
        }

        private bool WebSiteDownloaded;

        public bool WebSiteDownloaded1
        {
            get { return WebSiteDownloaded; }
            set { WebSiteDownloaded = value; }
        }

        private string SubDomainName;

        public string SubDomainName1
        {
            get { return SubDomainName; }
            set { SubDomainName = value; }
        }

        private string YoutubeURL;

        public string YoutubeURL1
        {
            get { return YoutubeURL; }
            set { YoutubeURL = value; }
        }

        private string CustomTabName;

        public string CustomTabName1
        {
            get { return CustomTabName; }
            set { CustomTabName = value; }
        }

        private string SiteID;

        public string SiteID1
        {
            get { return SiteID; }
            set { SiteID = value; }
        }
    }
}
