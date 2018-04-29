using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace guessNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            bool quit = false;
            Console.WriteLine("You are now playing 'Guess a Number'! The number is going to draw randomly from the range of 1 - 100. Enter the number you think the console drew and you have six chances to guess! Good luck!");
            while (!quit) 
            {
                Random random = new Random();
                bool guessingNumber = true;
                int guesses = 10;
                int randomNumber = random.Next(1, 100);
                
                while (guessingNumber)
                {
                    int oneNum;
                    string playerGuess = Console.ReadLine();
                    if (Int32.TryParse(playerGuess, out oneNum))
                    {
                        if (oneNum > 100 || oneNum < 1)
                        {
                            Console.WriteLine("Remeber, it's a random number bewtween 1 and 100!");
                            continue;
                        }

                        if (oneNum < randomNumber)
                        {
                            guesses--;
                            Console.WriteLine("The number you entered is smaller than the random number, you have {0} chances left.", guesses);
                        }

                        if (oneNum > randomNumber)
                        {
                            guesses--;
                            Console.WriteLine("The number you entered is larger than the random number, you have {0} chances left.", guesses);
                        }

                        if (oneNum == randomNumber)
                        {
                            Console.WriteLine("Congratulations! You have guessed the right number! Try guessing another one. If you wish to exit the loop, input 'Quit'.");
                            guesses = 10;
                            randomNumber = random.Next(1, 100);
                        }

                       

                        if (guesses == 0)
                        {
                            Console.WriteLine("Sorry, you have no more guesses. The random number is {0}, better luck next time! Press enter to exit.", randomNumber);
                            Console.ReadLine();
                            quit = true;
                            break;
                        }
                    }
                    else
                    {
                        if (playerGuess.ToLower() == "quit")
                        {
                            quit = true;
                            break;
                        }
                        Console.WriteLine("Your input is either invalid or way out of range! Please enter a number between 1 - 100!");
                    }
                }
            }
        }
    }
}

