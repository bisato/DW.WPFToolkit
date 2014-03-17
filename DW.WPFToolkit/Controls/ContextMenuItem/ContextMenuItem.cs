using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Media;

namespace DW.WPFToolkit.Controls
{
    public class ContextMenuItem : MenuItem
    {
        protected override void OnInitialized(EventArgs e)
        {
            base.OnInitialized(e);
            
            var binding = new Binding();
            binding.Path = new PropertyPath("PlacementTarget");
            binding.RelativeSource = new RelativeSource(RelativeSourceMode.FindAncestor, typeof(ContextMenu), 1);
            SetBinding(ElementHolderProperty, binding);
        }

        public object ItemDataContext
        {
            get { return (object)GetValue(ItemDataContextProperty); }
            set { SetValue(ItemDataContextProperty, value); }
        }

        public static readonly DependencyProperty ItemDataContextProperty =
            DependencyProperty.Register("ItemDataContext", typeof(object), typeof(ContextMenuItem), new UIPropertyMetadata(null));

        public object ElementHolder
        {
            get { return (object)GetValue(ElementHolderProperty); }
            set { SetValue(ElementHolderProperty, value); }
        }

        public static readonly DependencyProperty ElementHolderProperty =
            DependencyProperty.Register("ElementHolder", typeof(object), typeof(ContextMenuItem), new UIPropertyMetadata(OnElementHolderChanged));

        public bool IsBindToSelf
        {
            get { return (bool)GetValue(IsBindToSelfProperty); }
            set { SetValue(IsBindToSelfProperty, value); }
        }

        public static readonly DependencyProperty IsBindToSelfProperty =
            DependencyProperty.Register("IsBindToSelf", typeof(bool), typeof(ContextMenuItem), new UIPropertyMetadata(false));

        private static void OnElementHolderChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (e.NewValue != null)
            {
                var control = (ContextMenuItem)d;
                var parent = VisualTreeHelper.GetParent(e.NewValue as DependencyObject);
                while (parent != null)
                {
                    if (parent is Window ||
                        parent is UserControl)
                        break;

                    if (control.ItemDataContext == null &&
                        parent is FrameworkElement)
                        control.ItemDataContext = ((FrameworkElement)parent).DataContext;

                    parent = VisualTreeHelper.GetParent(parent);
                }
                if (parent != null)
                    control.DataContext = ((FrameworkElement)parent).DataContext;

                if (control.IsBindToSelf)
                    control.DataContext = control.ItemDataContext;
            }
        }
    }
}
