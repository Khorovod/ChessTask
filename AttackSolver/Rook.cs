using Interface;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace AttackSolver
{
    public class Rook : ChessFigure, IChessman
    {
        private readonly Point _start;

        public Rook(Board board, Point start) : base(board)
        {
            _start.X = start.X - 1;
            _start.Y = start.Y - 1;
        }


        public List<Point> GetMoves()
        {
            List<Point> res = new List<Point>();

            int s = 1;
            while(CanMoveTo(_start.X + s, _start.Y))
            {
                res.Add(new Point(_start.X + s, _start.Y));
                s++;
            }

            s = 1;
            while (CanMoveTo(_start.X - s, _start.Y))
            {
                res.Add(new Point(_start.X - s, _start.Y));
                s++;
            }

            s = 1;
            while (CanMoveTo(_start.X, _start.Y + s))
            {
                res.Add(new Point(_start.X, _start.Y + s));
                s++;
            }

            s = 1;
            while (CanMoveTo(_start.X, _start.Y - s))
            {
                res.Add(new Point(_start.X, _start.Y - s));
                s++;
            }

            return res;
        }
    }
}
