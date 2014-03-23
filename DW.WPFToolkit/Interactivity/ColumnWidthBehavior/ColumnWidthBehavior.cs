using System.Collections.Generic;
using System.Collections.Specialized;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using DW.WPFToolkit.Helpers;

namespace DW.WPFToolkit.Interactivity
{
    public class ColumnWidthBehavior : DependencyObject
    {
        public static ColumnResizeKind GetAutoSize(DependencyObject obj)
        {
            return (ColumnResizeKind)obj.GetValue(AutoSizeProperty);
        }

        public static void SetAutoSize(DependencyObject obj, ColumnResizeKind value)
        {
            obj.SetValue(AutoSizeProperty, value);
        }

        /// <summary>
        /// Identifies the <see cref="DW.WPFToolkit.Interactivity.ColumnWidthBehavior.GetAutoSize(DependencyObject)" /> <see cref="DW.WPFToolkit.Interactivity.ColumnWidthBehavior.SetAutoSize(DependencyObject, ColumnResizeKind)" /> attached property.
        /// </summary>
        public static readonly DependencyProperty AutoSizeProperty =
            DependencyProperty.RegisterAttached("AutoSize", typeof(ColumnResizeKind), typeof(ColumnWidthBehavior), new UIPropertyMetadata(OnAutoSizeChanged));

        private static void OnAutoSizeChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            var behavior = GetOrSetBehavior(sender);
            var element = (FrameworkElement)sender;
            behavior._owner = sender;
            element.Loaded += behavior.Element_Loaded;
        }

        public static double GetProportionalWidth(DependencyObject obj)
        {
            return (double)obj.GetValue(ProportionalWidthProperty);
        }

        public static void SetProportionalWidth(DependencyObject obj, double value)
        {
            obj.SetValue(ProportionalWidthProperty, value);
        }

        /// <summary>
        /// Identifies the <see cref="DW.WPFToolkit.Interactivity.ColumnWidthBehavior.GetProportionalWidth(DependencyObject)" /> <see cref="DW.WPFToolkit.Interactivity.ColumnWidthBehavior.SetProportionalWidth(DependencyObject, double)" /> attached property.
        /// </summary>
        public static readonly DependencyProperty ProportionalWidthProperty =
            DependencyProperty.RegisterAttached("ProportionalWidth", typeof(double), typeof(ColumnWidthBehavior), new UIPropertyMetadata(double.NaN));

        public static double GetTemplatePaddingWidthFix(DependencyObject obj)
        {
            return (double)obj.GetValue(TemplatePaddingWidthFixProperty);
        }

        public static void SetTemplatePaddingWidthFix(DependencyObject obj, double value)
        {
            obj.SetValue(TemplatePaddingWidthFixProperty, value);
        }

        /// <summary>
        /// Identifies the <see cref="DW.WPFToolkit.Interactivity.ColumnWidthBehavior.GetTemplatePaddingWidthFix(DependencyObject)" /> <see cref="DW.WPFToolkit.Interactivity.ColumnWidthBehavior.SetTemplatePaddingWidthFix(DependencyObject, double)" /> attached property.
        /// </summary>
        public static readonly DependencyProperty TemplatePaddingWidthFixProperty =
            DependencyProperty.RegisterAttached("TemplatePaddingWidthFix", typeof(double), typeof(ColumnVisibilityBehavior), new UIPropertyMetadata(10.0));

        private static bool GetOriginalWidthIsRemembered(DependencyObject obj)
        {
            return (bool)obj.GetValue(OriginalWidthIsRememberedProperty);
        }

        private static void SetOriginalWidthIsRemembered(DependencyObject obj, bool value)
        {
            obj.SetValue(OriginalWidthIsRememberedProperty, value);
        }

        /// <summary>
        /// Identifies the <see cref="DW.WPFToolkit.Interactivity.ColumnWidthBehavior.GetOriginalWidthIsRemembered(DependencyObject)" /> <see cref="DW.WPFToolkit.Interactivity.ColumnWidthBehavior.SetOriginalWidthIsRemembered(DependencyObject, bool)" /> attached property.
        /// </summary>
        private static readonly DependencyProperty OriginalWidthIsRememberedProperty =
            DependencyProperty.RegisterAttached("OriginalWidthIsRemembered", typeof(bool), typeof(ColumnWidthBehavior), new UIPropertyMetadata(false));

        private static double GetOriginalWidth(DependencyObject obj)
        {
            return (double)obj.GetValue(OriginalWidthProperty);
        }

        private static void SetOriginalWidth(DependencyObject obj, double value)
        {
            obj.SetValue(OriginalWidthProperty, value);
        }

        /// <summary>
        /// Identifies the <see cref="DW.WPFToolkit.Interactivity.ColumnWidthBehavior.GetOriginalWidth(DependencyObject)" /> <see cref="DW.WPFToolkit.Interactivity.ColumnWidthBehavior.SetOriginalWidth(DependencyObject, double)" /> attached property.
        /// </summary>
        private static readonly DependencyProperty OriginalWidthProperty =
            DependencyProperty.RegisterAttached("OriginalWidth", typeof(double), typeof(ColumnWidthBehavior), new UIPropertyMetadata(0.0));

        private static ColumnWidthBehavior GetColumnWidthBehavior(DependencyObject obj)
        {
            return (ColumnWidthBehavior)obj.GetValue(ColumnWidthBehaviorProperty);
        }

        private static void SetColumnWidthBehavior(DependencyObject obj, ColumnWidthBehavior value)
        {
            obj.SetValue(ColumnWidthBehaviorProperty, value);
        }

