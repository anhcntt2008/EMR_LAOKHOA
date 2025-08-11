using BOSCommon;
using BOSERP;
using BOSLib.DataAccess;
using Emr;
using Microsoft.AspNet.SignalR.Client;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOSBase
{
    public class SignalHubClient
    {
        private IHubProxy _hubProxy;
        private HubConnection _connection;
        private readonly string _endpoint;
        private readonly string _hubName;
        private readonly string _sessionToken;
        private readonly string _authToken;

        public SignalHubClient(string authToken, string sessionToken)
        {
            //uu tien lay cau hinh tu DB
            _endpoint = BOSApp.GetSystemConfigValue(SysCfgConsts.SYSTEM_CONFIGS, SysCfgConsts.SYSTEM_CONFIGS_SIGNAL_ENDPOINT);
            if (string.IsNullOrEmpty(_endpoint))
            {
                var configuration = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                _endpoint = SystemMemCache.GetSystemConfigValue(SysCfgConsts.PRIVATE, SysCfgConsts.PRIVATE_SIGNAL_HUB);// configuration.AppSettings.Settings["signal_hub"].Value.ToString();
                if (!_endpoint.EndsWith("signalr"))
                    _endpoint = _endpoint + (_endpoint.EndsWith("/") ? "signalr" : "/signalr");
            }
            _hubName = BOSApp.GetSystemConfigValue(SysCfgConsts.SYSTEM_CONFIGS, SysCfgConsts.SYSTEM_CONFIGS_SIGNAL_HUB_NAME);
            if (string.IsNullOrEmpty(_hubName))
                _hubName = "emrSignalHub";

            _sessionToken = sessionToken;
            _authToken = authToken;
        }

        public async Task ConnectAsync()
        {
            if (_connection == null)
            {
                var param = new Dictionary<string, string>
                {
                    { "type", EmrConsts.SIGNAL_HUB_CLIENT_TYPE },
                    { "SessionId", System.Web.HttpUtility.UrlEncode( _sessionToken) }
                };
                _connection = new HubConnection(_endpoint, param);
                // only use for http request, if websocket not required
                _connection.Headers.Add("Authorization", "Bearer " + _authToken);

                _connection.Closed += Connection_Closed;
                _connection.StateChanged += Connection_StateChanged;

                _hubProxy = _connection.CreateHubProxy(_hubName);
                //Handle incoming event from server: use Invoke to write to console from SignalR's thread
                _hubProxy.On<string>("signalAppUpdate", (msg) => this.OnRequestAppUpdate(msg));
                _hubProxy.On<string, string>("messageFromAdmin", (sender, msg) => this.OnCommonMessage(sender, msg));
                _hubProxy.On<string, string>("messageFromOther", (sender, msg) => this.OnCommonMessage(sender, msg));

                _hubProxy.On<string>("pongAppUpdate", (msg) => this.OnCommonMessage(EmrConsts.SYS_HUB_SENDER, msg));
                _hubProxy.On<string>("pongSendToAllClients", (msg) => this.OnCommonMessage(EmrConsts.SYS_HUB_SENDER, msg));
                _hubProxy.On<string>("pong", (msg) => this.OnCommonMessage(EmrConsts.SYS_HUB_SENDER, msg));

                _hubProxy.On<int, string, string, string>("onRequestRecoveryDocument", (emrId, file, hash, requestConnectId) => this.OnRequestRecoveryDocument(emrId, file, hash, requestConnectId));
            }
            try
            {
                await _connection.Start();
            }
            catch (Exception)
            {
                BOSApp.SignalHubStatus("ERROR");
                //Reconnect();
            }
        }

        private void Connection_StateChanged(StateChange obj)
        {
            BOSApp.SignalHubStatus(obj.NewState.ToString().ToUpper());
        }

        private void OnRequestRecoveryDocument(int emrId, string file, string hash, string requestConnectId)
        {
            Task.Factory.StartNew(async () =>
            {
                var result = await BOSApp.OnRequestRecoveryDocument(emrId, file, hash);
                if (result == -1) return;
                this.OnCommonMessage(EmrConsts.SYS_HUB_SENDER, "Nhận được yêu cầu phục hồi và đã tải lên tờ bệnh án tìm được");
                if (result == 1)
                {
                    Invoke("SentToOneConnection", requestConnectId, BOSApp.CurrentUser, $"Đã phục hồi thành công từ máy của {BOSApp.CurrentUser}");
                }
            });
        }
        private void OnCommonMessage(string sender, string msg)
        {
            BOSApp.OnCommonSignalMessage(sender, msg);
        }
        public void Invoke(string action, params object[] paramValues)
        {
            if (_connection.State != ConnectionState.Connected)
            {
                OnCommonMessage(EmrConsts.SYS_HUB_SENDER, "Mất kết nối với hệ thống xử lý tín hiệu");
                return;
            }
            Task.Run(async () =>
            {
                await _hubProxy.Invoke(action, paramValues);
            });
        }
        public void Connection_Closed()
        {
            Reconnect();
        }
        private void Reconnect()
        {
            Task.Run(async () =>
            {
                await Task.Delay(60 * 1000); //1 phut
                await this.ConnectAsync();
            });
        }

        private void OnRequestAppUpdate(string msg)
        {
            BOSApp.RequestAppUpdate(msg);
        }

        internal void Disconnect()
        {
            if (_connection == null) return;
            if (_connection.State != ConnectionState.Disconnected)
                _connection.Stop();
        }

    }

}
