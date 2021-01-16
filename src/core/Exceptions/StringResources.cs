using System;

namespace Verbess.Utils.Conditions
{
    /// <summary>
    /// String resources for exceptions.
    /// </summary>
    internal static class StringResources
    {
        #region Const
        #region Exception
        internal const string ExceptionTypeIsInvalid = "The specified type {0} is not supported. The type must be concrete and have a public constructor with a single string argument.";
        #endregion

        #region Collection
        internal const string CollectionContainsCurrently1Element = "{0} contains currently 1 element.";
        internal const string CollectionContainsCurrentlyXElements = "{0} contains currently {1} elements.";
        internal const string CollectionIsCurrentlyANullReference = "{0} is currently a null reference.";
        internal const string CollectionShouldBeEmpty = "{0} should be empty.";
        internal const string CollectionShouldContainAllOfX = "{0} should contain all of {1}.";
        internal const string CollectionShouldContainAtLeastOneOfX = "{0} should contain at least one of {1}.";
        internal const string CollectionShouldContainLessThan1Element = "{0} should contain less than 1 element.";
        internal const string CollectionShouldContainLessThanXElements = "{0} should contain less than {1} elements.";
        internal const string CollectionShouldContainMoreThan1Element = "{0} should contain more than 1 element.";
        internal const string CollectionShouldContainMoreThanXElements = "{0} should contain more than {1} elements.";
        internal const string CollectionShouldContainX = "{0} should contain {1}.";
        internal const string CollectionShouldContain1Element = "{0} should contain 1 element.";
        internal const string CollectionShouldContainXElements = "{0} should contain {1} elements.";
        internal const string CollectionShouldContainXOrLessElements = "{0} should contain {1} or less elements.";
        internal const string CollectionShouldContainXOrMoreElements = "{0} should contain {1} or more elements.";
        internal const string CollectionShouldNotBeEmpty = "{0} should not be empty.";
        internal const string CollectionShouldNotContainAllOfX = "{0} should not contain all of {1}.";
        internal const string CollectionShouldNotContainAnyOfX = "{0} should not contain any of {1}.";
        internal const string CollectionShouldNotContainLessThan1Element = "{0} should not contain less than 1 element.";
        internal const string CollectionShouldNotContainLessThanXElements = "{0} should not contain less than {1} elements.";
        internal const string CollectionShouldNotContainMoreThan1Element = "{0} should not contain more than 1 element.";
        internal const string CollectionShouldNotContainMoreThanXElements = "{0} should not contain more than {1} elements.";
        internal const string CollectionShouldNotContainX = "{0} should not contain {1}.";
        internal const string CollectionShouldNotContain1Element = "{0} should not contain 1 element.";
        internal const string CollectionShouldNotContainXElements = "{0} should not contain {1} elements.";
        internal const string CollectionShouldNotContainXOrLessElements = "{0} should not contain {1} or less elements.";
        internal const string CollectionShouldNotContainXOrMoreElements = "{0} should not contain {1} or more elements.";
        #endregion

        #region Lambda
        internal const string LambdaXShouldHoldForValue = "'{1}' should hold for {0}.";
        #endregion

        #region Postcondition
        internal const string PostconditionFailed = "Postcondition failed.";
        internal const string PostconditionXFailed = "Postcondition '{0}' failed.";
        #endregion

