using System;
using System.Data;
using Npgsql;

namespace LearningStuff.PostgreSQL.Core
{
    public class SQLConnector
    {
        private readonly string _authorizationString;
        private NpgsqlConnection _sqlConnection;

        public SQLConnector(string authorizationString) 
            => _authorizationString = authorizationString ?? throw new ArgumentException("AuthorizationString can't be null");

        public NpgsqlConnection GetConnection()
        {
            _sqlConnection = new NpgsqlConnection(_authorizationString);

            if (_sqlConnection.State != ConnectionState.Open)
                _sqlConnection.Open();

            return _sqlConnection;
        }
    }
}