﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleship
{
    public class Player
    {
        public string name;
        public Board myBoard;
        public Board targetBoard; 
        public Piece destroyer;
        public Piece sub;
        public Piece bShip;
        public Piece carrier;
        public int score;

        public Player()
        {
            score = 0;
        }

        public void CreateBoards()
        {
            myBoard = new Board();
            myBoard.GenerateBoard();
            targetBoard = new Board();
            targetBoard.GenerateBoard();
        }
        public void PlaceDestroyer()
        {
            destroyer = new Destroyer();
            myBoard.PlacePiece(destroyer);
        }
        public void PlaceSub()
        {
            sub = new Sub();
            myBoard.PlacePiece(sub);
        }
        public void PlaceBattleship()
        {
            bShip = new BShip();
            myBoard.PlacePiece(bShip);
        }
        public void PlaceCarrier()
        {
            carrier = new Carrier();
            myBoard.PlacePiece(carrier);
        }
        public int[] AimAttack(Board mytargetboard)
        {
            int[] coordinates = new int[2];
            int x = 1;
            int y = 1;
            bool KeepGoing = true;
            for(int i = 1; mytargetboard.layout[x, y] != "[ ]"; i++)
            {
                if (y == 21)
                {
                    x++;
                    y = 1;
                }
                else
                {
                    y++;
                }
            }
            mytargetboard.layout[x, y] = "[+]";
            do
            {
                
                mytargetboard.DisplayBoard($"Where do you want to attack?");
                ConsoleKey buttonPress = Console.ReadKey().Key;
                if (buttonPress == ConsoleKey.RightArrow)
                {
                    bool moved = MoveCursorRight(mytargetboard, x, y);
                    if (moved)
                    {
                        y++;
                    }
                }
                else if (buttonPress == ConsoleKey.LeftArrow)
                {
                    bool moved = MoveCursorLeft(mytargetboard, x, y);
                    if (moved)
                    {
                        y--;
                    }
                }
                else if (buttonPress == ConsoleKey.UpArrow)
                {
                    bool moved = MoveCursorUp(mytargetboard, x, y);
                    if (moved)
                    {
                        x--;
                    }
                }
                else if (buttonPress == ConsoleKey.DownArrow)
                {
                    bool moved = MoveCursorDown(mytargetboard, x, y);
                    if (moved)
                    {
                        x++;
                    }
                }
                else if (buttonPress == ConsoleKey.Enter)
                {
                    coordinates[0] = x;
                    coordinates[1] = y;
                    KeepGoing = false;
                }
            }
            while (KeepGoing);
            return coordinates;
        }
        public bool MoveCursorRight(Board mytargetboard, int a, int b)
        {
            bool moved = false;
            if (mytargetboard.layout[a, b + 1] == "[ ]")
            {
                mytargetboard.layout[a, b] = "[ ]";
                mytargetboard.layout[a, b + 1] = "[+]";
                moved = true;
            }
            return moved;
        }
        public bool MoveCursorLeft(Board mytargetboard, int a, int b)
        {
            bool moved = false;
            if (mytargetboard.layout[a, b - 1] == "[ ]")
            {
                mytargetboard.layout[a, b] = "[ ]";
                mytargetboard.layout[a, b - 1] = "[+]";
                moved = true;
            }
            return moved;
        }
        public bool MoveCursorUp(Board mytargetboard, int a, int b)
        {
            bool moved = false;
            if (mytargetboard.layout[a - 1, b] == "[ ]")
            {
                mytargetboard.layout[a, b] = "[ ]";
                mytargetboard.layout[a - 1, b] = "[+]";
                moved = true;
            }
            return moved;
        }
        public bool MoveCursorDown(Board mytargetboard, int a, int b)
        {
            bool moved = false;
            if (mytargetboard.layout[a + 1, b] == "[ ]")
            {
                mytargetboard.layout[a, b] = "[ ]";
                mytargetboard.layout[a + 1, b] = "[+]";
                moved = true;
            }
            return moved;
        }
    }
}

