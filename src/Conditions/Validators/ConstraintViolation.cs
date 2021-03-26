namespace Conditions.Validators
{
    /// <summary>
    /// This enumeration is used to determine the type of exception the <see cref="Validator" /> should throw.
    /// </summary>
    public enum ConstraintViolation : byte
    {
        /// <summary>
        /// Throw the default exception for that instance.
        /// </summary>
        DefaultConstraint = 0,

        /// <summary>
        /// Throw the <see cref="System.ArgumentOutOfRangeException"/> for values that are out of range.
        /// </summary>
        OutOfRangeConstraint = 1,

        /// <summary>
        /// Throw the <see cref="System.ArgumentException"/>.
        /// </summary>
        InvalidConstraint = 2,
    }
}