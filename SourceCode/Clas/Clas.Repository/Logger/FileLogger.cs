using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using Clas.Model.Logger;

namespace Clas.Repository.Logger
{
    public class FileLogger
    {
        public static void WriteLog(LoggerLevel level, Exception ex)
        {
            WriteLog(level, DateTime.Now, ex.ToString());
        }
        public static void WriteLog(LoggerLevel level, DateTime time, string message)
        {
            try
            {
                var assembly = (new System.Uri(Assembly.GetExecutingAssembly().CodeBase)).AbsolutePath;

                string logFolder = assembly.Substring(0, assembly.LastIndexOf("/")) + "/clas_logs/";
                bool exists = System.IO.Directory.Exists(logFolder);
                if (!exists)
                    System.IO.Directory.CreateDirectory(logFolder);
                System.IO.File.WriteAllText(logFolder + level.ToString() + "_"+ time.ToString("ddMMyyy_hhmmss") + time.ToBinary(), message);

            }
            catch (Exception)
            {
                //do nothing
            }
        }
    }
}
