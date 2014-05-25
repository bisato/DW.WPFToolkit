using System.Text;
using System.Windows;

namespace DW.WPFToolkit.Controls
{
    public class DefaultMessageCopyFormatter : IMessageCopyFormatter
    {
        public void Copy(string title, string message, WPFMessageBoxButtons buttons, WPFMessageBoxImage icon, MessageBoxStrings strings)
        {
            var builder = new StringBuilder();
            builder.AppendLine("---------------------------");
            builder.AppendLine(title);
            builder.AppendLine("---------------------------");
            builder.AppendLine(message);
            builder.AppendLine("---------------------------");
            AppendButtons(builder, buttons, strings);
            builder.AppendLine("---------------------------");

            Clipboard.SetText(builder.ToString());
        }

        private void AppendButtons(StringBuilder builder, WPFMessageBoxButtons buttons, MessageBoxStrings strings)
        {
            switch (buttons)
            {
                case WPFMessageBoxButtons.OK:
                    builder.AppendLine(string.Format("{0}   ", GetString(strings.OK)));
                    break;
                case WPFMessageBoxButtons.OKCancel:
                    builder.AppendLine(string.Format("{0}   {1}   ", GetString(strings.OK), GetString(strings.Cancel)));
                    break;
                case WPFMessageBoxButtons.RetryCancel:
                    builder.AppendLine(string.Format("{0}   {1}   ", GetString(strings.Retry), GetString(strings.Cancel)));
                    break;
                case WPFMessageBoxButtons.YesNo:
                    builder.AppendLine(string.Format("{0}   {1}   ", GetString(strings.Yes), GetString(strings.No)));
                    break;
                case WPFMessageBoxButtons.YesNoCancel:
                    builder.AppendLine(string.Format("{0}   {1}   {2}   ", GetString(strings.Yes), GetString(strings.No), GetString(strings.Cancel)));
                    break;
                case WPFMessageBoxButtons.AbortRetryIgnore:
                    builder.AppendLine(string.Format("{0}   {1}   {2}   ", GetString(strings.Abort), GetString(strings.Retry), GetString(strings.Ignore)));
                    break;
            }
        }

        private string GetString(string original)
        {
            return original.Replace("_", "");
        }
    }
}