using System;
using Conditions.Extensions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Conditions.Tests.StringTests
{
    /// <summary>
    /// Tests the ValidatorExtensions.StartsWith method.
    /// </summary>
    [TestClass]
    public class StringStartsWithTests
    {
        [TestMethod]
        [Description("Calling StartsWith on string x with 'x StartsWith x' should pass.")]
        public void StartsWithTest1()
        {
            string a = "test";
            Condition.Requires(a).StartsWith(a);
        }

        [TestMethod]
        [Description("Calling StartsWith on string x (\"test\") with 'x StartsWith \"tes\"' should pass.")]
        public void StartsWithTest2()
        {
            string a = "test";
            Condition.Requires(a).StartsWith("tes");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [Description("Calling StartsWith on string x (\"test\") with 'x StartsWith null' should fail.")]
        public void StartsWithTest3()
        {
            string a = "test";
            // A null value will never be found
            Condition.Requires(a).StartsWith(null);
        }

        [TestMethod]
        [Description("Calling StartsWith on string x (\"test\") with 'x StartsWith \"\"' should pass.")]
        public void StartsWithTest4()
        {
            string a = "test";
            // An empty string will always be found
            Condition.Requires(a).StartsWith(String.Empty);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        [Description("Calling StartsWith on string x (null) with 'x StartsWith \"\"' should fail.")]
        public void StartsWithTest5()
        {
            string a = null;
            // A null string only contains other null strings.
            Condition.Requires(a).StartsWith(String.Empty);
        }

        [TestMethod]
        [Description("Calling StartsWith on string x (\"test\") with 'x StartsWith null' should pass.")]
        public void StartsWithTest6()
        {
            string a = null;
            Condition.Requires(a).StartsWith(null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [Description("Calling StartsWith on string x (\"test\") with 'x StartsWith \"test me\"' should fail.")]
        public void StartsWithTest7()
        {
            string a = "test";
            Condition.Requires(a).StartsWith("test me");
        }

        [TestMethod]
        [Description(
            "Calling StartsWith on string x (\"test\") with 'x StartsWith null' should succeed when exceptions are suppressed."
            )]
        public void StartsWithTest8()
        {
            string a = "test";
            // A null value will never be found
            Condition.Requires(a).SuppressExceptionsForTest().StartsWith(null);
        }
    }
}