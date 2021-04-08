using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using Conditions.Resources;
using Conditions.Utils;
using Conditions.Validators;

namespace Conditions
{
    /// <summary>
    /// Extension methods for <see cref="Validator{T}"/>.
    /// </summary>
    public static class ValidatorExtensions
    {
        #region Null

        public static Validator<T> IsNull<T>(this Validator<T> validator) where T : class
        {
            if (validator.Value != null)
            {
                Throw.ShouldBeNull<T>(validator);
            }

            return validator;
        }

        public static Validator<Nullable<T>> IsNull<T>(this Validator<Nullable<T>> validator) where T : struct
        {
            if (validator.Value.HasValue)
            {
                Throw.ShouldBeNull<Nullable<T>>(validator);
            }

            return validator;
        }

        public static Validator<T> IsNotNull<T>(this Validator<T> validator) where T : class
        {
            if (validator.Value == null)
            {
                Throw.ShouldNotBeNull<T>(validator);
            }

            return validator;
        }

        public static Validator<Nullable<T>> IsNotNull<T>(this Validator<Nullable<T>> validator) where T : struct
        {
            if (!validator.Value.HasValue)
            {
                Throw.ShouldNotBeNull<Nullable<T>>(validator);
            }

            return validator;
        }

        #endregion

        #region Type

        public static Validator<T> IsType<T>(this Validator<T> validator, Type type) where T : class
        {
            bool isValid = (validator.Value != null) && (type.GetTypeInfo().IsAssignableFrom(validator.Value.GetType().GetTypeInfo()));

            if (!isValid)
            {
                Throw.ShouldBeTypeOf<T>(validator, type);
            }

            return validator;
        }

        public static Validator<T> IsNotType<T>(this Validator<T> validator, Type type) where T : class
        {
            bool isValid = (validator.Value == null) || (!type.GetTypeInfo().IsAssignableFrom(validator.Value.GetType().GetTypeInfo()));

            if (!isValid)
            {
                Throw.ShouldNotBeTypeOf<T>(validator, type);
            }

            return validator;
        }

        #endregion

        #region Boolean

        public static Validator<bool> IsTrue(this Validator<bool> validator)
        {
            if (!validator.Value)
            {
                Throw.ShouldBeTrue<bool>(validator);
            }

            return validator;
        }

        public static Validator<Nullable<bool>> IsTrue(this Validator<Nullable<bool>> validator)
        {
            bool isValid = validator.Value == true;

            if (!isValid)
            {
                Throw.ShouldBeTrue<Nullable<bool>>(validator);
            }

            return validator;
        }

        public static Validator<bool> IsFalse(this Validator<bool> validator)
        {
            if (validator.Value)
            {
                Throw.ShouldBeFalse<bool>(validator);
            }

            return validator;
        }

        public static Validator<Nullable<bool>> IsFalse(this Validator<Nullable<bool>> validator)
        {
            bool isValid = validator.Value == false;

            if (!isValid)
            {
                Throw.ShouldBeFalse<Nullable<bool>>(validator);
            }

            return validator;
        }

        #endregion

        #region IComparable

        public static Validator<T> IsInRange<T>(this Validator<T> validator, T min, T max) where T : IComparable
        {
            Comparer<T> comparer = DefaultComparer<T>.Default;
            bool isValid = (comparer.Compare(validator.Value, min) >= 0) && (comparer.Compare(validator.Value, max) <= 0);

            if (!isValid)
            {
                Throw.ShouldBeInRange<T>(validator, min, max);
            }

            return validator;
        }

        public static Validator<Nullable<T>> IsInRange<T>(this Validator<Nullable<T>> validator, Nullable<T> min, Nullable<T> max) where T : struct, IComparable
        {
            Comparer<Nullable<T>> comparer = DefaultComparer<Nullable<T>>.Default;
            bool isValid = (comparer.Compare(validator.Value, min) >= 0) && (comparer.Compare(validator.Value, max) <= 0);

            if (!isValid)
            {
                Throw.ShouldBeInRange<Nullable<T>>(validator, min, max);
            }

            return validator;
        }

        public static Validator<T> IsNotInRange<T>(this Validator<T> validator, T min, T max) where T : IComparable
        {
            Comparer<T> comparer = DefaultComparer<T>.Default;
            bool isValid = (comparer.Compare(validator.Value, min) < 0) || (comparer.Compare(validator.Value, max) > 0);

            if (!isValid)
            {
                Throw.ShouldNotBeInRange<T>(validator, min, max);
            }

            return validator;
        }

