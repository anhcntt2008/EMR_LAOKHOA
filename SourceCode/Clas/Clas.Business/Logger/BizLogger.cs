using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Clas.Repository.Logger;
using Clas.Model.Logger;

namespace Clas.Business.Logger
{
    public static class BizLogger
    {
        public static void WriteLog(LoggerLevel level, Exception ex)
        {
            FileLogger.WriteLog(level,ex);
        }
        public static void WriteLog(LoggerLevel level, DateTime time, string message)
        {
            FileLogger.WriteLog(level,time, message);
        }
    }
}
