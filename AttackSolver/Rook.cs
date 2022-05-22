using Interface;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace AttackSolver
{
    public class Rook : IChessman
    {
        private readonly Point _start;
        private readonly Board _board;

        public Rook(Board board, Point start)
        {
            _start.X = start.X - 1;
            _start.Y = start.Y - 1;
            _board = board;
        }


        public List<Point> GetMoves()
        {
            List<Point> res = new List<Point>();

            int s = 1;
            while(_board.IsValidPoint(_start.X + s, _start.Y))
            {
                res.Add(new Point(_start.X + s, _start.Y));
                s++;
            }

            s = 1;
            while (_board.IsValidPoint(_start.X - s, _start.Y))
            {
                res.Add(new Point(_start.X - s, _start.Y));
                s++;
            }

            s = 1;
            while (_board.IsValidPoint(_start.X, _start.Y + s))
            {
                res.Add(new Point(_start.X, _start.Y + s));
                s++;
            }

            s = 1;
            while (_board.IsValidPoint(_start.X, _start.Y - s))
            {
                res.Add(new Point(_start.X, _start.Y - s));
                s++;
            }

            return res;
        }
    }
}
