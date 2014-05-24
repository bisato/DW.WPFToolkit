using System;
using System.Runtime.InteropServices;
using System.Windows;
using System.Windows.Input;
using System.Windows.Interop;

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

        [DllImport("user32.dll")]
        static extern IntPtr GetSystemMenu(IntPtr windowHandle, bool revert);
        [DllImport("user32.dll")]
        static extern bool EnableMenuItem(IntPtr menuHandle, uint itemId, uint enable);

        private const uint MF_BYCOMMAND = 0x00000000;
        private const uint MF_GRAYED = 0x00000001;
        private const uint MF_ENABLED = 0x00000000;

        private const uint SC_CLOSE = 0xF060;

        private const int WM_SHOWWINDOW = 0x00000018;
        private const int WM_CLOSE = 0x10;

        protected override void OnSourceInitialized(EventArgs e)
        {
            base.OnSourceInitialized(e);

            var hwndSource = PresentationSource.FromVisual(this) as HwndSource;
            if (hwndSource != null)
                hwndSource.AddHook(HwndSourceHook);
        }

        private IntPtr HwndSourceHook(IntPtr hwnd, int msg, IntPtr wParam, IntPtr lParam, ref bool handled)
        {
            if (msg == WM_SHOWWINDOW)
            {
                if (!(Buttons == WPFMessageBoxButtons.YesNo || Buttons == WPFMessageBoxButtons.AbortRetryIgnore))
                    return IntPtr.Zero;

                var hMenu = GetSystemMenu(hwnd, false);
                if (hMenu != IntPtr.Zero)
                    EnableMenuItem(hMenu, SC_CLOSE, MF_BYCOMMAND | MF_GRAYED);
            }
            else if (msg == WM_CLOSE && !_closeByButtons)
            {
                handled = Buttons == WPFMessageBoxButtons.YesNo || Buttons == WPFMessageBoxButtons.AbortRetryIgnore;
            }
            return IntPtr.Zero;
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
