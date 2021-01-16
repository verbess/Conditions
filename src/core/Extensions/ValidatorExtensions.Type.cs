using System;
using System.Reflection;

namespace Verbess.Utils.Conditions
{
    // Type checks
    public static partial class ValidatorExtensions
    {
        /// <summary>
        /// Checks whether the <see cref="Type"/> of the given value is of <paramref name="type"/>.
        /// An exception is thrown otherwise.
        /// When the given value is a null reference, the check will always pass, regardless of the specified
        /// <paramref name="type"/>. Please use the <b>IsNotNull</b> method to check for null references).
        /// </summary>
        /// <typeparam name="T">The type of the <see cref="Validator{T}.Value">Value</see> of the specified <paramref name="validator"/>.</typeparam>
        /// <param name="validator">The <see cref="Validator{T}"/> that holds the value that has to be checked.</param>
        /// <param name="type">The <see cref="Type"/> that will be used to perform the check.</param>
        /// <returns>The specified <paramref name="validator"/> instance.</returns>
        /// <exception cref="ArgumentException">Thrown when the <see cref="Validator{T}.Value">Value</see> of the specified <paramref name="validator"/> is not of the specified <paramref name="type"/>, while the specified <paramref name="validator"/> is created using the <see cref="Condition.Requires{T}(T,string)">Requires</see> extension method.</exception>
        /// <exception cref="PostconditionException">Thrown when the <see cref="Validator{T}.Value">Value</see> of the specified <paramref name="validator"/> is not of the specified <paramref name="type"/>, while the specified <paramref name="validator"/> is created using the <see cref="Condition.Ensures{T}(T,string)">Ensures</see> extension method.</exception>
        public static Validator<T> IsOfType<T>(this Validator<T> validator, Type type) where T : class
        {
            return IsOfType<T>(validator, type, null);
        }

        /// <summary>
        /// Checks whether the <see cref="Type"/> of the given value is of <paramref name="type"/>.
        /// An exception is thrown otherwise.
        /// When the given value is a null reference, the check will always pass, regardless of the specified
        /// <paramref name="type"/>. Please use the <b>IsNotNull</b> method to check for null references).
        /// </summary>
        /// <typeparam name="T">The type of the <see cref="Validator{T}.Value">Value</see> of the specified <paramref name="validator"/>.</typeparam>
        /// <param name="validator">The <see cref="Validator{T}"/> that holds the value that has to be checked.</param>
        /// <param name="type">The <see cref="Type"/> that will be used to perform the check.</param>
        /// <param name="conditionDescription">
        /// The description of the condition that should hold. The string may hold the placeholder '{0}' for 
        /// the <see cref="Validator{T}.ArgumentName">ArgumentName</see>.
        /// </param>
        /// <returns>The specified <paramref name="validator"/> instance.</returns>
        /// <exception cref="ArgumentException">Thrown when the <see cref="Validator{T}.Value">Value</see> of the specified <paramref name="validator"/> is not of the specified <paramref name="type"/>, while the specified <paramref name="validator"/> is created using the <see cref="Condition.Requires{T}(T,string)">Requires</see> extension method.</exception>
        /// <exception cref="PostconditionException">Thrown when the <see cref="Validator{T}.Value">Value</see> of the specified <paramref name="validator"/> is not of the specified <paramref name="type"/>, while the specified <paramref name="validator"/> is created using the <see cref="Condition.Ensures{T}(T,string)">Ensures</see> extension method.</exception>
        public static Validator<T> IsOfType<T>(this Validator<T> validator, Type type, string conditionDescription) where T : class
        {
            // The call to this method is pretty expensive, so it optimizing it for inlining will have no
            // significant effect.
            T value = validator.Value;

            bool valueIsValid = (value != null) &&
                                (type.GetTypeInfo().IsAssignableFrom(value.GetType().GetTypeInfo()));

            if (!valueIsValid)
            {
                Throw.ValueShouldBeOfType<T>(validator, type, conditionDescription);
            }

            return validator;
        }

