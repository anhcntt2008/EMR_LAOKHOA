using BOSCommon;
using BOSERP.Modules.MEPatient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraGrid.Views.Grid;

namespace BOSERP.Modules.ME.MEPatient.UI
{


    public partial class guiDuplicatePatients : BOSERPScreen
    {

        public BOSList<MEPatientsInfo> MEPatientsInfoList { get; set; }
        public MEPatientsInfo selectedPatient { get; set; }

        public guiDuplicatePatients()
        {
            InitializeComponent();
        }

        public void guiDuplicatePatients_Load(object sender, EventArgs e)
        {
            InitializeControls(Controls);
            MEPatientEntities entity = (MEPatientEntities)((BaseModuleERP)Module).CurrentModuleEntity;
            entity.MEPatientList.InitBOSListGridControl(fld_dgcMEPatients);
        }

        public override void InitializeControls(Control.ControlCollection controls)
        {
            foreach (Control ctrl in controls)
            {
                InitializeControl(ctrl);
                if (ctrl.Controls.Count > 0)
                {
                    InitializeControls(ctrl.Controls);
                }
            }
        }

        public void Init(DataSet ds)
        {
            MEPatientEntities entity = (MEPatientEntities)((BaseModuleERP)Module).CurrentModuleEntity;
            entity.MEPatientList.SetDefaultListAndRefreshGridControl();
            entity.MEPatientList.Invalidate(ds);
            entity.MEPatientList.GridControl.RefreshDataSource();
        }

        public void Init(List<MEPatientsInfo> list)
        {
            MEPatientEntities entity = (MEPatientEntities)((BaseModuleERP)Module).CurrentModuleEntity;
            entity.MEPatientList.SetDefaultListAndRefreshGridControl();
            entity.MEPatientList.Invalidate(list);
            entity.MEPatientList.GridControl.RefreshDataSource();
        }

        private void fld_btnDelete101_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void fld_btnAdd101_Click(object sender, EventArgs e)
        {
            SelectRow();
            this.Close();
        }

        private void fld_dgcMEPatients_DoubleClick(object sender, EventArgs e)
        {

        }
        private void SelectRow()
        {
            int[] selRows = ((GridView)mePatientsGridControl1.MainView).GetSelectedRows();
            selectedPatient = (MEPatientsInfo)(((GridView)mePatientsGridControl1.MainView).GetRow(selRows[0]));
            DialogResult = DialogResult.Yes;
        }
        private void mePatientsGridControl1_DoubleClick(object sender, EventArgs e)
        {
            SelectRow();
            this.Close();
        }
    }
}
