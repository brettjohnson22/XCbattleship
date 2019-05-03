using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleship
{
    class Game
    {
        //member variables (HAS A)
        public Player player1;
        public Player player2;

        //constructor (SPAWNER)
        public Game()
        {
            RunGame();
        }
        //member methods (CAN DO)

        public void GetPlayerNames()
        {
            Console.WriteLine("What is Player One's Name?");
            player1.name = Console.ReadLine();
            Console.WriteLine("What is Player Two's Name?");
            player2.name = Console.ReadLine();
        }
        public void ResizeWindow()
        {
            Console.SetWindowSize(60, 25);
            Console.WriteLine(Console.WindowWidth);
            Console.WriteLine(Console.WindowHeight);

        }

        public void PlayerTurn(Player currentplayer, Player currentopponent)
        {
            currentopponent.myBoard.DisplayTargetBoard("Where would you like to attack?");

        }
        public void RunGame()
        {
            player1 = new Player();
            ResizeWindow();
            player1.CreateBoard();
            player1.PlaceDestroyer();
            player1.PlaceSub();
            player1.PlaceBattleship();
            player1.PlaceCarrier();
            player1.myBoard.MoveCursor();
        }
    }

}
