using System.Windows;
using System.Windows.Controls;

namespace DW.WPFToolkit.Controls
{
    public class WPFMessageBoxDetailsButtonControl : Expander
    {
        static WPFMessageBoxDetailsButtonControl()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(WPFMessageBoxDetailsButtonControl), new FrameworkPropertyMetadata(typeof(WPFMessageBoxDetailsButtonControl)));
        }

        public string CollapsedHeaderText
        {
            get { return (string)GetValue(CollapsedHeaderTextProperty); }
            set { SetValue(CollapsedHeaderTextProperty, value); }
        }

        public static readonly DependencyProperty CollapsedHeaderTextProperty =
            DependencyProperty.Register("CollapsedHeaderText", typeof(string), typeof(WPFMessageBoxDetailsButtonControl), new UIPropertyMetadata(null));

        public string ExpandedHeaderText
        {
            get { return (string)GetValue(ExpandedHeaderTextProperty); }
            set { SetValue(ExpandedHeaderTextProperty, value); }
        }

        public static readonly DependencyProperty ExpandedHeaderTextProperty =
            DependencyProperty.Register("ExpandedHeaderText", typeof(string), typeof(WPFMessageBoxDetailsButtonControl), new UIPropertyMetadata(null));
    }
}
