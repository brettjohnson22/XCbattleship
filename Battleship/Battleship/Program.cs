using System;

namespace Battleship
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
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
//P1 lays their ships. Select type of ship. Select starting spot. Select ending spot.