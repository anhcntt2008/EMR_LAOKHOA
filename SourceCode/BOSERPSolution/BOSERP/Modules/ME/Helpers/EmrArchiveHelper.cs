using BOSCommon;
using BOSERP.Utilities;
using BOSLib;
using Clas.Business.Ftp;
using DevExpress.XtraPdfViewer;
using Emr;
using Emr.Ca.Core;
using Emr.Document.Pdf;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BOSERP.Modules.ME.Helpers
{
    public class EmrArchiveHelper
    {
        public string StorageDir = "Archives";

        private readonly string _documentPath;
        private readonly IPdfProcessor _pdfProcessor;
        private readonly FileTemplateManager _ftpFileMng;
        private readonly HashProvider _hashProvider;
        private readonly IDigitalSignatureBase _digitalSig;
        private readonly MEEmrArchivesController _archivesCtrl;
        public EmrArchiveHelper(string documentPath, IPdfProcessor pdfProcessor, FileTemplateManager ftpFileMng, HashProvider hashProvider, IDigitalSignatureBase digitalSig)
        {
            _documentPath = documentPath;
            _pdfProcessor = pdfProcessor;
            _ftpFileMng = ftpFileMng;
            _hashProvider = hashProvider;
            _digitalSig = digitalSig;
            _archivesCtrl = new MEEmrArchivesController();
        }
        public MEEmrArchivesInfo MergeAndArchived(MEEmrsInfo emr, List<MEEmrDocumentsInfo> documents)
        {
            var dotPdf = "." + EmrDocumentFileExtention.pdf.ToString();
            var fileNames = new List<string>();
            //ordered on list
            //documents = documents.OrderBy(d => d.MEEmrDocumentOrder).ThenBy(d => d.MEEmrDocumentSubOrder).ToList();
            foreach (var document in documents)
            {
                Console.WriteLine(document.MEEmrDocumentRefNo);
                //Bo qua cac to an va huy
                if (document.MEEmrDocumentStatus == EmrDocumentStatus.Discarded.ToString() || document.MEEmrDocumentStatus == EmrDocumentStatus.Hidden.ToString())
                    continue;
                if (document.MEEmrDocumentFileExt == EmrDocumentFileExtention.pdf.ToString())
                {
                    string fileName = Path.Combine("Emr", document.FK_MEEmrID.ToString(), document.MEEmrDocumentFile + dotPdf);
                    string fileLocal = Path.Combine(_documentPath, fileName);
                    _ftpFileMng.DownloadFile($"/Emr/{document.FK_MEEmrID}/", document.MEEmrDocumentFile + dotPdf, fileLocal);
                    fileNames.Add(fileName);
                }
            }
            if (fileNames.Count() == 0) return null;

            var archiveFile = Emr.SanitizedFileName.Sanitize(emr.MEEmrNo, ".");
            if (!string.IsNullOrEmpty(emr.MEEmrArchiveNo))
                archiveFile += Emr.SanitizedFileName.Sanitize($"_{Emr.Vietnamese.AliasConvert(emr.MEEmrArchiveNo,"-")}", ".");
            if (emr.MEEmrDateOut.Year != 9999)
                archiveFile += $"_{emr.MEEmrDateOut.ToString("ddMMyyyy")}";
            archiveFile += $"_{DateTime.Now.ToString("ddMMyyyyHHmmss")}";

            var outFileName = archiveFile + dotPdf;
            var outFilePath = _pdfProcessor.Merge(Path.Combine(StorageDir, emr.MEEmrID.ToString(), outFileName), fileNames.ToArray());

            BOSProgressBar.Start("Đang lưu và upload tập tin");
            _ftpFileMng.CreateDirectory($"/{StorageDir}/{emr.MEEmrID}/");
            _ftpFileMng.UploadFile($"/{StorageDir}/{emr.MEEmrID}/", outFileName, outFilePath);
            var hashStr = _hashProvider.ComputeHash(outFilePath);
            var archive = new MEEmrArchivesInfo()
            {
                FK_MEEmrID = emr.MEEmrID,
                // khoa cua nguoi thuc hien luu tru
                FK_HRDepartmentID = BOSApp.CurrentEmployeesInfo.FK_HRDepartmentID,
                FK_HREmployeeID = BOSApp.CurrentEmployeesInfo.HREmployeeID,
                MEEmrArchiveDate = DateTime.Now,
                MEEmrArchiveRemark = "Lưu trữ bệnh án",
                MEEmrArchiveStatus = EmrArchiveStatus.Archived.ToString(),
                MEEmrArchiveFile = archiveFile,
                MEEmrArchiveFileExt = EmrDocumentFileExtention.pdf.ToString(),
                MEEmrArchiveFileHash = hashStr
            };
            return archive;
        }
        public MEEmrArchivesInfo DigitalSignEmrArchivePdf(MEEmrsInfo emr, MEEmrArchivesInfo archive, MEEmrTypesInfo emrType, int page, string reason)
        {
            if (archive == null) return archive;
            if (emrType == null) return archive;

            var dotExt = "." + archive.MEEmrArchiveFileExt;
            string fileName = archive.MEEmrArchiveFile + dotExt;
            string filePath = Path.Combine(_documentPath, StorageDir, emr.MEEmrID.ToString(), fileName);
            try
            {
                var byteContent = File.ReadAllBytes(filePath);
                string signature = emrType.MEEmrTypeDgtSignatureImage ? Convert.ToBase64String(BOSApp.CurrentEmployeesInfo.HREmployeeSignature) : string.Empty;
                var configCA = BOSApp.GetSystemConfigValue(SysCfgConsts.SYSTEM_CONFIGS, SysCfgConsts.SYSTEM_CONFIGS_CA_METHOD);
                var methodCA = !string.IsNullOrEmpty(configCA) ? configCA : string.Empty;
                string transactionDesc = string.Empty;
                if (BOSApp.CurrentCompanyInfo.CSCompanyCaProvider == CaProviders.VNPT_CA)
                {
                    transactionDesc = $"{emr.MEPatientNo} - Tổng kết bệnh án";
                }
                List<DigitalSignatureLocation> locations = new List<DigitalSignatureLocation>();

                DigitalSignatureLocation digitalSignature = new DigitalSignatureLocation();
                List<DigitalSignatureRect> lstRect = new List<DigitalSignatureRect>();
                DigitalSignatureRect rect = new DigitalSignatureRect();
                rect.StartX = emrType.MEEmrTypeDgtSignatureX;
                rect.StartY = emrType.MEEmrTypeDgtSignatureY;
                rect.Width = emrType.MEEmrTypeDgtSignatureWidth;
                rect.Height = emrType.MEEmrTypeDgtSignatureHeight;
                rect.EndX = emrType.MEEmrTypeDgtSignatureX + emrType.MEEmrTypeDgtSignatureWidth;
                rect.EndY = emrType.MEEmrTypeDgtSignatureY + emrType.MEEmrTypeDgtSignatureHeight;


                lstRect.Add(rect);
                digitalSignature.pageSign = page;
                digitalSignature.lstRect = lstRect;
                locations.Add(digitalSignature);
                var base64Resp = _digitalSig.PdfSignerVinCa(byteContent, "PDF", new DigitalSignature()
                {
                    userName = BOSApp.CurrentEmployeesInfo.HREmployeeName,
                    userFullName = BOSApp.CurrentEmployeesInfo.HREmployeeName,
                    userDesc = "",
                    signatureType = "3",
                    signatureName = BOSApp.CurrentEmployeesInfo.HREmployeeName,
                    base64Pdf = Convert.ToBase64String(byteContent),
                    base64Signature = signature,
                    dateSigned = DateTime.Now,
                    appId = Cryptographier.Decrypt(BOSApp.CurrentUsersInfo.ADUserCaPasscode),
                    secret = BOSApp.CurrentUsersInfo.ADUserCaIdentity,
                    pdfFileName = fileName,
                    locations = locations
                }); ;

                //var base64Resp = _digitalSig.PdfSigner(byteContent,
                //    new SignerParammeterBase()
                //    {
                //        SerialNumber = BOSApp.CurrentUsersInfo.ADUserCaIdentity,
                //        AgreementUUID = BOSApp.CurrentUsersInfo.ADUserCaIdentity,
                //        AuthorizeCode = Emr.Cryptographier.Decrypt(BOSApp.CurrentUsersInfo.ADUserCaPasscode),
                //        IdentityNumber = BOSApp.CurrentEmployeesInfo.HREmployeeIDNumber,
                //        FileName = BOSApp.CurrentCompanyInfo.CSCompanyCaProvider == CaProviders.VNPT_CA ? transactionDesc : fileName,
                //        Method = methodCA
                //    },
                //    new PdfSignerPropertyBase()
                //    {
                //        Visible = emrType.MEEmrTypeDgtSignatureVisible,
                //        Width = emrType.MEEmrTypeDgtSignatureWidth,
                //        Height = emrType.MEEmrTypeDgtSignatureHeight,
                //        Reason = reason,
                //        Page = page,
                //        CoordinateX = emrType.MEEmrTypeDgtSignatureX, // góc Dưới - Trái
                //        CoordinateY = emrType.MEEmrTypeDgtSignatureY, // góc Dưới - Trái
                //        SignatureImage = signature,
                //        TextColor = emrType.MEEmrTypeDgtSignatureTextColor,
                //        FontSize = emrType.MEEmrTypeDgtSignatureFontSize,
                //    });

                var byteArr = Convert.FromBase64String(base64Resp);
                File.WriteAllBytes(filePath, byteArr);
                _ftpFileMng.UploadFile($"/{StorageDir}/{emr.MEEmrID}/", fileName, filePath);

                archive.MEEmrArchiveFileHash = _hashProvider.ComputeHash(byteArr);
                archive.MEEmrArchiveStatus = EmrArchiveStatus.DigitalSigned.ToString();
                archive.AAUpdatedUser = BOSApp.CurrentUser;
                archive.FK_HREmployeeID = BOSApp.CurrentEmployeesInfo.HREmployeeID;
                archive.AAUpdatedDate = DateTime.Now;
                archive.MEEmrArchiveSignTime = DateTime.Now;
                _archivesCtrl.UpdateObject(archive);
                return archive;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public List<MEEmrArchivesInfo> DigitalSignListEmrArchivePdf(List<MEEmrsInfo> emrList, List<MEEmrArchivesInfo> archiveList, MEEmrTypesInfo emrType, int page, string reason)
        {
            if (emrList == null) return null;
            if (archiveList == null) return null;
            try
            {
                string signature = emrType.MEEmrTypeDgtSignatureImage ? Convert.ToBase64String(BOSApp.CurrentEmployeesInfo.HREmployeeSignature) : string.Empty;
                var configCA = BOSApp.GetSystemConfigValue(SysCfgConsts.SYSTEM_CONFIGS, SysCfgConsts.SYSTEM_CONFIGS_CA_METHOD);
                var methodCA = !string.IsNullOrEmpty(configCA) ? configCA : string.Empty;
                var listByteContent = new List<byte[]>();
                for (int i = 0; i < archiveList.Count(); i++)
                {
                    var dotExt = "." + archiveList[i].MEEmrArchiveFileExt;
                    string fileName = archiveList[i].MEEmrArchiveFile + dotExt;
                    string filePath = Path.Combine(_documentPath, StorageDir, emrList[i].MEEmrID.ToString(), fileName);
                    var byteContent = File.ReadAllBytes(filePath);
                    listByteContent.Add(byteContent);
                }
                var listBase64Resp = _digitalSig.ListPdfSigner(listByteContent,
                    new SignerParammeterBase()
                    {
                        SerialNumber = BOSApp.CurrentUsersInfo.ADUserCaIdentity,
                        AgreementUUID = BOSApp.CurrentUsersInfo.ADUserCaIdentity,
                        AuthorizeCode = Emr.Cryptographier.Decrypt(BOSApp.CurrentUsersInfo.ADUserCaPasscode),
                        IdentityNumber = BOSApp.CurrentEmployeesInfo.HREmployeeIDNumber,
                        FileName = "Tổng kết danh sách bệnh án",
                        Method = methodCA
                    },
                    new PdfSignerPropertyBase()
                    {
                        Visible = emrType.MEEmrTypeDgtSignatureVisible,
                        Width = emrType.MEEmrTypeDgtSignatureWidth,
                        Height = emrType.MEEmrTypeDgtSignatureHeight,
                        Reason = reason,
                        Page = page,
                        CoordinateX = emrType.MEEmrTypeDgtSignatureX, // góc Dưới - Trái
                    CoordinateY = emrType.MEEmrTypeDgtSignatureY, // góc Dưới - Trái
                    SignatureImage = signature,
                        TextColor = emrType.MEEmrTypeDgtSignatureTextColor,
                        FontSize = emrType.MEEmrTypeDgtSignatureFontSize,
                    });
                if (listBase64Resp.Count() != archiveList.Count())
                    return new List<MEEmrArchivesInfo>();
                for (int i = 0; i < listBase64Resp.Count(); i++)
                {
                    var dotExt = "." + archiveList[i].MEEmrArchiveFileExt;
                    string fileName = archiveList[i].MEEmrArchiveFile + dotExt;
                    string filePath = Path.Combine(_documentPath, StorageDir, emrList[i].MEEmrID.ToString(), fileName);
                    var byteArr = Convert.FromBase64String(listBase64Resp[i]);
                    File.WriteAllBytes(filePath, byteArr);
                    _ftpFileMng.UploadFile($"/{StorageDir}/{emrList[i].MEEmrID}/", fileName, filePath);

                    archiveList[i].MEEmrArchiveFileHash = _hashProvider.ComputeHash(byteArr);
                    archiveList[i].MEEmrArchiveStatus = EmrArchiveStatus.DigitalSigned.ToString();
                    archiveList[i].AAUpdatedUser = BOSApp.CurrentUser;
                    archiveList[i].FK_HREmployeeID = BOSApp.CurrentEmployeesInfo.HREmployeeID;
                    archiveList[i].AAUpdatedDate = DateTime.Now;
                    archiveList[i].MEEmrArchiveSignTime = DateTime.Now;
                    _archivesCtrl.UpdateObject(archiveList[i]);
                }
                return archiveList;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public string ViewDigitalSignatureInfo(MEEmrArchivesInfo archive, string filePath, bool logConfig, bool notification, BOSComponent.BOSMemoEdit msgLogs)
        {
            var result = string.Empty;
            var hashStr = _hashProvider.ComputeHash(filePath);
            if (hashStr != archive.MEEmrArchiveFileHash)
            {
                BOSProgressBar.Close();
                MessageBox.Show($"NỘI DUNG BỘ BỆNH ÁN ĐÃ BỊ THAY ĐỔI KỂ TỪ THỜI ĐIỂM THỰC HIỆN LƯU TRỮ"
               + "\n \u2756 Mã băm cũ: " + archive.MEEmrArchiveFileHash
               + "\n\n \u2756 Mã băm hiện tại: " + hashStr,
               "Nội dung tờ bệnh án đã bị thay đổi kể từ thời điểm thực hiện lưu trữ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            if (archive.MEEmrArchiveStatus == EmrArchiveStatus.DigitalSigned.ToString())
            {
                var valid = false;
                var location = BOSApp.CurrentCompanyInfo.CSCompanyCaProvider == CaProviders.ESIGN_CA ? "LOCAL" : $"MÁY CHỦ {BOSApp.CurrentCompanyInfo.CSCompanyCaProvider} KÝ SỐ TRẢ VỀ";
                try
                {
                    BOSProgressBar.Start("Đang xác thực chữ ký số");
                    var configCA = BOSApp.GetSystemConfigValue(SysCfgConsts.SYSTEM_CONFIGS, SysCfgConsts.SYSTEM_CONFIGS_CA_METHOD);
                    var methodCA = !string.IsNullOrEmpty(configCA) ? configCA : string.Empty;
                    valid = _digitalSig.Verify(File.ReadAllBytes(filePath), archive.MEEmrArchiveFileExt, methodCA);
                }
                catch (SignerCustomException ex)
                {
                    BOSProgressBar.Close();
                    MessageBox.Show(location + ": XÁC THỰC KHÔNG THÀNH CÔNG" +
                        "\n Mã lỗi: " + ex.Code +
                        "\n Chi tiết: " + ex.Message,
                        "Xác thực không thành công", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    if (notification)
                    {
                        msgLogs.Text += "\r\n DIGITAL VERIFY FAILED: " + ex.Code + "-" + ex.ToString();
                    }
                    else if (logConfig)
                    {
                        result += "\r\n DIGITAL VERIFY FAILED: " + ex.Code + "-" + ex.ToString();
                    }
                }
                catch (Exception ex)
                {
                    BOSProgressBar.Close();
                    var notificationStr = notification ? " Xem chi tiết ở thông báo" : string.Empty;
                    MessageBox.Show(ex.ToString(), $"Lỗi không xác định khi gọi xác thực.{notificationStr}", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    if (notification)
                    {
                        msgLogs.Text += "\r\n DIGITAL VERIFY FAILED: " + ex.ToString();
                    }
                    else if (logConfig)
                    {
                        result += "\r\n DIGITAL VERIFY FAILED: " + ex.ToString();
                    }
                }
                if (valid)
                {
                    var cerDetail = _digitalSig.GetCerDetailFromPdf(filePath);
                    BOSProgressBar.Close();
                    MessageBox.Show(location + ": \u2714 TOÀN VẸN DỮ LIỆU VÀ CHỮ KÝ HỢP LỆ.\n\n" + cerDetail, "Xác thực toàn vẹn dữ liệu và thông tin chữ ký số", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }

            return result;
        }

        public void MergePdfFromDocx(string dirLocalPdf, string pdfFile, List<MEEmrDocumentsInfo> documents, bool isDownload = true)
        {
            var dotPdf = "." + EmrDocumentFileExtention.pdf.ToString();
            var fileNames = new List<string>();
            foreach (var document in documents)
            {
                Console.WriteLine(document.MEEmrDocumentRefNo);
                if (document.MEEmrDocumentStatus == EmrDocumentStatus.Discarded.ToString() || document.MEEmrDocumentStatus == EmrDocumentStatus.Hidden.ToString())
                    continue;
                string fileName = Path.Combine("Emr", document.FK_MEEmrID.ToString(), document.MEEmrDocumentFile + dotPdf);
                string fileLocal = Path.Combine(_documentPath, fileName);

                if (isDownload)
                {
                    _ftpFileMng.DownloadFile($"/Emr/{document.FK_MEEmrID}/", document.MEEmrDocumentFile + dotPdf, fileLocal);
                }
                fileNames.Add(fileName);
            }
            _pdfProcessor.Merge(Path.Combine(dirLocalPdf, pdfFile + dotPdf), fileNames.ToArray());
        }
    }
}
