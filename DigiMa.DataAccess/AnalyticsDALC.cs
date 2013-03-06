using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Data;
using DigiMa.Data;
using DigiMa.Common;

namespace DigiMa.DataAccess
{
    public class AnalyticsDALC
    {

        DatabaseHandler oDBH = null;
        public DataSet GetTotalActions3(string Customer, string Appname)
        {
            DataSet gtactions = new DataSet();

            oDBH = new DatabaseHandler();
            gtactions = oDBH.FillData_SP("TotalActions3", Appname, Customer);

            return gtactions;

        }

        public DataSet TotalActions3SM(string Appname, string Customer, string SMType)
        {
            DataSet gtactions = new DataSet();

            oDBH = new DatabaseHandler();
            gtactions = oDBH.FillData_SP("TotalActions3SM", Appname, Customer, SMType);

            return gtactions;

        }

        public DataSet GetUniquevisitors1(string Customer, string Appname)
        {
            DataSet uniquevistors = new DataSet();

            oDBH = new DatabaseHandler();
            uniquevistors = oDBH.FillData_SP("Uniquevisitors1", Appname, Customer);

            return uniquevistors;
        }

        public DataSet GetUniquevisitors1SM(string Customer, string Appname, string SMType)
        {
            DataSet uniquevistors = new DataSet();

            oDBH = new DatabaseHandler();
            uniquevistors = oDBH.FillData_SP("Uniquevisitors1SM", Appname, Customer, SMType);

            return uniquevistors;
        }

        public DataSet Getlevelwisequery1(string Customer, string Appname)
        {
            DataSet levelwise = new DataSet();

            oDBH = new DatabaseHandler();
            levelwise = oDBH.FillData_SP("levelwisequery1", Customer, Appname);

            return levelwise;

        }

        public DataSet Geteyeballcount1(string Customer, string Appname)
        {
            DataSet eyeballcount = new DataSet();
            oDBH = new DatabaseHandler();
            eyeballcount = oDBH.FillData_SP("eyeballcount1", Appname, Customer);
            return eyeballcount;

        }

        public DataSet Geteyeballcount1SM(string Customer, string Appname, string SMType)
        {
            DataSet eyeballcount = new DataSet();
            oDBH = new DatabaseHandler();
            eyeballcount = oDBH.FillData_SP("eyeballcount1SM", Appname, Customer, SMType);
            return eyeballcount;

        }

        public DataSet GetTotalActions1(string Customer, string Appname)
        {
            DataSet TotalActions = new DataSet();
            oDBH = new DatabaseHandler();
            TotalActions = oDBH.FillData_SP("TotalActions1", Appname, Customer);
            return TotalActions;
        }

        public DataSet GetTotalActionsSM(string Customer, string Appname, string NotifierType)
        {
            DataSet TotalActions = new DataSet();
            oDBH = new DatabaseHandler();
            TotalActions = oDBH.FillData_SP("TotalActions1", Appname, Customer, NotifierType);
            return TotalActions;
        }

        public DataSet GetGenderWiseActions1(string Customer, string Appname)
        {
            DataSet GenderWiseActions = new DataSet();
            oDBH = new DatabaseHandler();
            GenderWiseActions = oDBH.FillData_SP("GenderWiseActions1", Appname, Customer);
            return GenderWiseActions;
        }

        public DataSet GetPlatformWiseActions1(string Customer, string Appname)
        {
            DataSet GenderWiseActions = new DataSet();
            oDBH = new DatabaseHandler();
            GenderWiseActions = oDBH.FillData_SP("GetPlatformWiseActions", Appname, Customer);
            return GenderWiseActions;
        }
        public DataSet GenderWiseActionsSM(string Customer, string Appname, string SMType)
        {
            DataSet GenderWiseActions = new DataSet();
            oDBH = new DatabaseHandler();
            GenderWiseActions = oDBH.FillData_SP("GenderWiseActionsSM", Appname, Customer, SMType);
            return GenderWiseActions;
        }


