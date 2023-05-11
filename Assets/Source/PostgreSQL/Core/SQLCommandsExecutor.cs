﻿using System;
using System.Threading.Tasks;
using Npgsql;

namespace LearningStuff.PostgreSQL.Core
{
    public sealed class SQLCommandsExecutor
    {
        private readonly SQLConnector _connector;

        public SQLCommandsExecutor(SQLConnector connector) 
            => _connector = connector ?? throw new ArgumentException("Connector can't be null");

        public NpgsqlDataReader ExecuteReader(string commandText)
        {
            var command = new NpgsqlCommand(commandText, _connector.GetConnection());
            return command.ExecuteReader();
        }

        public int ExecuteNonQuery(string commandText)
        {
            var command = new NpgsqlCommand(commandText, _connector.GetConnection());
            return command.ExecuteNonQuery();
        }

        public object ExecuteScalar(string commandText)
        {
            var command = new NpgsqlCommand(commandText, _connector.GetConnection());
            return command.ExecuteScalar();
        }
        
        public Task<NpgsqlDataReader> ExecuteReaderAsync(string commandText)
        {
            var command = new NpgsqlCommand(commandText, _connector.GetConnection());
            return Task.FromResult(command.ExecuteReader());
        }
        
        public Task<int> ExecuteNonQueryAsync(string commandText)
        {
            var command = new NpgsqlCommand(commandText, _connector.GetConnection());
            return Task.FromResult(command.ExecuteNonQuery());
        }

        public Task<object> ExecuteScalarAsync(string commandText)
        {
            var command = new NpgsqlCommand(commandText, _connector.GetConnection());
            return Task.FromResult(command.ExecuteScalar());
        }
    }
}