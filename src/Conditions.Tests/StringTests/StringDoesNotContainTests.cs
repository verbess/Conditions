using System;
using Conditions.Extensions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Conditions.Tests.StringTests
{
    /// <summary>
    /// Tests the ValidatorExtensions.DoesNotContain method.
    /// </summary>
    [TestClass]
    public class StringDoesNotContainTests
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [Description("Calling DoesNotContain on string x (\"test\") with 'x DoesNotContain x' should fail.")]
        public void DoesNotContainTest1()
        {
            string a = "test";
            Condition.Requires(a).DoesNotContain(a);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [Description("Calling DoesNotContain on string x (\"test\") with 'x DoesNotContain \"es\"' should fail.")]
        public void DoesNotContainTest2()
        {
            string a = "test";
            Condition.Requires(a).DoesNotContain("es");
        }

        [TestMethod]
        [Description("Calling DoesNotContain on string x (\"test\") with 'x DoesNotContain null' should pass.")]
        public void DoesNotContainTest3()
        {
            string a = "test";
            // A null value will never be found
            Condition.Requires(a).DoesNotContain(null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [Description("Calling DoesNotContain on string x (\"test\") with 'x DoesNotContain \"\"' should fail.")]
        public void DoesNotContainTest4()
        {
            string a = "test";
            // An empty string will always be found
            Condition.Requires(a).DoesNotContain(String.Empty);
        }

        [TestMethod]
        [Description("Calling DoesNotContain on string x (null) with 'x DoesNotContain \"\"' should pass.")]
        public void DoesNotContainTest5()
        {
            string a = null;
            // A null string only contains other null strings.
            Condition.Requires(a).DoesNotContain(String.Empty);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        [Description("Calling DoesNotContain on string x (null) with 'x DoesNotContain null' should fail.")]
        public void DoesNotContainTest6()
        {
            string a = null;
            Condition.Requires(a).DoesNotContain(null);
        }

        [TestMethod]
        [Description("Calling DoesNotContain on string x (\"test\") with 'x DoesNotContain \"test me\"' should pass.")]
        public void DoesNotContainTest7()
        {
            string a = "test";
            Condition.Requires(a).DoesNotContain("test me");
        }

        [TestMethod]
        [Description("Calling DoesNotContain on string x (\"test\") with 'x DoesNotContain x' should succeed when exceptions are suppressed.")]
        public void DoesNotContainTest8()
        {
            string a = "test";
            Condition.Requires(a).SuppressExceptionsForTest().DoesNotContain(a);
        }
    }
}