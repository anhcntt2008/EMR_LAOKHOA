using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Windows.Forms;
using BOSBase;
using BOSCommon;
using BOSLib;
using Clas.Business.Doctor24x7;
using Clas.Model.Doctor24x7;
using Clas.Repository.HttpApi;
using Localization;
using Clas.Emr.Intergration;
using System.Configuration;
using Newtonsoft.Json.Linq;
using System.Text;
using System.Security.Cryptography;
using System.Net.NetworkInformation;
using Emr.Base.Models.Abp;

namespace BOSERP
{
    public partial class guiPassword : BOSERPScreen
    {
        public string Devide;
        public guiPassword()
        {
            InitializeComponent();
        }
        private void guiPassword_Load(object sender, EventArgs e)
        {
            fld_txtPasswordCurrent.Focus();
        }
        private void fld_btnUpdatePwd_Click(object sender, EventArgs e)
        {
            Ok();
        }
        private void fld_btnClose_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
        private void Ok()
        {
            var pwdCurr = fld_txtPasswordCurrent.Text;
            var pwdNew = fld_txtPasswordNew.Text;
            if (string.IsNullOrEmpty(pwdCurr) || string.IsNullOrEmpty(pwdNew))
            {
                MessageBox.Show("Vui lòng nhập mật khẩu.", CommonLocalizedResources.MessageBoxDefaultCaption,
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            var userCurr = BOSApp.CurrentUsersInfo;
            var dataPriv = userCurr.Clone() as ADUsersInfo; // Prevent edit user system
            var pwdCurrSecure = Convert.ToBase64String(SHA1Managed.Create().ComputeHash(ASCIIEncoding.ASCII.GetBytes(pwdCurr)));
            if (pwdCurrSecure != dataPriv.ADPassword)
            {
                MessageBox.Show("Mật khẩu hiện tại chưa đúng.", CommonLocalizedResources.MessageBoxDefaultCaption,
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            #region Prevent edit user system
            var configUsers = BOSApp.GetSystemConfigValue(SysCfgConsts.SYSTEM_CONFIGS, SysCfgConsts.SYSTEM_CONFIGS_USERS_SYSTEM);
            if (!string.IsNullOrEmpty(configUsers))
            {
                var userArr = configUsers.Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries).Select(p => p.Trim()).ToList();
                if (userArr.Contains(dataPriv.ADUserName))
                {
                    MessageBox.Show("Người dùng này được cấu hình không thay đổi thông tin. Cấu hình lại hoặc liên hệ IT hỗ trợ.", CommonLocalizedResources.MessageBoxDefaultCaption, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            #endregion

            dataPriv.ADPassword = pwdNew;
            ADUsersController objUsersController = new ADUsersController();
            objUsersController.UpdateUser(dataPriv, true);
            MessageBox.Show("Mật khẩu đã cập nhật.", CommonLocalizedResources.MessageBoxDefaultCaption,
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}