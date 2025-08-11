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

namespace BOSERP.Modules.MEEmrType.UI
{
    public partial class guiEmrDocuments : BOSERPScreen
    {
        public List<MEEmrDocumentsInfo> _emrDocuments { get; private set; }
        
        public guiEmrDocuments(List<MEEmrDocumentsInfo> emrDocuments)
        {
            InitializeComponent();
            _emrDocuments = emrDocuments;
        }
        private void EmrDocuments_Load(object sender, EventArgs e)
        {
            this.KeyPreview = true;
            var grid = this.grcEmrDocuments.MainView as GridView;
            grid.OptionsBehavior.Editable = false;
            grid.OptionsView.ShowGroupPanel = false;
            grid.OptionsView.ShowIndicator = true;
            grid.OptionsView.ColumnAutoWidth = false;
            grid.OptionsView.ShowDetailButtons = false;
            grid.OptionsNavigation.EnterMoveNextColumn = true;
            grid.OptionsSelection.EnableAppearanceFocusedCell = false;
            grid.OptionsNavigation.UseTabKey = false;
            grid.OptionsSelection.MultiSelect = false;

            this.grcEmrDocuments.DataSource = _emrDocuments;
            this.grcEmrDocuments.RefreshDataSource();
            this.grcEmrDocuments.Refresh();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            this.Close();
        }

        
    }
}
