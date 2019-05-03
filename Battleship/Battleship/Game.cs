﻿using System;
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
            Console.WriteLine("Welcome to Battleship! By Brett Johnson");
            Console.ReadLine();
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
            AttackOptions(currentplayer, currentopponent);
            //Console.WriteLine($"{currentplayer.name}'s Turn.");
            //Console.ReadLine();
            //currentplayer.targetBoard.DisplayBoard("Where would you like to attack?");
            //int[] coordinates = currentplayer.AimAttack(currentplayer.targetBoard);
            //bool hit = ResolveAttack(currentopponent.myBoard, currentplayer.targetBoard, coordinates[0], coordinates[1]);
            //if(hit)
            //{
            //    currentplayer.score++;
            //}
        }
        public void RunGame()
        {
            player1 = new Player();
            player2 = new Player();
            GetPlayerNames();
            //ResizeWindow();
            SetBoard(player1);
            SetBoard(player2);
            while (player1.score < 14 && player2.score < 14)
            {
                PlayerTurn(player1, player2);
                PlayerTurn(player2, player1);
            }
            GameOver();
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
        public void AttackOptions(Player currentplayer, Player currentopponent)
        {
            bool keepGoing = true;
            do
            {
                Console.WriteLine($"{currentplayer.name}'s Turn. Type 'A' for Attack or 'V' to View Own Board");
                string input = Console.ReadLine();
                switch (input)
                {
                    case "a":
                        goto case "A";
                    case "A":
                        currentplayer.targetBoard.DisplayBoard("Where would you like to attack?");
                        int[] coordinates = currentplayer.AimAttack(currentplayer.targetBoard);
                        bool hit = ResolveAttack(currentopponent.myBoard, currentplayer.targetBoard, currentopponent, coordinates[0], coordinates[1]);
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
        public bool ResolveAttack(Board boardBeingAttacked, Board playersTargetBoard, Player currentopponent, int x, int y)
        {
            bool hit = false;
            if (boardBeingAttacked.layout[x, y] == 'D')
            {
                boardBeingAttacked.layout[x, y] = 'X';
                playersTargetBoard.layout[x, y] = 'X';
                currentopponent.destroyer.hitPointCounter--;
                if (currentopponent.destroyer.hitPointCounter == 0)
                {
                    Console.WriteLine($"Hit! {currentopponent.name}'s Destroyer has sunk!");
                }
                else
                {
                    Console.WriteLine("Hit!");
                }
                hit = true;
                Console.ReadLine();
                Console.Clear();
            }
            else if (boardBeingAttacked.layout[x, y] == 'S')
            {
                boardBeingAttacked.layout[x, y] = 'X';
                playersTargetBoard.layout[x, y] = 'X';
                currentopponent.sub.hitPointCounter--;
                if (currentopponent.sub.hitPointCounter == 0)
                {
                    Console.WriteLine($"Hit! {currentopponent.name}'s Submarine has sunk!");
                }
                else
                {
                    Console.WriteLine("Hit!");
                }
                hit = true;
                Console.ReadLine();
                Console.Clear();
            }
            else if (boardBeingAttacked.layout[x, y] == 'B')
            {
                boardBeingAttacked.layout[x, y] = 'X';
                playersTargetBoard.layout[x, y] = 'X';
                currentopponent.bShip.hitPointCounter--;
                if (currentopponent.bShip.hitPointCounter == 0)
                {
                    Console.WriteLine($"Hit! {currentopponent.name}'s Battleship has sunk!");
                }
                else
                {
                    Console.WriteLine("Hit!");
                }
                hit = true;
                Console.ReadLine();
                Console.Clear();
            }
            else if (boardBeingAttacked.layout[x, y] == 'C')
            {
                boardBeingAttacked.layout[x, y] = 'X';
                playersTargetBoard.layout[x, y] = 'X';
                currentopponent.carrier.hitPointCounter--;
                if (currentopponent.carrier.hitPointCounter == 0)
                {
                    Console.WriteLine($"Hit! {currentopponent.name}'s Aircraft Carrier has sunk!");
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
                boardBeingAttacked.layout[x, y] = 'M';
                playersTargetBoard.layout[x, y] = 'M';
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
