using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleship
{
    public abstract class Piece
    {
        //member variables (HAS A)
        public int pieceSize;
        public bool horizontal;
        public string name;

        //constructor (SPAWNER)
        public Piece()
        {
            horizontal = true;
        }
        //member methods (CAN DO)
    }
}
