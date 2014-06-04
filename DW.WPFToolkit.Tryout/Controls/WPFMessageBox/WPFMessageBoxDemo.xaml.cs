using System;
using System.ComponentModel;
using System.Linq.Expressions;
using System.Windows;
using DW.WPFToolkit.Controls;

namespace DW.WPFToolkit.Tryout.Controls
{
    public partial class WPFMessageBoxDemo : INotifyPropertyChanged
    {
        public WPFMessageBoxDemo()
        {
            InitializeComponent();
            DataContext = this;

            MessageBoxText = "This is a normal messagebox text to test the awesome WPFMessageBox.";
            Caption = "WPFMessageBox Test";
            Buttons = WPFMessageBoxButtons.OKCancel;
            Icon = WPFMessageBoxImage.Information;
            DefaultButton = WPFMessageBoxResult.OK;
            ShowHelpButton = false;
            ShowNoToAllButton = false;
            ShowSystemMenu = false;
            ShowYesToAllButton = false;
            StartupLocation = WindowStartupLocation.CenterOwner;
            ShowInTaskbar = false;
            ResizeMode = ResizeMode.NoResize;
        }

        private void ShowMessageBox_Click(object sender, RoutedEventArgs e)
        {
            var options = new WPFMessageBoxOptions();
            //options.HelpRequestCallback
            //options.Icon
            //options.MessageCopyFormatter
            options.ShowHelpButton = ShowHelpButton;
            options.ShowNoToAllButton = ShowNoToAllButton;
            options.ShowSystemMenu = ShowSystemMenu;
            options.ShowYesToAllButton = ShowYesToAllButton;
            //options.Strings
            options.StartupLocation = StartupLocation;
            options.ShowInTaskbar = ShowInTaskbar;
            options.ResizeMode = ResizeMode;

            Result = WPFMessageBox.Show(Application.Current.MainWindow, MessageBoxText, Caption, Buttons, Icon, DefaultButton, options);
            Clipboard = System.Windows.Clipboard.GetText();
        }

        public string MessageBoxText
        {
            get { return _messageBoxText; }
            set
            {
                _messageBoxText = value;
                NotifyPropertyChanged(() => MessageBoxText);
            }
        }
        private string _messageBoxText;

        public string Caption
        {
            get { return _caption; }
            set
            {
                _caption = value;
                NotifyPropertyChanged(() => Caption);
            }
        }
        private string _caption;

        public WPFMessageBoxButtons Buttons
        {
            get { return _buttons; }
            set
            {
                _buttons = value;
                NotifyPropertyChanged(() => Buttons);
            }
        }
        private WPFMessageBoxButtons _buttons;

        public WPFMessageBoxImage Icon
        {
            get { return _icon; }
            set
            {
                _icon = value;
                NotifyPropertyChanged(() => Icon);
            }
        }
        private WPFMessageBoxImage _icon;

        public WPFMessageBoxResult DefaultButton
        {
            get { return _defaultButton; }
            set
            {
                _defaultButton = value;
                NotifyPropertyChanged(() => DefaultButton);
            }
        }
        private WPFMessageBoxResult _defaultButton;

        public bool ShowHelpButton
        {
            get { return _showHelpButton; }
            set
            {
                _showHelpButton = value;
                NotifyPropertyChanged(() => ShowHelpButton);
            }
        }
        private bool _showHelpButton;

        public bool ShowNoToAllButton
        {
            get { return _showNoToAllButton; }
            set
            {
                _showNoToAllButton = value;
                NotifyPropertyChanged(() => ShowNoToAllButton);
            }
        }
        private bool _showNoToAllButton;

        public bool ShowSystemMenu
        {
            get { return _showSystemMenu; }
            set
            {
                _showSystemMenu = value;
                NotifyPropertyChanged(() => ShowSystemMenu);
            }
        }
        private bool _showSystemMenu;

        public bool ShowYesToAllButton
        {
            get { return _showYesToAllButton; }
            set
            {
                _showYesToAllButton = value;
                NotifyPropertyChanged(() => ShowYesToAllButton);
            }
        }
        private bool _showYesToAllButton;

        public WindowStartupLocation StartupLocation
        {
            get { return _startupLocation; }
            set
            {
                _startupLocation = value;
                NotifyPropertyChanged(() => StartupLocation);
            }
        }
        private WindowStartupLocation _startupLocation;

        public bool ShowInTaskbar
        {
            get { return _showInTaskbar; }
            set
            {
                _showInTaskbar = value;
                NotifyPropertyChanged(() => ShowInTaskbar);
            }
        }
        private bool _showInTaskbar;

        public ResizeMode ResizeMode
        {
            get { return _resizeMode; }
            set
            {
                _resizeMode = value;
                NotifyPropertyChanged(() => ResizeMode);
            }
        }
        private ResizeMode _resizeMode;
        

        public WPFMessageBoxResult Result
        {
            get { return _result; }
            set
            {
                _result = value;
                NotifyPropertyChanged(() => Result);
            }
        }
        private WPFMessageBoxResult _result;

        public string Clipboard
        {
            get { return _clipboard; }
            set
            {
                _clipboard = value;
                NotifyPropertyChanged(() => Clipboard);
            }
        }
        private string _clipboard;

        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged<T>(Expression<Func<T>> property)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                var memberExpression = property.Body as MemberExpression;
                handler(this, new PropertyChangedEventArgs(memberExpression.Member.Name));
            }
        }
    }
}
