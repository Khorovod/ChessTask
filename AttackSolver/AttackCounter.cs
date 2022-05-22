using Interface;
using System.Drawing;
using System;

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
                    return new Rook(board, startCoords).GetMoves().Count;
                case ChessmanType.Bishop:
                    return new Bishop(board, startCoords).GetMoves().Count;
                case ChessmanType.Knight:
                    return new Knight(board, startCoords).GetMoves().Count;
                default:
                    throw new NotImplementedException($"'{cmType}' not supported yet");
            }
        }

    }
}
