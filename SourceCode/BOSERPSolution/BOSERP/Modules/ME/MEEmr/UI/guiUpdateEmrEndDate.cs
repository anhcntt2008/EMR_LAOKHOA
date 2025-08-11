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
    /// Summary description for guiUpdateEmrEndDate
    /// </summary>
    public partial class guiUpdateEmrEndDate : BOSERPScreen
    {
        public DateTime _emrEndDate;
        private MEEmrsController _emrCtrl;
        public guiUpdateEmrEndDate(DateTime emrEndDate)
        {
            InitializeComponent();
            _emrCtrl = new MEEmrsController();
            _emrEndDate = emrEndDate;
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.guiUpdateEmrEndDate_Ok_KeyDown);
        }
        
        private void guiUpdateEmrEndDate_Load(object sender, EventArgs e)
        {
            this.KeyPreview = true;
            guiUpdateEmrEndDate_fld_dteAACreatedDate1.Enabled = true;
            guiUpdateEmrEndDate_fld_dteAACreatedDate1.EditValue = _emrEndDate;
        }

        private void guiUpdateEmrEndDate_Ok_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Alt && e.KeyCode == Keys.O)
            {
                Ok();
            }
        }

        private void guiUpdateEmrEndDate_btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            this.Close();
        }

        public void Ok()
        {
            _emrEndDate = (DateTime)guiUpdateEmrEndDate_fld_dteAACreatedDate1.EditValue;
            if (_emrEndDate == null)
            {
                MessageBox.Show($"Vui lòng chọn ngày đóng.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }
            this.Close();
            DialogResult = DialogResult.OK;
        }

        private void guiUpdateEmrEndDate_btnOk_Click(object sender, EventArgs e)
        {
            Ok();
        }
    }
}
