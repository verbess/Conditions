using System;
using System.Reflection;
using Conditions.Utils;
using Conditions.Validators;

namespace Conditions.Resources
{
    /// <summary>
    /// The formatter of string resources, use this to get formatted string.
    /// </summary>
    internal static class ContextFormatter
    {
        public static string BuildFormattedContext(string key)
        {
            return BuildFormattedContextInternal(key, null);
        }

        public static string BuildFormattedContext(string key, params object[] args)
        {
            return BuildFormattedContextInternal(key, args);
        }

        private static string BuildFormattedContextInternal(string key, params object[] args)
        {
            string format = key;

            if (args == null)
            {
                return format;
            }
            else
            {
                return String.Format(format, args);
            }
        }

        public static string BuildActualValueContext<T>(Validator<T> validator)
        {
            bool canNotConvert = (validator.Value != null) && (validator.Value.GetType().FullName == validator.Value.ToString());

            if (canNotConvert)
            {
                return null;
            }
            else
            {
                return BuildFormattedContextInternal(StringResources.TheActualValueIs, validator.ParamName, validator.Value.ConvertToString());
            }
        }

        public static string BuildActualStringLengthContext(Validator<string> validator)
        {
            int length = validator.Value != null ? validator.Value.Length : 0;

            return BuildFormattedContextInternal(StringResources.TheActualStringHasLength, validator.ParamName, length);
        }

        public static ConstraintViolation BuildConstraintViolationContext<T>(ConstraintViolation defaultType)
        {
            if (typeof(T).GetTypeInfo().IsEnum)
            {
                return ConstraintViolation.InvalidConstraint;
            }
            else
            {
                return defaultType;
            }
        }

        public static ConstraintViolation BuildConstraintViolationContext<T>()
        {
            return BuildConstraintViolationContext<T>(ConstraintViolation.DefaultConstraint);
        }
    }
}