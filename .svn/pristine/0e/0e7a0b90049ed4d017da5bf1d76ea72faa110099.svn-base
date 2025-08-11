using System;
using System.Data;
using System.Data.Common;
using System.ComponentModel;
using System.Collections.Generic;
using System.Reflection;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Windows.Forms;

namespace BOSLib
{
    /// <summary>
    /// Summary description for DALBaseProvider.
    /// </summary>
    public class DALBaseProvider
    {
        protected string _tableName;
        protected Type _objectType;

        #region Constructors
        public DALBaseProvider()
        {

        }

        public DALBaseProvider(string strTableName, Type objType)
        {
            _tableName = strTableName;
            _objectType = objType;
        }
        #endregion

        #region Public Properties
        public string TableName
        {
            get
            {
                return _tableName;
            }
            set
            {
                _tableName = value;
            }
        }

        public Type ObjectType
        {
            get
            {
                return _objectType;
            }
            set
            {
                _objectType = value;
            }
        }
        #endregion

        #region Function for Generate Insert,Update,Select Query for Table
        private string GenerateInsertQuery()
        {
            string strInsertQuery = string.Format("INSERT INTO [dbo].[{0}] ", TableName);
            DataSet dsTableColumns = SqlDatabaseHelper.GetAllTableColumns(TableName);
            if (dsTableColumns.Tables.Count > 0)
            {
                strInsertQuery = strInsertQuery + GenerateInsertColumns(dsTableColumns) + " VALUES " + GenerateInsertColumnParameters(dsTableColumns);
            }
            return strInsertQuery;
        }

        private string GenerateInsertColumns(DataSet dsTableColumns)
        {
            string strInsertColumns = "(";
            for (int i = 0; i < dsTableColumns.Tables[0].Rows.Count; i++)
            {
                if (i == dsTableColumns.Tables[0].Rows.Count - 1)
                    strInsertColumns = strInsertColumns + "[" + dsTableColumns.Tables[0].Rows[i]["COLUMN_NAME"].ToString() + "])";
                else
                    strInsertColumns = strInsertColumns + "[" + dsTableColumns.Tables[0].Rows[i]["COLUMN_NAME"].ToString() + "],";
            }
            return strInsertColumns;

        }

        private string GenerateInsertColumnParameters(DataSet dsTableColumns)
        {
            string strInsertColumnParameters = "(";
            for (int i = 0; i < dsTableColumns.Tables[0].Rows.Count; i++)
            {
                if (i == dsTableColumns.Tables[0].Rows.Count - 1)
                    strInsertColumnParameters = strInsertColumnParameters + "@" + dsTableColumns.Tables[0].Rows[i]["COLUMN_NAME"].ToString() + ")";
                else
                    strInsertColumnParameters = strInsertColumnParameters + "@" + dsTableColumns.Tables[0].Rows[i]["COLUMN_NAME"].ToString() + ",";
            }
            return strInsertColumnParameters;
        }

        private string GenerateUpdateQuery()
        {
            string strUpdateQuery = string.Format("UPDATE [dbo].[{0}] SET ", TableName);

            DataSet dsTableColumns = SqlDatabaseHelper.GetAllTableColumns(TableName);
            if (dsTableColumns.Tables.Count > 0)
            {
                strUpdateQuery = strUpdateQuery + GenerateUpdateSetStatement(dsTableColumns) + " WHERE " + GenerateUpdateQueryWhereClause(dsTableColumns);
            }
            return strUpdateQuery;
        }

