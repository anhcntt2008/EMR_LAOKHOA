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
using BOSERP.UI;

namespace BOSERP.Modules.MEDocumentManage.UI
{
    /// <summary>
    /// Summary description for DSMEEMR100
    /// </summary>
    public partial class guiSelectEmr : BOSERPScreen
    {
        private readonly MEEmrsController _emrCtrl;
        public List<MEEmrsInfo> _emrs { get; private set; }
        public guiSelectEmr(List<MEEmrsInfo> emrs, string title)
        {
            InitializeComponent();
            _emrs = emrs;
            fld_lblLabel9.Text = "Danh sách bệnh án có " + title + ". \r\nVui lòng thực hiện lại " + title + ".\r\nLưu lại thông tin = thao tác Export dữ liệu.";
        }

        private void guiSelectEmr_Load(object sender, EventArgs e)
        {
            var gridControl = this.Controls["fld_dgcEmrs"] as MEEmrsGridControl;
            if (gridControl != null)
            {
                gridControl.DataSource = _emrs;
                gridControl.RefreshDataSource();
                gridControl.Refresh();
            }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
