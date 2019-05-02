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
        }
    }
}
//I need to figure out how to display a gameboard (array of arrays?)
//The arrays will store values (undiscovered:empty, ship, discovered:hit ship, miss)
//There should be a position label on x and y axis
//Game class, board class, player class, gamepiece abstract class (child class for each type of ship)
//Each player has a board
//I need to allow for pieces to be laid vertically or horizontally



//Initial set up -- Get player names, determine who goes first
//P1 lays their ships -- Inform of ship types. Select type of ship. Select starting spot. Select ending spot. Update list, continue.
//Clear screen. P2 lays their ships.
//Clear screen. Show P2 battlefield