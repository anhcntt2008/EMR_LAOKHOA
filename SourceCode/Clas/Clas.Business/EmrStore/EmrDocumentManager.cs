using Clas.Model.Base;
using Clas.Model.Mongo;
using Clas.Repository.Mongo;
using MongoDB.Bson;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Clas.Business.EmrStore
{
    public class EmrDocumentManager
    {
        private Database _db;
        public EmrDocumentManager()
        {
            this._db = new Database();
        }
        public string Insert(EmrDocument doc, string collection)
        {
            if (this._db.InsertOneDocument(doc, collection) != null)
                return doc.Id.ToString();
            return string.Empty;
        }
        public string Update(string id, EmrDocument doc, string collection, List<string> excludedFields = null)
        {
            if (this._db.UpdateDocument(id, doc, collection, excludedFields) != null)
                return doc.Id.ToString();
            return string.Empty;
        }
        public EmrDocument Delete(string id, string collection, string user)
        {
            return this._db.DeleteDocument<EmrDocument>(id, collection, user);
        }

        public object Find(Dictionary<string, object> filters, Dictionary<string, string> fields, string collection)
        {
            var results = this._db.Find<BsonDocument>(filters, fields, collection);
            if (results != null)
            {
                if (results.Count > 1)
                {
                    var arr = new JArray();
                    foreach (var doc in results)
                    {
                        arr.Add(JObject.FromObject(doc.ToDictionary(), new JsonSerializer()
                        {
                            DateTimeZoneHandling = DateTimeZoneHandling.Local
                        }));
                    }
                    return arr;
                }
                if (results.Count == 1) return JObject.FromObject(results[0].ToDictionary(), new JsonSerializer()
                {
                    DateTimeZoneHandling = DateTimeZoneHandling.Local
                });
            }
            return null;
        }
        public object FindLast(Dictionary<string, object> filters, Dictionary<string, string> fields, string collection)
        {
            var results = this._db.Find<BsonDocument>(filters, fields, collection);
            if (results != null)
            {
                if (results.Count > 1)
                {
                    int max = results.Count();
                    return JObject.FromObject(results[max-1].ToDictionary(), new JsonSerializer()
                    {
                        DateTimeZoneHandling = DateTimeZoneHandling.Local
                    });
                }
                if (results.Count == 1) return JObject.FromObject(results[0].ToDictionary(), new JsonSerializer()
                {
                    DateTimeZoneHandling = DateTimeZoneHandling.Local
                });
            }
            return null;
        }
        public List<EmrDocument> GetList(Dictionary<string, object> filters, Dictionary<string, string> fields, string collection)
        {
            return this._db.Find<EmrDocument>(filters, fields, collection);
        }

        #region XuanTM
        public string InsertLog(LogMongo log, string collection)
        {
            if (this._db.InsertLog(log, collection) != null)
                return log.Id.ToString();
            return string.Empty;
        }

        public List<LogMongo> GetLogList(Dictionary<string, object> filters, Dictionary<string, string> fields, string collection)
        {
            return this._db.Find<LogMongo>(filters, fields, collection);
        }
        #endregion
    }
}
