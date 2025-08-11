using Emr.Ca.Core;
using Emr.Ca.eSign.eSignServiceReference;
using iTextSharp.text.pdf;
using iTextSharp.text.pdf.security;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.IO.Packaging;
using System.Linq;
using System.Net;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using lib.rssp.exsig;
using lib.rssp.exsig.pdf;
using lib.rssp.sign;
using Newtonsoft.Json;

namespace Emr.Ca.eSign
{
    public class DigitalSignatureBase : DigitalSignatureReader, IDigitalSignatureBase
    {
        private readonly string _url;
        private readonly string _relyingParty;
        private readonly string _relyingPartyUser;
        private readonly string _relyingPartyPassword;
        private readonly string _relyingPartySignature;
        private readonly string _relyingPartyKeyStore;
        private readonly string _relyingPartyKeyStorePassword;
        private static readonly DateTime Jan1st1970 = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
        private readonly ServicesClient _service;

        public string TextColor { get; set; }
        public string DefaultReason { get; set; }
        public string Contact { get; set; }
        public string Location { get; set; }
        public int CoordinateX { get; set; }
        public int CoordinateY { get; set; }
        public int SignatureWidth { get; set; }
        public int SignatureHeight { get; set; }
        public int FontSize { get; set; }
        public string VisualStatus { get; set; }
        public string TextDirection { get; set; }
        public string ShowReason { get; set; }
        public string urlHSM = "";
        public DigitalSignatureBase(
            string url,
            string relyingParty,
            string relyingPartyUser,
            string relyingPartyPassword,
            string relyingPartySignature,
            string relyingPartyKeyStore,
            string relyingPartyKeyStorePassword)
        {
            _url = url; // "https://trusted-hub.com:8443/eSignCloud/Services?wsdl";
            _relyingParty = relyingParty;// "LKHOSPITAL";
            _relyingPartyUser = relyingPartyUser;// "lkhospital";
            _relyingPartyPassword = relyingPartyPassword;// "lkhospital2019@esigncloud";
            _relyingPartySignature = relyingPartySignature;// "aCiPiDxEIfoWajqE+k4CCnf0pUcLi7NxgNGq5hQYC26RtD+oauzwYblLU5oRTUM7YhLsfzXlCJ6VSgTFQze8vYw5x0ct4ReB5jP+1kb1RoCP+BT4rjQYxWhsWlF5h6RhER24CzFLUx4hv4TssxuHNq9WtDcEIZww17qe8KkMGPjTy7xQPkxJLIaf9c1ZPymrhfINa0wytDSSYY4NZH5YvuJfoAGZsRfuoyRbwxxoDteVRl5eQ/QyJtrHNRVMYBEkg+ONzsS4KRX9dnmk0A1oJYPA63m6ppXHsx3TZtxGieS0uYUyYfMTQlySo65TwlM7ZsH+hu5twqYv4kio3jPSpQ==";
            _relyingPartyKeyStore = relyingPartyKeyStore;// "file\\cloudfca.p12";
            _relyingPartyKeyStorePassword = relyingPartyKeyStorePassword; // "12345678";

            ServicePointManager.CheckCertificateRevocationList = false;
            ServicePointManager.ServerCertificateValidationCallback = (a, b, c, d) => true;
            ServicePointManager.Expect100Continue = true;
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            ServicePointManager.DefaultConnectionLimit = 9999;

            var binding = new BasicHttpBinding("eSignCAServicesPortBinding");
            var address = new EndpointAddress(_url);
            _service = new ServicesClient(binding, address); 


        }
        private static long CurrentTimeMillis()
        {
            return (long)(DateTime.UtcNow - Jan1st1970).TotalMilliseconds;
        }

        private static string getPKCS1Signature(string data, string key, string passkey)
        {
            MakeSignature mks = new MakeSignature(data, key, passkey);
            return mks.getSignature();
        }

        private static long nanoTime()
        {
            long nano = 10000L * Stopwatch.GetTimestamp();
            nano /= TimeSpan.TicksPerMillisecond;
            nano *= 100L;
            return nano;
        }

