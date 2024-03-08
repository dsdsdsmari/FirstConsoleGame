using System;
using System.CodeDom.Compiler;

internal class FirstConsoleGame
{
    static void Main()
    {
        while (true)
        {
            Play();

            Console.Write("\nDo you want to continue playing? (Y/N): ");
            string continuePlaying = Console.ReadLine()?.ToUpper();

            while (continuePlaying != "Y" && continuePlaying != "N")
            {
                Console.WriteLine("Invalid input. Please enter 'Y' or 'N'.");
                Console.Write("Do you want to continue playing? (Y/N): ");
                continuePlaying = Console.ReadLine()?.ToUpper();
            }

            if (continuePlaying == "N")
            {
                Console.WriteLine("\nThanks for playing! Press any key to exit...");
                Console.ReadKey();
                break;
            }
        }
    }

    // initiates and manages the core game mechanics.
    static void Play()
    {
        bool isTie = false;

        while (true)
        {
            // clears the console and displays the game title and menu
            Console.Clear();
            Console.WriteLine("*************************************");
            Console.WriteLine("**    Rock, Paper, Scissors Game   **");
            Console.WriteLine("*************************************");

            Console.WriteLine("\n1. Rock");
            Console.WriteLine("2. Paper");
            Console.WriteLine("3. Scissors");
            Console.WriteLine("4. Quit Game");

            int userChoice = GetUserChoice();

            if (userChoice == 4)
            {
                if (QuitGame())
                {
                    Environment.Exit(0);
                }
                else
                {
                    continue;
                }
            }

            string[] choices = { "Rock", "Paper", "Scissors" };
            Random random = new Random();
            int computerChoice = random.Next(1, 4);

            Console.WriteLine("\nYou chose " + choices[userChoice - 1] + ".");
            Console.WriteLine("Computer chose " + choices[computerChoice - 1] + ".");

            int result = Result(userChoice, computerChoice);

            if (result == 0 && !isTie)
            {
                Console.WriteLine("It's a tie! Choose again.");
                isTie = true;
                continue;
            }
            else if (result == 0)
            {
                isTie = false;
            }
            else if (result == 1)
            {
                Console.WriteLine("You win!");
            }
            else
            {
                Console.WriteLine("Computer wins!");
            }

            break;
        }
    }

    static bool QuitGame()
    {
        Console.Write("\nDo you wish to end the game already? (Y/N): ");
        string confirmQuit = Console.ReadLine()?.ToUpper();

        while (confirmQuit != "Y" && confirmQuit != "N")
        {
            Console.WriteLine("\nInvalid input. Please enter 'Y' or 'N'.");
            Console.Write("Do you wish to end the game already? (Y/N): ");
            confirmQuit = Console.ReadLine()?.ToUpper();
        }

        return confirmQuit == "Y";
    }

    // handles user input for the game menu
    static int GetUserChoice()
    {
        while (true)
        {
            Console.Write("\nEnter your choice (1-4): ");
            string selectedChoice = Console.ReadLine();

            if (selectedChoice == "4")
                return 4;

            try
            {
                int userChoice = Convert.ToInt32(selectedChoice);

                if (userChoice < 1 || userChoice > 4)
                {
                    Console.WriteLine("Invalid choice. Please enter a number between 1 and 4.");
                    continue;
                }

                return userChoice;
            }
            catch (FormatException)
            {
                Console.WriteLine("Invalid input. Please enter a number between 1 and 4.");
            }
        }
    }

    // executes the game logic and determines the winner
    static int Result(int userChoice, int computerChoice)
    {
        if (userChoice == computerChoice)
        {
            return 0; // result - Tie
        }
        else if ((userChoice == 1 && computerChoice == 3) ||
                 (userChoice == 2 && computerChoice == 1) ||
                 (userChoice == 3 && computerChoice == 2))
        {
            return 1; // result - Winner: User
        }
        else
        {
            return -1; // result - Winner: Computer
        }
    }
}