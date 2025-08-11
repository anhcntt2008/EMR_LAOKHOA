using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emr.Pluggable.Interface
{
    public interface IPluginBase
    {
        string Name { get; }
        string Version { get; }
    }
}
