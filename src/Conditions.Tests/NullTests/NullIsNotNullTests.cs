using System;
using Conditions.Extensions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Conditions.Tests.NullTests
{
    [TestClass]
    public class NullIsNotNullTests
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        [Description("Calling IsNotNull on null should fail.")]
        public void IsNotNullTest1()
        {
            object o = null;
            Condition.Requires(o).IsNotNull();
        }

        [TestMethod]
        [Description("Calling IsNotNull on a reference should pass.")]
        public void IsNotNullTest2()
        {
            object o = new object();
            Condition.Requires(o).IsNotNull();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        [Description("Calling IsNotNull on a null Nullable<T> should fail.")]
        public void IsNotNullTest3()
        {
            int? i = null;
            Condition.Requires(i).IsNotNull();
        }

        [TestMethod]
        [Description("Calling IsNotNull on a set Nullable<T> should pass.")]
        public void IsNotNullTest4()
        {
            int? i = 3;
            Condition.Requires(i).IsNotNull();
        }

        [TestMethod]
        [Description("Calling IsNotNull on an object containing an enum should pass.")]
        public void IsNotNullTest5()
        {
            object i = DayOfWeek.Sunday;
            Condition.Requires(i).IsNotNull();
        }

        [TestMethod]
        [Description("Calling IsNotNull on null should succeed when exceptions are suppressed.")]
        public void IsNotNullTest6()
        {
            object o = null;
            Condition.Requires(o).SuppressExceptionsForTest().IsNotNull();
        }
    }
}