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
            new Game();
            

            //Board board = new Board();
            //game.ResizeWindow();
            //board.GenerateBoard();
            //board.DisplayBoard();
            //board.DropChar(5, 10, 'X');
            //board.DisplayBoard();
            //board.MovePiece();
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
//I need a way to link the two boards.
//Attacks can check value against enemy's "My Board"
//Once the board exists, it will hold values at all the indicies.
//Attacks will change the values in the indicies of both boards.
//targetBoards will start out blank. Each attack will change the "." to a miss or a hit.



//Placing pieces
    ////Display the piece in the upper left corner.
    ////While !Enter, if "Right Key", layout[+1,] redisplay

//Attacks need to check the value at the specified coordinates, then react in a certain way.
////If ".", register a miss. Print Miss char to enemy's board.
////If "B", register a hit. Print Hit char to enemy's board. Check to see if any adjacent values are also B.


//Initial set up -- Get player names, determine who goes first
//P1 lays their ships -- Inform of ship types. Select type of ship. Select starting spot. Select ending spot. Update list, continue.
//Clear screen. P2 lays their ships.
//Clear screen. Show P2 battlefield



//I need the cursor to move around a board that reflects hits and misses, but not enemy ship placement.
//At the start of the turn, I need to create a new board that looks at 
