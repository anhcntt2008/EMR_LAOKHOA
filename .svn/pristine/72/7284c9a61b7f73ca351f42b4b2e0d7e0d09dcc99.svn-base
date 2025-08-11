using System;
using System.Collections.Generic;
using System.Text;
using Clas.Model.Base;

namespace Clas.Model.Doctor24x7
{
    public class Checkup
    {
        public string id { get; set; }
        public string appointmentNo { get; set; }
        public string userId { get; set; }
        public string hospitalId { get; set; }
        public string doctorId { get; set; }
        public string checkupTypeId { get; set; }
        public string symptom { get; set; }
        public string scheduleId { get; set; }
        public object paymentMethod { get; set; }
        public object patientType { get; set; }
        public object serviceType { get; set; }
        public int status { get; set; }
        public object refundStatus { get; set; }
        public object refundPerson { get; set; }
        public object whenRefunded { get; set; }
        public bool isPaid { get; set; }
        public object result { get; set; }
        public long whenCreated { get; set; }
        public object whenUpdated { get; set; }
        public long appointmentDate { get; set; }
        public long endAppointmentDate { get; set; }
        public long? paymentExpiredDate { get; set; }
        public object payment { get; set; }
        public float amount { get; set; }
        public float checkupFee { get; set; }
        public float schedulingFee { get; set; }
        public float cancelCheckupFee { get; set; }
        public float discountAmount { get; set; }
        public object fullAddress { get; set; }
        public Hospital hospital { get; set; }
        public CheckupType checkupType { get; set; }
        public Doctor doctor { get; set; }
        public User dataUser { get; set; }
        public int? rating { get; set; }
        public object room { get; set; }
        public bool paid { get; set; }
        public bool healthInsurance { get; set; }
        public DateTime AppoitmentDateTime { get; set; }
        public DateTime AppointmentEndTime { get; set; }
        public string PatientName { get; set; }
        public bool IsLocalRegister { get; set; }
        public string LocalRegisterStatus { get; set; }
    }
    public class CheckupPostModel
    {
        public string scheduleId { get; set; }
        public string symptom { get; set; }

        // neu user id =  null phai co day du thong tin dataUser
        public string userId { get; set; }

        // neu user chua co se tao moi user
        public CheckupPostDataUser dataUser { get; set; }
    }
    public class CheckupPostDataUser
    {
        public string parentId { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string phone { get; set; }
        public string email { get; set; }
        public string idNo { get; set; }
        public string address { get; set; }
        public string cityId { get; set; }
        public string districtId { get; set; }
    }

    public class CheckupHttpResult : HttpResult
    {
        public CheckupResultModel data { get; set; }
    }
    public class CheckupResultModel
    {
        public Checkup checkup { get; set; }
        public List<Checkup> checkups { get; set; }
    }
    public class CheckupDataUser
    {

        public string id { get; set; }
        public object parentId { get; set; }
        public string code { get; set; }
        public object title { get; set; }
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
        //KhangCV modified 17/03/2017 START
        public string photo { get; set; }
        //KhangCV modified 17/03/2017 END
        public object type { get; set; }
        public object roleMap { get; set; }
        public object roles { get; set; }
        public int status { get; set; }
        public bool? maritalStatus { get; set; }
        public object city { get; set; }
        public object district { get; set; }
        public string ownerHospitalId { get; set; }
        public object occupation { get; set; }
        public object skypeId { get; set; }
        public float avgRating { get; set; }
        public int rating { get; set; }
        public int rateCount { get; set; }
        public object patientType { get; set; }
        public object partnerCode { get; set; }
        //public Patienttypemap patientTypeMap { get; set; }
        public bool secure { get; set; }
    }

    // [NNHUY] [20/1/2017] [Start]
    public class PatientHttpResult : HttpResult
    {
        public PatientResult data { get; set; }
    }

    public class PatientResult
    {
        public PatientModel profile { get; set; }
    }

    public class PatientModel
    {
        public string id { get; set; }
    }
    public class PatientPostRequest
    {
        public string fullName;

        public string firstName { get; set; }
        public string lastName { get; set; }
        public string gender { get; set; }
        public string idNo { get; set; }
        public string email { get; set; }
        public string address { get; set; }
        public string phone { get; set; }
        public string cityId { get; set; }
        public string districtId { get; set; }
        public string password { get; set; }
        public long birthDay { get; set; }
        public string maritalStatus { get; set; }
        public string occupation { get; set; }
        public string patientType { get; set; }

    }
    // [NNHUY] [20/1/2017] [End]
}
