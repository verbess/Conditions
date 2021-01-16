using System;

namespace Verbess.Utils.Conditions
{
    /// <summary>
    /// Entry point methods to start validating pre- and postconditions.
    /// </summary>
    public static class Condition
    {
        public static Validator<T> Requires<T>(this T value)
        {
            return new RequiresValidator<T>(nameof(value), value);
        }

        public static Validator<T> Requires<T>(this T value, string paramName)
        {
            return new RequiresValidator<T>(paramName, value);
        }

        public static Validator<T> Ensures<T>(this T value)
        {
            return new EnsuresValidator<T>(nameof(value), value);
        }

        public static Validator<T> Ensures<T>(this T value, string paramName)
        {
            return new EnsuresValidator<T>(paramName, value);
        }

        public static AlternativeExceptionCondition WithExceptionOnFailure<TException>() where TException : Exception
        {
            AlternativeExceptionCondition condition = AlternativeExceptionExtensions<TException>.Condition;

            if (condition == null)
            {
                throw new ArgumentException(StringResources.GetString(StringResources.ExceptionTypeIsInvalid, typeof(TException)), nameof(TException));
            }

            return condition;
        }
    }
}