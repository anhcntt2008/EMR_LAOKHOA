using System;
using System.Collections.Generic;
using System.Text;
using Clas.Model.Base;

namespace Clas.Model.Doctor24x7
{
    public class DoctorInfo
    {
        public string hospitalId { get; set; }
        public string checkupTypeId { get; set; }
        public int[] roles { get; set; }
        public Hospital hospital { get; set; }
        public CheckupType checkupType { get; set; }
    }
    public class Doctor
    {
        public string id { get; set; }
        public string code { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string title { get; set; }
        public string fullName { get; set; }

        //KhangCV ADDED 20/03/2017 START
        public string email { get; set; }
        public string phone { get; set; }
        //KhangCV ADDED 20/03/2017 END

        public int status { get; set; }
        public CheckupType checkupType { get; set; }
        public DoctorInfo[] doctorInfos { get; set; }

        //KhangCV [ADDED] [20/03/2017] START
        public string doctorDisplayText {
            get {
                return string.Format("{0} - {1}", fullName, email);
            }
        }
        //KhangCV [ADDED] [20/03/2017] END

    }

    public class DoctorListHttpResult : HttpResult
    {
        public DoctorListModel data { get; set; }
    }
    public class DoctorListModel
    {
        public int total { get; set; }
        public Doctor[] doctors { get; set; }
    }
}
