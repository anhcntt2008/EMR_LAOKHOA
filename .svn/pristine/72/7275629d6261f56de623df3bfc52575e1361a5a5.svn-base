using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Clas.Model.Doctor24x7;
using Clas.Repository.HttpApi;

namespace Clas.Business.Doctor24x7
{
    public class DoctorManager
    {
        public DoctorListHttpResult GetListDoctors(string userId, string sessionId, string hospitalId,
            bool? isOwner, int start, int length, string search,
            string sortField, string order, string status)
        {
            NetHttp client = new NetHttp();
            Dictionary<string, string> headers = new Dictionary<string, string>();
            headers.Add("Content-Type", "application/json");
            headers.Add("userId", userId);
            headers.Add("sessionId", sessionId);
            if (sortField == null || sortField == "")
                sortField = "firstName";
            if (order == null || order == "")
                order = "DESC";
            string query = String.Format("hospital/doctors?hospitalId={0}&isOwner={1}&search={2}&start={3}&length={4}&sortField={5}&order={6}&status={7}",
                hospitalId, isOwner, search, start, length, sortField, order, status);
            var result = client.Get<DoctorListHttpResult>(query, headers);
            return result;
        }
    }
}
