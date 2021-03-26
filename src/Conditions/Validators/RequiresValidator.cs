using System;

namespace Conditions.Validators
{
    /// <summary>
    /// Used for condition checks.
    /// </summary>
    /// <typeparam name="T">The type of the parameter to be validated.</typeparam>
    internal class RequiresValidator<T> : Validator<T>
    {
        public RequiresValidator(string paramName, T value) : base(paramName, value) { }

        protected override void ThrowExceptionInternal(string condition, string addition, ConstraintViolation type)
        {
            string message = BuildExceptionContext(condition, addition);

            ThrowExceptionBasedOnConstraintViolation(type, message);
        }

        protected virtual void ThrowExceptionBasedOnConstraintViolation(ConstraintViolation type, string message)
        {
            switch (type)
            {
                case ConstraintViolation.OutOfRangeConstraint:
                    throw new ArgumentOutOfRangeException(ParamName, message);

                case ConstraintViolation.InvalidConstraint:
                    throw new ArgumentException(message, ParamName);

                case ConstraintViolation.DefaultConstraint:
                default:
                    if (Value != null)
                    {
                        throw new ArgumentException(message, ParamName);
                    }
                    else
                    {
                        throw new ArgumentNullException(ParamName, message);
                    }
            }
        }

        private static string BuildExceptionContext(string condition, string addition)
        {
            if (!String.IsNullOrEmpty(addition))
            {
                return String.Concat(condition, " ", addition);
            }
            else
            {
                return condition;
            }
        }
    }
}