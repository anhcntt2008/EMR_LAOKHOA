using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.ServiceModel;
using lib.rssp.connector;
using lib.rssp.connector.esign;
using lib.rssp.exsig;

namespace Emr.Ca.eSign
{
    public class SoapConnectorImp : ESignSoapSigningMethod
    {

        private BasicHttpBinding basicHttpbinding;
        private EndpointAddress endpointAddress;

        private readonly String URL;
        private readonly String relyingParty;
        private readonly String relyingPartyUser;
        private readonly String relyingPartyPassword;
        private readonly String relyingPartySignature;
        private readonly String relyingPartyKeyStore;
        private readonly String relyingPartyKeyStorePassword;
        private readonly String agreementUUID;
        private readonly String authorizeCode;

        public SoapConnectorImp(Algorithm algorithm, string url,
            string relyingParty,
            string relyingPartyUser,
            string relyingPartyPassword,
            string relyingPartySignature,
            string relyingPartyKeyStore,
            string relyingPartyKeyStorePassword,
            string agreementUUID,
            string authorizeCode) : base(algorithm)
        {

            this.URL = url; //"https://103.141.177.27:443/eSignCloud/Services?wsdl";
            this.relyingParty = relyingParty;// "LKHOSPITAL";
            this.relyingPartyUser = relyingPartyUser;// "lkhospital";
            this.relyingPartyPassword = relyingPartyPassword;// "lkhospital2019@esigncloud";
            this.relyingPartySignature = relyingPartySignature;// "aCiPiDxEIfoWajqE+k4CCnf0pUcLi7NxgNGq5hQYC26RtD+oauzwYblLU5oRTUM7YhLsfzXlCJ6VSgTFQze8vYw5x0ct4ReB5jP+1kb1RoCP+BT4rjQYxWhsWlF5h6RhER24CzFLUx4hv4TssxuHNq9WtDcEIZww17qe8KkMGPjTy7xQPkxJLIaf9c1ZPymrhfINa0wytDSSYY4NZH5YvuJfoAGZsRfuoyRbwxxoDteVRl5eQ/QyJtrHNRVMYBEkg+ONzsS4KRX9dnmk0A1oJYPA63m6ppXHsx3TZtxGieS0uYUyYfMTQlySo65TwlM7ZsH+hu5twqYv4kio3jPSpQ==";
            this.relyingPartyKeyStore = relyingPartyKeyStore;// "file\\esign_ssl.p12"; // current: "file\\cloudfca.p12";
            this.relyingPartyKeyStorePassword = relyingPartyKeyStorePassword;// "12345678";
            this.agreementUUID = agreementUUID;// "201911051032";
            this.authorizeCode = authorizeCode;// "12345678";

            ServicePointManager.CheckCertificateRevocationList = false;
            ServicePointManager.ServerCertificateValidationCallback = (a, b, c, d) => true;
            ServicePointManager.Expect100Continue = true;
            ServicePointManager.SecurityProtocol = (SecurityProtocolType)3072;
            ServicePointManager.DefaultConnectionLimit = 9999;

            basicHttpbinding = new BasicHttpBinding(BasicHttpSecurityMode.None);
            basicHttpbinding.Name = "Rssp";
            basicHttpbinding.Security.Transport.ClientCredentialType = HttpClientCredentialType.None;
            basicHttpbinding.Security.Message.ClientCredentialType = BasicHttpMessageCredentialType.UserName;
            basicHttpbinding.CloseTimeout = TimeSpan.FromMinutes(1);
            basicHttpbinding.OpenTimeout = TimeSpan.FromMinutes(1);
            basicHttpbinding.ReceiveTimeout = TimeSpan.FromMinutes(10);
            basicHttpbinding.SendTimeout = TimeSpan.FromMinutes(1);
            basicHttpbinding.Security.Mode = BasicHttpSecurityMode.Transport;
            basicHttpbinding.MaxBufferSize = 2147483647;
            basicHttpbinding.MaxReceivedMessageSize = 2147483647;
            basicHttpbinding.MaxBufferPoolSize = 2147483647;
            ServicePointManager.SecurityProtocol = (SecurityProtocolType)3072;
            endpointAddress = new EndpointAddress(new Uri(this.URL));
        }


        public void forgetPassCode()
        {
            ServicesClient service = new ServicesClient(basicHttpbinding, endpointAddress);
            String timestamp = DefaultConnector.CurrentTimeMillis().ToString();
            String data2sign = relyingPartyUser + relyingPartyPassword + relyingPartySignature + timestamp;
            String pkcs1Signature = DefaultConnector.getPKCS1Signature(data2sign, relyingPartyKeyStore, relyingPartyKeyStorePassword);

            String notificationTemplate = "MISACA: Your Authorize Code: {AuthorizeCode}. It will be expired within 5 minutes";
            String notificationSubject = "MISACA - Authorization Code";

            signCloudReq signCloudReq = new signCloudReq();
            signCloudReq.relyingParty = relyingParty;
            signCloudReq.agreementUUID = agreementUUID;
            signCloudReq.notificationSubject = notificationSubject;
            signCloudReq.notificationTemplate = notificationTemplate;

            credentialData credentialData = new credentialData();
            credentialData.username = relyingPartyUser;
            credentialData.password = relyingPartyPassword;
            credentialData.timestamp = timestamp;
            credentialData.signature = relyingPartySignature;

            credentialData.pkcs1Signature = pkcs1Signature;
            signCloudReq.credentialData = credentialData;

            signCloudResp signCloudResp = service.forgetPasscodeForSignCloud(signCloudReq);
            Console.WriteLine("Code: " + signCloudResp.responseCode);
            Console.WriteLine("Message: " + signCloudResp.responseMessage);
            Console.WriteLine("New Passcode: " + signCloudResp.authorizeCredential);
        }

