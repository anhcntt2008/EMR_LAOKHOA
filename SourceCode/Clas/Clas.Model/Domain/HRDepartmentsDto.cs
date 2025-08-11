using System;
using System.Collections.Generic;

namespace Clas.Model.Domain
{
    public partial class HRDepartmentsDto
    {
        public HRDepartmentsDto()
        {
        }

        public int HRDepartmentID { get; set; }
        public DateTime AACreatedDate { get; set; }
        public string AACreatedUser { get; set; }
        public DateTime AAUpdatedDate { get; set; }
        public string AAUpdatedUser { get; set; }
        public string AAStatus { get; set; }
        public string HRDepartmentNo { get; set; }
        public string HRDepartmentName { get; set; }
        public string HRDepartmentDesc { get; set; }
        public bool? HRDepartmentEmrShared { get; set; }


    }
}
