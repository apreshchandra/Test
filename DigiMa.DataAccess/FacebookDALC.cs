using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using DigiMa.Common;
using System.Web;
using DigiMa.Data;
using System.Net;
using System.IO;
using System.Text;

namespace DigiMa.DataAccess
{
    public class FacebookDALC
    {
        private const string YES = "Y";
        CommonUtility objCommon = new CommonUtility();

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

        public AppUser GetAppUser(SonetPie sonetpie, string ADID, string user_id)
        {
            try
            {
                DatabaseHandler oDBH = new DatabaseHandler();

                DataTable oAppUserDataTable = oDBH.FillData_SP("GetAppUser", ADID, user_id).Tables[0];
                if (oAppUserDataTable != null)
                {
                    AppUser _oAppUser = new AppUser();
                    _oAppUser.DID = oAppUserDataTable.Rows[0]["DID"].ToString();
                    _oAppUser.AppConfigDID = oAppUserDataTable.Rows[0]["AppConfigDID"].ToString();
                    _oAppUser.UserName = oAppUserDataTable.Rows[0]["UserName"].ToString();
                    _oAppUser.SonetID = oAppUserDataTable.Rows[0]["soNetID"].ToString();
                    _oAppUser.SonetSRC = oAppUserDataTable.Rows[0]["soNetSRC"].ToString();
                    _oAppUser.ImageURL = oAppUserDataTable.Rows[0]["ImageURL"].ToString();
                    _oAppUser.City = oAppUserDataTable.Rows[0]["City"].ToString();
                    _oAppUser.State = oAppUserDataTable.Rows[0]["State"].ToString();
                    _oAppUser.Country = oAppUserDataTable.Rows[0]["Country"].ToString();
                    _oAppUser.EmailID = oAppUserDataTable.Rows[0]["EmailID"].ToString();
                    _oAppUser.UserStatus = oAppUserDataTable.Rows[0]["UserStatus"].ToString();
                    _oAppUser.Gender = oAppUserDataTable.Rows[0]["Gender"].ToString();
                    _oAppUser.EmailSubscription = oAppUserDataTable.Rows[0]["EmailSubscription"].ToString();
                    _oAppUser.SubscriptionEmailID = oAppUserDataTable.Rows[0]["SubscriptionEmailID"].ToString();
                    _oAppUser.SubscriptionReferral = oAppUserDataTable.Rows[0]["SubscriptionReferral"].ToString();
                    _oAppUser.SBirthdate = oAppUserDataTable.Rows[0]["Birthday"].ToString();
                    return _oAppUser;
                }
                else { return null; }
            }
            catch (Exception ex)
            {
                //Log4NetUtility.ErrorDebug(this.GetType().FullName, "Error in GetConfigData(string _AppId)", ex);
                throw ex;
            }
        } //DONE
        public AppConfiguration GetAppConfiguration(string appName, string appID)
        {
            try
            {
                DatabaseHandler oDBH = new DatabaseHandler();

                DataSet oAppConfDataSet = oDBH.FillData_SP("GetAppConfiguration", appName, appID);
                if (oAppConfDataSet.Tables.Count > 0)
                {
                    AppConfiguration _oAppConfiguration = new AppConfiguration();
                    _oAppConfiguration.DID = oAppConfDataSet.Tables[0].Rows[0]["DID"].ToString();
                    _oAppConfiguration.AppCustomerDID = oAppConfDataSet.Tables[0].Rows[0]["AppCustomerDID"].ToString();
                    _oAppConfiguration.AppType = oAppConfDataSet.Tables[0].Rows[0]["AppType"].ToString();
                    _oAppConfiguration.AppID = oAppConfDataSet.Tables[0].Rows[0]["AppID"].ToString();
                    _oAppConfiguration.AppKey = oAppConfDataSet.Tables[0].Rows[0]["AppKey"].ToString();
                    _oAppConfiguration.AppSecretKey = oAppConfDataSet.Tables[0].Rows[0]["AppSecretKey"].ToString();
                    _oAppConfiguration.AppPath = HttpUtility.HtmlDecode(oAppConfDataSet.Tables[0].Rows[0]["AppPath"].ToString());
                    _oAppConfiguration.AppName = oAppConfDataSet.Tables[0].Rows[0]["AppName"].ToString();
                    _oAppConfiguration.AppLogo = HttpUtility.HtmlDecode(oAppConfDataSet.Tables[0].Rows[0]["AppLogo"].ToString());
                    _oAppConfiguration.AppHeader = HttpUtility.HtmlDecode(oAppConfDataSet.Tables[0].Rows[0]["AppHeader"].ToString());
                    _oAppConfiguration.AppFooter = HttpUtility.HtmlDecode(oAppConfDataSet.Tables[0].Rows[0]["AppFooter"].ToString());
                    _oAppConfiguration.AppExpiryPath = HttpUtility.HtmlDecode(oAppConfDataSet.Tables[0].Rows[0]["AppExpiryPath"].ToString());
                    _oAppConfiguration.AppExpiryDT = HttpUtility.HtmlDecode(oAppConfDataSet.Tables[0].Rows[0]["AppExpiryDT"].ToString());
                    _oAppConfiguration.SAppCustomNameAdded = HttpUtility.HtmlDecode(oAppConfDataSet.Tables[0].Rows[0]["CustomNameAdded"].ToString());
                    _oAppConfiguration.SAppPagePath = HttpUtility.HtmlDecode(oAppConfDataSet.Tables[0].Rows[0]["AppPagePath"].ToString());
                    _oAppConfiguration.SCustomtTabName = HttpUtility.HtmlDecode(oAppConfDataSet.Tables[0].Rows[0]["CustomTabName"].ToString());
                    _oAppConfiguration.SPageID = HttpUtility.HtmlDecode(oAppConfDataSet.Tables[0].Rows[0]["AppPageID"].ToString());
                    _oAppConfiguration.SAppStartDT = HttpUtility.HtmlDecode(oAppConfDataSet.Tables[0].Rows[0]["AppStartDT"].ToString());
                    _oAppConfiguration.STemplatePage = HttpUtility.HtmlDecode(oAppConfDataSet.Tables[0].Rows[0]["TemplatePage"].ToString());
                    _oAppConfiguration.SInquiryEmail = HttpUtility.HtmlDecode(oAppConfDataSet.Tables[0].Rows[0]["InquiryEmail"].ToString());
                    return _oAppConfiguration;
                }
                else { return null; }
            }

            catch (Exception ex)
            {
                //Log4NetUtility.ErrorDebug(this.GetType().FullName, "Error in GetConfigData(string _AppId)", ex);
                throw ex;
            }
        } //DONE
        public AppCustomer GetAppCustomer(string CDID)
        {
            try
            {
                DatabaseHandler oDBH = new DatabaseHandler();
                DataTable oAppCustDataTable = oDBH.FillData_SP("GetAppCustomer", CDID).Tables[0];
                if (oAppCustDataTable != null)
                {
                    AppCustomer _oAppCustomer = new AppCustomer();
                    _oAppCustomer.CustomerID = oAppCustDataTable.Rows[0]["cid"].ToString();
                    _oAppCustomer.SCustomerUserName = oAppCustDataTable.Rows[0]["username"].ToString();
                    _oAppCustomer.SCustomerEmail = oAppCustDataTable.Rows[0]["cemail"].ToString();
                    _oAppCustomer.SCustomerStatus = oAppCustDataTable.Rows[0]["cstatus"].ToString();
                    _oAppCustomer.SCustomerPWD = oAppCustDataTable.Rows[0]["password"].ToString();
                    _oAppCustomer.IsCoupon = oAppCustDataTable.Rows[0]["IsCoupon"].ToString();
                    _oAppCustomer.IsSweepStakes = oAppCustDataTable.Rows[0]["IsSweepStakes"].ToString();
                    _oAppCustomer.IsMultiPage = oAppCustDataTable.Rows[0]["IsMultiPage"].ToString();
                    return _oAppCustomer;
                }
                else { return null; }
            }
            catch (Exception ex)
            {
                //Log4NetUtility.ErrorDebug(this.GetType().FullName, "Error in GetConfigData(string _AppId)", ex);
                throw ex;
            }
        } //DONE
        public bool AddAppNotifierDetails(SonetPie osonetpie, AppNotifier oDCAppNotifier)
        {
            try
            {
                DatabaseHandler oDBH = new DatabaseHandler();

                int i = oDBH.ExecuteNonQuery_SP("AddAppNotifierDetails", oDCAppNotifier.DID, oDCAppNotifier.AppProductDID, oDCAppNotifier.AppUserDID, oDCAppNotifier.SoNetFriendID, oDCAppNotifier.SoNetFriendName, oDCAppNotifier.NotifierType, oDCAppNotifier.NoOfVisits.ToString(), oDCAppNotifier.SoNetEmailID, oDCAppNotifier.SoNetEmailContext, oDCAppNotifier.SoNetEmailContent);
                if (i < 0) return false; else return true;
            }
            catch (Exception ex)
            {
                //Log4NetUtility.ErrorDebug(this.GetType().FullName, "Error in GetConfigData(string _AppId)", ex);
                throw ex;
            }
        }//DONE

