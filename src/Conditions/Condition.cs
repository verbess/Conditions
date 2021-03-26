using Conditions.Validators;

namespace Conditions
{
    /// <summary>
    /// Entry methods to start validating conditions.
    /// </summary>
    public static class Condition
    {
        /// <summary>
        /// Allows you to validate the conditions of the given parameter.
        /// </summary>
        /// <param name="value">The value of the parameter to validate.</param>
        /// <typeparam name="T">The type of the parameter to validate.</typeparam>
        /// <returns>A <see cref="Validator{T}" /> containing the <paramref name="value" /> and "value" as parameter name.</returns>
        public static Validator<T> Requires<T>(this T value)
        {
            return new RequiresValidator<T>(nameof(value), value);
        }

        /// <summary>
        /// Allows you to validate the conditions of the given parameter.
        /// </summary>
        /// <param name="value">The value of the parameter to validate.</param>
        /// <param name="paramName">The name of the parameter to validate.</param>
        /// <typeparam name="T">The type of the parameter to validate.</typeparam>
        /// <returns>A <see cref="Validator{T}" /> containing the <paramref name="value" /> and parameter name.</returns>
        public static Validator<T> Requires<T>(this T value, string paramName)
        {
            return new RequiresValidator<T>(paramName, value);
        }
    }
}