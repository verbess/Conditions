using System;
using System.Collections;
using System.Globalization;
using System.Linq.Expressions;
using System.Reflection;

namespace Verbess.Utils.Conditions
{
    /// <summary>
    /// All throw logic is factored out of the public extension methods and put in this helper class. This 
    /// allows more methods to be a candidate for inlining by the JIT compiler.
    /// </summary>
    internal static class Throw
    {
        internal static void ValueShouldNotBeNull<T>(Validator<T> validator, string conditionDescription)
        {
            string condition = GetFormattedConditionMessage<T>(validator, StringResources.ValueShouldNotBeNull, conditionDescription, validator.ParamName);

            validator.Throw(condition);
        }

        internal static void ValueShouldBeBetween<T>(Validator<T> validator, T minValue, T maxValue, string conditionDescription)
        {
            string condition = GetFormattedConditionMessage<T>(validator, StringResources.ValueShouldBeBetweenXAndY, conditionDescription, validator.ParamName, minValue.Stringify(), maxValue.Stringify());

            string additionalMessage = GetActualValueMessage<T>(validator);

            ConstraintViolationType violationType = GetViolationOrDefault<T>(ConstraintViolationType.OutOfRange);

            validator.Throw(condition, additionalMessage, violationType);
        }

        internal static void ValueShouldBeEqualTo<T>(Validator<T> validator, T value, string conditionDescription)
        {
            string condition = GetFormattedConditionMessage<T>(validator, StringResources.ValueShouldBeEqualToX, conditionDescription, validator.ParamName, value.Stringify());

            string additionalMessage = GetActualValueMessage<T>(validator);

            ConstraintViolationType violationType = GetViolationOrDefault<T>();

            validator.Throw(condition, additionalMessage, violationType);
        }

        internal static void ValueShouldBeNull<T>(Validator<T> validator, string conditionDescription)
        {
            string condition = GetFormattedConditionMessage<T>(validator, StringResources.ValueShouldBeNull, conditionDescription, validator.ParamName);

            validator.Throw(condition);
        }

        internal static void ValueShouldBeGreaterThan<T>(Validator<T> validator, T minValue, string conditionDescription)
        {
            string condition = GetFormattedConditionMessage<T>(validator, StringResources.ValueShouldBeGreaterThanX, conditionDescription, validator.ParamName, minValue.Stringify());

            string additionalMessage = GetActualValueMessage<T>(validator);

            ConstraintViolationType violationType = GetViolationOrDefault<T>(ConstraintViolationType.OutOfRange);

            validator.Throw(condition, additionalMessage, violationType);
        }

        internal static void ValueShouldNotBeGreaterThan<T>(Validator<T> validator, T minValue, string conditionDescription)
        {
            string condition = GetFormattedConditionMessage<T>(validator, StringResources.ValueShouldNotBeGreaterThanX, conditionDescription, validator.ParamName, minValue.Stringify());

            string additionalMessage = GetActualValueMessage<T>(validator);

            ConstraintViolationType violationType = GetViolationOrDefault<T>(ConstraintViolationType.OutOfRange);

            validator.Throw(condition, additionalMessage, violationType);
        }

        internal static void ValueShouldBeGreaterThanOrEqualTo<T>(Validator<T> validator, T minValue, string conditionDescription)
        {
            string condition = GetFormattedConditionMessage<T>(validator, StringResources.ValueShouldBeGreaterThanOrEqualToX, conditionDescription, validator.ParamName, minValue.Stringify());

            string additionalMessage = GetActualValueMessage<T>(validator);

            ConstraintViolationType type = GetViolationOrDefault<T>(ConstraintViolationType.OutOfRange);

            validator.Throw(condition, additionalMessage, type);
        }

        internal static void ValueShouldNotBeGreaterThanOrEqualTo<T>(Validator<T> validator, T maxValue, string conditionDescription)
        {
            string condition = GetFormattedConditionMessage<T>(validator, StringResources.ValueShouldNotBeGreaterThanOrEqualToX, conditionDescription, validator.ParamName, maxValue.Stringify());

            string additionalMessage = GetActualValueMessage<T>(validator);

            ConstraintViolationType type = GetViolationOrDefault<T>(ConstraintViolationType.OutOfRange);

            validator.Throw(condition, additionalMessage, type);
        }

