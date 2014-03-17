using System.Windows;
using DW.WPFToolkit.Helpers;

namespace DW.WPFToolkit.Controls
{
    public class TreeListViewItem : EnhancedTreeViewItem
    {
        static TreeListViewItem()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(TreeListViewItem), new FrameworkPropertyMetadata(typeof(TreeListViewItem)));
        }

        protected override DependencyObject GetContainerForItemOverride()
        {
            return new TreeListViewItem();
        }

        protected override bool IsItemItsOwnContainerOverride(object item)
        {
            return item is TreeListViewItem;
        }

        public int Level
        {
            get { return VisualTreeAssist.GetParentsUntilCount<TreeListViewItem, TreeListView>(this); }
        }
    }
}
