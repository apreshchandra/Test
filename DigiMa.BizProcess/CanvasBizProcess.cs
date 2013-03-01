using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using DigiMa.DataAccess;
using DigiMa.Common;
using DigiMa.Data;
using System.Text;

namespace DigiMa.BizProcess
{
    public class CanvasBizProcess : IDisposable
    {
        #region IDisposable Methods

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        #endregion
        ~CanvasBizProcess()
        {
            Dispose();
        }


        public DataSet GetTempData(int TemplateID)
        {
            CanvasDALC cabc = new CanvasDALC();
            return cabc.GetTempData(TemplateID);
        }

        public bool InsertFinalHTML(AppProduct oAppProduct)
        {
            CanvasDALC cabc = new CanvasDALC();
            return cabc.InsertFinalHTML(oAppProduct);
        }

        public string FetchFinalHTML(string PDID, string CDID)
        {
            CanvasDALC cabc = new CanvasDALC();
            return cabc.FetchFinalHTML(PDID, CDID);
        }

        public Dictionary<string, string> DoLogin(string username, string password)
        {
            CanvasDALC cabc = new CanvasDALC();
            return cabc.DoLogin(username, password);
        }

        public string GetCustId(string email)
        {
            CanvasDALC cabc = new CanvasDALC();
            return cabc.GetCustId(email);
        }

        public bool InsertNewCustomer(AppCustomer oAppCustomer)
        {
            CanvasDALC cabc = new CanvasDALC();
            return cabc.InsertNewCustomer(oAppCustomer);
        }

        public AppCustomer GetCustomerInfo(string email, string cid, bool login)
        {
            CanvasDALC cabc = new CanvasDALC();
            return cabc.GetCustomerInfo(email, cid, login);
        }

        public int ChangePasswordUser(string cid, string txtpassword)
        {
            CanvasDALC cabc = new CanvasDALC();
            return cabc.ChangePasswordUser(cid, txtpassword);
        }

        public int VerifyEmailInsertNewPassword(string MailID, string temppass)
        {
            CanvasDALC cabc = new CanvasDALC();
            return cabc.VerifyEmailInsertNewPassword(MailID, temppass);
        }

        public bool SaveSweepStakesData(SweepStakesData oSweep)
        {
            CanvasDALC cabc = new CanvasDALC();
            return cabc.SaveSweepStakesData(oSweep);
        }

        public string FetchSweepStakeUtilData(string aDID, string contentType)
        {
            CanvasDALC cabc = new CanvasDALC();
            return cabc.FetchSweepStakeUtilData(aDID, contentType);
        }

        public bool IsConfigForSweepstakes(string appconfigDID)
        {
            CanvasDALC cabc = new CanvasDALC();
            return cabc.IsConfigForSweepstakes(appconfigDID);
        }

        public bool SaveSweepStakesEntryInfo(SweepStakesEntryInfo sweepEntry)
        {
            CanvasDALC cabc = new CanvasDALC();
            return cabc.SaveSweepStakesEntryInfo(sweepEntry);
        }

        public bool UpdateTempPwd(string MailID, string temppass)
        {
            CanvasDALC cabc = new CanvasDALC();
            return cabc.UpdateTempPwd(MailID, temppass);
        }
        public DataTable FetchConfigDataForLoggedInUser(string appCustDID)
        {
            CanvasDALC cabc = new CanvasDALC();
            return cabc.FetchConfigDataForLoggedInUser(appCustDID);
        }

        public bool InsertPreviewHTML(string HTML, string CDID, string PDID)
        {
            CanvasDALC cabc = new CanvasDALC();
            return cabc.InsertPreviewHTML(HTML, CDID, PDID);
        }

        public int CheckUserEmail(string txtEmailID)
        {
            CanvasDALC cabc = new CanvasDALC();
            return cabc.CheckUserEmail(txtEmailID);
        }

        public int ConfirmResetPassword(string cid)
        {
            CanvasDALC cabc = new CanvasDALC();
            return cabc.ConfirmResetPassword(cid);
        }

        public int UpdatefpStatus(string cid, int status)
        {
            CanvasDALC cabc = new CanvasDALC();
            return cabc.UpdatefpStatus(cid, status);
        }

        public DataSet GetCountryList()
        {
            CanvasDALC cabc = new CanvasDALC();
            return cabc.GetCountryList();
        }

        public bool UpdatePreviewHTML(string HTML, string CDID, string PDID)
        {
            CanvasDALC cabc = new CanvasDALC();
            return cabc.UpdatePreviewHTML(HTML,CDID,PDID);
        }

        public bool SaveCouponData(SweepStakesData oSweep)
        {
            CanvasDALC cabc = new CanvasDALC();
            return cabc.SaveCouponData(oSweep);
        }

        public bool UpdateSweepStakesData(SweepStakesData oSweep)
        {
            CanvasDALC cabc = new CanvasDALC();
            return cabc.UpdateSweepStakesData(oSweep);
        }

        public string GetSweepWinnersCount(string appConfigDID)
        {
            CanvasDALC cabc = new CanvasDALC();
            return cabc.GetSweepWinnersCount(appConfigDID);
        }

        public DataSet GetSweepWinners(int WinnerCount, string ADID)
        {
            CanvasDALC cabc = new CanvasDALC();
            return cabc.GetSweepWinners(WinnerCount, ADID);
        }

        public DataSet ShowSweepstakesWinner(string ADID)
        {
            CanvasDALC cabc = new CanvasDALC();
            return cabc.ShowSweepstakesWinner(ADID);
        }

        public bool IsSweepWinnerDeclared(string appconfigDID)
        {
            CanvasDALC cabc = new CanvasDALC();
            return cabc.IsSweepWinnerDeclared(appconfigDID);
        }

        public AppUser GetTwitterTokens(string ADID, string SMType, string soNetId)
        {
            CanvasDALC cabc = new CanvasDALC();
            return cabc.GetTwitterTokens(ADID, SMType, soNetId);
        }

        public PreferenceData GetPReferenceDataForUserPreference(string PrefID)
        {
            CanvasDALC cabc = new CanvasDALC();
            return cabc.GetPReferenceDataForUserPreference(PrefID);
        }

    }
}
