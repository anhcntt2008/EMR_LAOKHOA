using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using BOSERP.Utilities;
using Localization;
using DevExpress.XtraGrid.Views.Grid;

namespace BOSERP.Modules.METemplate.UI
{
	/// <summary>
	/// Summary description for DMMETE100
	/// </summary>
	public partial class DMMETE100 : BOSERPScreen
	{

		public DMMETE100()
		{
			//
			// Required designer variable
			//
			InitializeComponent();
		}

        private void bosLabel2_Click(object sender, EventArgs e)
        {

        }

        private void fld_btnAddAction_Click(object sender, EventArgs e)
        {
            AddStartupActionToTemplate();
        }

        private void fld_btnRemoveAction_Click(object sender, EventArgs e)
        {
            GridView gridView = (GridView)this.fld_dgcMEEmrTemplateActions.MainView;
            if (gridView.FocusedRowHandle < 0)
            {
                MessageBox.Show(BaseLocalizedResources.ChooseObjectMessage, CommonLocalizedResources.MessageBoxDefaultCaption, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
          ((METemplateModule)Module).RemoteStartupActionToTemplate(gridView.GetRow(gridView.FocusedRowHandle) as MEEmrTemplateActionsInfo);
        }

        private void AddStartupActionToTemplate()
        {
            GridView gridView = (GridView)this.fld_dgcMEEmrActions.MainView;
            if (gridView.FocusedRowHandle < 0)
            {
                MessageBox.Show(BaseLocalizedResources.ChooseObjectMessage, CommonLocalizedResources.MessageBoxDefaultCaption, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
          ((METemplateModule)Module).AddStartupActionToTemplate(gridView.GetRow(gridView.FocusedRowHandle) as MEEmrActionsInfo);
        }

        private void fld_lkeMETemplateShareMode_EditValueChanged(object sender, EventArgs e)
        {
            ((METemplateModule)Module).ChangeShareMode(fld_lkeMETemplateShareMode.EditValue?.ToString());
        }
    }
}
