using System;
using System.Collections.Generic;

namespace Clas.Model.Domain {
    public partial class MEPatientsDto {
        public MEPatientsDto () {
            MEEmrs = new HashSet<MEEmrsDto> ();
        }

        public int MEPatientID { get; set; }
        public string AAStatus { get; set; }
        public string AACreatedUser { get; set; }
        public DateTime AACreatedDate { get; set; }
        public string AAUpdatedUser { get; set; }
        public DateTime AAUpdatedDate { get; set; }
        public string MEPatientNo { get; set; }
        public string MEPatientName { get; set; }
        public string MEPatientType { get; set; }
        public string MEPatientDesc { get; set; }
        public string MEPatientTitle { get; set; }
        public DateTime MEPatientBirthday { get; set; }
        public string MEGender { get; set; }
        public bool? MEPatientActiveCheck { get; set; }
        public string MEPatientOccupation { get; set; }
        public string MEMarital { get; set; }
        public string MEPatientEthnicity { get; set; }
        public string MEPatientContactEmail { get; set; }
        public string MEPatientContactPhone { get; set; }
        public string MEPatientContactCellPhone { get; set; }
        public string MEPatientContactCompany { get; set; }
        public string MEPatientContactDepartment { get; set; }
        public string MEPatientContactAddressStreet { get; set; }
        public string MEPatientContactAddressLine1 { get; set; }
        public string MEPatientContactAddressLine2 { get; set; }
        public string MEPatientContactAddressLine3 { get; set; }
        public string MEPatientContactAddressWard { get; set; }
        public string MEPatientContactAddressDistrict { get; set; }
        public string MEPatientContactAddressCity { get; set; }
        public string MEPatientContactAddressPostalCode { get; set; }
        public string MEPatientContactAddressStateProvince { get; set; }
        public string MEPatientContactAddressCountry { get; set; }
        public int FK_MEEthnicID { get; set; }
        public string MEPatientContactCellPhone2 { get; set; }
        public string MEPatientIDCard { get; set; }
        public DateTime MEPatientIDCardDate { get; set; }
        public string MEPatientIDCardStateProvinces { get; set; }
        public string MEPatientPermanentResidence { get; set; }
        public ICollection<MEEmrsDto> MEEmrs { get; set; }

    }
}