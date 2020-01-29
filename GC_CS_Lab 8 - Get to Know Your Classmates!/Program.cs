using System;

namespace GC_CS_Lab_8___Get_to_Know_Your_Classmates_
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] studentName = { "Jessica", "Denise", "Blake", "Jacqueline", "Aaron", "Timothy" };
            string[] studentFood = { "sushi", "mac & cheese", "steak", "shrimp alfredo", "broasted chicken", "pizza" };
            string[] studentHomeTown = { "Southfield", "Troy", "Rochester Hills", "Livonia", "Allentown, PA", "Detroit" };
            string[] studentAge = { "23", "35", "41", "38", "30", "27" };

            string continueEntry;

            // This shows the program title
            ShowTitle("Get to Know Your Classmates!");

            // Program loop
            do
            {
                // Prompt for and receive input
                int StuNum = GetStuNum($"Please enter a student number: [1-{studentName.Length}]");

                // Get information on that student
                GetStuInfo((StuNum - 1), studentName, studentFood, studentHomeTown, studentAge );

                // Prompt to repeat program
                continueEntry = TryAgain("Would you like info on another student? [y/n]");
            }
            while (continueEntry == "y");
        }

        public static void GetStuInfo(int studentSelect, string [] stuName, string [] stuFood, string [] stuHomeTown, string [] stuAge)
        {

            string[] stuChoices = { "Favorite food", "Hometown", "Age" };
            string stuContinue = "y";
            string studentTrait;

            // Loop to get trait for specific student
            do
            {
                try
                {
                    studentTrait = GetUserInput($"What information would you like to know about {stuName[studentSelect]}? [Favorite food, Hometown, Age]").Trim().ToLower();
                }
                catch
                {
                    SetOutputColor();
                    Console.WriteLine($"Invalid student number. Currently, student number ranges from 1 to {stuName.Length}.\n");
                    break;
                }

               // output user selected trait or error for invalid options
                SetOutputColor();
                switch (studentTrait)
                {
                    case "favorite food":
                        Console.WriteLine($"{stuName[studentSelect]}'s favorite food is {stuFood[studentSelect]}.\n");
                        break;
                    case "hometown":
                        Console.WriteLine($"{stuName[studentSelect]} is from {stuHomeTown[studentSelect]}.\n");
                        break;
                    case "age":
                        Console.WriteLine($"{stuName[studentSelect]} is {stuAge[studentSelect]} years old.\n");
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please enter \"Favorite food\", \"Hometown\", or \"Age\".\n");
                        break;
                }
                // Prompt to repeat program
                stuContinue = TryAgain($"Would you like more info on {stuName[studentSelect]}? [y/n]");
            }
            while (stuContinue == "y");

        }

        public static int GetStuNum(string userNumPrompt)
        {
            // Method for obtaining student number
            int userInput = CheckSelect(GetUserInput(userNumPrompt));
            return userInput;
        }
        
        public static int CheckSelect(string studentNumber)
        {
            // Checks for integer value for studentNumber
            int number = 0;
            try
            {                
                number = int.Parse(studentNumber);
                return number;
            }
            catch
            {
                number = CheckSelect(GetUserInput("Incorrect input! Please enter a valid student number: "));
                return number;
            }
        }

        public static string TryAgain(string message)
        {
            // Method for running program again.  Passes back to do while loop in main.
            string userChoice = GetUserInput(message).ToLower();
            while ((userChoice != "y") && (userChoice != "n"))
            {
                userChoice = GetUserInput("Please enter 'y' or 'n'.  [y/n]").ToLower();
            }
            return userChoice;
        }


        public static string GetUserInput(string message)
        {
            // Allows for program prompt and user input (string)
            SetOutputColor();
            Console.WriteLine(message);
            SetInputColor();
            string input = Console.ReadLine();
            return input;
        }

        public static void ShowTitle(string title)
        {
            // This method simply shows the title
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.BackgroundColor = ConsoleColor.DarkRed;
            Console.WriteLine($"{title} \n\n");
        }

        public static void SetInputColor()
        {
            // Method for setting colors for user inputted text
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.BackgroundColor = ConsoleColor.Black;
        }

        public static void SetOutputColor()
        {
            // Method for setting colors for default display text
            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.Black;
        }
    }
}
