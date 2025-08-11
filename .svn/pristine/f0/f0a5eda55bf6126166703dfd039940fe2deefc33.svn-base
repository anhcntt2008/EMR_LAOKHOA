
using System;
using Clas.Emr.Ipc.Utils;
using Clas.Emr.Ipc.Native;

namespace Clas.Emr.Ipc.Net.Messaging
{
    /// <summary>
    /// UtHV
    /// 27/10/2017
    /// Customized from https://www.codeproject.com/articles/17606/WebControls/?fid=385377&df=90&mpp=25&sort=Position&view=Normal&spc=Relaxed&fr=26
    /// By Author TheCodeKing
    /// Class used to broadcast messages to other applications listening
    /// on a particular channel.
    /// </summary>
    public static class IpcBroadcast
    {
        /// <summary>
        /// The API used to broadcast messages to a channel, and other applications that
        /// may be listening.
        /// </summary>
        /// <param name="channel">The channel name to broadcast on.</param>
        /// <param name="message">The string message data.</param>
        public static void SendToChannel(string channel, string message, string dataType)
        {
            // create a DataGram instance
            DataGram dataGram = new DataGram(channel, message, dataType);
            // Allocate the DataGram to a memory address contained in COPYDATASTRUCT
            Win32.COPYDATASTRUCT dataStruct = dataGram.ToStruct();
            // Use a filter with the EnumWindows class to get a list of windows containing
            // a property name that matches the destination channel. These are the listening
            // applications.
            WindowEnumFilter filter = new WindowEnumFilter(IpcListener.GetChannelKey(channel));
            WindowsEnum winEnum = new WindowsEnum(filter.WindowFilterHandler);
            foreach (IntPtr hWnd in winEnum.Enumerate(Win32.GetDesktopWindow()))
            {
                IntPtr outPtr = IntPtr.Zero;
                // For each listening window, send the message data. Return if hang or unresponsive within 1 sec.
                Win32.SendMessageTimeout(hWnd, Win32.WM_COPYDATA, (int)IntPtr.Zero, ref dataStruct, Win32.SendMessageTimeoutFlags.SMTO_ABORTIFHUNG, 1000, out outPtr);
            }
            // free the memory
            dataGram.Dispose();
        }
    }
}
