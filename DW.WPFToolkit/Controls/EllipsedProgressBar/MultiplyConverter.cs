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
#if TRIAL
        static MultiplyConverter()
        {
            License1.LicenseChecker.Validate();
        }
#endif

        /// <summary>
        /// Takes the value as double and multiplies it with the parameter parsed to double.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="targetType">This parameter is not used.</param>
        /// <param name="parameter"></param>
        /// <param name="culture">This parameter is not used.</param>
        /// <returns></returns>
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var targetValue = (double)value;
            double multiply;
            double.TryParse(parameter.ToString(), NumberStyles.Float, CultureInfo.InvariantCulture, out multiply);
            return targetValue * multiply;
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
