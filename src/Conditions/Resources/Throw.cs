using System;
using System.Collections;
using Conditions.Utils;
using Conditions.Validators;

namespace Conditions.Resources
{
    internal static class Throw
    {
        #region Null

        public static void ShouldBeNull<T>(Validator<T> validator)
        {
            string condition = ContextFormatter.BuildFormattedContext(StringResources.ShouldBeNull, validator.ParamName);

            validator.ThrowException(condition);
        }

        public static void ShouldNotBeNull<T>(Validator<T> validator)
        {
            string condition = ContextFormatter.BuildFormattedContext(StringResources.ShouldNotBeNull, validator.ParamName);

            validator.ThrowException(condition);
        }

        #endregion

        #region Type

        public static void ShouldBeTypeOf<T>(Validator<T> validator, Type type)
        {
            string condition = ContextFormatter.BuildFormattedContext(StringResources.ShouldBeTypeOf, validator.ParamName, type.Name);

            validator.ThrowException(condition);
        }

        public static void ShouldNotBeTypeOf<T>(Validator<T> validator, Type type)
        {
            string condition = ContextFormatter.BuildFormattedContext(StringResources.ShouldNotBeTypeOf, validator.ParamName, type.Name);

            validator.ThrowException(condition);
        }

        #endregion

        #region Boolean

        public static void ShouldBeTrue<T>(Validator<T> validator)
        {
            string condition = ContextFormatter.BuildFormattedContext(StringResources.ShouldBeTrue, validator.ParamName);

            validator.ThrowException(condition);
        }

        public static void ShouldBeFalse<T>(Validator<T> validator)
        {
            string condition = ContextFormatter.BuildFormattedContext(StringResources.ShouldBeFalse, validator.ParamName);

            validator.ThrowException(condition);
        }

        #endregion

        #region Value

        public static void ShouldBeNumber<T>(Validator<T> validator)
        {
            string condition = ContextFormatter.BuildFormattedContext(StringResources.ShouldBeNumber, validator.ParamName);

            validator.ThrowException(condition);
        }

        public static void ShouldNotBeNumber<T>(Validator<T> validator)
        {
            string condition = ContextFormatter.BuildFormattedContext(StringResources.ShouldNotBeNumber, validator.ParamName);

            validator.ThrowException(condition);
        }

        public static void ShouldBeInfinity<T>(Validator<T> validator)
        {
            string condition = ContextFormatter.BuildFormattedContext(StringResources.ShouldBeInfinity, validator.ParamName);

            validator.ThrowException(condition);
        }

        public static void ShouldNotBeInfinity<T>(Validator<T> validator)
        {
            string condition = ContextFormatter.BuildFormattedContext(StringResources.ShouldNotBeInfinity, validator.ParamName);

            validator.ThrowException(condition);
        }

        public static void ShouldBePositiveInfinity<T>(Validator<T> validator)
        {
            string condition = ContextFormatter.BuildFormattedContext(StringResources.ShouldBePositiveInfinity, validator.ParamName);

            validator.ThrowException(condition);
        }

        public static void ShouldNotBePositiveInfinity<T>(Validator<T> validator)
        {
            string condition = ContextFormatter.BuildFormattedContext(StringResources.ShouldNotBePositiveInfinity, validator.ParamName);

            validator.ThrowException(condition);
        }

        public static void ShouldBeNegativeInfinity<T>(Validator<T> validator)
        {
            string condition = ContextFormatter.BuildFormattedContext(StringResources.ShouldBeNegativeInfinity, validator.ParamName);

            validator.ThrowException(condition);
        }

        public static void ShouldNotBeNegativeInfinity<T>(Validator<T> validator)
        {
            string condition = ContextFormatter.BuildFormattedContext(StringResources.ShouldNotBeNegativeInfinity, validator.ParamName);

            validator.ThrowException(condition);
        }

        public static void ShouldBeInRange<T>(Validator<T> validator, T min, T max)
        {
            string condition = ContextFormatter.BuildFormattedContext(StringResources.ShouldBeInRange, validator.ParamName, min.ConvertToString(), max.ConvertToString());
            string addition = ContextFormatter.BuildActualValueContext<T>(validator);
            ConstraintViolation type = ContextFormatter.BuildConstraintViolationContext<T>(ConstraintViolation.OutOfRangeConstraint);

            validator.ThrowException(condition, addition, type);
        }

