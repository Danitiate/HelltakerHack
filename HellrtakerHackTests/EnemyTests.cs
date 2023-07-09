using HelltakerHack;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HelltakerHackTests
{
    [TestClass]
    public class EnemyTests
    {
        [TestMethod]
        public void MoveEnemy()
        {
            var grid = GridHelper.SetupGrid("1 1 1 1 1\n" +
                                 "1 1 2 1 1\n" +
                                 "1 8 3 1 1\n" +
                                 "1 1 9 1 1\n" +
                                 "1 1 1 1 1");
            var sut = new Solver(grid);
            var actual = sut.SolvePuzzle(2);
            var expected = "↑ ↑ ";
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void KillEnemy()
        {
            var grid = GridHelper.SetupGrid("1 1 1 1 1\n" +
                                 "1 1 1 1 1\n" +
                                 "1 8 3 1 1\n" +
                                 "1 1 9 1 1\n" +
                                 "1 1 1 1 1");
            var sut = new Solver(grid);
            var actual = sut.SolvePuzzle(2);
            var expected = "↑ ↑ ";
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void MoveAndKillEnemy()
        {
            var grid = GridHelper.SetupGrid("1 1 1 1 1\n" +
                                 "1 8 2 1 1\n" +
                                 "1 1 3 1 1\n" +
                                 "1 1 9 1 1\n" +
                                 "1 1 1 1 1");
            var sut = new Solver(grid);
            var actual = sut.SolvePuzzle(4);
            var expected = "↑ ↑ ↑ ↑ ";
            Assert.AreEqual(expected, actual);
        }
    }
}
