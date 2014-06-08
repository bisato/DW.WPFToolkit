using System;
using System.Windows;
using System.Windows.Media;

namespace DW.WPFToolkit.Controls
{
    public class WPFMessageBoxOptions
    {
        public WPFMessageBoxOptions()
        {
            WindowOptions = new WindowOptionsContainer();

            MessageCopyFormatter = new DefaultMessageCopyFormatter();
            Strings = new MessageBoxStrings();
            ShowHelpButton = false;
            HelpRequestCallback = null;
            ShowYesToAllButton = false;
            ShowNoToAllButton = false;
            ShowDoNotShowAgainCheckBox = false;
            IsDoNotShowAgainChecked = false;
            ShowDetails = false;
        }

        public IMessageCopyFormatter MessageCopyFormatter { get; set; }
        public MessageBoxStrings Strings { get; set; }
        public bool ShowHelpButton { get; set; }
        public Action HelpRequestCallback { get; set; }
        public bool ShowYesToAllButton { get; set; }
        public bool ShowNoToAllButton { get; set; }
        public bool ShowDetails { get; set; }
        
        public bool ShowDoNotShowAgainCheckBox { get; set; }
        public bool IsDoNotShowAgainChecked { get; set; }

        public WindowOptionsContainer WindowOptions { get; private set; }

        public class WindowOptionsContainer
        {
            internal WindowOptionsContainer()
            {
                ShowSystemMenu = false;
                Icon = null;
                StartupLocation = WindowStartupLocation.CenterOwner;
                ShowInTaskbar = false;
                ResizeMode = ResizeMode.NoResize;
                Position = new Point();
                MinWidth = 249;
                MaxWidth = 494;
                MinHeight = 172;
                MaxHeight = double.PositiveInfinity;
            }

            public bool ShowSystemMenu { get; set; }
            public ImageSource Icon { get; set; }
            public WindowStartupLocation StartupLocation { get; set; }
            public bool ShowInTaskbar { get; set; }
            public ResizeMode ResizeMode { get; set; }
            public Point Position { get; set; }
            public double MinWidth { get; set; }
            public double MaxWidth { get; set; }
            public double MinHeight { get; set; }
            public double MaxHeight { get; set; }
        }
    }
}