        #region String
        internal const string StringShouldBeEmpty = "{0} should be an empty string.";
        internal const string StringShouldBeLongerOrEqualTo1Character = "{0} should be longer or equal to 1 character.";
        internal const string StringShouldBeLongerOrEqualToXCharacters = "{0} should be longer or equal to {1} characters.";
        internal const string StringShouldBeLongerThan1Character = "{0} should be longer than 1 character.";
        internal const string StringShouldBeLongerThanXCharacters = "{0} should be longer than {1} characters.";
        internal const string StringShouldBeNullOrEmpty = "{0} should be null or an empty string.";
        internal const string StringShouldBeNullOrWhiteSpace = "{0} should be null, empty or consists only of white-space characters.";
        internal const string StringShouldBeShorterOrEqualTo1Character = "{0} should be shorter or equal to 1 character.";
        internal const string StringShouldBeShorterOrEqualToXCharacters = "{0} should be shorter or equal to {1} characters.";
        internal const string StringShouldBeShorterThan1Character = "{0} should be shorter than 1 character.";
        internal const string StringShouldBeShorterThanXCharacters = "{0} should be shorter than {1} characters.";
        internal const string StringShouldBe1CharacterLong = "{0} should be 1 character long.";
        internal const string StringShouldBeXCharactersLong = "{0} should be {1} characters long.";
        internal const string StringShouldContainX = "{0} should contain {1}.";
        internal const string StringShouldEndWithX = "{0} should end with {1}.";
        internal const string StringShouldNotBeEmpty = "{0} should not be an empty string.";
        internal const string StringShouldNotBeNullOrEmpty = "{0} should not be null or an empty string.";
        internal const string StringShouldNotBeNullOrWhiteSpace = "{0} should not be null, and empty string or consists only of white-space characters.";
        internal const string StringShouldNotBe1CharacterLong = "{0} should not be 1 character long.";
        internal const string StringShouldNotBeXCharactersLong = "{0} should not be {1} characters long.";
        internal const string StringShouldNotContainX = "{0} should not contain {1}.";
        internal const string StringShouldNotEndWithX = "{0} should not end with {1}.";
        internal const string StringShouldNotStartWithX = "{0} should not start with {1}.";
        internal const string StringShouldStartWithX = "{0} should start with {1}.";
        #endregion

        #region Actual Value
        internal const string TheActualValueIsX = "The actual value {0} is {1}.";
        internal const string TheActualValueIs1CharacterLong = "The actual value {0} is 1 character long.";
        internal const string TheActualValueIsXCharactersLong = "The actual value {0} is {1} characters long.";
        #endregion

        #region Value
        internal const string ValueShouldBeANumber = "{0} should be a number.";
        internal const string ValueShouldBeBetweenXAndY = "{0} should be between {1} and {2}.";
        internal const string ValueShouldBeEqualToX = "{0} should be equal to {1}.";
        internal const string ValueShouldBeFalse = "{0} should be false.";
        internal const string ValueShouldBeGreaterThanOrEqualToX = "{0} should be greater than or equal to {1}.";
        internal const string ValueShouldBeGreaterThanX = "{0} should be greater than {1}.";
        internal const string ValueShouldBeNull = "{0} should be null.";
        internal const string ValueShouldBeOfTypeX = "{0} should be of type {1}.";
        internal const string ValueShouldBeSmallerThanOrEqualToX = "{0} should be smaller than or equal to {1}.";
        internal const string ValueShouldBeSmallerThanX = "{0} should be smaller than {1}.";
        internal const string ValueShouldBeTrue = "{0} should be true.";
        internal const string ValueShouldBeUnequalToX = "{0} should be unequal to {1}.";
        internal const string ValueShouldBeValid = "{0} should be valid.";
        internal const string ValueShouldNotBeANumber = "{0} should not be a number.";
        internal const string ValueShouldNotBeBetweenXAndY = "{0} should not be between {1} and {2}.";
        internal const string ValueShouldNotBeGreaterThanOrEqualToX = "{0} should not be greater than or equal to {1}.";
        internal const string ValueShouldNotBeGreaterThanX = "{0} should not be greater than {1}.";
        internal const string ValueShouldNotBeSmallerThanOrEqualToX = "{0} should not be smaller than or equal to {1}.";
        internal const string ValueShouldNotBeSmallerThanX = "{0} should not be smaller than {1}.";
        internal const string ValueShouldNotBeNull = "{0} should not be null.";
        internal const string ValueShouldNotBeOfTypeX = "{0} should not be of type {1}.";
        internal const string ValueShouldBeInfinity = "{0} should be infinity.";
        internal const string ValueShouldNotBeInfinity = "{0} should not be infinity.";
        internal const string ValueShouldBeNegativeInfinity = "{0} should be negative infinity.";
        internal const string ValueShouldNotBeNegativeInfinity = "{0} should not be negative infinity.";
        internal const string ValueShouldBePositiveInfinity = "{0} should be positive infinity.";
        internal const string ValueShouldNotBePositiveInfinity = "{0} should not be positive infinity.";
        #endregion
        #endregion

        internal static string GetString(string name)
        {
            return GetStringCore(name, null);
        }

        internal static string GetString(string name, params object[] args)
        {
            return GetStringCore(name, args);
        }

        private static string GetStringCore(string name, params object[] args)
        {
            string format = name;

            if (args == null)
            {
                return format;
            }

            return String.Format(format, args);
        }
    }
}