        /// <summary>
        /// Checks whether the <see cref="Type"/> of the given value is not of <paramref name="type"/>.
        /// An exception is thrown otherwise.
        /// When the given value is a null reference, the check will always pass, regardless of the specified
        /// <paramref name="type"/>. Please use the <b>IsNotNull</b> method to check for null references).
        /// </summary>
        /// <typeparam name="T">The type of the <see cref="Validator{T}.Value">Value</see> of the specified <paramref name="validator"/>.</typeparam>
        /// <param name="validator">The <see cref="Validator{T}"/> that holds the value that has to be checked.</param>
        /// <param name="type">The <see cref="Type"/> that will be used to perform the check.</param>
        /// <returns>The specified <paramref name="validator"/> instance.</returns>
        /// <exception cref="ArgumentException">Thrown when the <see cref="Validator{T}.Value">Value</see> of the specified <paramref name="validator"/> is of the specified <paramref name="type"/>, while the specified <paramref name="validator"/> is created using the <see cref="Condition.Requires{T}(T,string)">Requires</see> extension method.</exception>
        /// <exception cref="PostconditionException">Thrown when the <see cref="Validator{T}.Value">Value</see> of the specified <paramref name="validator"/> is of the specified <paramref name="type"/>, while the specified <paramref name="validator"/> is created using the <see cref="Condition.Ensures{T}(T,string)">Ensures</see> extension method.</exception>
        public static Validator<T> IsNotOfType<T>(this Validator<T> validator, Type type) where T : class
        {
            return IsNotOfType<T>(validator, type, null);
        }

        /// <summary>
        /// Checks whether the <see cref="Type"/> of the given value is not of <paramref name="type"/>.
        /// An exception is thrown otherwise.
        /// When the given value is a null reference, the check will always pass, regardless of the specified
        /// <paramref name="type"/>. Please use the <b>IsNotNull</b> method to check for null references).
        /// </summary>
        /// <typeparam name="T">The type of the <see cref="Validator{T}.Value">Value</see> of the specified <paramref name="validator"/>.</typeparam>
        /// <param name="validator">The <see cref="Validator{T}"/> that holds the value that has to be checked.</param>
        /// <param name="type">The <see cref="Type"/> that will be used to perform the check.</param>
        /// <param name="conditionDescription">
        /// The description of the condition that should hold. The string may hold the placeholder '{0}' for 
        /// the <see cref="Validator{T}.ArgumentName">ArgumentName</see>.
        /// </param>
        /// <returns>The specified <paramref name="validator"/> instance.</returns>
        /// <exception cref="ArgumentException">Thrown when the <see cref="Validator{T}.Value">Value</see> of the specified <paramref name="validator"/> is of the specified <paramref name="type"/>, while the specified <paramref name="validator"/> is created using the <see cref="Condition.Requires{T}(T,string)">Requires</see> extension method.</exception>
        /// <exception cref="PostconditionException">Thrown when the <see cref="Validator{T}.Value">Value</see> of the specified <paramref name="validator"/> is of the specified <paramref name="type"/>, while the specified <paramref name="validator"/> is created using the <see cref="Condition.Ensures{T}(T,string)">Ensures</see> extension method.</exception>      
        public static Validator<T> IsNotOfType<T>(this Validator<T> validator, Type type, string conditionDescription) where T : class
        {
            // The call to this method is pretty expensive, so it optimizing it for inlining will have no 
            // significant effect.
            T value = validator.Value;

            if (value != null)
            {
                bool valueIsInvalid = type.GetTypeInfo().IsAssignableFrom(value.GetType().GetTypeInfo());

                if (valueIsInvalid)
                {
                    Throw.ValueShouldNotBeOfType<T>(validator, type, conditionDescription);
                }
            }

            return validator;
        }
    }
}