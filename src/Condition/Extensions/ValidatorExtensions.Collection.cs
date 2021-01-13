using System.Collections;
using System.Collections.Generic;

namespace Verbess.Utils.Conditions
{
    // Collection checks
    public static partial class ValidatorExtensions
    {
        /// <summary>
        /// Checks whether the given value contains no elements. An exception is thrown otherwise. When the 
        /// value is a null reference it is considered empty.
        /// </summary>
        /// <typeparam name="TCollection">The type of the value to check.</typeparam>
        /// <param name="validator">The <see cref="Validator{T}"/> that holds the value that has to be checked.</param>
        /// <returns>The specified <paramref name="validator"/> instance.</returns>
        /// <exception cref="ArgumentException">Thrown when the <see cref="Validator{T}.Value">Value</see> of the specified <paramref name="validator"/> is not empty, while the specified <paramref name="validator"/> is created using the <see cref="Condition.Requires{T}(T,string)">Requires</see> extension method.</exception>
        /// <exception cref="PostconditionException">Thrown when the <see cref="Validator{T}.Value">Value</see> of the specified <paramref name="validator"/> is not empty, while the specified <paramref name="validator"/> is created using the <see cref="Condition.Ensures{T}(T,string)">Ensures</see> extension method.</exception>
        public static Validator<TCollection> IsEmpty<TCollection>(this Validator<TCollection> validator) where TCollection : IEnumerable
        {
            if (!CollectionExtensions.IsSequenceNullOrEmpty(validator.Value))
            {
                Throw.CollectionShouldBeEmpty<TCollection>(validator, null);
            }

            return validator;
        }

        /// <summary>
        /// Checks whether the given value contains no elements. An exception is thrown otherwise. When the 
        /// value is a null reference it is considered empty.
        /// </summary>
        /// <typeparam name="TCollection">The type of the value to check.</typeparam>
        /// <param name="validator">The <see cref="Validator{T}"/> that holds the value that has to be checked.</param>
        /// <param name="conditionDescription">
        /// The description of the condition that should hold. The string may hold the placeholder '{0}' for 
        /// the <see cref="Validator{T}.ArgumentName">ArgumentName</see>.
        /// </param>
        /// <returns>The specified <paramref name="validator"/> instance.</returns>
        /// <exception cref="ArgumentException">Thrown when the <see cref="Validator{T}.Value">Value</see> of the specified <paramref name="validator"/> is not empty, while the specified <paramref name="validator"/> is created using the <see cref="Condition.Requires{T}(T,string)">Requires</see> extension method.</exception>
        /// <exception cref="PostconditionException">Thrown when the <see cref="Validator{T}.Value">Value</see> of the specified <paramref name="validator"/> is not empty, while the specified <paramref name="validator"/> is created using the <see cref="Condition.Ensures{T}(T,string)">Ensures</see> extension method.</exception>
        public static Validator<TCollection> IsEmpty<TCollection>(this Validator<TCollection> validator, string conditionDescription) where TCollection : IEnumerable
        {
            if (!CollectionExtensions.IsSequenceNullOrEmpty(validator.Value))
            {
                Throw.CollectionShouldBeEmpty<TCollection>(validator, conditionDescription);
            }

            return validator;
        }

        /// <summary>
        /// Checks whether the given value does contain elements. An exception is thrown otherwise. When the 
        /// value is a null reference it is considered empty.
        /// </summary>
        /// <typeparam name="TCollection">The type of the value to check.</typeparam>
        /// <param name="validator">The <see cref="Validator{T}"/> that holds the value that has to be checked.</param>
        /// <returns>The specified <paramref name="validator"/> instance.</returns>
        /// <exception cref="ArgumentException">Thrown when the <see cref="Validator{T}.Value">Value</see> of the specified <paramref name="validator"/> is empty, while the specified <paramref name="validator"/> is created using the <see cref="Condition.Requires{T}(T,string)">Requires</see> extension method.</exception>
        /// <exception cref="ArgumentNullException">Thrown when the <see cref="Validator{T}.Value">Value</see> of the specified <paramref name="validator"/> is a null reference, while the specified <paramref name="validator"/> is created using the <see cref="Condition.Requires{T}(T,string)">Requires</see> extension method.</exception>
        /// <exception cref="PostconditionException">Thrown when the <see cref="Validator{T}.Value">Value</see> of the specified <paramref name="validator"/> is empty, while the specified <paramref name="validator"/> is created using the <see cref="Condition.Ensures{T}(T,string)">Ensures</see> extension method.</exception>
        public static Validator<TCollection> IsNotEmpty<TCollection>(this Validator<TCollection> validator) where TCollection : IEnumerable
        {
            if (CollectionExtensions.IsSequenceNullOrEmpty(validator.Value))
            {
                Throw.CollectionShouldNotBeEmpty<TCollection>(validator, null);
            }

            return validator;
        }

        /// <summary>
        /// Checks whether the given value does contain elements. An exception is thrown otherwise. When the 
        /// value is a null reference it is considered empty.
        /// </summary>
        /// <typeparam name="TCollection">The type of the value to check.</typeparam>
        /// <param name="validator">The <see cref="Validator{T}"/> that holds the value that has to be checked.</param>
        /// <param name="conditionDescription">
        /// The description of the condition that should hold. The string may hold the placeholder '{0}' for 
        /// the <see cref="Validator{T}.ArgumentName">ArgumentName</see>.
        /// </param>
        /// <returns>The specified <paramref name="validator"/> instance.</returns>
        /// <exception cref="ArgumentException">Thrown when the <see cref="Validator{T}.Value">Value</see> of the specified <paramref name="validator"/> is empty, while the specified <paramref name="validator"/> is created using the <see cref="Condition.Requires{T}(T,string)">Requires</see> extension method.</exception>
        /// <exception cref="ArgumentNullException">Thrown when the <see cref="Validator{T}.Value">Value</see> of the specified <paramref name="validator"/> is a null reference, while the specified <paramref name="validator"/> is created using the <see cref="Condition.Requires{T}(T,string)">Requires</see> extension method.</exception>
        /// <exception cref="PostconditionException">Thrown when the <see cref="Validator{T}.Value">Value</see> of the specified <paramref name="validator"/> is empty, while the specified <paramref name="validator"/> is created using the <see cref="Condition.Ensures{T}(T,string)">Ensures</see> extension method.</exception>
        public static Validator<TCollection> IsNotEmpty<TCollection>(this Validator<TCollection> validator, string conditionDescription) where TCollection : IEnumerable
        {
            if (CollectionExtensions.IsSequenceNullOrEmpty(validator.Value))
            {
                Throw.CollectionShouldNotBeEmpty<TCollection>(validator, conditionDescription);
            }

            return validator;
        }

        /// <summary>
        /// Checks whether the given value contains the specified <paramref name="element"/>. An exception is 
        /// thrown otherwise. When the value is a null reference it is considered empty and therefore won't 
        /// contain <paramref name="element"/>.
        /// </summary>
        /// <typeparam name="TCollection">The type of the value to check.</typeparam>
        /// <typeparam name="TElement">The type that can be considered an element of the <typeparamref name="TCollection"/>.</typeparam>
        /// <param name="validator">The <see cref="Validator{T}"/> that holds the value that has to be checked.</param>
        /// <param name="element">The element that should contain the given value.</param>
        /// <returns>The specified <paramref name="validator"/> instance.</returns>
        /// <exception cref="ArgumentException">Thrown when the <see cref="Validator{T}.Value">Value</see> of the specified <paramref name="validator"/> does not contain <paramref name="element"/>, while the specified <paramref name="validator"/> is created using the <see cref="Condition.Requires{T}(T,string)">Requires</see> extension method.</exception>
        /// <exception cref="ArgumentNullException">Thrown when the <see cref="Validator{T}.Value">Value</see> of the specified <paramref name="validator"/> is a null reference, while the specified <paramref name="validator"/> is created using the <see cref="Condition.Requires{T}(T,string)">Requires</see> extension method.</exception>
        /// <exception cref="PostconditionException">Thrown when the <see cref="Validator{T}.Value">Value</see> of the specified <paramref name="validator"/> does not contain <paramref name="element"/>, while the specified <paramref name="validator"/> is created using the <see cref="Condition.Ensures{T}(T,string)">Ensures</see> extension method.</exception>
        public static Validator<TCollection> Contains<TCollection, TElement>(this Validator<TCollection> validator, TElement element) where TCollection : IEnumerable<TElement>
        {
            IEnumerable<TElement> collection = validator.Value;

            if ((collection == null) || (!CollectionExtensions.Contains<TElement>(collection, element)))
            {
                Throw.CollectionShouldContain<TCollection>(validator, element, null);
            }

            return validator;
        }

        /// <summary>
        /// Checks whether the given value contains the specified <paramref name="element"/>. An exception is 
        /// thrown otherwise. When the value is a null reference it is considered empty and therefore won't 
        /// contain <paramref name="element"/>.
        /// </summary>
        /// <typeparam name="TCollection">The type of the value to check.</typeparam>
        /// <typeparam name="TElement">The type that can be considered an element of the <typeparamref name="TCollection"/>.</typeparam>
        /// <param name="validator">The <see cref="Validator{T}"/> that holds the value that has to be checked.</param>
        /// <param name="element">The element that should contain the given value.</param>
        /// <param name="conditionDescription">
        /// The description of the condition that should hold. The string may hold the placeholder '{0}' for 
        /// the <see cref="Validator{T}.ArgumentName">ArgumentName</see>.
        /// </param>
        /// <returns>The specified <paramref name="validator"/> instance.</returns>
        /// <exception cref="ArgumentException">Thrown when the <see cref="Validator{T}.Value">Value</see> of the specified <paramref name="validator"/> does not contain <paramref name="element"/>, while the specified <paramref name="validator"/> is created using the <see cref="Condition.Requires{T}(T,string)">Requires</see> extension method.</exception>
        /// <exception cref="ArgumentNullException">Thrown when the <see cref="Validator{T}.Value">Value</see> of the specified <paramref name="validator"/> is a null reference, while the specified <paramref name="validator"/> is created using the <see cref="Condition.Requires{T}(T,string)">Requires</see> extension method.</exception>
        /// <exception cref="PostconditionException">Thrown when the <see cref="Validator{T}.Value">Value</see> of the specified <paramref name="validator"/> does not contain <paramref name="element"/>, while the specified <paramref name="validator"/> is created using the <see cref="Condition.Ensures{T}(T,string)">Ensures</see> extension method.</exception>
        public static Validator<TCollection> Contains<TCollection, TElement>(this Validator<TCollection> validator, TElement element, string conditionDescription) where TCollection : IEnumerable<TElement>
        {
            IEnumerable<TElement> collection = validator.Value;

            if ((collection == null) || (!CollectionExtensions.Contains<TElement>(collection, element)))
            {
                Throw.CollectionShouldContain<TCollection>(validator, element, conditionDescription);
            }

            return validator;
        }

        /// <summary>
        /// Checks whether the given value contains the specified <paramref name="element"/>. An exception is 
        /// thrown otherwise. When the value is a null reference it is considered empty and therefore won't 
        /// contain <paramref name="element"/>.
        /// </summary>
        /// <typeparam name="TCollection">The type of the value to check.</typeparam>
        /// <param name="validator">The <see cref="Validator{T}"/> that holds the value that has to be checked.</param>
        /// <param name="element">The element that should contain the given value.</param>
        /// <returns>The specified <paramref name="validator"/> instance.</returns>
        /// <exception cref="ArgumentException">Thrown when the <see cref="Validator{T}.Value">Value</see> of the specified <paramref name="validator"/> does not contain <paramref name="element"/>, while the specified <paramref name="validator"/> is created using the <see cref="Condition.Requires{T}(T,string)">Requires</see> extension method.</exception>
        /// <exception cref="ArgumentNullException">Thrown when the <see cref="Validator{T}.Value">Value</see> of the specified <paramref name="validator"/> is a null reference, while the specified <paramref name="validator"/> is created using the <see cref="Condition.Requires{T}(T,string)">Requires</see> extension method.</exception>
        /// <exception cref="PostconditionException">Thrown when the <see cref="Validator{T}.Value">Value</see> of the specified <paramref name="validator"/> does not contain <paramref name="element"/>, while the specified <paramref name="validator"/> is created using the <see cref="Condition.Ensures{T}(T,string)">Ensures</see> extension method.</exception>
        public static Validator<TCollection> Contains<TCollection>(this Validator<TCollection> validator, object element) where TCollection : IEnumerable
        {
            IEnumerable collection = validator.Value;

            if ((collection == null) || (!CollectionExtensions.Contains(collection, element)))
            {
                Throw.CollectionShouldContain<TCollection>(validator, element, null);
            }

            return validator;
        }

