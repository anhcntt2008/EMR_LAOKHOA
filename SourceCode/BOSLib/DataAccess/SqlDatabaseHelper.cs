using System;
using System.Data.Common;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Data;
using System.Data.SqlClient;
using System.Data.OleDb;
using System.Text;
using System.Security;
using System.Security.Cryptography;
using System.Windows.Forms;
using System.Configuration;
using Microsoft.Practices.EnterpriseLibrary.Data;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using BOSLib.DataAccess;
using System.Linq;
using System.Collections.Concurrent;

namespace BOSLib
{
    /// <summary>
    /// Summary description for Class1.
    /// </summary>
    /// <summary>
    /// Summary description for DatabaseHelper.
    /// </summary>
    public class SqlDatabaseHelper
    {
        private static SqlDatabase database = null;
        public static string AAStatusColumn = "AAStatus";
        private static SortedList lstPrimaryColumns = new SortedList();
        private static object lstPrimaryColumnsLock = new object();

        //private static List<String> lstTableColumnNames = new List<String>();
        private static String _connectionString = String.Empty;
        private static String _companyName = String.Empty;

        public static string _rabbitMQ_HostName = string.Empty;
        public static string _HIS_DB_SERVER = string.Empty;
        public static string _HIS_INTERGRATE_API_ENDPOINT = string.Empty;
        public static string _HIS_API_ENDPOINT = string.Empty;
        public static string _HIS_SIGN_API_ENDPOINT = string.Empty;
        public static string _EMR_API_ENDPOINT = string.Empty;
        public static string _MONGO_HOST = string.Empty;
        public static string _PRIVATE_FTP_HOST = string.Empty;
        //public static string _FTP_ROOT_PATH = string.Empty;

        private static Dictionary<string, string> _tableIdentities;

        #region Public properties
        public static SortedList PrimaryColumnsList
        {
            get
            {
                return lstPrimaryColumns;
            }
        }

        /// <summary>
        /// Gets or sets the column collection that does not allow null
        /// </summary>
        public static SortedList<string, DataColumnCollection> NotNullTableColumns { get; set; }

        /// <summary>
        /// Gets or sets the foreign column collection
        /// </summary>
        public static ConcurrentDictionary<string, DataColumnCollection> ForeignTableColumns { get; set; }
        #endregion

