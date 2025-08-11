using System.Collections.Generic;
using Clas.Model.Base;
using Clas.Model.CHBase;
using Clas.Repository.HttpApi;

namespace Clas.Business.CHBase
{
    public class SendMailiHis
    {
        public bool SendMailRequest(MailRequestModel mailRequestModel, string userId, string sessionId)
        {
            var client = new NetHttp();
            var headers = new Dictionary<string, string>();
            headers.Add("Content-Type", "application/json");
            headers.Add("userId", userId);
            headers.Add("sessionId", sessionId);
            var result = client.Post<HttpResult, MailRequestModel>("IHIS/mail/shareInfo", headers, mailRequestModel);
            return result.successful;
        }
    }
}