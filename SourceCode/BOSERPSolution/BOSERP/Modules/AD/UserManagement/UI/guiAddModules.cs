using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraTreeList;
using DevExpress.XtraTreeList.Nodes;
using BOSLib;
using System.Transactions;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using Localization;

namespace BOSERP.Modules.UserManagement
{
    public partial class guiAddModules : BOSERPScreen
    {       
        private TreeList treeList = null;
        private BOSList<STModulesInfo> lstModule;        
        private GridHitInfo downHitInfo = null;

        public guiAddModules()
        {
            InitializeComponent();
        }

        public guiAddModules(TreeList _treeList)
        {
            InitializeComponent();
            this.treeList = _treeList;
            lstModule = new BOSList<STModulesInfo>();            
            InitializeModuleNonSection();
            InitializeModuleSection();
            
        }

        private void fld_btnCloseModule_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void InitializeModuleSection()
        {
            TreeListNode node = treeList.FocusedNode;
            if (node != null)
            {
                ADUserGroupSectionsController objUserGroupSectionsController = new ADUserGroupSectionsController();
                ADUserGroupSectionsInfo objADUserGroupSectionsInfo = (ADUserGroupSectionsInfo)objUserGroupSectionsController.GetObjectByID(Convert.ToInt32(node.Tag));
                if (objADUserGroupSectionsInfo != null)
                {
                    STModuleToUserGroupSectionsController objModuleToUserGroupSectionsController = new STModuleToUserGroupSectionsController();
                    DataSet ds = objModuleToUserGroupSectionsController.GetAllModuleToUserGroupSectionByUserGroupSectionID(objADUserGroupSectionsInfo.ADUserGroupSectionID);
                    if (ds != null)
                    {
                        foreach (DataRow row in ds.Tables[0].Rows)
                        {
                            STModuleToUserGroupSectionsInfo objSTModuleToUserGroupSectionsInfo = (STModuleToUserGroupSectionsInfo)new STModuleToUserGroupSectionsController().GetObjectFromDataRow(row);
                            if (objADUserGroupSectionsInfo != null)
                            {
                                STModulesInfo objSTModulesInfo = (STModulesInfo)new STModulesController().GetObjectByID(objSTModuleToUserGroupSectionsInfo.STModuleID);
                                if (objSTModulesInfo != null)
                                {
                                    //Add extra module description
                                    STModuleDescriptionsController objModuleDescriptionsController = new STModuleDescriptionsController();
                                    STModuleDescriptionsInfo objModuleDescriptionsInfo = (STModuleDescriptionsInfo)objModuleDescriptionsController.GetModuleDescriptionByModuleNameAndLanguageName(objSTModulesInfo.STModuleName, BOSApp.CurrentLang);
                                    objSTModulesInfo.STModuleDescription = objModuleDescriptionsInfo.STModuleDescriptionDescription;

                                    lstModule.Add(objSTModulesInfo);
                                }
                            }
                        }
                    }
                }
            }
            fld_dgcModuleSection.DataSource = lstModule;
            fld_dgvModuleSection.RefreshData();

        }
        public void InitializeModuleNonSection()
        {
            STModulesController objModulesController = new STModulesController();
            STModuleDescriptionsController objModuleDescriptionsController = new STModuleDescriptionsController();
            DataSet ds = objModulesController.GetAllModules();
            if (ds.Tables.Count > 0)
            {
                List<STModulesInfo> lstModules = new List<STModulesInfo>();
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    STModulesInfo objModulesInfo = (STModulesInfo)objModulesController.GetObjectFromDataRow(row);
                    STModuleDescriptionsInfo objModuleDescriptionsInfo = objModuleDescriptionsController.GetModuleDescriptionByModuleNameAndLanguageName(objModulesInfo.STModuleName, BOSApp.CurrentLang);
                    if (objModuleDescriptionsInfo != null)
                        objModulesInfo.STModuleDescription = objModuleDescriptionsInfo.STModuleDescriptionDescription;
                    lstModules.Add(objModulesInfo);
                }
                fld_dgcModuleNonSection.DataSource = lstModules;
                fld_dgvModuleNonSection.RefreshData();
            }
        }

