using System;
using System.Data;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Reflection; // For Missing.Value and BindingFlags
using System.Runtime.InteropServices; // For COMException
using Microsoft.Office.Interop.Excel;
using System.Collections;
using System.IO;
using DevExpress.XtraExport;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Export;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraEditors;
using BOSLib;

namespace BOSERP
{
    public class ExcelImportExportObject
    {
        private String filename = null;
        //for import
        private Microsoft.Office.Interop.Excel.Application Excelapp;
        private Workbooks workbooks;
        private Workbook mainExcelWorkbook;
        private Range celin;
        private Worksheet mainWorksheet;
        private Sheets mainWorkSheets;
        private SortedList listSheetProcessed;

        public event BOSLib.ProgressEventHandler ProgressEvent;
        private ProgressStatus Status;

        public ExcelImportExportObject()
        {
            Excelapp = null;
        }

        public Boolean OpenExcelFile(string Excelfile)
        {
            //Throw exception when can't open file
            try
            {
                object missing = Missing.Value;

                Excelapp = new Microsoft.Office.Interop.Excel.Application();
                Excelapp.Visible = false;
                Excelapp.DisplayAlerts = false;
                workbooks = Excelapp.Workbooks;

                filename = Excelfile;
                if (File.Exists(Excelfile) == false)
                {
                    mainExcelWorkbook = workbooks.Add(missing);
                }
                else
                {
                    mainExcelWorkbook = workbooks.Open(Excelfile, missing, false, missing,
                    missing, missing, missing, missing, missing, missing, missing, missing, missing,
                    missing, missing);

                }

                mainWorkSheets = mainExcelWorkbook.Worksheets;
                mainWorksheet = (Worksheet)mainWorkSheets.get_Item(4);

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public void CloseExcelFile()
        {


            mainExcelWorkbook.SaveAs(filename,

                                                        XlFileFormat.xlWorkbookNormal, Type.Missing, Type.Missing,

                                                     Type.Missing, Type.Missing, XlSaveAsAccessMode.xlNoChange,

                                                     Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
            workbooks.Close();

            if (Excelapp != null)
            {
                Excelapp.DisplayAlerts = false;
                Excelapp.Quit();
            }

            System.Runtime.InteropServices.Marshal.ReleaseComObject(Excelapp);

            return;
        }

        #region Export functions
        public Boolean ExportFromGridView(GridView gridView, String tablename)
        {
            Status = ProgressStatus.InProgress;
            Timer timer = new Timer();
            timer.Tick += new EventHandler(Timer_Tick);
            timer.Interval = 10;
            timer.Start();
            try
            {
                IExportProvider provider = new ExportXlsProvider(System.IO.Path.GetTempPath() + "temp.xls");
                BaseExportLink link = gridView.CreateExportLink(provider);
                (link as GridViewExportLink).ExpandAll = false;
                link.ExportTo(true);
                provider.Dispose();

                object missing = Missing.Value;

                if (File.Exists(System.IO.Path.GetTempPath() + "temp.xls") == false)
                {
                    return false;
                }

                Workbook myWorkBook = workbooks.Open(System.IO.Path.GetTempPath() + "temp.xls", missing, false, missing,
                                                            missing, missing, missing, missing, missing, missing,
                                                            missing, missing, missing, missing, missing);

                Worksheet mySheet = (Worksheet)myWorkBook.Worksheets.get_Item(1);
                mySheet.UsedRange.Copy(missing);

                Worksheet lastWorkSheet = (Worksheet)mainWorkSheets.Add(missing, mainWorkSheets.get_Item(mainWorkSheets.Count), missing, missing);
                lastWorkSheet.UsedRange.PasteSpecial(XlPasteType.xlPasteAll,
                                                            XlPasteSpecialOperation.xlPasteSpecialOperationNone, missing, missing);
                lastWorkSheet.Name = tablename;

                myWorkBook.Close(false, missing, false);
            }
            catch (System.Exception)
            {
                return false;
            }
            finally
            {
                Status = ProgressStatus.Complete;
            }
            return true;
        }
        #endregion

        #region Import functions

        public Boolean ImportFromExcel(String filename)
        {
            Status = ProgressStatus.InProgress;
            Timer timer = new Timer();
            timer.Tick += new EventHandler(Timer_Tick);
            timer.Interval = 10;
            timer.Start();
            try
            {
                listSheetProcessed = new SortedList();
                object missing = Missing.Value;
                String sheetname;
                Worksheet curWorkSheet;

                //import all single mainWorkSheets
                for (int i = 4; i <= mainWorkSheets.Count; i++)
                {
                    curWorkSheet = (Worksheet)mainWorkSheets.get_Item(i);
                    sheetname = curWorkSheet.Name;
                    if (IsSingleSheetInNoneProcessed(curWorkSheet))
                    {
                        ImportSingleSheet(curWorkSheet);
                        listSheetProcessed.Add(sheetname, i);
                    }
                    //Raise progress event
                    System.Windows.Forms.Application.DoEvents();
                }

                //import all none single mainWorkSheets
                while (listSheetProcessed.Count < mainWorkSheets.Count - 3)
                {
                    for (int i = 4; i <= mainWorkSheets.Count; i++)
                    {
                        curWorkSheet = (Worksheet)mainWorkSheets.get_Item(i);
                        sheetname = curWorkSheet.Name;
                        if (listSheetProcessed.IndexOfKey(sheetname) < 0)
                        {
                            if (WorkWithNoneSingleSheet(curWorkSheet))
                            {
                                break;
                            }
                        }
                        //Raise progress event
                        System.Windows.Forms.Application.DoEvents();
                    }
                }

                CloseExcelFile();
            }
            catch (System.Exception)
            {
                return false;
            }
            finally
            {
                Status = ProgressStatus.Complete;
            }
            return true;
        }

        public Boolean WorkWithNoneSingleSheet(Worksheet wsh)
        {

            Worksheet sheetTemp;
            String mainTableName = wsh.Name;
            String otherTableName;
            ArrayList listKeyOfRelationSheet = new ArrayList();

            //search all processedSheet relate with current sheet
            foreach (object shname in listSheetProcessed.Keys)
            {
                sheetTemp = (Worksheet)mainWorkSheets.get_Item(listSheetProcessed[shname]);
                otherTableName = sheetTemp.Name;
                String primaryKey = SqlDatabaseHelper.GetPrimaryKeyColumn(otherTableName);
                String foreignKey = "FK_" + primaryKey;

                if (SqlDatabaseHelper.ColumnIsExistInTable(mainTableName, foreignKey))
                {
                    listKeyOfRelationSheet.Add(shname);
                }

            }

            //work
            if (listKeyOfRelationSheet.Count > 0)
            {
                WorkWithNoneSingleSheet(wsh, listKeyOfRelationSheet);
                listSheetProcessed.Add(wsh.Name, wsh.Index);
                return true;
            }
            return false;
        }

        public void WorkWithNoneSingleSheet(Worksheet wsh, ArrayList listKeyOfRelationSheet)
        {

            BOSDbUtil dbUtil = new BOSDbUtil();
            String TableName = wsh.Name;
            BusinessObject currentObject = BusinessObjectFactory.GetBusinessObject(TableName + "Info");
            BaseBusinessController currentObjectCtrl = new BaseBusinessController(currentObject.GetType());

            //Create list to store all of id of business object in worksheet
            List<int> lstWorksheetID = new List<int>();
            DataSet dsOldObjects = currentObjectCtrl.GetAllObjects();

            int IDindex = 0;
            PropertyInfo[] properties = currentObject.GetType().GetProperties();
            foreach (PropertyInfo prop in properties)
            {
                IDindex += 1;
                if (dbUtil.IsPrimaryKey(TableName, prop.Name))
                    break;
            }

            for (int X = 2; X <= wsh.UsedRange.Rows.Count; X++)
            {
                Boolean isExist = false;
                for (int Y = 1; Y <= properties.Length; Y++)
                {
                    Range celin = (Range)wsh.Cells[X, Y];
                    object objValue = celin.Text;

                    if (objValue != System.DBNull.Value && objValue.ToString().CompareTo("") != 0 && objValue.ToString().CompareTo("NULL") != 0)
                    {
                        if (Y == IDindex)
                        {
                            int iObjectID = Convert.ToInt32(objValue);
                            lstWorksheetID.Add(iObjectID);
                            if (currentObjectCtrl.IsExist(iObjectID))
                            {
                                //If exist, must be updated
                                isExist = true;
                            }
                            else
                            {
                                BusinessObject obj = (BusinessObject)currentObjectCtrl.GetDeletedObjectByID(iObjectID);
                                if (obj != null)
                                    isExist = true;
                            }
                        }

                        if (properties[Y - 1].PropertyType.Equals(typeof(Int32)))
                        { dbUtil.SetPropertyValue(currentObject, properties[Y - 1].Name, Convert.ToInt32(objValue)); }
                        else if (properties[Y - 1].PropertyType.Equals(typeof(Boolean)))
                            dbUtil.SetPropertyValue(currentObject, properties[Y - 1].Name, Convert.ToBoolean(objValue.ToString().CompareTo("Checked")));
                        else if (properties[Y - 1].PropertyType.Equals(typeof(short)))
                            dbUtil.SetPropertyValue(currentObject, properties[Y - 1].Name, Convert.ToInt32(objValue));
                        else if (properties[Y - 1].PropertyType.Equals(typeof(double)))
                            dbUtil.SetPropertyValue(currentObject, properties[Y - 1].Name, Convert.ToDouble(objValue));
                        else if (properties[Y - 1].PropertyType.Equals(typeof(decimal)))
                            dbUtil.SetPropertyValue(currentObject, properties[Y - 1].Name, Convert.ToDecimal(objValue));
                        else if ((properties[Y - 1].PropertyType.Equals(typeof(String))) || (properties[Y - 1].PropertyType.Equals(typeof(string))))
                            dbUtil.SetPropertyValue(currentObject, properties[Y - 1].Name, Convert.ToString(objValue));
                        else if (properties[Y - 1].PropertyType.Equals(typeof(DateTime)))
                            dbUtil.SetPropertyValue(currentObject, properties[Y - 1].Name, Convert.ToDateTime(objValue));
                        else
                            continue;
                    }
                }

                if (!isExist)
                {
                    foreach (object shname in listKeyOfRelationSheet)
                    {
                        if (IsExistRelationObject(currentObject, Convert.ToString(shname)) == false)
                        {
                            Range currCel = (Range)wsh.Rows[X, Type.Missing];
                            currCel.Font.Color = System.Drawing.Color.Red.ToArgb();
                            return;
                        }
                    }
                    currentObjectCtrl.CreateObject(currentObject);
                }
                else
                {
                    Range currCel = (Range)wsh.Rows[X, Type.Missing];
                    currCel.Font.Color = System.Drawing.Color.Red.ToArgb();

                    //Update object
                    currentObjectCtrl.UpdateObject(currentObject);
                }

            }

            //Delete all object in database if it does not exist in worksheep
            foreach (DataRow row in dsOldObjects.Tables[0].Rows)
            {
                BusinessObject objBusiness = (BusinessObject)currentObjectCtrl.GetObjectFromDataRow(row);

                int id = (int)dbUtil.GetPropertyValue(objBusiness, properties[0].Name);
                if (!lstWorksheetID.Contains(id))
                {
                    currentObjectCtrl.DeleteObject(id);
                }
            }

        }

        public Boolean IsExistRelationObject(BusinessObject busOBJ, String relationSheetName)
        {
            BOSDbUtil dbUtil = new BOSDbUtil();
            BusinessObject relateObj = BusinessObjectFactory.GetBusinessObject(relationSheetName + "Info");
            BaseBusinessController relateObjCtrl = new BaseBusinessController(relateObj.GetType());

            String primaryKey = SqlDatabaseHelper.GetPrimaryKeyColumn(relationSheetName);
            String foreginKey = "FK_" + primaryKey;
            object IDvalue = dbUtil.GetPropertyValue(busOBJ, foreginKey);

            return (relateObjCtrl.GetObjectByID((int)IDvalue) != null);

        }

        public Boolean IsSingleSheetInNoneProcessed(Worksheet wsh) //only 1 ID
        {
            BOSDbUtil dbUtil = new BOSDbUtil();
            //chua kiem tra sheetname =objectname
            String mainTableName = wsh.Name;
            Worksheet sheetOther;
            String otherTableName;

            for (int i = 4; i <= mainWorkSheets.Count; i++)
            {
                if (i == wsh.Index)
                    continue;

                sheetOther = (Worksheet)mainWorkSheets.get_Item(i);
                otherTableName = sheetOther.Name;
                // if (listSheetProcessed.ContainsKey(otherTableName))                    
                //  continue;

                String otherPrimaryKey = SqlDatabaseHelper.GetPrimaryKeyColumn(otherTableName);
                String foreignKey = "FK_" + otherPrimaryKey;

                if (SqlDatabaseHelper.ColumnIsExistInTable(mainTableName, foreignKey))
                {
                    return false;
                }


            }
            return true;
        }

        public void ImportSingleSheet(Worksheet wsh)
        {
            BOSDbUtil dbUtil = new BOSDbUtil();
            String TableName = wsh.Name;
            BusinessObject currentObject = BusinessObjectFactory.GetBusinessObject(TableName + "Info");
            BaseBusinessController currentObjectCtrl = new BaseBusinessController(currentObject.GetType());

            //Create list to store all of id of business object in worksheet
            List<int> lstWorksheetID = new List<int>();
            DataSet dsOldObjects = currentObjectCtrl.GetAllObjects();

            int IDindex = 0;
            PropertyInfo[] properties = currentObject.GetType().GetProperties();
            foreach (PropertyInfo prop in properties)
            {
                IDindex += 1;
                if (dbUtil.IsPrimaryKey(TableName, prop.Name)) { break; }
            }

            for (int X = 2; X <= wsh.UsedRange.Rows.Count; X++)
            {
                Boolean isExist = false;
                for (int Y = 1; Y <= properties.Length; Y++)
                {
                    Range celin = (Range)wsh.Cells[X, Y];
                    object objValue = celin.Text;

                    if (objValue != System.DBNull.Value && objValue.ToString().CompareTo("") != 0 && objValue.ToString().CompareTo("NULL") != 0)
                    {

                        if (properties[Y - 1].PropertyType.Equals(typeof(Int32)))
                        { dbUtil.SetPropertyValue(currentObject, properties[Y - 1].Name, Convert.ToInt32(objValue)); }
                        else if (properties[Y - 1].PropertyType.Equals(typeof(Boolean)))
                            dbUtil.SetPropertyValue(currentObject, properties[Y - 1].Name, Convert.ToBoolean(objValue.ToString().CompareTo("Checked")));
                        else if (properties[Y - 1].PropertyType.Equals(typeof(short)))
                            dbUtil.SetPropertyValue(currentObject, properties[Y - 1].Name, Convert.ToInt32(objValue));
                        else if (properties[Y - 1].PropertyType.Equals(typeof(double)))
                            dbUtil.SetPropertyValue(currentObject, properties[Y - 1].Name, Convert.ToDouble(objValue));
                        else if (properties[Y - 1].PropertyType.Equals(typeof(decimal)))
                            dbUtil.SetPropertyValue(currentObject, properties[Y - 1].Name, Convert.ToDecimal(objValue));
                        else if ((properties[Y - 1].PropertyType.Equals(typeof(String))) || (properties[Y - 1].PropertyType.Equals(typeof(string))))
                            dbUtil.SetPropertyValue(currentObject, properties[Y - 1].Name, Convert.ToString(objValue));
                        else if (properties[Y - 1].PropertyType.Equals(typeof(DateTime)))
                            dbUtil.SetPropertyValue(currentObject, properties[Y - 1].Name, Convert.ToDateTime(objValue));
                        else
                            continue;
                    }


                    if (Y == IDindex)
                    {
                        int iObjectID = Convert.ToInt32(objValue);
                        lstWorksheetID.Add(iObjectID);
                        if (currentObjectCtrl.IsExist(iObjectID))
                        {
                            //If exist, must be updated
                            isExist = true;
                        }
                        else
                        {
                            BusinessObject obj = (BusinessObject)currentObjectCtrl.GetDeletedObjectByID(iObjectID);
                            if (obj != null)
                                isExist = true;
                        }
                    }
                }

                if (!isExist)
                {
                    currentObjectCtrl.CreateObject(currentObject);
                }
                else
                {
                    currentObjectCtrl.UpdateObject(currentObject);
                    Range currCel = (Range)wsh.Rows[X, Type.Missing];
                    currCel.Font.Color = System.Drawing.Color.Red.ToArgb();
                }
            }

            //Delete all object in database if it does not exist in worksheep
            foreach (DataRow row in dsOldObjects.Tables[0].Rows)
            {
                BusinessObject objBusiness = (BusinessObject)currentObjectCtrl.GetObjectFromDataRow(row);

                int id = (int)dbUtil.GetPropertyValue(objBusiness, properties[0].Name);
                if (!lstWorksheetID.Contains(id))
                {
                    currentObjectCtrl.DeleteObject(id);
                }
            }
        }
        #endregion

        #region Ultilities
        private void Timer_Tick(object sender, EventArgs e)
        {
            ProgressEvent(this, new BOSLib.ProgressEventArgs(Status));
            if (Status == ProgressStatus.Complete)
                (sender as Timer).Stop();
        }
        #endregion

    }
}
