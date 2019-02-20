using _01.InitialSetUp;
using System;
using System.Data.SqlClient;

namespace _03.MinionNames
{
    public class Program
    {
        static void Main(string[] args)
        {
            Configuration config = new Configuration();

            using (var connection = new SqlConnection(config.ConnectionString))
            {
                connection.Open();

                int villainId = int.Parse(Console.ReadLine());

                string villainNameQuery = $"SELECT Name FROM Villains WHERE Id = @Id";

                SqlCommand command = new SqlCommand(villainNameQuery, connection);
                command.Parameters.AddWithValue("@Id", villainId);
        
                if (command.ExecuteScalar() == null)
                {
                    Console.WriteLine($"No villain with ID {villainId} exists in the database.");
                    return;
                }

                string villainName = (string)command.ExecuteScalar();

                Console.WriteLine($"Villain: {villainName}");

                string getMininonsByVillainQuery = $@"SELECT ROW_NUMBER() OVER (ORDER BY m.Name) as RowNum,
                                                 m.Name, 
                                                 m.Age
                                            FROM MinionsVillains AS mv
                                            JOIN Minions As m ON mv.MinionId = m.Id
                                           WHERE mv.VillainId = @Id
                                        ORDER BY m.Name";

                SqlCommand getMinionsCmd = new SqlCommand(getMininonsByVillainQuery, connection);
                getMinionsCmd.Parameters.AddWithValue("@Id", villainId);

                using (SqlDataReader reader = getMinionsCmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        if (!reader.HasRows)
                        {
                            Console.WriteLine("(no minions)");
                            break;
                        }

                        long rowNumber = (long) reader["RowNum"];
                        string minionName = (string) reader["Name"];
                        int minionAge = (int) reader["Age"];

                        Console.WriteLine($"{rowNumber}. {minionName} {minionAge}");
                    }
                }
            }
        }
    }
}