        /// <summary>
        /// Checks whether the given value contains the specified <paramref name="element"/>. An exception is 
        /// thrown otherwise. When the value is a null reference it is considered empty and therefore won't 
        /// contain <paramref name="element"/>.
        /// </summary>
        /// <typeparam name="TCollection">The type of the value to check.</typeparam>
        /// <param name="validator">The <see cref="Validator{T}"/> that holds the value that has to be checked.</param>
        /// <param name="element">The element that should contain the given value.</param>
        /// <param name="conditionDescription">
        /// The description of the condition that should hold. The string may hold the placeholder '{0}' for 
        /// the <see cref="Validator{T}.ArgumentName">ArgumentName</see>.
        /// </param>
        /// <returns>The specified <paramref name="validator"/> instance.</returns>
        /// <exception cref="ArgumentException">Thrown when the <see cref="Validator{T}.Value">Value</see> of the specified <paramref name="validator"/> does not contain <paramref name="element"/>, while the specified <paramref name="validator"/> is created using the <see cref="Condition.Requires{T}(T,string)">Requires</see> extension method.</exception>
        /// <exception cref="ArgumentNullException">Thrown when the <see cref="Validator{T}.Value">Value</see> of the specified <paramref name="validator"/> is a null reference, while the specified <paramref name="validator"/> is created using the <see cref="Condition.Requires{T}(T,string)">Requires</see> extension method.</exception>
        /// <exception cref="PostconditionException">Thrown when the <see cref="Validator{T}.Value">Value</see> of the specified <paramref name="validator"/> does not contain <paramref name="element"/>, while the specified <paramref name="validator"/> is created using the <see cref="Condition.Ensures{T}(T,string)">Ensures</see> extension method.</exception>
        public static Validator<TCollection> Contains<TCollection>(this Validator<TCollection> validator, object element, string conditionDescription) where TCollection : IEnumerable
        {
            IEnumerable collection = validator.Value;

            if ((collection == null) || (!CollectionExtensions.Contains(collection, element)))
            {
                Throw.CollectionShouldContain<TCollection>(validator, element, conditionDescription);
            }

            return validator;
        }

        /// <summary>
        /// Checks whether the given value does not contain the specified <paramref name="element"/>. An 
        /// exception is thrown otherwise. When the value is a null reference it is considered empty and 
        /// therefore won't contain <paramref name="element"/>.
        /// </summary>
        /// <typeparam name="TCollection">The type of the value to check.</typeparam>
        /// <typeparam name="TElement">The type that can be considered an element of the <typeparamref name="TCollection"/>.</typeparam>
        /// <param name="validator">The <see cref="Validator{T}"/> that holds the value that has to be checked.</param>
        /// <param name="element">The element that should contain the given value.</param>
        /// <returns>The specified <paramref name="validator"/> instance.</returns>
        /// <exception cref="ArgumentException">Thrown when the <see cref="Validator{T}.Value">Value</see> of the specified <paramref name="validator"/> does contain <paramref name="element"/>, while the specified <paramref name="validator"/> is created using the <see cref="Condition.Requires{T}(T,string)">Requires</see> extension method.</exception>
        /// <exception cref="PostconditionException">Thrown when the <see cref="Validator{T}.Value">Value</see> of the specified <paramref name="validator"/> does contain <paramref name="element"/>, while the specified <paramref name="validator"/> is created using the <see cref="Condition.Ensures{T}(T,string)">Ensures</see> extension method.</exception>
        public static Validator<TCollection> DoesNotContain<TCollection, TElement>(this Validator<TCollection> validator, TElement element) where TCollection : IEnumerable<TElement>
        {
            IEnumerable<TElement> collection = validator.Value;

            if ((collection != null) && (CollectionExtensions.Contains<TElement>(collection, element)))
            {
                Throw.CollectionShouldNotContain<TCollection>(validator, element, null);
            }

            return validator;
        }

        /// <summary>
        /// Checks whether the given value does not contain the specified <paramref name="element"/>. An 
        /// exception is thrown otherwise. When the value is a null reference it is considered empty and 
        /// therefore won't contain <paramref name="element"/>.
        /// </summary>
        /// <typeparam name="TCollection">The type of the value to check.</typeparam>
        /// <typeparam name="TElement">The type that can be considered an element of the <typeparamref name="TCollection"/>.</typeparam>
        /// <param name="validator">The <see cref="Validator{T}"/> that holds the value that has to be checked.</param>
        /// <param name="element">The element that should contain the given value.</param>
        /// <param name="conditionDescription">
        /// The description of the condition that should hold. The string may hold the placeholder '{0}' for 
        /// the <see cref="Validator{T}.ArgumentName">ArgumentName</see>.
        /// </param>
        /// <returns>The specified <paramref name="validator"/> instance.</returns>
        /// <exception cref="ArgumentException">Thrown when the <see cref="Validator{T}.Value">Value</see> of the specified <paramref name="validator"/> does contain <paramref name="element"/>, while the specified <paramref name="validator"/> is created using the <see cref="Condition.Requires{T}(T,string)">Requires</see> extension method.</exception>
        /// <exception cref="PostconditionException">Thrown when the <see cref="Validator{T}.Value">Value</see> of the specified <paramref name="validator"/> does contain <paramref name="element"/>, while the specified <paramref name="validator"/> is created using the <see cref="Condition.Ensures{T}(T,string)">Ensures</see> extension method.</exception>
        public static Validator<TCollection> DoesNotContain<TCollection, TElement>(this Validator<TCollection> validator, TElement element, string conditionDescription) where TCollection : IEnumerable<TElement>
        {
            IEnumerable<TElement> collection = validator.Value;

            if ((collection != null) && (CollectionExtensions.Contains<TElement>(collection, element)))
            {
                Throw.CollectionShouldNotContain<TCollection>(validator, element, conditionDescription);
            }

            return validator;
        }

        /// <summary>
        /// Checks whether the given value does not contain the specified <paramref name="element"/>. An 
        /// exception is thrown otherwise. When the value is a null reference it is considered empty and 
        /// therefore won't contain <paramref name="element"/>.
        /// </summary>
        /// <typeparam name="TCollection">The type of the value to check.</typeparam>
        /// <param name="validator">The <see cref="Validator{T}"/> that holds the value that has to be checked.</param>
        /// <param name="element">The element that should contain the given value.</param>
        /// <returns>The specified <paramref name="validator"/> instance.</returns>
        /// <exception cref="ArgumentException">Thrown when the <see cref="Validator{T}.Value">Value</see> of the specified <paramref name="validator"/> does contain <paramref name="element"/>, while the specified <paramref name="validator"/> is created using the <see cref="Condition.Requires{T}(T,string)">Requires</see> extension method.</exception>
        /// <exception cref="PostconditionException">Thrown when the <see cref="Validator{T}.Value">Value</see> of the specified <paramref name="validator"/> does contain <paramref name="element"/>, while the specified <paramref name="validator"/> is created using the <see cref="Condition.Ensures{T}(T,string)">Ensures</see> extension method.</exception>
        public static Validator<TCollection> DoesNotContain<TCollection>(this Validator<TCollection> validator, object element) where TCollection : IEnumerable
        {
            IEnumerable collection = validator.Value;

            if ((collection != null) && (CollectionExtensions.Contains(collection, element)))
            {
                Throw.CollectionShouldNotContain<TCollection>(validator, element, null);
            }

            return validator;
        }

        /// <summary>
        /// Checks whether the given value does not contain the specified <paramref name="element"/>. An 
        /// exception is thrown otherwise. When the value is a null reference it is considered empty and 
        /// therefore won't contain <paramref name="element"/>.
        /// </summary>
        /// <typeparam name="TCollection">The type of the value to check.</typeparam>
        /// <param name="validator">The <see cref="Validator{T}"/> that holds the value that has to be checked.</param>
        /// <param name="element">The element that should contain the given value.</param>
        /// <param name="conditionDescription">
        /// The description of the condition that should hold. The string may hold the placeholder '{0}' for 
        /// the <see cref="Validator{T}.ArgumentName">ArgumentName</see>.
        /// </param>
        /// <returns>The specified <paramref name="validator"/> instance.</returns>
        /// <exception cref="ArgumentException">Thrown when the <see cref="Validator{T}.Value">Value</see> of the specified <paramref name="validator"/> does contain <paramref name="element"/>, while the specified <paramref name="validator"/> is created using the <see cref="Condition.Requires{T}(T,string)">Requires</see> extension method.</exception>
        /// <exception cref="PostconditionException">Thrown when the <see cref="Validator{T}.Value">Value</see> of the specified <paramref name="validator"/> does contain <paramref name="element"/>, while the specified <paramref name="validator"/> is created using the <see cref="Condition.Ensures{T}(T,string)">Ensures</see> extension method.</exception>
        public static Validator<TCollection> DoesNotContain<TCollection>(this Validator<TCollection> validator, object element, string conditionDescription) where TCollection : IEnumerable
        {
            IEnumerable collection = validator.Value;

            if ((collection != null) && (CollectionExtensions.Contains(collection, element)))
            {
                Throw.CollectionShouldNotContain<TCollection>(validator, element, conditionDescription);
            }

            return validator;
        }

        /// <summary>
        /// Checks whether the given value contains any of the specified <paramref name="elements"/>. An 
        /// exception is thrown otherwise. When the value is a null reference or an empty list it won't 
        /// contain any <paramref name="elements"/>. When the <paramref name="elements"/> list is null or 
        /// empty the collection is considered to not contain any element.
        /// </summary>
        /// <typeparam name="TCollection">The type of the value to check.</typeparam>
        /// <typeparam name="TElement">The type that can be considered an element of the <typeparamref name="TCollection"/>.</typeparam>
        /// <param name="validator">The <see cref="Validator{T}"/> that holds the value that has to be checked.</param>
        /// <param name="elements">The list of elements.</param>
        /// <returns>The specified <paramref name="validator"/> instance.</returns>
        /// <exception cref="ArgumentException">Thrown when the <see cref="Validator{T}.Value">Value</see> of the specified <paramref name="validator"/> does not contain any element of the given <paramref name="elements"/> list, while the specified <paramref name="validator"/> is created using the <see cref="Condition.Requires{T}(T,string)">Requires</see> extension method.</exception>
        /// <exception cref="ArgumentNullException">Thrown when the <see cref="Validator{T}.Value">Value</see> of the specified <paramref name="validator"/> is a null reference, while the specified <paramref name="validator"/> is created using the <see cref="Condition.Requires{T}(T,string)">Requires</see> extension method.</exception>
        /// <exception cref="PostconditionException">Thrown when the <see cref="Validator{T}.Value">Value</see> of the specified <paramref name="validator"/> does not contain any element of the given <paramref name="elements"/> list, while the specified <paramref name="validator"/> is created using the <see cref="Condition.Ensures{T}(T,string)">Ensures</see> extension method.</exception>
        public static Validator<TCollection> ContainsAny<TCollection, TElement>(this Validator<TCollection> validator, IEnumerable<TElement> elements) where TCollection : IEnumerable<TElement>
        {
            if (!CollectionExtensions.ContainsAny<TElement>(validator.Value, elements))
            {
                Throw.CollectionShouldContainAtLeastOneOf<TCollection>(validator, elements, null);
            }

            return validator;
        }