        private string GenerateUpdateSetStatement(DataSet dsTableColumns)
        {
            string strUpdateSetStatement = string.Empty;
            for (int i = 0; i < dsTableColumns.Tables[0].Rows.Count; i++)
            {
                string strColumnName = dsTableColumns.Tables[0].Rows[i]["COLUMN_NAME"].ToString();
                if (!SqlDatabaseHelper.ColumnIsPrimaryKey(TableName, strColumnName))
                {
                    if (i == dsTableColumns.Tables[0].Rows.Count - 1)
                        strUpdateSetStatement = strUpdateSetStatement + "[" + strColumnName + "] = @" + strColumnName;
                    else
                        strUpdateSetStatement = strUpdateSetStatement + "[" + strColumnName + "] = @" + strColumnName + ",";
                }
            }
            return strUpdateSetStatement;
        }

        private string GenerateUpdateQueryWhereClause(DataSet dsTableColumns)
        {
            string strWhereClause = string.Empty;
            string strPrimaryKeyColumn = SqlDatabaseHelper.GetPrimaryKeyColumn(TableName);
            strWhereClause = strWhereClause + "[" + strPrimaryKeyColumn + "]" + " = @" + strPrimaryKeyColumn;
            return strWhereClause;
        }

        private string GenerateSelectAllQuery()
        {
            return string.Format("SELECT * FROM [dbo].[{0}]", TableName);
        }

        private string GenerateSelectByPrimaryKeyQuery()
        {
            return string.Format("SELECT * FROM [dbo].[{0}] WHERE [{1}]=@{2}", TableName, SqlDatabaseHelper.GetPrimaryKeyColumn(TableName), SqlDatabaseHelper.GetPrimaryKeyColumn(TableName));
        }

        private string GenerateDeleteQuery()
        {
            return string.Format("DELETE FROM [dbo].[{0}] WHERE [{1}]=@{2}", TableName, SqlDatabaseHelper.GetPrimaryKeyColumn(TableName), SqlDatabaseHelper.GetPrimaryKeyColumn(TableName));
        }

        private string GenerateDeleteAllObjectsQuery()
        {
            return string.Format("DELETE FROM [dbo].[{0}]", TableName);
        }

        #endregion

        #region Function for Generate Insert,Update,Select Stored Procedure Name
        private string GenerateInsertStoredProcedureName()
        {
            return string.Format("{0}_Insert", TableName);
        }

        private string GenerateUpdateStoredProcedureName()
        {
            return string.Format("{0}_Update", TableName);
        }

        private string GenerateDeleteStoredProcedureName()
        {
            return string.Format("{0}_Delete", TableName);
        }

        private string GenerateDeleteByForeignColumnStoredProcedureName(String strForeignColumn)
        {
            return string.Format("{0}_DeleteBy{1}", TableName, strForeignColumn);
        }

        private string GenerateDeleteAllStoredProcedureName()
        {
            return string.Format("{0}_DeleteAll", TableName);
        }

        private string GenerateSelectAllStoredProcedureName()
        {
            return string.Format("{0}_SelectAll", TableName);
        }

        private string GenerateSelectAllProfilesStoredProcedureName()
        {
            return string.Format("{0}_SelectAllProfiles", TableName);
        }

        private string GenerateSelectAllAlivesStoredProcedureName()
        {
            return string.Format("{0}_SelectAlive{0}", TableName);
        }

        private string GenerateSelectByPrimaryKeyStoredProcedureName()
        {
            return string.Format("{0}_Select", TableName);
        }

        private string GenerateSelectDeletedByPrimayKeyStoredProcedureName()
        {
            return string.Format("{0}_SelectDeletedByID", TableName);
        }

        private string GenerateSelectByNameStoredProcedureName()
        {
            return string.Format("{0}_SelectByName", TableName);
        }

        private string GenerateSelectByNoStoredProcedureName()
        {
            return string.Format("{0}_SelectByNo", TableName);
        }

        private string GenerateSelectByAANumberIntStoredProcedureName()
        {
            return string.Format("{0}_SelectByAANumberInt", TableName);
        }

        private string GenerateSelectNewObjectInSessionStoredProcedureName()
        {
            return string.Format("{0}_SelectNewInSession", TableName);
        }

