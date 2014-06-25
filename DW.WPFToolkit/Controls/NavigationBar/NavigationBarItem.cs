using System.Windows;
using System.Windows.Controls;

namespace DW.WPFToolkit.Controls
{
    public class NavigationBarItem : HeaderedContentControl
    {
        static NavigationBarItem()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(NavigationBarItem), new FrameworkPropertyMetadata(typeof(NavigationBarItem)));
        }

        public bool IsExpanded
        {
            get { return (bool)GetValue(IsExpandedProperty); }
            set { SetValue(IsExpandedProperty, value); }
        }

        public static readonly DependencyProperty IsExpandedProperty =
            DependencyProperty.Register("IsExpanded", typeof(bool), typeof(NavigationBarItem), new PropertyMetadata(OnIsExpandedChanged));

        public Orientation Orientation
        {
            get { return (Orientation)GetValue(OrientationProperty); }
            set { SetValue(OrientationProperty, value); }
        }

        public static readonly DependencyProperty OrientationProperty =
            DependencyProperty.Register("Orientation", typeof(Orientation), typeof(NavigationBarItem), new PropertyMetadata(Orientation.Vertical));

        private static void OnIsExpandedChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var control = (NavigationBarItem)d;
            var value = (bool)e.NewValue;
            NavigationBarPanel.SetIsExpanded(control, value);

            if (value)
                control.OnExpanded();
            else
                control.OnCollapsed();
        }

        public static readonly RoutedEvent ExpandedEvent = EventManager.RegisterRoutedEvent("Expanded", RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(NavigationBarItem));

        public event RoutedEventHandler Expanded
        {
            add { AddHandler(ExpandedEvent, value); }
            remove { RemoveHandler(ExpandedEvent, value); }
        }

        private void OnExpanded()
        {
            var newEventArgs = new RoutedEventArgs(NavigationBarItem.ExpandedEvent);
            RaiseEvent(newEventArgs);
        }

        public static readonly RoutedEvent CollapsedEvent = EventManager.RegisterRoutedEvent("Collapsed", RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(NavigationBarItem));

        public event RoutedEventHandler Collapsed
        {
            add { AddHandler(CollapsedEvent, value); }
            remove { RemoveHandler(CollapsedEvent, value); }
        }

        private void OnCollapsed()
        {
            var newEventArgs = new RoutedEventArgs(NavigationBarItem.CollapsedEvent);
            RaiseEvent(newEventArgs);
        }
    }
}
