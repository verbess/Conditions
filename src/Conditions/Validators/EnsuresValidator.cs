using System;

namespace Verbess.Utils.Conditions
{
    /// <summary>
    /// The EnsuresValidator can be used for postcondition checks.
    /// </summary>
    /// <typeparam name="T">The type of the parameter to be validated.</typeparam>
    internal sealed class EnsuresValidator<T> : Validator<T>
    {
        internal EnsuresValidator(string paramName, T value) : base(paramName, value) { }

        protected override void ThrowCore(string condition, string additionalMessage, ConstraintViolationType type)
        {
            string message = StringResources.GetString(StringResources.PostconditionXFailed, condition);

            if (!String.IsNullOrEmpty(additionalMessage))
            {
                message = String.Concat(message, " ", additionalMessage);
            }

            throw new PostconditionException(message);
        }
    }
}