        public static void ShouldNotBeInRange<T>(Validator<T> validator, T min, T max)
        {
            string condition = ContextFormatter.BuildFormattedContext(StringResources.ShouldNotBeInRange, validator.ParamName, min.ConvertToString(), max.ConvertToString());
            string addition = ContextFormatter.BuildActualValueContext<T>(validator);
            ConstraintViolation type = ContextFormatter.BuildConstraintViolationContext<T>();

            validator.ThrowException(condition, addition, type);
        }

        public static void ShouldBeEqualTo<T>(Validator<T> validator, T value)
        {
            string condition = ContextFormatter.BuildFormattedContext(StringResources.ShouldBeEqualTo, validator.ParamName, value.ConvertToString());
            string addition = ContextFormatter.BuildActualValueContext<T>(validator);
            ConstraintViolation type = ContextFormatter.BuildConstraintViolationContext<T>();

            validator.ThrowException(condition, addition, type);
        }

        public static void ShouldNotBeEqualTo<T>(Validator<T> validator, T value)
        {
            string condition = ContextFormatter.BuildFormattedContext(StringResources.ShouldNotBeEqualTo, validator.ParamName, value.ConvertToString());
            ConstraintViolation type = ContextFormatter.BuildConstraintViolationContext<T>();

            validator.ThrowException(condition, type);
        }

        public static void ShouldBeGreaterThan<T>(Validator<T> validator, T value)
        {
            string condition = ContextFormatter.BuildFormattedContext(StringResources.ShouldBeGreaterThan, validator.ParamName, value.ConvertToString());
            string addition = ContextFormatter.BuildActualValueContext<T>(validator);
            ConstraintViolation type = ContextFormatter.BuildConstraintViolationContext<T>(ConstraintViolation.OutOfRangeConstraint);

            validator.ThrowException(condition, addition, type);
        }

        public static void ShouldBeGreaterOrEqualTo<T>(Validator<T> validator, T value)
        {
            string condition = ContextFormatter.BuildFormattedContext(StringResources.ShouldBeGreaterOrEqualTo, validator.ParamName, value.ConvertToString());
            string addition = ContextFormatter.BuildActualValueContext<T>(validator);
            ConstraintViolation type = ContextFormatter.BuildConstraintViolationContext<T>(ConstraintViolation.OutOfRangeConstraint);

            validator.ThrowException(condition, addition, type);
        }

        public static void ShouldBeLessThan<T>(Validator<T> validator, T value)
        {
            string condition = ContextFormatter.BuildFormattedContext(StringResources.ShouldBeLessThan, validator.ParamName, value.ConvertToString());
            string addition = ContextFormatter.BuildActualValueContext<T>(validator);
            ConstraintViolation type = ContextFormatter.BuildConstraintViolationContext<T>(ConstraintViolation.OutOfRangeConstraint);

            validator.ThrowException(condition, addition, type);
        }

        public static void ShouldBeLessOrEqualTo<T>(Validator<T> validator, T value)
        {
            string condition = ContextFormatter.BuildFormattedContext(StringResources.ShouldBeLessOrEqualTo, validator.ParamName, value.ConvertToString());
            string addition = ContextFormatter.BuildActualValueContext<T>(validator);
            ConstraintViolation type = ContextFormatter.BuildConstraintViolationContext<T>(ConstraintViolation.OutOfRangeConstraint);

            validator.ThrowException(condition, addition, type);
        }

        #endregion

        #region String

        public static void StringShouldBeEmpty(Validator<string> validator)
        {
            string condition = ContextFormatter.BuildFormattedContext(StringResources.StringShouldBeEmpty, validator.ParamName);

            validator.ThrowException(condition);
        }

        public static void StringShouldNotBeEmpty(Validator<string> validator)
        {
            string condition = ContextFormatter.BuildFormattedContext(StringResources.StringShouldNotBeEmpty, validator.ParamName);

            validator.ThrowException(condition);
        }

        public static void StringShouldBeNullOrEmpty(Validator<string> validator)
        {
            string condition = ContextFormatter.BuildFormattedContext(StringResources.StringShouldBeNullOrEmpty, validator.ParamName);

            validator.ThrowException(condition);
        }

        public static void StringShouldNotBeNullOrEmpty(Validator<string> validator)
        {
            string condition = ContextFormatter.BuildFormattedContext(StringResources.StringShouldNotBeNullOrEmpty, validator.ParamName);

            validator.ThrowException(condition);
        }

        public static void StringShouldBeNullOrWhiteSpace(Validator<string> validator)
        {
            string condition = ContextFormatter.BuildFormattedContext(StringResources.StringShouldBeNullOrWhiteSpace, validator.ParamName);

            validator.ThrowException(condition);
        }