        private string GenerateUpdateObjectSaveStatusInSessionStoredProcedureName()
        {
            return string.Format("{0}_UpdateSaveStatusInSession", TableName);
        }

        private string GenerateSearchObjectStoredProcedureName()
        {
            return string.Format("{0}_Search", TableName);
        }

        private string GenerateSelectByForeignColumnStoredProcedureName(String strForeignColumnName)
        {
            return string.Format("{0}_SelectBy{1}", TableName, strForeignColumnName);
        }

        #endregion

        #region Utility Functions
        public void SetValueToPrimaryColumn(object obj, int iObjectID)
        {
            SqlDatabaseHelper.SetValueToPrimaryColumn(obj, this, iObjectID);
        }

        public void SetValueToIDStringColumn(object obj, int iObjectID)
        {
            SqlDatabaseHelper.SetValueToIDStringColumn(obj, this, iObjectID);
        }


        public object GetPrimaryColumnValue(object obj)
        {
            return SqlDatabaseHelper.GetPrimaryColumnValue(obj, this);
        }

        //public virtual int GetMaxID()
        //{
        //    return SqlDatabaseHelper.GetMaxID(TableName);
        //}
        public virtual int GetNextID()
        {
            return SqlDatabaseHelper.GetNextID(TableName);
        }
        public virtual int GetNextID(int current)
        {
            return SqlDatabaseHelper.GetNextID(TableName);
        }
        public DbCommand GetStoredProcedureCommand(String spName)
        {
            return SqlDatabaseHelper.GetStoredProcedure(spName);
        }

        public void AddParameter(DbCommand cmd, String name, DbType type, ParameterDirection direction, object value)
        {
            SqlDatabaseHelper.AddParameter(cmd, name, type, direction, value);
        }

        /// <summary>
        /// Execute a stored procedure
        /// </summary>
        /// <param name="spName">Stored procedure name</param>
        /// <param name="parameters">Parameters need to be passed to the stored procedure</param>
        public void ExecuteStoredProcedure(String spName, params object[] parameters)
        {
            SqlDatabaseHelper.RunStoredProcedure(spName, parameters);
        }

        public object GetParameterValue(DbCommand cmd, String paramName)
        {
            if (cmd.Parameters[paramName].Value == DBNull.Value)
                return null;
            return cmd.Parameters[paramName].Value;
        }
        #endregion

        #region Transaction Functions
        public DbTransaction BeginTransaction()
        {
            return SqlDatabaseHelper.BeginTransaction();
        }

        public void CommitTransaction(DbTransaction transaction)
        {
            SqlDatabaseHelper.CommitTransaction(transaction);
        }

        public void RollbackTransaction(DbTransaction transaction)
        {
            SqlDatabaseHelper.RollbackTransaction(transaction);
        }
        #endregion

        #region Create,Update,Delelte Functions
        public virtual int CreateObject(object obj)
        {
            return SqlDatabaseHelper.InsertObject(obj, this, GenerateInsertStoredProcedureName());
        }

        public virtual int CreateObject(object obj, DbTransaction transaction)
        {
            return SqlDatabaseHelper.InsertObject(obj, this, GenerateInsertStoredProcedureName(), transaction);
        }

        public virtual int UpdateObject(object obj)
        {
            return SqlDatabaseHelper.InsertObject(obj, this, GenerateUpdateStoredProcedureName());
        }

        public virtual int UpdateObject(object obj, DbTransaction transaction)
        {
            return SqlDatabaseHelper.InsertObject(obj, this, GenerateUpdateStoredProcedureName(), transaction);
        }

        public virtual void DeleteObject(int iObjectID)
        {
            DbCommand cmd = SqlDatabaseHelper.GetStoredProcedure(GenerateDeleteStoredProcedureName());
            SqlDatabaseHelper.AddInParameter(cmd, SqlDatabaseHelper.GetPrimaryKeyColumn(TableName), SqlDbType.Int, iObjectID);
            SqlDatabaseHelper.RunStoredProcedure(cmd);
        }

