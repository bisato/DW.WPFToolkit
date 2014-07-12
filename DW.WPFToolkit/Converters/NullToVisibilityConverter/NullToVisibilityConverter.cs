using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace DW.WPFToolkit.Converters
{
    /// <summary>
    /// Represents the converter that converts the state if the parameter is null to a Visibility value depending on the parameter.
    /// </summary>
    public sealed class NullToVisibilityConverter : IValueConverter
    {
        /// <summary>
        /// Converts the null state of an object to a Visibility representation depending on the parameter.
        /// </summary>
        /// <param name="value">The object to check for null.</param>
        /// <param name="targetType">This parameter is not used.</param>
        /// <param name="parameter">The <see cref="NullToVisibilityDirection" /> which defines what to return.</param>
        /// <param name="culture">This parameter is not used.</param>
        /// <returns>Visibility. if the value is not null; otherwise Visibility.Visible. With the <see cref="NullToVisibilityDirection.NullIsVisible" /> its opposite.</returns>
        /// <remarks>The default of the <see cref="NullToVisibilityDirection" /> is <see cref="NullToVisibilityDirection.NullIsCollapsed" />.</remarks>
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var direction = NullToVisibilityDirection.NullIsCollapsed;
            if (parameter is NullToVisibilityDirection)
                direction = (NullToVisibilityDirection)parameter;

            if (value == null)
            {
                if (direction == NullToVisibilityDirection.NullIsCollapsed)
                    return Visibility.Collapsed;
                if (direction == NullToVisibilityDirection.NullIsHidden)
                    return Visibility.Hidden;
                return Visibility.Visible;
            }

            if (direction == NullToVisibilityDirection.NullIsCollapsed)
                return Visibility.Visible;
            if (direction == NullToVisibilityDirection.NullIsHidden)
                return Visibility.Visible;
            return Visibility.Collapsed;
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
