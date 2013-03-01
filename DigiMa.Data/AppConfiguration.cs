using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace DigiMa.Data
{
    public class AppConfiguration : AppBase
    {
        private string _sDID;
        private string _sAppCustomerDID;
        private string _sAppType;
        private string _sAppID;
        private string _sAppKey;
        private string _sAppSecretKey;
        private string _sAppPath;
        private string _sAppName;
        private string _sAppLogo;
        private string _sAppHeader;
        private string _sAppFooter;
        private string _sAppExpiryPath;
        private string _sAppStatus;
        private string _sAppExpiryDT;
        private string _sAppPageTabSelected;
        private string _sAppPagePath;
        private string _sAppCustomNameAdded;
        private string _sCustomtTabName;
        private string _sPageID;
        private string _sAppStartDT;
        private string _sInquiryEmail;
        private string _sTemplatePage;
        private string _sCampaignType;
        private string _sSiteID;
        private int _sTemplateID;


        public int STemplateID
        {
            get { return _sTemplateID; }
            set { _sTemplateID = value; }
        }

        public string SSiteID
        {
            get { return _sSiteID; }
            set { _sSiteID = value; }
        }

        public string SCampaignType
        {
            get { return _sCampaignType; }
            set { _sCampaignType = value; }
        }

        public string STemplatePage
        {
            get { return _sTemplatePage; }
            set { _sTemplatePage = value; }
        }

        public string SInquiryEmail
        {
            get { return _sInquiryEmail; }
            set { _sInquiryEmail = value; }
        }

        public string SAppStartDT
        {
            get { return _sAppStartDT; }
            set { _sAppStartDT = value; }
        }

        public string SPageID
        {
            get { return _sPageID; }
            set { _sPageID = value; }
        }

        public string SCustomtTabName
        {
            get { return _sCustomtTabName; }
            set { _sCustomtTabName = value; }
        }

        public string SAppCustomNameAdded
        {
            get { return _sAppCustomNameAdded; }
            set { _sAppCustomNameAdded = value; }
        }

        public string SAppPagePath
        {
            get { return _sAppPagePath; }
            set { _sAppPagePath = value; }
        }

        public string SAppPageTabSelected
        {
            get { return _sAppPageTabSelected; }
            set { _sAppPageTabSelected = value; }
        }

        
        public string DID
        {
            get { return _sDID; }
            set { _sDID = value; }
        }

        
        public string AppCustomerDID
        {
            get { if (this != null) return _sAppCustomerDID; else return string.Empty; }
            set { _sAppCustomerDID = value; }
        }

        
        public string AppType
        {
            get { return _sAppType; }
            set { _sAppType = value; }
        }

        
        public string AppID
        {
            get { return _sAppID; }
            set { _sAppID = value; }
        }

        
        public string AppKey
        {
            get { return _sAppKey; }
            set { _sAppKey = value; }
        }

        
        public string AppSecretKey
        {
            get { return _sAppSecretKey; }
            set { _sAppSecretKey = value; }
        }

        
        public string AppPath
        {
            get { return _sAppPath; }
            set { _sAppPath = value; }
        }

        
        public string AppName
        {
            get { return _sAppName; }
            set { _sAppName = value; }
        }

        
        public string AppLogo
        {
            get { return _sAppLogo; }
            set { _sAppLogo = value; }
        }

        
        public string AppHeader
        {
            get { if (this != null) return _sAppHeader; else return string.Empty; }
            set { _sAppHeader = value; }
        }

        
        public string AppFooter
        {
            get { if (this != null) return _sAppFooter; else return string.Empty; }
            set { _sAppFooter = value; }
        }

        
        public string AppExpiryPath
        {
            get { if (this != null) return _sAppExpiryPath; else return string.Empty; }
            set { _sAppExpiryPath = value; }
        }

        
        public string AppStatus
        {
            get { if (this != null) return _sAppStatus; else return string.Empty; }
            set { _sAppStatus = value; }
        }

        
        public string AppExpiryDT
        {
            get { if (this != null) return _sAppExpiryDT; else return string.Empty; }
            set { _sAppExpiryDT = value; }
        }

        public string GetNewDIDWithPrefix()
        {
            return GetNewDID("AN");
        }
    }

    [DataContract]
    public class SonetPie
    {
        private Hashtable _qsvars = new Hashtable();

        public Hashtable QSvars
        {
            get { return _qsvars; }
            set { _qsvars = value; }
        }

        private Hashtable _frmvars = new Hashtable();

        public Hashtable Formvars
        {
            get { return _frmvars; }
            set { _frmvars = value; }
        }

        private string _qsvarsstring;

        public string QSvarsString
        {
            get { return _qsvarsstring; }
            set { _qsvarsstring = value; }
        }

        private string _frmvarsstring;

        public string FormvarsString
        {
            get { if (_frmvarsstring != null) return _frmvarsstring; else return string.Empty; }
            set { _frmvarsstring = value; }
        }

        private string _sAbsolutePath;

        public string AbsolutePath
        {
            get { return _sAbsolutePath; }
            set { _sAbsolutePath = value; }
        }

        private string _sDefaultPageDID;

        public string DefaultPageDID
        {
            get { return _sDefaultPageDID; }
            set { _sDefaultPageDID = value; }
        }


        private string _sFirstPageDID;

        public string FirstPageDID
        {
            get { return _sFirstPageDID; }
            set { _sFirstPageDID = value; }
        }
    }
}
