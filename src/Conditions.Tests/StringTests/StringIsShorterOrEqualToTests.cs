using System;
using Conditions.Extensions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Conditions.Tests.StringTests
{
    /// <summary>
    /// Tests the ValidatorExtensions.IsShorterOrEqualTo method.
    /// </summary>
    [TestClass]
    public class StringIsShorterOrEqualToTests
    {
        [TestMethod]
        [Description("Calling IsShorterOrEqualTo on string x with 'x.Length < upped bound' should pass.")]
        public void IsShorterOrEqualTo1()
        {
            string a = "test";
            Condition.Requires(a).IsShorterOrEqualTo(5);
        }

        [TestMethod]
        [Description("Calling IsShorterOrEqualTo on string x with 'x.Length = upped bound' should pass.")]
        public void IsShorterOrEqualTo2()
        {
            string a = "test";
            Condition.Requires(a).IsShorterOrEqualTo(4);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [Description("Calling IsShorterOrEqualTo on string x with 'x.Length > upped bound' should fail.")]
        public void IsShorterOrEqualTo3()
        {
            string a = "test";
            Condition.Requires(a).IsShorterOrEqualTo(1);
        }

        [TestMethod]
        [Description("Calling IsShorterOrEqualTo on string x with 'x.Length < upped bound' should pass.")]
        public void IsShorterOrEqualTo4()
        {
            string a = String.Empty;
            Condition.Requires(a).IsShorterOrEqualTo(1);
        }

        [TestMethod]
        [Description("Calling IsShorterOrEqualTo on string x with 'x.Length = upped bound' should pass.")]
        public void IsShorterOrEqualTo5()
        {
            string a = String.Empty;
            Condition.Requires(a).IsShorterOrEqualTo(0);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [Description("Calling IsShorterOrEqualTo on string x with 'x.Length > upped bound' should fail.")]
        public void IsShorterOrEqualTo6()
        {
            string a = String.Empty;
            Condition.Requires(a).IsShorterOrEqualTo(-1);
        }

        [TestMethod]
        [Description("Calling IsShorterOrEqualTo on string x with 'null = upped bound' should pass.")]
        public void IsShorterOrEqualTo7()
        {
            string a = null;
            Condition.Requires(a).IsShorterOrEqualTo(0);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        [Description("Calling IsShorterOrEqualTo on string x with 'null > upped bound' should fail.")]
        public void IsShorterOrEqualTo8()
        {
            string a = null;
            // A null value is considered to have a length of 0 characters.
            Condition.Requires(a).IsShorterOrEqualTo(-1);
        }

        [TestMethod]
        [Description("Calling IsShorterOrEqualTo on string x with 'x.Length > upped bound' should succeed when exceptions are suppressed.")]
        public void IsShorterOrEqualTo9()
        {
            string a = "test";
            Condition.Requires(a).SuppressExceptionsForTest().IsShorterOrEqualTo(1);
        }
    }
}