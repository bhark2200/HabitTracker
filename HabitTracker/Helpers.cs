using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HabitTracker
{
    internal class Helpers
    {
        static internal void ViewDBAndStoreDB()
        {
            using (var connection = new SqliteConnection(Database.connectionString))
            {
                //Creating the command to be sent to the database
                using (var tableCmd = connection.CreateCommand())
                {
                    connection.Open();
                    //Declaring what is that command (in SQL syntax)
                    tableCmd.CommandText = $"SELECT Date, Quantity FROM stepsPerDay";

                    //Executing the command, which isn't a query, it's not asking to return data from the table.

                    tableCmd.ExecuteNonQuery();
                }
    }
}
