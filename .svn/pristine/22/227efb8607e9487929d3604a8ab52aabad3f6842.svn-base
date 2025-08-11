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

namespace BOSERP.Modules.METemplate
{
    /// <summary>
    /// Summary description for DSMEEMR100
    /// </summary>
    public partial class DSMEEMR105 : BOSERPScreen
    {
        private Dictionary<string, object> _data;
        private MEParamsController _paramsController;
        private MEParamRelationsController _paramRelationsController;
        private List<MEParamsInfo> _listParamData;

        public DSMEEMR105(Dictionary<string, object> data, List<MEParamsInfo> listParamData)
        {
            InitializeComponent();
            this._data = data;
            this._paramsController = new MEParamsController();
            this._paramRelationsController = new MEParamRelationsController();
            _listParamData = listParamData;
        }

        private void DSMEEMR100_Load(object sender, EventArgs e)
        {
            this.fld_grdSelectionDataChart.Screen = this;
            this.fld_grdSelectionDataChart.InitializeControl();
            this.fld_grdSelectionDataChart.DataSource = this._listParamData;
            this.fld_grdSelectionDataChart.RefreshDataSource();
            this.fld_grdSelectionDataChart.Refresh();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            var grid = this.fld_grdSelectionDataChart.MainView as GridView;
            var entity = (METemplateEntities)((BaseModuleERP)Module).CurrentModuleEntity;
            List<MEParamsInfo> selected = new List<MEParamsInfo>();
            if (grid.GetSelectedRows().Length == 0)
            {
                MessageBox.Show("Vui lòng chọn dữ liệu?", "Chọn dữ liệu");
                return;
            }
            foreach (var item in grid.GetSelectedRows())
            {
                selected.Add(grid.GetRow(item) as MEParamsInfo);
            }
            this.Close();
            ((METemplateModule)Module).ViewChartForm(this._data, selected);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
