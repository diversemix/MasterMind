using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MasterMindLibrary;

namespace UnitTestMasterMind
{
    [TestClass]
    public class UnitTestColourSet
    {
        /// <summary>
        /// Ensure we throw an exception if we are not initialised properly.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TestNotInitedProperly()
        {
            ColourSet cs1 = new ColourSet(ColourChoice.YELLOW);
        }

        [TestMethod]
        public void TestCreateColourSet()
        {
            ColourSet cs1 = new ColourSet(
                ColourChoice.BLUE,
                ColourChoice.YELLOW,
                ColourChoice.GREEN,
                ColourChoice.RED);
        }

        [TestMethod]
        public void TestEquality()
        {
            ColourSet cs1 = new ColourSet(
                ColourChoice.BLUE,
                ColourChoice.YELLOW,
                ColourChoice.GREEN,
                ColourChoice.RED);

            ColourSet cs2 = new ColourSet(
                ColourChoice.BLUE,
                ColourChoice.YELLOW,
                ColourChoice.GREEN,
                ColourChoice.RED);

            Assert.AreEqual(cs1, cs2);
        }
    }
}