        internal static void ValueShouldBeSmallerThan<T>(Validator<T> validator, T maxValue, string conditionDescription)
        {
            string condition = GetFormattedConditionMessage<T>(validator, StringResources.ValueShouldBeSmallerThanX, conditionDescription, validator.ParamName, maxValue.Stringify());

            string additionalMessage = GetActualValueMessage<T>(validator);

            ConstraintViolationType violationType = GetViolationOrDefault<T>(ConstraintViolationType.OutOfRange);

            validator.Throw(condition, additionalMessage, violationType);
        }

        internal static void ValueShouldNotBeSmallerThan<T>(Validator<T> validator, T minValue, string conditionDescription)
        {
            string condition = GetFormattedConditionMessage<T>(validator, StringResources.ValueShouldNotBeSmallerThanX, conditionDescription, validator.ParamName, minValue.Stringify());

            string additionalMessage = GetActualValueMessage<T>(validator);

            ConstraintViolationType violationType = GetViolationOrDefault<T>(ConstraintViolationType.OutOfRange);

            validator.Throw(condition, additionalMessage, violationType);
        }

        internal static void ValueShouldBeSmallerThanOrEqualTo<T>(Validator<T> validator, T maxValue, string conditionDescription)
        {
            string condition = GetFormattedConditionMessage<T>(validator, StringResources.ValueShouldBeSmallerThanOrEqualToX, conditionDescription, validator.ParamName, maxValue.Stringify());

            string additionalMessage = GetActualValueMessage<T>(validator);

            ConstraintViolationType violationType = GetViolationOrDefault<T>(ConstraintViolationType.OutOfRange);

            validator.Throw(condition, additionalMessage, violationType);
        }

        internal static void ValueShouldNotBeSmallerThanOrEqualTo<T>(Validator<T> validator, T minValue, string conditionDescription)
        {
            string condition = GetFormattedConditionMessage<T>(validator, StringResources.ValueShouldNotBeSmallerThanOrEqualToX, conditionDescription, validator.ParamName, minValue.Stringify());

            string additionalMessage = GetActualValueMessage<T>(validator);

            ConstraintViolationType violationType = GetViolationOrDefault<T>(ConstraintViolationType.OutOfRange);

            validator.Throw(condition, additionalMessage, violationType);
        }

        internal static void ExpressionEvaluatedFalse<T>(Validator<T> validator, string conditionDescription)
        {
            string condition = GetFormattedConditionMessage<T>(validator, StringResources.ValueShouldBeValid, conditionDescription, validator.ParamName);

            string additionalMessage = GetActualValueMessage<T>(validator);

            ConstraintViolationType violationType = GetViolationOrDefault<T>();

            validator.Throw(condition, additionalMessage, violationType);
        }

        internal static void LambdaXShouldHoldForValue<T>(Validator<T> validator, LambdaExpression lambda, string conditionDescription)
        {
            string lambdaDefinition = GetLambdaDefinition(lambda);

            string condition = GetFormattedConditionMessage<T>(validator, StringResources.LambdaXShouldHoldForValue, conditionDescription, validator.ParamName, lambdaDefinition);

            string additionalMessage = GetActualValueMessage<T>(validator);

            ConstraintViolationType violationType = GetViolationOrDefault<T>();

            validator.Throw(condition, additionalMessage, violationType);
        }

        internal static void ValueShouldBeNullOrAnEmptyString(Validator<string> validator, string conditionDescription)
        {
            string condition = GetFormattedConditionMessage<string>(validator, StringResources.StringShouldBeNullOrEmpty, conditionDescription, validator.ParamName);

            validator.Throw(condition);
        }

        internal static void ValueShouldBeAnEmptyString(Validator<string> validator, string conditionDescription)
        {
            string condition = GetFormattedConditionMessage<string>(validator, StringResources.StringShouldBeEmpty, conditionDescription, validator.ParamName);

            validator.Throw(condition);
        }

        internal static void ValueShouldNotBeAnEmptyString(Validator<string> validator, string conditionDescription)
        {
            string condition = GetFormattedConditionMessage<string>(validator, StringResources.StringShouldNotBeEmpty, conditionDescription, validator.ParamName);

            validator.Throw(condition);
        }

        internal static void ValueShouldNotBeNullOrAnEmptyString(Validator<string> validator, string conditionDescription)
        {
            string condition = GetFormattedConditionMessage<string>(validator, StringResources.StringShouldNotBeNullOrEmpty, conditionDescription, validator.ParamName);

            validator.Throw(condition);
        }

