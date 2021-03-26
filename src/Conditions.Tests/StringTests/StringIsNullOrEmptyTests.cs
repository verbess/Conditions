using System;
using Conditions.Extensions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Conditions.Tests.StringTests
{
    /// <summary>
    /// Tests the ValidatorExtensions.IsNullOrEmpty method.
    /// </summary>
    [TestClass]
    public class StringIsNullOrEmptyTests
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [Description("Calling IsNullOrEmpty on string x with 'x.Length > 0' should fail.")]
        public void IsNullOrEmptyTest1()
        {
            string a = "test";
            Condition.Requires(a).IsNullOrEmpty();
        }

        [TestMethod]
        [Description("Calling IsNullOrEmpty on string (\"\") should pass.")]
        public void IsNullOrEmptyTest2()
        {
            string a = String.Empty;
            Condition.Requires(a).IsNullOrEmpty();
        }

        [TestMethod]
        [Description("Calling IsNullOrEmpty on string (null) should pass.")]
        public void IsNullOrEmptyTest3()
        {
            string a = null;
            // A null value will never be found
            Condition.Requires(a).IsNullOrEmpty();
        }

        [TestMethod]
        [Description("Calling IsNullOrEmpty on string x with 'x.Length > 0' should succeed when exceptions are suppressed.")]
        public void IsNullOrEmptyTest4()
        {
            string a = "test";
            Condition.Requires(a).SuppressExceptionsForTest().IsNullOrEmpty();
        }
    }
}