using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clas.Model.Base
{
    public class Document
    {
        public ObjectId Id { get; set; }
        public ObjectId RefId { get; set; }
        public int _v { get; set; }

        public String AACreatedUser { get; set; }
        [BsonDateTimeOptions(Kind = DateTimeKind.Local)]
        public DateTime AACreatedDate { get; set; }
        public String AAUpdatedUser { get; set; }
        [BsonDateTimeOptions(Kind = DateTimeKind.Local)]
        public DateTime AAUpdatedDate { get; set; }
    }
}
