using System;

namespace DW.WPFToolkit.Helpers
{
    public class WindowClosingArgs : EventArgs
    {
        public WindowClosingArgs()
        {
            DialogResult = true;
        }

        public bool DialogResult { get; set; }

        public bool Cancel { get; set; }
    }
}