        /// <summary>
        /// Checks whether the given value contains any of the specified <paramref name="elements"/>. An 
        /// exception is thrown otherwise. When the value is a null reference or an empty list it won't 
        /// contain any <paramref name="elements"/>. When the <paramref name="elements"/> list is null or 
        /// empty the collection is considered to not contain any element.
        /// </summary>
        /// <typeparam name="TCollection">The type of the value to check.</typeparam>
        /// <typeparam name="TElement">The type that can be considered an element of the <typeparamref name="TCollection"/>.</typeparam>
        /// <param name="validator">The <see cref="Validator{T}"/> that holds the value that has to be checked.</param>
        /// <param name="elements">The list of elements.</param>
        /// <param name="conditionDescription">
        /// The description of the condition that should hold. The string may hold the placeholder '{0}' for 
        /// the <see cref="Validator{T}.ArgumentName">ArgumentName</see>.
        /// </param>
        /// <returns>The specified <paramref name="validator"/> instance.</returns>
        /// <exception cref="ArgumentException">Thrown when the <see cref="Validator{T}.Value">Value</see> of the specified <paramref name="validator"/> does not contain any element of the given <paramref name="elements"/> list, while the specified <paramref name="validator"/> is created using the <see cref="Condition.Requires{T}(T,string)">Requires</see> extension method.</exception>
        /// <exception cref="ArgumentNullException">Thrown when the <see cref="Validator{T}.Value">Value</see> of the specified <paramref name="validator"/> is a null reference, while the specified <paramref name="validator"/> is created using the <see cref="Condition.Requires{T}(T,string)">Requires</see> extension method.</exception>
        /// <exception cref="PostconditionException">Thrown when the <see cref="Validator{T}.Value">Value</see> of the specified <paramref name="validator"/> does not contain any element of the given <paramref name="elements"/> list, while the specified <paramref name="validator"/> is created using the <see cref="Condition.Ensures{T}(T,string)">Ensures</see> extension method.</exception>
        public static Validator<TCollection> ContainsAny<TCollection, TElement>(this Validator<TCollection> validator, IEnumerable<TElement> elements, string conditionDescription) where TCollection : IEnumerable<TElement>
        {
            if (!CollectionExtensions.ContainsAny<TElement>(validator.Value, elements))
            {
                Throw.CollectionShouldContainAtLeastOneOf<TCollection>(validator, elements, conditionDescription);
            }

            return validator;
        }

        /// <summary>
        /// Checks whether the given value contains any of the specified <paramref name="elements"/>. An 
        /// exception is thrown otherwise. When the value is a null reference or an empty list it won't 
        /// contain any <paramref name="elements"/>. When the <paramref name="elements"/> list is null or 
        /// empty the collection is considered to not contain any element.
        /// </summary>
        /// <typeparam name="TCollection">The type of the value to check.</typeparam>
        /// <param name="validator">The <see cref="Validator{T}"/> that holds the value that has to be checked.</param>
        /// <param name="elements">The list of elements.</param>
        /// <returns>The specified <paramref name="validator"/> instance.</returns>
        /// <exception cref="ArgumentException">Thrown when the <see cref="Validator{T}.Value">Value</see> of the specified <paramref name="validator"/> does not contain any element of the given <paramref name="elements"/> list, while the specified <paramref name="validator"/> is created using the <see cref="Condition.Requires{T}(T,string)">Requires</see> extension method.</exception>
        /// <exception cref="ArgumentNullException">Thrown when the <see cref="Validator{T}.Value">Value</see> of the specified <paramref name="validator"/> is a null reference, while the specified <paramref name="validator"/> is created using the <see cref="Condition.Requires{T}(T,string)">Requires</see> extension method.</exception>
        /// <exception cref="PostconditionException">Thrown when the <see cref="Validator{T}.Value">Value</see> of the specified <paramref name="validator"/> does not contain any element of the given <paramref name="elements"/> list, while the specified <paramref name="validator"/> is created using the <see cref="Condition.Ensures{T}(T,string)">Ensures</see> extension method.</exception>
        public static Validator<TCollection> ContainsAny<TCollection>(this Validator<TCollection> validator, IEnumerable elements) where TCollection : IEnumerable
        {
            if (!CollectionExtensions.ContainsAny(validator.Value, elements))
            {
                Throw.CollectionShouldContainAtLeastOneOf<TCollection>(validator, elements, null);
            }

            return validator;
        }

        /// <summary>
        /// Checks whether the given value contains any of the specified <paramref name="elements"/>. An 
        /// exception is thrown otherwise. When the value is a null reference or an empty list it won't 
        /// contain any <paramref name="elements"/>. When the <paramref name="elements"/> list is null or 
        /// empty the collection is considered to not contain any element.
        /// </summary>
        /// <typeparam name="TCollection">The type of the value to check.</typeparam>
        /// <param name="validator">The <see cref="Validator{T}"/> that holds the value that has to be checked.</param>
        /// <param name="elements">The list of elements.</param>
        /// <param name="conditionDescription">
        /// The description of the condition that should hold. The string may hold the placeholder '{0}' for 
        /// the <see cref="Validator{T}.ArgumentName">ArgumentName</see>.
        /// </param>
        /// <returns>The specified <paramref name="validator"/> instance.</returns>
        /// <exception cref="ArgumentException">Thrown when the <see cref="Validator{T}.Value">Value</see> of the specified <paramref name="validator"/> does not contain any element of the given <paramref name="elements"/> list, while the specified <paramref name="validator"/> is created using the <see cref="Condition.Requires{T}(T,string)">Requires</see> extension method.</exception>
        /// <exception cref="ArgumentNullException">Thrown when the <see cref="Validator{T}.Value">Value</see> of the specified <paramref name="validator"/> is a null reference, while the specified <paramref name="validator"/> is created using the <see cref="Condition.Requires{T}(T,string)">Requires</see> extension method.</exception>
        /// <exception cref="PostconditionException">Thrown when the <see cref="Validator{T}.Value">Value</see> of the specified <paramref name="validator"/> does not contain any element of the given <paramref name="elements"/> list, while the specified <paramref name="validator"/> is created using the <see cref="Condition.Ensures{T}(T,string)">Ensures</see> extension method.</exception>
        public static Validator<TCollection> ContainsAny<TCollection>(this Validator<TCollection> validator, IEnumerable elements, string conditionDescription) where TCollection : IEnumerable
        {
            if (!CollectionExtensions.ContainsAny(validator.Value, elements))
            {
                Throw.CollectionShouldContainAtLeastOneOf<TCollection>(validator, elements, conditionDescription);
            }

            return validator;
        }

        /// <summary>
        /// Checks whether the given value does not contains any of the specified <paramref name="elements"/>.
        /// An exception is thrown otherwise.
        /// When the value is a null reference or an empty list it won't contain any <paramref name="elements"/>.
        /// When the <paramref name="elements"/> list is null or empty the collection is considered to not 
        /// contain any element.
        /// </summary>
        /// <typeparam name="TCollection">The type of the value to check.</typeparam>
        /// <typeparam name="TElement">The type that can be considered an element of the <typeparamref name="TCollection"/>.</typeparam>
        /// <param name="validator">The <see cref="Validator{T}"/> that holds the value that has to be checked.</param>
        /// <param name="elements">The list of elements.</param>
        /// <returns>The specified <paramref name="validator"/> instance.</returns>
        /// <exception cref="ArgumentException">Thrown when the <see cref="Validator{T}.Value">Value</see> of the specified <paramref name="validator"/> does contain one or more elements of the given <paramref name="elements"/> list, while the specified <paramref name="validator"/> is created using the <see cref="Condition.Requires{T}(T,string)">Requires</see> extension method.</exception>
        /// <exception cref="PostconditionException">Thrown when the <see cref="Validator{T}.Value">Value</see> of the specified <paramref name="validator"/> does contain one or more elements of the given <paramref name="elements"/> list, while the specified <paramref name="validator"/> is created using the <see cref="Condition.Ensures{T}(T,string)">Ensures</see> extension method.</exception>
        public static Validator<TCollection> DoesNotContainAny<TCollection, TElement>(this Validator<TCollection> validator, IEnumerable<TElement> elements) where TCollection : IEnumerable<TElement>
        {
            if (CollectionExtensions.ContainsAny<TElement>(validator.Value, elements))
            {
                Throw.CollectionShouldNotContainAnyOf<TCollection>(validator, elements, null);
            }

            return validator;
        }

        /// <summary>
        /// Checks whether the given value does not contains any of the specified <paramref name="elements"/>.
        /// An exception is thrown otherwise.
        /// When the value is a null reference or an empty list it won't contain any <paramref name="elements"/>.
        /// When the <paramref name="elements"/> list is null or empty the collection is considered to not 
        /// contain any element.
        /// </summary>
        /// <typeparam name="TCollection">The type of the value to check.</typeparam>
        /// <typeparam name="TElement">The type that can be considered an element of the <typeparamref name="TCollection"/>.</typeparam>
        /// <param name="validator">The <see cref="Validator{T}"/> that holds the value that has to be checked.</param>
        /// <param name="elements">The list of elements.</param>
        /// <param name="conditionDescription">
        /// The description of the condition that should hold. The string may hold the placeholder '{0}' for 
        /// the <see cref="Validator{T}.ArgumentName">ArgumentName</see>.
        /// </param>
        /// <returns>The specified <paramref name="validator"/> instance.</returns>
        /// <exception cref="ArgumentException">Thrown when the <see cref="Validator{T}.Value">Value</see> of the specified <paramref name="validator"/> does contain one or more elements of the given <paramref name="elements"/> list, while the specified <paramref name="validator"/> is created using the <see cref="Condition.Requires{T}(T,string)">Requires</see> extension method.</exception>
        /// <exception cref="PostconditionException">Thrown when the <see cref="Validator{T}.Value">Value</see> of the specified <paramref name="validator"/> does contain one or more elements of the given <paramref name="elements"/> list, while the specified <paramref name="validator"/> is created using the <see cref="Condition.Ensures{T}(T,string)">Ensures</see> extension method.</exception>
        public static Validator<TCollection> DoesNotContainAny<TCollection, TElement>(this Validator<TCollection> validator, IEnumerable<TElement> elements, string conditionDescription) where TCollection : IEnumerable<TElement>
        {
            if (CollectionExtensions.ContainsAny<TElement>(validator.Value, elements))
            {
                Throw.CollectionShouldNotContainAnyOf<TCollection>(validator, elements, conditionDescription);
            }

            return validator;
        }

        /// <summary>
        /// Checks whether the given value does not contains any of the specified <paramref name="elements"/>.
        /// An exception is thrown otherwise.
        /// When the value is a null reference or an empty list it won't contain any <paramref name="elements"/>.
        /// When the <paramref name="elements"/> list is null or empty the collection is considered to not 
        /// contain any element.
        /// </summary>
        /// <typeparam name="TCollection">The type of the value to check.</typeparam>
        /// <param name="validator">The <see cref="Validator{T}"/> that holds the value that has to be checked.</param>
        /// <param name="elements">The list of elements.</param>
        /// <returns>The specified <paramref name="validator"/> instance.</returns>
        /// <exception cref="ArgumentException">Thrown when the <see cref="Validator{T}.Value">Value</see> of the specified <paramref name="validator"/> does contain one or more elements of the given <paramref name="elements"/> list, while the specified <paramref name="validator"/> is created using the <see cref="Condition.Requires{T}(T,string)">Requires</see> extension method.</exception>
        /// <exception cref="PostconditionException">Thrown when the <see cref="Validator{T}.Value">Value</see> of the specified <paramref name="validator"/> does contain one or more elements of the given <paramref name="elements"/> list, while the specified <paramref name="validator"/> is created using the <see cref="Condition.Ensures{T}(T,string)">Ensures</see> extension method.</exception>
        public static Validator<TCollection> DoesNotContainAny<TCollection>(this Validator<TCollection> validator, IEnumerable elements) where TCollection : IEnumerable
        {
            if (CollectionExtensions.ContainsAny(validator.Value, elements))
            {
                Throw.CollectionShouldNotContainAnyOf<TCollection>(validator, elements, null);
            }

            return validator;
        }

        /// <summary>
        /// Checks whether the given value does not contains any of the specified <paramref name="elements"/>.
        /// An exception is thrown otherwise.
        /// When the value is a null reference or an empty list it won't contain any <paramref name="elements"/>.
        /// When the <paramref name="elements"/> list is null or empty the collection is considered to not 
        /// contain any element.
        /// </summary>
        /// <typeparam name="TCollection">The type of the value to check.</typeparam>
        /// <param name="validator">The <see cref="Validator{T}"/> that holds the value that has to be checked.</param>
        /// <param name="elements">The list of elements.</param>
        /// <param name="conditionDescription">
        /// The description of the condition that should hold. The string may hold the placeholder '{0}' for 
        /// the <see cref="Validator{T}.ArgumentName">ArgumentName</see>.
        /// </param>
        /// <returns>The specified <paramref name="validator"/> instance.</returns>
        /// <exception cref="ArgumentException">Thrown when the <see cref="Validator{T}.Value">Value</see> of the specified <paramref name="validator"/> does contain one or more elements of the given <paramref name="elements"/> list, while the specified <paramref name="validator"/> is created using the <see cref="Condition.Requires{T}(T,string)">Requires</see> extension method.</exception>
        /// <exception cref="PostconditionException">Thrown when the <see cref="Validator{T}.Value">Value</see> of the specified <paramref name="validator"/> does contain one or more elements of the given <paramref name="elements"/> list, while the specified <paramref name="validator"/> is created using the <see cref="Condition.Ensures{T}(T,string)">Ensures</see> extension method.</exception>
        public static Validator<TCollection> DoesNotContainAny<TCollection>(this Validator<TCollection> validator, IEnumerable elements, string conditionDescription) where TCollection : IEnumerable
        {
            if (CollectionExtensions.ContainsAny(validator.Value, elements))
            {
                Throw.CollectionShouldNotContainAnyOf<TCollection>(validator, elements, conditionDescription);
            }

            return validator;
        }

