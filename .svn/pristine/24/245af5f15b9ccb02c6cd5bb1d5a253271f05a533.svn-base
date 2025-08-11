using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Text;
using System.Windows.Forms;
using BOSComponent;
using BOSLib;
using DevExpress.XtraGrid.Columns;
using Localization;

namespace BOSERP.Modules.MEPatient
{
    public partial class MEVisitOrderItemsGridControl : BOSGridControl
    {
        public override void InitGridControlDataSource()
        {
            MEPatientEntities entity = (MEPatientEntities)((BaseModuleERP)Screen.Module).CurrentModuleEntity;
            BindingSource bds = new BindingSource();
            bds.DataSource = entity.MEVisitOrderItemList;
            DataSource = bds;
        }
    }
}