        public string PdfSigner(byte[] dataToSign, SignerParammeterBase parammeters, PdfSignerPropertyBase properties)
        {
            if (parammeters.Method == "CAViettelHash")
            {
                List<byte[]> src = new List<byte[]>
                {
                    dataToSign
                };

                SoapConnectorImp connector = new SoapConnectorImp(Algorithm.SHA256, _url, _relyingParty, _relyingPartyUser, _relyingPartyPassword, _relyingPartySignature, _relyingPartyKeyStore, _relyingPartyKeyStorePassword, parammeters.AgreementUUID, parammeters.AuthorizeCode);


                PdfProfile profile = new PdfProfile(PdfForm.B, Algorithm.SHA256);

                if (!string.IsNullOrEmpty(properties.SignatureImage))
                {
                    profile.SetImage(Convert.FromBase64String(properties.SignatureImage), ImageProfile.IMAGE_LEFT);
                }
                var location = (!string.IsNullOrEmpty(properties.Contact) ? properties.Contact : this.Contact) + ", " + (!string.IsNullOrEmpty(properties.Location) ? properties.Location : this.Location);
                profile.SetLocation(location);

                //profile.SetSigningTime(CurrentTimeMillis());
                profile.SetSigningTime(DateTime.Now, "yyyy-MM-dd HH:mm:ss");

                profile.SetTextContent("Ký bởi: {signby}\nKý ngày: {date}\nNơi ký: {location}");
                profile.SetFont(DefaultFont.D_Times, 6, 1.2f, TextAlignment.ALIGN_LEFT, DefaultColor.BLACK);

                var countSignature = this.GetCountSignatureFields(dataToSign, "pdf");
                properties.Width = properties.Width > 0 ? properties.Width : this.SignatureWidth;
                properties.Height = properties.Height > 0 ? properties.Height : this.SignatureHeight;
                properties.CoordinateX = properties.CoordinateX > 0 ? properties.CoordinateX : this.CoordinateX;
                properties.CoordinateY = properties.CoordinateY > 0 ? properties.CoordinateY : this.CoordinateY;
                // co the co nhieu chu ky
                var padding = (properties.Width + 5) * countSignature;
                var coordinate = (properties.CoordinateX + padding).ToString();
                coordinate += ",";
                coordinate += properties.CoordinateY.ToString();
                coordinate += ",";
                coordinate += (properties.CoordinateX + padding + properties.Width).ToString();
                coordinate += ",";
                coordinate += (properties.CoordinateY + properties.Height).ToString();
                var colorStr = GetKnownColor(properties.TextColor);
             
                if (this.ShowReason?.ToLower() == "true")
                {
                    profile.SetReason(properties.Reason);
                }
                

                //profile.SetCheckMark(false); // before true
                if (properties.Visible.ToString().ToUpper() == "TRUE")
                {
                    profile.SetVisibleSignature(properties.Page.ToString(), coordinate);
                }
                
                try
                {
                    src = profile.Sign(connector, src);
                    return Convert.ToBase64String(src[0]);
                }
                catch (Exception ex)
                {
                    throw new SignerCustomException(1, ex.Message);
                }
            }
            else
            {
                var timestamp = CurrentTimeMillis().ToString();
                var data2sign = _relyingPartyUser + _relyingPartyPassword + _relyingPartySignature + timestamp;
                var pkcs1Signature = getPKCS1Signature(data2sign, _relyingPartyKeyStore, _relyingPartyKeyStorePassword);

                var credentialData = new credentialData
                {
                    username = _relyingPartyUser,
                    password = _relyingPartyPassword,
                    timestamp = timestamp,
                    signature = _relyingPartySignature,
                    pkcs1Signature = pkcs1Signature
                };

                var request = new signCloudReq
                {
                    relyingParty = _relyingParty,
                    agreementUUID = parammeters.AgreementUUID,
                    authorizeMethod = ESignCloudConstant.AUTHORISATION_METHOD_PASSCODE,
                    authorizeCode = parammeters.AuthorizeCode,
                    messagingMode = ESignCloudConstant.SYNCHRONOUS,

                    signingFileData = dataToSign,
                    signingFileName = parammeters.FileName,
                    mimeType = ESignCloudConstant.MIMETYPE_PDF,
                    credentialData = credentialData
                };
                var countSignature = this.GetCountSignatureFields(dataToSign, "pdf");

                properties.Width = properties.Width > 0 ? properties.Width : this.SignatureWidth;
                properties.Height = properties.Height > 0 ? properties.Height : this.SignatureHeight;
                properties.CoordinateX = properties.CoordinateX > 0 ? properties.CoordinateX : this.CoordinateX;
                properties.CoordinateY = properties.CoordinateY > 0 ? properties.CoordinateY : this.CoordinateY;

                // co the co nhieu chu ky
                var padding = (properties.Width + 5) * countSignature;

                var coordinate = (properties.CoordinateX + padding).ToString();
                coordinate += ",";
                coordinate += properties.CoordinateY.ToString();
                coordinate += ",";
                coordinate += (properties.CoordinateX + padding + properties.Width).ToString();
                coordinate += ",";
                coordinate += (properties.CoordinateY + properties.Height).ToString();

                var colorStr = GetKnownColor(properties.TextColor);

                var signMetas = new List<signCloudMetaDataEntry1>
            {
                new signCloudMetaDataEntry1
                {
                    key = "COUNTERSIGNENABLED",
                    value = "False"
                },
                new signCloudMetaDataEntry1
                {
                    key = "PAGENO",
                    value = properties.Page.ToString()// "First"// "Last"
                },
                new signCloudMetaDataEntry1
                {
                    key = "COORDINATE",
                    value = coordinate, //"150,280,330,360"
                },
                new signCloudMetaDataEntry1
                {
                    key = "VISIBLESIGNATURE",
                    value = properties.Visible.ToString()// "True"
                },
                new signCloudMetaDataEntry1
                {
                    key = "VISUALSTATUS",
                    value = (this.VisualStatus?.ToLower() == "false") ? "False" : "True"
                },
                new signCloudMetaDataEntry1
                {
                    key = "IMAGEANDTEXT",
                    value = "True"
                },
                new signCloudMetaDataEntry1
                {
                    key = "TEXTDIRECTION",
                    value = string.IsNullOrEmpty(this.TextDirection) ? "RIGHTTOLEFT" : this.TextDirection //"RIGHTTOLEFT"//"LEFTTORIGHT"
                },
                new signCloudMetaDataEntry1
                {
                    key = "SHOWSIGNERINFO",
                    value = "True"
                },
                new signCloudMetaDataEntry1
                {
                    key = "SIGNERINFOPREFIX",
                    value = "Ký bởi:"
                },
                new signCloudMetaDataEntry1
                {
                    key = "SHOWDATETIME",
                    value = "True"
                },
                new signCloudMetaDataEntry1
                {
                    key = "DATETIMEPREFIX",
                    value = "Ký ngày:"
                },
                new signCloudMetaDataEntry1
                {
                    key = "SHOWREASON",
                    value = (this.ShowReason?.ToLower() == "false") ? "False" : "True"
                },
                new signCloudMetaDataEntry1
                {
                    key = "SIGNREASONPREFIX",
                    value = "Lý do:"
                },
                new signCloudMetaDataEntry1
                {
                    key = "SIGNREASON",
                    value =  properties.Reason, //"Đồng ý các điều khoản HĐ"
                },
                new signCloudMetaDataEntry1
                {
                    key = "SHOWLOCATION",
                    value = "True"
                },
                new signCloudMetaDataEntry1
                {
                    key = "LOCATION",
                    value =   (!string.IsNullOrEmpty(properties.Contact) ? properties.Contact : this.Contact)
                    +", "
                    +  (!string.IsNullOrEmpty(properties.Location) ? properties.Location : this.Location),
                },
                new signCloudMetaDataEntry1
                {
                    key = "LOCATIONPREFIX",
                    value = "Nơi ký:"
                },
                new signCloudMetaDataEntry1
                {
                    key = "TEXTCOLOR",
                    value = colorStr
                },
                new signCloudMetaDataEntry1
                {
                    key = "LOCKAFTERSIGNING",
                    value = "False"
                }
            };
                if (!string.IsNullOrEmpty(properties.SignatureImage))
                {
                    signMetas.Add(new signCloudMetaDataEntry1
                    {
                        key = "SIGNATUREIMAGE",
                        value = properties.SignatureImage
                    });
                }
                request.signCloudMetaData = new signCloudMetaData
                {
                    singletonSigning = signMetas.ToArray()
                };
                var response = _service.prepareFileForSignCloud(request);
                // TODO 1018 SUCCESSFULLY YOUR PASSCODE NEED TO BE CHANGED
                if (response.responseCode == 0 || response.responseCode == 1018)
                    return Convert.ToBase64String(response.signedFileData);
                else
                {
                    if (ESignCloudConstant.ResponseMessages.ContainsKey(response.responseCode))
                        throw new SignerCustomException(response.responseCode, ESignCloudConstant.ResponseMessages[response.responseCode]);

                    throw new SignerCustomException(response.responseCode, response.responseMessage);
                }
            }
        }
        public List<string> ListPdfSigner(List<byte[]> dataListToSign, SignerParammeterBase parammeters, PdfSignerPropertyBase properties)
        {
            return null;
        }
        private string GetKnownColor(int color)
        {
            var colorStr = this.TextColor;
            var argb = Color.FromArgb(color);
            foreach (KnownColor kc in Enum.GetValues(typeof(KnownColor)))
            {
                Color known = Color.FromKnownColor(kc);
                if (argb.ToArgb() == known.ToArgb())
                {
                    colorStr = known.Name.ToLower();
                    break;
                }
            }
            return colorStr;
        }
        public string FileSigner(byte[] dataToSign, string extensionFile, SignerParammeterBase parammeters)
        {
            var timestamp = CurrentTimeMillis().ToString();
            var data2sign = _relyingPartyUser + _relyingPartyPassword + _relyingPartySignature + timestamp;
            var pkcs1Signature = getPKCS1Signature(data2sign, _relyingPartyKeyStore, _relyingPartyKeyStorePassword);

            var credentialData = new credentialData
            {
                username = _relyingPartyUser,
                password = _relyingPartyPassword,
                timestamp = timestamp,
                signature = _relyingPartySignature,
                pkcs1Signature = pkcs1Signature
            };

            var request = new signCloudReq
            {
                relyingParty = _relyingParty,
                agreementUUID = parammeters.AgreementUUID,
                authorizeMethod = ESignCloudConstant.AUTHORISATION_METHOD_PASSCODE,
                authorizeCode = parammeters.AuthorizeCode,
                messagingMode = ESignCloudConstant.SYNCHRONOUS,

                signingFileData = dataToSign,
                signingFileName = parammeters.FileName,
                mimeType = ESignCloudConstant.MIMETYPE_BINARY_WORD,
                credentialData = credentialData
            };

            var response = _service.prepareFileForSignCloud(request);
            // TODO 1018 SUCCESSFULLY YOUR PASSCODE NEED TO BE CHANGED
            if (response.responseCode == 0 || response.responseCode == 1018)
                return Convert.ToBase64String(response.signedFileData);
            else
            {
                if (ESignCloudConstant.ResponseMessages.ContainsKey(response.responseCode))
                    throw new SignerCustomException(response.responseCode, ESignCloudConstant.ResponseMessages[response.responseCode]);

                throw new SignerCustomException(response.responseCode, response.responseMessage);
            }
        }
        public bool Verify(byte[] dataToVerify, string extensionFile)
        {
            switch (extensionFile)
            {
                case "pdf":
                    return VerifyPdf(dataToVerify);
                case "docx":
                    return VerifyDocx(dataToVerify);
                default:
                    return false;
            }
        }

