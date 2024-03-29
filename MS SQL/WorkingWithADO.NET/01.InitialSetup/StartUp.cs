﻿using System;
using System.Data.SqlClient;

namespace _01.InitialSetup
{
    public class StartUp
    {
        static void Main(string[] args)
        {
                SqlConnection connection = new SqlConnection(String.Format(Configuration.ConnectionString, "master"));

                connection.Open();

                using (connection)
                {
                     SqlCommand sqlCommand = new SqlCommand(Configuration.CreateDatabase, connection);

                    try
                    {
                        sqlCommand.ExecuteNonQuery();
                        Console.WriteLine("Successfully created database MinionsDB");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Invalid operation: {ex.Message}");
                        return;
                    }

                     SqlCommand useSqlCommand = new SqlCommand(Configuration.UseCurrentDatabase, connection);

                    useSqlCommand.ExecuteNonQuery();

                    foreach (var query in Configuration.CreateTablesQueries)
                    {
                         SqlCommand createTableCmd = new SqlCommand(query, connection);

                        try
                        {
                            createTableCmd.ExecuteNonQuery();
                            Console.WriteLine($"Successfully created table");
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine($"Invalid operation: {ex.Message}");
                        }
                    }

                    foreach (var query in Configuration.InsertQueries)
                    {
                     SqlCommand insertCmd = new SqlCommand(query, connection);

                        try
                        {
                            int affectedRows = insertCmd.ExecuteNonQuery();
                            Console.WriteLine("Successfully inserted data into table");
                            Console.WriteLine($"Affected rows: {affectedRows}");
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine($"Invalid operation: {ex.Message}");
                        }
                    }
                }
            }
        }
    }

