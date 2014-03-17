using System;
using System.Runtime.InteropServices;
using System.Windows;
using System.Windows.Interop;

namespace DW.WPFToolkit.Interactivity
{
    public class WindowTitleBarBehavior : FrameworkElement
    {
        public static bool GetRemoveTitleItems(DependencyObject obj)
        {
            return (bool)obj.GetValue(RemoveTitleItemsProperty);
        }

        public static void SetRemoveTitleItems(DependencyObject obj, bool value)
        {
            obj.SetValue(RemoveTitleItemsProperty, value);
        }

        public static readonly DependencyProperty RemoveTitleItemsProperty =
            DependencyProperty.RegisterAttached("RemoveTitleItems", typeof(bool), typeof(WindowTitleBarBehavior), new UIPropertyMetadata(false, OnRemoveTitleItemsChanged));

        public static bool GetDisableMinimizeButton(DependencyObject obj)
        {
            return (bool)obj.GetValue(DisableMinimizeButtonProperty);
        }

        public static void SetDisableMinimizeButton(DependencyObject obj, bool value)
        {
            obj.SetValue(DisableMinimizeButtonProperty, value);
        }

        public static readonly DependencyProperty DisableMinimizeButtonProperty =
            DependencyProperty.RegisterAttached("DisableMinimizeButton", typeof(bool), typeof(WindowTitleBarBehavior), new UIPropertyMetadata(false, OnDisableMinimizeButtonChanged));

        public static bool GetDisableMaximizeButton(DependencyObject obj)
        {
            return (bool)obj.GetValue(DisableMaximizeButtonProperty);
        }

        public static void SetDisableMaximizeButton(DependencyObject obj, bool value)
        {
            obj.SetValue(DisableMaximizeButtonProperty, value);
        }

        public static readonly DependencyProperty DisableMaximizeButtonProperty =
            DependencyProperty.RegisterAttached("DisableMaximizeButton", typeof(bool), typeof(WindowTitleBarBehavior), new UIPropertyMetadata(false, OnDisableMaximizeButtonChanged));

        private static void OnDisableMaximizeButtonChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var window = d as Window;
            if (window != null)
                window.SourceInitialized += new System.EventHandler(DisableMaximizeButton_SourceInitialized);
        }

        private static void DisableMaximizeButton_SourceInitialized(object sender, System.EventArgs e)
        {
            var window = (Window)sender;
            var hwnd = new WindowInteropHelper(window).Handle;
            var windowLong = GetWindowLong(hwnd, GWL_STYLE);
            windowLong &= ~WS_MAXIMIZEBOX;
            SetWindowLong(hwnd, GWL_STYLE, windowLong);
        }

        private static void OnDisableMinimizeButtonChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var window = d as Window;
            if (window != null)
                window.SourceInitialized += new System.EventHandler(DisableMinimizeButton_SourceInitialized);
        }

        private static void DisableMinimizeButton_SourceInitialized(object sender, System.EventArgs e)
        {
            var window = (Window)sender;
            var hwnd = new WindowInteropHelper(window).Handle;
            var windowLong = GetWindowLong(hwnd, GWL_STYLE);
            windowLong &= ~WS_MINIMIZEBOX;
            SetWindowLong(hwnd, GWL_STYLE, windowLong);
        }

        private static void OnRemoveTitleItemsChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var window = d as Window;
            if (window != null)
                window.SourceInitialized += new System.EventHandler(RemoveTitleItems_SourceInitialized);
        }

        private static void RemoveTitleItems_SourceInitialized(object sender, System.EventArgs e)
        {
            var window = (Window)sender;
            var hwnd = new WindowInteropHelper(window).Handle;
            var windowLong = GetWindowLong(hwnd, GWL_STYLE);
            windowLong &= ~WS_SYSMENU;
            SetWindowLong(hwnd, GWL_STYLE, windowLong);
        }

        [DllImport("user32.dll")]
        static extern int GetWindowLong(IntPtr hwnd, int index);

        [DllImport("user32.dll")]
        static extern int SetWindowLong(IntPtr hwnd, int index, int newStyle);

        [DllImport("user32.dll")]
        static extern bool SetWindowPos(IntPtr hwnd, IntPtr hwndInsertAfter, int x, int y, int width, int height, uint flags);

        [DllImport("user32.dll")]
        static extern IntPtr SendMessage(IntPtr hwnd, uint msg, IntPtr wParam, IntPtr lParam);

        const int GWL_STYLE = -16;
        const int WS_CAPTION = 0xC00000;
        const int WS_MAXIMIZEBOX = 0x10000;
        const int WS_MINIMIZEBOX = 0x20000;
        const int WS_SYSMENU = 0x80000;
    }
}
