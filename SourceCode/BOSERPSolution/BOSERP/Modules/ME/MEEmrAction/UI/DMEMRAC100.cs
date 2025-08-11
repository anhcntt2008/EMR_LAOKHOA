using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using DevExpress.XtraGrid.Views.Grid;
using Localization;
using System.Collections.Generic;
using DevExpress.XtraGrid.Columns;
using BOSComponent;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Repository;
using BOSCommon;

namespace BOSERP.Modules.MEEmrAction.UI
{
    /// <summary>
    /// Summary description for DMEMRAC100
    /// </summary>
    public partial class DMEMRAC100 : BOSERPScreen
    {

        public DMEMRAC100()
        {
            //
            // Required designer variable
            //
            InitializeComponent();
        }

        private void fld_btnRemoveActionParam_Click(object sender, EventArgs e)
        {
            GridView gridView = (GridView)this.fld_dgcMEEmrActionParams.MainView;
            if (gridView.FocusedRowHandle < 0)
            {
                MessageBox.Show(BaseLocalizedResources.ChooseObjectMessage, CommonLocalizedResources.MessageBoxDefaultCaption, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            ((MEEmrActionModule)Module).RemoveParamFromAction(gridView.GetRow(gridView.FocusedRowHandle) as MEEmrActionParamsInfo);
        }

        private void fld_btnAddActionParam_Click(object sender, EventArgs e)
        {
            GridView gridView = (GridView)this.fld_dgcMEParams.MainView;
            if (gridView.FocusedRowHandle < 0)
            {
                MessageBox.Show(BaseLocalizedResources.ChooseObjectMessage, CommonLocalizedResources.MessageBoxDefaultCaption, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            ((MEEmrActionModule)Module).AddParamToAction(gridView.GetRow(gridView.FocusedRowHandle) as MEParamsInfo);
        }

        private void fld_btnAddRequestParam_Click(object sender, EventArgs e)
        {
            AddRequestParamToAction();
        }

        private void fld_dgcRequestParamPool_DoubleClick(object sender, EventArgs e)
        {
            AddRequestParamToAction();
        }
        private void AddRequestParamToAction()
        {
            GridView gridView = (GridView)this.fld_dgcRequestParamPool.MainView;
            if (gridView.FocusedRowHandle < 0)
            {
                MessageBox.Show(BaseLocalizedResources.ChooseObjectMessage, CommonLocalizedResources.MessageBoxDefaultCaption, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            ((MEEmrActionModule)Module).AddRequestParamToAction((KeyValuePair<string, object>)gridView.GetRow(gridView.FocusedRowHandle));
        }
        private void fld_lkeFK_MESourceTemplateID_EditValueChanged(object sender, EventArgs e)
        {
            if (fld_lkeFK_MESourceTemplateID.EditValue == null) return;
            var gridView = fld_dgcMEEmrActionParams.MainView as GridView;
            GridColumn column = gridView.Columns["MEEmrActionParamSourcePath"];
            if (column != null)
            {
                var rep = new RepositoryItemLookUpEdit();
                rep.TextEditStyle = TextEditStyles.Standard;
                rep.SearchMode = SearchMode.AutoFilter;
                rep.NullText = string.Empty;
                rep.BestFitMode = BestFitMode.BestFitResizePopup;
                rep.Tag = "METemplateParams";
                rep.ValueMember = "METemplateParamPath";
                rep.DisplayMember = "MEParamName";
                var table = ((MEEmrActionModule)Module).GetEmrActionParamSourcePaths((int)fld_lkeFK_MESourceTemplateID.EditValue).Tables[0];
                var dumyRow = table.NewRow();
                dumyRow["METemplateParamPath"] = string.Empty;
                table.Rows.InsertAt(dumyRow, 0);
                rep.DataSource = table;
                var colName = new LookUpColumnInfo();
                colName.Caption = "Tên thẻ dữ liệu nguồn";
                colName.FieldName = rep.DisplayMember;
                colName.Width = 150;
                rep.Columns.Add(colName);

                colName = new LookUpColumnInfo();
                colName.Caption = "Đường dẫn thẻ dữ liệu nguồn";
                colName.FieldName = "METemplateParamPath";
                colName.Width = 200;
                rep.Columns.Add(colName);

                column.OptionsColumn.AllowEdit = true;
                column.ColumnEdit = rep;
            }
        }

        private void fld_lkeMEEmrActionType_EditValueChanged(object sender, EventArgs e)
        {
            var lke = (BOSLookupEdit)sender;
            if (lke.EditValue == null) return;
            if (lke.EditValue.ToString() != EmrActionTypes.DinamapProV100.ToString()) return;
            var gridView = fld_dgcMEEmrActionParams.MainView as GridView;
            GridColumn column = gridView.Columns["MEEmrActionParamSourcePath"];
            if (column != null)
            {
                var rep = new RepositoryItemLookUpEdit();
                rep.TextEditStyle = TextEditStyles.Standard;
                rep.SearchMode = SearchMode.AutoFilter;
                rep.NullText = string.Empty;
                rep.BestFitMode = BestFitMode.BestFitResizePopup;
                rep.Tag = "METemplateParams";

                rep.ValueMember = "V100DataPath";
                rep.DisplayMember = "V100DataName";
                var table = new List<object>()
                {
                   new { V100DataPath ="Systolic", V100DataName="Huyết áp tâm thu" },
                   new { V100DataPath ="Diastolic", V100DataName="Huyết áp tâm trương" },
                   new { V100DataPath ="Oxygen", V100DataName="Nồng độ Oxy máu SpO2" },
                   new { V100DataPath ="HeartRate", V100DataName="Nhịp tim" },
                   new { V100DataPath ="Temperature", V100DataName="Nhiệt độ" },
                };

                rep.DataSource = table;
                var colName = new LookUpColumnInfo();

                colName.Caption = "Tên thẻ dữ liệu nguồn";
                colName.FieldName = rep.DisplayMember;
                colName.Width = 150;
                rep.Columns.Add(colName);

                colName = new LookUpColumnInfo();
                colName.Caption = "Đường dẫn thẻ dữ liệu nguồn";
                colName.FieldName = rep.ValueMember;
                colName.Width = 200;
                rep.Columns.Add(colName);

                column.OptionsColumn.AllowEdit = true;
                column.ColumnEdit = rep;
            }
            fld_dgcMEEmrActionParams.MainView.RefreshData();
        }
    }
}
