using System;
using Conditions.Extensions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Conditions.Tests.StringTests
{
    /// <summary>
    /// Tests the ValidatorExtensions.DoesNotEndWith method.
    /// </summary>
    [TestClass]
    public class StringDoesNotEndWithTests
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [Description("Calling DoesNotEndWith on string x (\"test\") with 'x DoesNotEndWith x' should fail.")]
        public void DoesNotEndWithTest1()
        {
            string a = "test";
            Condition.Requires(a).DoesNotEndWith(a);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [Description("Calling DoesNotEndWith on string x (\"test\") with 'x DoesNotEndWith \"est\"' should fail.")]
        public void DoesNotEndWithTest2()
        {
            string a = "test";
            Condition.Requires(a).DoesNotEndWith("est");
        }

        [TestMethod]
        [Description("Calling DoesNotEndWith on string x (\"test\") with 'x DoesNotEndWith null' should pass.")]
        public void DoesNotEndWithTest3()
        {
            string a = "test";
            // A null value will never be found
            Condition.Requires(a).DoesNotEndWith(null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [Description("Calling DoesNotEndWith on string x (\"test\") with 'x DoesNotEndWith \"\"' should fail.")]
        public void DoesNotEndWithTest4()
        {
            string a = "test";
            // An empty string will always be found
            Condition.Requires(a).DoesNotEndWith(String.Empty);
        }

        [TestMethod]
        [Description("Calling DoesNotEndWith on string x (null) with 'x DoesNotEndWith \"\"' should pass.")]
        public void DoesNotEndWithTest5()
        {
            string a = null;
            // A null string only contains other null strings.
            Condition.Requires(a).DoesNotEndWith(String.Empty);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        [Description("Calling DoesNotEndWith on string x (null) with 'x DoesNotEndWith null' should fail.")]
        public void DoesNotEndWithTest6()
        {
            string a = null;
            Condition.Requires(a).DoesNotEndWith(null);
        }

        [TestMethod]
        [Description("Calling DoesNotEndWith on string x (\"test\") with 'x DoesNotEndWith \"me test\"' should pass.")]
        public void DoesNotEndWithTest7()
        {
            string a = "test";
            Condition.Requires(a).DoesNotEndWith("me test");
        }

        [TestMethod]
        [Description("Calling DoesNotEndWith on string x (\"test\") with 'x DoesNotEndWith x' should succeed when exceptions are suppressed.")]
        public void DoesNotEndWithTest8()
        {
            string a = "test";
            Condition.Requires(a).SuppressExceptionsForTest().DoesNotEndWith(a);
        }
    }
}