        public static Validator<Nullable<T>> IsNotInRange<T>(this Validator<Nullable<T>> validator, Nullable<T> min, Nullable<T> max) where T : struct, IComparable
        {
            Comparer<Nullable<T>> comparer = DefaultComparer<Nullable<T>>.Default;
            bool isValid = (comparer.Compare(validator.Value, min) < 0) || (comparer.Compare(validator.Value, max) > 0);

            if (!isValid)
            {
                Throw.ShouldNotBeInRange<Nullable<T>>(validator, min, max);
            }

            return validator;
        }

        public static Validator<T> IsEqualTo<T>(this Validator<T> validator, T value) where T : IComparable
        {
            Comparer<T> comparer = DefaultComparer<T>.Default;
            bool isValid = comparer.Compare(validator.Value, value) == 0;

            if (!isValid)
            {
                Throw.ShouldBeEqualTo<T>(validator, value);
            }

            return validator;
        }

        public static Validator<Nullable<T>> IsEqualTo<T>(this Validator<Nullable<T>> validator, Nullable<T> value) where T : struct, IComparable
        {
            Comparer<Nullable<T>> comparer = DefaultComparer<Nullable<T>>.Default;
            bool isValid = comparer.Compare(validator.Value, value) == 0;

            if (!isValid)
            {
                Throw.ShouldBeEqualTo<Nullable<T>>(validator, value);
            }

            return validator;
        }

        public static Validator<T> IsNotEqualTo<T>(this Validator<T> validator, T value) where T : IComparable
        {
            Comparer<T> comparer = DefaultComparer<T>.Default;
            bool isValid = comparer.Compare(validator.Value, value) != 0;

            if (!isValid)
            {
                Throw.ShouldNotBeEqualTo<T>(validator, value);
            }

            return validator;
        }

        public static Validator<Nullable<T>> IsNotEqualTo<T>(this Validator<Nullable<T>> validator, Nullable<T> value) where T : struct, IComparable
        {
            Comparer<Nullable<T>> comparer = DefaultComparer<Nullable<T>>.Default;
            bool isValid = comparer.Compare(validator.Value, value) != 0;

            if (!isValid)
            {
                Throw.ShouldNotBeEqualTo<Nullable<T>>(validator, value);
            }

            return validator;
        }

        public static Validator<T> IsGreaterThan<T>(this Validator<T> validator, T value) where T : IComparable
        {
            Comparer<T> comparer = DefaultComparer<T>.Default;
            bool isValid = comparer.Compare(validator.Value, value) > 0;

            if (!isValid)
            {
                Throw.ShouldBeGreaterThan<T>(validator, value);
            }

            return validator;
        }

        public static Validator<Nullable<T>> IsGreaterThan<T>(this Validator<Nullable<T>> validator, Nullable<T> value) where T : struct, IComparable
        {
            Comparer<Nullable<T>> comparer = DefaultComparer<Nullable<T>>.Default;
            bool isValid = comparer.Compare(validator.Value, value) > 0;

            if (!isValid)
            {
                Throw.ShouldBeGreaterThan<Nullable<T>>(validator, value);
            }

            return validator;
        }

        public static Validator<T> IsGreaterOrEqualTo<T>(this Validator<T> validator, T value) where T : IComparable
        {
            Comparer<T> comparer = DefaultComparer<T>.Default;
            bool isValid = comparer.Compare(validator.Value, value) >= 0;

            if (!isValid)
            {
                Throw.ShouldBeGreaterOrEqualTo<T>(validator, value);
            }

            return validator;
        }

        public static Validator<Nullable<T>> IsGreaterOrEqualTo<T>(this Validator<Nullable<T>> validator, Nullable<T> value) where T : struct, IComparable
        {
            Comparer<Nullable<T>> comparer = DefaultComparer<Nullable<T>>.Default;
            bool isValid = comparer.Compare(validator.Value, value) >= 0;

            if (!isValid)
            {
                Throw.ShouldBeGreaterOrEqualTo<Nullable<T>>(validator, value);
            }

            return validator;
        }

        public static Validator<T> IsLessThan<T>(this Validator<T> validator, T value) where T : IComparable
        {
            Comparer<T> comparer = DefaultComparer<T>.Default;
            bool isValid = comparer.Compare(validator.Value, value) < 0;

            if (!isValid)
            {
                Throw.ShouldBeLessThan<T>(validator, value);
            }

            return validator;
        }

        public static Validator<Nullable<T>> IsLessThan<T>(this Validator<Nullable<T>> validator, Nullable<T> value) where T : struct, IComparable
        {
            Comparer<Nullable<T>> comparer = DefaultComparer<Nullable<T>>.Default;
            bool isValid = comparer.Compare(validator.Value, value) < 0;

            if (!isValid)
            {
                Throw.ShouldBeLessThan<Nullable<T>>(validator, value);
            }

            return validator;
        }

