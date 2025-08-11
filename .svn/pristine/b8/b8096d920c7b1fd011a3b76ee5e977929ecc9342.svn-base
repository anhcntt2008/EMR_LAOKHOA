using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using BOSCommon;
using BOSERP.Modules.ME.MEPatient.Localization;
using Clas.Business.BHYT;
using Clas.CHBase.Model;
using Clas.Model.BHYT;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraTab;
using Localization;

namespace BOSERP.Modules.MEPatient.UI
{
    /// <summary>
    ///     Summary description for DMMAPA100
    /// </summary>
    public partial class DMMEPA100 : BOSERPScreen
    {
        private KeyValue _chbaseData;
        private readonly List<List<LichSuKCBChiTiet>> _subList = new List<List<LichSuKCBChiTiet>>();

        public DMMEPA100()
        {
            //
            // Required designer variable
            //
            InitializeComponent();

            fld_dteStartDate.DateTime = DateTime.Today.AddYears(-1);
            fld_dteEndDate.DateTime = DateTime.Today;
            PanelCls.Visible = false;
        }
        private void fld_lkeFK_MEOccupationID_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                var occupationID = Convert.ToInt32(fld_lkeFK_MEOccupationID.EditValue);
                if (occupationID == -1)
                    ((MEPatientModule)Module).CreateNewOccupation();
                Control_KeyUp(sender, e);
            }
        }

        private void fld_bedGELocationName_ButtonClick(object sender,
            ButtonPressedEventArgs e)
        {
            ((MEPatientModule)Module).ChooseLocation();
        }

        private void fld_txtMEPatientName1_EditValueChanged(object sender, EventArgs e)
        {
            ((MEPatientModule)Module).SearchPatientByName();
        }

        private void fld_dteMEPatientBirthday_EditValueChanged(object sender, EventArgs e)
        {
            //Duoc thay the boi event fld_dteMEPatientBirthday_Validated
            //Vi event nay duoc goi trong module Quan ly nguoi dung
            //Module quan ly nguoi dung khong remote duoc event cua devexpress
            //((MEPatientModule)Module).SearchPatientByNameAndBirthdayAndGender();
            try
            {
                var age = DateTime.Now.Year - fld_dteMEPatientBirthday.DateTime.Year;
                if (DateTime.Now.Month < fld_dteMEPatientBirthday.DateTime.Month ||
                    DateTime.Now.Month == fld_dteMEPatientBirthday.DateTime.Month &&
                    DateTime.Now.Day < fld_dteMEPatientBirthday.DateTime.Day)
                    age--;
                fld_txtMEPatientAge.Text = age.ToString();
            }
            catch (Exception)
            {
                //
            }
        }

        private void fld_dteMEPatientBirthday_Validated(object sender, EventArgs e)
        {
            ((MEPatientModule)Module).SearchPatientByNameAndBirthdayAndGender();
        }

        private void fld_lkeMEGender_EditValueChanged(object sender, EventArgs e)
        {
            ((MEPatientModule)Module).SearchPatientByNameAndBirthdayAndGender();
        }

        private void fld_lkeFK_MEEthnicID_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                var ethnicID = Convert.ToInt32(fld_lkeFK_MEEthnicID.EditValue);
                if (ethnicID == -1)
                    ((MEPatientModule)Module).CreateNewEthnic();
                Control_KeyUp(sender, e);
            }
        }

        private void fld_tabTabControl100_Selecting(object sender, TabPageCancelEventArgs e)
        {

            if (e.Page == xtraTabPageChBase)
            {
                var getData = ((MEPatientModule)Module).GetChBaseInfo();
                if ((bool)getData.Key)
                {
                    var chBaseInfo = (MECHBasesInfo)getData.Value;
                    if (chBaseInfo == null)
                    {
                        var checkDialog =
                            MessageBox.Show(
                                PatientLocalizedResources.PatientNotShare,
                                CommonLocalizedResources.MessageBoxDefaultCaption, MessageBoxButtons.YesNo,
                                MessageBoxIcon.Warning);
                        if (checkDialog == DialogResult.Yes)
                            ((MEPatientModule)Module).RequestChBase();
                        e.Cancel = true;
                    }
                    else
                    {
                        if (!chBaseInfo.MECHBaseHasAuthorized)
                        {
                            var checkDialog =
                                MessageBox.Show(
                                    PatientLocalizedResources.PatientNotAccept,
                                    CommonLocalizedResources.MessageBoxDefaultCaption, MessageBoxButtons.YesNo,
                                    MessageBoxIcon.Warning);
                            if (checkDialog == DialogResult.Yes)
                                chBaseInfo = ((MEPatientModule)Module).ReCreateBasesInfo(chBaseInfo); //((MEPatientModule)Module).SendMailRequest(chBaseInfo, true);
                            e.Cancel = true;
                        }
                    }
                }
                else
                {
                    e.Cancel = true;
                }
            }
            if (e.Page == xtraTabPageBHYT)
            {
                if (string.IsNullOrEmpty(BOSApp.CurrentBranchInfo.BRBranchHealthInsurancePassword) ||
                string.IsNullOrEmpty(BOSApp.CurrentBranchInfo.BRBranchHealthInsuranceUserName))
                {
                    MessageBox.Show("Bạn chưa thiết lập tài khoản đăng nhập vào hệ thống bảo hiểm y tế.", "Thông báo");
                    return;
                }
                Cursor.Current = Cursors.WaitCursor;
                var entity = (MEPatientEntities)((BaseModuleERP)Module).CurrentModuleEntity;
                var objMEPatiensInfo = (MEPatientsInfo)entity.MainObject;
                _subList.Clear();
                comboBoxTheBHYT.Properties.Items.Clear();
                if (entity.MEPatientInssList.Count > 0)
                {
                    showInfo(true);
                    comboBoxTheBHYT.Properties.Items.AddRange(
                        entity.MEPatientInssList.Select(t => t.MEPatientInsNo).ToList());
                    foreach (var objPatientInss in entity.MEPatientInssList)
                    {
                        var bhytManage = new BHYTManager(BOSApp.CurrentBranchInfo.BRBranchHealthInsuranceUserName, BOSApp.CurrentBranchInfo.BRBranchHealthInsurancePassword);
                        var objKQPhienLamViec = bhytManage.GetPhienLamViec();
                        var _list = new List<LichSuKCBChiTiet>();
                        if (objKQPhienLamViec != null && objKQPhienLamViec.maKetQua == "200")
                        {
                            var objTheBHYT = new ApiTheBHYT
                            {
                                maThe = objPatientInss.MEPatientInsNo,
                                hoTen = objMEPatiensInfo.MEPatientName,
                                ngaySinh = objMEPatiensInfo.MEPatientBirthday.ToString("dd/MM/yyyy"),
                                gioiTinh = objMEPatiensInfo.MEGender.Equals("Male") ? 1 : 2,
                                maCSKCB = objPatientInss.MEPatientInsRegisteredPlaceNo,
                                ngayBD = objPatientInss.MEPatientInsRegisteredDate.ToString("dd/MM/yyyy"),
                                ngayKT = objPatientInss.MEPatientInsExpiryDate.ToString("dd/MM/yyyy")
                            };
                            var objLichSuKCB = bhytManage.GetLichSuKCB(objKQPhienLamViec.APIKey, objTheBHYT);
                            comboBoxLSKB.Properties.Items.Clear();
                            comboBoxLSKB.Text = string.Empty;
                            if (objLichSuKCB.dsLichSuKCB != null)
                            {
                                var listLSKB = new List<string>();
                                foreach (var objLichSu in objLichSuKCB.dsLichSuKCB)
                                {
                                    var objLichSuKCBChiTiet = bhytManage.KQNhanHoSoKCBChiTiet(objKQPhienLamViec.APIKey,
                                        objLichSu);
                                    _list.Add(objLichSuKCBChiTiet);
                                    listLSKB.Add(objLichSuKCBChiTiet.hoSoKCB.xml1.TenBenh);
                                }
                                comboBoxLSKB.Properties.Items.AddRange(listLSKB);
                            }
                        }
                        _subList.Add(_list);
                    }
                    comboBoxTheBHYT.SelectedIndex = 0;
                }
                else
                {
                    showInfo(false);
                    comboBoxTheBHYT.SelectedIndex = 0;
                    comboBoxTheBHYT.Text = string.Empty;
                }
                Cursor.Current = Cursors.Default;
            }
        }

        private void fld_btnOK_Click(object sender, EventArgs e)
        {
            if (fld_dteStartDate.DateTime > fld_dteEndDate.DateTime)
            {
                MessageBox.Show(
                    PatientLocalizedResources.StartDateMoreThenEndDate,
                    CommonLocalizedResources.MessageBoxDefaultCaption, MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning);
                return;
            }
            var data = ((MEPatientModule)Module).ShowData(fld_dteStartDate.DateTime, fld_dteEndDate.DateTime,
                fld_cboType.SelectedIndex);
            switch (fld_cboType.SelectedIndex)
            {
                case 0:
                    navBarControlHistoryChBase.Visible = true;
                    navBarControlReading.Visible = false;
                    PanelCls.Visible = false;

                    gridControlProcedure.DataSource = data[0];
                    gridControlMedication.DataSource = data[1];
                    gridControlImmunization.DataSource = data[2];
                    gridView1.Columns[0].Visible = false;
                    gridView2.Columns[0].Visible = false;
                    gridView3.Columns[0].Visible = false;
                    break;
                case 1:
                    navBarControlHistoryChBase.Visible = false;
                    navBarControlReading.Visible = true;
                    PanelCls.Visible = false;

                    gridControlHeightWeight.DataSource = data[0];
                    gridControlBloodGlucose.DataSource = data[1];
                    gridControlBloodSep.DataSource = data[2];
                    gridControlSignVitals.DataSource = data[3];
                    gridView4.Columns[0].Visible = false;
                    gridView5.Columns[0].Visible = false;
                    gridView6.Columns[0].Visible = false;
                    gridView7.Columns[0].Visible = false;
                    break;
                case 2:
                    navBarControlHistoryChBase.Visible = false;
                    navBarControlReading.Visible = false;
                    PanelCls.Visible = true;
                    var cls = data[0] as List<FileModel>;
                    GridCls.DataSource = cls;
                    gridView12.Columns[0].Visible = false;
                    break;
            }
        }

        private void fld_txtMEPatientContactEmail_Validated(object sender, EventArgs e)
        {
            ((MEPatientModule)Module).InvalidateAppointmentList();
        }

        private void fld_txtMEPatientContactCellPhone_Validated(object sender, EventArgs e)
        {
            ((MEPatientModule)Module).InvalidateAppointmentList();
        }

        private void comboBoxTheBHYT_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBoxLSKB.Properties.Items.Clear();
            if (_subList.Count > 0)
                if (_subList[comboBoxTheBHYT.SelectedIndex].Count > 0)
                {
                    comboBoxLSKB.Properties.Items.AddRange(
                        _subList[comboBoxTheBHYT.SelectedIndex].Select(t => t.hoSoKCB.xml1.TenBenh).ToList());
                    comboBoxLSKB.SelectedIndex = 0;
                    showInfo(true);
                }
                else
                {
                    comboBoxLSKB.Text = string.Empty;
                    showInfo(false);
                }
        }

        private void comboBoxLSKB_SelectedIndexChanged(object sender, EventArgs e)
        {
            gridControlMedical.DataSource =
                _subList[comboBoxTheBHYT.SelectedIndex][comboBoxLSKB.SelectedIndex].hoSoKCB.dsXml2;
            gridControlDVKT.DataSource =
                _subList[comboBoxTheBHYT.SelectedIndex][comboBoxLSKB.SelectedIndex].hoSoKCB.dsXml3;
            gridControlDVKT.DataSource =
                _subList[comboBoxTheBHYT.SelectedIndex][comboBoxLSKB.SelectedIndex].hoSoKCB.dsXml3;
            gridControlHSCLS.DataSource =
                _subList[comboBoxTheBHYT.SelectedIndex][comboBoxLSKB.SelectedIndex].hoSoKCB.dsXml4;
            gridControlHSDB.DataSource =
                _subList[comboBoxTheBHYT.SelectedIndex][comboBoxLSKB.SelectedIndex].hoSoKCB.dsXml5;
            var year =
                _subList[comboBoxTheBHYT.SelectedIndex][comboBoxLSKB.SelectedIndex].hoSoKCB.xml1.NgayVao.ToString()
                    .Substring(0, 4);
            var month =
                _subList[comboBoxTheBHYT.SelectedIndex][comboBoxLSKB.SelectedIndex].hoSoKCB.xml1.NgayVao.ToString()
                    .Substring(4, 2);
            var day =
                _subList[comboBoxTheBHYT.SelectedIndex][comboBoxLSKB.SelectedIndex].hoSoKCB.xml1.NgayVao.ToString()
                    .Substring(6, 2);
            bosLabel15.Text = day + "/" + month + "/" + year;
            bosLabel12.Text =
                _subList[comboBoxTheBHYT.SelectedIndex][comboBoxLSKB.SelectedIndex].hoSoKCB.xml1.SoNgayDtri.ToString();
            bosLabel14.Text = _subList[comboBoxTheBHYT.SelectedIndex][comboBoxLSKB.SelectedIndex].hoSoKCB.xml1.DiaChi;
            bosLabel17.Text = _subList[comboBoxTheBHYT.SelectedIndex][comboBoxLSKB.SelectedIndex].hoSoKCB.xml1.HoTen;
            bosLabel19.Text =
                _subList[comboBoxTheBHYT.SelectedIndex][comboBoxLSKB.SelectedIndex].hoSoKCB.xml1.GioiTinh == 1
                    ? "Nam"
                    : "Nữ";
            var birthday_year =
                _subList[comboBoxTheBHYT.SelectedIndex][comboBoxLSKB.SelectedIndex].hoSoKCB.xml1.NgaySinh.Substring(0, 4);
            var birthday_month =
                _subList[comboBoxTheBHYT.SelectedIndex][comboBoxLSKB.SelectedIndex].hoSoKCB.xml1.NgaySinh.Substring(4, 2);
            var birthday_day =
                _subList[comboBoxTheBHYT.SelectedIndex][comboBoxLSKB.SelectedIndex].hoSoKCB.xml1.NgaySinh.Substring(6, 2);
            bosLabel21.Text = birthday_day + "/" + birthday_month + "/" + birthday_year;
        }

        private void showInfo(bool show)
        {
            bosLabel10.Visible = show;
            bosLabel11.Visible = show;
            bosLabel12.Visible = show;
            bosLabel13.Visible = show;
            bosLabel14.Visible = show;
            bosLabel15.Visible = show;
            bosLabel17.Visible = show;
            bosLabel18.Visible = show;
            bosLabel19.Visible = show;
            bosLabel20.Visible = show;
            bosLabel21.Visible = show;
            bosLabel22.Visible = show;
            navBarControl1.Visible = show;
        }

        private void gridView12_DoubleClick(object sender, EventArgs e)
        {
            var selectRow = gridView12.GetSelectedRows();
            if (selectRow.Length == 0)
                return;
            var obj = gridView12.GetRow(selectRow[0]);
            if (obj == null)
                return;
            ((MEPatientModule)Module).OpenFileCls(((FileModel)obj).Id);
        }

        private void fld_txtMEPatientName1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
                SendKeys.Send("{TAB}");
        }

        private void fld_dteMEPatientBirthday_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
                SendKeys.Send("{TAB}");
        }

        private void fld_lkeMEGender_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
                SendKeys.Send("{TAB}");
        }

        private void fld_txtMEPatientIDCard_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
                SendKeys.Send("{TAB}");
        }

        private void Control_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
                SendKeys.Send("{TAB}");
        }

        private void fld_txtMEPatientContactEmail_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13 || e.KeyCode == Keys.Tab)
                fld_txtMEPatientContactAddressLine1.Focus();
        }

        private void fld_txtMEPatientContactAddressPostalCode100_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13 || e.KeyCode == Keys.Tab)
                fld_lkeFK_MEOccupationID.Focus();
        }

        private void fld_txtMEPatientAge_TextChanged(object sender, EventArgs e)
        {
           /* try
            {
                var age = int.Parse(fld_txtMEPatientAge.Text);
                var date = new DateTime(DateTime.Today.Year - age, 1, 1);
                fld_dteMEPatientBirthday.DateTime = date;
            }
            catch (Exception)
            {
                //ignore
            }
            */
        }


        private void fld_txtMEPatientAge_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                e.Handled = true;
        }

        private void fld_txtMEPatientAge_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13 || e.KeyCode == Keys.Tab)
            {

                fld_lkeMEGender.Focus();
            }
            try
            {
                var age = int.Parse(fld_txtMEPatientAge.Text);
                var date = new DateTime(DateTime.Today.Year - age, 1, 1);
                fld_dteMEPatientBirthday.DateTime = date;
            }
            catch (Exception)
            {
                //ignore
            }
        }
        private void fld_txtMEPatientContactEmail_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Tab)
            {
                e.IsInputKey = true;
            }
        }

        private void fld_txtMEPatientContactAddressPostalCode100_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Tab)
            {
                e.IsInputKey = true;
            }
        }



        private void fld_txtQR_KeyPress(object sender, KeyPressEventArgs e)
        {
            // ky tu ket thuc qr code
            fld_txtQRStatus.Text = "Đang xử lý dữ liệu...";
            if (e.KeyChar == '$')
            {
                QrHelper qr = new QrHelper();
                var card = qr.QrParse(fld_txtQR.Text);
                if (card == null)
                {
                    fld_txtQRStatus.Text = "Mã QR không đúng, vui lòng thử lại.";
                    fld_txtQR.Text = string.Empty;
                    fld_txtQR.Focus();
                    return;
                }
                int id = ((MEPatientModule)Module).InvalidateFromInsuranceCard(card);
                fld_txtQRStatus.Text = "Click vào đây để quét lại";
                fld_txtQR.Text = string.Empty;
            }
        }

        private void fld_txtQRStatus_Click(object sender, EventArgs e)
        {
            fld_txtQRStatus.Text = "Đang chờ quét mã thẻ...";
            fld_txtQR.Text = string.Empty;
            fld_txtQR.Focus();
        }

        private void fld_txtQR_Leave(object sender, EventArgs e)
        {
            fld_txtQRStatus.Text = "Click vào đây để quét lại";
            fld_txtQR.Text = string.Empty;
        }

        private void fld_txtMEPatientContactAddressPostalCode100_KeyPress(object sender, KeyPressEventArgs e)
        {
           
        }

        private void fld_txtMEPatientContactAddressPostalCode100_KeyUp_1(object sender, KeyEventArgs e)
        {
            ((MEPatientModule)Module).GetLocationByThreeLevelCode();
        }
    }
}