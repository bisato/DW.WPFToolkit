namespace DW.WPFToolkit.Controls
{
    public interface IMessageCopyFormatter
    {
        void Copy(string title, string message, WPFMessageBoxButtons buttons, WPFMessageBoxImage icon, MessageBoxStrings strings);
    }
}