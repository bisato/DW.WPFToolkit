using System;

namespace DW.WPFToolkit.Interactivity
{
    /// <summary>
    /// Holds the information if the window can be closed or not. If yes it holds also the information how the DialogResult has to be. This object is used by the <see cref="DW.WPFToolkit.Interactivity.WindowBehavior" />.
    /// </summary>
    public class WindowClosingArgs : EventArgs
    {
#if TRIAL
        static WindowClosingArgs()
        {
            License1.License.Display();
        }
#endif

        /// <summary>
        /// Initializes a new instance of the <see cref="DW.WPFToolkit.Interactivity.WindowClosingArgs" /> class.
        /// </summary>
        public WindowClosingArgs()
        {
            DialogResult = true;
        }

        /// <summary>
        /// Gets or sets the value which indicates how to close the dialog if <see cref="DW.WPFToolkit.Interactivity.WindowClosingArgs.Cancel" /> is false. The default is true.
        /// </summary>
        public bool DialogResult { get; set; }

        /// <summary>
        /// Gets or sets the value to define if the closing process has to be canceled and the window to stay open.
        /// </summary>
        public bool Cancel { get; set; }
    }
}
