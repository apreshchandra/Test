using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data;

namespace DigiMa.DataAccess
{

    /// <summary>
    /// This is my class
    /// </summary>
    interface IDatabaseHandler : IDisposable
    {
        event CurrentActivityHandler CurrentActivity;

        string ConnectionString { get; set; }
        string ConnectionID { get; }
        DatabaseType DBType { get; set; }

        void Open();
        void Open(string sConnectionString);
        bool Ping();
        void Close();

        void BeginTransaction();
        void BeginTransaction(IsolationLevel oIsolationLevel);

        void CommitTransaction();
        void CommitTransaction(bool doCloseConnection);

        void RollbackTransaction();
        void RollbackTransaction(bool doCloseConnection);

        DataSet FillData(string sQuery);
        DataSet FillData(string sQuery, params object[] oValues);
        DataSet FillData(string sQuery, params IDbDataParameter[] oSP_Params);
        DataSet FillData(string sQuery, ref IDbDataParameter[] oSP_Params);
        DataSet FillData_SP(string sSP_Name);
        DataSet FillData_SP(string sSP_Name, params object[] oValues);
        DataSet FillData_SP(string sSP_Name, params IDbDataParameter[] oSP_Params);
        DataSet FillData_SP(string sSP_Name, ref IDbDataParameter[] oSP_Params);

        int ExecuteNonQuery(string sQuery);
        int ExecuteNonQuery(string sQuery, params object[] oValues);
        int ExecuteNonQuery(string sQuery, params IDbDataParameter[] oSP_Params);
        int ExecuteNonQuery(string sQuery, ref IDbDataParameter[] oSP_Params);
        int ExecuteNonQuery_SP(string sSP_Name);
        int ExecuteNonQuery_SP(string sSP_Name, params object[] oValues);
        int ExecuteNonQuery_SP(string sSP_Name, params IDbDataParameter[] oSP_Params);
        int ExecuteNonQuery_SP(string sSP_Name, ref IDbDataParameter[] oSP_Params);

        object ExecuteScalar(string sQuery);
        object ExecuteScalar(string sQuery, params object[] oValues);
        object ExecuteScalar(string sQuery, params IDbDataParameter[] oSP_Params);
        object ExecuteScalar(string sQuery, ref IDbDataParameter[] oSP_Params);
        object ExecuteScalar_SP(string sSP_Name);
        object ExecuteScalar_SP(string sSP_Name, params object[] oValues);
        object ExecuteScalar_SP(string sSP_Name, params IDbDataParameter[] oSP_Params);
        object ExecuteScalar_SP(string sSP_Name, ref IDbDataParameter[] oSP_Params);

        IDbDataParameter ExecuteReader(string sQuery);
        IDbDataParameter ExecuteReader(string sQuery, params object[] oValues);
        IDbDataParameter ExecuteReader(string sQuery, params IDbDataParameter[] oSP_Params);
        IDbDataParameter ExecuteReader(string sQuery, ref IDbDataParameter[] oSP_Params);
        IDbDataParameter ExecuteReader_SP(string sSP_Name);
        IDbDataParameter ExecuteReader_SP(string sSP_Name, params object[] oValues);
        IDbDataParameter ExecuteReader_SP(string sSP_Name, params IDbDataParameter[] oSP_Params);
        IDbDataParameter ExecuteReader_SP(string sSP_Name, ref IDbDataParameter[] oSP_Params);

        IDbDataParameter CreateDataParameter();
        IDbDataParameter CreateDataParameter(string sParameterName, object oValue);
        IDbDataParameter CreateDataParameter(string sParameterName, object oValue, ParameterDirection oDirection);
        IDbDataParameter CreateDataParameter(string sParameterName, object oValue, ParameterDirection oDirection, int iSize);

    }

}
