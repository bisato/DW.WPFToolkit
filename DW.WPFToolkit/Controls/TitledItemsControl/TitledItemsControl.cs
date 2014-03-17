using System.Windows;
using System.Windows.Controls;

namespace DW.WPFToolkit.Controls
{
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

        public static readonly DependencyProperty VerticalTitleAlignmentsProperty =
            DependencyProperty.Register("VerticalTitleAlignments", typeof(VerticalAlignment), typeof(TitledItemsControl), new UIPropertyMetadata(VerticalAlignment.Center));

        public HorizontalAlignment HorizontalTitleAlignments
        {
            get { return (HorizontalAlignment)GetValue(HorizontalTitleAlignmentsProperty); }
            set { SetValue(HorizontalTitleAlignmentsProperty, value); }
        }

        public static readonly DependencyProperty HorizontalTitleAlignmentsProperty =
            DependencyProperty.Register("HorizontalTitleAlignments", typeof(HorizontalAlignment), typeof(TitledItemsControl), new UIPropertyMetadata(HorizontalAlignment.Right));

        public Thickness TitleMargins
        {
            get { return (Thickness)GetValue(TitleMarginsProperty); }
            set { SetValue(TitleMarginsProperty, value); }
        }

        public static readonly DependencyProperty TitleMarginsProperty =
            DependencyProperty.Register("TitleMargins", typeof(Thickness), typeof(TitledItemsControl), new UIPropertyMetadata(new Thickness(5, 0, 5, 0)));

        public HorizontalAlignment HorizontalContentAlignments
        {
            get { return (HorizontalAlignment)GetValue(HorizontalContentAlignmentsProperty); }
            set { SetValue(HorizontalContentAlignmentsProperty, value); }
        }

        public static readonly DependencyProperty HorizontalContentAlignmentsProperty =
            DependencyProperty.Register("HorizontalContentAlignments", typeof(HorizontalAlignment), typeof(TitledItemsControl), new UIPropertyMetadata(HorizontalAlignment.Stretch));

        public VerticalAlignment VerticalContentAlignments
        {
            get { return (VerticalAlignment)GetValue(VerticalContentAlignmentsProperty); }
            set { SetValue(VerticalContentAlignmentsProperty, value); }
        }

        public static readonly DependencyProperty VerticalContentAlignmentsProperty =
            DependencyProperty.Register("VerticalContentAlignments", typeof(VerticalAlignment), typeof(TitledItemsControl), new UIPropertyMetadata(VerticalAlignment.Center));

        public Thickness ContentMargins
        {
            get { return (Thickness)GetValue(ContentMarginsProperty); }
            set { SetValue(ContentMarginsProperty, value); }
        }

        public static readonly DependencyProperty ContentMarginsProperty =
            DependencyProperty.Register("ContentMargins", typeof(Thickness), typeof(TitledItemsControl), new UIPropertyMetadata(new Thickness(0, 2, 0, 2)));
    }
}
