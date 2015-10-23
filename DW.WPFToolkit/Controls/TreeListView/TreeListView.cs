#region License
/*
The MIT License (MIT)

Copyright (c) 2009-2015 David Wendland

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in
all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
THE SOFTWARE
*/
#endregion License

using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;

using DW.WPFToolkit.Helpers;

namespace DW.WPFToolkit.Controls
{
    /// <summary>
    /// Shows the <see cref="DW.WPFToolkit.Controls.EnhancedTreeView" /> with the possibity to expand or collapse child elements shown in a GridView. The expander can be placed in every column cell template.
    /// </summary>
    /// <example>
    /// <code lang="XAML">
    /// <![CDATA[
    /// <WPFToolkit:TreeListView ItemsSource="{Binding Customer}">
    ///     <WPFToolkit:TreeListView.Resources>
    ///         <HierarchicalDataTemplate DataType="{x:Type Data:Customer}" ItemsSource="{Binding Customer}" />
    ///     </WPFToolkit:TreeListView.Resources>
    ///     <WPFToolkit:TreeListView.View>
    ///         <GridView>
    ///             <GridViewColumn Header="Name">
    ///                 <GridViewColumn.CellTemplate>
    ///                     <DataTemplate>
    ///                         <DockPanel>
    ///                             <WPFToolkit:TreeListViewExpander DockPanel.Dock="Left" />
    ///                             <TextBlock Text="{Binding Name}" Margin="5,0,0,0" />
    ///                         </DockPanel>
    ///                     </DataTemplate>
    ///                 </GridViewColumn.CellTemplate>
    ///             </GridViewColumn>
    ///             <GridViewColumn Header="Family Name" DisplayMemberBinding="{Binding FamilyName}" />
    ///         </GridView>
    ///     </WPFToolkit:TreeListView.View>
    /// </WPFToolkit:TreeListView>
    /// ]]>
    /// </code>
    /// </example>
    public class TreeListView : EnhancedTreeView
    {
        static TreeListView()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(TreeListView), new FrameworkPropertyMetadata(typeof(TreeListView)));
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

        /// <summary>
        /// Dependency Property for the bound selected Element. Get and Set. Only valid in SingleMode.
        /// </summary>
        public static readonly DependencyProperty SelectedElementProperty =
                DependencyProperty.Register(
                    "SelectedElement",
                    typeof(object),
                    typeof(TreeListView),
                    new PropertyMetadata(default(object), SelectedElementChanged));

        /// <summary>
        /// EventHandler for Status Changed Event of ContainerGenerator
        /// Defined as "extra" eventhandler, that it can be unsubscribed.
        /// </summary>
        private EventHandler<EventArgs> _containerStatusChangedEventHandler;

        /// <summary>
        /// Gets or sets the selected (bound) Element
        /// </summary>
        public object SelectedElement
        {
            get
            {
                return GetValue(SelectedElementProperty);
            }
            set
            {
                SetValue(SelectedElementProperty, value);
            }
        }

        /// <summary>
        /// Handler for changed Event of the selected Element
        /// </summary>
        /// <param name="d">The TreeListView</param>
        /// <param name="e">The args. (not used)</param>
        private static void SelectedElementChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            
            var newElement = e.NewValue;
            var treeListView = d as TreeListView;
            if (treeListView != null && newElement != null)
            {
                // break, if not SingleMode
                if (treeListView.SelectionMode != SelectionMode.Single)
                    return;
                var gen = treeListView.ItemContainerGenerator;

                var ui = ContainerFromItem(gen, newElement);
                if (ui != null)
                {
                    // set as selected
                    ui.SetValue(TreeViewItem.IsSelectedProperty, true);
                }
                else if (gen != null)
                {
                    // the generator can be null, when is is not completely generated, so we listen (weak, for sure!) to the "StatusChanged" Event and do our work there.
                    treeListView._containerStatusChangedEventHandler = (o, args) => ContainerGeneratorStatusChangedHandler(o, newElement);
                    WeakEventManager<ItemContainerGenerator, EventArgs>.AddHandler(gen, "StatusChanged",
                        treeListView._containerStatusChangedEventHandler);
                }
            }
        }

        /// <summary>
        /// Gets the generated (UI) TreeListViewItem.
        /// </summary>
        /// <param name="containerGenerator">The ItemContainerGenerator from the "parent".</param>
        /// <param name="item">The (bound) item to get the generated UI Item.</param>
        /// <returns>The generated UI TreeListViewItem. null if nothing to return.</returns>
        private static TreeListViewItem ContainerFromItem(ItemContainerGenerator containerGenerator, object item)
        {
            if (containerGenerator != null)
            {
                var container = containerGenerator.ContainerFromItem(item) as TreeListViewItem;
                if (container != null)
                {
                    return container;
                }

                foreach (var childItem in containerGenerator.Items)
                {
                    var parent = containerGenerator.ContainerFromItem(childItem) as TreeListViewItem;
                    if (parent == null)
                    {
                        continue;
                    }

                    container = parent.ItemContainerGenerator.ContainerFromItem(item) as TreeListViewItem;
                    if (container != null)
                    {
                        return container;
                    }

                    container = ContainerFromItem(parent.ItemContainerGenerator, item);
                    if (container != null)
                    {
                        return container;
                    }
                }
            }
            return null;
        }

        /// <summary>
        /// The Event Handler of the "StatusChanged" Event of a ContainerGenerator.
        /// </summary>
        /// <param name="sender">The ContainerGenerator which has initiated the event.</param>
        /// <param name="newSelection"></param>
        private static void ContainerGeneratorStatusChangedHandler(object sender, object newSelection)
        {

            var itemContainerGenerator = sender as ItemContainerGenerator;

            // if the Generator has done its work.
            if (newSelection != null && itemContainerGenerator != null
                && itemContainerGenerator.Status
                == System.Windows.Controls.Primitives.GeneratorStatus.ContainersGenerated)
            {
                // get UIElement from Item through recursion
                var ui = ContainerFromItem(itemContainerGenerator, newSelection);
                if (ui != null)
                {
                    // Event Handler aushängen
                    var enhancedTreeView = VisualTreeAssist.FindParent<TreeListView>(ui);
                    if (enhancedTreeView != null)
                    {
                        WeakEventManager<ItemContainerGenerator, EventArgs>.RemoveHandler(itemContainerGenerator, "StatusChanged",
                            enhancedTreeView._containerStatusChangedEventHandler);
                    }
                    ui.SetValue(TreeViewItem.IsSelectedProperty, true);

                }
            }
        }
    }
}
