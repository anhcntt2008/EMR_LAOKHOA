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
    public partial class MECommandsTreeListControl : BOSTreeListControl
    {
        public MECommandsTreeListControl()
        {
            InitializeComponent();
        }

        public MECommandsTreeListControl(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }

        public override void InitializeControl()
        {
            base.InitializeControl();
            this.ExpandAll();
            this.CellValueChanging += new CellValueChangedEventHandler(MECommandsTreeListControl_CellValueChanging);
        }

        protected void MECommandsTreeListControl_CellValueChanging(object sender, CellValueChangedEventArgs e)
        {
            if (e.Column.FieldName == "Selected")
            {
                UserManagementEntities entity = ((BaseModuleERP)this.Screen.Module).CurrentModuleEntity as UserManagementEntities;
                BOSTreeListObject node = entity.MECommandsTreeList.CurrentObject as BOSTreeListObject;

                if (node.Selected)
                    node.Selected = false;
                else
                    node.Selected = true;
                if (node.SubList != null)
                {
                    node.SubList.SetValueToList("Selected", node.Selected);
                }
                this.RefreshDataSource();
            }
        }

        protected override void InitTreeListDataSource()
        {
            UserManagementEntities entity = (UserManagementEntities)((BaseModuleERP)Screen.Module).CurrentModuleEntity;
            BOSTreeList dataSource = new BOSTreeList();
            ((UserManagementModule)Screen.Module).InitCommandTreeList();
            dataSource = entity.MECommandsTreeList;
            this.DataSource =dataSource;
        }

        public override void InitTreeListColumns(string strTableName)
        {
            base.InitTreeListColumns(strTableName);
            this.BOSDisplayOption = true;

            TreeListColumn column = Columns["MECommandDesc"];
            if (column != null)
            {
                column.VisibleIndex = 1;
                column.Width = 150;
                column.OptionsColumn.AllowEdit = false;
            }

            column = Columns["Selected"];
            column.Caption = UserManagementLocalizedResources.Choose;
            column.VisibleIndex = 2;
            column.OptionsColumn.AllowEdit = true;
        }

         
    }
}
