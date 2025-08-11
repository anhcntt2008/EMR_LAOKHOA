using System;
using System.Collections.Generic;
using System.Text;
using Clas.Model.Base;
using Clas.Model.Utils;

namespace Clas.Model.Doctor24x7
{
    public class Schedule
    {
        public string id { get; set; }
        public long startTime { get; set; }
        public long endTime { get; set; }
        public Doctor doctor { get; set; }
        public Hospital hospital { get; set; }

        public DateTime StartTimeLocal
        {
            get
            {
                return startTime.ToLocalTime();
            }
        }
        public DateTime EndTimeLocal
        {
            get
            {
                return endTime.ToLocalTime();
            }
        }

        public string HospitalName
        {
            get
            {
                return hospital.name;
            }

        }

        public string HospitalAddress
        {
            get
            {
                return hospital.address;
            }

        }

        public string ScheduleText
        {
            get
            {
                return StartTimeLocal + " - " + EndTimeLocal + "(" + HospitalName + ")";
            }
        }
    }
    public class ScheduleHttpResult : HttpResult
    {
        public ScheduleResultModel data { get; set; }
    }
    public class ScheduleResultModel
    {
        public int total { get; set; }
        public Schedule[] schedules { get; set; }
    }
}
