using System;
using Conditions.Extensions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Conditions.Tests.CompareTests
{
    [TestClass]
    public class CompareDoubleTests
    {
        private static readonly Double One = 1;
        private static readonly Double Two = 2;
        private static readonly Double Three = 3;
        private static readonly Double Four = 4;
        private static readonly Double Five = 5;

        #region IsDoubleInRange

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [Description("Calling IsInRange on Double x with 'lower bound > x < upper bound' should fail.")]
        public void IsDoubleInRangeTest1()
        {
            Double a = One;
            Condition.Requires(a).IsInRange(Two, Four);
        }

        [TestMethod]
        [Description("Calling IsInRange on Double x with 'lower bound = x < upper bound' should pass.")]
        public void IsDoubleInRangeTest2()
        {
            Double a = Two;
            Condition.Requires(a).IsInRange(Two, Four);
        }

        [TestMethod]
        [Description("Calling IsInRange on Double x with 'lower bound < x < upper bound' should pass.")]
        public void IsDoubleInRangeTest3()
        {
            Double a = Three;
            Condition.Requires(a).IsInRange(Two, Four);
        }

        [TestMethod]
        [Description("Calling IsInRange on Double x with 'lower bound < x = upper bound' should pass.")]
        public void IsDoubleInRangeTest4()
        {
            Double a = Four;
            Condition.Requires(a).IsInRange(Two, Four);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [Description("Calling IsInRange on Double x with 'lower bound < x > upper bound' should fail.")]
        public void IsDoubleInRangeTest5()
        {
            Double a = Five;
            Condition.Requires(a).IsInRange(Two, Four);
        }

        [TestMethod]
        [Description("Calling IsInRange on Double x with 'lower bound > x < upper bound' should succeed when exceptions are suppressed.")]
        public void IsDoubleInRangeTest6()
        {
            Double a = One;
            Condition.Requires(a).SuppressExceptionsForTest().IsInRange(Two, Four);
        }

        #endregion // IsDoubleInRange

        #region IsDoubleNotInRange

        [TestMethod]
        [Description("Calling IsNotInRange on Double x with 'lower bound > x < upper bound' should pass.")]
        public void IsDoubleNotInRangeTest1()
        {
            Double a = One;
            Condition.Requires(a).IsNotInRange(Two, Four);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [Description("Calling IsNotInRange on Double x with 'lower bound = x < upper bound' should fail.")]
        public void IsDoubleNotInRangeTest2()
        {
            Double a = Two;
            Condition.Requires(a).IsNotInRange(Two, Four);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [Description("Calling IsNotInRange on Double x with 'lower bound < x < upper bound' should fail.")]
        public void IsDoubleNotInRangeTest3()
        {
            Double a = Three;
            Condition.Requires(a).IsNotInRange(Two, Four);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [Description("Calling IsNotInRange on Double x with 'lower bound < x = upper bound' should fail.")]
        public void IsDoubleNotInRangeTest4()
        {
            Double a = Four;
            Condition.Requires(a).IsNotInRange(Two, Four);
        }

        [TestMethod]
        [Description("Calling IsNotInRange on Double x with 'lower bound < x > upper bound' should pass.")]
        public void IsDoubleNotInRangeTest5()
        {
            Double a = Five;
            Condition.Requires(a).IsNotInRange(Two, Four);
        }

        [TestMethod]
        [Description("Calling IsNotInRange on Double x with 'lower bound = x < upper bound' should succeed when exceptions are suppressed.")]
        public void IsDoubleNotInRangeTest6()
        {
            Double a = Two;
            Condition.Requires(a).SuppressExceptionsForTest().IsNotInRange(Two, Four);
        }

        #endregion // IsDoubleNotInRange

        #region IsDoubleGreaterThan

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [Description("Calling IsGreaterThan on Double x with 'lower bound < x' should fail.")]
        public void IsDoubleGreaterThanTest1()
        {
            Double a = One;
            Condition.Requires(a).IsGreaterThan(Two);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [Description("Calling IsGreaterThan on Double x with 'lower bound = x' should fail.")]
        public void IsDoubleGreaterThanTest2()
        {
            Double a = Two;
            Condition.Requires(a).IsGreaterThan(Two);
        }

        [TestMethod]
        [Description("Calling IsGreaterThan on Double x with 'lower bound < x' should pass.")]
        public void IsDoubleGreaterThanTest3()
        {
            Double a = Three;
            Condition.Requires(a).IsGreaterThan(Two);
        }

        [TestMethod]
        [Description("Calling IsGreaterThan on Double x with 'lower bound < x' should succeed when exceptions are suppressed.")]
        public void IsDoubleGreaterThanTest4()
        {
            Double a = One;
            Condition.Requires(a).SuppressExceptionsForTest().IsGreaterThan(Two);
        }

        #endregion // IsDoubleGreaterThan

        #region IsDoubleGreaterOrEqualTo

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [Description("Calling IsGreaterOrEqualTo on Double x with 'lower bound > x' should fail.")]
        public void IsDoubleGreaterOrEqualToTest1()
        {
            Double a = One;
            Condition.Requires(a).IsGreaterOrEqualTo(Two);
        }

        [TestMethod]
        [Description("Calling IsGreaterOrEqualTo on Double x with 'lower bound = x' should pass.")]
        public void IsDoubleGreaterOrEqualToTest2()
        {
            Double a = Two;
            Condition.Requires(a).IsGreaterOrEqualTo(Two);
        }

        [TestMethod]
        [Description("Calling IsGreaterOrEqualTo on Double x with 'lower bound < x' should pass.")]
        public void IsDoubleGreaterOrEqualToTest3()
        {
            Double a = Three;
            Condition.Requires(a).IsGreaterOrEqualTo(Two);
        }

        [TestMethod]
        [Description("Calling IsGreaterOrEqualTo on Double x with 'lower bound > x' should succeed when exceptions are suppressed.")]
        public void IsDoubleGreaterOrEqualToTest4()
        {
            Double a = One;
            Condition.Requires(a).SuppressExceptionsForTest().IsGreaterOrEqualTo(Two);
        }

        #endregion // IsDoubleGreaterOrEqualTo

        #region IsDoubleLessThan

        [TestMethod]
        [Description("Calling IsLessThan on Double x with 'x < upper bound' should pass.")]
        public void IsDoubleLessThanTest1()
        {
            Double a = One;
            Condition.Requires(a).IsLessThan(Two);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [Description("Calling IsLessThan on Double x with 'x = upper bound' should fail.")]
        public void IsDoubleLessThanTest2()
        {
            Double a = Two;
            Condition.Requires(a).IsLessThan(Two);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [Description("Calling IsLessThan on Double x with 'x > upper bound' should fail.")]
        public void IsDoubleLessThanTest3()
        {
            Double a = Three;
            Condition.Requires(a).IsLessThan(Two);
        }

        [TestMethod]
        [Description("Calling IsLessThan on Double x with 'x = upper bound' should succeed when exceptions are suppressed.")]
        public void IsDoubleLessThanTest4()
        {
            Double a = Two;
            Condition.Requires(a).SuppressExceptionsForTest().IsLessThan(Two);
        }

        #endregion // IsDoubleLessThan

        #region IsDoubleLessOrEqualTo

        [TestMethod]
        [Description("Calling IsLessOrEqualTo on Double x with 'x < upper bound' should pass.")]
        public void IsDoubleLessOrEqualToTest1()
        {
            Double a = One;
            Condition.Requires(a).IsLessOrEqualTo(Two);
        }

        [TestMethod]
        [Description("Calling IsLessOrEqualTo on Double x with 'x = upper bound' should pass.")]
        public void IsDoubleLessOrEqualToTest2()
        {
            Double a = Two;
            Condition.Requires(a).IsLessOrEqualTo(Two);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [Description("Calling IsLessOrEqualTo on Double x with 'x > upper bound' should fail.")]
        public void IsDoubleLessOrEqualToTest3()
        {
            Double a = Three;
            Condition.Requires(a).IsLessOrEqualTo(Two);
        }

        [TestMethod]
        [Description("Calling IsLessOrEqualTo on Double x with 'x > upper bound' should succeed when exceptions are suppressed.")]
        public void IsDoubleLessOrEqualToTest4()
        {
            Double a = Three;
            Condition.Requires(a).SuppressExceptionsForTest().IsLessOrEqualTo(Two);
        }

        #endregion // IsDoubleLessOrEqualTo

        #region IsDoubleEqualTo

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [Description("Calling IsEqualTo on Double x with 'x < other' should fail.")]
        public void IsDoubleEqualToTest1()
        {
            Double a = One;
            Condition.Requires(a).IsEqualTo(Two);
        }

        [TestMethod]
        [Description("Calling IsEqualTo on Double x with 'x = other' should pass.")]
        public void IsDoubleEqualToTest2()
        {
            Double a = Two;
            Condition.Requires(a).IsEqualTo(Two);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [Description("Calling IsEqualTo on Double x with 'x > other' should fail.")]
        public void IsDoubleEqualToTest3()
        {
            Double a = Three;
            Condition.Requires(a).IsEqualTo(Two);
        }

        [TestMethod]
        [Description("Calling IsEqualTo on Double x with 'x < other' should succeed when exceptions are suppressed.")]
        public void IsDoubleEqualToTest4()
        {
            Double a = One;
            Condition.Requires(a).SuppressExceptionsForTest().IsEqualTo(Two);
        }

        #endregion // IsDoubleEqualTo

        #region IsDoubleNotEqualTo

        [TestMethod]
        [Description("Calling IsNotEqualTo on Double x with 'x < other' should pass.")]
        public void IsDoubleNotEqualToTest1()
        {
            Double a = One;
            Condition.Requires(a).IsNotEqualTo(Two);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [Description("Calling IsNotEqualTo on Double x with 'x = other' should fail.")]
        public void IsDoubleNotEqualToTest2()
        {
            Double a = Two;
            Condition.Requires(a).IsNotEqualTo(Two);
        }

        [TestMethod]
        [Description("Calling IsNotEqualTo on Double x with 'x > other' should pass.")]
        public void IsDoubleNotEqualToTest3()
        {
            Double a = Three;
            Condition.Requires(a).IsNotEqualTo(Two);
        }

        [TestMethod]
        [Description("Calling IsNotEqualTo on Double x with 'x = other' should succeed when exceptions are suppressed.")]
        public void IsDoubleNotEqualToTest4()
        {
            Double a = Two;
            Condition.Requires(a).SuppressExceptionsForTest().IsNotEqualTo(Two);
        }

        #endregion // IsDoubleNotEqualTo
    }
}