        internal static void ValueShouldBeUnequalTo<T>(Validator<T> validator, T value, string conditionDescription)
        {
            string condition = GetFormattedConditionMessage<T>(validator, StringResources.ValueShouldBeUnequalToX, conditionDescription, validator.ParamName, value.Stringify());

            ConstraintViolationType violationType = GetViolationOrDefault<T>();

            validator.Throw(condition, violationType);
        }

        internal static void ValueShouldNotBeBetween<T>(Validator<T> validator, T minValue, T maxValue, string conditionDescription)
        {
            string condition = GetFormattedConditionMessage<T>(validator, StringResources.ValueShouldNotBeBetweenXAndY, conditionDescription, validator.ParamName, minValue.Stringify(), maxValue.Stringify());

            string additionalMessage = GetActualValueMessage<T>(validator);

            ConstraintViolationType violationType = GetViolationOrDefault<T>();

            validator.Throw(condition, additionalMessage, violationType);
        }

        internal static void StringShouldBeNullOrWhiteSpace(Validator<string> validator, string conditionDescription)
        {
            string condition = GetFormattedConditionMessage<string>(validator, StringResources.StringShouldBeNullOrWhiteSpace, conditionDescription, validator.ParamName);

            validator.Throw(condition);
        }

        internal static void StringShouldNotBeNullOrWhiteSpace(Validator<string> validator, string conditionDescription)
        {
            string condition = GetFormattedConditionMessage<string>(validator, StringResources.StringShouldNotBeNullOrWhiteSpace, conditionDescription, validator.ParamName);

            validator.Throw(condition);
        }

        internal static void StringShouldHaveLength(Validator<string> validator, int length, string conditionDescription)
        {
            string condition;
            if (length == 1)
            {
                condition = GetFormattedConditionMessage<string>(validator, StringResources.StringShouldBe1CharacterLong, conditionDescription, validator.ParamName);
            }
            else
            {
                condition = GetFormattedConditionMessage<string>(validator, StringResources.StringShouldBeXCharactersLong, conditionDescription, validator.ParamName, length);
            }

            string additionalMessage = GetActualStringLengthMessage(validator);

            validator.Throw(condition, additionalMessage);
        }

        internal static void StringShouldNotHaveLength(Validator<string> validator, int length, string conditionDescription)
        {
            string condition;
            if (length == 1)
            {
                condition = GetFormattedConditionMessage<string>(validator, StringResources.StringShouldNotBe1CharacterLong, conditionDescription, validator.ParamName);
            }
            else
            {
                condition = GetFormattedConditionMessage<string>(validator, StringResources.StringShouldNotBeXCharactersLong, conditionDescription, validator.ParamName, length);
            }

            validator.Throw(condition);
        }

        internal static void StringShouldBeLongerThan(Validator<string> validator, int minLength, string conditionDescription)
        {
            string condition;
            if (minLength == 1)
            {
                condition = GetFormattedConditionMessage<string>(validator, StringResources.StringShouldBeLongerThan1Character, conditionDescription, validator.ParamName);
            }
            else
            {
                condition = GetFormattedConditionMessage<string>(validator, StringResources.StringShouldBeLongerThanXCharacters, conditionDescription, validator.ParamName, minLength);
            }

            string additionalMessage = GetActualStringLengthMessage(validator);

            validator.Throw(condition, additionalMessage);
        }

        internal static void StringShouldBeShorterThan(Validator<string> validator, int maxLength, string conditionDescription)
        {
            string condition;
            if (maxLength == 1)
            {
                condition = GetFormattedConditionMessage<string>(validator, StringResources.StringShouldBeShorterThan1Character, conditionDescription, validator.ParamName);
            }
            else
            {
                condition = GetFormattedConditionMessage<string>(validator, StringResources.StringShouldBeShorterThanXCharacters, conditionDescription, validator.ParamName, maxLength);
            }

            string additionalMessage = GetActualStringLengthMessage(validator);

            validator.Throw(condition, additionalMessage);
        }

        internal static void StringShouldBeShorterOrEqualTo(Validator<string> validator, int maxLength, string conditionDescription)
        {
            string condition;
            if (maxLength == 1)
            {
                condition = GetFormattedConditionMessage<string>(validator, StringResources.StringShouldBeShorterOrEqualTo1Character, conditionDescription, validator.ParamName);
            }
            else
            {
                condition = GetFormattedConditionMessage<string>(validator, StringResources.StringShouldBeShorterOrEqualToXCharacters, conditionDescription, validator.ParamName, maxLength);
            }

            string additionalMessage = GetActualStringLengthMessage(validator);

            validator.Throw(condition, additionalMessage);
        }