        #region "Constructor"
        static SqlDatabaseHelper()
        {
            try
            {
                _connectionString = GetConnectionStringFromRegistry();
                //If can get connection string from registry
                if (!String.IsNullOrEmpty(_connectionString))
                    database = new SqlDatabase(_connectionString);
                else
                {
                    //Get from configuration file
                    Crypto cryp = new Crypto();
                    string serverName = cryp.DecryptNew(ConfigurationManager.AppSettings["ServerName"], true);
                    string databaseName = cryp.DecryptNew(ConfigurationManager.AppSettings["DatabaseName"], true);
                    string userID = cryp.DecryptNew(ConfigurationManager.AppSettings["UserID"], true);
                    string password = cryp.DecryptNew(ConfigurationManager.AppSettings["Password"], true);

                    _rabbitMQ_HostName = ConfigurationManager.AppSettings["RabbitMQ_HostName"];
                    _HIS_DB_SERVER = ConfigurationManager.AppSettings["HIS_DB_SERVER"];
                    _HIS_INTERGRATE_API_ENDPOINT = ConfigurationManager.AppSettings["HIS_INTERGRATE_API_ENDPOINT"];
                    _HIS_API_ENDPOINT = ConfigurationManager.AppSettings["HIS_API_ENDPOINT"];
                    _EMR_API_ENDPOINT = ConfigurationManager.AppSettings["EMR_API_ENDPOINT"];
                    _HIS_SIGN_API_ENDPOINT = ConfigurationManager.AppSettings["HIS_SIGN_API_ENDPOINT"];
                    _MONGO_HOST = ConfigurationManager.AppSettings["MONGO_HOST"];
                    _PRIVATE_FTP_HOST = ConfigurationManager.AppSettings["PRIVATE_FTP_HOST"];
                    //_FTP_ROOT_PATH = ConfigurationManager.AppSettings["PRIVATE_FTP_ROOT_PATH"];

                    _connectionString = string.Format("Data Source={0};Initial Catalog={1};User ID={2};Password={3}", serverName, databaseName, userID, password);
                    database = new SqlDatabase(_connectionString);
                }
                lstPrimaryColumns = GetAllTablePrimaryColumns();
                NotNullTableColumns = new SortedList<string, DataColumnCollection>();
                ForeignTableColumns = new ConcurrentDictionary<string, DataColumnCollection>();
                _tableIdentities = GetTableIdentities();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public static System.String CompanyName
        {
            get { return _companyName; }
            set { _companyName = value; }
        }

        public static String GetConnectionStringFromRegistry()
        {
            String result;

            RegistryWorker regW = new RegistryWorker();
            regW.SubKey = "SOFTWARE\\BYS";
            regW.SubKey = regW.SubKey + "\\ConnectionString";
            String strDatabase = regW.Read("Database");
            String strServer = regW.Read("Server");
            String strUser = regW.Read("User");
            string strPassword = regW.Read("Password");

            if (!String.IsNullOrEmpty(strServer))
            {
                Crypto cryp = new Crypto();
                strPassword = cryp.Decrypt(strPassword);
                result = string.Format("Data Source={0};Initial Catalog={1};User ID={2};Password={3}", strServer, strDatabase, strUser, strPassword);
                return result;
            }
            return String.Empty;
        }

        public static void SwitchConnection(String strConnectionString)
        {
            database = new SqlDatabase(strConnectionString);
        }

        public static void RollbackToLocalConnection()
        {
            database = new SqlDatabase(_connectionString);
        }

        public static SqlDatabase CreateConnection(string connectionString)
        {
            return new SqlDatabase(connectionString);
        }
        #endregion

        #region "Get Object Functions"
        public static object GetSingleObject(DataTable dt, Type type)
        {
            try
            {
                if (dt.Rows.Count <= 0)
                    return null;
                object obj = GetObjectFromDataRow(dt.Rows[0], type);
                return obj;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public static System.Collections.ArrayList GetObjectCollection(DataTable dt, Type type, string tableName)
        {
            System.Reflection.PropertyInfo[] properties = type.GetProperties(BindingFlags.Public | BindingFlags.NonPublic);
            System.Collections.ArrayList list = new System.Collections.ArrayList();
            foreach (DataRow row in dt.Rows)
            {
                list.Add(GetObjectFromDataRow(row, type));
            }
            return list;
        }

        public static object GetObjectFromDataRow(DataRow row, Type type)
        {
            object obj = type.InvokeMember("", System.Reflection.BindingFlags.CreateInstance, null, null, null);
            foreach (DataColumn column in row.Table.Columns)
            {
                object objValue = row[column];
                if (objValue != System.DBNull.Value)
                {
                    PropertyInfo property = obj.GetType().GetProperty(column.ColumnName);
                    if (property != null)
                        property.SetValue(obj, objValue, null);
                }
            }
            return obj;
        }

        public static DataSet GetObjectbyId(string tableName, int id)
        {
            String sqlCommand = string.Format("Select * From {0} where {1} = {2}", GetPrimaryKeyColumn(tableName), id);
            DbCommand cmd = database.GetSqlStringCommand(sqlCommand);
            return database.ExecuteDataSet(cmd);
        }

        public static void SetValueToPrimaryColumn(object obj, DALBaseProvider provider, int iObjectID)
        {
            string strPrimaryKeyColumn = GetPrimaryKeyColumn(provider.TableName);

            PropertyInfo property = provider.ObjectType.GetProperty(strPrimaryKeyColumn);
            property.SetValue(obj, iObjectID, null);

        }

        public static void SetValueToIDStringColumn(object obj, DALBaseProvider provider, int iObjectID)
        {
            string strPrimaryKeyColumn = GetPrimaryKeyColumn(provider.TableName);
            PropertyInfo property = provider.ObjectType.GetProperty(strPrimaryKeyColumn + "String");
            if (property != null)
            {
                property.SetValue(obj, iObjectID.ToString(), null);
            }
        }


        public static object GetPrimaryColumnValue(object obj, DALBaseProvider provider)
        {
            string strPrimaryKeyColumn = GetPrimaryKeyColumn(provider.TableName);
            PropertyInfo property = provider.ObjectType.GetProperty(strPrimaryKeyColumn);
            object objValue = property.GetValue(obj, null);
            return objValue;
        }

        #endregion

        #region Table,Column,Query Helpers

        private static Dictionary<string, string> GetTableIdentities()
        {
            var allTables = new SortedList<string, string>();
            foreach (DataRow r in GetSchemaTables().Rows)
            {
                allTables.Add(r["TABLE_NAME"].ToString(), r["TABLE_NAME"].ToString());
            }
            var result = new Dictionary<string, string>();
            foreach (var tb in allTables)
            {
                if (allTables.ContainsKey(tb.Key + "_Identity"))
                {
                    result.Add(tb.Key, tb.Key + "_Identity");
                }
            }
            return result;
        }

        public static DataTable GetSchemaTables()
        {
            if (SystemMemCache.INFORMATION_SCHEMA_TABLES == null)
            {
                var strQuery = "SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_TYPE = 'BASE TABLE' AND TABLE_NAME <> 'sysdiagrams'";
                DbCommand cmd = GetQuery(strQuery);
                SystemMemCache.INFORMATION_SCHEMA_TABLES = RunQuery(cmd).Tables[0];
            }
            return SystemMemCache.INFORMATION_SCHEMA_TABLES;
        }
        public static DataSet GetSchemaTableFromMemoryCache(string sql)
        {
            var tbs = GetSchemaTables();
            var ds = new DataSet();
            var tb = tbs.Clone();
            ds.Tables.Add(tb);

            var rows = tbs.Select(sql).ToList();
            foreach (var row in rows)
            {
                tb.ImportRow(row);
            }
            return ds;
        }


        public static string GetPrimaryKeyColumn(string strTableName)
        {
            //DataSet ds = database.ExecuteDataSet("GEDBUtil_SelectTablePrimaryKeys", strTableName);
            //if (ds.Tables.Count > 0)
            //{
            //    if (ds.Tables[0].Rows.Count > 0)
            //        return ds.Tables[0].Rows[0]["COLUMN_NAME"].ToString();
            //}
            //return string.Empty;

            String strPrimaryKeyColumn = String.Empty;

            if (lstPrimaryColumns[strTableName] != null)
                strPrimaryKeyColumn = lstPrimaryColumns[strTableName].ToString();
            else
            {
                String strQuery = "SELECT kcu.* FROM INFORMATION_SCHEMA.KEY_COLUMN_USAGE kcu,INFORMATION_SCHEMA.TABLE_CONSTRAINTS tc ";
                strQuery += String.Format("WHERE (kcu.TABLE_NAME='{0}')", strTableName);
                strQuery += "AND(kcu.CONSTRAINT_NAME=tc.CONSTRAINT_NAME)AND(tc.CONSTRAINT_TYPE='PRIMARY KEY')";
                DbCommand cmd = GetQuery(strQuery);
                DataSet ds = RunQuery(cmd);
                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                        strPrimaryKeyColumn = ds.Tables[0].Rows[0]["COLUMN_NAME"].ToString();
                }
            }

            return strPrimaryKeyColumn;
        }

        public static DataSet GetAllTableColumns(string strTableName)
        {
            String strQuery = String.Format("TABLE_NAME = '{0}'", strTableName);
            return GetSchemaColumnFromMemoryCache(strQuery);
            //String strQuery = String.Format("SELECT * FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = '{0}'", strTableName);
            //DbCommand cmd = GetQuery(strQuery);
            //return RunQuery(cmd);
        }
        public static DataSet GetSchemaColumnFromMemoryCache(string sql)
        {
            if (SystemMemCache.INFORMATION_SCHEMA_COLUMNS == null)
            {
                var strQuery = "SELECT * FROM INFORMATION_SCHEMA.COLUMNS";
                DbCommand cmd = GetQuery(strQuery);
                SystemMemCache.INFORMATION_SCHEMA_COLUMNS = RunQuery(cmd).Tables[0];
            }
            var ds = new DataSet();
            var tb = SystemMemCache.INFORMATION_SCHEMA_COLUMNS.Clone();
            ds.Tables.Add(tb);

            var rows = SystemMemCache.INFORMATION_SCHEMA_COLUMNS.Select(sql).ToList();
            foreach (var row in rows)
            {
                tb.ImportRow(row);
            }
            return ds;
        }

        public static SortedList GetAllTablePrimaryColumns()
        {
            SortedList lstPrimaryColumns = new SortedList();
            String strQuery = "SELECT kcu.* FROM INFORMATION_SCHEMA.KEY_COLUMN_USAGE kcu,INFORMATION_SCHEMA.TABLE_CONSTRAINTS tc WHERE";
            strQuery += "(kcu.TABLE_NAME IN (SELECT TABLE_NAME FROM INFORMATION_SCHEMA.TABLES	WHERE(TABLE_TYPE='BASE TABLE')AND(TABLE_NAME<>'sysdiagrams')))";
            strQuery += " AND(kcu.CONSTRAINT_NAME=tc.CONSTRAINT_NAME)AND(tc.CONSTRAINT_TYPE='PRIMARY KEY')";
            DbCommand cmd = GetQuery(strQuery);
            DataSet ds = RunQuery(cmd);
            if (ds.Tables.Count > 0)
            {
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    String strTableName = row["TABLE_NAME"].ToString();
                    String strColumnName = row["COLUMN_NAME"].ToString();
                    lock (lstPrimaryColumnsLock)
                    {
                        if (!lstPrimaryColumns.ContainsKey(strTableName))
                            lstPrimaryColumns.Add(strTableName, strColumnName);
                    }
                }
            }
            return lstPrimaryColumns;
        }

        public static DataSet GetTableColumn(String strTableName, String strColumnName)
        {
            String strQuery = String.Format("TABLE_NAME = '{0}' AND COLUMN_NAME = '{1}'", strTableName, strColumnName);
            return GetSchemaColumnFromMemoryCache(strQuery);
            //String strQuery = String.Format("SELECT * FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = '{0}' AND COLUMN_NAME = '{1}'", strTableName, strColumnName);
            //DbCommand cmd = GetQuery(strQuery);
            //return RunQuery(cmd);
        }

        public static bool ColumnIsExistInTable(string strTableName, string strColumnName)
        {
            DataSet ds = GetTableColumn(strTableName, strColumnName);
            if (ds.Tables.Count > 0)
            {
                if (ds.Tables[0].Rows.Count > 0)
                    return true;
            }
            return false;
        }

        //public static bool ColumnIsForeignKey(string strTableName, string strColumnName)
        //{
        //    String strQuery = String.Format("SELECT kcu.* FROM INFORMATION_SCHEMA.KEY_COLUMN_USAGE kcu, INFORMATION_SCHEMA.TABLE_CONSTRAINTS tc WHERE kcu.TABLE_NAME = '{0}' AND kcu.COLUMN_NAME = '{1}' AND kcu.CONSTRAINT_NAME = tc.CONSTRAINT_NAME AND tc.CONSTRAINT_TYPE = 'FOREIGN KEY'", strTableName, strColumnName);
        //    DbCommand cmd = GetQuery(strQuery);
        //    DataSet ds = RunQuery(cmd);
        //    if (ds.Tables.Count > 0)
        //    {
        //        if (ds.Tables[0].Rows.Count > 0)
        //            return true;
        //    }
        //    return false;
        //}

        //public static bool IsColumnAllowNull(string strTableName, string strColumnName)
        //{
        //    DataSet ds = GetTableColumn(strTableName, strColumnName);
        //    if (ds.Tables.Count > 0)
        //    {
        //        if (ds.Tables[0].Rows.Count > 0)
        //        {
        //            if (ds.Tables[0].Rows[0]["IS_NULLABLE"].ToString() == "YES")
        //                return true;
        //            else
        //                return false;
        //        }
        //    }
        //    return true;
        //}

        public static bool ColumnIsPrimaryKey(string strTableName, string strColumnName)
        {
            String strQuery = String.Format("SELECT kcu.* FROM INFORMATION_SCHEMA.KEY_COLUMN_USAGE kcu, INFORMATION_SCHEMA.TABLE_CONSTRAINTS tc WHERE kcu.TABLE_NAME = '{0}' AND kcu.COLUMN_NAME = '{1}' AND kcu.CONSTRAINT_NAME = tc.CONSTRAINT_NAME AND tc.CONSTRAINT_TYPE = 'PRIMARY KEY'", strTableName, strColumnName);
            DbCommand cmd = GetQuery(strQuery);
            DataSet ds = RunQuery(cmd);
            if (ds.Tables.Count > 0)
            {
                if (ds.Tables[0].Rows.Count > 0)
                    return true;
            }
            return false;
        }

        public static String GetQueryCommandByTableNameAndTableQueryKey(String strTableName, String strTableQueryKey)
        {
            String strQueryCommand = String.Empty;
            DbCommand cmd = SqlDatabaseHelper.GetQuery(String.Format("SELECT * FROM [dbo].[STTableQueries] WHERE ([STTableQueryTableName]='{0}')AND([STTableQueryKey]='{1}')", strTableName, strTableQueryKey));
            DataSet ds = SqlDatabaseHelper.RunQuery(cmd);
            if (ds.Tables.Count > 0)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    strQueryCommand = ds.Tables[0].Rows[0]["STTableQueryCommand"].ToString();
                }
            }
            return strQueryCommand;
        }

