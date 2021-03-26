using System;
using Conditions.Extensions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Conditions.Tests.CompareTests
{
    [TestClass]
    public class CompareInt16Tests
    {
        private static readonly Int16 One = 1;
        private static readonly Int16 Two = 2;
        private static readonly Int16 Three = 3;
        private static readonly Int16 Four = 4;
        private static readonly Int16 Five = 5;

        #region IsInt16InRange

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [Description("Calling IsInRange on Int16 x with 'lower bound > x < upper bound' should fail.")]
        public void IsInt16InRangeTest1()
        {
            Int16 a = One;
            Condition.Requires(a).IsInRange(Two, Four);
        }

        [TestMethod]
        [Description("Calling IsInRange on Int16 x with 'lower bound = x < upper bound' should pass.")]
        public void IsInt16InRangeTest2()
        {
            Int16 a = Two;
            Condition.Requires(a).IsInRange(Two, Four);
        }

        [TestMethod]
        [Description("Calling IsInRange on Int16 x with 'lower bound < x < upper bound' should pass.")]
        public void IsInt16InRangeTest3()
        {
            Int16 a = Three;
            Condition.Requires(a).IsInRange(Two, Four);
        }

        [TestMethod]
        [Description("Calling IsInRange on Int16 x with 'lower bound < x = upper bound' should pass.")]
        public void IsInt16InRangeTest4()
        {
            Int16 a = Four;
            Condition.Requires(a).IsInRange(Two, Four);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [Description("Calling IsInRange on Int16 x with 'lower bound < x > upper bound' should fail.")]
        public void IsInt16InRangeTest5()
        {
            Int16 a = Five;
            Condition.Requires(a).IsInRange(Two, Four);
        }

        [TestMethod]
        [Description("Calling IsInRange on Int16 x with 'lower bound > x < upper bound' should succeed when exceptions are suppressed.")]
        public void IsInt16InRangeTest6()
        {
            Int16 a = One;
            Condition.Requires(a).SuppressExceptionsForTest().IsInRange(Two, Four);
        }

        #endregion // IsInt16InRange

        #region IsInt16NotInRange

        [TestMethod]
        [Description("Calling IsNotInRange on Int16 x with 'lower bound > x < upper bound' should pass.")]
        public void IsInt16NotInRangeTest1()
        {
            Int16 a = One;
            Condition.Requires(a).IsNotInRange(Two, Four);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [Description("Calling IsNotInRange on Int16 x with 'lower bound = x < upper bound' should fail.")]
        public void IsInt16NotInRangeTest2()
        {
            Int16 a = Two;
            Condition.Requires(a).IsNotInRange(Two, Four);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [Description("Calling IsNotInRange on Int16 x with 'lower bound < x < upper bound' should fail.")]
        public void IsInt16NotInRangeTest3()
        {
            Int16 a = Three;
            Condition.Requires(a).IsNotInRange(Two, Four);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [Description("Calling IsNotInRange on Int16 x with 'lower bound < x = upper bound' should fail.")]
        public void IsInt16NotInRangeTest4()
        {
            Int16 a = Four;
            Condition.Requires(a).IsNotInRange(Two, Four);
        }

        [TestMethod]
        [Description("Calling IsNotInRange on Int16 x with 'lower bound < x > upper bound' should pass.")]
        public void IsInt16NotInRangeTest5()
        {
            Int16 a = Five;
            Condition.Requires(a).IsNotInRange(Two, Four);
        }

        [TestMethod]
        [Description("Calling IsNotInRange on Int16 x with 'lower bound = x < upper bound' should succeed when exceptions are suppressed.")]
        public void IsInt16NotInRangeTest6()
        {
            Int16 a = Two;
            Condition.Requires(a).SuppressExceptionsForTest().IsNotInRange(Two, Four);
        }

        #endregion // IsInt16NotInRange

        #region IsInt16GreaterThan

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [Description("Calling IsGreaterThan on Int16 x with 'lower bound < x' should fail.")]
        public void IsInt16GreaterThanTest1()
        {
            Int16 a = One;
            Condition.Requires(a).IsGreaterThan(Two);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [Description("Calling IsGreaterThan on Int16 x with 'lower bound = x' should fail.")]
        public void IsInt16GreaterThanTest2()
        {
            Int16 a = Two;
            Condition.Requires(a).IsGreaterThan(Two);
        }

        [TestMethod]
        [Description("Calling IsGreaterThan on Int16 x with 'lower bound < x' should pass.")]
        public void IsInt16GreaterThanTest3()
        {
            Int16 a = Three;
            Condition.Requires(a).IsGreaterThan(Two);
        }

        [TestMethod]
        [Description("Calling IsGreaterThan on Int16 x with 'lower bound < x' should succeed when exceptions are suppressed.")]
        public void IsInt16GreaterThanTest4()
        {
            Int16 a = One;
            Condition.Requires(a).SuppressExceptionsForTest().IsGreaterThan(Two);
        }

        #endregion // IsInt16GreaterThan

        #region IsInt16GreaterOrEqualTo

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [Description("Calling IsGreaterOrEqualTo on Int16 x with 'lower bound > x' should fail.")]
        public void IsInt16GreaterOrEqualToTest1()
        {
            Int16 a = One;
            Condition.Requires(a).IsGreaterOrEqualTo(Two);
        }

        [TestMethod]
        [Description("Calling IsGreaterOrEqualTo on Int16 x with 'lower bound = x' should pass.")]
        public void IsInt16GreaterOrEqualToTest2()
        {
            Int16 a = Two;
            Condition.Requires(a).IsGreaterOrEqualTo(Two);
        }

        [TestMethod]
        [Description("Calling IsGreaterOrEqualTo on Int16 x with 'lower bound < x' should pass.")]
        public void IsInt16GreaterOrEqualToTest3()
        {
            Int16 a = Three;
            Condition.Requires(a).IsGreaterOrEqualTo(Two);
        }

        [TestMethod]
        [Description("Calling IsGreaterOrEqualTo on Int16 x with 'lower bound > x' should succeed when exceptions are suppressed.")]
        public void IsInt16GreaterOrEqualToTest4()
        {
            Int16 a = One;
            Condition.Requires(a).SuppressExceptionsForTest().IsGreaterOrEqualTo(Two);
        }

        #endregion // IsInt16GreaterOrEqualTo

        #region IsInt16LessThan

        [TestMethod]
        [Description("Calling IsLessThan on Int16 x with 'x < upper bound' should pass.")]
        public void IsInt16LessThanTest1()
        {
            Int16 a = One;
            Condition.Requires(a).IsLessThan(Two);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [Description("Calling IsLessThan on Int16 x with 'x = upper bound' should fail.")]
        public void IsInt16LessThanTest2()
        {
            Int16 a = Two;
            Condition.Requires(a).IsLessThan(Two);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [Description("Calling IsLessThan on Int16 x with 'x > upper bound' should fail.")]
        public void IsInt16LessThanTest3()
        {
            Int16 a = Three;
            Condition.Requires(a).IsLessThan(Two);
        }

        [TestMethod]
        [Description("Calling IsLessThan on Int16 x with 'x = upper bound' should succeed when exceptions are suppressed.")]
        public void IsInt16LessThanTest4()
        {
            Int16 a = Two;
            Condition.Requires(a).SuppressExceptionsForTest().IsLessThan(Two);
        }

        #endregion // IsInt16LessThan

        #region IsInt16LessOrEqualTo

        [TestMethod]
        [Description("Calling IsLessOrEqualTo on Int16 x with 'x < upper bound' should pass.")]
        public void IsInt16LessOrEqualToTest1()
        {
            Int16 a = One;
            Condition.Requires(a).IsLessOrEqualTo(Two);
        }

        [TestMethod]
        [Description("Calling IsLessOrEqualTo on Int16 x with 'x = upper bound' should pass.")]
        public void IsInt16LessOrEqualToTest2()
        {
            Int16 a = Two;
            Condition.Requires(a).IsLessOrEqualTo(Two);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [Description("Calling IsLessOrEqualTo on Int16 x with 'x > upper bound' should fail.")]
        public void IsInt16LessOrEqualToTest3()
        {
            Int16 a = Three;
            Condition.Requires(a).IsLessOrEqualTo(Two);
        }

        [TestMethod]
        [Description("Calling IsLessOrEqual on Int16 x with 'x > upper bound' should succeed when exceptions are suppressed.")]
        public void IsInt16LessOrEqualToTest4()
        {
            Int16 a = Three;
            Condition.Requires(a).SuppressExceptionsForTest().IsLessOrEqualTo(Two);
        }

        #endregion // IsInt16LessOrEqualTo

        #region IsInt16EqualTo

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [Description("Calling IsEqualTo on Int16 x with 'x < other' should fail.")]
        public void IsInt16EqualToTest1()
        {
            Int16 a = One;
            Condition.Requires(a).IsEqualTo(Two);
        }

        [TestMethod]
        [Description("Calling IsEqualTo on Int16 x with 'x = other' should pass.")]
        public void IsInt16EqualToTest2()
        {
            Int16 a = Two;
            Condition.Requires(a).IsEqualTo(Two);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [Description("Calling IsEqualTo on Int16 x with 'x > other' should fail.")]
        public void IsInt16EqualToTest3()
        {
            Int16 a = Three;
            Condition.Requires(a).IsEqualTo(Two);
        }

        [TestMethod]
        [Description("Calling IsEqualTo on Int16 x with 'x < other' should succeed when exceptions are suppressed.")]
        public void IsInt16EqualToTest4()
        {
            Int16 a = One;
            Condition.Requires(a).SuppressExceptionsForTest().IsEqualTo(Two);
        }

        #endregion // IsInt16EqualTo

        #region IsInt16NotEqualTo

        [TestMethod]
        [Description("Calling IsNotEqualTo on Int16 x with 'x < other' should pass.")]
        public void IsInt16NotEqualToTest1()
        {
            Int16 a = One;
            Condition.Requires(a).IsNotEqualTo(Two);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [Description("Calling IsNotEqualTo on Int16 x with 'x = other' should fail.")]
        public void IsInt16NotEqualToTest2()
        {
            Int16 a = Two;
            Condition.Requires(a).IsNotEqualTo(Two);
        }

        [TestMethod]
        [Description("Calling IsNotEqualTo on Int16 x with 'x > other' should pass.")]
        public void IsInt16NotEqualToTest3()
        {
            Int16 a = Three;
            Condition.Requires(a).IsNotEqualTo(Two);
        }

        [TestMethod]
        [Description("Calling IsNotEqualTo on Int16 x with 'x = other' should succeed when exceptions are suppressed.")]
        public void IsInt16NotEqualToTest4()
        {
            Int16 a = Two;
            Condition.Requires(a).SuppressExceptionsForTest().IsNotEqualTo(Two);
        }

        #endregion // IsInt16NotEqualTo
    }
}