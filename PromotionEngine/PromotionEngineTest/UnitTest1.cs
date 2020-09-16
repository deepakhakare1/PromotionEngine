using Microsoft.VisualStudio.TestTools.UnitTesting;
using PromotionEngine;

namespace PromotionEngineTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void ExpectedResultPass()
        {
           // Define a test input and output value:
            decimal expectedResult = 280;
            // Run the method under test:

            decimal actualResult = PromotionEngineRule.GetPromotionEngineResult ();
            // Verify the result:
            Assert.AreEqual(expectedResult, actualResult, "Passed");
        }
        [TestMethod]
        public void ExpectedResultFailed()
        {
            // Define a test input and output value:
            decimal expectedResult = 2m;
            
            // Run the method under test:
            decimal actualResult = PromotionEngineRule.GetPromotionEngineResult();
            // Verify the result:
            Assert.AreEqual(expectedResult, actualResult, "Failed");
        }
    }
}
