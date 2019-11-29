using _01.InitialSetup;
using System;
using System.Data.SqlClient;

namespace _04.AddMinion
{
    public class StartUp
    {
        public static int TownId;
        public static int MinionId;
        public static int VillainId;

        private const string DbName = "MinionsDB";
        static void Main(string[] args)
        {
            string input = Console.ReadLine()
                .Split(":", StringSplitOptions.RemoveEmptyEntries)[1];
            string[] minionInfo = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);

            string minionName = minionInfo[0];
            int minionAge = int.Parse(minionInfo[1]);
            string minionTown = minionInfo[2];

            string[] villainInfo = Console.ReadLine()
                .Split(": ", StringSplitOptions.RemoveEmptyEntries);

            string villainName = villainInfo[1];

            SqlConnection connection = new SqlConnection(String.Format(Configuration.ConnectionString, DbName));

            connection.Open();

            using (connection)
            {
                // Town check

                SqlCommand townCmd = new SqlCommand(Queries.TakeTownId, connection);

                townCmd.Parameters.AddWithValue("@townName", minionTown);

                object targetTownId = townCmd.ExecuteScalar();

                if (targetTownId != null)
                {
                    TownId = (int)targetTownId;
                }
                else
                {
                    SqlCommand townCmdToAdd = new SqlCommand(Queries.InsertTownName, connection);

                    townCmdToAdd.Parameters.AddWithValue("@townName", minionTown);

                    townCmdToAdd.ExecuteNonQuery();

                    Console.WriteLine($"Town {minionTown} was added to the database.");
                }

                // Minion check

                SqlCommand minionCmd = new SqlCommand(Queries.TakeMinionId, connection);

                minionCmd.Parameters.AddWithValue("@Name", minionName);

                object targetMinionId = minionCmd.ExecuteScalar();

                if (targetMinionId != null)
                {
                    MinionId = (int)targetMinionId;
                }
                else
                {
                    SqlCommand minionCmdToAdd = new SqlCommand(Queries.InsertMinion, connection);

                    minionCmdToAdd.Parameters.AddWithValue("@name", minionName);
                    minionCmdToAdd.Parameters.AddWithValue("@age", minionAge);
                    minionCmdToAdd.Parameters.AddWithValue("@townId", TownId);

                    minionCmdToAdd.ExecuteNonQuery();
                }

                // Villain check

                SqlCommand villainCmd = new SqlCommand(Queries.TakeVillainId, connection);

                villainCmd.Parameters.AddWithValue("@Name", villainName);

                object targetVillainId = villainCmd.ExecuteScalar();

                if (targetVillainId != null)
                {
                    VillainId = (int)targetVillainId;
                }
                else
                {
                    SqlCommand villainCmdToAdd = new SqlCommand(Queries.InsertVillain, connection);

                    villainCmdToAdd.Parameters.AddWithValue("@villainName", villainName);

                    villainCmdToAdd.ExecuteNonQuery();

                    Console.WriteLine($"Villain {villainName} was added to the database.");
                }

                // Adding minion to be servant of villain

                SqlCommand minionOfVillainCmd = new SqlCommand(Queries.InsertMinionVillain, connection);
                minionOfVillainCmd.Parameters.AddWithValue("@villainId", VillainId);
                minionOfVillainCmd.Parameters.AddWithValue("@minionId", MinionId);

                minionOfVillainCmd.ExecuteNonQuery();

                Console.WriteLine($"Successfully added {minionName} to be minion of {villainName}.");
            }
        }
    }
}
