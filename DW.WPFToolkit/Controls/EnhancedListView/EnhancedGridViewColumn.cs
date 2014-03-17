using System.Windows;
using System.Windows.Controls;
using DW.WPFToolkit.Interactivity;

namespace DW.WPFToolkit.Controls
{
    public class EnhancedGridViewColumn : GridViewColumn
    {
        public string Name
        {
            get { return (string)GetValue(NameProperty); }
            set { SetValue(NameProperty, value); }
        }

        public static readonly DependencyProperty NameProperty =
            DependencyProperty.Register("Name", typeof(string), typeof(EnhancedGridViewColumn), new UIPropertyMetadata(OnNameChanged));

        private static void OnNameChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            ColumnVisibilityBehavior.SetName(sender, (string)e.NewValue);
        }

        public bool IsDefaultSortColumn
        {
            get { return (bool)GetValue(IsDefaultSortColumnProperty); }
            set { SetValue(IsDefaultSortColumnProperty, value); }
        }

        public static readonly DependencyProperty IsDefaultSortColumnProperty =
            DependencyProperty.Register("IsDefaultSortColumn", typeof(bool), typeof(EnhancedGridViewColumn), new UIPropertyMetadata(OnIsDefaultSortColumnChanged));

        private static void OnIsDefaultSortColumnChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            ColumnSortBehavior.SetIsDefaultSortColumn(sender, (bool)e.NewValue);
        }

        public string SortPropertyName
        {
            get { return (string)GetValue(SortPropertyNameProperty); }
            set { SetValue(SortPropertyNameProperty, value); }
        }

        public static readonly DependencyProperty SortPropertyNameProperty =
            DependencyProperty.Register("SortPropertyName", typeof(string), typeof(EnhancedGridViewColumn), new UIPropertyMetadata(OnSortPropertyNameChanged));

        private static void OnSortPropertyNameChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            ColumnSortBehavior.SetSortPropertyName(sender, (string)e.NewValue);
        }

        public double ProportionalWidth
        {
            get { return (double)GetValue(ProportionalWidthProperty); }
            set { SetValue(ProportionalWidthProperty, value); }
        }

        public static readonly DependencyProperty ProportionalWidthProperty =
            DependencyProperty.Register("ProportionalWidth", typeof(double), typeof(EnhancedGridViewColumn), new UIPropertyMetadata(OnProportionalWidthChanged));

        private static void OnProportionalWidthChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            ColumnWidthBehavior.SetProportionalWidth(sender, (double)e.NewValue);
        }
    }
}
