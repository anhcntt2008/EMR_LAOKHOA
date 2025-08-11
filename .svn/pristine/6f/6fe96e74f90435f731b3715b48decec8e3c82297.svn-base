using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BOSERP.Modules.MEPatient;
using Localization;

namespace BOSERP.Modules.ME.MEPatient.UI
{
    public partial class guiSendRequestShareCHBase : BOSERPScreen
    {
        public MECHBasesInfo MechBasesInfo;
        public guiSendRequestShareCHBase()
        {
            InitializeComponent();
        }

        private void fld_btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void fld_btnOK_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(fld_txtParticipantName.Text) || string.IsNullOrEmpty(fld_txtQuestion.Text) ||
                string.IsNullOrEmpty(fld_txtAnswer.Text))
            {
                MessageBox.Show("Vui lòng nhập tất cả thông tin.", CommonLocalizedResources.MessageBoxDefaultCaption,
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            MechBasesInfo = new MECHBasesInfo()
            {
                MECHBaseParticipantName =fld_txtParticipantName.Text.Trim(),
                MECHBaseSecurityQuestion =fld_txtQuestion.Text,
                MECHBaseSecurityAnswer = fld_txtAnswer.Text,
                MECHBaseParticipantId = Guid.NewGuid().ToString(),
                MECHBaseDateTokenGenerated = DateTime.Now,
                MECHBaseHasAuthorized = false
            };
            ((MEPatientModule)Module).SendRequestChBase(MechBasesInfo);
            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
