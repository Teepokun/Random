using System;
using System.Linq;
using DebuggingPractice;
using LaYumba.Functional;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using static LaYumba.Functional.F;
namespace DebuggingTest2
{
    [TestClass]
    public class EnsureActuallyWorksTests
    {
        [DataRow("Monday", EDayOfWeek.Monday)]
        [DataRow("Tuesday", EDayOfWeek.Tuesday)]
        [DataRow("Wednesday", EDayOfWeek.Wednesday)]
        [DataRow("Thursday", EDayOfWeek.Thursday)]
        [DataRow("Friday", EDayOfWeek.Friday)]
        [DataRow("Saturday", EDayOfWeek.Saturday)]
        [DataRow("Sunday", EDayOfWeek.Sunday)]
        [DataTestMethod]
        public void TestCanConvertValidValues(string val, EDayOfWeek expected)
        {

            var result1 = val.ParseUsingExpressions().AsEnumerable().First();
            Assert.AreEqual(expected, result1);

            //Don't do this in real life kids...
            var result2 = val.ParseUsingDelegates().AsEnumerable().First();
            Assert.AreEqual(expected, result2);
        }

        [TestMethod]
        public void TestCanConvertInvalidValues()
        {
            var val = "Funday";
            var r1 = val.ParseUsingExpressions()
                .Match(
                    () => true,
                    v => false);

            var r2 = val.ParseUsingDelegates()
                .Match(
                    () => true,
                    v => false);

            Assert.IsTrue(r1 && r2 && true);
        }
    }
}
