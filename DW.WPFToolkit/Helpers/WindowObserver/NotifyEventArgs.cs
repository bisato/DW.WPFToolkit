using System;
using System.Windows;

namespace DW.WPFToolkit.Helpers
{
    /// <summary>
    /// Holds the data passed when a specific WinAPI message has appear. This is used in the <see cref="DW.WPFToolkit.Helpers.WindowObserver" />.
    /// </summary>
    public sealed class NotifyEventArgs : EventArgs
    {
#if TRIAL
        static NotifyEventArgs()
        {
            License1.License.Display();
        }
#endif

        internal NotifyEventArgs(Window observedWindow, int messageId)
        {
            ObservedWindow = observedWindow;
            MessageId = messageId;
        }

        /// <summary>
        /// Gets the window which has raised the specific WinAPI message.
        /// </summary>
        public Window ObservedWindow { get; private set; }

        /// <summary>
        /// Gets the appeared WinAPI message. See <see cref="DW.WPFToolkit.Helpers.WindowMessages" />.
        /// </summary>
        public int MessageId { get; private set; }
    }
}
