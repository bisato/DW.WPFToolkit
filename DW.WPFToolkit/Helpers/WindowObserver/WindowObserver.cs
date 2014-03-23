﻿using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Interop;
using DW.WPFToolkit.Internal;

namespace DW.WPFToolkit.Helpers
{
    /// <summary>
    /// Brings possibilities to easy listen for WinAPI events.
    /// </summary>
    public class WindowObserver
    {
        private readonly Window _observedWindow;
        private readonly List<Callback> _callbacks;

        /// <summary>
        /// Initializes a new instance of the <see cref="DW.WPFToolkit.Helpers.WindowObserver" /> class.
        /// </summary>
        /// <param name="observedWindow">The window which WinAPI messages should be observed.</param>
        /// <exception cref="System.ArgumentNullException">observedWindow is null.</exception>
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

        /// <summary>
        /// Occurs when the observed window has send the a WinAPI message
        /// </summary>
        public event EventHandler<NotifyEventArgs> Message;

        private void NotifyMessage(int msg)
        {
            var handler = Message;
            if (handler != null)
                handler(this, new NotifyEventArgs(_observedWindow, msg));
        }

        /// <summary>
        /// Registers a calback to be invoked when a WinAPI message appears in the observed window.
        /// </summary>
        /// <param name="callback">The callback to be invoked when a WinAPI message appears in the observed window.</param>
        /// <remarks>The callback is not registered as a WeakReference, consider using <see cref="DW.WPFToolkit.Helpers.WindowObserver.RemoveCallback(Action{NotifyEventArgs})" /> to remove a callback if its not needed anymore.</remarks>
        /// <exception cref="System.ArgumentNullException">callback is null.</exception>
        public void AddCallback(Action<NotifyEventArgs> callback)
        {
            AddCallbackFor(null, callback);
        }

        /// <summary>
        /// Registers a calback to be invoked when the specific WinAPI message appears in the observed window.
        /// </summary>
        /// <param name="messageId">The WinAPI message to listen for. If its null all WinAPI messages will be forwarded to the callback.</param>
        /// <param name="callback">The callback to be invoked when the specific WinAPI message appears in the observed window.</param>
        /// <remarks>The callback is not registered as a WeakReference, consider using <see cref="DW.WPFToolkit.Helpers.WindowObserver.RemoveCallback(Action{NotifyEventArgs})" /> to remove a callback if its not needed anymore.</remarks>
        /// <exception cref="System.ArgumentNullException">callback is null.</exception>
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

        /// <summary>
        /// Removed the previous registered callback.
        /// </summary>
        /// <param name="callback">The previous registered callback to remove. If it is remoed already nothing happens.</param>
        /// <exception cref="System.ArgumentNullException">callback is null.</exception>
        public void RemoveCallback(Action<NotifyEventArgs> callback)
        {
            if (callback == null)
                throw new ArgumentNullException("callback");

            _callbacks.RemoveAll(c => c.Action == callback);
        }

        /// <summary>
        /// Removes all registered callbacks.
        /// </summary>
        public void ClearCallbacks()
        {
            _callbacks.Clear();
        }

        /// <summary>
        /// Removes all callbacks which listen for a specific WinAPI message.
        /// </summary>
        /// <param name="messageId">The WinAPI message the callbacks does listen for.</param>
        public void RemoveCallbacksFor(int messageId)
        {
            _callbacks.RemoveAll(c => c.ListenMessageId == messageId);
        }
    }
}