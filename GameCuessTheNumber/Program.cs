using GameCuessTheNumber;
using System;

namespace GameGuessTheNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            var game = new GameLogic(guessingPlayer: GuessingPlayer.Machine) ;
            game.Start();
        }
    }
}
