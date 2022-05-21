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
            _start.X = start.X-1;
            _start.Y = start.Y-1;
        }

        bool CanMove(Point point)
        {
            if (point.X < 0 || point.X >= _board.Grid.GetLength(0) || point.Y < 0 || point.Y >= _board.Grid.GetLength(1))
            {
                return false;
            }
            else if(_board.Grid[point.X, point.Y].IsObstacle)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public List<Point> GetMoves()
        {
            List<Point> res = new List<Point>();

            var point = new Point(_start.X + 2, _start.Y + 1);
            if(CanMove(point))
            {
                res.Add(point);
            }
            point = new Point(_start.X + 2, _start.Y - 1);
            if (CanMove(point))
            {
                res.Add(point);
            }
            point = new Point(_start.X - 2, _start.Y + 1);
            if (CanMove(point))
            {
                res.Add(point);
            }
            point = new Point(_start.X - 2, _start.Y - 1);
            if (CanMove(point))
            {
                res.Add(point);
            }
            point = new Point(_start.X + 1, _start.Y + 2);
            if (CanMove(point))
            {
                res.Add(point);
            }
            point = new Point(_start.X + 1, _start.Y - 2);
            if (CanMove(point))
            {
                res.Add(point);
            }
            point = new Point(_start.X - 1, _start.Y + 2);
            if (CanMove(point))
            {
                res.Add(point);
            }
            point = new Point(_start.X - 1, _start.Y - 2);
            if (CanMove(point))
            {
                res.Add(point);
            }

            return res;
        }
    }
}
