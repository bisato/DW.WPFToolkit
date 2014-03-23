using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using DW.WPFToolkit.Helpers;

namespace DW.WPFToolkit.Interactivity
{
    public class ColumnSortBehavior : DependencyObject
    {
        public static DataTemplate GetNeutralHeaderTemplate(DependencyObject obj)
        {
            return (DataTemplate)obj.GetValue(NeutralHeaderTemplateProperty);
        }

        public static void SetNeutralHeaderTemplate(DependencyObject obj, DataTemplate value)
        {
            obj.SetValue(NeutralHeaderTemplateProperty, value);
        }

        /// <summary>
        /// Identifies the <see cref="DW.WPFToolkit.Interactivity.ColumnSortBehavior.GetNeutralHeaderTemplate(DependencyObject)" /> <see cref="DW.WPFToolkit.Interactivity.ColumnSortBehavior.SetNeutralHeaderTemplate(DependencyObject, DataTemplate)" /> attached property.
        /// </summary>
        public static readonly DependencyProperty NeutralHeaderTemplateProperty =
            DependencyProperty.RegisterAttached("NeutralHeaderTemplate", typeof(DataTemplate), typeof(ColumnSortBehavior), new UIPropertyMetadata(null));

        public static DataTemplate GetAscendingSortHeaderTemplate(DependencyObject obj)
        {
            return (DataTemplate)obj.GetValue(AscendingSortHeaderTemplateProperty);
        }

        public static void SetAscendingSortHeaderTemplate(DependencyObject obj, DataTemplate value)
        {
            obj.SetValue(AscendingSortHeaderTemplateProperty, value);
        }

        /// <summary>
        /// Identifies the <see cref="DW.WPFToolkit.Interactivity.ColumnSortBehavior.GetAscendingSortHeaderTemplate(DependencyObject)" /> <see cref="DW.WPFToolkit.Interactivity.ColumnSortBehavior.SetAscendingSortHeaderTemplate(DependencyObject, DataTemplate)" /> attached property.
        /// </summary>
        public static readonly DependencyProperty AscendingSortHeaderTemplateProperty =
            DependencyProperty.RegisterAttached("AscendingSortHeaderTemplate", typeof(DataTemplate), typeof(ColumnSortBehavior), new UIPropertyMetadata(null));

        public static DataTemplate GetDescendingSortHeaderTemplate(DependencyObject obj)
        {
            return (DataTemplate)obj.GetValue(DescendingSortHeaderTemplateProperty);
        }

        public static void SetDescendingSortHeaderTemplate(DependencyObject obj, DataTemplate value)
        {
            obj.SetValue(DescendingSortHeaderTemplateProperty, value);
        }

        /// <summary>
        /// Identifies the <see cref="DW.WPFToolkit.Interactivity.ColumnSortBehavior.GetDescendingSortHeaderTemplate(DependencyObject)" /> <see cref="DW.WPFToolkit.Interactivity.ColumnSortBehavior.SetDescendingSortHeaderTemplate(DependencyObject, DataTemplate)" /> attached property.
        /// </summary>
        public static readonly DependencyProperty DescendingSortHeaderTemplateProperty =
            DependencyProperty.RegisterAttached("DescendingSortHeaderTemplate", typeof(DataTemplate), typeof(ColumnSortBehavior), new UIPropertyMetadata(null));

        public static bool GetAllowColumnSortings(DependencyObject obj)
        {
            return (bool)obj.GetValue(AllowColumnSortingsProperty);
        }

        public static void SetAllowColumnSortings(DependencyObject obj, bool value)
        {
            obj.SetValue(AllowColumnSortingsProperty, value);
        }

        /// <summary>
        /// Identifies the <see cref="DW.WPFToolkit.Interactivity.ColumnSortBehavior.GetAllowColumnSortings(DependencyObject)" /> <see cref="DW.WPFToolkit.Interactivity.ColumnSortBehavior.SetAllowColumnSortings(DependencyObject, bool)" /> attached property.
        /// </summary>
        public static readonly DependencyProperty AllowColumnSortingsProperty =
            DependencyProperty.RegisterAttached("AllowColumnSortings", typeof(bool), typeof(ColumnSortBehavior), new UIPropertyMetadata(OnAllowColumnSortingsChanged));

        private static void OnAllowColumnSortingsChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            var element = (FrameworkElement)sender;
            element.Loaded += new RoutedEventHandler(Eement_Loaded);
        }

        public static bool GetIsDefaultSortColumn(DependencyObject obj)
        {
            return (bool)obj.GetValue(IsDefaultSortColumnProperty);
        }

        public static void SetIsDefaultSortColumn(DependencyObject obj, bool value)
        {
            obj.SetValue(IsDefaultSortColumnProperty, value);
        }

        /// <summary>
        /// Identifies the <see cref="DW.WPFToolkit.Interactivity.ColumnSortBehavior.GetIsDefaultSortColumn(DependencyObject)" /> <see cref="DW.WPFToolkit.Interactivity.ColumnSortBehavior.SetIsDefaultSortColumn(DependencyObject, bool)" /> attached property.
        /// </summary>
        public static readonly DependencyProperty IsDefaultSortColumnProperty =
            DependencyProperty.RegisterAttached("IsDefaultSortColumn", typeof(bool), typeof(ColumnSortBehavior), new UIPropertyMetadata(null));

        public static string GetSortPropertyName(DependencyObject obj)
        {
            return (string)obj.GetValue(SortPropertyNameProperty);
        }

        public static void SetSortPropertyName(DependencyObject obj, string value)
        {
            obj.SetValue(SortPropertyNameProperty, value);
        }

        /// <summary>
        /// Identifies the <see cref="DW.WPFToolkit.Interactivity.ColumnSortBehavior.GetSortPropertyName(DependencyObject)" /> <see cref="DW.WPFToolkit.Interactivity.ColumnSortBehavior.SetSortPropertyName(DependencyObject, string)" /> attached property.
        /// </summary>
        public static readonly DependencyProperty SortPropertyNameProperty =
            DependencyProperty.RegisterAttached("SortPropertyName", typeof(string), typeof(ColumnSortBehavior), new UIPropertyMetadata(null));

        private static ColumnSortBehavior GetColumnSortingBehavior(DependencyObject obj)
        {
            return (ColumnSortBehavior)obj.GetValue(ColumnSortingBehaviorProperty);
        }

        private static void SetColumnSortingBehavior(DependencyObject obj, ColumnSortBehavior value)
        {
            obj.SetValue(ColumnSortingBehaviorProperty, value);
        }

        /// <summary>
        /// Identifies the <see cref="DW.WPFToolkit.Interactivity.ColumnSortBehavior.GetColumnSortingBehavior(DependencyObject)" /> <see cref="DW.WPFToolkit.Interactivity.ColumnSortBehavior.SetColumnSortingBehavior(DependencyObject, ColumnSortBehavior)" /> attached property.
        /// </summary>
        private static readonly DependencyProperty ColumnSortingBehaviorProperty =
            DependencyProperty.RegisterAttached("ColumnSortingBehavior", typeof(ColumnSortBehavior), typeof(ColumnSortBehavior), new UIPropertyMetadata(null));

        private static ColumnSortBehavior GetOrSetBehavior(DependencyObject sender)
        {
            var behavior = GetColumnSortingBehavior(sender);
            if (behavior == null)
            {
                behavior = new ColumnSortBehavior();
                SetColumnSortingBehavior(sender, behavior);
            }
            return behavior;
        }

        private static void Eement_Loaded(object sender, RoutedEventArgs e)
        {
            var element = (FrameworkElement)sender;
            if (GetAllowColumnSortings(element))
            {
                if (GetColumnSortingBehavior(element) != null)
                    return;

                var behavior = GetOrSetBehavior(element);
                element.AddHandler(GridViewColumnHeader.ClickEvent, new RoutedEventHandler(behavior.GridViewColumnHeaderClickedHandler));
                behavior._owner = (ItemsControl)element;
                behavior.GetColumns(element);
                behavior.RunDefaultSort();
            }
        }

