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

            var options = new WPFMessageBoxOptions();

            MessageBoxText = "This is a normal messagebox text to test the awesome WPFMessageBox.";
            Caption = "WPFMessageBox Test";
            Buttons = WPFMessageBoxButtons.OKCancel;
            Icon = WPFMessageBoxImage.Information;
            DefaultButton = WPFMessageBoxResult.OK;
            ShowHelpButton = options.ShowHelpButton;
            ShowNoToAllButton = options.ShowNoToAllButton;
            ShowSystemMenu = options.WindowOptions.ShowSystemMenu;
            ShowYesToAllButton = options.ShowYesToAllButton;
            StartupLocation = options.WindowOptions.StartupLocation;
            ShowInTaskbar = options.WindowOptions.ShowInTaskbar;
            ResizeMode = options.WindowOptions.ResizeMode;
            PositionLeft = options.WindowOptions.Position.X;
            PositionTop = options.WindowOptions.Position.Y;
            MinWidth1 = options.WindowOptions.MinWidth;
            MaxWidth1 = options.WindowOptions.MaxWidth;
            Width1 = options.WindowOptions.Width;
            MinHeight1 = options.WindowOptions.MinHeight;
            MaxHeight1 = options.WindowOptions.MaxHeight;
            Height1 = options.WindowOptions.Height;
            ShowDoNotShowAgainCheckBox = options.ShowDoNotShowAgainCheckBox;
            IsDoNotShowAgainChecked = options.IsDoNotShowAgainChecked;
        }

        private void ShowMessageBox_Click(object sender, RoutedEventArgs e)
        {
            var options = new WPFMessageBoxOptions();

            //options.HelpRequestCallback
            //options.WindowOptions.Icon
            //options.MessageCopyFormatter
            //options.Strings

            options.ShowHelpButton = ShowHelpButton;
            options.ShowNoToAllButton = ShowNoToAllButton;
            options.WindowOptions.ShowSystemMenu = ShowSystemMenu;
            options.ShowYesToAllButton = ShowYesToAllButton;
            options.WindowOptions.StartupLocation = StartupLocation;
            options.WindowOptions.ShowInTaskbar = ShowInTaskbar;
            options.WindowOptions.ResizeMode = ResizeMode;
            if (PositionLeft > 0)
                options.WindowOptions.Position = new Point(PositionLeft, PositionTop);
            options.WindowOptions.MinWidth = MinWidth1;
            options.WindowOptions.MaxWidth = MaxWidth1;
            options.WindowOptions.Width = Width1;
            options.WindowOptions.MinHeight = MinHeight1;
            options.WindowOptions.MaxHeight = MaxHeight1;
            options.WindowOptions.Height = Height1;
            options.ShowDoNotShowAgainCheckBox = ShowDoNotShowAgainCheckBox;
            options.IsDoNotShowAgainChecked = IsDoNotShowAgainChecked;

            Result = WPFMessageBox.Show(Application.Current.MainWindow, MessageBoxText, Caption, Buttons, Icon, DefaultButton, options);
            Clipboard = System.Windows.Clipboard.GetText();
            IsDoNotShowAgainCheckedResult = options.IsDoNotShowAgainChecked;
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

        public double PositionLeft
        {
            get { return _positionLeft; }
            set
            {
                _positionLeft = value;
                NotifyPropertyChanged(() => PositionLeft);
            }
        }
        private double _positionLeft;

        public double PositionTop
        {
            get { return _positionTop; }
            set
            {
                _positionTop = value;
                NotifyPropertyChanged(() => PositionTop);
            }
        }
        private double _positionTop;


        public double MinWidth1
        {
            get { return _minWidth; }
            set
            {
                _minWidth = value;
                NotifyPropertyChanged(() => MinWidth1);
            }
        }
        private double _minWidth;
        
        public double MaxWidth1
        {
            get { return _maxWidth; }
            set
            {
                _maxWidth = value;
                NotifyPropertyChanged(() => MaxWidth1);
            }
        }
        private double _maxWidth;

        public double Width1
        {
            get { return _width; }
            set
            {
                _width = value;
                NotifyPropertyChanged(() => Width1);
            }
        }
        private double _width;

        public double MinHeight1
        {
            get { return _minHeight; }
            set
            {
                _minHeight = value;
                NotifyPropertyChanged(() => MinHeight1);
            }
        }
        private double _minHeight;

        public double MaxHeight1
        {
            get { return _maxHeight; }
            set
            {
                _maxHeight = value;
                NotifyPropertyChanged(() => MaxHeight1);
            }
        }
        private double _maxHeight;

        public double Height1
        {
            get { return _height; }
            set
            {
                _height = value;
                NotifyPropertyChanged(() => Height1);
            }
        }
        private double _height;

        public bool ShowDoNotShowAgainCheckBox
        {
            get { return _showDoNotShowAgainCheckBox; }
            set
            {
                _showDoNotShowAgainCheckBox = value;
                NotifyPropertyChanged(() => ShowDoNotShowAgainCheckBox);
            }
        }
        private bool _showDoNotShowAgainCheckBox;

        public bool IsDoNotShowAgainChecked
        {
            get { return _isDoNotShowAgainChecked; }
            set
            {
                _isDoNotShowAgainChecked = value;
                NotifyPropertyChanged(() => IsDoNotShowAgainChecked);
            }
        }
        private bool _isDoNotShowAgainChecked;

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

        public bool IsDoNotShowAgainCheckedResult
        {
            get { return _isDoNotShowAgainCheckedResult; }
            set
            {
                _isDoNotShowAgainCheckedResult = value;
                NotifyPropertyChanged(() => IsDoNotShowAgainCheckedResult);
            }
        }
        private bool _isDoNotShowAgainCheckedResult;

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
