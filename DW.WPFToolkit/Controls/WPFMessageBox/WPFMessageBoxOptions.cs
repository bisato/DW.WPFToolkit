using System.Windows.Media;

namespace DW.WPFToolkit.Controls
{
    public class WPFMessageBoxOptions
    {
        public WPFMessageBoxOptions()
        {
            MessageCopyFormatter = new DefaultMessageCopyFormatter();
            ShowSystemMenu = false;
        }

        public IMessageCopyFormatter MessageCopyFormatter { get; set; }
        public bool ShowSystemMenu { get; set; }
        public ImageSource Icon { get; set; }
    }
}