using BOSCommon;
using BOSLib.DataAccess;
using System.Configuration;

namespace Clas.Emr.Intergration
{
    public class IpcHelper
    {
        private readonly string _sentToChannel;

        public IpcHelper()
        {
            _sentToChannel = SystemMemCache.GetSystemConfigValue(SysCfgConsts.PRIVATE, SysCfgConsts.PRIVATE_EMR_SEND_TO_CHANNEL);
        }
        public void SendMessage(string uri, string message, string type = "Json")
        {
            Clas.Emr.Ipc.Net.Messaging.IpcBroadcast.SendToChannel(_sentToChannel, message, type);
        }
    }
}