        /// <summary>
        /// Checks whether the given value contains all of the specified <paramref name="elements"/>. An 
        /// exception is thrown otherwise. When the <paramref name="elements"/> collection is a null reference 
        /// or an empty list, the collection is considered to contain all of the specified (even if the value 
        /// itself is empty). When the given value is empty and the given <paramref name="elements"/> list 
        /// isn't, the collection is considered to not contain all of the specified <paramref name="elements"/>.
        /// </summary>
        /// <typeparam name="TCollection">The type of the value to check.</typeparam>
        /// <typeparam name="TElement">The type that can be considered an element of the <typeparamref name="TCollection"/>.</typeparam>
        /// <param name="validator">The <see cref="Validator{T}"/> that holds the value that has to be checked.</param>
        /// <param name="elements">The list of elements.</param>
        /// <returns>The specified <paramref name="validator"/> instance.</returns>
        /// <exception cref="ArgumentException">Thrown when the <see cref="Validator{T}.Value">Value</see> of the specified <paramref name="validator"/> does not contain all of the elements of the given <paramref name="elements"/> list, while the specified <paramref name="validator"/> is created using the <see cref="Condition.Requires{T}(T,string)">Requires</see> extension method.</exception>
        /// <exception cref="ArgumentNullException">Thrown when the <see cref="Validator{T}.Value">Value</see> of the specified <paramref name="validator"/> is a null reference, while the specified <paramref name="validator"/> is created using the <see cref="Condition.Requires{T}(T,string)">Requires</see> extension method.</exception>
        /// <exception cref="PostconditionException">Thrown when the <see cref="Validator{T}.Value">Value</see> of the specified <paramref name="validator"/> does not contain all of the elements of the given <paramref name="elements"/> list, while the specified <paramref name="validator"/> is created using the <see cref="Condition.Ensures{T}(T,string)">Ensures</see> extension method.</exception>
        public static Validator<TCollection> ContainsAll<TCollection, TElement>(this Validator<TCollection> validator, IEnumerable<TElement> elements) where TCollection : IEnumerable<TElement>
        {
            if (!CollectionExtensions.ContainsAll<TElement>(validator.Value, elements))
            {
                Throw.CollectionShouldContainAllOf<TCollection>(validator, elements, null);
            }

            return validator;
        }

        /// <summary>
        /// Checks whether the given value contains all of the specified <paramref name="elements"/>. An 
        /// exception is thrown otherwise. When the <paramref name="elements"/> collection is a null reference 
        /// or an empty list, the collection is considered to contain all of the specified (even if the value 
        /// itself is empty). When the given value is empty and the given <paramref name="elements"/> list 
        /// isn't, the collection is considered to not contain all of the specified <paramref name="elements"/>.
        /// </summary>
        /// <typeparam name="TCollection">The type of the value to check.</typeparam>
        /// <typeparam name="TElement">The type that can be considered an element of the <typeparamref name="TCollection"/>.</typeparam>
        /// <param name="validator">The <see cref="Validator{T}"/> that holds the value that has to be checked.</param>
        /// <param name="elements">The list of elements.</param>
        /// <param name="conditionDescription">
        /// The description of the condition that should hold. The string may hold the placeholder '{0}' for 
        /// the <see cref="Validator{T}.ArgumentName">ArgumentName</see>.
        /// </param>
        /// <returns>The specified <paramref name="validator"/> instance.</returns>
        /// <exception cref="ArgumentException">Thrown when the <see cref="Validator{T}.Value">Value</see> of the specified <paramref name="validator"/> does not contain all of the elements of the given <paramref name="elements"/> list, while the specified <paramref name="validator"/> is created using the <see cref="Condition.Requires{T}(T,string)">Requires</see> extension method.</exception>
        /// <exception cref="ArgumentNullException">Thrown when the <see cref="Validator{T}.Value">Value</see> of the specified <paramref name="validator"/> is a null reference, while the specified <paramref name="validator"/> is created using the <see cref="Condition.Requires{T}(T,string)">Requires</see> extension method.</exception>
        /// <exception cref="PostconditionException">Thrown when the <see cref="Validator{T}.Value">Value</see> of the specified <paramref name="validator"/> does not contain all of the elements of the given <paramref name="elements"/> list, while the specified <paramref name="validator"/> is created using the <see cref="Condition.Ensures{T}(T,string)">Ensures</see> extension method.</exception>
        public static Validator<TCollection> ContainsAll<TCollection, TElement>(this Validator<TCollection> validator, IEnumerable<TElement> elements, string conditionDescription) where TCollection : IEnumerable<TElement>
        {
            if (!CollectionExtensions.ContainsAll<TElement>(validator.Value, elements))
            {
                Throw.CollectionShouldContainAllOf<TCollection>(validator, elements, conditionDescription);
            }

            return validator;
        }

        /// <summary>
        /// Checks whether the given value contains all of the specified <paramref name="elements"/>. An 
        /// exception is thrown otherwise. When the <paramref name="elements"/> collection is a null reference 
        /// or an empty list, the collection is considered to contain all of the specified (even if the value 
        /// itself is empty). When the given value is empty and the given <paramref name="elements"/> list 
        /// isn't, the collection is considered to not contain all of the specified <paramref name="elements"/>.
        /// </summary>
        /// <typeparam name="TCollection">The type of the value to check.</typeparam>
        /// <param name="validator">The <see cref="Validator{T}"/> that holds the value that has to be checked.</param>
        /// <param name="elements">The list of elements.</param>
        /// <returns>The specified <paramref name="validator"/> instance.</returns>
        /// <exception cref="ArgumentException">Thrown when the <see cref="Validator{T}.Value">Value</see> of the specified <paramref name="validator"/> does not contain all of the elements of the given <paramref name="elements"/> list, while the specified <paramref name="validator"/> is created using the <see cref="Condition.Requires{T}(T,string)">Requires</see> extension method.</exception>
        /// <exception cref="ArgumentNullException">Thrown when the <see cref="Validator{T}.Value">Value</see> of the specified <paramref name="validator"/> is a null reference, while the specified <paramref name="validator"/> is created using the <see cref="Condition.Requires{T}(T,string)">Requires</see> extension method.</exception>
        /// <exception cref="PostconditionException">Thrown when the <see cref="Validator{T}.Value">Value</see> of the specified <paramref name="validator"/> does not contain all of the elements of the given <paramref name="elements"/> list, while the specified <paramref name="validator"/> is created using the <see cref="Condition.Ensures{T}(T,string)">Ensures</see> extension method.</exception>
        public static Validator<TCollection> ContainsAll<TCollection>(this Validator<TCollection> validator, IEnumerable elements) where TCollection : IEnumerable
        {
            if (!CollectionExtensions.ContainsAll(validator.Value, elements))
            {
                Throw.CollectionShouldContainAllOf<TCollection>(validator, elements, null);
            }

            return validator;
        }

        /// <summary>
        /// Checks whether the given value contains all of the specified <paramref name="elements"/>. An 
        /// exception is thrown otherwise. When the <paramref name="elements"/> collection is a null reference 
        /// or an empty list, the collection is considered to contain all of the specified (even if the value 
        /// itself is empty). When the given value is empty and the given <paramref name="elements"/> list 
        /// isn't, the collection is considered to not contain all of the specified <paramref name="elements"/>.
        /// </summary>
        /// <typeparam name="TCollection">The type of the value to check.</typeparam>
        /// <param name="validator">The <see cref="Validator{T}"/> that holds the value that has to be checked.</param>
        /// <param name="elements">The list of elements.</param>
        /// <param name="conditionDescription">
        /// The description of the condition that should hold. The string may hold the placeholder '{0}' for 
        /// the <see cref="Validator{T}.ArgumentName">ArgumentName</see>.
        /// </param>
        /// <returns>The specified <paramref name="validator"/> instance.</returns>
        /// <exception cref="ArgumentException">Thrown when the <see cref="Validator{T}.Value">Value</see> of the specified <paramref name="validator"/> does not contain all of the elements of the given <paramref name="elements"/> list, while the specified <paramref name="validator"/> is created using the <see cref="Condition.Requires{T}(T,string)">Requires</see> extension method.</exception>
        /// <exception cref="ArgumentNullException">Thrown when the <see cref="Validator{T}.Value">Value</see> of the specified <paramref name="validator"/> is a null reference, while the specified <paramref name="validator"/> is created using the <see cref="Condition.Requires{T}(T,string)">Requires</see> extension method.</exception>
        /// <exception cref="PostconditionException">Thrown when the <see cref="Validator{T}.Value">Value</see> of the specified <paramref name="validator"/> does not contain all of the elements of the given <paramref name="elements"/> list, while the specified <paramref name="validator"/> is created using the <see cref="Condition.Ensures{T}(T,string)">Ensures</see> extension method.</exception>
        public static Validator<TCollection> ContainsAll<TCollection>(this Validator<TCollection> validator, IEnumerable elements, string conditionDescription) where TCollection : IEnumerable
        {
            if (!CollectionExtensions.ContainsAll(validator.Value, elements))
            {
                Throw.CollectionShouldContainAllOf<TCollection>(validator, elements, conditionDescription);
            }

            return validator;
        }

        /// <summary>
        /// Checks whether the given value does not contains all of the specified <paramref name="elements"/>.
        /// An exception is thrown otherwise. When the <paramref name="elements"/> collection is a null 
        /// reference or an empty list, the collection is considered to contain all of the specified (even if 
        /// the value itself is empty). When the given value is empty and the given <paramref name="elements"/>
        /// list isn't, the collection is considered to not contain all of the specified 
        /// <paramref name="elements"/>.
        /// </summary>
        /// <typeparam name="TCollection">The type of the value to check.</typeparam>
        /// <typeparam name="TElement">The type that can be considered an element of the <typeparamref name="TCollection"/>.</typeparam>
        /// <param name="validator">The <see cref="Validator{T}"/> that holds the value that has to be checked.</param>
        /// <param name="elements">The list of elements.</param>
        /// <returns>The specified <paramref name="validator"/> instance.</returns>
        /// <exception cref="ArgumentException">Thrown when the <see cref="Validator{T}.Value">Value</see> of the specified <paramref name="validator"/> does contain all of the elements of the specified <paramref name="elements"/> list, while the specified <paramref name="validator"/> is created using the <see cref="Condition.Requires{T}(T,string)">Requires</see> extension method.</exception>
        /// <exception cref="ArgumentNullException">Thrown when the <see cref="Validator{T}.Value">Value</see> of the specified <paramref name="validator"/> is a null reference and the specified <paramref name="elements"/> list is null or empty, while the specified <paramref name="validator"/> is created using the <see cref="Condition.Requires{T}(T,string)">Requires</see> extension method.</exception>
        /// <exception cref="PostconditionException">Thrown when the <see cref="Validator{T}.Value">Value</see> of the specified <paramref name="validator"/> does contain all of the elements of the specified <paramref name="elements"/> list, while the specified <paramref name="validator"/> is created using the <see cref="Condition.Ensures{T}(T,string)">Ensures</see> extension method.</exception>
        public static Validator<TCollection> DoesNotContainAll<TCollection, TElement>(this Validator<TCollection> validator, IEnumerable<TElement> elements) where TCollection : IEnumerable<TElement>
        {
            if (CollectionExtensions.ContainsAll<TElement>(validator.Value, elements))
            {
                Throw.CollectionShouldNotContainAllOf<TCollection>(validator, elements, null);
            }

            return validator;
        }

