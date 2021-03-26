
using System;
using Conditions.Extensions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Conditions.Tests.CompareTests
{
    [TestClass]
    public class CompareByteTests
    {
        private static readonly Byte One = 1;
        private static readonly Byte Two = 2;
        private static readonly Byte Three = 3;
        private static readonly Byte Four = 4;
        private static readonly Byte Five = 5;

        #region IsByteInRange

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [Description("Calling IsInRange on Byte x with 'lower bound > x < upper bound' should fail.")]
        public void IsByteInRangeTest1()
        {
            Byte a = One;
            Condition.Requires(a).IsInRange(Two, Four);
        }

        [TestMethod]
        [Description("Calling IsInRange on Byte x with 'lower bound = x < upper bound' should pass.")]
        public void IsByteInRangeTest2()
        {
            Byte a = Two;
            Condition.Requires(a).IsInRange(Two, Four);
        }

        [TestMethod]
        [Description("Calling IsInRange on Byte x with 'lower bound < x < upper bound' should pass.")]
        public void IsByteInRangeTest3()
        {
            Byte a = Three;
            Condition.Requires(a).IsInRange(Two, Four);
        }

        [TestMethod]
        [Description("Calling IsInRange on Byte x with 'lower bound < x = upper bound' should pass.")]
        public void IsByteInRangeTest4()
        {
            Byte a = Four;
            Condition.Requires(a).IsInRange(Two, Four);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [Description("Calling IsInRange on Byte x with 'lower bound < x > upper bound' should fail.")]
        public void IsByteInRangeTest5()
        {
            Byte a = Five;
            Condition.Requires(a).IsInRange(Two, Four);
        }

        [TestMethod]
        [Description("Calling IsInRange on Byte x with 'lower bound > x < upper bound' should succeed when exceptions are suppressed.")]
        public void IsByteInRangeTest6()
        {
            Byte a = One;
            Condition.Requires(a).SuppressExceptionsForTest().IsInRange(Two, Four);
        }

        #endregion // IsByteInRange

        #region IsByteNotInRange

        [TestMethod]
        [Description("Calling IsNotInRange on Byte x with 'lower bound > x < upper bound' should pass.")]
        public void IsByteNotInRangeTest1()
        {
            Byte a = One;
            Condition.Requires(a).IsNotInRange(Two, Four);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [Description("Calling IsNotInRange on Byte x with 'lower bound = x < upper bound' should fail.")]
        public void IsByteNotInRangeTest2()
        {
            Byte a = Two;
            Condition.Requires(a).IsNotInRange(Two, Four);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [Description("Calling IsNotInRange on Byte x with 'lower bound < x < upper bound' should fail.")]
        public void IsByteNotInRangeTest3()
        {
            Byte a = Three;
            Condition.Requires(a).IsNotInRange(Two, Four);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [Description("Calling IsNotInRange on Byte x with 'lower bound < x = upper bound' should fail.")]
        public void IsByteNotInRangeTest4()
        {
            Byte a = Four;
            Condition.Requires(a).IsNotInRange(Two, Four);
        }

        [TestMethod]
        [Description("Calling IsNotInRange on Byte x with 'lower bound < x > upper bound' should pass.")]
        public void IsByteNotInRangeTest5()
        {
            Byte a = Five;
            Condition.Requires(a).IsNotInRange(Two, Four);
        }

        [TestMethod]
        [Description("Calling IsNotInRange on Byte x with 'lower bound = x < upper bound' should succeed when exceptions are suppressed.")]
        public void IsByteNotInRangeTest6()
        {
            Byte a = Two;
            Condition.Requires(a).SuppressExceptionsForTest().IsNotInRange(Two, Four);
        }

        #endregion // IsByteNotInRange

        #region IsByteEqualTo

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [Description("Calling IsEqualTo on Byte x with 'x < other' should fail.")]
        public void IsByteEqualToTest1()
        {
            Byte a = One;
            Condition.Requires(a).IsEqualTo(Two);
        }

        [TestMethod]
        [Description("Calling IsEqualTo on Byte x with 'x = other' should pass.")]
        public void IsByteEqualToTest2()
        {
            Byte a = Two;
            Condition.Requires(a).IsEqualTo(Two);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [Description("Calling IsEqualTo on Byte x with 'x > other' should fail.")]
        public void IsByteEqualToTest3()
        {
            Byte a = Three;
            Condition.Requires(a).IsEqualTo(Two);
        }

        [TestMethod]
        [Description("Calling IsEqualTo on Byte x with 'x < other' should succeed when exceptions are suppressed.")]
        public void IsByteEqualToTest4()
        {
            Byte a = One;
            Condition.Requires(a).SuppressExceptionsForTest().IsEqualTo(Two);
        }

        #endregion // IsByteEqualTo

        #region IsByteNotEqualTo

        [TestMethod]
        [Description("Calling IsNotEqualTo on Byte x with 'x < other' should pass.")]
        public void IsByteNotEqualToTest1()
        {
            Byte a = One;
            Condition.Requires(a).IsNotEqualTo(Two);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [Description("Calling IsNotEqualTo on Byte x with 'x = other' should fail.")]
        public void IsByteNotEqualToTest2()
        {
            Byte a = Two;
            Condition.Requires(a).IsNotEqualTo(Two);
        }

        [TestMethod]
        [Description("Calling IsNotEqualTo on Byte x with 'x > other' should pass.")]
        public void IsByteNotEqualToTest3()
        {
            Byte a = Three;
            Condition.Requires(a).IsNotEqualTo(Two);
        }

        [TestMethod]
        [Description("Calling IsNotEqualTo on Byte x with 'x = other' should succeed when exceptions are suppressed.")]
        public void IsByteNotEqualToTest4()
        {
            Byte a = Two;
            Condition.Requires(a).SuppressExceptionsForTest().IsNotEqualTo(Two);
        }


        #endregion // IsByteNotEqualTo

        #region IsByteGreaterThan

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [Description("Calling IsGreaterThan on Byte x with 'lower bound < x' should fail.")]
        public void IsByteGreaterThanTest1()
        {
            Byte a = One;
            Condition.Requires(a).IsGreaterThan(Two);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [Description("Calling IsGreaterThan on Byte x with 'lower bound = x' should fail.")]
        public void IsByteGreaterThanTest2()
        {
            Byte a = Two;
            Condition.Requires(a).IsGreaterThan(Two);
        }

        [TestMethod]
        [Description("Calling IsGreaterThan on Byte x with 'lower bound < x' should pass.")]
        public void IsByteGreaterThanTest3()
        {
            Byte a = Three;
            Condition.Requires(a).IsGreaterThan(Two);
        }

        [TestMethod]
        [Description("Calling IsGreaterThan on Byte x with 'lower bound < x' should succeed when exceptions are suppressed.")]
        public void IsByteGreaterThanTest4()
        {
            Byte a = One;
            Condition.Requires(a).SuppressExceptionsForTest().IsGreaterThan(Two);
        }

        #endregion // IsByteGreaterThan

        #region IsByteGreaterOrEqualTo

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [Description("Calling IsGreaterOrEqualTo on Byte x with 'lower bound > x' should fail.")]
        public void IsByteGreaterOrEqualToTest1()
        {
            Byte a = One;
            Condition.Requires(a).IsGreaterOrEqualTo(Two);
        }

        [TestMethod]
        [Description("Calling IsGreaterOrEqualTo on Byte x with 'lower bound = x' should pass.")]
        public void IsByteGreaterOrEqualToTest2()
        {
            Byte a = Two;
            Condition.Requires(a).IsGreaterOrEqualTo(Two);
        }

        [TestMethod]
        [Description("Calling IsGreaterOrEqualTo on Byte x with 'lower bound < x' should pass.")]
        public void IsByteGreaterOrEqualToTest3()
        {
            Byte a = Three;
            Condition.Requires(a).IsGreaterOrEqualTo(Two);
        }

        [TestMethod]
        [Description("Calling IsGreaterOrEqualTo on Byte x with 'lower bound > x' should succeed when exceptions are suppressed.")]
        public void IsByteGreaterOrEqualToTest4()
        {
            Byte a = One;
            Condition.Requires(a).SuppressExceptionsForTest().IsGreaterOrEqualTo(Two);
        }

        #endregion // IsByteGreaterOrEqualTo

        #region IsByteLessThan

        [TestMethod]
        [Description("Calling IsLessThan on Byte x with 'x < upper bound' should pass.")]
        public void IsByteLessThanTest1()
        {
            Byte a = One;
            Condition.Requires(a).IsLessThan(Two);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [Description("Calling IsLessThan on Byte x with 'x = upper bound' should fail.")]
        public void IsByteLessThanTest2()
        {
            Byte a = Two;
            Condition.Requires(a).IsLessThan(Two);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [Description("Calling IsLessThan on Byte x with 'x > upper bound' should fail.")]
        public void IsByteLessThanTest3()
        {
            Byte a = Three;
            Condition.Requires(a).IsLessThan(Two);
        }

        [TestMethod]
        [Description("Calling IsLessThan on Byte x with 'x = upper bound' should succeed when exceptions are suppressed.")]
        public void IsByteLessThanTest4()
        {
            Byte a = Two;
            Condition.Requires(a).SuppressExceptionsForTest().IsLessThan(Two);
        }

        #endregion // IsByteLessThan

        #region IsByteLessOrEqualTo

        [TestMethod]
        [Description("Calling IsLessOrEqualTo on Byte x with 'x < upper bound' should pass.")]
        public void IsByteLessOrEqualToTest1()
        {
            Byte a = One;
            Condition.Requires(a).IsLessOrEqualTo(Two);
        }

        [TestMethod]
        [Description("Calling IsLessOrEqualTo on Byte x with 'x = upper bound' should pass.")]
        public void IsByteLessOrEqualToTest2()
        {
            Byte a = Two;
            Condition.Requires(a).IsLessOrEqualTo(Two);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [Description("Calling IsLessOrEqualTo on Byte x with 'x > upper bound' should fail.")]
        public void IsByteLessOrEqualToTest3()
        {
            Byte a = Three;
            Condition.Requires(a).IsLessOrEqualTo(Two);
        }

        [TestMethod]
        [Description("Calling IsLessOrEqualTo on Byte x with 'x > upper bound' should succeed when exceptions are suppressed.")]
        public void IsByteLessOrEqualToTest4()
        {
            Byte a = Three;
            Condition.Requires(a).SuppressExceptionsForTest().IsLessOrEqualTo(Two);
        }

        #endregion // IsByteLessOrEqualTo
    }
}