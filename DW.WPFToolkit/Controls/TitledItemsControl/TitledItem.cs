using System.Windows;
using System.Windows.Controls;

namespace DW.WPFToolkit.Controls
{
    public class TitledItem : ContentControl
    {
        static TitledItem()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(TitledItem), new FrameworkPropertyMetadata(typeof(TitledItem)));
        }

        public object Title
        {
            get { return (object)GetValue(TitleProperty); }
            set { SetValue(TitleProperty, value); }
        }

        public static readonly DependencyProperty TitleProperty =
            DependencyProperty.Register("Title", typeof(object), typeof(TitledItem), new UIPropertyMetadata(null));

        public VerticalAlignment VerticalTitleAlignment
        {
            get { return (VerticalAlignment)GetValue(VerticalTitleAlignmentProperty); }
            set { SetValue(VerticalTitleAlignmentProperty, value); }
        }

        public static readonly DependencyProperty VerticalTitleAlignmentProperty =
            DependencyProperty.Register("VerticalTitleAlignment", typeof(VerticalAlignment), typeof(TitledItem), new UIPropertyMetadata(VerticalAlignment.Center));

        public HorizontalAlignment HorizontalTitleAlignment
        {
            get { return (HorizontalAlignment)GetValue(HorizontalTitleAlignmentProperty); }
            set { SetValue(HorizontalTitleAlignmentProperty, value); }
        }

        public static readonly DependencyProperty HorizontalTitleAlignmentProperty =
            DependencyProperty.Register("HorizontalTitleAlignment", typeof(HorizontalAlignment), typeof(TitledItem), new UIPropertyMetadata(HorizontalAlignment.Right));

        public Thickness TitleMargin
        {
            get { return (Thickness)GetValue(TitleMarginProperty); }
            set { SetValue(TitleMarginProperty, value); }
        }

        public static readonly DependencyProperty TitleMarginProperty =
            DependencyProperty.Register("TitleMargin", typeof(Thickness), typeof(TitledItem), new UIPropertyMetadata(new Thickness(5, 0, 5, 0)));

        public Thickness ContentMargin
        {
            get { return (Thickness)GetValue(ContentMarginProperty); }
            set { SetValue(ContentMarginProperty, value); }
        }

        public static readonly DependencyProperty ContentMarginProperty =
            DependencyProperty.Register("ContentMargin", typeof(Thickness), typeof(TitledItem), new UIPropertyMetadata(new Thickness(0, 2, 0, 2)));
    }
}