        /// <summary>
        /// Checks whether the given value does not contains all of the specified <paramref name="elements"/>.
        /// An exception is thrown otherwise. When the <paramref name="elements"/> collection is a null 
        /// reference or an empty list, the collection is considered to contain all of the specified (even if 
        /// the value itself is empty). When the given value is empty and the given <paramref name="elements"/>
        /// list isn't, the collection is considered to not contain all of the specified 
        /// <paramref name="elements"/>.
        /// </summary>
        /// <typeparam name="TCollection">The type of the value to check.</typeparam>
        /// <typeparam name="TElement">The type that can be considered an element of the <typeparamref name="TCollection"/>.</typeparam>
        /// <param name="validator">The <see cref="Validator{T}"/> that holds the value that has to be checked.</param>
        /// <param name="elements">The list of elements.</param>
        /// <param name="conditionDescription">
        /// The description of the condition that should hold. The string may hold the placeholder '{0}' for 
        /// the <see cref="Validator{T}.ArgumentName">ArgumentName</see>.
        /// </param>
        /// <returns>The specified <paramref name="validator"/> instance.</returns>
        /// <exception cref="ArgumentException">Thrown when the <see cref="Validator{T}.Value">Value</see> of the specified <paramref name="validator"/> does contain all of the elements of the specified <paramref name="elements"/> list, while the specified <paramref name="validator"/> is created using the <see cref="Condition.Requires{T}(T,string)">Requires</see> extension method.</exception>
        /// <exception cref="ArgumentNullException">Thrown when the <see cref="Validator{T}.Value">Value</see> of the specified <paramref name="validator"/> is a null reference and the specified <paramref name="elements"/> list is null or empty, while the specified <paramref name="validator"/> is created using the <see cref="Condition.Requires{T}(T,string)">Requires</see> extension method.</exception>
        /// <exception cref="PostconditionException">Thrown when the <see cref="Validator{T}.Value">Value</see> of the specified <paramref name="validator"/> does contain all of the elements of the specified <paramref name="elements"/> list, while the specified <paramref name="validator"/> is created using the <see cref="Condition.Ensures{T}(T,string)">Ensures</see> extension method.</exception>
        public static Validator<TCollection> DoesNotContainAll<TCollection, TElement>(this Validator<TCollection> validator, IEnumerable<TElement> elements, string conditionDescription) where TCollection : IEnumerable<TElement>
        {
            if (CollectionExtensions.ContainsAll<TElement>(validator.Value, elements))
            {
                Throw.CollectionShouldNotContainAllOf<TCollection>(validator, elements, conditionDescription);
            }

            return validator;
        }

        /// <summary>
        /// Checks whether the given value does not contains all of the specified <paramref name="elements"/>.
        /// An exception is thrown otherwise. When the <paramref name="elements"/> collection is a null 
        /// reference or an empty list, the collection is considered to contain all of the specified (even if 
        /// the value itself is empty). When the given value is empty and the given <paramref name="elements"/>
        /// list isn't, the collection is considered to not contain all of the specified 
        /// <paramref name="elements"/>.
        /// </summary>
        /// <typeparam name="TCollection">The type of the value to check.</typeparam>
        /// <param name="validator">The <see cref="Validator{T}"/> that holds the value that has to be checked.</param>
        /// <param name="elements">The list of elements.</param>
        /// <returns>The specified <paramref name="validator"/> instance.</returns>
        /// <exception cref="ArgumentException">Thrown when the <see cref="Validator{T}.Value">Value</see> of the specified <paramref name="validator"/> does contain all of the elements of the given <paramref name="elements"/> list, while the specified <paramref name="validator"/> is created using the <see cref="Condition.Requires{T}(T,string)">Requires</see> extension method.</exception>
        /// <exception cref="ArgumentNullException">Thrown when the <see cref="Validator{T}.Value">Value</see> of the specified <paramref name="validator"/> is a null reference and the specified <paramref name="elements"/> list is null or empty, while the specified <paramref name="validator"/> is created using the <see cref="Condition.Requires{T}(T,string)">Requires</see> extension method.</exception>
        /// <exception cref="PostconditionException">Thrown when the <see cref="Validator{T}.Value">Value</see> of the specified <paramref name="validator"/> does contain all of the elements of the given <paramref name="elements"/> list, while the specified <paramref name="validator"/> is created using the <see cref="Condition.Ensures{T}(T,string)">Ensures</see> extension method.</exception>
        public static Validator<TCollection> DoesNotContainAll<TCollection>(this Validator<TCollection> validator, IEnumerable elements) where TCollection : IEnumerable
        {
            if (CollectionExtensions.ContainsAll(validator.Value, elements))
            {
                Throw.CollectionShouldNotContainAllOf<TCollection>(validator, elements, null);
            }

            return validator;
        }

        /// <summary>
        /// Checks whether the given value does not contains all of the specified <paramref name="elements"/>.
        /// An exception is thrown otherwise. When the <paramref name="elements"/> collection is a null 
        /// reference or an empty list, the collection is considered to contain all of the specified (even if 
        /// the value itself is empty). When the given value is empty and the given <paramref name="elements"/>
        /// list isn't, the collection is considered to not contain all of the specified 
        /// <paramref name="elements"/>.
        /// </summary>
        /// <typeparam name="TCollection">The type of the value to check.</typeparam>
        /// <param name="validator">The <see cref="Validator{T}"/> that holds the value that has to be checked.</param>
        /// <param name="elements">The list of elements.</param>
        /// <param name="conditionDescription">
        /// The description of the condition that should hold. The string may hold the placeholder '{0}' for 
        /// the <see cref="Validator{T}.ArgumentName">ArgumentName</see>.
        /// </param>
        /// <returns>The specified <paramref name="validator"/> instance.</returns>
        /// <exception cref="ArgumentException">Thrown when the <see cref="Validator{T}.Value">Value</see> of the specified <paramref name="validator"/> does contain all of the elements of the given <paramref name="elements"/> list, while the specified <paramref name="validator"/> is created using the <see cref="Condition.Requires{T}(T,string)">Requires</see> extension method.</exception>
        /// <exception cref="ArgumentNullException">Thrown when the <see cref="Validator{T}.Value">Value</see> of the specified <paramref name="validator"/> is a null reference and the specified <paramref name="elements"/> list is null or empty, while the specified <paramref name="validator"/> is created using the <see cref="Condition.Requires{T}(T,string)">Requires</see> extension method.</exception>
        /// <exception cref="PostconditionException">Thrown when the <see cref="Validator{T}.Value">Value</see> of the specified <paramref name="validator"/> does contain all of the elements of the given <paramref name="elements"/> list, while the specified <paramref name="validator"/> is created using the <see cref="Condition.Ensures{T}(T,string)">Ensures</see> extension method.</exception>
        public static Validator<TCollection> DoesNotContainAll<TCollection>(this Validator<TCollection> validator, IEnumerable elements, string conditionDescription) where TCollection : IEnumerable
        {
            if (CollectionExtensions.ContainsAll(validator.Value, elements))
            {
                Throw.CollectionShouldNotContainAllOf<TCollection>(validator, elements, conditionDescription);
            }

            return validator;
        }

        /// <summary>
        /// Checks whether the given value has the number of elements as specified by 
        /// <paramref name="numberOfElements"/>. An exception is thrown otherwise. When the value is a null 
        /// reference, it is considered to have 0 elements.
        /// </summary>
        /// <typeparam name="TCollection">The type of the value to check.</typeparam>
        /// <param name="validator">The <see cref="Validator{T}"/> that holds the value that has to be checked.</param>
        /// <param name="numberOfElements">The number of elements the collection should contain.</param>
        /// <returns>The specified <paramref name="validator"/> instance.</returns>
        /// <exception cref="ArgumentException">Thrown when the <see cref="Validator{T}.Value">Value</see> of the specified <paramref name="validator"/> does not contain the number of elements as specified with the <paramref name="numberOfElements"/> argument, while the specified <paramref name="validator"/> is created using the <see cref="Condition.Requires{T}(T,string)">Requires</see> extension method.</exception>
        /// <exception cref="ArgumentNullException">Thrown when the <see cref="Validator{T}.Value">Value</see> of the specified <paramref name="validator"/> is a null reference, while <paramref name="numberOfElements"/> is bigger than 0, while the specified <paramref name="validator"/> is created using the <see cref="Condition.Requires{T}(T,string)">Requires</see> extension method.</exception>
        /// <exception cref="PostconditionException">Thrown when the <see cref="Validator{T}.Value">Value</see> of the specified <paramref name="validator"/> does not contain the number of elements as specified with the <paramref name="numberOfElements"/> argument, while the specified <paramref name="validator"/> is created using the <see cref="Condition.Ensures{T}(T,string)">Ensures</see> extension method.</exception>
        public static Validator<TCollection> HasLength<TCollection>(this Validator<TCollection> validator, int numberOfElements) where TCollection : IEnumerable
        {
            if (!CollectionExtensions.SequenceHasLength(validator.Value, numberOfElements))
            {
                Throw.CollectionShouldContainNumberOfElements<TCollection>(validator, numberOfElements, null);
            }

            return validator;
        }

        /// <summary>
        /// Checks whether the given value has the number of elements as specified by 
        /// <paramref name="numberOfElements"/>. An exception is thrown otherwise. When the value is a null 
        /// reference, it is considered to have 0 elements.
        /// </summary>
        /// <typeparam name="TCollection">The type of the value to check.</typeparam>
        /// <param name="validator">The <see cref="Validator{T}"/> that holds the value that has to be checked.</param>
        /// <param name="numberOfElements">The number of elements the collection should contain.</param>
        /// <param name="conditionDescription">
        /// The description of the condition that should hold. The string may hold the placeholder '{0}' for 
        /// the <see cref="Validator{T}.ArgumentName">ArgumentName</see>.
        /// </param>
        /// <returns>The specified <paramref name="validator"/> instance.</returns>
        /// <exception cref="ArgumentException">Thrown when the <see cref="Validator{T}.Value">Value</see> of the specified <paramref name="validator"/> does not contain the number of elements as specified with the <paramref name="numberOfElements"/> argument, while the specified <paramref name="validator"/> is created using the <see cref="Condition.Requires{T}(T,string)">Requires</see> extension method.</exception>
        /// <exception cref="ArgumentNullException">Thrown when the <see cref="Validator{T}.Value">Value</see> of the specified <paramref name="validator"/> is a null reference, while <paramref name="numberOfElements"/> is bigger than 0, while the specified <paramref name="validator"/> is created using the <see cref="Condition.Requires{T}(T,string)">Requires</see> extension method.</exception>
        /// <exception cref="PostconditionException">Thrown when the <see cref="Validator{T}.Value">Value</see> of the specified <paramref name="validator"/> does not contain the number of elements as specified with the <paramref name="numberOfElements"/> argument, while the specified <paramref name="validator"/> is created using the <see cref="Condition.Ensures{T}(T,string)">Ensures</see> extension method.</exception>
        public static Validator<TCollection> HasLength<TCollection>(this Validator<TCollection> validator, int numberOfElements, string conditionDescription) where TCollection : IEnumerable
        {
            if (!CollectionExtensions.SequenceHasLength(validator.Value, numberOfElements))
            {
                Throw.CollectionShouldContainNumberOfElements<TCollection>(validator, numberOfElements, conditionDescription);
            }

            return validator;
        }

        /// <summary>
        /// Checks whether the number of elements in the given value, is different from the specified 
        /// <paramref name="numberOfElements"/> argument. An exception is thrown otherwise. When the value is 
        /// a null reference, it is considered to have 0 elements.
        /// </summary>
        /// <typeparam name="TCollection">The type of the value to check.</typeparam>
        /// <param name="validator">The <see cref="Validator{T}"/> that holds the value that has to be checked.</param>
        /// <param name="numberOfElements">The number of elements the collection should not contain.</param>
        /// <returns>The specified <paramref name="validator"/> instance.</returns>
        /// <exception cref="ArgumentException">Thrown when the <see cref="Validator{T}.Value">Value</see> of the specified <paramref name="validator"/> does contain the number of elements as specified with the <paramref name="numberOfElements"/> argument, while the specified <paramref name="validator"/> is created using the <see cref="Condition.Requires{T}(T,string)">Requires</see> extension method.</exception>
        /// <exception cref="ArgumentNullException">Thrown when the <see cref="Validator{T}.Value">Value</see> of the specified <paramref name="validator"/> is a null reference and the <paramref name="numberOfElements"/> equals 0, while the specified <paramref name="validator"/> is created using the <see cref="Condition.Requires{T}(T,string)">Requires</see> extension method.</exception>
        /// <exception cref="PostconditionException">Thrown when the <see cref="Validator{T}.Value">Value</see> of the specified <paramref name="validator"/> does contain the number of elements as specified with the <paramref name="numberOfElements"/> argument, while the specified <paramref name="validator"/> is created using the <see cref="Condition.Ensures{T}(T,string)">Ensures</see> extension method.</exception>
        public static Validator<TCollection> DoesNotHaveLength<TCollection>(this Validator<TCollection> validator, int numberOfElements) where TCollection : IEnumerable
        {
            if (CollectionExtensions.SequenceHasLength(validator.Value, numberOfElements))
            {
                Throw.CollectionShouldNotContainNumberOfElements<TCollection>(validator, numberOfElements, null);
            }

            return validator;
        }

