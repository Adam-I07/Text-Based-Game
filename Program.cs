using System;

namespace First_Rpg_Game
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "RPG";
            RunGame newGame = new RunGame();

            Console.WriteLine("Start Menu");
            Console.WriteLine("(1) Start Game");
            Console.WriteLine("(2) Exit");
            Console.WriteLine("-----------------------");
            Console.WriteLine("Disclaimer");
            Console.WriteLine("When writing a decision you go with make sure you write the whole word with the correct spelling within the  ' ' of the question.");
            Console.WriteLine("Enter 1 or 2: ");
            var ans = Console.ReadLine();
            int choice = 0;
            bool continuePar = false;
            do
            {
                int.TryParse(ans, out choice);
            
                if (choice == 1 || choice == 2)
                {
                    continuePar = true;
                    switch (choice)
                    {
                        case 1:
                            newGame.StartGame();
                            break;
                        case 2:
                            Console.WriteLine("Program has been terminated.");
                            Environment.Exit(0);
                            break;
                    }

                }
                else
                {
                    Console.WriteLine("You must type numeric value only!!!" + "Enter a value from the menu: ");
                    ans = Console.ReadLine();
                }

            } while (continuePar == false);
        }
    }
    
}
