using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clas.Emr.Model
{
    public class StethoscopeResponse
    {
        public bool Success { get; set; }
        public List<string> ErrrorMessages { get; set; }
        public List<StethoscopeData> Values { get; set; }
    }

    public class StethoscopeData
    {
        public String PatientId { get; set; }
        public String Localization { get; set; }
       // public DateTimeOffset CreatedAt { get; set; }
        public Byte[] AudioFile { get; set; }

        // extra
        public string LocalizationName { get; set; }
    }
}
