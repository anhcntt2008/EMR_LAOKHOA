using BOSCommon;
using BOSERP;
using BOSLib;
using Emr.Ca.Bkav;
using Emr.Ca.Core;
using Emr.Ca.eSign;
using Emr.Ca.VNPT;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Emr.Ca
{
    public class DigitalSignatureProvider
    {
        private readonly string _provider;
        private readonly ADSystemConfigsController _systemCfgCtrl;
        private readonly string _appPath;

        public DigitalSignatureProvider(string provider)
        {
            _provider = provider;
            _systemCfgCtrl = new ADSystemConfigsController();
            _appPath = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + "\\";
        }
        public IDigitalSignatureBase GetInstance()
        {
            var configs = _systemCfgCtrl.GetListByGroups($"'{_provider}'");
            var configDict = configs.ToDictionary(c => c.ADSystemConfigKey, c => c.ADSystemConfigValue);
            string p12Path, pw;

            switch (_provider)
            {
                case CaProviders.BKAV_CA:
                    p12Path = _appPath + configDict[BkavConfigKeys.BKAV_CA_X509CERTIFICATE2.ToString()];
                    pw = Cryptographier.Decrypt(configDict[BkavConfigKeys.BKAV_CA_X509CERTIFICATE2_PW.ToString()]);
                    var bkavSigner = new Bkav.DigitalSignatureBase(
                        configDict[BkavConfigKeys.BKAV_CA_URL.ToString()],
                        p12Path,
                        pw,
                        configDict[BkavConfigKeys.BKAV_CA_PARTNER_NAME.ToString()]
                        );
                    bkavSigner.TagName = GetConfigFromDict(configDict, BkavConfigKeys.BKAV_CA_TAG_NAME);
                    bkavSigner.VerifyDefaultUser = GetConfigFromDict(configDict, BkavConfigKeys.BKAV_CA_VERIFY_DEFAULT_USER);

                    bkavSigner.CoordinateX = GetConfigFromDict(configDict, BkavConfigKeys.BKAV_CA_COORDINATE_X);
                    bkavSigner.CoordinateY = GetConfigFromDict(configDict, BkavConfigKeys.BKAV_CA_COORDINATE_Y);
                    bkavSigner.SignatureWidth = GetConfigFromDict(configDict, BkavConfigKeys.BKAV_CA_SIGNATURE_WIDTH);
                    bkavSigner.SignatureHeight = GetConfigFromDict(configDict, BkavConfigKeys.BKAV_CA_SIGNATURE_HEIGHT);
                    bkavSigner.Location = GetConfigFromDict(configDict, BkavConfigKeys.BKAV_CA_LOCATION);
                    bkavSigner.Contact = GetConfigFromDict(configDict, BkavConfigKeys.BKAV_CA_CONTACT);

                    bkavSigner.FontSize = int.Parse(GetConfigFromDict(configDict, BkavConfigKeys.BKAV_CA_FONT_SIZE));
                    bkavSigner.TextColor = GetConfigFromDict(configDict, BkavConfigKeys.BKAV_CA_TEXT_COLOR);
                    bkavSigner.DefaultReason = GetConfigFromDict(configDict, BkavConfigKeys.BKAV_CA_DEFAULT_REASON);
                    bkavSigner.ShowReason = GetConfigFromDict(configDict, BkavConfigKeys.BKAV_CA_SHOW_REASON);
                    bkavSigner.UseExtensionFileOffice = bool.Parse(GetConfigFromDict(configDict, BkavConfigKeys.BKAV_CA_USE_EXTENSION_FILE_OFFICE));
                    bkavSigner.Version = GetConfigFromDict(configDict, BkavConfigKeys.BKAV_CA_VERSION);
                    return bkavSigner;

                case CaProviders.ESIGN_CA:
                    p12Path = _appPath + configDict[eSignConfigKeys.ESIGN_CA_X509CERTIFICATE2.ToString()];
                    string urlSign = SqlDatabaseHelper._HIS_SIGN_API_ENDPOINT;
                    pw = Cryptographier.Decrypt(configDict[eSignConfigKeys.ESIGN_CA_X509CERTIFICATE2_PW.ToString()]);
                    var eSigner = new eSign.DigitalSignatureBase(urlSign,
                        //configDict[eSignConfigKeys.ESIGN_CA_URL.ToString()],
                        configDict[eSignConfigKeys.ESIGN_CA_PARTY.ToString()],
                        configDict[eSignConfigKeys.ESIGN_CA_PARTY_USER.ToString()],
                        Cryptographier.Decrypt(configDict[eSignConfigKeys.ESIGN_CA_PARTY_PW.ToString()]),
                        configDict[eSignConfigKeys.ESIGN_CA_PARTY_SIGNATURE.ToString()],
                        p12Path,
                        pw);
                    eSigner.CoordinateX = int.Parse(GetConfigFromDict(configDict, eSignConfigKeys.ESIGN_CA_COORDINATE_X));
                    eSigner.CoordinateY = int.Parse(GetConfigFromDict(configDict, eSignConfigKeys.ESIGN_CA_COORDINATE_Y));
                    eSigner.SignatureWidth = int.Parse(GetConfigFromDict(configDict, eSignConfigKeys.ESIGN_CA_SIGNATURE_WIDTH));
                    eSigner.SignatureHeight = int.Parse(GetConfigFromDict(configDict, eSignConfigKeys.ESIGN_CA_SIGNATURE_HEIGHT));
                    eSigner.Location = GetConfigFromDict(configDict, eSignConfigKeys.ESIGN_CA_LOCATION);
                    eSigner.Contact = GetConfigFromDict(configDict, eSignConfigKeys.ESIGN_CA_CONTACT);
                    eSigner.FontSize = int.Parse(GetConfigFromDict(configDict, eSignConfigKeys.ESIGN_CA_FONT_SIZE));
                    eSigner.TextColor = GetConfigFromDict(configDict, eSignConfigKeys.ESIGN_CA_TEXT_COLOR);
                    eSigner.DefaultReason = GetConfigFromDict(configDict, eSignConfigKeys.ESIGN_CA_DEFAULT_REASON);
                    eSigner.TextDirection = GetConfigFromDict(configDict, eSignConfigKeys.ESIGN_CA_TEXT_DIRECTION);
                    eSigner.VisualStatus = GetConfigFromDict(configDict, eSignConfigKeys.ESIGN_CA_VISIBLE_SIGNATURE);
                    eSigner.ShowReason = GetConfigFromDict(configDict, eSignConfigKeys.ESIGN_CA_SHOW_REASON);
                    return eSigner;

                case CaProviders.VNPT_CA:
                    int countGetTranInfo = int.Parse(GetConfigFromDict(configDict, VNPTConfigKeys.VNPT_CA_COUNT_GET_TRAN_INFO)) + 10;
                    var vnptSigner = new VNPT.DigitalSignatureBase(configDict[VNPTConfigKeys.VNPT_CA_URL.ToString()], countGetTranInfo);
                    vnptSigner.CoordinateX = int.Parse(GetConfigFromDict(configDict, VNPTConfigKeys.VNPT_CA_COORDINATE_X));
                    vnptSigner.CoordinateY = int.Parse(GetConfigFromDict(configDict, VNPTConfigKeys.VNPT_CA_COORDINATE_Y));
                    vnptSigner.SignatureWidth = int.Parse(GetConfigFromDict(configDict, VNPTConfigKeys.VNPT_CA_SIGNATURE_WIDTH));
                    vnptSigner.SignatureHeight = int.Parse(GetConfigFromDict(configDict, VNPTConfigKeys.VNPT_CA_SIGNATURE_HEIGHT));
                    vnptSigner.Location = GetConfigFromDict(configDict, VNPTConfigKeys.VNPT_CA_LOCATION);
                    vnptSigner.Contact = GetConfigFromDict(configDict, VNPTConfigKeys.VNPT_CA_CONTACT);
                    vnptSigner.FontSize = int.Parse(GetConfigFromDict(configDict, VNPTConfigKeys.VNPT_CA_FONT_SIZE));
                    vnptSigner.FontStyle = GetConfigFromDict(configDict, VNPTConfigKeys.VNPT_CA_FONT_STYLE);
                    vnptSigner.FontName = GetConfigFromDict(configDict, VNPTConfigKeys.VNPT_CA_FONT_NAME);
                    vnptSigner.FontColor = GetConfigFromDict(configDict, VNPTConfigKeys.VNPT_CA_FONT_COLOR);
                    vnptSigner.DefaultReason = GetConfigFromDict(configDict, VNPTConfigKeys.VNPT_CA_DEFAULT_REASON);
                    vnptSigner.ShowReason = bool.Parse(GetConfigFromDict(configDict, VNPTConfigKeys.VNPT_CA_SHOW_REASON));
                    vnptSigner.Layer2Text = GetConfigFromDict(configDict, VNPTConfigKeys.VNPT_CA_LAYER2_TEXT);
                    vnptSigner.RenderMode = GetConfigFromDict(configDict, VNPTConfigKeys.VNPT_CA_RENDER_MODE);
                    vnptSigner.SignatureBorderType = GetConfigFromDict(configDict, VNPTConfigKeys.VNPT_CA_SIGNATURE_BORDER_TYPE);
                    vnptSigner.CountGetTranInfo = int.Parse(GetConfigFromDict(configDict, VNPTConfigKeys.VNPT_CA_COUNT_GET_TRAN_INFO));
                    vnptSigner.Page = int.Parse(GetConfigFromDict(configDict, VNPTConfigKeys.VNPT_CA_PAGE));
                    vnptSigner.EmployeeName = BOSApp.CurrentEmployeesInfo.HREmployeeName;

                    return vnptSigner;


                default:
                    throw new NotImplementedException();
            }
        }
        private string GetConfigFromDict(Dictionary<string, string> dict, string key)
        {
            dict.TryGetValue(key.ToString(), out string value);
            return value;
        }
    }
}
