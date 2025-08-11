using System;
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
    class ExcelCalculation
    {

        Application Excelapp;
        Workbooks _workbooks;
        Workbook thisexcel;
        Range celin;
        _Worksheet worksheet;
        //Range celout;
        //Sheets sheets;
        SortedList listcomments;


        public ExcelCalculation()
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
                thisexcel = _workbooks.Open(Excelfile, missing, false, missing,
                    missing, missing, missing, missing, missing, missing, missing, missing, missing,
                    missing, missing);

                Sheets sheets = thisexcel.Worksheets;
                worksheet = (_Worksheet)sheets.get_Item(1);

                Getcomments();
            }
            else
            {
                Excelapp = null;
            }


            return true;

        }

        private void Getcomments()
        {
            listcomments = new SortedList();

            object missing = Missing.Value;
            int rows, cols;

            for (rows = 1; rows < 30; rows++)
                for (cols = 1; cols < 30; cols++)
                {
                    {
                        celin = (Range)worksheet.Cells[rows, cols];
                        if (celin.Comment != null)
                        {
                            // make a list for all excel commentars
                            String CommentName = celin.Comment.Text(missing, missing, missing);
                            if (listcomments[CommentName] == null)
                                listcomments.Add(CommentName, new System.Drawing.Point(rows, cols));
                        }

                    }
                }




            return;
        }

        public void PutValue(ERPModuleEntities CurrentModuleEntity)
        {
            if (Excelapp == null)
                return;


            PropertyInfo[] properties = CurrentModuleEntity.MainObject.GetType().GetProperties();
            for (int i = 0; i < properties.Length; i++)
            {
                if (listcomments[properties[i].Name] != null)
                {
                    // is in excel --> put value
                    System.Drawing.Point koor = new System.Drawing.Point();
                    koor = (System.Drawing.Point)listcomments[properties[i].Name];
                    celin = (Range)worksheet.Cells[koor.X, koor.Y];
                    object objValue = properties[i].GetValue((MAProductsInfo)CurrentModuleEntity.MainObject, null);
                    celin.Value2 = objValue.ToString();

                }


            }
        }
        public void PutValue(BusinessObject CurrentInfo)
        {
            if (Excelapp == null)
                return;

            PropertyInfo[] properties = CurrentInfo.GetType().GetProperties();
            for (int i = 0; i < properties.Length; i++)
            {
                if (listcomments[properties[i].Name] != null)
                {
                    // is in excel --> put value
                    System.Drawing.Point koor = new System.Drawing.Point();
                    koor = (System.Drawing.Point)listcomments[properties[i].Name];
                    celin = (Range)worksheet.Cells[koor.X, koor.Y];
                    object objValue = properties[i].GetValue((MAProductsInfo)CurrentInfo, null);
                    celin.Value2 = objValue.ToString();

                }

            }

        }

        public void GetValue(ERPModuleEntities CurrentModuleEntity)
        {

            if (Excelapp == null)
                return;

            PropertyInfo[] properties = CurrentModuleEntity.MainObject.GetType().GetProperties();
            for (int i = 0; i < properties.Length; i++)
            {
                String strGetName = "Ret_" + properties[i].Name;

                if (listcomments[strGetName] != null)
                {
                    // is in excel --> put value
                    System.Drawing.Point koor = new System.Drawing.Point();
                    koor = (System.Drawing.Point)listcomments[strGetName];
                    celin = (Range)worksheet.Cells[koor.X, koor.Y];
                    object objValue = celin.Value2;
                    properties[i].SetValue((MAProductsInfo)CurrentModuleEntity.MainObject, objValue, null);

                }




            }

        }
        public void GetValue(BusinessObject CurrentInfo)
        {

            if (Excelapp == null)
                return;

            PropertyInfo[] properties = CurrentInfo.GetType().GetProperties();
            for (int i = 0; i < properties.Length; i++)
            {
                String strGetName = "Ret_" + properties[i].Name;

                if (listcomments[strGetName] != null)
                {
                    // is in excel --> put value
                    System.Drawing.Point koor = new System.Drawing.Point();
                    koor = (System.Drawing.Point)listcomments[strGetName];
                    celin = (Range)worksheet.Cells[koor.X, koor.Y];
                    object objValue = celin.Value2;
                    properties[i].SetValue((MAProductsInfo)CurrentInfo, objValue, null);

                }




            }

        }



        public void Close()
        {

            if (Excelapp != null)
            {
                listcomments.Clear();
                Excelapp.DisplayAlerts = false;
                Excelapp.Quit();
            }
            Excelapp = null;
            return;
        }

        public Boolean OpenForEditing(string Excelfile)
        {
            try
            {
                if ((Excelfile == "") || (File.Exists(Excelfile) == false))
                    return false;

                object missing = Missing.Value;
                Excelapp = new Microsoft.Office.Interop.Excel.Application();                

                Excelapp.Visible = true; //true to show  or false not to show

                _workbooks = Excelapp.Workbooks;
                thisexcel = _workbooks.Open(Excelfile, missing, false, missing,
                    missing, missing, missing, missing, missing, missing, missing, missing, missing,
                    missing, missing);

                Excelapp.Run("SetzeWerteC", missing, missing, missing, missing, missing, missing,
                            missing, missing, missing, missing, missing, missing, missing, missing, missing, missing,
                            missing, missing, missing, missing, missing, missing, missing, missing,
                            missing, missing, missing, missing, missing, missing);




                return true;
            }
            catch (Exception e)
            {
                System.Windows.Forms.MessageBox.Show(e.Message);
                return false;
            }
        }

        public Boolean OpenForEditingProf(string Excelfile)
        {

            if ((Excelfile == "") || (File.Exists(Excelfile) == false))
                return false;

            object missing = Missing.Value;
            Excelapp = new Microsoft.Office.Interop.Excel.Application();

            Excelapp.Visible = true; //true to show  or false not to show

            _workbooks = Excelapp.Workbooks;
            thisexcel = _workbooks.Open(Excelfile, missing, false, missing,
                missing, missing, missing, missing, missing, missing, missing, missing, missing,
                missing, missing);










            return true;
        }



    }
}
