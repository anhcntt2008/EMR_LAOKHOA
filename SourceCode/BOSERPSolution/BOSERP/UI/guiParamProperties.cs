using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BOSCommon;

namespace BOSERP
{
    public partial class guiParamProperties : BOSERPScreen
	{
        private List<KeyValuePair<string, string>> properties;

        public guiParamProperties(List<KeyValuePair<string, string>> properties)
        {
            InitializeComponent();
            this.properties = properties;
        }

        private void guiKeyWordValue_Load(object sender, EventArgs e)
        {
            fld_grdParamProperties.DataSource = this.properties;
            fld_grdParamProperties.RefreshDataSource();
        }

        public override void InitializeControls(Control.ControlCollection controls)
        {
            foreach (Control ctrl in controls)
            {
                InitializeControl(ctrl);
                if (ctrl.Controls.Count > 0)
                {
                    InitializeControls(ctrl.Controls);
                }
            }
        }
	}
}
