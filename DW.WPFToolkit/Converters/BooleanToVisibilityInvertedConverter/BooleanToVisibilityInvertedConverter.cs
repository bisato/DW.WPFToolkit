using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace DW.WPFToolkit.Converters
{
    /// <summary>
    /// Represents the converter that converts Boolean values to and from System.Windows.Visibility enumeration values like the <see cref="System.Windows.Controls.BooleanToVisibilityConverter" /> but in the opposite way.
    /// </summary>
    public sealed class BooleanToVisibilityInvertedConverter : IValueConverter
    {
#if TRIAL
        static BooleanToVisibilityInvertedConverter()
        {
            License1.LicenseChecker.Validate();
        }
#endif

        /// <summary>
        /// Converts a Boolean value to a <see cref="System.Windows.Visibility" /> enumeration value.
        /// </summary>
        /// <param name="value">The Boolean value to convert. This value can be a standard Boolean value or a nullable Boolean value.</param>
        /// <param name="targetType">This parameter is not used.</param>
        /// <param name="parameter">This parameter is not used.</param>
        /// <param name="culture">This parameter is not used.</param>
        /// <returns><see cref="System.Windows.Visibility.Collapsed" /> if value is true; otherwise, <see cref="System.Windows.Visibility.Visible" />.</returns>
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
            return (flag ? Visibility.Collapsed : Visibility.Visible);
        }

        /// <summary>
        /// Converts a <see cref="System.Windows.Visibility" /> enumeration value to a Boolean value.
        /// </summary>
        /// <param name="value">A <see cref="System.Windows.Visibility" /> enumeration value.</param>
        /// <param name="targetType">This parameter is not used.</param>
        /// <param name="parameter">This parameter is not used.</param>
        /// <param name="culture">This parameter is not used.</param>
        /// <returns>true if value is <see cref="System.Windows.Visibility.Collapsed" />; otherwise, false.</returns>
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return ((value is Visibility) &&
                    (((Visibility)value) == Visibility.Collapsed));
        }
    }
}
