using Microsoft.Data.Sqlite;


namespace HabitTracker
{
    internal class Database
    {
        static string connectionString = @"Data Source=habit-Tracker.db";
        static internal void CreateDatabase()
        {
            /*Creating a connetion passing the the connection string as an argument
             * This will create the database for you, there's no need to manually create it.
             * And no need to use File.Create().*/

            using (var connection = new SqliteConnection(connectionString))
            {
                //Creating the command to be sent to the database
                using (var tableCmd = connection.CreateCommand())
                {
                    connection.Open();
                    //Declaring what is that command (in SQL syntax)
                    tableCmd.CommandText =
                        @"CREATE TABLE IF NOT EXISTS stepsPerDay (
                    Id INTEGER PRIMARY KEY AUTOINCREMENT,
                    Date TEXT,
                    Quantity INTEGER
                    )";

                    //Executing the command, which isn't a query, it's not asking to return data from the table.
                    tableCmd.ExecuteNonQuery();
                }
            }
        }
    }
}
