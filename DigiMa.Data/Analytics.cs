using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DigiMa.Data
{
    public class Analytics
    {
        private string CustomerName;

        public string CustomerName1
        {
            get { return CustomerName; }
            set { CustomerName = value; }
        }
        private string AppName;

        public string AppName1
        {
            get { return AppName; }
            set { AppName = value; }
        }
        public string Country;
        public string Country1
        {
            get { return Country; }
            set { Country = value; }
        }
        public string State;
        public string State1
        {
            get { return State; }
            set { State = value; }
        }
        public string City;
        public string City1
        {
            get { return City; }
            set { City = value; }
        }
        public string Gender;
        public string Gender1
        {
            get { return Gender; }
            set { Gender = value; }
        }
        public int Level;
        public int Level1
        {
            get { return Level; }
            set { Level = value; }
        }
    }


    public class AnalyticsDataEnums
    {
        private string NotifierType;


        public string NotifierType1
        {
            get { return NotifierType; }
            set { NotifierType = value; }
        }


        private string YearMonth;


        public string YearMonth1
        {
            get { return YearMonth; }
            set { YearMonth = value; }
        }

        private string NotifierTypeCount;

        public string NotifierTypeCount1
        {
            get { return NotifierTypeCount; }
            set { NotifierTypeCount = value; }
        }
    }
    public class AnalyticsDataEnumsLocationAge
    {
        public string Gender;
        public string Gender1
        {
            get { return Gender; }
            set { Gender = value; }
        }

        public string Age;
        public string Age1
        {

            get { return Age; }
            set { Age = value; }
        }
        public string NotifierTypeCount;
        public string NotifierTypeCount1
        {
            get { return NotifierTypeCount; }
            set { NotifierTypeCount = value; }
        }
    }
    public class AnalyticsDataEnumsLocationActions
    {
        public string Gender;
        public string Gender1
        {
            get { return Gender; }
            set { Gender = value; }
        }

        public string NotifierType;
        public string NotifierType1
        {

            get { return NotifierType; }
            set { NotifierType = value; }
        }
        public string NotifierTypeCount;
        public string NotifierTypeCount1
        {
            get { return NotifierTypeCount; }
            set { NotifierTypeCount = value; }
        }
    }
    public class AnalyticsDataEnumsLocationPeriod
    {
        public string YearMonth;
        public string YearMonth1
        {
            get { return YearMonth; }
            set { YearMonth = value; }
        }
        public string NotifierType;
        public string NotifierType1
        {
            get { return NotifierType; }
            set { NotifierType = value; }
        }
        public string NotifierTypeCount;
        public string NotifierTypeCount1
        {
            get { return NotifierTypeCount; }
            set { NotifierTypeCount = value; }
        }
    }

}
