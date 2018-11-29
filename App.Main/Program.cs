using App.Data;
using App.Infrastructure;
using System;

namespace App.Main
{
    class Program
    {
        static void Main(string[] args)
        {
            IPPLQueryExecutor queryExecutor = new PPLQueryExecutor();

            var sqlString = @"Select * from dbo.car where capacity > @cap";

            var data = queryExecutor.ExecuteQuery<Car>(sqlString, new { cap = 4000});

            foreach (var item in data)
            {
                Console.WriteLine($"{item.Name} - {item.Capacity}");
            }
        }
    }
}
