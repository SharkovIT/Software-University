﻿using System;
using System.Collections.Generic;
using System.Text;

namespace _09.IncreaseAgeStoredProcedure
{
    public static class Queries
    {
        public static string CreateProcedure = @"CREATE OR ALTER PROC usp_GetOlder @id INT
                                                 AS
                                                 UPDATE Minions
                                                    SET Age += 1
                                                  WHERE Id = @Id";

        public static string SelectMinionNameAndAge = "SELECT Name, Age FROM Minions WHERE Id = @Id";
    }
}