        internal static void StringShouldBeLongerOrEqualTo(Validator<string> validator, int minLength, string conditionDescription)
        {
            string condition;
            if (minLength == 1)
            {
                condition = GetFormattedConditionMessage<string>(validator, StringResources.StringShouldBeLongerOrEqualTo1Character, conditionDescription, validator.ParamName);
            }
            else
            {
                condition = GetFormattedConditionMessage<string>(validator, StringResources.StringShouldBeLongerOrEqualToXCharacters, conditionDescription, validator.ParamName, minLength);
            }

            string additionalMessage = GetActualStringLengthMessage(validator);

            validator.Throw(condition, additionalMessage);
        }

        internal static void StringShouldContain(Validator<string> validator, string value, string conditionDescription)
        {
            string condition = GetFormattedConditionMessage<string>(validator, StringResources.StringShouldContainX, conditionDescription, validator.ParamName, value.Stringify());

            validator.Throw(condition);
        }

        internal static void StringShouldNotContain(Validator<string> validator, string value, string conditionDescription)
        {
            string condition = GetFormattedConditionMessage<string>(validator, StringResources.StringShouldNotContainX, conditionDescription, validator.ParamName, value.Stringify());

            validator.Throw(condition);
        }

        internal static void StringShouldNotEndWith(Validator<string> validator, string value, string conditionDescription)
        {
            string condition = GetFormattedConditionMessage<string>(validator, StringResources.StringShouldNotEndWithX, conditionDescription, validator.ParamName, value.Stringify());

            validator.Throw(condition);
        }

        internal static void StringShouldNotStartWith(Validator<string> validator, string value, string conditionDescription)
        {
            string condition = GetFormattedConditionMessage<string>(validator, StringResources.StringShouldNotStartWithX, conditionDescription, validator.ParamName, value.Stringify());

            validator.Throw(condition);
        }

        internal static void StringShouldEndWith(Validator<string> validator, string value, string conditionDescription)
        {
            string condition = GetFormattedConditionMessage<string>(validator, StringResources.StringShouldEndWithX, conditionDescription, validator.ParamName, value.Stringify());

            validator.Throw(condition);
        }

        internal static void StringShouldStartWith(Validator<string> validator, string value, string conditionDescription)
        {
            string condition = GetFormattedConditionMessage<string>(validator, StringResources.StringShouldStartWithX, conditionDescription, validator.ParamName, value.Stringify());

            validator.Throw(condition);
        }

        internal static void ValueShouldBeOfType<T>(Validator<T> validator, Type type, string conditionDescription)
        {
            string condition = GetFormattedConditionMessage<T>(validator, StringResources.ValueShouldBeOfTypeX, conditionDescription, validator.ParamName, type.Name);

            validator.Throw(condition);
        }

        internal static void ValueShouldNotBeOfType<T>(Validator<T> validator, Type type, string conditionDescription)
        {
            string condition = GetFormattedConditionMessage<T>(validator, StringResources.ValueShouldNotBeOfTypeX, conditionDescription, validator.ParamName, type.Name);

            validator.Throw(condition);
        }

        internal static void ValueShouldBeTrue<T>(Validator<T> validator, string conditionDescription)
        {
            string condition = GetFormattedConditionMessage<T>(validator, StringResources.ValueShouldBeTrue, conditionDescription, validator.ParamName);

            validator.Throw(condition);
        }

        internal static void ValueShouldBeFalse<T>(Validator<T> validator, string conditionDescription)
        {
            string condition = GetFormattedConditionMessage<T>(validator, StringResources.ValueShouldBeFalse, conditionDescription, validator.ParamName);

            validator.Throw(condition);
        }

        internal static void ValueShouldBeANumber<T>(Validator<T> validator, string conditionDescription)
        {
            string condition = GetFormattedConditionMessage<T>(validator, StringResources.ValueShouldBeANumber, conditionDescription, validator.ParamName);

            validator.Throw(condition);
        }

        internal static void ValueShouldNotBeANumber<T>(Validator<T> validator, string conditionDescription)
        {
            string condition = GetFormattedConditionMessage<T>(validator, StringResources.ValueShouldNotBeANumber, conditionDescription, validator.ParamName);

            validator.Throw(condition);
        }

