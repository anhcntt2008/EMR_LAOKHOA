using System;
using System.Collections.Generic;
using System.Text;

namespace BOSERP.Utilities
{
    public class ChangeSize
    {
        /// <summary>
        /// Convert bytes to Megabytes
        /// </summary>
        /// <param name="bytes">value of size</param>
        /// <returns></returns>
        public double ConvertBytesToMegabytes(long bytes)
        {
            return (bytes / 1024) / 1024;
        }

        /// <summary>
        /// Convert Bytes to KiloBytes
        /// </summary>
        /// <param name="bytes">value of size</param>
        /// <returns></returns>
        public double ConvertBytesToKiloBytes(long bytes)
        {
            return bytes / 1024;
        }
    }
}
