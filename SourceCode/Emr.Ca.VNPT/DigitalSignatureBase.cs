using Clas.Emr.Intergration;

using Emr.Ca.Core;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Emr.Ca.VNPT
{
    public class DigitalSignatureBase : DigitalSignatureReader, IDigitalSignatureBase
    {
        private string _url;
        private ApiHelper _api;

        public string TextColor { get; set; }
        public string DefaultReason { get; set; }
        public string Contact { get; set; }
        public string Location { get; set; }
        public int CoordinateX { get; set; }
        public int CoordinateY { get; set; }
        public int SignatureWidth { get; set; }
        public int SignatureHeight { get; set; }
        public int FontSize { get; set; }
        public string FontStyle { get; set; }
        public string FontName { get; set; }
        public string FontColor { get; set; }
        public string VisualStatus { get; set; }
        public string TextDirection { get; set; }
        public bool ShowReason { get; set; }
        public string Layer2Text { get; set; }
        public string RenderMode { get; set; }
        public string SignatureBorderType { get; set; }
        public int CountGetTranInfo { get; set; }
        public int Page { get; set; }
        public string EmployeeName { get; set; }

        public DigitalSignatureBase(string url = "", int countGetTranInfo = 10)
        {
            _url = url;
            _api = new ApiHelper(_url, "", "VNPT_CA", countGetTranInfo * 10000);
        }

        public string PdfSigner(byte[] dataToSign, SignerParammeterBase parammeters, PdfSignerPropertyBase properties)
        {
            object data = null;

            #region SignerParammeterBase
            parammeters.EmployeeName = EmployeeName;
            #endregion

            #region PdfSignerPropertyBase
            properties.Contact = Contact;
            properties.Location = Location;
            properties.CoordinateX = properties.CoordinateX > 0 ? properties.CoordinateX : CoordinateX;
            properties.CoordinateY = properties.CoordinateY > 0 ? properties.CoordinateY : CoordinateY;
            properties.CountGetTranInfo = CountGetTranInfo;
            properties.FontColor = FontColor;
            properties.FontName = FontName;
            properties.FontSize = properties.FontSize > 0 ? properties.FontSize : FontSize;
            properties.FontStyle = FontStyle;
            properties.SignatureHeight = properties.Height > 0 ? properties.Height : SignatureHeight;
            properties.SignatureWidth = properties.Width > 0 ? properties.Width : SignatureWidth;
            properties.Layer2Text = Layer2Text;
            properties.Page = properties.Page > 0 ? properties.Page : Page;
            properties.RenderMode = RenderMode;
            properties.ShowReason = ShowReason;
            properties.SignatureBorderType = SignatureBorderType;
            #endregion


            var paramList = new Dictionary<string, object>
            {
                { "dataToSign", dataToSign },
                { "singerParams", parammeters },
                { "pdfSignerProperty", properties }
            };
            
            data = _api.Post(_url, null, paramList);
            if (data != null)
            {
                if (((JToken)data).Type == JTokenType.Object)
                {
                    bool success = Convert.ToBoolean((data as JObject).SelectToken($"Success").ToString());
                    if (success)
                        return (data as JObject).SelectToken($"Data").ToString();
                    else
                        throw new SignerCustomException(-1, (data as JObject).SelectToken($"Message").ToString());
                }
            }
            throw new SignerCustomException(-1, "Data null");
        }
        public List<string> ListPdfSigner(List<byte[]> dataListToSign, SignerParammeterBase parammeters, PdfSignerPropertyBase properties)
        {
            object data = null;

            #region SignerParammeterBase
            parammeters.EmployeeName = EmployeeName;
            #endregion

            #region PdfSignerPropertyBase
            properties.Contact = Contact;
            properties.Location = Location;
            properties.CoordinateX = properties.CoordinateX > 0 ? properties.CoordinateX : CoordinateX;
            properties.CoordinateY = properties.CoordinateY > 0 ? properties.CoordinateY : CoordinateY;
            properties.CountGetTranInfo = CountGetTranInfo;
            properties.FontColor = FontColor;
            properties.FontName = FontName;
            properties.FontSize = properties.FontSize > 0 ? properties.FontSize : FontSize;
            properties.FontStyle = FontStyle;
            properties.SignatureHeight = properties.Height > 0 ? properties.Height : SignatureHeight;
            properties.SignatureWidth = properties.Width > 0 ? properties.Width : SignatureWidth;
            properties.Layer2Text = Layer2Text;
            properties.Page = properties.Page > 0 ? properties.Page : Page;
            properties.RenderMode = RenderMode;
            properties.ShowReason = ShowReason;
            properties.SignatureBorderType = SignatureBorderType;
            #endregion


            var paramList = new Dictionary<string, object>
            {
                { "dataListToSign", dataListToSign },
                { "singerParams", parammeters },
                { "pdfSignerProperty", properties }
            };

            data = _api.Post(_url, null, paramList);
            if (data != null)
            {
                if (((JToken)data).Type == JTokenType.Object)
                {
                    bool success = Convert.ToBoolean((data as JObject).SelectToken($"Success").ToString());
                    if (success)
                    {
                        List<string> dataList = new List<string>();
                        var list = (data as JObject).SelectToken($"Data").ToList();
                        foreach(var item in list)
                        {
                            dataList.Add(item.ToString());
                        }
                        return dataList;
                        //return (data as JObject).SelectToken($"Data").ToList();
                    }
                    else
                        throw new SignerCustomException(-1, (data as JObject).SelectToken($"Message").ToString());
                }
            }
            throw new SignerCustomException(-1, "Data null");
        }
        public string FileSigner(byte[] dataToSign, string extensionFile, SignerParammeterBase parammeters)
        {
            return "";
        }

        public string GetDefaultReason()
        {
            return this.DefaultReason;
        }

        public bool WillShowReason()
        {
            return this.ShowReason;
        }

        public bool Verify(byte[] dataToVerify, string extensionFile)
        {
            return true;
        }

        public bool Verify(byte[] dataToVerify, string extensionFile, string method)
        {
            return true;
        }

        public string FileSignerVinCa(byte[] dataToSign, string extensionFile, DigitalSignature parammeters)
        {
            const string contentType = "application/json";
            const string meThod = "POST";
            string stringData = JsonConvert.SerializeObject(parammeters);
            string result = EmrCaCore.WebRequest("https://localhost:44310/api/VinHSM/VinHSMSignatureDocx", stringData, "", meThod, contentType);
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
