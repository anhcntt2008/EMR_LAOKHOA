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
using DevExpress.XtraGrid.Views.Base;
using System.Linq;

namespace BOSERP.Modules.MEEmr.UI
{
    /// <summary>
    /// Summary description for DSMEEMR100
    /// </summary>
    public partial class DSMEEMR106 : BOSERPScreen
    {
        private bool _isMulti;
        private readonly List<string> _preSelectedVals;
        private MEParamLookupsInfo _config;
        private List<MEParamLookupDatasInfo> _listData;
        public List<MEParamLookupDatasInfo> SelectedData;

        private bool _sort = true;
        private List<MEParamLookupDatasInfo> _listDataCurrent; // use sort by user
        private string _valueField;
        private MEParamsInfo _mEParamsInfo;

        public DSMEEMR106(MEParamLookupsInfo config, List<MEParamLookupDatasInfo> listData, bool isMulti, List<string> selectedVals, MEParamsInfo mEParamsInfo, string valueField = "")
        {
            InitializeComponent();
            this.Width = Screen.PrimaryScreen.Bounds.Width - 100;
            this.Height = Screen.PrimaryScreen.Bounds.Height - 100;
            this._config = config;
            if (mEParamsInfo.MEParamExtend)
            {
                this._listData = listData.OrderBy(item => item.MEParamLookupDataText.Length).ToList();
                this.fld_dgcSelectedData.Visible = false;
                this.Width = Screen.PrimaryScreen.Bounds.Width / 2;
                this.Height = Screen.PrimaryScreen.Bounds.Height / 2;
                fld_grdMEParamLookupDatas.Width = this.Width - 10;
            }
            else
                this._listData = listData;
            this._isMulti = isMulti;
            this._preSelectedVals = selectedVals;
            this._mEParamsInfo = mEParamsInfo;

            _sort = _config.MEParamLookupSort;
            _listDataCurrent = new List<MEParamLookupDatasInfo>(); // use sort by user
            _valueField = valueField;

            SelectedData = new List<MEParamLookupDatasInfo>();
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Ok_KeyDown);
        }
        private void Ok_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Alt && e.KeyCode == Keys.O)
            {
                this.Ok();
            }
            else if (_mEParamsInfo.MEParamExtend && e.KeyCode == Keys.Enter)
            {
                this.Ok();
            }
        }
        private void DSMEEMR100_Load(object sender, EventArgs e)
        {
            this.KeyPreview = true;
            this.fld_grdMEParamLookupDatas.Screen = this;
            this.fld_grdMEParamLookupDatas.InitializeControl();
            this.fld_grdMEParamLookupDatas.DataSource = this._listData;
            this.fld_grdMEParamLookupDatas.RefreshDataSource();
            this.fld_grdMEParamLookupDatas.Refresh();
            var gridView = this.fld_grdMEParamLookupDatas.MainView as DevExpress.XtraGrid.Views.Grid.GridView;
            gridView.OptionsSelection.MultiSelect = _isMulti;
            gridView.OptionsBehavior.AutoExpandAllGroups = true;
            if (this._config.MEParamLookupAutoGroupLevel > 0)
            {
                gridView.Columns["MEParamLookupDataGroup"].Group();
            }
            if (this._config.MEParamLookupAutoGroupLevel > 1)
            {
                gridView.Columns["MEParamLookupDataGroup1"].Group();
            }
            if (this._config.MEParamLookupAutoGroupLevel > 2)
            {
                gridView.Columns["MEParamLookupDataGroup2"].Group();
            }
            if (_preSelectedVals != null && _isMulti && _preSelectedVals.Count > 0)
            {
                for (int i = 0; i < gridView.DataRowCount; i++)
                {
                    if (gridView.IsGroupRow(i)) continue;
                    var row = gridView.GetRow(i) as MEParamLookupDatasInfo;
                    if ((_mEParamsInfo.MEParamMap == "MEParamLookupDataValue" && _preSelectedVals.Contains(row.MEParamLookupDataValue))
                        || (_mEParamsInfo.MEParamMap == "MEParamLookupDataText" && _preSelectedVals.Contains(row.MEParamLookupDataText))
                        || (_mEParamsInfo.MEParamMap == "MEParamLookupDataKey" && _preSelectedVals.Contains(row.MEParamLookupDataKey)))
                    {
                        gridView.SelectRow(i);
                        row.Selected = true;
                        _listDataCurrent.Add(row); // use sort by user
                        if (_sort)
                        {
                            this.SelectedData.Add(row);
                        }
                    }
                }
                if (!_sort)
                {
                    foreach(var item in _preSelectedVals)
                    {
                        var itemE = _listDataCurrent.FirstOrDefault(m => item.Contains(m.MEParamLookupDataValue));
                        if (itemE != null)
                        {
                            SelectedData.Add(itemE);
                        }
                    }
                }
            }
            if (_isMulti)
            {
                this.fld_dgcSelectedData.Screen = this;
                this.fld_dgcSelectedData.InitializeControl();
                this.fld_dgcSelectedData.DataSource = this.SelectedData;
                this.fld_dgcSelectedData.RefreshDataSource();
                this.fld_dgcSelectedData.Refresh();
            }
            else
            {
                this.fld_dgcSelectedData.Visible = false;
                this.fld_grdMEParamLookupDatas.Width = this.fld_grdMEParamLookupDatas.Width + this.fld_dgcSelectedData.Width + 6;
            }

            if (_mEParamsInfo.MEParamExtend)
            {
                gridView.SetAutoFilterValue(gridView.Columns[1], _valueField, DevExpress.XtraGrid.Columns.AutoFilterCondition.Default);
                
                gridView.FocusedRowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle;
                gridView.FocusedColumn = gridView.Columns[1];
            }

            gridView.SelectionChanged += new DevExpress.Data.SelectionChangedEventHandler(GridView_SelectionChanged);
            gridView.DoubleClick += new EventHandler(GridView_DoubleClick);
            gridView.ColumnFilterChanged += new EventHandler(GridView_ColumnFilterChanged);
            gridView.CalcRowHeight += GridView_CalcRowHeight;
            gridView.BestFitColumns();
        }

        private void GridView_CalcRowHeight(object sender, RowHeightEventArgs e)
        {
            GridView grid = sender as GridView;
            if (grid.IsFilterRow(e.RowHandle))
                e.RowHeight = e.RowHeight + 10;
        }

        private void GridView_ColumnFilterChanged(object sender, EventArgs e)
        {
            GridView grid = sender as GridView;
            try
            {
                IsHandleSelectionChanged = false;
                for (int i = 0; i < grid.DataRowCount; i++)
                {
                    if (grid.IsGroupRow(i)) continue;
                    var row = grid.GetRow(i) as MEParamLookupDatasInfo;
                    if (row.Selected)
                        grid.SelectRow(i);
                }
            }
            catch (Exception) { throw; }
            finally
            {
                IsHandleSelectionChanged = true;
            }
        }

        private void GridView_DoubleClick(object sender, EventArgs e)
        {
            if (!_isMulti)
            {
                Ok();
            }
        }
        private bool IsHandleSelectionChanged = true;

        private void GridView_SelectionChanged(object sender, DevExpress.Data.SelectionChangedEventArgs e)
        {
            if (!IsHandleSelectionChanged) return;
            GridView grid = sender as GridView;
            var dataSources = grid.DataSource as List<MEParamLookupDatasInfo>;
            switch (e.Action)
            {
                case CollectionChangeAction.Add:
                    (grid.GetRow(e.ControllerRow) as MEParamLookupDatasInfo).Selected = true;
                    if (!_sort)
                    {
                        SelectedData.Add((grid.GetRow(e.ControllerRow) as MEParamLookupDatasInfo));
                    }
                    break;
                case CollectionChangeAction.Remove:
                    (grid.GetRow(e.ControllerRow) as MEParamLookupDatasInfo).Selected = false;
                    if (!_sort)
                    {
                        SelectedData.Remove((grid.GetRow(e.ControllerRow) as MEParamLookupDatasInfo));
                    }
                    break;
                case CollectionChangeAction.Refresh:
                    if (grid.SelectedRowsCount == 0)
                    {
                        for (int i = 0; i < grid.DataRowCount; i++)
                        {
                            if (grid.IsGroupRow(i)) continue;
                            var row = grid.GetRow(i) as MEParamLookupDatasInfo;
                            row.Selected = false;
                        }
                    }
                    foreach (int row in grid.GetSelectedRows())
                    {
                        var item = grid.GetRow(row) as MEParamLookupDatasInfo;
                        item.Selected = true;
                    }
                    break;
                default:
                    break;
            }
            if (_sort)
            {
                SelectedData.Clear();
                SelectedData.AddRange(dataSources.Where(r => r.Selected).ToList());
            }
            else
            {
                this.fld_dgcSelectedData.DataSource = this.SelectedData;
            }
            this.fld_dgcSelectedData.RefreshDataSource();
        }
        private void Ok()
        {
            var grid = this.fld_grdMEParamLookupDatas.MainView as GridView;
            MEEmrEntities entity = (MEEmrEntities)((BaseModuleERP)Module).CurrentModuleEntity;
            if (!_isMulti && grid.FocusedRowHandle >= 0)
            {
                var item = grid.GetRow(grid.FocusedRowHandle) as MEParamLookupDatasInfo;
                SelectedData.Add(item);
            }
            else if (_mEParamsInfo.MEParamExtend && SelectedData.Count == 0 && grid.RowCount > 0) //Mặc định lấy dòng đầu tiên
            {
                var item = grid.GetRow(0) as MEParamLookupDatasInfo;
                SelectedData.Add(item);
            }
            if (SelectedData.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn dữ liệu?", "Chọn dữ liệu");
                return;
            }
            if (_config.MEParamLookupMaximumSelect > 0 && SelectedData.Count > _config.MEParamLookupMaximumSelect)
            {
                MessageBox.Show($"Chỉ được chọn {_config.MEParamLookupMaximumSelect} dòng!", "Thông báo");
                return;
            }
            DialogResult = DialogResult.OK;
            this.Close();
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

        private void DSMEEMR106_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                DialogResult = DialogResult.Cancel;
                this.Close();
            }
        }

        private void DSMEEMR106_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void fld_dgcSelectedData_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Delete)
            {
                var grid = sender as DevExpress.XtraGrid.GridControl;
                GridView selectedGrid = grid.FocusedView as GridView;
                var gridLookup = this.fld_grdMEParamLookupDatas.MainView as GridView;
                var selectedRow = selectedGrid.GetRow(selectedGrid.GetFocusedDataSourceRowIndex()) as MEParamLookupDatasInfo;
                var dataList = gridLookup.DataSource as List<MEParamLookupDatasInfo>;
                for (int i = 0; i < dataList.Count; i++)
                {
                    if (selectedRow.MEParamLookupDataID == dataList[i].MEParamLookupDataID)
                    {
                        gridLookup.UnselectRow(i);
                        selectedRow.Selected = false;
                        break;
                    }
                }
                // selectedGrid.DeleteSelectedRows();
                e.Handled = true;
            }

        }
    }
}
