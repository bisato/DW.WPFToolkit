using System;
using System.Windows;
using System.Windows.Input;
using System.Windows.Threading;

namespace DW.WPFToolkit.Helpers
{
    public static class ControlFocus
    {
        public static void GiveFocus(UIElement element)
        {
            element.Dispatcher.BeginInvoke(new Action(delegate
            {
                element.Focus();
                Keyboard.Focus(element);
            }),
            DispatcherPriority.Render);
        }

        public static void GiveFocus(UIElement element, Action actionOnFocus)
        {
            element.Dispatcher.BeginInvoke(new Action(() =>
                                                        {
                                                            actionOnFocus();
                                                            element.Focus();
                                                            Keyboard.Focus(element);
                                                        }),
            DispatcherPriority.Render);
        }
    }
}
