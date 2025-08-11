using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using BOSComponent;
using System.Windows.Forms;
using DevExpress.XtraTreeList.Nodes;
using Localization;
using DevExpress.XtraTreeList.Columns;
using System.Data;
using BOSCommon;
using System.Drawing;

namespace BOSERP.Modules.Location
{
    public partial class GELocationsTreeListControl : BOSTreeListControl
    {
        public override void InitializeControl()
        {
            base.InitializeControl();
            this.ExpandAll();
            MouseClick += new System.Windows.Forms.MouseEventHandler(GELocationsTreeListControl_MouseClick);
            KeyUp += new KeyEventHandler(GELocationsTreeListControl_KeyUp);
        }

        /// <summary>
        /// Prevent user delete selected location by delete key
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GELocationsTreeListControl_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
                return;
        }

        protected override void InitTreeListDataSource()
        {
            LocationEntities entity = (LocationEntities)((BaseModuleERP)Screen.Module).CurrentModuleEntity;
            BOSTreeList dataSource = new BOSTreeList();
            dataSource.Add(new GELocationsInfo(LocationLocalizedResources.LocationName));
            GELocationsController objLocationsController = new GELocationsController();
            DataSet ds = objLocationsController.GetAllParentOjects();
            entity.LocationTreeList.Invalidate(ds);
            dataSource[0].SubList = entity.LocationTreeList;
            DataSource = dataSource;
        }

        public override void InitTreeListColumns(string strTableName)
        {
            base.InitTreeListColumns(strTableName);

            TreeListColumn column = Columns["GELocationName"];
            column.VisibleIndex = 1;
            column.OptionsColumn.AllowEdit = false;
        }

        private void GELocationsTreeListControl_MouseClick(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            BOSTreeListControl locationTreeList = (BOSTreeListControl)sender;
            if (e.Button == MouseButtons.Right)
            {
                TreeListNode focusedNode = locationTreeList.FocusedNode;
                if (focusedNode != null)
                {
                    if (focusedNode.Level == 0)
                    {
                        ContextMenu popupMenu = new ContextMenu();
                        popupMenu.MenuItems.Add(LocationLocalizedResources.AddLocation, new EventHandler(AddLocation_Clicked));
                        popupMenu.Show(locationTreeList, new Point(e.X, e.Y));
                    }
                    else
                    {
                        ContextMenu popupMenu = new ContextMenu();
                        popupMenu.MenuItems.Add(LocationLocalizedResources.AddLocation, new EventHandler(AddLocation_Clicked));
                        popupMenu.MenuItems.Add(LocationLocalizedResources.EditLocation, new EventHandler(EditLocation_Clicked));
                        popupMenu.MenuItems.Add(LocationLocalizedResources.DeleteLocation, new EventHandler(DeleteLocation_Clicked));
                        popupMenu.Show(locationTreeList, new Point(e.X, e.Y));
                    }
                }
            }
        }
       
        private void AddLocation_Clicked(object sender, EventArgs e)
        {
            ((LocationModule)Screen.Module).AddLocation();            
        }

        private void EditLocation_Clicked(object sender, EventArgs e)
        {
            ((LocationModule)Screen.Module).EditLocation();
        }
      
        private void DeleteLocation_Clicked(object sender, EventArgs e)
        {
            LocationEntities entity = (LocationEntities)((BaseModuleERP)Screen.Module).CurrentModuleEntity;
            TreeListNode node = entity.LocationTreeList.TreeListControl.GetSelectedNode();
            if (node != null && node.Level > 0)
            {
                ((LocationModule)Screen.Module).DeleteSelectedLocation();
            }
        }
    }
}
