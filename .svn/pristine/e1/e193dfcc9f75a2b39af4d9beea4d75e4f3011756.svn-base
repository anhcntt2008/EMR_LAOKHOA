using System;
using System.Data;
using System.Linq;
using Microsoft.Practices.EnterpriseLibrary.Data;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using BOSLib.DataAccess;
using System.Globalization;
using System.IO;
using System.Windows.Forms;

namespace BOSLib
{
    public class BOSDbUtil : BaseBusinessController
    {
        public BOSDbUtil()
        {
            dal = new DALBaseProvider();
        }

        public bool IsExistTable(string strTableName)
        {
            var isExist = false;
            var strQuery = $"TABLE_NAME = '{strTableName}'";
            var ds = SqlDatabaseHelper.GetSchemaTableFromMemoryCache(strQuery);
            if (ds.Tables.Count > 0)
                if (ds.Tables[0].Rows.Count > 0)
                    isExist = true;

            return isExist;
        }

        public DataColumnCollection GetDataColumnCollectionFromDataSet(DataSet ds)
        {
            var table = new DataTable();
            if (ds.Tables.Count <= 0) return table.Columns;
            foreach (DataRow row in ds.Tables[0].Rows)
            {
                var column = new DataColumn();
                column.ColumnName = row["COLUMN_NAME"].ToString();
                column.AllowDBNull = row["IS_NULLABLE"].ToString() == "YES";
                table.Columns.Add(column);
            }
            return table.Columns;
        }


        public DataSet GetNotAllowNullTableColumns(string strTableName)
        {
            return SqlDatabaseHelper.GetSchemaColumnFromMemoryCache($"TABLE_NAME = '{strTableName}'  AND IS_NULLABLE = 'NO' AND COLUMN_DEFAULT IS NULL");
        }

        public DataSet GetTableColumn(string strTableName, string strColumnName)
        {
            return SqlDatabaseHelper.GetSchemaColumnFromMemoryCache($"TABLE_NAME = '{strTableName}' AND COLUMN_NAME = '{strColumnName}'");
        }
        public bool ColumnIsExist(string strTableName, string strColumnName)
        {
            var dsColumn = GetTableColumn(strTableName, strColumnName);
            if (dsColumn.Tables.Count <= 0) return false;
            return dsColumn.Tables[0].Rows.Count > 0;
        }

        public string GetColumnDbType(string strTableName, string strColumnName)
        {
            var strColumnDbType = string.Empty;
            var dsColumn = GetTableColumn(strTableName, strColumnName);
            if (dsColumn.Tables.Count <= 0) return strColumnDbType;
            if (dsColumn.Tables[0].Rows.Count <= 0) return strColumnDbType;
            strColumnDbType = dsColumn.Tables[0].Rows[0]["DATA_TYPE"].ToString();
            if (strColumnDbType == "varchar" || strColumnDbType == "nvarchar" || strColumnDbType == "varbinary")
                strColumnDbType += "(" + dsColumn.Tables[0].Rows[0]["CHARACTER_MAXIMUM_LENGTH"] + ")";
            return strColumnDbType;
        }

        public string GetColumnDataType(string strTableName, string strColumnName)
        {
            var strColumnDataType = string.Empty;
            var dsColumn = GetTableColumn(strTableName, strColumnName);
            if (dsColumn.Tables.Count <= 0) return strColumnDataType;
            if (dsColumn.Tables[0].Rows.Count > 0)
                strColumnDataType = dsColumn.Tables[0].Rows[0]["DATA_TYPE"].ToString();
            return strColumnDataType;
        }

        public bool ColumnIsAllowNull(string strTableName, string strColumnName)
        {
            if (!SqlDatabaseHelper.NotNullTableColumns.ContainsKey(strTableName))
            {
                var ds = GetNotAllowNullTableColumns(strTableName);
                var columnCollection = GetDataColumnCollectionFromDataSet(ds);
                SqlDatabaseHelper.NotNullTableColumns.Add(strTableName, columnCollection);
            }
            if (!SqlDatabaseHelper.NotNullTableColumns[strTableName].Contains(strColumnName)) return true;
            var column = SqlDatabaseHelper.NotNullTableColumns[strTableName][strColumnName];
            return column.AllowDBNull;
        }

