using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using Microsoft.Office.Interop.Excel;
using DevExpress.XtraGrid.Views.Grid;
using System.Data;
using System.Drawing;

namespace BOSERP.Modules.Report
{
    class ExcelExporter
    {
        public ExcelExporter()
        {
        }

        public static void ExportToExcel(List<ExportExcelParameter> lstParameter)
        {
            Microsoft.Office.Interop.Excel.Application exApp = new Microsoft.Office.Interop.Excel.Application();
            Workbook exWorkBook = exApp.Workbooks.Add(XlWBATemplate.xlWBATWorksheet);
            Worksheet exSheet = (Worksheet)exWorkBook.Worksheets[1];
            exSheet.Activate();

            for (int i = 0; i < lstParameter.Count; i++)
            {
                ExportExcelParameter parameter = lstParameter[i];
                Range range = (Range)exSheet.Cells[parameter.PosX, parameter.PosY];

                range.Font.Color = ColorTranslator.ToOle(parameter.ForeColor);
                range.Font.Name = parameter.Font.Name;
                range.Font.Size = parameter.Font.Size;
                range.Font.Bold = parameter.Font.Bold;
                if (parameter.Value.GetType() == typeof(double))
                    range.NumberFormat = "#,##0.00";
                else if (parameter.Value.GetType() == typeof(float))
                    range.NumberFormat = "#,##0";
                if(parameter.BackColor != Color.Empty)
                    range.Interior.Color = ColorTranslator.ToOle(parameter.BackColor);
                range.Value2 = parameter.Value.ToString();
              
                if(parameter.Value.GetType() == typeof(System.Data.DataTable))
                {
                    System.Data.DataTable table = (System.Data.DataTable)parameter.Value;

                    for (int j = 0; j < table.Columns.Count; j++)
                    {
                        Range rangeCaption = (Range)exSheet.Cells[parameter.PosX, parameter.PosY + j];
                        rangeCaption.Value2 = table.Columns[j].Caption;
                        rangeCaption.ColumnWidth = table.Columns[j].DefaultValue;
                        rangeCaption.Font.Color = ColorTranslator.ToOle(Color.Black);
                        rangeCaption.Font.Size = "11";
                        rangeCaption.Font.Bold = FontStyle.Bold;
                        rangeCaption.Interior.Color = ColorTranslator.ToOle(Color.LightGray);
                    }

                    for (int j = 0; j < table.Rows.Count; j++)
                    {
                        for (int k = 0;  k < table.Columns.Count; k++)
                        {
                            Range rangeCell = (Range)exSheet.Cells[parameter.PosX + j + 1, parameter.PosY + k];
                            rangeCell.Font.Name = "Tahoma";
                            rangeCell.Font.Size = 10;
                            if (table.Rows[j][k].GetType() == typeof(string))
                                rangeCell.NumberFormat = "@";
                            else if (table.Rows[j][k].GetType() == typeof(double))
                                rangeCell.NumberFormat = "#,##0.00";
                            else if (table.Rows[j][k].GetType() == typeof(float))
                                rangeCell.NumberFormat = "#,##0";
                            rangeCell.Value2 = table.Rows[j][k];
                        }
                    }
                }
            }
            exApp.Visible = true;
        }
    }
}
