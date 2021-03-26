using System;
using Conditions.Extensions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Conditions.Tests.StringTests
{
    [TestClass]
    public class StringIsNotNullOrWhiteSpaceTests
    {
        [TestMethod]
        [Description("Calling IsNotNullOrWhiteSpace on string x with x = 'a' should succeed.")]
        public void IsNotNullOrWhiteSpaceTest1()
        {
            string a = "a";
            Condition.Requires(a).IsNotNullOrWhiteSpace();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [Description("Calling IsNotNullOrWhiteSpace on string '' should fail.")]
        public void IsNotNullOrWhiteSpaceTest2()
        {
            string a = String.Empty;
            Condition.Requires(a).IsNotNullOrWhiteSpace();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        [Description("Calling IsNotNullOrWhiteSpace on string null should fail.")]
        public void IsNotNullOrWhiteSpaceTest3()
        {
            string a = null;
            Condition.Requires(a).IsNotNullOrWhiteSpace();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [Description("Calling IsNotNullOrWhiteSpace on string containing only white space characters should fail.")]
        public void IsNotNullOrWhiteSpaceTest4()
        {
            string a = "\t  \n\r";
            Condition.Requires(a).IsNotNullOrWhiteSpace();
        }

        [TestMethod]
        [Description("Calling IsNotNullOrWhiteSpace on an invalid string should succeed when exceptions are suppressed.")]
        public void IsNotNullOrWhiteSpaceTest5()
        {
            string invalidString = string.Empty;
            Condition.Requires(invalidString).SuppressExceptionsForTest().IsNotNullOrWhiteSpace();
        }
    }
}