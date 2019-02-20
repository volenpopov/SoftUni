using _01.InitialSetUp;
using System;
using System.Data.SqlClient;

namespace _06.RemoveVillain
{
    public class Program
    {
        static void Main(string[] args)
        {
            Configuration config = new Configuration();

            int villainId = int.Parse(Console.ReadLine());

            using (var connection = new SqlConnection(config.ConnectionString))
            {
                connection.Open();

                string checkVillainSql = "SELECT Name FROM Villains WHERE Id = @villainId";

                SqlCommand checkVillainCmd = new SqlCommand(checkVillainSql, connection);
                checkVillainCmd.Parameters.AddWithValue("@villainId", villainId);

                string villainName = (string)checkVillainCmd.ExecuteScalar(); 

                if (villainName == null)
                {
                    Console.WriteLine("No such villain was found.");
                    return;
                }
        
                string deleteMinionsVillainsSql = "DELETE FROM MinionsVillains WHERE VillainId = @villainId";

                SqlCommand deleteMinionsVillainsCmd = new SqlCommand(deleteMinionsVillainsSql, connection);
                deleteMinionsVillainsCmd.Parameters.AddWithValue("@villainId", villainId);

                int deletedMinionsCount = deleteMinionsVillainsCmd.ExecuteNonQuery();

                string deleteVillainSql = "DELETE FROM Villains WHERE Id = @villainId";

                SqlCommand deleteVillainCmd = new SqlCommand(deleteVillainSql, connection);
                deleteVillainCmd.Parameters.AddWithValue("@villainId", villainId);

                deleteVillainCmd.ExecuteNonQuery();

                Console.WriteLine($"{villainName} was deleted."
                        + Environment.NewLine
                        + $"{deletedMinionsCount} minions were released.");
            }
        }
    }
}
