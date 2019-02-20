using _01.InitialSetUp;
using System;
using System.Data.SqlClient;
using System.Linq;

namespace _08.IncreaseMinionAge
{
    public class Program
    {
        static void Main(string[] args)
        {
            Configuration config = new Configuration();

            int[] miniondIds = Console.ReadLine().Split().Select(int.Parse).ToArray();

            string updateAgeAndNameSql = @" UPDATE Minions
                                            SET Name = UPPER(LEFT(Name, 1)) + SUBSTRING(Name, 2, LEN(Name)), Age += 1
                                            WHERE Id = @Id";

            using (var connection = new SqlConnection(config.ConnectionString))
            {
                connection.Open();

                var updateNameAndAgeCmd = new SqlCommand(updateAgeAndNameSql, connection);
                
                foreach (var id in miniondIds)
                {
                    updateNameAndAgeCmd.Parameters.AddWithValue("@Id", id);
                    updateNameAndAgeCmd.ExecuteNonQuery();
                }

                var getAllNamesAndAgeSql = "SELECT Name, Age FROM Minions";

                var getAllNamesAndAgeCmd = new SqlCommand(getAllNamesAndAgeSql, connection);

                using (var reader = getAllNamesAndAgeCmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Console.WriteLine($"{reader["Name"]} {reader["Age"]}");
                    }
                }
                
            }
        }
    }
}
