using System.Linq;
using Interface;
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
                Grid[obstacle.X, obstacle.Y].IsObstacle = true;
            }
        }

    }
}