        public virtual void DeleteObject(int iObjectID, DbTransaction transaction)
        {
            try
            {
                DbCommand cmd = SqlDatabaseHelper.GetStoredProcedure(GenerateDeleteStoredProcedureName());
                SqlDatabaseHelper.AddInParameter(cmd, SqlDatabaseHelper.GetPrimaryKeyColumn(TableName), SqlDbType.Int, iObjectID);
                cmd.Transaction = transaction;
                SqlDatabaseHelper.RunStoredProcedure(cmd);
                SqlDatabaseHelper.CommitTransaction(transaction);
            }
            catch (Exception)
            {
                SqlDatabaseHelper.RollbackTransaction(transaction);
            }
        }

        public virtual void DeleteAllObjects()
        {
            SqlDatabaseHelper.RunStoredProcedure(GenerateDeleteAllStoredProcedureName());
        }

        public virtual void DeleteByForeignColumn(String strForeignColumn, object objValue)
        {
            SqlDatabaseHelper.RunStoredProcedure(GenerateDeleteByForeignColumnStoredProcedureName(strForeignColumn), objValue);
        }

        #endregion

        #region Get Functions
        public virtual object GetObjectById(int iObjectID)
        {
            DbCommand cmd = SqlDatabaseHelper.GetStoredProcedure(GenerateSelectByPrimaryKeyStoredProcedureName());
            SqlDatabaseHelper.AddInParameter(cmd, SqlDatabaseHelper.GetPrimaryKeyColumn(TableName), SqlDbType.Int, iObjectID);
            DataSet ds = SqlDatabaseHelper.RunStoredProcedure(cmd);
            if (ds.Tables.Count <= 0)
                return null;
            return SqlDatabaseHelper.GetSingleObject(ds.Tables[0], ObjectType);
        }

        public virtual DataSet GetDataSetByID(int iObjectID)
        {
            DbCommand cmd = SqlDatabaseHelper.GetStoredProcedure(GenerateSelectByPrimaryKeyStoredProcedureName());
            SqlDatabaseHelper.AddInParameter(cmd, SqlDatabaseHelper.GetPrimaryKeyColumn(TableName), SqlDbType.Int, iObjectID);
            DataSet ds = SqlDatabaseHelper.RunStoredProcedure(cmd);
            return ds;
        }

        public virtual String GetObjectNameByID(int iObjectID)
        {
            object obj = GetObjectById(iObjectID);
            if (obj != null)
            {
                String strObjectNameColumn = SqlDatabaseHelper.GetPrimaryKeyColumn(TableName).Substring(0, SqlDatabaseHelper.GetPrimaryKeyColumn(TableName).Length - 2) + "Name";
                PropertyInfo property = ObjectType.GetProperty(strObjectNameColumn);
                if (property != null)
                {
                    return property.GetValue(obj, null).ToString();
                }
            }
            return String.Empty;
        }

        public virtual String GetObjectNoByID(int iObjectID)
        {
            object obj = GetObjectById(iObjectID);
            if (obj != null)
            {
                String strObjectNoColumn = SqlDatabaseHelper.GetPrimaryKeyColumn(TableName).Substring(0, SqlDatabaseHelper.GetPrimaryKeyColumn(TableName).Length - 2) + "No";
                PropertyInfo property = ObjectType.GetProperty(strObjectNoColumn);
                if (property != null)
                {
                    return property.GetValue(obj, null).ToString();
                }
            }
            return String.Empty;
        }

        public virtual object GetObjectByName(String strObjectName)
        {
            try
            {
                DataSet ds = SqlDatabaseHelper.RunStoredProcedure(GenerateSelectByNameStoredProcedureName(), strObjectName);
                if (ds.Tables.Count > 0)
                {
                    return SqlDatabaseHelper.GetSingleObject(ds.Tables[0], ObjectType);
                }
            }
            catch (Exception)
            {
                return null;
            }
            return null;
        }

