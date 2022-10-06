﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HabitTracker
{
    internal class Menu
    {
        internal static void Showmenu()
        {
            Console.Clear();
            bool gameRunning = true;
            do
            {
                Console.WriteLine($@"
Menu
_______________________________
I - Enter steps for a new day.
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
                        break;
                    case "v":
                        Helpers.ViewDB();
                        Console.ReadLine();
                        break;
                    case "u":
                        Database.Update();
                        break;
                    case "d":
                        Database.Delete();
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
