using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using DigiMa.Common;
using DigiMa.Data;
using System.Text;

namespace DigiMa.DataAccess
{
    public class CanvasDALC
    {



        public DataSet GetTempData(int TemplateID)
        {
            DataSet dsToolkit1 = new DataSet();

            DatabaseHandler oDBH = new DatabaseHandler();
            dsToolkit1 = oDBH.FillData("select * from Template where tid=" + Convert.ToString(TemplateID));

            return dsToolkit1;
        }


        public bool InsertFinalHTML(AppProduct oAppProduct)
        {
            try
            {
                DatabaseHandler oDBH = new DatabaseHandler();
                if (oDBH.ExecuteNonQuery_SP("InsertFinalHTML", oAppProduct.AppConfigDID, oAppProduct.ProductHTML, oAppProduct.DID) > 0)
                {

                    DatabaseHandler oDBHProd = new DatabaseHandler();
                    StringBuilder oSBQueryPRod = new StringBuilder();
                    oSBQueryPRod.Append("Update [AppProduct] set PRoductHTML='" + oAppProduct.ProductHTML + "'");
                    oSBQueryPRod.Append("where DID='" + oAppProduct.DID + "'");
                    if (oDBHProd.ExecuteNonQuery(oSBQueryPRod.ToString()) > 0) return true; else return false;
                }
                //Now insert this FetchFinalHTML to AppProduct too!
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        } //DONE


        public string FetchFinalHTML(string PDID, string CDID)
        {
            DataSet dsFinalHTML = new DataSet();
            DatabaseHandler oDBH = new DatabaseHandler();
            dsFinalHTML = oDBH.FillData_SP("FetchFinalHTML", PDID, CDID);
            if (dsFinalHTML.Tables.Count > 0)
            {
                if (dsFinalHTML.Tables[0].Rows.Count > 0)
                {
                    return Convert.ToString(dsFinalHTML.Tables[0].Rows[0]["ProductHTML"].ToString());
                }
                else
                {
                    return "No Preview Available";
                }
            }
            else
            {
                return "No Preview Available";
            }
        } //DONE

        public Dictionary<string, string> DoLogin(string username, string password)
        {
            try
            {
                DataSet dsFinalHTML = new DataSet();
                DatabaseHandler oDBH = new DatabaseHandler();
                Dictionary<string, string> passDict = new Dictionary<string, string>();
                dsFinalHTML = oDBH.FillData_SP("DoLogin", username);
                if (dsFinalHTML.Tables[0].Rows.Count > 0)
                {
                    passDict.Add("pass", Convert.ToString(dsFinalHTML.Tables[0].Rows[0]["password"].ToString()));

                    return passDict;
                }
                else
                {
                    passDict.Add("pass", "ERROR");
                    return passDict;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        } //--DONE

        public string GetCustId(string email)
        {
            try
            {
                DataSet dsFinalHTML = new DataSet();
                DatabaseHandler oDBH = new DatabaseHandler();
                dsFinalHTML = oDBH.FillData_SP("GetCustId", email);

                if (dsFinalHTML.Tables[0].Rows.Count > 0)
                {
                    return Convert.ToString(dsFinalHTML.Tables[0].Rows[0]["cid"].ToString());


                }
                else
                {
                    return "ERROR";

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        } // --DONE

        public bool InsertNewCustomer(AppCustomer oAppCustomer)
        {
            try
            {
                DatabaseHandler oDBH = new DatabaseHandler();
                StringBuilder oSBQuery = new StringBuilder();
                oDBH = new DatabaseHandler();
                oDBH.ExecuteNonQuery_SP("InsertNewCustomer", oAppCustomer.GetNewDIDWithPrefix(), oAppCustomer.SCustomerUserName, oAppCustomer.SCustomerEmail, oAppCustomer.SCustomerPWD, oAppCustomer.SCompanyName, oAppCustomer.SCustomerCountry, 1, 1, oAppCustomer.SAddress,"");
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        } // --DONE

        public AppCustomer GetCustomerInfo(string email, string cid, bool login)
        {

            if (email != null && cid == null)
            {
                try
                {
                    DataSet dsFinalHTML = new DataSet();
                    DatabaseHandler oDBH = new DatabaseHandler();
                    AppCustomer oAppCustomer = new AppCustomer();
                    dsFinalHTML = oDBH.FillData_SP("GetCustomerInfo", email);


                    oAppCustomer.CustomerID = Convert.ToString(dsFinalHTML.Tables[0].Rows[0]["cid"].ToString());
                    oAppCustomer.SCompanyName = Convert.ToString(dsFinalHTML.Tables[0].Rows[0]["ccompany"].ToString());
                    oAppCustomer.SCustomerCountry = Convert.ToInt32(dsFinalHTML.Tables[0].Rows[0]["ctryid"].ToString());
                    oAppCustomer.SCustomerPWD = Convert.ToString(dsFinalHTML.Tables[0].Rows[0]["password"].ToString());
                    oAppCustomer.SCustomerStatus = Convert.ToString(dsFinalHTML.Tables[0].Rows[0]["cstatus"].ToString());
                    oAppCustomer.SCustomerUserName = Convert.ToString(dsFinalHTML.Tables[0].Rows[0]["username"].ToString());
                    oAppCustomer.SCustomerEmail = email;

                    return oAppCustomer;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else if (login)
            {
                try
                {
                    DataSet dsFinalHTML = new DataSet();
                    DatabaseHandler oDBH = new DatabaseHandler();
                    AppCustomer oAppCustomer = new AppCustomer();
                    dsFinalHTML = oDBH.FillData("select * from customer where cemail='" + email + "'");

                    oAppCustomer.CustomerID = Convert.ToString(dsFinalHTML.Tables[0].Rows[0]["cid"].ToString());
                    oAppCustomer.SCompanyName = Convert.ToString(dsFinalHTML.Tables[0].Rows[0]["ccompany"].ToString());
                    oAppCustomer.SCustomerCountry = Convert.ToInt32(dsFinalHTML.Tables[0].Rows[0]["ctryid"].ToString());
                    oAppCustomer.SCustomerPWD = Convert.ToString(dsFinalHTML.Tables[0].Rows[0]["password"].ToString());
                    oAppCustomer.SCustomerStatus = Convert.ToString(dsFinalHTML.Tables[0].Rows[0]["cstatus"].ToString());
                    oAppCustomer.SCustomerUserName = Convert.ToString(dsFinalHTML.Tables[0].Rows[0]["username"].ToString());
                    oAppCustomer.SCustomerEmail = email;

                    return oAppCustomer;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else if (email == null && cid != null)
            {
                DataSet dsFinalHTML = new DataSet();
                DatabaseHandler oDBH = new DatabaseHandler();
                AppCustomer oAppCustomer = new AppCustomer();
                dsFinalHTML = oDBH.FillData("select * from customer where cid='" + cid + "'");

                oAppCustomer.CustomerID = Convert.ToString(dsFinalHTML.Tables[0].Rows[0]["cid"].ToString());
                oAppCustomer.SCompanyName = Convert.ToString(dsFinalHTML.Tables[0].Rows[0]["ccompany"].ToString());
                oAppCustomer.SCustomerCountry = Convert.ToInt32(dsFinalHTML.Tables[0].Rows[0]["ctryid"].ToString());
                oAppCustomer.SCustomerPWD = Convert.ToString(dsFinalHTML.Tables[0].Rows[0]["password"].ToString());
                oAppCustomer.SCustomerStatus = Convert.ToString(dsFinalHTML.Tables[0].Rows[0]["cstatus"].ToString());
                oAppCustomer.SCustomerUserName = Convert.ToString(dsFinalHTML.Tables[0].Rows[0]["username"].ToString());

                return oAppCustomer;
            }
            else
            {
                try
                {
                    DataSet dsFinalHTML = new DataSet();
                    DatabaseHandler oDBH = new DatabaseHandler();
                    AppCustomer oAppCustomer = new AppCustomer();
                    dsFinalHTML = oDBH.FillData("select cemail from customer where cid='" + cid + "'");

                    oAppCustomer.SCustomerEmail = Convert.ToString(dsFinalHTML.Tables[0].Rows[0]["cemail"].ToString());

                    return oAppCustomer;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        } //--DONE

        public int ChangePasswordUser(string cid, string txtpasswordnew)
        {
            try
            {
                EncryptionUtilities encryptObj = new EncryptionUtilities();
                txtpasswordnew = encryptObj.getEncryptedCode(txtpasswordnew);
                DatabaseHandler oDBH = new DatabaseHandler();
                if (oDBH.ExecuteNonQuery_SP("ChangePasswordUser", txtpasswordnew, cid) > 0) return 1; else return 0;

            }
            catch (Exception ex)
            {
                throw ex;
            }

        } // --DONE

        public int VerifyEmailInsertNewPassword(string MailID, string temppass)
        {
            try
            {
                StringBuilder oSBValPass = new StringBuilder();
                DatabaseHandler oDBH = new DatabaseHandler();
                DataSet validatemail = oDBH.FillData_SP("VerifyEmailInsertNewPassword", MailID);
                if (validatemail.Tables.Count > 0)
                {
                    if (validatemail.Tables[0].Rows.Count > 0)
                    {
                        //get the value
                        string username = validatemail.Tables[0].Rows[0]["username"].ToString();
                        //return true;
                        return 1;
                    }
                    else
                    {
                        //User not found
                        //return false;
                        return 0;
                    }
                }
                else
                {
                    //user not found, cancel operation
                    //return false;
                    return 0;
                }
            }
            catch
            {
                throw;
            }
        } // --DONE 

        public bool SaveSweepStakesData(SweepStakesData oSweep)
        {
            try
            {
                DatabaseHandler oDBH = new DatabaseHandler();
                oDBH.ExecuteNonQuery_SP("SaveSweepStakesData", oSweep.SSweepConfigDID, oSweep.SSweepStartDate, oSweep.SSweepEndDate, oSweep.SSweepAboutUs, oSweep.SSweepTerms, oSweep.SSweepPrivacy, oSweep.SSweeprules);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        } //DONE

        public string FetchSweepStakeUtilData(string aDID, string contentType)
        {
            try
            {
                DataSet dsFinalHTML = new DataSet();
                DatabaseHandler oDBH = new DatabaseHandler();
                switch (contentType)
                {
                    case "TERMSCOND": dsFinalHTML = oDBH.FillData("select Terms from SweepstakeData where [AppConfigDID]='" + aDID + "'");
                        return dsFinalHTML.Tables[0].Rows[0]["Terms"].ToString();
                        break;
                    case "PRIVACY": dsFinalHTML = oDBH.FillData("select Privacy from SweepstakeData where [AppConfigDID]='" + aDID + "'");
                        return dsFinalHTML.Tables[0].Rows[0]["Privacy"].ToString();
                        break;
                    case "RULES": dsFinalHTML = oDBH.FillData("select Rules from SweepstakeData where [AppConfigDID]='" + aDID + "'");
                        return dsFinalHTML.Tables[0].Rows[0]["Rules"].ToString();
                        break;
                    default: return string.Empty; break;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        } //HOLD

        public bool IsConfigForSweepstakes(string appconfigDID)
        {
            try
            {
                DataSet dsFinalHTML = new DataSet();
                DatabaseHandler oDBH = new DatabaseHandler();
                dsFinalHTML = oDBH.FillData_SP("IsConfigForSweepstakes", appconfigDID);
                if (dsFinalHTML.Tables[0].Rows[0]["AppModel"].ToString().Equals("SWEEPSTAKES"))
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
                throw ex;
            }
        } //DONE

        public bool UpdateTempPwd(string MailID, string temppass)
        {
            try
            {
                DatabaseHandler oDBH = new DatabaseHandler();
                if (oDBH.ExecuteNonQuery_SP("UpdateTempPwd", temppass, MailID) > 0) return true; else return false;

            }
            catch (Exception ex)
            {
                throw ex;
            }

        } //--DONE

        public bool SaveSweepStakesEntryInfo(SweepStakesEntryInfo sweepEntry)
        {
            try
            {
                DatabaseHandler oDBH = new DatabaseHandler();
                oDBH.ExecuteNonQuery_SP("SaveSweepStakesEntryInfo", sweepEntry.AppConfigDID1, sweepEntry.SoNetID1, sweepEntry.FirstName1, sweepEntry.LastName1, sweepEntry.Address1, sweepEntry.Country1, sweepEntry.City1, sweepEntry.ZipCode1, sweepEntry.Email1, sweepEntry.Gender1, sweepEntry.DOB1, sweepEntry.Telephone1, sweepEntry.Mobile1, sweepEntry.UserType, sweepEntry.Remarks);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        } //DONE

        public DataTable FetchConfigDataForLoggedInUser(string appCustDID)
        {
            DatabaseHandler oDBH = new DatabaseHandler();
            DataSet ds = oDBH.FillData_SP("sp_Get_Config_List_For_LoggedIn_User", appCustDID);

            return ds.Tables[0];
        } //DONE
        public bool InsertPreviewHTML(string HTML, string CDID, string PDID)
        {
            try
            {
                DatabaseHandler oDBH = new DatabaseHandler();
                oDBH.ExecuteNonQuery("InsertPreviewHTML", CDID, HTML, PDID);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        } //DONE

        public int CheckUserEmail(string txtEmailID)
        {
            try
            {
                DatabaseHandler oDBH = new DatabaseHandler();
                DataSet validatemail = oDBH.FillData_SP("CheckUserEmail", txtEmailID);
                if (validatemail.Tables.Count > 0)
                {
                    if (validatemail.Tables[0].Rows.Count > 0)
                    {
                        //get the value
                        //string username = validatemail.Tables[0].Rows[0]["username"].ToString();
                        //return true;
                        return 1;
                    }
                    else
                    {
                        //User not found
                        //return false;
                        return 0;
                    }
                }
                else
                {
                    //user not found, cancel operation
                    //return false;
                    return 0;
                }
            }
            catch
            {
                throw;
            }

        } //-- DONE

        public int ConfirmResetPassword(string cid)
        {
            try
            {
                DatabaseHandler oDBHProd = new DatabaseHandler();
                StringBuilder oSBQueryPRod = new StringBuilder();

                DataSet confirmreset = oDBHProd.FillData_SP("ConfirmResetPassword", cid);
                if (confirmreset.Tables.Count > 0)
                {
                    if (confirmreset.Tables[0].Rows.Count > 0)
                    {
                        //get the value
                        //string username = validatemail.Tables[0].Rows[0]["username"].ToString();
                        //return true;
                        string status = confirmreset.Tables[0].Rows[0]["fpStatus"].ToString();
                        if (status == "1")
                        {
                            return 1;
                        }
                        else
                        {
                            return 0;
                        }

                    }
                    else
                    {
                        //User not found
                        //return false;
                        return 0;
                    }
                }
                else
                {
                    //user not found, cancel operation
                    //return false;
                    return 0;
                }
            }
            catch
            {
                throw;
            }
        }

        public int UpdatefpStatus(string cid, int status)
        {
            try
            {
                DatabaseHandler oDBHProd = new DatabaseHandler();
                StringBuilder oSBQueryPRod = new StringBuilder();

                if (oDBHProd.ExecuteNonQuery_SP("UpdatefpStatus", status, cid) > 0) return 1; else return 0;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet GetCountryList()
        {
            DataSet dsCountryList = new DataSet();

            DatabaseHandler oDBH = new DatabaseHandler();
            dsCountryList = oDBH.FillData_SP("GetCountry");

            if (dsCountryList.Tables.Count > 0)
            {
                if (dsCountryList.Tables[0].Rows.Count > 0)
                {
                    return dsCountryList;
                }
                else
                {
                    return null;
                }
            }
            else
            {
                return null;
            }
        }

        public bool UpdatePreviewHTML(string HTML, string CDID, string PDID)
        {
            try
            {
                DatabaseHandler oDBH = new DatabaseHandler();
                oDBH.ExecuteNonQuery("UpdatePreviewHTML", CDID, HTML, PDID);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public bool SaveCouponData(SweepStakesData oSweep)
        {
            try
            {
                DatabaseHandler oDBH = new DatabaseHandler();
                oDBH.ExecuteNonQuery_SP("SaveCouponData", oSweep.SSweepConfigDID, oSweep.SSweepStartDate, oSweep.SSweepEndDate, oSweep.SSweepAboutUs, oSweep.SSweepTerms, oSweep.SSweepPrivacy, oSweep.SSweeprules, oSweep.SPRizeDetails, oSweep.SEligibility, oSweep.SSweepExpiryDate, oSweep.SCouponCode, oSweep.SCouponDesc, oSweep.SCouponReedem, oSweep.SSweepWinners);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool UpdateSweepStakesData(SweepStakesData oSweep)
        {
            try
            {
                DatabaseHandler oDBH = new DatabaseHandler();
                oDBH.ExecuteNonQuery_SP("UpdateSweepStakesData", oSweep.SSweepConfigDID, oSweep.SPRizeDetails, oSweep.SSweepStartDate, oSweep.SSweepEndDate, oSweep.SSweepAboutUs, oSweep.SSweepTerms, oSweep.SSweepPrivacy, oSweep.SSweeprules, oSweep.SCouponReedem, oSweep.SCouponCode, oSweep.SCouponDesc, oSweep.SSweepExpiryDate, oSweep.SEligibility, oSweep.SSweepWinners);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        } //DONE

        public string GetSweepWinnersCount(string appConfigDID)
        {
            try
            {
                DataSet dsFinalHTML = new DataSet();
                DatabaseHandler oDBH = new DatabaseHandler();
                dsFinalHTML = oDBH.FillData_SP("GetSweepWinnersCount", appConfigDID);

                if (dsFinalHTML.Tables[0].Rows.Count > 0)
                {
                    return Convert.ToString(dsFinalHTML.Tables[0].Rows[0]["SweepWinners"].ToString());

                }
                else
                {
                    return "ERROR";

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        } // --DONE

        public DataSet GetSweepWinners(int WinnerCount, string ADID)
        {
            DataSet dsSweepWinners = new DataSet();

            DatabaseHandler oDBH = new DatabaseHandler();
            dsSweepWinners = oDBH.FillData_SP("GetSweepWinners", WinnerCount, ADID);

            if (dsSweepWinners.Tables.Count > 0)
            {
                if (dsSweepWinners.Tables[0].Rows.Count > 0)
                {
                    return dsSweepWinners;
                }
                else
                {
                    return null;
                }
            }
            else
            {
                return null;
            }
        }

        public DataSet ShowSweepstakesWinner(string ADID)
        {
            DataSet dsSweepWinners = new DataSet();

            DatabaseHandler oDBH = new DatabaseHandler();
            dsSweepWinners = oDBH.FillData_SP("ShowSweepstakesWinner", ADID);

            if (dsSweepWinners.Tables.Count > 0)
            {
                if (dsSweepWinners.Tables[0].Rows.Count > 0)
                {
                    return dsSweepWinners;
                }
                else
                {
                    return null;
                }
            }
            else
            {
                return null;
            }
        }

        public bool IsSweepWinnerDeclared(string appconfigDID)
        {
            try
            {
                DatabaseHandler oDBH = new DatabaseHandler();
                DataSet validatemail = oDBH.FillData_SP("IsSweepWinnerDeclared", appconfigDID);
                if (validatemail.Tables.Count > 0)
                {
                    if (validatemail.Tables[0].Rows.Count > 0)
                    {
                        //get the value
                        //string username = validatemail.Tables[0].Rows[0]["username"].ToString();
                        //return true;
                        return true;
                    }
                    else
                    {
                        //User not found
                        //return false;
                        return false;
                    }
                }
                else
                {
                    //user not found, cancel operation
                    //return false;
                    return false;
                }
            }
            catch
            {
                throw;
            }
        }


        public AppUser GetTwitterTokens(string ADID, string SMType, string soNetId)
        {

            DataSet dsTweeterTokens = new DataSet();
            DatabaseHandler oDBH = new DatabaseHandler();
            AppUser oAppUser = new AppUser();
            dsTweeterTokens = oDBH.FillData_SP("GetTwitterTokens", ADID, SMType, soNetId);


            try
            {
                if (dsTweeterTokens.Tables.Count > 0)
                {
                    if (dsTweeterTokens.Tables[0].Rows.Count > 0)
                    {
                        oAppUser.Token = Convert.ToString(dsTweeterTokens.Tables[0].Rows[0]["Token"].ToString());
                        oAppUser.TokenSecret = Convert.ToString(dsTweeterTokens.Tables[0].Rows[0]["TokenSecret"].ToString());
                        return oAppUser;
                    }
                }
                else
                {

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return null;

        }


        public PreferenceData GetPReferenceDataForUserPreference(string PrefID)
        {

            DataSet dsTweeterTokens = new DataSet();
            DatabaseHandler oDBH = new DatabaseHandler();
            PreferenceData oPrefData = new PreferenceData();
            dsTweeterTokens = oDBH.FillData_SP("GetPReferenceDataForUserPreference",Convert.ToInt32(PrefID));


            try
            {
                if (dsTweeterTokens.Tables.Count > 0)
                {
                    if (dsTweeterTokens.Tables[0].Rows.Count > 0)
                    {

                        oPrefData.TaskOne1 = Convert.ToString(dsTweeterTokens.Tables[0].Rows[0]["TaskOne"].ToString());
                        oPrefData.TaskTwo1 = Convert.ToString(dsTweeterTokens.Tables[0].Rows[0]["TaskTwo"].ToString());
                        oPrefData.TaskThree1 = Convert.ToString(dsTweeterTokens.Tables[0].Rows[0]["TaskThree"].ToString());
                        return oPrefData;
                    }
                }
                else
                {

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return null;

        }

    }
}
