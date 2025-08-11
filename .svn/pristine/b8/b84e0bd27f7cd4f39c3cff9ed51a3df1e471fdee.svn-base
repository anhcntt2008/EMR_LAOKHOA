using System;
using System.Data.Common;
using System.Collections;
using System.Reflection;
using System.Data;
using System.Data.OleDb;
using System.Text;
using System.Security;
using System.Security.Cryptography;
using System.Windows.Forms;

using MySql.Data;
using MySql.Data.MySqlClient;

using Microsoft.Practices.EnterpriseLibrary.Data;
using Microsoft.Practices.EnterpriseLibrary.Data.MySql;
using Microsoft.Practices.EnterpriseLibrary.Data.Configuration;
using Microsoft.Practices.EnterpriseLibrary.Configuration;


namespace WIFASLib
{
    public class MySqlDatabaseHelper
    {
        private static MySqlDatabase database = null;

        #region "Constructor"
        static MySqlDatabaseHelper()
        {
            try
            {
                database = (MySqlDatabase)DatabaseFactory.CreateDatabase();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        #endregion

        #region "Get Object Functions"
        public static object GetSingleObject(DataTable dt, Type type)
        {
            if (dt.Rows.Count <= 0)
                return null;
            System.Reflection.PropertyInfo[] properties = type.GetProperties();
            object obj = GetObjectFromDataRow(dt.Rows[0], type);
            return obj;
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
        public static string GetPrimaryKeyColumn(string strTableName)
        {
            DataSet ds = database.ExecuteDataSet("GEDBUtil_SelectTablePrimaryKeys", strTableName);
            if (ds.Tables.Count > 0)
            {
                if (ds.Tables[0].Rows.Count > 0)
                    return ds.Tables[0].Rows[0]["COLUMN_NAME"].ToString();
            }
            return string.Empty;
        }

        public static DataSet GetAllTableColumns(string strTableName)
        {
            return (DataSet)database.ExecuteDataSet("GEDBUtil_SelectTableColumns", strTableName);
        }

        public static bool ColumnIsExistInTable(string strTableName, string strColumnName)
        {
            DataSet ds = database.ExecuteDataSet("GEDBUtil_SelectTableColumn", strTableName, strColumnName);
            if (ds.Tables.Count > 0)
            {
                if (ds.Tables[0].Rows.Count > 0)
                    return true;
            }
            return false;
        }

        public static bool ColumnIsForeignKey(string strTableName, string strColumnName)
        {
            DataSet ds = database.ExecuteDataSet("GEDBUtil_SelectTableForeignKey", strTableName, strColumnName);
            if (ds.Tables.Count > 0)
            {
                if (ds.Tables[0].Rows.Count > 0)
                    return true;
            }

            return false;
        }

        public static bool IsColumnAllowNull(string strTableName, string strColumnName)
        {
            DataSet ds = database.ExecuteDataSet("GEDBUtil_SelectTableColumn", strTableName, strColumnName);
            if (ds.Tables.Count > 0)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    if (ds.Tables[0].Rows[0]["IS_NULLABLE"].ToString() == "YES")
                        return true;
                    else
                        return false;
                }
            }
            return true;
        }

        public static bool ColumnIsPrimaryKey(string strTableName, string strColumnName)
        {
            DataSet ds = database.ExecuteDataSet("GEDBUtil_SelectTablePrimaryKey", strColumnName);
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
        public static int GetMaxID(string tableName)
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

        public static void AddInParameter(DbCommand cmd, string name, MySqlDbType type, Object objValue)
        {
            database.AddInParameter(cmd, name, type, objValue);
        }

        public static void AddParameterForObject(object obj, DALBaseProvider provider, DbCommand cmd)
        {
            try
            {
                System.Reflection.PropertyInfo[] properties = provider.ObjectType.GetProperties();
                for (int i = 0; i < properties.Length; i++)
                {
                    //Add property exist in Table
                    if (ColumnIsExistInTable(provider.TableName, properties[i].Name))
                    {
                        object objValue = properties[i].GetValue(obj, null);
                        if (properties[i].PropertyType.Equals(typeof(Int32)))
                        {
                            //If property Name is Foreign Key,if allow null,set parameter null in case of value=0
                            if (ColumnIsForeignKey(provider.TableName, properties[i].Name))
                            {
                                if (Convert.ToInt32(objValue) == 0)
                                {
                                    if (IsColumnAllowNull(provider.TableName, properties[i].Name))
                                        database.AddInParameter(cmd, properties[i].Name, MySqlDbType.Int32, null);
                                    else
                                        database.AddInParameter(cmd, properties[i].Name, MySqlDbType.Int32, objValue);
                                }
                                else
                                    database.AddInParameter(cmd, properties[i].Name, MySqlDbType.Int32, objValue);
                            }
                            else
                            {
                                database.AddInParameter(cmd, properties[i].Name, MySqlDbType.Int32, objValue);
                            }

                        }
                        else if (properties[i].PropertyType.Equals(typeof(Boolean)))
                            database.AddInParameter(cmd, properties[i].Name, MySqlDbType.Bit, objValue);
                        else if (properties[i].PropertyType.Equals(typeof(short)))
                            database.AddInParameter(cmd, properties[i].Name, MySqlDbType.Int16, objValue);
                        else if (properties[i].PropertyType.Equals(typeof(double)))
                            database.AddInParameter(cmd, properties[i].Name, MySqlDbType.Float, objValue);
                        else if (properties[i].PropertyType.Equals(typeof(decimal)))
                            database.AddInParameter(cmd, properties[i].Name, MySqlDbType.Decimal, objValue);
                        else if ((properties[i].PropertyType.Equals(typeof(String))) || (properties[i].PropertyType.Equals(typeof(string))))
                            database.AddInParameter(cmd, properties[i].Name, MySqlDbType.VarChar, objValue);
                        else if (properties[i].PropertyType.Equals(typeof(DateTime)))
                        {
                            if ((DateTime)objValue == DateTime.MinValue)
                                continue;
                            database.AddInParameter(cmd, properties[i].Name, MySqlDbType.Datetime, objValue);
                        }
                        else if (properties[i].PropertyType.Equals(typeof(byte[])))
                        {
                            database.AddInParameter(cmd, properties[i].Name, MySqlDbType.Blob, objValue);
                        }
                        else
                            continue;

                    }

                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Source + e.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                    database.AddInParameter(cmd, strParamName, MySqlDbType.Int32, objValue);
                }
                else
                {
                    database.AddInParameter(cmd, strParamName, MySqlDbType.VarChar, objValue);
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
                MessageBox.Show(e.Source + e.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return 0;
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
            catch (MySqlException exp)
            {
                MessageBox.Show(exp.Message);
                return null;
            }
        }

        public static DataSet RunStoredProcedure(string spName, params object[] values)
        {
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

        public static string ExecuteStoredProcedureScript(String strStoredProcedureScript)
        {
            try
            {
                database.ExecuteNonQuery(CommandType.Text, strStoredProcedureScript);
                return "Command excute succesfully!";
            }
            catch (Exception e)
            {
                return e.Message;
            }
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
                        database.AddInParameter(cmd, parameters[i], MySqlDbType.Int32, paramValues[i]);
                    else if (paramValues[i].GetType().Equals(typeof(bool)))
                        database.AddInParameter(cmd, parameters[i], MySqlDbType.Bit, paramValues[i]);
                    else if (paramValues[i].GetType().Equals(typeof(short)))
                        database.AddInParameter(cmd, parameters[i], MySqlDbType.Int16, paramValues[i]);
                    else if (paramValues[i].GetType().Equals(typeof(double)))
                        database.AddInParameter(cmd, parameters[i], MySqlDbType.Float, paramValues[i]);
                    else if (paramValues[i].GetType().Equals(typeof(decimal)))
                        database.AddInParameter(cmd, parameters[i], MySqlDbType.Decimal, paramValues[i]);
                    else if (paramValues[i].GetType().Equals(typeof(String)) || paramValues[i].GetType().Equals(typeof(string)))
                        database.AddInParameter(cmd, parameters[i], MySqlDbType.VarChar, paramValues[i]);
                    else if (paramValues[i].GetType().Equals(typeof(DateTime)))
                        database.AddInParameter(cmd, parameters[i], MySqlDbType.Datetime, paramValues[i]);
                    else if (paramValues[i].GetType().Equals(typeof(byte[])))
                        database.AddInParameter(cmd, parameters[i], MySqlDbType.Blob, paramValues[i]);
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
