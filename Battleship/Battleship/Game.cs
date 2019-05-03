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
            Console.WriteLine($"{currentplayer.name}'s Turn");
            Console.ReadLine();
            currentplayer.targetBoard.DisplayBoard("Where would you like to attack?");
            int[] coordinates = currentplayer.AimAttack(currentplayer.targetBoard);
            ResolveAttack(currentopponent.myBoard, currentplayer.targetBoard, coordinates[0], coordinates[1]);
        }
        public void RunGame()
        {
            player1 = new Player();
            player2 = new Player();
            GetPlayerNames();
           // ResizeWindow();
            SetBoard(player1);
            SetBoard(player2);
            PlayerTurn(player1, player2);
            PlayerTurn(player2, player1);
            PlayerTurn(player1, player2);
            PlayerTurn(player2, player1);

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
        public void ResolveAttack(Board boardBeingAttacked, Board playersTargetBoard, int x, int y)
        {
            if (boardBeingAttacked.layout[x, y] == '0')
            {
                boardBeingAttacked.layout[x, y] = 'X';
                playersTargetBoard.layout[x, y] = 'X';
                Console.WriteLine("Hit!");
                Console.ReadLine();
            }
            else
            {
                boardBeingAttacked.layout[x, y] = 'M';
                playersTargetBoard.layout[x, y] = 'M';
                Console.WriteLine("Miss!");
                Console.ReadLine();
            }
        }
    }

}