        public static Validator<T> IsLessOrEqualTo<T>(this Validator<T> validator, T value) where T : IComparable
        {
            Comparer<T> comparer = DefaultComparer<T>.Default;
            bool isValid = comparer.Compare(validator.Value, value) <= 0;

            if (!isValid)
            {
                Throw.ShouldBeLessOrEqualTo<T>(validator, value);
            }

            return validator;
        }

        public static Validator<Nullable<T>> IsLessOrEqualTo<T>(this Validator<Nullable<T>> validator, Nullable<T> value) where T : struct, IComparable
        {
            Comparer<Nullable<T>> comparer = DefaultComparer<Nullable<T>>.Default;
            bool isValid = comparer.Compare(validator.Value, value) <= 0;

            if (!isValid)
            {
                Throw.ShouldBeLessOrEqualTo<Nullable<T>>(validator, value);
            }

            return validator;
        }

        #endregion

        #region Byte

        public static Validator<byte> IsInRange(this Validator<byte> validator, byte min, byte max)
        {
            bool isValid = (validator.Value >= min) && (validator.Value <= max);

            if (!isValid)
            {
                Throw.ShouldBeInRange<byte>(validator, min, max);
            }

            return validator;
        }

        public static Validator<byte> IsNotInRange(this Validator<byte> validator, byte min, byte max)
        {
            bool isValid = (validator.Value < min) || (validator.Value > max);

            if (!isValid)
            {
                Throw.ShouldNotBeInRange<byte>(validator, min, max);
            }

            return validator;
        }

        public static Validator<byte> IsEqualTo(this Validator<byte> validator, byte value)
        {
            if (validator.Value != value)
            {
                Throw.ShouldBeEqualTo<byte>(validator, value);
            }

            return validator;
        }

        public static Validator<byte> IsNotEqualTo(this Validator<byte> validator, byte value)
        {
            if (validator.Value == value)
            {
                Throw.ShouldNotBeEqualTo<byte>(validator, value);
            }

            return validator;
        }

        public static Validator<byte> IsGreaterThan(this Validator<byte> validator, byte value)
        {
            if (validator.Value <= value)
            {
                Throw.ShouldBeGreaterThan<byte>(validator, value);
            }

            return validator;
        }

        public static Validator<byte> IsGreaterOrEqualTo(this Validator<byte> validator, byte value)
        {
            if (validator.Value < value)
            {
                Throw.ShouldBeGreaterOrEqualTo<byte>(validator, value);
            }

            return validator;
        }

        public static Validator<byte> IsLessThan(this Validator<byte> validator, byte value)
        {
            if (validator.Value >= value)
            {
                Throw.ShouldBeLessThan<byte>(validator, value);
            }

            return validator;
        }

        public static Validator<byte> IsLessOrEqualTo(this Validator<byte> validator, byte value)
        {
            if (validator.Value > value)
            {
                Throw.ShouldBeLessOrEqualTo<byte>(validator, value);
            }

            return validator;
        }

        #endregion

        #region Int16

        public static Validator<short> IsInRange(this Validator<short> validator, short min, short max)
        {
            bool isValid = (validator.Value >= min) && (validator.Value <= max);

            if (!isValid)
            {
                Throw.ShouldBeInRange<short>(validator, min, max);
            }

            return validator;
        }

        public static Validator<short> IsNotInRange(this Validator<short> validator, short min, short max)
        {
            bool isValid = (validator.Value < min) || (validator.Value > max);

            if (!isValid)
            {
                Throw.ShouldNotBeInRange<short>(validator, min, max);
            }

            return validator;
        }

        public static Validator<short> IsEqualTo(this Validator<short> validator, short value)
        {
            if (validator.Value != value)
            {
                Throw.ShouldBeEqualTo<short>(validator, value);
            }

            return validator;
        }

        public static Validator<short> IsNotEqualTo(this Validator<short> validator, short value)
        {
            if (validator.Value == value)
            {
                Throw.ShouldNotBeEqualTo<short>(validator, value);
            }

            return validator;
        }

        public static Validator<short> IsGreaterThan(this Validator<short> validator, short value)
        {
            if (validator.Value <= value)
            {
                Throw.ShouldBeGreaterThan<short>(validator, value);
            }

            return validator;
        }

        public static Validator<short> IsGreaterOrEqualTo(this Validator<short> validator, short value)
        {
            if (validator.Value < value)
            {
                Throw.ShouldBeGreaterOrEqualTo<short>(validator, value);
            }

            return validator;
        }

        public static Validator<short> IsLessThan(this Validator<short> validator, short value)
        {
            if (validator.Value >= value)
            {
                Throw.ShouldBeLessThan<short>(validator, value);
            }

            return validator;
        }

