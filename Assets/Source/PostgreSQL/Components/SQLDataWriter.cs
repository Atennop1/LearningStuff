using System;
using System.Linq;
using System.Text;
using LearningStuff.PostgreSQL.Core;

namespace LearningStuff.PostgreSQL.Components
{
    public class SQLDataWriter
    {
        private readonly SQLCommandsExecutor _sqlCommandsExecutor;
        private readonly SQLParametersStringBuilder _sqlParametersStringBuilder;

        public SQLDataWriter(SQLCommandsExecutor sqlCommandsExecutor, SQLParametersStringBuilder sqlParametersStringBuilder)
        {
            _sqlParametersStringBuilder = sqlParametersStringBuilder ?? throw new ArgumentNullException(nameof(sqlParametersStringBuilder));
            _sqlCommandsExecutor = sqlCommandsExecutor ?? throw new ArgumentNullException(nameof(sqlCommandsExecutor));
        }

        public void WriteData(string databaseName, SQLData[] sqlData)
        {
            var finalCommandStringBuilder = new StringBuilder();

            finalCommandStringBuilder.Append($"INSERT INTO {databaseName} (");
            finalCommandStringBuilder.Append(_sqlParametersStringBuilder.BuildParameters(sqlData.Select(data => data.Name).ToArray(), ", "));
            finalCommandStringBuilder.Append(")");
            
            finalCommandStringBuilder.Append(" VALUES (");
            finalCommandStringBuilder.Append(_sqlParametersStringBuilder
                .BuildParameters(sqlData.Select(data => data.Value is int or float ? data.Value.ToString() : $"'{data.Value}'").ToArray(), ", "));
            
            finalCommandStringBuilder.Append(")");
            _sqlCommandsExecutor.ExecuteNonQuery(finalCommandStringBuilder.ToString());
        }
    }
}