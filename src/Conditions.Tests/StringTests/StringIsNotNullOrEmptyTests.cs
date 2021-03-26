using System;
using Conditions.Extensions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Conditions.Tests.StringTests
{
    /// <summary>
    /// Tests the ValidatorExtensions.IsNotNullOrEmpty method.
    /// </summary>
    [TestClass]
    public class StringIsNotNullOrEmptyTests
    {
        [TestMethod]
        [Description("Calling IsNullOrEmpty on string x with 'x.Length > 0' should pass.")]
        public void IsNotNullOrEmptyTest1()
        {
            string a = "test";
            Condition.Requires(a).IsNotNullOrEmpty();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [Description("Calling IsNullOrEmpty on string (\"\") should fail.")]
        public void IsNotNullOrEmptyTest2()
        {
            string a = String.Empty;
            Condition.Requires(a).IsNotNullOrEmpty();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        [Description("Calling IsNullOrEmpty on string (null) should fail.")]
        public void IsNotNullOrEmptyTest3()
        {
            string a = null;
            // A null value will never be found
            Condition.Requires(a).IsNotNullOrEmpty();
        }

        [TestMethod]
        [Description("Calling IsNullOrEmpty on string (\"\") should succeed when exceptions are suppressed.")]
        public void IsNotNullOrEmptyTest4()
        {
            string a = String.Empty;
            Condition.Requires(a).SuppressExceptionsForTest().IsNotNullOrEmpty();
        }
    }
}