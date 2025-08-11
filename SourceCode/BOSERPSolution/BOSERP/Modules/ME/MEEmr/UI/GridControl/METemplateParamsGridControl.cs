using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Text;
using System.Windows.Forms;
using BOSComponent;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Columns;
using Localization;
using DevExpress.XtraGrid.Views.Base;
using System.Drawing;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraEditors;
using System.Data;
using System.Linq;

namespace BOSERP.Modules.MEEmr
{
    public partial class METemplateParamsGridControl : BOSGridControl
    {
        public override void InitGridControlDataSource()
        {
        }
        protected override DevExpress.XtraGrid.Views.Grid.GridView InitializeGridView()
        {
            GridView gridView = base.InitializeGridView();
            gridView.OptionsBehavior.AutoExpandAllGroups = true;
            GridColumn column = gridView.Columns["FK_METemplateID"];
            if (column != null)
            {
                column.Caption = "Tờ bệnh án";
                column.GroupIndex = 0;
                column.Group();
            }
            return gridView;
        }
    }
}
