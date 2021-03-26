using System;
using Conditions.Extensions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Conditions.Tests.StringTests
{
    /// <summary>
    /// Tests the ValidatorExtensions.IsLongerOrEqualTo method.
    /// </summary>
    [TestClass]
    public class StringIsLongerOrEqualToTests
    {
        [TestMethod]
        [Description("Calling IsLongerOrEqualTo on string x with 'lower bound < x.Length' should pass.")]
        public void IsLongerOrEqualToTest1()
        {
            string a = "test";
            Condition.Requires(a).IsLongerOrEqualTo(3);
        }

        [TestMethod]
        [Description("Calling IsLongerOrEqualTo on string x with 'lower bound = x.Length' should pass.")]
        public void IsLongerOrEqualToTest2()
        {
            string a = "test";
            Condition.Requires(a).IsLongerOrEqualTo(4);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [Description("Calling IsLongerOrEqualTo on string x with 'lower bound > x.Length' should fail.")]
        public void IsLongerOrEqualToTest3()
        {
            string a = "test";
            Condition.Requires(a).IsLongerOrEqualTo(5);
        }

        [TestMethod]
        [Description("Calling IsLongerOrEqualTo on string x with '-1 < x.Length' should pass.")]
        public void IsLongerOrEqualToTest4()
        {
            string a = String.Empty;
            Condition.Requires(a).IsLongerOrEqualTo(-1);
        }

        [TestMethod]
        [Description("Calling IsLongerOrEqualTo on string x with 'lower bound = x.Length' should pass.")]
        public void IsLongerOrEqualToTest5()
        {
            string a = String.Empty;
            Condition.Requires(a).IsLongerOrEqualTo(0);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [Description("Calling IsLongerOrEqualTo on string x with 'lower bound > x.Length' should fail.")]
        public void IsLongerOrEqualToTest6()
        {
            string a = String.Empty;
            Condition.Requires(a).IsLongerOrEqualTo(1);
        }

        [TestMethod]
        [Description("Calling IsLongerOrEqualTo on string x with 'lower bound = null' should pass.")]
        public void IsLongerOrEqualToTest7()
        {
            string a = null;
            Condition.Requires(a).IsLongerOrEqualTo(0);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        [Description("Calling IsLongerOrEqualTo on string x with 'lower bound > null' should fail.")]
        public void IsLongerOrEqualToTest8()
        {
            string a = null;
            // A null string is considered to have the length of 0.
            Condition.Requires(a).IsLongerOrEqualTo(1);
        }

        [TestMethod]
        [Description(
            "Calling IsLongerOrEqualTo on string x with 'lower bound > x.Length' should succeed when exceptions are suppressed."
            )]
        public void IsLongerOrEqualToTest9()
        {
            string a = "test";
            Condition.Requires(a).SuppressExceptionsForTest().IsLongerOrEqualTo(5);
        }
    }
}