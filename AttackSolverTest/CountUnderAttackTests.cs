using Interface;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using Xunit;
using Xunit.Abstractions;

namespace AttackSolverTest
{
    public class CountUnderAttackTests
    {
        private readonly ITestOutputHelper output;

        public CountUnderAttackTests(ITestOutputHelper output)
        {
            this.output = output;
        }

        [Fact]
        [Trait("Figure", "Rook")]
        [Trait("Figure", "Bishop")]
        public void Test1()
        {
            var insts = FindImplementations();
            if (insts.Count == 0)
                throw new Exception(
                    "No implementation of IAttackCounter was found, make sure you add a reference to your project to AttackSolverTest");

            foreach (var inst in insts)
            {
                output.WriteLine("Testing " + inst.GetType().FullName);
                // Rook - ladja
                var res = inst.CountUnderAttack(ChessmanType.Rook, new Size(3, 2), new Point(1, 1),
                    new[] { new Point(2, 2), new Point(3, 1) });
                Assert.Equal(2, res);

                // Bishop - slon
                res = inst.CountUnderAttack(ChessmanType.Bishop, new Size(4, 5), new Point(2, 2),
                    new[] { new Point(3, 3), new Point(1, 3), });
                Assert.Equal(2, res);
            }
        }

        [Fact]
        [Trait("Board", "Size")]
        public void BoardIsZeroSize()
        {
            var inst = FindImplementations().Single();

            try
            {
                var res = inst.CountUnderAttack(ChessmanType.Bishop, new Size(0, 0), new Point(3, 2),
                        new[] { new Point(2, 1) });
            }
            catch (ArgumentException ex)
            {
                Assert.Equal("invalid board size", ex.Message);
            }


        }
        [Fact]
        [Trait("Board", "Size")]
        public void BoardSizeIsInvalid()
        {
            var inst = FindImplementations().Single();
            try
            {
                var res = inst.CountUnderAttack(ChessmanType.Bishop, new Size(-4, -4), new Point(3, 2),
                        new[] { new Point(2, 1) });
            }
            catch (ArgumentException ex)
            {
                Assert.Equal("invalid board size", ex.Message);
            }
        }
        [Fact]
        [Trait("StartPoint", "Point")]
        public void StartPositionInvalid()
        {
            var inst = FindImplementations().Single();
            var startPoint = new Point(0, -2);
            try
            {
                var res = inst.CountUnderAttack(ChessmanType.Knight, new Size(4, 4), startPoint,
                    new[] { new Point(2, 1) });
            }
            catch (ArgumentException ex)
            {
                Assert.Equal($"invalid point '{startPoint}'", ex.Message);
            }
        }
        [Fact]
        [Trait("Figure", "Knight")]
        public void KnightCenter()
        {
            var inst = FindImplementations().Single();

            var res = inst.CountUnderAttack(ChessmanType.Knight, new Size(5, 5), new Point(3, 3),
                new[] { new Point(1, 2), new Point(4, 5) });
            Assert.Equal(6, res);

        }
        [Fact]
        [Trait("Figure", "Knight")]
        public void KnightCornerIncorrectObstacle()
        {
            var inst = FindImplementations().Single();

            var res = inst.CountUnderAttack(ChessmanType.Knight, new Size(3, 4), new Point(1, 1),
                new[] { new Point(1, 2), new Point(4, 5), new Point(3, 2) });
            Assert.Equal(1, res);

        }
        [Fact]
        [Trait("Figure", "Knight")]
        public void KnightCornerObstacleIsStart()
        {
            var inst = FindImplementations().Single();

            var res = inst.CountUnderAttack(ChessmanType.Knight, new Size(4, 4), new Point(1, 2),
                new[] { new Point(1, 2) });
            Assert.Equal(3, res);

        }
        [Fact]
        [Trait("Figure", "Knight")]
        public void KnightZero()
        {
            var inst = FindImplementations().Single();

            var size = new Size(2, 2);
            var start = new Point(1, 1);
            var obstacles = new[] { new Point(1, 1) };

            var res = inst.CountUnderAttack(ChessmanType.Knight, size, start, obstacles);
            Assert.Equal(0, res);

        }
        //[Fact]
        [Fact(Skip = "too slow")]
        [Trait("Figure", "Knight")]
        public void KnigthBig()
        {
            var inst = FindImplementations().Single();

            var size = new Size(10000, 10000);
            var start = new Point(5000, 5000);
            var obstacles = new[] { new Point(10, 13), new Point(8, 13), new Point(8, 15), new Point(9, 15) };

            var res = inst.CountUnderAttack(ChessmanType.Knight, size, start, obstacles);
            Assert.Equal(8, res);

        }

