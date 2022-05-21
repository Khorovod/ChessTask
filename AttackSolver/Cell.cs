using System;
using System.Collections.Generic;
using System.Text;

namespace AttackSolver
{
    public class Cell
    {
        public Cell(int row, int column)
        {
            Row = row;
            Col = column;
        }

        public int Row { get; set; }
        public int Col { get; set; }
        public bool IsObstacle { get; set; }
    }
}