        public static void InsertQueryCommand(String strQueryCommand, String strTableName, String strQueryKey)
        {
            String strCommand = String.Format("INSERT INTO [dbo].[STTableQueries] ([STTableQueryID],[STTableQueryTableName],[STTableQueryKey],[STTableQueryCommand]) VALUES({0},'{1}','{2}','{3}')", GetMaxID("STTableQueries") + 1, strTableName, strQueryKey, strQueryCommand);
            DbCommand cmd = GetQuery(strCommand);
            database.ExecuteNonQuery(cmd);
        }
        #endregion

        #region "Add Parameter Functions"
        public static int GetNextID(string tableName)
        {
            if (_tableIdentities.ContainsKey(tableName))
                return GetNextIDFromIdentity(tableName);
            else
                return GetMaxID(tableName) + 1;
        }
        public static int GetNextID(int current, string tableName)
        {
            if (_tableIdentities.ContainsKey(tableName))
                return GetNextIDFromIdentity(tableName);
            else
                return current + 1;
        }
        private static int GetMaxID(string tableName)
        {
            int MaxID = 0;
            String sqlCommand = String.Format("SELECT Max({0}) AS MaxID FROM [{1}]", GetPrimaryKeyColumn(tableName), tableName);
            DbCommand cmd = database.GetSqlStringCommand(sqlCommand);
            DataSet ds = database.ExecuteDataSet(cmd);
            if (ds.Tables.Count > 0)
            {
                DataRow row = ds.Tables[0].Rows[0];
                if (row[0].ToString() != "")
                    MaxID = (int)row[0];
            }
            return MaxID;
        }
        private static int GetNextIDFromIdentity(string tableName)
        {
            int MaxID = 0;
            String sqlCommand = String.Format("INSERT INTO [{0}_Identity] OUTPUT Inserted.ID VALUES(GETDATE())", tableName);
            DbCommand cmd = database.GetSqlStringCommand(sqlCommand);
            DataSet ds = database.ExecuteDataSet(cmd);
            if (ds.Tables.Count > 0)
            {
                DataRow row = ds.Tables[0].Rows[0];
                if (row[0].ToString() != "")
                    MaxID = (int)row[0];
            }
            return MaxID;
        }
        public static void AddInParameter(DbCommand cmd, string name, SqlDbType type, Object objValue)
        {
            database.AddInParameter(cmd, name, type, objValue);
        }

