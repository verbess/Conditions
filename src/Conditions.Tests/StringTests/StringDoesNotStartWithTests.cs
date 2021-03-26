using System;
using Conditions.Extensions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Conditions.Tests.StringTests
{
    /// <summary>
    /// Tests the ValidatorExtensions.DoesNotStartWith method.
    /// </summary>
    [TestClass]
    public class StringDoesNotStartWithTests
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [Description("Calling DoesNotStartWith on string x with 'x DoesNotStartWith x' should fail.")]
        public void DoesNotStartWithTest1()
        {
            string a = "test";
            Condition.Requires(a).DoesNotStartWith(a);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [Description("Calling DoesNotStartWith on string x (\"test\") with 'x DoesNotStartWith \"tes\"' should fail.")]
        public void DoesNotStartWithTest2()
        {
            string a = "test";
            Condition.Requires(a).DoesNotStartWith("tes");
        }

        [TestMethod]
        [Description("Calling DoesNotStartWith on string x (\"test\") with 'x DoesNotStartWith null' should pass.")]
        public void DoesNotStartWithTest3()
        {
            string a = "test";
            // A null value will never be found
            Condition.Requires(a).DoesNotStartWith(null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [Description("Calling DoesNotStartWith on string x (\"test\") with 'x DoesNotStartWith \"\"' should fail.")]
        public void DoesNotStartWithTest4()
        {
            string a = "test";
            // An empty string will always be found
            Condition.Requires(a).DoesNotStartWith(String.Empty);
        }

        [TestMethod]
        [Description("Calling DoesNotStartWith on string x (null) with 'x DoesNotStartWith \"\"' should pass.")]
        public void DoesNotStartWithTest5()
        {
            string a = null;
            // A null string only contains other null strings.
            Condition.Requires(a).DoesNotStartWith(String.Empty);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        [Description("Calling DoesNotStartWith on string x (null) with 'x DoesNotStartWith null' should fail.")]
        public void DoesNotStartWithTest6()
        {
            string a = null;
            Condition.Requires(a).DoesNotStartWith(null);
        }

        [TestMethod]
        [Description(
            "Calling DoesNotStartWith on string x (\"test\") with 'x DoesNotStartWith \"test me\"' should pass.")]
        public void DoesNotStartWithTest7()
        {
            string a = "test";
            Condition.Requires(a).DoesNotStartWith("test me");
        }

        [TestMethod]
        [Description("Calling DoesNotStartWith on string x with 'x DoesNotStartWith x' should succeed when exceptions are suppressed.")]
        public void DoesNotStartWithTest8()
        {
            string a = "test";
            Condition.Requires(a).SuppressExceptionsForTest().DoesNotStartWith(a);
        }
    }
}