using Interface;
using System.Collections.Generic;
using System.Drawing;
using System;

namespace AttackSolver
{
    public class Bishop : IChessman
    {
        private readonly Point _start;
        private readonly Board _board;

        public Bishop(Board board, Point start)
        {
            _board = board;
            ValidatePoint.GraterThanZero(start);
            _start.X = start.X - 1;
            _start.Y = start.Y - 1;
        }

        public List<Point> GetMoves()
        {
            List<Point> res = new List<Point>();

            int s = 1;
            while (_board.IsValidPoint(_start.X + s, _start.Y + s))
            {
                res.Add(new Point(_start.X + s, _start.Y + s));
                s++;
            }

            s = 1;
            while (_board.IsValidPoint(_start.X + s, _start.Y - s))
            {
                res.Add(new Point(_start.X + s, _start.Y - s));
                s++;
            }

            s = 1;
            while (_board.IsValidPoint(_start.X - s, _start.Y + s))
            {
                res.Add(new Point(_start.X - s, _start.Y + s));
                s++;
            }

            s = 1;
            while (_board.IsValidPoint(_start.X - s, _start.Y - s))
            {
                res.Add(new Point(_start.X - s, _start.Y - s));
                s++;
            }
            return res;
        }
    }
}
