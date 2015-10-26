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
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

using DW.WPFToolkit.Helpers;
using DW.WPFToolkit.Helpers.Reflection;

namespace DW.WPFToolkit.Controls
{
    /// <summary>
    /// Enhances the <see cref="System.Windows.Controls.TreeView" /> with a multi select possibility and stretching of its child items over the whole width.
    /// </summary>
    /// <example>
    /// <code lang="XAML">
    /// <![CDATA[
    /// <WPFToolkit:EnhancedTreeView SelectionMode="Extended" ItemsContentStretching="True">
    ///     <WPFToolkit:EnhancedTreeView.ItemContainerStyle>
    ///         <Style TargetType="{x:Type WPFToolkit:EnhancedTreeViewItem}">
    ///             <Setter Property="ContentStretching" Value="True" />
    ///         </Style>
    ///     </WPFToolkit:EnhancedTreeView.ItemContainerStyle>
    /// </WPFToolkit:EnhancedTreeView>
    /// ]]>
    /// </code>
    /// </example>
    public class EnhancedTreeView : TreeView
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DW.WPFToolkit.Controls.EnhancedTreeView" /> class.
        /// </summary>
        public EnhancedTreeView()
        {
            PreviewMouseRightButtonDown += EnhancedTreeView_PreviewMouseRightButtonDown;
            _isSelectionChangeActiveProperty = typeof(TreeView).GetProperty("IsSelectionChangeActive", BindingFlags.NonPublic | BindingFlags.Instance);
            SelectedTreeViewItems = new ObservableCollection<TreeViewItem>();

            _isCodeSelection = true;

            PreviewMouseDown += (sender, e) => _isCodeSelection = false;
            PreviewMouseUp += (sender, e) => _isCodeSelection = true;
            PreviewKeyDown += (sender, e) => _isCodeSelection = false;
            PreviewKeyUp += (sender, e) => _isCodeSelection = true;
        }

        private bool _isCodeSelection;
        private TreeViewItem _lastSelectedItem;

        /// <summary>
        /// Generates a new child item container to hold in the <see cref="DW.WPFToolkit.Controls.EnhancedTreeView" />.
        /// </summary>
        /// <returns>The generated child item container</returns>
        protected override DependencyObject GetContainerForItemOverride()
        {
            return new EnhancedTreeViewItem();
        }

        /// <summary>
        /// Checks if the item is already the correct item container. If not the <see cref="DW.WPFToolkit.Controls.EnhancedTreeView.GetContainerForItemOverride" /> will be used to generate the right container.
        /// </summary>
        /// <param name="item">The item to shown in the <see cref="DW.WPFToolkit.Controls.EnhancedTreeView" />.</param>
        /// <returns>True if the item is the correct item container already.</returns>
        protected override bool IsItemItsOwnContainerOverride(object item)
        {
            return item is EnhancedTreeViewItem;
        }

        private void EnhancedTreeView_PreviewMouseRightButtonDown(object sender, MouseButtonEventArgs e)
        {
            var control = (EnhancedTreeView)sender;
            var clickedItem = control.InputHitTest(e.GetPosition(control));
            while (clickedItem != null && !(clickedItem is TreeViewItem))
            {
                var frameworkkItem = (FrameworkElement)clickedItem;
                clickedItem = (IInputElement)(frameworkkItem.Parent ?? frameworkkItem.TemplatedParent);
            }

            if (clickedItem != null)
                ((TreeViewItem)clickedItem).IsSelected = true;
        }

        /// <summary>
        /// Handles the selection chaning depending on the <see cref="DW.WPFToolkit.Controls.EnhancedTreeView.SelectionMode" />.
        /// </summary>
        /// <param name="e">The data passed by the caller.</param>
        protected override void OnSelectedItemChanged(RoutedPropertyChangedEventArgs<object> e)
        {
            base.OnSelectedItemChanged(e);

            OnSelectedItemChangedCommand(e.NewValue);

            if (SelectionMode == SelectionMode.Single)
                return;

            DisableSelectionChangedEvent();

            var newSelected = GetSelectedContainer();
            if (newSelected != null)
            {
                if (_isCodeSelection)
                    HandleCodeSelection(newSelected);
                else if ((Keyboard.Modifiers & ModifierKeys.Control) == ModifierKeys.Control)
                    HandleControlKeySelection(newSelected);
                else if ((Keyboard.Modifiers & ModifierKeys.Shift) == ModifierKeys.Shift)
                    HandleShiftKeySelection(newSelected);
                else
                    HandleSingleSelection(newSelected);
            }

            EnableSelectionChangedEvent();
        }

