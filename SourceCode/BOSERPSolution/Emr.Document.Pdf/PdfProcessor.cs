using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PdfDocument = iTextSharp.text.Document;
namespace Emr.Document.Pdf
{
    public class PdfProcessor : IPdfProcessor
    {
        private string _storageDir;
        private string _workSpaceDir;

        public PdfProcessor(string storageDir)
        {
            _storageDir = storageDir;
            _workSpaceDir = _storageDir;
        }
        public PdfProcessor(string storageDir, string workSpaceDir)
        {
            _storageDir = storageDir;
            _workSpaceDir = workSpaceDir;
        }
        public string Merge(string outPutFile, params string[] fileNames)
        {
            var outPutFilePath = Path.Combine(_workSpaceDir, outPutFile);
            //Define a new output document and its size, type
            PdfDocument document = new PdfDocument(PageSize.A4, 0, 0, 0, 0);
            using (FileStream newFileStream = new FileStream(outPutFilePath, FileMode.Create))
            {
                PdfCopy writer = new PdfCopy(document, newFileStream);
                document.Open();
                foreach (string file in fileNames)
                {
                    var filePath = Path.Combine(_storageDir, file);
                    PdfReader reader = new PdfReader(filePath);
                    for (int i = 1; i <= reader.NumberOfPages; i++)
                    {
                        PdfImportedPage page = writer.GetImportedPage(reader, i);
                        document.SetPageSize(reader.GetPageSizeWithRotation(i));
                        document.NewPage();
                        writer.AddPage(page);
                    }
                    reader.Close();
                    reader.Dispose();
                }
                writer.Close();
                document.Close();
                document.Dispose();
            }
            return outPutFilePath;
        }
    }
}
