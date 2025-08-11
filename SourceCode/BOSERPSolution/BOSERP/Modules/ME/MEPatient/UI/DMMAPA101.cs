using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

namespace BOSERP.Modules.MEPatient.UI
{
	/// <summary>
	/// Summary description for DMMAPA101
	/// </summary>
	public partial class DMMAPA101 : BOSERPScreen
	{

		public DMMAPA101()
		{
			//
			// Required designer variable
			//
			InitializeComponent();
		}

        private void fld_btnAdd101_Click(object sender, EventArgs e)
        {
            ((MEPatientModule)Module).AddItemToPatientRelativeList();
        }

        private void fld_btnDelete101_Click(object sender, EventArgs e)
        {
            ((MEPatientModule)Module).DeleteItemFromPatientRelativeList();
        }

        private void fld_btnEdit101_Click(object sender, EventArgs e)
        {
            ((MEPatientModule)Module).ChangeItemFromPatientRelativeList();
        }
	}
}