        /// <summary>
        /// Identifies the <see cref="DW.WPFToolkit.Interactivity.ColumnWidthBehavior.GetColumnWidthBehavior(DependencyObject)" /> <see cref="DW.WPFToolkit.Interactivity.ColumnWidthBehavior.SetColumnWidthBehavior(DependencyObject, ColumnWidthBehavior)" /> attached property.
        /// </summary>
        private static readonly DependencyProperty ColumnWidthBehaviorProperty =
            DependencyProperty.RegisterAttached("ColumnWidthBehavior", typeof(ColumnWidthBehavior), typeof(ColumnWidthBehavior), new UIPropertyMetadata(null));

        private static ColumnWidthBehavior GetOrSetBehavior(DependencyObject sender)
        {
            var behavior = GetColumnWidthBehavior(sender);
            if (behavior == null)
            {
                behavior = new ColumnWidthBehavior();
                SetColumnWidthBehavior(sender, behavior);
            }
            return behavior;
        }

        private DependencyObject _owner;
        private GridViewColumnCollection _columns;
        private List<GridViewColumn> _toResizeColumns;
        private ScrollContentPresenter _scrollContentPresenter;
        private void Element_Loaded(object sender, RoutedEventArgs e)
        {
            Resize();
        }

        private void ScrollContentPresenter_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            Resize();
        }

        private void Resize()
        {
            var kind = GetAutoSize(_owner);
            if (kind != ColumnResizeKind.NoResize)
            {
                if (_columns == null)
                    TryReadColumns();

                if (_scrollContentPresenter == null)
                {
                    _scrollContentPresenter = FindPresenter();
                    if (_scrollContentPresenter != null)
                        _scrollContentPresenter.SizeChanged += new SizeChangedEventHandler(ScrollContentPresenter_SizeChanged);
                }

                if (_columns != null &&
                    _scrollContentPresenter != null)
                {
                    switch (kind)
                    {
                        case ColumnResizeKind.ByContent:
                            ResizeByContent();
                            break;
                        case ColumnResizeKind.ByControl:
                            ResizeByControl();
                            break;
                        case ColumnResizeKind.Proportional:
                            ResizeProportional();
                            break;
                    }
                }
            }
        }

        private void TryReadColumns()
        {
            var presenter = VisualTreeAssist.FindChild<GridViewHeaderRowPresenter>(_owner);
            if (presenter != null)
                _columns = presenter.Columns;

            if (_columns != null)
            {
                SetOriginalWidths();
                _columns.CollectionChanged += (a, b) => Reset();
            }
        }

        private void Reset()
        {
            if (_toResizeColumns != null)
            {
                foreach (var column in _toResizeColumns)
                    if (GetOriginalWidthIsRemembered(column))
                        column.Width = GetOriginalWidth(column);
                _toResizeColumns.Clear();
                _toResizeColumns = null;
            }

            Resize();
        }

        private void SetOriginalWidths()
        {
            foreach (var column in _columns)
            {
                SetOriginalWidth(column, column.Width);
                SetOriginalWidthIsRemembered(column, true);
            }
        }

        private ScrollContentPresenter FindPresenter()
        {
            var internalScrollViewer = VisualTreeAssist.FindChild<ScrollViewer>(_owner);
            return VisualTreeAssist.FindChild<ScrollContentPresenter>(internalScrollViewer);
        }

        #region ByContent
        private void ResizeByContent()
        {
            if (!_changedEventCatched)
            {
                _changedEventCatched = true;

                var itemsControl = (ItemsControl)_owner;
                var coll = CollectionViewSource.GetDefaultView(itemsControl.Items);
                if (coll != null)
                {
                    if (coll is INotifyCollectionChanged)
                        ((INotifyCollectionChanged)coll).CollectionChanged += (a, b) => { ResizeByContent(); };
                }
            }

            foreach (var column in _columns)
            {
                if (double.IsNaN(column.Width))
                {
                    column.Width = 0;
                    column.Width = double.NaN;
                }
            }
        }
        private bool _changedEventCatched;
        #endregion ByContent

        #region ByControl
        private void ResizeByControl()
        {
            var maxWidth = _scrollContentPresenter.ActualWidth;
            maxWidth -= GetTemplatePaddingWidthFix(_owner);

            double leftDistance = 0;
            if (maxWidth > 0)
            {
                leftDistance = CalculateFixedDistance(leftDistance);

                foreach (var column in _toResizeColumns)
                {
                    var newWidth = (maxWidth - leftDistance) / _toResizeColumns.Count;
                    if (newWidth >= 0)
                        column.Width = newWidth;
                }
            }
        }
        #endregion ByControl

        #region Proportional
        private void ResizeProportional()
        {
            var maxWidth = _scrollContentPresenter.ActualWidth;
            maxWidth -= GetTemplatePaddingWidthFix(_owner);

            double leftDistance = 0;
            if (maxWidth > 0)
            {
                leftDistance = CalculateFixedDistance(leftDistance);

                foreach (var column in _toResizeColumns)
                {
                    var proportion = GetProportionalWidth(column);
                    if (!double.IsNaN(proportion))
                    {
                        var newWidth = (maxWidth / 100.0) * proportion;
                        if (newWidth >= 0)
                            column.Width = newWidth;
                    }
                }
            }
        }
        #endregion Proportional

        private double CalculateFixedDistance(double leftDistance)
        {
            if (_toResizeColumns == null)
            {
                _toResizeColumns = new List<GridViewColumn>();
                foreach (var column in _columns)
                {
                    if (column.Width >= 0)
                        leftDistance += column.ActualWidth;
                    else
                        _toResizeColumns.Add(column);
                }
            }
            else
            {
                foreach (var column in _columns)
                {
                    if (!_toResizeColumns.Contains(column))
                        leftDistance += column.ActualWidth;
                }
            }
            return leftDistance;
        }
    }
}
