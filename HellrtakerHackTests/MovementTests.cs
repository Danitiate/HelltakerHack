using HelltakerHack;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HelltakerHackTests
{
    [TestClass]
    public class MovementTests
    {
        [TestMethod]
        public void MoveNorth()
        {
            var grid = GridHelper.SetupGrid("1 1 1 1 1\n" +
                                 "1 1 8 1 1\n" +
                                 "1 1 2 1 1\n" +
                                 "1 1 9 1 1\n" +
                                 "1 1 1 1 1\n" +
                                 "1 1 1 1 1");
            var sut = new Solver(grid);
            var actual = sut.SolvePuzzle(1);
            var expected = "↑ ";
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void MoveEast()
        {
            var grid = GridHelper.SetupGrid("1 1 1 1 1\n" +
                                 "1 1 1 1 1\n" +
                                 "1 9 2 8 1\n" +
                                 "1 1 1 1 1\n" +
                                 "1 1 1 1 1");
            var sut = new Solver(grid);
            var actual = sut.SolvePuzzle(1);
            var expected = "→ ";
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void MoveSouth()
        {
            var grid = GridHelper.SetupGrid("1 1 1 1 1\n" +
                                 "1 1 9 1 1\n" +
                                 "1 1 2 1 1\n" +
                                 "1 1 8 1 1\n" +
                                 "1 1 1 1 1");
            var sut = new Solver(grid);
            var actual = sut.SolvePuzzle(1);
            var expected = "↓ ";
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void MoveWest()
        {
            var grid = GridHelper.SetupGrid("1 1 1 1 1\n" +
                                 "1 1 1 1 1\n" +
                                 "1 8 2 9 1\n" +
                                 "1 1 1 1 1\n" +
                                 "1 1 1 1 1");
            var sut = new Solver(grid);
            var actual = sut.SolvePuzzle(1);
            var expected = "← ";
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void NavigateMaze()
        {
            var grid = GridHelper.SetupGrid("1 1 1 1 1 1 1 1 1 1 1\n" +
                                 "1 1 1 1 2 2 2 2 2 2 1\n" +
                                 "1 2 2 2 2 1 1 1 1 2 1\n" +
                                 "1 2 1 2 1 1 1 1 1 8 1\n" +
                                 "1 1 1 2 1 1 2 2 2 1 1\n" +
                                 "1 2 1 2 2 2 2 1 2 1 1\n" +
                                 "1 2 1 2 1 1 2 1 2 1 1\n" +
                                 "1 2 2 2 2 2 1 1 9 2 1\n" +
                                 "1 1 1 1 1 1 1 1 1 2 1\n" +
                                 "1 2 2 2 2 2 2 2 2 2 1\n" +
                                 "1 1 1 1 1 1 1 1 1 1 1");
            var sut = new Solver(grid);
            var actual = sut.SolvePuzzle(20);
            var expected = "↑ ↑ ↑ ← ← ↓ ← ← ← ↑ ↑ ↑ → ↑ → → → → → ↓ ";
            Assert.AreEqual(expected, actual);
        }
    }
}
