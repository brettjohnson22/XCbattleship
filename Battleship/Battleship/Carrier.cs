using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleship
{
    public class Carrier : Piece
    {
        public Carrier()
        {
            pieceSize = 5;
            name = "Carrier";
            identifier = "[C]";
            hitPointCounter = 5;
        }
    }
}
