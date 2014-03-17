using System;
using System.Windows.Data;
using DW.WPFToolkit.Helpers;

namespace DW.WPFToolkit.Controls
{
    public class TreeListViewConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value != null)
            {
                var container = VisualTreeAssist.FindParent<TreeListViewItem>(value);
                if (container != null)
                    return container.Level * 10;
            }
            return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
