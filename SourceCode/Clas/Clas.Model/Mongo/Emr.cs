using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clas.Model.Mongo
{

    [MongoDB.Bson.Serialization.Attributes.BsonIgnoreExtraElements]
    public class Emr
    {
        public int MEEmrID { get; set; }
        public String AAStatus { get; set; }
        public String MEEmrNo { get; set; }
        public String MEEmrDesc { get; set; }
        public String MEEmrStatus { get; set; }
        public DateTime MEEmrCreatedDate { get; set; }
        public DateTime MEEmrEndDate { get; set; }
        public int FK_MEPatientID { get; set; }
        public int FK_MEPatientVisitID { get; set; }
        public int FK_BRBranchID { get; set; }
        public String AACreatedUser { get; set; }
        public DateTime AACreatedDate { get; set; }
        public String AAUpdatedUser { get; set; }
        public DateTime AAUpdatedDate { get; set; }
        public int FK_MEEmrTypeID { get; set; }
        public int FK_HRDepartmentID { get; set; }

        public string MEEmrTypeProfile { get; set; }
        public int FK_HREmployeeCreatedID { get; set; }
    }
}
