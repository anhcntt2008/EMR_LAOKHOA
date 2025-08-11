using BOSLib;
using Microsoft.Practices.EnterpriseLibrary.Data;
using Microsoft.Practices.EnterpriseLibrary.Data.Oracle;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Windows.Forms;
using Oracle.ManagedDataAccess.Client; // ODP.NET, Managed Driver
using Oracle.ManagedDataAccess.Types;
using BOSLib.DataAccess;
using BOSCommon;

namespace Clas.Emr.Intergration
{
    public class SqlHelper
    {
        private string _connectionString;
        private Database _database = null;
        private string _dbType = "MSSQL";
        private bool _lowerCase;

        public SqlHelper()
        {
            try
            {
                //Get from configuration file
                Crypto cryp = new Crypto();
                string serverName = cryp.DecryptNew(SystemMemCache.GetSystemConfigValue(SysCfgConsts.PRIVATE, SysCfgConsts.PRIVATE_HIS_DB_SERVER), true);
                string databaseName = cryp.DecryptNew(SystemMemCache.GetSystemConfigValue(SysCfgConsts.PRIVATE, SysCfgConsts.PRIVATE_HIS_DB_NAME), true);
                string userID = cryp.DecryptNew(SystemMemCache.GetSystemConfigValue(SysCfgConsts.PRIVATE, SysCfgConsts.PRIVATE_HIS_DB_USER), true);
                string password = cryp.DecryptNew(SystemMemCache.GetSystemConfigValue(SysCfgConsts.PRIVATE, SysCfgConsts.PRIVATE_HIS_DB_PASSWORD), true);
                _dbType = SystemMemCache.GetSystemConfigValue(SysCfgConsts.PRIVATE, SysCfgConsts.PRIVATE_HIS_DB_TYPE);
                _lowerCase = SystemMemCache.GetSystemConfigValue(SysCfgConsts.PRIVATE, SysCfgConsts.PRIVATE_HIS_DB_LOWERCASE) == "true";
                string port = SystemMemCache.GetSystemConfigValue(SysCfgConsts.PRIVATE, SysCfgConsts.PRIVATE_HIS_DB_PORT);
                if (_dbType == "ORA")
                {
                    string protocol = SystemMemCache.GetSystemConfigValue(SysCfgConsts.PRIVATE, SysCfgConsts.PRIVATE_HIS_DB_PROTOCOL);
                    _connectionString = string.Format("Data Source=(DESCRIPTION=(ADDRESS=(PROTOCOL={0})(HOST={1})(PORT={2}))(CONNECT_DATA=(SERVICE_NAME={3})));User Id={4};Password={5};"
                        , string.IsNullOrEmpty(protocol) ? "tcp" : protocol
                        , serverName
                        , string.IsNullOrEmpty(port) ? "1521" : port
                        , databaseName
                        , userID, password);
                    _database = new OracleDatabase(_connectionString);
                }
                else
                {
                    if (!string.IsNullOrEmpty(port))
                        port = "," + port;
                    _connectionString = string.Format("Data Source={0}{4};Initial Catalog={1};User ID={2};Password={3}", serverName, databaseName, userID, password, port);
                    _database = new SqlDatabase(_connectionString);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// uthv dung cho emr
        /// </summary>
        /// <param name="spName"></param>
        /// <param name="values"></param>
        /// <returns></returns>
        public DataSet RunSp(string spName, object[] values)
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
            if (_dbType == "ORA")
            {
                values = AddCursorParameter(spName, values);
            }
            return _database.ExecuteDataSet(spName, values);
        }

        private object[] AddCursorParameter(string spName, object[] values)
        {
            var count = _database.DiscoverStoreProcedureParameters(spName);
            var newParams = values.ToList();
            for (int i = 0; i < (count - values.Length); i++)
            {
                //don gian chi add them param null cho cursor
                newParams.Add(null);
            }
            return newParams.ToArray();
        }

        public object GetList(string spName, Dictionary<string, object> paramList)
        {
            try
            {
                var ds = RunSp(spName, paramList.Values.ToArray());
                var result = new List<Dictionary<string, object>>();
                if (ds.Tables.Count > 0)
                {
                    foreach (DataTable tb in ds.Tables)
                        if (tb.Rows.Count > 0)
                            //table khong chua cot param la table root
                            if (!tb.Columns.Contains("param"))
                            {
                                // neu ko chua cot type hay cot type = Item thi xem nhu la 1 item
                                if (!tb.Columns.Contains("type") || tb.Rows[0]["type"].ToString().ToLower() == "item")
                                {
                                    var row = tb.Rows[0];
                                    var obj = tb.Columns.Cast<DataColumn>().ToDictionary(c => _lowerCase ? c.ColumnName.ToLower() : c.ColumnName, c => row[c]);
                                    if (ds.Tables.Count > 1 && obj.ContainsKey("pkey"))
                                        obj = this.GetChildValue("root", obj["pkey"], ds, obj);
                                    return obj;
                                }
                                else
                                {
                                    var cols = tb.Columns.Cast<DataColumn>().Where(c => c.ColumnName.ToLower() != "type"
                                        && c.ColumnName.ToLower() != "pkey"
                                        && c.ColumnName.ToLower() != "fkey"
                                        && c.ColumnName.ToLower() != "param"
                                        && c.ColumnName.ToLower() != "parent").ToList();
                                    //truong hop du lieu can la array ko co column
                                    if (cols.Count == 1)
                                    {
                                        var col = cols.First();
                                        var obj = new Dictionary<string, object>();
                                        var arr = tb.Rows.Cast<DataRow>().Select(r => r[col]).ToArray();
                                        obj.Add(_lowerCase ? col.ColumnName.ToLower() : col.ColumnName, arr);
                                        return obj;
                                    }
                                    else
                                    {
                                        for (int i = 0; i < tb.Rows.Count; i++)
                                        {
                                            var row = tb.Rows[i] as DataRow;
                                            var value = tb.Columns.Cast<DataColumn>().ToDictionary(c => _lowerCase ? c.ColumnName.ToLower() : c.ColumnName, c => row[c]);
                                            if (ds.Tables.Count > 1 && value.ContainsKey("pkey"))
                                                value = this.GetChildValue("root", value["pkey"], ds, value);
                                            result.Add(value);
                                        }
                                    }
                                    return result;
                                }
                            }
                }
                Trace.TraceError("SQL ERROR: {0}:{1}", DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss"), "EMPTY DATA RETURN");
                return null;
            }
            catch (Exception ex)
            {
                Trace.TraceError("SQL ERROR: {0}:{1}", DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss"), ex);
                throw ex;
            }
        }
        private Dictionary<string, object> GetChildValue(string parent, object key, DataSet ds, Dictionary<string, object> value)
        {
            if (ds.Tables.Count > 0)
            {
                foreach (DataTable tb in ds.Tables)
                    if (tb.Rows.Count > 0)
                        if (tb.Columns.Contains("parent"))
                        {
                            if (parent == tb.Rows[0]["parent"].ToString().ToLower())
                            {
                                var param = tb.Rows[0]["param"].ToString();
                                // neu ko chua cot type hay cot type = Item thi xem nhu la 1 item
                                if (!tb.Columns.Contains("type") || tb.Rows[0]["type"].ToString().ToLower() == "item")
                                {
                                    var obj = new Dictionary<string, object>();
                                    for (int i = 0; i < tb.Rows.Count; i++)
                                    {
                                        var row = tb.Rows[i] as DataRow;
                                        if (row["fkey"].ToString() == key.ToString())
                                        {
                                            obj = row.Table.Columns.Cast<DataColumn>().ToDictionary(c => _lowerCase ? c.ColumnName.ToLower() : c.ColumnName, c => row[c]);
                                            obj = this.GetChildValue(param, row["pkey"], ds, obj);
                                            value.Add(param, obj);
                                            break;
                                        }
                                    }

                                }
                                else
                                {

                                    var cols = tb.Columns.Cast<DataColumn>().Where(c => c.ColumnName.ToLower() != "type"
                                        && c.ColumnName.ToLower() != "pkey"
                                        && c.ColumnName.ToLower() != "fkey"
                                        && c.ColumnName.ToLower() != "param"
                                        && c.ColumnName.ToLower() != "parent").ToList();
                                    //truong hop du lieu can la array ko co column
                                    if (cols.Count == 1)
                                    {
                                        var col = cols.First();
                                        var arr = tb.Rows.Cast<DataRow>().Select(r => r[col]).ToArray();
                                        value.Add(_lowerCase ? col.ColumnName.ToLower() : col.ColumnName, arr);
                                    }
                                    else
                                    {
                                        var set = new List<Dictionary<string, object>>();
                                        for (int i = 0; i < tb.Rows.Count; i++)
                                        {
                                            var row = tb.Rows[i] as DataRow;
                                            var obj = new Dictionary<string, object>();
                                            if (row["fkey"].ToString() == key.ToString())
                                            {
                                                obj = row.Table.Columns.Cast<DataColumn>().ToDictionary(c => _lowerCase ? c.ColumnName.ToLower() : c.ColumnName, c => row[c]);
                                                obj = this.GetChildValue(param, row["pkey"], ds, obj);
                                                set.Add(obj);
                                            }
                                        }
                                        value.Add(param, set);
                                    }
                                }
                            }
                        }
            }
            return value;
        }

        /// <summary>
        /// uthv
        /// return data from store canbe multiple table
        /// bat buoc:
        /// 1. Cac du lieu tra ve dang 1 dong phai co SELECT TOP 1
        /// 2. Cac du lieu dang danh sach phai tra ve phai them cot TableName = ParamName
        /// </summary>
        /// <param name="spName"></param>
        /// <param name="paramList"></param>
        /// <returns></returns>
        public List<Dictionary<string, object>> Get(string spName, Dictionary<string, object> paramList)
        {
            try
            {
                var ds = RunSp(spName, paramList.Values.ToArray());
                var result = new List<Dictionary<string, object>>();
                var rootNode = string.Empty;
                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        var tb = ds.Tables[0];
                        //get list data
                        var set = new Dictionary<string, object>();
                        for (int i = 0; i < tb.Rows.Count; i++)
                        {
                            var row = tb.Rows[i] as DataRow;
                            set = row.Table.Columns.Cast<DataColumn>().ToDictionary(c => _lowerCase ? c.ColumnName.ToLower() : c.ColumnName, c => row[c]);
                            result.Add(set);
                        }
                        return result;
                    }
                }
                Trace.TraceError("SQL ERROR: {0}:{1}", DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss"), "EMPTY DATA RETURN");
                return null;
            }
            catch (Exception ex)
            {
                Trace.TraceError("SQL ERROR: {0}:{1}", DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss"), ex);
                throw ex;
            }
        }
    }
}

