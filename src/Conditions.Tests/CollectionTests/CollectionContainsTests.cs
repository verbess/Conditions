using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Conditions.Extensions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Conditions.Tests.CollectionTests
{
    /// <summary>
    /// Tests the ValidatorExtensions.Contains method.
    /// </summary>
    [TestClass]
    public class CollectionContainsTests
    {
        // Calling Contains on an array should compile.
        internal static void CollectionContainsShouldCompileTest1()
        {
            int[] c = { 1 };
            Condition.Requires(c).Contains(1);
        }

        // Calling Contains on a Collection should compile.
        internal static void CollectionContainsShouldCompileTest2()
        {
            Collection<int> c = new Collection<int> { 1 };
            Condition.Requires(c).Contains(1);
        }

        // Calling Contains on an IEnumerable should compile.
        internal static void CollectionContainsShouldCompileTest3()
        {
            IEnumerable<int> c = new Collection<int> { 1 };
            Condition.Requires(c).Contains(1);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        [Description("Calling Contains on null reference should fail.")]
        public void CollectionContainsTest1()
        {
            Collection<int> c = null;
            Condition.Requires(c).Contains(1);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [Description("Calling Contains on an empty collection should fail.")]
        public void CollectionContainsTest2()
        {
            Collection<int> c = new Collection<int>();
            Condition.Requires(c).Contains(1);
        }

        [TestMethod]
        [Description("Calling Contains on an Collection that contains the tested value should pass.")]
        public void CollectionContainsTest3()
        {
            Collection<int> c = new Collection<int> { 1 };
            Condition.Requires(c).Contains(1);
        }

        [TestMethod]
        [Description("Calling Contains on an non-generic Collection that contains the tested value should pass.")]
        public void CollectionContainsTest4()
        {
            ArrayList c = new ArrayList { 1 };
            Condition.Requires(c).Contains((object)1);
        }

        [TestMethod]
        [Description("Calling Contains on an typed Collection that contains the tested non-generic value should pass.")]
        public void CollectionContainsTest5()
        {
            Collection<int> c = new Collection<int> { 1 };
            Condition.Requires(c).Contains((object)1);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [Description(
            "Calling Contains on an typed Collection that doesn't contain the tested non-generic value should fail.")]
        public void CollectionContainsTest6()
        {
            Collection<int> c = new Collection<int> { 1 };
            Condition.Requires(c).Contains(new object());
        }

        [TestMethod]
        [Description("Calling Contains on a type that doesn't implement ICollection or ICollection<T>, but contains the tested value should pass.")]
        public void CollectionContainsTest7()
        {
            IEnumerable c = Enumerable.Range(1, 1000);
            Condition.Requires(c).Contains((object)1000);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [Description("Calling Contains on a type that doesn't implement ICollection or ICollection<T> and doesn't contain the tested value should fail.")]
        public void CollectionContainsTest8()
        {
            IEnumerable c = Enumerable.Range(1, 1000);
            Condition.Requires(c).Contains((object)1001);
        }

        [TestMethod]
        [Description("Calling Contains on a type that implements IEnumerable<T> but no ICollection<T>, but contains the tested value should pass.")]
        public void CollectionContainsTest9()
        {
            IEnumerable<int> c = Enumerable.Range(1, 10);
            Condition.Requires(c).Contains(10);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [Description("Calling Contains on a type that implements IEnumerable<T> but no ICollection<T>, but doesn't contain the tested value should fail.")]
        public void CollectionContainsTest10()
        {
            IEnumerable<int> c = Enumerable.Range(1, 10);
            Condition.Requires(c).Contains(11);
        }

        [TestMethod]
        [Description(
            "Calling the generic Contains with an element that's not in the list while enumerating it, should fail.")]
        public void CollectionContainsTest11()
        {
            // Defines a set with a special equality comparer.
            HashSet<int> set = new HashSet<int>(new[] { 1, 2, 3, 4 }, new OddEqualityComparer());

            // Because of the use of OddEqualityComparer, the collection only contains the values 1 and 2.
            Assert.IsTrue(set.Count == 2);
            // Because of the use of OddEqualityComparer, set.Contains should return true.
            Assert.IsTrue(set.Contains(3), "OddEqualityComparer is implemented incorrectly.");

            // Because the value is not in the initial list, Contains should fail.
            // Otherwise this behavior would be inconsistent with the non-generic overload of Contains.
            try
            {
                // Call the generic Contains<C, E>(Validator<C>, E) overload.
                Condition.Requires(set).Contains(3);
                Assert.Fail("Contains did not throw the excepted ArgumentException.");
            }
            catch
            {
                // We expect an exception to be thrown.
            }
        }

        [TestMethod]
        [Description("Calling the non-generic Contains with an element that's not in the list while enumerating it, should fail.")]
        public void CollectionContainsTest12()
        {
            // Defines a set with a special equality comparer.
            HashSet<int> set = new HashSet<int>(new[] { 1, 2, 3, 4 }, new OddEqualityComparer());

            // Because of the use of OddEqualityComparer, the collection only contains the values 1 and 2.
            Assert.IsTrue(set.Count == 2);
            // Because of the use of OddEqualityComparer, set.Contains should return true.
            Assert.IsTrue(set.Contains(3), "OddEqualityComparer is implemented incorrectly.");

            // Because the value is not in the initial list, Contains should fail.
            try
            {
                // Call the non-generic Contains<T>(Validator<T>, object) overload.
                Condition.Requires(set).Contains((object)3);
                Assert.Fail("Contains did not throw the excepted ArgumentException.");
            }
            catch
            {
                // We expect an exception to be thrown.
            }
        }

        [TestMethod]
        [Description("Calling Contains on an a null reference should succeed when exceptions are suppressed.")]
        public void CollectionContainsTest13()
        {
            Collection<int> c = null;
            Condition.Requires(c).SuppressExceptionsForTest().Contains(1);
        }
    }
}