using _01.InitialSetup;
using System;
using System.Data;
using System.Data.SqlClient;

namespace _09.IncreaseAgeStoredProcedure
{
    public class StartUp
    {
        private const string DbName = "MinionsDB";
        private const string ProcedureName = "usp_GetOlder";
        static void Main(string[] args)
        {
            SqlConnection connection = new SqlConnection(string.Format(Configuration.ConnectionString, DbName));

            connection.Open();

            using (connection)
            {
                int minionId = int.Parse(Console.ReadLine());

                // Create procedure
                SqlCommand createCommand = new SqlCommand(Queries.CreateProcedure, connection);
                createCommand.ExecuteNonQuery();

                // Exec procedure
                SqlCommand execCommand = new SqlCommand(ProcedureName, connection);

                execCommand.CommandType = CommandType.StoredProcedure;
                execCommand.Parameters.AddWithValue("@Id", minionId);
                execCommand.ExecuteNonQuery();

                // Create reader to show result after procedure executes
                SqlCommand selectCommand = new SqlCommand(Queries.SelectMinionNameAndAge, connection);
                selectCommand.Parameters.AddWithValue("@Id", minionId);

                SqlDataReader reader = selectCommand.ExecuteReader();

                while (reader.Read())
                {
                    string minionName = (string)reader["Name"];
                    int minionAge = (int)reader["Age"];

                    Console.WriteLine($"{minionName} - {minionAge} years old");
                }
            }
        }
    }
}