        public void GetTableForeignKeysFromDb()
        {
            if (SystemMemCache.INFORMATION_SCHEMA_KEY_COLUMN_USAGE == null)
            {
                var strQuery = "SELECT kcu.*, tc.CONSTRAINT_TYPE as TABLE_CONSTRAINTS_CONSTRAINT_TYPE FROM INFORMATION_SCHEMA.KEY_COLUMN_USAGE kcu, INFORMATION_SCHEMA.TABLE_CONSTRAINTS tc WHERE kcu.CONSTRAINT_NAME = tc.CONSTRAINT_NAME";
                SystemMemCache.INFORMATION_SCHEMA_KEY_COLUMN_USAGE = dal.GetDataSet(strQuery).Tables[0];
            }
        }
        public DataSet GetTableForeignKeys(string strTableName)
        {
            //var strQuery =
            //    $"SELECT kcu.* FROM INFORMATION_SCHEMA.KEY_COLUMN_USAGE kcu, INFORMATION_SCHEMA.TABLE_CONSTRAINTS tc WHERE kcu.TABLE_NAME = '{strTableName}' AND kcu.CONSTRAINT_NAME = tc.CONSTRAINT_NAME AND tc.CONSTRAINT_TYPE = 'FOREIGN KEY'";
            //return dal.GetDataSet(strQuery);
            GetTableForeignKeysFromDb();
            var ds = new DataSet();
            var tb = SystemMemCache.INFORMATION_SCHEMA_KEY_COLUMN_USAGE.Clone();
            ds.Tables.Add(tb);

            var rows = SystemMemCache.INFORMATION_SCHEMA_KEY_COLUMN_USAGE.Select($"TABLE_NAME = '{strTableName}'  AND TABLE_CONSTRAINTS_CONSTRAINT_TYPE = 'FOREIGN KEY'").ToList();
            foreach (var row in rows)
            {
                tb.ImportRow(row);
            }
            return ds;

        }

        public DataSet GetTablePrimaryKeys(string strTableName)
        {
            var strQuery =
                $"SELECT kcu.* FROM INFORMATION_SCHEMA.KEY_COLUMN_USAGE kcu, INFORMATION_SCHEMA.TABLE_CONSTRAINTS tc WHERE kcu.TABLE_NAME = '{strTableName}' AND kcu.CONSTRAINT_NAME = tc.CONSTRAINT_NAME AND tc.CONSTRAINT_TYPE = 'PRIMARY KEY'";
            return dal.GetDataSet(strQuery);
        }

        public string GetTablePrimaryColumn(string strTableName)
        {
            var strPrimaryColumn = string.Empty;

            if (SqlDatabaseHelper.PrimaryColumnsList[strTableName] != null)
            {
                strPrimaryColumn = SqlDatabaseHelper.PrimaryColumnsList[strTableName].ToString();
            }
            else
            {
                var ds = GetTablePrimaryKeys(strTableName);
                if (ds.Tables.Count <= 0) return strPrimaryColumn;
                if (ds.Tables[0].Rows.Count > 0)
                    strPrimaryColumn = ds.Tables[0].Rows[0]["COLUMN_NAME"].ToString();
            }
            return strPrimaryColumn;
        }

        public bool IsForeignKey(string strTableName, string strColumnName)
        {
            if (strColumnName.Contains("FK_"))
                return true;
            GetTableForeignKeysFromDb();
            var has = SystemMemCache.INFORMATION_SCHEMA_KEY_COLUMN_USAGE.Select($"TABLE_NAME = '{strTableName}' AND COLUMN_NAME = '{strColumnName}'  AND TABLE_CONSTRAINTS_CONSTRAINT_TYPE = 'FOREIGN KEY'").Any();
            //Console.WriteLine(strColumnName + ":" + has);
            return has;
        }

        public bool IsPrimaryKey(string strTableName, string strColumnName)
        {
            var strPrimaryKey = GetTablePrimaryColumn(strTableName);
            return strPrimaryKey == strColumnName;
        }

        public void AddForeignTableColumns(string strForeignTableName)
        {
            if (!SqlDatabaseHelper.ForeignTableColumns.ContainsKey(strForeignTableName))
            {
                var ds = dal.GetDataSet("GEDBUtil_GetPrimaryColumnsByForeignTableName", strForeignTableName);
                var table = new DataTable();
                if (ds.Tables.Count > 0)
                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                        var column = new DataColumn();
                        column.ColumnName = row["ForeignColumnName"].ToString();
                        column.ExtendedProperties.Add("PrimaryTableName", row["PrimaryTableName"].ToString());
                        column.ExtendedProperties.Add("PrimaryColumnName", row["PrimaryColumnName"].ToString());
                        if (table.Columns.IndexOf(column.ColumnName) < 0)
                            table.Columns.Add(column);
                    }
                SqlDatabaseHelper.ForeignTableColumns.TryAdd(strForeignTableName, table.Columns);
            }
        }

