using System;
using Conditions.Extensions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Conditions.Tests.NumericTests
{
    [TestClass]
    public partial class NumericDoubleTests
    {
        #region IsDoubleNaN

        [TestMethod]
        [Description("Calling IsNaN on Double x with x is not a number should succeed.")]
        public void IsDoubleNaNTest1()
        {
            Double a = Double.NaN;
            Condition.Requires(a).IsNaN();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [Description("Calling IsNaN on Double x with x is a number should fail.")]
        public void IsDoubleNaNTest2()
        {
            Double a = 4;
            Condition.Requires(a).IsNaN();
        }

        [TestMethod]
        [Description("Calling IsNaN on Double x should succeed when exceptions are suppressed.")]
        public void IsDoubleNaNTest3()
        {
            Double a = 4;
            Condition.Requires(a).SuppressExceptionsForTest().IsNaN();
        }

        #endregion // IsDoubleNaN

        #region IsDoubleNonNaN

        [TestMethod]
        [Description("Calling IsNotNaN on Double x with x is a number should succeed.")]
        public void IsDoubleNonNaNTest1()
        {
            Double a = 4;
            Condition.Requires(a).IsNotNaN();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [Description("Calling IsNotNaN on Double x with x is not a number should fail.")]
        public void IsDoubleNonNaNTest2()
        {
            Double a = Double.NaN;
            Condition.Requires(a).IsNotNaN();
        }

        [TestMethod]
        [Description("Calling IsNotNaN on Double x should succeed when exceptions are suppressed.")]
        public void IsDoubleNotNaNTest3()
        {
            Double a = Double.NaN;
            Condition.Requires(a).SuppressExceptionsForTest().IsNotNaN();
        }

        #endregion // IsDoubleNonNaN

        #region IsDoubleInfinity

        [TestMethod]
        [Description("Calling IsInfinity on Double x with x is negative infinity should succeed.")]
        public void IsDoubleInfinityTest1()
        {
            Double a = Double.NegativeInfinity;
            Condition.Requires(a).IsInfinity();
        }

        [TestMethod]
        [Description("Calling IsInfinity on Double x with x is positive infinity should succeed.")]
        public void IsDoubleInfinityTest2()
        {
            Double a = Double.PositiveInfinity;
            Condition.Requires(a).IsInfinity();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [Description("Calling IsInfinity on Double x with x is a number should fail.")]
        public void IsDoubleInfinityTest3()
        {
            Double a = 4;
            Condition.Requires(a).IsInfinity();
        }

        [TestMethod]
        [Description("Calling IsInfinity on Double x should succeed when exceptions are suppressed.")]
        public void IsDoubleInfinityTest4()
        {
            Double a = 4;
            Condition.Requires(a).SuppressExceptionsForTest().IsInfinity();
        }

        #endregion // IsDoubleInfinity

        #region IsDoubleNotInfinity

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [Description("Calling IsNotInfinity on Double x with x is negative infinity should fail.")]
        public void IsDoubleNotInfinityTest1()
        {
            Double a = Double.NegativeInfinity;
            Condition.Requires(a).IsNotInfinity();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [Description("Calling IsNotInfinity on Double x with x is positive infinity should fail.")]
        public void IsDoubleNotInfinityTest2()
        {
            Double a = Double.PositiveInfinity;
            Condition.Requires(a).IsNotInfinity();
        }

        [TestMethod]
        [Description("Calling IsNotInfinity on Double x with x is a number should succeed.")]
        public void IsDoubleNotInfinityTest3()
        {
            Double a = 4;
            Condition.Requires(a).IsNotInfinity();
        }

        [TestMethod]
        [Description("Calling IsNotInfinity on Double x should succeed when exceptions are suppressed.")]
        public void IsDoubleNotInfinityTest4()
        {
            Double a = Double.PositiveInfinity;
            Condition.Requires(a).SuppressExceptionsForTest().IsNotInfinity();
        }

        #endregion // IsDoubleNotInfinity

        #region IsDoublePositiveInfinity

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [Description("Calling IsPositiveInfinity on Double x with x is negative infinity should fail.")]
        public void IsDoublePositiveInfinityTest1()
        {
            Double a = Double.NegativeInfinity;
            Condition.Requires(a).IsPositiveInfinity();
        }

        [TestMethod]
        [Description("Calling IsPositiveInfinity on Double x with x is positive infinity should succeed.")]
        public void IsDoublePositiveInfinityTest2()
        {
            Double a = Double.PositiveInfinity;
            Condition.Requires(a).IsPositiveInfinity();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [Description("Calling IsPositiveInfinity on Double x with x is a number should fail.")]
        public void IsDoublePositiveInfinityTest3()
        {
            Double a = 4;
            Condition.Requires(a).IsPositiveInfinity();
        }

        [TestMethod]
        [Description("Calling IsPositiveInfinity on Double x should succeed when exceptions are suppressed.")]
        public void IsDoublePositiveInfinityTest4()
        {
            Double a = Double.NegativeInfinity;
            Condition.Requires(a).SuppressExceptionsForTest().IsPositiveInfinity();
        }

        #endregion // IsDoublePositiveInfinity

        #region IsDoubleNotPositiveInfinity

        [TestMethod]
        [Description("Calling IsNotPositiveInfinity on Double x with x is negative infinity should succeed.")]
        public void IsDoubleNotPositiveInfinityTest1()
        {
            Double a = Double.NegativeInfinity;
            Condition.Requires(a).IsNotPositiveInfinity();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [Description("Calling IsNotPositiveInfinity on Double x with x is positive infinity should fail.")]
        public void IsDoubleNotPositiveInfinityTest2()
        {
            Double a = Double.PositiveInfinity;
            Condition.Requires(a).IsNotPositiveInfinity();
        }

        [TestMethod]
        [Description("Calling IsNotPositiveInfinity on Double x with x is a number should succeed.")]
        public void IsDoubleNotPositiveInfinityTest3()
        {
            Double a = 4;
            Condition.Requires(a).IsNotPositiveInfinity();
        }

        [TestMethod]
        [Description("Calling IsNotPositiveInfinity on Double x should succeed when exceptions are suppressed.")]
        public void IsDoubleNotPositiveInfinityTest4()
        {
            Double a = Double.PositiveInfinity;
            Condition.Requires(a).SuppressExceptionsForTest().IsNotPositiveInfinity();
        }

        #endregion // IsDoubleNotPositiveInfinity

        #region IsDoubleNegativeInfinity

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [Description("Calling IsNegativeInfinity on Double x with x is positive infinity should fail.")]
        public void IsDoubleNegativeInfinityTest1()
        {
            Double a = Double.PositiveInfinity;
            Condition.Requires(a).IsNegativeInfinity();
        }

        [TestMethod]
        [Description("Calling IsNegativeInfinity on Double x with x is negative infinity should succeed.")]
        public void IsDoubleNegativeInfinityTest2()
        {
            Double a = Double.NegativeInfinity;
            Condition.Requires(a).IsNegativeInfinity();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [Description("Calling IsNegativeInfinity on Double x with x is a number should fail.")]
        public void IsDoubleNegativeInfinityTest3()
        {
            Double a = 4;
            Condition.Requires(a).IsNegativeInfinity();
        }

        [TestMethod]
        [Description("Calling IsNegativeInfinity on Double x should succeed when exceptions are suppressed.")]
        public void IsDoubleNegativeInfinityTest4()
        {
            Double a = Double.PositiveInfinity;
            Condition.Requires(a).SuppressExceptionsForTest().IsNegativeInfinity();
        }

        #endregion // IsDoubleNegativeInfinity

        #region IsDoubleNotNegativeInfinity

        [TestMethod]
        [Description("Calling IsNotNegativeInfinity on Double x with x is positive infinity should succeed.")]
        public void IsDoubleNotNegativeInfinityTest1()
        {
            Double a = Double.PositiveInfinity;
            Condition.Requires(a).IsNotNegativeInfinity();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [Description("Calling IsNotNegativeInfinity on Double x with x is negative infinity should fail.")]
        public void IsDoubleNotNegativeInfinityTest2()
        {
            Double a = Double.NegativeInfinity;
            Condition.Requires(a).IsNotNegativeInfinity();
        }

        [TestMethod]
        [Description("Calling IsNotNegativeInfinity on Double x with x is a number should succeed.")]
        public void IsDoubleNotNegativeInfinityTest3()
        {
            Double a = 4;
            Condition.Requires(a).IsNotNegativeInfinity();
        }

        [TestMethod]
        [Description("Calling IsNotNegativeInfinity on Double x should succeed when exceptions are suppressed.")]
        public void IsDoubleNotNegativeInfinityTest4()
        {
            Double a = Double.NegativeInfinity;
            Condition.Requires(a).SuppressExceptionsForTest().IsNotNegativeInfinity();
        }

        #endregion // IsDoubleNotNegativeInfinity
    }
}