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
    public partial class guiSelectSubTemplate : BOSERPScreen
    {
        private List<METemplatesInfo> _listSubTemplate;

        public METemplatesInfo SelectedSubTemplate { get; private set; }

        public guiSelectSubTemplate(List<METemplatesInfo> listSubTemplate)
        {
            InitializeComponent();
            _listSubTemplate = listSubTemplate;
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
            var grid = this.fld_grdSelectionSubTemplate.MainView as GridView;
            if (grid.GetSelectedRows().Length == 0)
            {
                MessageBox.Show("Vui lòng chọn mẫu?", "Chọn mẫu con", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult = DialogResult.OK;
            this.SelectedSubTemplate = grid.GetRow(grid.GetSelectedRows()[0]) as METemplatesInfo;
            this.Close();
        }
        private void DSMEEMR100_Load(object sender, EventArgs e)
        {
            this.KeyPreview = true;
            this.fld_grdSelectionSubTemplate.Screen = this;
            this.fld_grdSelectionSubTemplate.InitializeControl();
            this.fld_grdSelectionSubTemplate.DataSource = this._listSubTemplate;
            this.fld_grdSelectionSubTemplate.RefreshDataSource();
            this.fld_grdSelectionSubTemplate.Refresh();
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
