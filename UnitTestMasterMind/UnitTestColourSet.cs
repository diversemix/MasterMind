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
    }
}