        public static Validator<short> IsLessOrEqualTo(this Validator<short> validator, short value)
        {
            if (validator.Value > value)
            {
                Throw.ShouldBeLessOrEqualTo<short>(validator, value);
            }

            return validator;
        }

        #endregion

        #region Int32

        public static Validator<int> IsInRange(this Validator<int> validator, int min, int max)
        {
            bool isValid = (validator.Value >= min) && (validator.Value <= max);

            if (!isValid)
            {
                Throw.ShouldBeInRange<int>(validator, min, max);
            }

            return validator;
        }

        public static Validator<int> IsNotInRange(this Validator<int> validator, int min, int max)
        {
            bool isValid = (validator.Value < min) || (validator.Value > max);

            if (!isValid)
            {
                Throw.ShouldNotBeInRange<int>(validator, min, max);
            }

            return validator;
        }

        public static Validator<int> IsEqualTo(this Validator<int> validator, int value)
        {
            if (validator.Value != value)
            {
                Throw.ShouldBeEqualTo<int>(validator, value);
            }

            return validator;
        }

        public static Validator<int> IsNotEqualTo(this Validator<int> validator, int value)
        {
            if (validator.Value == value)
            {
                Throw.ShouldNotBeEqualTo<int>(validator, value);
            }

            return validator;
        }

        public static Validator<int> IsGreaterThan(this Validator<int> validator, int value)
        {
            if (validator.Value <= value)
            {
                Throw.ShouldBeGreaterThan<int>(validator, value);
            }

            return validator;
        }

        public static Validator<int> IsGreaterOrEqualTo(this Validator<int> validator, int value)
        {
            if (validator.Value < value)
            {
                Throw.ShouldBeGreaterOrEqualTo<int>(validator, value);
            }

            return validator;
        }

        public static Validator<int> IsLessThan(this Validator<int> validator, int value)
        {
            if (validator.Value >= value)
            {
                Throw.ShouldBeLessThan<int>(validator, value);
            }

            return validator;
        }

        public static Validator<int> IsLessOrEqualTo(this Validator<int> validator, int value)
        {
            if (validator.Value > value)
            {
                Throw.ShouldBeLessOrEqualTo<int>(validator, value);
            }

            return validator;
        }

        #endregion

        #region Int64

        public static Validator<long> IsInRange(this Validator<long> validator, long min, long max)
        {
            bool isValid = (validator.Value >= min) && (validator.Value <= max);

            if (!isValid)
            {
                Throw.ShouldBeInRange<long>(validator, min, max);
            }

            return validator;
        }

        public static Validator<long> IsNotInRange(this Validator<long> validator, long min, long max)
        {
            bool isValid = (validator.Value < min) || (validator.Value > max);

            if (!isValid)
            {
                Throw.ShouldNotBeInRange<long>(validator, min, max);
            }

            return validator;
        }

        public static Validator<long> IsEqualTo(this Validator<long> validator, long value)
        {
            if (validator.Value != value)
            {
                Throw.ShouldBeEqualTo<long>(validator, value);
            }

            return validator;
        }

        public static Validator<long> IsNotEqualTo(this Validator<long> validator, long value)
        {
            if (validator.Value == value)
            {
                Throw.ShouldNotBeEqualTo<long>(validator, value);
            }

            return validator;
        }

        public static Validator<long> IsGreaterThan(this Validator<long> validator, long value)
        {
            if (validator.Value <= value)
            {
                Throw.ShouldBeGreaterThan<long>(validator, value);
            }

            return validator;
        }

        public static Validator<long> IsGreaterOrEqualTo(this Validator<long> validator, long value)
        {
            if (validator.Value < value)
            {
                Throw.ShouldBeGreaterOrEqualTo<long>(validator, value);
            }

            return validator;
        }

        public static Validator<long> IsLessThan(this Validator<long> validator, long value)
        {
            if (validator.Value >= value)
            {
                Throw.ShouldBeLessThan<long>(validator, value);
            }

            return validator;
        }

        public static Validator<long> IsLessOrEqualTo(this Validator<long> validator, long value)
        {
            if (validator.Value > value)
            {
                Throw.ShouldBeLessOrEqualTo<long>(validator, value);
            }

            return validator;
        }

        #endregion

        #region Single

        public static Validator<float> IsNaN(this Validator<float> validator)
        {
            if (!Double.IsNaN(validator.Value))
            {
                Throw.ShouldBeNumber<float>(validator);
            }

            return validator;
        }

        public static Validator<float> IsNotNaN(this Validator<float> validator)
        {
            if (Double.IsNaN(validator.Value))
            {
                Throw.ShouldNotBeNumber<float>(validator);
            }

            return validator;
        }

