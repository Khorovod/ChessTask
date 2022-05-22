using Interface;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace AttackSolver
{
    public class Bishop : ChessFigure, IChessman
    {
        private readonly Point _start;

        public Bishop(Board board, Point start) : base(board)
        {
            _start.X = start.X - 1;
            _start.Y = start.Y - 1;
        }

        public List<Point> GetMoves()
        {
            throw new NotImplementedException();
        }
    }
}
