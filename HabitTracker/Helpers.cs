using Microsoft.Data.Sqlite;
using System.Data;
using System.Net.Sockets;

namespace HabitTracker
{
    internal class Helpers
    {
        internal static List<int> IdList = new List<int>();
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

        internal static  void ViewDB()
        {
            Console.Clear();
            IdList.Clear();
            using var connection = new SqliteConnection(Database.connectionString);
            
            connection.Open();

            string selectStatement = "SELECT * FROM stepsPerDay";

            using var cmd = new SqliteCommand(selectStatement, connection);
            using SqliteDataReader rdr = cmd.ExecuteReader();
            Console.WriteLine($@"ID       Date        Steps
______________________________");
            
            while (rdr.Read())
            {
                
                IdList.Add(rdr.GetInt32(0));
                Console.WriteLine($"{rdr.GetInt32(0)}    {rdr.GetString(1)}    {rdr.GetInt32(2)}");
                
            }

        }        

        internal static bool CheckIfIdIsThere(int idCheck)
        {
            foreach (var i in IdList)
            {
                if (idCheck == i)
                {
                    return true;
                }                         
                   
            }
            Console.WriteLine("ID not in system. Please choose a new Id.");
            return false;
        }
    }
}
