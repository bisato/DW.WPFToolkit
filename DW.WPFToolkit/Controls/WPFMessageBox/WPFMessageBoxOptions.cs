using System;
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
        }

        public IMessageCopyFormatter MessageCopyFormatter { get; set; }
        public bool ShowSystemMenu { get; set; }
        public ImageSource Icon { get; set; }
        public MessageBoxStrings Strings { get; set; }
        public bool ShowHelpButton { get; set; }
        public Action HelpRequestCallback { get; set; }
    }
}