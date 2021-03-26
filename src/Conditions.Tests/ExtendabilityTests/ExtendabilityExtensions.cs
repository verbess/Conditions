using System.Collections.Generic;
using System.Linq;
using Conditions.Validators;

namespace Conditions.Tests
{
    internal static class ExtendabilityExtensions
    {
        /// <summary>Returns a stub Validator that will never throw an exception.</summary>
        /// <typeparam name="T">The supplied type.</typeparam>
        /// <param name="validator">The validator.</param>
        /// <returns>A new <see cref="Validator{T}"/></returns>
        public static Validator<T> SuppressExceptionsForTest<T>(this Validator<T> validator)
        {
            return new StubValidator<T>(validator);
        }

        public static Validator<T> MyExtension<T>(
            this Validator<T> validator, IEnumerable<T> collection)
        {
            if (collection == null || !collection.Contains(validator.Value))
            {
                validator.ThrowException(validator.ParamName + " should be in the supplied collection");
            }

            return validator;
        }

        // This stub validator allows testing code branches that could not be reached with the normal
        // RequiresValidator and EnsuresValidator.
        private sealed class StubValidator<T> : Validator<T>
        {
            public StubValidator(Validator<T> baseValidator)
                : base(baseValidator.ParamName, baseValidator.Value)
            {
            }

            protected override void ThrowExceptionInternal(string condition, string additionalMessage,
                ConstraintViolation type)
            {
                // Don't throw.
            }
        }
    }
}