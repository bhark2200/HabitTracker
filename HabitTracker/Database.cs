using Microsoft.Data.Sqlite;

namespace HabitTracker
{
    internal class Database
    {
        static internal string connectionString = @"Data Source=habit-Tracker.db";
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

        static internal void Insert()
        {

            Console.Clear();

            int stepsForDay;
            bool isNumber = true;
            string date = DateTime.Now.ToString("d");

            do
            {
                Console.WriteLine($"Please enter the amount of steps for today: {date}.");
                var stepsForDayString = Console.ReadLine();

                isNumber = int.TryParse(stepsForDayString, out stepsForDay);
                if (isNumber == false)
                {
                    Console.WriteLine("Invalid Input. Hit any key to reenter steps.");
                    Console.ReadLine();

                }

            } while (isNumber == false);


            using (var connection = new SqliteConnection(connectionString))
            {
                //Creating the command to be sent to the database
                using (var tableCmd = connection.CreateCommand())
                {
                    connection.Open();
                    //Declaring what is that command (in SQL syntax)
                    tableCmd.CommandText = $"INSERT INTO stepsPerDay (Date, Quantity) VALUES (@date, @stepsForDay)";
                    tableCmd.Parameters.AddWithValue("@date", date);
                    tableCmd.Parameters.AddWithValue("@stepsForDay", stepsForDay);
                    tableCmd.Prepare();


                    //Executing the command, which isn't a query, it's not asking to return data from the table.
                    
                    tableCmd.ExecuteNonQuery();
                }
            }
        }

        static internal void Delete()
        {

            Console.Clear();
            int rowToDelete;
            bool isNumber = true;

            Helpers.ViewDB();
            

            do
            {
                Console.WriteLine("Please enter ID number of row to Delete.");
                var rowToDeleteString = Console.ReadLine();

                isNumber = int.TryParse(rowToDeleteString, out rowToDelete);
                if (isNumber == false)
                {
                    Console.WriteLine("Invalid Input. Hit any key to reenter steps.");
                    Console.ReadLine();

                }

            } while (isNumber == false);


            using (var connection = new SqliteConnection(connectionString))
            {
                
                using (var tableCmd = connection.CreateCommand())
                {
                    connection.Open();
                    
                    tableCmd.CommandText = $"DELETE FROM stepsPerDay WHERE ID = @id";
                    tableCmd.Parameters.AddWithValue("@id", rowToDelete);
                    tableCmd.Prepare();
                                     
                    tableCmd.ExecuteNonQuery();
                }
            }
            Helpers.ViewDB();
            Console.WriteLine("Row Deleted. Hit a enter to continue.");
            Console.ReadLine();
        }
    }


}
