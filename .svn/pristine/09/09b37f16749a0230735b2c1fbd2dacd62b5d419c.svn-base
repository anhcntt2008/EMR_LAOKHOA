using System.Collections.Generic;
using Clas.Model.Doctor24x7;
using Clas.Repository.HttpApi;

namespace Clas.Business.Doctor24x7
{
    public class CheckupTypeManager
    {
        public List<CheckupType> GetCheckupTypesByHospital(string hospitalId, string userId, string sessionId)
        {
            var netHttp = new NetHttp();
            var headers = new Dictionary<string, string>
            {
                {"Content-Type", "application/json"},
                {"userId", userId},
                {"sessionId", sessionId}
            };
            var result =
                netHttp.Get<CheckupTypeHttpResult>(
                    $"hospital/{hospitalId}/checkuptypes?start=0&length=" + int.MaxValue, headers);
            return result?.data?.checkupTypes;
        }
    }
}