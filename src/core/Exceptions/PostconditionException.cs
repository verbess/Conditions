using System;

namespace Verbess.Utils.Conditions
{
    /// <summary>
    /// The exception that is thrown when a method's postcondition is not valid.
    /// </summary>
    public sealed class PostconditionException : Exception
    {
        public PostconditionException() : this(StringResources.GetString(StringResources.PostconditionFailed)) { }

        public PostconditionException(string message) : base(message) { }

        public PostconditionException(string message, Exception inner) : base(message, inner) { }
    }
}