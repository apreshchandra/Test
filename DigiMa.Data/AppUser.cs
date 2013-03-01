using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace DigiMa.Data
{
    public class AppUser : AppBase
    {
        private string _sDID;
        private string _sAppConfigDID;
        private string _sUserName;
        private string _ssoNetID;
        private string _ssoNetSRC;
        private string _sImageURL;
        private string _sCity;
        private string _sState;
        private string _sCountry;
        private string _sEmailID;
        private string _sUserStatus;
        private string _sGender;
        private string _sEmailSubscription;
        private string _sSubscriptionEmailID;
        private string _sSubscriptionReferral;
        private string _sBirthdate;
        private string _sFriend_count;
        private string _sSMType;
        private string _sToken;
        private string _sTokenSecret;

        public string SFriend_count
        {
            get { return _sFriend_count; }
            set { _sFriend_count = value; }
        }

        public string SBirthdate
        {
            get { return _sBirthdate; }
            set { _sBirthdate = value; }
        }



        public string DID
        {
            get { return _sDID; }
            set { _sDID = value; }
        }


        public string AppConfigDID
        {
            get { return _sAppConfigDID; }
            set { _sAppConfigDID = value; }
        }


        public string UserName
        {
            get { return _sUserName; }
            set { _sUserName = value; }
        }


        public string SonetID
        {
            get { return _ssoNetID; }
            set { _ssoNetID = value; }
        }


        public string SonetSRC
        {
            get { return _ssoNetSRC; }
            set { _ssoNetSRC = value; }
        }


        public string ImageURL
        {
            get { return _sImageURL; }
            set { _sImageURL = value; }
        }


        public string City
        {
            get { return _sCity; }
            set { _sCity = value; }
        }


        public string State
        {
            get { return _sState; }
            set { _sState = value; }
        }


        public string Country
        {
            get { return _sCountry; }
            set { _sCountry = value; }
        }


        public string EmailID
        {
            get { return _sEmailID; }
            set { _sEmailID = value; }
        }


        public string UserStatus
        {
            get { return _sUserStatus; }
            set { _sUserStatus = value; }
        }


        public string Gender
        {
            get { return _sGender; }
            set { _sGender = value; }
        }


        public string EmailSubscription
        {
            get { return _sEmailSubscription; }
            set { _sEmailSubscription = value; }
        }


        public string SubscriptionEmailID
        {
            get { return _sSubscriptionEmailID; }
            set { _sSubscriptionEmailID = value; }
        }


        public string SubscriptionReferral
        {
            get { return _sSubscriptionReferral; }
            set { _sSubscriptionReferral = value; }
        }

        public string GetNewDIDWithPrefix()
        {
            return GetNewDID("AU");
        }

        public string SMType
        {
            get { return _sSMType; ; }
            set { _sSMType = value; }
        }

        public string Token
        {
            get { return _sToken; ; }
            set { _sToken = value; }
        }

        public string TokenSecret
        {
            get { return _sTokenSecret; ; }
            set { _sTokenSecret = value; }
        }

    }
}
