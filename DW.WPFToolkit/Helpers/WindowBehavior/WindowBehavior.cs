using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace DW.WPFToolkit.Helpers
{
    public class WindowBehavior : DependencyObject
    {
        public static bool? GetDialogResult(DependencyObject obj)
        {
            return (bool?)obj.GetValue(DialogResultProperty);
        }

        public static void SetDialogResult(DependencyObject obj, bool? value)
        {
            obj.SetValue(DialogResultProperty, value);
        }

        public static readonly DependencyProperty DialogResultProperty =
            DependencyProperty.RegisterAttached("DialogResult", typeof(bool?), typeof(WindowBehavior), new UIPropertyMetadata(OnDialogResultChanged));

        public static ICommand GetDialogResultCommand(DependencyObject obj)
        {
            return (ICommand)obj.GetValue(DialogResultCommandProperty);
        }

        public static void SetDialogResultCommand(DependencyObject obj, ICommand value)
        {
            obj.SetValue(DialogResultCommandProperty, value);
        }

        public static readonly DependencyProperty DialogResultCommandProperty =
            DependencyProperty.RegisterAttached("DialogResultCommand", typeof(ICommand), typeof(WindowBehavior), new UIPropertyMetadata(OnDialogResultChanged));

        public static ICommand GetClosingCommand(DependencyObject obj)
        {
            return (ICommand)obj.GetValue(ClosingCommandProperty);
        }

        public static void SetClosingCommand(DependencyObject obj, ICommand value)
        {
            obj.SetValue(ClosingCommandProperty, value);
        }

        public static readonly DependencyProperty ClosingCommandProperty =
            DependencyProperty.RegisterAttached("ClosingCommand", typeof(ICommand), typeof(WindowBehavior), new UIPropertyMetadata(OnClosingCommandChanged));

        public static ICommand GetClosedCommand(DependencyObject obj)
        {
            return (ICommand)obj.GetValue(ClosedCommandProperty);
        }

        public static void SetClosedCommand(DependencyObject obj, ICommand value)
        {
            obj.SetValue(ClosedCommandProperty, value);
        }

        public static readonly DependencyProperty ClosedCommandProperty =
            DependencyProperty.RegisterAttached("ClosedCommand", typeof(ICommand), typeof(WindowBehavior), new UIPropertyMetadata(OnClosedCommandChanged));

        public static ICommand GetLoadedCommand(DependencyObject obj)
        {
            return (ICommand)obj.GetValue(LoadedCommandProperty);
        }

        public static void SetLoadedCommand(DependencyObject obj, ICommand value)
        {
            obj.SetValue(LoadedCommandProperty, value);
        }

        public static readonly DependencyProperty LoadedCommandProperty =
            DependencyProperty.RegisterAttached("LoadedCommand", typeof(ICommand), typeof(WindowBehavior), new UIPropertyMetadata(OnLoadedCommandChanged));

        public static object GetLoadedCommandParameter(DependencyObject obj)
        {
            return (object)obj.GetValue(LoadedCommandParameterProperty);
        }

        public static void SetLoadedCommandParameter(DependencyObject obj, object value)
        {
            obj.SetValue(LoadedCommandParameterProperty, value);
        }

        public static readonly DependencyProperty LoadedCommandParameterProperty =
            DependencyProperty.RegisterAttached("LoadedCommandParameter", typeof(object), typeof(WindowBehavior), new UIPropertyMetadata(null));

        public static bool GetIsClose(DependencyObject obj)
        {
            return (bool)obj.GetValue(IsCloseProperty);
        }

        public static void SetIsClose(DependencyObject obj, bool value)
        {
            obj.SetValue(IsCloseProperty, value);
        }

        public static readonly DependencyProperty IsCloseProperty =
            DependencyProperty.RegisterAttached("IsClose", typeof(bool), typeof(WindowBehavior), new UIPropertyMetadata(OnIsCloseChanged));

        public static string GetWinApiMessages(DependencyObject obj)
        {
            return (string)obj.GetValue(WinApiMessagesProperty);
        }

        public static void SetWinApiMessages(DependencyObject obj, string value)
        {
            obj.SetValue(WinApiMessagesProperty, value);
        }

        public static readonly DependencyProperty WinApiMessagesProperty =
            DependencyProperty.RegisterAttached("WinApiMessages", typeof(string), typeof(WindowBehavior), new UIPropertyMetadata(OnWinApiMessagesChanged));

        public static ICommand GetWinApiCommand(DependencyObject obj)
        {
            return (ICommand)obj.GetValue(WinApiCommandProperty);
        }

        public static void SetWinApiCommand(DependencyObject obj, ICommand value)
        {
            obj.SetValue(WinApiCommandProperty, value);
        }

        public static readonly DependencyProperty WinApiCommandProperty =
            DependencyProperty.RegisterAttached("WinApiCommand", typeof(ICommand), typeof(WindowBehavior), new UIPropertyMetadata(OnWinApiCommandChanged));

        private static WindowObserver GetObserver(DependencyObject obj)
        {
            return (WindowObserver)obj.GetValue(ObserverProperty);
        }

        private static void SetObserver(DependencyObject obj, WindowObserver value)
        {
            obj.SetValue(ObserverProperty, value);
        }

        private static readonly DependencyProperty ObserverProperty =
            DependencyProperty.RegisterAttached("Observer", typeof(WindowObserver), typeof(WindowBehavior), new UIPropertyMetadata(null));

        private static void OnWinApiMessagesChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            var messages = e.NewValue as string;
            if (string.IsNullOrWhiteSpace(messages))
                return;

            var observer = GetOrCreateObsever(sender);
            if (observer == null)
                return;
            
            observer.ClearCallbacks();

            if (messages.ToLower().Trim() == "all")
                observer.AddCallback(EventNotified);
            else
                foreach (var id in StringToIntegerList(messages))
                    observer.AddCallbackFor(id, EventNotified);
        }

        private static void EventNotified(NotifyEventArgs e)
        {
            var command = GetWinApiCommand(e.ObservedWindow);
            if (command != null &&
                command.CanExecute(e))
                command.Execute(e);
        }

        private static IEnumerable<int> StringToIntegerList(string messages)
        {
            var idTexts = messages.Split(new[] {';'}, StringSplitOptions.RemoveEmptyEntries);
            var ids = new List<int>();
            foreach (var idText in idTexts)
            {
                int id;
                try
                {
                    ids.Add(int.TryParse(idText, NumberStyles.HexNumber, new CultureInfo(1033), out id)
                                        ? id
                                        : Convert.ToInt32(idText, 16));
                }
                catch
                {
                    throw new ArgumentException("The attached WinApiMessages cannot be parsed to a list of integers. Supported are just integer numbers separated by a semicolon, e.g. '3;42' or hex values (base of 16) like '0x03;0x2A'. See message values in the 'DW.SharpTools\\DW.SharpTools\\WindowObserver\\WindowMessages.cs' or in the WinUser.h (Windows SDK; C:\\Program Files (x86)\\Microsoft SDKs\\Windows\\v7.0A\\Include\\WinUser.h)");
                }
            }
            return ids;
        }

        private static void OnWinApiCommandChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            if (e.NewValue != null)
                GetOrCreateObsever(sender);
        }

        private static WindowObserver GetOrCreateObsever(DependencyObject sender)
        {
            var observer = GetObserver(sender);
            if (observer == null)
            {
                var window = sender as Window;
                if (window != null)
                {
                    observer = new WindowObserver(window);
                    SetObserver(sender, observer);
                }
            }

            return observer;
        }

        private static void OnIsCloseChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            var button = sender as Button;
            if (button != null)
                button.Click += new RoutedEventHandler(CloseButton_Click);
        }

        private static void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            if (GetIsClose((DependencyObject)sender))
            {
                var button = sender as Button;
                var window = VisualTreeAssist.FindParent<Window>(button);
                if (window != null)
                    window.Close();
            }
        }

        private static void OnDialogResultChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            var button = sender as Button;
            if (button != null)
                button.Click += new RoutedEventHandler(DialogResultButton_Click);
        }

        private static void DialogResultButton_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            var window = VisualTreeAssist.FindParent<Window>(button);
            if (window != null)
            {
                var resultCommand = WindowBehavior.GetDialogResultCommand(button);
                if (resultCommand != null)
                {
                    var args = new Interactivity.WindowClosingArgs();
                    resultCommand.Execute(args);
                    if (!args.Cancel)
                        window.DialogResult = args.DialogResult;
                }
                else
                    window.DialogResult = WindowBehavior.GetDialogResult(button);
            }
        }

        private static void OnClosingCommandChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            var window = sender as Window;
            if (window == null)
                throw new InvalidOperationException("'WindowBehavior.ClosingCommand' only can be attached to a 'Window' object");

            window.Closing += new CancelEventHandler(Window_Closing);
        }

        private static void Window_Closing(object sender, CancelEventArgs e)
        {
            var command = GetClosingCommand((DependencyObject)sender);
            if (command != null &&
                command.CanExecute(null))
            {
                var args = new Interactivity.WindowClosingArgs();
                command.Execute(args);
                e.Cancel = args.Cancel;
            }
        }

        private static void OnClosedCommandChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            var window = sender as Window;
            if (window == null)
                throw new InvalidOperationException("'WindowBehavior.ClosedCommand' only can be attached to a 'Window' object");

            window.Closed += new EventHandler(Window_Closed);
        }

        private static void Window_Closed(object sender, EventArgs e)
        {
            var command = GetClosedCommand((DependencyObject)sender);
            if (command != null &&
                command.CanExecute(null))
                command.Execute(null);
        }

        private static void OnLoadedCommandChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            var window = sender as FrameworkElement;
            if (window == null)
                throw new InvalidOperationException("'WindowBehavior.LoadedCommand' only can be attached to a 'FrameworkElement' object");

            window.Loaded += new RoutedEventHandler(Window_Loaded);
        }

        private static void Window_Loaded(object sender, RoutedEventArgs e)
        {
            var command = GetLoadedCommand((DependencyObject)sender);
            var parameter = GetLoadedCommandParameter((DependencyObject)sender);
            if (command != null &&
                command.CanExecute(parameter))
                command.Execute(parameter);
        }
    }
}
