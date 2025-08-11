using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Threading;
using BOSCommon;
using BOSLib.DataAccess;
using Clas.Model.Base;
using Clas.Model.Doctor24x7;
using Clas.Repository.HttpApi;
using Newtonsoft.Json.Linq;

namespace Clas.Business.Doctor24x7
{
    public class UserManager
    {
        public object JsonConvert { get; private set; }

        public UserLoginHttpResult Login(string id, string password)
        {
            var model = new UserLoginHttpRequest
            {
                id = id.Trim(),
                password = password
            };

            var client = new NetHttp();
            var headers = new Dictionary<string, string>();

            var result = client.Post<UserLoginHttpResult, UserLoginHttpRequest>("doctor/login", headers, model);
            return result;
        }

        public UserDetailsHttpResult GetUserDetailsIncludeClinic(string ownerId, string userId, string sessionId)
        {
            var client = new NetHttp();
            var headers = new Dictionary<string, string>();
            headers.Add("Content-Type", "application/json");
            headers.Add("userId", ownerId);
            headers.Add("sessionId", sessionId);
            var result = client.Get<UserDetailsHttpResult>(string.Format("user/{0}/get", userId), headers);
            return result;
        }

        public ScheduleHttpResult GetAvailableScheduleOfDoctor(string doctorId, string hospitalId, long? startDate,
            long? endDate, string userId, string sessionId)
        {
            var client = new NetHttp();
            var headers = new Dictionary<string, string>();
            headers.Add("Content-Type", "application/json");
            headers.Add("userId", userId);
            headers.Add("sessionId", sessionId);
            var path = string.Format("doctor/schedule/available?doctorId={0}&hospitalId={1}&startDate={2}&endDate={3}",
                doctorId,
                hospitalId,
                startDate,
                endDate);
            var result = client.Get<ScheduleHttpResult>(path, headers);
            return result;
        }


        public User GetPatientByEmail(string email, string userId, string sessionId)
        {
            var client = new NetHttp();
            var headers = new Dictionary<string, string>();
            headers.Add("Content-Type", "application/json");
            headers.Add("userId", userId);
            headers.Add("sessionId", sessionId);
            var path =
                string.Format(
                    "hospital/patients?search={0}&start=0&length=50&sortField=firstName&order=DESC&patientType=&status=0;1",
                    email);
            var result = client.Get<UserPatientHttpResult>(path, headers);
            if (result != null)
                return result.data.patients.FirstOrDefault();
            return null;
        }

        /// <summary>
        ///     UtHV
        ///     13032017 Lấy thông tin bệnh nhân từ Bs24x7 bằng mã code bệnh nhân để đồng bộ thông tin với soft local
        /// </summary>
        /// <param name="code"></param>
        /// <param name="userId"></param>
        /// <param name="sessionId"></param>
        /// <returns></returns>
        public User GetPatientByCode(string code, string userId, string sessionId)
        {
            var client = new NetHttp();
            var headers = new Dictionary<string, string>();
            headers.Add("Content-Type", "application/json");
            headers.Add("userId", userId);
            headers.Add("sessionId", sessionId);
            var path = string.Format("patient/getByCode?code={0}", code);
            var result = client.Get<UserPatientHttpResult>(path, headers);
            if (result != null)
                return result.data.profile;
            return null;
        }

        public string GetUrlImagePatient(string userId, string sessionId, string patientId)
        {
            var client = new NetHttp();
            var headers = new Dictionary<string, string>();
            headers.Add("Content-Type", "application/json");
            headers.Add("userId", userId);
            headers.Add("sessionId", sessionId);
            var path = string.Format("user/{0}/get", patientId);
            var result = client.Get<UserPatientHttpResult>(path, headers);
            if (result != null)
                return result.data.user.photo;
            return string.Empty;
        }

