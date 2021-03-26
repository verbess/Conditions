using System;
using System.Data.SqlTypes;
using Conditions.Extensions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Conditions.Tests.CompareTests
{
    [TestClass]
    public class CompareGenericTests
    {
        #region IsInRange

        [TestMethod]
        [Description("Calling IsInRange on IComparable<T> object x with 'lower bound < x < upper bound' should pass.")]
        public void IsInRangeTest1()
        {
            ComparableClass value = new ComparableClass(3);
            ComparableClass min = new ComparableClass(1);
            ComparableClass max = new ComparableClass(10);
            Condition.Requires(value).IsInRange(min, max);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [Description("Calling IsInRange on IComparable<T> object x with 'lower bound > null < upper bound' should fail.")]
        public void IsInRangeTest2()
        {
            ComparableClass value = null;
            ComparableClass min = new ComparableClass(1);
            ComparableClass max = new ComparableClass(10);
            Condition.Requires(value).IsInRange(min, max);
        }

        [TestMethod]
        [Description("Calling IsInRange on IComparable<T> object x with 'null < x < upper bound' should pass.")]
        public void IsInRangeTest3()
        {
            ComparableClass value = new ComparableClass(3);
            ComparableClass min = null;
            ComparableClass max = new ComparableClass(10);
            Condition.Requires(value).IsInRange(min, max);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [Description("Calling IsInRange on IComparable<T> object x with 'lower bound < x > null' should fail.")]
        public void IsInRangeTest4()
        {
            ComparableClass value = new ComparableClass(3);
            ComparableClass min = new ComparableClass(1);
            ComparableClass max = null;
            Condition.Requires(value).IsInRange(min, max);
        }

        [TestMethod]
        [Description("Calling IsInRange on IComparable<T> object x with 'null = null < upper bound' should pass.")]
        public void IsInRangeTest5()
        {
            ComparableClass value = null;
            ComparableClass min = null;
            ComparableClass max = new ComparableClass(10);
            Condition.Requires(value).IsInRange(min, max);
        }

        [TestMethod]
        [Description("Calling IsInRange on IComparable<T> object x with 'null = null = null' should pass.")]
        public void IsInRangeTest6()
        {
            ComparableClass value = null;
            ComparableClass min = null;
            ComparableClass max = null;
            Condition.Requires(value).IsInRange(min, max);
        }

        [TestMethod]
        [Description("Calling IsInRange on IComparable struct x with 'lower bound < x < upper bound' should pass.")]
        public void IsInRangeTest7()
        {
            // SqlInt32 does not implement IComparable<SqlInt32>, only IComparable.
            SqlInt32 value = 3;
            SqlInt32 min = 1;
            SqlInt32 max = 10;
            Condition.Requires(value).IsInRange(min, max);
        }

        [TestMethod]
        [Description("Calling IsInRange on string x with 'lower bound < x < upper bound' should pass.")]
        public void IsInRangeTest8()
        {
            string value = "c";
            string min = "a";
            string max = "j";
            Condition.Requires(value).IsInRange(min, max);
        }

        [TestMethod]
        [Description("Calling IsInRange on Nullable<int> x with 'null < x < upper bound' should pass.")]
        public void IsInRangeTest9()
        {
            int? value = 3;
            int? min = null;
            int? max = 10;
            Condition.Requires(value).IsInRange(min, max);
        }

        [TestMethod]
        [Description("Calling IsInRange on Nullable<int> x with '(int)lower bound < x < (int)upper bound' should pass.")]
        public void IsInRangeTest10()
        {
            int? value = 3;
            int min = 1;
            int max = 10;
            // There is a special overload that takes T's instead of Nullable<T>'s, because C# type inference
            // doesn't work well with types that can implicitly be converted to types that are arguments in
            // method overloads in the candidate set.
            Condition.Requires(value).IsInRange(min, max);
        }

        [TestMethod]
        [Description("Calling IsInRange on System.Enum x with 'lower bound < x < upper bound' should pass.")]
        public void IsInRangeTest11()
        {
            DayOfWeek friday = DayOfWeek.Friday;
            Condition.Requires(friday).IsInRange(DayOfWeek.Sunday, DayOfWeek.Saturday);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [Description("Calling IsInRange on Nullable<int> x with 'null < x > upper bound' should fail.")]
        public void IsInRangeTest12()
        {
            int? value = 10;
            int? min = null;
            int? max = 3;
            Condition.Requires(value).IsInRange(min, max);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [Description("Calling IsInRange on Nullable<int> x with '(int)lower bound < x > (int)upper bound' should fail.")]
        public void IsInRangeTest13()
        {
            int? value = 10;
            int min = 1;
            int max = 3;
            // There is a special overload that takes T's instead of Nullable<T>'s, because C# type inference
            // doesn't work well with types that can implicitly be converted to types that are arguments in
            // method overloads in the candidate set.
            Condition.Requires(value).IsInRange(min, max);
        }

        [TestMethod]
        [ExpectedException(typeof(System.ArgumentException))]
        [Description("Calling IsInRange on System.Enum x with 'lower bound < x > upper bound' should fail with an ArgumentException.")]
        public void IsInRangeTest14()
        {
            DayOfWeek weekDay = DayOfWeek.Saturday;
            Condition.Requires(weekDay).IsInRange(DayOfWeek.Monday, DayOfWeek.Friday);
        }

        #endregion // IsInRange

        #region IsNotInRange

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [Description("Calling IsNotInRange on IComparable<T> object with 'lower bound < x < upper bound' should fail.")]
        public void IsNotInRangeTest1()
        {
            ComparableClass value = new ComparableClass(3);
            ComparableClass min = new ComparableClass(1);
            ComparableClass max = new ComparableClass(10);
            Condition.Requires(value).IsNotInRange(min, max);
        }

        [TestMethod]
        [Description("Calling IsNotInRange on IComparable<T> object with 'lower bound > null < upper bound' should pass.")]
        public void IsNotInRangeTest2()
        {
            ComparableClass value = null;
            ComparableClass min = new ComparableClass(1);
            ComparableClass max = new ComparableClass(10);
            Condition.Requires(value).IsNotInRange(min, max);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [Description("Calling IsNotInRange on IComparable<T> object with 'null < x < upper bound' should fail.")]
        public void IsNotInRangeTest3()
        {
            ComparableClass value = new ComparableClass(3);
            ComparableClass min = null;
            ComparableClass max = new ComparableClass(10);
            Condition.Requires(value).IsNotInRange(min, max);
        }

        [TestMethod]
        [Description("Calling IsNotInRange on IComparable<T> object with 'lower bound < x > null' should pass.")]
        public void IsNotInRangeTest4()
        {
            ComparableClass value = new ComparableClass(3);
            ComparableClass min = new ComparableClass(1);
            ComparableClass max = null;
            Condition.Requires(value).IsNotInRange(min, max);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        [Description("Calling IsNotInRange on IComparable<T> object with 'null = null < upper bound' should fail.")]
        public void IsNotInRangeTest5()
        {
            ComparableClass value = null;
            ComparableClass min = null;
            ComparableClass max = new ComparableClass(10);
            Condition.Requires(value).IsNotInRange(min, max);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        [Description("Calling IsNotInRange on IComparable<T> object with 'null = null = null' should fail.")]
        public void IsNotInRangeTest6()
        {
            ComparableClass value = null;
            ComparableClass min = null;
            ComparableClass max = null;
            Condition.Requires(value).IsNotInRange(min, max);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [Description("Calling IsNotInRange on IComparable struct with 'lower bound < x < upper bound' should fail.")]
        public void IsNotInRangeTest7()
        {
            // SqlInt32 does not implement IComparable<SqlInt32>, only IComparable.
            SqlInt32 value = 3;
            SqlInt32 min = 1;
            SqlInt32 max = 10;
            Condition.Requires(value).IsNotInRange(min, max);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [Description("Calling IsNotInRange on string with 'lower bound < x < upper bound' should fail.")]
        public void IsNotInRangeTest8()
        {
            string value = "c";
            string min = "a";
            string max = "j";
            Condition.Requires(value).IsNotInRange(min, max);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [Description("Calling IsNotInRange on Nullable<int> with 'lower bound < x < upper bound' should fail.")]
        public void IsNotInRangeTest9()
        {
            int? value = 3;
            int? min = null;
            int? max = 10;
            Condition.Requires(value).IsNotInRange(min, max);
        }

        [TestMethod]
        [Description("Calling IsNotInRange on Nullable<int> with '(int)lower bound > x < (int)upper bound' should pass."
            )]
        public void IsNotInRangeTest10()
        {
            int? value = 3;
            int min = 10; // min and max are normal integers
            int max = 100;

            Condition.Requires(value).IsNotInRange(min, max);
        }

        [TestMethod]
        [Description("Calling IsNotInRange on Enum with 'lower bound < x > upper bound' should pass.")]
        public void IsNotInRangeTest11()
        {
            DayOfWeek friday = DayOfWeek.Friday;
            Condition.Requires(friday).IsNotInRange(DayOfWeek.Sunday, DayOfWeek.Thursday);
        }

        [TestMethod]
        [Description("Calling IsNotInRange on Nullable<int> with 'lower bound < x > upper bound' should pass.")]
        public void IsNotInRangeTest12()
        {
            int? value = 10;
            int? min = null;
            int? max = 3;
            Condition.Requires(value).IsNotInRange(min, max);
        }

        [TestMethod]
        [ExpectedException(typeof(System.ArgumentException))]
        [Description("Calling IsNotInRange on Enum with 'lower bound < x > upper bound' should fail with an ArgumentException.")]
        public void IsNotInRangeTest13()
        {
            DayOfWeek wednesday = DayOfWeek.Wednesday;
            Condition.Requires(wednesday).IsNotInRange(DayOfWeek.Monday, DayOfWeek.Friday);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [Description("Calling IsNotInRange on Nullable<int> with '(int)lower bound < x < (int)upper bound' should fail.")]
        public void IsNotInRangeTest14()
        {
            int? value = 90;
            int min = 10; // min and max are normal integers
            int max = 100;

            Condition.Requires(value).IsNotInRange(min, max);
        }

        #endregion // IsNotInRange

        #region IsEqualTo

        [TestMethod]
        [Description("Calling IsEqualTo on IComparable<T> object x with 'x = other' should pass.")]
        public void IsEqualToTest1()
        {
            ComparableClass a = new ComparableClass();
            Condition.Requires(a).IsEqualTo(a);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        [Description("Calling IsEqualTo on IComparable<T> object x with 'null != other' should fail.")]
        public void IsEqualToTest2()
        {
            ComparableClass a = null;
            ComparableClass b = new ComparableClass();
            Condition.Requires(a).IsEqualTo(b);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [Description("Calling IsEqualTo on IComparable<T> object x with 'x != null' should fail.")]
        public void IsEqualToTest3()
        {
            ComparableClass a = new ComparableClass();
            ComparableClass b = null;
            Condition.Requires(a).IsEqualTo(b);
        }

        [TestMethod]
        [Description("Calling IsEqualTo on IComparable<T> object x with 'null = null' should pass.")]
        public void IsEqualToTest4()
        {
            ComparableClass a = null;
            ComparableClass b = null;
            Condition.Requires(a).IsEqualTo(b);
        }

        [TestMethod]
        [Description("Calling IsEqualTo on Nullable<T> x with 'x = (int)other' should pass.")]
        public void IsEqualToTest5()
        {
            int? a = 3;
            int b = (int)a; // b is a normal integer
            Condition.Requires(a).IsEqualTo(b);
        }

        [TestMethod]
        [Description("Calling IsEqualTo on Enum x with 'x = other' should pass.")]
        public void IsEqualToTest6()
        {
            DayOfWeek friday = DayOfWeek.Friday;
            Condition.Requires(friday).IsEqualTo(friday);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        [Description("Calling IsEqualTo on x == null with 'x = 4' should fail with ArgumentNullException.")]
        public void IsEqualToTest7()
        {
            int? a = null;
            int b = 4; // b is a normal integer
            Condition.Requires(a).IsEqualTo(b);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        [Description("Calling IsEqualTo on x == null with 'x = 4' should fail with ArgumentNullException.")]
        public void IsEqualToTest8()
        {
            int? a = null;
            int? b = 4;
            Condition.Requires(a).IsEqualTo(b);
        }

        [TestMethod]
        [Description("Calling IsEqualTo on Nullable<T> x with 'x = x' should pass.")]
        public void IsEqualToTest9()
        {
            int? a = 6;
            int? b = a;
            Condition.Requires(a).IsEqualTo(b);
        }

        [TestMethod]
        [ExpectedException(typeof(System.ArgumentException))]
        [Description("Calling IsEqualTo on Enum x with 'x != other' should fail with an ArgumentException.")]
        public void IsEqualToTest10()
        {
            DayOfWeek friday = DayOfWeek.Friday;
            Condition.Requires(friday).IsEqualTo(DayOfWeek.Saturday);
        }

        #endregion // IsEqualTo

        #region IsNotEqualTo

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [Description("Calling IsNotEqualTo on IComparable<T> object x with 'x = other' should fail.")]
        public void IsNotEqualToTest1()
        {
            ComparableClass a = new ComparableClass();
            Condition.Requires(a).IsNotEqualTo(a);
        }

        [TestMethod]
        [Description("Calling IsNotEqualTo on IComparable<T> object x with 'null != other' should pass.")]
        public void IsNotEqualToTest2()
        {
            ComparableClass a = null;
            ComparableClass b = new ComparableClass();
            Condition.Requires(a).IsNotEqualTo(b);
        }

        [TestMethod]
        [Description("Calling IsNotEqualTo on IComparable<T> object x with 'x != null' should pass.")]
        public void IsNotEqualToTest3()
        {
            ComparableClass a = new ComparableClass();
            ComparableClass b = null;
            Condition.Requires(a).IsNotEqualTo(b);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        [Description("Calling IsNotEqualTo on IComparable<T> object x with 'null = null' should fail.")]
        public void IsNotEqualToTest4()
        {
            ComparableClass a = null;
            ComparableClass b = null;
            Condition.Requires(a).IsNotEqualTo(b);
        }

        [TestMethod]
        [Description("Calling IsNotEqualTo on Nullable<int> x with 'x != (int)other' should pass.")]
        public void IsNotEqualToTest5()
        {
            int? a = 3;
            int b = 4;
            Condition.Requires(a).IsNotEqualTo(b);
        }

        [TestMethod]
        [Description("Calling IsNotEqualTo on Enum x with 'x != other' should pass.")]
        public void IsNotEqualToTest6()
        {
            DayOfWeek friday = DayOfWeek.Friday;
            Condition.Requires(friday).IsNotEqualTo(DayOfWeek.Sunday);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        [Description("Calling IsNotEqualTo on Nullable<int> x = null with 'x = x' should fail with ArgumentNullException.")]
        public void IsNotEqualToTest7()
        {
            int? a = null;
            int? b = null;
            Condition.Requires(a).IsNotEqualTo(b);
        }

        [TestMethod]
        [Description("Calling IsNotEqualTo on Nullable<int> x = null with 'x != y' should pass.")]
        public void IsNotEqualToTest8()
        {
            int? a = null;
            int? b = 4;
            Condition.Requires(a).IsNotEqualTo(b);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [Description("Calling IsNotEqualTo on Nullable<int> x with 'x = (int)other' should fail.")]
        public void IsNotEqualToTest9()
        {
            int? a = 4;
            int b = 4;
            Condition.Requires(a).IsNotEqualTo(b);
        }

        [TestMethod]
        [ExpectedException(typeof(System.ArgumentException))]
        [Description("Calling IsNotEqualTo on Enum x with 'x == other' should fail with an ArgumentException.")]
        public void IsNotEqualToTest10()
        {
            DayOfWeek friday = DayOfWeek.Friday;
            Condition.Requires(friday).IsNotEqualTo(friday);
        }

        #endregion // IsNotEqualTo

        #region IsGreaterThan

        [TestMethod]
        [Description("Calling IsGreaterThan on IComparable<T> object x with 'lower bound < x' should pass.")]
        public void IsGreaterThanTest1()
        {
            ComparableClass value = new ComparableClass(3);
            ComparableClass min = new ComparableClass(1);
            Condition.Requires(value).IsGreaterThan(min);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [Description("Calling IsGreaterThan on IComparable<T> object x with 'lower bound < null' should fail.")]
        public void IsGreaterThanTest2()
        {
            ComparableClass value = null;
            ComparableClass min = new ComparableClass(1);
            Condition.Requires(value).IsGreaterThan(min);
        }

        [TestMethod]
        [Description("Calling IsGreaterThan on IComparable<T> object x with 'null < x' should pass.")]
        public void IsGreaterThanTest3()
        {
            ComparableClass value = new ComparableClass(3);
            ComparableClass min = null;
            Condition.Requires(value).IsGreaterThan(min);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [Description("Calling IsGreaterThan on IComparable<T> object x with 'null = null' should fail.")]
        public void IsGreaterThanTest4()
        {
            ComparableClass value = null;
            ComparableClass min = null;
            Condition.Requires(value).IsGreaterThan(min);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [Description("Calling IsGreaterThan on IComparable<T> object x with 'lower bound = x' should fail.")]
        public void IsGreaterThanTest5()
        {
            ComparableClass value = new ComparableClass(0);
            Condition.Requires(value).IsGreaterThan(value);
        }

        [TestMethod]
        [Description("Calling IsGreaterThan on Enum x with 'lower bound < x' should pass.")]
        public void IsGreaterThanTest6()
        {
            DayOfWeek friday = DayOfWeek.Friday;
            Condition.Requires(friday).IsGreaterThan(DayOfWeek.Sunday);
        }

        [TestMethod]
        [Description("Calling IsGreaterThan on Nullable<int> x with '(int)lower bound < x' should pass.")]
        public void IsGreaterThanTest7()
        {
            int? a = 3;
            int min = 2;
            // There is a special overload that takes T's instead of Nullable<T>'s, because C# type inference
            // doesn't work well with types that can implicitly be converted to types that are arguments in
            // method overloads in the candidate set.
            Condition.Requires(a).IsGreaterThan(min);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [Description("Calling IsGreaterThan on Nullable<int> x with '(int)lower bound > x' should fail.")]
        public void IsGreaterThanTest8()
        {
            int? a = 2;
            int min = 3;
            // There is a special overload that takes T's instead of Nullable<T>'s, because C# type inference
            // doesn't work well with types that can implicitly be converted to types that are arguments in
            // method overloads in the candidate set.
            Condition.Requires(a).IsGreaterThan(min);
        }

        [TestMethod]
        [Description("Calling IsGreaterThan on Nullable<int> x with 'lower bound < x' should pass.")]
        public void IsGreaterThanTest9()
        {
            int? a = 3;
            int? min = 2;
            // There is a special overload that takes T's instead of Nullable<T>'s, because C# type inference
            // doesn't work well with types that can implicitly be converted to types that are arguments in
            // method overloads in the candidate set.
            Condition.Requires(a).IsGreaterThan(min);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [Description("Calling IsGreaterThan on Nullable<int> x with 'lower bound > x' should fail.")]
        public void IsGreaterThanTest10()
        {
            int? a = 2;
            int? min = 3;
            // There is a special overload that takes T's instead of Nullable<T>'s, because C# type inference
            // doesn't work well with types that can implicitly be converted to types that are arguments in
            // method overloads in the candidate set.
            Condition.Requires(a).IsGreaterThan(min);
        }

        [TestMethod]
        [ExpectedException(typeof(System.ArgumentException))]
        [Description("Calling IsGreaterThan on Enum x with 'lower bound > x' should fail with an ArgumentException.")]
        public void IsGreaterThanTest11()
        {
            DayOfWeek friday = DayOfWeek.Friday;
            Condition.Requires(friday).IsGreaterThan(DayOfWeek.Saturday);
        }

        #endregion // IsGreaterThan

        #region IsGreaterOrEqualTo

        [TestMethod]
        [Description("Calling IsGreaterOrEqualTo on IComparable<T> object x with 'lower bound < x' should pass.")]
        public void IsGreaterOrEqualToTest1()
        {
            ComparableClass value = new ComparableClass(3);
            ComparableClass min = new ComparableClass(1);
            Condition.Requires(value).IsGreaterOrEqualTo(min);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [Description("Calling IsGreaterOrEqualTo on IComparable<T> object x with 'lower bound > null' should fail.")]
        public void IsGreaterOrEqualToTest2()
        {
            ComparableClass value = null;
            ComparableClass min = new ComparableClass(1);
            Condition.Requires(value).IsGreaterOrEqualTo(min);
        }

        [TestMethod]
        [Description("Calling IsGreaterOrEqualTo on IComparable<T> object x with 'lower bound < x' should pass.")]
        public void IsGreaterOrEqualToTest3()
        {
            ComparableClass value = new ComparableClass(3);
            ComparableClass min = null;
            Condition.Requires(value).IsGreaterOrEqualTo(min);
        }

        [TestMethod]
        [Description("Calling IsGreaterOrEqualTo on IComparable<T> object x with 'null < null' should pass.")]
        public void IsGreaterOrEqualToTest4()
        {
            ComparableClass value = null;
            Condition.Requires(value).IsGreaterOrEqualTo(value);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [Description("Calling IsGreaterOrEqualTo on IComparable<T> object x with 'lower bound > null' should fail.")]
        public void IsGreaterOrEqualToTest5()
        {
            ComparableClass value = null;
            ComparableClass min = new ComparableClass(Int32.MinValue);
            Condition.Requires(value).IsGreaterOrEqualTo(min);
        }

        [TestMethod]
        [Description("Calling IsGreaterOrEqualTo on IComparable<T> object x with 'null < x' should pass.")]
        public void IsGreaterOrEqualToTest6()
        {
            ComparableClass value = new ComparableClass(Int32.MinValue);
            ComparableClass min = null;
            Condition.Requires(value).IsGreaterOrEqualTo(min);
        }

        [TestMethod]
        [Description("Calling IsGreaterOrEqualTo on IComparable<T> object x with 'lower bound = x' should pass.")]
        public void IsGreaterOrEqualToTest7()
        {
            ComparableClass value = new ComparableClass(0);
            Condition.Requires(value).IsGreaterOrEqualTo(value);
        }

        [TestMethod]
        [Description("Calling IsGreaterOrEqualTo on Nullable<int> x with '(int)lower bound < x' should pass.")]
        public void IsGreaterOrEqualToTest8()
        {
            int? a = 3;
            int min = 2; // min is a normal integer
            Condition.Requires(a).IsGreaterOrEqualTo(min);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [Description("Calling IsGreaterOrEqualTo on Nullable<int> x with '(int)lower bound > x' should fail.")]
        public void IsGreaterOrEqualToTest9()
        {
            int? a = 2;
            int min = 3; // min is a normal integer
            Condition.Requires(a).IsGreaterOrEqualTo(min);
        }

        [TestMethod]
        [Description("Calling IsGreaterOrEqualTo on Nullable<int> x with 'lower bound < x' should pass.")]
        public void IsGreaterOrEqualToTest10()
        {
            int? a = 3;
            int? min = 2;
            Condition.Requires(a).IsGreaterOrEqualTo(min);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [Description("Calling IsGreaterOrEqualTo on Nullable<int> x with 'lower bound > x' should fail.")]
        public void IsGreaterOrEqualToTest11()
        {
            int? a = 2;
            int? min = 3;
            Condition.Requires(a).IsGreaterOrEqualTo(min);
        }

        [TestMethod]
        [Description("Calling IsGreaterOrEqualTo on Enum x with 'lower bound = x' should pass.")]
        public void IsGreaterOrEqualToTest12()
        {
            DayOfWeek friday = DayOfWeek.Friday;
            Condition.Requires(friday).IsGreaterOrEqualTo(friday);
        }

        [TestMethod]
        [ExpectedException(typeof(System.ArgumentException))]
        [Description("Calling IsGreaterOrEqualTo on Enum x with 'lower bound < x' should fail with an ArgumentException.")]
        public void IsGreaterOrEqualToTest13()
        {
            DayOfWeek friday = DayOfWeek.Friday;
            Condition.Requires(friday).IsGreaterOrEqualTo(DayOfWeek.Saturday);
        }

        #endregion // IsGreaterOrEqualTo

        #region IsLessThan

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [Description("Calling IsLessThan on IComparable<T> object x with 'x > upper bound' should fail.")]
        public void IsLessThanTest1()
        {
            ComparableClass value = new ComparableClass(3);
            ComparableClass max = new ComparableClass(1);
            Condition.Requires(value).IsLessThan(max);
        }

        [TestMethod]
        [Description("Calling IsLessThan on IComparable<T> object x with 'null < upper bound' should pass.")]
        public void IsLessThanTest2()
        {
            ComparableClass value = null;
            ComparableClass max = new ComparableClass(1);
            Condition.Requires(value).IsLessThan(max);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [Description("Calling IsLessThan on IComparable<T> object x with 'x > null' should fail.")]
        public void IsLessThanTest3()
        {
            ComparableClass value = new ComparableClass(3);
            ComparableClass max = null;
            Condition.Requires(value).IsLessThan(max);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [Description("Calling IsLessThan on IComparable<T> object x with 'null = null' should fail.")]
        public void IsLessThanTest4()
        {
            ComparableClass value = null;
            Condition.Requires(value).IsLessThan(null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [Description("Calling IsLessThan on IComparable<T> object x with 'x = x' should fail.")]
        public void IsLessThanTest5()
        {
            ComparableClass value = new ComparableClass(0);
            Condition.Requires(value).IsLessThan(value);
        }

        [TestMethod]
        [Description("Calling IsLessThan on Nullable<int> x with 'x < (int)upper bound' should pass.")]
        public void IsLessThanTest6()
        {
            int? a = 3;
            int max = 4; // max is a normal integer
            Condition.Requires(a).IsLessThan(max);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [Description("Calling IsLessThan on Nullable<int> x with 'x > (int)upper bound' should fail.")]
        public void IsLessThanTest7()
        {
            int? a = 4;
            int max = 3; // max is a normal integer
            Condition.Requires(a).IsLessThan(max);
        }

        [TestMethod]
        [Description("Calling IsLessThan on Nullable<int> x with 'x < upper bound' should pass.")]
        public void IsLessThanTest8()
        {
            int? a = 3;
            int? max = 4;
            Condition.Requires(a).IsLessThan(max);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [Description("Calling IsLessThan on Nullable<int> x with 'x > upper bound' should fail.")]
        public void IsLessThanTest9()
        {
            int? a = 4;
            int? max = 3;
            Condition.Requires(a).IsLessThan(max);
        }

        [TestMethod]
        [Description("Calling IsLessThan on Enum x with 'x < upper bound' should pass.")]
        public void IsLessThanTest10()
        {
            DayOfWeek friday = DayOfWeek.Friday;
            Condition.Requires(friday).IsLessThan(DayOfWeek.Saturday);
        }

        [TestMethod]
        [ExpectedException(typeof(System.ArgumentException))]
        [Description("Calling IsLessThan on Enum x with 'x < upper bound' should fail with an ArgumentException.")]
        public void IsLessThanTest11()
        {
            DayOfWeek friday = DayOfWeek.Friday;
            Condition.Requires(friday).IsLessThan(DayOfWeek.Thursday);
        }

        #endregion // IsLessThan

        #region IsLessOrEqualTo

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [Description("Calling IsLessOrEqualTo on IComparable<T> object x with 'x < upper bound' should fail.")]
        public void IsLessOrEqualToTest1()
        {
            ComparableClass value = new ComparableClass(3);
            ComparableClass max = new ComparableClass(1);
            Condition.Requires(value).IsLessOrEqualTo(max);
        }

        [TestMethod]
        [Description("Calling IsLessOrEqualTo on IComparable<T> object x with 'null < upper bound' should pass.")]
        public void IsLessOrEqualToTest2()
        {
            ComparableClass value = null;
            ComparableClass max = new ComparableClass(1);
            Condition.Requires(value).IsLessOrEqualTo(max);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [Description("Calling IsLessOrEqualTo on IComparable<T> object x with 'x > null' should fail.")]
        public void IsLessOrEqualToTest3()
        {
            ComparableClass value = new ComparableClass(3);
            ComparableClass max = null;
            Condition.Requires(value).IsLessOrEqualTo(max);
        }

        [TestMethod]
        [Description("Calling IsLessOrEqualTo on IComparable<T> object x with 'null = null' should pass.")]
        public void IsLessOrEqualToTest4()
        {
            ComparableClass value = null;
            Condition.Requires(value).IsLessOrEqualTo(value);
        }

        [TestMethod]
        [Description("Calling IsLessOrEqualTo on IComparable<T> object x with 'null < upper bound' should pass.")]
        public void IsLessOrEqualToTest5()
        {
            ComparableClass value = null;
            ComparableClass max = new ComparableClass(Int32.MinValue);
            Condition.Requires(value).IsLessOrEqualTo(max);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [Description("Calling IsLessOrEqualTo on IComparable<T> object x with 'x > null' should fail.")]
        public void IsLessOrEqualToTest6()
        {
            ComparableClass value = new ComparableClass(Int32.MinValue);
            ComparableClass max = null;
            Condition.Requires(value).IsLessOrEqualTo(max);
        }

        [TestMethod]
        [Description("Calling IsLessOrEqualTo on IComparable<T> object x with 'x = upper bound' should pass.")]
        public void IsLessOrEqualToTest7()
        {
            ComparableClass value = new ComparableClass(0);
            Condition.Requires(value).IsLessOrEqualTo(value);
        }

        [TestMethod]
        [Description("Calling IsLessOrEqualTo on Nullable<int> x with 'x < (int)upper bound' should pass.")]
        public void IsLessOrEqualToTest8()
        {
            int? a = 3;
            int max = 4; // max is a normal integer
            Condition.Requires(a).IsLessOrEqualTo(max);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [Description("Calling IsLessOrEqualTo on Nullable<int> x with 'x > (int)upper bound' should fail.")]
        public void IsLessOrEqualToTest9()
        {
            int? a = 4;
            int max = 3; // max is a normal integer
            Condition.Requires(a).IsLessOrEqualTo(max);
        }

        [TestMethod]
        [Description("Calling IsLessOrEqualTo on Nullable<int> x with 'x < upper bound' should pass.")]
        public void IsLessOrEqualToTest10()
        {
            int? a = 3;
            int? max = 4;
            Condition.Requires(a).IsLessOrEqualTo(max);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [Description("Calling IsLessOrEqualTo on Nullable<int> x with 'x > upper bound' should fail.")]
        public void IsLessOrEqualToTest11()
        {
            int? a = 4;
            int? max = 3;
            Condition.Requires(a).IsLessOrEqualTo(max);
        }

        [TestMethod]
        [Description("Calling IsLessOrEqualTo on Enum x with 'x = upper bound' should pass.")]
        public void IsLessOrEqualToTest12()
        {
            DayOfWeek friday = DayOfWeek.Friday;
            Condition.Requires(friday).IsLessOrEqualTo(friday);
        }

        [TestMethod]
        [ExpectedException(typeof(System.ArgumentException))]
        [Description("Calling IsLessOrEqualTo on Enum x with 'x > upper bound' should fail with an ArgumentException.")]
        public void IsLessOrEqualToTest13()
        {
            DayOfWeek friday = DayOfWeek.Friday;
            Condition.Requires(friday).IsLessOrEqualTo(DayOfWeek.Thursday);
        }

        #endregion // IsLessOrEqualTo

        private sealed class ComparableClass : IComparable<ComparableClass>, IComparable
        {
            private readonly int value;
            public ComparableClass()
            {
            }

            public ComparableClass(int value)
            {
                this.value = value;
            }

            public int CompareTo(ComparableClass other)
            {
                if (other == null)
                {
                    return 1;
                }

                return value.CompareTo(other.value);
            }

            public int CompareTo(object obj)
            {
                ComparableClass other = obj as ComparableClass;

                return other != null ? CompareTo(other) : 1;
            }
        }
    }
}