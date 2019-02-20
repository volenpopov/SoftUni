using _01.InitialSetUp;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace _07.PrintAllMinionNames
{
    public class Program
    {
        static void Main(string[] args)
        {
            Configuration config = new Configuration();

            string[] minionsNames = GetMinionsNames(config).ToArray();

            for (int i = 0; i < minionsNames.Length; i++)
            {
                Console.WriteLine(minionsNames[i]);

                if (i < minionsNames.Length - 1 - i)
                    Console.WriteLine(minionsNames[minionsNames.Length - 1 - i]);
                else
                    break;
            }
        }

        private static IEnumerable<string> GetMinionsNames(Configuration config)
        {
            string getMinionsNamesSql = "SELECT Name FROM Minions";

            using (var connection = new SqlConnection(config.ConnectionString))
            {
                connection.Open();

                SqlCommand getMinionsNamesCmd = new SqlCommand(getMinionsNamesSql, connection);

                using (var reader = getMinionsNamesCmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        yield return (string)reader["Name"];
                    }
                }
            }
        }
    }
}
