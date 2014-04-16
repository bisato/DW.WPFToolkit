using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;

namespace DW.WPFToolkit.Controls
{
    /// <summary>
    /// Shows the <see cref="DW.WPFToolkit.Controls.EnhancedTreeView" /> with the possibity to expand or collapse child elements shown in a GridView. The expander can be placed in every column cell template.
    /// </summary>
    public class TreeListView : EnhancedTreeView
    {
        static TreeListView()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(TreeListView), new FrameworkPropertyMetadata(typeof(TreeListView)));
#if TRIAL
            License1.LicenseChecker.Validate();
#endif
        }

        /// <summary>
        /// Generates a new child item container to hold in the <see cref="DW.WPFToolkit.Controls.TreeListView" />.
        /// </summary>
        /// <returns>The generated child item container</returns>
        protected override DependencyObject GetContainerForItemOverride()
        {
            return new TreeListViewItem();
        }

        /// <summary>
        /// Checks if the item is already the correct item container. If not the <see cref="DW.WPFToolkit.Controls.TreeListView.GetContainerForItemOverride" /> will be used to generate the right container.
        /// </summary>
        /// <param name="item">The item to shown in the <see cref="DW.WPFToolkit.Controls.TreeListView" />.</param>
        /// <returns>True if the item is the correct item container already.</returns>
        protected override bool IsItemItsOwnContainerOverride(object item)
        {
            return item is TreeListViewItem;
        }

        /// <summary>
        /// Gets or sets the <see cref="System.Windows.Controls.GridView"/> shown in the control.
        /// </summary>
        [DefaultValue(null)]
        public GridView View
        {
            get { return (GridView)GetValue(ViewProperty); }
            set { SetValue(ViewProperty, value); }
        }

        /// <summary>
        /// Identifies the <see cref="DW.WPFToolkit.Controls.TreeListView.View" /> dependency property.
        /// </summary>
        public static readonly DependencyProperty ViewProperty =
            DependencyProperty.Register("View", typeof(GridView), typeof(TreeListView), new UIPropertyMetadata(null));
    }
}
