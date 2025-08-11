using BOSComponent;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
namespace BOSERP
{
    public partial class guiSelectDept : Form
    {
        private List<HRDepartmentsInfo> _workingDepts;
        private bool _popUpIsOpened = false;
        public guiSelectDept(List<HRDepartmentsInfo> workingDepts)
        {
            InitializeComponent();
            _workingDepts = workingDepts;
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Ok_KeyDown);
            lkeDepartment.Properties.ValueMember = "HRDepartmentID";
            lkeDepartment.Properties.DisplayMember = "HRDepartmentName";
            var column = new DevExpress.XtraEditors.Controls.LookUpColumnInfo
            {
                Caption = "Mã khoa",
                FieldName = "HRDepartmentNo",
                Width = 80
            };
            lkeDepartment.Properties.Columns.Add(column);
            column = new DevExpress.XtraEditors.Controls.LookUpColumnInfo
            {
                Caption = "Tên khoa",
                FieldName = "HRDepartmentName",
                Width = 150
            };
            lkeDepartment.Properties.Columns.Add(column);
            lkeDepartment.Properties.Popup += lkeDepartmentProperties_Popup;
            lkeDepartment.Properties.Closed += lkeDepartmentProperties_Closed;
            lkeDepartment.TabIndex = 0;
            lkeDepartment.Click += LkeDepartment_Click;
        }

        private void LkeDepartment_Click(object sender, EventArgs e)
        {
            ((BOSLookupEdit)sender).SelectAll();
        }

        private void lkeDepartmentProperties_Closed(object sender, DevExpress.XtraEditors.Controls.ClosedEventArgs e)
        {
            _popUpIsOpened = false;
        }

        private void lkeDepartmentProperties_Popup(object sender, EventArgs e)
        {
            _popUpIsOpened = true;
        }

        private void guiSelectDept_Load(object sender, EventArgs e)
        {
            this.KeyPreview = true;
            lkeDepartment.Properties.DataSource = _workingDepts;
            lkeDepartment.EditValue = _workingDepts.First().HRDepartmentID;
            lkeDepartment.Focus();
            lkeDepartment.SelectAll();
        }
        private void Ok_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Alt && e.KeyCode == Keys.O)
            {
                this.Ok();
            }
            else if (e.KeyCode == Keys.Enter)
                this.Ok();
            else if (e.KeyCode == Keys.Escape)
                this.Cancel();
        }

        private void Cancel()
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void Ok()
        {
            if (_popUpIsOpened)
            {
                lkeDepartment.SelectAll();
                return;
            }
            SelectedDepartmentID = int.Parse(lkeDepartment.EditValue.ToString());
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
        public sealed override Color BackColor
        {
            get { return base.BackColor; }
            set { base.BackColor = value; }
        }

        public int SelectedDepartmentID { get; internal set; }

        private void fld_btnOk_Click(object sender, EventArgs e)
        {
            Ok();
        }

        private void lkeDepartment_Enter(object sender, EventArgs e)
        {
            ((BOSLookupEdit)sender).SelectAll();
        }
    }
}