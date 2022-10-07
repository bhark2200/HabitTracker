
namespace HabitTracker
{
    internal class Menu
    {
        internal static void Showmenu()
        {
            bool gameRunning = true;
            do
            {
                Console.WriteLine($@"
Menu
_______________________________
I - Enter steps.
U - Update steps.
D - Delete an entry.
V - View all step entries.
0 - Quit Program.
_______________________________");
                var menuSelection = Console.ReadLine();

                switch (menuSelection.Trim().ToLower())
                {
                    case "i":
                        Database.Insert();
                        Console.Clear();
                        break;
                    case "v":
                        Helpers.ViewDB();
                        Console.WriteLine("Hit Enter to continue.");
                        Console.ReadLine();
                        Console.Clear();
                        break;
                    case "u":
                        Database.Update();
                        Console.Clear();
                        break;
                    case "d":
                        Database.Delete();
                        Console.Clear();
                        break;
                    case "0":
                        gameRunning = false;
                        break;
                    default:
                        Console.WriteLine("Please enter a valid input. Press enter to continue");
                        Console.ReadLine();
                        Console.Clear();
                        break;
                }
            } while (gameRunning);
        }
    }
}
