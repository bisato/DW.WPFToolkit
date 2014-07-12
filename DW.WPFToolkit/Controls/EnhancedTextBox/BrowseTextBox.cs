using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace DW.WPFToolkit.Controls
{
    /// <summary>
    /// Adds a browse button to the <see cref="DW.WPFToolkit.Controls.EnhancedTextBox" />.
    /// </summary>
    public class BrowseTextBox : EnhancedTextBox
    {
        static BrowseTextBox()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(BrowseTextBox), new FrameworkPropertyMetadata(typeof(BrowseTextBox)));
        }

        /// <summary>
        /// Gets or sets the text shown in the browse button.
        /// </summary>
        [DefaultValue("...")]
        public object BrowseButtonContent
        {
            get { return (object)GetValue(BrowseButtonContentProperty); }
            set { SetValue(BrowseButtonContentProperty, value); }
        }

        /// <summary>
        /// Identifies the <see cref="DW.WPFToolkit.Controls.BrowseTextBox.BrowseButtonContent" /> dependency property.
        /// </summary>
        public static readonly DependencyProperty BrowseButtonContentProperty =
            DependencyProperty.Register("BrowseButtonContent", typeof(object), typeof(BrowseTextBox), new UIPropertyMetadata("..."));

        /// <summary>
        /// Gets or sets the position where the browse button has to be placed inside the text box.
        /// </summary>
        [DefaultValue(Dock.Right)]
        public Dock BrowseButtonPosition
        {
            get { return (Dock)GetValue(BrowseButtonPositionProperty); }
            set { SetValue(BrowseButtonPositionProperty, value); }
        }

        /// <summary>
        /// Identifies the <see cref="DW.WPFToolkit.Controls.BrowseTextBox.BrowseButtonPosition" /> dependency property.
        /// </summary>
        public static readonly DependencyProperty BrowseButtonPositionProperty =
            DependencyProperty.Register("BrowseButtonPosition", typeof(Dock), typeof(BrowseTextBox), new UIPropertyMetadata(Dock.Right));

        /// <summary>
        /// Gets or sets the padding of the browse button.
        /// </summary>
        public Thickness BrowseButtonPadding
        {
            get { return (Thickness)GetValue(BrowseButtonPaddingProperty); }
            set { SetValue(BrowseButtonPaddingProperty, value); }
        }

        /// <summary>
        /// Identifies the <see cref="DW.WPFToolkit.Controls.BrowseTextBox.BrowseButtonPadding" /> dependency property.
        /// </summary>
        public static readonly DependencyProperty BrowseButtonPaddingProperty =
            DependencyProperty.Register("BrowseButtonPadding", typeof(Thickness), typeof(BrowseTextBox), new UIPropertyMetadata(new Thickness(5, 0, 5, 0)));

        /// <summary>
        /// Gets or sets the margin of the browse button.
        /// </summary>
        public Thickness BrowseButtonMargin
        {
            get { return (Thickness)GetValue(BrowseButtonMarginProperty); }
            set { SetValue(BrowseButtonMarginProperty, value); }
        }

        /// <summary>
        /// Identifies the <see cref="DW.WPFToolkit.Controls.BrowseTextBox.BrowseButtonMargin" /> dependency property.
        /// </summary>
        public static readonly DependencyProperty BrowseButtonMarginProperty =
            DependencyProperty.Register("BrowseButtonMargin", typeof(Thickness), typeof(BrowseTextBox), new UIPropertyMetadata(null));

        /// <summary>
        /// Gets or sets a value which indicates if the browse button is shown or not.
        /// </summary>
        [DefaultValue(true)]
        public bool ShowBrowseButton
        {
            get { return (bool)GetValue(ShowBrowseButtonProperty); }
            set { SetValue(ShowBrowseButtonProperty, value); }
        }

        /// <summary>
        /// Identifies the <see cref="DW.WPFToolkit.Controls.BrowseTextBox.ShowBrowseButton" /> dependency property.
        /// </summary>
        public static readonly DependencyProperty ShowBrowseButtonProperty =
            DependencyProperty.Register("ShowBrowseButton", typeof(bool), typeof(BrowseTextBox), new UIPropertyMetadata(true));

        /// <summary>
        /// Gets or sets the command to be executed by the browse button.
        /// </summary>
        [DefaultValue(null)]
        public ICommand BrowseCommand
        {
            get { return (ICommand)GetValue(BrowseCommandProperty); }
            set { SetValue(BrowseCommandProperty, value); }
        }

        /// <summary>
        /// Identifies the <see cref="DW.WPFToolkit.Controls.BrowseTextBox.BrowseCommand" /> dependency property.
        /// </summary>
        public static readonly DependencyProperty BrowseCommandProperty =
            DependencyProperty.Register("BrowseCommand", typeof(ICommand), typeof(BrowseTextBox), new UIPropertyMetadata(null));

        /// <summary>
        /// Gets or sets the command passed by the <see cref="DW.WPFToolkit.Controls.BrowseTextBox.BrowseCommand" />.
        /// </summary>
        [DefaultValue(null)]
        public object BrowseCommandParameter
        {
            get { return (object)GetValue(BrowseCommandParameterProperty); }
            set { SetValue(BrowseCommandParameterProperty, value); }
        }

        /// <summary>
        /// Identifies the <see cref="DW.WPFToolkit.Controls.BrowseTextBox.BrowseCommandParameter" /> dependency property.
        /// </summary>
        public static readonly DependencyProperty BrowseCommandParameterProperty =
            DependencyProperty.Register("BrowseCommandParameter", typeof(object), typeof(BrowseTextBox), new UIPropertyMetadata(null));

        /// <summary>
        /// Gets or sets the vertical alignment of the vertical alignment of the browse button.
        /// </summary>
        [DefaultValue(VerticalAlignment.Center)]
        public VerticalAlignment VerticalBrowseButtonAlignment
        {
            get { return (VerticalAlignment)GetValue(VerticalBrowseButtonAlignmentProperty); }
            set { SetValue(VerticalBrowseButtonAlignmentProperty, value); }
        }

        /// <summary>
        /// Identifies the <see cref="DW.WPFToolkit.Controls.BrowseTextBox.VerticalBrowseButtonAlignment" /> dependency property.
        /// </summary>
        public static readonly DependencyProperty VerticalBrowseButtonAlignmentProperty =
            DependencyProperty.Register("VerticalBrowseButtonAlignment", typeof(VerticalAlignment), typeof(BrowseTextBox), new UIPropertyMetadata(VerticalAlignment.Center));

        /// <summary>
        /// Gets or sets the horizontal alignment of the browse button.
        /// </summary>
        [DefaultValue(HorizontalAlignment.Center)]
        public HorizontalAlignment HorizontalBrowseButtonAlignment
        {
            get { return (HorizontalAlignment)GetValue(HorizontalBrowseButtonAlignmentProperty); }
            set { SetValue(HorizontalBrowseButtonAlignmentProperty, value); }
        }

        /// <summary>
        /// Identifies the <see cref="DW.WPFToolkit.Controls.BrowseTextBox.HorizontalBrowseButtonAlignment" /> dependency property.
        /// </summary>
        public static readonly DependencyProperty HorizontalBrowseButtonAlignmentProperty =
            DependencyProperty.Register("HorizontalBrowseButtonAlignment", typeof(HorizontalAlignment), typeof(BrowseTextBox), new UIPropertyMetadata(HorizontalAlignment.Center));
    }
}
