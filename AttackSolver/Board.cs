using System.Collections.Generic;
using System.Drawing;
using System;

namespace AttackSolver
{
    public class Board
    {
        public Board(Size boardSize, IEnumerable<Point> obstacles )
        {
            CreateBoard(boardSize);
            FillBoard(obstacles);
        }

        public Cell[,] Grid { get; set; }

        void CreateBoard(Size boardSize)
        {
            if(boardSize != null && !boardSize.IsEmpty && boardSize.Width > 0 && boardSize.Height > 0)
            {
                Grid = new Cell[boardSize.Width, boardSize.Height];
                for (int i = 0; i < boardSize.Width; i++)
                {
                    for (int j = 0; j < boardSize.Height; j++)
                    {
                        Grid[i, j] = new Cell(i, j);
                    }
                }
            }
            else
            {
                throw new ArgumentException("invalid board size");
            }
        }

        void FillBoard(IEnumerable<Point> obstacles)
        {
            foreach (var obstacle in obstacles)
            {
                if (IsValidPoint(obstacle.X-1, obstacle.Y-1))
                    Grid[obstacle.X-1, obstacle.Y-1].IsObstacle = true;
            }
        }

        public bool IsValidPoint(int x, int y)
        {
            if (x < 0 || x >= Grid.GetLength(0) || y < 0 || y >= Grid.GetLength(1))
            {
                return false;
            }
            else if (Grid[x, y].IsObstacle)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        public bool IsValidPoint(Point point) => IsValidPoint(point.X, point.Y);
    }
}
