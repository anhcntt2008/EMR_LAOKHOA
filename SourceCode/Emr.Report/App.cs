using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emr.Report
{
    public static class App
    {
        public static string FtpUser { get; set; }
        public static string FtpRootFilePath { get; set; }
        public static string FtpPassword { get; set; }
        public static string FtpHost { get; set; }
        public static string ReportLocalDir { get; set; }
        public static string DataSourceName { get; set; }
        public static string ConnString { get; set; }
        public static Dictionary<string, object> Context { get; internal set; }

        public static string FtpDesignDir = "/Design/";
        public static string ReportExt = ".repx";
    }
}
