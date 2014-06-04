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
            StartupLocation = null;
            ShowInTaskbar = false;
            ResizeMode = ResizeMode.NoResize;
        }

        public IMessageCopyFormatter MessageCopyFormatter { get; set; }
        public bool ShowSystemMenu { get; set; }
        public ImageSource Icon { get; set; }
        public MessageBoxStrings Strings { get; set; }
        public bool ShowHelpButton { get; set; }
        public Action HelpRequestCallback { get; set; }
        public bool ShowYesToAllButton { get; set; }
        public bool ShowNoToAllButton { get; set; }
        public WindowStartupLocation? StartupLocation { get; set; }
        public bool ShowInTaskbar { get; set; }
        public ResizeMode ResizeMode { get; set; }
    }
}