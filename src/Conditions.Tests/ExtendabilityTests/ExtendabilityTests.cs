using System;
using Conditions.Extensions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Conditions.Tests
{
    [TestClass]
    public sealed class ExtendabilityTests
    {
        [TestMethod]
        [Description("Tests whether the framework can be extended.")]
        public void ExtendabilityTest1()
        {
            int value = 1;

            Condition.Requires(value).MyExtension(new[] { 1 });
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [Description("Tests whether the framework can be extended. This method should fail.")]
        public void ExtendabilityTest2()
        {
            int value = 1;

            Condition.Requires(value).MyExtension(new[] { 2 });
        }

        [TestMethod]
        [Description("Tests whether the API works without the use of extension methods.")]
        public void ExtendabilityTest3()
        {
            int value = 1;
            ValidatorExtensions.IsGreaterOrEqualTo(Condition.Requires(value, "value"), 0);
        }
    }
}