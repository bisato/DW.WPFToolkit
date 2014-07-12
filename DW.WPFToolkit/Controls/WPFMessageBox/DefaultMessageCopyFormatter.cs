#region License
/*
The MIT License (MIT)

Copyright (c) 2009-2014 David Wendland

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in
all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
THE SOFTWARE
*/
#endregion License

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