        /// <summary>
        /// Checks whether the number of elements in the given value, is different from the specified 
        /// <paramref name="numberOfElements"/> argument. An exception is thrown otherwise. When the value is 
        /// a null reference, it is considered to have 0 elements.
        /// </summary>
        /// <typeparam name="TCollection">The type of the value to check.</typeparam>
        /// <param name="validator">The <see cref="Validator{T}"/> that holds the value that has to be checked.</param>
        /// <param name="numberOfElements">The number of elements the collection should not contain.</param>
        /// <param name="conditionDescription">
        /// The description of the condition that should hold. The string may hold the placeholder '{0}' for 
        /// the <see cref="Validator{T}.ArgumentName">ArgumentName</see>.
        /// </param>
        /// <returns>The specified <paramref name="validator"/> instance.</returns>
        /// <exception cref="ArgumentException">Thrown when the <see cref="Validator{T}.Value">Value</see> of the specified <paramref name="validator"/> does contain the number of elements as specified with the <paramref name="numberOfElements"/> argument, while the specified <paramref name="validator"/> is created using the <see cref="Condition.Requires{T}(T,string)">Requires</see> extension method.</exception>
        /// <exception cref="ArgumentNullException">Thrown when the <see cref="Validator{T}.Value">Value</see> of the specified <paramref name="validator"/> is a null reference and the <paramref name="numberOfElements"/> equals 0, while the specified <paramref name="validator"/> is created using the <see cref="Condition.Requires{T}(T,string)">Requires</see> extension method.</exception>
        /// <exception cref="PostconditionException">Thrown when the <see cref="Validator{T}.Value">Value</see> of the specified <paramref name="validator"/> does contain the number of elements as specified with the <paramref name="numberOfElements"/> argument, while the specified <paramref name="validator"/> is created using the <see cref="Condition.Ensures{T}(T,string)">Ensures</see> extension method.</exception>
        public static Validator<TCollection> DoesNotHaveLength<TCollection>(this Validator<TCollection> validator, int numberOfElements, string conditionDescription) where TCollection : IEnumerable
        {
            if (CollectionExtensions.SequenceHasLength(validator.Value, numberOfElements))
            {
                Throw.CollectionShouldNotContainNumberOfElements<TCollection>(validator, numberOfElements, conditionDescription);
            }

            return validator;
        }

        /// <summary>
        /// Checks whether the number of elements in the given value, is less than the specified
        /// <paramref name="numberOfElements"/> argument. An exception is thrown otherwise. When the value is
        /// a null reference, it is considered to have 0 elements.
        /// </summary>
        /// <typeparam name="TCollection">The type of the value to check.</typeparam>
        /// <param name="validator">The <see cref="Validator{T}"/> that holds the value that has to be checked.</param>
        /// <param name="numberOfElements">The collection must contain less elements than this value.</param>
        /// <returns>The specified <paramref name="validator"/> instance.</returns>
        /// <exception cref="ArgumentException">Thrown when the <see cref="Validator{T}.Value">Value</see> of the specified <paramref name="validator"/> contains more or the same amount of elements as specified by the <paramref name="numberOfElements"/> argument, while the specified <paramref name="validator"/> is created using the <see cref="Condition.Requires{T}(T,string)">Requires</see> extension method.</exception>
        /// <exception cref="ArgumentNullException">Thrown when the <see cref="Validator{T}.Value">Value</see> of the specified <paramref name="validator"/> is a null reference and the <paramref name="numberOfElements"/> is smaller or equal to 0, while the specified <paramref name="validator"/> is created using the <see cref="Condition.Requires{T}(T,string)">Requires</see> extension method.</exception>
        /// <exception cref="PostconditionException">Thrown when the <see cref="Validator{T}.Value">Value</see> of the specified <paramref name="validator"/> contains more or the same amount of elements as specified by the <paramref name="numberOfElements"/> argument, while the specified <paramref name="validator"/> is created using the <see cref="Condition.Ensures{T}(T,string)">Ensures</see> extension method.</exception>
        public static Validator<TCollection> IsShorterThan<TCollection>(this Validator<TCollection> validator, int numberOfElements) where TCollection : IEnumerable
        {
            if (!CollectionExtensions.SequenceIsShorterThan(validator.Value, numberOfElements))
            {
                Throw.CollectionShouldContainLessThan<TCollection>(validator, numberOfElements, null);
            }

            return validator;
        }

        /// <summary>
        /// Checks whether the number of elements in the given value, is less than the specified
        /// <paramref name="numberOfElements"/> argument. An exception is thrown otherwise. When the value is
        /// a null reference, it is considered to have 0 elements.
        /// </summary>
        /// <typeparam name="TCollection">The type of the value to check.</typeparam>
        /// <param name="validator">The <see cref="Validator{T}"/> that holds the value that has to be checked.</param>
        /// <param name="numberOfElements">The collection must contain less elements than this value.</param>
        /// <param name="conditionDescription">
        /// The description of the condition that should hold. The string may hold the placeholder '{0}' for 
        /// the <see cref="Validator{T}.ArgumentName">ArgumentName</see>.
        /// </param>
        /// <returns>The specified <paramref name="validator"/> instance.</returns>
        /// <exception cref="ArgumentException">Thrown when the <see cref="Validator{T}.Value">Value</see> of the specified <paramref name="validator"/> contains more or the same amount of elements as specified by the <paramref name="numberOfElements"/> argument, while the specified <paramref name="validator"/> is created using the <see cref="Condition.Requires{T}(T,string)">Requires</see> extension method.</exception>
        /// <exception cref="ArgumentNullException">Thrown when the <see cref="Validator{T}.Value">Value</see> of the specified <paramref name="validator"/> is a null reference and the <paramref name="numberOfElements"/> is smaller or equal to 0, while the specified <paramref name="validator"/> is created using the <see cref="Condition.Requires{T}(T,string)">Requires</see> extension method.</exception>
        /// <exception cref="PostconditionException">Thrown when the <see cref="Validator{T}.Value">Value</see> of the specified <paramref name="validator"/> contains more or the same amount of elements as specified by the <paramref name="numberOfElements"/> argument, while the specified <paramref name="validator"/> is created using the <see cref="Condition.Ensures{T}(T,string)">Ensures</see> extension method.</exception>
        public static Validator<TCollection> IsShorterThan<TCollection>(this Validator<TCollection> validator, int numberOfElements, string conditionDescription) where TCollection : IEnumerable
        {
            if (!CollectionExtensions.SequenceIsShorterThan(validator.Value, numberOfElements))
            {
                Throw.CollectionShouldContainLessThan<TCollection>(validator, numberOfElements, conditionDescription);
            }

            return validator;
        }

        /// <summary>
        /// Checks whether the number of elements in the given value, is not less than the specified
        /// <paramref name="numberOfElements"/> argument. An exception is thrown otherwise. When the value is
        /// a null reference, it is considered to have 0 elements.
        /// </summary>
        /// <typeparam name="TCollection">The type of the value to check.</typeparam>
        /// <param name="validator">The <see cref="Validator{T}"/> that holds the value that has to be checked.</param>
        /// <param name="numberOfElements">The collection must contain the same amount or more elements than this value.</param>
        /// <returns>The specified <paramref name="validator"/> instance.</returns>
        /// <exception cref="ArgumentException">Thrown when the <see cref="Validator{T}.Value">Value</see> of the specified <paramref name="validator"/> contains less elements as specified by the <paramref name="numberOfElements"/> argument, while the specified <paramref name="validator"/> is created using the <see cref="Condition.Requires{T}(T,string)">Requires</see> extension method.</exception>
        /// <exception cref="ArgumentNullException">Thrown when the <see cref="Validator{T}.Value">Value</see> of the specified <paramref name="validator"/> is a null reference and the <paramref name="numberOfElements"/> is greater or equal to 0, while the specified <paramref name="validator"/> is created using the <see cref="Condition.Requires{T}(T,string)">Requires</see> extension method.</exception>
        /// <exception cref="PostconditionException">Thrown when the <see cref="Validator{T}.Value">Value</see> of the specified <paramref name="validator"/> contains less elements as specified by the <paramref name="numberOfElements"/> argument, while the specified <paramref name="validator"/> is created using the <see cref="Condition.Ensures{T}(T,string)">Ensures</see> extension method.</exception>
        public static Validator<TCollection> IsNotShorterThan<TCollection>(this Validator<TCollection> validator, int numberOfElements) where TCollection : IEnumerable
        {
            if (CollectionExtensions.SequenceIsShorterThan(validator.Value, numberOfElements))
            {
                Throw.CollectionShouldNotContainLessThan<TCollection>(validator, numberOfElements, null);
            }

            return validator;
        }

        /// <summary>
        /// Checks whether the number of elements in the given value, is not less than the specified
        /// <paramref name="numberOfElements"/> argument. An exception is thrown otherwise. When the value is
        /// a null reference, it is considered to have 0 elements.
        /// </summary>
        /// <typeparam name="TCollection">The type of the value to check.</typeparam>
        /// <param name="validator">The <see cref="Validator{T}"/> that holds the value that has to be checked.</param>
        /// <param name="numberOfElements">The collection must contain the same amount or more elements than this value.</param>
        /// <param name="conditionDescription">
        /// The description of the condition that should hold. The string may hold the placeholder '{0}' for 
        /// the <see cref="Validator{T}.ArgumentName">ArgumentName</see>.
        /// </param>
        /// <returns>The specified <paramref name="validator"/> instance.</returns>
        /// <exception cref="ArgumentException">Thrown when the <see cref="Validator{T}.Value">Value</see> of the specified <paramref name="validator"/> contains less elements as specified by the <paramref name="numberOfElements"/> argument, while the specified <paramref name="validator"/> is created using the <see cref="Condition.Requires{T}(T,string)">Requires</see> extension method.</exception>
        /// <exception cref="ArgumentNullException">Thrown when the <see cref="Validator{T}.Value">Value</see> of the specified <paramref name="validator"/> is a null reference and the <paramref name="numberOfElements"/> is greater or equal to 0, while the specified <paramref name="validator"/> is created using the <see cref="Condition.Requires{T}(T,string)">Requires</see> extension method.</exception>
        /// <exception cref="PostconditionException">Thrown when the <see cref="Validator{T}.Value">Value</see> of the specified <paramref name="validator"/> contains less elements as specified by the <paramref name="numberOfElements"/> argument, while the specified <paramref name="validator"/> is created using the <see cref="Condition.Ensures{T}(T,string)">Ensures</see> extension method.</exception>
        public static Validator<TCollection> IsNotShorterThan<TCollection>(this Validator<TCollection> validator, int numberOfElements, string conditionDescription) where TCollection : IEnumerable
        {
            if (CollectionExtensions.SequenceIsShorterThan(validator.Value, numberOfElements))
            {
                Throw.CollectionShouldNotContainLessThan<TCollection>(validator, numberOfElements, conditionDescription);
            }

            return validator;
        }

        /// <summary>
        /// Checks whether the number of elements in the given value, is less than or equal to the specified
        /// <paramref name="numberOfElements"/> argument. An exception is thrown otherwise. When the value is
        /// a null reference, it is considered to have 0 elements.
        /// </summary>
        /// <typeparam name="TCollection">The type of the value to check.</typeparam>
        /// <param name="validator">The <see cref="Validator{T}"/> that holds the value that has to be checked.</param>
        /// <param name="numberOfElements">The collection must contain the same amount or less elements than this value.</param>
        /// <returns>The specified <paramref name="validator"/> instance.</returns>
        /// <exception cref="ArgumentException">Thrown when the <see cref="Validator{T}.Value">Value</see> of the specified <paramref name="validator"/> contains more elements than specified by the <paramref name="numberOfElements"/> argument, while the specified <paramref name="validator"/> is created using the <see cref="Condition.Requires{T}(T,string)">Requires</see> extension method.</exception>
        /// <exception cref="ArgumentNullException">Thrown when the <see cref="Validator{T}.Value">Value</see> of the specified <paramref name="validator"/> is a null reference and the <paramref name="numberOfElements"/> is lass than 0, while the specified <paramref name="validator"/> is created using the <see cref="Condition.Requires{T}(T,string)">Requires</see> extension method.</exception>
        /// <exception cref="PostconditionException">Thrown when the <see cref="Validator{T}.Value">Value</see> of the specified <paramref name="validator"/> contains more elements than specified by the <paramref name="numberOfElements"/> argument, while the specified <paramref name="validator"/> is created using the <see cref="Condition.Ensures{T}(T,string)">Ensures</see> extension method.</exception>
        public static Validator<TCollection> IsShorterOrEqual<TCollection>(this Validator<TCollection> validator, int numberOfElements) where TCollection : IEnumerable
        {
            if (!CollectionExtensions.SequenceIsShorterOrEqual(validator.Value, numberOfElements))
            {
                Throw.CollectionShouldContainLessOrEqual<TCollection>(validator, numberOfElements, null);
            }

            return validator;
        }

