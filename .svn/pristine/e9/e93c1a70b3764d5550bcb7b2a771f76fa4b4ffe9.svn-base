using iTextSharp.text.pdf;
using iTextSharp.text.pdf.security;
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Packaging;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Emr.Ca.Core
{
    public class DigitalSignatureReader
    {
        public string GetCerDetailFromDocx(string filePath)
        {
            using (Package pkg = Package.Open(filePath, FileMode.Open, FileAccess.Read))
            {
                var dsm = new PackageDigitalSignatureManager(pkg);
                if (dsm.Signatures.Any())
                {
                    var strBuilder = new StringBuilder();
                    foreach (var signature in dsm.Signatures)
                    {
                        strBuilder.AppendLine("\u2756 Trường chữ ký số: " + signature.CertificateEmbeddingOption);
                        strBuilder.AppendLine("\u2756 Xác thực (local): " + signature.Verify());
                        strBuilder.AppendLine("\u2756 Loại chữ ký: " + signature.SignatureType);
                        strBuilder.AppendLine("\u2756 Ngày ký: " + signature.SigningTime.ToString("dd/MM/yyyy HH:mm:ss"));
                        var cer = signature.Signer as X509Certificate2;
                        if (cer == null) continue;
                        strBuilder.AppendLine("\u2756 Chứng thư số:");
                        strBuilder.AppendLine("    \u2022 Cấp bởi: " + cer.Issuer);
                        strBuilder.AppendLine("    \u2022 Cấp cho: " + cer.Subject);
                        strBuilder.AppendLine("    \u2022 Số serial: " + cer.GetSerialNumberString());
                        strBuilder.AppendLine("    \u2022 Thuật toán: " + cer.SignatureAlgorithm.FriendlyName);
                        strBuilder.AppendLine("    \u2022 Giá trị từ: " + cer.NotBefore.ToString("dd/MM/yyyy HH:mm:ss") + " đến: " + cer.NotAfter.ToString("dd/MM/yyyy HH:mm:ss"));
                        strBuilder.AppendLine("                    ----- \u2756 -----");
                    }
                    return strBuilder.ToString();
                }
                return string.Empty;
            }
        }
        public string GetCerDetailFromPdf(string filePath)
        {
            using (PdfReader pdfreader = new PdfReader(filePath))
            {
                AcroFields acroFields = pdfreader.AcroFields;
                List<string> signatureNames = acroFields.GetSignatureNames();
                var strBuilder = new StringBuilder();
                if (signatureNames.Any())
                {
                    for (int i = 0; i < signatureNames.Count; i++)
                    {
                        String name = signatureNames[i];
                        PdfPKCS7 pkcs7 = acroFields.VerifySignature(name);
                        strBuilder.AppendLine("\u2756 Trường chữ ký số: " + name);
                        strBuilder.AppendLine("\u2756 Xác thực (local): " + pkcs7.Verify());
                        strBuilder.AppendLine("\u2756 Lý do: " + pkcs7.Reason);
                        strBuilder.AppendLine("\u2756 Ngày ký: " + pkcs7.SignDate.ToString("dd/MM/yyyy HH:mm:ss"));
                        var cer = pkcs7.SigningCertificate;
                        strBuilder.AppendLine("\u2756 Chứng thư số:");
                        strBuilder.AppendLine("    \u2022 Cấp bởi: " + cer.IssuerDN);
                        strBuilder.AppendLine("    \u2022 Cấp cho: " + cer.SubjectDN);
                        strBuilder.AppendLine("    \u2022 Số serial: " + cer.SerialNumber);
                        strBuilder.AppendLine("    \u2022 Thuật toán: " + cer.SigAlgName);
                        strBuilder.AppendLine("    \u2022 Đang còn hiệu lực: " + cer.IsValidNow);
                        strBuilder.AppendLine("    \u2022 Giá trị từ: " + cer.NotBefore.ToString("dd/MM/yyyy HH:mm:ss") + " đến: " + cer.NotAfter.ToString("dd/MM/yyyy HH:mm:ss"));
                        strBuilder.AppendLine("                    ----- \u2756 -----");
                    }
                }
                return strBuilder.ToString();
            }
        }
        public int GetCountSignatureFields(byte[] content, string extensionFile)
        {
            switch (extensionFile)
            {
                case "pdf":
                    return GetCountSignatureFieldsPdf(content);
                case "docx":
                    return GetCountSignatureFieldsDocx(content);
                default:
                    return 0;
            }
        }
        private int GetCountSignatureFieldsPdf(byte[] content)
        {
            using (PdfReader pdfreader = new PdfReader(content))
            {
                AcroFields acroFields = pdfreader.AcroFields;
                return acroFields.GetSignatureNames().Count;
            }
        }
        private int GetCountSignatureFieldsDocx(byte[] content)
        {
            using (var memoryStream = new MemoryStream(content))
            {
                using (Package pkg = Package.Open(memoryStream, FileMode.Open, FileAccess.Read))
                {
                    var dsm = new PackageDigitalSignatureManager(pkg);
                    if (!dsm.IsSigned) return 0;
                    return dsm.Signatures.Count;
                }
            }
        }
    }
}