        internal static void ValueShouldBeInfinity<T>(Validator<T> validator, string conditionDescription)
        {
            string condition = GetFormattedConditionMessage<T>(validator, StringResources.ValueShouldBeInfinity, conditionDescription, validator.ParamName);

            validator.Throw(condition);
        }

        internal static void ValueShouldNotBeInfinity<T>(Validator<T> validator, string conditionDescription)
        {
            string condition = GetFormattedConditionMessage<T>(validator, StringResources.ValueShouldNotBeInfinity, conditionDescription, validator.ParamName);

            validator.Throw(condition);
        }

        internal static void ValueShouldBeNegativeInfinity<T>(Validator<T> validator, string conditionDescription)
        {
            string condition = GetFormattedConditionMessage<T>(validator, StringResources.ValueShouldBeNegativeInfinity, conditionDescription, validator.ParamName);

            validator.Throw(condition);
        }

        internal static void ValueShouldNotBeNegativeInfinity<T>(Validator<T> validator, string conditionDescription)
        {
            string condition = GetFormattedConditionMessage<T>(validator, StringResources.ValueShouldNotBeNegativeInfinity, conditionDescription, validator.ParamName);

            validator.Throw(condition);
        }

        internal static void ValueShouldBePositiveInfinity<T>(Validator<T> validator, string conditionDescription)
        {
            string condition = GetFormattedConditionMessage<T>(validator, StringResources.ValueShouldBePositiveInfinity, conditionDescription, validator.ParamName);

            validator.Throw(condition);
        }

        internal static void ValueShouldNotBePositiveInfinity<T>(Validator<T> validator, string conditionDescription)
        {
            string condition = GetFormattedConditionMessage<T>(validator, StringResources.ValueShouldNotBePositiveInfinity, conditionDescription, validator.ParamName);

            validator.Throw(condition);
        }

        internal static void CollectionShouldBeEmpty<T>(Validator<T> validator, string conditionDescription)
        {
            string condition = GetFormattedConditionMessage<T>(validator, StringResources.CollectionShouldBeEmpty, conditionDescription, validator.ParamName);

            validator.Throw(condition);
        }

        internal static void CollectionShouldNotBeEmpty<T>(Validator<T> validator, string conditionDescription) where T : IEnumerable
        {
            string condition = GetFormattedConditionMessage<T>(validator, StringResources.CollectionShouldNotBeEmpty, conditionDescription, validator.ParamName);

            validator.Throw(condition);
        }

        internal static void CollectionShouldContain<T>(Validator<T> validator, object value, string conditionDescription) where T : IEnumerable
        {
            string condition = GetFormattedConditionMessage<T>(validator, StringResources.CollectionShouldContainX, conditionDescription, validator.ParamName, value.Stringify());

            validator.Throw(condition);
        }

        internal static void CollectionShouldNotContain<T>(Validator<T> validator, object value, string conditionDescription)
        {
            string condition = GetFormattedConditionMessage<T>(validator, StringResources.CollectionShouldNotContainX, conditionDescription, validator.ParamName, value.Stringify());

            validator.Throw(condition);
        }

        internal static void CollectionShouldContainAtLeastOneOf<T>(Validator<T> validator, IEnumerable values, string conditionDescription)
        {
            string condition = GetFormattedConditionMessage<T>(validator, StringResources.CollectionShouldContainAtLeastOneOfX, conditionDescription, validator.ParamName, values.Stringify());

            validator.Throw(condition);
        }

        internal static void CollectionShouldNotContainAnyOf<T>(Validator<T> validator, IEnumerable values, string conditionDescription)
        {
            string condition = GetFormattedConditionMessage<T>(validator, StringResources.CollectionShouldNotContainAnyOfX, conditionDescription, validator.ParamName, values.Stringify());

            validator.Throw(condition);
        }

        internal static void CollectionShouldContainAllOf<T>(Validator<T> validator, IEnumerable values, string conditionDescription) where T : IEnumerable
        {
            string condition = GetFormattedConditionMessage<T>(validator, StringResources.CollectionShouldContainAllOfX, conditionDescription, validator.ParamName, values.Stringify());

            validator.Throw(condition);
        }

