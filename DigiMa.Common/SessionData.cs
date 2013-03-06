using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using DigiMa.Data;

namespace DigiMa.Common
{
    public static class SessionData
    {

        #region Session Properties
        public static AppCustomer Customer
        {
            get
            {
                if (HttpContext.Current.Session != null && HttpContext.Current.Session["Customer"] != null)    //Please don't change the session name because in master page, User control and class files this session is used directly without the help of property
                {
                    return (AppCustomer)HttpContext.Current.Session["Customer"];
                }
                else
                {
                    AppCustomer oCompanyDetails = new AppCustomer();
                    oCompanyDetails.CustomerID = "";
                    oCompanyDetails.SCustomerUserName = "";
                    oCompanyDetails.SCustomerEmail = "";
                    return oCompanyDetails;
                }
            }
            set
            {
                if (value == null || (value.CustomerID == "" && string.IsNullOrEmpty(value.SCustomerUserName) && string.IsNullOrEmpty(value.SCustomerEmail)))
                    HttpContext.Current.Session["Customer"] = null;
                else
                {
                    HttpContext.Current.Session["Customer"] = value;
                }
            }
        }

        public static AppConfiguration Config
        {
            get
            {
                if (HttpContext.Current.Session != null && HttpContext.Current.Session["Config"] != null)    //Please don't change the session name because in master page, User control and class files this session is used directly without the help of property
                {
                    return (AppConfiguration)HttpContext.Current.Session["Config"];
                }
                else
                {
                    AppConfiguration oCompanyDetails = new AppConfiguration();
                    oCompanyDetails.AppCustomerDID = "";
                    oCompanyDetails.DID = "";
                    oCompanyDetails.AppName = "";
                    return oCompanyDetails;
                }
            }
            set
            {
                if (value == null || (value.AppCustomerDID == "" && string.IsNullOrEmpty(value.DID) && string.IsNullOrEmpty(value.AppName)))
                    HttpContext.Current.Session["Config"] = null;
                else
                {
                    HttpContext.Current.Session["Config"] = value;
                }
            }
        }


        public static AppProduct Product
        {
            get
            {
                if (HttpContext.Current.Session["Product"] != null)    //Please don't change the session name because in master page, User control and class files this session is used directly without the help of property
                {
                    return (AppProduct)HttpContext.Current.Session["Product"];
                }
                else
                {
                    return null;
                }
            }
            set
            {
                if (value == null || (value.DID == "" && string.IsNullOrEmpty(value.AppConfigDID)))
                    HttpContext.Current.Session["Product"] = null;
                else
                {
                    HttpContext.Current.Session["Product"] = value;
                }
            }
        }

        public static TwitterData TwitterData
        {
            get
            {
                if (HttpContext.Current.Session["TwitterData"] != null)    //Please don't change the session name because in master page, User control and class files this session is used directly without the help of property
                {
                    return (TwitterData)HttpContext.Current.Session["TwitterData"];
                }
                else
                {
                    TwitterData oTweetData = new TwitterData();
                    oTweetData.TokenKey = "";
                    oTweetData.TokenSecretKey = "";
                    oTweetData.CachedUserId1 = "";

                    return oTweetData;

                }
            }
            set
            {
                if (value == null || (value.TokenKey == "" && string.IsNullOrEmpty(value.TokenKey)) || (value.TokenSecretKey == "" && string.IsNullOrEmpty(value.TokenSecretKey))
                   || (value.CachedUserId1 == "" && string.IsNullOrEmpty(value.CachedUserId1)))
                    HttpContext.Current.Session["TwitterData"] = null;
                else
                {
                    HttpContext.Current.Session["TwitterData"] = value;
                }
            }
        }

        public static PreferenceData PrefData
        {
            get
            {
                if (HttpContext.Current.Session["PrefData"] != null)    //Please don't change the session name because in master page, User control and class files this session is used directly without the help of property
                {
                    return (PreferenceData)HttpContext.Current.Session["PrefData"];
                }
                else
                {
                    PreferenceData oPrefData = new PreferenceData();
                    oPrefData.PrefID1 = "";
                    oPrefData.PrefLongDesc1 = "";
                    oPrefData.PrefShortDesc1 = "";
                    oPrefData.TemplateID1 = 13;
                    return oPrefData;

                }
            }
            set
            {
                if (value == null || (value.PrefLongDesc1 == "" && string.IsNullOrEmpty(value.PrefLongDesc1)) || (value.PrefShortDesc1 == "" && string.IsNullOrEmpty(value.PrefShortDesc1))
                   || (value.PrefID1 == "" && string.IsNullOrEmpty(value.PrefID1)))
                    HttpContext.Current.Session["PrefData"] = null;
                else
                {
                    HttpContext.Current.Session["PrefData"] = value;
                }
            }
        }


        public static UserAction UserAction
        {
            get
            {
                if (HttpContext.Current.Session["UserAction"] != null)    //Please don't change the session name because in master page, User control and class files this session is used directly without the help of property
                {
                    return (UserAction)HttpContext.Current.Session["UserAction"];
                }
                else
                {
                    UserAction oUserAction = new UserAction();
                    oUserAction.RoleName = "";
                    oUserAction.SubDomainName1 = "";
                    oUserAction.UserName = "";

                    return oUserAction;

                }
            }
            set
            {
                if (value == null || (value.RoleName == "" && string.IsNullOrEmpty(value.RoleName)) || (value.SubDomainName1 == "" && string.IsNullOrEmpty(value.SubDomainName1))
                   || (value.UserName == "" && string.IsNullOrEmpty(value.UserName)))
                    HttpContext.Current.Session["UserAction"] = null;
                else
                {
                    HttpContext.Current.Session["UserAction"] = value;
                }
            }
        }

        public static string SessionID { get { return HttpContext.Current.Session.SessionID; } }

        #endregion
    }
}
