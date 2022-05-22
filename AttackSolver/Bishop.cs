using Interface;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace AttackSolver
{
    public class Bishop : IChessman
    {
        private readonly Point _start;
        private readonly Board _board;

        public Bishop(Board board, Point start)
        {
            _start.X = start.X - 1;
            _start.Y = start.Y - 1;
            _board = board;
        }

        public List<Point> GetMoves()
        {
            throw new NotImplementedException();
        }
    }
}
