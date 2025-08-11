using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using BOSLib;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
using DPUruNet;

namespace Emr.FingerPrint
{
    public partial class Capture : Form
    {
        /// <summary>
        /// Holds the main form with many functions common to all of SDK actions.
        /// </summary>
        private ReaderHandler _handler;
        private readonly string _contentHash;
        private readonly List<SignerNameDto> _listName;
        private readonly SignerNameDto _defaultSigner;

        public string SelectedName { get; private set; }
        public SignerNameDto SelectedSigner { get; private set; }

        public Capture(ReaderHandler handler, string contentHash, List<SignerNameDto> listName, SignerNameDto defaultSigner, bool alternativeSign)
        {
            InitializeComponent();
            _handler = handler;
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
        /// <summary>
        /// Initialize the form.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Capture_Load(object sender, EventArgs e)
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

            // Reset variables
            //pbFingerprint.Image = null;

            if (!_handler.OpenReader())
            {
                this.Close();
            }

            if (!_handler.StartCaptureAsync(this.OnCaptured))
            {
                this.Close();
            }
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

        /// <summary>
        /// Handler for when a fingerprint is captured.
        /// </summary>
        /// <param name="captureResult">contains info and data on the fingerprint capture</param>
        public void OnCaptured(CaptureResult captureResult)
        {
            try
            {
                // Check capture quality and throw an error if bad.
                if (!_handler.CheckCaptureResult(captureResult)) return;

                // Create bitmap
                foreach (Fid.Fiv fiv in captureResult.Data.Views)
                {
                    SendMessage(Action.SendBitmap, _handler.CreateBitmap(fiv.RawImage, fiv.Width, fiv.Height, _contentHash));
                }
            }
            catch (Exception ex)
            {
                // Send error message, then close form
                SendMessage(Action.SendMessage, "Error:  " + ex.Message);
            }
        }
        private void Ok()
        {
            SelectedName = (chkAltSign.Checked ? txtAltSign.Text + ": " : string.Empty) + txtSignerName.Text.ToUpper();
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
        /// <summary>
        /// Close window.
        /// </summary>
        private void btnOK_Click(System.Object sender, System.EventArgs e)
        {

            Ok();
        }
        public Image GetImage()
        {
            return pbFingerprint.Image;
        }
        /// <summary>
        /// Close window.
        /// </summary>
        private void Capture_Closed(object sender, EventArgs e)
        {
            _handler.CancelCaptureAndCloseReader(this.OnCaptured);
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
                            //System.Media.SystemSounds.Beep.Play();
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

        private void button1_Click(object sender, EventArgs e)
        {
            pbFingerprint.Image = null;
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void chkAltSign_CheckedChanged(object sender, EventArgs e)
        {
            CheckEdit edit = sender as CheckEdit;
            if (edit.Checked)
                txtAltSign.Text = "Ký thay";
            else
                txtAltSign.Text = string.Empty;
        }
    }
}