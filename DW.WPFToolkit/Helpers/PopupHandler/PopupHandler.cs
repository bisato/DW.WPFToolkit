using System;
using System.Windows;

namespace DW.WPFToolkit.Helpers
{
    public class PopupHandler
    {
        private WindowObserver _observer;
        private UIElement _observedControl;
        private Action _closeMethod;

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
