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

        /// <summary>
        /// Identifies the <see cref="DW.WPFToolkit.Controls.TreeListView.View" /> dependency property.
        /// </summary>
        public static readonly DependencyProperty ViewProperty =
            DependencyProperty.Register("View", typeof(GridView), typeof(TreeListView), new UIPropertyMetadata(null));
    }
}
