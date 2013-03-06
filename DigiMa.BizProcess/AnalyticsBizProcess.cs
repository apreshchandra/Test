using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Data;
using DigiMa.DataAccess;
using DigiMa.Common;
using DigiMa.Data;

namespace DigiMa.BizProcess
{
    public class AnalyticsBizProcess
    {
        AnalyticsDALC anbp = null;

        public DataSet GetTotalActions3(string Customer, string Appname)
        {
            anbp = new AnalyticsDALC();
            return anbp.GetTotalActions3(Customer, Appname);
        }

        public DataSet TotalActions3SM(string Appname, string Customer, string SMType)
        {
            anbp = new AnalyticsDALC();
            return anbp.TotalActions3SM(Appname, Customer, SMType);
        }


        public DataSet GetUniquevisitors1(string Customer, string Appname)
        {
            anbp = new AnalyticsDALC();
            return anbp.GetUniquevisitors1(Customer, Appname);
        }
        public DataSet GetUniquevisitors1SM(string Customer, string Appname, string SMType)
        {
            anbp = new AnalyticsDALC();
            return anbp.GetUniquevisitors1SM(Customer, Appname, SMType);
        }

        public DataSet Getlevelwisequery1(string Customer, string Appname)
        {
            anbp = new AnalyticsDALC();
            return anbp.Getlevelwisequery1(Customer, Appname);
        }

        public DataSet Geteyeballcount1(string Customer, string Appname)
        {
            anbp = new AnalyticsDALC();
            return anbp.Geteyeballcount1(Customer, Appname);
        }

        public DataSet Geteyeballcount1SM(string Customer, string Appname, string SMType)
        {
            anbp = new AnalyticsDALC();
            return anbp.Geteyeballcount1SM(Customer, Appname, SMType);
        }

        public DataSet GetTotalActions1(string Customer, string Appname)
        {
            anbp = new AnalyticsDALC();
            return anbp.GetTotalActions1(Customer, Appname);
        }

        public DataSet GetTotalActionsSM(string Customer, string Appname, string NotifierType)
        {
            anbp = new AnalyticsDALC();
            return anbp.GetTotalActionsSM(Customer, Appname, NotifierType);
        }

        public DataSet GetGetGenderWiseActions1(string Customer, string Appname)
        {
            anbp = new AnalyticsDALC();
            return anbp.GetGenderWiseActions1(Customer, Appname);
        }

        public DataSet GetPlatformWiseActions1(string Customer, string Appname)
        {
            anbp = new AnalyticsDALC();
            return anbp.GetPlatformWiseActions1(Customer, Appname);
        }

        public DataSet GenderWiseActionsSM(string Customer, string Appname, string SMType)
        {
            anbp = new AnalyticsDALC();
            return anbp.GenderWiseActionsSM(Customer, Appname, SMType);
        }

        public DataSet GetLocationWise1(string Customer, string Appname)
        {
            anbp = new AnalyticsDALC();
            return anbp.GetLocationWise1(Customer, Appname);
        }

        public DataSet GetLocationWise1SM(string Customer, string Appname, string SMType)
        {
            anbp = new AnalyticsDALC();
            return anbp.GetLocationWise1SM(Customer, Appname, SMType);
        }


        public DataSet GetAppwiseActionsChart1(string Customer, string Appname)
        {
            anbp = new AnalyticsDALC();
            return anbp.GetAppwiseActionsChart1(Customer, Appname);
        }
        public DataSet GetLocationDrillDown(string Customer, string Appname, string Country)
        {
            anbp = new AnalyticsDALC();
            return anbp.GetLocationDrillDown(Customer, Appname, Country);
        }

        public DataSet GetLocationDrillDownSM(string Customer, string Appname, string Country, string SMType)
        {
            anbp = new AnalyticsDALC();
            return anbp.GetLocationDrillDownSM(Customer, Appname, Country, SMType);
        }

