using System;
using System.Collections.Specialized;
using System.Windows;
using System.Windows.Controls;

namespace DW.WPFToolkit.Interactivity
{
    public class ScrollBehavior : DependencyObject
    {
        public static object GetScrollToItem(DependencyObject obj)
        {
            return (object)obj.GetValue(ScrollToItemProperty);
        }

        public static void SetScrollToItem(DependencyObject obj, object value)
        {
            obj.SetValue(ScrollToItemProperty, value);
        }

        public static readonly DependencyProperty ScrollToItemProperty =
            DependencyProperty.RegisterAttached("ScrollToItem", typeof(object), typeof(ScrollBehavior), new UIPropertyMetadata(OnScrollChanged));

        public static bool GetAutoScrollToLast(DependencyObject obj)
        {
            return (bool)obj.GetValue(AutoScrollToLastProperty);
        }

        public static void SetAutoScrollToLast(DependencyObject obj, bool value)
        {
            obj.SetValue(AutoScrollToLastProperty, value);
        }

        public static readonly DependencyProperty AutoScrollToLastProperty =
            DependencyProperty.RegisterAttached("AutoScrollToLast", typeof(bool), typeof(ScrollBehavior), new UIPropertyMetadata(OnScrollChanged));

        public static bool GetAutoScrollToSelected(DependencyObject obj)
        {
            return (bool)obj.GetValue(AutoScrollToSelectedProperty);
        }

        public static void SetAutoScrollToSelected(DependencyObject obj, bool value)
        {
            obj.SetValue(AutoScrollToSelectedProperty, value);
        }

        public static readonly DependencyProperty AutoScrollToSelectedProperty =
            DependencyProperty.RegisterAttached("AutoScrollToSelected", typeof(bool), typeof(ScrollBehavior), new UIPropertyMetadata(OnScrollChanged));

        private static ScrollBehavior GetScrollBehavior(DependencyObject obj)
        {
            return (ScrollBehavior)obj.GetValue(ScrollBehaviorProperty);
        }

        private static void SetScrollBehavior(DependencyObject obj, ScrollBehavior value)
        {
            obj.SetValue(ScrollBehaviorProperty, value);
        }

        private static readonly DependencyProperty ScrollBehaviorProperty =
            DependencyProperty.RegisterAttached("ScrollBehavior", typeof(ScrollBehavior), typeof(ScrollBehavior), new UIPropertyMetadata(null));

        private static void OnScrollChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            var listbox = sender as ListBox;
            if (listbox == null)
                throw new InvalidOperationException("The ScrollBehavior.ScrollToItem only can be attached to an ListBox or ListView");

            var scrollBehavior = GetScrollBehavior(sender);
            if (scrollBehavior == null)
            {
                scrollBehavior = new ScrollBehavior();
                SetScrollBehavior(sender, scrollBehavior);
                listbox.Loaded += new RoutedEventHandler(scrollBehavior.Listbox_Loaded);
            }
            scrollBehavior.ScrollToItem(listbox, GetScrollToItem(listbox));
        }

        private void Listbox_Loaded(object sender, RoutedEventArgs e)
        {
            var listbox = sender as ListBox;

            var autoSelectionScroll = GetAutoScrollToSelected(listbox);
            var autoLastScroll = GetAutoScrollToLast(listbox);

            ScrollToItem(listbox, GetScrollToItem(listbox));
            if (autoLastScroll)
            {
                var collection = listbox.ItemsSource as INotifyCollectionChanged;
                if (collection != null)
                    collection.CollectionChanged += (owner, arg) => { ScrollToLast(listbox); };
                ScrollToLast(listbox);
            }
            if (autoSelectionScroll)
                listbox.SelectionChanged += new SelectionChangedEventHandler(ListBox_SelectionChanged);
        }

        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var listbox = sender as ListBox;

            if (listbox.SelectedItem != null)
                listbox.ScrollIntoView(listbox.SelectedItem);
        }

        private void ScrollToItem(ListBox listBox, object item)
        {
            if (item != null)
                listBox.ScrollIntoView(item);
        }

        private void ScrollToLast(ListBox listBox)
        {
            if (listBox.Items.Count > 0)
                listBox.ScrollIntoView(listBox.Items[listBox.Items.Count - 1]);
        }
    }
}
