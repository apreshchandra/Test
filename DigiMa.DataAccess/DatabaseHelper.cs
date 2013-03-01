using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data;


namespace DigiMa.DataAccess
{

    internal class DatabaseHelper : IDatabaseHandler, IDisposable
    {
        #region Variables

        static Database oDatabase;

        private bool _isTranBegin = false;

        private string _ConnectionString, _ConnectionID;

        private DatabaseType _DBType = DatabaseType.Database;

        private DbConnection _Connection;

        private DbCommand _Command;

        private DbTransaction _Transaction;

        #endregion

        #region Properties

        public string ConnectionString
        {
            get { return _ConnectionString; }
            set { _ConnectionString = value; }
        }

        public string ConnectionID { get { return _ConnectionID; } }

        public DatabaseType DBType
        {
            get { return _DBType; }
            set { _DBType = DatabaseType.Database; }
        }

        #endregion

        #region Constructor & Destructor

        public DatabaseHelper()
        {
            try
            {
                _ConnectionID = Guid.NewGuid().ToString();
                 oDatabase = DatabaseFactory.CreateDatabase();
                 _ConnectionString = oDatabase.ConnectionString;
               
            }
            catch (Exception)
            {
                throw;
            }
        }

        ~DatabaseHelper()
        {
            Dispose();
        }

        #endregion

        #region Open/Close/Ping Connection

