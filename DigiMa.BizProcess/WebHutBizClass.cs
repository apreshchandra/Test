using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DigiMa.DataAccess;
using DigiMa.Common;
using DigiMa.Data;
using System.Text.RegularExpressions;

namespace DigiMa.BizProcess
{
    public class WebHutBizClass
    {
        WebHutData oWebHutData = new WebHutData();

        public UserAction GetUserDetails(string UserName, string Password)
        {
            try
            {
                SimpleAES oSimpleAES = new SimpleAES();
                Regex oRegex = new Regex(@"^[a-zA-Z0-9_]+$");
                if (oRegex.IsMatch(UserName))
                {
                    string sPassword= oWebHutData.GetPassword(UserName);
                    if (sPassword != "" && oSimpleAES.DecryptString(sPassword) == Password)
                    {
                        UserAction oUserDetails = new UserAction();
                        oUserDetails=oWebHutData.GetUserDetails(UserName);
                        return oUserDetails;
                    }
                }
                return null;
            }
            catch (Exception ex)
            {
               
            }
            return null;
        }

    }
}
