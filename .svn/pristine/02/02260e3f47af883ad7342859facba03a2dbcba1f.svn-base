using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;

namespace BOSERP
{
    public class RegisterHelper
    {
        public RegisterHelper() { }
        public RegisterHelper(DataExchangeServiceClient client)
        {
            string userName = ConfigurationSettings.AppSettings["Username"];
            string password = ConfigurationSettings.AppSettings["Password"];
            client.ClientCredentials.Windows.ClientCredential.UserName = userName;
            client.ClientCredentials.Windows.ClientCredential.Password = password;
        }
    
    }
}
