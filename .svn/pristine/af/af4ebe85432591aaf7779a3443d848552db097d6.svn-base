using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emr.Devices.GeV100
{
    class Program
    {  
        static void Main(string[] args)
        {
            var conn = new GeV100SerialConn("COM3");
            conn.GetStateAsync();
            Console.ReadKey();
        }
    }
}
