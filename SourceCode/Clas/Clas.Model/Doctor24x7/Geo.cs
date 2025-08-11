using System;
using System.Collections.Generic;
using System.Text;

namespace Clas.Model.Doctor24x7
{
    public class Geo
    {
    }
    public class City
    {
        public string id { get; set; }
        public string name { get; set; }
        public bool isUsedForDoctorSearch { get; set; }
        public object districts { get; set; }
    }

    public class District
    {
        public string id { get; set; }
        public string cityId { get; set; }
        public string name { get; set; }
        public object location { get; set; }
    }
}
