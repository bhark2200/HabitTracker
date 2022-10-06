using Microsoft.Data.Sqlite;
using System.Data;

namespace HabitTracker
{
    internal class Helpers
    {
        static internal void ViewDB()
        {
            Console.Clear();
            using var connection = new SqliteConnection(Database.connectionString);
            
            connection.Open();

            string selectStatement = "SELECT * FROM stepsPerDay";

            using var cmd = new SqliteCommand(selectStatement, connection);
            using SqliteDataReader rdr = cmd.ExecuteReader();

            while (rdr.Read())
            { 
                Console.WriteLine($"ID: {rdr.GetInt32(0)} Date: {rdr.GetString(1)} Steps: {rdr.GetInt32(2)}");
            }

        }        
    }
}
