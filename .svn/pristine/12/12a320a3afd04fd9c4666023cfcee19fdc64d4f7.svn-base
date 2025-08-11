using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Text;
using System.Windows.Forms;
using BOSCommon;
using BOSComponent;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Columns;
using Localization;
using System.Data;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Base.ViewInfo;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using System.Drawing;

namespace BOSERP.Modules.Report
{
    public partial class MEPatientVisitsLabTableGridControl : BOSGridControl
    {
        protected override DevExpress.XtraGrid.Views.Grid.GridView InitializeGridView()
        {
            GridView gridView = base.InitializeGridView();
            gridView.OptionsBehavior.Editable = false;
            gridView.OptionsSelection.EnableAppearanceFocusedCell = true;
            //gridView.CustomDrawCell += new RowCellCustomDrawEventHandler(GridView_CustomDrawCell);

            //DDCan [Show Visit Lab ID]
            gridView.ColumnPanelRowHeight = 60;
            gridView.Appearance.HeaderPanel.Options.UseTextOptions = true;
            gridView.Appearance.HeaderPanel.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;

            return gridView;
        }


        public override void InitializeControl()
        {
            base.InitializeControl();
            UseEmbeddedNavigator = false;
        }
    }
}
