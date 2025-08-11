
using System;
using System.Text;
using System.Runtime.InteropServices;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using Clas.Emr.Ipc.Native;

namespace Clas.Emr.Ipc.Net.Messaging
{
    /// <summary>
    /// The data struct that is passed between AppDomain boundaries. This is
    /// sent as a delimited string containing the channel and message.
    /// </summary>
    public struct DataGram
    {
        /// <summary>
        /// Stores the channel name associated with this message.
        /// </summary>
        private string channel;
        /// <summary>
        /// Stores the string message.
        /// </summary>
        private string message;
        private string dataType;
        /// <summary>
        /// The native data struct used to pass the data between applications. This
        /// contains a pointer to the data packet.
        /// </summary>
        private Win32.COPYDATASTRUCT dataStruct;
        /// <summary>
        /// Gets the channel name.
        /// </summary>
        public string Channel
        {
            get
            {
                return this.channel;
            }
        }
        /// <summary>
        /// Gets the message.
        /// </summary>
        public string Message
        {
            get
            {
                return this.message;
            }
        }
        /// <summary>
        /// data type
        /// </summary>
        public string DataType
        {
            get
            {
                return this.dataType;
            }
        }
        /// <summary>
        /// Constructor which creates the data gram from a message and channel name.
        /// </summary>
        /// <param name="channel">The channel through which the message will be sent.</param>
        /// <param name="message">The string message to send.</param>
        public DataGram(string channel, string message, string dataType)
        {
            this.dataStruct = new Win32.COPYDATASTRUCT();
            this.channel = channel;
            this.message = message;
            this.dataType = dataType;
        }
        /// <summary>
        /// Constructor creates an instance of the class from a pointer address, and expands
        /// the data packet into the originating channel name and message.
        /// </summary>
        /// <param name="lpParam">A pointer the a COPYDATASTRUCT containing information required to 
        /// expand the DataGram.</param>
        private DataGram(IntPtr lpParam)
        {
            this.dataStruct = (Win32.COPYDATASTRUCT)Marshal.PtrToStructure(lpParam, typeof(Win32.COPYDATASTRUCT));
            byte[] bytes = new byte[this.dataStruct.cbData];
            Marshal.Copy(this.dataStruct.lpData, bytes, 0, this.dataStruct.cbData);
            MemoryStream stream = new MemoryStream(bytes);
            BinaryFormatter b = new BinaryFormatter();
            string rawmessage = (string)b.Deserialize(stream);

            // expand data gram
            if (!string.IsNullOrEmpty(rawmessage) && rawmessage.Contains("§"))
            {
                string[] packet = rawmessage.Split(new char[] { '§' }, 3);
                this.channel = packet[0];
                this.message = packet[1];
                this.dataType = packet[2];
            }
            else
            {
                this.channel = string.Empty;
                this.message = rawmessage;
                this.dataType = "unknow";
            }
        }
        /// <summary>
        /// Pushes the DatGram's data into memory and returns a COPYDATASTRUCT instance with
        /// a pointer to the data so it can be sent in a Windows Message and read by another application.
        /// </summary>
        /// <returns>A struct containing the pointer to this DataGram's data.</returns>
        internal Win32.COPYDATASTRUCT ToStruct()
        {
            string raw = string.Format("{0}§{1}§{2}", channel, message, dataType);

            // serialize data into stream
            BinaryFormatter b = new BinaryFormatter();
            MemoryStream stream = new MemoryStream();
            b.Serialize(stream, raw);
            stream.Flush();
            int dataSize = (int)stream.Length;

            // create byte array and get pointer to mem location
            byte[] bytes = new byte[dataSize];
            stream.Seek(0, SeekOrigin.Begin);
            stream.Read(bytes, 0, dataSize);
            stream.Close();
            IntPtr ptrData = Marshal.AllocCoTaskMem(dataSize);
            Marshal.Copy(bytes, 0, ptrData, dataSize);

            this.dataStruct.cbData = dataSize;
            this.dataStruct.dwData = IntPtr.Zero;
            this.dataStruct.lpData = ptrData;

            return this.dataStruct;
        }
        /// <summary>
        /// Creates an instance of a DataGram struct from a pointer to a COPYDATASTRUCT
        /// object containing the address of the data.
        /// </summary>
        /// <param name="lpParam">A pointer to a COPYDATASTRUCT object from which the DataGram data
        /// can be derived.</param>
        /// <returns>A DataGram instance containing a message, and the channel through which
        /// it was sent.</returns>
        internal static DataGram FromPointer(IntPtr lpParam)
        {
            return new DataGram(lpParam);
        }
        /// <summary>
        /// Disposes of the unmanaged memory stored by the COPYDATASTRUCT instance
        /// when data is passed between applications.
        /// </summary>
        public void Dispose()
        {
            if (this.dataStruct.lpData != IntPtr.Zero)
            {
                Marshal.FreeCoTaskMem(this.dataStruct.lpData);
                this.dataStruct.lpData = IntPtr.Zero;
                this.dataStruct.dwData = IntPtr.Zero;
                this.dataStruct.cbData = 0;
            }
        }
    }
}
