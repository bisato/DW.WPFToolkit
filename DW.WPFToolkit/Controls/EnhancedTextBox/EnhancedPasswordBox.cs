using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace DW.WPFToolkit.Controls
{
    [TemplatePart(Name = "PART_InfoText", Type = typeof(TextBlock))]
    [TemplatePart(Name = "PART_PasswordBox", Type = typeof(PasswordBox))]
    public class EnhancedPasswordBox : Control
    {
        static EnhancedPasswordBox()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(EnhancedPasswordBox), new FrameworkPropertyMetadata(typeof(EnhancedPasswordBox)));
        }

        public EnhancedPasswordBox()
        {
            Loaded += new RoutedEventHandler(InfoTextBox_Loaded);
        }

        private void InfoTextBox_Loaded(object sender, RoutedEventArgs e)
        {
            RefreshInfoAppearance();
            if (!string.IsNullOrEmpty(Password))
                TakePasswordOver(this, Password);
        }

        private bool _selfChange;
        private PasswordBox _innerPasswordBox;
        private TextBlock _infoText;

        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();

            _innerPasswordBox = GetTemplateChild("PART_PasswordBox") as PasswordBox;
            if (_innerPasswordBox != null)
            {
                _innerPasswordBox.PasswordChanged += PasswordBox_PasswordChanged;

                _innerPasswordBox.GotFocus += InnerPasswordBox_GotFocus;
                _innerPasswordBox.LostFocus += InnerPasswordBox_LostFocus;
                _innerPasswordBox.PasswordChanged += InnerPasswordBox_PasswordChanged;
            }

            RefreshInfoAppearance();
        }

        private void InnerPasswordBox_GotFocus(object sender, RoutedEventArgs e)
        {
            if (GetInfoTextBlock())
            {
                if (InfoAppearance != InfoAppearance.OnEmpty)
                    _infoText.Visibility = Visibility.Collapsed;
            }
        }

        private void InnerPasswordBox_LostFocus(object sender, RoutedEventArgs e)
        {
            if (GetInfoTextBlock())
            {
                if (InfoAppearance != InfoAppearance.None &&
                    string.IsNullOrEmpty(Password))
                    _infoText.Visibility = System.Windows.Visibility.Visible;
            }
        }

        private void InnerPasswordBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if (GetInfoTextBlock())
            {
                var passwordBox = (PasswordBox)sender;
                if (string.IsNullOrEmpty(passwordBox.Password))
                {
                    if (InfoAppearance == InfoAppearance.OnEmpty)
                        _infoText.Visibility = Visibility.Visible;
                }
                else if (_infoText.Visibility == Visibility.Visible)
                    _infoText.Visibility = Visibility.Collapsed;
            }
        }

        protected override void OnGotFocus(RoutedEventArgs e)
        {
            if (_innerPasswordBox != null)
                _innerPasswordBox.Focus();
            base.OnGotFocus(e);
        }

        private void PasswordBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            var box = (PasswordBox)sender;
            _selfChange = true;
            Password = box.Password;
            _selfChange = false;
        }
        
        private static void OnPasswordChanged(DependencyObject o, DependencyPropertyChangedEventArgs e)
        {
            TakePasswordOver(o as EnhancedPasswordBox, e.NewValue);
        }

        private static void TakePasswordOver(EnhancedPasswordBox control, object password)
        {
            if (!control._selfChange &&
                password != null &&
                control._innerPasswordBox != null)
            {
                control._innerPasswordBox.PasswordChanged -= control.PasswordBox_PasswordChanged;
                control._innerPasswordBox.Password = password.ToString();
                control._innerPasswordBox.PasswordChanged += control.PasswordBox_PasswordChanged;
            }
        }

        private void RefreshInfoAppearance()
        {
            if (GetInfoTextBlock())
            {
                if (InfoAppearance == InfoAppearance.None)
                    _infoText.Visibility = Visibility.Collapsed;
                if (!string.IsNullOrEmpty(Password))
                    _infoText.Visibility = Visibility.Collapsed;
            }
        }

        private bool GetInfoTextBlock()
        {
            if (_infoText == null)
                _infoText = GetTemplateChild("PART_InfoText") as TextBlock;
            return _infoText != null;
        }

        public InfoAppearance InfoAppearance
        {
            get { return (InfoAppearance)GetValue(InfoAppearanceProperty); }
            set { SetValue(InfoAppearanceProperty, value); }
        }

        /// <summary>
        /// Identifies the <see cref="DW.WPFToolkit.Controls.EnhancedPasswordBox.InfoAppearance" /> dependency property.
        /// </summary>
        public static readonly DependencyProperty InfoAppearanceProperty =
            DependencyProperty.Register("InfoAppearance", typeof(InfoAppearance), typeof(EnhancedPasswordBox), new UIPropertyMetadata(InfoAppearance.OnLostFocus, OnInfoAppearanceChanged));

        private static void OnInfoAppearanceChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            ((EnhancedPasswordBox)sender).RefreshInfoAppearance();
        }

        public string InfoText
        {
            get { return (string)GetValue(InfoTextProperty); }
            set { SetValue(InfoTextProperty, value); }
        }

        /// <summary>
        /// Identifies the <see cref="DW.WPFToolkit.Controls.EnhancedPasswordBox.InfoText" /> dependency property.
        /// </summary>
        public static readonly DependencyProperty InfoTextProperty =
            DependencyProperty.Register("InfoText", typeof(string), typeof(EnhancedPasswordBox), new UIPropertyMetadata(""));

        public FontStyle InfoTextFontStyle
        {
            get { return (FontStyle)GetValue(InfoTextFontStyleProperty); }
            set { SetValue(InfoTextFontStyleProperty, value); }
        }

        /// <summary>
        /// Identifies the <see cref="DW.WPFToolkit.Controls.EnhancedPasswordBox.InfoTextFontStyle" /> dependency property.
        /// </summary>
        public static readonly DependencyProperty InfoTextFontStyleProperty =
            DependencyProperty.Register("InfoTextFontStyle", typeof(FontStyle), typeof(EnhancedPasswordBox), new UIPropertyMetadata(FontStyles.Italic));

        public Brush InfoTextForeground
        {
            get { return (Brush)GetValue(InfoTextForegroundProperty); }
            set { SetValue(InfoTextForegroundProperty, value); }
        }

        /// <summary>
        /// Identifies the <see cref="DW.WPFToolkit.Controls.EnhancedPasswordBox.InfoTextForeground" /> dependency property.
        /// </summary>
        public static readonly DependencyProperty InfoTextForegroundProperty =
            DependencyProperty.Register("InfoTextForeground", typeof(Brush), typeof(EnhancedPasswordBox), new UIPropertyMetadata(Brushes.Gray));

        public HorizontalAlignment InfoTextHorizontalAlignment
        {
            get { return (HorizontalAlignment)GetValue(InfoTextHorizontalAlignmentProperty); }
            set { SetValue(InfoTextHorizontalAlignmentProperty, value); }
        }

        /// <summary>
        /// Identifies the <see cref="DW.WPFToolkit.Controls.EnhancedPasswordBox.InfoTextHorizontalAlignment" /> dependency property.
        /// </summary>
        public static readonly DependencyProperty InfoTextHorizontalAlignmentProperty =
            DependencyProperty.Register("InfoTextHorizontalAlignment", typeof(HorizontalAlignment), typeof(EnhancedPasswordBox), new UIPropertyMetadata(HorizontalAlignment.Left));

        public VerticalAlignment InfoTextVerticalAlignment
        {
            get { return (VerticalAlignment)GetValue(InfoTextVerticalAlignmentProperty); }
            set { SetValue(InfoTextVerticalAlignmentProperty, value); }
        }

        /// <summary>
        /// Identifies the <see cref="DW.WPFToolkit.Controls.EnhancedPasswordBox.InfoTextVerticalAlignment" /> dependency property.
        /// </summary>
        public static readonly DependencyProperty InfoTextVerticalAlignmentProperty =
            DependencyProperty.Register("InfoTextVerticalAlignment", typeof(VerticalAlignment), typeof(EnhancedPasswordBox), new UIPropertyMetadata(VerticalAlignment.Center));

        public Thickness InfoTextMargin
        {
            get { return (Thickness)GetValue(InfoTextMarginProperty); }
            set { SetValue(InfoTextMarginProperty, value); }
        }

        /// <summary>
        /// Identifies the <see cref="DW.WPFToolkit.Controls.EnhancedPasswordBox.InfoTextMargin" /> dependency property.
        /// </summary>
        public static readonly DependencyProperty InfoTextMarginProperty =
            DependencyProperty.Register("InfoTextMargin", typeof(Thickness), typeof(EnhancedPasswordBox), new UIPropertyMetadata(null));

        public Style InfoTextStyle
        {
            get { return (Style)GetValue(InfoTextStyleProperty); }
            set { SetValue(InfoTextStyleProperty, value); }
        }

        /// <summary>
        /// Identifies the <see cref="DW.WPFToolkit.Controls.EnhancedPasswordBox.InfoTextStyle" /> dependency property.
        /// </summary>
        public static readonly DependencyProperty InfoTextStyleProperty =
            DependencyProperty.Register("InfoTextStyle", typeof(Style), typeof(EnhancedPasswordBox), new UIPropertyMetadata(null));

        public string Password
        {
            get { return (string)GetValue(PasswordProperty); }
            set { SetValue(PasswordProperty, value); }
        }

        /// <summary>
        /// Identifies the <see cref="DW.WPFToolkit.Controls.EnhancedPasswordBox.Password" /> dependency property.
        /// </summary>
        public static readonly DependencyProperty PasswordProperty =
            DependencyProperty.Register("Password", typeof(string), typeof(EnhancedPasswordBox), new FrameworkPropertyMetadata(string.Empty, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault, OnPasswordChanged));
    }
}
