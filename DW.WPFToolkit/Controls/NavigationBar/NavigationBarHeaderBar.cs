using System.Windows;
using System.Windows.Controls;

namespace DW.WPFToolkit.Controls
{
    public class NavigationBarHeaderBar : ContentControl
    {
        static NavigationBarHeaderBar()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(NavigationBarHeaderBar), new FrameworkPropertyMetadata(typeof(NavigationBarHeaderBar)));
        }

        public bool IsChecked
        {
            get { return (bool)GetValue(IsCheckedProperty); }
            set { SetValue(IsCheckedProperty, value); }
        }

        public static readonly DependencyProperty IsCheckedProperty =
            DependencyProperty.Register("IsChecked", typeof(bool), typeof(NavigationBarHeaderBar), new PropertyMetadata(false));
    }
}
