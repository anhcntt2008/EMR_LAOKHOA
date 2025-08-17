using BOSLib;
using BOSLib.DataAccess;
using Emr.Base.Models.Abp;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Clas.Emr.Intergration
{
    public class ApiHelper
    {
        private HttpClient _client;
        private readonly string _name;
        private string _endpoint;
        private string _token;
        private readonly string _unableConnect = "KHÔNG THỂ KẾT NỐI ĐẾN MÁY CHỦ HIS API.VUI LÒNG KIỂM TRA LẠI \n\n";

        public ApiHelper(int timeout = 100000)
        {
            System.Configuration.Configuration configuration = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            //this._endpoint = SystemMemCache.GetSystemConfigValue(BOSCommon.SysCfgConsts.PRIVATE, BOSCommon.SysCfgConsts.PRIVATE_HIS_API_ENDPOINT);
            this._endpoint = SqlDatabaseHelper._HIS_API_ENDPOINT;
            this._token = SystemMemCache.GetSystemConfigValue(BOSCommon.SysCfgConsts.PRIVATE, BOSCommon.SysCfgConsts.PRIVATE_HIS_API_TOKEN);
            this._client = new HttpClient();
            this._client.Timeout = TimeSpan.FromMilliseconds(timeout);
        }
        public ApiHelper(string endpoint, string token, string name = "HIS", int timeout = 100000)
        {
            System.Configuration.Configuration configuration = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            this._endpoint = endpoint;
            this._token = token;
            this._client = new HttpClient();
            this._name = name;
            this._unableConnect = $"KHÔNG THỂ KẾT NỐI ĐẾN MÁY CHỦ {name.ToUpper()} API.VUI LÒNG KIỂM TRA LẠI \n\n";
            this._client.Timeout = TimeSpan.FromMilliseconds(timeout);
        }
        public string GetHttpRequestMessageString(string uri, Dictionary<string, object> paramList)
        {
            return GetHttpRequestMessage(uri, paramList, HttpMethod.Get).ToString();
        }
        public HttpRequestMessage GetHttpRequestMessage(string uri, Dictionary<string, object> paramList, HttpMethod method)
        {
            var url = string.Empty;
            var paramStr = GetUrlParams(paramList);

            if (uri.StartsWith("http://") || uri.StartsWith("https://"))
                url = uri;
            else
                url = string.Format("{0}/{1}", this._endpoint, uri);

            if (!string.IsNullOrEmpty(paramStr))
                url += ("?" + paramStr);

            var requestMsg = new HttpRequestMessage(method, url);

            if (!string.IsNullOrEmpty(_token))
            {
                requestMsg.Headers.Add("Authorization", "Bearer " + this._token);
                requestMsg.Headers.Add("token", this._token);
            }
            return requestMsg;
        }
        public object Get(string uri, Dictionary<string, object> paramList)
        {
            var requestMsg = GetHttpRequestMessage(uri, paramList, HttpMethod.Get);
            string responseString = string.Empty;
            try
            {
                var response = this._client.SendAsync(requestMsg).Result;
                if (response.IsSuccessStatusCode)
                {
                    var responseContent = response.Content;
                    responseString = responseContent.ReadAsStringAsync().Result;
                    //TODO hard code Can Tho
                    //if (responseString.Contains("Error")) return null;
                    return JsonConvert.DeserializeObject(responseString);
                }
                else
                {
                    LogErr(requestMsg, null);
                }
            }
            catch (Exception e)
            {
                LogErr(requestMsg, null, e);
                var baseEx = e.GetBaseException();
                if (baseEx != null && baseEx.InnerException != null && baseEx.InnerException.Message == "Unable to connect to the remote server")
                {
                    throw new Exception(_unableConnect);
                }
                throw e;
            }
            return null;
        }

        public AjaxResponse<T> Get<AjaxResponse, T>(string uri, Dictionary<string, object> paramList) where T : class
        {
            var requestMsg = GetHttpRequestMessage(uri, paramList, HttpMethod.Get);
            try
            {
                var response = this._client.SendAsync(requestMsg).Result;
                string json = response.Content.ReadAsStringAsync().Result;

                if (response.IsSuccessStatusCode)
                {
                    if (typeof(T).Equals(typeof(string)))
                    {
                        var result = JsonConvert.DeserializeObject<AjaxResponse<string>>(json);
                        return result as AjaxResponse<T>;
                    }
                    return JsonConvert.DeserializeObject<AjaxResponse<T>>(json);
                }
                // api throw UserFriendlyException
                else if (response.StatusCode == System.Net.HttpStatusCode.InternalServerError)
                {
                    var error = JsonConvert.DeserializeObject<AjaxResponse<object>>(json);
                    if (error == null)
                        throw new Exception(response.ReasonPhrase);
                    // TH T khong phai AjaxResponse se nhan ve null
                    return new AjaxResponse<T>(error.Error, error.UnAuthorizedRequest);
                }
                else
                {
                    LogErr(requestMsg, null);
                }
            }
            catch (Exception e)
            {
                LogErr(requestMsg, null, e);
                var baseEx = e.GetBaseException();
                if (baseEx != null && baseEx.InnerException != null && baseEx.InnerException.Message == "Unable to connect to the remote server")
                {
                    throw new Exception(_unableConnect);
                }
                throw e;
            }
            return null;
        }

        public List<Dictionary<string, object>> GetList(string uri, Dictionary<string, object> paramList)
        {
            var requestMsg = GetHttpRequestMessage(uri, paramList, HttpMethod.Get);
            try
            {
                var response = this._client.SendAsync(requestMsg).Result;
                if (response.IsSuccessStatusCode)
                {
                    var responseContent = response.Content;
                    string responseString = responseContent.ReadAsStringAsync().Result;
                    //TODO hard code Can Tho
                    //if (responseString.Contains("Error")) return null;
                    return JsonConvert.DeserializeObject<List<Dictionary<string, object>>>(responseString);
                }
                else
                {
                    LogErr(requestMsg, null);
                }
            }
            catch (Exception e)
            {
                LogErr(requestMsg, null, e);
                var baseEx = e.GetBaseException();
                if (baseEx != null && baseEx.InnerException != null && baseEx.InnerException.Message == "Unable to connect to the remote server")
                {
                    throw new Exception(_unableConnect);
                }
                throw e;
            }
            return null;
        }
        public List<Dictionary<string, object>> PostAndGetList(string uri, Dictionary<string, object> paramList, object body, string contentType = "application/json")
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
                    //if (responseString.Contains("Error")) return null;
                    return JsonConvert.DeserializeObject<List<Dictionary<string, object>>>(responseString);
                }
                else
                {
                    LogErr(requestMsg, body);
                }
            }
            catch (Exception e)
            {
                LogErr(requestMsg, body, e);
                var baseEx = e.GetBaseException();
                if (baseEx != null && baseEx.InnerException != null && baseEx.InnerException.Message == "Unable to connect to the remote server")
                {
                    throw new Exception(_unableConnect);
                }
                throw e;
            }
            return null;
        }

        public object Post(string uri, Dictionary<string, object> paramList, object body, string contentType = "application/json")
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
                    //if (responseString.Contains("Error")) return null;
                    return JsonConvert.DeserializeObject(responseString);
                }
                else
                {
                    LogErr(requestMsg, body);
                }
            }
            catch (Exception e)
            {
                LogErr(requestMsg, body, e);
                var baseEx = e.GetBaseException();
                if (baseEx != null && baseEx.InnerException != null && baseEx.InnerException.Message == "Unable to connect to the remote server")
                {
                    throw new Exception(_unableConnect);
                }
                throw e;
            }
            return null;
        }
        public AjaxResponse<T> Post<AjaxResponse, T>(string uri, Dictionary<string, object> paramList, object body, string contentType = "application/json") where T : class
        {
            var requestMsg = GetHttpRequestMessage(uri, paramList, HttpMethod.Post);
            requestMsg.Content = new StringContent(JsonConvert.SerializeObject(body, Formatting.Indented), Encoding.UTF8, contentType);
            try
            {
                var response = this._client.SendAsync(requestMsg).Result;
                string json = response.Content.ReadAsStringAsync().Result;

                if (response.IsSuccessStatusCode)
                {
                    if (typeof(T).Equals(typeof(string)))
                    {
                        var result = JsonConvert.DeserializeObject<AjaxResponse<string>>(json);
                        return result as AjaxResponse<T>;
                    }
                    return JsonConvert.DeserializeObject<AjaxResponse<T>>(json);
                }
                // api throw UserFriendlyException
                else if (response.StatusCode == System.Net.HttpStatusCode.InternalServerError)
                {
                    var error = JsonConvert.DeserializeObject<AjaxResponse<object>>(json);
                    if (error == null)
                        throw new Exception(response.ReasonPhrase);
                    // TH T khong phai AjaxResponse se nhan ve null
                    return new AjaxResponse<T>(error.Error, error.UnAuthorizedRequest);
                }
                else
                {
                    LogErr(requestMsg, body);
                }
            }
            catch (Exception e)
            {
                LogErr(requestMsg, body, e);
                var baseEx = e.GetBaseException();
                if (baseEx != null && baseEx.InnerException != null && baseEx.InnerException.Message == "Unable to connect to the remote server")
                {
                    throw new Exception(_unableConnect);
                }
                throw e;
            }
            return null;
        }
        private void LogErr(HttpRequestMessage requestMsg, object body, Exception e = null)
        {
            if (body != null)
            {
                var type = body.GetType();
                var pw = type.GetProperty("password");
                if (pw != null) body = null;
                type.GetProperty("pass");
                if (pw != null) body = null;
                type.GetProperty("Pass");
                if (pw != null) body = null;
            }

            Trace.TraceError("API ERROR: {0}\t{1}\t{2}\tBODY:{3}\t{4}",
                DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss"),
                requestMsg.Method,
                requestMsg.RequestUri,
                JsonConvert.SerializeObject(body, Formatting.Indented),
                e);
        }

        private string GetUrlParams(Dictionary<string, object> paramList)
        {
            if (paramList == null) return string.Empty;
            return string.Join("&", paramList.Select(p =>
            {
                var value = string.Empty;
                if (p.Value != null)
                    if (p.Value is DateTime)
                        value = ((DateTime)p.Value).ToString("O");
                    else
                        value = p.Value.ToString();

                return p.Key + "=" + HttpUtility.UrlEncode(value);
            }));
        }
    }
}
