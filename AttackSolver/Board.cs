using System.Collections.Generic;
using System.Drawing;

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
            Grid = new Cell[boardSize.Width, boardSize.Height];
            for (int i = 0; i < boardSize.Width; i++)
            {
                for (int j = 0; j < boardSize.Height; j++)
                {
                    Grid[i, j] = new Cell(i, j);
                }
            }
        }

        void FillBoard(IEnumerable<Point> obstacles)
        {
            foreach (var obstacle in obstacles)
            {
                if (!(IsValidPoint(obstacle.X, obstacle.Y)))
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
    }
}
