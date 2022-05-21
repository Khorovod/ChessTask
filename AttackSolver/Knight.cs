using Interface;
using System.Collections.Generic;
using System.Drawing;

namespace AttackSolver
{
    public class Knight : IChessman
    {
        private readonly Board _board;
        private readonly Point _start;

        public Knight(Board board, Point start)
        {
            _board = board;
            _start = start;
        }


        public List<Point> GetMoves()
        {
            List<Point> res = new List<Point>();

            return res;
        }
    }
}
