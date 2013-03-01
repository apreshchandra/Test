
using System;
using System.Collections.Generic;
using DigiMa.DataAccess;
using DigiMa.Common;
using DigiMa.Data;
using System.Linq;
using System.Data;
using System.Text;

namespace DigiMa.BizProcess
{
    public class FacebookBizProcess : BizBase
    {
        public FacebookBizProcess() { }
        public FacebookBizProcess(SonetPie osonetpie) : base(osonetpie) { }
        FacebookDALC fbDALC = new FacebookDALC();
        public bool SetAppUserAuthorize(AppUser oAppUser, string ADID)
        {
            try
            {
                //Check set is sucess or not
                bool _bSetAppUserSuccess = false;

                //Check AppUser Exist or not
                if (!fbDALC.IsAppUserActive(ADID, oAppUser))
                {
                    //Set New DID from DB
                    oAppUser.DID = oAppUser.GetNewDIDWithPrefix();
                    if (fbDALC.IsAppUserExist(ADID, ref oAppUser))
                        _bSetAppUserSuccess = fbDALC.EditAppUserDetails(GetSonetPie, oAppUser);
                    else
                        _bSetAppUserSuccess = fbDALC.AddAppUserDetails(GetSonetPie, oAppUser);

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

        public AppUser GetAppUser(SonetPie sonetpie, string ADID, string user_id)
        {
            try
            {
                //Load AppCustomer into object
                return fbDALC.GetAppUser(sonetpie, ADID, user_id);
            }
            catch (Exception ex)
            {
                //Log4NetUtility.ErrorDebug(this.GetType().FullName, "Error in DCAppConfiguration GetAppConfiguration()", ex);
                throw ex;
            }
        }

        public bool EditAppNotifierDetails(AppNotifier _oAppNotifier)
        {
            try
            {
                return fbDALC.EditAppNotifierDetails(_oAppNotifier);
            }
            catch (Exception ex)
            {
                //Log4NetUtility.ErrorDebug(this.GetType().FullName, "Error in DCAppConfiguration GetAppConfiguration()", ex);
                throw ex;
            }
        }

        public AppProduct GetActiveAppProduct(SonetPie osonetpie, string ADID)
        {
            try
            {
                //Load AppCustomer into object
                return fbDALC.GetActiveAppProduct(osonetpie, ADID);
            }
            catch (Exception ex)
            {
                //Log4NetUtility.ErrorDebug(this.GetType().FullName, "Error in DCAppConfiguration GetAppConfiguration()", ex);
                throw ex;
            }
        }

        public bool RaiseAppNotifier(AppUser oDCAppUser, string NTYP, string UDID, string PDID, string NDID, string SFID) //For POST
        {
            //Check Event is sucess or not
            bool _bSetAppNotifierSuccess = false;
            try
            {

                //Validate NTYP before switching to respective notifier
                if (string.IsNullOrEmpty(NTYP)) return _bSetAppNotifierSuccess;

                //Build Post DCAppNotifier
                AppNotifier _oDCAppNotifier = new AppNotifier();
                _oDCAppNotifier.AppUserDID = UDID;
                _oDCAppNotifier.AppProductDID = PDID;

                //Check if NDID already defined if so use it
                if (!string.IsNullOrEmpty(NDID))
                    _oDCAppNotifier.DID = NDID;
                else
                    _oDCAppNotifier.DID = _oDCAppNotifier.GetNewDIDWithPrefix();

                _oDCAppNotifier.NoOfVisits = 0;

                //Check which notifier to call based on NTYP
                switch (NTYP.ToUpper())
                {
                    case "POST":
                        _oDCAppNotifier.NotifierType = "POST";

                        _oDCAppNotifier.SoNetFriendID = SFID;
                        _oDCAppNotifier.SoNetFriendName = string.Empty;

                        _bSetAppNotifierSuccess = fbDALC.AddAppNotifierDetails(GetSonetPie, _oDCAppNotifier);
                        break;
                    case "MPOST": _oDCAppNotifier.NotifierType = "MPOST";
                        _oDCAppNotifier.SoNetFriendID = SFID;
                        if (!SFID.Contains(","))
                        {
                            _bSetAppNotifierSuccess = fbDALC.AddAppNotifierDetails(GetSonetPie, _oDCAppNotifier);
                        }
                        break;
                    default:
                        _bSetAppNotifierSuccess = false;
                        break;
                }

                return _bSetAppNotifierSuccess;
            }
            catch (Exception ex)
            {
                //Log4NetUtility.ErrorDebug(this.GetType().FullName, "Error in DCAppConfiguration GetAppConfiguration()", ex);
                throw ex;
            }
        }

        public bool RaiseAppNotifier(AppUser oDCAppUser, string NTYP, string UDID, string PDID, string NDID, AppLeadData oAppLeadData, string TO_id) //For Share, Like, Lead
        {
            //Check Event is sucess or not
            bool _bSetAppNotifierSuccess = false;
            try
            {

                //Validate NTYP before switching to respective notifier
                if (string.IsNullOrEmpty(NTYP)) return _bSetAppNotifierSuccess;

                //Build Post DCAppNotifier
                AppNotifier _oDCAppNotifier = new AppNotifier();
                _oDCAppNotifier.AppUserDID = UDID;
                _oDCAppNotifier.AppProductDID = PDID;

                //Check if NDID already defined if so use it
                if (!string.IsNullOrEmpty(NDID))
                    _oDCAppNotifier.DID = NDID;
                else
                    _oDCAppNotifier.DID = _oDCAppNotifier.GetNewDIDWithPrefix();

                _oDCAppNotifier.NoOfVisits = 0;

                //Check which notifier to call based on NTYP
                switch (NTYP.ToUpper())
                {
                    case "SHARE":
                        _oDCAppNotifier.NotifierType = "SHARE";
                        _bSetAppNotifierSuccess = fbDALC.AddAppNotifierDetails(GetSonetPie, _oDCAppNotifier);
                        break;

                    case "LEAD":
                        _oDCAppNotifier.NotifierType = "LEAD";
                        _oDCAppNotifier.SoNetEmailID = oAppLeadData.EmailID;
                        _oDCAppNotifier.SoNetEmailContext = oAppLeadData.Subject;
                        _oDCAppNotifier.SoNetEmailContent = oAppLeadData.Body;
                        _bSetAppNotifierSuccess = fbDALC.AddAppNotifierDetails(GetSonetPie, _oDCAppNotifier);
                        break;

                    case "LIKE": _oDCAppNotifier.NotifierType = "LIKE";
                        _bSetAppNotifierSuccess = fbDALC.AddAppNotifierDetails(GetSonetPie, _oDCAppNotifier);
                        break;
                    case "MSHARE": _oDCAppNotifier.NotifierType = "MSHARE";
                        _bSetAppNotifierSuccess = fbDALC.AddAppNotifierDetails(GetSonetPie, _oDCAppNotifier);
                        break;

                    case "TWEET": _oDCAppNotifier.NotifierType = "TWEET";
                        _bSetAppNotifierSuccess = fbDALC.AddAppNotifierDetails(GetSonetPie, _oDCAppNotifier);
                        break;
                    case "MPOST": _oDCAppNotifier.NotifierType = "MPOST";
                        _oDCAppNotifier.SoNetFriendID = TO_id;
                        if (!TO_id.Contains(","))
                        {
                            _bSetAppNotifierSuccess = fbDALC.AddAppNotifierDetails(GetSonetPie, _oDCAppNotifier);
                        }
                        break;
                    case "MLIKE": _oDCAppNotifier.NotifierType = "MLIKE";
                        _bSetAppNotifierSuccess = fbDALC.AddAppNotifierDetails(GetSonetPie, _oDCAppNotifier);
                        break;

                    case "CLICK":
                        _oDCAppNotifier.NotifierType = "CLICK";
                        _bSetAppNotifierSuccess = fbDALC.AddAppNotifierDetails(GetSonetPie, _oDCAppNotifier);
                        break;
                    case "LISHARE": _oDCAppNotifier.NotifierType = "LISHARE";
                        _bSetAppNotifierSuccess = fbDALC.AddAppNotifierDetails(GetSonetPie, _oDCAppNotifier);
                        break;
                    default:
                        _bSetAppNotifierSuccess = false;
                        break;
                }

                return _bSetAppNotifierSuccess;
            }
            catch (Exception ex)
            {
                //Log4NetUtility.ErrorDebug(this.GetType().FullName, "Error in DCAppConfiguration GetAppConfiguration()", ex);
                throw ex;
            }
        }

        public bool RaiseAppNotifier(AppUser oDCAppUser, string NTYP, string UDID, string PDID, string NDID) //For Print,Email
        {
            //Check Event is sucess or not
            bool _bSetAppNotifierSuccess = false;
            try
            {

                //Validate NTYP before switching to respective notifier
                if (string.IsNullOrEmpty(NTYP)) return _bSetAppNotifierSuccess;

                //Build Post DCAppNotifier
                AppNotifier _oDCAppNotifier = new AppNotifier();
                _oDCAppNotifier.AppUserDID = UDID;
                _oDCAppNotifier.AppProductDID = PDID;

                //Check if NDID already defined if so use it
                if (!string.IsNullOrEmpty(NDID))
                    _oDCAppNotifier.DID = NDID;
                else
                    _oDCAppNotifier.DID = _oDCAppNotifier.GetNewDIDWithPrefix();

                _oDCAppNotifier.NoOfVisits = 0;

                //Check which notifier to call based on NTYP
                switch (NTYP.ToUpper())
                {
                    case "PRINT":
                        _oDCAppNotifier.NotifierType = "PRINT";
                        _bSetAppNotifierSuccess = fbDALC.AddAppNotifierDetails(GetSonetPie, _oDCAppNotifier);
                        break;

                    case "EMAIL":
                        _oDCAppNotifier.NotifierType = "LIKE";
                        _bSetAppNotifierSuccess = fbDALC.AddAppNotifierDetails(GetSonetPie, _oDCAppNotifier);
                        break;

                    default:
                        _bSetAppNotifierSuccess = false;
                        break;
                }

                return _bSetAppNotifierSuccess;
            }
            catch (Exception ex)
            {
                //Log4NetUtility.ErrorDebug(this.GetType().FullName, "Error in DCAppConfiguration GetAppConfiguration()", ex);
                throw ex;
            }
        }

        public AppCustomer GetAppCustomer(string CDID)
        {
            try
            {
                return fbDALC.GetAppCustomer(CDID);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public AppProduct GetAppProduct(string ADID)
        {
            try
            {
                return fbDALC.GetAppProduct(ADID);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public AppProduct GetAppProductDetails(SonetPie osonetpie, string PDID)
        {
            try
            {
                return fbDALC.GetAppProductDetails(osonetpie, PDID);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool UpdateProductImagesAndContent(string PDID, Byte[] imgArrayHeader, string typeOfImage, string URL)
        {
            try
            {
                return fbDALC.UpdateProductImagesAndContent(PDID, imgArrayHeader, typeOfImage, URL);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool SetNewConfigDetails(AppConfiguration oAppConfig, string CustTabName, string AppModel)
        {
            try
            {
                return fbDALC.SetNewConfigDetails(oAppConfig, CustTabName, AppModel);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public AppConfiguration GetAppConfiguration(string AppName, string appID)
        {
            try
            {
                return fbDALC.GetAppConfiguration(AppName, appID);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool SetNewProductDetails(AppProduct oAppProduct)
        {
            try
            {
                return fbDALC.SetNewProductDetails(oAppProduct);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public AppProduct GetAppProductDetails()
        {
            try
            {
                return fbDALC.GetAppProductDetails();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool UpdateAppConfigForFacebook(AppConfiguration oAppConfig)
        {
            try
            {
                return fbDALC.UpdateAppConfigForFacebook(oAppConfig);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public AppConfiguration GetAvailableConfig(string CDID)
        {
            try
            {
                return fbDALC.GetAvailableConfig(CDID);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool IsConfigurationExpired(string appConfigDID)
        {
            try
            {
                return fbDALC.IsConfigurationExpired(appConfigDID);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool IsAppCreationAllowed(string CDID)
        {
            try
            {
                return fbDALC.IsAppCreationAllowed(CDID);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool UpdateAppPagePath(string path, string appID, string pageID)
        {
            try
            {
                return fbDALC.UpdateAppPagePath(path, appID, pageID);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public string GetAppPagePath(string ADID)
        {
            try
            {
                return fbDALC.GetAppPagePath(ADID);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string GetPageID(string ADID)
        {
            try
            {
                return fbDALC.GetPageID(ADID);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool UpdateCustomTabNAme(string ADID)
        {
            try
            {
                return fbDALC.UpdateCustomTabNAme(ADID);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool AddToLikeGatewayData(string user_id, string app_id)
        {
            try
            {
                return fbDALC.AddToLikeGatewayData(user_id, app_id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool IsAppLikedByUser(string app_id, string user_id)
        {
            try
            {
                return fbDALC.IsAppLikedByUser(app_id, user_id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public string GetCustomTabName(string AppID)
        {
            try
            {
                return fbDALC.GetCustomTabName(AppID);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public bool CheckIfSweepstakeAlreadyEntered(string ADID, string sonetID)
        {
            try
            {
                return fbDALC.CheckIfSweepstakeAlreadyEntered(ADID, sonetID);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string GetAppName(string AppID)
        {
            try
            {
                return fbDALC.GetAppName(AppID);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool IsUserCreatedForFacebook(string user_id, string appConfigDID)
        {
            try
            {
                return fbDALC.IsUserCreatedForFacebook(user_id, appConfigDID);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string GetAppSecret(string appID)
        {
            try
            {
                return fbDALC.GetAppSecret(appID);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public string FetchAppLogo(string appID)
        {
            try
            {
                return fbDALC.FetchAppLogo(appID);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int GetLikeCount(string AppproductDID)
        {
            try
            {
                return fbDALC.GetLikeCount(AppproductDID);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool CheckLikeNotify(string UDID)
        {
            try
            {
                return fbDALC.CheckLikeNotify(UDID);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string GetTemplatePage(string AppName)
        {
            try
            {
                return fbDALC.GetTemplatePage(AppName);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public SweepStakesData GetSweepDataForEditing(string ADID)
        {
            try
            {
                return fbDALC.GetSweepDataForEditing(ADID);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool UpdateConfigDetails(AppConfiguration oAppConfig, string ModelType, string CustTabName)
        {
            try
            {
                return fbDALC.UpdateConfigDetails(oAppConfig, ModelType, CustTabName);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool UpdateProductDetails(AppProduct oAppProduct)
        {
            try
            {
                return fbDALC.UpdateProductDetails(oAppProduct);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string GetProductHTML(string DID)
        {
            try
            {
                return fbDALC.GetProductHTML(DID);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string GetInquiryEmail(string ADID)
        {
            try
            {
                return fbDALC.GetInquiryEmail(ADID);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string GetCouponImgPath(string DID)
        {
            try
            {
                return fbDALC.GetCouponImgPath(DID);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string GetExpiryDate(string AppConfigDID)
        {
            try
            {
                return fbDALC.GetExpiryDate(AppConfigDID);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string GetCouponDetails(string AppConfigDID)
        {
            try
            {
                return fbDALC.GetCouponDetails(AppConfigDID);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string GetCouponCode(string AppConfigDID)
        {
            try
            {
                return fbDALC.GetCouponCode(AppConfigDID);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool IsLikeGatewayAdded(string appConfigDID)
        {
            try
            {
                return fbDALC.IsLikeGatewayAdded(appConfigDID);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool InsertVideoShareData(string appConfigDID, string vidURL, string vidURLConverted, string vidDesc)
        {
            try
            {
                return fbDALC.InsertVideoShareData(appConfigDID, vidURL, vidURLConverted, vidDesc);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public VideoShareData GetVideoShareData(string appConfigDID)
        {
            try
            {
                return fbDALC.GetVideoShareData(appConfigDID);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool UpdateVideoShareData(string appConfigDID, string vidURL, string vidURLConverted, string vidDesc)
        {
            try
            {
                return fbDALC.UpdateVideoShareData(appConfigDID, vidURL, vidURLConverted, vidDesc);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string GetCustomLogo(string PDID)
        {
            try
            {
                return fbDALC.GetCustomLogo(PDID);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable GetPreviewProduct(string PDID)
        {
            try
            {
                //Load AppCustomer into object
                return fbDALC.GetPreviewProduct(PDID);
            }
            catch (Exception ex)
            {
                //Log4NetUtility.ErrorDebug(this.GetType().FullName, "Error in DCAppConfiguration GetAppConfiguration()", ex);
                throw ex;
            }
        }

        public string IsSweepstakesAppModel(string appConfigDID)
        {
            try
            {
                return fbDALC.IsSweepstakesAppModel(appConfigDID);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool IsSweepstakesWinnerDay(string appConfigDID)
        {
            try
            {
                return fbDALC.IsSweepstakesWinnerDay(appConfigDID);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string GetSweepstakesEndDate(string appConfigDID)
        {
            try
            {
                return fbDALC.GetSweepstakesEndDate(appConfigDID);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool InsertErrData(string errData)
        {
            try
            {
                return fbDALC.InsertErrData(errData);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public string GetConfigDEED(string appID)
        {
            try
            {
                return fbDALC.GetConfigDEED(appID);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string GetUserDID(string ADID, string sonetID)
        {
            try
            {
                return fbDALC.GetUserDID(ADID, sonetID);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string GetAppPath(string appID)
        {
            try
            {
                return fbDALC.GetAppPath(appID);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool IsAppUserExistMobile(AppUser oDCAppUser)
        {
            try
            {
                return fbDALC.IsAppUserExistMobile(oDCAppUser);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string GetNotifierDID(string PDID)
        {
            try
            {
                return fbDALC.GetNotifierDID(PDID);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool UpdateConfigExpiryForWH(string DID)
        {
            try
            {
                return fbDALC.UpdateConfigExpiryForWH(DID);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool SetUserAction(UserAction oUserAction)
        {
            try
            {
                return fbDALC.SetUserAction(oUserAction);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public string GetSiteIDForConfig(string ADID)
        {
            try
            {
                return fbDALC.GetSiteIDForConfig(ADID);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int GetTemplateIDForConfig(string ADID)
        {
            try
            {
                return fbDALC.GetTemplateIDForConfig(ADID);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string GetProductDID(string ADID)
        {
            try
            {
                return fbDALC.GetProductDID(ADID);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool InsertMicrositesData(string CustID, string MicroSiteName)
        {
            try
            {
                return fbDALC.InsertMicrositesData(CustID, MicroSiteName);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int CheckMicroSiteName(string txtEmailID)
        {
            try
            {
                return fbDALC.CheckMicroSiteName(txtEmailID);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
