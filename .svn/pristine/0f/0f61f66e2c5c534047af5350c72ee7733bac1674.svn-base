/**C4585C279A88E8537C1A338EFE5484F9**/
using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Emr.Devices.GeV100
{
    public class GeV100SerialConn
    {
        private string _numberDecimalSeparator;
        private SerialPort sp;
        private State _state;
        private int _timeout;

        public bool IsOpen { get { return sp.IsOpen; } }

        public GeV100SerialConn(string comPort = "COM3", int timeout = 3000)
        {
            _numberDecimalSeparator = Thread.CurrentThread.CurrentCulture.NumberFormat.NumberDecimalSeparator;
            sp = new SerialPort(comPort);
            sp.BaudRate = 9600;
            sp.Parity = Parity.None;
            sp.StopBits = StopBits.One;
            sp.DataBits = 8;
            sp.ReadBufferSize = 1400;
            sp.Handshake = Handshake.None;
            //sp.DataReceived += new SerialDataReceivedEventHandler(DataReceivedHandler);
            sp.ErrorReceived += new SerialErrorReceivedEventHandler(ErrorReceivedEventHandler);
            sp.ReadTimeout = 3000;
            _timeout = timeout;
        }
        public static async Task<string> ComPortDetectAsync()
        {
            for (int i = 0; i < 11; i++)
            {
                var com = "COM" + i;
                var port = new GeV100SerialConn(com, 1000);
                try
                {
                    port.Open();
                    port.Request(" NA!2");
                    var response = await port.ReadAsync();
                    if (response.StartsWith(" NA")) return com;
                }
                catch (Exception)
                {
                }
            }
            return string.Empty;
        }
        private void ErrorReceivedEventHandler(object sender, SerialErrorReceivedEventArgs e)
        {
            throw new Exception("Serial Error: " + e.EventType.ToString());
        }

        private void DataReceivedHandler(object sender, SerialDataReceivedEventArgs e)
        {
            //var sp = (SerialPort)sender;
            //string inData = sp.ReadTo("\r");
        }

        private void Temperature(string inData)
        {
            /*Response: “uTCabcdddddeeeef”
                “a” Status
                    “0” - Last determination OK/predictive temperature idle [HC_028a]
                    “1” - Determination in progress [HC_028b]
                    “2” - Determination timeout [HC_028c]
                    “3” - Loss of tissue contact, temp out of range high (probe too hot), or temp out of range low , or ProSeries only) probe broken [HC_028d]
                    “4” - Determination abort, probe unplugged, bad probe or ( ProCare Only) probe broken[HC_028e]
                “b” Mode
                    “0” - Normal (predictive) mode [HC_028f]
                    “1” - Monitor mode [HC_028g]
                “c” New determination counter. This field contains an ASCII character from ‘ ‘ (blank) to ‘~’ (tilde). The
                ASCII code of the character is incremented each time a determination is started. It “wraps around” from
                tilde to blank. The starting value is unspecified
                [HC_028h] 
                “ddddd” Time (in seconds) since last determination. If the determination is older than 99990 seconds or the
                temperature is not available, then this field contains  “99999” [HC_028I].

                “eeee” Temperature (in tenth degrees F) [HC_028j]
                “f” Temperature units used for the bedside display
                    “0” - Degrees F [HC_028k]
                    “1” - Degrees C [HC_028l]
             */
            var status = inData.Substring(3, 1);
            _state.TemperatureSt = status;
            if (status != "0")
            {
                _state.Temperature = 0;
                _state.TemperatureMsg = "Đo nhiệt độ: ";
                switch (status)
                {
                    case "1":
                        _state.TemperatureMsg += "Không tìm thấy thiết bị đo"; break;
                    case "2":
                        _state.TemperatureMsg += "Đo quá thời gian"; break;
                    case "3":
                        _state.TemperatureMsg += "Loss of tissue contact, temp out of range high (probe too hot), or temp out of range low"; break;
                    case "4":
                        _state.TemperatureMsg += "Bị ngắt ngang trong quá trình đo"; break;
                    default:
                        break;
                }
                return;
            }
            var unit = inData.Substring(15, 1);
            var value = decimal.Parse(inData.Substring(11, 4).Insert(3, _numberDecimalSeparator));
            if (unit == "1")
                _state.Temperature = (value - 32) * 5 / 9;
            else
                _state.Temperature = value;
        }

        private void ParseHeartRate(string inData)
        {
            /*
             Response: “uRAabbb”
                “a” Heart/pulse rate source
                    “2” - Pulse oximeter [HC_023a]
                    “3” - Non-invasive blood pressure [HC_023b]
                “bbb” Heart/pulse rate [HC_023c] */
            var source = inData.Substring(3, 1);
            _state.HeartRateScr = source == "2" ? "PULSE_OXIMETER" : "BLOOD_PRESSURE";
            var str = inData.Substring(4, 3);
            _state.HeartRate = int.Parse(str);
            if (_state.HeartRate == 0 || _state.HeartRate == -99)
            {
                _state.HeartRate = 0;
                _state.HeartRateMsg = "Đo nhịp tim: Không có dữ liệu";
            }
        }

        private void ParsePulseOximeter(string inData)
        {
            /* Response: “uOAabbbcdd”
                 “a” Channel status
                    “0” -Standby mode[HC_020a]
                    “1” – Operate mode OK[HC_020b]
                    “3” -No data(for Procare includes sensor off)[HC_020c]
                    “6” -Sensor unplugged(for ProSeries includes sensor off) [HC_020d]
                 “bbb” Oxygen saturation[HC_020e]
                 “c” Signal strength('0' to '9') [HC_020f]
                 “dd” Averaging interval[HC_020g]*/
            var status = inData.Substring(3, 1);
            _state.OxygenSt = status;
            if (status != "1")
            {
                _state.Oxygen = 0;
                _state.OxygenMsg = "Đo nồng độ Oxy máu: ";
                switch (status)
                {
                    case "0":
                        _state.OxygenMsg += "Đang chế độ nghỉ"; break;
                    case "3":
                        _state.OxygenMsg += "Không có dữ liệu"; break;
                    case "6":
                        _state.OxygenMsg += "Cảm biến bị tháo"; break;
                    default:
                        break;
                }
                return;
            }
            var str = inData.Substring(4, 3);
            _state.Oxygen = int.Parse(str);
        }

        private void ParseBloodPressure(string inData)
        {
            /*Command: “uNA” Read non-invasive blood pressure status
            Response: “uNAabcddddeeefffggg”
            “a” Determination status
                “0” – Busy[HC_009a]
                “1” -Done OK[HC_009b]
                “2” -Not used
                “3” -Determination failed[HC_009c]
                “4” -Pumpup timeout[HC_009d]
                “6” -Total time timeout[HC_009e]
                “7” -One - pressure timeout[HC_009f]
                “8” -Overpressure or Excess air in cuff[HC_009g]
                “9” -Unknown NIBP status
            “b” Adult / neonate status
                “0” -Unknown[HC_009h]
                “1” -Adult[HC_009I]
                “2” -Neonate[HC_009j]
            “c” Determination type
                “0” -Normal mode[HC_009k]
                “1” -Stat mode[HC_009l]
            “dddd” Time since last determination of systolic diastolic and mean arterial pressure(in seconds, 0 - 5400)[HC_009m]
            “eee” Systolic pressure
            “fff” Diastolic pressure
            “ggg” Mean arterial pressure[HC_009n]*/
            var status = inData.Substring(3, 1);
            _state.BloodPrsSt = status;
            if (status != "1")
            {
                _state.Systolic = 0;
                _state.Diastolic = 0;
                _state.BloodPrsMsg = "Đo huyết áp: ";
                switch (status)
                {
                    case "0":
                        _state.BloodPrsMsg += "Đang bận"; break;
                    case "2":
                        _state.BloodPrsMsg += "Không sử dụng"; break;
                    case "3":
                        _state.BloodPrsMsg += "Có lỗi khi đo"; break;
                    case "4":
                        _state.BloodPrsMsg += "Bơm quá lâu"; break;
                    case "6":
                        _state.BloodPrsMsg += "Đo quá lâu"; break;
                    case "7":
                        _state.BloodPrsMsg += "Một chỉ số đo quá thời gian"; break;
                    case "8":
                        _state.BloodPrsMsg += "Thủng hay thoát khí"; break;
                    case "9":
                        _state.BloodPrsMsg += "Lỗi không xác định"; break;
                    default:
                        break;
                }
                return;
            }
            if (inData.Substring(6, 4) == "9999")
            {
                _state.BloodPrsMsg += "Đo huyết áp: Không có dữ liệu đo gần đây";
                return;
            }
            _state.Systolic = int.Parse(inData.Substring(10, 3));
            _state.Diastolic = int.Parse(inData.Substring(13, 3));
        }

        public void Open()
        {
            if (!sp.IsOpen) sp.Open();
        }
        public void Close()
        {
            if (sp.IsOpen) sp.Close();
        }
        private void ParseData(string inData)
        {
            if (inData.Length < 2) return;
            var param = inData.Substring(0, 3);
            switch (param)
            {
                case " NA": //1. Non-invasive blood pressure
                    ParseBloodPressure(inData);
                    break;
                case " OA": //2. Pulse oximeter
                    ParsePulseOximeter(inData);
                    break;
                case " RA": //3. Heart or pulse rate
                    ParseHeartRate(inData);
                    break;
                case " TC": //4. Temperature
                    Temperature(inData);
                    break;
                default:
                    break;
            }
        }
        public void Request(string msg)
        {
            //await sp.BaseStream.WriteAsync(bytes, 0, bytes.Length);
            var str = msg.ToCharArray().ToList();
            str.Insert(0, (char)13);
            str.Add((char)13);
            sp.Write(str.ToArray(), 0, str.Count);
        }
        private async Task<string> ReadToEndAsync()
        {
            var buffer = new byte[1];
            string result = string.Empty;

            while (true)
            {
                await sp.BaseStream.ReadAsync(buffer, 0, 1);
                result += sp.Encoding.GetString(buffer);
                if (buffer[0] == 13)
                {
                    return result;
                }
            }
        }
        public async Task<string> ReadAsync()
        {
            var task = ReadToEndAsync();
            if (await Task.WhenAny(task, Task.Delay(_timeout)) == task)
            {
                return task.Result;
            }
            else
            {
                return string.Empty;
            }
        }
        public async Task<State> GetStateAsync()
        {
            _state = new State();
            _state.Time = DateTime.Now;
            if (!sp.IsOpen) sp.Open();
            Request(" NA!2");//1. Non-invasive blood pressure
            ParseData(await ReadAsync());
            Request(" OA!3");//2. Pulse oximeter
            ParseData(await ReadAsync());
            Request(" RA!6");//3. Heart or pulse rate
            ParseData(await ReadAsync());
            Request(" TC!:");//4. Temperature
            ParseData(await ReadAsync());
            return _state;
        }
        public async Task<string> WriteCommandAndReadResult(string cmd)
        {
            if (!sp.IsOpen) sp.Open();
            Request(cmd);
            return await ReadAsync();
        }
        public void WriteCommand(string cmd)
        {
            if (!sp.IsOpen) sp.Open();
            Request(cmd);
        }
    }
}
