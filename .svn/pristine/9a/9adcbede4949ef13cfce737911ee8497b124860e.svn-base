using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Emr.Base.Models.Abp
{
    /// <summary>
    /// This exception type is directly shown to the user.
    /// To map to UserFriendlyException
    /// </summary>
    [Serializable]
    public class UserFriendlyException : AbpException
    {
        /// <summary>
        /// Additional information about the exception.
        /// </summary>
        public string Details { get; private set; }

        /// <summary>
        /// An arbitrary error code.
        /// </summary>
        public int Code { get; set; }

        /// <summary>
        /// Severity of the exception.
        /// Default: Warn.
        /// </summary>
        public LogSeverity Severity { get; set; }

        /// <summary>
        /// Constructor.
        /// </summary>
        public UserFriendlyException()
        {
            Severity = LogSeverity.Warn;
        }

        /// <summary>
        /// Constructor for serializing.
        /// </summary>
        public UserFriendlyException(SerializationInfo serializationInfo, StreamingContext context)
            : base(serializationInfo, context)
        {

        }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="message">Exception message</param>
        public UserFriendlyException(string message)
            : base(message)
        {
            Severity = LogSeverity.Warn;
        }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="message">Exception message</param>
        /// <param name="severity">Exception severity</param>
        public UserFriendlyException(string message, LogSeverity severity)
            : base(message)
        {
            Severity = severity;
        }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="code">Error code</param>
        /// <param name="message">Exception message</param>
        public UserFriendlyException(int code, string message)
            : this(message)
        {
            Code = code;
        }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="message">Exception message</param>
        /// <param name="details">Additional information about the exception</param>
        public UserFriendlyException(string message, string details)
            : this(message)
        {
            Details = details;
        }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="code">Error code</param>
        /// <param name="message">Exception message</param>
        /// <param name="details">Additional information about the exception</param>
        public UserFriendlyException(int code, string message, string details)
            : this(message, details)
        {
            Code = code;
        }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="message">Exception message</param>
        /// <param name="innerException">Inner exception</param>
        public UserFriendlyException(string message, Exception innerException)
            : base(message, innerException)
        {
            Severity = LogSeverity.Warn;
        }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="message">Exception message</param>
        /// <param name="details">Additional information about the exception</param>
        /// <param name="innerException">Inner exception</param>
        public UserFriendlyException(string message, string details, Exception innerException)
            : this(message, innerException)
        {
            Details = details;
        }
    }

    /// <summary>
    /// Base exception type for those are thrown by Abp system for Abp specific exceptions.
    /// </summary>
    [Serializable]
    public class AbpException : Exception
    {
        /// <summary>
        /// Creates a new <see cref="AbpException"/> object.
        /// </summary>
        public AbpException()
        {

        }

        /// <summary>
        /// Creates a new <see cref="AbpException"/> object.
        /// </summary>
        public AbpException(SerializationInfo serializationInfo, StreamingContext context)
            : base(serializationInfo, context)
        {

        }

        /// <summary>
        /// Creates a new <see cref="AbpException"/> object.
        /// </summary>
        /// <param name="message">Exception message</param>
        public AbpException(string message)
            : base(message)
        {

        }

        /// <summary>
        /// Creates a new <see cref="AbpException"/> object.
        /// </summary>
        /// <param name="message">Exception message</param>
        /// <param name="innerException">Inner exception</param>
        public AbpException(string message, Exception innerException)
            : base(message, innerException)
        {

        }
    }

    //
    // Summary:
    //     Indicates severity for log.
    public enum LogSeverity
    {
        //
        // Summary:
        //     Debug.
        Debug = 0,
        //
        // Summary:
        //     Info.
        Info = 1,
        //
        // Summary:
        //     Warn.
        Warn = 2,
        //
        // Summary:
        //     Error.
        Error = 3,
        //
        // Summary:
        //     Fatal.
        Fatal = 4
    }
}