        private void HandleCodeSelection(TreeViewItem newSelected)
        {
            HandleControlKeySelection(newSelected);
            RemoveDeselectedItemContainers();
        }

        private void RemoveDeselectedItemContainers()
        {
            for (int i = 0; i < SelectedTreeViewItems.Count; i++)
            {
                if (!SelectedTreeViewItems[i].IsSelected)
                    SelectedTreeViewItems.RemoveAt(i);
            }
        }

        private void HandleControlKeySelection(TreeViewItem newSelected)
        {
            if (SelectedTreeViewItems.Contains(newSelected))
            {
                newSelected.IsSelected = false;
                SelectedTreeViewItems.Remove(newSelected);
                if (_lastSelectedItem != null)
                    _lastSelectedItem.IsSelected = true;
                _lastSelectedItem = null;
            }
            else
            {
                if (_lastSelectedItem != null)
                    _lastSelectedItem.IsSelected = true;
                SelectedTreeViewItems.Add(newSelected);
                _lastSelectedItem = newSelected;
            }
        }

        private void HandleShiftKeySelection(TreeViewItem newSelectedItemContainer)
        {
            if (_lastSelectedItem != null)
            {
                ClearAllSelections();
                var items = GetFlatTreeViewItems(this);

                var firstItemPos = items.IndexOf(_lastSelectedItem);
                var lastItemPos = items.IndexOf(newSelectedItemContainer);
                Sort(ref firstItemPos, ref lastItemPos);

                for (int i = firstItemPos; i <= lastItemPos; ++i)
                {
                    items[i].IsSelected = true;
                    SelectedTreeViewItems.Add(items[i]);
                }
            }
        }

        private void HandleSingleSelection(TreeViewItem newSelectedItem)
        {
            ClearAllSelections();
            newSelectedItem.IsSelected = true;
            SelectedTreeViewItems.Add(newSelectedItem);
            _lastSelectedItem = newSelectedItem;
        }

        private void Sort(ref int firstItemPos, ref int lastItemPos)
        {
            if (firstItemPos > lastItemPos)
            {
                var tmp = firstItemPos;
                firstItemPos = lastItemPos;
                lastItemPos = tmp;
            }
        }

        private List<TreeViewItem> GetFlatTreeViewItems(ItemsControl control)
        {
            var items = new List<TreeViewItem>();

            foreach (object item in control.Items)
            {
                var containerItem = item as TreeViewItem;
                if (containerItem == null)
                    containerItem = control.ItemContainerGenerator.ContainerFromItem(item) as TreeViewItem;
                if (containerItem != null)
                {
                    items.Add(containerItem);
                    if (containerItem.IsExpanded)
                        items.AddRange(GetFlatTreeViewItems(containerItem));
                }
            }

            return items;
        }

        private void ClearAllSelections()
        {
            while (SelectedTreeViewItems.Count > 0)
            {
                SelectedTreeViewItems[0].IsSelected = false;
                SelectedTreeViewItems.RemoveAt(0);
            }
        }

        private TreeViewItem GetSelectedContainer()
        {
            return (TreeViewItem)typeof(TreeView).GetField("_selectedContainer", BindingFlags.NonPublic | BindingFlags.Instance).GetValue((TreeView)this);
        }

        private PropertyInfo _isSelectionChangeActiveProperty;
        
        private void DisableSelectionChangedEvent()
        {
            _isSelectionChangeActiveProperty.SetValue((TreeView)this, true, null);
        }

        private void EnableSelectionChangedEvent()
        {
            _isSelectionChangeActiveProperty.SetValue((TreeView)this, false, null);
        }

        /// <summary>
        /// Gets all selected items in the tree view. If nothing is selected an empty list is returned.
        /// </summary>
        public ObservableCollection<object> SelectedItems
        {
            get
            {
                var items = new ObservableCollection<object>();
                var selectedItems = SelectedTreeViewItems.Select(i => i.Header);
                foreach (var item in selectedItems)
                    items.Add(item);
                return items;
            }
        }

        /// <summary>
        /// Gets the selected tree view item container.
        /// </summary>
        public ObservableCollection<TreeViewItem> SelectedTreeViewItems { get; private set; }

        /// <summary>
        /// Gets or set a value which indicates how items can be selected in the tree view.
        /// </summary>
        [DefaultValue(SelectionMode.Extended)]
        public SelectionMode SelectionMode
        {
            get { return (SelectionMode)GetValue(SelectionModeProperty); }
            set { SetValue(SelectionModeProperty, value); }
        }

