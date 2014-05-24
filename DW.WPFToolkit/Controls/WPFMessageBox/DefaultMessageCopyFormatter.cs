using System.Text;
using System.Windows;

namespace DW.WPFToolkit.Controls
{
    public class DefaultMessageCopyFormatter : IMessageCopyFormatter
    {
        public void Copy(string title, string message, WPFMessageBoxButtons buttons, WPFMessageBoxImage icon)
        {
            var builder = new StringBuilder();
            builder.AppendLine("---------------------------");
            builder.AppendLine(title);
            builder.AppendLine("---------------------------");
            builder.AppendLine(message);
            builder.AppendLine("---------------------------");
            AppendButtons(builder, buttons);
            builder.AppendLine("---------------------------");

            Clipboard.SetText(builder.ToString());
        }

        private void AppendButtons(StringBuilder builder, WPFMessageBoxButtons buttons)
        {
            switch (buttons)
            {
                case WPFMessageBoxButtons.OK:
                    builder.AppendLine("OK   ");
                    break;
                case WPFMessageBoxButtons.OKCancel:
                    builder.AppendLine("OK   Abbrechen   ");
                    break;
                case WPFMessageBoxButtons.RetryCancel:
                    builder.AppendLine("Wiederholen   Abbrechen   ");
                    break;
                case WPFMessageBoxButtons.YesNo:
                    builder.AppendLine("Ja   Nein   ");
                    break;
                case WPFMessageBoxButtons.YesNoCancel:
                    builder.AppendLine("Ja   Nein   Abbrechen   ");
                    break;
                case WPFMessageBoxButtons.AbortRetryIgnore:
                    builder.AppendLine("Abbrechen   Wiederholen   Ignorieren   ");
                    break;
            }
        }
    }
}