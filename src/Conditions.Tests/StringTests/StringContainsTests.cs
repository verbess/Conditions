using System;
using Conditions.Extensions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Conditions.Tests.StringTests
{
    /// <summary>
    /// Tests the ValidatorExtensions.Contains method.
    /// </summary>
    [TestClass]
    public class StringContainsTests
    {
        [TestMethod]
        [Description("Calling Contains on string x with 'x Contains x' should pass.")]
        public void ContainsTest1()
        {
            string a = "test";
            Condition.Requires(a).Contains(a);
        }

        [TestMethod]
        [Description("Calling Contains on string x (\"test\") with 'x Contains \"es\"' should pass.")]
        public void ContainsTest2()
        {
            string a = "test";
            Condition.Requires(a).Contains("es");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [Description("Calling Contains on string x (\"test\") with 'x Contains null' should fail.")]
        public void ContainsTest3()
        {
            string a = "test";
            // A null value will never be found
            Condition.Requires(a).Contains(null);
        }

        [TestMethod]
        [Description("Calling Contains on string x (\"test\") with 'x Contains \"\"' should pass.")]
        public void ContainsTest4()
        {
            string a = "test";
            // An empty string will always be found
            Condition.Requires(a).Contains(String.Empty);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        [Description("Calling Contains on string x (null) with 'x Contains \"\"' should fail.")]
        public void ContainsTest5()
        {
            string a = null;
            // A null string only contains other null strings.
            Condition.Requires(a).Contains(String.Empty);
        }

        [TestMethod]
        [Description("Calling Contains on string x (null) with 'x Contains null' should pass.")]
        public void ContainsTest6()
        {
            string a = null;
            Condition.Requires(a).Contains(null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [Description("Calling Contains on string x (\"test\") with 'x Contains \"test me\"' should fail.")]
        public void ContainsTest7()
        {
            string a = "test";
            Condition.Requires(a).Contains("test me");
        }

        [TestMethod]
        [Description("Calling Contains on string x (\"test\") with 'x Contains null' should succeed when exceptions are suppressed.")]
        public void ContainsTest8()
        {
            string a = "test";
            // A null value will never be found
            Condition.Requires(a).SuppressExceptionsForTest().Contains(null);
        }
    }
}