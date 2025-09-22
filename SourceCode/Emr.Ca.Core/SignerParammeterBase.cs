using Emr.Ca.Core;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Security;
using System.Text;
using System.Threading.Tasks;

namespace Emr.Ca.Core
{
    public class EmrCaCore
    {
        public static string WebRequest(string pzUrl, string pzData, string pzAuthorization, string pzMethod, string pzContentType)
        {
            try
            {
                var httpWebRequest = (HttpWebRequest)System.Net.WebRequest.Create(pzUrl);
                httpWebRequest.ContentType = pzContentType;
                httpWebRequest.Method = pzMethod;
                if (!string.IsNullOrEmpty(pzAuthorization))
                    httpWebRequest.Headers.Add("Authorization", pzAuthorization);
                httpWebRequest.Proxy = new WebProxy();//no proxy
                if (!string.IsNullOrEmpty(pzData))
                {
                    using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
                    {
                        string json = pzData;
                        streamWriter.Write(json);
                        streamWriter.Flush();
                        streamWriter.Close();
                    }
                }
                InitiateSslTrust();//bypass SSL
                var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                var result = string.Empty;
                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    result = streamReader.ReadToEnd();
                }
                return result;
            }
            catch (Exception ex)
            {
                return null;
            }

        }
        public static void InitiateSslTrust()
        {
            try
            {
                ServicePointManager.ServerCertificateValidationCallback = new RemoteCertificateValidationCallback(delegate { return true; });
            }
            catch (Exception ex)
            {

            }
        }
    }

    public class ResponseFile
    {
        public bool IsSuccess { get; set; }
        public string Messge { get; set; }
        public object data { get; set; }
    }

    public class DigitalSignature
    {
        public string userName { get; set; }
        public string userFullName { get; set; }
        public string userDesc { get; set; }
        public string appId { get; set; }
        public string secret { get; set; }
        public string signatureType { get; set; }
        public string signatureName { get; set; }
        public string pdfFileName { get; set; }
        public string base64Pdf { get; set; }
        public string base64Signature { get; set; }
        public DateTime? dateSigned { get; set; }

        public List<DigitalSignatureLocation> locations { get; set; }
    }
    public class DigitalSignatureLocation
    {
        public int pageSign { get; set; }
        public List<DigitalSignatureRect> lstRect { get; set; }
    }
    public class DigitalSignatureRect
    {
        public int StartX { get; set; }
        public int StartY { get; set; }
        public int EndX { get; set; }
        public int EndY { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
    }

    public class SignerParammeterBase
    {
        /// <summary>
        /// BKAV SerialNumber "5403010326D6A5994A39BB41A52D0AAF"
        /// </summary>
        public string SerialNumber { get; set; }
        /// <summary>
        /// BKAV IdentityNumder "1234567890",
        /// </summary>
        public string IdentityNumber { get; set; }
        public string AgreementUUID { get; set; }
        public string AuthorizeCode { get; set; }
        public string FileName { get; set; }

        public string Method { get; set; } // Use define Viettel CA HASH or no.
        public string EmployeeName { get; set; }

        public string appID { get; set; }
        public string secret { get; set; }



    }
}