        public void changePassCode()
        {
            Console.Write("Old PassCode: ");
            String oldPass = Console.ReadLine();
            Console.Write("New PassCode: ");
            String newPass = Console.ReadLine();

            //ServicesClient service = new ServicesClient(basicHttpbinding, endpointAddress);
            ServicesClient service = new ServicesClient(basicHttpbinding, endpointAddress);
            String timestamp = DefaultConnector.CurrentTimeMillis().ToString();
            String data2sign = relyingPartyUser + relyingPartyPassword + relyingPartySignature + timestamp;
            String pkcs1Signature = DefaultConnector.getPKCS1Signature(data2sign, relyingPartyKeyStore, relyingPartyKeyStorePassword);

            signCloudReq signCloudReq = new signCloudReq();
            signCloudReq.relyingParty = relyingParty;
            signCloudReq.agreementUUID = agreementUUID;
            signCloudReq.currentPasscode = oldPass;
            signCloudReq.newPasscode = newPass;

            credentialData credentialData = new credentialData();
            credentialData.username = relyingPartyUser;
            credentialData.password = relyingPartyPassword;
            credentialData.timestamp = timestamp;
            credentialData.signature = relyingPartySignature;
            credentialData.pkcs1Signature = pkcs1Signature;
            signCloudReq.credentialData = credentialData;

            signCloudResp signCloudResp = service.changePasscodeForSignCloud(signCloudReq);
            Console.WriteLine("Code: " + signCloudResp.responseCode);
            Console.WriteLine("Message: " + signCloudResp.responseMessage);
        }


        public override signCloudResp GetCertificateDetailForSignCloud()
        {

            ServicesClient service = new ServicesClient(basicHttpbinding, endpointAddress);
            String timestamp = DefaultConnector.CurrentTimeMillis().ToString();
            String data2sign = relyingPartyUser + relyingPartyPassword + relyingPartySignature + timestamp;
            String pkcs1Signature = DefaultConnector.getPKCS1Signature(data2sign, relyingPartyKeyStore, relyingPartyKeyStorePassword);

            signCloudReq signCloudReq = new signCloudReq();
            signCloudReq.relyingParty = relyingParty;
            signCloudReq.agreementUUID = agreementUUID;

            credentialData credentialData = new credentialData();
            credentialData.username = relyingPartyUser;
            credentialData.password = relyingPartyPassword;
            credentialData.timestamp = timestamp;
            credentialData.signature = relyingPartySignature;
            credentialData.pkcs1Signature = pkcs1Signature;
            signCloudReq.credentialData = credentialData;

            return service.getCertificateDetailForSignCloud(signCloudReq);
        }

        public override signCloudResp PrepareHashSigningForSignCloud(List<String> hashes, String algorithm)
        {
            ServicesClient service = new ServicesClient(basicHttpbinding, endpointAddress);

            String timestamp = DefaultConnector.CurrentTimeMillis().ToString();
            String data2sign = relyingPartyUser + relyingPartyPassword + relyingPartySignature + timestamp;
            String pkcs1Signature = DefaultConnector.getPKCS1Signature(data2sign, relyingPartyKeyStore, relyingPartyKeyStorePassword);

            signCloudReq signCloudReq = new signCloudReq();
            signCloudReq.relyingParty = relyingParty;
            signCloudReq.agreementUUID = agreementUUID;

            credentialData credentialData = new credentialData();
            credentialData.username = relyingPartyUser;
            credentialData.password = relyingPartyPassword;
            credentialData.timestamp = timestamp;
            credentialData.signature = relyingPartySignature;
            credentialData.pkcs1Signature = pkcs1Signature;
            signCloudReq.credentialData = credentialData;

            signCloudReq.authorizeMethod = DefaultConnector.AUTHORISATION_METHOD_PASSCODE;
            signCloudReq.messagingMode = DefaultConnector.SYNCHRONOUS;
            //Console.Write("PassCode: ");
            //signCloudReq.authorizeCode = Console.ReadLine();
            signCloudReq.authorizeCode = authorizeCode;

            List<multipleSigningFileData> multipleSigningFileDatas = new List<multipleSigningFileData>();
            for (int i = 0; i < hashes.Count; i++)
            {
                multipleSigningFileData multipleSigningFileData = new multipleSigningFileData();
                multipleSigningFileData.hash = hashes[i];
                multipleSigningFileData.mimeType = DefaultConnector.GetMimeType(algorithm);
                multipleSigningFileData.signingFileName = "Hash_Name_" + DefaultConnector.CurrentTimeMillis();
                multipleSigningFileDatas.Add(multipleSigningFileData);
            }
            signCloudReq.multipleSigningFileData = multipleSigningFileDatas.ToArray();
            return service.prepareHashSigningForSignCloud(signCloudReq);
        }

        public override signCloudResp AuthorizeHashSigningForSignCloud()
        {
            throw new NotImplementedException();
        }
    }
}
