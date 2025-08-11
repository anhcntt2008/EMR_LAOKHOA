using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Clas.Repository.HttpApi;
using Clas.Model.DrugInfo;
using System.Configuration;
using BOSLib.DataAccess;
using BOSCommon;

namespace Clas.Business.DrugInfo
{
    public class DrugManager
    {
        private string _dugInfoUrl = "https://thongtinthuoc.com:8443/";
        private string _token = "216e6af7-64ed-4477-afde-7a97911c7c1a";
        public DrugManager()
        {
            _dugInfoUrl = SystemMemCache.GetSystemConfigValue(SysCfgConsts.PRIVATE, SysCfgConsts.PRIVATE_DRUG_INFO_HOST);
            _token = SystemMemCache.GetSystemConfigValue(SysCfgConsts.PRIVATE, SysCfgConsts.PRIVATE_DRUG_INFO_TOKEN);
        }
        public DrugCheckResult Check(DrugCheckRequest model)
        {
            NetHttp client = new NetHttp(_dugInfoUrl);
            Dictionary<string, string> headers = new Dictionary<string, string>();
            headers.Add("Content-Type", "application/json");
            headers.Add("Authorization", "Token " + _token);

            var result = client.Post<DrugCheckResult, DrugCheckRequest>("prescriptions/check", headers, model);
            return result;
        }
    }
}
