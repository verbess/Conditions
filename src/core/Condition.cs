using System;

namespace Verbess.Utils.Conditions
{
    /// <summary>
    /// Entry point methods to start validating pre- and postconditions.
    /// </summary>
    public static class Condition
    {
        /// <summary>
        /// Returns a new <see cref="Validator{T}">Validator</see> that allows you to
        /// validate the preconditions of the given parameter, given it a default ParameterName of 'value'.
        /// </summary>
        /// <typeparam name="T">The type of the parameter to validate.</typeparam>
        /// <param name="value">The value of the parameter to validate.</param>
        /// <returns>A new <see cref="Validator{T}">Validator</see> containing the 
        /// <paramref name="value"/> and "value" as parameter name.</returns>
        public static Validator<T> Requires<T>(this T value)
        {
            return new RequiresValidator<T>(nameof(value), value);
        }

        /// <summary>
        /// Returns a new <see cref="Validator{T}">Validator</see> that allows you to
        /// validate the preconditions of the given parameter.
        /// </summary>
        /// <typeparam name="T">The type of the parameter to validate.</typeparam>
        /// <param name="value">The value of the parameter to validate.</param>
        /// <param name="paramName">The name of the parameter to validate</param>
        /// <returns>A new <see cref="Validator{T}">Validator</see> containing the 
        /// <paramref name="value"/> and <paramref name="paramName"/>.</returns>
        public static Validator<T> Requires<T>(this T value, string paramName)
        {
            return new RequiresValidator<T>(paramName, value);
        }

        /// <summary>
        /// Returns a new <see cref="Validator{T}">Validator</see> that allows you to 
        /// validate the given parameter, given it a default ParameterName of 'value'.
        /// </summary>
        /// <typeparam name="T">The type of the parameter to validate.</typeparam>
        /// <param name="value">The value of the parameter to validate.</param>
        /// <returns>A new <see cref="Validator{T}">Validator</see> containing the 
        /// <paramref name="value"/> and "value" as parameter name.</returns>
        public static Validator<T> Ensures<T>(this T value)
        {
            return new EnsuresValidator<T>(nameof(value), value);
        }

        /// <summary>
        /// Returns a new <see cref="Validator{T}">Validator</see> that allows you to 
        /// validate the postconditions of the given object.
        /// </summary>
        /// <typeparam name="T">The type of the object to validate.</typeparam>
        /// <param name="value">The object to validate.</param>
        /// <param name="paramName">The name of the parameter to validate</param>
        /// <returns>A new <see cref="Validator{T}">Validator</see> containing the 
        /// <paramref name="value"/> and <paramref name="paramName"/>.</returns>
        public static Validator<T> Ensures<T>(this T value, string paramName)
        {
            return new EnsuresValidator<T>(paramName, value);
        }

        /// <summary>
        /// Returns a new <see cref="AlternativeExceptionCondition" /> that allows you to specify the exception
        /// type that has to be thrown in case a a validation fails.
        /// </summary>
        /// <typeparam name="TException">The type of the exception to throw.</typeparam>
        /// <returns>A new <see cref="AlternativeExceptionCondition" />.</returns>
        public static AlternativeExceptionCondition WithExceptionOnFailure<TException>() where TException : Exception
        {
            AlternativeExceptionCondition condition = AlternativeExceptionExtensions<TException>.Condition;

            if (condition == null)
            {
                throw new ArgumentException(StringResources.GetString(StringResources.ExceptionTypeIsInvalid, typeof(TException)), nameof(TException));
            }
            else
            {
                return condition;
            }
        }
    }
}