        private void GetColumns(DependencyObject sender)
        {
            var behavior = GetOrSetBehavior(sender);
            var presenter = VisualTreeAssist.FindChild<GridViewHeaderRowPresenter>(_owner);
            if (presenter != null)
                _columns = presenter.Columns;
            
            if (_columns != null)
            {
                foreach (var column in _columns)
                    column.HeaderTemplate = GetNeutralHeaderTemplate(sender);
            }
        }

        private bool _isSorting;
        private ItemsControl _owner;
        private GridViewColumnCollection _columns;
        private GridViewColumn _lastSortedColumn;
        private ListSortDirection _lastDirection;

        private void RunDefaultSort()
        {
            if (_columns != null)
            {
                GridViewColumn sortableGridViewColumn = null;
                foreach (var column in _columns)
                {
                    if (GetIsDefaultSortColumn(column))
                    {
                        sortableGridViewColumn = column;
                        break;
                    }
                }
                if (sortableGridViewColumn != null)
                {
                    _lastSortedColumn = sortableGridViewColumn;
                    Sort(GetSortPropertyName(sortableGridViewColumn), ListSortDirection.Ascending);
                    sortableGridViewColumn.HeaderTemplate = GetAscendingSortHeaderTemplate(_owner);
                }
            }
        }

        private void GridViewColumnHeaderClickedHandler(object sender, RoutedEventArgs e)
        {
            var headerClicked = e.OriginalSource as GridViewColumnHeader;
            if (headerClicked != null &&
                headerClicked.Role != GridViewColumnHeaderRole.Padding)
            {
                var clickedColumn = headerClicked.Column;
                string toSortPropertyName = GetSortPropertyName(clickedColumn);
                if (clickedColumn != null &&
                    !String.IsNullOrEmpty(toSortPropertyName))
                {
                    var direction = ListSortDirection.Ascending;
                    bool isNewSortColumn = IsNewSortColumn(toSortPropertyName);
                    if (!isNewSortColumn)
                        direction = _lastDirection == ListSortDirection.Ascending ? ListSortDirection.Descending : ListSortDirection.Ascending;

                    Sort(toSortPropertyName, direction);

                    clickedColumn.HeaderTemplate = direction == ListSortDirection.Ascending ? GetAscendingSortHeaderTemplate(_owner) : GetDescendingSortHeaderTemplate(_owner);

                    ResetLastTemplate(isNewSortColumn);
                    _lastSortedColumn = clickedColumn;
                }
            }
        }

        private bool IsNewSortColumn(string toSortPropertyName)
        {
            if (_lastSortedColumn == null)
                return true;
            var lastSortPropertyName = GetSortPropertyName(_lastSortedColumn);
            return string.IsNullOrEmpty(toSortPropertyName) ||
                   !string.Equals(lastSortPropertyName, toSortPropertyName, StringComparison.InvariantCultureIgnoreCase);
        }

        private void ResetLastTemplate(bool isNewSortColumn)
        {
            if (isNewSortColumn &&
                _lastSortedColumn != null)
                _lastSortedColumn.HeaderTemplate = GetNeutralHeaderTemplate(_owner);
        }

        private void Resort()
        {
            if (!_isSorting)
            {
                _isSorting = true;
                if (_lastSortedColumn != null &&
                    !string.IsNullOrEmpty(GetSortPropertyName(_lastSortedColumn)))
                    Sort(GetSortPropertyName(_lastSortedColumn), _lastDirection);
                _isSorting = false;
            }
        }

        private void Sort(string sortBy, ListSortDirection direction)
        {
            _lastDirection = direction;
            var dataView = CollectionViewSource.GetDefaultView(_owner.Items);
            if (dataView != null)
            {
                dataView.SortDescriptions.Clear();
                dataView.SortDescriptions.Add(new SortDescription(sortBy, direction));
                dataView.Refresh();
            }
        }
    }
}
