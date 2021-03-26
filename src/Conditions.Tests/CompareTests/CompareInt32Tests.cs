using System;
using Conditions.Extensions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Conditions.Tests.CompareTests
{
    [TestClass]
    public class CompareInt32Tests
    {
        private static readonly Int32 One = 1;
        private static readonly Int32 Two = 2;
        private static readonly Int32 Three = 3;
        private static readonly Int32 Four = 4;
        private static readonly Int32 Five = 5;

        #region IsInt32InRange

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [Description("Calling IsInRange on Int32 x with 'lower bound > x < upper bound' should fail.")]
        public void IsInt32InRangeTest1()
        {
            Int32 a = One;
            Condition.Requires(a).IsInRange(Two, Four);
        }

        [TestMethod]
        [Description("Calling IsInRange on Int32 x with 'lower bound = x < upper bound' should pass.")]
        public void IsInt32InRangeTest2()
        {
            Int32 a = Two;
            Condition.Requires(a).IsInRange(Two, Four);
        }

        [TestMethod]
        [Description("Calling IsInRange on Int32 x with 'lower bound < x < upper bound' should pass.")]
        public void IsInt32InRangeTest3()
        {
            Int32 a = Three;
            Condition.Requires(a).IsInRange(Two, Four);
        }

        [TestMethod]
        [Description("Calling IsInRange on Int32 x with 'lower bound < x = upper bound' should pass.")]
        public void IsInt32InRangeTest4()
        {
            Int32 a = Four;
            Condition.Requires(a).IsInRange(Two, Four);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [Description("Calling IsInRange on Int32 x with 'lower bound < x > upper bound' should fail.")]
        public void IsInt32InRangeTest5()
        {
            Int32 a = Five;
            Condition.Requires(a).IsInRange(Two, Four);
        }

        [TestMethod]
        [Description("Calling IsInRange on Int32 x with 'lower bound > x < upper bound' should succeed when exceptions are suppressed.")]
        public void IsInt32InRangeTest6()
        {
            Int32 a = One;
            Condition.Requires(a).SuppressExceptionsForTest().IsInRange(Two, Four);
        }

        #endregion // IsInt32InRange

        #region IsInt32NotInRange

        [TestMethod]
        [Description("Calling IsNotInRange on Int32 x with 'lower bound > x < upper bound' should pass.")]
        public void IsInt32NotInRangeTest1()
        {
            Int32 a = One;
            Condition.Requires(a).IsNotInRange(Two, Four);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [Description("Calling IsNotInRange on Int32 x with 'lower bound = x < upper bound' should fail.")]
        public void IsInt32NotInRangeTest2()
        {
            Int32 a = Two;
            Condition.Requires(a).IsNotInRange(Two, Four);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [Description("Calling IsNotInRange on Int32 x with 'lower bound < x < upper bound' should fail.")]
        public void IsInt32NotInRangeTest3()
        {
            Int32 a = Three;
            Condition.Requires(a).IsNotInRange(Two, Four);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [Description("Calling IsNotInRange on Int32 x with 'lower bound < x = upper bound' should fail.")]
        public void IsInt32NotInRangeTest4()
        {
            Int32 a = Four;
            Condition.Requires(a).IsNotInRange(Two, Four);
        }

        [TestMethod]
        [Description("Calling IsNotInRange on Int32 x with 'lower bound < x > upper bound' should pass.")]
        public void IsInt32NotInRangeTest5()
        {
            Int32 a = Five;
            Condition.Requires(a).IsNotInRange(Two, Four);
        }

        [TestMethod]
        [Description("Calling IsNotInRange on Int32 x with 'lower bound = x < upper bound' should succeed when exceptions are suppressed.")]
        public void IsInt32NotInRangeTest6()
        {
            Int32 a = Two;
            Condition.Requires(a).SuppressExceptionsForTest().IsNotInRange(Two, Four);
        }

        #endregion // IsInt32NotInRange

        #region IsInt32GreaterThan

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [Description("Calling IsGreaterThan on Int32 x with 'lower bound < x' should fail.")]
        public void IsInt32GreaterThanTest1()
        {
            Int32 a = One;
            Condition.Requires(a).IsGreaterThan(Two);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [Description("Calling IsGreaterThan on Int32 x with 'lower bound = x' should fail.")]
        public void IsInt32GreaterThanTest2()
        {
            Int32 a = Two;
            Condition.Requires(a).IsGreaterThan(Two);
        }

        [TestMethod]
        [Description("Calling IsGreaterThan on Int32 x with 'lower bound < x' should pass.")]
        public void IsInt32GreaterThanTest3()
        {
            Int32 a = Three;
            Condition.Requires(a).IsGreaterThan(Two);
        }

        [TestMethod]
        [Description("Calling IsGreaterThan on Int32 x with 'lower bound < x' should succeed when exceptions are suppressed.")]
        public void IsInt32GreaterThanTest4()
        {
            Int32 a = One;
            Condition.Requires(a).SuppressExceptionsForTest().IsGreaterThan(Two);
        }

        #endregion // IsInt32GreaterThan

        #region IsInt32GreaterOrEqualTo

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [Description("Calling IsGreaterOrEqualTo on Int32 x with 'lower bound > x' should fail.")]
        public void IsInt32GreaterOrEqualToTest1()
        {
            Int32 a = One;
            Condition.Requires(a).IsGreaterOrEqualTo(Two);
        }

        [TestMethod]
        [Description("Calling IsGreaterOrEqualTo on Int32 x with 'lower bound = x' should pass.")]
        public void IsInt32GreaterOrEqualToTest2()
        {
            Int32 a = Two;
            Condition.Requires(a).IsGreaterOrEqualTo(Two);
        }

        [TestMethod]
        [Description("Calling IsGreaterOrEqualTo on Int32 x with 'lower bound < x' should pass.")]
        public void IsInt32GreaterOrEqualToTest3()
        {
            Int32 a = Three;
            Condition.Requires(a).IsGreaterOrEqualTo(Two);
        }

        [TestMethod]
        [Description("Calling IsGreaterOrEqual on Int32 x with 'lower bound > x' should succeed when exceptions are suppressed.")]
        public void IsInt32GreaterOrEqualToTest4()
        {
            Int32 a = One;
            Condition.Requires(a).SuppressExceptionsForTest().IsGreaterOrEqualTo(Two);
        }

        #endregion // IsInt32GreaterOrEqualTo

        #region IsInt32LessThan

        [TestMethod]
        [Description("Calling IsLessThan on Int32 x with 'x < upper bound' should pass.")]
        public void IsInt32LessThanTest1()
        {
            Int32 a = One;
            Condition.Requires(a).IsLessThan(Two);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [Description("Calling IsLessThan on Int32 x with 'x = upper bound' should fail.")]
        public void IsInt32LessThanTest2()
        {
            Int32 a = Two;
            Condition.Requires(a).IsLessThan(Two);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [Description("Calling IsLessThan on Int32 x with 'x > upper bound' should fail.")]
        public void IsInt32LessThanTest3()
        {
            Int32 a = Three;
            Condition.Requires(a).IsLessThan(Two);
        }

        [TestMethod]
        [Description("Calling IsLessThan on Int32 x with 'x = upper bound' should succeed when exceptions are suppressed.")]
        public void IsInt32LessThanTest4()
        {
            Int32 a = Two;
            Condition.Requires(a).SuppressExceptionsForTest().IsLessThan(Two);
        }

        #endregion // IsInt32LessThan

        #region IsInt32LessOrEqualTo

        [TestMethod]
        [Description("Calling IsLessOrEqualTo on Int32 x with 'x < upper bound' should pass.")]
        public void IsInt32LessOrEqualToTest1()
        {
            Int32 a = One;
            Condition.Requires(a).IsLessOrEqualTo(Two);
        }

        [TestMethod]
        [Description("Calling IsLessOrEqualTo on Int32 x with 'x = upper bound' should pass.")]
        public void IsInt32LessOrEqualToTest2()
        {
            Int32 a = Two;
            Condition.Requires(a).IsLessOrEqualTo(Two);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [Description("Calling IsLessOrEqualTo on Int32 x with 'x > upper bound' should fail.")]
        public void IsInt32LessOrEqualToTest3()
        {
            Int32 a = Three;
            Condition.Requires(a).IsLessOrEqualTo(Two);
        }

        [TestMethod]
        [Description("Calling IsLessOrEqual on Int32 x with 'x > upper bound' should succeed when exceptions are suppressed.")]
        public void IsInt32LessOrEqualToTest4()
        {
            Int32 a = Three;
            Condition.Requires(a).SuppressExceptionsForTest().IsLessOrEqualTo(Two);
        }

        #endregion // IsInt32LessOrEqualTo

        #region IsInt32EqualTo

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [Description("Calling IsEqualTo on Int32 x with 'x < other' should fail.")]
        public void IsInt32EqualToTest1()
        {
            Int32 a = One;
            Condition.Requires(a).IsEqualTo(Two);
        }

        [TestMethod]
        [Description("Calling IsEqualTo on Int32 x with 'x = other' should pass.")]
        public void IsInt32EqualToTest2()
        {
            Int32 a = Two;
            Condition.Requires(a).IsEqualTo(Two);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [Description("Calling IsEqualTo on Int32 x with 'x > other' should fail.")]
        public void IsInt32EqualToTest3()
        {
            Int32 a = Three;
            Condition.Requires(a).IsEqualTo(Two);
        }

        [TestMethod]
        [Description("Calling IsEqualTo on Int32 x with 'x < other' should succeed when exceptions are suppressed.")]
        public void IsInt32EqualToTest4()
        {
            Int32 a = One;
            Condition.Requires(a).SuppressExceptionsForTest().IsEqualTo(Two);
        }

        #endregion // IsInt32EqualTo

        #region IsInt32NotEqualTo

        [TestMethod]
        [Description("Calling IsNotEqualTo on Int32 x with 'x < other' should pass.")]
        public void IsInt32NotEqualToTest1()
        {
            Int32 a = One;
            Condition.Requires(a).IsNotEqualTo(Two);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [Description("Calling IsNotEqualTo on Int32 x with 'x = other' should fail.")]
        public void IsInt32NotEqualToTest2()
        {
            Int32 a = Two;
            Condition.Requires(a).IsNotEqualTo(Two);
        }

        [TestMethod]
        [Description("Calling IsNotEqualTo on Int32 x with 'x > other' should pass.")]
        public void IsInt32NotEqualToTest3()
        {
            Int32 a = Three;
            Condition.Requires(a).IsNotEqualTo(Two);
        }

        [TestMethod]
        [Description("Calling IsNotEqualTo on Int32 x with 'x = other' should succeed when exceptions are suppressed.")]
        public void IsInt32NotEqualToTest4()
        {
            Int32 a = Two;
            Condition.Requires(a).SuppressExceptionsForTest().IsNotEqualTo(Two);
        }

        #endregion // IsInt32NotEqualTo
    }
}