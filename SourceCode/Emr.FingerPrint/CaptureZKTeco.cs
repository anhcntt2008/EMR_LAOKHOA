using BOSLib;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
using Sample;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Emr.FingerPrint
{
    public partial class CaptureZKTeco : Form
    {
        const int MESSAGE_CAPTURED_OK = 0x0400 + 6;
        private readonly List<SignerNameDto> _listName;
        private readonly SignerNameDto _defaultSigner;
        private readonly string _contentHash;
        private ReaderHandlerZK _handlerZK;

        public string SelectedName { get; private set; }
        public SignerNameDto SelectedSigner { get; private set; }
        public CaptureZKTeco(ReaderHandlerZK handlerZK, string contentHash, List<SignerNameDto> listName, SignerNameDto defaultSigner, bool alternativeSign)
        {
            InitializeComponent();
            _handlerZK = handlerZK;
            _contentHash = contentHash;
            _listName = listName;
            _defaultSigner = defaultSigner;
            chkAltSign.Enabled = alternativeSign;
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Ok_KeyDown);
        }
        private void Ok_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Alt && e.KeyCode == Keys.O)
            {
                this.Ok();
            }
        }
        private void CaptureZKTeco_Load(object sender, EventArgs e)
        {
            this.KeyPreview = true;

            GridView grid = fld_dgcSignerName.MainView as GridView;
            grid.OptionsSelection.EnableAppearanceFocusedCell = false;
            grid.OptionsSelection.EnableAppearanceFocusedRow = true;
            grid.OptionsSelection.MultiSelectMode = GridMultiSelectMode.CheckBoxRowSelect;
            grid.OptionsSelection.MultiSelect = false;
            grid.OptionsBehavior.Editable = false;
            grid.OptionsView.ShowGroupPanel = false;
            grid.FocusedRowChanged += Grid_FocusedRowChanged;

            var col = grid.Columns.Add();
            col.Visible = true;
            col.FieldName = col.Name = "Relation";
            col.Width = 100;
            col.OptionsColumn.AllowEdit = false;
            col.Caption = "Quan hệ";

            col = grid.Columns.Add();
            col.FieldName = col.Name = "FullName";
            col.Width = 200;
            col.OptionsColumn.AllowEdit = true;
            col.Caption = "Họ và tên";
            col.Visible = true;

            col = grid.Columns.Add();
            col.FieldName = col.Name = "SignerNo";
            col.Width = 200;
            col.OptionsColumn.AllowEdit = true;
            col.Caption = "Mã bệnh nhân";
            col.Visible = true;

            this.fld_dgcSignerName.DataSource = _listName;
            this.fld_dgcSignerName.RefreshDataSource();
            this.fld_dgcSignerName.Refresh();
            for (int i = 0; i < gridView2.DataRowCount; i++)
            {
                if (gridView2.IsGroupRow(i)) continue;
                var row = gridView2.GetRow(i) as SignerNameDto;
                if (row.FullName == _defaultSigner.FullName)
                {
                    gridView2.SelectRow(i);
                    gridView2.FocusedRowHandle = i;
                    break;
                }
            }
            txtSignerName.Text = _defaultSigner.FullName;
        }

        private void Grid_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            var grid = (sender as GridView);
            if (e.FocusedRowHandle >= 0)
            {
                var row = grid.GetRow(e.FocusedRowHandle) as SignerNameDto;
                if (string.IsNullOrEmpty(row.FullName))
                    row = _listName.FirstOrDefault();
                SelectedName = row?.FullName;
                SelectedSigner = row;
                txtSignerName.Text = row?.FullName;
            }
        }

        private void chkAltSign_CheckedChanged(object sender, EventArgs e)
        {
            CheckEdit edit = sender as CheckEdit;
            if (edit.Checked)
                txtAltSign.Text = "Ký thay";
            else
                txtAltSign.Text = string.Empty;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            pbFingerprint.Image = null;
            this.DialogResult = DialogResult.Cancel;
        }
        private void btnClosed_Click(object sender, EventArgs e)
        {
            _handlerZK.DBClear();
            _handlerZK.CloseDevice();
            _handlerZK.Terminate();
        }
        private void btnOk_Click(object sender, EventArgs e)
        {
            Ok();
        }
        private void Ok()
        {
            SelectedName = (chkAltSign.Checked ? txtAltSign.Text + ": " : string.Empty) + txtSignerName.Text.ToUpper();
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
        public Image GetImage()
        {
            return pbFingerprint.Image;
        }
        #region SendMessage
        private enum Action
        {
            SendBitmap,
            SendMessage
        }
        private delegate void SendMessageCallback(Action action, object payload);
        private void SendMessage(Action action, object payload)
        {
            try
            {
                if (this.pbFingerprint.InvokeRequired)
                {
                    SendMessageCallback d = new SendMessageCallback(SendMessage);
                    this.Invoke(d, new object[] { action, payload });
                }
                else
                {
                    switch (action)
                    {
                        case Action.SendMessage:
                            MessageBox.Show((string)payload);
                            break;
                        case Action.SendBitmap:
                            pbFingerprint.Image = (Bitmap)payload;
                            pbFingerprint.Refresh();
                            Console.Beep();
                            break;
                    }
                }
            }
            catch (Exception)
            {
            }
        }
        #endregion
        protected override void DefWndProc(ref Message m)
        {
            switch (m.Msg)
            {
                case MESSAGE_CAPTURED_OK:
                    {
                        try
                        {
                            SendMessage(Action.SendBitmap, _handlerZK.CreateBitmap(_handlerZK.FPBuffer, _handlerZK.mfpWidth, _handlerZK.mfpHeight, _contentHash));
                        }
                        catch (Exception ex)
                        {

                        }
                    }
                    break;

                default:
                    base.DefWndProc(ref m);
                    break;
            }
        }

    }
}
