using System;
using Conditions.Extensions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Conditions.Tests.CompareTests
{
    [TestClass]
    public class CompareBooleanTests
    {
        #region IsTrue

        [TestMethod]
        [Description("Calling IsTrue on Boolean x with 'x == true' should pass.")]
        public void IsTrueTest1()
        {
            bool b = true;
            Condition.Requires(b).IsTrue();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [Description("Calling IsTrue on Boolean x with 'x == false' should fail.")]
        public void IsTrueTest2()
        {
            bool b = false;
            Condition.Requires(b).IsTrue();
        }

        [TestMethod]
        [Description("Calling IsTrue on Boolean? x with 'x == true' should pass.")]
        public void IsTrueTest3()
        {
            bool? b = true;
            Condition.Requires(b).IsTrue();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [Description("Calling IsTrue on Boolean? x with 'x == false' should fail.")]
        public void IsTrueTest4()
        {
            bool? b = false;
            Condition.Requires(b).IsTrue();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        [Description("Calling IsTrue on Boolean? x with 'x == null' should fail.")]
        public void IsTrueTest5()
        {
            bool? b = null;
            Condition.Requires(b).IsTrue();
        }

        [TestMethod]
        [Description("Calling IsTrue on Boolean x with 'x == false' should succeed when exceptions are suppressed.")]
        public void IsTrueTest6()
        {
            bool b = false;
            Condition.Requires(b).SuppressExceptionsForTest().IsTrue();
        }

        #endregion // IsTrue

        #region IsFalse

        [TestMethod]
        [Description("Calling IsFalse on Boolean x with 'x == false' should pass.")]
        public void IsFalseTest1()
        {
            bool b = false;
            Condition.Requires(b).IsFalse();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [Description("Calling IsFalse on Boolean x with 'x == true' should fail.")]
        public void IsFalseTest2()
        {
            bool b = true;
            Condition.Requires(b).IsFalse();
        }

        [TestMethod]
        [Description("Calling IsFalse on Boolean? x with 'x == false' should pass.")]
        public void IsFalseTest3()
        {
            bool? b = false;
            Condition.Requires(b).IsFalse();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [Description("Calling IsFalse on Boolean? x with 'x == true' should fail.")]
        public void IsFalseTest4()
        {
            bool? b = true;
            Condition.Requires(b).IsFalse();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        [Description("Calling IsFalse on Boolean? x with 'x == null' should fail.")]
        public void IsFalseTest5()
        {
            bool? b = null;
            Condition.Requires(b).IsFalse();
        }

        [TestMethod]
        [Description("Calling IsFalse on Boolean x with 'x == true' should succeed when exceptions are suppressed.")]
        public void IsFalseTest6()
        {
            bool b = true;
            Condition.Requires(b).SuppressExceptionsForTest().IsFalse();
        }

        #endregion // IsFalse
    }
}