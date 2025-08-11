using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using DevExpress.XtraGrid.Views.Grid;
using Clas.Emr.Model;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;

namespace BOSERP
{
    /// <summary>
    /// Summary description for DSMEEMR100
    /// </summary>
    public partial class guiInputWorkflowParam : BOSERPScreen
    {
        private readonly MEParamsInfo[] _paramList;

        public guiInputWorkflowParam(MEParamsInfo[] paramList)
        {
            InitializeComponent();
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Ok_KeyDown);
            this.StartPosition = FormStartPosition.CenterParent;
            _paramList = paramList;
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
            DialogResult = DialogResult.OK;
            this.Close();
        }
        private void DSMEEMR100_Load(object sender, EventArgs e)
        {
            this.KeyPreview = true;
            this.fld_dgcInputWorkflowParam.Screen = this;
            this.fld_dgcInputWorkflowParam.InitializeControl();
            this.fld_dgcInputWorkflowParam.DataSource = this._paramList;
            this.fld_dgcInputWorkflowParam.RefreshDataSource();
            this.fld_dgcInputWorkflowParam.Refresh();
            (this.fld_dgcInputWorkflowParam.MainView as GridView).BestFitColumns();
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