        public string GetPrimaryTableWhichForeignColumnReferenceTo(string strForeignTableName,
            string strForeignColumnName)
        {
            AddForeignTableColumns(strForeignTableName);

            var strPrimaryTableName = string.Empty;
            if (!SqlDatabaseHelper.ForeignTableColumns[strForeignTableName].Contains(strForeignColumnName))
                return strPrimaryTableName;
            {
                var column = SqlDatabaseHelper.ForeignTableColumns[strForeignTableName][strForeignColumnName];
                strPrimaryTableName = column.ExtendedProperties["PrimaryTableName"].ToString();
            }
            return strPrimaryTableName;
        }

        public DataSet ExecuteQuery(string strQuery)
        {
            var cmd = SqlDatabaseHelper.GetQuery(strQuery);
            return SqlDatabaseHelper.RunQuery(cmd);
        }

        public void SetPropertyValue(BusinessObject obj, string strPropertyName, object value)
        {
            var property = obj.GetType().GetProperty(strPropertyName);
            if (property != null && property.CanWrite)
                property?.SetValue(obj, value, null);
        }

        public void SetPropertyValue(object obj, string strPropertyName, object value)
        {
            var property = obj.GetType().GetProperty(strPropertyName);
            property?.SetValue(obj, value, null);
        }

        public object GetPropertyValue(BusinessObject obj, string strPropertyName)
        {
            var objType = obj.GetType();
            var property = objType.GetProperty(strPropertyName);

            return property?.GetValue(obj, null);
        }

        public object GetPropertyValue(object obj, string strPropertyName)
        {
            var objType = obj.GetType();
            var property = objType.GetProperty(strPropertyName);
            return property?.GetValue(obj, null);
        }

        public string GetPropertyStringValue(object obj, string strPropertyName)
        {
            var objValue = GetPropertyValue(obj, strPropertyName);
            return objValue?.ToString() ?? string.Empty;
        }

        public int GetPropertyIntValue(object obj, string strPropertyName)
        {
            var objValue = GetPropertyValue(obj, strPropertyName);
            return objValue != null ? Convert.ToInt32(objValue) : 0;
        }

        public string GetStoredProcedureTextByStoredProcedureName(string strStoredProcedureName)
        {
            var strStoredProceduretext = string.Empty;
            var strQuery =
                $"SELECT sc.* FROM syscomments sc, sysobjects so WHERE sc.id = so.id AND so.name = '{strStoredProcedureName}' AND so.type = 'P'";
            var dsStoredProcedureText = dal.GetDataSet(strQuery);
            if (dsStoredProcedureText.Tables.Count > 0)
                strStoredProceduretext = dsStoredProcedureText.Tables[0].Rows.Cast<DataRow>().Aggregate(strStoredProceduretext, (current, rowStoredProcedureText) => current + rowStoredProcedureText["text"].ToString());
            return strStoredProceduretext;
        }


        public void ExecuteNonQuery(string spName, params object[] values)
        {
            SqlDatabaseHelper.ExecuteNonQuery(spName, values);
        }

        public void ExecuteNonQuery(Database database, string spName, params object[] values)
        {
            SqlDatabaseHelper.ExecuteNonQuery(database, spName, values);
        }

        public DataSet GetViewColumn(string strViewName, string strColumnName)
        {
            var strQuery =
                $"SELECT * FROM INFORMATION_SCHEMA.VIEW_COLUMN_USAGE WHERE VIEW_NAME = '{strViewName}' AND COLUMN_NAME = '{strColumnName}'";
            return dal.GetDataSet(strQuery);
        }


        /// <summary>
        ///     Get table name by its column's name
        /// </summary>
        /// <param name="columnName">Column name</param>
        /// <returns>Table name</returns>
        public string GetTableNameByColumnName(string columnName)
        {
            var query = $"COLUMN_NAME = '{columnName}'";
            var ds = SqlDatabaseHelper.GetSchemaColumnFromMemoryCache(query);
            if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                return Convert.ToString(ds.Tables[0].Rows[0]["TABLE_NAME"]);
            return string.Empty;

            //var query = $"SELECT * FROM INFORMATION_SCHEMA.COLUMNS WHERE COLUMN_NAME = '{columnName}'";
            //var ds = dal.GetDataSet(query);
            //if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            //    return Convert.ToString(ds.Tables[0].Rows[0]["TABLE_NAME"]);
            //return string.Empty;
        }

