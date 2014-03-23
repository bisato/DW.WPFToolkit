using System;
using System.Windows;
using System.Windows.Data;
using DW.WPFToolkit.Helpers;

namespace DW.WPFToolkit.Controls
{
    /// <summary>
    /// Adds an intending level of the items shown in the tree of the <see cref="DW.WPFToolkit.Controls.TreeListView" />.
    /// </summary>
    public class TreeListViewConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value != null)
            {
                var container = VisualTreeAssist.FindParent<TreeListViewItem>(value as DependencyObject);
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
