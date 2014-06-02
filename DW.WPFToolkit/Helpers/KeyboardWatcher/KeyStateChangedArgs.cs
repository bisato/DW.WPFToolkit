using System;
using System.Windows.Input;

namespace DW.WPFToolkit.Helpers
{
    /// <summary>
    /// Holds all information which was happen to a key catched from the <see cref="DW.WPFToolkit.Helpers.KeyboardWatcher" />.
    /// </summary>
    public class KeyStateChangedArgs : EventArgs
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DW.WPFToolkit.Helpers.KeyStateChangedArgs" /> class.
        /// </summary>
        /// <param name="key">The key which state has been changed.</param>
        /// <param name="state">The actual state of the key.</param>
        public KeyStateChangedArgs(Key key, KeyState state)
        {
            Key = key;
            State = state;
        }

        /// <summary>
        /// Gets the key which state has been changed.
        /// </summary>
        public Key Key { get; private set; }

        /// <summary>
        /// Gets the actual state of the key.
        /// </summary>
        public KeyState State { get; private set; }
    }
}