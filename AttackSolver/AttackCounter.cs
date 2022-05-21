using Interface;
using System.Drawing;

namespace AttackSolver
{
    public class MyAttackCounter : IAttackCounter
    {
        public int CountUnderAttack(ChessmanType cmType, Size boardSize, Point startCoords, Point[] obstacles)
        {
            var board = new Board(boardSize, obstacles);

            switch (cmType)
            {
                case ChessmanType.Rook:

                    break;
                case ChessmanType.Bishop:

                    break;
                case ChessmanType.Knight:
                    return new Knight(board, startCoords).GetMoves().Count;
                default:
                    break;
            }
            return 0;
        }

    }
}
