using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Clas.Model.Doctor24x7;
using Clas.Repository.HttpApi;

namespace Clas.Business.Doctor24x7
{
    public class CheckupManager
    {
        public CheckupHttpResult Checkup(string userId, string sessionId, CheckupPostModel model)
        {
            NetHttp client = new NetHttp();
            Dictionary<string, string> headers = new Dictionary<string, string>();
            headers.Add("Content-Type", "application/json");
            headers.Add("userId", userId);
            headers.Add("sessionId", sessionId);

            var result = client.Post<CheckupHttpResult, CheckupPostModel>("patient/checkupV2", headers, model);
            return result;
        }

        public CheckupHttpResult GetListCheckupOfHospital(string userId, string sessionId, string hospitalId, long startTime, long endTime)
        {
            NetHttp client = new NetHttp();
            Dictionary<string, string> headers = new Dictionary<string, string>();
            headers.Add("Content-Type", "application/json");
            headers.Add("userId", userId);
            headers.Add("sessionId", sessionId);

            var path = String.Format("doctor/checkups/byHospitalAndTime?doctorId={0}&hospitalId={1}&startDate={2}&endDate={3}", userId, hospitalId, startTime, endTime);
            var result = client.Get<CheckupHttpResult>(path, headers);
            return result;
        }
    }
}