        public virtual object GetObjectByNo(String strObjectNo)
        {
            try
            {
                DataSet ds = SqlDatabaseHelper.RunStoredProcedure(GenerateSelectByNoStoredProcedureName(), strObjectNo);
                if (ds.Tables.Count > 0)
                {
                    return SqlDatabaseHelper.GetSingleObject(ds.Tables[0], ObjectType);
                }
            }
            catch (Exception)
            {
                return null;
            }
            return null;
        }

        public virtual object GetObjectByAANumberInt(int iAANumberInt)
        {
            try
            {
                DataSet ds = SqlDatabaseHelper.RunStoredProcedure(GenerateSelectByAANumberIntStoredProcedureName(), iAANumberInt);
                if (ds.Tables.Count > 0)
                {
                    return SqlDatabaseHelper.GetSingleObject(ds.Tables[0], ObjectType);
                }
            }
            catch (Exception)
            {
                return null;
            }
            return null;
        }

        public virtual int GetObjectIDByName(String strObjectName)
        {
            int iObjectID = 0;
            object obj = GetObjectByName(strObjectName);
            if (obj != null)
            {
                iObjectID = Convert.ToInt32(SqlDatabaseHelper.GetPrimaryColumnValue(obj, this));
            }
            return iObjectID;
        }

        public virtual int GetObjectIDByNo(String strObjectNo)
        {
            int iObjectID = 0;
            object obj = GetObjectByNo(strObjectNo);
            if (obj != null)
            {
                iObjectID = Convert.ToInt32(SqlDatabaseHelper.GetPrimaryColumnValue(obj, this));
            }
            return iObjectID;
        }

        public virtual object GetDeletedObjectByID(int iObjectID)
        {
            DbCommand cmd = SqlDatabaseHelper.GetStoredProcedure(GenerateSelectDeletedByPrimayKeyStoredProcedureName());
            SqlDatabaseHelper.AddInParameter(cmd, SqlDatabaseHelper.GetPrimaryKeyColumn(TableName), SqlDbType.Int, iObjectID);
            DataSet ds = SqlDatabaseHelper.RunStoredProcedure(cmd);
            if (ds.Tables.Count <= 0)
                return null;
            return SqlDatabaseHelper.GetSingleObject(ds.Tables[0], ObjectType);
        }

        public DataSet GetDataSet(string spName, params object[] paramValues)
        {
            return (DataSet)SqlDatabaseHelper.RunStoredProcedure(spName, paramValues);
        }

        /// <summary>
        /// Get Data Set By Query Command
        /// </summary>
        /// <param name="strQuery"></param>
        /// <returns></returns>
        public DataSet GetDataSet(String strQuery)
        {
            DbCommand cmd = SqlDatabaseHelper.GetQuery(strQuery);
            return (DataSet)SqlDatabaseHelper.RunQuery(cmd);
        }
        public DataSet GetDataSetByStringColumn(String column, string value)
        {
            String strQuery = String.Format("Select * From [dbo].[{0}] Where [{1}]='{2}'", TableName, column, value);
            return GetDataSet(strQuery);
        }
        public DataSet GetDataSetByIntColumn(String column, int value)
        {
            String strQuery = String.Format("Select * From [dbo].[{0}] Where [{1}]={2}", TableName, column, value);
            return GetDataSet(strQuery);
        }

        public DataSet GetDataSet(DbCommand cmd)
        {
            return SqlDatabaseHelper.RunStoredProcedure(cmd);
        }

