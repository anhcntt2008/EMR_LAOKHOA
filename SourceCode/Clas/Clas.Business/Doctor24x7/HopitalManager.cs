using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Clas.Repository.HttpApi;
using Clas.Model.Doctor24x7;

namespace Clas.Business.Doctor24x7
{
    public class HopitalManager
    {
        public HospitalListResult GetListHopitals(string userId, string sessionId, int start, int length, bool getAdminUsers, string search)
        {
            NetHttp client = new NetHttp();
            Dictionary<string, string> headers = new Dictionary<string, string>();
            headers.Add("Content-Type", "application/json");
            headers.Add("userId", userId);
            headers.Add("sessionId", sessionId);
            var result = client.Get<HospitalListResult>(String.Format("hospitals?start={0}&length={1}&getAdminUsers={2}&search={3}", start, length, getAdminUsers, search), headers);
            return result;
        }

        public Hospital GetHospitalById(string userId, string sessionId, string id)
        {
            NetHttp client = new NetHttp();
            Dictionary<string, string> headers = new Dictionary<string, string>();
            headers.Add("Content-Type", "application/json");
            headers.Add("userId", userId);
            headers.Add("sessionId", sessionId);
            //clas-healthcare/hospital/950605c4-28f0-11e5-af73-c9d454f98ac7/get
            var result = client.Get<HospitalResult>($"hospital/{id}/get", headers);
            return result?.data.hospital;
        }

    }
}
