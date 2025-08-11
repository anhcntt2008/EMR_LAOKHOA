using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Clas.Emr.Intergration
{
    /// <summary>
    /// uthv 12/10/2017
    /// This is the pool where action will get value of it param before send to HIS app or call api
    /// </summary>
    public class ParamPool
    {
        private IDictionary<string, object> _pool;
        public ParamPool() : base()
        {
            _pool = new Dictionary<string, object>();
        }
        /// <summary>
        /// uthv
        /// parse object to dictionary and add to pool
        /// </summary>
        /// <param name="data"></param>
        public void AddFromObject(object data,
            BindingFlags bindingAttr = BindingFlags.DeclaredOnly | BindingFlags.Public | BindingFlags.Instance)
        {
            var values = data.GetType().GetProperties(bindingAttr).ToDictionary
             (
                 propInfo => propInfo.Name,
                 propInfo => propInfo.GetValue(data, null)
             );
            foreach (var item in values)
            {
                this.AddOrUpdate(item);
            }
        }
        public void AddFromDataRow(DataRow row)
        {
            if (row == null) return;
            var values = row.Table.Columns
              .Cast<DataColumn>()
              .ToDictionary(c => c.ColumnName, c => row[c]);
            foreach (var item in values)
            {
                this.AddOrUpdate(item);
            }
        }
        public object this[string key]
        {
            get
            {
                if (_pool.ContainsKey(key))
                    return _pool[key];
                return null;
            }

            set
            {
                if (_pool.ContainsKey(key))
                    _pool[key] = value;
                _pool.Add(key, value);
            }
        }

        public void AddOrUpdate(KeyValuePair<string, object> item)
        {
            if (_pool.ContainsKey(item.Key))
            {
                _pool[item.Key] = item.Value;
            }
            else
            {
                _pool.Add(item);
            }
        }
        /// <summary>
        /// auto parse str param like param1={MEPatientName}
        /// get param value
        /// </summary>
        /// <param name="strParam"></param>
        /// <returns></returns>
        public Dictionary<string, object> GetActionParam(string strParam)
        {
            var query = new Dictionary<string, object>();
            if (string.IsNullOrEmpty(strParam)) return query;
            var parames = strParam.Split('|');
            if (parames.Length > 0)
            {
                foreach (var p in parames)
                {
                    var tokens = p.Split('=');
                    if (tokens.Length == 2)
                    {
                        var poolName = tokens[1].TrimStart('{').TrimEnd('}');
                        if (_pool.ContainsKey(poolName))
                            query.Add(tokens[0].Trim(), this[poolName]);
                        else
                            query.Add(tokens[0].Trim(), poolName);
                    }

                }
            }
            return query;
        }
        public List<KeyValuePair<string, object>> ToList()
        {
            return _pool.ToList();
        }
    }
}
