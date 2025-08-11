using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using BOSComponent;
using DevExpress.XtraGrid.Columns;
using Localization;
using DevExpress.XtraGrid.Views.Grid;
using BOSCommon;
using DevExpress.XtraEditors.Controls;
using BOSLib;
using System.Data;

namespace BOSERP.Modules.Report
{
    public partial class RPInputInvoiceGridControl : ReportGridControl
    {
        protected override void AddColumnsToGridView(string strTableName, DevExpress.XtraGrid.Views.Grid.GridView gridView)
        {
            base.AddColumnsToGridView(strTableName, gridView);

            GridColumn column = new GridColumn();
            column.Caption = ReportLocalizedResources.Selected;
            column.FieldName = "Selected";
            column.OptionsColumn.AllowEdit = true;
            gridView.Columns.Add(column);

            column = new GridColumn();
            column.Caption = ReportLocalizedResources.DocumentInvoiceType;
            column.FieldName = "DocumentInvoiceType";
            column.OptionsColumn.AllowEdit = true;
            gridView.Columns.Add(column);

            column = new GridColumn();
            column.Caption = ReportLocalizedResources.ACObjectName;
            column.FieldName = "ACObjectName";
            column.OptionsColumn.AllowEdit = true;
            gridView.Columns.Add(column);
        }

        protected override GridView InitializeGridView()
        {
            GridView gridView = base.InitializeGridView();
            gridView.OptionsBehavior.Editable = true;
            GridColumn column = gridView.Columns["ACDocumentFormNo"];
            if (column != null)
            {
                column.OptionsColumn.AllowEdit = true;
            }         
            column = gridView.Columns["ACDocumentVoucherNo"];
            if (column != null)
            {
                column.OptionsColumn.AllowEdit = true;
            }
            column = gridView.Columns["ACDocumentSymbol"];
            if (column != null)
            {
                column.OptionsColumn.AllowEdit = true;
            }
            //column = gridView.Columns["ACDocumentInvoiceType"];
            //if (column != null)
            //{
            //    column.OptionsColumn.AllowEdit = true;
            //    RepositoryItemBOSLookupEdit rep = new RepositoryItemBOSLookupEdit();
            //    rep.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo("ADConfigText", ""));
            //    rep.ShowHeader = false;
            //    rep.TextEditStyle = TextEditStyles.Standard;
            //    rep.NullText = string.Empty;
            //    rep.DisplayMember = "ADConfigText";
            //    rep.ValueMember = "ADConfigKeyValue";
            //    rep.DataSource = GetAllInputInvoiceTypes();
            //    column.ColumnEdit = rep;
            //}
            //column = gridView.Columns["ACDocumentInvoiceNo"];
            //if (column != null)
            //{
            //    column.OptionsColumn.AllowEdit = true;
            //    RepositoryItemBOSLookupEdit rep = new RepositoryItemBOSLookupEdit();
            //    rep.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo("ADConfigText", ""));
            //    rep.ShowHeader = false;
            //    rep.TextEditStyle = TextEditStyles.Standard;
            //    rep.NullText = string.Empty;
            //    rep.DisplayMember = "ADConfigText";
            //    rep.ValueMember = "ADConfigKeyValue";
            //    rep.DataSource = GetAllVATInvoiceNos();
            //    column.ColumnEdit = rep;
            //}
            return gridView;
        }


        //public List<ADConfigValuesInfo> GetAllVATInvoiceNos()
        //{
        //    List<ADConfigValuesInfo> dataSource = new List<ADConfigValuesInfo>();

        //    ADConfigValuesController controller = new ADConfigValuesController();
        //    DataSet ds = controller.GetADConfigValuesByGroup(ConfigValueGroup.InvoiceInvoiceNo);
        //    if (ds != null && ds.Tables.Count != 0)
        //    {
        //        foreach (DataRow row in ds.Tables[0].Rows)
        //        {
        //            ADConfigValuesInfo configValue = controller.GetObjectFromDataRow(row) as ADConfigValuesInfo;
        //            dataSource.Add(configValue);
        //        }
        //    }
        //    return dataSource;
        //}

        //public List<ADConfigValuesInfo> GetAllInputInvoiceTypes()
        //{
        //    List<ADConfigValuesInfo> dataSource = new List<ADConfigValuesInfo>();

        //    ADConfigValuesController controller = new ADConfigValuesController();
        //    DataSet ds = controller.GetADConfigValuesByGroup(ConfigValueGroup.InvoiceInInvoiceType);
        //    if (ds != null && ds.Tables.Count != 0)
        //    {
        //        foreach (DataRow row in ds.Tables[0].Rows)
        //        {
        //            ADConfigValuesInfo configValue = controller.GetObjectFromDataRow(row) as ADConfigValuesInfo;
        //            dataSource.Add(configValue);
        //        }
        //    }
        //    return dataSource;   
        //}

    }
}
