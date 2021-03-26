using System;
using Conditions.Extensions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Conditions.Tests.CompareTests
{
    [TestClass]
    public class CompareDateTimeTests
    {
        private static readonly DateTime One = new DateTime(2000, 1, 1);
        private static readonly DateTime Two = new DateTime(2000, 1, 2);
        private static readonly DateTime Three = new DateTime(2000, 1, 3);
        private static readonly DateTime Four = new DateTime(2000, 1, 4);
        private static readonly DateTime Five = new DateTime(2000, 1, 5);

        #region IsDateTimeInRange

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [Description("Calling IsInRange on DateTime x with 'lower bound > x < upper bound' should fail.")]
        public void IsDateTimeInRangeTest1()
        {
            DateTime a = One;
            Condition.Requires(a).IsInRange(Two, Four);
        }

        [TestMethod]
        [Description("Calling IsInRange on DateTime x with 'lower bound = x < upper bound' should pass.")]
        public void IsDateTimeInRangeTest2()
        {
            DateTime a = Two;
            Condition.Requires(a).IsInRange(Two, Four);
        }

        [TestMethod]
        [Description("Calling IsInRange on DateTime x with 'lower bound < x < upper bound' should pass.")]
        public void IsDateTimeInRangeTest3()
        {
            DateTime a = Three;
            Condition.Requires(a).IsInRange(Two, Four);
        }

        [TestMethod]
        [Description("Calling IsInRange on DateTime x with 'lower bound < x = upper bound' should pass.")]
        public void IsDateTimeInRangeTest4()
        {
            DateTime a = Four;
            Condition.Requires(a).IsInRange(Two, Four);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [Description("Calling IsInRange on DateTime x with 'lower bound < x > upper bound' should fail.")]
        public void IsDateTimeInRangeTest5()
        {
            DateTime a = Five;
            Condition.Requires(a).IsInRange(Two, Four);
        }

        [TestMethod]
        [Description("Calling IsInRange on DateTime x with 'lower bound > x < upper bound' should succeed when exceptions are suppressed.")]
        public void IsDateTimeInRangeTest6()
        {
            DateTime a = One;
            Condition.Requires(a).SuppressExceptionsForTest().IsInRange(Two, Four);
        }

        #endregion // IsDateTimeInRange

        #region IsDateTimeNotInRange

        [TestMethod]
        [Description("Calling IsNotInRange on DateTime x with 'lower bound > x < upper bound' should pass.")]
        public void IsDateTimeNotInRangeTest1()
        {
            DateTime a = One;
            Condition.Requires(a).IsNotInRange(Two, Four);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [Description("Calling IsNotInRange on DateTime x with 'lower bound = x < upper bound' should fail.")]
        public void IsDateTimeNotInRangeTest2()
        {
            DateTime a = Two;
            Condition.Requires(a).IsNotInRange(Two, Four);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [Description("Calling IsNotInRange on DateTime x with 'lower bound < x < upper bound' should fail.")]
        public void IsDateTimeNotInRangeTest3()
        {
            DateTime a = Three;
            Condition.Requires(a).IsNotInRange(Two, Four);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [Description("Calling IsNotInRange on DateTime x with 'lower bound < x = upper bound' should fail.")]
        public void IsDateTimeNotInRangeTest4()
        {
            DateTime a = Four;
            Condition.Requires(a).IsNotInRange(Two, Four);
        }

        [TestMethod]
        [Description("Calling IsNotInRange on DateTime x with 'lower bound < x > upper bound' should pass.")]
        public void IsDateTimeNotInRangeTest5()
        {
            DateTime a = Five;
            Condition.Requires(a).IsNotInRange(Two, Four);
        }

        [TestMethod]
        [Description("Calling IsNotInRange on DateTime x with 'lower bound = x < upper bound' should succeed when exceptions are suppressed.")]
        public void IsDateTimeNotInRangeTest6()
        {
            DateTime a = Two;
            Condition.Requires(a).SuppressExceptionsForTest().IsNotInRange(Two, Four);
        }

        #endregion // IsDateTimeNotInRange

        #region IsDateTimeGreaterThan

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [Description("Calling IsGreaterThan on DateTime x with 'lower bound < x' should fail.")]
        public void IsDateTimeGreaterThanTest1()
        {
            DateTime a = One;
            Condition.Requires(a).IsGreaterThan(Two);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [Description("Calling IsGreaterThan on DateTime x with 'lower bound = x' should fail.")]
        public void IsDateTimeGreaterThanTest2()
        {
            DateTime a = Two;
            Condition.Requires(a).IsGreaterThan(Two);
        }

        [TestMethod]
        [Description("Calling IsGreaterThan on DateTime x with 'lower bound < x' should pass.")]
        public void IsDateTimeGreaterThanTest3()
        {
            DateTime a = Three;
            Condition.Requires(a).IsGreaterThan(Two);
        }

        [TestMethod]
        [Description("Calling IsGreaterThan on DateTime x with 'lower bound < x' should succeed when exceptions are suppressed.")
        ]
        public void IsDateTimeGreaterThanTest4()
        {
            DateTime a = One;
            Condition.Requires(a).SuppressExceptionsForTest().IsGreaterThan(Two);
        }

        #endregion // IsDateTimeGreaterThan

        #region IsDateTimeGreaterOrEqualTo

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [Description("Calling IsGreaterOrEqualTo on DateTime x with 'lower bound > x' should fail.")]
        public void IsDateTimeGreaterOrEqualToTest1()
        {
            DateTime a = One;
            Condition.Requires(a).IsGreaterOrEqualTo(Two);
        }

        [TestMethod]
        [Description("Calling IsGreaterOrEqualTo on DateTime x with 'lower bound = x' should pass.")]
        public void IsDateTimeGreaterOrEqualToTest2()
        {
            DateTime a = Two;
            Condition.Requires(a).IsGreaterOrEqualTo(Two);
        }

        [TestMethod]
        [Description("Calling IsGreaterOrEqualTo on DateTime x with 'lower bound < x' should pass.")]
        public void IsDateTimeGreaterOrEqualToTest3()
        {
            DateTime a = Three;
            Condition.Requires(a).IsGreaterOrEqualTo(Two);
        }

        [TestMethod]
        [Description("Calling IsGreaterOrEqualTo on DateTime x with 'lower bound > x' should succeed when exceptions are suppressed.")]
        public void IsDateTimeGreaterOrEqualToTest4()
        {
            DateTime a = One;
            Condition.Requires(a).SuppressExceptionsForTest().IsGreaterOrEqualTo(Two);
        }

        #endregion // IsDateTimeGreaterOrEqualTo

        #region IsDateTimeLessThan

        [TestMethod]
        [Description("Calling IsLessThan on DateTime x with 'x < upper bound' should pass.")]
        public void IsDateTimeLessThanTest1()
        {
            DateTime a = One;
            Condition.Requires(a).IsLessThan(Two);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [Description("Calling IsLessThan on DateTime x with 'x = upper bound' should fail.")]
        public void IsDateTimeLessThanTest2()
        {
            DateTime a = Two;
            Condition.Requires(a).IsLessThan(Two);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [Description("Calling IsLessThan on DateTime x with 'x > upper bound' should fail.")]
        public void IsDateTimeLessThanTest3()
        {
            DateTime a = Three;
            Condition.Requires(a).IsLessThan(Two);
        }

        [TestMethod]
        [Description("Calling IsLessThan on DateTime x with 'x = upper bound' should succeed when exceptions are suppressed.")]
        public void IsDateTimeLessThanTest4()
        {
            DateTime a = Two;
            Condition.Requires(a).SuppressExceptionsForTest().IsLessThan(Two);
        }

        #endregion // IsDateTimeLessThan

        #region IsDateTimeLessOrEqualTo

        [TestMethod]
        [Description("Calling IsLessOrEqualTo on DateTime x with 'x < upper bound' should pass.")]
        public void IsDateTimeLessOrEqualTest1()
        {
            DateTime a = One;
            Condition.Requires(a).IsLessOrEqualTo(Two);
        }

        [TestMethod]
        [Description("Calling IsLessOrEqualTo on DateTime x with 'x = upper bound' should pass.")]
        public void IsDateTimeLessOrEqualTest2()
        {
            DateTime a = Two;
            Condition.Requires(a).IsLessOrEqualTo(Two);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [Description("Calling IsLessOrEqualTo on DateTime x with 'x > upper bound' should fail.")]
        public void IsDateTimeLessOrEqualTest3()
        {
            DateTime a = Three;
            Condition.Requires(a).IsLessOrEqualTo(Two);
        }

        [TestMethod]
        [Description("Calling IsLessOrEqualTo on DateTime x with 'x > upper bound' should succeed when exceptions are suppressed.")
        ]
        public void IsDateTimeLessOrEqualToTest4()
        {
            DateTime a = Three;
            Condition.Requires(a).SuppressExceptionsForTest().IsLessOrEqualTo(Two);
        }

        #endregion // IsDateTimeLessOrEqualTo

        #region IsDateTimeEqualTo

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [Description("Calling IsEqualTo on DateTime x with 'x < other' should fail.")]
        public void IsDateTimeEqualToTest1()
        {
            DateTime a = One;
            Condition.Requires(a).IsEqualTo(Two);
        }

        [TestMethod]
        [Description("Calling IsEqualTo on DateTime x with 'x = other' should pass.")]
        public void IsDateTimeEqualToTest2()
        {
            DateTime a = Two;
            Condition.Requires(a).IsEqualTo(Two);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [Description("Calling IsEqualTo on DateTime x with 'x > other' should fail.")]
        public void IsDateTimeEqualToTest3()
        {
            DateTime a = Three;
            Condition.Requires(a).IsEqualTo(Two);
        }

        [TestMethod]
        [Description("Calling IsEqualTo on DateTime x with 'x < other' should succeed when exceptions are suppressed.")]
        public void IsDateTimeEqualToTest4()
        {
            DateTime a = One;
            Condition.Requires(a).SuppressExceptionsForTest().IsEqualTo(Two);
        }

        #endregion // IsDateTimeEqualTo

        #region IsDateTimeNotEqualTo

        [TestMethod]
        [Description("Calling IsNotEqualTo on DateTime x with 'x < other' should pass.")]
        public void IsDateTimeNotEqualToTest1()
        {
            DateTime a = One;
            Condition.Requires(a).IsNotEqualTo(Two);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [Description("Calling IsNotEqualTo on DateTime x with 'x = other' should fail.")]
        public void IsDateTimeNotEqualToTest2()
        {
            DateTime a = Two;
            Condition.Requires(a).IsNotEqualTo(Two);
        }

        [TestMethod]
        [Description("Calling IsNotEqualTo on DateTime x with 'x > other' should pass.")]
        public void IsDateTimeNotEqualToTest3()
        {
            DateTime a = Three;
            Condition.Requires(a).IsNotEqualTo(Two);
        }

        [TestMethod]
        [Description("Calling IsNotEqualTo on DateTime x with 'x = other' should succeed when exceptions are suppressed.")]
        public void IsDateTimeNotEqualToTest4()
        {
            DateTime a = Two;
            Condition.Requires(a).SuppressExceptionsForTest().IsNotEqualTo(Two);
        }

        #endregion // IsDateTimeNotEqualTo
    }
}