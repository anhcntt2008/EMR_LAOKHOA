using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BOSLib;
using Clas.Model.MailBs24x7;
using Clas.Repository.HttpApi;

namespace Clas.Business.MailBs24x7
{
    public class MailServerManager
    {
        private readonly string _baseUrl;
        private readonly NetHttp _client;
        private UserModel _accLogin;
        public MailServerManager(UserModel model = null)
        {
            _baseUrl = ConfigurationManager.AppSettings["MailServerUrl"];
            _client = new NetHttp();
            _accLogin = model;
        }

        private UserModel GetDefaultModel()
        {
            var userNameEncrypt = ConfigurationManager.AppSettings["MailUserName"];
            var passwordEncrypt = ConfigurationManager.AppSettings["MailPassword"];
            Crypto cryp = new Crypto();
            var userName = cryp.Decrypt(userNameEncrypt) + "@bacsi24x7.vn";
            var password = cryp.Decrypt(passwordEncrypt);
            return  new UserModel(userName, password);
        }
        public ResultModel Login()
        {
            var urlLogin = $"{_baseUrl}api/Zimbra/Login";
            if (_accLogin == null)
            {
                _accLogin = GetDefaultModel();
            }
            return _client.PostToPath<ResultModel, UserModel>(urlLogin, null, _accLogin);
        }

        public ResultModel CreateAccount(UserModel model)
        {
            var urlCreateAccount = $"{_baseUrl}api/Zimbra/CreateAccount";
            return _client.PostToPath<ResultModel, UserModel>(urlCreateAccount, null, model);
        }
    }
}