        internal static void CollectionShouldNotContainAllOf<T>(Validator<T> validator, IEnumerable values, string conditionDescription)
        {
            string condition = GetFormattedConditionMessage<T>(validator, StringResources.CollectionShouldNotContainAllOfX, conditionDescription, validator.ParamName, values.Stringify());

            validator.Throw(condition);
        }

        internal static void CollectionShouldContainNumberOfElements<T>(Validator<T> validator, int numberOfElements, string conditionDescription) where T : IEnumerable
        {
            string condition;
            if (numberOfElements == 1)
            {
                condition = GetFormattedConditionMessage<T>(validator, StringResources.CollectionShouldContain1Element, conditionDescription, validator.ParamName);
            }
            else
            {
                condition = GetFormattedConditionMessage<T>(validator, StringResources.CollectionShouldContainXElements, conditionDescription, validator.ParamName, numberOfElements);
            }

            validator.Throw(condition, GetCollectionContainsElementsMessage<T>(validator));
        }

        internal static void CollectionShouldNotContainNumberOfElements<T>(Validator<T> validator, int numberOfElements, string conditionDescription)
        {
            string condition;
            if (numberOfElements == 1)
            {
                condition = GetFormattedConditionMessage<T>(validator, StringResources.CollectionShouldNotContain1Element, conditionDescription, validator.ParamName);
            }
            else
            {
                condition = GetFormattedConditionMessage<T>(validator, StringResources.CollectionShouldNotContainXElements, conditionDescription, validator.ParamName, numberOfElements);
            }

            validator.Throw(condition);
        }

        internal static void CollectionShouldContainLessThan<T>(Validator<T> validator, int numberOfElements, string conditionDescription) where T : IEnumerable
        {
            string condition;
            if (numberOfElements == 1)
            {
                condition = GetFormattedConditionMessage<T>(validator, StringResources.CollectionShouldContainLessThan1Element, conditionDescription, validator.ParamName);
            }
            else
            {
                condition = GetFormattedConditionMessage<T>(validator, StringResources.CollectionShouldContainLessThanXElements, conditionDescription, validator.ParamName, numberOfElements);
            }

            string additionalMessage = GetCollectionContainsElementsMessage<T>(validator);

            validator.Throw(condition, additionalMessage);
        }

        internal static void CollectionShouldNotContainLessThan<T>(Validator<T> validator, int numberOfElements, string conditionDescription) where T : IEnumerable
        {
            string condition;
            if (numberOfElements == 1)
            {
                condition = GetFormattedConditionMessage<T>(validator, StringResources.CollectionShouldNotContainLessThan1Element, conditionDescription, validator.ParamName);
            }
            else
            {
                condition = GetFormattedConditionMessage<T>(validator, StringResources.CollectionShouldNotContainLessThanXElements, conditionDescription, validator.ParamName, numberOfElements);
            }

            string additionalMessage = GetCollectionContainsElementsMessage<T>(validator);

            validator.Throw(condition, additionalMessage);
        }

        internal static void CollectionShouldContainLessOrEqual<T>(Validator<T> validator, int numberOfElements, string conditionDescription) where T : IEnumerable
        {
            string condition = GetFormattedConditionMessage<T>(validator, StringResources.CollectionShouldContainXOrLessElements, conditionDescription, validator.ParamName, numberOfElements);

            string additionalMessage = GetCollectionContainsElementsMessage<T>(validator);

            validator.Throw(condition, additionalMessage);
        }

        internal static void CollectionShouldNotContainLessOrEqual<T>(Validator<T> validator, int numberOfElements, string conditionDescription) where T : IEnumerable
        {
            string condition = GetFormattedConditionMessage<T>(validator, StringResources.CollectionShouldNotContainXOrLessElements, conditionDescription, validator.ParamName, numberOfElements);

            string additionalMessage = GetCollectionContainsElementsMessage<T>(validator);

            validator.Throw(condition, additionalMessage);
        }

        internal static void CollectionShouldContainMoreThan<T>(Validator<T> validator, int numberOfElements, string conditionDescription) where T : IEnumerable
        {
            string condition;
            if (numberOfElements == 1)
            {
                condition = GetFormattedConditionMessage<T>(validator, StringResources.CollectionShouldContainMoreThan1Element, conditionDescription, validator.ParamName);
            }
            else
            {
                condition = GetFormattedConditionMessage<T>(validator, StringResources.CollectionShouldContainMoreThanXElements, conditionDescription, validator.ParamName, numberOfElements);
            }

            string additionalMessage = GetCollectionContainsElementsMessage<T>(validator);

            validator.Throw(condition, additionalMessage);
        }

