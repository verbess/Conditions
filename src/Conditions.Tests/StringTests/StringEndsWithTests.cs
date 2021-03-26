using System;
using Conditions.Extensions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Conditions.Tests.StringTests
{
    /// <summary>
    /// Tests the ValidatorExtensions.EndsWith method.
    /// </summary>
    [TestClass]
    public class StringEndsWithTests
    {
        [TestMethod]
        [Description("Calling EndsWith on string x with 'x EndsWith x' should pass.")]
        public void EndsWithTest1()
        {
            string a = "test";
            Condition.Requires(a).EndsWith(a);
        }

        [TestMethod]
        [Description("Calling EndsWith on string x (\"test\") with 'x EndsWith \"est\"' should pass.")]
        public void EndsWithTest2()
        {
            string a = "test";
            Condition.Requires(a).EndsWith("est");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [Description("Calling EndsWith on string x (\"test\") with 'x EndsWith null' should fail.")]
        public void EndsWithTest3()
        {
            string a = "test";
            // A null value will never be found
            Condition.Requires(a).EndsWith(null);
        }

        [TestMethod]
        [Description("Calling EndsWith on string x (\"test\") with 'x EndsWith \"\"' should pass.")]
        public void EndsWithTest4()
        {
            string a = "test";
            // An empty string will always be found
            Condition.Requires(a).EndsWith(String.Empty);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        [Description("Calling EndsWith on string x (null) with 'x EndsWith \"\"' should fail.")]
        public void EndsWithTest5()
        {
            string a = null;
            // A null string only contains other null strings.
            Condition.Requires(a).EndsWith(String.Empty);
        }

        [TestMethod]
        [Description("Calling EndsWith on string x (null) with 'x EndsWith null' should pass.")]
        public void EndsWithTest6()
        {
            string a = null;
            Condition.Requires(a).EndsWith(null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [Description("Calling EndsWith on string x (\"test\") with 'x EndsWith \"me test\"' should fail.")]
        public void EndsWithTest7()
        {
            string a = "test";
            Condition.Requires(a).EndsWith("me test");
        }

        [TestMethod]
        [Description("Calling EndsWith on string x (\"test\") with 'x EndsWith null' should succeed when exceptions are suppressed.")]
        public void StartsWithTest8()
        {
            string a = "test";
            // A null value will never be found
            Condition.Requires(a).SuppressExceptionsForTest().EndsWith(null);
        }
    }
}