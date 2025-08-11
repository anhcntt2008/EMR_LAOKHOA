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
using Emr.Devices.GeV100;
using System.Threading.Tasks;
using BOSComponent;
using DevExpress.XtraCharts;

namespace BOSERP.Modules.MEEmr.UI
{
    /// <summary>
    /// Summary description for DSMEEMR100
    /// </summary>
    public partial class guiGeV100Monitor : BOSERPScreen
    {
        private GeV100SerialConn _serialPort;
        private int _countTime = 0;
        private List<State> _data;

        public guiGeV100Monitor(Emr.Devices.GeV100.GeV100SerialConn v100SerialPort)
        {
            InitializeComponent();
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Ok_KeyDown);
            _serialPort = v100SerialPort;
            sysTimer.Interval = 1000;
            mearsurementTimer.Interval = int.Parse(spnTimeInterval.EditValue.ToString()) * 1000; //(30s)
            _data = new List<State>();
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
            if (_serialPort == null)
            {
                lblSerialPortMsg.Text = "Không tìm thấy Dinamap GE V100";
                return;
            }
            try
            {
                _serialPort.Open();
            }
            catch (Exception)
            {
                lblSerialPortMsg.Text = "Thiết bị không sẵn sàng";
                return;
            }
            sysTimer.Start();
            mearsurementTimer.Start();
            lblSerialPortMsg.Text = string.Empty;

            var serBlood = chartVitalSign.Series["Huyết áp"];
            serBlood.ArgumentDataMember = "TimeStr";
            serBlood.ValueDataMembers.AddRange(new string[] { "Diastolic", "Systolic" });

            var serTemp = chartVitalSign.Series["Nhiệt độ"];
            serTemp.ArgumentDataMember = "TimeStr";
            serTemp.ValueDataMembers.AddRange(new string[] { "Temperature" });

            var serSpO2 = chartVitalSign.Series["SpO2"];
            serSpO2.ArgumentDataMember = "TimeStr";
            serSpO2.ValueDataMembers.AddRange(new string[] { "Oxygen" });

            var serHeart = chartVitalSign.Series["Nhịp tim"];
            serHeart.ArgumentDataMember = "TimeStr";
            serHeart.ValueDataMembers.AddRange(new string[] { "HeartRate" });

            chartVitalSign.DataSource = _data;
            UpdateChart();
            chkViewLabelData.Checked = true;
        }
        public void Ok()
        {
            DialogResult = DialogResult.OK;
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
        }

        private void sysTimer_Tick(object sender, EventArgs e)
        {
            string szHour = DateTime.Now.ToString("HH:mm:ss");
            lblCurrentTime.ForeColor = Color.Black;
            lblCurrentTime.Text = szHour;
        }

        private void mearsurementTimer_Tick(object sender, EventArgs e)
        {
            UpdateChart();

        }
        private void UpdateChart()
        {
            if (!_serialPort.IsOpen)
            {
                lblSerialPortMsg.Text = "Kiểm tra kết nối đến thiết bị Dinamap GE V100";
                return;
            }
            _countTime++;
            lblCountTime.Text = _countTime.ToString();
            var state = Task.Run(async () => await _serialPort.GetStateAsync()).ConfigureAwait(false).GetAwaiter().GetResult();
            state.CountTime = _countTime;
            _data.Add(state);
            var msg = !string.IsNullOrEmpty(state.BloodPrsMsg) ? state.BloodPrsMsg + "; " : string.Empty;
            msg += !string.IsNullOrEmpty(state.OxygenMsg) ? state.OxygenMsg + "; " : string.Empty;
            msg += !string.IsNullOrEmpty(state.HeartRateMsg) ? state.HeartRateMsg + "; " : string.Empty;
            msg += !string.IsNullOrEmpty(state.TemperatureMsg) ? state.TemperatureMsg + "; " : string.Empty;
            lblSerialPortMsg.Text = msg;
            chartVitalSign.RefreshData();
        }
        private void btnStart_Click(object sender, EventArgs e)
        {
            mearsurementTimer.Stop();
            mearsurementTimer.Interval = (int.Parse(spnTimeInterval.EditValue.ToString())) * 1000; //(30s)
            mearsurementTimer.Start();
            UpdateChart();
            marqueeProgressBarControl1.Visible = true;
        }
        private void btnRefesh_Click(object sender, EventArgs e)
        {
            _data.Clear();
            _countTime = 0;
            UpdateChart();
        }

        private void chkViewLabelData_CheckedChanged(object sender, EventArgs e)
        {
            var chk = (BOSCheckEdit)sender;
            foreach (Series ser in chartVitalSign.Series)
            {
                ser.LabelsVisibility = chk.Checked ? DevExpress.Utils.DefaultBoolean.True : DevExpress.Utils.DefaultBoolean.False;
            }
            chartVitalSign.Refresh();
        }

        private void btnPause_Click(object sender, EventArgs e)
        {
            mearsurementTimer.Stop();
            marqueeProgressBarControl1.Visible = false;
        }
    }
}
