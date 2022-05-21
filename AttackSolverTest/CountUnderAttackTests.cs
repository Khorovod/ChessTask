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
                    new [] { new Point(2, 2), new Point(1, 3)  });
                Assert.Equal(2, res);

                // Bishop - slon
                res = inst.CountUnderAttack(ChessmanType.Bishop, new Size(4, 5), new Point(2, 2),
                    new [] {new Point(1, 2), new Point(4, 5), });
                Assert.Equal(3, res);
            }
        }

        [Fact]
        public void KnightCenter()
        {
            var inst = FindImplementations().First();

            var res = inst.CountUnderAttack(ChessmanType.Knight, new Size(5, 5), new Point(3, 3),
                new[] { new Point(1, 2), new Point(4, 5) });
            Assert.Equal(6, res);

        }
        [Fact]
        public void KnightCornerIncorrectObstacle()
        {
            var inst = FindImplementations().First();

            var res = inst.CountUnderAttack(ChessmanType.Knight, new Size(3, 4), new Point(1, 1),
                new[] { new Point(1, 2), new Point(4, 5), new Point(3, 2) });
            Assert.Equal(1, res);

        }
        [Fact]
        public void KnightCornerObstacleIsStart()
        {
            var inst = FindImplementations().First();

            var res = inst.CountUnderAttack(ChessmanType.Knight, new Size(4, 4), new Point(1, 2),
                new[] { new Point(1, 2) });
            Assert.Equal(3, res);

        }
        IList<IAttackCounter> FindImplementations()
        {
            return AppDomain.CurrentDomain.GetAssemblies()
                .SelectMany(s => s.GetTypes())
                .Where(mytype => mytype.GetInterfaces().Contains(typeof(IAttackCounter)))
                .Select(type => (IAttackCounter) Activator.CreateInstance(type)).ToList();
        }
    }
}
