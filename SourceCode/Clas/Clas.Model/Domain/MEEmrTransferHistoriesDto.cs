using System;
using System.Collections.Generic;

namespace Clas.Model.Domain
{
    public partial class MEEmrTransferHistoriesDto
    {
        public int MEEmrTransferHistoryID { get; set; }
        public string AAStatus { get; set; }
        public string AACreatedUser { get; set; }
        public DateTime AACreatedDate { get; set; }
        public string AAUpdatedUser { get; set; }
        public DateTime AAUpdatedDate { get; set; }
        public string MEEmrTransferHistoryNo { get; set; }
        public DateTime MEEmrTransferHistoryDate { get; set; }
        public int FK_MEEmrID { get; set; }
        public int FK_HREmployeeFromID { get; set; }
        public int FK_HREmployeeToID { get; set; }
        public int FK_HRDepartmentFromID { get; set; }
        public int FK_HRDepartmentToID { get; set; }
        public bool MEEmrTransferHistoryCurrent { get; set; }
        public string MEEmrTransferHistoryRemark { get; set; }

        public HRDepartmentsDto FK_HRDepartmentFrom { get; set; }
        public HRDepartmentsDto FK_HRDepartmentTo { get; set; }
        public HREmployeesDto FK_HREmployeeFrom { get; set; }
        public HREmployeesDto FK_HREmployeeTo { get; set; }
        public MEEmrsDto FK_MEEmr { get; set; }
    }
}
