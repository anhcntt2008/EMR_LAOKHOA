using System;
using System.IO;
using System.Windows.Forms;
using DevExpress.DataAccess.Sql;
using DevExpress.XtraReports.UI;
using System.Collections.Generic;
using System.Linq;

namespace Emr.Report
{
    public class ReportReader
    {

        /// <summary>
        /// Get report file name.
        /// </summary>

        public static string GetFileName(string name)
        {
            return string.Format(@"{0}\{1}", App.ReportLocalDir, name);
        }
        /// <summary>
        /// Create a new report or load from exist once.
        /// </summary>
        public static XtraReport Create(string name)
        {
            string fileName = ReportReader.GetFileName(name);
            XtraReport report;
            if (File.Exists(fileName))
            {
                report = XtraReport.FromFile(fileName, true);
                SqlDataSource dataSource = report.DataSource as SqlDataSource;
                if (dataSource != null)
                {
                    dataSource.ConnectionParameters = DataSource.GetConnectionString();
                }
                else
                {
                    report.DataSource = DataSource.GetDataSource();
                }
            }
            else
            {
                report = new XtraReport
                {
                    DataSource = DataSource.GetDataSource()
                };
            }

            foreach (var item in App.Context)
            {
                var para = report.Parameters[item.Key];
                if (para == null)
                    report.Parameters.Add(new DevExpress.XtraReports.Parameters.Parameter()
                    {
                        Name = item.Key,
                        Value = item.Value,
                        Visible = false
                    });
                else
                    para.Value = item.Value;
            }
            return report;

        }
    }
}
