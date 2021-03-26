using System;
using Conditions.Extensions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Conditions.Tests.StringTests
{
    /// <summary>
    /// Tests the ValidatorExtensions.IsLongerThan method.
    /// </summary>
    [TestClass]
    public class StringIsLongerThanTests
    {
        [TestMethod]
        [Description("Calling IsLongerThan on string x with 'lower bound < x.Length' should pass.")]
        public void IsLongerThan1()
        {
            string a = "test";
            Condition.Requires(a).IsLongerThan(3);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [Description("Calling IsLongerThan on string x with 'lower bound = x.Length' should fail.")]
        public void IsLongerThan2()
        {
            string a = "test";
            Condition.Requires(a).IsLongerThan(4);
        }

        [TestMethod]
        [Description("Calling IsLongerThan on string x with '-1 < x.Length' should pass.")]
        public void IsLongerThan3()
        {
            string a = String.Empty;
            Condition.Requires(a).IsLongerThan(-1);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [Description("Calling IsLongerThan on string x with 'lower bound = x.Length' should fail.")]
        public void IsLongerThan4()
        {
            string a = String.Empty;
            Condition.Requires(a).IsLongerThan(0);
        }

        [TestMethod]
        [Description("Calling IsLongerThan on string x with '-1 < null' should pass.")]
        public void IsLongerThan5()
        {
            string a = null;
            Condition.Requires(a).IsLongerThan(-1);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        [Description("Calling IsLongerThan on string x with 'lower bound = null' should fail.")]
        public void IsLongerThan6()
        {
            string a = null;
            Condition.Requires(a).IsLongerThan(0);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [Description("Calling IsLongerThan on string x with 'lower bound = 1' should fail.")]
        public void IsLongerThan7()
        {
            // Testing a string with length of one and minLength = 1 to achieve 100% code coverage.
            string a = "1";
            Condition.Requires(a).IsLongerThan(1);
        }

        [TestMethod]
        [Description("Calling IsLongerThan on string x with 'lower bound = x.Length' should succeed when exceptions are suppressed.")]
        public void IsLongerThan8()
        {
            string a = "test";
            Condition.Requires(a).SuppressExceptionsForTest().IsLongerThan(4);
        }
    }
}