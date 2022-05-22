using Interface;
using System.Collections.Generic;
using System.Drawing;

namespace AttackSolver
{
    public class Knight : ChessFigure, IChessman
    {
        private readonly Point _start;

        public Knight(Board board, Point start) : base(board)
        {
            _start.X = start.X-1;
            _start.Y = start.Y-1;
        }

        public List<Point> GetMoves()
        {
            List<Point> res = new List<Point>();

            var point = new Point(_start.X + 2, _start.Y + 1);
            if(CanMoveTo(point.X, point.Y))
            {
                res.Add(point);
            }
            point = new Point(_start.X + 2, _start.Y - 1);
            if (CanMoveTo(point.X, point.Y))
            {
                res.Add(point);
            }
            point = new Point(_start.X - 2, _start.Y + 1);
            if (CanMoveTo(point.X, point.Y))
            {
                res.Add(point);
            }
            point = new Point(_start.X - 2, _start.Y - 1);
            if (CanMoveTo(point.X, point.Y))
            {
                res.Add(point);
            }
            point = new Point(_start.X + 1, _start.Y + 2);
            if (CanMoveTo(point.X, point.Y))
            {
                res.Add(point);
            }
            point = new Point(_start.X + 1, _start.Y - 2);
            if (CanMoveTo(point.X, point.Y))
            {
                res.Add(point);
            }
            point = new Point(_start.X - 1, _start.Y + 2);
            if (CanMoveTo(point.X, point.Y))
            {
                res.Add(point);
            }
            point = new Point(_start.X - 1, _start.Y - 2);
            if (CanMoveTo(point.X, point.Y))
            {
                res.Add(point);
            }

            return res;
        }
    }
}
