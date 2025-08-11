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

namespace BOSERP.Modules.MEPatient
{
    public partial class MEPatientRelativesGridControl : BOSGridControl
    {
        public override void InitGridControlDataSource()
        {
            MEPatientEntities entity = (MEPatientEntities)((BaseModuleERP)Screen.Module).CurrentModuleEntity;
            BindingSource bds = new BindingSource();
            bds.DataSource = entity.MEPatientRelativeList;
            DataSource = bds;
        }

        protected override void GridView_KeyUp(object sender, KeyEventArgs e)
        {
            base.GridView_KeyUp(sender, e);

            if (e.KeyCode == Keys.Delete)
            {
                ((MEPatientModule)Screen.Module).DeleteItemFromPatientRelativeList();
            }
        }
    }
}
