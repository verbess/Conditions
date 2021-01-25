using System;

namespace Verbess.Utils.Conditions
{
    /// <summary>
    /// The RequiresValidator can be used for precondition checks.
    /// </summary>
    /// <typeparam name="T">The type of the parameter to be validated.</typeparam>
    internal class RequiresValidator<T> : Validator<T>
    {
        public RequiresValidator(string paramName, T value) : base(paramName, value) { }

        protected override void ThrowCore(string condition, string additionalMessage, ConstraintViolationType type)
        {
            string message;
            if (!String.IsNullOrEmpty(additionalMessage))
            {
                message = String.Concat(condition, " ", additionalMessage);
            }
            else
            {
                message = condition;
            }

            Exception exception = BuildExceptionBasedOnViolationType(type, message);

            throw exception;
        }

        public virtual Exception BuildExceptionBasedOnViolationType(ConstraintViolationType type, string message)
        {
            switch (type)
            {
                case ConstraintViolationType.OutOfRange:
                    return new ArgumentOutOfRangeException(ParamName, message);

                case ConstraintViolationType.Invalid:
                    ArgumentException argumentException = new ArgumentException(message, ParamName);
                    return new ArgumentException(argumentException.Message);

                default:
                    if (Value != null)
                    {
                        return new ArgumentException(message, ParamName);
                    }
                    else
                    {
                        return new ArgumentNullException(ParamName, message);
                    }
            }
        }
    }
}