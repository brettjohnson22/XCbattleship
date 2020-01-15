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
        }
        //member methods (CAN DO)
        public void RunGame()
        {
            Console.WriteLine("Welcome to Battleship! By Brett Johnson");
            Console.ReadLine();
            player1 = new Player();
            player2 = new Player();
            ResizeWindow();
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
            Console.SetWindowSize(70, 25);
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
            if (currentopponent.myBoard.layout[x, y] == "[D]")
            {
                currentopponent.myBoard.layout[x, y] = "[X]";
                currentplayer.targetBoard.layout[x, y] = "[X]";
                currentopponent.destroyer.hitPointCounter--;
                if (currentopponent.destroyer.hitPointCounter == 0)
                {
                    Console.WriteLine($"Hit! {currentplayer.name} has sunk {currentopponent.name}'s Destroyer!");
                }
                else
                {
                    Console.WriteLine("Hit!");
                }
                hit = true;
                Console.ReadLine();
                Console.Clear();
            }
            else if (currentopponent.myBoard.layout[x, y] == "[S]")
            {
                currentopponent.myBoard.layout[x, y] = "[X]";
                currentplayer.targetBoard.layout[x, y] = "[X]";
                currentopponent.sub.hitPointCounter--;
                if (currentopponent.sub.hitPointCounter == 0)
                {
                    Console.WriteLine($"Hit! {currentplayer.name} has sunk {currentopponent.name}'s Submarine!");
                }
                else
                {
                    Console.WriteLine("Hit!");
                }
                hit = true;
                Console.ReadLine();
                Console.Clear();
            }
            else if (currentopponent.myBoard.layout[x, y] == "[B]")
            {
                currentopponent.myBoard.layout[x, y] = "[X]";
                currentplayer.targetBoard.layout[x, y] = "[X]";
                currentopponent.bShip.hitPointCounter--;
                if (currentopponent.bShip.hitPointCounter == 0)
                {
                    Console.WriteLine($"Hit! {currentplayer.name} has sunk {currentopponent.name}'s Battleship!");
                }
                else
                {
                    Console.WriteLine("Hit!");
                }
                hit = true;
                Console.ReadLine();
                Console.Clear();
            }
            else if (currentopponent.myBoard.layout[x, y] == "[C]")
            {
                currentopponent.myBoard.layout[x, y] = "[X]";
                currentplayer.targetBoard.layout[x, y] = "[X]";
                currentopponent.carrier.hitPointCounter--;
                if (currentopponent.carrier.hitPointCounter == 0)
                {
                    Console.WriteLine($"Hit! {currentplayer.name} has sunk {currentopponent.name}'s Aircraft Carrier!");
                }
                else
                {
                    Console.WriteLine("Hit!");
                }
                hit = true;
                Console.ReadLine();
                Console.Clear();
            }
            else 
            {
                currentopponent.myBoard.layout[x, y] = "[M]";
                currentplayer.targetBoard.layout[x, y] = "[M]";
                Console.WriteLine("Miss!");
                Console.ReadLine();
                Console.Clear();
            }
            return hit;
        }
        public void GameOver()
        {
            if(player1.score > player2.score)
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
