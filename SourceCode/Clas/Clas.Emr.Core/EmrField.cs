/**C4585C279A88E8537C1A338EFE5484F9**/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevExpress.XtraRichEdit.API.Native;

namespace Clas.Emr.Core
{
    public class EmrField
    {
        public string CodeLevelStr { get; internal set; }
        public string[] CodeLevelArr { get; internal set; }
        public Field Field { get; internal set; }
        public string FieldCode { get; internal set; }
        public string Gid { get; internal set; }
        public string ParamNo { get; internal set; }
        public object Value { get; internal set; }
        public string StrValue { get; internal set; }
        public string[] Tokens { get; internal set; }
    }
}
