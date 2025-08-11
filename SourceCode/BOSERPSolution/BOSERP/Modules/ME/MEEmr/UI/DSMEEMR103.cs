using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using BOSERP.Modules.MEEmr;
using DevExpress.XtraGrid.Views.Grid;
using Clas.Emr.Model;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using DevExpress.XtraGrid.Columns;
using System.Linq;
using Newtonsoft.Json;

namespace BOSERP.Modules.MEEmr.UI
{
    /// <summary>
    /// Summary description for DSMEEMR100
    /// </summary>
    public partial class DSMEEMR103 : BOSERPScreen
    {
        private JArray _data;
        private List<Dictionary<string, string>> _viewData;
        private List<MEEmrActionParamsInfo> _updateParams;
        private MEParamsController _paramCtrl;

        public JObject SelectedRow { get; private set; }

        //public DSMEEMR103()
        //{
        //    //
        //    // Required designer variable
        //    //
        //    InitializeComponent();
        //}

        public DSMEEMR103(JArray data, List<MEEmrActionParamsInfo> updateParams)
        {
            InitializeComponent();
            this._data = data;
            this._viewData = new List<Dictionary<string, string>>();
            foreach (var item in _data)
            {
                _viewData.Add(FlattenJsonToDict(item.ToObject<JObject>()));
            }
            this._updateParams = updateParams;
            this._paramCtrl = new MEParamsController();
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Ok_KeyDown);
        }
        private void Ok_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Alt && e.KeyCode == Keys.O)
            {
                this.Ok();
            }
        }

        private void DSMEEMR100_Load(object sender, EventArgs e)
        {
            this.KeyPreview = true;
            this.fld_grdDataSelection.Screen = this;
            this.fld_grdDataSelection.InitializeControl();
            this.InitGridColumns();
            this.fld_grdDataSelection.DataSource = JsonConvert.DeserializeObject(JsonConvert.SerializeObject(_viewData));
            this.fld_grdDataSelection.RefreshDataSource();
            this.fld_grdDataSelection.Refresh();
            var gridView = this.fld_grdDataSelection.MainView as GridView;
            gridView.BestFitColumns();
        }

        private void InitGridColumns()
        {
            var gridView = this.fld_grdDataSelection.MainView as GridView;
            var idx = 1;
            GridColumn column = new GridColumn();
            column.Caption = "Mã giao dịch";
            column.FieldName = "tid";
            column.OptionsColumn.AllowEdit = false;
            column.VisibleIndex = idx++;
            gridView.Columns.Add(column);

            foreach (var param in _updateParams)
            {
                var p = this._paramCtrl.GetObjectByID(param.FK_MEParamID) as MEParamsInfo;
                column = new GridColumn();
                column.Caption = p.MEParamCaption;
                column.FieldName = p.MEParamNo;
                column.OptionsColumn.AllowEdit = false;
                column.VisibleIndex = idx++;
                gridView.Columns.Add(column);
            }
            var row = this._viewData.FirstOrDefault();
            if (row != null)
                foreach (var item in row.Keys)
                {
                    if (gridView.Columns[item] != null) continue;
                    var code = item.Split('.').Last();
                    var p = this._paramCtrl.GetObjectByNo(code) as MEParamsInfo;
                    column = new GridColumn();
                    column.Caption = p != null ? p.MEParamCaption : item;
                    column.FieldName = item;
                    column.OptionsColumn.AllowEdit = false;
                    column.VisibleIndex = idx++;
                    gridView.Columns.Add(column);
                }
            gridView.OptionsView.ColumnAutoWidth = false;

        }
        public void Ok()
        {
            var grid = this.fld_grdDataSelection.MainView as GridView;
            foreach (var item in grid.GetSelectedRows())
            {
                this.SelectedRow = this._data[grid.GetDataSourceRowIndex(item)] as JObject;
            }
            if (this.SelectedRow != null)
            {
                DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("Chọn ít nhất 1 dòng dữ liệu", "Chưa chọn dữ liệu");
            }
        }
        private void btnOk_Click(object sender, EventArgs e)
        {
            Ok();

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            this.Close();
        }
        private static Dictionary<string, string> FlattenJsonToDict(JObject obj)
        {
            return obj.Descendants()
                .Where(j => j.Children().Count() == 0)
                .Aggregate(
                    new Dictionary<string, string>(),
                    (props, jtoken) =>
                    {
                        props.Add(jtoken.Path, jtoken.ToString());
                        return props;
                    });
        }
    }
}
