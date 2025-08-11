using BOSCommon;
using BOSERP;
using BOSLib;
using BOSLib.DataAccess;
using Clas.Model.Base;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;

namespace Clas.Repository.Mongo
{
    public class Database
    {
        private MongoClient _client;
        private readonly string _connectionString;
        private IMongoDatabase _db;

        public Database()
        {
            Crypto cryp = new Crypto();
            System.Configuration.Configuration configuration =
               ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            // XUANTM move to sql storage. Flex
            var host = cryp.DecryptNew(SystemMemCache.GetSystemConfigValue(SysCfgConsts.PRIVATE, SysCfgConsts.PRIVATE_MONGO_HOST), true);
            var port = cryp.DecryptNew(SystemMemCache.GetSystemConfigValue(SysCfgConsts.PRIVATE, SysCfgConsts.PRIVATE_MONGO_PORT), true);
            var user = cryp.DecryptNew(SystemMemCache.GetSystemConfigValue(SysCfgConsts.PRIVATE, SysCfgConsts.PRIVATE_MONGO_USER), true);
            var pw = cryp.DecryptNew(SystemMemCache.GetSystemConfigValue(SysCfgConsts.PRIVATE, SysCfgConsts.PRIVATE_MONGO_PW), true);
            var authSource = cryp.DecryptNew(SystemMemCache.GetSystemConfigValue(SysCfgConsts.PRIVATE, SysCfgConsts.PRIVATE_MONGO_AUTH_SOURCE), true);
            var dbName = cryp.DecryptNew(SystemMemCache.GetSystemConfigValue(SysCfgConsts.PRIVATE, SysCfgConsts.PRIVATE_MONGO_DB), true);
            _connectionString = string.Format("mongodb://{0}:{1}@{2}:{3}/{4}?authSource={5}",
                user, pw, host, port, dbName, authSource);
            _client = new MongoClient(_connectionString);
            if (!string.IsNullOrEmpty(dbName))
                _db = _client.GetDatabase(dbName);
        }
        public void CreateCollection(string name)
        {
            if (_db == null) return;
            _db.CreateCollection(name);
        }
        public Document InsertOneDocument(Document doc, string collectionName)
        {
            if (_db == null) return null;
            collectionName = collectionName.ToLower();
            var collection = _db.GetCollection<Document>(collectionName);
            if (collection == null)
            {
                this.CreateCollection(collectionName);
                collection = _db.GetCollection<Document>(collectionName);
            }
            doc.Id = new ObjectId();
            collection.InsertOne(doc);
            return doc;
        }

        public List<T> Find<T>(Dictionary<string, object> filters, Dictionary<string, string> fields, string collectionName)
        {
            if (_db == null) return null;

            collectionName = collectionName.ToLower();
            var collection = _db.GetCollection<T>(collectionName);
            var cols = Newtonsoft.Json.JsonConvert.SerializeObject(fields);
            var builder = Builders<T>.Filter;
            var filter = builder.Empty;
            foreach (var item in filters)
            {
                filter = filter & GetFilter(builder, item);
            }
            filter = filter & builder.Eq("AAStatus", "Alive");
            if (fields.Count > 0)
                return collection.Aggregate().Match(filter).Project<T>(cols).ToList();

            return collection.Find<T>(filter).ToList();
        }

        private FilterDefinition<T> GetFilter<T>(FilterDefinitionBuilder<T> builder, KeyValuePair<string, object> item)
        {
            var exp = (Tuple<MongoFilter, object>)item.Value;
            switch (exp.Item1)
            {
                case MongoFilter.Ne:
                    return builder.Ne(item.Key, exp.Item2);
                case MongoFilter.Nin:
                    return builder.Nin(item.Key, (exp.Item2 as object[]));
                default:
                    return builder.Eq(item.Key, exp.Item2);
            }

        }
        public T UpdateDocument<T>(string id, T doc, string collectionName, List<string> excludedFields = null) where T : Document
        {
            if (_db == null) return null;

            collectionName = collectionName.ToLower();
            var collection = _db.GetCollection<T>(collectionName);
            doc.Id = ObjectId.Parse(id);
            var filter = Builders<T>.Filter.Eq("_id", doc.Id);
            var old = collection.Find(filter).FirstOrDefault();
            old.RefId = doc.Id;
            //old.AAUpdatedDate = doc.AAUpdatedDate;
            //old.AAUpdatedUser = doc.AAUpdatedUser;
            InsertOneDocument(old, collectionName + "_revisions");
            doc._v = old._v + 1;
            if (excludedFields == null)
            {
                var result = collection.FindOneAndReplace(filter, doc,
                    new FindOneAndReplaceOptions<T, T>()
                    {
                        IsUpsert = true,
                        ReturnDocument = ReturnDocument.After
                    });
                return result;
            }
            else
            {
                var update = GetUpdateDefinitionBuilder<T>(doc, excludedFields);
                var result = collection.FindOneAndUpdate(filter, update,
                   new FindOneAndUpdateOptions<T, T>()
                   {
                       IsUpsert = true,
                       ReturnDocument = ReturnDocument.After
                   });
                return result;
            }
        }
        public UpdateDefinition<T> GetUpdateDefinitionBuilder<T>(T doc, List<string> excludedFields = null) where T : Document
        {
            var builder = Builders<T>.Update;
            UpdateDefinition<T> update = builder.Combine();
            Type type = typeof(T);
            PropertyInfo[] properties = type.GetProperties();
            foreach (PropertyInfo property in properties)
            {
                if (!excludedFields.Contains(property.Name))
                    update = update.Set(property.Name, property.GetValue(doc, null));
            }
            return update;
        }
        public T DeleteDocument<T>(string id, string collectionName, string user) where T : Document
        {
            if (_db == null) return null;
            if (string.IsNullOrEmpty(id)) return null;
            collectionName = collectionName.ToLower();
            var collection = _db.GetCollection<T>(collectionName);
            var filter = Builders<T>.Filter.Eq("_id", ObjectId.Parse(id));
            var update = Builders<T>.Update.Set("AAStatus", "Delete").Set("AAUpdatedUser", user).Set("AAUpdatedDate", DateTime.Now);
            var result = collection.FindOneAndUpdate(filter, update, new FindOneAndUpdateOptions<T, T>()
            {
                IsUpsert = true,
                ReturnDocument = ReturnDocument.After
            });
            return result;
        }

        #region XuanTM
        public LogMongo InsertLog(LogMongo log, string collectionName)
        {
            if (_db == null) return null;
            collectionName = collectionName.ToLower();
            var collection = _db.GetCollection<LogMongo>(collectionName);
            if (collection == null)
            {
                this.CreateCollection(collectionName);
                collection = _db.GetCollection<LogMongo>(collectionName);
            }
            log.Id = new ObjectId();
            collection.InsertOne(log);
            return log;
        }
        #endregion
    }
}
