using System;
using System.Collections.Generic;

namespace Clas.Model.Domain {
    public partial class MEEmrShareHistoriesDto {
        public int MEEmrShareHistoryID { get; set; }
        public string AAStatus { get; set; }
        public string AACreatedUser { get; set; }
        public DateTime AACreatedDate { get; set; }
        public string AAUpdatedUser { get; set; }
        public DateTime AAUpdatedDate { get; set; }
        public int FK_HREmployeeShareByID { get; set; }
        public DateTime MEEmrShareHistoryDate { get; set; }
        public int FK_MEEmrID { get; set; }
        public int FK_HRDepartmentID { get; set; }
        public int FK_HREmployeeID { get; set; }
        public DateTime MEEmrShareHistoryFromDate { get; set; }
        public DateTime MEEmrShareHistoryToDate { get; set; }
        public bool MEEmrShareHistoryActive { get; set; }
        public string MEEmrShareHistoryRemark { get; set; }

        public HRDepartmentsDto FK_HRDepartment { get; set; }
        public HREmployeesDto FK_HREmployee { get; set; }
        public HREmployeesDto FK_HREmployeeShareBy { get; set; }
        public MEEmrsDto FK_MEEmr { get; set; }
    }
}