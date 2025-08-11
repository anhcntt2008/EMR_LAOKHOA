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
    public partial class guiDocumentNoteList : BOSERPScreen
    {
        private int _emrId;
        private BOSList<MEEmrDocumentNotesInfo> _documentNoteList;

        public guiDocumentNoteList(int emrId)
        {
            InitializeComponent();
            this.KeyDown += new KeyEventHandler(this.Form_KeyDown);
            _emrId = emrId;
        }
        private void Form_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.G)
            {
                Ok();
            }
            if (e.KeyCode == Keys.Escape)
            {
                DialogResult = DialogResult.Cancel;
                this.Close();
            }
        }
        public void Ok()
        {
            var grid = (fld_dgcMEEmrDocumentNotes.MainView as GridView);
            if (grid.FocusedRowHandle >= 0)
            {
                var row = grid.GetRow(grid.FocusedRowHandle) as MEEmrDocumentNotesInfo;
                GotoBookmark(row.MEEmrDocumentNoteBookmark, row.FK_MEEmrDocumentID);
            }
        }
        public void GotoBookmark(string bookmark, int documentId = 0)
        {
            if (string.IsNullOrEmpty(bookmark))
            {
                MessageBox.Show("Không có đánh dấu vị trí cụ thể trên tờ bệnh án", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
                ((MEEmrModule)Module).GotoBookmark(bookmark, documentId);
        }
        private void DSMEEMR100_Load(object sender, EventArgs e)
        {
            this.KeyPreview = true;
            _documentNoteList = new BOSList<MEEmrDocumentNotesInfo>();
            _documentNoteList.InitBOSList(((MEEmrModule)Module).CurrentModuleEntity,
             TableName.MEEmrsTableName,
             TableName.MEEmrDocumentNotesTableName,
              BOSList<MEEmrDocumentNotesInfo>.cstRelationForeign);
            _documentNoteList.ItemTableForeignKey = "FK_MEEmrID";
            BindingSource bds = new BindingSource
            {
                DataSource = _documentNoteList
            };
            fld_dgcMEEmrDocumentNotes.DataSource = bds;
            _documentNoteList.Invalidate(_emrId);
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

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            _documentNoteList.Invalidate(_emrId);
            fld_dgcMEEmrDocumentNotes.RefreshDataSource();
        }
    }
}
