using Microsoft.Data.Sqlite;

namespace HabitTracker
{
    internal class Database
    {
        internal static string connectionString = @"Data Source=habit-Tracker.db";
        internal static void CreateDatabase()
        {
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

                    tableCmd.ExecuteNonQuery();
                }
            }
        }

        internal static void Insert()
        {
            Console.Clear();

            string date = DateTime.Now.ToString("d");
            var stepsForDay = Helpers.IsANumberEntered($"Please enter the amount of steps for today: {date}.");

            using (var connection = new SqliteConnection(connectionString))
            {                
                using (var tableCmd = connection.CreateCommand())
                {
                    connection.Open();
                    
                    tableCmd.CommandText = "INSERT INTO stepsPerDay (Date, Quantity) VALUES (@date, @stepsForDay)";
                    tableCmd.Parameters.AddWithValue("@date", date);
                    tableCmd.Parameters.AddWithValue("@stepsForDay", stepsForDay);
                    tableCmd.Prepare();
                                                                              
                    tableCmd.ExecuteNonQuery();
                }
            }
        }

        internal static void Delete()
        {
            Console.Clear();
            bool idCheck;
            int rowToDelete;
            Helpers.ViewDB();
            do
            {
                rowToDelete = Helpers.IsANumberEntered("Please enter ID number of row to Delete.");
                idCheck = Helpers.CheckIfIdIsThere(rowToDelete);
            } while (!idCheck);

            using (var connection = new SqliteConnection(connectionString))
            {
                
                using (var tableCmd = connection.CreateCommand())
                {
                    connection.Open();
                    
                    tableCmd.CommandText = "DELETE FROM stepsPerDay WHERE ID = @id";
                    tableCmd.Parameters.AddWithValue("@id", rowToDelete);
                    tableCmd.Prepare();
                                     
                    tableCmd.ExecuteNonQuery();
                }
            }
            Helpers.ViewDB();
            Console.WriteLine("Row Deleted. Hit a enter to continue.");
            Console.ReadLine();
        }

        internal static void Update()
        {
            Helpers.ViewDB();
            int rowToUpdate;
            bool idCheck;
            do 
            {
                rowToUpdate = Helpers.IsANumberEntered("Please enter ID number of row to update.");
                idCheck= Helpers.CheckIfIdIsThere(rowToUpdate);
            }while (!idCheck);
            
            var stepsToUpdate = Helpers.IsANumberEntered("Please enter steps to update.");

            using (var connection = new SqliteConnection(connectionString))
            {
                using (var tableCmd = connection.CreateCommand())
                {
                    connection.Open();

                    tableCmd.CommandText = "UPDATE stepsPerDay SET Quantity = @steps WHERE ID = @id";
                    tableCmd.Parameters.AddWithValue("@steps", stepsToUpdate);
                    tableCmd.Parameters.AddWithValue("@id", rowToUpdate);
                    tableCmd.Prepare();

                    tableCmd.ExecuteNonQuery();
                }
            }
            Helpers.ViewDB();
            Console.WriteLine("Row Updated. Hit enter to continue.");
            Console.ReadLine();
        }
    }


}
