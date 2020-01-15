using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleship
{
    public class Destroyer : Piece
    {
        public Destroyer()
        {
            pieceSize = 2;
            name = "Destroyer";
            identifier = "[D]";
            hitPointCounter = 2;
        }
    }
}
