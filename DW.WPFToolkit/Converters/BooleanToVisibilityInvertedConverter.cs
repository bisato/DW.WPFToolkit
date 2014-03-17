using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace DW.WPFToolkit.Converters
{
    public sealed class BooleanToVisibilityInvertedConverter : IValueConverter
    {
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

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return ((value is Visibility) &&
                    (((Visibility)value) == Visibility.Collapsed));
        }
    }
}
