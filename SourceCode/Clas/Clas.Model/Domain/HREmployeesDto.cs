using System;
using System.Collections.Generic;

namespace Clas.Model.Domain {
    public partial class HREmployeesDto {
        public HREmployeesDto () { }

        public int HREmployeeID { get; set; }
        public string AAStatus { get; set; }
        public string AACreatedUser { get; set; }
        public string AAUpdatedUser { get; set; }
        public DateTime AACreatedDate { get; set; }
        public DateTime AAUpdatedDate { get; set; }
        public bool IsTransferred { get; set; }
        public DateTime AATransferredDate { get; set; }
        public int FK_HRDepartmentID { get; set; }
        public int FK_HRDepartmentRoomID { get; set; }
        public string HREmployeeNo { get; set; }
        public string HREmployeeName { get; set; }
        public string HREmployeeGenderCombo { get; set; }
        public DateTime HREmployeeDob { get; set; }
        public byte[] HREmployeeSignature { get; set; }
        public string HREmployeeShortSignature { get; set; }
    }
}