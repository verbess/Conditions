using System;
using System.Linq;
using System.Reflection;

namespace Verbess.Utils.Conditions
{
    internal static class AlternativeExceptionExtensions<TException> where TException : Exception
    {
        private static readonly AlternativeExceptionCondition condition;
        private static readonly ConstructorInfo constructor;

        internal static AlternativeExceptionCondition Condition
        {
            get => condition;
        }

        internal static ConstructorInfo Constructor
        {
            get => constructor;
        }

        static AlternativeExceptionExtensions()
        {
            condition = BuildCondition();
            constructor = FindConstructor();
        }

        private static AlternativeExceptionCondition BuildCondition()
        {
            return FindConstructor() != null ? new AlternativeExceptionConditionInternal() : null;
        }

        private static ConstructorInfo FindConstructor()
        {
            TypeInfo typeInfo = typeof(TException).GetTypeInfo();

            if (typeInfo.IsAbstract)
            {
                return null;
            }
            else
            {
                return typeInfo.DeclaredConstructors.Where<ConstructorInfo>(IsUsableConstructor).FirstOrDefault<ConstructorInfo>();
            }
        }

        private static bool IsUsableConstructor(ConstructorInfo constructor)
        {
            return (constructor.Attributes.HasFlag(MethodAttributes.Public)) &&
                   (constructor.GetParameters().Length == 1) &&
                   (constructor.GetParameters().First<ParameterInfo>().ParameterType == typeof(string));
        }

        private sealed class AlternativeExceptionConditionInternal : AlternativeExceptionCondition
        {
            internal AlternativeExceptionConditionInternal() : base() { }

            public override Validator<T> Requires<T>(T value)
            {
                return new RequiresWithCustomExceptionValidator<T, TException>(nameof(value), value);
            }

            public override Validator<T> Requires<T>(T value, string paramName)
            {
                return new RequiresWithCustomExceptionValidator<T, TException>(paramName, value);
            }
        }
    }
}