        public DataSet GetLocationWise1(string Customer, string Appname)
        {
            DataSet LocationWise = new DataSet();
            oDBH = new DatabaseHandler();
            LocationWise = oDBH.FillData_SP("LocationWise1", Appname, Customer);
            return LocationWise;
        }

        public DataSet GetLocationWise1SM(string Customer, string Appname, string SMType)
        {
            DataSet LocationWise = new DataSet();
            oDBH = new DatabaseHandler();
            LocationWise = oDBH.FillData_SP("LocationWise1SM", Appname, Customer, SMType);
            return LocationWise;
        }



        public DataSet GetAppwiseActionsChart1(string Customer, string Appname)
        {
            // AnalyticsDataEnums oADE = new AnalyticsDataEnums();
            // BindingList<string> oList = new BindingList<string>();
            //DataSet dsNew= new DataSet(); 
            //oDBH = new DatabaseHandler();
            //dsNew = oDBH.FillData_SP("AppwiseActionsChart1", Appname, Customer);

            //foreach (DataRow dr in dsNew.Tables[0].Rows)
            //{
            //    oADE.NotifierType1 = dr["NotifierType"].ToString();
            //    oADE.YearMonth1 = dr["YearMonth"].ToString();
            //    oADE.NotifierTypeCount1 = dr["NotifierTypeCount"].ToString();
            //    oList.Add(oADE.ToString());
            //}

            //return oList;
            DataSet AppwiseActionsChart1 = new DataSet();
            oDBH = new DatabaseHandler();
            AppwiseActionsChart1 = oDBH.FillData_SP("AppwiseActionsChart1", Appname, Customer);
            return AppwiseActionsChart1;
        }
        public DataSet GetLocationDrillDown(string Customer, string Appname, string Country)
        {
            DataSet LocationDrillDown_stte = new DataSet();
            oDBH = new DatabaseHandler();
            LocationDrillDown_stte = oDBH.FillData_SP("Sp_LocationDrillDown_State", Customer, Appname, Country);
            return LocationDrillDown_stte;

        }

