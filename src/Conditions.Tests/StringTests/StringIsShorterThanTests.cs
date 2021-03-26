using System;
using Conditions.Extensions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Conditions.Tests.StringTests
{
    /// <summary>
    /// Tests the ValidatorExtensions.IsShorterThan method.
    /// </summary>
    [TestClass]
    public class StringIsShorterThanTests
    {
        [TestMethod]
        [Description("Calling IsShorterThan on string x with 'x.Length < upped bound' should pass.")]
        public void IsShorterThan1()
        {
            string a = "test";
            Condition.Requires(a).IsShorterThan(5);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [Description("Calling IsShorterThan on string x with 'x.Length = upped bound' should fail.")]
        public void IsShorterThan2()
        {
            string a = "test";
            Condition.Requires(a).IsShorterThan(4);
        }

        [TestMethod]
        [Description("Calling IsShorterThan on string x with 'x.Length > upped bound' should fail.")]
        public void IsShorterThan3()
        {
            string a = String.Empty;
            Condition.Requires(a).IsShorterThan(1);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [Description("Calling IsShorterThan on string x with 'x.Length > upped bound' should fail.")]
        public void IsShorterThan4()
        {
            string a = String.Empty;
            Condition.Requires(a).IsShorterThan(0);
        }

        [TestMethod]
        [Description("Calling IsShorterThan on string x with 'null < upped bound' should pass.")]
        public void IsShorterThan5()
        {
            string a = null;
            Condition.Requires(a).IsShorterThan(1);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        [Description("Calling IsShorterThan on string x with 'null = upped bound' should fail.")]
        public void IsShorterThan6()
        {
            string a = null;
            // A null string is considered to have a length of 0.
            Condition.Requires(a).IsShorterThan(0);
        }

        [TestMethod]
        [Description("Calling IsShorterThan on string x with 'x.Length = upped bound' should succeed when exceptions are suppressed.")]
        public void IsShorterThan7()
        {
            string a = "test";
            Condition.Requires(a).SuppressExceptionsForTest().IsShorterThan(4);
        }
    }
}