        [Fact]
        [Trait("Figure", "Rook")]
        public void RookCenter()
        {
            var inst = FindImplementations().Single();

            var size = new Size(4, 4);
            var start = new Point(2, 2);
            var obstacles = new[] { new Point(1, 1) };

            var res = inst.CountUnderAttack(ChessmanType.Rook, size, start, obstacles);
            Assert.Equal(6, res);

        }
        [Fact]
        [Trait("Figure", "Rook")]
        public void RookCenterWObstacle()
        {
            var inst = FindImplementations().Single();

            var size = new Size(4, 4);
            var start = new Point(2, 2);
            var obstacles = new[] { new Point(4, 2) };

            var res = inst.CountUnderAttack(ChessmanType.Rook, size, start, obstacles);
            Assert.Equal(5, res);

        }
        [Fact]
        [Trait("Figure", "Rook")]
        public void RookCenterWObstaclesAround()
        {
            var inst = FindImplementations().Single();

            var size = new Size(5, 5);
            var start = new Point(3, 3);
            var obstacles = new[] { new Point(1, 3), new Point(3, 1), new Point(3, 5), new Point(5, 3) };

            var res = inst.CountUnderAttack(ChessmanType.Rook, size, start, obstacles);
            Assert.Equal(4, res);

        }
        [Fact]
        [Trait("Figure", "Rook")]
        public void RookCorner()
        {
            var inst = FindImplementations().Single();

            var size = new Size(3, 2);
            var start = new Point(3, 2);
            var obstacles = new[] { new Point(2, 1) };

            var res = inst.CountUnderAttack(ChessmanType.Rook, size, start, obstacles);
            Assert.Equal(3, res);

        }

        [Fact]
        [Trait("Figure", "Bishop")]
        public void BishopCenter()
        {
            var inst = FindImplementations().Single();

            var size = new Size(5, 5);
            var start = new Point(3, 3);
            var obstacles = new[] { new Point(3, 1), new Point(4, 3), new Point(3, 4) };

            var res = inst.CountUnderAttack(ChessmanType.Bishop, size, start, obstacles);
            Assert.Equal(8, res);

        }
        [Fact]
        [Trait("Figure", "Bishop")]
        public void BishopCorner()
        {
            var inst = FindImplementations().Single();

            var size = new Size(10, 15);
            var start = new Point(10, 15);
            var obstacles = new[] { new Point(5, 1), new Point(3, 2), new Point(10, 14), new Point(9, 15) };

            var res = inst.CountUnderAttack(ChessmanType.Bishop, size, start, obstacles);
            Assert.Equal(9, res);

        }
        [Fact]
        [Trait("Figure", "Bishop")]
        public void BishopCornerObstacles()
        {
            var inst = FindImplementations().Single();

            var size = new Size(10, 15);
            var start = new Point(9, 14);
            var obstacles = new[] { new Point(10, 13), new Point(8, 13), new Point(8, 15), new Point(9, 15) };

            var res = inst.CountUnderAttack(ChessmanType.Bishop, size, start, obstacles);
            Assert.Equal(1, res);

        }
        //[Fact]
        [Fact(Skip = "too slow")]
        [Trait("Figure", "Bishop")]
        public void BishopBig()
        {
            var inst = FindImplementations().Single();

            var size = new Size(10000, 10000);
            var start = new Point(5000, 5000);
            var obstacles = new[] { new Point(10, 13), new Point(8, 13), new Point(8, 15), new Point(9, 15) };

            var res = inst.CountUnderAttack(ChessmanType.Bishop, size, start, obstacles);
            Assert.Equal(19997, res);

        }

        IList<IAttackCounter> FindImplementations()
        {
            return AppDomain.CurrentDomain.GetAssemblies()
                .SelectMany(s => s.GetTypes())
                .Where(mytype => mytype.GetInterfaces().Contains(typeof(IAttackCounter)))
                .Select(type => (IAttackCounter)Activator.CreateInstance(type)).ToList();
        }
    }
}
