using System;
using Conditions.Extensions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Conditions.Tests.UseCases
{
    [TestClass]
    public class TypeTestUseCases
    {
        #region CheckIsType

        [TestMethod]
        [Description("Use Case code should match with use of IsType.")]
        public void CheckIsType1()
        {
            object param = new object();

            UseCaseTestHelper.Test(() =>
            {
                // Use Case: this is what the user would write without conditions.
                if (!(param is string))
                {
                    throw new ArgumentException("param is not of type string.", "param");
                }
            },
                () =>
                {
                    // This is what the user should write with conditions.
                    Condition.Requires(param, "param").IsType(typeof(string));
                });
        }

        [TestMethod]
        [Description("Use Case code should match with use of IsType.")]
        public void CheckIsType2()
        {
            object param = null;

            UseCaseTestHelper.Test(() =>
            {
                // Use Case: this is what the use would write without conditions.
                if (!(param is string))
                {
                    if (param == null)
                    {
                        throw new ArgumentNullException("param", "param should not be of type string.");
                    }
                    else
                    {
                        throw new ArgumentException("param should not be of type string.", "param");
                    }
                }
            },
                () =>
                {
                    // This is what the user should write with conditions.
                    Condition.Requires(param, "param").IsType(typeof(string));
                });
        }

        #endregion // CheckIsType

        #region CheckIsNotType

        [TestMethod]
        [Description("Use Case code should match with use of IsNotType.")]
        public void CheckIsNotType1()
        {
            object param = string.Empty;

            UseCaseTestHelper.Test(() =>
            {
                // Use Case: this is what the use would write without conditions.
                if (param is string)
                {
                    throw new ArgumentException("param should not be of type string.", "param");
                }
            },
                () =>
                {
                    // This is what the user should write with conditions.
                    Condition.Requires(param, "param").IsNotType(typeof(string));
                });
        }

        [TestMethod]
        [Description("Use Case code should match with use of IsNotType.")]
        public void CheckIsNotType2()
        {
            object param = null;

            UseCaseTestHelper.Test(() =>
            {
                // Use Case: this is what the use would write without conditions.
                if (param is string)
                {
                    throw new ArgumentException("param should not be of type string.", "param");
                }
            },
                () =>
                {
                    // This is what the user should write with conditions.
                    Condition.Requires(param, "param").IsNotType(typeof(string));
                });
        }

        #endregion // CheckIsNotType
    }
}