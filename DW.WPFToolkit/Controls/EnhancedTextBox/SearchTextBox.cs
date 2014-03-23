using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace DW.WPFToolkit.Controls
{
    /// <summary>
    /// Adds search and cancel buttons to the EnhancedTextBox to represent a search box shown like in the Windows explorer.
    /// </summary>
    public class SearchTextBox : EnhancedTextBox
    {
        static SearchTextBox()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(SearchTextBox), new FrameworkPropertyMetadata(typeof(SearchTextBox)));
        }

        public Dock SearchButtonPosition
        {
            get { return (Dock)GetValue(SearchButtonPositionProperty); }
            set { SetValue(SearchButtonPositionProperty, value); }
        }

        /// <summary>
        /// Identifies the <see cref="DW.WPFToolkit.Controls.SearchTextBox.SearchButtonPosition" /> dependency property.
        /// </summary>
        public static readonly DependencyProperty SearchButtonPositionProperty =
            DependencyProperty.Register("SearchButtonPosition", typeof(Dock), typeof(SearchTextBox), new UIPropertyMetadata(Dock.Right));

        public Thickness SearchButtonMargin
        {
            get { return (Thickness)GetValue(SearchButtonMarginProperty); }
            set { SetValue(SearchButtonMarginProperty, value); }
        }

        /// <summary>
        /// Identifies the <see cref="DW.WPFToolkit.Controls.SearchTextBox.SearchButtonMargin" /> dependency property.
        /// </summary>
        public static readonly DependencyProperty SearchButtonMarginProperty =
            DependencyProperty.Register("SearchButtonMargin", typeof(Thickness), typeof(SearchTextBox), new UIPropertyMetadata(null));

        public Thickness SearchButtonPadding
        {
            get { return (Thickness)GetValue(SearchButtonPaddingProperty); }
            set { SetValue(SearchButtonPaddingProperty, value); }
        }

        /// <summary>
        /// Identifies the <see cref="DW.WPFToolkit.Controls.SearchTextBox.SearchButtonPadding" /> dependency property.
        /// </summary>
        public static readonly DependencyProperty SearchButtonPaddingProperty =
            DependencyProperty.Register("SearchButtonPadding", typeof(Thickness), typeof(SearchTextBox), new UIPropertyMetadata(null));

        public VerticalAlignment VerticalSearchButtonAlignment
        {
            get { return (VerticalAlignment)GetValue(VerticalSearchButtonAlignmentProperty); }
            set { SetValue(VerticalSearchButtonAlignmentProperty, value); }
        }

        /// <summary>
        /// Identifies the <see cref="DW.WPFToolkit.Controls.SearchTextBox.VerticalSearchButtonAlignment" /> dependency property.
        /// </summary>
        public static readonly DependencyProperty VerticalSearchButtonAlignmentProperty =
            DependencyProperty.Register("VerticalSearchButtonAlignment", typeof(VerticalAlignment), typeof(SearchTextBox), new UIPropertyMetadata(VerticalAlignment.Center));

        public HorizontalAlignment HorizontalSearchButtonAlignment
        {
            get { return (HorizontalAlignment)GetValue(HorizontalSearchButtonAlignmentProperty); }
            set { SetValue(HorizontalSearchButtonAlignmentProperty, value); }
        }

        /// <summary>
        /// Identifies the <see cref="DW.WPFToolkit.Controls.SearchTextBox.HorizontalSearchButtonAlignment" /> dependency property.
        /// </summary>
        public static readonly DependencyProperty HorizontalSearchButtonAlignmentProperty =
            DependencyProperty.Register("HorizontalSearchButtonAlignment", typeof(HorizontalAlignment), typeof(SearchTextBox), new UIPropertyMetadata(HorizontalAlignment.Center));

        public bool ShowSearchButton
        {
            get { return (bool)GetValue(ShowSearchButtonProperty); }
            set { SetValue(ShowSearchButtonProperty, value); }
        }

        /// <summary>
        /// Identifies the <see cref="DW.WPFToolkit.Controls.SearchTextBox.ShowSearchButton" /> dependency property.
        /// </summary>
        public static readonly DependencyProperty ShowSearchButtonProperty =
            DependencyProperty.Register("ShowSearchButton", typeof(bool), typeof(SearchTextBox), new UIPropertyMetadata(true));

        public ICommand SearchCommand
        {
            get { return (ICommand)GetValue(SearchCommandProperty); }
            set { SetValue(SearchCommandProperty, value); }
        }

        /// <summary>
        /// Identifies the <see cref="DW.WPFToolkit.Controls.SearchTextBox.SearchCommand" /> dependency property.
        /// </summary>
        public static readonly DependencyProperty SearchCommandProperty =
            DependencyProperty.Register("SearchCommand", typeof(ICommand), typeof(SearchTextBox), new UIPropertyMetadata(null));

        public object SearchCommandParameter
        {
            get { return (object)GetValue(SearchCommandParameterProperty); }
            set { SetValue(SearchCommandParameterProperty, value); }
        }

        /// <summary>
        /// Identifies the <see cref="DW.WPFToolkit.Controls.SearchTextBox.SearchCommandParameter" /> dependency property.
        /// </summary>
        public static readonly DependencyProperty SearchCommandParameterProperty =
            DependencyProperty.Register("SearchCommandParameter", typeof(object), typeof(SearchTextBox), new UIPropertyMetadata(null));

        public ICommand CancelCommand
        {
            get { return (ICommand)GetValue(CancelCommandProperty); }
            set { SetValue(CancelCommandProperty, value); }
        }

        /// <summary>
        /// Identifies the <see cref="DW.WPFToolkit.Controls.SearchTextBox.CancelCommand" /> dependency property.
        /// </summary>
        public static readonly DependencyProperty CancelCommandProperty =
            DependencyProperty.Register("CancelCommand", typeof(ICommand), typeof(SearchTextBox), new PropertyMetadata(null));

        public object CancelCommandParameter
        {
            get { return (object)GetValue(CancelCommandParameterProperty); }
            set { SetValue(CancelCommandParameterProperty, value); }
        }

        /// <summary>
        /// Identifies the <see cref="DW.WPFToolkit.Controls.SearchTextBox.CancelCommandParameter" /> dependency property.
        /// </summary>
        public static readonly DependencyProperty CancelCommandParameterProperty =
            DependencyProperty.Register("CancelCommandParameter", typeof(object), typeof(SearchTextBox), new PropertyMetadata(null));

        public bool IsSearching
        {
            get { return (bool)GetValue(IsSearchingProperty); }
            set { SetValue(IsSearchingProperty, value); }
        }

        /// <summary>
        /// Identifies the <see cref="DW.WPFToolkit.Controls.." /> dependency property.
        /// </summary>
        public static readonly DependencyProperty IsSearchingProperty =
            DependencyProperty.Register("IsSearching", typeof(bool), typeof(SearchTextBox), new UIPropertyMetadata(false));
    }
}
