using System;
using System.Collections.Generic;
using System.Text;
using System.Transactions;
using System.Windows.Forms;
using BOSLib;
using BOSCommon;
using Localization;
using BOSComponent;
using DevExpress.XtraEditors;
using System.Data;
using BOSERP.Modules.Report;
using System.IO;
using System.Linq;
using BOSERP.Modules.ME.MEService.Localization;

namespace BOSERP.Modules.MEService
{
    public class MEServiceModule : BaseModuleERP
    {
        #region Constants        
        public const string ServiceGridControlName = "fld_dgcICProducts";
        public const string ProductGroupLookupEditName = "fld_lkeICProductGroupID";
        public const string ProductLookupEditName = "fld_lkeFK_ICProductID";
        public const string EmployeeCheckedComboBoxEditName = "fld_ccbeEmployee";
        public const string FileTextEditName = "fld_txtFile";
        #endregion

        #region Variable
        private BOSLookupEdit ProductGroupLookupEdit;
        private BOSLookupEdit ProductLookupEdit;
        private DevExpress.XtraEditors.CheckedComboBoxEdit EmployeeCheckedComboBoxEdit;
        private TextEdit FileTextEdit;

        #endregion

        public MEServiceModule()
        {
            Name = "MEService";
            CurrentModuleEntity = new MEServiceEntities();
            CurrentModuleEntity.Module = this;
            InitializeModule();

            ProductGroupLookupEdit = (BOSLookupEdit)Controls[MEServiceModule.ProductGroupLookupEditName];
            ProductLookupEdit = (BOSLookupEdit)Controls[MEServiceModule.ProductLookupEditName];
            EmployeeCheckedComboBoxEdit = (DevExpress.XtraEditors.CheckedComboBoxEdit)Controls[MEServiceModule.EmployeeCheckedComboBoxEditName];
            FileTextEdit = (TextEdit)Controls[MEServiceModule.FileTextEditName];

            InvalidateEmployeeCheckedComboboxEdit();

            CurrentModuleEntity.Invalidate(BOSCommon.Department.Service);
        }

