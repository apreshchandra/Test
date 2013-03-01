using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DigiMa
{
    [Serializable()]
    public enum Severity
    {
        Error,
        Information,
        Warning,
        Debug,
        Email
    }
    [Serializable()]
    public enum DatabaseType
    {
        Database,
        SQL,
        Oracle,
        File
    }
    [Serializable()]
    public enum Layer
    {
        UI,
        Service,
        Business,
        DataAccess,
        Data,
        Framework,
        AutoDeployment,
        SiteFilesDownloader,
        CodeEngine,
        Common,
        CliqLaunchVideoConverter,
    }
    [Serializable()]
    public enum LogType
    {
        Files,
        Log4Net,
        Database,
        EventLog
    }
    [Serializable()]
    public enum Privileges
    {
        Publish,
        CreateSite,
        CreatePage
    }
    [Serializable()]
    public enum Roles
    {
        User=1,
        LocalAdmin,
        SystemAdmin
    }
    [Serializable()]
    public enum Status
    {
        H,
        A,
        I,
        B,
        FD,
        FS

    }
    [Serializable()]
    public enum Keywords
    {
        DIYMOBILE_COMPANYID,
        DIYMOBILE_COMPANYNAME,
        DIYMOBILE_COMPANYEMAIL,

        DIYMOBILE_USERID,
        DIYMOBILE_USERFIRSTNAME,
        DIYMOBILE_USERLASTNAME,
        DIYMOBILE_USEREMAIL,

        DIYMOBILE_SITEID,
        DIYMOBILE_SITENAME,
        DIYMOBILE_SITEURL,

        DIYMOBILE_PAGEID,
        DIYMOBILE_PAGENAME,

        DIYMOBILE_WEBSERVICEURL,
        DIYMOBILE_WEBSITEURL,
        DIYMOBILE_CUSTOMERSITEURL,
    }

    public delegate void CurrentActivityHandler(string sCurrentActivity);
    public delegate void RequestResponseTimeHandler(object oDataObject);

}
