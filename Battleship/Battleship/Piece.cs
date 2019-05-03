using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleship
{
    public abstract class Piece
    {
        //member variables (HAS A)
        public int pieceSize;
        public bool horizontal;
        public string name;

        //constructor (SPAWNER)
        public Piece()
        {
            horizontal = true;
        }
        //member methods (CAN DO)
        //            public void MovePiece()
        //    {
        //        int x = 1;
        //        int y = 1;
        //        //Somehow store "current place?"
        //        layout[x, y] = '0';
        //        layout[x, y + 1] = '0';
        //        DisplayBoard();
        //        bool KeepGoing = true;
        //        do
        //        {
        //            DisplayBoard();
        //            ConsoleKey buttonPress = Console.ReadKey().Key;
        //            if (buttonPress == ConsoleKey.RightArrow)
        //            {
        //                layout[x, y] = '.';
        //                layout[x, y + 2] = '0';
        //                y++;
        //            }
        //            else if (buttonPress == ConsoleKey.DownArrow)
        //            {
        //                layout[x, y] = '.';
        //                layout[x, y + 1] = '.';
        //                layout[x + 1, y] = '0';
        //                layout[x + 1, y + 1] = '0';
        //                x++;
        //            }
        //            else if (buttonPress == ConsoleKey.LeftArrow)
        //            {
        //                layout[x, y + 1] = '.';
        //                layout[x, y - 1] = '0';
        //                y--;
        //            }
        //            else if (buttonPress == ConsoleKey.UpArrow)
        //            {
        //                layout[x, y] = '.';
        //                layout[x, y + 1] = '.';
        //                layout[x - 1, y] = '0';
        //                layout[x - 1, y + 1] = '0';
        //                x--;
        //            }
        //            else if (buttonPress == ConsoleKey.Enter)
        //            {
        //                KeepGoing = false;
        //            }
        //        } while (KeepGoing);
        //        DisplayBoard();
        //        Console.ReadLine();
        //    }
        //}
    }
}
