using System;
using System.Globalization;
using System.Windows.Data;

namespace DW.WPFToolkit.Converters
{
    /// <summary>
    /// Represents the converter that converts the state if the parameter is null to a boolean value depending on the parameter.
    /// </summary>
    public sealed class NullToBooleanConverter : IValueConverter
    {
#if TRIAL
        static NullToBooleanConverter()
        {
            License1.License.Display();
        }
#endif

        /// <summary>
        /// Converts the null state of an object to a boolean representation depending on the parameter.
        /// </summary>
        /// <param name="value">The object to check for null.</param>
        /// <param name="targetType">This parameter is not used.</param>
        /// <param name="parameter">The <see cref="NullToBooleanDirection" /> which defines what to return.</param>
        /// <param name="culture">This parameter is not used.</param>
        /// <returns>True if the value is not null; otherwise false. With the <see cref="NullToBooleanDirection.NullIsTrue" /> its opposite.</returns>
        /// <remarks>The default of the <see cref="NullToBooleanDirection" /> is <see cref="NullToBooleanDirection.NullIsFalse" />.</remarks>
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var direction = NullToBooleanDirection.NullIsFalse;
            if (parameter is NullToBooleanDirection)
                direction = (NullToBooleanDirection)parameter;

            if (value == null)
            {
                if (direction == NullToBooleanDirection.NullIsFalse)
                    return false;
                return true;
            }
            if (direction == NullToBooleanDirection.NullIsFalse)
                return true;
            return false;
        }

        /// <summary>
        /// Not implemented.
        /// </summary>
        /// <param name="value">This parameter is not used.</param>
        /// <param name="targetType">This parameter is not used.</param>
        /// <param name="parameter">This parameter is not used.</param>
        /// <param name="culture">This parameter is not used.</param>
        /// <returns>nothing</returns>
        /// <exception cref="System.NotImplementedException">The convert back is not intended to be used.</exception>
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
