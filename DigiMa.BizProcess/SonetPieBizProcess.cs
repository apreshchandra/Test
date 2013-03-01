using System;
using System.Collections.Generic;
using System.Linq;
using DigiMa.DataAccess;
using DigiMa.Common;
using DigiMa.Data;
using System.Text;

namespace DigiMa.BizProcess
{
    public class SonetPieBizProcess
    {
        public AppConfiguration GetAppConfiguration(string appName, string appID)
        {
            try
            {
                FacebookDALC ofbDALC = new FacebookDALC();
                return ofbDALC.GetAppConfiguration(appName, appID);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
