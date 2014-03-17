using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace DW.WPFToolkit.Controls
{
    [TemplatePart(Name = "PART_ContentButton", Type = typeof(SplitToggleButton))]
    public class SplitButton : ComboBox
    {
        static SplitButton()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(SplitButton), new FrameworkPropertyMetadata(typeof(SplitButton)));
        }

        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();

            var content = GetTemplateChild("PART_ContentButton") as SplitToggleButton;
            if (content != null)
                content.Click += new RoutedEventHandler(Content_Click);
        }

        private void Content_Click(object sender, RoutedEventArgs e)
        {
            CallClickEvent();
            CallCommand();
        }

        public ICommand Command
        {
            get { return (ICommand)GetValue(CommandProperty); }
            set { SetValue(CommandProperty, value); }
        }

        public static readonly DependencyProperty CommandProperty =
            DependencyProperty.Register("Command", typeof(ICommand), typeof(SplitButton), new UIPropertyMetadata(null));

        public object CommandParameter
        {
            get { return (object)GetValue(CommandParameterProperty); }
            set { SetValue(CommandParameterProperty, value); }
        }

        public static readonly DependencyProperty CommandParameterProperty =
            DependencyProperty.Register("CommandParameter", typeof(object), typeof(SplitButton), new UIPropertyMetadata(null));

        public event RoutedEventHandler Click
        {
            add { AddHandler(ClickEvent, value); }
            remove { RemoveHandler(ClickEvent, value); }
        }

        public static readonly RoutedEvent ClickEvent = EventManager.RegisterRoutedEvent("Click", RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(SplitButton));

        private void CallClickEvent()
        {
            var newEventArgs = new RoutedEventArgs(SplitButton.ClickEvent);
            RaiseEvent(newEventArgs);
        }

        private void CallCommand()
        {
            if (Command != null &&
                Command.CanExecute(CommandParameter))
                Command.Execute(CommandParameter);
        }

        public object Content
        {
            get { return (object)GetValue(ContentProperty); }
            set { SetValue(ContentProperty, value); }
        }

        public static readonly DependencyProperty ContentProperty =
            DependencyProperty.Register("Content", typeof(object), typeof(SplitButton), new UIPropertyMetadata(null));

        protected override DependencyObject GetContainerForItemOverride()
        {
            return new SplitButtonItem();
        }

        protected override bool IsItemItsOwnContainerOverride(object item)
        {
            return item is SplitButtonItem;
        }
    }
}
