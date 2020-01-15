using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleship
{
    public abstract class Piece
    {
        public int pieceSize;
        public bool horizontal;
        public string name;
        public string identifier;
        public int hitPointCounter;

        public Piece()
        {
            horizontal = true;
        }
    }
}
