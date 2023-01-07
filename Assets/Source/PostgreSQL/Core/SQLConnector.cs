using System;
using System.Data;
using Npgsql;

namespace LearningStuff.PostgreSQL.Core
{
    public class SQLConnector
    {
        private readonly string AuthorizationString;
        private NpgsqlConnection _sqlConnection;
        private bool _isConnectionOpen => _sqlConnection.State == ConnectionState.Open;

        public SQLConnector(string authorizationString)
        {
            AuthorizationString = authorizationString ?? throw new ArgumentException("AuthorizationString can't be null");
        }

        public NpgsqlConnection GetConnection()
        {
            _sqlConnection = new NpgsqlConnection(AuthorizationString);

            if (!_isConnectionOpen)
                _sqlConnection.Open();

            return _sqlConnection;
        }
    }
}