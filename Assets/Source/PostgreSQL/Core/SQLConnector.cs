using System;
using System.Data;
using Npgsql;

namespace LearningStuff.PostgreSQL.Core
{
    public class SQLConnector
    {
        public bool IsConnectionOpen => _sqlConnection.State == ConnectionState.Open;
        
        private readonly string AuthorizationString;
        private NpgsqlConnection _sqlConnection;

        public SQLConnector(string authorizationString)
        {
            AuthorizationString = authorizationString ?? throw new ArgumentException("AuthorizationString can't be null");
        }

        public NpgsqlConnection GetConnection()
        {
            _sqlConnection = new NpgsqlConnection(AuthorizationString);

            if (!IsConnectionOpen)
                _sqlConnection.Open();

            return _sqlConnection;
        }
    }
}