using System;
using System.Data;
using LearningStuff.PostgreSQL.Core;

namespace LearningStuff.PostgreSQL.Components
{
    public sealed class SQLDataReader
    {
        private readonly SQLCommandsExecutor _sqlCommandsExecutor;

        public SQLDataReader(SQLCommandsExecutor sqlCommandsExecutor) 
            => _sqlCommandsExecutor = sqlCommandsExecutor ?? throw new ArgumentNullException(nameof(sqlCommandsExecutor));

        public DataTable GetData(string sqlRequest)
        {
            if (sqlRequest == null)
                throw new ArgumentNullException(nameof(sqlRequest));
            
            var dataReader = _sqlCommandsExecutor.ExecuteReader(sqlRequest);
            var dataTable = new DataTable();
            
            dataTable.Load(dataReader);
            return dataTable;
        }
    }
}