using System;
using System.Collections;
using System.Collections.ObjectModel;
using Conditions.Extensions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Conditions.Tests.TypeTests
{
    [TestClass]
    public class TypeIsTypeTests
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        [Description("Calling IsType on null reference should fail.")]
        public void IsTypeTest1()
        {
            object o = null;

            Condition.Requires(o).IsType(typeof(EventArgs));
        }

        [TestMethod]
        [Description("Calling IsType on a down-casted object tested to be the down-casted type should pass.")]
        public void IsTypeTest2()
        {
            object o = "String";

            Condition.Requires(o).IsType(typeof(object));
        }

        [TestMethod]
        [Description("Calling IsType on a down-casted object tested to be the real type should pass.")]
        public void IsTypeTest3()
        {
            object o = "String";

            Condition.Requires(o).IsType(typeof(string));
        }

        [TestMethod]
        [Description("Calling IsType on a object tested to be it's parent type should pass.")]
        public void IsTypeTest4()
        {
            string s = "String";

            Condition.Requires(s).IsType(typeof(object));
        }

        [TestMethod]
        [Description("Calling IsType on a object tested to be it's own type should pass.")]
        public void IsTypeTest5()
        {
            string s = "String";

            Condition.Requires(s).IsType(typeof(string));
        }

        [TestMethod]
        [Description("Calling IsType on a System.Object tested to be System.Object should pass.")]
        public void IsTypeTest6()
        {
            object o = new object();

            Condition.Requires(o).IsType(typeof(object));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [Description("Calling IsType on a down-casted object tested to be a non comparable type should fail.")]
        public void IsTypeTest7()
        {
            object o = "String";

            Condition.Requires(o).IsType(typeof(EventArgs));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [Description("Calling IsType on a object tested to be a non comparable type should fail.")]
        public void IsTypeTest8()
        {
            string s = "String";

            Condition.Requires(s).IsType(typeof(EventArgs));
        }

        [TestMethod]
        [Description(
            "Calling IsType on an object implementing ICollection tested to implement ICollection should pass.")]
        public void IsTypeTest9()
        {
            ICollection o = new Collection<int>();

            Condition.Requires(o).IsType(typeof(ICollection));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [Description("Calling IsType on an enum tested to implement ICollection should fail with an ArgumentException.")]
        public void IsTypeTest10()
        {
            object day = DayOfWeek.Monday;

            Condition.Requires(day).IsType(typeof(ICollection));
        }

        [TestMethod]
        [Description("Calling IsType on null reference should succeed when exceptions are suppressed.")]
        public void IsTypeTest11()
        {
            object o = null;

            Condition.Requires(o).SuppressExceptionsForTest().IsType(typeof(EventArgs));
        }
    }
}