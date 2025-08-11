using BOSCommon;
using BOSLib;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOSERP
{
    public static class AppMemCache
    {
        private static METemplateParamsController _templateParamsCtrl { get; set; }
        private static MEParamsController _paramCtrl { get; set; }
        private static MEParamRelationsController _paramRelationCtrl { get; set; }
        private static METemplateIndexsController _templateIndexCtrl { get; set; }
        private static MEEmrTypeTemplatesController _emrTypeTemplateCtrl { get; set; }
        private static MEEmrActionParamsController _actionParamsCtrl { get; set; }

        public static bool UseAppMemCache = true;

        public static List<GENumberingInfo> GENumberings { get; set; }

        private static List<MEParamsInfo> _params { get; set; }
        private static ConcurrentDictionary<int, MEParamsInfo> _paramsDictByID { get; set; }
        private static ConcurrentDictionary<string, MEParamsInfo> _paramsDictByNo { get; set; }
        private static ConcurrentDictionary<int, List<MEParamRelationsInfo>> _paramRelationDict { get; set; }
        private static ConcurrentDictionary<string, METemplateIndexsInfo> _templateIndexsDictKeyName { get; set; }
        private static List<METemplateIndexsInfo> _templateIndexs { get; set; }
        private static List<MEEmrTypeTemplatesInfo> _emrTypeTemplates { get; set; }
        private static Dictionary<string, JToken> _actionDataCache { get; set; }
        private static Dictionary<string, DateTime> _actionDataCacheTime { get; set; }
        private static ConcurrentDictionary<int, ConcurrentDictionary<string, METemplateParamsInfo>> _templateParamsDictByPath { get; set; }
        private static ConcurrentDictionary<int, List<METemplateParamsInfo>> _templateParamsDict { get; set; }
        private static string _connectionString { get; set; }
        private static ConcurrentDictionary<string, MEParamsInfo> _hiddenParamsDictByNo { get; set; }
        private static ConcurrentDictionary<int, List<MEEmrTypeTemplatesInfo>> _emrTypeTemplatesDict;
        private static ConcurrentDictionary<int, List<MEEmrActionParamsInfo>> _actionParamsDict;

        public static void Init()
        {
            _actionDataCache = new Dictionary<string, JToken>();
            _actionDataCacheTime = new Dictionary<string, DateTime>();
            _templateParamsDictByPath = new ConcurrentDictionary<int, ConcurrentDictionary<string, METemplateParamsInfo>>();
            _templateParamsDict = new ConcurrentDictionary<int, List<METemplateParamsInfo>>();
            _templateParamsCtrl = new METemplateParamsController();
            _paramCtrl = new MEParamsController();
            _paramRelationCtrl = new MEParamRelationsController();
            _templateIndexCtrl = new METemplateIndexsController();
            _emrTypeTemplateCtrl = new MEEmrTypeTemplatesController();
            _actionParamsCtrl = new MEEmrActionParamsController();
            if (!UseAppMemCache) return;

            Task.Run(() =>
            {
                if (GENumberings == null)
                    GENumberings = (new GENumberingController()).GetAll();
            });
        }
        public static void Clear()
        {
            _actionDataCache.Clear();
            _actionDataCacheTime.Clear();
            _templateParamsDictByPath.Clear();
            _templateParamsDictByPath = null;
            if (!UseAppMemCache) return;

            GENumberings.Clear();
            GENumberings = null;
            _params.Clear();
            _params = null;
            _paramsDictByID.Clear();
            _paramsDictByID = null;
            _paramsDictByNo.Clear();
            _paramsDictByNo = null;
            _paramRelationDict.Clear();
            _paramRelationDict = null;
            _templateIndexsDictKeyName.Clear();
            _templateIndexsDictKeyName = null;
            _templateIndexs.Clear();
            _templateIndexs = null;
            _emrTypeTemplates.Clear();
            _emrTypeTemplates = null;
            _hiddenParamsDictByNo.Clear();
            _hiddenParamsDictByNo = null;
            _emrTypeTemplatesDict.Clear();
            _emrTypeTemplatesDict = null;
            _actionParamsDict.Clear();
            _actionParamsDict = null;
        }
        public static void InitEmrModuleSessionAsync()
        {
            if (!UseAppMemCache) return;

            Task.Run(() =>
            {
                GetParams();
                Task.Run(() => GetParamsDictKeyID());
                Task.Run(() => GetParamsDictKeyNo());
                Task.Run(() => GetHiddenParamsDictKeyNo());
            });
            Task.Run(() => GetParamRelationsDict());
            Task.Run(() =>
            {
                GetTemplateIndexs();
                Task.Run(() => GetTemplateIndexsDictKeyName());
            });
            Task.Run(() =>
            {
                GetEmrTypeTemplates();
                Task.Run(() => GetEmrTypeTemplatesDict());
            });
            Task.Run(() => GetActionParamsDict());

        }
        public static void InitDocumentSession(int templateId)
        {
            if (!UseAppMemCache)
            {
                _templateParamsDictByPath.Clear();
                _templateParamsDict.Clear();
            }
            var list = _templateParamsCtrl.GetAllTemplateParamObjectByTemplateID(templateId);
            if (!_templateParamsDict.ContainsKey(templateId))
            {
                _templateParamsDict.TryAdd(templateId, list);
            }
            if (!_templateParamsDictByPath.ContainsKey(templateId))
            {
                var dict = GetTemplateParamsDictPath(list);
                _templateParamsDictByPath.TryAdd(templateId, dict);
            }
        }
        public static void InitDocumentSessionAsync(int documentId, int templateId)
        {
            //TODO
        }
        #region Params
        internal static List<MEParamsInfo> GetParams()
        {
            if (!UseAppMemCache)
                return _paramCtrl.GetAll();
            else if (_params == null)
                _params = _paramCtrl.GetAll();
            return _params;
        }
        private static ConcurrentDictionary<int, MEParamsInfo> GetParamsDictKeyIDFromStorage()
        {
            var dict = new ConcurrentDictionary<int, MEParamsInfo>();
            foreach (var item in GetParams())
            {
                dict.TryAdd(item.MEParamID, item);
            }
            return dict;
        }
        internal static ConcurrentDictionary<int, MEParamsInfo> GetParamsDictKeyID()
        {
            if (!UseAppMemCache)
                return GetParamsDictKeyIDFromStorage();
            else if (_paramsDictByID == null)
                _paramsDictByID = GetParamsDictKeyIDFromStorage();
            return _paramsDictByID;
        }
        public static MEParamsInfo GetParamFromDictKeyID(int id)
        {
            if (!UseAppMemCache)
                return _paramCtrl.GetObjectByID(id) as MEParamsInfo;
            if (_paramsDictByID == null) return null;
            _paramsDictByID.TryGetValue(id, out MEParamsInfo p);
            return p;
        }
        private static ConcurrentDictionary<string, MEParamsInfo> GetParamsDictKeyNoFromStorage()
        {
            var dict = new ConcurrentDictionary<string, MEParamsInfo>();
            foreach (var item in GetParams())
            {
                dict.TryAdd(item.MEParamNo, item);
            }
            return dict;
        }
        public static ConcurrentDictionary<string, MEParamsInfo> GetParamsDictKeyNo()
        {
            if (!UseAppMemCache)
                return GetParamsDictKeyNoFromStorage();
            else if (_paramsDictByNo == null)
                _paramsDictByNo = GetParamsDictKeyNoFromStorage();
            return _paramsDictByNo;
        }
        public static MEParamsInfo GetParamFromDictKeyNo(string no)
        {
            if (!UseAppMemCache)
                return _paramCtrl.GetObjectByNo(no) as MEParamsInfo;
            if (_paramsDictByNo == null) return null;
            _paramsDictByNo.TryGetValue(no, out MEParamsInfo p);
            return p;
        }
        private static ConcurrentDictionary<string, MEParamsInfo> GetAllHiddenParamsFromStorage()
        {
            var dict = new ConcurrentDictionary<string, MEParamsInfo>();
            foreach (var item in _paramCtrl.GetAllHiddenParams())
            {
                dict.TryAdd(item.MEParamNo, item);
            }
            return dict;
        }
        public static ConcurrentDictionary<string, MEParamsInfo> GetHiddenParamsDictKeyNo()
        {
            if (!UseAppMemCache)
                return GetAllHiddenParamsFromStorage();
            else if (_hiddenParamsDictByNo == null)
                _hiddenParamsDictByNo = GetAllHiddenParamsFromStorage();
            return _hiddenParamsDictByNo;
        }
        #endregion

        #region Param Relations
        private static ConcurrentDictionary<int, List<MEParamRelationsInfo>> GetParamRelationsDictFromStorage()
        {
            var dict = _paramRelationCtrl.GetAll().GroupBy(x => x.FK_MEParamParentID).ToDictionary(gdc => gdc.Key, gdc => gdc.ToList());
            return new ConcurrentDictionary<int, List<MEParamRelationsInfo>>(dict);
        }
        public static List<MEParamRelationsInfo> GetParamRelationsFromDict(int parentId)
        {
            if (!UseAppMemCache)
                return _paramRelationCtrl.GetAllByParentID(parentId);

            if (_paramRelationDict == null) return new List<MEParamRelationsInfo>();
            _paramRelationDict.TryGetValue(parentId, out List<MEParamRelationsInfo> dict);
            if (dict == null) return new List<MEParamRelationsInfo>();
            return dict;
        }
        public static ConcurrentDictionary<int, List<MEParamRelationsInfo>> GetParamRelationsDict()
        {
            if (!UseAppMemCache)
                return GetParamRelationsDictFromStorage();
            else if (_paramRelationDict == null)
                _paramRelationDict = GetParamRelationsDictFromStorage();
            return _paramRelationDict;
        }

        #endregion

        #region Template Indexs

        internal static List<METemplateIndexsInfo> GetTemplateIndexs()
        {
            if (!UseAppMemCache)
                return _templateIndexCtrl.GetAll();
            else if (_templateIndexs == null)
                _templateIndexs = _templateIndexCtrl.GetAll();
            return _templateIndexs;
        }
        private static ConcurrentDictionary<string, METemplateIndexsInfo> GetTemplateIndexsDictKeyNameFromStorage()
        {
            var dict = new ConcurrentDictionary<string, METemplateIndexsInfo>();
            foreach (var item in GetTemplateIndexs())
            {
                dict.TryAdd($"{ item.FK_MEEmrTypeID }-{ item.METemplateIndexName }", item);
            }
            return dict;
        }
        public static ConcurrentDictionary<string, METemplateIndexsInfo> GetTemplateIndexsDictKeyName()
        {
            if (!UseAppMemCache)
                return GetTemplateIndexsDictKeyNameFromStorage();
            else if (_templateIndexsDictKeyName == null)
                _templateIndexsDictKeyName = GetTemplateIndexsDictKeyNameFromStorage();
            return _templateIndexsDictKeyName;
        }
        public static METemplateIndexsInfo GetTemplateIndexFromDictKeyName(string name, int emrTypeId)
        {
            if (!UseAppMemCache)
                return _templateIndexCtrl.GetObjectInfoByNameAndEmrType(name, emrTypeId);
            if (_templateIndexsDictKeyName == null) return null;
            _templateIndexsDictKeyName.TryGetValue($"{ emrTypeId }-{ name }", out METemplateIndexsInfo p);
            return p;
        }
        public static METemplateIndexsInfo GetTemplateIndexById(int objId)
        {
            if (!UseAppMemCache)
                return _templateIndexCtrl.GetObjectInfoByID(objId);
            if (_templateIndexs == null) return null;
            return _templateIndexs.Where(i => i.METemplateIndexID == objId).FirstOrDefault();
        }
        #endregion

        #region Emr Type Templates
        internal static List<MEEmrTypeTemplatesInfo> GetEmrTypeTemplates()
        {
            if (!UseAppMemCache)
                return _emrTypeTemplateCtrl.GetAll();
            else if (_emrTypeTemplates == null)
                _emrTypeTemplates = _emrTypeTemplateCtrl.GetAll();
            return _emrTypeTemplates;
        }
        private static ConcurrentDictionary<int, List<MEEmrTypeTemplatesInfo>> GetEmrTypeTemplatesDictFromStorage()
        {
            var dict = GetEmrTypeTemplates().GroupBy(x => x.FK_MEEmrTypeID).ToDictionary(gdc => gdc.Key, gdc => gdc.ToList());
            return new ConcurrentDictionary<int, List<MEEmrTypeTemplatesInfo>>(dict);
        }
        public static List<MEEmrTypeTemplatesInfo> GetEmrTypeTemplatesFromDict(int emrTypeId)
        {
            if (!UseAppMemCache)
                return _emrTypeTemplateCtrl.GetAllByEmrTypeID(emrTypeId);

            if (_emrTypeTemplatesDict == null) return new List<MEEmrTypeTemplatesInfo>();
            _emrTypeTemplatesDict.TryGetValue(emrTypeId, out List<MEEmrTypeTemplatesInfo> dict);
            if (dict == null) return new List<MEEmrTypeTemplatesInfo>();
            return dict;
        }
        public static ConcurrentDictionary<int, List<MEEmrTypeTemplatesInfo>> GetEmrTypeTemplatesDict()
        {
            if (!UseAppMemCache)
                return GetEmrTypeTemplatesDictFromStorage();
            else if (_emrTypeTemplatesDict == null)
                _emrTypeTemplatesDict = GetEmrTypeTemplatesDictFromStorage();
            return _emrTypeTemplatesDict;
        }
        #endregion

        #region Action Params
        private static ConcurrentDictionary<int, List<MEEmrActionParamsInfo>> GetActionParamsDictFromStorage()
        {
            var dict = _actionParamsCtrl.GetAll().GroupBy(x => x.FK_MEEmrActionID).ToDictionary(gdc => gdc.Key, gdc => gdc.ToList());
            return new ConcurrentDictionary<int, List<MEEmrActionParamsInfo>>(dict);
        }
        public static List<MEEmrActionParamsInfo> GetActionParamsFromDict(int actionId)
        {
            if (!UseAppMemCache)
                return _actionParamsCtrl.GetAllByActionID(actionId);

            if (_actionParamsDict == null) return new List<MEEmrActionParamsInfo>();
            _actionParamsDict.TryGetValue(actionId, out List<MEEmrActionParamsInfo> dict);
            if (dict == null) return new List<MEEmrActionParamsInfo>();
            return dict;
        }
        public static ConcurrentDictionary<int, List<MEEmrActionParamsInfo>> GetActionParamsDict()
        {
            if (!UseAppMemCache)
                return GetActionParamsDictFromStorage();
            else if (_actionParamsDict == null)
                _actionParamsDict = GetActionParamsDictFromStorage();
            return _actionParamsDict;
        }
        #endregion

        #region Emr Action Api/SQL Data Cache
        public static bool GetActionDataFromMemCache(string key, DateTime t2, ref object data)
        {
            if (_actionDataCacheTime.TryGetValue(key, out DateTime t1))
            {
                if (t2 <= t1)
                {
                    if (_actionDataCache.TryGetValue(key, out JToken cache))
                    {
                        data = cache.DeepClone();
                        return true;
                    }
                }
            }
            return false;
        }
        public static bool SetActionDataToMemCache(string key, DateTime time, object data)
        {
            var clone = (data as JToken)?.DeepClone();
            if (clone != null)
            {
                if (_actionDataCacheTime.ContainsKey(key))
                    _actionDataCacheTime[key] = time;
                else
                    _actionDataCacheTime.Add(key, time);


                if (_actionDataCache.ContainsKey(key))
                    _actionDataCache[key] = clone;
                else
                    _actionDataCache.Add(key, clone);
                return true;
            }
            return false;
        }

        #endregion

        #region Template Params
        private static ConcurrentDictionary<string, METemplateParamsInfo> GetTemplateParamsDictPath(List<METemplateParamsInfo> list)
        {
            var dict = new ConcurrentDictionary<string, METemplateParamsInfo>();
            foreach (var item in list)
            {
                dict.TryAdd(item.METemplateParamPath, item);
            }
            return dict;
        }
        public static ConcurrentDictionary<string, METemplateParamsInfo> GetTemplateParamsDictPath(int templateId)
        {
            //caller khong can biet goi to cache hay local
            //chac chan co vi InitDocumentSession da goi
            if (_templateParamsDictByPath.TryGetValue(templateId, out ConcurrentDictionary<string, METemplateParamsInfo> cache))
                return cache;

            var list = _templateParamsCtrl.GetAllTemplateParamObjectByTemplateID(templateId);
            return GetTemplateParamsDictPath(list);
        }
        public static List<METemplateParamsInfo> GetTemplateParams(int templateId)
        {
            if (_templateParamsDict.TryGetValue(templateId, out List<METemplateParamsInfo> cache))
                return cache;

            return _templateParamsCtrl.GetAllTemplateParamObjectByTemplateID(templateId);
        }

        #endregion

        #region Monitoring for future use
        /*public static void RegisterSqlChangeMonitor()
        {
            //Get from configuration file
            Crypto cryp = new Crypto();
            string serverName = ConfigurationManager.AppSettings["ServerName"];
            string databaseName = ConfigurationManager.AppSettings["DatabaseName"];
            string userID = cryp.DecryptNew(ConfigurationManager.AppSettings["UserID"], true);
            string password = cryp.DecryptNew(ConfigurationManager.AppSettings["Password"], true);
            _connectionString = string.Format("Data Source={0};Initial Catalog={1};User ID={2};Password={3}", serverName, databaseName, userID, password);
            SqlDependency.Start(_connectionString);
            try
            {
                //CacheItemPolicy policy = new CacheItemPolicy
                //{
                //    AbsoluteExpiration = DateTime.Now.AddDays(3)
                //};
                //CacheItem item = new CacheItem("params", new object());
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    connection.Open();
                    var sql = "SELECT AACreatedDate, AAUpdatedDate FROM dbo.MEParams";
                    using (SqlCommand command = new SqlCommand(sql))
                    {
                        command.Connection = connection;
                        command.Notification = null;
                        SqlDependency dependency = new SqlDependency(command);
                        SqlChangeMonitor monitor = new SqlChangeMonitor(dependency);
                        //policy.ChangeMonitors.Add(monitor);
                        dependency.OnChange += OnSqlDependencyOnChange;
                        //MemoryCache.Default.Set(item, policy);
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {

            }
        }
        private static void OnSqlDependencyOnChange(object sender, SqlNotificationEventArgs e)
        {
            SqlDependency dependency = sender as SqlDependency;
            dependency.OnChange -= OnSqlDependencyOnChange;
            RegisterSqlChangeMonitor();
        }*/
        #endregion
    }
}