        public bool EditAppNotifierDetails(AppNotifier oDCAppNotifier)
        {
            try
            {
                DatabaseHandler oDBH = new DatabaseHandler();
                StringBuilder oSBQuery = new StringBuilder();

                oDBH.FillData_SP("EditAppNotifierDetails", oDCAppNotifier.DID);
                return true;
            }
            catch (Exception ex)
            {
                //Log4NetUtility.ErrorDebug(this.GetType().FullName, "Error in GetConfigData(string _AppId)", ex);
                throw ex;
            }
        } //DONE

        public AppProduct GetAppProduct(string ADID)
        {
            //try
            //{
            //    DatabaseHandler oDBH = new DatabaseHandler();
            //    return oDBH.FillData_SP("GetAppProduct", osonetpie.QSvars["ADID"].ToString()).Tables[0];
            //}
            //catch (Exception ex)
            //{
            //    //Log4NetUtility.ErrorDebug(this.GetType().FullName, "Error in GetConfigData(string _AppId)", ex);
            //    throw ex;
            //}
            try
            {
                DatabaseHandler oDBH = new DatabaseHandler();
                DataSet dsFinalHTML = new DataSet();

                dsFinalHTML = oDBH.FillData_SP("GetAppProduct", ADID);
                if (dsFinalHTML.Tables.Count > 0)
                {
                    AppProduct _oAppProduct = new AppProduct();
                    _oAppProduct.DID = dsFinalHTML.Tables[0].Rows[0]["DID"].ToString();
                    _oAppProduct.AppConfigDID = dsFinalHTML.Tables[0].Rows[0]["AppConfigDID"].ToString();

                    return _oAppProduct;
                }
                else { return null; }
            }
            catch (Exception ex)
            {
                //Log4NetUtility.ErrorDebug(this.GetType().FullName, "Error in GetConfigData(string _AppId)", ex);
                throw ex;
            }

        } //DONE

