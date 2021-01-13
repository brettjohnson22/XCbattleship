using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleship
{
    class Game
    {
        public Player player1;
        public Player player2;

        public Game()
        {
            player1 = new Player();
            player2 = new Player();
        }

        public void RunGame()
        {
            ResizeWindow();
            Console.WriteLine("Welcome to Battleship! By Brett Johnson");
            Console.ReadLine();
            GetPlayerNames();
            SetBoard(player1);
            SetBoard(player2);
            while (player1.score < 14 && player2.score < 14)
            {
                PlayerTurn(player1, player2);
                if (player1.score < 14)
                {
                    PlayerTurn(player2, player1);
                }
            }
            GameOver();
        }
        public void ResizeWindow()
        {
            Console.SetWindowSize(63, 25);
            Console.BufferWidth = 63;
            Console.BufferHeight = 25;
        }
        public void GetPlayerNames()
        {
            bool validChoice = false;
            while (!validChoice)
            {
                Console.WriteLine("What is Player One's Name?");
                string nameInput = Console.ReadLine();
                switch (nameInput)
                {
                    case "":
                        Console.WriteLine("You must enter a name.");
                        break;
                    default:
                        player1.name = nameInput;
                        validChoice = true;
                        break;
                }
            }
            validChoice = false;
            while (!validChoice)
            {
                Console.WriteLine("What is Player Two's Name?");
                string nameInput = Console.ReadLine();
                switch (nameInput)
                {
                    case "":
                        Console.WriteLine("You must enter a name.");
                        break;
                    default:
                        player2.name = nameInput;
                        validChoice = true;
                        break;
                }
            }
            Console.Clear();
        }

        public void SetBoard(Player player)
        {
            Console.WriteLine($"{player.name}, hit 'Enter' to place your pieces.");
            Console.ReadLine();
            player.CreateBoards();
            player.PlaceDestroyer();
            player.PlaceSub();
            player.PlaceBattleship();
            player.PlaceCarrier();
            Console.Clear();
        }

        public void PlayerTurn(Player currentplayer, Player currentopponent)
        {
            bool keepGoing = true;
            do
            {
                Console.WriteLine($"{currentplayer.name}'s Turn. Type 'A' for Attack or 'V' to View Own Board");
                string input = Console.ReadLine();
                switch (input)
                {
                    case "":
                        goto case "A";
                    case "a":
                        goto case "A";
                    case "A":
                        currentplayer.targetBoard.DisplayBoard("Where would you like to attack?");
                        int[] coordinates = currentplayer.AimAttack(currentplayer.targetBoard);
                        bool hit = ResolveAttack(currentplayer, currentopponent, coordinates[0], coordinates[1]);
                        if (hit)
                        {
                            currentplayer.score++;
                        }
                        keepGoing = false;
                        break;
                    case "v":
                        goto case "V";
                    case "V":
                        currentplayer.myBoard.DisplayBoard($"These are your ships. You have {currentplayer.score} points.");
                        Console.ReadLine();
                        Console.Clear();
                        break;
                }
            }
            while (keepGoing);
        }

        public bool ResolveAttack(Player currentplayer, Player currentopponent, int x, int y)
        {
            bool hit = false;
            Piece hitShip = null;

            if (currentopponent.myBoard.layout[x, y] == "[D]")
            {
                hitShip = currentopponent.destroyer;
                hit = true;
            }
            else if (currentopponent.myBoard.layout[x, y] == "[S]")
            {
                hitShip = currentopponent.sub;
                hit = true;
            }
            else if (currentopponent.myBoard.layout[x, y] == "[B]")
            {
                hitShip = currentopponent.bShip;
                hit = true;
            }
            else if (currentopponent.myBoard.layout[x, y] == "[C]")
            {
                hitShip = currentopponent.carrier;
                hit = true;
            }

            if (hit)
            {
                ResolveHit(currentplayer, currentopponent, x, y, hitShip);
            }
            else
            {
                currentopponent.myBoard.layout[x, y] = "[M]";
                currentplayer.targetBoard.layout[x, y] = "[M]";
                Console.WriteLine("Miss!");
            }
            Console.ReadLine();
            Console.Clear();

            return hit;
        }

        public void ResolveHit(Player currentplayer, Player currentopponent, int x, int y, Piece hitShip)
        {
            currentopponent.myBoard.layout[x, y] = "[X]";
            currentplayer.targetBoard.layout[x, y] = "[X]";
            hitShip.hitPointCounter--;
            if (hitShip.hitPointCounter == 0)
            {
                Console.WriteLine($"Hit! {currentplayer.name} has sunk {currentopponent.name}'s {hitShip.name}");
            }
            else
            {
                Console.WriteLine("Hit!");
            }
        }

        public void GameOver()
        {
            if (player1.score > player2.score)
            {
                Console.WriteLine($"{player1.name} wins!");
                Console.ReadLine();
            }
            else
            {
                Console.WriteLine($"{player2.name} wins!");
                Console.ReadLine();
            }
        }
    }

}
