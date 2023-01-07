namespace LearningStuff.PostgreSQL.Core
{
    public enum SQLCommandExecutionType
    {
        NonQuery,
        Reader,
        Scalar,
        NonQueryAsync,
        ReaderAsync,
        ScalarAsync
    }
}