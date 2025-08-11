using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Text;
using DevExpress.XtraGrid.Views.Grid;
using System.Data;
using BOSComponent;
using System.Windows.Forms;

namespace BOSERP.Modules.SellStaff
{
    public partial class HREmployeeCertificatesGridControl : BOSGridControl
    {
        public override void InitGridControlDataSource()
        {

            SellStaffEntities entity = (SellStaffEntities)((BaseModuleERP)Screen.Module).CurrentModuleEntity;
            BindingSource bds = new BindingSource();
            bds.DataSource = entity.HREmployeeCertificateList;
            DataSource = bds;
        }

        protected override void AddColumnsToGridView(string strTableName, GridView gridView)
        {
            base.AddColumnsToGridView(strTableName, gridView);
        }
    }
}
