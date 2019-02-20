using _01.InitialSetUp;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace _05.ChangeTownNamesCasing
{
    public class Program
    {
        static void Main(string[] args)
        {
            Configuration config = new Configuration();

            string country = Console.ReadLine();

            string updateTownsToUpperSql = @"UPDATE Towns
                                           SET Name = UPPER(Name)
                                         WHERE CountryCode = (SELECT c.Id FROM Countries AS c WHERE c.Name = @countryName)";

            string getTownsByCountrySql = @"SELECT t.Name 
                                           FROM Towns as t
                                           JOIN Countries AS c ON c.Id = t.CountryCode
                                          WHERE c.Name = @countryName";

            using (var connection = new SqlConnection(config.ConnectionString))
            {
                connection.Open();

                var updateTownsToUpperCmd = new SqlCommand(updateTownsToUpperSql, connection);
                updateTownsToUpperCmd.Parameters.AddWithValue(@"countryName", country);

                int rowsAffected = updateTownsToUpperCmd.ExecuteNonQuery();

                Console.WriteLine($"{rowsAffected} town names were affected.");

                var getTownsCmd = new SqlCommand(getTownsByCountrySql, connection);
                getTownsCmd.Parameters.AddWithValue("@countryName", country);

                List<string> townNames = new List<string>();

                using (SqlDataReader reader = getTownsCmd.ExecuteReader())
                {
                    while(reader.Read())
                    {
                        townNames.Add((string)reader["Name"]);
                    }
                }

                Console.WriteLine($"[{string.Join(", ", townNames)}]");
            }
                


        }
    }
}
