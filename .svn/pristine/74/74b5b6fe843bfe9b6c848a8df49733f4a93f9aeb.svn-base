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
using Clas.Emr.Core;

namespace BOSERP.Modules.MEEmr.UI
{
    /// <summary>
    /// Summary description for DSMEEMR100
    /// </summary>
    public partial class guiDateTimeSelection : BOSERPScreen
    {
        private DataAccess _dataHelper;
        private string mEParamFormatType;
        private string mEParamFormatString;

        public object InputValue { get; internal set; }

        public guiDateTimeSelection(string mEParamFormatType, string mEParamFormatString, DataAccess dataHelper)
        {
            InitializeComponent();
            this._dataHelper = dataHelper;
            this.mEParamFormatType = mEParamFormatType;
            this.mEParamFormatString = mEParamFormatString;
            if (this.mEParamFormatType == ParamFormatType.DateTime.ToString())
                cldDatetime.CalendarTimeEditing = DevExpress.Utils.DefaultBoolean.True;
            else if (this.mEParamFormatType == ParamFormatType.Time.ToString())
            {
                cldDatetime.CalendarDateEditing = false;
                cldDatetime.CalendarTimeEditing = DevExpress.Utils.DefaultBoolean.True;
            }

            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Ok_KeyDown);
        }
        private void Ok_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Alt && e.KeyCode == Keys.O)
            {
                this.Ok();
            }
        }

        private void DSMEEMR100_Load(object sender, EventArgs e)
        {
            this.KeyPreview = true;
            cldDatetime.EditValue = DateTime.Now;
            txtTime.Enabled = false;
            //if (!string.IsNullOrEmpty(mEParamFormatString))
            //{
            //    cldDatetime.CalendarTimeProperties.EditMask = mEParamFormatString;
            //}
        }
        public void Ok()
        {
            DialogResult = DialogResult.OK;
            if (cldDatetime.EditValue != null)
                //InputValue = string.Format(mEParamFormatString, ((DateTime)cldDatetime.EditValue));
                InputValue = _dataHelper.GetStringFromDataValue(mEParamFormatType, mEParamFormatString, (DateTime)cldDatetime.EditValue);
            this.Close();
        }
        private void btnOk_Click(object sender, EventArgs e)
        {
            this.Ok();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void cldDatetime_EditValueChanged(object sender, EventArgs e)
        {
            if (cldDatetime.EditValue != null)
                //txtTime.Text =  string.Format(mEParamFormatString, ((DateTime)cldDatetime.EditValue));
                txtTime.Text = _dataHelper.GetStringFromDataValue(mEParamFormatType, mEParamFormatString, (DateTime)cldDatetime.EditValue);
        }
    }
}
