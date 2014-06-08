using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Input;
using DW.WPFToolkit.Interactivity;

namespace DW.WPFToolkit.Controls
{
    public partial class WPFMessageBox : INotifyPropertyChanged
    {
        internal WPFMessageBox()
        {
            InitializeComponent();
            DataContext = this;

            AddHandler(WPFMessageBoxButtonsPanel.ClickEvent, (RoutedEventHandler)OnButtonClick);
            AddHandler(WPFMessageBoxButtonsPanel.HelpRequestEvent, (RoutedEventHandler)OnHelpRequestClick);
            AddHandler(WPFMessageBoxButtonsPanel.ExpandDetailsEvent, (RoutedEventHandler)OnExpandDetailsClick);
        }

        private Size _oldMinSize;
        private Size _oldMaxSize;
        private Size _oldSize;
        private void OnExpandDetailsClick(object sender, RoutedEventArgs e)
        {
            IsDetailsExpanded = !IsDetailsExpanded;
            OnPropertyChanged("IsDetailsExpanded");

            if (IsDetailsExpanded)
            {
                UpperArea.Height = new GridLength(UpperArea.ActualHeight);
                LowerArea.Height = new GridLength(1, GridUnitType.Star);

                _oldMinSize = new Size(MinWidth, MinHeight);
                _oldMaxSize = new Size(MaxWidth, MaxHeight);
                _oldSize = new Size(Width, Height);

                MinWidth = Options.WindowOptions.DetailedMinWidth;
                MaxWidth = Options.WindowOptions.DetailedMaxWidth;
                MinHeight = Options.WindowOptions.DetailedMinHeight;
                MaxHeight = Options.WindowOptions.DetailedMaxHeight;
            }
            else
            {
                UpperArea.Height = new GridLength(1, GridUnitType.Star);
                LowerArea.Height = new GridLength(0, GridUnitType.Auto);

                MinWidth = _oldMinSize.Width;
                MaxWidth = _oldMaxSize.Width;
                Width = _oldSize.Width;
                MinHeight = _oldMinSize.Height;
                MaxHeight = _oldMaxSize.Height;
                Height = _oldSize.Height;
            }
        }

        private bool _closeByButtons;
        private void OnButtonClick(object sender, RoutedEventArgs e)
        {
            var panel = (WPFMessageBoxButtonsPanel)e.OriginalSource;
            Result = panel.Result;

            _closeByButtons = true;
            DialogResult = true;
        }

        private void OnHelpRequestClick(object sender, RoutedEventArgs e)
        {
            if (Options.HelpRequestCallback != null)
                Options.HelpRequestCallback();
        }

        public bool IsDetailsExpanded { get; set; }
        public string Message { get; set; }
        public WPFMessageBoxImage Image { get; set; }
        public WPFMessageBoxButtons Buttons { get; set; }
        public WPFMessageBoxResult DefaultButton { get; set; }
        public WPFMessageBoxResult Result { get; set; }
        public WPFMessageBoxOptions Options { get; set; }

        protected override void OnSourceInitialized(EventArgs e)
        {
            base.OnSourceInitialized(e);

            if (!Options.WindowOptions.ShowSystemMenu)
                WindowTitleBar.DisableSystemMenu(this);
            else
                if (Options.WindowOptions.Icon != null)
                    Icon = Options.WindowOptions.Icon;

            if (Options.WindowOptions.ResizeMode == ResizeMode.NoResize)
            {
                WindowTitleBar.DisableMinimizeButton(this);
                WindowTitleBar.DisableMaximizeButton(this);
            }
            if (Buttons == WPFMessageBoxButtons.YesNo || Buttons == WPFMessageBoxButtons.AbortRetryIgnore)
                WindowTitleBar.DisableCloseButton(this);
        }

        protected override void OnContentRendered(EventArgs e)
        {
            PART_ButtonPanel.Measure(new Size(double.MaxValue, double.MaxValue));
            var panelWidth = PART_ButtonPanel.DesiredSize.Width;

            if (!double.IsNaN(panelWidth))
            {
                if (panelWidth > MaxWidth)
                    MaxWidth = panelWidth + 40;
                if (panelWidth > Options.WindowOptions.DetailedMaxWidth)
                    Options.WindowOptions.DetailedMaxWidth = panelWidth + 40;
                if (panelWidth > MinWidth)
                    MinWidth = panelWidth + 40;
                if (panelWidth > Options.WindowOptions.DetailedMinWidth)
                    Options.WindowOptions.DetailedMinWidth = panelWidth + 40;
            }



            base.OnContentRendered(e);

            PART_ButtonPanel.SetDefaultButton();
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

            if (e.Key == Key.C && Keyboard.Modifiers == ModifierKeys.Control && Options.MessageCopyFormatter != null)
                Options.MessageCopyFormatter.Copy(Title, Message, Buttons, Image, Options.Strings);

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
            if (options == null)
                throw new ArgumentNullException("options");

            var box = new WPFMessageBox
            {
                Owner = owner,
                Message = messageBoxText,
                Title = caption ?? string.Empty,
                Buttons = buttons,
                Image = icon,
                DefaultButton = defaultButton,
                Options = options
            };

            SetWindowOptions(box, options.WindowOptions);

            var dialogResult = box.ShowDialog();
            if (dialogResult != true)
            {
                if (buttons == WPFMessageBoxButtons.OK)
                    return WPFMessageBoxResult.OK;
                return WPFMessageBoxResult.Cancel;
            }
            return box.Result;
        }

        private static void SetWindowOptions(Window window, WPFMessageBoxOptions.WindowOptionsContainer options)
        {
            window.WindowStartupLocation = options.StartupLocation;
            if (window.Owner == null && options.StartupLocation == WindowStartupLocation.CenterOwner)
                window.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            if (window.WindowStartupLocation == WindowStartupLocation.Manual)
            {
                window.Left = options.Position.X;
                window.Top = options.Position.Y;
            }

            window.ResizeMode = options.ResizeMode;
            window.ShowInTaskbar = options.ShowInTaskbar;

            window.MinWidth = options.MinWidth;
            window.MaxWidth = options.MaxWidth;
            window.MinHeight = options.MinHeight;
            window.MaxHeight = options.MaxHeight;

            window.SizeToContent = SizeToContent.WidthAndHeight;
            window.SnapsToDevicePixels = true;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            var handler = PropertyChanged;
            if (handler != null)
                handler(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
