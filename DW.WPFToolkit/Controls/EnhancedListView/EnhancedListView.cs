using System.Collections;
using System.Windows;
using System.Windows.Controls;
using DW.WPFToolkit.Interactivity;

namespace DW.WPFToolkit.Controls
{
    /// <summary>
    /// Enhances the <see cref="System.Windows.Controls.ListView" /> with additional features like column sorting, dynamic column width and dynamic shown column.
    /// </summary>
    public class EnhancedListView : ListView
    {
        public ColumnResizeKind AutoSize
        {
            get { return (ColumnResizeKind)GetValue(AutoSizeProperty); }
            set { SetValue(AutoSizeProperty, value); }
        }

        /// <summary>
        /// Identifies the <see cref="DW.WPFToolkit.Controls.EnhancedListView.AutoSize" /> dependency property.
        /// </summary>
        public static readonly DependencyProperty AutoSizeProperty =
            DependencyProperty.Register("AutoSize", typeof(ColumnResizeKind), typeof(EnhancedListView), new UIPropertyMetadata(ColumnResizeKind.NoResize, OnAutoSizeChanged));

        private static void OnAutoSizeChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            ColumnWidthBehavior.SetAutoSize(sender, (ColumnResizeKind)e.NewValue);
        }

        public double TemplatePaddingWidthFix
        {
            get { return (double)GetValue(TemplatePaddingWidthFixProperty); }
            set { SetValue(TemplatePaddingWidthFixProperty, value); }
        }

        /// <summary>
        /// Identifies the <see cref="DW.WPFToolkit.Controls.EnhancedListView.TemplatePaddingWidthFix" /> dependency property.
        /// </summary>
        public static readonly DependencyProperty TemplatePaddingWidthFixProperty =
            DependencyProperty.Register("TemplatePaddingWidthFix", typeof(double), typeof(EnhancedListView), new UIPropertyMetadata(10.0, OnTemplatePaddingWidthFixChanged));

        private static void OnTemplatePaddingWidthFixChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            ColumnWidthBehavior.SetTemplatePaddingWidthFix(sender, (double)e.NewValue);
        }

        public IList VisibleColumns
        {
            get { return (IList)GetValue(VisibleColumnsProperty); }
            set { SetValue(VisibleColumnsProperty, value); }
        }

        /// <summary>
        /// Identifies the <see cref="DW.WPFToolkit.Controls.EnhancedListView.VisibleColumns" /> dependency property.
        /// </summary>
        public static readonly DependencyProperty VisibleColumnsProperty =
            DependencyProperty.Register("VisibleColumns", typeof(IList), typeof(EnhancedListView), new UIPropertyMetadata(OnVisibleColumnsChanged));

        private static void OnVisibleColumnsChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            ColumnVisibilityBehavior.SetVisibleColumns(sender, (IList)e.NewValue);
        }

        public DataTemplate NeutralHeaderTemplate
        {
            get { return (DataTemplate)GetValue(NeutralHeaderTemplateProperty); }
            set { SetValue(NeutralHeaderTemplateProperty, value); }
        }

        /// <summary>
        /// Identifies the <see cref="DW.WPFToolkit.Controls.EnhancedListView.NeutralHeaderTemplate" /> dependency property.
        /// </summary>
        public static readonly DependencyProperty NeutralHeaderTemplateProperty =
            DependencyProperty.Register("NeutralHeaderTemplate", typeof(DataTemplate), typeof(EnhancedListView), new UIPropertyMetadata(null, OnNeutralHeaderTemplateChanged));

        private static void OnNeutralHeaderTemplateChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            ColumnSortBehavior.SetNeutralHeaderTemplate(sender, (DataTemplate)e.NewValue);
        }

        public DataTemplate AscendingSortHeaderTemplate
        {
            get { return (DataTemplate)GetValue(AscendingSortHeaderTemplateProperty); }
            set { SetValue(AscendingSortHeaderTemplateProperty, value); }
        }

        /// <summary>
        /// Identifies the <see cref="DW.WPFToolkit.Controls.EnhancedListView.AscendingSortHeaderTemplate" /> dependency property.
        /// </summary>
        public static readonly DependencyProperty AscendingSortHeaderTemplateProperty =
            DependencyProperty.Register("AscendingSortHeaderTemplate", typeof(DataTemplate), typeof(EnhancedListView), new UIPropertyMetadata(null, OnAscendingSortHeaderTemplateChanged));

        private static void OnAscendingSortHeaderTemplateChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            ColumnSortBehavior.SetAscendingSortHeaderTemplate(sender, (DataTemplate)e.NewValue);
        }

        public DataTemplate DescendingSortHeaderTemplate
        {
            get { return (DataTemplate)GetValue(DescendingSortHeaderTemplateProperty); }
            set { SetValue(DescendingSortHeaderTemplateProperty, value); }
        }

        /// <summary>
        /// Identifies the <see cref="DW.WPFToolkit.Controls.EnhancedListView.DescendingSortHeaderTemplate" /> dependency property.
        /// </summary>
        public static readonly DependencyProperty DescendingSortHeaderTemplateProperty =
            DependencyProperty.Register("DescendingSortHeaderTemplate", typeof(DataTemplate), typeof(EnhancedListView), new UIPropertyMetadata(null, OnDescendingSortHeaderTemplateChanged));

        private static void OnDescendingSortHeaderTemplateChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            ColumnSortBehavior.SetDescendingSortHeaderTemplate(sender, (DataTemplate)e.NewValue);
        }

        public bool AllowColumnSortings
        {
            get { return (bool)GetValue(AllowColumnSortingsProperty); }
            set { SetValue(AllowColumnSortingsProperty, value); }
        }

        /// <summary>
        /// Identifies the <see cref="DW.WPFToolkit.Controls.EnhancedListView.AllowColumnSortings" /> dependency property.
        /// </summary>
        public static readonly DependencyProperty AllowColumnSortingsProperty =
            DependencyProperty.Register("AllowColumnSortings", typeof(bool), typeof(EnhancedListView), new UIPropertyMetadata(false, OnAllowColumnSortingsChanged));

        private static void OnAllowColumnSortingsChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            ColumnSortBehavior.SetAllowColumnSortings(sender, (bool)e.NewValue);
        }
    }
}
