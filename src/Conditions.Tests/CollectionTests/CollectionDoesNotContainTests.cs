using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Conditions.Extensions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Conditions.Tests.CollectionTests
{
    /// <summary>
    /// Tests the ValidatorExtensions.DoesNotContain method.
    /// </summary>
    [TestClass]
    public class CollectionDoesNotContainTests
    {
        // Calling DoesNotContain on an array should compile.
        internal static void CollectionDoesNotContainShouldCompileTest1()
        {
            int[] c = new int[0];
            Condition.Requires(c).DoesNotContain(1);
        }

        // Calling DoesNotContain on a Collection should compile.
        internal static void CollectionDoesNotContainShouldCompileTest2()
        {
            Collection<int> c = new Collection<int>();
            Condition.Requires(c).DoesNotContain(1);
        }

        // Calling DoesNotContain on an IEnumerable should compile.
        internal static void CollectionDoesNotContainShouldCompileTest3()
        {
            IEnumerable<int> c = new Collection<int>();
            Condition.Requires(c).DoesNotContain(1);
        }

        [TestMethod]
        [Description("Calling DoesNotContain on null reference should pass.")]
        public void CollectionDoesNotContainTest1()
        {
            Collection<int> c = null;
            Condition.Requires(c).DoesNotContain(1);
        }

        [TestMethod]
        [Description("Calling DoesNotContain on an empty collection should pass.")]
        public void CollectionDoesNotContainTest2()
        {
            Collection<int> c = new Collection<int>();
            Condition.Requires(c).DoesNotContain(1);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [Description("Calling DoesNotContain on an Collection that contains the tested value should fail.")]
        public void CollectionDoesNotContainTest3()
        {
            Collection<int> c = new Collection<int> { 1 };
            Condition.Requires(c).DoesNotContain(1);
        }

        [TestMethod]
        [Description("Calling DoesNotContain on an ArrayList that does not contain the tested value should pass.")]
        public void CollectionDoesNotContainTest4()
        {
            ArrayList c = new ArrayList { 1, 2, 3, 4 };
            Condition.Requires(c).DoesNotContain((object)5);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [Description("Calling DoesNotContain on an ArrayList that contains the tested value should fail.")]
        public void CollectionDoesNotContainTest5()
        {
            ArrayList c = new ArrayList { 1, 2, 3, 4 };
            Condition.Requires(c).DoesNotContain((object)4);
        }

        [TestMethod]
        [Description("Calling the generic DoesNotContain with an element that's not in the list while enumerating it, should fail.")]
        public void CollectionDoesNotContainTest6()
        {
            // Defines a set with a special equality comparer.
            HashSet<int> set = new HashSet<int>(new[] { 1, 3 }, new OddEqualityComparer());

            // Because of the use of OddEqualityComparer, the collection only contains the value 1.
            Assert.IsTrue(set.Count == 1);
            // Because of the use of OddEqualityComparer, the set contains both 1 and 3.
            Assert.IsTrue(set.Contains(1), "OddEqualityComparer is implemented incorrectly.");
            Assert.IsTrue(set.Contains(3), "OddEqualityComparer is implemented incorrectly.");

            // DoesNotContain should succeed, because 3 should not be in the list while iterating over it.
            // Call the generic DoesNotContain<T>(Validator<T>, T) overload.
            Condition.Requires(set).DoesNotContain(3);
        }

        [TestMethod]
        [Description("Calling the non-generic DoesNotContain with an element that's not in the list while enumerating it, should fail.")]
        public void CollectionDoesNotContainTest7()
        {
            // Defines a set with a special equality comparer.
            HashSet<int> set = new HashSet<int>(new[] { 1, 3 }, new OddEqualityComparer());

            // Because of the use of OddEqualityComparer, the collection only contains the value 1.
            Assert.IsTrue(set.Count == 1);
            // Because of the use of OddEqualityComparer, the set contains both 1 and 3.
            Assert.IsTrue(set.Contains(1), "OddEqualityComparer is implemented incorrectly.");
            Assert.IsTrue(set.Contains(3), "OddEqualityComparer is implemented incorrectly.");

            // DoesNotContain should succeed, because 3 should not be in the list while iterating over it.
            // Call the non-generic DoesNotContain<T>(Validator<T>, object) overload.
            Condition.Requires(set).DoesNotContain((object)3);
        }

        [TestMethod]
        [Description("Calling DoesNotContain on an Collection that contains the tested value should succeed when exceptions are suppressed.")]
        public void CollectionDoesNotContainTest8()
        {
            Collection<int> c = new Collection<int> { 1 };
            Condition.Requires(c).SuppressExceptionsForTest().DoesNotContain(1);
        }
    }
}