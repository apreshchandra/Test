using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DigiMa.DataAccess;
using DigiMa.Common;
using DigiMa.Data;

namespace DigiMa.BizProcess
{
    public class TwitterBizProcess:BizBase
    {
        public TwitterBizProcess() { }
        public TwitterBizProcess(SonetPie osonetpie) : base(osonetpie) { }
        TwitterDALC TwDALC = new TwitterDALC();


        public bool SetAppUserAuthorize(AppUser oAppUser, string ADID)
        {
            try
            {
                //Check set is sucess or not
                bool _bSetAppUserSuccess = false;

                //Check AppUser Exist or not
                if (!TwDALC.IsAppUserActive(ADID, oAppUser))
                {
                    //Set New DID from DB
                    oAppUser.DID = oAppUser.GetNewDIDWithPrefix();
                    if (TwDALC.IsAppUserExist(ADID, ref oAppUser))
                        _bSetAppUserSuccess = TwDALC.EditAppUserDetails(GetSonetPie, oAppUser);
                    else
                        _bSetAppUserSuccess = TwDALC.AddAppUserDetails(GetSonetPie, oAppUser);

                    ////Insert AppEvent for authorize
                    //if (_bSetAppUserSuccess)
                    //{
                    //    //Raise Log Event for Authorize
                    //    _bSetAppUserSuccess = new BizAppUserEvent(GetsoNetKoKo).LogUserEventAuthorize(oDCAppUser);
                    //}
                }

                return _bSetAppUserSuccess;
            }
            catch (Exception ex)
            {
                //Log4NetUtility.ErrorDebug(this.GetType().FullName, "Error in DCAppConfiguration GetAppConfiguration()", ex);
                throw ex;
            }
        }

        public bool IsUserCreatedForTwitter(string user_id, string appConfigDID)
        {
            try
            {
                return TwDALC.IsUserCreatedForTwitter(user_id, appConfigDID);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
