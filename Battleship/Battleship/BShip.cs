using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleship
{
    public class BShip : Piece
    {
        public BShip()
        {
            pieceSize = 4;
            name = "Battleship";
            identifier = "[B]";
            hitPointCounter = 4;
        }
    }
}
