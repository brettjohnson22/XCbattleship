using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleship
{
    class Board
    {
        //member variables (HAS A)
        public char[,] layout;

        //constructor (SPAWNER)
        public Board()
        {
            
        }
        //member methods (CAN DO)
        public void GenerateBoard()
        {
            layout = new char[22, 22];
            for (int i = 0; i < 22; i++)
            {
                for (int j = 0; j < 22; j++)
                {
                    if (i == 0 || i == 21)
                    {
                        layout[i, j] = '_';
                    }
                    else if (j == 0 || j == 21)
                    {
                        layout[i, j] = '|';
                    }
                    else
                    {
                        layout[i, j] = '.';
                    }
                }
                Console.WriteLine();
            }
        }

        public void DisplayBoard()
        {
            Console.Clear();
            for (int i = 0; i < 22; i++)
            {
                for (int j = 0; j < 22; j++)
                {
                    Console.Write(layout[i, j]);
                }
                Console.WriteLine();
            }
        }

        public void DropChar(int x, int y, char a)
        {
            layout[x, y] = a;
        }

        public void ShowPiece()
        {
            int x = 1;
            int y = 1;
            layout[x, y] = '0';
            layout[x, y + 1] = '0';
            DisplayBoard();
            {
                bool KeepGoing = true;
                do
                {
                    if (Console.ReadKey().Key == ConsoleKey.RightArrow)
                    {
                        layout[x, y] = '.';
                        layout[x, y + 2] = '0';
                        y++;
                        DisplayBoard();
                    }
                    else if (Console.ReadKey().Key == ConsoleKey.DownArrow)
                    {
                        layout[x, y] = '.';
                        layout[x, y + 1] = '.';
                        layout[x + 1, y] = '0';
                        layout[x + 1, y + 1] = '0';
                        x++;
                        DisplayBoard();
                    }
                    else if (Console.ReadKey().Key == ConsoleKey.LeftArrow)
                    {
                        layout[x, y + 1] = '.';
                        layout[x, y - 1] = '0';
                        y--;
                        DisplayBoard();
                    }
                    else if (Console.ReadKey().Key == ConsoleKey.UpArrow)
                    {
                        layout[x, y] = '.';
                        layout[x, y + 1] = '.';
                        layout[x - 1, y] = '0';
                        layout[x - 1, y + 1] = '0';
                        x--;
                        DisplayBoard();
                    }
                    else if (Console.ReadKey().Key == ConsoleKey.Enter)
                    {
                        DisplayBoard();
                        KeepGoing = false;

                    }
                } while (KeepGoing);
            }
            
        }
    }
}
