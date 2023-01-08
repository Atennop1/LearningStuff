using System;
using System.Linq;
using System.Text;
using LearningStuff.PostgreSQL.Core;
using Npgsql;

namespace LearningStuff.PostgreSQL
{
    public class SQLDataWriter
    {
        private readonly SQLConnector _connector;
        private readonly SQLCommandsExecutor _sqlCommandsExecutor;

        public SQLDataWriter(SQLConnector connector)
        {
            _connector = connector ?? throw new ArgumentException("Connector can't be null");
            _sqlCommandsExecutor = new SQLCommandsExecutor(_connector);
        }

        public void WriteData(string databaseName, SQLData[] sqlData)
        {
            var sqlCommand = new NpgsqlCommand();
            var finalCommandStringBuilder = new StringBuilder();
            sqlCommand.Connection = _connector.GetConnection();

            finalCommandStringBuilder.Append($"INSERT INTO {databaseName} (");
            finalCommandStringBuilder.Append(BuildParameters(sqlData.Select(data => data.Name).ToArray()));
            
            finalCommandStringBuilder.Append(" VALUES (");
            finalCommandStringBuilder.Append(BuildParameters(sqlData.Select(data => data.Value.ToString()).ToArray()));
            
            _sqlCommandsExecutor.ExecuteNonQuery(finalCommandStringBuilder.ToString());
        }

        private string BuildParameters(string[] names)
        {
            var stringBuilder = new StringBuilder();
            
            foreach (var name in names)
            {
                stringBuilder.Append(name);
                stringBuilder.Append(name != names[^1] ? ", " : ")");
            }

            return stringBuilder.ToString();
        }
    }
}