using _01.InitialSetUp;
using System;
using System.Data.SqlClient;

namespace _09.IncreaseAgeStoredProcedure
{
    public class Program
    {
        static void Main(string[] args)
        {
            Configuration config = new Configuration();

            int minionId = int.Parse(Console.ReadLine());

            string uspGetOlderProc = "EXEC usp_GetOlder @id";

            using (var connection = new SqlConnection(config.ConnectionString))
            {
                connection.Open();

                var getOlderCmd = new SqlCommand(uspGetOlderProc, connection);
                getOlderCmd.Parameters.AddWithValue("@id", minionId);
                
                using (var reader = getOlderCmd.ExecuteReader())
                {
                    reader.Read();

                    string minionName = (string)reader[0];
                    int minionAge = (int)reader[1];

                    Console.WriteLine($"{minionName} - {minionAge} years old");
                }
            }
        }
    }
}