        public DataSet GetLocationDrillDownSM(string Customer, string Appname, string Country, string SMType)
        {
            DataSet LocationDrillDown_stte = new DataSet();
            oDBH = new DatabaseHandler();
            LocationDrillDown_stte = oDBH.FillData_SP("Sp_LocationDrillDown_StateSM", Customer, Appname, Country, SMType);
            return LocationDrillDown_stte;

        }
        public DataSet GetLocationDrillDownGender(string Customer, string Appname, string Country)
        {
            DataSet LocationDrillDown_Gender = new DataSet();
            oDBH = new DatabaseHandler();
            LocationDrillDown_Gender = oDBH.FillData_SP("Sp_LocationDrillDown_Gender", Customer, Appname, Country);
            return LocationDrillDown_Gender;
        }
        public DataSet GetLocationDrillDown_Age(string Customer, string Appname, string Country)
        {
            //AnalyticsDataEnumsLocationAge oADE = new AnalyticsDataEnumsLocationAge();
            //List<string> oList = new List<string>();
            //DataSet dsNew = new DataSet();
            //oDBH = new DatabaseHandler();
            //dsNew = oDBH.FillData_SP("Sp_LocationDrillDown_Age", Customer, Appname,Country);

            //foreach (DataRow dr in dsNew.Tables[0].Rows)
            //{
            //    oADE.Gender1 = dr["Gender"].ToString();
            //    oADE.Age1 = dr["Age"].ToString();
            //    oADE.NotifierTypeCount1 = dr["NotifierTypeCount"].ToString();
            //    oList.Add(oADE.ToString());
            //}

            //return oList;
            DataSet LocationDrillDown_Age = new DataSet();
            oDBH = new DatabaseHandler();
            LocationDrillDown_Age = oDBH.FillData_SP("Sp_LocationDrillDown_Age", Customer, Appname, Country);
            return LocationDrillDown_Age;
        }
        public DataSet GetLocationDrillDown_Actions(string Customer, string Appname, string Country)
        {
            //AnalyticsDataEnumsLocationActions oADE = new AnalyticsDataEnumsLocationActions();
            //List<string> oList = new List<string>();
            //DataSet dsNew = new DataSet();
            //oDBH = new DatabaseHandler();
            //dsNew = oDBH.FillData_SP("Sp_LocationDrillDown_Actions", Customer, Appname, Country);

            //foreach (DataRow dr in dsNew.Tables[0].Rows)
            //{
            //    oADE.Gender1 = dr["Gender"].ToString();
            //    oADE.NotifierType1 = dr["NotifierType"].ToString();
            //    oADE.NotifierTypeCount1 = dr["NotifierTypeCount"].ToString();
            //    oList.Add(oADE.ToString());
            //}

            //return oList;
            DataSet LocationDrillDown_Actions = new DataSet();
            oDBH = new DatabaseHandler();
            LocationDrillDown_Actions = oDBH.FillData_SP("Sp_LocationDrillDown_Actions", Customer, Appname, Country);
            return LocationDrillDown_Actions;
        }
        public DataSet GetLocationDrillDown1_City(string Customer, string Appname, string State)
        {
            DataSet LocationDrillDown1_City = new DataSet();
            oDBH = new DatabaseHandler();
            LocationDrillDown1_City = oDBH.FillData_SP("Sp_LocationDrillDown1_City", Customer, Appname, State);
            return LocationDrillDown1_City;
        }
        public DataSet GetLocationDrillDown1_Gender(string Customer, string Appname, string State)
        {
            DataSet LocationDrillDown1_Gender = new DataSet();
            oDBH = new DatabaseHandler();
            LocationDrillDown1_Gender = oDBH.FillData_SP("Sp_LocationDrillDown1_Gender", Customer, Appname, State);
            return LocationDrillDown1_Gender;
        }
        public DataSet GetLocationDrillDown1_Age(string Customer, string Appname, string State)
        {
            //AnalyticsDataEnumsLocationAge oADE = new AnalyticsDataEnumsLocationAge();
            //List<string> oList = new List<string>();
            //DataSet dsNew = new DataSet();
            //oDBH = new DatabaseHandler();
            //dsNew = oDBH.FillData_SP("Sp_LocationDrillDown1_Age", Customer, Appname, State);

            //foreach (DataRow dr in dsNew.Tables[0].Rows)
            //{
            //    oADE.Gender1 = dr["Gender"].ToString();
            //    oADE.Age1 = dr["Age"].ToString();
            //    oADE.NotifierTypeCount1 = dr["NotifierTypeCount"].ToString();
            //    oList.Add(oADE.ToString());
            //}

            //return oList;
            DataSet LocationDrillDown1_Age = new DataSet();
            oDBH = new DatabaseHandler();
            LocationDrillDown1_Age = oDBH.FillData_SP("Sp_LocationDrillDown1_Age", Customer, Appname, State);
            return LocationDrillDown1_Age;
        }
        public DataSet GetLocationDrillDown1_Actions(string Customer, string Appname, string State)
        {
            //AnalyticsDataEnumsLocationActions oADE = new AnalyticsDataEnumsLocationActions();
            //List<string> oList = new List<string>();
            //DataSet dsNew = new DataSet();
            //oDBH = new DatabaseHandler();
            //dsNew = oDBH.FillData_SP("Sp_LocationDrillDown1_Actions", Customer, Appname, State);
            //dsNew.Tables[0].TableName = "myTable";

            //foreach (DataRow dr in dsNew.Tables[0].Rows)
            //{
            //    oADE.Gender1 = dr["Gender"].ToString();
            //    oADE.NotifierType1 = dr["NotifierType"].ToString();
            //    oADE.NotifierTypeCount1 = dr["NotifierTypeCount"].ToString();
            //    oList.Add(oADE.ToString());
            //}

            //return oList;
            DataSet LocationDrillDown1_Actions = new DataSet();
            oDBH = new DatabaseHandler();
            LocationDrillDown1_Actions = oDBH.FillData_SP("Sp_LocationDrillDown1_Actions", Customer, Appname, State);
            return LocationDrillDown1_Actions;

        }
        public DataSet GetLocationDrillDown2_Gender(string Customer, string Appname, string City)
        {
            DataSet LocationDrillDown2_Gender = new DataSet();
            oDBH = new DatabaseHandler();
            LocationDrillDown2_Gender = oDBH.FillData_SP("Sp_LocationDrillDown2_Gender", Customer, Appname, City);
            return LocationDrillDown2_Gender;
        }
        public DataSet GetLocationDrillDown2_Age(string Customer, string Appname, string City)
        {
            //AnalyticsDataEnumsLocationAge oADE = new AnalyticsDataEnumsLocationAge();
            //List<string> oList = new List<string>();
            //DataSet dsNew = new DataSet();
            //oDBH = new DatabaseHandler();
            //dsNew = oDBH.FillData_SP("Sp_LocationDrillDown2_Age", Customer, Appname, City);

            //foreach (DataRow dr in dsNew.Tables[0].Rows)
            //{
            //    oADE.Gender1 = dr["Gender"].ToString();
            //    oADE.Age1 = dr["Age"].ToString();
            //    oADE.NotifierTypeCount1 = dr["NotifierTypeCount"].ToString();
            //    oList.Add(oADE.ToString());
            //}

            //return oList;
            DataSet LocationDrillDown2_Age = new DataSet();
            oDBH = new DatabaseHandler();
            LocationDrillDown2_Age = oDBH.FillData_SP("Sp_LocationDrillDown2_Age", Customer, Appname, City);
            return LocationDrillDown2_Age;
        }
        public DataSet GetLocationDrillDown2_Actions(string Customer, string Appname, string City)
        {
            //AnalyticsDataEnumsLocationActions oADE = new AnalyticsDataEnumsLocationActions();
            //List<string> oList = new List<string>();
            //DataSet dsNew = new DataSet();
            //oDBH = new DatabaseHandler();
            //dsNew = oDBH.FillData_SP("Sp_LocationDrillDown2_Actions", Customer, Appname, City);

            //foreach (DataRow dr in dsNew.Tables[0].Rows)
            //{
            //    oADE.Gender1 = dr["Gender"].ToString();
            //    oADE.NotifierType1 = dr["NotifierType"].ToString();
            //    oADE.NotifierTypeCount1 = dr["NotifierTypeCount"].ToString();
            //    oList.Add(oADE.ToString());
            //}

            //return oList;
            DataSet LocationDrillDown2_Actions = new DataSet();
            oDBH = new DatabaseHandler();
            LocationDrillDown2_Actions = oDBH.FillData_SP("Sp_LocationDrillDown2_Actions", Customer, Appname, City);
            return LocationDrillDown2_Actions;
        }
        public DataSet GetLocationDrillDown_Gender1(string Customer, string Appname, string Country, string Gender)
        {
            DataSet LocationDrillDown_Gender1 = new DataSet();
            oDBH = new DatabaseHandler();
            LocationDrillDown_Gender1 = oDBH.FillData_SP("Sp_LocationDrillDownGender", Customer, Appname, Country, Gender);
            return LocationDrillDown_Gender1;
        }
        public DataSet GetLocationDrillDown1_Gender1(string Customer, string Appname, string State, string Gender)
        {
            DataSet LocationDrillDown1_Gender1 = new DataSet();
            oDBH = new DatabaseHandler();
            LocationDrillDown1_Gender1 = oDBH.FillData_SP("Sp_LocationDrillDown1Gender", Customer, Appname, State, Gender);
            return LocationDrillDown1_Gender1;
        }
        public DataSet GetLocationDrillDown2_Gender1(string Customer, string Appname, string City, string Gender)
        {
            DataSet LocationDrillDown2_Gender1 = new DataSet();
            oDBH = new DatabaseHandler();
            LocationDrillDown2_Gender1 = oDBH.FillData_SP("Sp_LocationDrillDown2Gender", Customer, Appname, City, Gender);
            return LocationDrillDown2_Gender1;
        }
        public DataSet GenderDrillDown(string Customer, string Appname, string Gender)
        {
            DataSet GenderDrillDown = new DataSet();
            oDBH = new DatabaseHandler();
            GenderDrillDown = oDBH.FillData_SP("Sp_GenderDrillDown", Customer, Appname, Gender);
            return GenderDrillDown;
        }
        public DataSet GenderDrillDownSM(string Customer, string Appname, string Gender, string SMType)
        {
            DataSet GenderDrillDown = new DataSet();
            oDBH = new DatabaseHandler();
            GenderDrillDown = oDBH.FillData_SP("Sp_GenderDrillDownSM", Customer, Appname, Gender, SMType);
            return GenderDrillDown;
        }


