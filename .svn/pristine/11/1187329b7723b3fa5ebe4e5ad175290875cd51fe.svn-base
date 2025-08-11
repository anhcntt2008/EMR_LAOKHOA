using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace BOSLib
{
    #region ReportController
    /// <summary>
    /// This object represents the properties and methods of a Report.
    /// </summary>
    public class PRReportsController:BaseBusinessController
    {
        private readonly string spGetPRReportsByModuleCode = "PRReports_SelectByModuleCode";
        private readonly string spGetPRReportsByModuleName = "PRReports_SelectByModuleName";
        public PRReportsController()
        {
            dal = new DALBaseProvider("PRReports", typeof(PRReportsInfo));
        }

        public DataSet GetPRReportsByModuleCode(String strModuleCode)
        {
            return dal.GetDataSet(spGetPRReportsByModuleCode, strModuleCode);
        }

        public DataSet GetPRReportsByModuleName(String strModuleName)
        {
            return dal.GetDataSet(spGetPRReportsByModuleName, strModuleName);
        }
    }
    #endregion

}
