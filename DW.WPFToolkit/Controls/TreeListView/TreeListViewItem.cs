using System.Windows;
using DW.WPFToolkit.Helpers;

namespace DW.WPFToolkit.Controls
{
    /// <summary>
    /// Sepresents a single entry in the <see cref="DW.WPFToolkit.Controls.TreeListView" />.
    /// </summary>
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