        /// <summary>
        /// Identifies the <see cref="DW.WPFToolkit.Controls.EnhancedTreeView.SelectionMode" /> dependency property.
        /// </summary>
        public static readonly DependencyProperty SelectionModeProperty =
            DependencyProperty.Register("SelectionMode", typeof(SelectionMode), typeof(EnhancedTreeView), new UIPropertyMetadata(SelectionMode.Extended));

        /// <summary>
        /// Gets or sets a value which indicates of the child tree view items should be stretched over the whole control width or not.
        /// </summary>
        [DefaultValue(false)]
        public bool ItemsContentStretching
        {
            get { return (bool)GetValue(ItemsContentStretchingProperty); }
            set { SetValue(ItemsContentStretchingProperty, value); }
        }

        /// <summary>
        /// Identifies the <see cref="DW.WPFToolkit.Controls.EnhancedTreeView.ItemsContentStretching" /> dependency property.
        /// </summary>
        public static readonly DependencyProperty ItemsContentStretchingProperty =
            DependencyProperty.Register("ItemsContentStretching", typeof(bool), typeof(EnhancedTreeView), new UIPropertyMetadata(false));

        /// <summary>
        /// Gets or sets the command to be executed if a item got selected.
        /// </summary>
        [DefaultValue(null)]
        public ICommand SelectedItemChangedCommand
        {
            get { return (ICommand)GetValue(SelectedItemChangedCommandProperty); }
            set { SetValue(SelectedItemChangedCommandProperty, value); }
        }

        /// <summary>
        /// Identifies the <see cref="DW.WPFToolkit.Controls.EnhancedTreeView.SelectedItemChangedCommand" /> dependency property.
        /// </summary>
        public static readonly DependencyProperty SelectedItemChangedCommandProperty =
            DependencyProperty.Register("SelectedItemChangedCommand", typeof(ICommand), typeof(EnhancedTreeView), new PropertyMetadata(null));

        private void OnSelectedItemChangedCommand(object newValue)
        {
            if (SelectedItemChangedCommand != null && SelectedItemChangedCommand.CanExecute(newValue))
                SelectedItemChangedCommand.Execute(newValue);
        }

        #region SelectedElement
        /// <summary>
        /// Dependency Property for the bound selected Element. Get and Set. Only valid in SingleMode.
        /// </summary>
        public static readonly DependencyProperty SelectedElementProperty =
                DependencyProperty.Register(
                    "SelectedElement",
                    typeof(object),
                    typeof(EnhancedTreeView),
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
        /// <param name="d">The EnhancedTreeView</param>
        /// <param name="e">The args. (not used)</param>
        private static void SelectedElementChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {

            var newElement = e.NewValue;
            var treeListView = d as EnhancedTreeView;
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
                    gen.StatusChanged += (o, args) => treeListView._containerStatusChangedEventHandler(o, args);
                }
            }
        }

        /// <summary>
        /// Gets the generated (UI) EnhancedTreeViewItem.
        /// </summary>
        /// <param name="containerGenerator">The ItemContainerGenerator from the "parent".</param>
        /// <param name="item">The (bound) item to get the generated UI Item.</param>
        /// <returns>The generated UI EnhancedTreeViewItem. null if nothing to return.</returns>
        private static EnhancedTreeViewItem ContainerFromItem(ItemContainerGenerator containerGenerator, object item)
        {
            if (containerGenerator != null)
            {
                var container = containerGenerator.ContainerFromItem(item) as EnhancedTreeViewItem;
                if (container != null)
                {
                    return container;
                }
                // Get items from Container through Reflection. This Property is only public in verision > .NET 4.5
                IEnumerable items = containerGenerator.GetPropertyValue("Items") as IEnumerable;
                if (items != null)
                {
                    foreach (var childItem in items)
                    {
                        var parent = containerGenerator.ContainerFromItem(childItem) as EnhancedTreeViewItem;
                        if (parent == null)
                        {
                            continue;
                        }

                        container = parent.ItemContainerGenerator.ContainerFromItem(item) as EnhancedTreeViewItem;
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
                    var enhancedTreeView = VisualTreeAssist.FindParent<EnhancedTreeView>(ui);
                    if (enhancedTreeView != null)
                    {
                        itemContainerGenerator.StatusChanged -=
                            (o, args) => enhancedTreeView._containerStatusChangedEventHandler(o, args);
                    }
                    ui.SetValue(TreeViewItem.IsSelectedProperty, true);

                }
            }
        }
        #endregion
    }
}
