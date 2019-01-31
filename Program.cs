using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    class Program
    {
        public static bool gamePlaying;

        static void Main(string[] args)
        {
            Player player1 = new Player("Player 1", 'X');
            Player player2 = new Player("Player 2", 'O');
            Player currentPlayer = player1;
            Game game = new Game();
            gamePlaying = true;

            while (gamePlaying)
            {
                game.OutputGrid();
                game.SetIcon(currentPlayer, false);
                game.OutputGrid();

                string text = game.CheckWinOrDraw(currentPlayer);

                if (text != null)
                {
                    Console.WriteLine(text);
                    Console.WriteLine("Press any key to restart");
                    Console.ReadLine();
                    game = new Game();
                    continue;
                }

                currentPlayer = currentPlayer == player1 ? player2 : player1;
            }
            Console.Read();
        }
    }
}
