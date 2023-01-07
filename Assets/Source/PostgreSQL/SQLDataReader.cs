using System;
using System.Data;
using LearningStuff.PostgreSQL.Core;
using Npgsql;

namespace LearningStuff.PostgreSQL
{
    public class SQLDataReader
    {
        private readonly SQLConnector _connector;

        public SQLDataReader(SQLConnector connector)
        {
            _connector = connector ?? throw new ArgumentException("Connector can't be null");
        }

        public DataTable GetData(string sqlRequest)
        {
            var sqlCommand = new NpgsqlCommand();
            sqlCommand.Connection = _connector.GetConnection();
            sqlCommand.CommandText = sqlRequest;

            var dataReader = sqlCommand.ExecuteReader();
            var dataTable = new DataTable();
            
            dataTable.Load(dataReader);
            return dataTable;
        }
    }
}