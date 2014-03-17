using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace DW.WPFToolkit.Controls
{
    [TemplatePart(Name = "PART_InfoText", Type = typeof(TextBlock))]
    public class EnhancedTextBox : TextBox
    {
        static EnhancedTextBox()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(EnhancedTextBox), new FrameworkPropertyMetadata(typeof(EnhancedTextBox)));
        }

        public EnhancedTextBox()
        {
            Loaded += InfoTextBox_Loaded;
            PreviewDragOver += DroppableTextBox_PreviewDragOver;
            PreviewDrop += DroppableTextBox_PreviewDrop;
        }

        private void InfoTextBox_Loaded(object sender, RoutedEventArgs e)
        {
            RefreshInfoAppearance();
        }

        private TextBlock _infoText;

        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();

            RefreshInfoAppearance();
        }

        protected override void OnGotFocus(RoutedEventArgs e)
        {
            base.OnGotFocus(e);

            if (GetInfoTextBlock())
            {
                if (InfoAppearance != InfoAppearance.OnEmpty)
                    _infoText.Visibility = Visibility.Collapsed;
            }
        }

        protected override void OnLostFocus(RoutedEventArgs e)
        {
            base.OnLostFocus(e);

            if (GetInfoTextBlock())
            {
                if (InfoAppearance != InfoAppearance.None &&
                    string.IsNullOrEmpty(Text))
                    _infoText.Visibility = System.Windows.Visibility.Visible;
            }
        }

        protected override void OnTextChanged(TextChangedEventArgs e)
        {
            base.OnTextChanged(e);

            if (GetInfoTextBlock())
            {
                if (string.IsNullOrEmpty(Text))
                {
                    if (InfoAppearance == InfoAppearance.OnEmpty)
                        _infoText.Visibility = Visibility.Visible;
                }
                else if (_infoText.Visibility == Visibility.Visible)
                    _infoText.Visibility = Visibility.Collapsed;
            }
        }

        private void RefreshInfoAppearance()
        {
            if (GetInfoTextBlock())
            {
                if (InfoAppearance == InfoAppearance.None ||
                    !string.IsNullOrEmpty(Text))
                    _infoText.Visibility = Visibility.Collapsed;
            }
        }

        private bool GetInfoTextBlock()
        {
            if (_infoText == null)
                _infoText = GetTemplateChild("PART_InfoText") as TextBlock;
            return _infoText != null;
        }

        private void DroppableTextBox_PreviewDragOver(object sender, DragEventArgs e)
        {
            if (!string.IsNullOrEmpty(GetContent(e)))
                e.Effects = DragDropEffect;
            else
                e.Effects = DragDropEffects.None;
            e.Handled = true;
        }

        private void DroppableTextBox_PreviewDrop(object sender, DragEventArgs e)
        {
            e.Handled = true;
            var contentText = GetContent(e);
            if (string.IsNullOrEmpty(contentText))
                return;
            (sender as TextBox).Text = contentText;
            this.Focus();
        }

        private string GetContent(DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop, true))
            {
                var content = e.Data.GetData(DataFormats.FileDrop, true) as string[];
                if (content != null)
                {
                    switch (AllowedDropType)
                    {
                        case DroppableTypes.File:
                            if (content.Length == 1 &&
                                File.Exists(content[0]))
                                return content[0];
                            break;
                        case DroppableTypes.Files:
                            foreach (var value in content)
                            {
                                if (!File.Exists(value))
                                    return null;
                            }
                            return string.Join(Separator, content);
                        case DroppableTypes.FilesFolders:
                            foreach (var value in content)
                            {
                                if (!File.Exists(value) &&
                                    !Directory.Exists(value))
                                    return null;
                            }
                            return string.Join(Separator, content);
                        case DroppableTypes.Folder:
                            if (content.Length == 1 &&
                                Directory.Exists(content[0]))
                                return content[0];
                            break;
                        case DroppableTypes.Folders:
                            foreach (string value in content)
                            {
                                if (!Directory.Exists(value))
                                    return null;
                            }
                            return string.Join(Separator, content);
                    }
                }
            }
            return null;
        }

        public InfoAppearance InfoAppearance
        {
            get { return (InfoAppearance)GetValue(InfoAppearanceProperty); }
            set { SetValue(InfoAppearanceProperty, value); }
        }

        public static readonly DependencyProperty InfoAppearanceProperty =
            DependencyProperty.Register("InfoAppearance", typeof(InfoAppearance), typeof(EnhancedTextBox), new UIPropertyMetadata(InfoAppearance.OnLostFocus, OnInfoAppearanceChanged));

        private static void OnInfoAppearanceChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            ((EnhancedTextBox)sender).RefreshInfoAppearance();
        }

        public string InfoText
        {
            get { return (string)GetValue(InfoTextProperty); }
            set { SetValue(InfoTextProperty, value); }
        }

        public static readonly DependencyProperty InfoTextProperty =
            DependencyProperty.Register("InfoText", typeof(string), typeof(EnhancedTextBox), new UIPropertyMetadata(""));

        public FontStyle InfoTextFontStyle
        {
            get { return (FontStyle)GetValue(InfoTextFontStyleProperty); }
            set { SetValue(InfoTextFontStyleProperty, value); }
        }

        public static readonly DependencyProperty InfoTextFontStyleProperty =
            DependencyProperty.Register("InfoTextFontStyle", typeof(FontStyle), typeof(EnhancedTextBox), new UIPropertyMetadata(FontStyles.Italic));

        public Brush InfoTextForeground
        {
            get { return (Brush)GetValue(InfoTextForegroundProperty); }
            set { SetValue(InfoTextForegroundProperty, value); }
        }

        public static readonly DependencyProperty InfoTextForegroundProperty =
            DependencyProperty.Register("InfoTextForeground", typeof(Brush), typeof(EnhancedTextBox), new UIPropertyMetadata(Brushes.Gray));

        public HorizontalAlignment InfoTextHorizontalAlignment
        {
            get { return (HorizontalAlignment)GetValue(InfoTextHorizontalAlignmentProperty); }
            set { SetValue(InfoTextHorizontalAlignmentProperty, value); }
        }

        public static readonly DependencyProperty InfoTextHorizontalAlignmentProperty =
            DependencyProperty.Register("InfoTextHorizontalAlignment", typeof(HorizontalAlignment), typeof(EnhancedTextBox), new UIPropertyMetadata(HorizontalAlignment.Left));

        public VerticalAlignment InfoTextVerticalAlignment
        {
            get { return (VerticalAlignment)GetValue(InfoTextVerticalAlignmentProperty); }
            set { SetValue(InfoTextVerticalAlignmentProperty, value); }
        }

        public static readonly DependencyProperty InfoTextVerticalAlignmentProperty =
            DependencyProperty.Register("InfoTextVerticalAlignment", typeof(VerticalAlignment), typeof(EnhancedTextBox), new UIPropertyMetadata(VerticalAlignment.Center));

        public Thickness InfoTextMargin
        {
            get { return (Thickness)GetValue(InfoTextMarginProperty); }
            set { SetValue(InfoTextMarginProperty, value); }
        }

        public static readonly DependencyProperty InfoTextMarginProperty =
            DependencyProperty.Register("InfoTextMargin", typeof(Thickness), typeof(EnhancedTextBox), new UIPropertyMetadata(null));

        public Style InfoTextStyle
        {
            get { return (Style)GetValue(InfoTextStyleProperty); }
            set { SetValue(InfoTextStyleProperty, value); }
        }

        public static readonly DependencyProperty InfoTextStyleProperty =
            DependencyProperty.Register("InfoTextStyle", typeof(Style), typeof(EnhancedTextBox), new UIPropertyMetadata(null));

        public object FirstControl
        {
            get { return (object)GetValue(FirstControlProperty); }
            set { SetValue(FirstControlProperty, value); }
        }

        public static readonly DependencyProperty FirstControlProperty =
            DependencyProperty.Register("FirstControl", typeof(object), typeof(EnhancedTextBox), new UIPropertyMetadata(null));

        public Dock FirstControlPosition
        {
            get { return (Dock)GetValue(FirstControlPositionProperty); }
            set { SetValue(FirstControlPositionProperty, value); }
        }

        public static readonly DependencyProperty FirstControlPositionProperty =
            DependencyProperty.Register("FirstControlPosition", typeof(Dock), typeof(EnhancedTextBox), new UIPropertyMetadata(Dock.Left));

        public object SecondControl
        {
            get { return (object)GetValue(SecondControlProperty); }
            set { SetValue(SecondControlProperty, value); }
        }

        public static readonly DependencyProperty SecondControlProperty =
            DependencyProperty.Register("SecondControl", typeof(object), typeof(EnhancedTextBox), new UIPropertyMetadata(null));

        public Dock SecondControlPosition
        {
            get { return (Dock)GetValue(SecondControlPositionProperty); }
            set { SetValue(SecondControlPositionProperty, value); }
        }

        public static readonly DependencyProperty SecondControlPositionProperty =
            DependencyProperty.Register("SecondControlPosition", typeof(Dock), typeof(EnhancedTextBox), new UIPropertyMetadata(Dock.Right));

        public DroppableTypes AllowedDropType
        {
            get { return (DroppableTypes)GetValue(AllowedDropTypeProperty); }
            set { SetValue(AllowedDropTypeProperty, value); }
        }

        public static readonly DependencyProperty AllowedDropTypeProperty =
            DependencyProperty.Register("AllowedDropType", typeof(DroppableTypes), typeof(EnhancedTextBox), new UIPropertyMetadata(DroppableTypes.File));

        public string Separator
        {
            get { return (string)GetValue(SeparatorProperty); }
            set { SetValue(SeparatorProperty, value); }
        }

        public static readonly DependencyProperty SeparatorProperty =
            DependencyProperty.Register("Separator", typeof(string), typeof(EnhancedTextBox), new UIPropertyMetadata("; "));

        public DragDropEffects DragDropEffect
        {
            get { return (DragDropEffects)GetValue(DragDropEffectProperty); }
            set { SetValue(DragDropEffectProperty, value); }
        }

        public static readonly DependencyProperty DragDropEffectProperty =
            DependencyProperty.Register("DragDropEffect", typeof(DragDropEffects), typeof(EnhancedTextBox), new UIPropertyMetadata(DragDropEffects.Link));
    }
}
