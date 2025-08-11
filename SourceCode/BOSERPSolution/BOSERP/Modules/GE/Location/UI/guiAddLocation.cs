using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Localization;

namespace BOSERP.Modules.Location
{
    public partial class guiAddLocation : BOSERPScreen
    {
        public guiAddLocation()
        {
            InitializeComponent();
        }   

        private void fld_btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void fld_btnAddLocation_Click(object sender, EventArgs e)
        {
            if (!((LocationModule)Module).CheckForValidLocation())
            {
                return;
            }
            
            DialogResult = DialogResult.OK;
            Close();
        }

        private void guiAddLocation_Load(object sender, EventArgs e)
        {
            fld_txtGELocationName.Screen = this;
            fld_txtGELocationName.InitializeControl();
            fld_medGELocationDesc.Screen = this;
            fld_medGELocationDesc.InitializeControl();
            fld_txtGELocationThreeLevelCode.Screen = this;
            fld_txtGELocationThreeLevelCode.InitializeControl();
        }       
    }
}
