using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emr.Document.Pdf
{
    public interface IPdfProcessor
    {
        string Merge(string outPutFile, params string[] fileNames);
    }
}
