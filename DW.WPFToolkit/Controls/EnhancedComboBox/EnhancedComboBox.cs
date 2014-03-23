using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace DW.WPFToolkit.Controls
{
    public class EnhancedComboBox : ComboBox
    {
        static EnhancedComboBox()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(EnhancedComboBox), new FrameworkPropertyMetadata(typeof(EnhancedComboBox)));
        }

        public InfoAppearance InfoAppearance
        {
            get { return (InfoAppearance)GetValue(InfoAppearanceProperty); }
            set { SetValue(InfoAppearanceProperty, value); }
        }

        /// <summary>
        /// Identifies the <see cref="DW.WPFToolkit.Controls.EnhancedComboBox.InfoAppearance" /> dependency property.
        /// </summary>
        public static readonly DependencyProperty InfoAppearanceProperty =
            DependencyProperty.Register("InfoAppearance", typeof(InfoAppearance), typeof(EnhancedComboBox), new UIPropertyMetadata(InfoAppearance.OnLostFocus));

        public string InfoText
        {
            get { return (string)GetValue(InfoTextProperty); }
            set { SetValue(InfoTextProperty, value); }
        }

        /// <summary>
        /// Identifies the <see cref="DW.WPFToolkit.Controls.EnhancedComboBox.InfoText" /> dependency property.
        /// </summary>
        public static readonly DependencyProperty InfoTextProperty =
            DependencyProperty.Register("InfoText", typeof(string), typeof(EnhancedComboBox), new UIPropertyMetadata(""));

        public FontStyle InfoTextFontStyle
        {
            get { return (FontStyle)GetValue(InfoTextFontStyleProperty); }
            set { SetValue(InfoTextFontStyleProperty, value); }
        }

        /// <summary>
        /// Identifies the <see cref="DW.WPFToolkit.Controls.EnhancedComboBox.InfoTextFontStyle" /> dependency property.
        /// </summary>
        public static readonly DependencyProperty InfoTextFontStyleProperty =
            DependencyProperty.Register("InfoTextFontStyle", typeof(FontStyle), typeof(EnhancedComboBox), new UIPropertyMetadata(FontStyles.Italic));

        public Brush InfoTextForeground
        {
            get { return (Brush)GetValue(InfoTextForegroundProperty); }
            set { SetValue(InfoTextForegroundProperty, value); }
        }

        /// <summary>
        /// Identifies the <see cref="DW.WPFToolkit.Controls.EnhancedComboBox.InfoTextForeground" /> dependency property.
        /// </summary>
        public static readonly DependencyProperty InfoTextForegroundProperty =
            DependencyProperty.Register("InfoTextForeground", typeof(Brush), typeof(EnhancedComboBox), new UIPropertyMetadata(Brushes.Gray));

        public HorizontalAlignment InfoTextHorizontalAlignment
        {
            get { return (HorizontalAlignment)GetValue(InfoTextHorizontalAlignmentProperty); }
            set { SetValue(InfoTextHorizontalAlignmentProperty, value); }
        }

        /// <summary>
        /// Identifies the <see cref="DW.WPFToolkit.Controls.EnhancedComboBox.InfoTextHorizontalAlignment" /> dependency property.
        /// </summary>
        public static readonly DependencyProperty InfoTextHorizontalAlignmentProperty =
            DependencyProperty.Register("InfoTextHorizontalAlignment", typeof(HorizontalAlignment), typeof(EnhancedComboBox), new UIPropertyMetadata(HorizontalAlignment.Left));

        public VerticalAlignment InfoTextVerticalAlignment
        {
            get { return (VerticalAlignment)GetValue(InfoTextVerticalAlignmentProperty); }
            set { SetValue(InfoTextVerticalAlignmentProperty, value); }
        }

        /// <summary>
        /// Identifies the <see cref="DW.WPFToolkit.Controls.EnhancedComboBox.InfoTextVerticalAlignment" /> dependency property.
        /// </summary>
        public static readonly DependencyProperty InfoTextVerticalAlignmentProperty =
            DependencyProperty.Register("InfoTextVerticalAlignment", typeof(VerticalAlignment), typeof(EnhancedComboBox), new UIPropertyMetadata(VerticalAlignment.Center));

        public Thickness InfoTextMargin
        {
            get { return (Thickness)GetValue(InfoTextMarginProperty); }
            set { SetValue(InfoTextMarginProperty, value); }
        }

        /// <summary>
        /// Identifies the <see cref="DW.WPFToolkit.Controls.EnhancedComboBox.InfoTextMargin" /> dependency property.
        /// </summary>
        public static readonly DependencyProperty InfoTextMarginProperty =
            DependencyProperty.Register("InfoTextMargin", typeof(Thickness), typeof(EnhancedComboBox), new UIPropertyMetadata(null));

        public Style InfoTextStyle
        {
            get { return (Style)GetValue(InfoTextStyleProperty); }
            set { SetValue(InfoTextStyleProperty, value); }
        }

        /// <summary>
        /// Identifies the <see cref="DW.WPFToolkit.Controls.EnhancedComboBox.InfoTextStyle" /> dependency property.
        /// </summary>
        public static readonly DependencyProperty InfoTextStyleProperty =
            DependencyProperty.Register("InfoTextStyle", typeof(Style), typeof(EnhancedComboBox), new UIPropertyMetadata(null));
    }
}
