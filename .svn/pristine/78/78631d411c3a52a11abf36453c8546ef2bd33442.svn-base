using System;
using System.Collections.Generic;

namespace Clas.Model.Domain
{
    public partial class MEEmrDocumentsDto
    {
        public MEEmrDocumentsDto()
        {
            MEEmrDocumentSigns = new HashSet<MEEmrDocumentSignsDto>();
        }

        public int MEEmrDocumentID { get; set; }
        public string AAStatus { get; set; }
        public string MEEmrDocumentNo { get; set; }
        public string MEEmrDocumentFile { get; set; }
        public string MEEmrDocumentDesc { get; set; }
        public DateTime MEEmrDocumentCreatedDate { get; set; }
        public DateTime MEEmrDocumentEndDate { get; set; }
        public string MEEmrDocumentStatus { get; set; }
        public int FK_MEEmrID { get; set; }
        public int FK_METemplateID { get; set; }
        public string AACreatedUser { get; set; }
        public DateTime AACreatedDate { get; set; }
        public string AAUpdatedUser { get; set; }
        public DateTime AAUpdatedDate { get; set; }
        public object MEEmrDocumentContent { get; set; }
        public string MEEmrDocumentGuid { get; set; }
        public int FK_EditingUserID { get; set; }
        public int MEEmrDocumentOrder { get; set; }
        public string MEEmrDocumentFileExt { get; set; }
        public int FK_HRDepartmentID { get; set; }
        public string MEEmrDocumentMongoID { get; set; }
        public string MEEmrDocumentGroup { get; set; }
        public int FK_HREmployeeCreatedID { get; set; }
        public HREmployeesDto FK_EditingUser { get; set; }
        public HRDepartmentsDto FK_HRDepartment { get; set; }
        public MEEmrsDto FK_MEEmr { get; set; }
        //public METemplates FK_METemplate { get; set; }
        public ICollection<MEEmrDocumentSignsDto> MEEmrDocumentSigns { get; set; }

        public int MEEmrDocumentPageCount { get; set; }

        public int MEEmrDocumentDuplexCount { get; set; }
    }
}