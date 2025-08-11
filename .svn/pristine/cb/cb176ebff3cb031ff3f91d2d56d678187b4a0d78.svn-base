
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BOSERP.Modules.MEEmrAction.UI
{
    public partial class guiIntegrationIntruction : BOSERPScreen
    {
        public guiIntegrationIntruction()
        {
            InitializeComponent();
        }

        private void guiIntegrationIntruction_Load(object sender, EventArgs e)
        {
            txtIntruction.Text = (Module as MEEmrActionModule).GetIntegrationIntruction();
        }
    }
}
