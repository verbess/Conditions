using System;
using System.Collections;
using System.Collections.ObjectModel;
using Conditions.Extensions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Conditions.Tests.CollectionTests
{
    /// <summary>
    /// Tests the ValidatorExtensions.IsNotEmpty method.
    /// </summary>
    [TestClass]
    public class CollectionIsNotEmptyTests
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        [Description("Calling IsNotEmpty on null reference should fail.")]
        public void IsNotEmptyTest1()
        {
            ICollection c = null;
            Condition.Requires(c).IsNotEmpty();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [Description("Calling IsNotEmpty on an empty ICollection should fail.")]
        public void IsNotEmptyTest2()
        {
            Collection<int> c = new Collection<int>();
            Condition.Requires(c).IsNotEmpty();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        [Description("Calling IsNotEmpty on null reference should fail.")]
        public void IsNotEmptyTest3()
        {
            IEnumerable c = null;
            Condition.Requires(c).IsNotEmpty();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [Description("Calling IsNotEmpty on an not empty IEnumerable should fail.")]
        public void IsNotEmptyTest4()
        {
            EmptyTestEnumerable c = new EmptyTestEnumerable();
            Condition.Requires(c).IsNotEmpty();
        }

        [TestMethod]
        [Description("Calling IsNotEmpty on an not empty ICollection should pass.")]
        public void IsNotEmptyTest5()
        {
            Collection<int> c = new Collection<int> { 1 };
            Condition.Requires(c).IsNotEmpty();
        }

        [TestMethod]
        [Description("Calling IsNotEmpty on an not empty IEnumerable should pass.")]
        public void IsNotEmptyTest6()
        {
            NonEmptyTestEnumerable c = new NonEmptyTestEnumerable();
            Condition.Requires(c).IsNotEmpty();
        }

        [TestMethod]
        [Description("Calling IsNotEmpty on null reference should succeed when exceptions are suppressed.")]
        public void IsNotEmptyTest7()
        {
            ICollection c = null;
            Condition.Requires(c).SuppressExceptionsForTest().IsNotEmpty();
        }
    }
}