        private void fld_btnForward_Click(object sender, EventArgs e)
        {
            int iRowHandle = fld_dgvModuleNonSection.FocusedRowHandle;
            if (iRowHandle >= 0)
            {
                STModulesInfo objSTModulesInfo = (STModulesInfo)fld_dgvModuleNonSection.GetRow(iRowHandle);                
                if (objSTModulesInfo != null)
                {
                    if (lstModule.Exists("STModuleName", objSTModulesInfo.STModuleName))
                    {
                        MessageBox.Show(UserManagementLocalizedResources.ModuleExistsMessage, CommonLocalizedResources.MessageBoxDefaultCaption, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    lstModule.Add(objSTModulesInfo);
                }
            }
            fld_dgcModuleSection.DataSource = lstModule;
            fld_dgvModuleSection.RefreshData();
        }

        private void fld_btnSaveMUGSection_Click(object sender, EventArgs e)
        {
            using (TransactionScope scope = new TransactionScope(TransactionScopeOption.RequiresNew))
            {
                try
                {
                    TreeListNode node = treeList.FocusedNode;
                    if (node != null)
                    {
                        ADUserGroupSectionsInfo objADUserGroupSectionsInfo = (ADUserGroupSectionsInfo)new ADUserGroupSectionsController().GetObjectByID(Convert.ToInt32(node.Tag));
                        if (objADUserGroupSectionsInfo != null)
                        {
                            //delete all 
                            new STModuleToUserGroupSectionsController().DeleteAllModuleToUserGroupSectionByUserGroupSectionID(objADUserGroupSectionsInfo.ADUserGroupSectionID);
                            int iSortOrder = 0;
                            foreach (STModulesInfo objSTModulesInfo in lstModule)
                            {
                                iSortOrder++;
                                STModuleToUserGroupSectionsInfo objSTModuleToUserGroupSectionsInfo = new STModuleToUserGroupSectionsInfo();
                                objSTModuleToUserGroupSectionsInfo.STModuleID = objSTModulesInfo.STModuleID;
                                objSTModuleToUserGroupSectionsInfo.STUserGroupSectionID = objADUserGroupSectionsInfo.ADUserGroupSectionID;
                                objSTModuleToUserGroupSectionsInfo.STModuleToUserGroupSectionSortOrder = iSortOrder;
                                new STModuleToUserGroupSectionsController().CreateObject(objSTModuleToUserGroupSectionsInfo);

                            }
                        }
                    }
                    scope.Complete();
                }
                catch (Exception ex)
                {
                    scope.Dispose();
                }
            }
            ((UserManagementModule)this.Module).InitializeTreeList(treeList);
            this.Close();
        }

        private void fld_btnBackward_Click(object sender, EventArgs e)
        {
            int iRowHandle = fld_dgvModuleSection.FocusedRowHandle;
            if (iRowHandle >= 0)
            {
                STModulesInfo objSTModulesInfo = (STModulesInfo)fld_dgvModuleSection.GetRow(iRowHandle);
                if (objSTModulesInfo != null)
                {
                    int iIndex = lstModule.IndexOf(objSTModulesInfo);
                    lstModule.RemoveAt(iIndex);
                }
            }
            fld_dgcModuleSection.DataSource = lstModule;
            fld_dgvModuleSection.RefreshData();
        }

        /// <summary>
        /// Do drag/drop gridview
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        #region Do drag/drop
        private void fld_dgvModuleSection_MouseDown(object sender, MouseEventArgs e)
        {
            GridView view = sender as GridView;
            downHitInfo = null;

            GridHitInfo hitInfo = view.CalcHitInfo(new Point(e.X, e.Y));
            if (Control.ModifierKeys != Keys.None) return;
            if (e.Button == MouseButtons.Left && hitInfo.InRow)
                downHitInfo = hitInfo;

        }

        private void fld_dgcModuleSection_DragDrop(object sender, DragEventArgs e)
        {
            GridControl grid = sender as GridControl;
            GridView view = grid.MainView as GridView;
            GridHitInfo srcHitInfo = e.Data.GetData(typeof(GridHitInfo)) as GridHitInfo;
            GridHitInfo hitInfo = view.CalcHitInfo(grid.PointToClient(new Point(e.X, e.Y)));
            int sourceRow = srcHitInfo.RowHandle;
            int targetRow = hitInfo.RowHandle;
            MoveRow(sourceRow, targetRow);

        }

        private void fld_dgcModuleSection_DragOver(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.None;

            GridHitInfo downHitInfo = e.Data.GetData(typeof(GridHitInfo)) as GridHitInfo;
            if (downHitInfo != null)
            {
                GridControl grid = sender as GridControl;
                GridView view = grid.MainView as GridView;
                GridHitInfo hitInfo = view.CalcHitInfo(grid.PointToClient(new Point(e.X, e.Y)));
                if (hitInfo.InRow && hitInfo.RowHandle != downHitInfo.RowHandle)
                    e.Effect = DragDropEffects.Move;
            }

        }

        private void fld_dgvModuleSection_MouseMove(object sender, MouseEventArgs e)
        {
            GridView view = sender as GridView;
            if (e.Button == MouseButtons.Left && downHitInfo != null)
            {
                Size dragSize = SystemInformation.DragSize;
                Rectangle dragRect = new Rectangle(new Point(downHitInfo.HitPoint.X - dragSize.Width / 2,
                    downHitInfo.HitPoint.Y - dragSize.Height / 2), dragSize);

                if (!dragRect.Contains(new Point(e.X, e.Y)))
                {
                    view.GridControl.DoDragDrop(downHitInfo, DragDropEffects.All);
                    downHitInfo = null;
                }
            }   
        }

        private void MoveRow(int sourceRow, int targetRow)
        {
            if (sourceRow == targetRow) return;
            STModulesInfo temp = (STModulesInfo)lstModule[sourceRow].Clone();
            lstModule.RemoveAt(sourceRow);
            lstModule.Insert(targetRow, temp);
            fld_dgcModuleSection.DataSource = lstModule;
            fld_dgvModuleSection.RefreshData();
        }
#endregion

    }
}