        public static Validator<float> IsInfinity(this Validator<float> validator)
        {
            if (!Double.IsInfinity(validator.Value))
            {
                Throw.ShouldBeInfinity<float>(validator);
            }

            return validator;
        }

        public static Validator<float> IsNotInfinity(this Validator<float> validator)
        {
            if (Double.IsInfinity(validator.Value))
            {
                Throw.ShouldNotBeInfinity<float>(validator);
            }

            return validator;
        }

        public static Validator<float> IsPositiveInfinity(this Validator<float> validator)
        {
            if (!Double.IsPositiveInfinity(validator.Value))
            {
                Throw.ShouldBePositiveInfinity<float>(validator);
            }

            return validator;
        }

        public static Validator<float> IsNotPositiveInfinity(this Validator<float> validator)
        {
            if (Double.IsPositiveInfinity(validator.Value))
            {
                Throw.ShouldNotBePositiveInfinity<float>(validator);
            }

            return validator;
        }

        public static Validator<float> IsNegativeInfinity(this Validator<float> validator)
        {
            if (!Double.IsNegativeInfinity(validator.Value))
            {
                Throw.ShouldBeNegativeInfinity<float>(validator);
            }

            return validator;
        }

        public static Validator<float> IsNotNegativeInfinity(this Validator<float> validator)
        {
            if (Double.IsNegativeInfinity(validator.Value))
            {
                Throw.ShouldNotBeNegativeInfinity<float>(validator);
            }

            return validator;
        }

        public static Validator<float> IsInRange(this Validator<float> validator, float min, float max)
        {
            bool isValid = (validator.Value >= min) && (validator.Value <= max);

            if (!isValid)
            {
                Throw.ShouldBeInRange<float>(validator, min, max);
            }

            return validator;
        }

        public static Validator<float> IsNotInRange(this Validator<float> validator, float min, float max)
        {
            bool isValid = (validator.Value < min) || (validator.Value > max);

            if (!isValid)
            {
                Throw.ShouldNotBeInRange<float>(validator, min, max);
            }

            return validator;
        }

        public static Validator<float> IsEqualTo(this Validator<float> validator, float value)
        {
            if (validator.Value != value)
            {
                Throw.ShouldBeEqualTo<float>(validator, value);
            }

            return validator;
        }

        public static Validator<float> IsNotEqualTo(this Validator<float> validator, float value)
        {
            if (validator.Value == value)
            {
                Throw.ShouldNotBeEqualTo<float>(validator, value);
            }

            return validator;
        }

        public static Validator<float> IsGreaterThan(this Validator<float> validator, float value)
        {
            if (validator.Value <= value)
            {
                Throw.ShouldBeGreaterThan<float>(validator, value);
            }

            return validator;
        }

        public static Validator<float> IsGreaterOrEqualTo(this Validator<float> validator, float value)
        {
            if (validator.Value < value)
            {
                Throw.ShouldBeGreaterOrEqualTo<float>(validator, value);
            }

            return validator;
        }

        public static Validator<float> IsLessThan(this Validator<float> validator, float value)
        {
            if (validator.Value >= value)
            {
                Throw.ShouldBeLessThan<float>(validator, value);
            }

            return validator;
        }

        public static Validator<float> IsLessOrEqualTo(this Validator<float> validator, float value)
        {
            if (validator.Value > value)
            {
                Throw.ShouldBeLessOrEqualTo<float>(validator, value);
            }

            return validator;
        }

        #endregion

        #region Double

        public static Validator<double> IsNaN(this Validator<double> validator)
        {
            if (!Double.IsNaN(validator.Value))
            {
                Throw.ShouldBeNumber<double>(validator);
            }

            return validator;
        }

        public static Validator<double> IsNotNaN(this Validator<double> validator)
        {
            if (Double.IsNaN(validator.Value))
            {
                Throw.ShouldNotBeNumber<double>(validator);
            }

            return validator;
        }

        public static Validator<double> IsInfinity(this Validator<double> validator)
        {
            if (!Double.IsInfinity(validator.Value))
            {
                Throw.ShouldBeInfinity<double>(validator);
            }

            return validator;
        }

        public static Validator<double> IsNotInfinity(this Validator<double> validator)
        {
            if (Double.IsInfinity(validator.Value))
            {
                Throw.ShouldNotBeInfinity<double>(validator);
            }

            return validator;
        }

        public static Validator<double> IsPositiveInfinity(this Validator<double> validator)
        {
            if (!Double.IsPositiveInfinity(validator.Value))
            {
                Throw.ShouldBePositiveInfinity<double>(validator);
            }

            return validator;
        }

        public static Validator<double> IsNotPositiveInfinity(this Validator<double> validator)
        {
            if (Double.IsPositiveInfinity(validator.Value))
            {
                Throw.ShouldNotBePositiveInfinity<double>(validator);
            }

            return validator;
        }