        public DateTime GetLastCreatedDateOfTable(string strTableName)
        {
            try
            {
                var dtLastCreatedDate = DateTime.MinValue;
                const string strAaCreatedDateColumn = "AACreatedDate";
                if (!ColumnIsExist(strTableName, strAaCreatedDateColumn)) return dtLastCreatedDate;
                var strQuery =
                    string.Format("Select MAX([{0}]) From [{1}] Where DATEDIFF(d, [{0}], '9999-12-31') > 0",
                        strAaCreatedDateColumn, strTableName);
                var cmd = SqlDatabaseHelper.GetQuery(strQuery);
                var ds = SqlDatabaseHelper.RunQuery(cmd);
                if (ds.Tables.Count <= 0) return dtLastCreatedDate;
                if (ds.Tables[0].Rows.Count > 0)
                    dtLastCreatedDate = Convert.ToDateTime(ds.Tables[0].Rows[0][0]);

                return dtLastCreatedDate;
            }
            catch (Exception)
            {
                return DateTime.MinValue;
            }
        }

        public DateTime GetLastUpdatedDateOfTable(string strTableName)
        {
            try
            {
                var dtLastUpdatedDate = DateTime.MinValue;
                const string strAaUpdatedDate = "AAUpdatedDate";
                if (!ColumnIsExist(strTableName, strAaUpdatedDate)) return dtLastUpdatedDate;
                var strQuery =
                    string.Format("Select MAX([{0}]) From [{1}] Where DATEDIFF(d, [{0}], '9999-12-31') > 0",
                        strAaUpdatedDate, strTableName);
                var cmd = SqlDatabaseHelper.GetQuery(strQuery);
                var ds = SqlDatabaseHelper.RunQuery(cmd);
                if (ds.Tables.Count <= 0) return dtLastUpdatedDate;
                if (ds.Tables[0].Rows.Count > 0)
                    dtLastUpdatedDate = Convert.ToDateTime(ds.Tables[0].Rows[0][0]);

                return dtLastUpdatedDate;
            }
            catch (Exception)
            {
                return DateTime.MinValue;
            }
        }

        public DateTime GetDateMofifyOfTable(string strTableName)
        {
            try
            {
                return Convert.ToDateTime(dal.GetSingleValue("GetDateMofifyOfTable", strTableName), CultureInfo.InvariantCulture);
            }
            catch (InvalidOperationException ex)
            {
                //ERROR: The Stored Procedure Doesn't Exist
                throw ex;
            }
            catch (Exception)
            {
                return DateTime.MinValue;
            }
        }

        public DateTime GetDateMofifyOfTableByMaxId(string strTableName, int maxId)
        {
            try
            {
                return Convert.ToDateTime(dal.GetSingleValue("GetDateMofifyOfTableByMaxId", strTableName, SqlDatabaseHelper.GetPrimaryKeyColumn(strTableName), maxId), CultureInfo.InvariantCulture);
            }
            catch (InvalidOperationException ex)
            {
                //ERROR: The Stored Procedure Doesn't Exist
                throw ex;
            }
            catch (Exception)
            {
                return DateTime.MinValue;
            }
        }

        public DateTime GetDateMofifyOfTableByMaxId(string strTableName, string primaryKey, int maxId)
        {
            try
            {
                return Convert.ToDateTime(dal.GetSingleValue("GetDateMofifyOfTableByMaxId", strTableName, primaryKey, maxId), CultureInfo.InvariantCulture);
            }
            catch (InvalidOperationException ex)
            {
                //ERROR: The Stored Procedure Doesn't Exist
                throw ex;
            }
            catch (Exception)
            {
                return DateTime.MinValue;
            }
        }

        public DataSet GetDataSet(Database database, string spName, params object[] values)
        {
            return SqlDatabaseHelper.RunStoredProcedure((SqlDatabase)database, spName, values);
        }

        /// <summary>
        ///     Get the current date time of the server
        /// </summary>
        /// <returns>Current date time</returns>
        public DateTime GetCurrentServerDate()
        {
            return Convert.ToDateTime(dal.GetSingleValue("GetCurrentServerDate"));
        }

        public string DetectDevide()
        {
            // read cfg file
            var devideConfig = Path.Combine(Application.StartupPath, "device_type.cfg");
            if (!File.Exists(devideConfig))
            {
                using (StreamWriter w = new StreamWriter(devideConfig, false))
                {
                    w.WriteLine($"devide:Desktop");
                    return "Desktop";
                }
            }
            else
            {
                using (StreamReader r = new StreamReader(devideConfig))
                {
                    var firstLine = r.ReadLine() ?? $"devide:Desktop";
                    return firstLine.Split(':')[1];
                }
            }
        }

    }
}