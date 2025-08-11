using System.Configuration;
using Clas.Model.CHBase;
using Clas.Repository.HttpApi;

namespace Clas.Business.CHBase
{
    public class CHBaseManager
    {
        private readonly string _baseUrl;
        private readonly NetHttp _client;

        public CHBaseManager()
        {
            _client = new NetHttp();
            _baseUrl = ConfigurationManager.AppSettings["CHbaseApiUrl"];
        }

        public ApiResult CreateAccount(AccountModel model)
        {
            var url = $"{_baseUrl}CreateAccount";
            return _client.PostToPath<ApiResult, AccountModel>(url, null, model);
        }
    }
}