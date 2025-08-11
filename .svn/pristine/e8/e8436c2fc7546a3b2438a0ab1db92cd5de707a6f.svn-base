using System.Configuration;
using DevExpress.DataAccess.Sql;
using DevExpress.DataAccess.ConnectionParameters;

namespace Emr.Report
{
    public sealed class DataSource
    {
        public static SqlDataSource GetDataSource()
        {
            var dataSource = new SqlDataSource(DataSource.GetConnectionString())
            {
                Name = App.DataSourceName
            };
            return dataSource;
        }

        public static CustomStringConnectionParameters GetConnectionString()
        {
            return new CustomStringConnectionParameters(App.ConnString);
            // new CustomStringConnectionParameters(string.Format("Data Source={0};Initial Catalog={1};User ID={2};Password={3}", serverName, databaseName, userID, password));
        }
    }
}
