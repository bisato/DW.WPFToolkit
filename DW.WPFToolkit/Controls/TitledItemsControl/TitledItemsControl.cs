using System.Windows;
using System.Windows.Controls;

namespace DW.WPFToolkit.Controls
{
    /// <summary>
    /// Shows items with its title allined to each other. This can be used for every kind of input masks.
    /// </summary>
    public class TitledItemsControl : ItemsControl
    {
        static TitledItemsControl()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(TitledItemsControl), new FrameworkPropertyMetadata(typeof(TitledItemsControl)));
        }

        protected override DependencyObject GetContainerForItemOverride()
        {
            return new TitledItem();
        }

        protected override bool IsItemItsOwnContainerOverride(object item)
        {
            return item is TitledItem;
        }

        public VerticalAlignment VerticalTitleAlignments
        {
            get { return (VerticalAlignment)GetValue(VerticalTitleAlignmentsProperty); }
            set { SetValue(VerticalTitleAlignmentsProperty, value); }
        }

        /// <summary>
        /// Identifies the <see cref="DW.WPFToolkit.Controls.TitledItemsControl.VerticalTitleAlignments" /> dependency property.
        /// </summary>
        public static readonly DependencyProperty VerticalTitleAlignmentsProperty =
            DependencyProperty.Register("VerticalTitleAlignments", typeof(VerticalAlignment), typeof(TitledItemsControl), new UIPropertyMetadata(VerticalAlignment.Center));

        public HorizontalAlignment HorizontalTitleAlignments
        {
            get { return (HorizontalAlignment)GetValue(HorizontalTitleAlignmentsProperty); }
            set { SetValue(HorizontalTitleAlignmentsProperty, value); }
        }

        /// <summary>
        /// Identifies the <see cref="DW.WPFToolkit.Controls.TitledItemsControl.HorizontalTitleAlignments" /> dependency property.
        /// </summary>
        public static readonly DependencyProperty HorizontalTitleAlignmentsProperty =
            DependencyProperty.Register("HorizontalTitleAlignments", typeof(HorizontalAlignment), typeof(TitledItemsControl), new UIPropertyMetadata(HorizontalAlignment.Right));

        public Thickness TitleMargins
        {
            get { return (Thickness)GetValue(TitleMarginsProperty); }
            set { SetValue(TitleMarginsProperty, value); }
        }

        /// <summary>
        /// Identifies the <see cref="DW.WPFToolkit.Controls.TitledItemsControl.TitleMargins" /> dependency property.
        /// </summary>
        public static readonly DependencyProperty TitleMarginsProperty =
            DependencyProperty.Register("TitleMargins", typeof(Thickness), typeof(TitledItemsControl), new UIPropertyMetadata(new Thickness(5, 0, 5, 0)));

        public HorizontalAlignment HorizontalContentAlignments
        {
            get { return (HorizontalAlignment)GetValue(HorizontalContentAlignmentsProperty); }
            set { SetValue(HorizontalContentAlignmentsProperty, value); }
        }

        /// <summary>
        /// Identifies the <see cref="DW.WPFToolkit.Controls.TitledItemsControl.HorizontalContentAlignments" /> dependency property.
        /// </summary>
        public static readonly DependencyProperty HorizontalContentAlignmentsProperty =
            DependencyProperty.Register("HorizontalContentAlignments", typeof(HorizontalAlignment), typeof(TitledItemsControl), new UIPropertyMetadata(HorizontalAlignment.Stretch));

        public VerticalAlignment VerticalContentAlignments
        {
            get { return (VerticalAlignment)GetValue(VerticalContentAlignmentsProperty); }
            set { SetValue(VerticalContentAlignmentsProperty, value); }
        }

        /// <summary>
        /// Identifies the <see cref="DW.WPFToolkit.Controls.TitledItemsControl.VerticalContentAlignments" /> dependency property.
        /// </summary>
        public static readonly DependencyProperty VerticalContentAlignmentsProperty =
            DependencyProperty.Register("VerticalContentAlignments", typeof(VerticalAlignment), typeof(TitledItemsControl), new UIPropertyMetadata(VerticalAlignment.Center));

        public Thickness ContentMargins
        {
            get { return (Thickness)GetValue(ContentMarginsProperty); }
            set { SetValue(ContentMarginsProperty, value); }
        }

        /// <summary>
        /// Identifies the <see cref="DW.WPFToolkit.Controls.TitledItemsControl.ContentMargins" /> dependency property.
        /// </summary>
        public static readonly DependencyProperty ContentMarginsProperty =
            DependencyProperty.Register("ContentMargins", typeof(Thickness), typeof(TitledItemsControl), new UIPropertyMetadata(new Thickness(0, 2, 0, 2)));
    }
}
