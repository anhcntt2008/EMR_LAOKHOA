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
using DevExpress.XtraTreeList;
using DevExpress.XtraTreeList.Nodes;
using System.Linq;
using DevExpress.XtraTreeList.Nodes.Operations;
using DevExpress.XtraTreeList.ViewInfo;
using BOSCommon;
using BOSLib;

namespace BOSERP.Modules.MEEmr.UI
{
    /// <summary>
    /// Summary description for DSMEEMR100
    /// </summary>
    public partial class guiNotificationEmrDocument : BOSERPScreen
    {
        private List<MEEmrDocumentsInfo> _documentList;

        public guiNotificationEmrDocument(string title, List<MEEmrDocumentsInfo> docs)
        {
            InitializeComponent();
            this.Text = title;
            this._documentList = docs.Where(o => o.MEEmrDocumentStatus != EmrDocumentStatus.Hidden.ToString()).ToList();
        }

        private void guiNotificationEmrDocument_Load(object sender, EventArgs e)
        {
            this.KeyPreview = true;
            this.InitializeControls(this.Controls);
            fld_dgcMEEmrDocumentsNotification.DataSource = this._documentList;
        }

        private void guiNotificationEmrDocument_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                DialogResult = DialogResult.Cancel;
                this.Close();
            }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
