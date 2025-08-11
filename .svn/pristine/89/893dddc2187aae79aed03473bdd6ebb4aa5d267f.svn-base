using System;
using CHBase.SDK.Web;

namespace Clas.CHBase
{
    /// <summary>
    ///     Creates OfflineWebApplicationConnection to CHBase
    /// </summary>
    internal class CHBaseConnectionManager
    {
        /// <summary>
        ///     Creates Offline Web Application Connection
        /// </summary>
        /// <param name="applicationId">Application Id used for creating the offline connection</param>
        /// <param name="personId">Person Id who granted permission to perform operation</param>
        /// <returns>Returns authentication connection</returns>
        public static OfflineWebApplicationConnection CreateConnection(Guid applicationId,
            Guid personId)
        {
            OfflineWebApplicationConnection offlineConn = new OfflineWebApplicationConnection(applicationId,
                WebApplicationConfiguration.HealthServiceUrl, personId);
            offlineConn.Authenticate();
            return offlineConn;
        }

        /// <summary>
        ///     Create Offline Web Application Connection
        /// </summary>
        /// <param name="applicationId">Application ID used for creating the offline connection</param>
        /// <returns>reference to OfflineWebApplicationConnection </returns>
        public static OfflineWebApplicationConnection CreateConnection(Guid applicationId)
        {
            OfflineWebApplicationConnection conn = new OfflineWebApplicationConnection();
            conn.Authenticate();
            return conn;
        }
    }
}