using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace DigiMa.Data
{
    public class SweepStakesData : AppBase //RE-use this class for Coupons
    {

        private string _sSweepConfigDID;

        public string SSweepConfigDID
        {
            get { return _sSweepConfigDID; }
            set { _sSweepConfigDID = value; }
        }
        private string _sSweepStartDate;

        public string SSweepStartDate
        {
            get { return _sSweepStartDate; }
            set { _sSweepStartDate = value; }
        }
        private string _sSweepEndDate;

        public string SSweepEndDate
        {
            get { return _sSweepEndDate; }
            set { _sSweepEndDate = value; }
        }
        private string _sSweepExpiryDate;
        public string SSweepExpiryDate
        {
            get { return _sSweepExpiryDate; }
            set { _sSweepExpiryDate = value; }
        }

        private string _sSweepAboutUs;

        public string SSweepAboutUs
        {
            get { return _sSweepAboutUs; }
            set { _sSweepAboutUs = value; }
        }
        private string _sSweepTerms;

        public string SSweepTerms
        {
            get { return _sSweepTerms; }
            set { _sSweepTerms = value; }
        }
        private string _sSweepPrivacy;

        public string SSweepPrivacy
        {
            get { return _sSweepPrivacy; }
            set { _sSweepPrivacy = value; }
        }
        private string _sSweeprules;

        public string SSweeprules
        {
            get { return _sSweeprules; }
            set { _sSweeprules = value; }
        }

        private string _sPRizeDetails;


        public string SPRizeDetails
        {
            get { return _sPRizeDetails; }
            set { _sPRizeDetails = value; }
        }

        private string _sEligibility;

        public string SEligibility
        {
            get { return _sEligibility; }
            set { _sEligibility = value; }
        }

        private string _sCouponCode;

        public string SCouponCode
        {
            get { return _sCouponCode; }
            set { _sCouponCode = value; }
        }

        private string _sCouponDesc;

        public string SCouponDesc
        {
            get { return _sCouponDesc; }
            set { _sCouponDesc = value; }
        }
        private string _sCouponReedem;

        public string SCouponReedem
        {
            get { return _sCouponReedem; }
            set { _sCouponReedem = value; }
        }

        private int _sSweepWinners;
        public int SSweepWinners
        {
            get { return _sSweepWinners; }
            set { _sSweepWinners = value; }
        }


    }
}
