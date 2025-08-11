using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraTreeList.Columns;
using BOSComponent;
using BOSLib;
using System.Drawing;
using DevExpress.XtraTreeList;
using Localization;

namespace BOSERP.Modules.UserManagement
{
    public partial class STToolbarsTreeListControl : BOSTreeListControl
    {
        /// <summary>
        /// A value indicates whether the change is made by user
        /// </summary>
        private bool IsUserChange = true;

        public STToolbarsTreeListControl()
        {
            InitializeComponent();
        }

        public STToolbarsTreeListControl(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }

        protected override void InitTreeListDataSource()
        {
            UserManagementEntities entity = (UserManagementEntities)((BaseModuleERP)this.Screen.Module).CurrentModuleEntity;
            BOSTreeList dataSource = new BOSTreeList();
            this.DataSource = entity.STToolbarsTreeList;
        }

        public override void InitTreeListColumns(string strTableName)
        {
            base.InitTreeListColumns(strTableName);
            for (int i = 0; i < this.Columns.Count; i++)
            {
                this.Columns[i].VisibleIndex = i;
            }
            this.BOSDisplayOption = true;

            TreeListColumn column = Columns["STToolbarCaption"];
            if (column != null)
            {
                column.VisibleIndex = 1;
                column.Width = 150;
                column.OptionsColumn.AllowEdit = false;
            }
        }

        public override void InitializeControl()
        {
            base.InitializeControl();
            this.CellValueChanging += new CellValueChangedEventHandler(STToolbarsTreeListControl_CellValueChanging);
        }

        /// <summary>
        /// Modifying the checkstate of the cell value
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void STToolbarsTreeListControl_CellValueChanging(object sender, CellValueChangedEventArgs e)
        {
            if (e.Column.FieldName == "Selected")
            {
                if (IsUserChange)
                {
                    UserManagementEntities entity = ((BaseModuleERP)this.Screen.Module).CurrentModuleEntity as UserManagementEntities;
                    BOSTreeListObject node = entity.STToolbarsTreeList.CurrentObject as BOSTreeListObject;
                    if (node.Selected)
                        node.Selected = false;
                    else
                        node.Selected = true;
                    if (node.SubList != null)
                    {
                        node.SubList.SetValueToList("Selected", node.Selected);
                    }
                    this.RefreshDataSource();
                    IsUserChange = false;
                }
                else
                {
                    IsUserChange = true;
                }
            }
        }       
    }
}
