using System;
using Conditions.Extensions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Conditions.Tests.NullTests
{
    [TestClass]
    public class NullIsNullTests
    {
        [TestMethod]
        [Description("Calling IsNull on null should pass.")]
        public void IsNullTest1()
        {
            object o = null;
            Condition.Requires(o).IsNull();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [Description("Calling IsNull on a reference should fail.")]
        public void IsNullTest2()
        {
            object o = new object();
            Condition.Requires(o).IsNull();
        }

        [TestMethod]
        [Description("Calling IsNull on a null Nullable<T> should pass.")]
        public void IsNullTest3()
        {
            int? i = null;
            Condition.Requires(i).IsNull();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [Description("Calling IsNull on a set Nullable<T> should fail.")]
        public void IsNullTest4()
        {
            int? i = 3;
            Condition.Requires(i).IsNull();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [Description("Calling IsNull on an object containing an enum should fail with ArgumentException.")]
        public void IsNullTest5()
        {
            object i = DayOfWeek.Sunday;
            Condition.Requires(i).IsNull();
        }

        [TestMethod]
        [Description("Calling IsNull on a reference should succeed when exceptions are suppressed.")]
        public void IsNullTest6()
        {
            object o = new object();
            Condition.Requires(o).SuppressExceptionsForTest().IsNull();
        }
    }
}