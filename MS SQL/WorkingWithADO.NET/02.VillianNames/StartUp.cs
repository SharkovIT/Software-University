using _01.InitialSetup;
using System;
using System.Data.SqlClient;

namespace _02.VillianNames
{
    public class StartUp
    {
        private const string DbName = "MinionsDB";
        static void Main(string[] args)
        {
            SqlConnection connection = new SqlConnection(String.Format(Configuration.ConnectionString, DbName));

            connection.Open();

            using (connection)
            {
                 SqlCommand sqlCommand = new SqlCommand(Queries.VillainNames, connection);

                try
                {
                     SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();

                    while (sqlDataReader.Read())
                    {
                        string villainName = (string)sqlDataReader["Name"];
                        int minionsCount = (int)sqlDataReader["MinionsCount"];

                        Console.WriteLine($"{villainName} - {minionsCount}");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Invalid operation: {ex.Message}");
                }
            }
        }
    }
}
