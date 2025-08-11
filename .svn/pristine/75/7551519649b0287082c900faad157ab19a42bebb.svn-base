using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using Clas.Model.Logger;
using Clas.Repository.Logger;
using Newtonsoft.Json;
using RestSharp;
using Clas.Model.Base;
using BOSLib.DataAccess;
using BOSCommon;

namespace Clas.Repository.HttpApi
{
    /// <summary>
    ///     uthv
    ///     https://github.com/restsharp/RestSharp
    /// </summary>
    public class NetHttp
    {
        private const string _errorMessage = "Error retrieving response.  Check inner details for more info.";
        private readonly string _baseUrl = "https://healthcare.clas.mobi:8445/clas-healthcare-v2/";

        /// <summary>
        ///     default params to call to doctor24x7
        /// </summary>
        public NetHttp()
        {
            _baseUrl = SystemMemCache.GetSystemConfigValue(SysCfgConsts.PRIVATE, SysCfgConsts.PRIVATE_DOCTOR_24X7_HOST);
        }

        public NetHttp(string baseUrl)
        {
            _baseUrl = baseUrl;
        }

        public T PostToPath<T, U>(string path, IDictionary<string, string> header, U obj)
        {
            try
            {
                var client = new RestClient {BaseUrl = new Uri(path)};

                Func<RestRequest> requestFunc = () =>
                {
                    var request = new RestRequest(Method.POST);
                    if (header != null)
                        foreach (var item in header)
                            request.AddHeader(item.Key, item.Value);
                    request.AddJsonBody(obj);
                    return request;
                };

                var response = client.Execute(requestFunc());

                if (response.ErrorException != null)
                {
                    var ex = new ApplicationException(_errorMessage, response.ErrorException);
                    throw ex;
                }

                var result = JsonConvert.DeserializeObject<T>(response.Content);

                return result;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(GetType() + "-" + ex);
                FileLogger.WriteLog(LoggerLevel.ERROR, ex);
                throw ex;
            }
        }

        public T Post<T, U>(string path, IDictionary<string, string> header, U obj)
        {
            var json = string.Empty;
            try
            {
                var client = new RestClient();
                client.BaseUrl = new Uri(_baseUrl + path);

                Func<RestRequest> requestFunc = () =>
                {
                    var request = new RestRequest(Method.POST);
                    if (header != null)
                        foreach (var item in header)
                            request.AddHeader(item.Key, item.Value);
                    request.AddJsonBody(obj);
                    return request;
                };

                //var request = new RestRequest(Method.POST);
                //if (header != null)
                //    foreach (var item in header)
                //        request.AddHeader(item.Key, item.Value);
                //request.AddJsonBody(obj);

                var response = client.Execute(requestFunc());

                if (response.ErrorException != null)
                {
                    var ex = new ApplicationException(_errorMessage, response.ErrorException);
                    throw ex;
                }
                // UtHV chi check trong truong hop goi api cua bs24x7
                // cac truong hop khac khong can check session het han
                if (_baseUrl == SystemMemCache.GetSystemConfigValue(SysCfgConsts.PRIVATE, SysCfgConsts.PRIVATE_DOCTOR_24X7_HOST))
                    json = CheckUnauthAsync(response.Content, requestFunc, client);
                else
                    json = response.Content;

                var result = JsonConvert.DeserializeObject<T>(json);

                return result;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(GetType() + "-" + ex);
                FileLogger.WriteLog(LoggerLevel.ERROR, ex);
                throw ex;
            }
        }

        public T Get<T>(string path, IDictionary<string, string> header)
        {
            var json = string.Empty;
            try
            {
                var client = new RestClient();
                client.BaseUrl = new Uri(_baseUrl + path);

                Func<RestRequest> requestFunc = () =>
                {
                    var request = new RestRequest(Method.GET);
                    if (header != null)
                        foreach (var item in header)
                            request.AddHeader(item.Key, item.Value);
                    return request;
                };

                var response = client.Execute(requestFunc());
                if (response.ErrorException != null)
                {
                    var ex = new ApplicationException(_errorMessage, response.ErrorException);
                    throw ex;
                }

                // UtHV chi check trong truong hop goi api cua bs24x7
                // cac truong hop khac khong can check session het han
                if (_baseUrl == SystemMemCache.GetSystemConfigValue(SysCfgConsts.PRIVATE, SysCfgConsts.PRIVATE_DOCTOR_24X7_HOST))
                    json = CheckUnauthAsync(response.Content, requestFunc, client);
                else
                    json = response.Content;

                var result = JsonConvert.DeserializeObject<T>(json);

                return result;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(GetType() + "-" + ex);
                FileLogger.WriteLog(LoggerLevel.ERROR, ex);
                throw ex;
            }
        }

        private string CheckUnauthAsync(string content, Func<RestRequest> requestFunc, RestClient client)
        {
            var data = JsonConvert.DeserializeObject<HttpResult>(content);
            if (data != null)
                // FAILURE_SESSION_INVALID
                if (!data.successful && data.errorCode == 2)
                {
                    RestRequest requestMessage = RefreshTokenAndRetryIfUnauth(requestFunc());
                    if (requestMessage != null)
                    {
                        var response = client.Execute(requestMessage);
                        return response.Content;
                    }
                }
            return content;
        }

        private RestRequest RefreshTokenAndRetryIfUnauth(RestRequest restRequest)
        {
            var refreshApi = $"public/token/renew?hash={Clas.Model.Doctor24x7.CurrentUser.CurrentBacSi24X7.sessionId}&userId={Clas.Model.Doctor24x7.CurrentUser.CurrentBacSi24X7.userId}";
            var result = (new NetHttp()).Get<RefreshTokenResult>(refreshApi, null);
            if (result != null)
                if (result.successful)
                {
                    // replace session id
                    Clas.Model.Doctor24x7.CurrentUser.CurrentBacSi24X7.sessionId = result.data.hash;
                    for (int i = 0; i < restRequest.Parameters.Count; i++)
                    {
                        if (restRequest.Parameters[i].Name == "sessionId")
                        {
                            restRequest.Parameters.RemoveAt(i);
                            break;
                        }
                    }
                    restRequest.AddHeader("sessionId", result.data.hash);
                    return restRequest;
                }
            return null;
        }

        public KeyValue CheckNetworkToBs24x7()
        {
            //uthv mac dinh emr login local
            return new KeyValue(false);
            try
            {
                var client = new RestClient { BaseUrl = new Uri("https://healthcare.clas.mobi:8445/") };
                var request = new RestRequest(Method.GET);
                var response = client.Execute(request);
                return response.ErrorException != null ? new KeyValue(false, "Can not connect server") : new KeyValue(true);
            }
            catch (Exception e)
            {
                return new KeyValue(true, e.Message);
            }

        }


    }

    public class KeyValue
    {
        public bool IsNetwork;
        public string ErrorMessage;
        public KeyValue(bool isNetwork, string errorNetwork = null)
        {
            IsNetwork = isNetwork;
            ErrorMessage = errorNetwork;
        }
    }

    public class RefreshTokenResult : HttpResult
    {
        public RefreshTokenData data
        {
            get;
            set;
        }
    }

    public class RefreshTokenData
    {
        public string hash
        {
            get;
            set;
        }
    }
}