        public DataSet GetLocationDrillDownGender(string Customer, string Appname, string Country)
        {
            anbp = new AnalyticsDALC();
            return anbp.GetLocationDrillDownGender(Customer, Appname, Country);
        }
        public DataSet GetLocationDrillDown_Age(string Customer, string Appname, string Country)
        {
            anbp = new AnalyticsDALC();
            return anbp.GetLocationDrillDown_Age(Customer, Appname, Country);
        }
        public DataSet GetLocationDrillDown_Actions(string Customer, string Appname, string Country)
        {
            anbp = new AnalyticsDALC();
            return anbp.GetLocationDrillDown_Actions(Customer, Appname, Country);
        }
        public DataSet GetLocationDrillDown1_City(string Customer, string Appname, string State)
        {
            anbp = new AnalyticsDALC();
            return anbp.GetLocationDrillDown1_City(Customer, Appname, State);
        }
        public DataSet GetLocationDrillDown1_Gender(string Customer, string Appname, string State)
        {
            anbp = new AnalyticsDALC();
            return anbp.GetLocationDrillDown1_Gender(Customer, Appname, State);
        }
        public DataSet GetLocationDrillDown1_Age(string Customer, string Appname, string State)
        {
            anbp = new AnalyticsDALC();
            return anbp.GetLocationDrillDown1_Age(Customer, Appname, State);
        }
        public DataSet GetLocationDrillDown1_Actions(string Customer, string Appname, string State)
        {
            anbp = new AnalyticsDALC();
            return anbp.GetLocationDrillDown1_Actions(Customer, Appname, State);
        }
        public DataSet GetLocationDrillDown2_Gender(string Customer, string Appname, string City)
        {
            anbp = new AnalyticsDALC();
            return anbp.GetLocationDrillDown2_Gender(Customer, Appname, City);
        }
        public DataSet GetLocationDrillDown2_Age(string Customer, string Appname, string City)
        {
            anbp = new AnalyticsDALC();
            return anbp.GetLocationDrillDown2_Age(Customer, Appname, City);
        }
        public DataSet GetLocationDrillDown2_Actions(string Customer, string Appname, string City)
        {
            anbp = new AnalyticsDALC();
            return anbp.GetLocationDrillDown2_Actions(Customer, Appname, City);
        }
        public DataSet GetLocationDrillDown_Gender1(string Customer, string Appname, string Country, string Gender)
        {
            anbp = new AnalyticsDALC();
            return anbp.GetLocationDrillDown_Gender1(Customer, Appname, Country, Gender);
        }
        public DataSet GetLocationDrillDown1_Gender1(string Customer, string Appname, string State, string Gender)
        {
            anbp = new AnalyticsDALC();
            return anbp.GetLocationDrillDown1_Gender1(Customer, Appname, State, Gender);
        }
        public DataSet GetLocationDrillDown2_Gender1(string Customer, string Appname, string City, string Gender)
        {
            anbp = new AnalyticsDALC();
            return anbp.GetLocationDrillDown2_Gender1(Customer, Appname, City, Gender);
        }
        public DataSet GenderDrillDown(string Customer, string Appname, string Gender)
        {
            anbp = new AnalyticsDALC();
            return anbp.GenderDrillDown(Customer, Appname, Gender);
        }

        public DataSet GenderDrillDownSM(string Customer, string Appname, string Gender, string SMType)
        {
            anbp = new AnalyticsDALC();
            return anbp.GenderDrillDownSM(Customer, Appname, Gender, SMType);
        }

        public DataSet GetLevelsDrillDown_Actions(string Appname, int Level)
        {
            anbp = new AnalyticsDALC();
            return anbp.GetLevelsDrillDown_Actions(Appname, Level);
        }
        public DataSet GetLevelsDrillDown_Gender(string Appname, int Level)
        {
            anbp = new AnalyticsDALC();
            return anbp.GetLevelsDrillDown_Gender(Appname, Level);
        }
        public DataSet GetLevelsDrillDown_Location(string Appname, int Level)
        {
            anbp = new AnalyticsDALC();
            return anbp.GetLevelsDrillDown_Location(Appname, Level);
        }
        public DataSet GetLevelsDrillDown_Age(string Appname, int Level)
        {
            anbp = new AnalyticsDALC();
            return anbp.GetLevelsDrillDown_Age(Appname, Level);
        }
        public DataSet GetPeriodDrillDown(string Appname, string YearMonth)
        {
            anbp = new AnalyticsDALC();
            return anbp.GetPeriodDrillDown(Appname, YearMonth);
        }
    }
}
