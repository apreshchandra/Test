using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Configuration;

namespace DigiMa.DataAccess
{
    public class DatabaseHandler : IDatabaseHandler
    {
        #region Variables

        private IDatabaseHandler oDatabaseHandler = null;

        public event CurrentActivityHandler CurrentActivity;

        #endregion

        #region Properties

        public string ConnectionString
        {
            get { return oDatabaseHandler.ConnectionString; }
            set { oDatabaseHandler.ConnectionString = value; }
        }

        public string ConnectionID
        {
            get { return oDatabaseHandler.ConnectionID; }
        }

        public DatabaseType DBType
        {
            get { return oDatabaseHandler.DBType; }
            set { oDatabaseHandler.DBType = value; }
        }

        #endregion

        #region Constructor & Destructor

        public DatabaseHandler()
        {
            DatabaseType oDBType = DatabaseType.Database;
            if (ConfigurationManager.AppSettings["DatabaseType"] != null)
                oDBType = (DatabaseType)Enum.Parse(typeof(DatabaseType), ConfigurationManager.AppSettings["DatabaseType"]);
            InitDatabaseHandler(oDBType);
        }

        public DatabaseHandler(DatabaseType oDBType)
        {
            InitDatabaseHandler(oDBType);
        }

        ~DatabaseHandler()
        {
            Dispose();
        }

        #endregion

        #region Open/Close/Ping Connection

        public void Open()
        {
            oDatabaseHandler.Open();
        }

        public void Open(string sConnectionString)
        {
            oDatabaseHandler.Open(sConnectionString);
        }

        public bool Ping()
        {
            return oDatabaseHandler.Ping();
        }

        public void Close()
        {
            oDatabaseHandler.Close();
        }

        #endregion

        #region Transaction Begin/Commit/Rollback

        public void BeginTransaction()
        {
            oDatabaseHandler.BeginTransaction();
        }

        public void BeginTransaction(System.Data.IsolationLevel oIsolationLevel)
        {
            oDatabaseHandler.BeginTransaction(oIsolationLevel);
        }

        public void CommitTransaction()
        {
            oDatabaseHandler.CommitTransaction();
        }

        public void CommitTransaction(bool doCloseConnection)
        {
            oDatabaseHandler.CommitTransaction(doCloseConnection);
        }

        public void RollbackTransaction()
        {
            oDatabaseHandler.RollbackTransaction();
        }

        public void RollbackTransaction(bool doCloseConnection)
        {
            oDatabaseHandler.RollbackTransaction(doCloseConnection);
        }

        #endregion

        #region Init/Private Methods

