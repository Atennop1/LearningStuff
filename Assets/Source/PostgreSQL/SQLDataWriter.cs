using System;
using System.Data;
using System.Linq;
using System.Text;
using LearningStuff.PostgreSQL.Core;
using Npgsql;

namespace LearningStuff.PostgreSQL
{
    public class SQLDataWriter
    {
        private readonly SQLConnector _connector;

        public SQLDataWriter(SQLConnector connector)
        {
            _connector = connector ?? throw new ArgumentException("Connector can't be null");
        }

        public void WriteData(string databaseName, SQLData[] sqlData)
        {
            var sqlCommand = new NpgsqlCommand();
            sqlCommand.Connection = _connector.GetConnection();
            sqlCommand.CommandType = CommandType.Text;

            var finalCommandStringBuilder = new StringBuilder();
            var sqlDataNames = sqlData.Select(data => data.Name).ToArray();
            
            finalCommandStringBuilder.Append($"INSERT TO {databaseName} (");
            finalCommandStringBuilder.Append(BuildParameters(sqlDataNames, ""));
            
            finalCommandStringBuilder.Append("VALUES (");
            finalCommandStringBuilder.Append(BuildParameters(sqlDataNames, "@"));

            sqlCommand.CommandText = finalCommandStringBuilder.ToString();

            foreach (var data in sqlData)
                sqlCommand.Parameters.AddWithValue(data.Name, data.Value);

            sqlCommand.ExecuteNonQuery();
        }

        private string BuildParameters(string[] sqlDataNames, string prefix)
        {
            var stringBuilder = new StringBuilder();
            
            foreach (var name in sqlDataNames)
            {
                stringBuilder.Append($"{prefix}{name}");
                stringBuilder.Append(name != sqlDataNames[^1] ? ", " : ")");
            }

            return stringBuilder.ToString();
        }
    }
}