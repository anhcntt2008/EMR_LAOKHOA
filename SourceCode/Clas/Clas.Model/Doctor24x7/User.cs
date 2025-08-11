using System;
using System.Collections.Generic;
using System.Text;
using Clas.Model.Base;

namespace Clas.Model.Doctor24x7
{
    public static class CurrentUser
    {
        public static UserLoginHttpModel CurrentBacSi24X7 { get; set; }
    }

    public class User
    {
        public string id { get; set; }
        public object parentId { get; set; }
        public string code { get; set; }
        public string title { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string email { get; set; }
        public string address { get; set; }
        public string fullName { get; set; }
        public string phone { get; set; }
        public object password { get; set; }
        public string gender { get; set; }
        public long? birthDay { get; set; }
        public string idNo { get; set; }
        public object hospitalId { get; set; }
        public object facebookId { get; set; }
        public string cityId { get; set; }
        public string districtId { get; set; }
        public string photo { get; set; }
        public object type { get; set; }
        public object roleMap { get; set; }
        public object roles { get; set; }
        public bool status { get; set; }
        public bool? maritalStatus { get; set; }
        public City city { get; set; }
        public District district { get; set; }
        public string ownerHospitalId { get; set; }
        public object occupation { get; set; }
        public object skypeId { get; set; }
        public float avgRating { get; set; }
        public int rating { get; set; }
        public int rateCount { get; set; }
        public string experience { get; set; }
        public string certification { get; set; }
        public string languages { get; set; }
        public object checkupTypeId { get; set; }
        public object isFamilyDoctor { get; set; }
        public float[] location { get; set; }
        public decimal feeTreatment { get; set; }
        public CheckupType checkupType { get; set; }
        public decimal distance { get; set; }
        public int checkupCount { get; set; }
        public DoctorInfo[] doctorInfos { get; set; }
    }
    public class UserLoginHttpRequest
    {
        public string id { get; set; }
        public string password { get; set; }
    }
    public class UserLoginHttpResult : HttpResult
    {
        public UserLoginHttpModel data { get; set; }
    }
    public class UserLoginHttpModel
    {
        public string sessionId { get; set; }
        public string userId { get; set; }
        public long sessionExpired { get; set; }
        public int appType { get; set; }
        public Hospital[] hospitals { get; set; }
        public int userType { get; set; }
        public int hospitalSelectedIndex { get; set; }
    }

    public class UserDetailsModel
    {
        public User user { get; set; }
    }
    public class UserDetailsHttpResult : HttpResult
    {
        public UserDetailsModel data { get; set; }
    }
    public class UserPatientHttpResult : HttpResult
    {
        public UserPatientModel data { get; set; }
    }
    public class UserPatientModel
    {
        public int total { get; set; }
        public List<User> patients { get; set; }
        public User user { get; set; }
        public User profile { get; set; }
    }

    public class ListPatient : HttpResult
    {
        public ListUserData data { get; set; }
    }

    public class ListUserData
    {
        public int total { get; set; }
        public List<PatientBacSi24x7> patients { get; set; }
    }

}
