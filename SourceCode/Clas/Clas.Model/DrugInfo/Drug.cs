using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Clas.Model.DrugInfo
{
    public class Drug
    {
        public string drug_id { get; set; }
        public float quantity { get; set; }
        public float days { get; set; }
        public float morning { get; set; }
        public float lunch { get; set; }
        public float afternoon { get; set; }
        public float evening { get; set; }
    }
}
