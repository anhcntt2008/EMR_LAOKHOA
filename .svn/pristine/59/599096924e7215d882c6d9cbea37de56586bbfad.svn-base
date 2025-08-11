using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using BOSERP.Modules.METemplate;
using DevExpress.XtraGrid.Views.Grid;
using Localization;

namespace BOSERP.Modules.METemplate.UI
{
    public partial class DMMETE101 : BOSERPScreen
    {
        public DMMETE101()
        {
            InitializeComponent();
        }

        private void barBtnInsertParam_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
        }

        private void barBtnInsertAction_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            
        }

        private void fld_dgcMEParams_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            AddParamToTemplate();
        }

        private void btnAddParam_Click(object sender, EventArgs e)
        {
            AddParamToTemplate();
        }
        private void AddParamToTemplate()
        {
            GridView gridView = (GridView)this.fld_dgcMEParams.MainView;
            if (gridView.FocusedRowHandle < 0)
            {
                MessageBox.Show(BaseLocalizedResources.ChooseObjectMessage, CommonLocalizedResources.MessageBoxDefaultCaption, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            ((METemplateModule)Module).AddParamToTemplateAtCaretPosition(gridView.GetRow(gridView.FocusedRowHandle) as MEParamsInfo);
        }

        private void btnAddNewAction_Click(object sender, EventArgs e)
        {

        }

        private void btnAddAction_Click(object sender, EventArgs e)
        {
            AddActionToTemplate();
        }

        private void fld_dgcMEEmrActions_DoubleClick(object sender, EventArgs e)
        {
            AddActionToTemplate();
        }
        private void AddActionToTemplate()
        {
            GridView gridView = (GridView)this.fld_dgcMEEmrActions.MainView;
            if (gridView.FocusedRowHandle < 0)
            {
                MessageBox.Show(BaseLocalizedResources.ChooseObjectMessage, CommonLocalizedResources.MessageBoxDefaultCaption, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
           ((METemplateModule)Module).AddActionToTemplate(gridView.GetRow(gridView.FocusedRowHandle) as MEEmrActionsInfo);
        }

        private void richEditCtrl_HyperlinkClick(object sender, DevExpress.XtraRichEdit.HyperlinkClickEventArgs e)
        {
            e.Handled = true;
            if (!e.Control)
            {
               // MessageBox.Show("Ctrl + Click to get link action");
                return;
            }
        }

        private void richEditCtrl_SelectionChanged(object sender, EventArgs e)
        {

        }

        private void fld_btnAddParentParam_Click(object sender, EventArgs e)
        {
            GridView gridView = (GridView)this.fld_dgcMEParams.MainView;
            if (gridView.FocusedRowHandle < 0)
            {
                MessageBox.Show(BaseLocalizedResources.ChooseObjectMessage, CommonLocalizedResources.MessageBoxDefaultCaption, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            ((METemplateModule)Module).AddParamToTemplateAtCaretPosition(gridView.GetRow(gridView.FocusedRowHandle) as MEParamsInfo, true);
        }

        private void barBtnGroupParam_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ((METemplateModule)Module).GroupSelectParam();
        }

        private void barBtnUngroup_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ((METemplateModule)Module).ClearGroupSelectParam();
        }

        private void barBtnViewParamInfo_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ((METemplateModule)Module).ViewParamInfo();
        }

        private void fileSaveItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        private void barButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            // Liet ke the
            METemplateModule module = (METemplateModule)Module;
            ParamListForm form = new ParamListForm();
            module.GetParamsTree(form.GetTreeList());
            form.ShowDialog();
            //(new ParamListForm(module.GetParamsTree())).ShowDialog();
            //var treeList = module.GetParamsTree();
            //var col1 = treeList.Columns.Add();
            //col1.Caption = "Customer";
            //col1.VisibleIndex = 0;

            //(new ParamListForm(treeList)).ShowDialog();
        }

        private void btnRefreshParams_Click(object sender, EventArgs e)
        {
            METemplateModule module = (METemplateModule)Module;
            module.InvalidateRefreshParams();
        }

        private void btnRefreshActions_Click(object sender, EventArgs e)
        {
            METemplateModule module = (METemplateModule)Module;
            module.InvalidateRefreshActions();
        }

        private void showAllFieldCodesItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            METemplateModule module = (METemplateModule)Module;
            module.ShowParamCode();
        }
    }
}