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

namespace BOSERP.Modules.ME.MEPatient.UI
{
    public partial class GuiChBaseAccept : BOSERPScreen
    {
        private readonly MECHBasesInfo _chBasesInfo;
        private readonly string _password;
        public List<Guid> InfoCHBase;
        public GuiChBaseAccept(MECHBasesInfo basesInfo, string password)
        {
            InitializeComponent();
            _chBasesInfo = basesInfo;
            _password = password;
            Load += GuiChBaseAccept_Load;
        }

        private void GuiChBaseAccept_Load(object sender, EventArgs e)
        {
            fld_txtEmail.Text = _chBasesInfo.MECHBaseParticipantName;
            fld_txtPassword.Text = _password;
            fld_txtIdentityCode.Text = _chBasesInfo.MECHBaseParticipantCode;
            fld_txtQuestion.Text = _chBasesInfo.MECHBaseSecurityQuestion;
            fld_txtAnswer.Text = _chBasesInfo.MECHBaseSecurityAnswer;
        }

        private void fld_btnOK_Click(object sender, EventArgs e)
        {
            var module = (MEPatientModule)Module;
            var check = module.CheckStatusChBase(_chBasesInfo);
            if ((bool)check.Key)
            {
                InfoCHBase = check.Value as List<Guid>;
                DialogResult = DialogResult.OK;
                Close();
            }
            else
            {
                MessageBox.Show("Bạn chưa xác thực chia sẻ thông tin cho bệnh nhân. Vui lòng thử lại.", "Thông Báo");
            }

        }

        private void fld_btnClose_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(
                    "Bạn chắc chắn muốn hủy bỏ xác thực và gởi email thông tin chia sẻ bệnh án CHBase cho bệnh nhân?",
                    "Thông Báo") != DialogResult.OK) return;
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void fld_lblLink_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(fld_lblLink.Text);
        }
    }
}
