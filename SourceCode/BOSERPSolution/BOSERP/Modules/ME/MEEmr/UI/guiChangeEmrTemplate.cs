using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using BOSERP.Modules.MEEmr;
using DevExpress.XtraGrid.Views.Grid;
using Clas.Emr.Model;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using DevExpress.XtraGrid.Views.Base;
using BOSCommon;
using System.IO;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors;
using DevExpress.XtraLayout.Utils;
using System.Drawing.Drawing2D;
using System.Linq;
using DevExpress.XtraGrid.Columns;
using BOSComponent;

namespace BOSERP.Modules.MEEmr.UI
{
    /// <summary>
    /// Summary description for DSMEEMR100
    /// </summary>
    public partial class guiChangeEmrTemplate : BOSERPScreen
    {
        private readonly METemplateIndexsController _emrTemplateIndexsCtrl;
        private readonly int FK_MEEmrTypeID;
        private readonly int emrDocumentOrder;
        public int METemplateIndexOrder { get; private set; }
        public string METemplateIndexName { get; private set; }

        public guiChangeEmrTemplate(int emrTypeID, int mEEmrDocumentOrder)
        {
            InitializeComponent();
            this.KeyDown += new KeyEventHandler(this.Ok_KeyDown);
            FK_MEEmrTypeID = emrTypeID;
            emrDocumentOrder = mEEmrDocumentOrder;
            _emrTemplateIndexsCtrl = new METemplateIndexsController();
        }
        private void Ok_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Alt && e.KeyCode == Keys.O)
            {
                Ok();
            }
        }
        private void DSMEEMR100_Load(object sender, EventArgs e)
        {
            this.KeyPreview = true;
            var grid = this.grcDocumentGroupMapping.MainView as GridView;
            grid.OptionsBehavior.Editable = false;
            grid.OptionsView.ShowGroupPanel = false;
            grid.OptionsView.ShowIndicator = true;
            grid.OptionsView.ColumnAutoWidth = false;
            grid.OptionsView.ShowDetailButtons = false;
            grid.OptionsNavigation.EnterMoveNextColumn = true;
            grid.OptionsSelection.EnableAppearanceFocusedCell = false;
            grid.OptionsNavigation.UseTabKey = false;
            grid.OptionsSelection.MultiSelect = false;
            grid.DoubleClick += new EventHandler(GridView_DoubleClick);
            grid.RowStyle += new RowStyleEventHandler(GridView_RowStyle);
            var column = new GridColumn
            {
                Caption = "Thứ tự",
                FieldName = "METemplateIndexOrder",
                Visible = true,
                VisibleIndex = 1,
                Width = 100,
                SortOrder = DevExpress.Data.ColumnSortOrder.Ascending
            };
            grid.Columns.Add(column);

            column = new GridColumn
            {
                Caption = "Gáy mới",
                FieldName = "METemplateIndexName",
                Visible = true,
                VisibleIndex = 1,
                Width = 350
            };
            grid.Columns.Add(column);

            var TemplateIndexs = _emrTemplateIndexsCtrl.GetByEmrType(FK_MEEmrTypeID).OrderBy(t => t.METemplateIndexOrder);
            this.grcDocumentGroupMapping.DataSource = TemplateIndexs;
            this.grcDocumentGroupMapping.RefreshDataSource();
            this.grcDocumentGroupMapping.Refresh();
        }

        private void GridView_RowStyle(object sender,RowStyleEventArgs e)
        {
            GridView View = sender as GridView;
            if (e.RowHandle >= 0)
            {
                string colOrder = View.GetRowCellDisplayText(e.RowHandle, View.Columns["METemplateIndexOrder"]);
                if (colOrder == emrDocumentOrder.ToString())
                {
                    e.Appearance.BackColor = Color.FromArgb(255, 255, 192);
                    e.Appearance.ForeColor = Color.DarkRed;
                    e.Appearance.FontStyleDelta = FontStyle.Bold;
                }
            }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            Ok();
        }

        private void GridView_DoubleClick(object sender, EventArgs e)
        {
            Ok();
        }

        public void Ok()
        {
            var grid = (grcDocumentGroupMapping.MainView as GridView);
            if (grid.SelectedRowsCount == 0)
            {
                MessageBox.Show("Vui lòng chọn gáy mới", "Chưa chọn gáy", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }

            if (grid.FocusedRowHandle >= 0)
            {
                var objTemplateIndexsInfo = (METemplateIndexsInfo)grid.GetRow(grid.FocusedRowHandle);
                this.METemplateIndexOrder = objTemplateIndexsInfo.METemplateIndexOrder;
                this.METemplateIndexName = objTemplateIndexsInfo.METemplateIndexName;
                DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            this.Close();
        }

        
    }
}
