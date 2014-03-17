using System;
using System.Windows;
using System.Windows.Input;

namespace DW.WPFToolkit.Interactivity
{
    public class DoubleClickBehavior :  DependencyObject
    {
        public static ICommand GetCommand(DependencyObject obj)
        {
            return (ICommand)obj.GetValue(CommandProperty);
        }

        public static void SetCommand(DependencyObject obj, ICommand value)
        {
            obj.SetValue(CommandProperty, value);
        }

        public static readonly DependencyProperty CommandProperty =
            DependencyProperty.RegisterAttached("Command", typeof(ICommand), typeof(DoubleClickBehavior), new UIPropertyMetadata(OnCommandChanged));

        public static object GetCommandParameter(DependencyObject obj)
        {
            return (object)obj.GetValue(CommandParameterProperty);
        }

        public static void SetCommandParameter(DependencyObject obj, object value)
        {
            obj.SetValue(CommandParameterProperty, value);
        }

        public static readonly DependencyProperty CommandParameterProperty =
            DependencyProperty.RegisterAttached("CommandParameter", typeof(object), typeof(DoubleClickBehavior), new UIPropertyMetadata(null));

        private static void OnCommandChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            var control = sender as FrameworkElement;
            if (control == null)
                throw new InvalidOperationException("The DoubleClickBehavior can only attached to an FrameworkElement");

            control.PreviewMouseLeftButtonDown += new MouseButtonEventHandler(MouseButtonDown);
        }

        private static void MouseButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ClickCount == 2)
            {
                var command = GetCommand((DependencyObject)sender);
                var parameter = GetCommandParameter((DependencyObject)sender);
                if (parameter == null)
                {
                    var owner = sender as FrameworkElement;
                    parameter = owner.DataContext;
                }
                if (command != null &&
                    command.CanExecute(parameter))
                    command.Execute(parameter);
            }
        }
    }
}
