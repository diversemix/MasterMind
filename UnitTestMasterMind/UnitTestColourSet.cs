using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MasterMindLibrary;
using System.Collections.Generic;
using System.Linq;

namespace UnitTestMasterMind
{
    [TestClass]
    public class UnitTestColourSet
    {
        private ColourSet csA = new ColourSet("BLUE", "YELLOW", "GREEN", "RED");
        private ColourSet csB = new ColourSet("BLUE", "YELLOW", "GREEN", "RED");
        private ColourSet csC = new ColourSet("YELLOW", "GREEN", "RED", "BLUE");
        private ColourSet csD = new ColourSet("YELLOW", "BLUE", "GREEN", "RED");

        private ColourSet csX = new ColourSet("RED", "BLUE", "RED", "BLUE");
        private ColourSet csY = new ColourSet("YELLOW", "GREEN", "YELLOW", "GREEN");
        private ColourSet csZ = new ColourSet("RED", "GREEN", "YELLOW", "GREEN");

        /// <summary>
        /// Ensure we throw an exception if we are not initialised properly.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TestNotInitedProperly()
        {
            ColourSet csWrong = new ColourSet("YELLOW");
        }

        [TestMethod]
        public void TestEquality()
        {
            Assert.AreEqual(csA, csB);
        }

        [TestMethod]
        public void TestPinsAllBlack()
        {
            List<ComparePin> pins = csA.Compare(csB);
            Assert.AreEqual(pins.Count, 4);
            foreach (ComparePin pin in pins)
            {
                Assert.AreEqual(pin, ComparePin.BLACK);
            }
        }

        [TestMethod]
        public void TestPinsAllWhite()
        {
            List<ComparePin> pins = csA.Compare(csC);
            Assert.AreEqual(pins.Count, 4);
            foreach (ComparePin pin in pins)
            {
                Assert.AreEqual(pin, ComparePin.WHITE);
            }
        }

        [TestMethod]
        public void TestPins2Black2White()
        {
            List<ComparePin> pins = csA.Compare(csD);
            Assert.AreEqual(pins.Count, 4);
            var blackPins = from p in pins where p == ComparePin.BLACK select p;
            var whitePins = from p in pins where p == ComparePin.WHITE select p;
            Assert.AreEqual(blackPins.Count(), 2);
            Assert.AreEqual(whitePins.Count(), 2);
        }

        [TestMethod]
        public void TestZeroPins()
        {
            List<ComparePin> pins = csX.Compare(csY);
            Assert.AreEqual(pins.Count, 0);
        }

        [TestMethod]
        public void Test1BlackPin()
        {
            List<ComparePin> pins = csX.Compare(csZ);
            Assert.AreEqual(pins.Count, 1);
            Assert.AreEqual(pins[0], ComparePin.BLACK);
        }
    }
}
