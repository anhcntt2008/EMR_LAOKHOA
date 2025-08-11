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

namespace BOSERP.Modules.MEEmr.UI
{
    /// <summary>
    /// Summary description for DSMEEMR100
    /// </summary>
    public partial class DSMEEMR105 : BOSERPScreen
    {
        private List<METemplateChartsInfo> _listChart;

        public METemplateChartsInfo SelectedChart { get; private set; }

        public DSMEEMR105(List<METemplateChartsInfo> listChart)
        {
            InitializeComponent();
            _listChart = listChart;
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Ok_KeyDown);
            this.StartPosition = FormStartPosition.CenterParent;
        }
        private void Ok_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Alt && e.KeyCode == Keys.O)
            {
                this.Ok();
            }
        }
        public void Ok()
        {
            var grid = this.fld_grdSelectionChart.MainView as GridView;
            if (grid.GetSelectedRows().Length == 0)
            {
                MessageBox.Show("Vui lòng chọn biểu đồ?", "Chọn biểu đồ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult = DialogResult.OK;
            this.SelectedChart = grid.GetRow(grid.GetSelectedRows()[0]) as METemplateChartsInfo;
            this.Close();
        }
        private void DSMEEMR100_Load(object sender, EventArgs e)
        {
            this.KeyPreview = true;
            this.fld_grdSelectionChart.Screen = this;
            this.fld_grdSelectionChart.InitializeControl();
            this.fld_grdSelectionChart.DataSource = this._listChart;
            this.fld_grdSelectionChart.RefreshDataSource();
            this.fld_grdSelectionChart.Refresh();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            this.Ok();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
