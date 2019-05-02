using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleship
{
    class Program
    {
        static void Main(string[] args)
        {
            char[,] board = new char[22, 22];
            for (int i = 0; i < 22; i++)
            {
                for (int j = 0; j < 22; j++)
                {
                    if(i == 0 || i == 21)
                    {
                    board[i, j] = '_';
                    }
                    else if(j == 0 || j == 21)
                    {
                        board[i, j] = '|';
                    }
                    else
                    {
                        board[i, j] = '.';
                    }
                }
                Console.WriteLine();
            }
            for (int i = 0; i < 22; i++)
            {
                for(int j = 0; j < 22; j++)
                {
                    Console.Write(board[i, j]);
                }
                Console.WriteLine();
            }
            Console.ReadLine();
            //Game game = new Game();
            //game.ResizeWindow();
            //Console.ReadLine();
        }
    }
}
//I need to figure out how to display a gameboard (array of arrays?)
//The arrays will store values (undiscovered:empty, ship, discovered:hit ship, miss)
//There should be a position label on x and y axis
//Game class, board class, player class, gamepiece abstract class (child class for each type of ship)
//Each player has a board
//I need to allow for pieces to be laid vertically or horizontally

    
    
//Console.SetWindowSize(70, 30);
//24 Columns: 1 Blank. 1 Border. 20 game columns. 1 Border. 1 Blank.
//Each line is an array. use string.Join to join the array into a horizontal line.
//So it will be an array of arrays[24], with the first index being the top line, and so on down.
//char[,] array = new char[22, 22]
//[row, column]
//I need a way to display a board that shows the discovered values, but not the undiscovered values.


//Initial set up -- Get player names, determine who goes first
//P1 lays their ships -- Inform of ship types. Select type of ship. Select starting spot. Select ending spot. Update list, continue.
//Clear screen. P2 lays their ships.
//Clear screen. Show P2 battlefield
