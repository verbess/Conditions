using System;
using System.Collections;
using System.Collections.ObjectModel;
using Conditions.Extensions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Conditions.Tests.CollectionTests
{
    /// <summary>
    /// Tests the ValidatorExtensions.IsEmpty method.
    /// </summary>
    [TestClass]
    public class CollectionIsEmptyTests
    {
        [TestMethod]
        [Description("Calling IsEmpty on a null reference to ICollection should pass.")]
        public void IsEmptyTest1()
        {
            ICollection c = null;
            Condition.Requires(c).IsEmpty();
        }

        [TestMethod]
        [Description("Calling IsEmpty on an empty collection should pass.")]
        public void IsEmptyTest2()
        {
            Collection<int> c = new Collection<int>();
            Condition.Requires(c).IsEmpty();
        }

        [TestMethod]
        [Description("Calling IsEmpty on a null reference to IEnumerable should pass.")]
        public void IsEmptyTest3()
        {
            IEnumerable c = null;
            Condition.Requires(c).IsEmpty();
        }

        [TestMethod]
        [Description("Calling IsEmpty on an empty IEnumerable should pass.")]
        public void IsEmptyTest4()
        {
            EmptyTestEnumerable c = new EmptyTestEnumerable();
            Condition.Requires(c).IsEmpty();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [Description("Calling IsEmpty on an non empty ICollection should fail.")]
        public void IsEmptyTest5()
        {
            Collection<int> c = new Collection<int> { 1 };
            Condition.Requires(c).IsEmpty();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [Description("Calling IsEmpty on an non empty IEnumerable should fail.")]
        public void IsEmptyTest6()
        {
            NonEmptyTestEnumerable c = new NonEmptyTestEnumerable();
            Condition.Requires(c).IsEmpty();
        }

        [TestMethod]
        [Description("Calling IsEmpty on an non empty IEnumerable should succeed when exceptions are suppressed.")]
        public void IsEmptyTest7()
        {
            NonEmptyTestEnumerable c = new NonEmptyTestEnumerable();
            Condition.Requires(c).SuppressExceptionsForTest().IsEmpty();
        }
    }
}