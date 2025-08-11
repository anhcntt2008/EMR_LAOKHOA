using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using BOSERP.Modules.MEEmr;
using DevExpress.XtraGrid.Views.Grid;
using Clas.Emr.Model;

namespace BOSERP.Modules.MEEmr.UI
{
    /// <summary>
    /// Summary description for DSMEEMR100
    /// </summary>
    public partial class DSMEEMR102 : BOSERPScreen
    {

        public DSMEEMR102()
        {
            //
            // Required designer variable
            //
            InitializeComponent();
        }

        private void DSMEEMR100_Load(object sender, EventArgs e)
        {
            this.fld_grdStethoscopes.Screen = this;
            this.fld_grdStethoscopes.InitializeControl();

            this.fld_grdStethoscopes.RefreshDataSource();
            this.fld_grdStethoscopes.Refresh();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            var grid = this.fld_grdStethoscopes.MainView as GridView;
            MEEmrEntities entity = (MEEmrEntities)((BaseModuleERP)Module).CurrentModuleEntity;
            foreach (var item in grid.GetSelectedRows())
            {
                entity.SelectedStethoscopesDataList.Add(grid.GetRow(item) as StethoscopeData);
            }
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