        private void InitDatabaseHandler(DatabaseType oDBType)
        {
            try
            {
                switch (oDBType)
                {
                    case DatabaseType.SQL:
                        {
                           // oDatabaseHandler = new SqlHelper();
                            break;
                        }
                    case DatabaseType.Oracle:
                        {
                            break;
                        }
                    case DatabaseType.File:
                        {
                            break;
                        }
                    default:
                        {
                            oDatabaseHandler = new DatabaseHelper();
                            break;
                        }
                }
                DBType = oDBType;
                oDatabaseHandler.CurrentActivity += new CurrentActivityHandler(oDatabaseHandler_CurrentActivity);
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void oDatabaseHandler_CurrentActivity(string sCurrentActivity)
        {
            if (CurrentActivity != null)
                CurrentActivity.BeginInvoke(sCurrentActivity, null, null);
        }

        #endregion

        #region Fill Data

        public System.Data.DataSet FillData(string sQuery)
        {
            return oDatabaseHandler.FillData(sQuery);
        }

        public System.Data.DataSet FillData(string sQuery, params object[] oValues)
        {
            return oDatabaseHandler.FillData(sQuery, oValues);
        }

        public System.Data.DataSet FillData(string sQuery, params IDbDataParameter[] oSP_Params)
        {
            return oDatabaseHandler.FillData(sQuery, oSP_Params);
        }

        public System.Data.DataSet FillData(string sQuery, ref IDbDataParameter[] oSP_Params)
        {
            return oDatabaseHandler.FillData(sQuery, ref oSP_Params);
        }

        public System.Data.DataSet FillData_SP(string sSP_Name)
        {
            return oDatabaseHandler.FillData_SP(sSP_Name);
        }

        public System.Data.DataSet FillData_SP(string sSP_Name, params object[] oValues)
        {
            return oDatabaseHandler.FillData_SP(sSP_Name, oValues);
        }

        public System.Data.DataSet FillData_SP(string sSP_Name, params IDbDataParameter[] oSP_Params)
        {
            return oDatabaseHandler.FillData_SP(sSP_Name, oSP_Params);
        }

        public System.Data.DataSet FillData_SP(string sSP_Name, ref IDbDataParameter[] oSP_Params)
        {
            return oDatabaseHandler.FillData_SP(sSP_Name, ref oSP_Params);
        }

        #endregion

        #region ExecuteNonQuery

        public int ExecuteNonQuery(string sQuery)
        {
            return oDatabaseHandler.ExecuteNonQuery(sQuery);
        }

        public int ExecuteNonQuery(string sQuery, params object[] oValues)
        {
            return oDatabaseHandler.ExecuteNonQuery(sQuery, oValues);
        }

        public int ExecuteNonQuery(string sQuery, params IDbDataParameter[] oSP_Params)
        {
            return oDatabaseHandler.ExecuteNonQuery(sQuery, oSP_Params);
        }

        public int ExecuteNonQuery(string sQuery, ref IDbDataParameter[] oSP_Params)
        {
            return oDatabaseHandler.ExecuteNonQuery(sQuery, ref oSP_Params);
        }

        public int ExecuteNonQuery_SP(string sSP_Name)
        {
            return oDatabaseHandler.ExecuteNonQuery_SP(sSP_Name);
        }

        public int ExecuteNonQuery_SP(string sSP_Name, params object[] oValues)
        {
            return oDatabaseHandler.ExecuteNonQuery_SP(sSP_Name, oValues);
        }

        public int ExecuteNonQuery_SP(string sSP_Name, params IDbDataParameter[] oSP_Params)
        {
            return oDatabaseHandler.ExecuteNonQuery_SP(sSP_Name, oSP_Params);
        }

        public int ExecuteNonQuery_SP(string sSP_Name, ref IDbDataParameter[] oSP_Params)
        {
            return oDatabaseHandler.ExecuteNonQuery_SP(sSP_Name, ref oSP_Params);
        }

        #endregion

        #region ExecuteScalar

        public object ExecuteScalar(string sQuery)
        {
            return oDatabaseHandler.ExecuteScalar(sQuery);
        }

        public object ExecuteScalar(string sQuery, params object[] oValues)
        {
            return oDatabaseHandler.ExecuteScalar(sQuery, oValues);
        }

        public object ExecuteScalar(string sQuery, params IDbDataParameter[] oSP_Params)
        {
            return oDatabaseHandler.ExecuteScalar(sQuery, oSP_Params);
        }

        public object ExecuteScalar(string sQuery, ref IDbDataParameter[] oSP_Params)
        {
            return oDatabaseHandler.ExecuteScalar(sQuery, ref oSP_Params);
        }

        public object ExecuteScalar_SP(string sSP_Name)
        {
            return oDatabaseHandler.ExecuteScalar_SP(sSP_Name);
        }

        public object ExecuteScalar_SP(string sSP_Name, params object[] oValues)
        {
            return oDatabaseHandler.ExecuteScalar_SP(sSP_Name, oValues);
        }

        public object ExecuteScalar_SP(string sSP_Name, params IDbDataParameter[] oSP_Params)
        {
            return oDatabaseHandler.ExecuteScalar_SP(sSP_Name, oSP_Params);
        }

        public object ExecuteScalar_SP(string sSP_Name, ref IDbDataParameter[] oSP_Params)
        {
            return oDatabaseHandler.ExecuteScalar_SP(sSP_Name, ref oSP_Params);
        }

        #endregion

        #region ExecuteReader

        public IDbDataParameter ExecuteReader(string sQuery)
        {
            return oDatabaseHandler.ExecuteReader(sQuery);
        }

        public IDbDataParameter ExecuteReader(string sQuery, params object[] oValues)
        {
            return oDatabaseHandler.ExecuteReader(sQuery, oValues);
        }

        public IDbDataParameter ExecuteReader(string sQuery, params IDbDataParameter[] oSP_Params)
        {
            return oDatabaseHandler.ExecuteReader(sQuery, oSP_Params);
        }

        public IDbDataParameter ExecuteReader(string sQuery, ref IDbDataParameter[] oSP_Params)
        {
            return oDatabaseHandler.ExecuteReader(sQuery, ref oSP_Params);
        }

        public IDbDataParameter ExecuteReader_SP(string sSP_Name)
        {
            return oDatabaseHandler.ExecuteReader_SP(sSP_Name);
        }

        public IDbDataParameter ExecuteReader_SP(string sSP_Name, params object[] oValues)
        {
            return oDatabaseHandler.ExecuteReader_SP(sSP_Name, oValues);
        }

        public IDbDataParameter ExecuteReader_SP(string sSP_Name, params IDbDataParameter[] oSP_Params)
        {
            return oDatabaseHandler.ExecuteReader_SP(sSP_Name, oSP_Params);
        }

        public IDbDataParameter ExecuteReader_SP(string sSP_Name, ref IDbDataParameter[] oSP_Params)
        {
            return oDatabaseHandler.ExecuteReader_SP(sSP_Name, ref oSP_Params);
        }

        #endregion

        #region CreateDataParameter

        public IDbDataParameter CreateDataParameter()
        {
            return oDatabaseHandler.CreateDataParameter();
        }

        public IDbDataParameter CreateDataParameter(string sParameterName, object oValue)
        {
            return oDatabaseHandler.CreateDataParameter(sParameterName, oValue);
        }

        public IDbDataParameter CreateDataParameter(string sParameterName, object oValue, ParameterDirection oDirection)
        {
            return oDatabaseHandler.CreateDataParameter(sParameterName, oValue, oDirection);
        }

        public IDbDataParameter CreateDataParameter(string sParameterName, object oValue, ParameterDirection oDirection, int iSize)
        {
            return oDatabaseHandler.CreateDataParameter(sParameterName, oValue, oDirection, iSize);
        }

        #endregion

        #region IDisposable Members

        public void Dispose()
        {
            if (oDatabaseHandler != null)
                oDatabaseHandler.Dispose();
            GC.SuppressFinalize(this);
        }

        #endregion

        public void InsertExecutionLogs(string sSPNameOrQuery)
        {
            //oDatabaseHandler.InsertExecutionLogs(sSPNameOrQuery);
        }

    }

}