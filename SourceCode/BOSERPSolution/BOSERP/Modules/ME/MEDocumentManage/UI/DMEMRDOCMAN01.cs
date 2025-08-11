using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using DevExpress.XtraEditors;
using BOSERP.Modules.MEDocumentManage.UI;
using System.Collections.Generic;
using DevExpress.XtraGrid.Views.Grid;
using BOSCommon;
using BOSERP.UI;
using BOSLib;

namespace BOSERP.Modules.MEDocumentManage.UI
{
    public partial class DMEMRDOCMAN01 : BOSERPScreen
    {
        public DMEMRDOCMAN01()
        {
            InitializeComponent();
            WindowState = FormWindowState.Minimized;
        }
        public override void InitializeScreen(STScreensInfo objStScreensInfo)
        {
            base.InitializeScreen(objStScreensInfo);
        }

        private void fld_btnRefreshDocument_Click(object sender, EventArgs e)
        {
            ((MEDocumentManageModule)Module).InvalidateMEEmrDocuments();
        }

        private void btnReleaseDocument_Click(object sender, EventArgs e)
        {
            ((MEDocumentManageModule)Module).ReleaseEmrDocuments();
        }
    }
}
