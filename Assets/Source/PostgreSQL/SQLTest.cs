using LearningStuff.PostgreSQL.Core;
using UnityEngine;

namespace LearningStuff.PostgreSQL
{
    public class SQLTest : MonoBehaviour
    {
        private void Awake()
        {
            var sqlConnector = new SQLConnector(@"Server=localhost;Port=5434;User Id=postgres;Password=igay123Aa;Database=TestDB");
            var sqlDataReader = new SQLDataReader(sqlConnector);

            var data = sqlDataReader.GetData("select * from humans");
            Debug.Log($"Age: {data.Rows[0]["age"]}\nFirst Name: {data.Rows[0]["first_name"]}\nLast Name: {data.Rows[0]["last_name"]}");
        }
    }
}
