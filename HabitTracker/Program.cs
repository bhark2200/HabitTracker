using HabitTracker;
using System.Data;

Database.CreateDatabase();

Console.WriteLine($@"Welcome to your Habit Tracker, where you will track the amount of
steps you will take in a day.");

Menu.Showmenu();

