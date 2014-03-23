using System;
using DW.WPFToolkit.Helpers;

namespace DW.WPFToolkit.Internal
{
    internal class Callback
    {
        internal Action<NotifyEventArgs> Action { get; private set; }

        internal Callback(int? listenMessageId, Action<NotifyEventArgs> callback)
        {
            Action = callback;
            ListenMessageId = listenMessageId;
        }

        internal int? ListenMessageId { get; private set; }
    }
}
