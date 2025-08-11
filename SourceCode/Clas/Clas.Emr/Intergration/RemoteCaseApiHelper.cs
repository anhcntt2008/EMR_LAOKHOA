using BOSLib.DataAccess;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Clas.Emr.Intergration
{
    public class RemoteCaseApiHelper
    {
        private HttpClient _client;
        private string _endpoint;
        //private string _token;
        public string _customerId;
        public string _tenantId;

        public RemoteCaseApiHelper()
        {
            System.Configuration.Configuration configuration = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            this._endpoint = SystemMemCache.GetSystemConfigValue(BOSCommon.SysCfgConsts.PRIVATE, BOSCommon.SysCfgConsts.PRIVATE_RC_API_ENDPOINT);
            this._customerId = SystemMemCache.GetSystemConfigValue(BOSCommon.SysCfgConsts.PRIVATE, BOSCommon.SysCfgConsts.PRIVATE_RC_CUSTOMER_ID);
            this._tenantId = SystemMemCache.GetSystemConfigValue(BOSCommon.SysCfgConsts.PRIVATE, BOSCommon.SysCfgConsts.PRIVATE_RC_TENAN_ID);
            this._client = new HttpClient();
            this._client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }
        public string GetHttpRequestMessageString(string uri, Dictionary<string, object> paramList)
        {
            return GetHttpRequestMessage(uri, paramList, HttpMethod.Get).ToString();
        }
        public HttpRequestMessage GetHttpRequestMessage(string uri, Dictionary<string, object> paramList, HttpMethod method)
        {
            var url = (uri.Contains("http://") || uri.Contains("https://")) ? uri : string.Format("{0}/{1}{2}", this._endpoint, uri, GetUrlParams(paramList));
            var requestMsg = new HttpRequestMessage(method, url);
            //requestMsg.Headers.Add("token", this._token);
            return requestMsg;
        }
        public Dictionary<string, object> Get(string uri, Dictionary<string, object> paramList)
        {
            var requestMsg = GetHttpRequestMessage(uri, paramList, HttpMethod.Get);
            try
            {
                var response = this._client.SendAsync(requestMsg).Result;
                if (response.IsSuccessStatusCode)
                {
                    var responseContent = response.Content;
                    string responseString = responseContent.ReadAsStringAsync().Result;
                    return JsonConvert.DeserializeObject<Dictionary<string, object>>(responseString);
                }
                else
                {
                    Trace.TraceError("RC_API ERROR: {0}:{1}", DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss"), response);
                }
            }
            catch (Exception e)
            {
                Trace.TraceError("RC_API ERROR: {0}:{1}", DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss"), e);
                throw e;
            }
            return null;
        }
        public T Post<T>(string uri, Dictionary<string, object> paramList, object body, string contentType = "application/json")
        {
            var requestMsg = GetHttpRequestMessage(uri, paramList, HttpMethod.Post);
            requestMsg.Content = new StringContent(JsonConvert.SerializeObject(body, Formatting.Indented), Encoding.UTF8, contentType);
            try
            {
                var response = this._client.SendAsync(requestMsg).Result;
                if (response.IsSuccessStatusCode)
                {
                    var responseContent = response.Content;
                    string responseString = responseContent.ReadAsStringAsync().Result;
                    return JsonConvert.DeserializeObject<T>(responseString);
                }
                else
                {
                    Trace.TraceError("RC_API ERROR: {0}:{1}", DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss"), response);
                }
            }
            catch (Exception e)
            {
                Trace.TraceError("RC_API ERROR: {0}:{1}", DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss"), e);
                throw e;
            }
            return default(T);
        }

        private string GetUrlParams(Dictionary<string, object> paramList)
        {
            if (paramList == null || paramList.Count == 0) return string.Empty;
            return "?" + string.Join("&", paramList.Select(p => p.Key + "=" + HttpUtility.UrlEncode(p.Value == null ? "" : p.Value.ToString())));
        }
    }
}