        public UserPatientHttpResult CheckOverlapPatient(PatientPostRequest model, string userId, string sessionId)
        {
            var client = new NetHttp();
            var headers = new Dictionary<string, string>();
            headers.Add("Content-Type", "application/json");
            headers.Add("userId", userId);
            headers.Add("sessionId", sessionId);
            var path = "patient/getOverlap";
            var result = client.Post<UserPatientHttpResult, PatientPostRequest>(path, headers, model);
            return result;
        }
        /// <summary>
        /// uthv 11052017
        /// Thống nhất rule search BYS và Bacsi24x7: sửa lại API gọi chung cho ứng dụng Bacsi24x7. Rule search: [tên (and) năm sinh (and) giới tính] (or) CMND (or) email (or) SĐT(contain 6 số).
        /// </summary>
        /// <param name="model"></param>
        /// <param name="userId"></param>
        /// <param name="sessionId"></param>
        /// <returns></returns>
        public UserPatientHttpResult CheckOverlapPatientv2(PatientPostRequest model, string userId, string sessionId)
        {
            var client = new NetHttp();
            var headers = new Dictionary<string, string>();
            headers.Add("Content-Type", "application/json");
            headers.Add("userId", userId);
            headers.Add("sessionId", sessionId);
            var path = "patients/searchByCondition";
            var result = client.Post<UserPatientHttpResult, PatientPostRequest>(path, headers, model);
            return result;
        }
        public JObject CreatePatient(PatientPostRequest model, string userid, string sessionid)
        {
            var _baseUrl = "https://healthcare.clas.mobi:8445/clas-healthcare-v2/";
            var path = "patient/signUpAuto";
            var httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Add("userId", userid);
            httpClient.DefaultRequestHeaders.Add("sessionId", sessionid);
            var multipart = new MultipartFormDataContent
            {
                {new StringContent(string.IsNullOrEmpty(model.firstName) ? "" : model.firstName), "firstName"},
                {new StringContent(string.IsNullOrEmpty(model.lastName) ? "" : model.lastName), "lastName"},
                {new StringContent(string.IsNullOrEmpty(model.gender) ? "" : model.gender), "gender"},
                {new StringContent(string.IsNullOrEmpty(model.idNo) ? "" : model.idNo), "idNo"},
                {new StringContent(string.IsNullOrEmpty(model.email) ? "" : model.email), "email"},
                {new StringContent(string.IsNullOrEmpty(model.address) ? "" : model.address), "address"},
                {new StringContent(string.IsNullOrEmpty(model.phone) ? "" : model.phone), "phone"},
                {new StringContent(string.IsNullOrEmpty(model.cityId) ? "" : model.cityId), "cityId"},
                {new StringContent(string.IsNullOrEmpty(model.districtId) ? "" : model.districtId), "districtId"},
                {new StringContent(string.IsNullOrEmpty(model.password) ? "123456" : model.password), "password"},
                {new StringContent(model.birthDay > 0 ? model.birthDay.ToString() : "0"), "birthDay"}
            };
            var result = httpClient.PostAsync(new Uri(_baseUrl + path), multipart).Result;
            var response =
                Newtonsoft.Json.JsonConvert.DeserializeObject<ApiResponse>(result.Content.ReadAsStringAsync().Result);
            if (!response.IsSuccessful)
            {
                //throw new ApiException(response.ErrorDescription, response.ErrorCode, cultureCode.Name);
            }
            return response.Data;
        }

        public JObject AddPatient(PatientPostRequest model, string userid, string sessionid, string hospitalId)
        {
            var baseUrl = SystemMemCache.GetSystemConfigValue(SysCfgConsts.PRIVATE, SysCfgConsts.PRIVATE_DOCTOR_24X7_HOST);
            //Save
            //var path = $"hospital/{hospitalId}/patient/signingup";
            var path = $"hospital/{hospitalId}/patient/save";
            var httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Add("userId", userid);
            httpClient.DefaultRequestHeaders.Add("sessionId", sessionid);
            var multipart = new MultipartFormDataContent
            {
                {new StringContent(string.IsNullOrEmpty(model.firstName) ? "" : model.firstName), "firstName"},
                {new StringContent(string.IsNullOrEmpty(model.lastName) ? "" : model.lastName), "lastName"},
                {new StringContent(string.IsNullOrEmpty(model.gender) ? "" : model.gender), "gender"},
                {new StringContent(string.IsNullOrEmpty(model.idNo) ? "" : model.idNo), "idNo"},
                {new StringContent(string.IsNullOrEmpty(model.email) ? "" : model.email), "email"},
                {new StringContent(string.IsNullOrEmpty(model.address) ? "" : model.address), "address"},
                {new StringContent(string.IsNullOrEmpty(model.phone) ? "" : model.phone), "phone"},
                {new StringContent(string.IsNullOrEmpty(model.cityId) ? "" : model.cityId), "cityId"},
                {new StringContent(string.IsNullOrEmpty(model.districtId) ? "" : model.districtId), "districtId"},
                {new StringContent(string.IsNullOrEmpty(model.password) ? "123456" : model.password), "password"},
                {new StringContent(model.birthDay > 0 ? model.birthDay.ToString() : "0"), "birthDay"}
            };
            var result = httpClient.PostAsync(new Uri(baseUrl + path), multipart).Result;
            var response =
                Newtonsoft.Json.JsonConvert.DeserializeObject<ApiResponse>(result.Content.ReadAsStringAsync().Result);
            if (!response.IsSuccessful)
            {
                return null;
            }

            return response.Data;
        }

