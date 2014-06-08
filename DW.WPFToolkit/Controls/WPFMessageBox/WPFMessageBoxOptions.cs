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
            DetailsContent = null;
            CustomItem = null;
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
        public object DetailsContent { get; set; }
        public object CustomItem { get; set; }

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
                DetailedMinWidth = 249;
                DetailedMaxWidth = 494;
                DetailedMinHeight = 350;
                DetailedMaxHeight = double.PositiveInfinity;
                DetailedResizeMode = ResizeMode.NoResize;
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
            public double DetailedMinWidth { get; set; }
            public double DetailedMaxWidth { get; set; }
            public double DetailedMinHeight { get; set; }
            public double DetailedMaxHeight { get; set; }
            public ResizeMode DetailedResizeMode { get; set; }
        }
    }
}