namespace Verbess.Utils.Conditions
{
    /// <summary>
    /// This enumeration is used to determine the type of exception the validator should throw.
    /// </summary>
    public enum ConstraintViolationType : byte
    {
        /// <summary>
        /// Lets the <see cref="Validator"> to throw the default exception for that instance.
        /// </summary>
        Default = 0,

        /// <summary>
        /// Lets the <see cref="Validator"> optionally throw the <see cref="System.ArgumentOutOfRangeException"/> appropriate for values that are out of range.
        /// </summary>
        OutOfRange = 1,

        /// <summary>
        /// Lets the <see cref="Validator"> optionally throw the <see cref="System.ArgumentException"/>.
        /// </summary>
        Invalid = 2,
    }
}