using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleship
{
    public class Destroyer : Piece
    {
        //member variables (HAS A)

        //constructor (SPAWNER)
        public Destroyer()
        {
            pieceSize = 2;
            name = "Destroyer";
            identifier = "[D]";
            hitPointCounter = 2;
        }
        //member methods (CAN DO)
    }
}