        /// <summary>
        /// Add category to list
        /// </summary>
        public void AddItemToCategoryList(string productGroupName, string productGroupNo)
        {
            MEServiceEntities entity = (MEServiceEntities)CurrentModuleEntity;
            ICProductGroupsInfo objProductGroupsInfoParent = (ICProductGroupsInfo)entity.ModuleObjects[TableName.ICProductGroupsTableName];
            int productGroupParentID = objProductGroupsInfoParent.ICProductGroupID;
            entity.SetDefaultModuleObject(TableName.ICProductGroupsTableName);
            ICProductGroupsInfo objProductGroupsInfo = (ICProductGroupsInfo)entity.ModuleObjects[TableName.ICProductGroupsTableName];
            objProductGroupsInfo.ICProductGroupName = productGroupName;
            objProductGroupsInfo.ICProductGroupNo = productGroupNo;
            objProductGroupsInfo.ICProductGroupParentID = productGroupParentID;
            objProductGroupsInfo.FK_ICDepartmentID = BOSCommon.Department.Service;
            objProductGroupsInfo.ICProductList = null;
            if (!string.IsNullOrEmpty(objProductGroupsInfo.ICProductGroupName))
            {
                objProductGroupsInfo.ICProductGroupID = entity.SaveServiceGroup(objProductGroupsInfo);
                entity.ICProductGroupList.CurrentObject.SubList.Add(objProductGroupsInfo);
                entity.ICProductGroupList.TreeListControl.RefreshDataSource();
            }
            else
            {
                MessageBox.Show(ServiceLocalizedResources.ProductGroupNameIsNullErrorMessage, "#Message#",
                                                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Edit selected product service group from tree list control
        /// </summary>
        public void EditProductServiceGroup()
        {
            MEServiceEntities entity = (MEServiceEntities)CurrentModuleEntity;
            ICProductGroupsInfo objProductGroupsInfo = (ICProductGroupsInfo)entity.ModuleObjects[TableName.ICProductGroupsTableName];
            guiAddServiceGroup addServiceGroupForm = new guiAddServiceGroup();
            addServiceGroupForm.Module = this;
            addServiceGroupForm.fld_txtServiceGroupName.Text = objProductGroupsInfo.ICProductGroupName;
            addServiceGroupForm.fld_txtServiceGroupNo.Text = objProductGroupsInfo.ICProductGroupNo;
            addServiceGroupForm.fld_btnAddServiceGroup.Text = ServiceLocalizedResources.UpdateService;
            addServiceGroupForm.Text = ServiceLocalizedResources.EditServiceGroup;
            if (addServiceGroupForm.ShowDialog() == DialogResult.OK)
            {
                if (!string.IsNullOrEmpty(addServiceGroupForm.fld_txtServiceGroupName.Text) && !string.IsNullOrEmpty(addServiceGroupForm.fld_txtServiceGroupNo.Text))
                {
                    objProductGroupsInfo.ICProductGroupName = addServiceGroupForm.fld_txtServiceGroupName.Text;
                    objProductGroupsInfo.ICProductGroupNo = addServiceGroupForm.fld_txtServiceGroupNo.Text;
                    entity.ICProductGroupList.ChangeObjectFromList();
                    entity.SaveServiceGroup(objProductGroupsInfo);
                }
                else
                {
                    MessageBox.Show(ServiceLocalizedResources.ProductGroupNameIsNullErrorMessage, "#Message#",
                                                                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        /// <summary>
        /// Delete item from product group tree list
        /// </summary>
        public void DeleteItemFromProductGroupTreeList()
        {
            //if (MessageBox.Show("Các dịch vụ trong nhóm sẽ bị xóa." + ServiceLocalizedResources.RemoveSelectedServiceGroupMessage, "#Message#",
            //                            MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            //{
                MEServiceEntities entity = (MEServiceEntities)CurrentModuleEntity;
                ICProductGroupsInfo objProductGroupsInfo = (ICProductGroupsInfo)entity.ModuleObjects[TableName.ICProductGroupsTableName];
                ICProductGroupsController objProductGroupsController = new ICProductGroupsController();
                ICProductsController proDucCtrol = new ICProductsController();

                var productList = proDucCtrol.GetAllDataByForeignColumn("FK_ICProductGroupID", objProductGroupsInfo.ICProductGroupID);

                if (productList.Tables[0].Rows.Count > 0)
                {
                    MessageBox.Show("Có tồn tại dịch vụ trong nhóm", "#Message#", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                objProductGroupsController.DeleteObject(objProductGroupsInfo.ICProductGroupID);
                entity.ICProductGroupList.RemoveSelectedRowObjectFromList();
                
                //[23/04/2019][Khong cho xoa cac thanh phan trong nhom]
                //entity.DeleteServiceGroup(objProductGroupsInfo);
            //}
        }

        /// <summary>
        /// Save product service list
        /// </summary>
        public void SaveProductServiceList()
        {
            MEServiceEntities entity = (MEServiceEntities)CurrentModuleEntity;
            entity.SaveProductServiceList();
            MessageBox.Show(ServiceLocalizedResources.SaveSuccessfullyMessage, "#Message#",
                                                                        MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        /// <summary>
        /// Invalidate employee checked coxmboboxEdit
        /// </summary>
        private void InvalidateEmployeeCheckedComboboxEdit()
        {
            HREmployeesController objEmployeesController = new HREmployeesController();
            DataSet ds = objEmployeesController.GetAllObjects();
            EmployeeCheckedComboBoxEdit.Properties.DataSource = ds.Tables[0];
            EmployeeCheckedComboBoxEdit.Properties.ValueMember = "HREmployeeID";
            EmployeeCheckedComboBoxEdit.Properties.DisplayMember = "HREmployeeName";
        }

        /// <summary>
        /// Invalidate product lookup edit by product group
        /// </summary>
        public void InvalidateProductByProductGroup()
        {
            ICProductsController objProductsController = new ICProductsController();
            //UtHV 24032017 fix bug
            if (!string.IsNullOrEmpty(ProductGroupLookupEdit.EditValue.ToString()))
            {
                DataSet ds = objProductsController.GetProductList(5, Convert.ToInt32(ProductGroupLookupEdit.EditValue), null, null);
                ProductLookupEdit.Properties.DataSource = ds.Tables[0];
            }
        }

        /// <summary>
        /// Export commission to excel for editing
        /// </summary>
        public void ExportCommissionToExcel()
        {
            //Get product list
            List<ICProductsInfo> productList = GetProductList();

            //Get employee list
            List<HREmployeesInfo> employeeList = GetEmployeeList();

            ExportToExcel(productList, employeeList);
        }

        /// <summary>
        /// Get product list
        /// </summary>
        /// <returns></returns>
        public List<ICProductsInfo> GetProductList()
        {
            ICProductsController objProductsController = new ICProductsController();
            List<ICProductsInfo> productList = new List<ICProductsInfo>();

            if (ProductLookupEdit.EditValue != null)
            {
                ICProductsInfo objProductsInfo;
                objProductsInfo = (ICProductsInfo)objProductsController.GetObjectByID(Convert.ToInt32(ProductLookupEdit.EditValue));

                ICProductGroupsController objProductGroupsController = new ICProductGroupsController();
                productList.Add(objProductsInfo);
            }
            else
            {
                if (ProductGroupLookupEdit.EditValue != null)
                {
                    productList = objProductsController.GetProductList_2(5, Convert.ToInt32(ProductGroupLookupEdit.EditValue), null, null);
                }
                else
                {
                    productList = objProductsController.GetProductList_2(5, null, null, null);
                }
            }
            return productList;
        }

        /// <summary>
        /// Get employee list
        /// </summary>
        public List<HREmployeesInfo> GetEmployeeList()
        {
            //Get employee list
            HREmployeesController objEmployeesController = new HREmployeesController();
            List<HREmployeesInfo> employeeList = new List<HREmployeesInfo>();
            if (EmployeeCheckedComboBoxEdit.EditValue != null)
            {
                string value = EmployeeCheckedComboBoxEdit.EditValue.ToString();
                if (value != "")
                {
                    string[] arrayValue = value.Split(',');
                    for (int i = 0; i < arrayValue.Length; i++)
                    {
                        HREmployeesInfo objEmployeesInfo = (HREmployeesInfo)objEmployeesController.GetObjectByID(Convert.ToInt32(arrayValue[i].Trim()));
                        employeeList.Add(objEmployeesInfo);
                    }
                }
            }
            return employeeList;
        }

        /// <summary>
        /// Import commission from excel to system
        /// </summary>
        public void ImportCommissionFromExcel()
        {
            string curFile = FileTextEdit.Text;
            if (File.Exists(curFile))
            {
                MEServiceEntities entity = (MEServiceEntities)CurrentModuleEntity;

                Microsoft.Office.Interop.Excel.Application xlApp;
                Microsoft.Office.Interop.Excel.Workbook xlWorkBook;
                Microsoft.Office.Interop.Excel.Worksheet xlWorkSheet;
                Microsoft.Office.Interop.Excel.Range range;

                string productValue;
                string employeeValue;
                int productID;
                int employeeID;
                double commissionValue;
                int rCnt = 0;
                int cCnt = 0;

                xlApp = new Microsoft.Office.Interop.Excel.ApplicationClass();
                xlWorkBook = xlApp.Workbooks.Open(curFile, 0, true, 5, "", "", true, Microsoft.Office.Interop.Excel.XlPlatform.xlWindows, "\t", false, false, 0, true, 1, 0);
                xlWorkSheet = (Microsoft.Office.Interop.Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);

                range = xlWorkSheet.UsedRange;

                BOSList<ICProductEmployeesInfo> list = new BOSList<ICProductEmployeesInfo>();

                for (rCnt = 2; rCnt <= range.Rows.Count; rCnt++)
                {
                    for (cCnt = 3; cCnt <= range.Columns.Count; cCnt++)
                    {
                        //Get product id
                        productValue = (string)(range.Cells[rCnt, 2] as Microsoft.Office.Interop.Excel.Range).Value2;
                        string[] arrayValue = productValue.Split('-');
                        productID = Convert.ToInt32(arrayValue[0].ToString());

                        //Get employee id
                        employeeValue = (string)(range.Cells[1, cCnt] as Microsoft.Office.Interop.Excel.Range).Value2;
                        arrayValue = employeeValue.Split('-');
                        employeeID = Convert.ToInt32(arrayValue[0].ToString());

                        //Commision
                        string value2 = (range.Cells[rCnt, cCnt] as Microsoft.Office.Interop.Excel.Range).Value2 == null ? "0" :
                                                (range.Cells[rCnt, cCnt] as Microsoft.Office.Interop.Excel.Range).Value2.ToString();
                        commissionValue = double.Parse(value2);

                        ICProductEmployeesController objProductEmployeesController = new ICProductEmployeesController();
                        ICProductEmployeesInfo objProductEmployeesInfo = objProductEmployeesController.GetProductEmployeeByProductIDAndEmployeeID(productID, employeeID);

                        if (objProductEmployeesInfo == null)
                        {
                            if (commissionValue > 0)
                            {
                                objProductEmployeesInfo = new ICProductEmployeesInfo();
                                objProductEmployeesInfo.FK_ICProductID = productID;
                                objProductEmployeesInfo.FK_HREmployeeID = employeeID;
                                objProductEmployeesInfo.ICProductEmployeeCommissionPercent = commissionValue;
                                objProductEmployeesInfo.AACreatedDate = DateTime.Now;
                                objProductEmployeesInfo.AACreatedUser = BOSApp.CurrentUser;
                                objProductEmployeesController.CreateObject(objProductEmployeesInfo);
                            }
                        }
                        else
                        {
                            objProductEmployeesInfo.ICProductEmployeeCommissionPercent = commissionValue;
                            objProductEmployeesController.UpdateObject(objProductEmployeesInfo);
                        }

                    }
                }
                xlWorkBook.Close(true, null, null);
                xlApp.Quit();

                releaseObject(xlWorkSheet);
                releaseObject(xlWorkBook);
                releaseObject(xlApp);

                MessageBox.Show(ServiceLocalizedResources.ImportSuccessfullyMessage, "#Message#", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        /// <summary>
        /// View commmission
        /// </summary>
        public void ViewCommission()
        {
            MEServiceEntities entity = (MEServiceEntities)CurrentModuleEntity;

            ICProductEmployeesController objProductEmployeesController = new ICProductEmployeesController();
            List<ICProductEmployeesInfo> productEmployeeList = objProductEmployeesController.GetAllProductEmployee();

            //Get product list
            List<ICProductsInfo> productList = GetProductList();

            //Get employee list
            List<HREmployeesInfo> employeeList = GetEmployeeList();

            List<ICProductEmployeesInfo> newProductEmployeeList = new List<ICProductEmployeesInfo>();

            productEmployeeList = productEmployeeList.Where(i => productList.Exists(p => p.ICProductID == i.FK_ICProductID)).ToList();
            productEmployeeList = productEmployeeList.Where(i => employeeList.Exists(p => p.HREmployeeID == i.FK_HREmployeeID)).ToList();

            entity.ICProductEmployeeList.Invalidate(productEmployeeList);
            entity.ICProductEmployeeList.GridControl.RefreshDataSource();

            entity.ICProductEmployeeList.SaveItemObjects();
        }

        /// <summary>
        /// Save product employee list
        /// </summary>
        public void SaveProductEmployeeList()
        {
            MEServiceEntities entity = (MEServiceEntities)CurrentModuleEntity;
            entity.ICProductEmployeeList.SaveItemObjects();

            MessageBox.Show(ServiceLocalizedResources.SaveSuccessfullyMessage, "#Message#", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        /// <summary>
        /// Open dialog to choose file
        /// </summary>
        public void ChooseFile()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();

            openFileDialog.Filter = "Excel files 2002-2003 (*.xls)|*.xls|Excel files 2007-2010 (*.xlsx)|*.xlsx";
            openFileDialog.FilterIndex = 2;
            openFileDialog.RestoreDirectory = true;

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                FileTextEdit.Text = openFileDialog.FileName.ToString();
            }
        }

        /// <summary>
        /// Export to excel file
        /// </summary>
        /// <param name="productList"></param>
        /// <param name="employeeList"></param>
        public void ExportToExcel(List<ICProductsInfo> productList, List<HREmployeesInfo> employeeList)
        {
            List<ExportExcelParameter> lstParameter = new List<ExportExcelParameter>();
            lstParameter.AddRange(GetExcelContent(productList, employeeList));
            //ExcelExporter.ExportToExcel(lstParameter);
        }

        /// <summary>
        /// Get excel content from product list and employee list
        /// </summary>
        /// <param name="productList"></param>
        /// <param name="employeeList"></param>
        /// <returns></returns>
        public List<ExportExcelParameter> GetExcelContent(List<ICProductsInfo> productList, List<HREmployeesInfo> employeeList)
        {
            ICProductEmployeesController objProductEmployeesController = new ICProductEmployeesController();
            ICProductEmployeesInfo objProductEmployeesInfo;

            DataTable table = new DataTable();

            //Column service group
            DataColumn col = new DataColumn();
            col.ColumnName = ServiceLocalizedResources.ServiceGroup;
            table.Columns.Add(col);

            //Column service
            col = new DataColumn();
            col.ColumnName = ServiceLocalizedResources.Service;
            table.Columns.Add(col);

            //Init column foreach employee
            for (int j = 0; j < employeeList.Count; j++)
            {
                col = new DataColumn();
                col.ColumnName = employeeList[j].HREmployeeID + "-" + employeeList[j].HREmployeeName;
                table.Columns.Add(col);
            }

            for (int i = 0; i < productList.Count; i++)
            {
                ICProductsInfo objProductsInfo = productList[i];
                DataRow row = table.NewRow();
                for (int j = 0; j < employeeList.Count; j++)
                {
                    HREmployeesInfo objEmployeesInfo = employeeList[j];
                    if (j == 0)
                    {
                        row[0] = objProductsInfo.ICProductGroupName;
                        row[1] = objProductsInfo.ICProductID + "-" + objProductsInfo.ICProductName;
                    }
                    //row[j+2] = i;
                    objProductEmployeesInfo = objProductEmployeesController.GetProductEmployeeByProductIDAndEmployeeID(objProductsInfo.ICProductID, objEmployeesInfo.HREmployeeID);
                    if (objProductEmployeesInfo == null)
                    {
                        row[j + 2] = 0;
                    }
                    else
                    {
                        row[j + 2] = objProductEmployeesInfo.ICProductEmployeeCommissionPercent;
                    }
                }
                table.Rows.Add(row);
            }

            List<ExportExcelParameter> lstContentParameter = new List<ExportExcelParameter>();
            lstContentParameter.Add(new ExportExcelParameter(1, 1, table));
            return lstContentParameter;
        }

        /// <summary>
        /// release object
        /// </summary>
        /// <param name="obj"></param>
        private void releaseObject(object obj)
        {
            try
            {
                System.Runtime.InteropServices.Marshal.ReleaseComObject(obj);
                obj = null;
            }
            catch (Exception ex)
            {
                obj = null;
                MessageBox.Show("Unable to release the Object " + ex.ToString());
            }
            finally
            {
                GC.Collect();
            }
        }
    }
}
