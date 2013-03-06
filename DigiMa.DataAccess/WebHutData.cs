using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DigiMa.Data;
using System.Data;

namespace DigiMa.DataAccess
{
    public class WebHutData
    {
        DatabaseHandler oDatabaseHandler;


        public string GetPassword(string UserName)
        {
            try
            {
                oDatabaseHandler = new DatabaseHandler();
                DataSet oDataSet = new DataSet();
                oDataSet = oDatabaseHandler.FillData("select [Password] from Users where UserName='" + UserName + "'");
                if (oDataSet != null && oDataSet.Tables != null && oDataSet.Tables.Count > 0 && oDataSet.Tables[0].Rows != null && oDataSet.Tables[0].Rows.Count > 0)
                {
                    return oDataSet.Tables[0].Rows[0][0].ToString();
                }
                else
                    return "";
            }
            catch (Exception ex)
            {

            }
            return "";
        }
        public UserAction GetUserDetails(string UserName)
        {
            try
            {
                oDatabaseHandler = new DatabaseHandler();
                DataSet oDataSet = new DataSet();
                oDataSet = oDatabaseHandler.FillData("select U.UserId,U.RoleId,R.[Role] RoleName,R.[Create],R.Edit,R.[View],R.Assign,R.Finish from Users as U "
                                                     + " inner join Roles R on R.RoleId=U.RoleId"
                                                     + " where U.UserName='" + UserName + "'");

                if (oDataSet != null && oDataSet.Tables != null && oDataSet.Tables.Count > 0 && oDataSet.Tables[0].Rows != null && oDataSet.Tables[0].Rows.Count > 0)
                {
                    UserAction oUserDetails = new UserAction();
                    //oUserDetails.Cus = int.Parse(oDataSet.Tables[0].Rows[0]["UserId"].ToString());
                    oUserDetails.UserName = UserName;// oDataSet.Tables[0].Rows[0]["UserId"].ToString();
                    oUserDetails.RoleID = int.Parse(oDataSet.Tables[0].Rows[0]["RoleId"].ToString());

                    oUserDetails.RoleName = oDataSet.Tables[0].Rows[0]["RoleName"].ToString();
                    oUserDetails.Create = bool.Parse(oDataSet.Tables[0].Rows[0]["Create"].ToString());
                    oUserDetails.Edit = bool.Parse(oDataSet.Tables[0].Rows[0]["Edit"].ToString());
                    oUserDetails.View = bool.Parse(oDataSet.Tables[0].Rows[0]["View"].ToString());
                    oUserDetails.Assign = bool.Parse(oDataSet.Tables[0].Rows[0]["Assign"].ToString());
                    oUserDetails.Finish = bool.Parse(oDataSet.Tables[0].Rows[0]["Finish"].ToString());

                    return oUserDetails;
                }
                return null;
            }
            catch (Exception ex)
            {

            }
            return null;
        }
    }

    //For LOgin page




}
