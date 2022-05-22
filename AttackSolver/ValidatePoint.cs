using System.Drawing;
using System;

namespace AttackSolver
{
    static class ValidatePoint
    {

        public static void GraterThanZero(Point point)
        {
            if(point.X <= 0 && point.Y <= 0)
            {
                throw new ArgumentException($"invalid point '{point}'");
            }
        }

    }
}
