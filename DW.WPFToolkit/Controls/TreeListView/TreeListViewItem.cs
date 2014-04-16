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
#if TRIAL
            License1.LicenseChecker.Validate();
#endif
        }

        /// <summary>
        /// Generates a new child item container to hold in the <see cref="DW.WPFToolkit.Controls.TreeListViewItem" />.
        /// </summary>
        /// <returns>The generated child item container</returns>
        protected override DependencyObject GetContainerForItemOverride()
        {
            return new TreeListViewItem();
        }

        /// <summary>
        /// Checks if the item is already the correct item container. If not the <see cref="DW.WPFToolkit.Controls.TreeListViewItem.GetContainerForItemOverride" /> will be used to generate the right container.
        /// </summary>
        /// <param name="item">The item to shown in the <see cref="DW.WPFToolkit.Controls.TreeListViewItem" />.</param>
        /// <returns>True if the item is the correct item container already.</returns>
        protected override bool IsItemItsOwnContainerOverride(object item)
        {
            return item is TreeListViewItem;
        }

        /// <summary>
        /// Returns the level of the current item in the tree.
        /// </summary>
        public int Level
        {
            get { return VisualTreeAssist.GetParentsUntilCount<TreeListViewItem, TreeListView>(this); }
        }
    }
}
