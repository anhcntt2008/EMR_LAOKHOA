using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

namespace BOSERP.Modules.MEService.UI
{
	/// <summary>
	/// Summary description for DMSE100
	/// </summary>
	public partial class DMSE100 : BOSERPScreen
	{

		public DMSE100()
		{
			//
			// Required designer variable
			//
			InitializeComponent();
		}

        private void fld_btnSaveProducts_Click(object sender, EventArgs e)
        {
            ((MEServiceModule)Module).SaveProductServiceList();
        }
	}
}
