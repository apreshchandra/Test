using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DigiMa.DataAccess
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
    public enum Keywords
    {
        SONETCONNECT_HEADER,
        SONETCONNECT_FOOTER,
        SONETCONNECT_SHARE,
        SONETCONNECT_POST,
        SONETCONNECT_LIKE,
    }

    public delegate void CurrentActivityHandler(string sCurrentActivity);
    public delegate void RequestResponseTimeHandler(object oDataObject);

}
