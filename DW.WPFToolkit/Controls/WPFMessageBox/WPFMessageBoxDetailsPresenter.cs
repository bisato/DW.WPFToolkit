using System.Windows;
using System.Windows.Controls;

namespace DW.WPFToolkit.Controls
{
    public class WPFMessageBoxDetailsPresenter : ContentControl
    {
        static WPFMessageBoxDetailsPresenter()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(WPFMessageBoxDetailsPresenter), new FrameworkPropertyMetadata(typeof(WPFMessageBoxDetailsPresenter)));
        }

        public bool IsDetailsExpanded
        {
            get { return (bool)GetValue(IsDetailsExpandedProperty); }
            set { SetValue(IsDetailsExpandedProperty, value); }
        }
        
        public static readonly DependencyProperty IsDetailsExpandedProperty =
            DependencyProperty.Register("IsDetailsExpanded", typeof(bool), typeof(WPFMessageBoxDetailsPresenter), new UIPropertyMetadata(false));
    }
}
