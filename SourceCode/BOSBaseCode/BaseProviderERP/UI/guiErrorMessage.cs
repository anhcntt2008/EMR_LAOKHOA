using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using BOSLib;

namespace BOSERP
{
    public partial class guiErrorMessage : BOSERPScreen
    {
        public guiErrorMessage()
        {
            InitializeComponent();
        }

        public guiErrorMessage(DataTable tblErrors)
        {
            InitializeComponent();
            fld_dgcErrors.DataSource = tblErrors;
        }

        private void fld_btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void fld_btnOK_Click(object sender, EventArgs e)
        {
            if (fld_dgvErrors.FocusedRowHandle >= 0)
            {
                String strControlName = fld_dgvErrors.GetRowCellValue(fld_dgvErrors.FocusedRowHandle, colErrorControl).ToString();
                if (Module.Controls.Contains(strControlName))
                {
                    Module.Controls[strControlName].FindForm().Focus();
                    Module.Controls[strControlName].Focus();
                    if (Module.Controls[strControlName] is DevExpress.XtraGrid.GridControl)
                    {
                        DevExpress.XtraGrid.GridControl gridControl = Module.Controls[strControlName] as DevExpress.XtraGrid.GridControl;
                        int iPos = Convert.ToInt32(fld_dgvErrors.GetRowCellValue(fld_dgvErrors.FocusedRowHandle, colPosition));
                        if (iPos >= 0)
                        {
                            DevExpress.XtraGrid.Views.Grid.GridView gridView = gridControl.Views[0] as DevExpress.XtraGrid.Views.Grid.GridView;
                            gridView.FocusedRowHandle = iPos;
                        }
                    }                    
                }
                this.Close();
            }
        }

        private void guiErrorMessage_Load(object sender, EventArgs e)
        {
            DevExpress.XtraBars.BarButtonItem errorButton =
            ((BaseModuleERP)Module).ParentScreen.GetToolbarButton(BaseToolbar.ToolbarUtility, "Error");
            if (errorButton != null)
                errorButton.Enabled = true;
        }

        private void guiErrorMessage_FormClosed(object sender, FormClosedEventArgs e)
        {
            DevExpress.XtraBars.BarButtonItem errorButton = ((BaseModuleERP)Module).ParentScreen.GetToolbarButton(BaseToolbar.ToolbarUtility, "Error");
            if (errorButton != null)
                errorButton.Enabled = false;
        }

        private void fld_dgcErrors_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                DevExpress.XtraGrid.Views.Grid.ViewInfo.GridHitInfo hitInfo = fld_dgvErrors.CalcHitInfo(fld_dgcErrors.PointToClient(Control.MousePosition));
                int iRowHandle = hitInfo.RowHandle;
                if (iRowHandle >= 0)
                {
                    String strControlName = fld_dgvErrors.GetRowCellValue(iRowHandle, colErrorControl).ToString();
                    if (Module.Controls.Contains(strControlName))
                    {
                        Module.Controls[strControlName].FindForm().Focus();
                        Module.Controls[strControlName].Focus();

                        if (Module.Controls[strControlName] is DevExpress.XtraGrid.GridControl)
                        {
                            DevExpress.XtraGrid.GridControl gridControl = Module.Controls[strControlName] as DevExpress.XtraGrid.GridControl;
                            int iPos = Convert.ToInt32(fld_dgvErrors.GetRowCellValue(iRowHandle, colPosition));
                            if (iPos >= 0)
                            {
                                DevExpress.XtraGrid.Views.Grid.GridView gridView = gridControl.Views[0] as DevExpress.XtraGrid.Views.Grid.GridView;
                                gridView.FocusedRowHandle = iPos;
                            }
                        }
                    }                    
                }
            }
            catch (Exception)
            {
                return;
            }
        }              
    }
}