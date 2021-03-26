using System;
using Conditions.Extensions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Conditions.Tests.StringTests
{
    /// <summary>
    /// Tests the ValidatorExtensions.IsEmpty method.
    /// </summary>
    [TestClass]
    public class StringIsEmptyTests
    {
        [TestMethod]
        [Description("Calling IsEmpty on string x with 'x == String.Empty' should pass.")]
        public void IsStringEmptyTest1()
        {
            string s = String.Empty;
            Condition.Requires(s).IsEmpty();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        [Description("Calling IsEmpty on string x with 'x != String.Empty' should fail.")]
        public void IsStringEmptyTest2()
        {
            string s = null;
            Condition.Requires(s).IsEmpty();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [Description("Calling IsEmpty on string x with 'x != String.Empty' should fail.")]
        public void IsStringEmptyTest3()
        {
            string s = "test";
            Condition.Requires(s).IsEmpty();
        }

        [TestMethod]
        [Description("Calling IsEmpty on string x with 'x != String.Empty' should succeed when exceptions are suppressed.")]
        public void IsStringEmptyTest4()
        {
            string s = null;
            Condition.Requires(s).SuppressExceptionsForTest().IsEmpty();
        }
    }
}