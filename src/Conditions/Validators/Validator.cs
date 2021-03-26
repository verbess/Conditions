using System;

namespace Conditions.Validators
{
    /// <summary>
    /// Enables validation of conditions.
    /// </summary>
    /// <typeparam name="T">The type of the parameter to be validated.</typeparam>
    public abstract class Validator<T>
    {
        private readonly string paramName;
        private readonly T value;

        public string ParamName
        {
            get
            {
                return paramName;
            }
        }

        public T Value
        {
            get
            {
                return value;
            }
        }

        protected Validator(string paramName, T value)
        {
            this.paramName = paramName;
            this.value = value;
        }

        /// <summary>
        /// Throws an exception.
        /// </summary>
        /// <param name="condition">Describes the condition.</param>
        /// <param name="addition">An additional message that will be appended to the exception.</param>
        /// <param name="type">Extra information on the exception type that must be build.</param>
        protected abstract void ThrowExceptionInternal(string condition, string addition, ConstraintViolation type);

        public virtual void ThrowException(string condition, string addition, ConstraintViolation type)
        {
            ThrowExceptionInternal(condition, addition, type);
        }

        public virtual void ThrowException(string condition)
        {
            ThrowExceptionInternal(condition, null, ConstraintViolation.DefaultConstraint);
        }

        internal virtual void ThrowException(string condition, string addition)
        {
            ThrowExceptionInternal(condition, addition, ConstraintViolation.DefaultConstraint);
        }

        internal virtual void ThrowException(string condition, ConstraintViolation type)
        {
            ThrowExceptionInternal(condition, null, type);
        }

        public override string ToString()
        {
            return String.Format("'{0}': {1}", paramName, value);
        }
    }
}