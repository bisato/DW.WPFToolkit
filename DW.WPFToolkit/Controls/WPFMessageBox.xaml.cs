using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Input;
using DW.WPFToolkit.Internal;

namespace DW.WPFToolkit.Controls
{
    public partial class WPFMessageBox
    {
        public WPFMessageBox()
        {
            InitializeComponent();
            DataContext = this;

            AddHandler(WPFMessageBoxButtonsPanel.ClickEvent, (RoutedEventHandler)OnButtonClick);
        }

        private bool _closeByButtons;

        private void OnButtonClick(object sender, RoutedEventArgs e)
        {
            var panel = (WPFMessageBoxButtonsPanel)e.OriginalSource;
            Result = panel.Result;

            _closeByButtons = true;
            DialogResult = true;
        }

        public string Message
        {
            get { return (string)GetValue(MessageProperty); }
            set { SetValue(MessageProperty, value); }
        }

        public static readonly DependencyProperty MessageProperty =
            DependencyProperty.Register("Message", typeof(string), typeof(WPFMessageBoxImageControl), new PropertyMetadata(string.Empty));

        public WPFMessageBoxImage Image
        {
            get { return (WPFMessageBoxImage)GetValue(ImageProperty); }
            set { SetValue(ImageProperty, value); }
        }

        public static readonly DependencyProperty ImageProperty =
            DependencyProperty.Register("Image", typeof(WPFMessageBoxImage), typeof(WPFMessageBox), new PropertyMetadata(WPFMessageBoxImage.None));

        public WPFMessageBoxButtons Buttons
        {
            get { return (WPFMessageBoxButtons)GetValue(ButtonsProperty); }
            set { SetValue(ButtonsProperty, value); }
        }

        public static readonly DependencyProperty ButtonsProperty =
            DependencyProperty.Register("Buttons", typeof(WPFMessageBoxButtons), typeof(WPFMessageBox), new PropertyMetadata(WPFMessageBoxButtons.OK));

        public WPFMessageBoxResult DefaultButton
        {
            get { return (WPFMessageBoxResult)GetValue(DefaultButtonProperty); }
            set { SetValue(DefaultButtonProperty, value); }
        }

        public static readonly DependencyProperty DefaultButtonProperty =
            DependencyProperty.Register("DefaultButton", typeof(WPFMessageBoxResult), typeof(WPFMessageBox), new PropertyMetadata(WPFMessageBoxResult.None));

        public WPFMessageBoxResult Result
        {
            get { return (WPFMessageBoxResult)GetValue(ResultProperty); }
            set { SetValue(ResultProperty, value); }
        }

        public static readonly DependencyProperty ResultProperty =
            DependencyProperty.Register("Result", typeof(WPFMessageBoxResult), typeof(WPFMessageBox), new PropertyMetadata(WPFMessageBoxResult.None));

        protected override void OnSourceInitialized(EventArgs e)
        {
            base.OnSourceInitialized(e);

            WindowTitleBar.DisableSystemMenu(this);
            WindowTitleBar.DisableMinimizeButton(this);
            WindowTitleBar.DisableMaximizeButton(this);
            if (Buttons == WPFMessageBoxButtons.YesNo || Buttons == WPFMessageBoxButtons.AbortRetryIgnore)
                WindowTitleBar.DisableCloseButton(this);
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            if (!_closeByButtons && (Buttons == WPFMessageBoxButtons.YesNo || Buttons == WPFMessageBoxButtons.AbortRetryIgnore))
                e.Cancel = true;

            base.OnClosing(e);
        }

        protected override void OnPreviewKeyDown(KeyEventArgs e)
        {
            base.OnPreviewKeyUp(e);

            if (e.Key != Key.Escape)
                return;

            if (Buttons == WPFMessageBoxButtons.AbortRetryIgnore || Buttons == WPFMessageBoxButtons.YesNo)
                return;

            Close();
        }

        public static WPFMessageBoxResult Show(Window owner,
                                               string messageBoxText,
                                               string caption,
                                               WPFMessageBoxButtons buttons,
                                               WPFMessageBoxImage icon,
                                               WPFMessageBoxResult defaultButton,
                                               WPFMessageBoxOptions options)
        {
            var box = new WPFMessageBox();
            box.Owner = owner;
            box.Message = messageBoxText;
            box.Title = caption;
            box.Buttons = buttons;
            box.Image = icon;
            box.DefaultButton = defaultButton;
            var dialogResult = box.ShowDialog();
            if (dialogResult != true)
            {
                if (buttons == WPFMessageBoxButtons.OK)
                    return WPFMessageBoxResult.OK;
                return WPFMessageBoxResult.Cancel;
            }
            return box.Result;
        }
    }
}
