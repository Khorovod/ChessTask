using Interface;
using System.Collections.Generic;
using System.Drawing;

namespace AttackSolver
{
    public class Knight : IChessman
    {
        private readonly Point _start;
        private readonly Board _board;

        public Knight(Board board, Point start)
        {
            ValidatePoint.GraterThanZero(start);
            _start.X = start.X-1;
            _start.Y = start.Y-1;
            _board = board;
        }

        public List<Point> GetMoves()
        {
            List<Point> res = new List<Point>();

            var point = new Point(_start.X + 2, _start.Y + 1);
            if(_board.IsValidPoint(point))
            {
                res.Add(point);
            }
            point = new Point(_start.X + 2, _start.Y - 1);
            if (_board.IsValidPoint(point))
            {
                res.Add(point);
            }
            point = new Point(_start.X - 2, _start.Y + 1);
            if (_board.IsValidPoint(point))
            {
                res.Add(point);
            }
            point = new Point(_start.X - 2, _start.Y - 1);
            if (_board.IsValidPoint(point))
            {
                res.Add(point);
            }
            point = new Point(_start.X + 1, _start.Y + 2);
            if (_board.IsValidPoint(point))
            {
                res.Add(point);
            }
            point = new Point(_start.X + 1, _start.Y - 2);
            if (_board.IsValidPoint(point))
            {
                res.Add(point);
            }
            point = new Point(_start.X - 1, _start.Y + 2);
            if (_board.IsValidPoint(point))
            {
                res.Add(point);
            }
            point = new Point(_start.X - 1, _start.Y - 2);
            if (_board.IsValidPoint(point))
            {
                res.Add(point);
            }

            return res;
        }
    }
}