        public static Validator<double> IsNegativeInfinity(this Validator<double> validator)
        {
            if (!Double.IsNegativeInfinity(validator.Value))
            {
                Throw.ShouldBeNegativeInfinity<double>(validator);
            }

            return validator;
        }

        public static Validator<double> IsNotNegativeInfinity(this Validator<double> validator)
        {
            if (Double.IsNegativeInfinity(validator.Value))
            {
                Throw.ShouldNotBeNegativeInfinity<double>(validator);
            }

            return validator;
        }

        public static Validator<double> IsInRange(this Validator<double> validator, double min, double max)
        {
            bool isValid = (validator.Value >= min) && (validator.Value <= max);

            if (!isValid)
            {
                Throw.ShouldBeInRange<double>(validator, min, max);
            }

            return validator;
        }

        public static Validator<double> IsNotInRange(this Validator<double> validator, double min, double max)
        {
            bool isValid = (validator.Value < min) || (validator.Value > max);

            if (!isValid)
            {
                Throw.ShouldNotBeInRange<double>(validator, min, max);
            }

            return validator;
        }

        public static Validator<double> IsEqualTo(this Validator<double> validator, double value)
        {
            if (validator.Value != value)
            {
                Throw.ShouldBeEqualTo<double>(validator, value);
            }

            return validator;
        }

        public static Validator<double> IsNotEqualTo(this Validator<double> validator, double value)
        {
            if (validator.Value == value)
            {
                Throw.ShouldNotBeEqualTo<double>(validator, value);
            }

            return validator;
        }

        public static Validator<double> IsGreaterThan(this Validator<double> validator, double value)
        {
            if (validator.Value <= value)
            {
                Throw.ShouldBeGreaterThan<double>(validator, value);
            }

            return validator;
        }

        public static Validator<double> IsGreaterOrEqualTo(this Validator<double> validator, double value)
        {
            if (validator.Value < value)
            {
                Throw.ShouldBeGreaterOrEqualTo<double>(validator, value);
            }

            return validator;
        }

        public static Validator<double> IsLessThan(this Validator<double> validator, double value)
        {
            if (validator.Value >= value)
            {
                Throw.ShouldBeLessThan<double>(validator, value);
            }

            return validator;
        }

        public static Validator<double> IsLessOrEqualTo(this Validator<double> validator, double value)
        {
            if (validator.Value > value)
            {
                Throw.ShouldBeLessOrEqualTo<double>(validator, value);
            }

            return validator;
        }

        #endregion

        #region Decimal

        public static Validator<decimal> IsInRange(this Validator<decimal> validator, decimal min, decimal max)
        {
            bool isValid = (validator.Value >= min) && (validator.Value <= max);

            if (!isValid)
            {
                Throw.ShouldBeInRange<decimal>(validator, min, max);
            }

            return validator;
        }

        public static Validator<decimal> IsNotInRange(this Validator<decimal> validator, decimal min, decimal max)
        {
            bool isValid = (validator.Value < min) || (validator.Value > max);

            if (!isValid)
            {
                Throw.ShouldNotBeInRange<decimal>(validator, min, max);
            }

            return validator;
        }

        public static Validator<decimal> IsEqualTo(this Validator<decimal> validator, decimal value)
        {
            if (validator.Value != value)
            {
                Throw.ShouldBeEqualTo<decimal>(validator, value);
            }

            return validator;
        }

        public static Validator<decimal> IsNotEqualTo(this Validator<decimal> validator, decimal value)
        {
            if (validator.Value == value)
            {
                Throw.ShouldNotBeEqualTo<decimal>(validator, value);
            }

            return validator;
        }

        public static Validator<decimal> IsGreaterThan(this Validator<decimal> validator, decimal value)
        {
            if (validator.Value <= value)
            {
                Throw.ShouldBeGreaterThan<decimal>(validator, value);
            }

            return validator;
        }

        public static Validator<decimal> IsGreaterOrEqualTo(this Validator<decimal> validator, decimal value)
        {
            if (validator.Value < value)
            {
                Throw.ShouldBeGreaterOrEqualTo<decimal>(validator, value);
            }

            return validator;
        }

        public static Validator<decimal> IsLessThan(this Validator<decimal> validator, decimal value)
        {
            if (validator.Value >= value)
            {
                Throw.ShouldBeLessThan<decimal>(validator, value);
            }

            return validator;
        }

        public static Validator<decimal> IsLessOrEqualTo(this Validator<decimal> validator, decimal value)
        {
            if (validator.Value > value)
            {
                Throw.ShouldBeLessOrEqualTo<decimal>(validator, value);
            }

            return validator;
        }

        #endregion

        #region String

