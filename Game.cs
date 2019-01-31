using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    class Game
    {
        public char[] grid = new char[] { '1', '2', '3', '4', '5', '6', '7', '8', '9' };

        public Game()
        {
            char[] newGame = grid;
        }

        public void OutputGrid()
        {
            Console.Clear();
            Console.WriteLine("     |     |     ");
            Console.WriteLine("  {0}  |  {1}  |  {2}  ", grid[0], grid[1], grid[2]);
            Console.WriteLine("_____|_____|_____");
            Console.WriteLine("     |     |     ");
            Console.WriteLine("  {0}  |  {1}  |  {2}  ", grid[3], grid[4], grid[5]);
            Console.WriteLine("_____|_____|_____");
            Console.WriteLine("     |     |     ");
            Console.WriteLine("  {0}  |  {1}  |  {2}  ", grid[6], grid[7], grid[8]);
            Console.WriteLine("     |     |     ");
        }

        public string CheckWinOrDraw(Player currentPlayer)
        {
            string text = null;
            char[,] winningCombinations = new char[8, 3]
            {
                { grid[0], grid[1], grid[2] },
                { grid[3], grid[4], grid[5] },
                { grid[6], grid[7], grid[8] },
                { grid[0], grid[3], grid[6] },
                { grid[1], grid[4], grid[7] },
                { grid[2], grid[5], grid[8] },
                { grid[0], grid[4], grid[8] },
                { grid[2], grid[4], grid[6] }
            };

            int columns = winningCombinations.GetLength(0);

            for (int i = 0; i < columns; i++)
            {
                if (winningCombinations[i, 0] == currentPlayer.icon &&
                    winningCombinations[i, 1] == currentPlayer.icon &&
                    winningCombinations[i, 2] == currentPlayer.icon)
                {
                    text = $"Congratulations! {currentPlayer.name} has won the game!";
                }
            }

            if (text == null && Array.TrueForAll(grid, (char value) => !Char.IsNumber(value)))
            {
                text = "Game ended in a draw";
            }

            return text;
        }

        public void SetIcon(Player currentplayer, bool pass)
        {
            while (!pass)
            {
                Console.WriteLine($"{currentplayer.name}: Choose your field! ");
                int number = 0;

                try
                {
                    number = Convert.ToInt32(Console.ReadLine());
                }
                catch
                {
                    Console.WriteLine("Please enter a number!");
                    continue;
                }

                if (number > 9 || number < 1)
                {
                    Console.WriteLine("Number must be between 1 and 9");
                    continue;
                }


                if (!Char.IsNumber(grid[number - 1]))
                {
                    Console.WriteLine("Position already taken");
                    continue;
                }
                else
                {
                    grid[number - 1] = currentplayer.icon;
                    pass = true;
                }
            }
        }
    }
}
