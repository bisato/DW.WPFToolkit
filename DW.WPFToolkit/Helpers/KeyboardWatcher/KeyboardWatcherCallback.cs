using System;
using System.Collections.Generic;
using System.Windows.Input;

namespace DW.WPFToolkit.Helpers
{
    internal class KeyboardWatcherCallback
    {
        internal KeyboardWatchToken Token { get; set; }

        internal Action<KeyStateChangedArgs> Callback { get; set; }
        internal IEnumerable<Key> Keys { get; set; }
        internal IEnumerable<KeyState> KeyStates { get; set; }
    }
}