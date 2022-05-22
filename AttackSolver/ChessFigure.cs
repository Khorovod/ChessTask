using System.Drawing;

namespace AttackSolver
{
    public abstract class ChessFigure
    {

        private readonly Board _board;

        public ChessFigure(Board board)
        {
            _board = board;
        }

        protected virtual bool CanMoveTo(int x, int y)
        {
            if (x < 0 || x >= _board.Grid.GetLength(0) || y < 0 || y >= _board.Grid.GetLength(1))
            {
                return false;
            }
            else if (_board.Grid[x, y].IsObstacle)
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
