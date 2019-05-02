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
            player1 = new Player();
            player2 = new Player();
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
            Console.SetWindowSize(25, 25);
            Console.WriteLine(Console.WindowWidth);
            Console.WriteLine(Console.WindowHeight);

        }

        public void PlayerTurn()
        {

        }
    }
}
