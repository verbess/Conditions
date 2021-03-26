using System;
using Conditions.Extensions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Conditions.Tests.CompareTests
{
    [TestClass]
    public class CompareDecimalTests
    {
        private static readonly Decimal One = 1;
        private static readonly Decimal Two = 2;
        private static readonly Decimal Three = 3;
        private static readonly Decimal Four = 4;
        private static readonly Decimal Five = 5;

        #region IsDecimalInRange

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [Description("Calling IsInRange on Decimal x with 'lower bound > x < upper bound' should fail.")]
        public void IsDecimalInRangeTest1()
        {
            Decimal a = One;
            Condition.Requires(a).IsInRange(Two, Four);
        }

        [TestMethod]
        [Description("Calling IsInRange on Decimal x with 'lower bound = x < upper bound' should pass.")]
        public void IsDecimalInRangeTest2()
        {
            Decimal a = Two;
            Condition.Requires(a).IsInRange(Two, Four);
        }

        [TestMethod]
        [Description("Calling IsInRange on Decimal x with 'lower bound < x < upper bound' should pass.")]
        public void IsDecimalInRangeTest3()
        {
            Decimal a = Three;
            Condition.Requires(a).IsInRange(Two, Four);
        }

        [TestMethod]
        [Description("Calling IsInRange on Decimal x with 'lower bound < x = upper bound' should pass.")]
        public void IsDecimalInRangeTest4()
        {
            Decimal a = Four;
            Condition.Requires(a).IsInRange(Two, Four);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [Description("Calling IsInRange on Decimal x with 'lower bound < x > upper bound' should fail.")]
        public void IsDecimalInRangeTest5()
        {
            Decimal a = Five;
            Condition.Requires(a).IsInRange(Two, Four);
        }

        [TestMethod]
        [Description("Calling IsInRange on Decimal x with 'lower bound > x < upper bound' should succeed when exceptions are suppressed.")]
        public void IsDecimalInRangeTest6()
        {
            Decimal a = One;
            Condition.Requires(a).SuppressExceptionsForTest().IsInRange(Two, Four);
        }

        #endregion // IsDecimalInRange

        #region IsDecimalNotInRange

        [TestMethod]
        [Description("Calling IsNotInRange on Decimal x with 'lower bound > x < upper bound' should pass.")]
        public void IsDecimalNotInRangeTest1()
        {
            Decimal a = One;
            Condition.Requires(a).IsNotInRange(Two, Four);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [Description("Calling IsNotInRange on Decimal x with 'lower bound = x < upper bound' should fail.")]
        public void IsDecimalNotInRangeTest2()
        {
            Decimal a = Two;
            Condition.Requires(a).IsNotInRange(Two, Four);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [Description("Calling IsNotInRange on Decimal x with 'lower bound < x < upper bound' should fail.")]
        public void IsDecimalNotInRangeTest3()
        {
            Decimal a = Three;
            Condition.Requires(a).IsNotInRange(Two, Four);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [Description("Calling IsNotInRange on Decimal x with 'lower bound < x = upper bound' should fail.")]
        public void IsDecimalNotInRangeTest4()
        {
            Decimal a = Four;
            Condition.Requires(a).IsNotInRange(Two, Four);
        }

        [TestMethod]
        [Description("Calling IsNotInRange on Decimal x with 'lower bound < x > upper bound' should pass.")]
        public void IsDecimalNotInRangeTest5()
        {
            Decimal a = Five;
            Condition.Requires(a).IsNotInRange(Two, Four);
        }

        [TestMethod]
        [Description("Calling IsNotInRange on Decimal x with 'lower bound = x < upper bound' should succeed when exceptions are suppressed.")]
        public void IsDecimalNotInRangeTest6()
        {
            Decimal a = Two;
            Condition.Requires(a).SuppressExceptionsForTest().IsNotInRange(Two, Four);
        }

        #endregion // IsDecimalNotInRange

        #region IsDecimalGreaterThan

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [Description("Calling IsGreaterThan on Decimal x with 'lower bound < x' should fail.")]
        public void IsDecimalGreaterThanTest1()
        {
            Decimal a = One;
            Condition.Requires(a).IsGreaterThan(Two);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [Description("Calling IsGreaterThan on Decimal x with 'lower bound = x' should fail.")]
        public void IsDecimalGreaterThanTest2()
        {
            Decimal a = Two;
            Condition.Requires(a).IsGreaterThan(Two);
        }

        [TestMethod]
        [Description("Calling IsGreaterThan on Decimal x with 'lower bound < x' should pass.")]
        public void IsDecimalGreaterThanTest3()
        {
            Decimal a = Three;
            Condition.Requires(a).IsGreaterThan(Two);
        }

        [TestMethod]
        [Description("Calling IsGreaterThan on Decimal x with 'lower bound < x' should succeed when exceptions are suppressed.")]
        public void IsDecimalGreaterThanTest4()
        {
            Decimal a = One;
            Condition.Requires(a).SuppressExceptionsForTest().IsGreaterThan(Two);
        }

        #endregion // IsDecimalGreaterThan

        #region IsDecimalGreaterOrEqualTo

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [Description("Calling IsGreaterOrEqualTo on Decimal x with 'lower bound > x' should fail.")]
        public void IsDecimalGreaterOrEqualToTest1()
        {
            Decimal a = One;
            Condition.Requires(a).IsGreaterOrEqualTo(Two);
        }

        [TestMethod]
        [Description("Calling IsGreaterOrEqualTo on Decimal x with 'lower bound = x' should pass.")]
        public void IsDecimalGreaterOrEqualToTest2()
        {
            Decimal a = Two;
            Condition.Requires(a).IsGreaterOrEqualTo(Two);
        }

        [TestMethod]
        [Description("Calling IsGreaterOrEqualTo on Decimal x with 'lower bound < x' should pass.")]
        public void IsDecimalGreaterOrEqualToTest3()
        {
            Decimal a = Three;
            Condition.Requires(a).IsGreaterOrEqualTo(Two);
        }

        [TestMethod]
        [Description("Calling IsGreaterOrEqualTo on Decimal x with 'lower bound > x' should succeed when exceptions are suppressed.")]
        public void IsDecimalGreaterOrEqualToTest4()
        {
            Decimal a = One;
            Condition.Requires(a).SuppressExceptionsForTest().IsGreaterOrEqualTo(Two);
        }

        #endregion // IsDecimalGreaterOrEqualTo

        #region IsDecimalLessThan

        [TestMethod]
        [Description("Calling IsLessThan on Decimal x with 'x < upper bound' should pass.")]
        public void IsDecimalLessThanTest1()
        {
            Decimal a = One;
            Condition.Requires(a).IsLessThan(Two);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [Description("Calling IsLessThan on Decimal x with 'x = upper bound' should fail.")]
        public void IsDecimalLessThanTest2()
        {
            Decimal a = Two;
            Condition.Requires(a).IsLessThan(Two);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [Description("Calling IsLessThan on Decimal x with 'x > upper bound' should fail.")]
        public void IsDecimalLessThanTest3()
        {
            Decimal a = Three;
            Condition.Requires(a).IsLessThan(Two);
        }

        [TestMethod]
        [Description("Calling IsLessThan on Decimal x with 'x = upper bound' should succeed when exceptions are suppressed.")]
        public void IsDecimalLessThanTest4()
        {
            Decimal a = Two;
            Condition.Requires(a).SuppressExceptionsForTest().IsLessThan(Two);
        }

        #endregion // IsDecimalLessThan

        #region IsDecimalLessOrEqualTo

        [TestMethod]
        [Description("Calling IsLessOrEqualTo on Decimal x with 'x < upper bound' should pass.")]
        public void IsDecimalLessOrEqualToTest1()
        {
            Decimal a = One;
            Condition.Requires(a).IsLessOrEqualTo(Two);
        }

        [TestMethod]
        [Description("Calling IsLessOrEqualTo on Decimal x with 'x = upper bound' should pass.")]
        public void IsDecimalLessOrEqualToTest2()
        {
            Decimal a = Two;
            Condition.Requires(a).IsLessOrEqualTo(Two);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [Description("Calling IsLessOrEqualTo on Decimal x with 'x > upper bound' should fail.")]
        public void IsDecimalLessOrEqualToTest3()
        {
            Decimal a = Three;
            Condition.Requires(a).IsLessOrEqualTo(Two);
        }

        [TestMethod]
        [Description("Calling IsLessOrEqualTo on Decimal x with 'x > upper bound' should succeed when exceptions are suppressed.")]
        public void IsDecimalLessOrEqualToTest4()
        {
            Decimal a = Three;
            Condition.Requires(a).SuppressExceptionsForTest().IsLessOrEqualTo(Two);
        }

        #endregion // IsDecimalLessOrEqualTo

        #region IsDecimalEqualTo

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [Description("Calling IsEqualTo on Decimal x with 'x < other' should fail.")]
        public void IsDecimalEqualToTest1()
        {
            Decimal a = One;
            Condition.Requires(a).IsEqualTo(Two);
        }

        [TestMethod]
        [Description("Calling IsEqualTo on Decimal x with 'x = other' should pass.")]
        public void IsDecimalEqualToTest2()
        {
            Decimal a = Two;
            Condition.Requires(a).IsEqualTo(Two);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [Description("Calling IsEqualTo on Decimal x with 'x > other' should fail.")]
        public void IsDecimalEqualToTest3()
        {
            Decimal a = Three;
            Condition.Requires(a).IsEqualTo(Two);
        }

        [TestMethod]
        [Description("Calling IsEqualTo on Decimal x with 'x < other' should succeed when exceptions are suppressed.")]
        public void IsDecimalEqualToTest4()
        {
            Decimal a = One;
            Condition.Requires(a).SuppressExceptionsForTest().IsEqualTo(Two);
        }

        #endregion // IsDecimalEqualTo

        #region IsDecimalNotEqualTo

        [TestMethod]
        [Description("Calling IsNotEqualTo on Decimal x with 'x < other' should pass.")]
        public void IsDecimalNotEqualToTest1()
        {
            Decimal a = One;
            Condition.Requires(a).IsNotEqualTo(Two);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [Description("Calling IsNotEqualTo on Decimal x with 'x = other' should fail.")]
        public void IsDecimalNotEqualToTest2()
        {
            Decimal a = Two;
            Condition.Requires(a).IsNotEqualTo(Two);
        }

        [TestMethod]
        [Description("Calling IsNotEqualTo on Decimal x with 'x > other' should pass.")]
        public void IsDecimalNotEqualToTest3()
        {
            Decimal a = Three;
            Condition.Requires(a).IsNotEqualTo(Two);
        }

        [TestMethod]
        [Description("Calling IsNotEqualTo on Decimal x with 'x = other' should succeed when exceptions are suppressed.")]
        public void IsDecimalNotEqualToTest4()
        {
            Decimal a = Two;
            Condition.Requires(a).SuppressExceptionsForTest().IsNotEqualTo(Two);
        }

        #endregion // IsDecimalNotEqualTo
    }
}