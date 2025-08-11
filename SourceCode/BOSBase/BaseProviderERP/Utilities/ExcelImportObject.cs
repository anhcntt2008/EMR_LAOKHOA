

using System;
using System.Data;
using System.Collections.Generic;
using System.Text;
using System.Reflection; // For Missing.Value and BindingFlags
using System.Runtime.InteropServices; // For COMException
using Microsoft.Office.Interop.Excel;
using System.Collections;
using System.IO;
using eMASLib;

namespace eMASERP
{
    class ExcelImportObject
    {
        Application Excelapp;
        Workbooks _workbooks;
        Workbook thisexcel;
        Range celin;
        _Worksheet worksheet;
        //Range celout;
        Sheets sheets;
        SortedList listcomments;
        SortedList listSheetProcessed;

        public ExcelImportObject()
        {
            Excelapp = null;
        }



        public Boolean Open(string Excelfile, Boolean Show)
        {
            object missing = Missing.Value;


            if (Excelfile != "")
            {


                if (File.Exists(Excelfile) == false)
                {
                    return false;
                }

                Excelapp = new Microsoft.Office.Interop.Excel.Application();

                Excelapp.Visible = Show; //true to show  or false not to show

                _workbooks = Excelapp.Workbooks;
                thisexcel = _workbooks.Open(Excelfile, missing,  false, missing,
                    missing, missing, missing, missing, missing, missing, missing, missing, missing,
                    missing, missing);

                sheets = thisexcel.Worksheets;
                worksheet = (_Worksheet)sheets.get_Item(1);

            //   Getcomments();
            }
            else
            {
                Excelapp = null;
            }

           
            return true;

        }

        public void Close()
        {

            if (Excelapp != null)
            {
                //listcomments.Clear();
                Excelapp.DisplayAlerts = false;
                Excelapp.Quit();
            }
            Excelapp = null;
            return;
        }


        public void ImportFromExcel()
        {
            listSheetProcessed = new SortedList();
            object missing = Missing.Value;
            String sheetname;
            _Worksheet curWorkSheet;

            for (int i = 1; i <= sheets.Count;i++ )
            {
                curWorkSheet = (_Worksheet)sheets.get_Item(i);
                sheetname = curWorkSheet.Name;
                if (IsSingleSheet(curWorkSheet))
                {
                    ImportSingleSheet(curWorkSheet);
                    listSheetProcessed.Add(sheetname,i);
                }

            }
            while (listSheetProcessed.Count < sheets.Count)
            {
                for (int i = 1; i <= sheets.Count; i++)
                {
                    curWorkSheet = (_Worksheet)sheets.get_Item(i);
                    sheetname = curWorkSheet.Name;
                    if (listSheetProcessed.IndexOfKey(sheetname) < 0)
                    {
                        WorkWithNoneSingleSheet(curWorkSheet);
                        
                        break;
                    }
                }
            }
        }

        public void WorkWithNoneSingleSheet(_Worksheet wsh)
        {

            _Worksheet sheetTemp;
            String mainTableName = wsh.Name;
            String otherTableName;
            ArrayList listKeyOfRelationSheet = new ArrayList();

            foreach (object shname in listSheetProcessed.Keys)            
            {
                    sheetTemp = (_Worksheet)sheets.get_Item(listSheetProcessed[shname]);
                    otherTableName = sheetTemp.Name;
                    String primaryKey = SqlDatabaseHelper.GetPrimaryKeyColumn(otherTableName);

                    if (SqlDatabaseHelper.ColumnIsExistInTable(mainTableName, primaryKey))
                    {
                        listKeyOfRelationSheet.Add(shname);
                    }
            }

            if (listKeyOfRelationSheet.Count > 0)
            {
                WorkWithNoneSingleSheet(wsh, listKeyOfRelationSheet);
                listSheetProcessed.Add(wsh.Name, wsh.Index);
            }
        }

        public void WorkWithNoneSingleSheet(_Worksheet wsh, ArrayList listKeyOfRelationSheet)
        {                 

                eMASDbUtil dbUtil = new eMASDbUtil();
                String TableName = wsh.Name;
                BusinessObject currentObject = BusinessObjectFactory.GetBusinessObject(TableName + "Info");
                BaseBusinessController currentObjectCtrl = new BaseBusinessController(currentObject.GetType());                

                int IDindex = 0;
                PropertyInfo[] properties = currentObject.GetType().GetProperties();
                foreach (PropertyInfo prop in properties)
                {
                    IDindex += 1;
                    if (dbUtil.IsPrimaryKey(TableName, prop.Name))                    
                        break;                  
                }

                for (int X = 1; X <= wsh.UsedRange.Rows.Count; X++)
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
                                                    if (currentObjectCtrl.IsExist(Convert.ToInt32(objValue)))
                                                    {
                                                        isExist = true;
                                                        break;
                                                    }
                                                }

