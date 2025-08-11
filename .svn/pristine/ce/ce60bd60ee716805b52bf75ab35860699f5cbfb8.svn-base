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

namespace BOSERP.Modules.MEEmr.UI
{
    /// <summary>
    /// Summary description for DSMEEMR100
    /// </summary>
    public partial class guiTransfer : BOSERPScreen
    {
        public guiTransfer()
        {
            InitializeComponent();
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Ok_KeyDown);
        }
        private void Ok_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Alt && e.KeyCode == Keys.O)
            {
                Ok();
            }
        }
        public void Ok()
        {
            var entity = ((MEEmrModule)Module).CurrentModuleEntity as MEEmrEntities;
            var tran = entity.ModuleObjects[TableName.MEEmrTransferHistoriesTableName] as MEEmrTransferHistoriesInfo;
            if (tran.FK_HRDepartmentToID <= 0)
            {
                MessageBox.Show("Cần chọn khoa chuyển đến.", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                return;
            }
            if (tran.FK_HRDepartmentToID == tran.FK_HRDepartmentFromID)
            {
                MessageBox.Show("Khoa chuyển và nhận không được trùng nhau", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                return;
            }
            DialogResult = DialogResult.OK;
            this.Close();
        }
        private void DSMEEMR100_Load(object sender, EventArgs e)
        {
            this.KeyPreview = true;

        }
        private void btnOk_Click(object sender, EventArgs e)
        {
            Ok();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
