using System;
using System.Linq;
using System.Text;
using LearningStuff.PostgreSQL.Core;

namespace LearningStuff.PostgreSQL.Components
{
    public sealed class SQLDataDeleter
    {
        private readonly SQLCommandsExecutor _sqlCommandsExecutor;
        private readonly SQLParametersStringBuilder _sqlParametersStringBuilder;

        public SQLDataDeleter(SQLCommandsExecutor sqlCommandsExecutor, SQLParametersStringBuilder sqlParametersStringBuilder)
        {
            _sqlParametersStringBuilder = sqlParametersStringBuilder ?? throw new ArgumentNullException(nameof(sqlParametersStringBuilder));
            _sqlCommandsExecutor = sqlCommandsExecutor ?? throw new ArgumentNullException(nameof(sqlCommandsExecutor));
        }

        public void DeleteData(string databaseName, SQLArgument[] sqlData)
        {
            var finalCommandStringBuilder = new StringBuilder();
            finalCommandStringBuilder.Append($"DELETE FROM {databaseName} WHERE ");

            finalCommandStringBuilder.Append(_sqlParametersStringBuilder.BuildParameters(sqlData.Select(data => $"{data.Name} = {data.Value}").ToArray(), " AND "));
            _sqlCommandsExecutor.ExecuteNonQuery(finalCommandStringBuilder.ToString());
        }
    }
}