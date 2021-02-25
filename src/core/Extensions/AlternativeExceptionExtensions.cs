using System;
using System.Linq;
using System.Reflection;

namespace Verbess.Utils.Conditions
{
    internal static class AlternativeExceptionExtensions<TException> where TException : Exception
    {
        private static readonly AlternativeExceptionCondition condition;
        private static readonly ConstructorInfo constructor;

        public static AlternativeExceptionCondition Condition
        {
            get
            {
                return condition;
            }
        }

        public static ConstructorInfo Constructor
        {
            get
            {
                return constructor;
            }
        }

        static AlternativeExceptionExtensions()
        {
            constructor = FindConstructor();
            condition = BuildCondition();
        }

        private static AlternativeExceptionCondition BuildCondition()
        {
            return constructor != null ? new AlternativeExceptionConditionInternal() : null;
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
            public AlternativeExceptionConditionInternal() : base() { }

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