        public static Validator<string> IsEmpty(this Validator<string> validator)
        {
            bool isValid = (validator.Value != null) && (validator.Value.Length == 0);

            if (!isValid)
            {
                Throw.StringShouldBeEmpty(validator);
            }

            return validator;
        }

        public static Validator<string> IsNotEmpty(this Validator<string> validator)
        {
            bool isValid = (validator.Value == null) || (validator.Value.Length != 0);

            if (!isValid)
            {
                Throw.StringShouldNotBeEmpty(validator);
            }

            return validator;
        }

        public static Validator<string> IsNullOrEmpty(this Validator<string> validator)
        {
            if (!String.IsNullOrEmpty(validator.Value))
            {
                Throw.StringShouldBeNullOrEmpty(validator);
            }

            return validator;
        }

        public static Validator<string> IsNotNullOrEmpty(this Validator<string> validator)
        {
            if (String.IsNullOrEmpty(validator.Value))
            {
                Throw.StringShouldNotBeNullOrEmpty(validator);
            }

            return validator;
        }

        public static Validator<string> IsNullOrWhiteSpace(this Validator<string> validator)
        {
            if (!String.IsNullOrWhiteSpace(validator.Value))
            {
                Throw.StringShouldBeNullOrWhiteSpace(validator);
            }

            return validator;
        }

        public static Validator<string> IsNotNullOrWhiteSpace(this Validator<string> validator)
        {
            if (String.IsNullOrWhiteSpace(validator.Value))
            {
                Throw.StringShouldNotBeNullOrWhiteSpace(validator);
            }

            return validator;
        }

        public static Validator<string> IsLongerThan(this Validator<string> validator, int length)
        {
            int valueLength = 0;

            if (validator.Value != null)
            {
                valueLength = validator.Value.Length;
            }

            if (valueLength <= length)
            {
                Throw.StringShouldBeLongerThan(validator, length);
            }

            return validator;
        }

        public static Validator<string> IsLongerOrEqualTo(this Validator<string> validator, int length)
        {
            int valueLength = 0;

            if (validator.Value != null)
            {
                valueLength = validator.Value.Length;
            }

            if (valueLength < length)
            {
                Throw.StringShouldBeLongerOrEqualTo(validator, length);
            }

            return validator;
        }

        public static Validator<string> IsShorterThan(this Validator<string> validator, int length)
        {
            int valueLength = 0;

            if (validator.Value != null)
            {
                valueLength = validator.Value.Length;
            }

            if (valueLength >= length)
            {
                Throw.StringShouldBeShorterThan(validator, length);
            }

            return validator;
        }

        public static Validator<string> IsShorterOrEqualTo(this Validator<string> validator, int length)
        {
            int valueLength = 0;

            if (validator.Value != null)
            {
                valueLength = validator.Value.Length;
            }

            if (valueLength > length)
            {
                Throw.StringShouldBeShorterOrEqualTo(validator, length);
            }

            return validator;
        }

        public static Validator<string> Contains(this Validator<string> validator, string value)
        {
            bool isValid = ((validator.Value == null) && (value == null)) ||
                           ((validator.Value != null) && (value != null) && (validator.Value.Contains(value)));

            if (!isValid)
            {
                Throw.StringShouldContain(validator, value);
            }

            return validator;
        }

        public static Validator<string> DoesNotContain(this Validator<string> validator, string value)
        {
            bool isValid = ((validator.Value != null) || (value != null)) &&
                           ((validator.Value == null) || (value == null) || (!validator.Value.Contains(value)));

            if (!isValid)
            {
                Throw.StringShouldNotContain(validator, value);
            }

            return validator;
        }

        public static Validator<string> StartsWith(this Validator<string> validator, string value)
        {
            bool isValid = ((validator.Value == null) && (value == null)) ||
                           ((validator.Value != null) && (value != null) && (validator.Value.StartsWith(value)));

            if (!isValid)
            {
                Throw.StringShouldStartWith(validator, value);
            }

            return validator;
        }

        public static Validator<string> DoesNotStartWith(this Validator<string> validator, string value)
        {
            bool isValid = ((validator.Value != null) || (value != null)) &&
                           ((validator.Value == null) || (value == null) || (!validator.Value.StartsWith(value)));

            if (!isValid)
            {
                Throw.StringShouldNotStartWith(validator, value);
            }

            return validator;
        }

        public static Validator<string> EndsWith(this Validator<string> validator, string value)
        {
            bool isValid = ((validator.Value == null) && (value == null)) ||
                           ((validator.Value != null) && (value != null) && (validator.Value.EndsWith(value)));

            if (!isValid)
            {
                Throw.StringShouldEndWith(validator, value);
            }

            return validator;
        }

