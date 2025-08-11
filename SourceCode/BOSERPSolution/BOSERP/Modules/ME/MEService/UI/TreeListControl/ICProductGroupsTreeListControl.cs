using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Text;
using System.Windows.Forms;
using BOSComponent;
using BOSLib;
using DevExpress.XtraTreeList;
using DevExpress.XtraTreeList.Columns;
using DevExpress.XtraTreeList.Nodes;
using Localization;
using System.Drawing;
using BOSERP.Modules.ME.MEService.Localization;

namespace BOSERP.Modules.MEService
{
    public partial class ICProductGroupsTreeListControl : BOSTreeListControl
    {
        public override void InitializeControl()
        {
            base.InitializeControl();

            FocusedNodeChanged += new DevExpress.XtraTreeList.FocusedNodeChangedEventHandler(TreeList_FocusedNodeChanged);
            KeyUp += new KeyEventHandler(ICProductGroupsTreeListControl_KeyUp);
            MouseClick += new MouseEventHandler(ICProductGroupsTreeListControl_MouseClick);
        }

        private void ICProductGroupsTreeListControl_MouseClick(object sender, MouseEventArgs e)
        {
            BOSTreeListControl productGroupTreeList = (BOSTreeListControl)sender;
            if (e.Button == MouseButtons.Right)
            {
                TreeListNode focusedNode = productGroupTreeList.FocusedNode;
                if (focusedNode != null)
                {
                    if (focusedNode.Level >= 0)
                    {
                        ContextMenu popupMenu = new ContextMenu();
                        popupMenu.MenuItems.Add(ServiceLocalizedResources.AddServiceGroup,
                                                                        new EventHandler(AddServiceGroup_Clicked));
                        popupMenu.MenuItems.Add(ServiceLocalizedResources.EditServiceGroup,
                                                                        new EventHandler(EditServiceGroup_Clicked));
                        popupMenu.MenuItems.Add(ServiceLocalizedResources.DeleteServiceGroup,
                                                                        new EventHandler(DeleteServiceGroup_Clicked));
                        popupMenu.Show(productGroupTreeList, new Point(e.X, e.Y));
                    }
                }
            }
        }

        private void ICProductGroupsTreeListControl_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                MEServiceEntities entity = (MEServiceEntities)((BaseModuleERP)Screen.Module).CurrentModuleEntity;
                TreeListNode node = entity.ICProductGroupList.TreeListControl.GetSelectedNode();
                if (node != null && node.Level > 0)
                {
                    ((MEServiceModule)Screen.Module).DeleteItemFromProductGroupTreeList();
                }
            }
        }

        protected override void InitTreeListDataSource()
        {
            MEServiceEntities entity = (MEServiceEntities)((BaseModuleERP)Screen.Module).CurrentModuleEntity;
            BOSTreeList dataSource = new BOSTreeList();
            dataSource.Add(new ICProductGroupsInfo(ServiceLocalizedResources.Service));
            dataSource[0].SubList = entity.ICProductGroupList;
            DataSource = dataSource;
        }

        public override void InitTreeListColumns(string strTableName)
        {
            base.InitTreeListColumns(strTableName);

            TreeListColumn column = Columns["ICProductGroupName"];
            column.VisibleIndex = 1;
            column.OptionsColumn.AllowEdit = false;
        }

        private void TreeList_FocusedNodeChanged(object sender, FocusedNodeChangedEventArgs e)
        {
            MEServiceEntities entity = (MEServiceEntities)((BaseModuleERP)Screen.Module).CurrentModuleEntity;
            TreeListNode node = entity.ICProductGroupList.TreeListControl.GetSelectedNode();
            ServiceGridControl serviceGridControl = (ServiceGridControl)Screen.Module.Controls[MEServiceModule.ServiceGridControlName];
            if (node != null && node.Level > 0)
            {
                ICProductGroupsInfo objProductGroupsInfo = (ICProductGroupsInfo)entity.ICProductGroupList.CurrentObject;
                if (objProductGroupsInfo != null)
                {
                    if (objProductGroupsInfo.ICProductList == null)
                    {
                        objProductGroupsInfo.ICProductList = new BOSList<ICProductsInfo>();
                        objProductGroupsInfo.ICProductList.InitBOSList(
                                                                    entity,
                                                                    BOSUtil.GetTableNameFromBusinessObjectType(typeof(ICProductGroupsInfo)),
                                                                    BOSUtil.GetTableNameFromBusinessObjectType(typeof(ICProductsInfo)),
                                                                    BOSList<ICProductsInfo>.cstRelationForeign);
                        ((BOSList<ICProductsInfo>)objProductGroupsInfo.ICProductList).GridControl = serviceGridControl;
                        if (objProductGroupsInfo.ICProductGroupID > 0)
                        {
                            objProductGroupsInfo.ICProductList.Invalidate(objProductGroupsInfo.ICProductGroupID);
                        }
                    }
                    serviceGridControl.InvalidateDataSource(objProductGroupsInfo.ICProductList);
                }
            }
        }

        /// <summary>
        /// Add new product service group
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddServiceGroup_Clicked(object sender, EventArgs e)
        {
            guiAddServiceGroup addServiceGroupForm = new guiAddServiceGroup();
            addServiceGroupForm.Module = Screen.Module;
            addServiceGroupForm.fld_btnAddServiceGroup.Text = "Thêm";
            addServiceGroupForm.Text = "Thêm nhóm dịch vụ";
            if (addServiceGroupForm.ShowDialog() == DialogResult.OK)
            {
                if (!string.IsNullOrEmpty(addServiceGroupForm.ProduceGroupName) && !string.IsNullOrEmpty(addServiceGroupForm.ProduceGroupNo))
                {
                    ((MEServiceModule)Screen.Module).AddItemToCategoryList(addServiceGroupForm.ProduceGroupName, addServiceGroupForm.ProduceGroupNo);
                }
            }
        }

        /// <summary>
        /// Edit selected product service group
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void EditServiceGroup_Clicked(object sender, EventArgs e)
        {
            ((MEServiceModule)Screen.Module).EditProductServiceGroup();
        }

        /// <summary>
        /// Delete selected product service group
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DeleteServiceGroup_Clicked(object sender, EventArgs e)
        {
            MEServiceEntities entity = (MEServiceEntities)((BaseModuleERP)Screen.Module).CurrentModuleEntity;
            TreeListNode node = entity.ICProductGroupList.TreeListControl.GetSelectedNode();
            if (node != null && node.Level > 0)
            {
                ((MEServiceModule)Screen.Module).DeleteItemFromProductGroupTreeList();
            }
        }
    }
}
