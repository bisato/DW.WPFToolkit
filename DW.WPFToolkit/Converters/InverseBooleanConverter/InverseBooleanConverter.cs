using System;
using System.Globalization;
using System.Windows.Data;

namespace DW.WPFToolkit.Converters
{
    /// <summary>
    /// Represents the converter that converts Boolean values to its opposite.
    /// </summary>
    public class InverseBooleanConverter : IValueConverter
    {
        /// <summary>
        /// Converts Boolean values to its opposite.
        /// </summary>
        /// <param name="value">The Boolean value to convert. This value can be a standard Boolean value or a nullable Boolean value.</param>
        /// <param name="targetType">This parameter is not used.</param>
        /// <param name="parameter">This parameter is not used.</param>
        /// <param name="culture">This parameter is not used.</param>
        /// <returns></returns>
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var flag = false;
            if (value is bool)
                flag = (bool)value;
            else if (value is bool?) // TODO: Always false?
            {
                var nullable = (bool?)value;
                flag = nullable.HasValue ? nullable.Value : false;
            }
            return value == null ? false : !flag;
        }

        /// <summary>
        /// Converts Boolean values to its opposite.
        /// </summary>
        /// <param name="value">The Boolean value to convert.</param>
        /// <param name="targetType">This parameter is not used.</param>
        /// <param name="parameter">This parameter is not used.</param>
        /// <param name="culture">This parameter is not used.</param>
        /// <returns>false if value is true; otherwise, true.</returns>
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return Convert(value, targetType, parameter, culture);
        }
    }
}
