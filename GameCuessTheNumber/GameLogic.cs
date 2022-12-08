using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameCuessTheNumber
{
    public enum GuessingPlayer
    {
        Human,
        Machine
    }
    public class GameLogic
    {
        private readonly int max;
        private readonly int maxTries;
        private readonly GuessingPlayer guessingPlayer;

        public GameLogic(int max = 100, int maxTries = 5, GuessingPlayer guessingPlayer = GuessingPlayer.Human)
        {
            this.max = max;
            this.maxTries = maxTries;
            this.guessingPlayer = guessingPlayer;
        }

        public void Start()
        {
            if (guessingPlayer == GuessingPlayer.Human)
            {
                HumanGuesses();
            }
            else
            {
                MachineGuesses();
            }
        }

        private void HumanGuesses()
        {
            Random rand = new Random();
            int guessedNumber = rand.Next(0, max);

            int lastGuess = -1;
            int tries = 0;
            while (lastGuess != guessedNumber && tries < maxTries)
            {
                Console.WriteLine("Guess the number \"Human\"!");
                lastGuess= int.Parse(Console.ReadLine());

                if (lastGuess == guessedNumber)
                {
                    Console.WriteLine("Congats! You guessed the number \"Human\"");
                    break;
                }
                else if (lastGuess < guessedNumber)
                    Console.WriteLine("My number is greater!");
                else
                    Console.WriteLine("My number is less!");
                tries++;

                if (tries == maxTries)
                    Console.WriteLine("You lost \"Human\"!");
            }
        }

        private void MachineGuesses()
        {
            Console.WriteLine("Enter a number that's going to be guessed by a computer.");

            int guessedNumber = -1;
            while (guessedNumber == -1)
            {
                int parsedNumber = int.Parse(Console.ReadLine());
                if (parsedNumber >= 0 && parsedNumber <= this.max)
                    guessedNumber = parsedNumber;
            }
            int lastGuess = -1;
            int min = 0;
            int max = this.max;
            int tries = 0;

            while (lastGuess != guessedNumber && tries < maxTries)
            {
                lastGuess = (max + min) / 2;
                Console.WriteLine($"Did you guess this number - {lastGuess}?");
                Console.WriteLine("If yes, enter 'y', if you number is greater - enter 'g', if less - 'l'");

                string answer = Console.ReadLine();
                if (answer == "y")
                {
                    if (lastGuess != guessedNumber)
                    {
                        Console.WriteLine("Hahaha, \"Human\", you were wrong, and I won!");
                        break;
                    }
                    Console.WriteLine("Super! I win, \"Human\"!");
                    break;
                }
                else if (answer == "g")
                    min = lastGuess;
                else if (answer == "l")
                    max = lastGuess;

                if (lastGuess == guessedNumber)
                    Console.WriteLine("Don't cheat, \"Human\"!");

                tries++;

                if (tries == maxTries)
                    Console.WriteLine("I lost! :(");
            }
        }
    }
}
