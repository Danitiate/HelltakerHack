using HelltakerHack;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HelltakerHackTests
{
    [TestClass]
    public class RockTests
    {
        [TestMethod]
        public void MoveRock()
        {
            var grid = GridHelper.SetupGrid("1 1 1 1 1\n" +
                                 "1 1 2 1 1\n" +
                                 "1 8 4 1 1\n" +
                                 "1 1 9 1 1\n" +
                                 "1 1 1 1 1");
            var sut = new Solver(grid);
            var actual = sut.SolvePuzzle(2);
            var expected = "↑ ↑ ";
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void MoveRockOverSpike()
        {
            var grid = GridHelper.SetupGrid("1 1 1 1 1\n" +
                                 "1 1 2 1 1\n" +
                                 "1 8 2 1 1\n" +
                                 "1 1 5 1 1\n" +
                                 "1 1 4 1 1\n" + 
                                 "1 1 9 1 1\n" +
                                 "1 1 1 1 1");
            var sut = new Solver(grid);
            var actual = sut.SolvePuzzle(8);
            var expected = "↑ ↑ ↑ ↑2 ↑2 ↑ ";
            Assert.AreEqual(expected, actual);
        }
    }
}
