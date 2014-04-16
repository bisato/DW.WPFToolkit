using System;
using System.Windows;
using System.Windows.Input;

namespace DW.WPFToolkit.Interactivity
{
    /// <summary>
    /// Brings the feature to be able to double click any UI element.
    /// </summary>
    public class DoubleClickBehavior :  DependencyObject
    {
#if TRIAL
        static DoubleClickBehavior()
        {
            License1.License.Display();
        }
#endif

        /// <summary>
        /// Gets the command to be called when the element gets double clicked.
        /// </summary>
        /// <param name="obj">The element from which the property value is read.</param>
        /// <returns>The DW.WPFToolkit.Interactivity.DoubleClickBehavior.Command property value for the element.</returns>
        public static ICommand GetCommand(DependencyObject obj)
        {
            return (ICommand)obj.GetValue(CommandProperty);
        }

        /// <summary>
        /// Attaches the command to be called when the element gets double clicked.
        /// </summary>
        /// <param name="obj">The element to which the attached property is written.</param>
        /// <param name="value">The needed DW.WPFToolkit.Interactivity.DoubleClickBehavior.Command value.</param>
        public static void SetCommand(DependencyObject obj, ICommand value)
        {
            obj.SetValue(CommandProperty, value);
        }

        /// <summary>
        /// Identifies the <see cref="DW.WPFToolkit.Interactivity.DoubleClickBehavior.GetCommand(DependencyObject)" /> <see cref="DW.WPFToolkit.Interactivity.DoubleClickBehavior.SetCommand(DependencyObject, ICommand)" /> attached property.
        /// </summary>
        public static readonly DependencyProperty CommandProperty =
            DependencyProperty.RegisterAttached("Command", typeof(ICommand), typeof(DoubleClickBehavior), new UIPropertyMetadata(OnCommandChanged));

        /// <summary>
        /// Gets the command parameter to be passed when the called when DW.WPFToolkit.Interactivity.DoubleClickBehavior.Command gets called.
        /// </summary>
        /// <param name="obj">The element from which the property value is read.</param>
        /// <returns>The DW.WPFToolkit.Interactivity.DoubleClickBehavior.CommandParameter property value for the element.</returns>
        public static object GetCommandParameter(DependencyObject obj)
        {
            return (object)obj.GetValue(CommandParameterProperty);
        }

        /// <summary>
        /// Attaches the command parameter to be passed when the called when DW.WPFToolkit.Interactivity.DoubleClickBehavior.Command gets called.
        /// </summary>
        /// <param name="obj">The element to which the attached property is written.</param>
        /// <param name="value">The needed DW.WPFToolkit.Interactivity.DoubleClickBehavior.CommandParameter value.</param>
        public static void SetCommandParameter(DependencyObject obj, object value)
        {
            obj.SetValue(CommandParameterProperty, value);
        }

        /// <summary>
        /// Identifies the <see cref="DW.WPFToolkit.Interactivity.DoubleClickBehavior.GetCommandParameter(DependencyObject)" /> <see cref="DW.WPFToolkit.Interactivity.DoubleClickBehavior.SetCommandParameter(DependencyObject, object)" /> attached property.
        /// </summary>
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
