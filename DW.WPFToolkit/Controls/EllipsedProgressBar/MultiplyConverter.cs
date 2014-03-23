using System;
using System.Globalization;
using System.Windows.Data;

namespace DW.WPFToolkit.Controls
{
    /// <summary>
    /// Multiplies the given value by the parameter value.
    /// </summary>
    public class MultiplyConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var targetValue = (double)value;
            double multiply;
            double.TryParse(parameter.ToString(), NumberStyles.Float, CultureInfo.InvariantCulture, out multiply);
            return targetValue * multiply;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
