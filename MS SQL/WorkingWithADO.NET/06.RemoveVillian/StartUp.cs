using _01.InitialSetup;
using System;
using System.Data.SqlClient;

namespace _06.RemoveVillian
{
    public class StartUp
    {
        private const string DbName = "MinionsDB";

        static void Main(string[] args)
        {
            int villainId = int.Parse(Console.ReadLine());

            SqlConnection connection = new SqlConnection(String.Format(Configuration.ConnectionString, DbName));

            connection.Open();

            using (connection)
            {
                SqlTransaction sqlTransaction = connection.BeginTransaction();
                 SqlCommand sqlCommand = connection.CreateCommand();
                sqlCommand.Transaction = sqlTransaction;

                try
                {
                    sqlCommand.CommandText = Queries.TakeVillainId;
                    sqlCommand.Parameters.AddWithValue("@villainId", villainId);
                    string villainName = (string)sqlCommand.ExecuteScalar();

                    if (villainName == null)
                    {
                        Console.WriteLine("No such villain was found.");
                        return;
                    }

                    sqlCommand.CommandText = Queries.DeleteVillainFromMinionsVillains;
                    int releasedMinions = sqlCommand.ExecuteNonQuery();

                    sqlCommand.CommandText = Queries.DeleteVillainFromVillains;
                    sqlCommand.ExecuteNonQuery();

                    string releasedMinionsMessage = string.Empty;
                    if (releasedMinions >= 0)
                    {
                        releasedMinionsMessage = $"{releasedMinions} minions were released.";
                    }
                    else if (releasedMinions == 1)
                    {
                        releasedMinionsMessage = $"{releasedMinions} minion was released.";
                    }

                    Console.WriteLine($"{villainName} was deleted.");
                    Console.WriteLine(releasedMinionsMessage);

                    sqlTransaction.Commit();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);

                    try
                    {
                        sqlTransaction.Rollback();
                    }
                    catch (Exception exRollback)
                    {
                        Console.WriteLine(exRollback.Message);
                    }
                }
            }
        }
    }
}
