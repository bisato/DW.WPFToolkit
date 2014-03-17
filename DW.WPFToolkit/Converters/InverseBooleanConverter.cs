using System;
using System.Globalization;
using System.Windows.Data;

namespace DW.WPFToolkit.Converters
{
    public class InverseBooleanConverter : IValueConverter
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
            return value == null ? false : !flag;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return Convert(value, targetType, parameter, culture);
        }
    }
}
