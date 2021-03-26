using System;
using Conditions.Extensions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Conditions.Tests.StringTests
{
    /// <summary>
    /// Tests the ValidatorExtensions.IsNullOrWhiteSpace method.
    /// </summary>
    [TestClass]
    public class StringIsNullOrWhiteSpaceTests
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [Description("Calling IsNullOrWhiteSpace on string x with x = 'a' should fail.")]
        public void IsNullOrWhiteSpaceTest1()
        {
            string a = "a";
            Condition.Requires(a).IsNullOrWhiteSpace();
        }

        [TestMethod]
        [Description("Calling IsNullOrWhiteSpace on string '' should pass.")]
        public void IsNullOrWhiteSpaceTest2()
        {
            string a = String.Empty;
            Condition.Requires(a).IsNullOrWhiteSpace();
        }

        [TestMethod]
        [Description("Calling IsNullOrWhiteSpace on string null should pass.")]
        public void IsNullOrWhiteSpaceTest3()
        {
            string a = null;
            Condition.Requires(a).IsNullOrWhiteSpace();
        }

        [TestMethod]
        [Description("Calling IsNullOrWhiteSpace on string containing only white space characters should pass.")]
        public void IsNullOrWhiteSpaceTest4()
        {
            string a = "\t  \n\r";
            Condition.Requires(a).IsNullOrWhiteSpace();
        }

        [TestMethod]
        [Description("Calling IsNullOrWhiteSpace on an invalid string should succeed when exceptions are suppressed.")]
        public void IsNullOrWhiteSpaceTest5()
        {
            string a = "invalid string";
            Condition.Requires(a).SuppressExceptionsForTest().IsNullOrWhiteSpace();
        }
    }
}