                                                if (properties[Y - 1].PropertyType.Equals(typeof(Int32)))
                                                { dbUtil.SetPropertyValue(currentObject, properties[Y - 1].Name, Convert.ToInt32(objValue)); }
                                                else if (properties[Y - 1].PropertyType.Equals(typeof(Boolean)))
                                                    dbUtil.SetPropertyValue(currentObject, properties[Y - 1].Name, Convert.ToBoolean(objValue));
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
                                   if( IsRelationTable(currentObject, Convert.ToString(shname)) ==false)
                                        return;                           
                                }
                                currentObjectCtrl.CreateObject(currentObject);
                            }

                }

        }

        public Boolean IsRelationTable(BusinessObject busOBJ, String relationSheetName)
        {
                eMASDbUtil dbUtil = new eMASDbUtil();
                BusinessObject relateObj = BusinessObjectFactory.GetBusinessObject(relationSheetName + "Info");
                BaseBusinessController relateObjCtrl = new BaseBusinessController(relateObj.GetType());

                String primaryKey = SqlDatabaseHelper.GetPrimaryKeyColumn(relationSheetName);
                object IDvalue = dbUtil.GetPropertyValue(busOBJ, primaryKey);

                return (relateObjCtrl.GetObjectByID((int)IDvalue)!=null);

         }

        public Boolean IsSingleSheet(_Worksheet wsh) //only 1 ID
        {

            //chua kiem tra sheetname =objectname
            _Worksheet sheetTemp;
            String mainTableName = wsh.Name;
            String otherTableName;           

            for (int i = 1; i <= sheets.Count;i++ )
            {
                        if (i!= wsh.Index)
                        {
                            sheetTemp = (_Worksheet)sheets.get_Item(i);
                            otherTableName = sheetTemp.Name;
                            String primaryKey = SqlDatabaseHelper.GetPrimaryKeyColumn(otherTableName);

                            if (SqlDatabaseHelper.ColumnIsExistInTable(mainTableName, primaryKey))
                            {
                                return false;
                            }
                        }

            }
            return true;
        }

        public void ImportSingleSheet(_Worksheet wsh)
        {
            eMASDbUtil dbUtil = new eMASDbUtil();        
            String TableName = wsh.Name;
            BusinessObject currentObject = BusinessObjectFactory.GetBusinessObject(TableName + "Info");
            BaseBusinessController currentObjectCtrl = new BaseBusinessController(currentObject.GetType());

             int IDindex=0;
             PropertyInfo[] properties = currentObject.GetType().GetProperties();
             foreach (PropertyInfo prop in properties)
             {
                 IDindex += 1;
                 if (dbUtil.IsPrimaryKey(TableName, prop.Name)) {  break; }
             }

             for (int X = 1; X <= wsh.UsedRange.Rows.Count; X++)
             {
                     Boolean isExist = false;
                     for (int Y= 1; Y <= properties.Length; Y++)
                     {
                             Range celin = (Range)wsh.Cells[X, Y];
                             object objValue = celin.Text;

                             if (objValue != System.DBNull.Value && objValue.ToString().CompareTo("") != 0 && objValue.ToString().CompareTo("NULL") != 0)
                             {
                                
                                if (properties[Y - 1].PropertyType.Equals(typeof(Int32)))
                                    {dbUtil.SetPropertyValue(currentObject, properties[Y - 1].Name, Convert.ToInt32(objValue));}
                                else if (properties[Y - 1].PropertyType.Equals(typeof(Boolean)))
                                    dbUtil.SetPropertyValue(currentObject, properties[Y - 1].Name,Convert.ToBoolean(objValue));
                                else if (properties[Y - 1].PropertyType.Equals(typeof(short)))
                                    dbUtil.SetPropertyValue(currentObject, properties[Y - 1].Name,Convert.ToInt32(objValue));
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
                             

                             if (Y==IDindex)
                             {
                                 if (currentObjectCtrl.IsExist(Convert.ToInt32(objValue)) )
                                     {
                                         isExist = true;
                                         break;
                                     }
                             }
                     }

                    if(!isExist)
                    {
                        currentObjectCtrl.CreateObject(currentObject);
                    }

             }

            

        }

        public void ExportToExcel(BusinessObject CurrentObjectInfo)
        {
            object missing = Missing.Value;
            BaseBusinessController currentObjectCtrl = new BaseBusinessController(CurrentObjectInfo.GetType());
            Worksheet myWorksheet ;
            myWorksheet = (Worksheet)sheets.Add(missing, missing, missing, missing);
            myWorksheet.Name = eMASUtil.GetTableNameFromBusinessObject(CurrentObjectInfo);

            DataSet ds = currentObjectCtrl.GetAllObjects();
            //myWorksheet.UsedRange.Rows.Count = 0;
            foreach (DataRow row in ds.Tables[0].Rows)
            {
                BusinessObject objInfo = (BusinessObject)currentObjectCtrl.GetObjectFromDataRow(row);
                if (objInfo != null)
                {
                    PutValue(myWorksheet, objInfo);
                }
            }

            thisexcel.Save();
        }

        public void PutValue(Worksheet  wsh,BusinessObject CurrentInfo)
        {
            if (Excelapp == null)
                return;

            wsh.Rows.Count += 1;
            PropertyInfo[] properties = CurrentInfo.GetType().GetProperties();
            for (int i = 0; i < properties.Length; i++)
            {

                //tai sao wsh.UsedRange.Rows.Count ko tang ?

                    celin = (Range)wsh.Cells[wsh.UsedRange.Rows.Count,i+1];
                    object objValue = properties[i].GetValue(CurrentInfo, null);
                    celin.Value2 = objValue.ToString();

            }

        }
    }
}
