using System;
using System.Collections.Generic;

namespace Clas.Model.Domain
{
    public partial class MEEmrsDto
    {
        public MEEmrsDto()
        {
            MEEmrDocuments = new HashSet<MEEmrDocumentsDto>();
            MEEmrShareHistories = new HashSet<MEEmrShareHistoriesDto>();
            MEEmrTransferHistories = new HashSet<MEEmrTransferHistoriesDto>();
        }

        public int MEEmrID { get; set; }
        public string AAStatus { get; set; }
        public string MEEmrNo { get; set; }
        public string MEEmrDesc { get; set; }
        public string MEEmrStatus { get; set; }
        public DateTime? MEEmrCreatedDate { get; set; }
        public DateTime? MEEmrEndDate { get; set; }
        public int FK_MEPatientID { get; set; }
        public string AACreatedUser { get; set; }
        public DateTime AACreatedDate { get; set; }
        public string AAUpdatedUser { get; set; }
        public DateTime AAUpdatedDate { get; set; }
        public int? FK_MEEmrTypeID { get; set; }
        public int? FK_HRDepartmentID { get; set; }
        //public MEEmrTypes FK_MEEmrType { get; set; }

        public string MEEmrTypeProfile { get; set; }
        public int FK_HREmployeeCreatedID { get; set; }
        public MEPatientsDto MEPatient { get; set; }
        public ICollection<MEEmrDocumentsDto> MEEmrDocuments { get; set; }
        public ICollection<MEEmrShareHistoriesDto> MEEmrShareHistories { get; set; }
        public ICollection<MEEmrTransferHistoriesDto> MEEmrTransferHistories { get; set; }
    }
}
