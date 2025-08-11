using Emr.Ca.Bkav.WebReference;
using Emr.Ca.Core;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Security.Cryptography.X509Certificates;

namespace Emr.Ca.Bkav
{
    public class DigitalSignatureBase : DigitalSignatureReader, IDigitalSignatureBase
    {
        private readonly EAService _eaService;
        private readonly string _parnerName;
        public string VerifyDefaultUser { get; set; }
        public string TagName { get; set; }
        public string CoordinateX { get; set; }
        public string CoordinateY { get; set; }
        public string SignatureWidth { get; set; }
        public string SignatureHeight { get; set; }
        public string Location { get; set; }
        public string Contact { get; set; }
        public int FontSize { get; set; }
        public string TextColor { get; set; }
        public string DefaultReason { get; set; }
        public string ShowReason { get; set; }
        public bool UseExtensionFileOffice { get; set; }
        public string Version { get; set; }

        public string urlHSM = "";

        public DigitalSignatureBase(string url, string p12FilePath, string p12Pw, string partnerName)
        {
            _eaService = new EAService
            {
                Url = url
            };
            var x509 = new X509Certificate2(p12FilePath, p12Pw);
            _eaService.ClientCertificates.Add(x509);
            System.Net.ServicePointManager.ServerCertificateValidationCallback += delegate { return true; };
            _parnerName = partnerName;
            VerifyDefaultUser = "VERIFY";
            TagName = "CKDT";
            urlHSM = "https://localhost:44310/api/VinHSM/VinHSMSignatureDocx";


        }
        /// <summary>
        /// Sign pdf file with sepecific parametter
        /// </summary>
        /// <param name="dataToSign"></param>
        /// <param name="userIdentity"> "1234567890"</param>
        /// <returns></returns>
        public string PdfSigner(byte[] dataToSign, SignerParammeterBase parammeters, PdfSignerPropertyBase properties)
        {
            _eaService.isReadyToSign(out bool isReadyToSign, out bool b);
            if (!isReadyToSign)
            {
                throw new SignerCustomException(-1, "Máy chủ ký số BKAV không sẵn sàng. Xin thử lại sau");
            }
            int.TryParse(this.CoordinateX, out int x);
            x = properties.CoordinateX > 0 ? properties.CoordinateX : x;
            var countSignature = this.GetCountSignatureFields(dataToSign, "pdf");
            // co the co nhieu chu ky
            var padding = (properties.Width + 5) * countSignature;
            x = x + padding;
            var colorStr = this.TextColor;
            var color = Color.FromArgb(properties.TextColor);
            if (!color.IsEmpty)
                colorStr = $"{color.R},{color.G},{color.B}";

            var property = new PdfSignerPropertyModel()
            {
                px = x.ToString(),
                py = properties.CoordinateY > 0 ? properties.CoordinateY.ToString() : this.CoordinateY,
                width = properties.Width > 0 ? properties.Width.ToString() : this.SignatureWidth,
                height = properties.Height > 0 ? properties.Height.ToString() : this.SignatureHeight,
                page = properties.Page.ToString(),
                location = !string.IsNullOrEmpty(properties.Location) ? properties.Location : this.Location,
                reason = this.WillShowReason() ? properties.Reason : null,
                showReason = this.WillShowReason().ToString().ToLower(),
                visible = properties.Visible.ToString().ToLower(),
                contact = !string.IsNullOrEmpty(properties.Contact) ? properties.Contact : this.Contact,
                image = properties.SignatureImage,
                color = colorStr,
                font = (properties.FontSize > 0 ? properties.FontSize : this.FontSize).ToString(),
                version = Version
            };
            var data = new
            {
                serialNumber = parammeters.SerialNumber,
                MST = parammeters.IdentityNumber,
                partnerName = _parnerName,
                extensionFile = "pdf",
                property,
                dataBase64 = Convert.ToBase64String(dataToSign)
            };
            var signData = _eaService.sign0(JsonConvert.SerializeObject(data));
            var response = JsonConvert.DeserializeObject<ResponseModel>(signData);
            if (response.Status)
                return response.DataResponse;
            else
                throw new SignerCustomException(response.Code, response.Message);
        }
        public List<string> ListPdfSigner(List<byte[]> dataListToSign, SignerParammeterBase parammeters, PdfSignerPropertyBase properties)
        {
            return null;
        }

        /// <summary>
        /// Sign all file type
        /// </summary>
        /// <param name="dataToSign"></param>
        /// <param name="userIdentity"></param>
        /// <param name="extensionFile">ooxml, xml, pdf</param>
        /// <returns></returns>
        public string FileSignerVinCa(byte[] dataToSign, string extensionFile, DigitalSignature parammeters)
        {
            const string contentType = "application/json";
            const string meThod = "POST";
            string stringData = JsonConvert.SerializeObject(parammeters);
            string result = EmrCaCore.WebRequest(urlHSM, stringData, "", meThod, contentType);
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

        /// <summary>
        /// Sign all file type
        /// </summary>
        /// <param name="dataToSign"></param>
        /// <param name="userIdentity"></param>
        /// <param name="extensionFile">ooxml, xml, pdf</param>
        /// <returns></returns>
        public string FileSigner(byte[] dataToSign, string extensionFile, SignerParammeterBase parammeters)
        { 

            _eaService.isReadyToSign(out bool isReadyToSign, out bool b);
            if (!isReadyToSign)
            {
                throw new SignerCustomException(-1, "Máy chủ ký số BKAV không sẵn sàng. Xin thử lại sau");
            }
            //BKAV thay doi extension cua docx thanh office (docx va xlsx)
            if (UseExtensionFileOffice && extensionFile == "docx")
            {
                extensionFile = "office";
            }

            var data = new
            {
                serialNumber = parammeters.SerialNumber,
                MST = parammeters.IdentityNumber,
                partnerName = _parnerName,
                extensionFile,
                dataBase64 = Convert.ToBase64String(dataToSign)
            };
            var signData = _eaService.sign0(JsonConvert.SerializeObject(data));
            var response = JsonConvert.DeserializeObject<ResponseModel>(signData);
            if (response.Status)
                return response.DataResponse;
            else
                throw new SignerCustomException(response.Code, response.Message);
        }
        /// <summary>
        /// Verify signed data
        /// </summary>
        /// <param name="dataToVerify"></param>
        /// <param name="extensionFile">ooxml, xml, pdf</param>
        /// <returns></returns>
        public bool Verify(byte[] dataToVerify, string extensionFile)
        {
            String signData = _eaService.verify(dataToVerify, _parnerName, VerifyDefaultUser, extensionFile);
            var response = JsonConvert.DeserializeObject<ResponseModel>(signData);
            if (response.Status && response.Code == 0)
                return true;
            else
                throw new SignerCustomException(response.Code, response.Message);
        }

        public bool Verify(byte[] dataToVerify, string extensionFile, string method)
        {
            // No implement
            return true;
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
            string result = EmrCaCore.WebRequest("https://localhost:44310/api/VinHSM/VinHSMSignaturePDF", stringData, "", meThod, contentType);
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
