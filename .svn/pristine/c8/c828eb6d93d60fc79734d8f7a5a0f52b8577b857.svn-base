using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using BOSCommon;
using DevExpress.XtraGrid.Views.Grid;

namespace BOSERP.Modules.SellStaff
{
    public partial class guiChooseTemplate : BOSERPScreen
    {
        /// <summary>
        /// Template type associates with the command
        /// </summary>
        private TemplateType TemplateType;

        /// <summary>
        /// Gets or sets the selected template
        /// </summary>
        public GETemplatesInfo SelectedTemplate { get; set; }

        public guiChooseTemplate()
        {
            InitializeComponent();
        }

        public guiChooseTemplate(TemplateType type)
        {
            InitializeComponent();

            TemplateType = type;
        }

        private void guiChooseTemplate_Load(object sender, EventArgs e)
        {
            fld_dgcGETemplates.Screen = this;
            fld_dgcGETemplates.InitializeControl();
            GridView gridView = (GridView)fld_dgcGETemplates.MainView;
            gridView.OptionsView.ShowAutoFilterRow = true;
            gridView.DoubleClick += new EventHandler(GridView_DoubleClick);

            GETemplatesController objTemplatesController = new GETemplatesController();
            DataSet ds = objTemplatesController.GetTemplatesByType(TemplateType.ToString());

            if (ds.Tables.Count > 0)
            {
                fld_dgcGETemplates.DataSource = ds.Tables[0];
            }            
        }

        private void GridView_DoubleClick(object sender, EventArgs e)
        {
            ChooseTemplate();
            DialogResult = DialogResult.OK;
            Close();
        }

        private void ChooseTemplate()
        {
            GridView gridView = (GridView)fld_dgcGETemplates.MainView;
            if (gridView.FocusedRowHandle >= 0)
            {
                GETemplatesController objTemplatesController = new GETemplatesController();
                DataRow row = gridView.GetDataRow(gridView.FocusedRowHandle);
                SelectedTemplate = (GETemplatesInfo)objTemplatesController.GetObjectFromDataRow(row);                
            }
        }

        private void fld_btnChoose_Click(object sender, EventArgs e)
        {
            ChooseTemplate();
            DialogResult = DialogResult.OK;
            Close();
        }

        private void fld_btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
