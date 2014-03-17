using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace DW.WPFToolkit.Controls
{
    public class BrowseTextBox : EnhancedTextBox
    {
        static BrowseTextBox()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(BrowseTextBox), new FrameworkPropertyMetadata(typeof(BrowseTextBox)));
        }

        public object BrowseButtonContent
        {
            get { return (object)GetValue(BrowseButtonContentProperty); }
            set { SetValue(BrowseButtonContentProperty, value); }
        }

        public static readonly DependencyProperty BrowseButtonContentProperty =
            DependencyProperty.Register("BrowseButtonContent", typeof(object), typeof(BrowseTextBox), new UIPropertyMetadata("..."));

        public Dock BrowseButtonPosition
        {
            get { return (Dock)GetValue(BrowseButtonPositionProperty); }
            set { SetValue(BrowseButtonPositionProperty, value); }
        }

        public static readonly DependencyProperty BrowseButtonPositionProperty =
            DependencyProperty.Register("BrowseButtonPosition", typeof(Dock), typeof(BrowseTextBox), new UIPropertyMetadata(Dock.Right));

        public Thickness BrowseButtonPadding
        {
            get { return (Thickness)GetValue(BrowseButtonPaddingProperty); }
            set { SetValue(BrowseButtonPaddingProperty, value); }
        }

        public static readonly DependencyProperty BrowseButtonPaddingProperty =
            DependencyProperty.Register("BrowseButtonPadding", typeof(Thickness), typeof(BrowseTextBox), new UIPropertyMetadata(new Thickness(5, 0, 5, 0)));

        public Thickness BrowseButtonMargin
        {
            get { return (Thickness)GetValue(BrowseButtonMarginProperty); }
            set { SetValue(BrowseButtonMarginProperty, value); }
        }

        public static readonly DependencyProperty BrowseButtonMarginProperty =
            DependencyProperty.Register("BrowseButtonMargin", typeof(Thickness), typeof(BrowseTextBox), new UIPropertyMetadata(null));

        public bool ShowBrowseButton
        {
            get { return (bool)GetValue(ShowBrowseButtonProperty); }
            set { SetValue(ShowBrowseButtonProperty, value); }
        }

        public static readonly DependencyProperty ShowBrowseButtonProperty =
            DependencyProperty.Register("ShowBrowseButton", typeof(bool), typeof(BrowseTextBox), new UIPropertyMetadata(true));

        public ICommand BrowseCommand
        {
            get { return (ICommand)GetValue(BrowseCommandProperty); }
            set { SetValue(BrowseCommandProperty, value); }
        }

        public static readonly DependencyProperty BrowseCommandProperty =
            DependencyProperty.Register("BrowseCommand", typeof(ICommand), typeof(BrowseTextBox), new UIPropertyMetadata(null));

        public object BrowseCommandParameter
        {
            get { return (object)GetValue(BrowseCommandParameterProperty); }
            set { SetValue(BrowseCommandParameterProperty, value); }
        }

        public static readonly DependencyProperty BrowseCommandParameterProperty =
            DependencyProperty.Register("BrowseCommandParameter", typeof(object), typeof(BrowseTextBox), new UIPropertyMetadata(null));

        public VerticalAlignment VerticalBrowseButtonAlignment
        {
            get { return (VerticalAlignment)GetValue(VerticalBrowseButtonAlignmentProperty); }
            set { SetValue(VerticalBrowseButtonAlignmentProperty, value); }
        }

        public static readonly DependencyProperty VerticalBrowseButtonAlignmentProperty =
            DependencyProperty.Register("VerticalBrowseButtonAlignment", typeof(VerticalAlignment), typeof(BrowseTextBox), new UIPropertyMetadata(VerticalAlignment.Center));

        public HorizontalAlignment HorizontalBrowseButtonAlignment
        {
            get { return (HorizontalAlignment)GetValue(HorizontalBrowseButtonAlignmentProperty); }
            set { SetValue(HorizontalBrowseButtonAlignmentProperty, value); }
        }

        public static readonly DependencyProperty HorizontalBrowseButtonAlignmentProperty =
            DependencyProperty.Register("HorizontalBrowseButtonAlignment", typeof(HorizontalAlignment), typeof(BrowseTextBox), new UIPropertyMetadata(HorizontalAlignment.Center));
    }
}
