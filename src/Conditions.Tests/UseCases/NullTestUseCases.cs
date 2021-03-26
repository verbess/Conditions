using System;
using Conditions.Extensions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Conditions.Tests.UseCases
{
    [TestClass]
    public class NullTestUseCases
    {
        #region CheckIsNull

        [TestMethod]
        [Description("Use Case code should match with use of IsNull.")]
        public void CheckIsNull1()
        {
            object param = new object();

            UseCaseTestHelper.Test(() =>
            {
                // Use Case: this is what the user would write without conditions.
                if (param != null)
                {
                    throw new ArgumentException("param should not be null.", "param");
                }
            },
                () =>
                {
                    // This is what the user should write with conditions.
                    Condition.Requires(param, "param").IsNull();
                });
        }

        [TestMethod]
        [Description("Use Case code should match with use of IsNull.")]
        public void CheckIsNull2()
        {
            object param = null;

            UseCaseTestHelper.Test(() =>
            {
                // Use Case: this is what the user would write without conditions.
                if (param != null)
                {
                    throw new ArgumentException("param should not be null.", "param");
                }
            },
                () =>
                {
                    // This is what the user should write with conditions.
                    Condition.Requires(param, "param").IsNull();
                });
        }

        #endregion // CheckIsNull

        #region CheckIsNotNull

        [TestMethod]
        [Description("Use Case code should match with use of IsNotNull.")]
        public void CheckIsNotNull1()
        {
            object param = new object();

            UseCaseTestHelper.Test(() =>
            {
                // Use Case: this is what the user would write without conditions.
                if (param == null)
                {
                    throw new ArgumentNullException("param");
                }
            },
                () =>
                {
                    // This is what the user should write with conditions.
                    Condition.Requires(param, "param").IsNotNull();
                });
        }

        [TestMethod]
        [Description("Use Case code should match with use of IsNotNull.")]
        public void CheckIsNotNull2()
        {
            object param = null;

            UseCaseTestHelper.Test(() =>
            {
                // Use Case: this is what the user would write without conditions.
                if (param == null)
                {
                    throw new ArgumentNullException("param");
                }
            },
                () =>
                {
                    // This is what the user should write with conditions.
                    Condition.Requires(param, "param").IsNotNull();
                });
        }

        #endregion // CheckIsNotNull
    }
}