using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleship
{
    public class Sub : Piece
    {
        //member variables (HAS A)

        //constructor (SPAWNER)
        public Sub()
        {
            pieceSize = 3;
            name = "Submarine";
            identifier = 'S';
            hitPointCounter = 3;
        }
        //member methods (CAN DO)
    }
}
