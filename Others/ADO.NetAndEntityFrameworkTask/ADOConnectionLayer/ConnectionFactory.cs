using System;
using System.Configuration;
using System.Data;
using System.Data.Common;

namespace ADOConnectionLayer
{
    public class ConnectionFactory : IConnectionFactory
    {
        private readonly string _connectionString;
        private readonly DbProviderFactory _dbProviderFactory;
        private readonly string _name;

        public ConnectionFactory(string connectionName)
        {
            if(connectionName == null)
            {
                throw new ArgumentNullException(nameof(connectionName));
            }
            var connection = ConfigurationManager.ConnectionStrings["SchoolEntitiesContext"];
            if(connection == null)
            {
                throw new ConfigurationErrorsException($"Failed to find connection string named '" +
                                                       $"{connectionName}' in app/web.config.");
            }
            _name = connection.ProviderName;
            _dbProviderFactory = DbProviderFactories.GetFactory(_name);
            _connectionString = connection.ConnectionString;
        }

        public IDbConnection Create()
        {
            IDbConnection connection = _dbProviderFactory.CreateConnection();
            if(connection == null)
            {
                throw new ConfigurationErrorsException($"Failed to create a connection using the connection " +
                                                       $"string named '{_name}' in app/web.config.");
            }
            connection.ConnectionString = _connectionString;
            connection.Open();
            return connection;
        }
    }
}