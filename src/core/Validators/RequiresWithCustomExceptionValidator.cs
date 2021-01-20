using System;
using System.Reflection;

namespace Verbess.Utils.Conditions
{
    /// <summary>
    /// The RequiresValidator can be used for precondition checks. This will throw
    /// a custom exception in case of a failure.
    /// </summary>
    /// <typeparam name="T">The type of the parameter to be validated.</typeparam>
    /// <typeparam name="TException">The exception type to throw in case of a failure.</typeparam>
    internal sealed class RequiresWithCustomExceptionValidator<T, TException> : RequiresValidator<T> where TException : Exception
    {
        internal RequiresWithCustomExceptionValidator(string paramName, T value) : base(paramName, value) { }

        internal override Exception BuildExceptionBasedOnViolationType(ConstraintViolationType type, string message)
        {
            ConstructorInfo constructor = AlternativeExceptionExtensions<TException>.Constructor;

            return (Exception)constructor.Invoke(new object[] { message });
        }
    }
}