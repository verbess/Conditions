using System;
using Conditions.Extensions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Conditions.Tests.NumericTests
{
    [TestClass]
    public partial class NumericSingleTests
    {
        #region IsSingleNaN

        [TestMethod]
        [Description("Calling IsNaN on Single x with x is not a number should succeed.")]
        public void IsSingleNaNTest1()
        {
            Single a = Single.NaN;
            Condition.Requires(a).IsNaN();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [Description("Calling IsNaN on Single x with x is a number should fail.")]
        public void IsSingleNaNTest2()
        {
            Single a = 4;
            Condition.Requires(a).IsNaN();
        }

        #endregion // IsSingleNaN

        #region IsSingleNonNaN

        [TestMethod]
        [Description("Calling IsNotNaN on Single x with x is a number should succeed.")]
        public void IsSingleNonNaNTest1()
        {
            Single a = 4;
            Condition.Requires(a).IsNotNaN();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [Description("Calling IsNotNaN on Single x with x is not a number should fail.")]
        public void IsSingleNonNaNTest2()
        {
            Single a = Single.NaN;
            Condition.Requires(a).IsNotNaN();
        }

        #endregion // IsSingleNonNaN

        #region IsSingleInfinity

        [TestMethod]
        [Description("Calling IsInfinity on Single x with x is negative infinity should succeed.")]
        public void IsSingleInfinityTest1()
        {
            Single a = Single.NegativeInfinity;
            Condition.Requires(a).IsInfinity();
        }

        [TestMethod]
        [Description("Calling IsInfinity on Single x with x is positive infinity should succeed.")]
        public void IsSingleInfinityTest2()
        {
            Single a = Single.PositiveInfinity;
            Condition.Requires(a).IsInfinity();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [Description("Calling IsInfinity on Single x with x is a number should fail.")]
        public void IsSingleInfinityTest3()
        {
            Single a = 4;
            Condition.Requires(a).IsInfinity();
        }

        #endregion // IsSingleInfinity

        #region IsSingleNotInfinity

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [Description("Calling IsNotInfinity on Single x with x is negative infinity should fail.")]
        public void IsSingleNotInfinityTest1()
        {
            Single a = Single.NegativeInfinity;
            Condition.Requires(a).IsNotInfinity();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [Description("Calling IsNotInfinity on Single x with x is positive infinity should fail.")]
        public void IsSingleNotInfinityTest2()
        {
            Single a = Single.PositiveInfinity;
            Condition.Requires(a).IsNotInfinity();
        }

        [TestMethod]
        [Description("Calling IsNotInfinity on Single x with x is a number should succeed.")]
        public void IsSingleNotInfinityTest3()
        {
            Single a = 4;
            Condition.Requires(a).IsNotInfinity();
        }

        #endregion // IsSingleNotInfinity

        #region IsSinglePositiveInfinity

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [Description("Calling IsPositiveInfinity on Single x with x is negative infinity should fail.")]
        public void IsSinglePositiveInfinityTest1()
        {
            Single a = Single.NegativeInfinity;
            Condition.Requires(a).IsPositiveInfinity();
        }

        [TestMethod]
        [Description("Calling IsPositiveInfinity on Single x with x is positive infinity should succeed.")]
        public void IsSinglePositiveInfinityTest2()
        {
            Single a = Single.PositiveInfinity;
            Condition.Requires(a).IsPositiveInfinity();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [Description("Calling IsPositiveInfinity on Single x with x is a number should fail.")]
        public void IsSinglePositiveInfinityTest3()
        {
            Single a = 4;
            Condition.Requires(a).IsPositiveInfinity();
        }

        #endregion // IsSinglePositiveInfinity

        #region IsSingleNotPositiveInfinity

        [TestMethod]
        [Description("Calling IsNotPositiveInfinity on Single x with x is negative infinity should succeed.")]
        public void IsSingleNotPositiveInfinityTest1()
        {
            Single a = Single.NegativeInfinity;
            Condition.Requires(a).IsNotPositiveInfinity();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [Description("Calling IsNotPositiveInfinity on Single x with x is positive infinity should fail.")]
        public void IsSingleNotPositiveInfinityTest2()
        {
            Single a = Single.PositiveInfinity;
            Condition.Requires(a).IsNotPositiveInfinity();
        }

        [TestMethod]
        [Description("Calling IsNotPositiveInfinity on Single x with x is a number should succeed.")]
        public void IsSingleNotPositiveInfinityTest3()
        {
            Single a = 4;
            Condition.Requires(a).IsNotPositiveInfinity();
        }

        #endregion // IsSingleNotPositiveInfinity

        #region IsSingleNegativeInfinity

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [Description("Calling IsNegativeInfinity on Single x with x is positive infinity should fail.")]
        public void IsSingleNegativeInfinityTest1()
        {
            Single a = Single.PositiveInfinity;
            Condition.Requires(a).IsNegativeInfinity();
        }

        [TestMethod]
        [Description("Calling IsNegativeInfinity on Single x with x is negative infinity should succeed.")]
        public void IsSingleNegativeInfinityTest2()
        {
            Single a = Single.NegativeInfinity;
            Condition.Requires(a).IsNegativeInfinity();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [Description("Calling IsNegativeInfinity on Single x with x is a number should fail.")]
        public void IsSingleNegativeInfinityTest3()
        {
            Single a = 4;
            Condition.Requires(a).IsNegativeInfinity();
        }

        #endregion // IsSingleNegativeInfinity

        #region IsSingleNotNegativeInfinity

        [TestMethod]
        [Description("Calling IsNotNegativeInfinity on Single x with x is positive infinity should succeed.")]
        public void IsSingleNotNegativeInfinityTest1()
        {
            Single a = Single.PositiveInfinity;
            Condition.Requires(a).IsNotNegativeInfinity();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [Description("Calling IsNotNegativeInfinity on Single x with x is negative infinity should fail.")]
        public void IsSingleNotNegativeInfinityTest2()
        {
            Single a = Single.NegativeInfinity;
            Condition.Requires(a).IsNotNegativeInfinity();
        }

        [TestMethod]
        [Description("Calling IsNotNegativeInfinity on Single x with x is a number should succeed.")]
        public void IsSingleNotNegativeInfinityTest3()
        {
            Single a = 4;
            Condition.Requires(a).IsNotNegativeInfinity();
        }

        #endregion // IsSingleNotNegativeInfinity
    }
}