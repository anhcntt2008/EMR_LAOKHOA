using System;
using System.Collections.Generic;
using System.Text;
using Clas.Model.Base;

namespace Clas.Model.Doctor24x7
{
    public class Hospital
    {
        // for login result
        public string hospitalId { get; set; }
        public string name { get; set; }
        public Photos photos { get; set; }
        public int[] roles { get; set; }

        // for general
        public string id { get; set; }
        public string parentId { get; set; }
        public string code { get; set; }
        public string address { get; set; }
        public float[] location { get; set; }
        public string[] phones { get; set; }
        public string[] emails { get; set; }
        public decimal schedulingFee { get; set; }
        public decimal checkupFee { get; set; }
        public decimal cancelCheckupFee { get; set; }
        public object checkupTypeIds { get; set; }
        public object scbMid { get; set; }
        public object scbTid { get; set; }
        public bool status { get; set; }
        public string cityId { get; set; }
        public string districtId { get; set; }
        public bool? isFamousHospital { get; set; }
        public bool? isCLASHospital { get; set; }
        public object adminUsers { get; set; }
        public object type { get; set; }
        public bool usedMedicalRecord { get; set; }
        public int? classharePercent { get; set; }
    }
    public class HospitalListResult:HttpResult
    {
        public HospitalList data { get; set; }
    }
    public class HospitalList
    {
        public int total { get; set; }
        public Hospital[] hospitals { get; set; }
    }

    public class HospitalResult : HttpResult
    {
        public Data data { get; set; }
    }

    public class Data
    {
        public Hospital hospital { get; set; }
    }
}
