using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleship
{
    public class Sub : Piece
    {
        public Sub()
        {
            pieceSize = 3;
            name = "Submarine";
            identifier = "[S]";
            hitPointCounter = 3;
        }
    }
}
