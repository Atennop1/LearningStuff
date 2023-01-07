using System;
using System.Data;
using Npgsql;

namespace LearningStuff.PostgreSQL.Core
{
    public class SQLCommandsExecutor
    {
        private readonly SQLConnector _connector;

        public SQLCommandsExecutor(SQLConnector connector)
        {
            _connector = connector ?? throw new ArgumentException("Connector can't be null");
        }

        public void ExecuteCommand(string command, SQLCommandExecutionType executionType)
        {
            var sqlCommand = new NpgsqlCommand(command, _connector.GetConnection());
            sqlCommand.CommandType = CommandType.Text;
            
            switch (executionType)
            {
                case SQLCommandExecutionType.Reader:
                    sqlCommand.ExecuteReader();
                    break;
                
                case SQLCommandExecutionType.NonQuery:
                    sqlCommand.ExecuteNonQuery();
                    break;
                
                case SQLCommandExecutionType.Scalar:
                    sqlCommand.ExecuteScalar();
                    break;
                
                case SQLCommandExecutionType.NonQueryAsync:
                    sqlCommand.ExecuteNonQueryAsync();
                    break;
                
                case SQLCommandExecutionType.ReaderAsync:
                    sqlCommand.ExecuteReaderAsync();
                    break;
                
                case SQLCommandExecutionType.ScalarAsync:
                    sqlCommand.ExecuteScalarAsync();
                    break;
            }
        }
    }
}