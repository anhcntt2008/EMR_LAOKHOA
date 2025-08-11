namespace Clas.CHBase.Model
{
    public class BloodPressureModel
    {
        public string Id { get; set; }
        public string When { get; set; }
        public string Systolic { get; set; }
        public string Diastolic { get; set; }
        public string Pulse { get; set; }
        public bool? Irregular { get; set; }

    }
}