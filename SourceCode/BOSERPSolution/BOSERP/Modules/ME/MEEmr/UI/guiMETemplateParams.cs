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
    public partial class guiMETemplateParams : BOSERPScreen
    {
        private readonly List<METemplateParamsInfo> _templateParams;

        public guiMETemplateParams(string title, List<METemplateParamsInfo> templateParams)
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterParent;
            KeyDown += new KeyEventHandler(Ok_KeyDown);
            Text = title;
            _templateParams = templateParams;
        }

        private void guiMETemplateParams_Load(object sender, EventArgs e)
        {
            this.KeyPreview = true;
            this.InitializeControls(this.Controls);
            fld_dgcMETemplateParams.DataSource = this._templateParams;
        }

        private void Ok_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Alt && e.KeyCode == Keys.O)
            {
                Ok();
            }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            Ok();
        }

        private void guiMETemplateParams_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                DialogResult = DialogResult.Cancel;
                Close();
            }
        }

        public void Ok()
        {
            Close();
        }
    }
}
