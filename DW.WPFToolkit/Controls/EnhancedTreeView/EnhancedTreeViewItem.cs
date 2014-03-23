using System.Windows;
using System.Windows.Controls;

namespace DW.WPFToolkit.Controls
{
    public class EnhancedTreeViewItem : TreeViewItem
    {
        protected override System.Windows.DependencyObject GetContainerForItemOverride()
        {
            return new EnhancedTreeViewItem() { ContentStretching = ContentStretching };
        }

        protected override bool IsItemItsOwnContainerOverride(object item)
        {
            return item is EnhancedTreeViewItem;
        }

        public bool ContentStretching
        {
            get { return (bool)GetValue(ContentStretchingProperty); }
            set { SetValue(ContentStretchingProperty, value); }
        }

        /// <summary>
        /// Identifies the <see cref="DW.WPFToolkit.Controls.EnhancedTreeViewItem.ContentStretching" /> dependency property.
        /// </summary>
        public static readonly DependencyProperty ContentStretchingProperty =
            DependencyProperty.Register("ContentStretching", typeof(bool), typeof(EnhancedTreeViewItem), new UIPropertyMetadata(OnContentStretchingChanged));

        private static void OnContentStretchingChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            var value = (bool)e.NewValue;
            if (value)
            {
                var control = (EnhancedTreeViewItem)sender;
                if (control.IsLoaded)
                    control.AdjustChildren();
                else
                    control.Loaded += new RoutedEventHandler(control.StretchingTreeViewItem_Loaded);
            }
        }

        private void StretchingTreeViewItem_Loaded(object sender, RoutedEventArgs e)
        {
            AdjustChildren();
        }

        private void AdjustChildren()
        {
            if (VisualChildrenCount > 0)
            {
                var grid = GetVisualChild(0) as Grid;
                if (grid != null &&
                    grid.ColumnDefinitions.Count == 3)
                    grid.ColumnDefinitions.RemoveAt(1);
            }
        }
    }
}
