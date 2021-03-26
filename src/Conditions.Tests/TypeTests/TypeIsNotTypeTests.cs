using System;
using System.Collections;
using System.Collections.ObjectModel;
using Conditions.Extensions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Conditions.Tests.TypeTests
{
    [TestClass]
    public class TypeIsNotTypeTests
    {
        [TestMethod]
        [Description("Calling IsNotType on null reference should pass.")]
        public void IsNotTypeTest1()
        {
            object o = null;

            // Null objects have no type, so check must always succeed.
            Condition.Requires(o).IsNotType(typeof(object));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [Description("Calling IsNotType on a down-casted object tested to be the down-casted type should fail.")]
        public void IsNotTypeTest2()
        {
            object o = "String";

            Condition.Requires(o).IsNotType(typeof(object));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [Description("Calling IsNotType on a down-casted object tested to be the real type should fail.")]
        public void IsNotTypeTest3()
        {
            object o = "String";

            Condition.Requires(o).IsNotType(typeof(string));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [Description("Calling IsNotType on an object tested to be the parent type should fail.")]
        public void IsNotTypeTest4()
        {
            string s = "String";

            Condition.Requires(s).IsNotType(typeof(object));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [Description("Calling IsNotType on a down-casted object tested to be the down-casted type should fail.")]
        public void IsNotTypeTest5()
        {
            string s = "String";

            Condition.Requires(s).IsNotType(typeof(string));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [Description("Calling IsNotType on a System.Object tested to be System.Object type should fail.")]
        public void IsNotTypeTest6()
        {
            object o = new object();

            Condition.Requires(o).IsNotType(typeof(object));
        }

        [TestMethod]
        [Description("Calling IsNotType on a down-casted object tested to be an incomparable type should pass.")]
        public void IsNotTypeTest7()
        {
            object o = "String";

            Condition.Requires(o).IsNotType(typeof(EventArgs));
        }

        [TestMethod]
        [Description("Calling IsNotType on an object tested to be an incomparable type should pass.")]
        public void IsNotTypeTest8()
        {
            string s = "String";

            Condition.Requires(s).IsNotType(typeof(EventArgs));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [Description(
            "Calling IsNotType on an object implementing ICollection tested not to implement ICollection should fail."
            )]
        public void IsNotTypeTest9()
        {
            ICollection o = new Collection<int>();

            Condition.Requires(o).IsNotType(typeof(ICollection));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [Description(
            "Calling IsNotType on a DayOfWeek tested to implement DayOfWeek should fail with an ArgumentException.")]
        public void IsNotTypeTest10()
        {
            object day = DayOfWeek.Monday;

            Condition.Requires(day).IsNotType(typeof(DayOfWeek));
        }

        [TestMethod]
        [Description("Calling IsNotType on a down-casted object tested to be the down-casted type should succeed when exceptions are suppressed.")]
        public void IsNotOfTypeTest10()
        {
            object o = "String";

            Condition.Requires(o).SuppressExceptionsForTest().IsNotType(typeof(object));
        }
    }
}