        /// <summary>
        /// Checks whether the number of elements in the given value, is less than or equal to the specified
        /// <paramref name="numberOfElements"/> argument. An exception is thrown otherwise. When the value is
        /// a null reference, it is considered to have 0 elements.
        /// </summary>
        /// <typeparam name="TCollection">The type of the value to check.</typeparam>
        /// <param name="validator">The <see cref="Validator{T}"/> that holds the value that has to be checked.</param>
        /// <param name="numberOfElements">The collection must contain the same amount or less elements than this value.</param>
        /// <param name="conditionDescription">
        /// The description of the condition that should hold. The string may hold the placeholder '{0}' for 
        /// the <see cref="Validator{T}.ArgumentName">ArgumentName</see>.
        /// </param>
        /// <returns>The specified <paramref name="validator"/> instance.</returns>
        /// <exception cref="ArgumentException">Thrown when the <see cref="Validator{T}.Value">Value</see> of the specified <paramref name="validator"/> contains more elements than specified by the <paramref name="numberOfElements"/> argument, while the specified <paramref name="validator"/> is created using the <see cref="Condition.Requires{T}(T,string)">Requires</see> extension method.</exception>
        /// <exception cref="ArgumentNullException">Thrown when the <see cref="Validator{T}.Value">Value</see> of the specified <paramref name="validator"/> is a null reference and the <paramref name="numberOfElements"/> is lass than 0, while the specified <paramref name="validator"/> is created using the <see cref="Condition.Requires{T}(T,string)">Requires</see> extension method.</exception>
        /// <exception cref="PostconditionException">Thrown when the <see cref="Validator{T}.Value">Value</see> of the specified <paramref name="validator"/> contains more elements than specified by the <paramref name="numberOfElements"/> argument, while the specified <paramref name="validator"/> is created using the <see cref="Condition.Ensures{T}(T,string)">Ensures</see> extension method.</exception> 
        public static Validator<TCollection> IsShorterOrEqual<TCollection>(this Validator<TCollection> validator, int numberOfElements, string conditionDescription) where TCollection : IEnumerable
        {
            if (!CollectionExtensions.SequenceIsShorterOrEqual(validator.Value, numberOfElements))
            {
                Throw.CollectionShouldContainLessOrEqual<TCollection>(validator, numberOfElements, conditionDescription);
            }

            return validator;
        }

        /// <summary>
        /// Checks whether the number of elements in the given value, is not less than and not equals to the 
        /// specified <paramref name="numberOfElements"/> argument. An exception is thrown otherwise. When the
        /// value is a null reference, it is considered to have 0 elements.
        /// </summary>
        /// <typeparam name="TCollection">The type of the value to check.</typeparam>
        /// <param name="validator">The <see cref="Validator{T}"/> that holds the value that has to be checked.</param>
        /// <param name="numberOfElements">The collection must contain more elements than this value.</param>
        /// <returns>The specified <paramref name="validator"/> instance.</returns>
        /// <exception cref="ArgumentException">Thrown when the <see cref="Validator{T}.Value">Value</see> of the specified <paramref name="validator"/> contains less or the same amount of elements as specified by the <paramref name="numberOfElements"/> argument, while the specified <paramref name="validator"/> is created using the <see cref="Condition.Requires{T}(T,string)">Requires</see> extension method.</exception>
        /// <exception cref="ArgumentNullException">Thrown when the <see cref="Validator{T}.Value">Value</see> of the specified <paramref name="validator"/> is a null reference and the <paramref name="numberOfElements"/> is greater or equal to 0, while the specified <paramref name="validator"/> is created using the <see cref="Condition.Requires{T}(T,string)">Requires</see> extension method.</exception>
        /// <exception cref="PostconditionException">Thrown when the <see cref="Validator{T}.Value">Value</see> of the specified <paramref name="validator"/> contains less or the same amount of elements as specified by the <paramref name="numberOfElements"/> argument, while the specified <paramref name="validator"/> is created using the <see cref="Condition.Ensures{T}(T,string)">Ensures</see> extension method.</exception>
        public static Validator<TCollection> IsNotShorterOrEqual<TCollection>(this Validator<TCollection> validator, int numberOfElements) where TCollection : IEnumerable
        {
            if (CollectionExtensions.SequenceIsShorterOrEqual(validator.Value, numberOfElements))
            {
                Throw.CollectionShouldNotContainLessOrEqual<TCollection>(validator, numberOfElements, null);
            }

            return validator;
        }

        /// <summary>
        /// Checks whether the number of elements in the given value, is not less than and not equals to the 
        /// specified <paramref name="numberOfElements"/> argument. An exception is thrown otherwise. When the
        /// value is a null reference, it is considered to have 0 elements.
        /// </summary>
        /// <typeparam name="TCollection">The type of the value to check.</typeparam>
        /// <param name="validator">The <see cref="Validator{T}"/> that holds the value that has to be checked.</param>
        /// <param name="numberOfElements">The collection must contain more elements than this value.</param>
        /// <param name="conditionDescription">
        /// The description of the condition that should hold. The string may hold the placeholder '{0}' for 
        /// the <see cref="Validator{T}.ArgumentName">ArgumentName</see>.
        /// </param>
        /// <returns>The specified <paramref name="validator"/> instance.</returns>
        /// <exception cref="ArgumentException">Thrown when the <see cref="Validator{T}.Value">Value</see> of the specified <paramref name="validator"/> contains less or the same amount of elements as specified by the <paramref name="numberOfElements"/> argument, while the specified <paramref name="validator"/> is created using the <see cref="Condition.Requires{T}(T,string)">Requires</see> extension method.</exception>
        /// <exception cref="ArgumentNullException">Thrown when the <see cref="Validator{T}.Value">Value</see> of the specified <paramref name="validator"/> is a null reference and the <paramref name="numberOfElements"/> is greater or equal to 0, while the specified <paramref name="validator"/> is created using the <see cref="Condition.Requires{T}(T,string)">Requires</see> extension method.</exception>
        /// /// <exception cref="PostconditionException">Thrown when the <see cref="Validator{T}.Value">Value</see> of the specified <paramref name="validator"/> contains less or the same amount of elements as specified by the <paramref name="numberOfElements"/> argument, while the specified <paramref name="validator"/> is created using the <see cref="Condition.Ensures{T}(T,string)">Ensures</see> extension method.</exception> 
        public static Validator<TCollection> IsNotShorterOrEqual<TCollection>(this Validator<TCollection> validator, int numberOfElements, string conditionDescription) where TCollection : IEnumerable
        {
            if (CollectionExtensions.SequenceIsShorterOrEqual(validator.Value, numberOfElements))
            {
                Throw.CollectionShouldNotContainLessOrEqual<TCollection>(validator, numberOfElements, conditionDescription);
            }

            return validator;
        }

        /// <summary>
        /// Checks whether the number of elements in the given value, is more than the specified
        /// <paramref name="numberOfElements"/> argument. An exception is thrown otherwise. When the value is
        /// a null reference, it is considered to have 0 elements.
        /// </summary>
        /// <typeparam name="TCollection">The type of the value to check.</typeparam>
        /// <param name="validator">The <see cref="Validator{T}"/> that holds the value that has to be checked.</param>
        /// <param name="numberOfElements">The collection must contain the same amount or less elements than this value.</param>
        /// <returns>The specified <paramref name="validator"/> instance.</returns>
        /// <exception cref="ArgumentException">Thrown when the <see cref="Validator{T}.Value">Value</see> of the specified <paramref name="validator"/> contains less or the same amount of elements as specified by the <paramref name="numberOfElements"/> argument, while the specified <paramref name="validator"/> is created using the <see cref="Condition.Requires{T}(T,string)">Requires</see> extension method.</exception>
        /// <exception cref="ArgumentNullException">Thrown when the <see cref="Validator{T}.Value">Value</see> of the specified <paramref name="validator"/> is a null reference and the <paramref name="numberOfElements"/> is greater or equal to 0, while the specified <paramref name="validator"/> is created using the <see cref="Condition.Requires{T}(T,string)">Requires</see> extension method.</exception>
        /// <exception cref="PostconditionException">Thrown when the <see cref="Validator{T}.Value">Value</see> of the specified <paramref name="validator"/> contains less or the same amount of elements as specified by the <paramref name="numberOfElements"/> argument, while the specified <paramref name="validator"/> is created using the <see cref="Condition.Ensures{T}(T,string)">Ensures</see> extension method.</exception>
        public static Validator<TCollection> IsLongerThan<TCollection>(this Validator<TCollection> validator, int numberOfElements) where TCollection : IEnumerable
        {
            if (!CollectionExtensions.SequenceIsLongerThan(validator.Value, numberOfElements))
            {
                Throw.CollectionShouldContainMoreThan<TCollection>(validator, numberOfElements, null);
            }

            return validator;
        }

        /// <summary>
        /// Checks whether the number of elements in the given value, is more than the specified
        /// <paramref name="numberOfElements"/> argument. An exception is thrown otherwise. When the value is
        /// a null reference, it is considered to have 0 elements.
        /// </summary>
        /// <typeparam name="TCollection">The type of the value to check.</typeparam>
        /// <param name="validator">The <see cref="Validator{T}"/> that holds the value that has to be checked.</param>
        /// <param name="numberOfElements">The collection must contain the same amount or less elements than this value.</param>
        /// <param name="conditionDescription">
        /// The description of the condition that should hold. The string may hold the placeholder '{0}' for 
        /// the <see cref="Validator{T}.ArgumentName">ArgumentName</see>.
        /// </param>
        /// <returns>The specified <paramref name="validator"/> instance.</returns>
        /// <exception cref="ArgumentException">Thrown when the <see cref="Validator{T}.Value">Value</see> of the specified <paramref name="validator"/> contains less or the same amount of elements as specified by the <paramref name="numberOfElements"/> argument, while the specified <paramref name="validator"/> is created using the <see cref="Condition.Requires{T}(T,string)">Requires</see> extension method.</exception>
        /// <exception cref="ArgumentNullException">Thrown when the <see cref="Validator{T}.Value">Value</see> of the specified <paramref name="validator"/> is a null reference and the <paramref name="numberOfElements"/> is greater or equal to 0, while the specified <paramref name="validator"/> is created using the <see cref="Condition.Requires{T}(T,string)">Requires</see> extension method.</exception>
        /// <exception cref="PostconditionException">Thrown when the <see cref="Validator{T}.Value">Value</see> of the specified <paramref name="validator"/> contains less or the same amount of elements as specified by the <paramref name="numberOfElements"/> argument, while the specified <paramref name="validator"/> is created using the <see cref="Condition.Ensures{T}(T,string)">Ensures</see> extension method.</exception>
        public static Validator<TCollection> IsLongerThan<TCollection>(this Validator<TCollection> validator, int numberOfElements, string conditionDescription) where TCollection : IEnumerable
        {
            if (!CollectionExtensions.SequenceIsLongerThan(validator.Value, numberOfElements))
            {
                Throw.CollectionShouldContainMoreThan<TCollection>(validator, numberOfElements, conditionDescription);
            }

            return validator;
        }

