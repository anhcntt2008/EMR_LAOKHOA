using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Data;
using BOSLib;
using DevExpress.XtraGrid.Views.Grid;
using System.Windows.Forms;
using DevExpress.XtraEditors.Controls;
using Localization;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Localization;

namespace BOSERP.Modules.CompanyConstant
{
    public partial class ICProductOriginsGridControl : BOSComponent.BOSGridControl
    {
        public override void InitGridControlDataSource()
        {
            CompanyConstantEntities entity = (CompanyConstantEntities)((BaseModuleERP)Screen.Module).CurrentModuleEntity;
            BindingSource bds = new BindingSource();
            bds.DataSource = entity.ProductOriginList;
            this.DataSource = bds;
        }

        protected override GridView InitializeGridView()
        {
            GridView gridView = base.InitializeGridView();
            foreach (GridColumn item in gridView.Columns)
            {
                item.OptionsColumn.AllowEdit = true;
            }
            gridView.OptionsView.ShowGroupPanel = false;
            gridView.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Bottom;
            gridView.KeyUp += new System.Windows.Forms.KeyEventHandler(GridView_KeyUp);
            gridView.ValidateRow += new DevExpress.XtraGrid.Views.Base.ValidateRowEventHandler(gridView_ValidateRow);
            return gridView;
        }

        void gridView_ValidateRow(object sender, DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs e)
        {
            GridLocalizer.Active = new MyLocalizer();
            GridView gridView = (GridView)sender;
            ICProductOriginsInfo obj = (ICProductOriginsInfo)gridView.GetFocusedRow();
            CompanyConstantEntities entity = (CompanyConstantEntities)((BaseModuleERP)Screen.Module).CurrentModuleEntity;
            if (string.IsNullOrEmpty(obj.ICProductOriginNo))
            {
                e.ErrorText = CompanyConstantLocalizedResources.NotNullOrEmptyProductOriginNoMessage;
                e.Valid = false;
            }
            else if (string.IsNullOrEmpty(obj.ICProductOriginName))
            {
                e.ErrorText = CompanyConstantLocalizedResources.NotNullOrEmptyProductOriginNameMessage;
                e.Valid = false;
            }
            else if (entity.ProductOriginList.FindAll(p => p.ICProductOriginNo == obj.ICProductOriginNo).Count > 1)
            {
                e.ErrorText = CompanyConstantLocalizedResources.NotSameValueProductOriginMessage;
                e.Valid = false;
            }
        }

        protected override void GridView_KeyUp(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            base.GridView_KeyUp(sender, e);
            if (e.KeyCode == Keys.Delete)
            {
                ((CompanyConstantModule)Screen.Module).RemoveSelectedProductOrigin();
            }
        }
    }
    public class MyLocalizer : DevExpress.XtraGrid.Localization.GridLocalizer
    {
        public override string GetLocalizedString(DevExpress.XtraGrid.Localization.GridStringId id)
        {
            if (id == DevExpress.XtraGrid.Localization.GridStringId.ColumnViewExceptionMessage)
                return string.Empty;
            return base.GetLocalizedString(id);
        }
    }
}