        public void Open()
        {
            try
            {
                // CurrentActivityEvent("Opening Connection.");

                if (_Connection == null)
                    _Connection = oDatabase.CreateConnection();
                if (string.IsNullOrEmpty(_Connection.ConnectionString))
                {
                    if (!string.IsNullOrEmpty(_ConnectionString))
                        _Connection.ConnectionString = _ConnectionString;
                    else
                    {
                        throw new Exception("Connection String is Missing");
                    }
                }
                if (_Connection.State != ConnectionState.Open)
                    _Connection.Open();

                // CurrentActivityEvent("Connection Opened.");
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Open(string sConnectionString)
        {
            _ConnectionString = sConnectionString;
            Open();
        }

        public bool Ping()
        {
            return false; // oDatabaseHandler.Ping();
        }

        public void Close()
        {
            try
            {
                // CurrentActivityEvent("Closing Connection.");

                if (_Connection != null)
                {
                    if (!_isTranBegin)
                    {
                        _Connection.Close();
                        _Connection.Dispose();
                    }
                    else
                    {
                        throw new Exception("Transaction is Not Yet Committed/Rollbacked.");
                    }
                    // CurrentActivityEvent("Connection Closed.");
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        #endregion

        #region Transaction Begin/Commit/Rollback

        public void BeginTransaction()
        {
            BeginTransaction(IsolationLevel.ReadCommitted);
        }

        public void BeginTransaction(System.Data.IsolationLevel oIsolationLevel)
        {
            try
            {
                Open();
                // CurrentActivityEvent("Beginning Transaction.");
                _Transaction = _Connection.BeginTransaction(oIsolationLevel);
                _isTranBegin = true;
                // CurrentActivityEvent("Transaction Began.");
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void CommitTransaction()
        {
            CommitTransaction(false);
        }

        public void CommitTransaction(bool doCloseConnection)
        {
            try
            {
                // CurrentActivityEvent("Committing Transaction.");
                _Transaction.Commit();
                _isTranBegin = false;
                if (doCloseConnection) Close();
                // CurrentActivityEvent("Transaction Committed.");
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void RollbackTransaction()
        {
            RollbackTransaction(false);
        }

        public void RollbackTransaction(bool doCloseConnection)
        {
            try
            {
                // CurrentActivityEvent("Rollbacking Transaction.");
                _Transaction.Rollback();
                _isTranBegin = false;
                if (doCloseConnection) Close();
                // CurrentActivityEvent("Transaction Rollbacked.");
            }
            catch (Exception)
            {
                throw;
            }
        }

        #endregion

        #region Private Methods

        private void InitCommand(string sCommandText, CommandType oCommandType)
        {
            try
            {
                Open();
                // CurrentActivityEvent("Initializing Command.");
                if (_Command == null)
                    _Command = _Connection.CreateCommand();

                _Command.CommandText = sCommandText;
                _Command.CommandType = oCommandType;
                _Command.CommandTimeout = 0;

                if (oCommandType == CommandType.StoredProcedure)
                {
                    _Command.Parameters.Clear();
                    // CurrentActivityEvent("Discovering Command Parameters.");
                    oDatabase.DiscoverParameters(_Command);
                }
                // CurrentActivityEvent("Command Initialized.");
            }
            catch (Exception)
            {
                throw;
            }
        }

        #endregion

        #region Fill Data

        public System.Data.DataSet FillData(string sQuery)
        {
            try
            {
                // CurrentActivityEvent("Filling Data.");
                System.Data.DataSet oDS = oDatabase.ExecuteDataSet(CommandType.Text, sQuery); ;
                // CurrentActivityEvent("Data Filled.");
                return oDS;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public System.Data.DataSet FillData(string sQuery, params object[] oValues)
        {
            throw new Exception("This Method Is Not Yet Implemented");
        }

        public System.Data.DataSet FillData(string sQuery, params IDbDataParameter[] oSP_Params)
        {
            return FillData(CommandType.Text, sQuery, ref oSP_Params);
        }

        public System.Data.DataSet FillData(string sQuery, ref IDbDataParameter[] oSP_Params)
        {
            return FillData(CommandType.Text, sQuery, ref oSP_Params);
        }


        public System.Data.DataSet FillData_SP(string sSP_Name)
        {
            try
            {
                // CurrentActivityEvent("Filling Data.");
                System.Data.DataSet oDS = oDatabase.ExecuteDataSet(CommandType.StoredProcedure, sSP_Name);
                // CurrentActivityEvent("Data Filled.");
                return oDS;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public System.Data.DataSet FillData_SP(string sSP_Name, params object[] oValues)
        {
            try
            {
                // CurrentActivityEvent("Filling Data.");
                System.Data.DataSet oDS = oDatabase.ExecuteDataSet(sSP_Name, oValues);
                // CurrentActivityEvent("Data Filled.");
                return oDS;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public System.Data.DataSet FillData_SP(string sSP_Name, params IDbDataParameter[] oSP_Params)
        {
            return FillData(CommandType.StoredProcedure, sSP_Name, ref oSP_Params);
        }

        public System.Data.DataSet FillData_SP(string sSP_Name, ref IDbDataParameter[] oSP_Params)
        {
            return FillData(CommandType.StoredProcedure, sSP_Name, ref oSP_Params);
        }

        private System.Data.DataSet FillData(CommandType oCommandType, string sCommandText, ref IDbDataParameter[] oDataParams)
        {
            try
            {
                // CurrentActivityEvent("Filling Data.");
                InitCommand(sCommandText, oCommandType);
                _Command.Parameters.AddRange(oDataParams);
                return oDatabase.ExecuteDataSet(_Command);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                _Command.Parameters.CopyTo(oDataParams, 0);
                Close();
                // CurrentActivityEvent("Data Filled.");
            }
        }

        #endregion

        #region ExecuteNonQuery

        public int ExecuteNonQuery(string sQuery)
        {
            return oDatabase.ExecuteNonQuery(CommandType.Text, sQuery);
        }

        public int ExecuteNonQuery(string sQuery, params object[] oValues)
        {
            return oDatabase.ExecuteNonQuery(sQuery, oValues);
        }

        public int ExecuteNonQuery(string sQuery, params IDbDataParameter[] oSP_Params)
        {
            return ExecuteNonQuery_SP(sQuery, ref oSP_Params);
        }

        public int ExecuteNonQuery(string sQuery, ref IDbDataParameter[] oSP_Params)
        {
            try
            {
                InitCommand(sQuery, CommandType.Text);
                foreach (IDbDataParameter tmp1 in oSP_Params)
                {
                    foreach (IDbDataParameter tmp2 in _Command.Parameters)
                    {
                        if (tmp2.ParameterName.EndsWith(tmp1.ParameterName) && (tmp2.ParameterName.Length - 1) == tmp1.ParameterName.Length)
                        {
                            tmp2.Value = tmp1.Value;
                            break;
                        }
                    }
                }
                return oDatabase.ExecuteNonQuery(_Command);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                _Command.Parameters.CopyTo(oSP_Params, 0);
                if (!_isTranBegin)
                    Close();
            }
        }

        public int ExecuteNonQuery_SP(string sSP_Name)
        {
            return oDatabase.ExecuteNonQuery(CommandType.StoredProcedure, sSP_Name);
        }

        public int ExecuteNonQuery_SP(string sSP_Name, params object[] oValues)
        {
            return oDatabase.ExecuteNonQuery(sSP_Name, oValues);
        }

        public int ExecuteNonQuery_SP(string sSP_Name, params IDbDataParameter[] oSP_Params)
        {
            return ExecuteNonQuery_SP(sSP_Name, ref oSP_Params);
        }

        public int ExecuteNonQuery_SP(string sSP_Name, ref IDbDataParameter[] oSP_Params)
        {
            try
            {
                InitCommand(sSP_Name, CommandType.StoredProcedure);
                foreach (IDbDataParameter tmp1 in oSP_Params)
                {
                    foreach (IDbDataParameter tmp2 in _Command.Parameters)
                    {
                        if (tmp2.ParameterName.EndsWith(tmp1.ParameterName) && (tmp2.ParameterName.Length - 1) == tmp1.ParameterName.Length)
                        //if (tmp2.ParameterName.EndsWith(tmp1.ParameterName))
                        {
                            tmp2.Value = tmp1.Value;
                            break;
                        }
                    }
                }
                return oDatabase.ExecuteNonQuery(_Command);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                _Command.Parameters.CopyTo(oSP_Params, 0);
                if (!_isTranBegin)
                    Close();
            }
        }

        #endregion

        #region ExecuteScalar

        public object ExecuteScalar(string sQuery)
        {
            return oDatabase.ExecuteScalar(CommandType.Text, sQuery);
        }

        public object ExecuteScalar(string sQuery, params object[] oValues)
        {
            return oDatabase.ExecuteScalar(sQuery, oValues);
        }

        public object ExecuteScalar(string sQuery, params IDbDataParameter[] oSP_Params)
        {
            return oDatabase.ExecuteScalar(sQuery, oSP_Params);
        }

        public object ExecuteScalar(string sQuery, ref IDbDataParameter[] oSP_Params)
        {
            return null;// oDatabase.ExecuteScalar(sQuery, ref oSP_Params);
        }

        public object ExecuteScalar_SP(string sSP_Name)
        {
            return oDatabase.ExecuteScalar(CommandType.StoredProcedure, sSP_Name);
        }

        public object ExecuteScalar_SP(string sSP_Name, params object[] oValues)
        {
            return null; //oDatabaseHandler.ExecuteScalar_SP(sSP_Name, oValues);
        }

        public object ExecuteScalar_SP(string sSP_Name, params IDbDataParameter[] oSP_Params)
        {
            return null; // oDatabaseHandler.ExecuteScalar_SP(sSP_Name, oSP_Params);
        }

        public object ExecuteScalar_SP(string sSP_Name, ref IDbDataParameter[] oSP_Params)
        {
            return null; // oDatabaseHandler.ExecuteScalar_SP(sSP_Name, ref oSP_Params);
        }
        #endregion

        #region ExecuteReader

        public IDbDataParameter ExecuteReader(string sQuery)
        {
            return null; // oDatabaseHandler.ExecuteReader(sQuery);
        }

        public IDbDataParameter ExecuteReader(string sQuery, params object[] oValues)
        {
            return null; // oDatabaseHandler.ExecuteReader(sQuery, oValues);
        }

        public IDbDataParameter ExecuteReader(string sQuery, params IDbDataParameter[] oSP_Params)
        {
            return null; // oDatabaseHandler.ExecuteReader(sQuery, oSP_Params);
        }

        public IDbDataParameter ExecuteReader(string sQuery, ref IDbDataParameter[] oSP_Params)
        {
            return null; // oDatabaseHandler.ExecuteReader(sQuery, ref oSP_Params);
        }

        public IDbDataParameter ExecuteReader_SP(string sSP_Name)
        {
            return null; // oDatabaseHandler.ExecuteReader_SP(sSP_Name);
        }

        public IDbDataParameter ExecuteReader_SP(string sSP_Name, params object[] oValues)
        {
            return null; // oDatabaseHandler.ExecuteReader_SP(sSP_Name, oValues);
        }

        public IDbDataParameter ExecuteReader_SP(string sSP_Name, params IDbDataParameter[] oSP_Params)
        {
            return null; // oDatabaseHandler.ExecuteReader_SP(sSP_Name, oSP_Params);
        }

        public IDbDataParameter ExecuteReader_SP(string sSP_Name, ref IDbDataParameter[] oSP_Params)
        {
            return null; // oDatabaseHandler.ExecuteReader_SP(sSP_Name, ref oSP_Params);
        }

        #endregion

        #region CreateDataParameter

        public IDbDataParameter CreateDataParameter()
        {
            return oDatabase.DbProviderFactory.CreateParameter();
        }

        public IDbDataParameter CreateDataParameter(string sParameterName, object oValue)
        {
            return CreateDataParameter(sParameterName, oValue, ParameterDirection.Input, 50);
        }

        public IDbDataParameter CreateDataParameter(string sParameterName, object oValue, ParameterDirection oDirection)
        {
            return CreateDataParameter(sParameterName, oValue, oDirection, 50);
        }
        public IDbDataParameter CreateDataParameter(string sParameterName, object oValue, ParameterDirection oDirection, int iSize)
        {
            try
            {
                IDbDataParameter oTmp = oDatabase.DbProviderFactory.CreateParameter();
                oTmp.ParameterName = sParameterName;
                oTmp.Value = oValue;
                oTmp.Direction = oDirection;
                oTmp.Size = iSize;
                return oTmp;
            }
            catch (Exception)
            {
                throw;
            }
        }

        #endregion

        #region IDisposable Members

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        #endregion

        #region IDatabaseHandler Members

        public event CurrentActivityHandler CurrentActivity;

        #endregion
    }

}
