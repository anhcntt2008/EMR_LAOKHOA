using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Text;
using System.Windows.Forms;
using BOSComponent;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraEditors.Repository;
using System.Data;
using Localization;
using System.Drawing;
using BOSERP.Modules.MEPatient;

namespace BOSERP.Modules.Common
{
    public partial class MEPatientsGridControl : BOSGridControl
    {
        public override void InitGridControlDataSource()
        {
            CommonEntities entity = (CommonEntities)((BaseModuleERP)Screen.Module).CurrentModuleEntity;
            BindingSource bds = new BindingSource();
            bds.DataSource = entity.MEPatientList;
            DataSource = bds;
        }

        protected override GridView InitializeGridView()
        {
            GridView gridView = base.InitializeGridView();
            gridView.DoubleClick += new EventHandler(GridView_DoubleClick);
            return gridView;
        }

        private void GridView_DoubleClick(object sender, EventArgs e)
        {
            GridView gridView = (GridView)sender;
            MEPatientVisitsController objPatientVisitsController = new MEPatientVisitsController();
            if (gridView.FocusedRowHandle >= 0)
            {
                MEPatientsInfo objPatientsInfo = (MEPatientsInfo)gridView.GetRow(gridView.FocusedRowHandle);
                //MEPatientVisitsInfo objPatientVisitsInfo = new MEPatientVisitsInfo();
                //objPatientVisitsInfo.FK_MEPatientID = objPatientsInfo.MEPatientID;
                if (objPatientsInfo.MEPatientID == 0)
                {
                    var patientModule = new MEPatientModule(true);
                    objPatientsInfo = patientModule.CreatePatientAndCustomerFromBs24x7(objPatientsInfo);
                }

                MEPatientVisitsInfo objPatientVisitsInfo = objPatientVisitsController.GetLastPatientVisitByPatientID(objPatientsInfo.MEPatientID);

                //KhangCV ADD 17/03/2017 START
                if (objPatientVisitsInfo == null || (objPatientVisitsInfo != null && objPatientVisitsInfo.MEPatientVisitStatus == "Finished"))
                {
                    var confirm = MessageBox.Show("Bạn muốn tạo đợt khám mới cho bệnh nhân này?", "Xác nhận", MessageBoxButtons.YesNoCancel);
                    if (DialogResult.Cancel == confirm)
                        return;
                    if (DialogResult.No == confirm && objPatientVisitsInfo == null)
                    {
                        MessageBox.Show("Bệnh nhân không có đợt khám nào trước đây. Tạo đợt khám mới để tiếp tục.");
                        return;
                    }
                    if (DialogResult.Yes == confirm)
                        // Tiep nhan benh nhan, tao dot kham moi
                        objPatientVisitsInfo = (Screen as guiSearchPatient).CreateMEPatientVisitsInfo(objPatientsInfo, null);
                }


                //KhangCV ADD 17/03/2017 END

                Screen.Close();
                ((CommonModule)Screen.Module).ShowPatientVisitModule(objPatientVisitsInfo);
            }
        }

        // NNHuy [Add][24/3/2017][Start]
        protected override void AddColumnsToGridView(string strTableName, GridView gridView)
        {
            base.AddColumnsToGridView(strTableName, gridView);

            GridColumn column2 = new GridColumn();
            column2.Caption = "Mã Bacsi24x7";
            column2.FieldName = "MEPatientBs24x7ID";
            column2.OptionsColumn.AllowEdit = false;
            gridView.Columns.Add(column2);
        }
        // NNHuy [Add][24/3/2017][End]
    }
}
