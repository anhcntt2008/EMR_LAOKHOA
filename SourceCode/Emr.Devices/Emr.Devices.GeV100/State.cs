/**C4585C279A88E8537C1A338EFE5484F9**/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emr.Devices.GeV100
{
    public class State
    {
        public int Systolic { get; set; }
        public int Diastolic { get; set; }
        public string BloodPrsSt { get; set; }
        public DateTime Time { get; set; }
        public string OxygenSt { get; set; }
        public int Oxygen { get; set; }
        public string HeartRateScr { get; set; }
        public int HeartRate { get; set; }
        public decimal Temperature { get; set; }
        public string TemperatureSt { get; set; }
        public string BloodPrsMsg { get; set; }
        public string OxygenMsg { get; set; }
        public string HeartRateMsg { get; set; }
        public string TemperatureMsg { get; set; }
        public string TimeStr
        {
            get { return CountTime.ToString() + ". " + Time.ToString("HH:mm"); }
        }

        public int CountTime { get; set; }
    }
}
