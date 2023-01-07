using System;
using System.Data;
using LearningStuff.PostgreSQL.Core;
using Npgsql;

namespace LearningStuff.PostgreSQL
{
    public class SQLDataReader
    {
        private readonly SQLConnector _connector;
        private readonly SQLCommandsExecutor _sqlCommandsExecutor;

        public SQLDataReader(SQLConnector connector)
        {
            _connector = connector ?? throw new ArgumentException("Connector can't be null");
            _sqlCommandsExecutor = new SQLCommandsExecutor(_connector);
        }

        public DataTable GetData(string sqlRequest)
        {
            var sqlCommand = new NpgsqlCommand();
            sqlCommand.Connection = _connector.GetConnection();

            var dataReader = _sqlCommandsExecutor.ExecuteReader(sqlRequest);
            var dataTable = new DataTable();
            
            dataTable.Load(dataReader);
            return dataTable;
        }
    }
}