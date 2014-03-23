using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace DW.WPFToolkit.Controls
{
    /// <summary>
    /// Represents a single entry in the drop down of the <see cref="DW.WPFToolkit.Controls.SplitButton" />.
    /// </summary>
    public class SplitButtonItem : ComboBoxItem
    {
        static SplitButtonItem()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(SplitButtonItem), new FrameworkPropertyMetadata(typeof(SplitButtonItem)));
        }

        public SplitButtonItem()
        {
            PreviewMouseLeftButtonUp += SplitButtonItem_PreviewMouseLeftButtonUp;
        }

        private void SplitButtonItem_PreviewMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            CallClickEvent();
            CallCommand();
        }

        public ICommand Command
        {
            get { return (ICommand)GetValue(CommandProperty); }
            set { SetValue(CommandProperty, value); }
        }

        /// <summary>
        /// Identifies the <see cref="DW.WPFToolkit.Controls.SplitButtonItem.Command" /> dependency property.
        /// </summary>
        public static readonly DependencyProperty CommandProperty =
            DependencyProperty.Register("Command", typeof(ICommand), typeof(SplitButtonItem), new UIPropertyMetadata(null));

        public object CommandParameter
        {
            get { return (object)GetValue(CommandParameterProperty); }
            set { SetValue(CommandParameterProperty, value); }
        }

        /// <summary>
        /// Identifies the <see cref="DW.WPFToolkit.Controls.SplitButtonItem.CommandParameter" /> dependency property.
        /// </summary>
        public static readonly DependencyProperty CommandParameterProperty =
            DependencyProperty.Register("CommandParameter", typeof(object), typeof(SplitButtonItem), new UIPropertyMetadata(null));

        public event RoutedEventHandler Click
        {
            add { AddHandler(ClickEvent, value); }
            remove { RemoveHandler(ClickEvent, value); }
        }

        public static readonly RoutedEvent ClickEvent = EventManager.RegisterRoutedEvent("Click", RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(SplitButtonItem));

        private void CallClickEvent()
        {
            var newEventArgs = new RoutedEventArgs(SplitButtonItem.ClickEvent);
            RaiseEvent(newEventArgs);
        }

        private void CallCommand()
        {
            if (Command != null &&
                Command.CanExecute(CommandParameter))
                Command.Execute(CommandParameter);
        }
    }
}
