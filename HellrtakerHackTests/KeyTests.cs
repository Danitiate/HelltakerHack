using HelltakerHack;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HelltakerHackTests
{
    [TestClass]
    public class KeyTests
    {
        [TestMethod]
        public void KeyShouldOpenDoor()
        {
            var grid = GridHelper.SetupGrid("1 1 1 1 1\n" +
                                 "1 8 2 1 1\n" +
                                 "1 1 7 1 1\n" +
                                 "1 1 9 6 1\n" +
                                 "1 1 1 1 1");
            var sut = new Solver(grid);
            var actual = sut.SolvePuzzle(4);
            var expected = "→ ← ↑ ↑ ";
            Assert.AreEqual(expected, actual);
        }
    }
}