        //public JObject CheckOverlapPatient(PatientPostRequest model, string userid, string sessionid)
        //{
        //    var client = new NetHttp();
        //    var _baseUrl = "https://healthcare.clas.mobi:8445/clas-healthcare-v2/";
        //    var path = "patient/getOverlap";
        //    var cultureCode = Thread.CurrentThread.CurrentCulture;
        //    var httpClient = new HttpClient();
        //    httpClient.DefaultRequestHeaders.Add("userId", userid);
        //    httpClient.DefaultRequestHeaders.Add("sessionId", sessionid);
        //    var multipart = new MultipartFormDataContent
        //    {
        //        {new StringContent(string.IsNullOrEmpty(model.firstName) ? "" : model.firstName), "firstName"},
        //        {new StringContent(string.IsNullOrEmpty(model.lastName) ? "" : model.lastName), "lastName"},
        //        {new StringContent(string.IsNullOrEmpty(model.gender) ? "" : model.gender), "gender"},
        //        {new StringContent(string.IsNullOrEmpty(model.idNo) ? "" : model.idNo), "idNo"},
        //        {new StringContent(string.IsNullOrEmpty(model.email) ? "" : model.email), "email"},
        //        {new StringContent(string.IsNullOrEmpty(model.address) ? "" : model.address), "address"},
        //        {new StringContent(string.IsNullOrEmpty(model.phone) ? "" : model.phone), "phone"},
        //        {new StringContent(string.IsNullOrEmpty(model.cityId) ? "" : model.cityId), "cityId"},
        //        {new StringContent(string.IsNullOrEmpty(model.districtId) ? "" : model.districtId), "districtId"},
        //        {new StringContent(string.IsNullOrEmpty(model.password) ? "123456" : model.password), "password"}
        //    };
        //    var result = httpClient.PostAsync(new Uri(_baseUrl + path), multipart).Result;
        //    var response =
        //        Newtonsoft.Json.JsonConvert.DeserializeObject<ApiResponse>(result.Content.ReadAsStringAsync().Result);
        //    if (!response.IsSuccessful)
        //    {
        //        //throw new ApiException(response.ErrorDescription, response.ErrorCode, cultureCode.Name);
        //    }
        //    return response.Data;
        //}

        public ListPatient GetListPatientByHospital(string hospitalId, string userId, string sessionId, int start,
            int lenght)
        {
            var client = new NetHttp();
            var headers = new Dictionary<string, string>
            {
                {"Content-Type", "application/json"},
                {"userId", userId},
                {"sessionId", sessionId}
            };
            return
                client.Get<ListPatient>(
                    $"hospital/patients?hospitalId={hospitalId}&search=&start={start}&length={lenght}&sortField=firstName&order=ASC&patientType=&status=0;1",
                    headers);
        }

        public SyncDataModel GetDataSycnByDate(string hospitalId, decimal latestSync, string userId, string sessionId)
        {
            var client = new NetHttp();
            var headers = new Dictionary<string, string>
            {
                {"Content-Type", "application/json"},
                {"userId", userId},
                {"sessionId", sessionId}
            };
            var result =
                client.Get<ResultSyncDataModel>(
                    $"hospital/getPatientsDoctorsCheckupTypes/time?hospitalId={hospitalId}&updatedDate={latestSync}&start=0&length=" + int.MaxValue,
                    headers);
            return result.successful ? result.data : null;
        }

        public HttpResult AddPatientToHospital(string mEPatientBs24x7ID, string bRBranchBacSi24x7Id, string userId,
            string sessionId)
        {
            var client = new NetHttp();
            var headers = new Dictionary<string, string>();
            headers.Add("Content-Type", "application/json");
            headers.Add("userId", userId);
            headers.Add("sessionId", sessionId);
            var path = "/patient/addToHospital";
            var model = new
            {
                id = mEPatientBs24x7ID,
                hospitalId = bRBranchBacSi24x7Id
            };
            var result = client.Post<HttpResult, object>(path, headers, model);
            return result;
        }
    }
}