using _01.InitialSetUp;
using System;
using System.Data.SqlClient;

namespace _02.VillainNames
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            Configuration config = new Configuration();

            using (var connection = new SqlConnection(config.ConnectionString))
            {
                connection.Open();

                string commandStr = @"
                       SELECT v.Name, COUNT(mv.VillainId) AS MinionsCount  
                       FROM Villains AS v 
                       JOIN MinionsVillains AS mv ON v.Id = mv.VillainId 
                   GROUP BY v.Id, v.Name 
                     HAVING COUNT(mv.VillainId) > 3 
                   ORDER BY COUNT(mv.VillainId)";

                var command = new SqlCommand(commandStr, connection);

                SqlDataReader reader = command.ExecuteReader();

                using (reader)
                {
                    while(reader.Read())
                    {
                        string villainName = (string) reader["Name"];
                        int numberOfMinions = (int) reader["MinionsCount"];

                        Console.WriteLine($"{villainName} - {numberOfMinions}");
                    }
                }
            }
        }
    }
}
