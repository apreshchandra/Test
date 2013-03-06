using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DigiMa.Data
{
    public class AppCustomer : AppBase
    {
        private string _CustomerID;

        public string CustomerID
        {
            get { return _CustomerID; }
            set { _CustomerID = value; }
        }
        private string _sCustomerUserName;

        public string SCustomerUserName
        {
            get { return _sCustomerUserName; }
            set { _sCustomerUserName = value; }
        }
        private string _sCustomerPWD;

        public string SCustomerPWD
        {
            get { return _sCustomerPWD; }
            set { _sCustomerPWD = value; }
        }
        private string _sCustomerEmail;

        public string SCustomerEmail
        {
            get { return _sCustomerEmail; }
            set { _sCustomerEmail = value; }
        }

        private int _sCustomerCountry;

        public int SCustomerCountry
        {
            get { return _sCustomerCountry; }
            set { _sCustomerCountry = value; }
        }
        private string _sCustomerStatus;

        public string SCustomerStatus
        {
            get { return _sCustomerStatus; }
            set { _sCustomerStatus = value; }
        }

        public string GetNewDIDWithPrefix()
        {
            return GetNewDID("AC");
        }


        private string _sCompanyName;

        public string SCompanyName
        {
            get { return _sCompanyName; }
            set { _sCompanyName = value; }
        }

        private string _sfpStatus;

        public string SfpStatus
        {
            get { return _sfpStatus; }
            set { _sfpStatus = value; }
        }

        private string _sAddress;

        public string SAddress
        {
            get { return _sAddress; }
            set { _sAddress = value; }
        }

        private string _sIsCoupon;

        public string IsCoupon
        {
            get { return _sIsCoupon; }
            set { _sIsCoupon = value; }
        }

        private string _sIsSweepStakes;

        public string IsSweepStakes
        {
            get { return _sIsSweepStakes; }
            set { _sIsSweepStakes = value; }
        }


        private string _sIsMultiPage;

        public string IsMultiPage
        {
            get { return _sIsMultiPage; }
            set { _sIsMultiPage = value; }
        }

    }
}
