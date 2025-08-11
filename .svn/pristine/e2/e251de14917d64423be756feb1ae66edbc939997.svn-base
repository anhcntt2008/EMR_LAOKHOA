using BOSLib;
using DevExpress.DataAccess.ConnectionParameters;
using DevExpress.DataAccess.Sql;
using DevExpress.Xpo;
using DevExpress.Xpo.DB;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraRichEdit;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BOSERP.Modules.CompanyConstant.UI
{
    public partial class DMCS109 : BOSERPScreen
    {
        public DMCS109()
        {
            InitializeComponent();
        }

        private void fld_btnTestConnection_Click(object sender, EventArgs e)
        {
            var gridView = (fld_dgcReportDataSourceConfigValues.MainView as GridView);
            var config = gridView.GetFocusedRow() as ADConfigValuesInfo;
            if (config != null)
            {
                try
                {
                    IDataStore dataStore = XpoDefault.GetConnectionProvider(config.ADConfigKeyDesc, AutoCreateOption.None);
                    var simpleDataLayer = new SimpleDataLayer(dataStore);
                    MessageBox.Show("Connect successfully");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Connect failed");
                }
            }
        }
    }
}
