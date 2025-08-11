using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emr.Ca.Core
{
    public interface IDigitalSignatureBase
    {
        string PdfSigner(byte[] dataToSign, SignerParammeterBase parammeters, PdfSignerPropertyBase properties);
        string PdfSignerVinCa(byte[] dataToSign, string extensionFile, DigitalSignature parammeters);
        List<string> ListPdfSigner(List<byte[]> dataListToSign, SignerParammeterBase parammeters, PdfSignerPropertyBase properties);
        string FileSignerVinCa(byte[] dataToSign, string extensionFile, DigitalSignature parammeters);
        string FileSigner(byte[] dataToSign, string extensionFile, SignerParammeterBase parammeters);
        bool Verify(byte[] dataToVerify, string extensionFile);
        bool Verify(byte[] dataToVerify, string extensionFile, string method);
        string GetDefaultReason();
        string GetCerDetailFromPdf(string filePath);
        string GetCerDetailFromDocx(string filePath);
        int GetCountSignatureFields(byte[] content, string extensionFile);
        bool WillShowReason();
    }
}
