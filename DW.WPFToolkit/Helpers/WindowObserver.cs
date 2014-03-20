using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Interop;
using DW.Toolkit.Internal;

namespace DW.WPFToolkit.Helpers
{
    public class WindowObserver
    {
        private readonly Window _observedWindow;
        private readonly List<Callback> _callbacks;

        public WindowObserver(Window observedWindow)
        {
            if (observedWindow == null)
                throw new ArgumentNullException("observedWindow");

            _callbacks = new List<Callback>();

            _observedWindow = observedWindow;
            if (!observedWindow.IsLoaded)
                observedWindow.Loaded += WindowLoaded;
            else
                HookIn();
        }

        private void WindowLoaded(object sender, RoutedEventArgs e)
        {
            ((Window)sender).Loaded -= WindowLoaded;
            
            HookIn();
        }

        private void HookIn()
        {
            var handle = new WindowInteropHelper(_observedWindow).Handle;
            HwndSource.FromHwnd(handle).AddHook(WindowProc);
        }

        private IntPtr WindowProc(IntPtr hwnd, int msg, IntPtr wParam, IntPtr lParam, ref bool handled)
        {
            NotifyMessage(msg);
            NotifyCallbacks(msg);

            return (IntPtr)0;
        }

        public event EventHandler<NotifyEventArgs> Message;

        private void NotifyMessage(int msg)
        {
            var handler = Message;
            if (handler != null)
                handler(this, new NotifyEventArgs(_observedWindow, msg));
        }

        public void AddCallback(Action<NotifyEventArgs> callback)
        {
            AddCallbackFor(null, callback);
        }

        public void AddCallbackFor(int? messageId, Action<NotifyEventArgs> callback)
        {
            if (callback == null)
                throw new ArgumentNullException("callback");

            _callbacks.Add(new Callback(messageId, callback));
        }

        private void NotifyCallbacks(int message)
        {
            for (var i = 0; i < _callbacks.Count; i++)
            {
                if (_callbacks[i].ListenMessageId == null ||
                     _callbacks[i].ListenMessageId == message)
                    _callbacks[i].Action(new NotifyEventArgs(_observedWindow, message));
            }
        }

        public void RemoveCallback(Action<NotifyEventArgs> callback)
        {
            if (callback == null)
                throw new ArgumentNullException("callback");

            _callbacks.RemoveAll(c => c.Action == callback);
        }

        public void ClearCallbacks()
        {
            _callbacks.Clear();
        }

        public void RemoveCallbacksFor(int messageId)
        {
            _callbacks.RemoveAll(c => c.ListenMessageId == messageId);
        }
    }
}