        public AppProduct GetActiveAppProduct(SonetPie osonetpie, string ADID)
        {
            try
            {
                DatabaseHandler oDBH = new DatabaseHandler();
                DataSet dsFinalHTML = new DataSet();
                dsFinalHTML = oDBH.FillData_SP("GetActiveAppProduct", ADID);
                if (dsFinalHTML.Tables.Count > 0)
                {
                    AppProduct oAppProduct = new AppProduct();
                    oAppProduct.ProductHTML = dsFinalHTML.Tables[0].Rows[0]["producthtml"].ToString();
                    oAppProduct.AppConfigDID = dsFinalHTML.Tables[0].Rows[0]["AppConfigDID"].ToString();
                    oAppProduct.DID = dsFinalHTML.Tables[0].Rows[0]["DID"].ToString();
                    oAppProduct.ProductStatus = dsFinalHTML.Tables[0].Rows[0]["ProductStatus"].ToString();
                    oAppProduct.ProductName = dsFinalHTML.Tables[0].Rows[0]["ProductName"].ToString();
                    oAppProduct.ShareWidgetAdded = dsFinalHTML.Tables[0].Rows[0]["ShareWidgetAdded"].ToString();
                    oAppProduct.CommentsWidgetAdded = dsFinalHTML.Tables[0].Rows[0]["CommentsWidgetAdded"].ToString();
                    oAppProduct.LikeWidgetAdded = dsFinalHTML.Tables[0].Rows[0]["LikeWidgetAdded"].ToString();
                    oAppProduct.LikeGatewayAdded = dsFinalHTML.Tables[0].Rows[0]["LikeGatewayAdded"].ToString();
                    oAppProduct.InquiryWidgetAdded = dsFinalHTML.Tables[0].Rows[0]["InquiryWidgetAdded"].ToString();
                    oAppProduct.ReccWidgetAdded = dsFinalHTML.Tables[0].Rows[0]["ReccWidgetAdded"].ToString();
                    oAppProduct.AppCaption = dsFinalHTML.Tables[0].Rows[0]["AppCaption"].ToString();
                    oAppProduct.CanvasHeight = dsFinalHTML.Tables[0].Rows[0]["AppCanvasHeight"].ToString();
                    oAppProduct.CanvasWidth = dsFinalHTML.Tables[0].Rows[0]["AppCanvasWidth"].ToString();
                    oAppProduct.SProductHeaderImage = dsFinalHTML.Tables[0].Rows[0]["ProductHeaderImage"].ToString();
                    oAppProduct.SProductContentImage = dsFinalHTML.Tables[0].Rows[0]["ProductContentImage"].ToString();
                    oAppProduct.SProductFooterImage = dsFinalHTML.Tables[0].Rows[0]["ProductFooterImage"].ToString();
                    oAppProduct.TwitterWidgetAdded = dsFinalHTML.Tables[0].Rows[0]["TwitterWidgetAdded"].ToString();
                    oAppProduct.SHeaderBannerImg = dsFinalHTML.Tables[0].Rows[0]["ProductBannerImage"].ToString();
                    oAppProduct.SHeaderBannerURL = dsFinalHTML.Tables[0].Rows[0]["ProductBannerURL"].ToString();
                    oAppProduct.ProductCategory = dsFinalHTML.Tables[0].Rows[0]["ProductCategory"].ToString();
                    return oAppProduct;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                //Log4NetUtility.ErrorDebug(this.GetType().FullName, "Error in GetConfigData(string _AppId)", ex);
                throw ex;
            }
        }//DONE

        public AppProduct GetAppProductDetails(SonetPie osonetpie, string PDID)
        {
            try
            {
                DatabaseHandler oDBH = new DatabaseHandler();
                DataSet dsFinalHTML = new DataSet();

                dsFinalHTML = oDBH.FillData_SP("GetAppProductDetails");
                if (dsFinalHTML.Tables.Count > 0)
                {
                    AppProduct _oAppProduct = new AppProduct();
                    _oAppProduct.DID = dsFinalHTML.Tables[0].Rows[0]["DID"].ToString();
                    _oAppProduct.AppConfigDID = dsFinalHTML.Tables[0].Rows[0]["AppConfigDID"].ToString();
                    _oAppProduct.ProductCategory = dsFinalHTML.Tables[0].Rows[0]["ProductCategory"].ToString();
                    _oAppProduct.ProductName = dsFinalHTML.Tables[0].Rows[0]["ProductName"].ToString();
                    _oAppProduct.ProductLogo = HttpUtility.HtmlDecode(dsFinalHTML.Tables[0].Rows[0]["ProductLogo"].ToString());
                    _oAppProduct.ProductShortDesc = dsFinalHTML.Tables[0].Rows[0]["ProductShortDesc"].ToString();
                    _oAppProduct.ProductDesc = HttpUtility.HtmlDecode(dsFinalHTML.Tables[0].Rows[0]["ProductDesc"].ToString());
                    _oAppProduct.ProductHTML = HttpUtility.HtmlDecode(dsFinalHTML.Tables[0].Rows[0]["ProductHTML"].ToString());
                    _oAppProduct.ProductStatus = dsFinalHTML.Tables[0].Rows[0]["ProductStatus"].ToString();
                    _oAppProduct.Email = dsFinalHTML.Tables[0].Rows[0]["eMail"].ToString();
                    _oAppProduct.ShareWidgetAdded = dsFinalHTML.Tables[0].Rows[0]["ShareWidgetAdded"].ToString();
                    _oAppProduct.ReccWidgetAdded = dsFinalHTML.Tables[0].Rows[0]["ReccWidgetAdded"].ToString();
                    _oAppProduct.InquiryWidgetAdded = dsFinalHTML.Tables[0].Rows[0]["InquiryWidgetAdded"].ToString();
                    _oAppProduct.CommentsWidgetAdded = dsFinalHTML.Tables[0].Rows[0]["CommentsWidgetAdded"].ToString();
                    _oAppProduct.LikeGatewayAdded = dsFinalHTML.Tables[0].Rows[0]["LikeGatewayAdded"].ToString();
                    _oAppProduct.LikeWidgetAdded = dsFinalHTML.Tables[0].Rows[0]["LikeWidgetAdded"].ToString();
                    _oAppProduct.CanvasHeight = dsFinalHTML.Tables[0].Rows[0]["AppCanvasHeight"].ToString();
                    _oAppProduct.CanvasWidth = dsFinalHTML.Tables[0].Rows[0]["AppCanvasWidth"].ToString();
                    _oAppProduct.AppCaption = dsFinalHTML.Tables[0].Rows[0]["AppCaption"].ToString();
                    return _oAppProduct;
                }
                else { return null; }
            }
            catch (Exception ex)
            {
                //Log4NetUtility.ErrorDebug(this.GetType().FullName, "Error in GetConfigData(string _AppId)", ex);
                throw ex;
            }
        } //DONE

        public bool UpdateProductImagesAndContent(string PDID, Byte[] imgArray, string typeOFImage, string URL) //METHOD NOT IN USE CURRENTLY [20March2012]
        {
            try
            {
                DatabaseHandler oDBH = new DatabaseHandler();
                StringBuilder oSBQuery = new StringBuilder();

                if (typeOFImage.Equals("HEADER"))
                {

                    SqlConnection con = new SqlConnection();
                    con.ConnectionString = oDBH.ConnectionString;

                    // Create SQL Command 

                    SqlCommand cmd = new SqlCommand();
                    cmd.CommandText = "UPDATE [AppProduct] " + "SET ProductHeaderImage = @ProductHeaderImage  where DID='@PDID'";
                    cmd.CommandType = CommandType.Text;
                    cmd.Connection = con;

                    SqlParameter UploadedImage = new SqlParameter
                                  ("@ProductHeaderImage", SqlDbType.Image, imgArray.Length);
                    UploadedImage.Value = imgArray;
                    SqlParameter productDID = new SqlParameter("@PDID", SqlDbType.NVarChar);
                    productDID.Value = PDID;
                    cmd.Parameters.Add(UploadedImage);
                    cmd.Parameters.Add(productDID);
                    con.Open();
                    int result = cmd.ExecuteNonQuery();
                    con.Close();
                    return true;
                }
                else if (typeOFImage.Equals("CONTENT"))
                {
                    SqlConnection con = new SqlConnection();
                    con.ConnectionString = oDBH.ConnectionString;

                    // Create SQL Command 

                    SqlCommand cmd = new SqlCommand();
                    cmd.CommandText = "UPDATE [AppProduct] " + "SET ProductContentImage = @ProductContentImage  where DID='@PDID'";
                    cmd.CommandType = CommandType.Text;
                    cmd.Connection = con;

                    SqlParameter UploadedImage = new SqlParameter
                                  ("@ProductContentImage", SqlDbType.Image, imgArray.Length);
                    UploadedImage.Value = imgArray;
                    SqlParameter productDID = new SqlParameter("@PDID", SqlDbType.NVarChar);
                    productDID.Value = PDID;
                    cmd.Parameters.Add(UploadedImage);
                    cmd.Parameters.Add(productDID);
                    con.Open();
                    int result = cmd.ExecuteNonQuery();
                    con.Close();
                    return true;
                }
                else
                {
                    SqlConnection con = new SqlConnection();
                    con.ConnectionString = oDBH.ConnectionString;

                    // Create SQL Command 

                    SqlCommand cmd = new SqlCommand();
                    cmd.CommandText = "UPDATE [AppProduct] " + "SET ProductFooterImage = @ProductFooterImage  where DID='@PDID'";
                    cmd.CommandType = CommandType.Text;
                    cmd.Connection = con;

                    SqlParameter UploadedImage = new SqlParameter
                                  ("@ProductFooterImage", SqlDbType.Image, imgArray.Length);
                    UploadedImage.Value = imgArray;
                    SqlParameter productDID = new SqlParameter("@PDID", SqlDbType.NVarChar);
                    productDID.Value = PDID;
                    cmd.Parameters.Add(UploadedImage);
                    cmd.Parameters.Add(productDID);
                    con.Open();
                    int result = cmd.ExecuteNonQuery();
                    con.Close();
                    return true;
                }
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
                DatabaseHandler oDBH = new DatabaseHandler();
                StringBuilder _sbQuery = new StringBuilder();

                int i = oDBH.ExecuteNonQuery_SP("SetNewConfigDetails", oAppConfig.DID, oAppConfig.AppCustomerDID, "Facebook", oAppConfig.AppID, oAppConfig.AppKey, oAppConfig.AppSecretKey, oAppConfig.AppPath, oAppConfig.AppName, oAppConfig.AppLogo, "", "", oAppConfig.AppExpiryPath, oAppConfig.AppExpiryDT, System.DBNull.Value, CustTabName, oAppConfig.SAppStartDT, oAppConfig.SInquiryEmail, oAppConfig.STemplatePage, oAppConfig.SCampaignType, 'N', oAppConfig.SSiteID, oAppConfig.STemplateID);

                if (i < 0) return false; else return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        } //DONE

        public bool SetNewProductDetails(AppProduct oAppProduct)
        {
            try
            {
                DatabaseHandler oDBH = new DatabaseHandler();
                StringBuilder _sbQuery = new StringBuilder();
                int i = oDBH.ExecuteNonQuery_SP("SetNewProductDetails", oAppProduct.DID,
                         oAppProduct.AppConfigDID,
                          oAppProduct.ProductCategory,
                          oAppProduct.ProductName,
                          oAppProduct.ProductLogo,
                          oAppProduct.ProductShortDesc,
                          oAppProduct.ProductDesc,
                          oAppProduct.ProductHTML,
                          "A",
                          oAppProduct.SProductContentImage,
                          oAppProduct.SProductHeaderImage,
                          oAppProduct.SProductFooterImage,
                          oAppProduct.SProductFooterURL, oAppProduct.ShareWidgetAdded, oAppProduct.LikeWidgetAdded, oAppProduct.ReccWidgetAdded, oAppProduct.CommentsWidgetAdded, oAppProduct.InquiryWidgetAdded, oAppProduct.LikeGatewayAdded, oAppProduct.CanvasHeight, oAppProduct.CanvasWidth, oAppProduct.AppCaption, oAppProduct.TwitterWidgetAdded, oAppProduct.SHeaderBannerImg, oAppProduct.SHeaderBannerURL);

                if (i < 0) return false; else return true;
            }
            catch (Exception ex)
            {
                objCommon.SendErrorMail(ex.Message, ex.StackTrace, System.Reflection.MethodBase.GetCurrentMethod().Name.ToString(), System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.ToString(), SessionData.Product.DID);
                throw ex;
            }
        } //DONE

        public AppProduct GetAppProductDetails()
        {
            try
            {
                DatabaseHandler oDBH = new DatabaseHandler();

                DataTable oAppCustDataTableOne = oDBH.FillData_SP("GetAppProductDetails").Tables[0];

                /*NOW FETCH PRODUCT DETAIL*/

                string sqlQuery = "select top 1 DID,AppConfigDID,ProductCategory,ProductName,ProductLogo,ProductShortDesc,ProductDesc,ProductHTML,ProductStatus,ShareWidgetAdded,LikeWidgetAdded,ReccWidgetAdded,CommentsWidgetAdded,InquiryWidgetAdded,LikeGatewayAdded,AppCanvasHeight,AppCanvasWidth,AppCaption,TwitterWidgetAdded,ProductBannerImage,ProductBannerURL from AppProduct with (nolock) where DID='" + oAppCustDataTableOne.Rows[0]["DID"].ToString() + "'";

                DataTable oAppCustDataTable = oDBH.FillData(sqlQuery).Tables[0];
                if (oAppCustDataTable != null)
                {
                    AppProduct _oAppProduct = new AppProduct();
                    _oAppProduct.DID = oAppCustDataTable.Rows[0]["DID"].ToString();
                    _oAppProduct.AppConfigDID = oAppCustDataTable.Rows[0]["AppConfigDID"].ToString();
                    _oAppProduct.ProductCategory = oAppCustDataTable.Rows[0]["ProductCategory"].ToString();
                    _oAppProduct.ProductName = oAppCustDataTable.Rows[0]["ProductName"].ToString();
                    _oAppProduct.ProductLogo = HttpUtility.HtmlDecode(oAppCustDataTable.Rows[0]["ProductLogo"].ToString());
                    _oAppProduct.ProductShortDesc = oAppCustDataTable.Rows[0]["ProductShortDesc"].ToString();
                    _oAppProduct.ProductDesc = HttpUtility.HtmlDecode(oAppCustDataTable.Rows[0]["ProductDesc"].ToString());
                    _oAppProduct.ProductHTML = HttpUtility.HtmlDecode(oAppCustDataTable.Rows[0]["ProductHTML"].ToString());
                    _oAppProduct.ProductStatus = oAppCustDataTable.Rows[0]["ProductStatus"].ToString();
                    _oAppProduct.ShareWidgetAdded = oAppCustDataTable.Rows[0]["ShareWidgetAdded"].ToString();
                    _oAppProduct.ReccWidgetAdded = oAppCustDataTable.Rows[0]["ReccWidgetAdded"].ToString();
                    _oAppProduct.InquiryWidgetAdded = oAppCustDataTable.Rows[0]["InquiryWidgetAdded"].ToString();
                    _oAppProduct.CommentsWidgetAdded = oAppCustDataTable.Rows[0]["CommentsWidgetAdded"].ToString();
                    _oAppProduct.LikeWidgetAdded = oAppCustDataTable.Rows[0]["LikeWidgetAdded"].ToString();
                    _oAppProduct.CanvasHeight = oAppCustDataTable.Rows[0]["AppCanvasHeight"].ToString();
                    _oAppProduct.CanvasWidth = oAppCustDataTable.Rows[0]["AppCanvasWidth"].ToString();
                    _oAppProduct.AppCaption = oAppCustDataTable.Rows[0]["AppCaption"].ToString();
                    _oAppProduct.TwitterWidgetAdded = oAppCustDataTable.Rows[0]["TwitterWidgetAdded"].ToString();
                    _oAppProduct.SHeaderBannerImg = oAppCustDataTable.Rows[0]["ProductBannerImage"].ToString();
                    _oAppProduct.SHeaderBannerURL = oAppCustDataTable.Rows[0]["ProductBannerURL"].ToString();
                    return _oAppProduct;
                }
                else { return null; }
            }
            catch (Exception ex)
            {
                //Log4NetUtility.ErrorDebug(this.GetType().FullName, "Error in GetConfigData(string _AppId)", ex);
                throw ex;
            }
        } //DONE

        public DataTable GetAppCustomerList()
        {
            try
            {
                DatabaseHandler dataAccess = new DatabaseHandler();
                string sqlQuery = "select * from AppCustomer with (nolock)";

                return dataAccess.FillData(sqlQuery).Tables[0];
            }
            catch (Exception ex)
            {
                //Log4NetUtility.ErrorDebug(this.GetType().FullName, "Error in GetConfigData(string _AppId)", ex);
                throw ex;
            }
        } //HOLD

        public bool UpdateAppConfigForFacebook(AppConfiguration oAppConfig)
        {
            try
            {
                DatabaseHandler oDBH = new DatabaseHandler();
                StringBuilder oSBQuery = new StringBuilder();

                //Already user is present update the record with status

                int i = oDBH.ExecuteNonQuery_SP("UpdateAppConfigForFacebook", oAppConfig.AppID, oAppConfig.AppKey, oAppConfig.AppSecretKey, oAppConfig.AppName, oAppConfig.AppPath);
                if (i < 0) return false; else return true;
            }
            catch (Exception ex)
            {
                //Log4NetUtility.ErrorDebug(this.GetType().FullName, "Error in GetConfigData(string _AppId)", ex);
                throw ex;
            }
        } //DONE

        public AppConfiguration GetAvailableConfig(string CDID)//DONE
        {
            try
            {
                DatabaseHandler oDBH = new DatabaseHandler();
                DataSet dsFinalHTML = new DataSet();
                AppConfiguration _oAppConfig = new AppConfiguration();

                dsFinalHTML = oDBH.FillData_SP("GetAvailableConfig");
                if (dsFinalHTML.Tables.Count > 0)
                {
                    if (dsFinalHTML.Tables[0].Rows.Count > 0)
                    {
                        _oAppConfig.AppCustomerDID = CDID;
                        _oAppConfig.AppID = dsFinalHTML.Tables[0].Rows[0]["AppID"].ToString();
                        objCommon.SendErrorMail(Convert.ToString(_oAppConfig.AppID), "DALC", "", "", "");
                        _oAppConfig.AppKey = dsFinalHTML.Tables[0].Rows[0]["AppKey"].ToString();
                        _oAppConfig.AppSecretKey = dsFinalHTML.Tables[0].Rows[0]["AppSecretKey"].ToString();
                        _oAppConfig.AppPath = dsFinalHTML.Tables[0].Rows[0]["AppName"].ToString();
                        _oAppConfig.AppName = dsFinalHTML.Tables[0].Rows[0]["AppType"].ToString();
                        //_oAppConfig.DID = new AppConfiguration().GetNewDIDWithPrefix();
                    }
                    //Now Update this row status to IA

                    string sqlQueryUpdate = "update [AppConfigRefrence] set AppConfigStatus='IA' where RowID=" + dsFinalHTML.Tables[0].Rows[0]["RowID"].ToString();
                    if (oDBH.ExecuteNonQuery(sqlQueryUpdate) > 0) return _oAppConfig; else return _oAppConfig;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                CommonUtility commUtil = new CommonUtility();
                commUtil.SendErrorMail(ex.Message, ex.StackTrace, System.Reflection.MethodBase.GetCurrentMethod().Name.ToString(), System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.ToString(), SessionData.Customer.CustomerID);
            }
            return null;
        }

        public bool IsConfigurationExpired(string appConfigDID)
        {
            try
            {
                DatabaseHandler oDBH = new DatabaseHandler();
                StringBuilder oSBQuery = new StringBuilder();

                DataSet ds = oDBH.FillData_SP("sp_IsConfiguration_Expired", appConfigDID);

                if (ds.Tables[0].Rows[0][0].ToString().Equals("EXPIRED"))
                {
                    return true; //App EXPIRED.
                }
                else
                {
                    return false; //App is still GOOD.
                }

            }
            catch (Exception ex)
            {
                //Log4NetUtility.ErrorDebug(this.GetType().FullName, "Error in GetConfigData(string _AppId)", ex);
                throw ex;
            }
        } //DONE

        public bool IsAppCreationAllowed(string CDID)
        {
            try
            {
                DatabaseHandler oDBH = new DatabaseHandler();

                DataSet ds = oDBH.FillData_SP("IsAppCreationAllowed", CDID);

                if (ds.Tables[0].Rows[0][0].ToString().Equals(YES))
                {
                    return true; //can create
                }
                else
                {
                    return false; //cant create
                }

            }
            catch (Exception ex)
            {
                //Log4NetUtility.ErrorDebug(this.GetType().FullName, "Error in GetConfigData(string _AppId)", ex);
                throw ex;
            }
        } //DONE

        public bool UpdateAppPagePath(string path, string appID, string pageID)
        {
            try
            {
                DatabaseHandler oDBH = new DatabaseHandler();
                oDBH.ExecuteNonQuery_SP("UpdateAppPagePath", path, pageID, appID);
                return true;
            }
            catch (Exception ex)
            {
                //Log4NetUtility.ErrorDebug(this.GetType().FullName, "Error in GetConfigData(string _AppId)", ex);
                throw ex;
            }
        } //DONE
        public string GetAppPagePath(string ADID)
        {
            try
            {
                DatabaseHandler oDBH = new DatabaseHandler();

                DataSet ds = oDBH.FillData_SP("GetAppPagePath", ADID);

                return ds.Tables[0].Rows[0]["AppPagePath"].ToString();
            }
            catch (Exception ex)
            {
                //Log4NetUtility.ErrorDebug(this.GetType().FullName, "Error in GetConfigData(string _AppId)", ex);
                throw ex;
            }
        } //DONE

        public string GetPageID(string ADID)
        {
            try
            {
                DatabaseHandler oDBH = new DatabaseHandler();

                DataSet ds = oDBH.FillData_SP("GetPageID", ADID);

                return ds.Tables[0].Rows[0]["AppPageID"].ToString();
            }
            catch (Exception ex)
            {
                //Log4NetUtility.ErrorDebug(this.GetType().FullName, "Error in GetConfigData(string _AppId)", ex);
                throw ex;
            }
        } //DONE

        public bool UpdateCustomTabNAme(string ADID)
        {
            try
            {
                DatabaseHandler oDBH = new DatabaseHandler();
                oDBH.ExecuteNonQuery_SP("UpdateCustomTabNAme", ADID); return true;
            }
            catch (Exception ex)
            {
                //Log4NetUtility.ErrorDebug(this.GetType().FullName, "Error in GetConfigData(string _AppId)", ex);
                throw ex;
            }
        } //DONE

        public bool AddToLikeGatewayData(string user_id, string app_id)
        {
            try
            {
                DatabaseHandler oDBH = new DatabaseHandler();
                oDBH.ExecuteNonQuery_SP("AddToLikeGatewayData", user_id, app_id); return true;
            }
            catch (Exception ex)
            {
                //Log4NetUtility.ErrorDebug(this.GetType().FullName, "Error in GetConfigData(string _AppId)", ex);
                throw ex;
            }
        } //DONE

        public bool IsAppLikedByUser(string app_id, string user_id)
        {
            try
            {
                DatabaseHandler oDBH = new DatabaseHandler();

                DataSet ds = oDBH.FillData_SP("IsAppLikedByUser", user_id, app_id);

                if (Convert.ToInt32(ds.Tables[0].Rows[0][0].ToString()) == 0)
                {
                    return false; //NOT LIKED YET.
                }
                else
                {
                    return true; //Already LIKED.
                }

            }
            catch (Exception ex)
            {
                //Log4NetUtility.ErrorDebug(this.GetType().FullName, "Error in GetConfigData(string _AppId)", ex);
                throw ex;
            }
        } //DONE

        public string GetCustomTabName(string AppID)
        {
            try
            {
                DatabaseHandler oDBH = new DatabaseHandler();
                StringBuilder oSBQuery = new StringBuilder();

                DataSet ds = oDBH.FillData_SP("GetCustomTabName", AppID);

                if (ds.Tables[0].Rows.Count > 0)
                {
                    return ds.Tables[0].Rows[0]["CustomTabName"].ToString();
                }
                else
                {
                    return " ";
                }

            }
            catch (Exception ex)
            {
                //Log4NetUtility.ErrorDebug(this.GetType().FullName, "Error in GetConfigData(string _AppId)", ex);
                throw ex;
            }
        } //DONE

        public bool CheckIfSweepstakeAlreadyEntered(string ADID, string sonetID)
        {
            try
            {
                DatabaseHandler oDBH = new DatabaseHandler();
                StringBuilder oSBQuery = new StringBuilder();

                DataSet ds = oDBH.FillData_SP("CheckIfSweepstakeAlreadyEntered", ADID, sonetID);

                if (ds.Tables[0].Rows[0][0].ToString().Equals("1"))
                {
                    return true; //App EXPIRED.
                }
                else
                {
                    return false; //App is still GOOD.
                }

            }
            catch (Exception ex)
            {
                //Log4NetUtility.ErrorDebug(this.GetType().FullName, "Error in GetConfigData(string _AppId)", ex);
                throw ex;
            }
        } //DONE

        public string GetAppName(string AppID)
        {
            try
            {
                DatabaseHandler oDBH = new DatabaseHandler();
                StringBuilder oSBQuery = new StringBuilder();

                DataSet ds = oDBH.FillData_SP("GetAppName", AppID);

                if (ds.Tables[0].Rows.Count > 0)
                {
                    return ds.Tables[0].Rows[0]["AppName"].ToString();
                }
                else
                {
                    return " ";
                }

            }
            catch (Exception ex)
            {
                //Log4NetUtility.ErrorDebug(this.GetType().FullName, "Error in GetConfigData(string _AppId)", ex);
                throw ex;
            }
        }

        public bool IsUserCreatedForFacebook(string user_id, string appConfigDID)
        {
            try
            {
                DatabaseHandler oDBH = new DatabaseHandler();
                StringBuilder oSBQuery = new StringBuilder();

                DataSet ds = oDBH.FillData_SP("IsUserCreatedForFacebook", user_id, appConfigDID);

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

        public string GetAppSecret(string appID)
        {
            try
            {
                DatabaseHandler oDBH = new DatabaseHandler();
                StringBuilder oSBQuery = new StringBuilder();

                DataSet ds = oDBH.FillData_SP("GetAppSecret", appID);

                if (ds.Tables[0] != null)
                {

                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        return ds.Tables[0].Rows[0]["AppSecretKey"].ToString();
                    }
                }
                else
                {
                    return string.Empty;
                }
            }
            catch (Exception ex)
            {
                //Log4NetUtility.ErrorDebug(this.GetType().FullName, "Error in GetConfigData(string _AppId)", ex);
                throw ex;
            }
            return string.Empty;
        }

        public string FetchAppLogo(string appID)
        {
            try
            {
                DatabaseHandler oDBH = new DatabaseHandler();
                StringBuilder oSBQuery = new StringBuilder();

                DataSet ds = oDBH.FillData_SP("FetchAppLogo", appID);

                if (ds.Tables[0] != null)
                {

                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        return ds.Tables[0].Rows[0]["ProductLogo"].ToString();
                    }
                }
                else
                {
                    return string.Empty;
                }
            }
            catch (Exception ex)
            {
                //Log4NetUtility.ErrorDebug(this.GetType().FullName, "Error in GetConfigData(string _AppId)", ex);
                throw ex;
            }
            return string.Empty;
        }

        public int GetLikeCount(string AppproductDID)
        {
            try
            {
                DatabaseHandler oDBH = new DatabaseHandler();
                StringBuilder oSBQuery = new StringBuilder();
                int intVisits = 0;

                DataSet ds = oDBH.FillData_SP("GetLikeCount", AppproductDID);

                if (ds.Tables[0] != null && ds.Tables[0].Rows.Count > 0)
                {
                    intVisits = Convert.ToInt32(ds.Tables[0].Rows[0]["NoOfVisits"]);
                }

                return intVisits;
            }
            catch (Exception ex)
            {
                //Log4NetUtility.ErrorDebug(this.GetType().FullName, "Error in GetConfigData(string _AppId)", ex);
                throw ex;
            }
        }

        public bool CheckLikeNotify(string UDID)
        {
            try
            {
                DatabaseHandler oDBH = new DatabaseHandler();
                StringBuilder oSBQuery = new StringBuilder();

                DataSet ds = oDBH.FillData_SP("CheckLikeNotify", UDID);

                int likeCount = Convert.ToInt32(ds.Tables[0].Rows[0][0].ToString());

                if (likeCount != 0)
                {
                    return true; //App EXPIRED.
                }
                else
                {
                    return false; //App is still GOOD.
                }

            }
            catch (Exception ex)
            {
                //Log4NetUtility.ErrorDebug(this.GetType().FullName, "Error in GetConfigData(string _AppId)", ex);
                throw ex;
            }
        }

        public string GetTemplatePage(string AppName)
        {
            try
            {
                DatabaseHandler oDBH = new DatabaseHandler();
                StringBuilder oSBQuery = new StringBuilder();

                DataSet ds = oDBH.FillData_SP("GetTemplatePage", AppName);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    return ds.Tables[0].Rows[0]["TempPage"].ToString(); //App EXPIRED.
                }
                else
                {
                    return string.Empty; //App is still GOOD.
                }

            }
            catch (Exception ex)
            {
                //Log4NetUtility.ErrorDebug(this.GetType().FullName, "Error in GetConfigData(string _AppId)", ex);
                throw ex;
            }
        }

        public SweepStakesData GetSweepDataForEditing(string ADID)
        {
            try
            {
                DatabaseHandler oDBH = new DatabaseHandler();
                DataSet dsFinalHTML = new DataSet();
                dsFinalHTML = oDBH.FillData_SP("GetSweepDataForEditing", ADID);
                if (dsFinalHTML.Tables.Count > 0)
                {
                    SweepStakesData oSweepData = new SweepStakesData();
                    oSweepData.SSweepAboutUs = dsFinalHTML.Tables[0].Rows[0]["AboutUs"].ToString();
                    oSweepData.SSweepEndDate = dsFinalHTML.Tables[0].Rows[0]["EndDate"].ToString();
                    oSweepData.SSweepPrivacy = dsFinalHTML.Tables[0].Rows[0]["Privacy"].ToString();
                    oSweepData.SSweeprules = dsFinalHTML.Tables[0].Rows[0]["Rules"].ToString();
                    oSweepData.SSweepStartDate = dsFinalHTML.Tables[0].Rows[0]["StartDate"].ToString();
                    oSweepData.SSweepTerms = dsFinalHTML.Tables[0].Rows[0]["Terms"].ToString();

                    oSweepData.SSweepExpiryDate = dsFinalHTML.Tables[0].Rows[0]["ExpiryDate"].ToString();
                    oSweepData.SCouponCode = dsFinalHTML.Tables[0].Rows[0]["CouponCode"].ToString();
                    oSweepData.SCouponDesc = dsFinalHTML.Tables[0].Rows[0]["CouponDesc"].ToString();
                    oSweepData.SCouponReedem = dsFinalHTML.Tables[0].Rows[0]["CouponReedem"].ToString();
                    oSweepData.SEligibility = dsFinalHTML.Tables[0].Rows[0]["EligibilityDetails"].ToString();
                    oSweepData.SPRizeDetails = dsFinalHTML.Tables[0].Rows[0]["PrizeDetails"].ToString();
                    oSweepData.SSweepWinners = Convert.ToInt32(dsFinalHTML.Tables[0].Rows[0]["SweepWinners"].ToString());

                    return oSweepData;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                //Log4NetUtility.ErrorDebug(this.GetType().FullName, "Error in GetConfigData(string _AppId)", ex);
                throw ex;
            }
        }

        public bool UpdateConfigDetails(AppConfiguration oAppConfig, string ModelType, string CustTabName)
        {

            try
            {
                DatabaseHandler oDBH = new DatabaseHandler();
                StringBuilder _sbQuery = new StringBuilder();
                if (ModelType.Equals("SWEEPSTAKES"))
                {

                    int i = oDBH.ExecuteNonQuery_SP("UpdateConfigDetails", oAppConfig.DID, oAppConfig.AppCustomerDID, "Facebook", oAppConfig.AppID, oAppConfig.AppKey, oAppConfig.AppSecretKey, oAppConfig.AppPath, oAppConfig.AppName, oAppConfig.AppLogo, "", "", oAppConfig.AppExpiryPath, oAppConfig.AppExpiryDT, "SWEEPSTAKES", CustTabName, oAppConfig.SAppStartDT, oAppConfig.SInquiryEmail, oAppConfig.STemplatePage);

                    if (i < 0) return false; else return true;
                }
                else
                {
                    int i = oDBH.ExecuteNonQuery_SP("UpdateConfigDetails", oAppConfig.DID, oAppConfig.AppCustomerDID, "Facebook", oAppConfig.AppID, oAppConfig.AppKey, oAppConfig.AppSecretKey, oAppConfig.AppPath, oAppConfig.AppName, oAppConfig.AppLogo, "", "", oAppConfig.AppExpiryPath, oAppConfig.AppExpiryDT, "PROMOTIONS", CustTabName, oAppConfig.SAppStartDT, oAppConfig.SInquiryEmail, oAppConfig.STemplatePage);

                    if (i < 0) return false; else return true;
                }
            }
            catch (Exception ex)
            {
                //Log4NetUtility.ErrorDebug(this.GetType().FullName, "Error in GetConfigData(string _AppId)", ex);
                throw ex;
            }
        } //DONE

        public bool UpdateProductDetails(AppProduct oAppProduct)
        {
            try
            {
                DatabaseHandler oDBH = new DatabaseHandler();
                StringBuilder _sbQuery = new StringBuilder();
                int i = oDBH.ExecuteNonQuery_SP("UpdateProductDetails", oAppProduct.DID,
                          oAppProduct.ProductCategory,
                          oAppProduct.ProductName,
                          oAppProduct.ProductLogo,
                          oAppProduct.ProductShortDesc,
                          oAppProduct.ProductDesc,
                          oAppProduct.ProductHTML,
                          "A",
                          oAppProduct.SProductContentImage,
                          oAppProduct.SProductHeaderImage,
                          oAppProduct.SProductFooterImage,
                          oAppProduct.SProductFooterURL, oAppProduct.ShareWidgetAdded, oAppProduct.LikeWidgetAdded, oAppProduct.ReccWidgetAdded, oAppProduct.CommentsWidgetAdded, oAppProduct.InquiryWidgetAdded, oAppProduct.LikeGatewayAdded, oAppProduct.CanvasHeight, oAppProduct.CanvasWidth, oAppProduct.AppCaption, oAppProduct.TwitterWidgetAdded, oAppProduct.SHeaderBannerImg, oAppProduct.SHeaderBannerURL);

                if (i < 0) return false; else return true;
            }
            catch (Exception ex)
            {
                //Log4NetUtility.ErrorDebug(this.GetType().FullName, "Error in GetConfigData(string _AppId)", ex);
                throw ex;
            }
        }//DONE

        public string GetProductHTML(string DID)
        {
            try
            {
                DatabaseHandler oDBH = new DatabaseHandler();
                DataSet dsFinalHTML = new DataSet();
                dsFinalHTML = oDBH.FillData_SP("GetProductHTML", DID);
                if (dsFinalHTML.Tables.Count > 0)
                {
                    if (dsFinalHTML.Tables[0].Rows.Count > 0)
                    {
                        return dsFinalHTML.Tables[0].Rows[0]["ProductHTML"].ToString();
                    }
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                //Log4NetUtility.ErrorDebug(this.GetType().FullName, "Error in GetConfigData(string _AppId)", ex);
                throw ex;
            }
            return string.Empty;
        }


        public string GetInquiryEmail(string ADID)
        {
            try
            {
                DatabaseHandler oDBH = new DatabaseHandler();
                DataSet dsFinalHTML = new DataSet();
                dsFinalHTML = oDBH.FillData_SP("GetInquiryEmail", ADID);
                if (dsFinalHTML.Tables.Count > 0)
                {
                    if (dsFinalHTML.Tables[0].Rows.Count > 0)
                    {
                        return dsFinalHTML.Tables[0].Rows[0]["InquiryEmail"].ToString();
                    }
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                //Log4NetUtility.ErrorDebug(this.GetType().FullName, "Error in GetConfigData(string _AppId)", ex);
                throw ex;
            }
            return string.Empty;
        }

        public string GetCouponImgPath(string DID)
        {
            try
            {
                DatabaseHandler oDBH = new DatabaseHandler();
                StringBuilder oSBQuery = new StringBuilder();

                DataSet ds = oDBH.FillData_SP("GetCouponImgPath", DID);

                if (ds.Tables[0].Rows.Count > 0)
                {
                    return ds.Tables[0].Rows[0]["CouponImgPath"].ToString();
                }
                else
                {
                    return " ";
                }

            }
            catch (Exception ex)
            {
                //Log4NetUtility.ErrorDebug(this.GetType().FullName, "Error in GetConfigData(string _AppId)", ex);
                throw ex;
            }
        } //DONE

        public string GetExpiryDate(string AppConfigDID)
        {
            try
            {
                DatabaseHandler oDBH = new DatabaseHandler();
                StringBuilder oSBQuery = new StringBuilder();

                DataSet ds = oDBH.FillData_SP("GetExpiryDate", AppConfigDID);

                if (ds.Tables[0].Rows.Count > 0)
                {
                    return ds.Tables[0].Rows[0]["ExpiryDate"].ToString();
                }
                else
                {
                    return " ";
                }

            }
            catch (Exception ex)
            {
                //Log4NetUtility.ErrorDebug(this.GetType().FullName, "Error in GetConfigData(string _AppId)", ex);
                throw ex;
            }
        } //DONE

        public string GetCouponDetails(string DID)
        {
            try
            {
                DatabaseHandler oDBH = new DatabaseHandler();
                StringBuilder oSBQuery = new StringBuilder();

                DataSet ds = oDBH.FillData_SP("GetCouponDetails", DID);

                if (ds.Tables[0].Rows.Count > 0)
                {
                    return ds.Tables[0].Rows[0]["PrizeDetails"].ToString();
                }
                else
                {
                    return " ";
                }

            }
            catch (Exception ex)
            {
                //Log4NetUtility.ErrorDebug(this.GetType().FullName, "Error in GetConfigData(string _AppId)", ex);
                throw ex;
            }
        } //DONE

        public string GetCouponCode(string AppConfigDID)
        {
            try
            {
                DatabaseHandler oDBH = new DatabaseHandler();
                StringBuilder oSBQuery = new StringBuilder();

                DataSet ds = oDBH.FillData_SP("GetCouponCode", AppConfigDID);

                if (ds.Tables[0].Rows.Count > 0)
                {
                    return ds.Tables[0].Rows[0]["CouponCode"].ToString();
                }
                else
                {
                    return " ";
                }

            }
            catch (Exception ex)
            {
                //Log4NetUtility.ErrorDebug(this.GetType().FullName, "Error in GetConfigData(string _AppId)", ex);
                throw ex;
            }
        }

        public bool IsLikeGatewayAdded(string appConfigDID)
        {
            try
            {
                DatabaseHandler oDBH = new DatabaseHandler();
                StringBuilder oSBQuery = new StringBuilder();

                DataSet ds = oDBH.FillData_SP("IsLikeGatewayAdded", appConfigDID);

                if (ds.Tables[0].Rows.Count > 0)
                {
                    if (ds.Tables[0].Rows[0]["LikeGatewayAdded"].ToString().Equals(YES))
                    {
                        return true;
                    }
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
            return false;
        }

        public bool InsertVideoShareData(string appConfigDID, string vidURL, string vidURLConverted, string vidDesc)
        {

            try
            {
                DatabaseHandler oDBH = new DatabaseHandler();
                StringBuilder _sbQuery = new StringBuilder();

                int i = oDBH.ExecuteNonQuery_SP("InsertVideoShareData", appConfigDID, vidURL, vidURLConverted, vidDesc);

                if (i < 0) return false; else return true;

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
                DatabaseHandler oDBH = new DatabaseHandler();
                StringBuilder oSBQuery = new StringBuilder();
                VideoShareData ovidShareData = new VideoShareData();

                DataSet ds = oDBH.FillData_SP("GetVideoShareData", appConfigDID);

                if (ds.Tables[0].Rows.Count > 0)
                {
                    ovidShareData.SVideoShareURL = ds.Tables[0].Rows[0]["VideoURL"].ToString();
                    ovidShareData.SVideoShareURLConverted = ds.Tables[0].Rows[0]["VideoURLConverted"].ToString();
                    ovidShareData.SVideoShareDesc = ds.Tables[0].Rows[0]["VideoDescription"].ToString();
                    return ovidShareData;
                }
                else
                {
                    return null;
                }

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
                DatabaseHandler oDBH = new DatabaseHandler();
                StringBuilder _sbQuery = new StringBuilder();
                int i = oDBH.ExecuteNonQuery_SP("UpdateVideoShareData", appConfigDID, vidURL, vidURLConverted, vidDesc);

                if (i < 0) return false; else return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }//DONE

        public string GetCustomLogo(string PDID)
        {
            try
            {
                DatabaseHandler oDBH = new DatabaseHandler();
                StringBuilder oSBQuery = new StringBuilder();

                DataSet ds = oDBH.FillData_SP("GetCustomLogo", PDID);

                if (ds.Tables[0].Rows.Count > 0)
                {

                    return ds.Tables[0].Rows[0]["ProductLogo"].ToString();
                }
                else
                {
                    return null;
                }

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
                DatabaseHandler oDBH = new DatabaseHandler();
                return oDBH.FillData_SP("GetPreviewProduct", PDID).Tables[0];
            }
            catch (Exception ex)
            {
                //Log4NetUtility.ErrorDebug(this.GetType().FullName, "Error in GetConfigData(string _AppId)", ex);
                throw ex;
            }
        } //DONE

        public string IsSweepstakesAppModel(string appConfigDID)
        {
            try
            {
                DatabaseHandler oDBH = new DatabaseHandler();

                DataSet ds = oDBH.FillData_SP("IsSweepstakesAppModel", appConfigDID);

                return ds.Tables[0].Rows[0]["AppModel"].ToString();
            }
            catch (Exception ex)
            {
                //Log4NetUtility.ErrorDebug(this.GetType().FullName, "Error in GetConfigData(string _AppId)", ex);
                throw ex;
            }
        }
        public bool IsSweepstakesWinnerDay(string appConfigDID)
        {
            try
            {
                DatabaseHandler oDBH = new DatabaseHandler();
                StringBuilder oSBQuery = new StringBuilder();

                DataSet ds = oDBH.FillData_SP("IsSweepstakesWinnerDay", appConfigDID);

                if (ds.Tables[0].Rows[0][0].ToString().Equals("DDAY"))
                {
                    return true; //App EXPIRED.
                }
                else
                {
                    return false; //App is still GOOD.
                }

            }
            catch (Exception ex)
            {
                //Log4NetUtility.ErrorDebug(this.GetType().FullName, "Error in GetConfigData(string _AppId)", ex);
                throw ex;
            }
        } //DONE

        public string GetSweepstakesEndDate(string appConfigDID)
        {
            try
            {
                DatabaseHandler oDBH = new DatabaseHandler();

                DataSet ds = oDBH.FillData_SP("GetSweepstakesEndDate", appConfigDID);

                return ds.Tables[0].Rows[0]["ExpiryDate"].ToString();
            }
            catch (Exception ex)
            {
                //Log4NetUtility.ErrorDebug(this.GetType().FullName, "Error in GetConfigData(string _AppId)", ex);
                throw ex;
            }
        }

        public bool InsertErrData(string errData)
        {

            try
            {
                DatabaseHandler oDBH = new DatabaseHandler();
                StringBuilder _sbQuery = new StringBuilder();

                int i = oDBH.ExecuteNonQuery_SP("InsertErrData", errData);

                if (i < 0) return false; else return true;

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
                DatabaseHandler oDBH = new DatabaseHandler();

                DataSet ds = oDBH.FillData_SP("GetConfigDEED", appID);

                return ds.Tables[0].Rows[0]["DID"].ToString();
            }
            catch (Exception ex)
            {
                //Log4NetUtility.ErrorDebug(this.GetType().FullName, "Error in GetConfigData(string _AppId)", ex);
                throw ex;
            }
        }
        public string GetUserDID(string ADID, string sonetID)
        {
            try
            {
                DatabaseHandler oDBH = new DatabaseHandler();

                DataSet ds = oDBH.FillData_SP("GetUserDID", ADID, sonetID);

                return ds.Tables[0].Rows[0]["DID"].ToString();
            }
            catch (Exception ex)
            {
                //Log4NetUtility.ErrorDebug(this.GetType().FullName, "Error in GetConfigData(string _AppId)", ex);
                throw ex;
            }
        }
        public string GetAppPath(string appID)
        {
            try
            {
                DatabaseHandler oDBH = new DatabaseHandler();

                DataSet ds = oDBH.FillData_SP("GetAppPath", appID);

                return ds.Tables[0].Rows[0]["AppPath"].ToString();
            }
            catch (Exception ex)
            {
                //Log4NetUtility.ErrorDebug(this.GetType().FullName, "Error in GetConfigData(string _AppId)", ex);
                throw ex;
            }
        }

        public bool IsAppUserExistMobile(AppUser oDCAppUser)
        {
            try
            {
                DatabaseHandler oDBH = new DatabaseHandler();

                //Check if user is already present if present then update his information & status
                object objRowCount = oDBH.ExecuteNonQuery_SP("IsAppUserExist", oDCAppUser.AppConfigDID, oDCAppUser.SonetID);
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

        public string GetNotifierDID(string PDID)
        {
            try
            {
                DatabaseHandler oDBH = new DatabaseHandler();

                DataSet ds = oDBH.FillData_SP("GetNotifierDID", PDID);

                //return 

                if (ds.Tables[0].Rows.Count > 0)
                {
                    return ds.Tables[0].Rows[0]["DID"].ToString();
                }
                else
                {
                    return "";
                }
            }
            catch (Exception ex)
            {
                //Log4NetUtility.ErrorDebug(this.GetType().FullName, "Error in GetConfigData(string _AppId)", ex);
                throw ex;
            }
        }

        public bool UpdateConfigExpiryForWH(string DID)
        {
            try
            {
                DatabaseHandler oDBH = new DatabaseHandler();
                StringBuilder _sbQuery = new StringBuilder();
                int i = oDBH.ExecuteNonQuery_SP("UpdateConfigExpiryForWH", DID);

                if (i < 0) return false; else return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }//DONE

        public bool SetUserAction(UserAction oUserAction)
        {
            try
            {
                DatabaseHandler oDBH = new DatabaseHandler();
                StringBuilder _sbQuery = new StringBuilder();

                int i = oDBH.ExecuteNonQuery_SP("SetUserAction", oUserAction.CustomerId, oUserAction.PreferenceID1, 'N', oUserAction.SubDomainName1, oUserAction.YoutubeURL1, oUserAction.CustomTabName1, oUserAction.TemplateId, oUserAction.SiteID1);

                if (i < 0) return false; else return true;
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
                DatabaseHandler oDBH = new DatabaseHandler();

                DataSet ds = oDBH.FillData_SP("GetSiteIDForConfig", ADID);

                return ds.Tables[0].Rows[0]["SiteID"].ToString();
            }
            catch (Exception ex)
            {
                //Log4NetUtility.ErrorDebug(this.GetType().FullName, "Error in GetConfigData(string _AppId)", ex);
                throw ex;
            }
        } //DONE

        public int GetTemplateIDForConfig(string ADID)
        {
            try
            {
                DatabaseHandler oDBH = new DatabaseHandler();

                DataSet ds = oDBH.FillData_SP("GetTemplateIDForConfig", ADID);

                return Convert.ToInt32(ds.Tables[0].Rows[0]["TemplateID"]);
            }
            catch (Exception ex)
            {
                //Log4NetUtility.ErrorDebug(this.GetType().FullName, "Error in GetConfigData(string _AppId)", ex);
                throw ex;
            }
        } //DONE


        public string GetProductDID(string ADID)
        {
            try
            {
                DatabaseHandler oDBH = new DatabaseHandler();

                DataSet ds = oDBH.FillData_SP("GetProductDID", ADID);

                return Convert.ToString(ds.Tables[0].Rows[0]["DID"]);
            }
            catch (Exception ex)
            {
                //Log4NetUtility.ErrorDebug(this.GetType().FullName, "Error in GetConfigData(string _AppId)", ex);
                throw ex;
            }
        } //DONE


        public bool InsertMicrositesData(string CustID, string MicroSiteName)
        {
            try
            {
                DatabaseHandler oDBH = new DatabaseHandler();
                StringBuilder _sbQuery = new StringBuilder();

                int i = oDBH.ExecuteNonQuery_SP("InsertMicrositesData", CustID, MicroSiteName);

                if (i < 0) return false; else return true;
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
                DatabaseHandler oDBH = new DatabaseHandler();
                DataSet validatemail = oDBH.FillData_SP("CheckMicroSiteName", txtEmailID);
                if (validatemail.Tables.Count > 0)
                {
                    if (validatemail.Tables[0].Rows.Count > 0)
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
                    return 0;
                }
            }
            catch
            {
                throw;
            }

        } //-- DONE
    }
}