        /// <summary>
        /// Checks whether the number of elements in the given value, is not more than the specified
        /// <paramref name="numberOfElements"/> argument. An exception is thrown otherwise. When the value is
        /// a null reference, it is considered to have 0 elements.
        /// </summary>
        /// <typeparam name="TCollection">The type of the value to check.</typeparam>
        /// <param name="validator">The <see cref="Validator{T}"/> that holds the value that has to be checked.</param>
        /// <param name="numberOfElements">The collection must contain the same amount or less elements than this value.</param>
        /// <returns>The specified <paramref name="validator"/> instance.</returns>
        /// <exception cref="ArgumentException">Thrown when the <see cref="Validator{T}.Value">Value</see> of the specified <paramref name="validator"/> contains more elements than specified by the <paramref name="numberOfElements"/> argument, while the specified <paramref name="validator"/> is created using the <see cref="Condition.Requires{T}(T,string)">Requires</see> extension method.</exception>
        /// <exception cref="ArgumentNullException">Thrown when the <see cref="Validator{T}.Value">Value</see> of the specified <paramref name="validator"/> is a null reference and the <paramref name="numberOfElements"/> is smaller than 0, while the specified <paramref name="validator"/> is created using the <see cref="Condition.Requires{T}(T,string)">Requires</see> extension method.</exception>
        /// <exception cref="PostconditionException">Thrown when the <see cref="Validator{T}.Value">Value</see> of the specified <paramref name="validator"/> contains more elements than specified by the <paramref name="numberOfElements"/> argument, while the specified <paramref name="validator"/> is created using the <see cref="Condition.Ensures{T}(T,string)">Ensures</see> extension method.</exception>
        public static Validator<TCollection> IsNotLongerThan<TCollection>(this Validator<TCollection> validator, int numberOfElements) where TCollection : IEnumerable
        {
            if (CollectionExtensions.SequenceIsLongerThan(validator.Value, numberOfElements))
            {
                Throw.CollectionShouldNotContainMoreThan<TCollection>(validator, numberOfElements, null);
            }

            return validator;
        }

        /// <summary>
        /// Checks whether the number of elements in the given value, is not more than the specified
        /// <paramref name="numberOfElements"/> argument. An exception is thrown otherwise. When the value is
        /// a null reference, it is considered to have 0 elements.
        /// </summary>
        /// <typeparam name="TCollection">The type of the value to check.</typeparam>
        /// <param name="validator">The <see cref="Validator{T}"/> that holds the value that has to be checked.</param>
        /// <param name="numberOfElements">The collection must contain the same amount or less elements than this value.</param>
        /// <param name="conditionDescription">
        /// The description of the condition that should hold. The string may hold the placeholder '{0}' for 
        /// the <see cref="Validator{T}.ArgumentName">ArgumentName</see>.
        /// </param>
        /// <returns>The specified <paramref name="validator"/> instance.</returns>
        /// <exception cref="ArgumentException">Thrown when the <see cref="Validator{T}.Value">Value</see> of the specified <paramref name="validator"/> contains more elements than specified by the <paramref name="numberOfElements"/> argument, while the specified <paramref name="validator"/> is created using the <see cref="Condition.Requires{T}(T,string)">Requires</see> extension method.</exception>
        /// <exception cref="ArgumentNullException">Thrown when the <see cref="Validator{T}.Value">Value</see> of the specified <paramref name="validator"/> is a null reference and the <paramref name="numberOfElements"/> is smaller than 0, while the specified <paramref name="validator"/> is created using the <see cref="Condition.Requires{T}(T,string)">Requires</see> extension method.</exception>
        /// <exception cref="PostconditionException">Thrown when the <see cref="Validator{T}.Value">Value</see> of the specified <paramref name="validator"/> contains more elements than specified by the <paramref name="numberOfElements"/> argument, while the specified <paramref name="validator"/> is created using the <see cref="Condition.Ensures{T}(T,string)">Ensures</see> extension method.</exception>
        public static Validator<TCollection> IsNotLongerThan<TCollection>(this Validator<TCollection> validator, int numberOfElements, string conditionDescription) where TCollection : IEnumerable
        {
            if (CollectionExtensions.SequenceIsLongerThan(validator.Value, numberOfElements))
            {
                Throw.CollectionShouldNotContainMoreThan<TCollection>(validator, numberOfElements, conditionDescription);
            }

            return validator;
        }

        /// <summary>
        /// Checks whether the number of elements in the given value, is more than or equal to the specified
        /// <paramref name="numberOfElements"/> argument. An exception is thrown otherwise. When the value is
        /// a null reference, it is considered to have 0 elements.
        /// </summary>
        /// <typeparam name="TCollection">The type of the value to check.</typeparam>
        /// <param name="validator">The <see cref="Validator{T}"/> that holds the value that has to be checked.</param>
        /// <param name="numberOfElements">The collection must contain the same amount or more elements than this value.</param>
        /// <returns>The specified <paramref name="validator"/> instance.</returns>
        /// <exception cref="ArgumentException">Thrown when the <see cref="Validator{T}.Value">Value</see> of the specified <paramref name="validator"/> contains less than specified by the <paramref name="numberOfElements"/> argument, while the specified <paramref name="validator"/> is created using the <see cref="Condition.Requires{T}(T,string)">Requires</see> extension method.</exception>
        /// <exception cref="ArgumentNullException">Thrown when the <see cref="Validator{T}.Value">Value</see> of the specified <paramref name="validator"/> is a null reference and the <paramref name="numberOfElements"/> is greater than 0, while the specified <paramref name="validator"/> is created using the <see cref="Condition.Requires{T}(T,string)">Requires</see> extension method.</exception>
        /// <exception cref="PostconditionException">Thrown when the <see cref="Validator{T}.Value">Value</see> of the specified <paramref name="validator"/> contains less than specified by the <paramref name="numberOfElements"/> argument, while the specified <paramref name="validator"/> is created using the <see cref="Condition.Ensures{T}(T,string)">Ensures</see> extension method.</exception>
        public static Validator<TCollection> IsLongerOrEqual<TCollection>(this Validator<TCollection> validator, int numberOfElements) where TCollection : IEnumerable
        {
            if (!CollectionExtensions.SequenceIsLongerOrEqual(validator.Value, numberOfElements))
            {
                Throw.CollectionShouldContainMoreOrEqual<TCollection>(validator, numberOfElements, null);
            }

            return validator;
        }

        /// <summary>
        /// Checks whether the number of elements in the given value, is more than or equal to the specified
        /// <paramref name="numberOfElements"/> argument. An exception is thrown otherwise. When the value is
        /// a null reference, it is considered to have 0 elements.
        /// </summary>
        /// <typeparam name="TCollection">The type of the value to check.</typeparam>
        /// <param name="validator">The <see cref="Validator{T}"/> that holds the value that has to be checked.</param>
        /// <param name="numberOfElements">The collection must contain the same amount or more elements than this value.</param>
        /// <param name="conditionDescription">
        /// The description of the condition that should hold. The string may hold the placeholder '{0}' for 
        /// the <see cref="Validator{T}.ArgumentName">ArgumentName</see>.
        /// </param>
        /// <returns>The specified <paramref name="validator"/> instance.</returns>
        /// <exception cref="ArgumentException">Thrown when the <see cref="Validator{T}.Value">Value</see> of the specified <paramref name="validator"/> contains less than specified by the <paramref name="numberOfElements"/> argument, while the specified <paramref name="validator"/> is created using the <see cref="Condition.Requires{T}(T,string)">Requires</see> extension method.</exception>
        /// <exception cref="ArgumentNullException">Thrown when the <see cref="Validator{T}.Value">Value</see> of the specified <paramref name="validator"/> is a null reference and the <paramref name="numberOfElements"/> is greater than 0, while the specified <paramref name="validator"/> is created using the <see cref="Condition.Requires{T}(T,string)">Requires</see> extension method.</exception>
        /// <exception cref="PostconditionException">Thrown when the <see cref="Validator{T}.Value">Value</see> of the specified <paramref name="validator"/> contains less than specified by the <paramref name="numberOfElements"/> argument, while the specified <paramref name="validator"/> is created using the <see cref="Condition.Ensures{T}(T,string)">Ensures</see> extension method.</exception>
        public static Validator<TCollection> IsLongerOrEqual<TCollection>(this Validator<TCollection> validator, int numberOfElements, string conditionDescription) where TCollection : IEnumerable
        {
            if (!CollectionExtensions.SequenceIsLongerOrEqual(validator.Value, numberOfElements))
            {
                Throw.CollectionShouldContainMoreOrEqual<TCollection>(validator, numberOfElements, conditionDescription);
            }

            return validator;
        }

        /// <summary>
        /// Checks whether the number of elements in the given value, is not more than and not equal to the 
        /// specified <paramref name="numberOfElements"/> argument. An exception is thrown otherwise. When the
        /// value is a null reference, it is considered to have 0 elements.
        /// </summary>
        /// <typeparam name="TCollection">The type of the value to check.</typeparam>
        /// <param name="validator">The <see cref="Validator{T}"/> that holds the value that has to be checked.</param>
        /// <param name="numberOfElements">The collection must contain less elements than this value.</param>
        /// <returns>The specified <paramref name="validator"/> instance.</returns>
        /// <exception cref="ArgumentException">Thrown when the <see cref="Validator{T}.Value">Value</see> of the specified <paramref name="validator"/> contains more or the same amount of elements as specified by the <paramref name="numberOfElements"/> argument, while the specified <paramref name="validator"/> is created using the <see cref="Condition.Requires{T}(T,string)">Requires</see> extension method.</exception>
        /// <exception cref="ArgumentNullException">Thrown when the <see cref="Validator{T}.Value">Value</see> of the specified <paramref name="validator"/> is a null reference and the <paramref name="numberOfElements"/> is smaller or equal to 0, while the specified <paramref name="validator"/> is created using the <see cref="Condition.Requires{T}(T,string)">Requires</see> extension method.</exception>
        /// <exception cref="PostconditionException">Thrown when the <see cref="Validator{T}.Value">Value</see> of the specified <paramref name="validator"/> contains more or the same amount of elements as specified by the <paramref name="numberOfElements"/> argument, while the specified <paramref name="validator"/> is created using the <see cref="Condition.Ensures{T}(T,string)">Ensures</see> extension method.</exception>
        public static Validator<TCollection> IsNotLongerOrEqual<TCollection>(this Validator<TCollection> validator, int numberOfElements) where TCollection : IEnumerable
        {
            if (CollectionExtensions.SequenceIsLongerOrEqual(validator.Value, numberOfElements))
            {
                Throw.CollectionShouldNotContainMoreOrEqual<TCollection>(validator, numberOfElements, null);
            }

            return validator;
        }

        /// <summary>
        /// Checks whether the number of elements in the given value, is not more than and not equal to the 
        /// specified <paramref name="numberOfElements"/> argument. An exception is thrown otherwise. When the
        /// value is a null reference, it is considered to have 0 elements.
        /// </summary>
        /// <typeparam name="TCollection">The type of the value to check.</typeparam>
        /// <param name="validator">The <see cref="Validator{T}"/> that holds the value that has to be checked.</param>
        /// <param name="numberOfElements">The collection must contain less elements than this value.</param>
        /// <param name="conditionDescription">
        /// The description of the condition that should hold. The string may hold the placeholder '{0}' for 
        /// the <see cref="Validator{T}.ArgumentName">ArgumentName</see>.
        /// </param>
        /// <returns>The specified <paramref name="validator"/> instance.</returns>
        /// <exception cref="ArgumentException">Thrown when the <see cref="Validator{T}.Value">Value</see> of the specified <paramref name="validator"/> contains more or the same amount of elements as specified by the <paramref name="numberOfElements"/> argument, while the specified <paramref name="validator"/> is created using the <see cref="Condition.Requires{T}(T,string)">Requires</see> extension method.</exception>
        /// <exception cref="ArgumentNullException">Thrown when the <see cref="Validator{T}.Value">Value</see> of the specified <paramref name="validator"/> is a null reference and the <paramref name="numberOfElements"/> is smaller or equal to 0, while the specified <paramref name="validator"/> is created using the <see cref="Condition.Requires{T}(T,string)">Requires</see> extension method.</exception>
        /// <exception cref="PostconditionException">Thrown when the <see cref="Validator{T}.Value">Value</see> of the specified <paramref name="validator"/> contains more or the same amount of elements as specified by the <paramref name="numberOfElements"/> argument, while the specified <paramref name="validator"/> is created using the <see cref="Condition.Ensures{T}(T,string)">Ensures</see> extension method.</exception>
        public static Validator<TCollection> IsNotLongerOrEqual<TCollection>(this Validator<TCollection> validator, int numberOfElements, string conditionDescription) where TCollection : IEnumerable
        {
            if (CollectionExtensions.SequenceIsLongerOrEqual(validator.Value, numberOfElements))
            {
                Throw.CollectionShouldNotContainMoreOrEqual<TCollection>(validator, numberOfElements, conditionDescription);
            }

            return validator;
        }
    }
}