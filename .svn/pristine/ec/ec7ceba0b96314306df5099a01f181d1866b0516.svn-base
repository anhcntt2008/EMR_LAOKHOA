using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using DevExpress.XtraGrid.Views.Grid;
using Localization;

namespace BOSERP.Modules.MEEmrType.UI
{
    /// <summary>
    /// Summary description for DMEMRTYP100
    /// </summary>
    public partial class DMEMRTYP100 : BOSERPScreen
    {

        public DMEMRTYP100()
        {
            //
            // Required designer variable
            //
            InitializeComponent();
        }

        private void fld_btnAddTemplate_Click(object sender, EventArgs e)
        {
            GridView gridView = (GridView)this.fld_dgcMETemplates.MainView;
            if (gridView.FocusedRowHandle < 0)
            {
                MessageBox.Show(BaseLocalizedResources.ChooseObjectMessage, CommonLocalizedResources.MessageBoxDefaultCaption, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            ((MEEmrTypeModule)Module).AddTemplateToType(gridView.GetRow(gridView.FocusedRowHandle) as METemplatesInfo);
        }

        private void fld_btnRemoveTemplate_Click(object sender, EventArgs e)
        {
            GridView gridView = (GridView)this.fld_dgcMEEmrTypeTemplates.MainView;
            if (gridView.FocusedRowHandle < 0)
            {
                MessageBox.Show(BaseLocalizedResources.ChooseObjectMessage, CommonLocalizedResources.MessageBoxDefaultCaption, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            ((MEEmrTypeModule)Module).RemoveTemplateFromType(gridView.GetRow(gridView.FocusedRowHandle) as MEEmrTypeTemplatesInfo);
        }

        private void fld_btnAddAction_Click(object sender, EventArgs e)
        {
            AddStartupActionToType();
        }

        private void AddStartupActionToType()
        {
            GridView gridView = (GridView)this.fld_dgcMEEmrActions.MainView;
            if (gridView.FocusedRowHandle < 0)
            {
                MessageBox.Show(BaseLocalizedResources.ChooseObjectMessage, CommonLocalizedResources.MessageBoxDefaultCaption, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
          ((MEEmrTypeModule)Module).AddStartupActionToType(gridView.GetRow(gridView.FocusedRowHandle) as MEEmrActionsInfo);
        }

        private void fld_btnRemoveAction_Click(object sender, EventArgs e)
        {
            GridView gridView = (GridView)this.fld_dgcMEEmrTypeActions.MainView;
            if (gridView.FocusedRowHandle < 0)
            {
                MessageBox.Show(BaseLocalizedResources.ChooseObjectMessage, CommonLocalizedResources.MessageBoxDefaultCaption, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
          ((MEEmrTypeModule)Module).RemoteStartupActionToTemplate(gridView.GetRow(gridView.FocusedRowHandle) as MEEmrTypeActionsInfo);
        }
    }
}
