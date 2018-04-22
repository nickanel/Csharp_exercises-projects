using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace MiniEmailApp.Aux
{
    public static class AuxiliaryFunction
    {
        public static void Print()
        {            
            Console.WriteLine("Test of Console Print from Auxiliary Class");
        }
        //public Auxiliary() { }
        public static void PrintProgrammHeader()
        {

            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Green;
            string welcome = ("**  Bootcamp Email App** ");
            string welcome2 = ("This Application is Designed to offer basic email and/or chat capabilities ");
            string welcome3 = ("in windows console platform enviroment with user authentication intergration");
            Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + (welcome.Length / 2)) + "}", welcome));
            Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + (welcome2.Length / 2)) + "}", welcome2));
            Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + (welcome3.Length / 2)) + "}", welcome3));
            Console.WriteLine(" \n \n \n ");


        }


        public static int Return_Choice(string[] menuItems)
        {
            
            int choice = 0;

            ConsoleKeyInfo key;
            Console.WriteLine("Pick an option . . .");
            // menuItems = { "1.Sign in ", "2.Register", "3.Forgot my Password", "4.Exit" };

            // The loop that goes through all of the menu items.
            do
            {
                Console.Clear();
                PrintProgrammHeader();
                for (int c = 0; c < menuItems.Length; c++)
                {
                    // If the current item number is our variable c, tab out this option.
                    // You could easily change it to simply change the color of the text.
                    if (choice == c)
                    {
                        Console.Write(">> ");
                        Console.WriteLine(menuItems[c]);
                    }
                    // Just write the current option out if the current item is not our variable c.
                    else
                    {
                        Console.WriteLine(menuItems[c]);
                    }
                }

                // Waits until the user presses a key, and puts it into our object key.
                Console.Write("Select your choice with the arrow keys. \n");
                key = Console.ReadKey(true);

                // Simply put, if the key the user pressed is a "DownArrow", the current item will deacrease.
                // Likewise for "UpArrow", except in the opposite direction.
                // If choice goes below 0 or above the maximum menu item, it just loops around to the other end.
                if (key.Key.ToString() == "DownArrow")
                {
                    choice++;
                    if (choice > menuItems.Length - 1) choice = 0;
                }
                else if (key.Key.ToString() == "UpArrow")
                {
                    choice--;
                    if (choice < 0) choice = Convert.ToInt16(menuItems.Length - 1);
                }
                // Loop around until the user presses the enter go.
            } while (key.KeyChar != 13);
            return choice;
        }
        public static bool ValidateName(string name)
        {
            bool IsValidString = false;
            if (name.Length >= 5 && name.Length <= 20)
            {
                IsValidString = true;
            }


            return IsValidString;
        }

        public static bool ValidatePassword(string password)
        {
            //Using a regular expression to check if the given string contains chars
            bool IsValidString = false;
            int LetterCounter = Regex.Matches(password, @"[a-zA-Z]").Count;
            if (password.Length >= 7 && password.Length <= 20 && LetterCounter >= 3)
            {
                IsValidString = true;
            }


            return IsValidString;
        }


    }
}
