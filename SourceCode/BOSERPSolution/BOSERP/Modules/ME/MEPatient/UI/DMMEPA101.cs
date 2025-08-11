using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using BOSERP;

namespace BOSERP.Modules.MEPatient.UI
{
    /// <summary>
    /// Summary description for DMMAPA101
    /// </summary>
    public partial class DMMEPA101 : BOSERPScreen
    {

        public DMMEPA101()
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

        private void fld_lkeFK_MEPatientID1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
            {
                int patientId = (int)(fld_lkeFK_MEPatientID1.EditValue.ToString() != string.Empty ? fld_lkeFK_MEPatientID1.EditValue : 0);
                if (patientId > 0)
                {
                    MEPatientsController ctr = new MEPatientsController();
                    var patient = (MEPatientsInfo)ctr.GetObjectByID(patientId);
                    ((MEPatientModule)Module).FillPatientRelativeByPatient(patient);
                }
            }
            
        }

        private void fld_lkeFK_MEPatientID1_EditValueChanged(object sender, EventArgs e)
        {
            SendKeys.Send("{ENTER}");
        }
    }
}
