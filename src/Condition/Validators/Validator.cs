using System;

namespace Verbess.Utils.Conditions
{
    /// <summary>
    /// Enables validation of pre- and postconditions.
    /// </summary>
    /// <typeparam name="T">The type of the parameter to be validated.</typeparam>
    public abstract class Validator<T>
    {
        private readonly string paramName;
        private readonly T value;

        public string ParamName
        {
            get => paramName;
        }

        public T Value
        {
            get => value;
        }

        protected Validator(string paramName, T value)
        {
            this.paramName = paramName;
            this.value = value;
        }

        /// <summary>
        /// Throws an exception.
        /// </summary>
        /// <param name="condition">Describes the condition that doesn't hold.</param>
        /// <param name="additionalMessage">An additional message that will be appended to the exception
        /// message.</param>
        /// <param name="type">Gives extra information on the exception type that must be build.</param>
        /// <remarks>
        /// Implement this method when deriving from <see cref="Validator{T}"/>.
        /// The implementation should at least build the exception message from the 
        /// <paramref name="condition"/> and optional <paramref name="additionalMessage"/>. Usage of the
        /// <paramref name="type"/> is completely optional, but the implementation should at least be flexible
        /// and be able to handle unknown <see cref="ConstraintViolationType"/> values.
        /// </remarks>
        protected abstract void ThrowCore(string condition, string additionalMessage, ConstraintViolationType type);

        public virtual void Throw(string condition, string additionalMessage, ConstraintViolationType type)
        {
            ThrowCore(condition, additionalMessage, type);
        }

        public virtual void Throw(string condition)
        {
            ThrowCore(condition, null, ConstraintViolationType.Default);
        }

        internal virtual void Throw(string condition, string additionalMessage)
        {
            ThrowCore(condition, additionalMessage, ConstraintViolationType.Default);
        }

        internal virtual void Throw(string condition, ConstraintViolationType type)
        {
            ThrowCore(condition, null, type);
        }

        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override string ToString()
        {
            return String.Format("\"{0}\":{1}", paramName, value);
        }
    }
}