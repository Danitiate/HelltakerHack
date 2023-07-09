using HelltakerHack;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HelltakerHackTests
{
    [TestClass]
    public class SpikeTests
    {
        [TestMethod]
        public void MoveSpikeUsesTwoMoves()
        {
            var grid = GridHelper.SetupGrid("1 1 1 1 1\n" +
                                 "1 8 2 1 1\n" +
                                 "1 1 5 1 1\n" +
                                 "1 1 9 1 1\n" +
                                 "1 1 1 1 1");
            var sut = new Solver(grid);
            var actual = sut.SolvePuzzle(2);
            var expected = "Could not find any solution";
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void MoveSpikePossibleWithOneRemainingMove()
        {
            var grid = GridHelper.SetupGrid("1 1 1 1 1\n" +
                                 "1 1 1 1 1\n" +
                                 "1 8 5 1 1\n" +
                                 "1 1 9 1 1\n" +
                                 "1 1 1 1 1");
            var sut = new Solver(grid);
            var actual = sut.SolvePuzzle(1);
            var expected = "↑2 ";
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void InactiveSpikeDoesNotDamage()
        {
            var grid = GridHelper.SetupGrid("1 1 1 1 1\n" +
                                 "1 8 2 1 1\n" +
                                 "1 1 11 1 1\n" +
                                 "1 1 9 1 1\n" +
                                 "1 1 1 1 1");
            var sut = new Solver(grid);
            var actual = sut.SolvePuzzle(2);
            var expected = "↑ ↑ ";
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ActiveSpikeDoesDamage()
        {
            var grid = GridHelper.SetupGrid("1 1 1 1 1\n" +
                                 "1 8 2 1 1\n" +
                                 "1 1 10 1 1\n" +
                                 "1 1 9 1 1\n" +
                                 "1 1 1 1 1");
            var sut = new Solver(grid);
            var actual = sut.SolvePuzzle(3);
            var expected = "↑2 ↑ ";
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ActiveAndInactiveSpike()
        {
            var grid = GridHelper.SetupGrid("1 1 1 1 1\n" +
                                 "1 8 2 1 1\n" +
                                 "1 1 11 1 1\n" +
                                 "1 1 10 1 1\n" +
                                 "1 1 9 1 1\n" +
                                 "1 1 1 1 1");
            var sut = new Solver(grid);
            var actual = sut.SolvePuzzle(5);
            var expected = "↑2 ↑2 ↑ ";
            Assert.AreEqual(expected, actual);
        }


        [TestMethod]
        public void RockSpikePushableNoDamageAndRevealedSpikeDamages()
        {
            var grid = GridHelper.SetupGrid("1 1 1 1 1\n" +
                                 "1 8 1 1 1\n" +
                                 "1 2 2 1 1\n" +
                                 "1 2 12 1 1\n" +
                                 "1 1 9 1 1\n" +
                                 "1 1 1 1 1");
            var sut = new Solver(grid);
            var actual = sut.SolvePuzzle(5);
            var expected = "↑ ↑2 ← ↑ ";
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestScenario()
        {
            var grid = GridHelper.SetupGrid("1 1 9 2 1\n" +
                                 "1 12 12 4 1\n" +
                                 "1 2 5 2 1\n" +
                                 "1 2 3 2 1\n" +
                                 "1 8 2 3 1\n" +
                                 "1 1 1 1 1");
            var sut = new Solver(grid);
            var actual = sut.SolvePuzzle(9);
            var expected = "→ ↓ ↓ ↓ ↓ ←2 ← ↓ ";
            Assert.AreEqual(expected, actual);
        }
    }
}
