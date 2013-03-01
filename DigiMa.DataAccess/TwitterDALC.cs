using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using DigiMa.Common;
using DigiMa.Data;

namespace DigiMa.DataAccess
{
    public class TwitterDALC
    {
        public bool AddAppUserDetails(SonetPie osonetpie, AppUser oDCAppUser)
        {
            try
            {
                DatabaseHandler oDBH = new DatabaseHandler();
                if (oDCAppUser.SBirthdate == "")
                {

                    int i = oDBH.ExecuteNonQuery_SP("AddAppUserDetails", oDCAppUser.DID, oDCAppUser.AppConfigDID, oDCAppUser.UserName, oDCAppUser.SonetID, oDCAppUser.SonetSRC, oDCAppUser.ImageURL, oDCAppUser.City, oDCAppUser.State, oDCAppUser.Country, oDCAppUser.EmailID, oDCAppUser.UserStatus, oDCAppUser.Gender, oDCAppUser.EmailSubscription, System.DBNull.Value, oDCAppUser.SFriend_count, oDCAppUser.SMType, oDCAppUser.Token, oDCAppUser.TokenSecret);
                    if (i < 0) return false; else return true;
                }
                else
                {
                    int i = oDBH.ExecuteNonQuery_SP("AddAppUserDetails", oDCAppUser.DID, oDCAppUser.AppConfigDID, oDCAppUser.UserName, oDCAppUser.SonetID, oDCAppUser.SonetSRC, oDCAppUser.ImageURL, oDCAppUser.City, oDCAppUser.State, oDCAppUser.Country, oDCAppUser.EmailID, oDCAppUser.UserStatus, oDCAppUser.Gender, oDCAppUser.EmailSubscription, oDCAppUser.SBirthdate, oDCAppUser.SFriend_count, oDCAppUser.SMType, oDCAppUser.Token, oDCAppUser.TokenSecret);
                    if (i < 0) return false; else return true;
                }
            }
            catch (Exception ex)
            {
                //Log4NetUtility.ErrorDebug(this.GetType().FullName, "Error in GetConfigData(string _AppId)", ex);
                throw ex;
            }
        } //DONE
        public bool EditAppUserDetails(SonetPie osonetpie, AppUser oDCAppUser)
        {
            try
            {
                DatabaseHandler oDBH = new DatabaseHandler();
                if (oDCAppUser.SBirthdate == "")
                {
                    oDBH.FillData_SP("EditAppUserDetails", Convert.ToString(osonetpie.QSvars["ADID"]), oDCAppUser.SonetID, oDCAppUser.City, oDCAppUser.State, oDCAppUser.Country, oDCAppUser.EmailID, oDCAppUser.UserStatus, oDCAppUser.Gender, System.DBNull.Value, oDCAppUser.SFriend_count);
                    return true;
                }
                else
                {
                    oDBH.FillData_SP("EditAppUserDetails", Convert.ToString(osonetpie.QSvars["ADID"]), oDCAppUser.SonetID, oDCAppUser.City, oDCAppUser.State, oDCAppUser.Country, oDCAppUser.EmailID, oDCAppUser.UserStatus, oDCAppUser.Gender, oDCAppUser.SBirthdate, oDCAppUser.SFriend_count);
                    return true;
                }
            }
            catch (Exception ex)
            {
                //Log4NetUtility.ErrorDebug(this.GetType().FullName, "Error in GetConfigData(string _AppId)", ex);
                throw ex;
            }
        } //DONE

        public bool IsUserCreatedForTwitter(string user_id, string appConfigDID)
        {
            try
            {
                DatabaseHandler oDBH = new DatabaseHandler();
                StringBuilder oSBQuery = new StringBuilder();

                DataSet ds = oDBH.FillData_SP("IsUserCreatedForTwitter", user_id, appConfigDID);

                if (Convert.ToInt32(ds.Tables[0].Rows[0][0]) >= 1)
                {

                    return true;
                }
                else
                {
                    return false;
                }

            }
            catch (Exception ex)
            {
                //Log4NetUtility.ErrorDebug(this.GetType().FullName, "Error in GetConfigData(string _AppId)", ex);
                throw ex;
            }
        }

        public bool IsAppUserActive(string ADID, AppUser oDCAppUser)
        {
            try
            {
                DatabaseHandler oDBH = new DatabaseHandler();

                //Check if user is already present if present then update his information & status
                object objRowCount = oDBH.ExecuteNonQuery_SP("IsAppUserActive", ADID, oDCAppUser.SonetID);
                if ((int)objRowCount > 0)
                {
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                //Log4NetUtility.ErrorDebug(this.GetType().FullName, "Error in GetConfigData(string _AppId)", ex);
                throw ex;
            }
        }//DONE

        public bool IsAppUserExist(string ADID, ref AppUser oDCAppUser)
        {
            try
            {
                DatabaseHandler oDBH = new DatabaseHandler();

                //Check if user is already present if present then update his information & status
                object objRowCount = oDBH.ExecuteNonQuery_SP("IsAppUserExist", ADID, oDCAppUser.SonetID);
                if ((int)objRowCount > 0)
                {
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                //Log4NetUtility.ErrorDebug(this.GetType().FullName, "Error in GetConfigData(string _AppId)", ex);
                throw ex;
            }
        } //DONE
    }
}