        public virtual object GetTemplateObject()
        {
            String strSQL = String.Format("Select * From [dbo].[{0}] Where [{1}]='Template'", TableName, SqlDatabaseHelper.AAStatusColumn);
            DbCommand cmd = SqlDatabaseHelper.GetQuery(strSQL);
            DataSet ds = SqlDatabaseHelper.RunQuery(cmd);
            if (ds.Tables.Count > 0)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    return SqlDatabaseHelper.GetObjectFromDataRow(ds.Tables[0].Rows[0], ObjectType);
                }
            }
            return null;
        }

        public object GetDataObject(string spName, params object[] paramValues)
        {
            DataSet ds = SqlDatabaseHelper.RunStoredProcedure(spName, paramValues);
            return GetSingleObject(ds.Tables[0]);
        }

        /// <summary>
        /// Get single value from returned result by executing a stored procedure
        /// </summary>
        /// <param name="spName">Stored procedure name</param>
        /// <param name="paramValues">Parameters are passed in the stored procedure</param>
        /// <returns>Value</returns>
        public object GetSingleValue(string spName, params object[] paramValues)
        {
            DataSet ds = GetDataSet(spName, paramValues);
            object value = null;
            if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0][0] != DBNull.Value)
                {
                    value = ds.Tables[0].Rows[0][0];
                }
            }
            return value;
        }

        public object GetSingleObject(DataTable dt)
        {
            return SqlDatabaseHelper.GetSingleObject(dt, ObjectType);
        }

        //public object GetFirstObject()
        //{
        //    DataSet ds = GetAllObject();
        //    return GetSingleObject(ds.Tables[0]);
        //} 
        public object GetFirstObject()
        {
            String strSQL = String.Format("SELECT TOP 1 * FROM [dbo].[{0}] WHERE [{1}]='Alive'", TableName, SqlDatabaseHelper.AAStatusColumn);
            DbCommand cmd = SqlDatabaseHelper.GetQuery(strSQL);
            DataSet ds = SqlDatabaseHelper.RunQuery(cmd);
            return GetSingleObject(ds.Tables[0]);
        }

        public object GetObjectFromDataRow(DataRow row)
        {
            return SqlDatabaseHelper.GetObjectFromDataRow(row, ObjectType);
        }

        public DataSet GetNewObjectInSession(String strUserName)
        {
            return (DataSet)SqlDatabaseHelper.RunStoredProcedure(GenerateSelectNewObjectInSessionStoredProcedureName(), strUserName);
        }

        public void UpdateObjectSaveStatusInSession(String strUserName)
        {
            SqlDatabaseHelper.RunStoredProcedure(GenerateUpdateObjectSaveStatusInSessionStoredProcedureName(), strUserName);
        }

        public DataSet SearchObject(object objSearch)
        {
            DbCommand cmd = SqlDatabaseHelper.GetStoredProcedure(GenerateSearchObjectStoredProcedureName());
            SqlDatabaseHelper.AddParameterForSearchProperties(objSearch, cmd);
            return (DataSet)SqlDatabaseHelper.RunStoredProcedure(cmd);
        }

        public DataSet GetAllDataByForeignColumn(String strForeignColumnName, object objValue)
        {
            return (DataSet)SqlDatabaseHelper.RunStoredProcedure(GenerateSelectByForeignColumnStoredProcedureName(strForeignColumnName), objValue);

        }

        public virtual DataSet GetAllProfileObjects()
        {
            return SqlDatabaseHelper.RunStoredProcedure(GenerateSelectAllProfilesStoredProcedureName());
        }

        public virtual DataSet GetAllObject()
        {
            return SqlDatabaseHelper.RunStoredProcedure(GenerateSelectAllStoredProcedureName());
        }

        public virtual DataSet GetAllAliveObjects()
        {
            return SqlDatabaseHelper.RunStoredProcedure(GenerateSelectAllAlivesStoredProcedureName());
        }



        #endregion

        #region Function for get,delete all record From parent
        public DataSet GetAllObjectsByObjectParentID(int iObjectParentID)
        {
            String strPrimaryKey = SqlDatabaseHelper.GetPrimaryKeyColumn(TableName);
            String strParentObjectIDForeignKey = strPrimaryKey.Substring(0, strPrimaryKey.Length - 2) + "ParentID";
            String strQuery = String.Format("Select * From [{0}] Where AAStatus = 'Alive' And ([{1}]={2}) And ({2}>0)", TableName, strParentObjectIDForeignKey, iObjectParentID);
            DbCommand cmd = SqlDatabaseHelper.GetQuery(strQuery);
            return (DataSet)SqlDatabaseHelper.RunQuery(cmd);
        }

        public void DeleteAllObjectsByObjectParentID(int iObjectParentID)
        {
            String strPrimaryKey = SqlDatabaseHelper.GetPrimaryKeyColumn(TableName);
            String strParentObjectIDForeignKey = strPrimaryKey.Substring(0, strPrimaryKey.Length - 2) + "ParentID";
            if (SqlDatabaseHelper.ColumnIsExistInTable(TableName, strParentObjectIDForeignKey))
            {
                String strQuery = String.Format("Update [{0}] Set AAStatus = 'Delete' Where ([{1}]={2}) And ({2}>0)", TableName, strParentObjectIDForeignKey, iObjectParentID);
                DbCommand cmd = SqlDatabaseHelper.GetQuery(strQuery);
                SqlDatabaseHelper.RunQuery(cmd);
            }
        }
        #endregion

        #region Functions For Get,Delete Members From Owner and Switcher table
        public DataSet GetMembersFromOwner(String strOwnerTable, int iOwnerID, String strMemberTable, String strSwitcherTable)
        {
            String strOwnerPrimaryColumn = SqlDatabaseHelper.GetPrimaryKeyColumn(strOwnerTable);
            String strSwitcherPrimaryColumn = SqlDatabaseHelper.GetPrimaryKeyColumn(strSwitcherTable);
            String strMemberPrimaryColumn = SqlDatabaseHelper.GetPrimaryKeyColumn(strMemberTable);

            String strSwitcherQuery = String.Format(
                                    "Select [{0}] From [{1}] Where [{1}].[{2}] IN (Select [{2}] From [{3}] Where [{3}].[{2}]={4})",
                                    strMemberPrimaryColumn, strSwitcherTable,
                                    strOwnerPrimaryColumn, strOwnerTable, iOwnerID);
            String strMemberQuery = String.Format("Select * From [{0}] Where [{1}] IN ({2})",
                                                strMemberTable, strMemberPrimaryColumn, strSwitcherQuery);
            DbCommand cmd = SqlDatabaseHelper.GetQuery(strMemberQuery);
            return (DataSet)SqlDatabaseHelper.RunQuery(cmd);
        }

        public DataSet DeleteMembersFromOwner(String strOwnerTable, int iOwnerID, String strMemberTable, String strSwitcherTable)
        {
            String strOwnerPrimaryColumn = SqlDatabaseHelper.GetPrimaryKeyColumn(strOwnerTable);
            String strSwitcherPrimaryColumn = SqlDatabaseHelper.GetPrimaryKeyColumn(strSwitcherTable);
            String strMemberPrimaryColumn = SqlDatabaseHelper.GetPrimaryKeyColumn(strMemberTable);

            String strSwitcherQuery = String.Format(
                                    "Select [{0}] From [{1}] Where [{1}].[{2}] IN (Select [{2}] From [{3}] Where [{3}].[{2}]={4}))",
                                    strMemberPrimaryColumn, strSwitcherTable,
                                    strOwnerPrimaryColumn, strOwnerTable, iOwnerID);
            String strMemberQuery = String.Format("Detete From [{0}] Where [{1}] IN ({2})",
                                                strMemberTable, strMemberPrimaryColumn, strSwitcherQuery);
            DbCommand cmd = SqlDatabaseHelper.GetQuery(strMemberQuery);
            return (DataSet)SqlDatabaseHelper.RunQuery(cmd);
        }
        #endregion
    }
}
