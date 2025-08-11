using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using BOSERP.Modules.MEEmr;
using DevExpress.XtraGrid.Views.Grid;
using Clas.Emr.Model;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using DevExpress.XtraGrid.Views.Base;
using BOSCommon;
using System.IO;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors;
using DevExpress.XtraLayout.Utils;
using System.Drawing.Drawing2D;
using System.Linq;
using BOSERP.UI;
using BOSLib;

namespace BOSERP.Modules.MEEmr.UI
{
    /// <summary>
    /// Lien Ket Benh An
    /// </summary>
    public partial class guiSelectPatientRelation : BOSERPScreen
    {
        private readonly List<SignerNameDto> _listName;
        private readonly SignerNameDto _defaultSigner;
        public string SelectedName { get; private set; }
        public SignerNameDto SelectedSigner { get; private set; }

        public guiSelectPatientRelation(List<SignerNameDto> listName, SignerNameDto defaultSigner, bool alternativeSign)
        {
            InitializeComponent();
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.guiSelectPatientRelation_Ok_KeyDown);
            _listName = listName;
            _defaultSigner = defaultSigner;
            guiSelectPatientRelation_chkSefl.Checked = alternativeSign;
        }

        private void guiSelectPatientRelation_Load(object sender, EventArgs e)
        {
            this.KeyPreview = true;
            this.InitializeControls(this.Controls);

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
            //guiSelectPatientRelation_fld_txtSignName.Text = _defaultSigner.FullName;
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
                guiSelectPatientRelation_fld_txtSignName.Text = row?.FullName;
            }
        }

        private void guiSelectPatientRelation_Ok_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Alt && e.KeyCode == Keys.O)
            {
                Ok();
            }
        }

        private void guiSelectPatientRelation_btnOk_Click(object sender, EventArgs e)
        {
            Ok();
        }

        public void Ok()
        {
            SelectedName = (guiSelectPatientRelation_chkSefl.Checked ? txtAltSign.Text + ": " : string.Empty) + guiSelectPatientRelation_fld_txtSignName.Text.ToUpper();
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void guiSelectPatientRelation_btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            this.Close();
        }


        private void guiSelectPatientRelation_chkSefl_CheckedChanged(object sender, EventArgs e)
        {
            CheckEdit edit = sender as CheckEdit;
            if (edit.Checked)
            {
                txtAltSign.Text = "Ký thay";
                guiSelectPatientRelation_fld_txtSignName.Text = "";
                guiSelectPatientRelation_fld_txtSignName.Enabled = true;
                guiSelectPatientRelation_fld_lkeMEEmrRelation.Enabled = true;
                fld_dgcSignerName.Enabled = true;
            }
            else
            {
                txtAltSign.Text = string.Empty;
                guiSelectPatientRelation_fld_txtSignName.Text = _defaultSigner.FullName;
                guiSelectPatientRelation_fld_txtSignName.Enabled = false;
                guiSelectPatientRelation_fld_lkeMEEmrRelation.Enabled = false;
                fld_dgcSignerName.Enabled = false;
            }
        }
    }
}
