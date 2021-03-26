using System;
using Conditions.Extensions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Conditions.Tests.CompareTests
{
    [TestClass]
    public class CompareInt64Tests
    {
        private static readonly Int64 One = 1;
        private static readonly Int64 Two = 2;
        private static readonly Int64 Three = 3;
        private static readonly Int64 Four = 4;
        private static readonly Int64 Five = 5;

        #region IsInt64InRange

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [Description("Calling IsInRange on Int64 x with 'lower bound > x < upper bound' should fail.")]
        public void IsInt64InRangeTest1()
        {
            Int64 a = One;
            Condition.Requires(a).IsInRange(Two, Four);
        }

        [TestMethod]
        [Description("Calling IsInRange on Int64 x with 'lower bound = x < upper bound' should pass.")]
        public void IsInt64InRangeTest2()
        {
            Int64 a = Two;
            Condition.Requires(a).IsInRange(Two, Four);
        }

        [TestMethod]
        [Description("Calling IsInRange on Int64 x with 'lower bound < x < upper bound' should pass.")]
        public void IsInt64InRangeTest3()
        {
            Int64 a = Three;
            Condition.Requires(a).IsInRange(Two, Four);
        }

        [TestMethod]
        [Description("Calling IsInRange on Int64 x with 'lower bound < x = upper bound' should pass.")]
        public void IsInt64InRangeTest4()
        {
            Int64 a = Four;
            Condition.Requires(a).IsInRange(Two, Four);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [Description("Calling IsInRange on Int64 x with 'lower bound < x > upper bound' should fail.")]
        public void IsInt64InRangeTest5()
        {
            Int64 a = Five;
            Condition.Requires(a).IsInRange(Two, Four);
        }

        [TestMethod]
        [Description("Calling IsInRange on Int64 x with 'lower bound > x < upper bound' should succeed when exceptions are suppressed.")]
        public void IsInt64InRangeTest6()
        {
            Int64 a = One;
            Condition.Requires(a).SuppressExceptionsForTest().IsInRange(Two, Four);
        }

        #endregion // IsInt64InRange

        #region IsInt64NotInRange

        [TestMethod]
        [Description("Calling IsNotInRange on Int64 x with 'lower bound > x < upper bound' should pass.")]
        public void IsInt64NotInRangeTest1()
        {
            Int64 a = One;
            Condition.Requires(a).IsNotInRange(Two, Four);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [Description("Calling IsNotInRange on Int64 x with 'lower bound = x < upper bound' should fail.")]
        public void IsInt64NotInRangeTest2()
        {
            Int64 a = Two;
            Condition.Requires(a).IsNotInRange(Two, Four);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [Description("Calling IsNotInRange on Int64 x with 'lower bound < x < upper bound' should fail.")]
        public void IsInt64NotInRangeTest3()
        {
            Int64 a = Three;
            Condition.Requires(a).IsNotInRange(Two, Four);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [Description("Calling IsNotInRange on Int64 x with 'lower bound < x = upper bound' should fail.")]
        public void IsInt64NotInRangeTest4()
        {
            Int64 a = Four;
            Condition.Requires(a).IsNotInRange(Two, Four);
        }

        [TestMethod]
        [Description("Calling IsNotInRange on Int64 x with 'lower bound < x > upper bound' should pass.")]
        public void IsInt64NotInRangeTest5()
        {
            Int64 a = Five;
            Condition.Requires(a).IsNotInRange(Two, Four);
        }

        [TestMethod]
        [Description("Calling IsNotInRange on Int64 x with 'lower bound = x < upper bound' should succeed when exceptions are suppressed.")]
        public void IsInt64NotInRangeTest6()
        {
            Int64 a = Two;
            Condition.Requires(a).SuppressExceptionsForTest().IsNotInRange(Two, Four);
        }

        #endregion // IsInt64NotInRange

        #region IsInt64GreaterThan

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [Description("Calling IsGreaterThan on Int64 x with 'lower bound < x' should fail.")]
        public void IsInt64GreaterThanTest1()
        {
            Int64 a = One;
            Condition.Requires(a).IsGreaterThan(Two);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [Description("Calling IsGreaterThan on Int64 x with 'lower bound = x' should fail.")]
        public void IsInt64GreaterThanTest2()
        {
            Int64 a = Two;
            Condition.Requires(a).IsGreaterThan(Two);
        }

        [TestMethod]
        [Description("Calling IsGreaterThan on Int64 x with 'lower bound < x' should pass.")]
        public void IsInt64GreaterThanTest3()
        {
            Int64 a = Three;
            Condition.Requires(a).IsGreaterThan(Two);
        }

        [TestMethod]
        [Description("Calling IsGreaterThan on Int64 x with 'lower bound < x' should succeed when exceptions are suppressed.")]
        public void IsInt64GreaterThanTest4()
        {
            Int64 a = One;
            Condition.Requires(a).SuppressExceptionsForTest().IsGreaterThan(Two);
        }

        #endregion // IsInt64GreaterThan

        #region IsInt64GreaterOrEqualTo

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [Description("Calling IsGreaterOrEqualTo on Int64 x with 'lower bound > x' should fail.")]
        public void IsInt64GreaterOrEqualToTest1()
        {
            Int64 a = One;
            Condition.Requires(a).IsGreaterOrEqualTo(Two);
        }

        [TestMethod]
        [Description("Calling IsGreaterOrEqualTo on Int64 x with 'lower bound = x' should pass.")]
        public void IsInt64GreaterOrEqualToTest2()
        {
            Int64 a = Two;
            Condition.Requires(a).IsGreaterOrEqualTo(Two);
        }

        [TestMethod]
        [Description("Calling IsGreaterOrEqualTo on Int64 x with 'lower bound < x' should pass.")]
        public void IsInt64GreaterOrEqualToTest3()
        {
            Int64 a = Three;
            Condition.Requires(a).IsGreaterOrEqualTo(Two);
        }

        [TestMethod]
        [Description("Calling IsGreaterOrEqualTo on Int64 x with 'lower bound > x' should succeed when exceptions are suppressed.")]
        public void IsInt64GreaterOrEqualToTest4()
        {
            Int64 a = One;
            Condition.Requires(a).SuppressExceptionsForTest().IsGreaterOrEqualTo(Two);
        }

        #endregion // IsInt64GreaterOrEqualTo

        #region IsInt64LessThan

        [TestMethod]
        [Description("Calling IsLessThan on Int64 x with 'x < upper bound' should pass.")]
        public void IsInt64LessThanTest1()
        {
            Int64 a = One;
            Condition.Requires(a).IsLessThan(Two);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [Description("Calling IsLessThan on Int64 x with 'x = upper bound' should fail.")]
        public void IsInt64LessThanTest2()
        {
            Int64 a = Two;
            Condition.Requires(a).IsLessThan(Two);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [Description("Calling IsLessThan on Int64 x with 'x > upper bound' should fail.")]
        public void IsInt64LessThanTest3()
        {
            Int64 a = Three;
            Condition.Requires(a).IsLessThan(Two);
        }

        [TestMethod]
        [Description("Calling IsLessThan on Int64 x with 'x = upper bound' should succeed when exceptions are suppressed.")]
        public void IsInt64LessThanTest4()
        {
            Int64 a = Two;
            Condition.Requires(a).SuppressExceptionsForTest().IsLessThan(Two);
        }

        #endregion // IsInt64LessThan

        #region IsInt64LessOrEqualTo

        [TestMethod]
        [Description("Calling IsLessOrEqualTo on Int64 x with 'x < upper bound' should pass.")]
        public void IsInt64LessOrEqualToTest1()
        {
            Int64 a = One;
            Condition.Requires(a).IsLessOrEqualTo(Two);
        }

        [TestMethod]
        [Description("Calling IsLessOrEqualTo on Int64 x with 'x = upper bound' should pass.")]
        public void IsInt64LessOrEqualToTest2()
        {
            Int64 a = Two;
            Condition.Requires(a).IsLessOrEqualTo(Two);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [Description("Calling IsLessOrEqualTo on Int64 x with 'x > upper bound' should fail.")]
        public void IsInt64LessOrEqualToTest3()
        {
            Int64 a = Three;
            Condition.Requires(a).IsLessOrEqualTo(Two);
        }

        [TestMethod]
        [Description("Calling IsLessOrEqualTo on Int64 x with 'x > upper bound' should succeed when exceptions are suppressed.")]
        public void IsInt64LessOrEqualToTest4()
        {
            Int64 a = Three;
            Condition.Requires(a).SuppressExceptionsForTest().IsLessOrEqualTo(Two);
        }

        #endregion // IsInt64LessOrEqual

        #region IsInt64EqualTo

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [Description("Calling IsEqualTo on Int64 x with 'x < other' should fail.")]
        public void IsInt64EqualToTest1()
        {
            Int64 a = One;
            Condition.Requires(a).IsEqualTo(Two);
        }

        [TestMethod]
        [Description("Calling IsEqualTo on Int64 x with 'x = other' should pass.")]
        public void IsInt64EqualToTest2()
        {
            Int64 a = Two;
            Condition.Requires(a).IsEqualTo(Two);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [Description("Calling IsEqualTo on Int64 x with 'x > other' should fail.")]
        public void IsInt64EqualToTest3()
        {
            Int64 a = Three;
            Condition.Requires(a).IsEqualTo(Two);
        }

        [TestMethod]
        [Description("Calling IsEqualTo on Int64 x with 'x < other' should succeed when exceptions are suppressed.")]
        public void IsInt64EqualToTest4()
        {
            Int64 a = One;
            Condition.Requires(a).SuppressExceptionsForTest().IsEqualTo(Two);
        }

        #endregion // IsInt64EqualTo

        #region IsInt64NotEqualTo

        [TestMethod]
        [Description("Calling IsNotEqualTo on Int64 x with 'x < other' should pass.")]
        public void IsInt64NotEqualToTest1()
        {
            Int64 a = One;
            Condition.Requires(a).IsNotEqualTo(Two);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [Description("Calling IsNotEqualTo on Int64 x with 'x = other' should fail.")]
        public void IsInt64NotEqualToTest2()
        {
            Int64 a = Two;
            Condition.Requires(a).IsNotEqualTo(Two);
        }

        [TestMethod]
        [Description("Calling IsNotEqualTo on Int64 x with 'x > other' should pass.")]
        public void IsInt64NotEqualToTest3()
        {
            Int64 a = Three;
            Condition.Requires(a).IsNotEqualTo(Two);
        }

        [TestMethod]
        [Description("Calling IsNotEqualTo on Int64 x with 'x = other' should succeed when exceptions are suppressed.")]
        public void IsInt64NotEqualToTest4()
        {
            Int64 a = Two;
            Condition.Requires(a).SuppressExceptionsForTest().IsNotEqualTo(Two);
        }

        #endregion // IsInt64NotEqualTo
    }
}