        public static void StringShouldNotBeNullOrWhiteSpace(Validator<string> validator)
        {
            string condition = ContextFormatter.BuildFormattedContext(StringResources.StringShouldNotBeNullOrWhiteSpace, validator.ParamName);

            validator.ThrowException(condition);
        }

        public static void StringShouldContain(Validator<string> validator, string value)
        {
            string condition = ContextFormatter.BuildFormattedContext(StringResources.StringShouldContain, validator.ParamName, value.ConvertToString());

            validator.ThrowException(condition);
        }

        public static void StringShouldNotContain(Validator<string> validator, string value)
        {
            string condition = ContextFormatter.BuildFormattedContext(StringResources.StringShouldNotContain, validator.ParamName, value.ConvertToString());

            validator.ThrowException(condition);
        }

        public static void StringShouldStartWith(Validator<string> validator, string value)
        {
            string condition = ContextFormatter.BuildFormattedContext(StringResources.StringShouldStartWith, validator.ParamName, value.ConvertToString());

            validator.ThrowException(condition);
        }

        public static void StringShouldNotStartWith(Validator<string> validator, string value)
        {
            string condition = ContextFormatter.BuildFormattedContext(StringResources.StringShouldNotStartWith, validator.ParamName, value.ConvertToString());

            validator.ThrowException(condition);
        }

        public static void StringShouldEndWith(Validator<string> validator, string value)
        {
            string condition = ContextFormatter.BuildFormattedContext(StringResources.StringShouldEndWith, validator.ParamName, value.ConvertToString());

            validator.ThrowException(condition);
        }

        public static void StringShouldNotEndWith(Validator<string> validator, string value)
        {
            string condition = ContextFormatter.BuildFormattedContext(StringResources.StringShouldNotEndWith, validator.ParamName, value.ConvertToString());

            validator.ThrowException(condition);
        }

        public static void StringShouldBeLongerThan(Validator<string> validator, int length)
        {
            string condition = ContextFormatter.BuildFormattedContext(StringResources.StringShouldBeLongerThan, validator.ParamName, length);
            string addition = ContextFormatter.BuildActualStringLengthContext(validator);

            validator.ThrowException(condition, addition);
        }

        public static void StringShouldBeShorterThan(Validator<string> validator, int length)
        {
            string condition = ContextFormatter.BuildFormattedContext(StringResources.StringShouldBeShorterThan, validator.ParamName, length);
            string addition = ContextFormatter.BuildActualStringLengthContext(validator);

            validator.ThrowException(condition, addition);
        }

        public static void StringShouldBeLongerOrEqualTo(Validator<string> validator, int length)
        {
            string condition = ContextFormatter.BuildFormattedContext(StringResources.StringShouldBeLongerOrEqualTo, validator.ParamName, length);
            string addition = ContextFormatter.BuildActualStringLengthContext(validator);

            validator.ThrowException(condition, addition);
        }

        public static void StringShouldBeShorterOrEqualTo(Validator<string> validator, int length)
        {
            string condition = ContextFormatter.BuildFormattedContext(StringResources.StringShouldBeShorterOrEqualTo, validator.ParamName, length);
            string addition = ContextFormatter.BuildActualStringLengthContext(validator);

            validator.ThrowException(condition, addition);
        }

        #endregion

        #region Collection

        public static void CollectionShouldBeEmpty<T>(Validator<T> validator) where T : IEnumerable
        {
            string condition = ContextFormatter.BuildFormattedContext(StringResources.CollectionShouldBeEmpty, validator.ParamName);

            validator.ThrowException(condition);
        }

        public static void CollectionShouldNotBeEmpty<T>(Validator<T> validator) where T : IEnumerable
        {
            string condition = ContextFormatter.BuildFormattedContext(StringResources.CollectionShouldNotBeEmpty, validator.ParamName);

            validator.ThrowException(condition);
        }

        public static void CollectionShouldContain<T>(Validator<T> validator, object value) where T : IEnumerable
        {
            string condition = ContextFormatter.BuildFormattedContext(StringResources.CollectionShouldContain, validator.ParamName, value.ConvertToString());

            validator.ThrowException(condition);
        }

        public static void CollectionShouldNotContain<T>(Validator<T> validator, object value) where T : IEnumerable
        {
            string condition = ContextFormatter.BuildFormattedContext(StringResources.CollectionShouldNotContain, validator.ParamName, value.ConvertToString());

            validator.ThrowException(condition);
        }

        #endregion
    }
}