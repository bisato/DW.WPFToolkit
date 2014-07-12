using System;
using System.Windows;

namespace DW.WPFToolkit.Helpers
{
    /// <summary>
    /// This objects help to determine when a popup has to be closed. This can be by clicking somewhere else, clicking in the title bar or moving the window.
    /// </summary>
    public class PopupHandler
    {
        private WindowObserver _observer;
        private UIElement _observedControl;
        private Action _closeMethod;

        /// <summary>
        /// Starts an observing of the window which contains the control to determine when the item has to be closed.
        /// </summary>
        /// <param name="observedControl">The control which owner window has to be observed.</param>
        /// <param name="closeMethod">The close callback. This gets invoked when the owner window has send notifications to close the popup.</param>
        /// <exception cref="System.ArgumentNullException">observedControl is null.</exception>
        /// <exception cref="System.ArgumentNullException">closeMethod is null.</exception>
        public void AutoClose(UIElement observedControl, Action closeMethod)
        {
            if (observedControl == null)
                throw new ArgumentNullException("observedControl");
            if (closeMethod == null)
                throw new ArgumentNullException("closeMethod");

            _observedControl = observedControl;
            _closeMethod = closeMethod;
            var ownerWindow = Window.GetWindow(observedControl);
            if (ownerWindow != null)
            {
                _observer = new WindowObserver(ownerWindow);
                _observer.AddCallbackFor(WindowMessages.WM_NCLBUTTONDOWN, p => CallMethod());
                _observer.AddCallbackFor(WindowMessages.WM_LBUTTONDOWN, p => CallMethod());
                _observer.AddCallbackFor(WindowMessages.WM_KILLFOCUS, p => CallMethod());
            }
        }

        private void CallMethod()
        {
            if (!_observedControl.IsMouseOver)
                _closeMethod();
        }
    }
}
