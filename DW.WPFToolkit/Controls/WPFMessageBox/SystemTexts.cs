using System;
using System.Runtime.InteropServices;
using System.Text;

namespace DW.WPFToolkit.Controls
{
    internal static class SystemTexts
    {
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        private static extern int LoadString(IntPtr hInstance, uint stringId, StringBuilder lpBuffer, int nBufferMax);
        
        [DllImport("kernel32")]
        private static extern IntPtr LoadLibrary(string lpFileName);

        internal const uint OK_CAPTION = 800;
        internal const uint CANCEL_CAPTION = 801;
        internal const uint ABORT_CAPTION = 802;
        internal const uint RETRY_CAPTION = 803;
        internal const uint IGNORE_CAPTION = 804;
        internal const uint YES_CAPTION = 805;
        internal const uint NO_CAPTION = 806;
        internal const uint CLOSE_CAPTION = 807;
        internal const uint HELP_CAPTION = 808;
        internal const uint TRYAGAIN_CAPTION = 809;
        internal const uint CONTINUE_CAPTION = 810;

        internal static string GetString(uint id)
        {
            var sb = new StringBuilder(256);
            var user32 = LoadLibrary(Environment.SystemDirectory + "\\User32.dll");
            LoadString(user32, id, sb, sb.Capacity);
            return sb.ToString();
        }
    }
}