        public static Validator<string> DoesNotEndWith(this Validator<string> validator, string value)
        {
            bool isValid = ((validator.Value != null) || (value != null)) &&
                           ((validator.Value == null) || (value == null) || (!validator.Value.EndsWith(value)));

            if (!isValid)
            {
                Throw.StringShouldNotEndWith(validator, value);
            }

            return validator;
        }

        #endregion

        #region Collection

        public static Validator<T> IsEmpty<T>(this Validator<T> validator) where T : IEnumerable
        {
            if (!CollectionHelpers.IsNullOrEmpty(validator.Value))
            {
                Throw.CollectionShouldBeEmpty<T>(validator);
            }

            return validator;
        }

        public static Validator<T> IsNotEmpty<T>(this Validator<T> validator) where T : IEnumerable
        {
            if (CollectionHelpers.IsNullOrEmpty(validator.Value))
            {
                Throw.CollectionShouldNotBeEmpty<T>(validator);
            }

            return validator;
        }

        public static Validator<TCollection> Contains<TCollection, TElement>(this Validator<TCollection> validator, TElement element) where TCollection : IEnumerable<TElement>
        {
            bool isValid = (validator.Value != null) && (CollectionHelpers.Contains<TElement>(validator.Value, element));

            if (!isValid)
            {
                Throw.CollectionShouldContain<TCollection>(validator, element);
            }

            return validator;
        }

        public static Validator<T> Contains<T>(this Validator<T> validator, object element) where T : IEnumerable
        {
            bool isValid = (validator.Value != null) && (CollectionHelpers.Contains(validator.Value, element));

            if (!isValid)
            {
                Throw.CollectionShouldContain<T>(validator, element);
            }

            return validator;
        }

        public static Validator<TCollection> DoesNotContain<TCollection, TElement>(this Validator<TCollection> validator, TElement element) where TCollection : IEnumerable<TElement>
        {
            bool isValid = (validator.Value == null) || (!CollectionHelpers.Contains<TElement>(validator.Value, element));

            if (!isValid)
            {
                Throw.CollectionShouldNotContain<TCollection>(validator, element);
            }

            return validator;
        }

        public static Validator<T> DoesNotContain<T>(this Validator<T> validator, object element) where T : IEnumerable
        {
            bool isValid = (validator.Value == null) || (!CollectionHelpers.Contains(validator.Value, element));

            if (!isValid)
            {
                Throw.CollectionShouldNotContain<T>(validator, element);
            }

            return validator;
        }

        #endregion

        #region DateTime

        public static Validator<DateTime> IsInRange(this Validator<DateTime> validator, DateTime min, DateTime max)
        {
            bool isValid = (validator.Value >= min) && (validator.Value <= max);

            if (!isValid)
            {
                Throw.ShouldBeInRange<DateTime>(validator, min, max);
            }

            return validator;
        }

        public static Validator<DateTime> IsNotInRange(this Validator<DateTime> validator, DateTime min, DateTime max)
        {
            bool isValid = (validator.Value < min) || (validator.Value > max);

            if (!isValid)
            {
                Throw.ShouldNotBeInRange<DateTime>(validator, min, max);
            }

            return validator;
        }

        public static Validator<DateTime> IsEqualTo(this Validator<DateTime> validator, DateTime value)
        {
            if (validator.Value != value)
            {
                Throw.ShouldBeEqualTo<DateTime>(validator, value);
            }

            return validator;
        }

        public static Validator<DateTime> IsNotEqualTo(this Validator<DateTime> validator, DateTime value)
        {
            if (validator.Value == value)
            {
                Throw.ShouldNotBeEqualTo<DateTime>(validator, value);
            }

            return validator;
        }

        public static Validator<DateTime> IsGreaterThan(this Validator<DateTime> validator, DateTime value)
        {
            if (validator.Value <= value)
            {
                Throw.ShouldBeGreaterThan<DateTime>(validator, value);
            }

            return validator;
        }

        public static Validator<DateTime> IsGreaterOrEqualTo(this Validator<DateTime> validator, DateTime value)
        {
            if (validator.Value < value)
            {
                Throw.ShouldBeGreaterOrEqualTo<DateTime>(validator, value);
            }

            return validator;
        }

        public static Validator<DateTime> IsLessThan(this Validator<DateTime> validator, DateTime value)
        {
            if (validator.Value >= value)
            {
                Throw.ShouldBeLessThan<DateTime>(validator, value);
            }

            return validator;
        }

        public static Validator<DateTime> IsLessOrEqualTo(this Validator<DateTime> validator, DateTime value)
        {
            if (validator.Value > value)
            {
                Throw.ShouldBeLessOrEqualTo<DateTime>(validator, value);
            }

            return validator;
        }

        #endregion
    }
}