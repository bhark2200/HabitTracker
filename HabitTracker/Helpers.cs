using Microsoft.Data.Sqlite;
using System.Data;

namespace HabitTracker
{
    internal class Helpers
    {
        internal static int IsANumberEntered(string message)
        {
            bool isNumber = true;
            int intToReturn;


            do
            {
                Console.WriteLine(message);
                var stringToParse = Console.ReadLine();

                isNumber = int.TryParse(stringToParse, out intToReturn);
                if (isNumber == false)
                {
                    Console.WriteLine("Invalid Input. Hit any key to reenter steps.");
                    Console.ReadLine();
                    Console.Clear();

                }

            } while (isNumber == false);

            return intToReturn;
        }

        static internal void ViewDB()
        {
            Console.Clear();
            using var connection = new SqliteConnection(Database.connectionString);
            
            connection.Open();

            string selectStatement = "SELECT * FROM stepsPerDay";

            using var cmd = new SqliteCommand(selectStatement, connection);
            using SqliteDataReader rdr = cmd.ExecuteReader();
            Console.WriteLine($@"ID       Date        Steps
______________________________");

            while (rdr.Read())
            { 
                Console.WriteLine($"{rdr.GetInt32(0)}  |  {rdr.GetString(1)}  |  {rdr.GetInt32(2)}");
            }

        }        
    }
}
