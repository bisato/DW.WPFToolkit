using System.Windows;
using System.Windows.Controls;

namespace DW.WPFToolkit.Controls
{
    public class TreeListView : EnhancedTreeView
    {
        static TreeListView()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(TreeListView), new FrameworkPropertyMetadata(typeof(TreeListView)));
        }

        protected override DependencyObject GetContainerForItemOverride()
        {
            return new TreeListViewItem();
        }

        protected override bool IsItemItsOwnContainerOverride(object item)
        {
            return item is TreeListViewItem;
        }

        public GridView View
        {
            get { return (GridView)GetValue(ViewProperty); }
            set { SetValue(ViewProperty, value); }
        }

        public static readonly DependencyProperty ViewProperty =
            DependencyProperty.Register("View", typeof(GridView), typeof(TreeListView), new UIPropertyMetadata(null));
    }
}
