using System;
using System.Windows;
using System.Windows.Media;

namespace DW.WPFToolkit.Controls
{
    public class WPFMessageBoxOptions
    {
        public WPFMessageBoxOptions()
        {
            MessageCopyFormatter = new DefaultMessageCopyFormatter();
            ShowSystemMenu = false;
            Icon = null;
            Strings = new MessageBoxStrings();
            ShowHelpButton = false;
            HelpRequestCallback = null;
            ShowYesToAllButton = false;
            ShowNoToAllButton = false;
            StartupLocation = WindowStartupLocation.CenterOwner;
            ShowInTaskbar = false;
            ResizeMode = ResizeMode.NoResize;
            Position = new Point();
            MinWidth = 249;
            MaxWidth = 494;
            Width = 349;
            MinHeight = 172;
            MaxHeight = double.PositiveInfinity;
            ShowDoNotShowAgainCheckBox = false;
            IsDoNotShowAgainChecked = false;
        }

        public IMessageCopyFormatter MessageCopyFormatter { get; set; }
        public bool ShowSystemMenu { get; set; }
        public ImageSource Icon { get; set; }
        public MessageBoxStrings Strings { get; set; }
        public bool ShowHelpButton { get; set; }
        public Action HelpRequestCallback { get; set; }
        public bool ShowYesToAllButton { get; set; }
        public bool ShowNoToAllButton { get; set; }
        public WindowStartupLocation StartupLocation { get; set; }
        public bool ShowInTaskbar { get; set; }
        public ResizeMode ResizeMode { get; set; }
        public Point Position { get; set; }
        public double MinWidth { get; set; }
        public double MaxWidth { get; set; }
        public double Width { get; set; }
        public double MinHeight { get; set; }
        public double MaxHeight { get; set; }
        public double Height { get; set; }
        public bool ShowDoNotShowAgainCheckBox { get; set; }
        public bool IsDoNotShowAgainChecked { get; set; }
    }
}