using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DevExpress.XtraReports.UI;
using System.Data;
using System.Globalization;
using System.Reflection;
using BOSLib;
using System.Windows.Forms;

namespace BOSERP.Utilities
{
    public class XtraReportHelper
    {        
        /// <summary>
        /// Print a report to a printer
        /// </summary>
        /// <param name="report">Report</param>
        /// <param name="printerName">Printer name</param>
        public static void PrintToPrinter(XtraReport report, string printerName)
        {
            SetFormatField(report);

            report.Print(printerName);
        }

        /// <summary>
        /// Set format field for control in report
        /// </summary>
        /// <param name="report">Current report</param>
        public static void SetFormatField(XtraReport report)
        {
            foreach (Band band in report.Bands)
            {
                SetFormatField(band.Controls);
            }
        }

        public static void SetFormatField(XtraReport report, string fieldName, string formatString)
        {

        }

        /// <summary>
        /// Set the display format of data bound to the report's controls
        /// </summary>
        /// <param name="controls">Control collection</param>
        private static void SetFormatField(XRControlCollection controls)
        {
            foreach (XRControl control in controls)
            {
                if (control.GetType() == typeof(XRTable))
                {
                    XRTable table = (XRTable)control;
                    foreach (XRTableCell tableCell in table.Rows[0].Cells)
                    {
                        if (tableCell.DataBindings.Count > 0)
                        {
                            XRBinding binding = tableCell.DataBindings[0];
                            SetFormatControlBinding(tableCell, binding);
                        }
                    }
                }
                else
                {
                    if (control.DataBindings.Count > 0)
                    {
                        XRBinding binding = control.DataBindings[0];
                        SetFormatControlBinding(control, binding);
                    }
                }

                if (control.Controls.Count > 0)
                {
                    SetFormatField(control.Controls);
                }
            }
        }

        /// <summary>
        /// Set format for control binding
        /// </summary>
        /// <param name="ctrl">Control the data is bound to</param>
        /// <param name="binding">Data binding of the control</param>
        private static void SetFormatControlBinding(XRControl ctrl, XRBinding binding)
        {
            BOSDbUtil dbUtil = new BOSDbUtil();
            if (binding.DataSource is DataSet || binding.DataSource is DataTable)
            {
                DataTable table = null;
                if (binding.DataSource is DataSet)
                {
                    table = ((DataSet)binding.DataSource).Tables[0];
                }
                else
                {
                    table = (DataTable)binding.DataSource;
                }
                string[] arr = binding.DataMember.ToString().Split('.');
                if (arr.Length > 1)
                {
                    string columnName = arr[1];
                    if (table.Rows.Count > 0)
                    {
                        string tableName = dbUtil.GetTableNameByColumnName(columnName);
                        if (string.IsNullOrEmpty(tableName))
                        {
                            STFieldColumnsController objFieldColumnsController = new STFieldColumnsController();
                            STFieldsInfo objFieldsInfo = objFieldColumnsController.GetFirstFieldByColumnFieldName(columnName);
                            if (objFieldsInfo != null)
                            {
                                tableName = objFieldsInfo.STFieldDataSource;
                            }
                        }
                        if (!string.IsNullOrEmpty(tableName))
                        {
                            STFieldFormatGroupsInfo objFormatGroupsInfo = BOSUtil.GetColumnFormat(tableName, columnName);
                            if (objFormatGroupsInfo != null)
                            {                                
                                binding.FormatString = "{0:" + objFormatGroupsInfo.STFieldFormatGroupFormatString + "}";
                                if (ctrl is XRLabel)
                                {
                                    (ctrl as XRLabel).Summary.FormatString = binding.FormatString;
                                }
                            }
                        }
                    }
                }
            }
            else if (binding.DataSource is IList)
            {
                IList lst = (IList)binding.DataSource;                
                if (lst.Count > 0)
                {
                    PropertyInfo prop = lst[0].GetType().GetProperty(binding.DataMember);
                    if (prop != null)
                    {
                        string tableName = BOSUtil.GetTableNameFromBusinessObject((BusinessObject)lst[0]);
                        if (!string.IsNullOrEmpty(tableName))
                        {
                            STFieldFormatGroupsInfo objFormatGroupsInfo = BOSUtil.GetColumnFormat(tableName, binding.DataMember);
                            if (objFormatGroupsInfo != null)
                            {
                                binding.FormatString = "{0:" + objFormatGroupsInfo.STFieldFormatGroupFormatString + "}";
                                if (ctrl is XRLabel)
                                {                                    
                                    (ctrl as XRLabel).Summary.FormatString = binding.FormatString;
                                }
                            }
                        }
                    }
                }
            }                        
        }
    }
}
