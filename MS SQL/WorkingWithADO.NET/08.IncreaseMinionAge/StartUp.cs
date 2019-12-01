using _01.InitialSetup;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace _08.IncreaseMinionAge
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
                List<int> minionsIds = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToList();

                SqlCommand updateCmd = new SqlCommand(Queries.UpdateMinions, connection);

                for (int i = 0; i < minionsIds.Count; i++)
                {
                    int currentId = minionsIds[i];
                    updateCmd.Parameters.AddWithValue("@Id", currentId);
                    updateCmd.ExecuteNonQuery();
                    updateCmd.Parameters.Clear();
                }

                SqlCommand resultCmd = new SqlCommand(Queries.TakeMinionsNameAndAge, connection);
                SqlDataReader reader = resultCmd.ExecuteReader();

                while (reader.Read())
                {
                    string minionName = (string)reader["Name"];
                    int minionAge = (int)reader["Age"];

                    Console.WriteLine($"{minionName} {minionAge}");
                }
            }
        }
    }
}