        public DataSet GetLevelsDrillDown_Actions(string Appname, int Level)
        {
            DataSet LevelsDrillDown_Actions = new DataSet();
            oDBH = new DatabaseHandler();
            LevelsDrillDown_Actions = oDBH.FillData_SP("Sp_LevelsDrillDown_Actions", Appname, Level);
            return LevelsDrillDown_Actions;
        }
        public DataSet GetLevelsDrillDown_Gender(string Appname, int Level)
        {
            DataSet LevelsDrillDown_Gender = new DataSet();
            oDBH = new DatabaseHandler();
            LevelsDrillDown_Gender = oDBH.FillData_SP("Sp_LevelsDrillDown_Gender", Appname, Level);
            return LevelsDrillDown_Gender;
        }
        public DataSet GetLevelsDrillDown_Location(string Appname, int Level)
        {
            DataSet LevelsDrillDown_Location = new DataSet();
            oDBH = new DatabaseHandler();
            LevelsDrillDown_Location = oDBH.FillData_SP("Sp_LevelsDrillDown_Location", Appname, Level);
            return LevelsDrillDown_Location;
        }
        public DataSet GetLevelsDrillDown_Age(string Appname, int Level)
        {
            DataSet LevelsDrillDown_Age = new DataSet();
            oDBH = new DatabaseHandler();
            LevelsDrillDown_Age = oDBH.FillData_SP("Sp_LevelsDrillDown_Age", Appname, Level);
            return LevelsDrillDown_Age;
        }
        public DataSet GetPeriodDrillDown(string Appname, string YearMonth)
        {
            //AnalyticsDataEnumsLocationPeriod oADE = new AnalyticsDataEnumsLocationPeriod();
            //List<string> oList = new List<string>();
            //DataSet dsNew = new DataSet();
            //oDBH = new DatabaseHandler();
            //dsNew = oDBH.FillData_SP("Sp_PeriodDrillDown", Appname, YearMonth);

            //foreach (DataRow dr in dsNew.Tables[0].Rows)
            //{
            //    oADE.YearMonth1 = dr["YearMonth"].ToString();
            //    oADE.NotifierType1 = dr["NotifierType"].ToString();
            //    oADE.NotifierTypeCount1 = dr["NotifierTypeCount"].ToString();
            //    oList.Add(oADE.ToString());
            //}

            //return oList;
            DataSet PeriodDrillDown = new DataSet();
            oDBH = new DatabaseHandler();
            PeriodDrillDown = oDBH.FillData_SP("Sp_PeriodDrillDown", Appname, YearMonth);
            return PeriodDrillDown;
        }
    }
}
