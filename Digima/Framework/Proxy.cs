using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;


/// <summary>
/// Summary description for Proxy
/// </summary>
public class Proxy
{
    public Proxy()
    {
        //
        // TODO: Add constructor logic here
        //
    }


    public static object CurrentObject;

    public static void Close()
    {
        if (CurrentObject == null)
            return;
    }

    //public static dynamic SconServiceClient
    //public static dynamic SconServiceClient
    //{
    //    get
    //    {
    //        if (Functions.CBool(ConfigurationManager.AppSettings["EnableService"], true))
    //        {
    //            Proxy.Close();
    //            //CurrentObject = new SCServiceReference.ServiceClient();
    //            return SconServiceClient(CurrentObject);
    //        }
    //        else
    //        {
    //            return new SCService();
    //        }
    //    }

    //}
}