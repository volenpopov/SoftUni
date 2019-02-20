using _01.InitialSetUp;
using System;
using System.Data.SqlClient;

namespace _04.AddMinion
{
    public class Program
    {
        static void Main(string[] args)
        {
            Configuration config = new Configuration();

            string[] minionInput = Console.ReadLine().Split();
            string minionName = minionInput[1];
            int minionAge = int.Parse(minionInput[2]);
            string town = minionInput[3];

            string[] villainInput = Console.ReadLine().Split();
            string villainName = villainInput[1];

            string getVillainId = "SELECT Id FROM Villains WHERE Name = @Name";
            string getMinionId = "SELECT Id FROM Minions WHERE Name = @Name";
            string getTownId = "SELECT Id FROM Towns WHERE Name = @townName";
            string insertVillain = "INSERT INTO Villains (Name, EvilnessFactorId)  VALUES (@villainName, 4)";
            string insertMinion = "INSERT INTO Minions (Name, Age, TownId) VALUES (@name, @age, @townId)";
            string insertTown = "INSERT INTO Towns (Name) VALUES (@townName)";
            string insertIntoMinionsVillains = "INSERT INTO MinionsVillains (MinionId, VillainId) VALUES (@villainId, @minionId)";

            using (var connection = new SqlConnection(config.ConnectionString))
            {
                connection.Open();

                SqlTransaction sqlTran = connection.BeginTransaction();

                try
                {
                    var getTownCmd = new SqlCommand(getTownId, connection);
                    getTownCmd.Parameters.AddWithValue("@townName", town);
                    getTownCmd.Transaction = sqlTran;

                    int? townId = (int?)getTownCmd.ExecuteScalar();

                    if (townId == null)
                    {
                        AddTown(town, insertTown, connection, sqlTran);
                    }

                    townId = (int)getTownCmd.ExecuteScalar();

                    var getVillainIdCmd = new SqlCommand(getVillainId, connection);
                    getVillainIdCmd.Parameters.AddWithValue("@Name", villainName);
                    getVillainIdCmd.Transaction = sqlTran;

                    int? villainId = (int?)getVillainIdCmd.ExecuteScalar();

                    if (villainId == null)
                    {
                        AddVillain(villainName, insertVillain, connection, sqlTran);
                    }

                    villainId = (int)getVillainIdCmd.ExecuteScalar();

                    var getMinionIdCmd = new SqlCommand(getMinionId, connection);
                    getMinionIdCmd.Parameters.AddWithValue("@Name", minionName);
                    getMinionIdCmd.Transaction = sqlTran;

                    int? minionId = (int?)getMinionIdCmd.ExecuteScalar();

                    if (minionId == null)
                    {
                        AddMinion(minionName, minionAge, town, insertMinion, connection, sqlTran);
                    }

                    minionId = (int)getMinionIdCmd.ExecuteScalar();

                    var attachMinionToVillainCmd = new SqlCommand(insertIntoMinionsVillains, connection);
                    attachMinionToVillainCmd.Parameters.AddWithValue("@villainId", villainId);
                    attachMinionToVillainCmd.Parameters.AddWithValue("@minionId", minionId);
                    attachMinionToVillainCmd.Transaction = sqlTran;

                    attachMinionToVillainCmd.ExecuteNonQuery();

                    sqlTran.Commit();

                    Console.WriteLine($"Successfully added {minionName} to be minion of {villainName}.");
                }


                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);

                    try
                    {
                        sqlTran.Rollback();
                    }

                    catch (Exception exRollback)
                    {
                        Console.WriteLine(exRollback.Message);
                    }
                }
                
            }
        }

        private static void AddMinion(string minionName, int minionAge, string town, string insertMinion, SqlConnection connection, SqlTransaction sqlTran)
        {
            var insertNewMinionCmd = new SqlCommand(insertMinion, connection);
            insertNewMinionCmd.Parameters.AddWithValue("@name", minionName);
            insertNewMinionCmd.Parameters.AddWithValue("@age", minionAge);
            insertNewMinionCmd.Parameters.AddWithValue("@townId", town);
            insertNewMinionCmd.Transaction = sqlTran;

            insertNewMinionCmd.ExecuteNonQuery();
        }

        private static void AddVillain(string villainName, string insertVillain, SqlConnection connection, SqlTransaction sqlTran)
        {
            var insertNewVillainCmd = new SqlCommand(insertVillain, connection);
            insertNewVillainCmd.Parameters.AddWithValue("@villainName", villainName);
            insertNewVillainCmd.Transaction = sqlTran;

            insertNewVillainCmd.ExecuteNonQuery();

            Console.WriteLine($"Villain {villainName} was added to the database.");
        }

        private static void AddTown(string town, string insertTown, SqlConnection connection, SqlTransaction sqlTran)
        {
            var insertNewTownCmd = new SqlCommand(insertTown, connection);
            insertNewTownCmd.Parameters.AddWithValue("@townName", town);
            insertNewTownCmd.Transaction = sqlTran;

            insertNewTownCmd.ExecuteNonQuery();

            Console.WriteLine($"Town {town} was added to the database.");
        }
    }
}