        public bool Verify(byte[] dataToVerify, string extensionFile, string method)
        {
            switch (extensionFile)
            {
                case "pdf":
                    return VerifyPdf(dataToVerify, method);
                case "docx":
                    return VerifyDocx(dataToVerify);
                default:
                    return false;
            }
        }

        private Boolean VerifyPdf(byte[] dataToVerify)
        {
            using (PdfReader pdfreader = new PdfReader(dataToVerify))
            {
                AcroFields acroFields = pdfreader.AcroFields;
                List<string> signatureNames = acroFields.GetSignatureNames();
                Boolean valid = false;
                if (signatureNames.Any())
                {
                    for (int i = 0; i < signatureNames.Count; i++)
                    {
                        String name = signatureNames[i];
                        if (acroFields.SignatureCoversWholeDocument(name))
                        {
                            PdfPKCS7 pkcs7 = acroFields.VerifySignature(name);
                            valid = pkcs7.Verify();
                        }
                    }
                }
                return valid;
            }
        }

        private Boolean VerifyPdf(byte[] dataToVerify, string method)
        {
            if (method == "CAViettelHash")
            {
                var verifyResults = PdfProfile.Verify(dataToVerify, false);
                if (verifyResults != null)
                {
                    foreach (lib.rssp.exsig.VerifyResult verifyResult in verifyResults)
                    {
                        if (verifyResult != null)
                        {
                            return true;
                        }
                        return false;
                    }
                }
                return false;
            }

            using (PdfReader pdfreader = new PdfReader(dataToVerify))
            {
                AcroFields acroFields = pdfreader.AcroFields;
                List<string> signatureNames = acroFields.GetSignatureNames();
                Boolean valid = false;
                if (signatureNames.Any())
                {
                    for (int i = 0; i < signatureNames.Count; i++)
                    {
                        String name = signatureNames[i];
                        if (acroFields.SignatureCoversWholeDocument(name))
                        {
                            PdfPKCS7 pkcs7 = acroFields.VerifySignature(name);
                            valid = pkcs7.Verify();
                        }
                    }
                }
                return valid;
            }
        }
        
