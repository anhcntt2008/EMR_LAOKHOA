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
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using DevExpress.XtraEditors;

namespace BOSERP.Modules.MEDocumentManage
{
    public partial class MEEmrDocumentsGridControl : BOSGridControl
    {
        public override void InitGridControlDataSource()
        {
        }

        protected override GridView InitializeGridView()
        {
            GridView grid = base.InitializeGridView();
            grid.OptionsBehavior.Editable = false;
            grid.OptionsView.ShowAutoFilterRow = true;
            grid.OptionsView.ShowIndicator = true;
            grid.OptionsView.ColumnAutoWidth = false;
            grid.OptionsNavigation.EnterMoveNextColumn = true;
            grid.OptionsNavigation.UseTabKey = false;
            grid.OptionsSelection.MultiSelect = true;
            GridColumn column = grid.Columns["MEEmrDocumentCreatedDate"];
            if (column != null)
            {
                column.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
                column.DisplayFormat.FormatString = "dd/MM/yyyy HH:mm";
            }
            return grid;
        }
    }
}
