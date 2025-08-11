using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using BOSLib;
using DevExpress.XtraGrid.Views.Grid;
using System.Data;
using System.Windows.Forms;
using DevExpress.XtraGrid.Columns;
using BOSComponent;
using BOSCommon;
using DevExpress.XtraGrid.Views.Base;
using Localization;


namespace BOSERP.Modules.CompanyConstant
{
    public class HROTFactorsGridControl : BOSGridControl
    {
        private DevExpress.XtraEditors.Repository.RepositoryItemDateEdit repositoryItemDateEdit;
        public override void InitGridControlDataSource()
        {
            CompanyConstantEntities entity = (CompanyConstantEntities)((BaseModuleERP)Screen.Module).CurrentModuleEntity;
            BindingSource bds = new BindingSource();
            bds.DataSource = entity.HROTFactorList;
            this.DataSource = bds;
        }

        protected override GridView InitializeGridView()
        {
            GridView gridView = base.InitializeGridView();
            gridView.OptionsView.NewItemRowPosition = NewItemRowPosition.Bottom;
            repositoryItemDateEdit = new DevExpress.XtraEditors.Repository.RepositoryItemDateEdit();

            // repositoryItemDateEdit
            repositoryItemDateEdit.AutoHeight = false;
            repositoryItemDateEdit.DisplayFormat.FormatString = "HH:mm:ss";
            repositoryItemDateEdit.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            repositoryItemDateEdit.EditFormat.FormatString = "HH:mm:ss";
            repositoryItemDateEdit.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            repositoryItemDateEdit.Mask.EditMask = "HH:mm:ss";
            repositoryItemDateEdit.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTime;
            repositoryItemDateEdit.Name = "repositoryItemDateEdit1";

            GridColumn column = gridView.Columns["HROTFactorValue"];
            if (column != null)
                column.OptionsColumn.AllowEdit = true;

            column = gridView.Columns["HROTFactorFromTime"];
            if (column != null)
            {
                column.OptionsColumn.AllowEdit = true;
                column.ColumnEdit = repositoryItemDateEdit;
            }

            column = gridView.Columns["HROTFactorType"];
            if (column != null)
            {
                column.OptionsColumn.AllowEdit = true;
            }

            column = gridView.Columns["HROTFactorToTime"];
            if (column != null)
            {
                column.OptionsColumn.AllowEdit = true;
                column.ColumnEdit = repositoryItemDateEdit;
            }
            gridView.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(GridView_FocusedRowChanged);
            gridView.KeyUp += new KeyEventHandler(GridView_KeyUp);
            return gridView;
        }

        private void GridView_KeyUp(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            //base.GridView_KeyUp(sender, e);
            GridView gridView = (GridView)sender;
            if (e.KeyCode == Keys.Delete)
            {
                if (gridView.FocusedRowHandle >= 0)
                {
                    HROTFactorsInfo objOTFactorsInfo = (HROTFactorsInfo)gridView.GetRow(gridView.FocusedRowHandle);
                    if (objOTFactorsInfo.HROTFactorType.Equals(OTFactorType.Holiday.ToString()))
                    {
                        MessageBox.Show(CompanyConstantLocalizedResources.HolidayIsOnlyOneMessage, CommonLocalizedResources.MessageBoxDefaultCaption, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    if (objOTFactorsInfo.HROTFactorType.Equals(OTFactorType.EndOfWeek.ToString()))
                    {
                        MessageBox.Show(CompanyConstantLocalizedResources.EndOfWeekIsOnlyOneMessage, CommonLocalizedResources.MessageBoxDefaultCaption, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    ((CompanyConstantModule)Screen.Module).RemoveSelectedFactor();
                }
            }
        }

        protected void GridView_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (e.FocusedRowHandle>= 0)
            {
                GridView gridView = (GridView)MainView;
                HROTFactorsInfo objOTFactorsInfo = (HROTFactorsInfo)gridView.GetRow(e.FocusedRowHandle);
                if (String.IsNullOrEmpty(objOTFactorsInfo.HROTFactorType))
                {
                    objOTFactorsInfo.HROTFactorType = OTFactorType.WorkingDay.ToString();
                }
            }
        }
        
    }
}
