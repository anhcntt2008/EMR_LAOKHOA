using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BOSERP.Modules.ME.MEParams.UI
{
    public partial class MEParamValueSelectionForm : BOSERPScreen
    {
        public IList<MEParamValuesInfo> dataSource;

        public MEParamValueSelectionForm()
        {
            InitializeComponent();
        }

        private void MEParamValueSelectionForm_Load(object sender, EventArgs e)
        {
            this.fld_grdMEParamValues.Screen = this;
            this.fld_grdMEParamValues.InitializeControl();
            this.fld_grdMEParamValues.DataSource = this.dataSource;
            this.fld_grdMEParamValues.RefreshDataSource();
            this.fld_grdMEParamValues.Refresh();
        }

        private void fld_grdMEParamValues_Click(object sender, EventArgs e)
        {

        }
    }
}
