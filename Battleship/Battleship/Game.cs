using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleship
{
    class Game
    {
        public void ResizeWindow()
        {
            Console.SetWindowSize(30, 30);
            Console.WriteLine(Console.WindowWidth);
            Console.WriteLine(Console.WindowHeight);
            
        }
    }
}
