using System;

namespace TicTacToe
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter the name of Player 1: ");
            string player1Name = Console.ReadLine();
            Player player1 = new Player(player1Name, 'X');

            Console.Write("Enter the name of Player 2: ");
            string player2Name = Console.ReadLine();
            Player player2 = new Player(player2Name, 'O');

            Game game = new Game(player1, player2);
            game.Play();
        }
    }
}
