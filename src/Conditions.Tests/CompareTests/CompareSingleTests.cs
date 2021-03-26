using System;
using Conditions.Extensions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Conditions.Tests.CompareTests
{
    [TestClass]
    public class CompareSingleTests
    {
        private static readonly Single One = 1;
        private static readonly Single Two = 2;
        private static readonly Single Three = 3;
        private static readonly Single Four = 4;
        private static readonly Single Five = 5;

        #region IsSingleInRange

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [Description("Calling IsInRange on Single x with 'lower bound > x < upper bound' should fail.")]
        public void IsSingleInRangeTest1()
        {
            Single a = One;
            Condition.Requires(a).IsInRange(Two, Four);
        }

        [TestMethod]
        [Description("Calling IsInRange on Single x with 'lower bound = x < upper bound' should pass.")]
        public void IsSingleInRangeTest2()
        {
            Single a = Two;
            Condition.Requires(a).IsInRange(Two, Four);
        }

        [TestMethod]
        [Description("Calling IsInRange on Single x with 'lower bound < x < upper bound' should pass.")]
        public void IsSingleInRangeTest3()
        {
            Single a = Three;
            Condition.Requires(a).IsInRange(Two, Four);
        }

        [TestMethod]
        [Description("Calling IsInRange on Single x with 'lower bound < x = upper bound' should pass.")]
        public void IsSingleInRangeTest4()
        {
            Single a = Four;
            Condition.Requires(a).IsInRange(Two, Four);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [Description("Calling IsInRange on Single x with 'lower bound < x > upper bound' should fail.")]
        public void IsSingleInRangeTest5()
        {
            Single a = Five;
            Condition.Requires(a).IsInRange(Two, Four);
        }

        [TestMethod]
        [Description("Calling IsInRange on Single x with 'lower bound > x < upper bound' should succeed when exceptions are suppressed.")]
        public void IsSingleInRangeTest6()
        {
            Single a = One;
            Condition.Requires(a).SuppressExceptionsForTest().IsInRange(Two, Four);
        }

        #endregion // IsSingleInRange

        #region IsSingleNotInRange

        [TestMethod]
        [Description("Calling IsNotInRange on Single x with 'lower bound > x < upper bound' should pass.")]
        public void IsSingleNotInRangeTest1()
        {
            Single a = One;
            Condition.Requires(a).IsNotInRange(Two, Four);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [Description("Calling IsNotInRange on Single x with 'lower bound = x < upper bound' should fail.")]
        public void IsSingleNotInRangeTest2()
        {
            Single a = Two;
            Condition.Requires(a).IsNotInRange(Two, Four);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [Description("Calling IsNotInRange on Single x with 'lower bound < x < upper bound' should fail.")]
        public void IsSingleNotInRangeTest3()
        {
            Single a = Three;
            Condition.Requires(a).IsNotInRange(Two, Four);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [Description("Calling IsNotInRange on Single x with 'lower bound < x = upper bound' should fail.")]
        public void IsSingleNotInRangeTest4()
        {
            Single a = Four;
            Condition.Requires(a).IsNotInRange(Two, Four);
        }

        [TestMethod]
        [Description("Calling IsNotInRange on Single x with 'lower bound < x > upper bound' should pass.")]
        public void IsSingleNotInRangeTest5()
        {
            Single a = Five;
            Condition.Requires(a).IsNotInRange(Two, Four);
        }

        [TestMethod]
        [Description("Calling IsNotInRange on Single x with 'lower bound = x < upper bound' should succeed when exceptions are suppressed.")]
        public void IsSingleNotInRangeTest6()
        {
            Single a = Two;
            Condition.Requires(a).SuppressExceptionsForTest().IsNotInRange(Two, Four);
        }

        #endregion // IsSingleNotInRange

        #region IsSingleGreaterThan

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [Description("Calling IsGreaterThan on Single x with 'lower bound < x' should fail.")]
        public void IsSingleGreaterThanTest1()
        {
            Single a = One;
            Condition.Requires(a).IsGreaterThan(Two);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [Description("Calling IsGreaterThan on Single x with 'lower bound = x' should fail.")]
        public void IsSingleGreaterThanTest2()
        {
            Single a = Two;
            Condition.Requires(a).IsGreaterThan(Two);
        }

        [TestMethod]
        [Description("Calling IsGreaterThan on Single x with 'lower bound < x' should pass.")]
        public void IsSingleGreaterThanTest3()
        {
            Single a = Three;
            Condition.Requires(a).IsGreaterThan(Two);
        }

        [TestMethod]
        [Description("Calling IsGreaterThan on Single x with 'lower bound < x' should succeed when exceptions are suppressed.")]
        public void IsSingleGreaterThanTest4()
        {
            Single a = One;
            Condition.Requires(a).SuppressExceptionsForTest().IsGreaterThan(Two);
        }

        #endregion // IsSingleGreaterThan

        #region IsSingleGreaterOrEqualTo

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [Description("Calling IsGreaterOrEqualTo on Single x with 'lower bound > x' should fail.")]
        public void IsSingleGreaterOrEqualToTest1()
        {
            Single a = One;
            Condition.Requires(a).IsGreaterOrEqualTo(Two);
        }

        [TestMethod]
        [Description("Calling IsGreaterOrEqualTo on Single x with 'lower bound = x' should pass.")]
        public void IsSingleGreaterOrEqualToTest2()
        {
            Single a = Two;
            Condition.Requires(a).IsGreaterOrEqualTo(Two);
        }

        [TestMethod]
        [Description("Calling IsGreaterOrEqualTo on Single x with 'lower bound < x' should pass.")]
        public void IsSingleGreaterOrEqualToTest3()
        {
            Single a = Three;
            Condition.Requires(a).IsGreaterOrEqualTo(Two);
        }

        [TestMethod]
        [Description("Calling IsGreaterOrEqualTo on Single x with 'lower bound > x' should succeed when exceptions are suppressed.")]
        public void IsSingleGreaterOrEqualTest04()
        {
            Single a = One;
            Condition.Requires(a).SuppressExceptionsForTest().IsGreaterOrEqualTo(Two);
        }

        #endregion // IsSingleGreaterOrEqualTo

        #region IsSingleLessThan

        [TestMethod]
        [Description("Calling IsLessThan on Single x with 'x < upper bound' should pass.")]
        public void IsSingleLessThanTest1()
        {
            Single a = One;
            Condition.Requires(a).IsLessThan(Two);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [Description("Calling IsLessThan on Single x with 'x = upper bound' should fail.")]
        public void IsSingleLessThanTest2()
        {
            Single a = Two;
            Condition.Requires(a).IsLessThan(Two);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [Description("Calling IsLessThan on Single x with 'x > upper bound' should fail.")]
        public void IsSingleLessThanTest3()
        {
            Single a = Three;
            Condition.Requires(a).IsLessThan(Two);
        }

        [TestMethod]
        [Description("Calling IsLessThan on Single x with 'x = upper bound' should succeed when exceptions are suppressed.")]
        public void IsSingleLessThanTest4()
        {
            Single a = Two;
            Condition.Requires(a).SuppressExceptionsForTest().IsLessThan(Two);
        }

        #endregion // IsSingleLessThan

        #region IsSingleLessOrEqualTo

        [TestMethod]
        [Description("Calling IsLessOrEqualTo on Single x with 'x < upper bound' should pass.")]
        public void IsSingleLessOrEqualToTest1()
        {
            Single a = One;
            Condition.Requires(a).IsLessOrEqualTo(Two);
        }

        [TestMethod]
        [Description("Calling IsLessOrEqualTo on Single x with 'x = upper bound' should pass.")]
        public void IsSingleLessOrEqualToTest2()
        {
            Single a = Two;
            Condition.Requires(a).IsLessOrEqualTo(Two);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [Description("Calling IsLessOrEqualTo on Single x with 'x > upper bound' should fail.")]
        public void IsSingleLessOrEqualToTest3()
        {
            Single a = Three;
            Condition.Requires(a).IsLessOrEqualTo(Two);
        }

        [TestMethod]
        [Description("Calling IsLessOrEqualTo on Single x with 'x > upper bound' should succeed when exceptions are suppressed.")]
        public void IsSingleLessOrEqualToTest4()
        {
            Single a = Three;
            Condition.Requires(a).SuppressExceptionsForTest().IsLessOrEqualTo(Two);
        }

        #endregion // IsSingleLessOrEqualTo

        #region IsSingleEqualTo

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [Description("Calling IsEqualTo on Single x with 'x < other' should fail.")]
        public void IsSingleEqualToTest1()
        {
            Single a = One;
            Condition.Requires(a).IsEqualTo(Two);
        }

        [TestMethod]
        [Description("Calling IsEqualTo on Single x with 'x = other' should pass.")]
        public void IsSingleEqualToTest2()
        {
            Single a = Two;
            Condition.Requires(a).IsEqualTo(Two);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [Description("Calling IsEqualTo on Single x with 'x > other' should fail.")]
        public void IsSingleEqualToTest3()
        {
            Single a = Three;
            Condition.Requires(a).IsEqualTo(Two);
        }

        [TestMethod]
        [Description("Calling IsEqualTo on Single x with 'x < other' should succeed when exceptions are suppressed.")]
        public void IsSingleEqualToTest4()
        {
            Single a = One;
            Condition.Requires(a).SuppressExceptionsForTest().IsEqualTo(Two);
        }

        #endregion // IsSingleEqualTo

        #region IsSingleNotEqualTo

        [TestMethod]
        [Description("Calling IsNotEqualTo on Single x with 'x < other' should pass.")]
        public void IsSingleNotEqualToTest1()
        {
            Single a = One;
            Condition.Requires(a).IsNotEqualTo(Two);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [Description("Calling IsNotEqualTo on Single x with 'x = other' should fail.")]
        public void IsSingleNotEqualToTest2()
        {
            Single a = Two;
            Condition.Requires(a).IsNotEqualTo(Two);
        }

        [TestMethod]
        [Description("Calling IsNotEqualTo on Single x with 'x > other' should pass.")]
        public void IsSingleNotEqualToTest3()
        {
            Single a = Three;
            Condition.Requires(a).IsNotEqualTo(Two);
        }

        [TestMethod]
        [Description("Calling IsNotEqualTo on Single x with 'x = other' should succeed when exceptions are suppressed.")]
        public void IsSingleNotEqualToTest4()
        {
            Single a = Two;
            Condition.Requires(a).SuppressExceptionsForTest().IsNotEqualTo(Two);
        }

        #endregion // IsSingleNotEqualTo
    }
}