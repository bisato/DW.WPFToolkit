using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Windows;
using System.Windows.Controls;
using DW.WPFToolkit.Helpers;

namespace DW.WPFToolkit.Interactivity
{
    public class ColumnVisibilityBehavior : DependencyObject
    {
        private ColumnVisibilityBehavior()
        {
            _filteredColumns = new List<GridViewColumn>();
        }

        public static IList GetVisibleColumns(DependencyObject obj)
        {
            return (IList)obj.GetValue(VisibleColumnsProperty);
        }

        public static void SetVisibleColumns(DependencyObject obj, IList value)
        {
            obj.SetValue(VisibleColumnsProperty, value);
        }

        public static readonly DependencyProperty VisibleColumnsProperty =
            DependencyProperty.RegisterAttached("VisibleColumns", typeof(IList), typeof(ColumnVisibilityBehavior), new UIPropertyMetadata(OnVisibleColumnsChanged));

        private static void OnVisibleColumnsChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            var element = (FrameworkElement)sender;
            element.Loaded += new RoutedEventHandler(Eement_Loaded);
        }

        public static object GetName(DependencyObject obj)
        {
            return (object)obj.GetValue(NameProperty);
        }

        public static void SetName(DependencyObject obj, object value)
        {
            obj.SetValue(NameProperty, value);
        }

        public static readonly DependencyProperty NameProperty =
            DependencyProperty.RegisterAttached("Name", typeof(object), typeof(ColumnVisibilityBehavior), new UIPropertyMetadata(null));

        private static ColumnVisibilityBehavior GetColumnVisibilityBehavior(DependencyObject obj)
        {
            return (ColumnVisibilityBehavior)obj.GetValue(ColumnVisibilityBehaviorProperty);
        }

        private static void SetColumnVisibilityBehavior(DependencyObject obj, ColumnVisibilityBehavior value)
        {
            obj.SetValue(ColumnVisibilityBehaviorProperty, value);
        }

        private static readonly DependencyProperty ColumnVisibilityBehaviorProperty =
            DependencyProperty.RegisterAttached("ColumnVisibilityBehavior", typeof(ColumnVisibilityBehavior), typeof(ColumnVisibilityBehavior), new UIPropertyMetadata(null));

        private static ColumnVisibilityBehavior GetOrSetBehavior(DependencyObject sender)
        {
            ColumnVisibilityBehavior behavior = GetColumnVisibilityBehavior(sender);
            if (behavior == null)
            {
                behavior = new ColumnVisibilityBehavior();
                SetColumnVisibilityBehavior(sender, behavior);
            }
            return behavior;
        }

        private static int GetPosition(DependencyObject obj)
        {
            return (int)obj.GetValue(PositionProperty);
        }

        private static void SetPosition(DependencyObject obj, int value)
        {
            obj.SetValue(PositionProperty, value);
        }

        private static readonly DependencyProperty PositionProperty =
            DependencyProperty.RegisterAttached("Position", typeof(int), typeof(ColumnVisibilityBehavior), new UIPropertyMetadata(0));

        private static void Eement_Loaded(object sender, RoutedEventArgs e)
        {
            var element = (DependencyObject)sender;
            var behavior = GetOrSetBehavior(element);
            if (!behavior._isCatchedAlready)
            {
                var presenter = VisualTreeAssist.FindChild<GridViewHeaderRowPresenter>(element);
                if (presenter != null)
                    behavior.Handle(element, presenter.Columns);
            }
        }

        private bool _isCatchedAlready;
        private void Handle(DependencyObject sender, GridViewColumnCollection columns)
        {
            _isCatchedAlready = true;

            _owner = sender;
            _columns = columns;
            NumerizeColumns();

            var visibleColumns = GetVisibleColumns(sender);
            if (visibleColumns is INotifyCollectionChanged)
                ((INotifyCollectionChanged)visibleColumns).CollectionChanged += (a, b) => { Refresh(); };

            Refresh();
        }

        private void NumerizeColumns()
        {
            for (int i = 0; i < _columns.Count; ++i)
                SetPosition((DependencyObject)_columns[i], i);
        }

        private DependencyObject _owner;
        private GridViewColumnCollection _columns;
        private List<GridViewColumn> _filteredColumns;

        private void Refresh()
        {
            ResetOldFiltered();
            FilterOut();
        }

        private void ResetOldFiltered()
        {
            while (_columns.Count > 0)
            {
                _filteredColumns.Add(_columns[0]);
                _columns.RemoveAt(0);
            }
            _filteredColumns.Sort(SortByPosition);

            foreach (var column in _filteredColumns)
                _columns.Add(column);
            _filteredColumns.Clear();
        }

        private static int SortByPosition(GridViewColumn first, GridViewColumn second)
        {
            return GetPosition(first).CompareTo(GetPosition(second));
        }

        private void FilterOut()
        {
            var visibleColumns = GetVisibleColumns(_owner);
            for (int i = 0; i < _columns.Count; ++i)
            {
                var name = GetName((DependencyObject)_columns[i]);
                if (name != null)
                {
                    if (!visibleColumns.Contains(name))
                    {
                        _filteredColumns.Add((GridViewColumn)_columns[i]);
                        _columns.RemoveAt(i);
                        --i;
                    }
                }
            }
        }
    }
}
