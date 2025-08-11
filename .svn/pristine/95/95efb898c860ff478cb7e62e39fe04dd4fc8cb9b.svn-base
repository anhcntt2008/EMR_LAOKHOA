using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emr.Pluggable.Interface
{
    public class UserFriendlyException : Exception
    {
        public const string TYPE_POPUP = "POPUP";
        public const string TYPE_LOG = "LOG";
        public const string TYPE_HIGHLIGHT = "HIGHLIGHT";
        public const string TYPE_IN_EMR_SESSION = "IN_EMR_SESSION";

        public const string TITLE_KEY = "Title";
        public const string MESSAGE_KEY = "Message";
        public const string CODE_KEY = "Code";
        public const string TYPE_KEY = "Type";
        public const string TIME_OUT = "TimeOut";


        public int Code { get; set; }
        public string Type { get; set; }
        public string Title { get; set; }
        public int TimeOut { get; set; } = 0; // Miliseconds

        public UserFriendlyException(int code, string message) : base(message)
        {
            Code = code;
        }
        public UserFriendlyException(string message) : base(message)
        {
        }

        public UserFriendlyException(string message, Exception innerException) : base(message, innerException)
        {
        }
        public UserFriendlyException(string type, string title, string message) : base(message)
        {
            Type = type;
            Title = title;
        }
        public UserFriendlyException(string type, string title, string message, Exception innerException) : base(message, innerException)
        {
            Type = type;
            Title = title;
        }
        public UserFriendlyException(string type, string title, string message, int timeOut) : base(message)
        {
            Type = type;
            Title = title;
            TimeOut = timeOut;
        }
        public UserFriendlyException(string type, string title, string message, int timeOut, Exception innerException) : base(message, innerException)
        {
            Type = type;
            Title = title;
            TimeOut = timeOut;
        }
    }
}
