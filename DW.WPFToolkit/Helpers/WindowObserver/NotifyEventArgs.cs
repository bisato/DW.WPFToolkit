using System;
using System.Windows;

namespace DW.WPFToolkit.Helpers
{
    public class NotifyEventArgs : EventArgs
    {
        public NotifyEventArgs(Window observedWindow, int messageId)
        {
            ObservedWindow = observedWindow;
            MessageId = messageId;
        }

        public Window ObservedWindow { get; set; }

        public int MessageId { get; set; }
    }
}
