using Clas.Model.Base;

namespace Clas.Model.Doctor24x7
{
    public class SyncDataModel
    {
        public PatientBacSi24x7[] patients { get; set; }
        public Doctor[] doctors { get; set; }

        public CheckupType[] checkupTypes { get; set; }
    }

    public class ResultSyncDataModel : HttpResult
    {
        public SyncDataModel data { get; set; }
    }
}