        internal static void CollectionShouldNotContainMoreThan<T>(Validator<T> validator, int numberOfElements, string conditionDescription) where T : IEnumerable
        {
            string condition;
            if (numberOfElements == 1)
            {
                condition = GetFormattedConditionMessage<T>(validator, StringResources.CollectionShouldNotContainMoreThan1Element, conditionDescription, validator.ParamName);
            }
            else
            {
                condition = GetFormattedConditionMessage<T>(validator, StringResources.CollectionShouldNotContainMoreThanXElements, conditionDescription, validator.ParamName, numberOfElements);
            }

            string additionalMessage = GetCollectionContainsElementsMessage<T>(validator);

            validator.Throw(condition, additionalMessage);
        }

        internal static void CollectionShouldContainMoreOrEqual<T>(Validator<T> validator, int numberOfElements, string conditionDescription) where T : IEnumerable
        {
            string condition = GetFormattedConditionMessage<T>(validator, StringResources.CollectionShouldContainXOrMoreElements, conditionDescription, validator.ParamName, numberOfElements);

            string additionalMessage = GetCollectionContainsElementsMessage<T>(validator);

            validator.Throw(condition, additionalMessage);
        }

        internal static void CollectionShouldNotContainMoreOrEqual<T>(Validator<T> validator, int numberOfElements, string conditionDescription) where T : IEnumerable
        {
            string condition = GetFormattedConditionMessage<T>(validator, StringResources.CollectionShouldNotContainXOrMoreElements, conditionDescription, validator.ParamName, numberOfElements);

            string additionalMessage = GetCollectionContainsElementsMessage<T>(validator);

            validator.Throw(condition, additionalMessage);
        }

        private static string GetActualValueMessage<T>(Validator<T> validator)
        {
            object value = validator.Value;

            if ((value == null) || (value.GetType().FullName != value.ToString()))
            {
                return StringResources.GetString(StringResources.TheActualValueIsX, validator.ParamName, validator.Value.Stringify());
            }
            else
            {
                return null;
            }
        }

        private static string GetActualStringLengthMessage(Validator<string> validator)
        {
            int length = validator.Value != null ? validator.Value.Length : 0;

            if (length == 1)
            {
                return StringResources.GetString(StringResources.TheActualValueIs1CharacterLong, validator.ParamName);
            }
            else
            {
                return StringResources.GetString(StringResources.TheActualValueIsXCharactersLong, validator.ParamName, length);
            }
        }

        private static string GetCollectionContainsElementsMessage<T>(Validator<T> validator) where T : IEnumerable
        {
            IEnumerable collection = validator.Value;

            if (collection == null)
            {
                return StringResources.GetString(StringResources.CollectionIsCurrentlyANullReference, validator.ParamName);
            }
            else
            {
                int numberOfElements = CollectionExtensions.GetLength(collection);

                if (numberOfElements == 1)
                {
                    return StringResources.GetString(StringResources.CollectionContainsCurrently1Element, validator.ParamName);
                }
                else
                {
                    return StringResources.GetString(StringResources.CollectionContainsCurrentlyXElements, validator.ParamName, numberOfElements);
                }
            }
        }

        private static ConstraintViolationType GetViolationOrDefault<T>()
        {
            return GetViolationOrDefault<T>(ConstraintViolationType.Default);
        }

        private static ConstraintViolationType GetViolationOrDefault<T>(ConstraintViolationType defaultValue)
        {
            if (typeof(T).GetTypeInfo().IsEnum)
            {
                return ConstraintViolationType.Invalid;
            }
            else
            {
                return defaultValue;
            }
        }

        private static string GetFormattedConditionMessage<T>(Validator<T> validator, string resourceKey, string conditionDescription, params object[] resourceFormatArguments)
        {
            if (conditionDescription != null)
            {
                try
                {
                    return String.Format(CultureInfo.CurrentCulture, conditionDescription ?? String.Empty, validator.ParamName);
                }
                catch (FormatException)
                {
                    return conditionDescription;
                }
            }
            else
            {
                return StringResources.GetString(resourceKey, resourceFormatArguments);
            }
        }

        private static string GetLambdaDefinition(LambdaExpression lambda)
        {
            if (lambda == null)
            {
                return "null";
            }
            else
            {
                return lambda.Body.ToString();
            }
        }
    }
}