using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Text;
using BOSComponent;
using DevExpress.XtraGrid.Columns;
using Localization;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraEditors.Repository;

namespace BOSERP
{
    public partial class MEPatientVisitsGridControl : BOSGridControl
    {
        protected override void AddColumnsToGridView(string strTableName, DevExpress.XtraGrid.Views.Grid.GridView gridView)
        {
            base.AddColumnsToGridView(strTableName, gridView);
            GridColumn column = new GridColumn();
            column.Caption = CommonLocalizedResources.MEPatientName;
            column.FieldName = "MEPatientName";
            column.OptionsColumn.AllowEdit = false;
            gridView.Columns.Add(column);
        }

        protected override GridView InitializeGridView()
        {
            GridView gridView = base.InitializeGridView();

            RepositoryItemDateEdit repositoryItemTimeEdit = new RepositoryItemDateEdit();
            // repositoryItemDateEdit
            repositoryItemTimeEdit.AutoHeight = false;
            repositoryItemTimeEdit.DisplayFormat.FormatString = "HH:mm:ss";
            repositoryItemTimeEdit.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            repositoryItemTimeEdit.Mask.EditMask = "HH:mm:ss";
            repositoryItemTimeEdit.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTime;
            repositoryItemTimeEdit.Name = "repositoryItemTimeEdit1";

            GridColumn columnDateTime = gridView.Columns["MEPatientVisitCheckInTime"];
            if (columnDateTime != null)
            {
                columnDateTime.ColumnEdit = repositoryItemTimeEdit;
            }
            return gridView;
        }
    }
}
