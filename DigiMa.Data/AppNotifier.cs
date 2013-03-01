using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace DigiMa.Data
{
    public class AppNotifier: AppBase
    {
        private string _sDID;
        private string _sAppProductDID;
        private string _sAppUserDID;
        private string _ssoNetFriendID;
        private string _ssoNetFriendName;
        private string _sNotifierType;
        private int _iNoOfVisits;
        private string _ssoNetEmailID;
        private string _ssoNetEmailContext;
        private string _ssoNetEmailContent;

        
        public string DID
        {
            get { return _sDID; }
            set { _sDID = value; }
        }

        
        public string AppProductDID
        {
            get { return _sAppProductDID; }
            set { _sAppProductDID = value; }
        }

        
        public string AppUserDID
        {
            get { return _sAppUserDID; }
            set { _sAppUserDID = value; }
        }

        
        public string SoNetFriendID
        {
            get { return _ssoNetFriendID; }
            set { _ssoNetFriendID = value; }
        }

        
        public string SoNetFriendName
        {
            get { return _ssoNetFriendName; }
            set { _ssoNetFriendName = value; }
        }

        
        public string NotifierType
        {
            get { return _sNotifierType; }
            set { _sNotifierType = value; }
        }

        
        public int NoOfVisits
        {
            get { return _iNoOfVisits; }
            set { _iNoOfVisits = value; }
        }

        
        public string SoNetEmailID
        {
            get { return _ssoNetEmailID; }
            set { _ssoNetEmailID = value; }
        }

        
        public string SoNetEmailContext
        {
            get { return _ssoNetEmailContext; }
            set { _ssoNetEmailContext = value; }
        }

        
        public string SoNetEmailContent
        {
            get { return _ssoNetEmailContent; }
            set { _ssoNetEmailContent = value; }
        }

        public string GetNewDIDWithPrefix()
        {
            return GetNewDID("AN");
        }

    }
}
