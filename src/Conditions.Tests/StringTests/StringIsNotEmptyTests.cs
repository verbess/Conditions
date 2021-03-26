using System;
using Conditions.Extensions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Conditions.Tests.StringTests
{
    /// <summary>
    /// Tests the ValidatorExtensions.IsNotEmpty method.
    /// </summary>
    [TestClass]
    public class StringIsNotEmptyTests
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [Description("Calling IsNotEmpty on string x with 'x == String.Empty' should fail.")]
        public void IsStringNotEmptyTest1()
        {
            string s = String.Empty;
            Condition.Requires(s).IsNotEmpty();
        }

        [TestMethod]
        [Description("Calling IsNotEmpty on string x with 'x != String.Empty' should pass.")]
        public void IsStringNotEmptyTest2()
        {
            string s = null;
            Condition.Requires(s).IsNotEmpty();
        }

        [TestMethod]
        [Description("Calling IsNotEmpty on string x with 'x != String.Empty' should pass.")]
        public void IsStringNotEmptyTest3()
        {
            string s = "test";
            Condition.Requires(s).IsNotEmpty();
        }

        [TestMethod]
        [Description("Calling IsNotEmpty on string x with 'x == String.Empty' should succeed when exceptions are suppressed.")]
        public void IsStringNotEmptyTest4()
        {
            string s = String.Empty;
            Condition.Requires(s).SuppressExceptionsForTest().IsNotEmpty();
        }
    }
}