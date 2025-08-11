using Clas.Model.Base;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clas.Model.Mongo
{
    [MongoDB.Bson.Serialization.Attributes.BsonIgnoreExtraElements]
    public class EmrDocument : Document
    {
        public EmrDocument()
        {
            FK_HREmployeeCreatedID = 0;
        }
        public int MEEmrDocumentID;
        public String AAStatus { get; set; }
        public String MEEmrDocumentNo { get; set; }
        public String MEEmrDocumentFile { get; set; }
        public String MEEmrDocumentDesc { get; set; }
        [BsonDateTimeOptions(Kind = DateTimeKind.Local)]
        public DateTime MEEmrDocumentCreatedDate { get; set; }
        [BsonDateTimeOptions(Kind = DateTimeKind.Local)]
        public DateTime MEEmrDocumentEndDate { get; set; }
        public String MEEmrDocumentStatus { get; set; }
        public int FK_MEEmrID { get; set; }
        public int FK_METemplateID { get; set; }
        public BsonDocument MEEmrDocumentContent { get; set; }
        public String MEEmrDocumentGuid { get; set; }
        public int FK_EditingUserID { get; set; }
        public int FK_HRDepartmentID { get; set; }
        public int MEEmrDocumentOrder { get; set; }
        public String MEEmrDocumentFileExt { get; set; }
        public Emr MEEmr { get; set; }

        public String MEEmrDocumentGroup { get; set; }
        public String MEEmrDocumentCode { get; set; }
        public int MEEmrDocumentSubOrder { get; set; }
        public String MEEmrDocumentCommandDateStr { get; set; }
        public String MEEmrDocumentStr1 { get; set; }
        public String MEEmrDocumentStr2 { get; set; }
        public String MEEmrDocumentStr3 { get; set; }
        public String MEEmrDocumentStr4 { get; set; }
        public String MEEmrDocumentStr5 { get; set; }
        public double MEEmrDocumentNum1 { get; set; }
        public double MEEmrDocumentNum2 { get; set; }
        public double MEEmrDocumentNum3 { get; set; }
        public double MEEmrDocumentNum4 { get; set; }
        public double MEEmrDocumentNum5 { get; set; }
        public DateTime MEEmrDocumentDate1 { get; set; }
        public DateTime MEEmrDocumentDate2 { get; set; }
        public DateTime MEEmrDocumentDate3 { get; set; }
        public DateTime MEEmrDocumentDate4 { get; set; }
        public DateTime MEEmrDocumentDate5 { get; set; }
        public int FK_HREmployeeCreatedID { get; set; }

    }
}
