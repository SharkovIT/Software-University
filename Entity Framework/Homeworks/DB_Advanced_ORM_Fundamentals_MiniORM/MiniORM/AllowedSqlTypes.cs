﻿
using System;

namespace MiniORM
{
    internal static class AllowedSqlTypes
    {
        internal static Type[] SqlTypes =
        {
            typeof(string),
            typeof(int),
            typeof(uint),
            typeof(long),
            typeof(ulong),
            typeof(decimal),
            typeof(bool),
            typeof(DateTime),
        };
    }
}
