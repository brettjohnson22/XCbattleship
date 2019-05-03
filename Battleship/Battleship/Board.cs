using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleship
{
    public class Board
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

        //public void DropChar(int x, int y, char a)
        //{
        //    layout[x, y] = a;
        //}

        public void PlacePiece(Piece movingPiece)
        {
            int x = 1;
            int y = 1;
            //Somehow store "current place?"
            DropPiece(movingPiece, x, y);
            DisplayBoard();
            bool KeepGoing = true;
            do
            {
                DisplayBoard();
                ConsoleKey buttonPress = Console.ReadKey().Key;
                if (buttonPress == ConsoleKey.RightArrow && layout[x, y + movingPiece.pieceSize] == '.')
                {
                    MoveRight(movingPiece, x, y);
                    y++;
                }
                else if (buttonPress == ConsoleKey.LeftArrow && layout[x, y - 1] == '.')
                {
                    MoveLeft(movingPiece, x, y);
                    y--;
                }
                else if (buttonPress == ConsoleKey.UpArrow && x != 1)
                {
                    MoveUp(movingPiece, x, y);
                    x--;
                }
                else if (buttonPress == ConsoleKey.DownArrow && x != 20)
                {
                    MoveDown(movingPiece, x, y);
                    x++;
                }
                else if (buttonPress == ConsoleKey.F)
                {
                    FlipPiece(movingPiece, x, y);
                }
                else if (buttonPress == ConsoleKey.Enter)
                {
                    KeepGoing = false;
                }
            }
            while (KeepGoing);
            DisplayBoard();
        }
        public void DropPiece(Piece movingPiece, int x, int y)
        {
            for (int i = 0; i < movingPiece.pieceSize; i++)
            {
                layout[x, y + i] = '0';
            }
        }
        public void MoveRight(Piece movingPiece, int a, int b)
        {
            if (movingPiece.horizontal)
            {
                layout[a, b] = '.';
                layout[a, b + movingPiece.pieceSize] = '0';
            }
            else
            {
                for (int i = 0; i < movingPiece.pieceSize; i++)
                {
                    layout[a, b + i] = '.';
                    layout[a + 1, b + i] = '0';
                }
            }
        }
        public void MoveLeft(Piece movingPiece, int a, int b)
        {
            if (movingPiece.horizontal)
            {
                layout[a, b + (movingPiece.pieceSize - 1)] = '.';
                layout[a, b - 1] = '0';
            }
            else
            {
                for (int i = 0; i < movingPiece.pieceSize; i++)
                {
                    layout[a, b + i] = '.';
                    layout[a - 1, b + i] = '0';
                }
            }
        }
        public void MoveUp(Piece movingPiece, int a, int b)
        {
            if (movingPiece.horizontal)
            {
                for (int i = 0; i < movingPiece.pieceSize; i++)
                {
                    layout[a, b + i] = '.';
                    layout[a - 1, b + i] = '0';
                }
            }
            else
            {
                layout[a, b] = '.';
                layout[a - movingPiece.pieceSize, b] = '0';
            }
        }
        public void MoveDown(Piece movingPiece, int a, int b)
        {
            if (movingPiece.horizontal)
            {
                for (int i = 0; i < movingPiece.pieceSize; i++)
                {
                    layout[a, b + i] = '.';
                    layout[a + 1, b + i] = '0';
                }
            }
            else
            {
                layout[a, b] = '.';
                layout[a + movingPiece.pieceSize, b] = '0';
            }
        }
        public void FlipPiece(Piece movingPiece, int a, int b)
        {
            if (movingPiece.horizontal)
            {
                for (int i = 1; i < movingPiece.pieceSize; i++)
                {
                    layout[a, b + i] = '.';
                    layout[a + i, b] = '0';
                }
            }
            else
            {
                for (int i = 1; i < movingPiece.pieceSize; i++)
                {
                    layout[a, b + i] = '0';
                    layout[a + i, b] = '.';
                }
            }
            movingPiece.horizontal = !movingPiece.horizontal;
        }
    }
}