        private Boolean VerifyDocx(byte[] dataToVerify)
        {
            using (var memoryStream = new MemoryStream(dataToVerify))
            {
                using (Package pkg = Package.Open(memoryStream, FileMode.Open, FileAccess.Read))
                {
                    var dsm = new PackageDigitalSignatureManager(pkg);
                    if (!dsm.IsSigned) return false;
                    var verifyResult = dsm.VerifySignatures(true);
                    return verifyResult.Equals(System.IO.Packaging.VerifyResult.Success);
                }
            }
        }

        public string GetDefaultReason()
        {
            return this.DefaultReason;
        }

        public bool WillShowReason()
        {
            return (this.ShowReason?.ToLower() == "false") ? false : true;
        }
        public string PdfSignerVinCa(byte[] dataToSign, string extensionFile, DigitalSignature parammeters)
        {
            const string contentType = "application/json";
            const string meThod = "POST";
            string stringData = JsonConvert.SerializeObject(parammeters);
            string url = _url + "VinHSMSignaturePDF";
            string result = EmrCaCore.WebRequest(url, stringData, "", meThod, contentType);
            if (!string.IsNullOrEmpty(result))
            {
                ResponseFile response = JsonConvert.DeserializeObject<ResponseFile>(result);
                if (response != null && response.IsSuccess)
                {

                    return response.data.ToString();
                }
                else
                {
                    return "response is null: " + result;
                }
            }
            else
            {
                return "result is null";
            }
        }

        public string FileSignerVinCa(byte[] dataToSign, string extensionFile, DigitalSignature parammeters)
        {
            const string contentType = "application/json";
            const string meThod = "POST";
            string stringData = JsonConvert.SerializeObject(parammeters);
            string url = _url + "VinHSMSignatureDocx";
            string result = EmrCaCore.WebRequest(url, stringData, "", meThod, contentType);
            if (!string.IsNullOrEmpty(result))
            {
                ResponseFile response = JsonConvert.DeserializeObject<ResponseFile>(result);
                if (response != null && response.IsSuccess)
                {

                    return response.data.ToString();
                }
                else
                {
                    return "response is null: " + result;
                }
            }
            else
            {
                return "result is null";
            }
        }
    }
}
