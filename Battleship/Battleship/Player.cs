using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleship
{
    public class Player
    {
        //member variables (HAS A)
        public string name;
        public Board myBoard;
        public Board targetBoard;
        public Piece destroyer;
        public Piece sub;
        public Piece bShip;
        public Piece carrier;

        //constructor (SPAWNER)
        public Player()
        {

        }
        //member methods (CAN DO)
        public void CreateBoard()
        {
            myBoard = new Board();
            myBoard.GenerateBoard();
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
        public void LaunchAttack(Board EnemyBoard, int x, int y)
        {

        }
    }
}
