using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOSLib.DataAccess
{
    public static class SystemMemCache
    {
        public static DataTable GE_LOOKUP_TABLES { get; set; }
        public static DataTable INFORMATION_SCHEMA_TABLES { get; set; }
        public static DataTable INFORMATION_SCHEMA_COLUMNS { get; set; }
        public static DataTable INFORMATION_SCHEMA_KEY_COLUMN_USAGE { get; set; }
        public static List<STFieldFormatGroupsInfo> FieldFormatGroups { get; set; }
        public static Dictionary<string, List<STFieldFormatsInfo>> FieldFormats { get; set; }
        public static object FieldFormatsLock = new object();
        private static STFieldFormatsController _fieldFormatCtrl = new STFieldFormatsController();
        public static List<STFieldPermissionsInfo> FieldPermissions { get; set; }
        public static DataTable STToolbars { get; set; }

        public static Dictionary<string, Dictionary<string, string>> SysConfigs { get; set; }

        public static DataTable STFields { get; set; }

        public static DataTable STFieldColumns { get; set; }

        public static void Init()
        {
            Task.Run(() =>
            {
                if (SystemMemCache.FieldFormatGroups == null)
                    SystemMemCache.FieldFormatGroups = (new STFieldFormatGroupsController()).GetAll();
            });

            SystemMemCache.FieldFormats = new Dictionary<string, List<STFieldFormatsInfo>>();
            Task.Run(() =>
            {
                if (SystemMemCache.FieldFormatGroups == null)
                    SystemMemCache.FieldFormatGroups = (new STFieldFormatGroupsController()).GetAll();
            });
            Task.Run(() =>
            {
                if (SystemMemCache.FieldPermissions == null)
                    SystemMemCache.FieldPermissions = (new BOSERP.STFieldPermissionsController()).GetAll();
            });
            Task.Run(() =>
            {
                if (SystemMemCache.STToolbars == null)
                    SystemMemCache.STToolbars = (new STToolbarsController()).GetAllObjects().Tables[0];
            });
            Task.Run(() => (new BOSDbUtil()).GetTableForeignKeysFromDb());
            Task.Run(() =>
            {
                if (SystemMemCache.STFields == null)
                    SystemMemCache.STFields = (new STFieldsController()).GetFields().Tables[0];
            });

            Task.Run(() =>
            {
                if (SystemMemCache.STFieldColumns == null)
                    SystemMemCache.STFieldColumns = (new STFieldColumnsController()).GetFieldColumns().Tables[0];
            });
        }
        internal static List<STFieldFormatsInfo> GetFieldFormats(string tableName)
        {
            if (SystemMemCache.FieldFormats.TryGetValue(tableName, out List<STFieldFormatsInfo> list))
                return list;
            list = _fieldFormatCtrl.GetListBusinessObjects<STFieldFormatsInfo>(_fieldFormatCtrl.GetDataSet("STFieldFormats_GetByTableName", tableName));
            lock (FieldFormatsLock)
            {
                if (!SystemMemCache.FieldFormats.ContainsKey(tableName))
                    SystemMemCache.FieldFormats.Add(tableName, list);
            }
            return list;
        }
        public static string GetSystemConfigValue(string group, string key)
        {
            if (!SystemMemCache.SysConfigs.TryGetValue(group, out Dictionary<string, string> configs))
                return string.Empty;
            if (!configs.TryGetValue(key, out string config))
                return string.Empty;
            return config;
        }
        public static string GetSystemConfigInitValue(string group, string key, string initSt)
        {
            if (!SystemMemCache.SysConfigs.TryGetValue(group, out Dictionary<string, string> configs))
                return initSt;
            if (!configs.TryGetValue(key, out string config))
                return initSt;
            return config;
        }
    }
}
