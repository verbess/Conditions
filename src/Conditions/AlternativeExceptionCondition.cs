namespace Verbess.Utils.Conditions
{
    /// <summary>
    /// An instance of this type is returned from the 
    /// <see cref="Condition.WithExceptionOnFailure{TException}"/> method overloads and allow you to specify
    /// the exception type that should be thrown on failure.
    /// </summary>
    public abstract class AlternativeExceptionCondition
    {
        protected AlternativeExceptionCondition() { }

        public abstract Validator<T> Requires<T>(T value);

        public abstract Validator<T> Requires<T>(T value, string paramName);

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
            return base.ToString();
        }
    }
}