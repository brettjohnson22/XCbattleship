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
                if (buttonPress == ConsoleKey.RightArrow)
                {
                    bool moved = MoveRight(movingPiece, x, y);
                    if (moved)
                    {
                        y++;
                    }
                }
                else if (buttonPress == ConsoleKey.LeftArrow)
                {
                    bool moved = MoveLeft(movingPiece, x, y);
                    if (moved)
                    {
                        y--;
                    }
                }
                else if (buttonPress == ConsoleKey.UpArrow && x != 1)
                {
                    bool moved = MoveUp(movingPiece, x, y);
                    if (moved)
                    {
                        x--;
                    }
                }
                else if (buttonPress == ConsoleKey.DownArrow && x != 20)
                {
                    bool moved = MoveDown(movingPiece, x, y);
                    if (moved)
                    {
                        x++;
                    }
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
        public bool MoveRight(Piece movingPiece, int a, int b)
        {
            bool moved = false;
            int counter = 0;
            if (!movingPiece.horizontal)
                {
                for (int i = 0; i < movingPiece.pieceSize; i++)
                {
                    if (layout[a + i, b + 1] == '.')
                    {
                        counter++;
                    }
                }
            }
            if (movingPiece.horizontal && layout[a, b + movingPiece.pieceSize] == '.')
            {
                layout[a, b] = '.';
                layout[a, b + movingPiece.pieceSize] = '0';
                moved = true;
            }
            else if (counter == movingPiece.pieceSize)
            {
                for (int i = 0; i < movingPiece.pieceSize; i++)
                {
                    layout[a + i, b] = '.';
                    layout[a + i, b + 1] = '0';
                }
                moved = true;
            }
            return moved;
        }
        public bool MoveLeft(Piece movingPiece, int a, int b)
        {
            bool moved = false;
            int counter = 0;
            if (!movingPiece.horizontal)
            {
                for (int i = 0; i < movingPiece.pieceSize; i++)
                {
                    if (layout[a + i, b - 1] == '.')
                    {
                        counter++;
                    }
                }
            }
                if (movingPiece.horizontal && layout[a, b - 1] == '.')
            {
                layout[a, b + (movingPiece.pieceSize - 1)] = '.';
                layout[a, b - 1] = '0';
                moved = true;
            }
            else if (counter == movingPiece.pieceSize)
            {
                for (int i = 0; i < movingPiece.pieceSize; i++)
                {
                    layout[a + i, b] = '.';
                    layout[a + i, b - 1] = '0';
                }
                moved = true;
            }
            return moved;
        }
        public bool MoveUp(Piece movingPiece, int a, int b)
        {
            bool moved = false;
            int counter = 0;
            if (movingPiece.horizontal)
            {
                for (int i = 0; i < movingPiece.pieceSize; i++)
                {
                    if (layout[a - 1, b + i] == '.')
                    {
                        counter++;
                    }
                }
            }
            if (counter == movingPiece.pieceSize)
            {
                for (int i = 0; i < movingPiece.pieceSize; i++)
                {
                    if (layout[a - 1, b + i] == '.')
                    {
                        layout[a, b + i] = '.';
                        layout[a - 1, b + i] = '0';
                    }
                }
                moved = true;
            }
            else if (!movingPiece.horizontal && layout[a - 1, b] == '.')
            {
                layout[a + (movingPiece.pieceSize - 1), b] = '.';
                layout[a - 1, b] = '0';
                moved = true;
            }
            return moved;
        }
        public bool MoveDown(Piece movingPiece, int a, int b)
        {
            bool moved = false;
            int counter = 0;
            if (movingPiece.horizontal)
            {
                for (int i = 0; i < movingPiece.pieceSize; i++)
                {
                    if (layout[a + 1, b + i] == '.')
                    {
                        counter++;
                    }
                }
            }
            if (counter == movingPiece.pieceSize)
            {
                for (int i = 0; i < movingPiece.pieceSize; i++)
                {
                    if (layout[a + 1, b + i] == '.')
                    {
                        layout[a, b + i] = '.';
                        layout[a + 1, b + i] = '0';
                    }
                }
                moved = true;
            }
            else if (!movingPiece.horizontal && layout[a + movingPiece.pieceSize, b] == '.')
            {
                layout[a, b] = '.';
                layout[a + movingPiece.pieceSize, b] = '0';
                moved = true;
            }
            return moved;
        }
        public void FlipPiece(Piece movingPiece, int a, int b)
        {
            int counter = 0;
            if (movingPiece.horizontal && a + movingPiece.pieceSize < 22)
            {
                for (int i = 0; i < movingPiece.pieceSize; i++)
                {
                    if (layout[a + i, b] == '.')
                    {
                        counter++;
                    }
                }
               if (counter == movingPiece.pieceSize - 1)
                {
                    for (int i = 1; i < movingPiece.pieceSize; i++)
                    {
                        layout[a, b + i] = '.';
                        layout[a + i, b] = '0';
                    }
                    movingPiece.horizontal = !movingPiece.horizontal;
                }
            }
            else if (!movingPiece.horizontal && b + movingPiece.pieceSize < 22)
            {
                for (int i = 0; i < movingPiece.pieceSize; i++)
                {
                    if (layout[a, b + i] == '.')
                    {
                        counter++;
                    }
                }
                if (counter == movingPiece.pieceSize - 1)
                {
                    for (int i = 1; i < movingPiece.pieceSize; i++)
                    {
                        layout[a, b + i] = '0';
                        layout[a + i, b] = '.';
                    }
                    movingPiece.horizontal = !movingPiece.horizontal;
                }
            }
        }
    }
}