        public static void AddParameter(DbCommand cmd, string name, DbType type, ParameterDirection direction, object value)
        {
            SqlParameter param = new SqlParameter(name, value);
            param.DbType = type;
            param.Direction = direction;
            cmd.Parameters.Add(param);
        }

        /// <summary>
        /// Check Property is exist or not in Base Business Object
        /// </summary>
        /// <param name="strPropertyName"></param>
        /// <returns></returns>
        private static bool ColumnIsExistInBaseBusinessObject(String strPropertyName)
        {
            PropertyInfo[] properties = typeof(BusinessObject).GetProperties();

            foreach (PropertyInfo prop in properties)
            {
                if (prop.Name.Equals(strPropertyName))
                    return true;
            }
            return false;
        }

        public static void AddParameterForObject(object obj, DALBaseProvider provider, DbCommand cmd)
        {
            try
            {
                //Init table columns
                var lstTableColumnNames = new List<string>();
                DataSet ds = GetAllTableColumns(provider.TableName);
                if (ds.Tables.Count > 0)
                {
                    foreach (DataRow row in ds.Tables[0].Rows)
                        lstTableColumnNames.Add(row["COLUMN_NAME"].ToString());
                }

                System.Reflection.PropertyInfo[] properties = provider.ObjectType.GetProperties();
                for (int i = 0; i < properties.Length; i++)
                {
                    //Add property exist in Table
                    if (lstTableColumnNames.IndexOf(properties[i].Name) >= 0)
                    {
                        object objValue = properties[i].GetValue(obj, null);
                        if (properties[i].PropertyType.Equals(typeof(Int32)))
                            database.AddInParameter(cmd, properties[i].Name, SqlDbType.Int, objValue);
                        else if (properties[i].PropertyType.Equals(typeof(Boolean)))
                            database.AddInParameter(cmd, properties[i].Name, SqlDbType.Bit, objValue);
                        else if (properties[i].PropertyType.Equals(typeof(short)))
                            database.AddInParameter(cmd, properties[i].Name, SqlDbType.SmallInt, objValue);
                        else if (properties[i].PropertyType.Equals(typeof(byte)))
                            database.AddInParameter(cmd, properties[i].Name, SqlDbType.TinyInt, objValue);
                        else if (properties[i].PropertyType.Equals(typeof(double)))
                            database.AddInParameter(cmd, properties[i].Name, SqlDbType.Float, objValue);
                        else if (properties[i].PropertyType.Equals(typeof(decimal)))
                            database.AddInParameter(cmd, properties[i].Name, SqlDbType.Decimal, objValue);
                        else if ((properties[i].PropertyType.Equals(typeof(String))) || (properties[i].PropertyType.Equals(typeof(string))))
                            database.AddInParameter(cmd, properties[i].Name, SqlDbType.NVarChar, objValue);
                        else if (properties[i].PropertyType.Equals(typeof(DateTime)))
                        {
                            if ((DateTime)objValue == DateTime.MinValue)
                            {
                                //DDCan [MOD][10/09/2013] [Fix error: "Procedure or function 'ICProductSeries_Insert' expects parameter '@ICProductSerieReceiptDate', which was not supplied."], START
                                //Min Date in C# = 01/01/0001 while Min Date (DateTime Datatype) in SQL Server 2008 = 01/01/1753
                                //continue;
                                objValue = DateTime.MaxValue;
                                //DDCan [MOD][10/09/2013] [Fix error: "Procedure or function 'ICProductSeries_Insert' expects parameter '@ICProductSerieReceiptDate', which was not supplied."], END
                            }
                            database.AddInParameter(cmd, properties[i].Name, SqlDbType.DateTime, objValue);
                        }
                        else if (properties[i].PropertyType.Equals(typeof(byte[])))
                        {
                            database.AddInParameter(cmd, properties[i].Name, SqlDbType.VarBinary, objValue);
                        }
                        else
                            continue;

                    }

                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public static void AddParameterForSearchProperties(object obj, DbCommand cmd)
        {
            PropertyInfo[] searchProperties = obj.GetType().GetProperties();
            for (int i = 0; i < searchProperties.Length; i++)
            {
                object objValue = searchProperties[i].GetValue(obj, null);
                String strParamName = searchProperties[i].Name;
                if (searchProperties[i].Name.Equals("TopResults"))
                {
                    database.AddInParameter(cmd, strParamName, SqlDbType.Int, objValue);
                }
                else
                {
                    if (searchProperties[i].PropertyType.Equals(typeof(Int32)))
                    {
                        database.AddInParameter(cmd, searchProperties[i].Name, SqlDbType.Int, objValue);

                    }
                    else if (searchProperties[i].PropertyType.Equals(typeof(Boolean)))
                        database.AddInParameter(cmd, searchProperties[i].Name, SqlDbType.Bit, objValue);
                    else if (searchProperties[i].PropertyType.Equals(typeof(short)))
                        database.AddInParameter(cmd, searchProperties[i].Name, SqlDbType.SmallInt, objValue);
                    else if (searchProperties[i].PropertyType.Equals(typeof(double)))
                        database.AddInParameter(cmd, searchProperties[i].Name, SqlDbType.Float, objValue);
                    else if (searchProperties[i].PropertyType.Equals(typeof(decimal)))
                        database.AddInParameter(cmd, searchProperties[i].Name, SqlDbType.Decimal, objValue);
                    else if ((searchProperties[i].PropertyType.Equals(typeof(String))) || (searchProperties[i].PropertyType.Equals(typeof(string))))
                        database.AddInParameter(cmd, searchProperties[i].Name, SqlDbType.NVarChar, objValue);
                    else if (searchProperties[i].PropertyType.Equals(typeof(DateTime)))
                    {
                        if ((DateTime)objValue == DateTime.MinValue)
                            continue;
                        database.AddInParameter(cmd, searchProperties[i].Name, SqlDbType.DateTime, objValue);
                    }
                    else if (searchProperties[i].PropertyType.Equals(typeof(byte[])))
                    {
                        database.AddInParameter(cmd, searchProperties[i].Name, SqlDbType.VarBinary, objValue);
                    }
                }
            }
        }
        #endregion

        #region "Excute Store Procedured Functions"

        public static int InsertObject(object obj, DALBaseProvider provider, string spName)
        {
            try
            {
                DbCommand cmd = database.GetStoredProcCommand(spName);
                AddParameterForObject(obj, provider, cmd);

                database.ExecuteNonQuery(cmd);
                int ret = (int)database.GetParameterValue(cmd, GetPrimaryKeyColumn(provider.TableName));
                return ret;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public static int InsertObject(object obj, DALBaseProvider provider, string spName, DbTransaction transaction)
        {
            try
            {
                //Prepare Command to excute with transaction
                DbCommand cmd = database.GetStoredProcCommand(spName);
                AddParameterForObject(obj, provider, cmd);
                cmd.Transaction = transaction;

                //Excute command and commit if have not any exception
                database.ExecuteNonQuery(cmd, transaction);
                transaction.Commit();

                //return value
                int ret = (int)database.GetParameterValue(cmd, GetPrimaryKeyColumn(provider.TableName));
                return ret;

            }
            catch (Exception e)
            {
                transaction.Rollback();
                throw e;
            }
        }

        public static DataSet RunStoredProcedure(string spName)
        {
            DbCommand cmd = database.GetStoredProcCommand(spName);
            return database.ExecuteDataSet(cmd);
        }

        public static DataSet RunStoredProcedure(DbCommand cmd)
        {
            try
            {
                return database.ExecuteDataSet(cmd);
            }
            catch (SqlException e)
            {
                throw e;
            }
        }

        public static DataSet RunStoredProcedure(string spName, params object[] values)
        {
            for (int i = 0; i < values.Length; i++)
            {
                object value = values[i];
                if (value != null)
                {
                    if (value.GetType() != typeof(bool))
                    {
                        if (value.Equals(0) || value.Equals(string.Empty))
                        {
                            values[i] = null;
                        }
                    }
                }
            }
            return database.ExecuteDataSet(spName, values);
        }

        public static DataSet RunStoredProcedure(SqlDatabase database, string spName, params object[] values)
        {
            for (int i = 0; i < values.Length; i++)
            {
                object value = values[i];
                if (value != null)
                {
                    if (value.GetType() != typeof(bool))
                    {
                        if (value.Equals(0) || value.Equals(string.Empty))
                        {
                            values[i] = null;
                        }
                    }
                }
            }
            return database.ExecuteDataSet(spName, values);
        }

        public static DbCommand GetStoredProcedure(string spName)
        {
            return database.GetStoredProcCommand(spName);
        }

        public static object RunStoreProcedure(DbCommand cmd, string retVariable)
        {
            database.ExecuteNonQuery(cmd);
            return (object)database.GetParameterValue(cmd, retVariable);
        }

        public static void ExecuteNonQuery(String spName, params object[] values)
        {
            database.ExecuteNonQuery(spName, values);
        }

        public static void ExecuteNonQuery(Database database, String spName, params object[] values)
        {
            database.ExecuteNonQuery(spName, values);
        }

        public static bool TestConnection()
        {
            return SqlDatabaseHelper.TestConnection(database);
        }

        public static bool TestConnection(SqlDatabase database)
        {
            try
            {
                String strTestQuery = "Select * From [CSCompanys]";
                DbCommand cmd = database.GetSqlStringCommand(strTestQuery);
                database.ExecuteDataSet(cmd);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        #endregion

        #region Transaction Functions
        public static DbTransaction BeginTransaction()
        {
            DbConnection connection = database.CreateConnection();
            return connection.BeginTransaction();
        }

        public static void CommitTransaction(DbTransaction transaction)
        {
            transaction.Commit();
        }

        public static void RollbackTransaction(DbTransaction transaction)
        {
            transaction.Rollback();
        }
        #endregion

        #region "Execute Query String"
        public static DbCommand GetQuery(String strQueryCommand)
        {
            return database.GetSqlStringCommand(strQueryCommand);
        }

        public static DbCommand GetQuery(String strTableName, String strTableQueryKey, String strQueryCommand)
        {
            String strCommandFromDB = GetQueryCommandByTableNameAndTableQueryKey(strTableName, strTableQueryKey);
            if (String.IsNullOrEmpty(strCommandFromDB))
            {
                InsertQueryCommand(strQueryCommand, strTableName, strTableQueryKey);
                return database.GetSqlStringCommand(strQueryCommand);
            }
            else
            {
                return database.GetSqlStringCommand(strCommandFromDB);
            }
        }

        private static string GetWhereClause(string strQueryCommand)
        {
            if (strQueryCommand.Contains("WHERE"))
            {
                return strQueryCommand.Substring(strQueryCommand.IndexOf("WHERE"));
            }
            else
                return string.Empty;
        }


        public static string[] GetParameters(string strQueryCommand)
        {
            string[] parameters = new string[0];
            string strWhereClause = GetWhereClause(strQueryCommand);
            if (!string.IsNullOrEmpty(strWhereClause))
            {
                do
                {
                    strWhereClause = strWhereClause.Substring(strWhereClause.IndexOf("@"));
                    string strParameter = strWhereClause.Substring(1, strWhereClause.IndexOf(")") - 1);
                    //string strParameter=strWhereClause.Substring(strWhereClause.IndexOf("@"),
                    Array.Resize(ref parameters, parameters.Length + 1);
                    parameters[parameters.Length - 1] = strParameter;
                    strWhereClause = strWhereClause.Substring(strParameter.Length + 1);
                    if (strWhereClause.StartsWith(")"))
                        strWhereClause = strWhereClause.Substring(1);
                } while (strWhereClause.Contains("@"));

                return parameters;
            }
            else
                return null;
        }

        public static DataSet RunQuery(string strTableName, string strQueryCommandKey, string strQueryCommand, params object[] paramValues)
        {
            DbCommand cmd = GetQuery(strTableName, strQueryCommandKey, strQueryCommand);
            string[] parameters = GetParameters(strQueryCommand);
            if (parameters != null)
            {
                for (int i = 0; i < parameters.Length; i++)
                {
                    if (paramValues[i].GetType().Equals(typeof(int)))
                        database.AddInParameter(cmd, parameters[i], SqlDbType.Int, paramValues[i]);
                    else if (paramValues[i].GetType().Equals(typeof(bool)))
                        database.AddInParameter(cmd, parameters[i], SqlDbType.Bit, paramValues[i]);
                    else if (paramValues[i].GetType().Equals(typeof(short)))
                        database.AddInParameter(cmd, parameters[i], SqlDbType.SmallInt, paramValues[i]);
                    else if (paramValues[i].GetType().Equals(typeof(double)))
                        database.AddInParameter(cmd, parameters[i], SqlDbType.Float, paramValues[i]);
                    else if (paramValues[i].GetType().Equals(typeof(decimal)))
                        database.AddInParameter(cmd, parameters[i], SqlDbType.Decimal, paramValues[i]);
                    else if (paramValues[i].GetType().Equals(typeof(String)) || paramValues[i].GetType().Equals(typeof(string)))
                        database.AddInParameter(cmd, parameters[i], SqlDbType.NVarChar, paramValues[i]);
                    else if (paramValues[i].GetType().Equals(typeof(DateTime)))
                        database.AddInParameter(cmd, parameters[i], SqlDbType.DateTime, paramValues[i]);
                    else if (paramValues[i].GetType().Equals(typeof(byte[])))
                        database.AddInParameter(cmd, parameters[i], SqlDbType.VarBinary, paramValues[i]);
                    else
                        continue;
                }
            }
            return (DataSet)RunQuery(cmd);
        }

        public static DataSet RunQuery(DbCommand cmd)
        {
            return database.ExecuteDataSet(cmd);
        }

        #endregion       
    }
}
