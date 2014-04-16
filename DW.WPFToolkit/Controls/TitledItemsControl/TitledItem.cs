using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;

namespace DW.WPFToolkit.Controls
{
    /// <summary>
    /// Represents a single element with content and title in the <see cref="DW.WPFToolkit.Controls.TitledItemsControl" />.
    /// </summary>
    public class TitledItem : ContentControl
    {
        static TitledItem()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(TitledItem), new FrameworkPropertyMetadata(typeof(TitledItem)));
#if TRIAL
            License1.LicenseChecker.Validate();
#endif
        }

        /// <summary>
        /// Gets or sets the title of the item shown on the left.
        /// </summary>
        [DefaultValue(null)]
        public object Title
        {
            get { return (object)GetValue(TitleProperty); }
            set { SetValue(TitleProperty, value); }
        }

        /// <summary>
        /// Identifies the <see cref="DW.WPFToolkit.Controls.TitledItem.Title" /> dependency property.
        /// </summary>
        public static readonly DependencyProperty TitleProperty =
            DependencyProperty.Register("Title", typeof(object), typeof(TitledItem), new UIPropertyMetadata(null));

        /// <summary>
        /// Gets or sets the vertical alignment of the title.
        /// </summary>
        [DefaultValue(VerticalAlignment.Center)]
        public VerticalAlignment VerticalTitleAlignment
        {
            get { return (VerticalAlignment)GetValue(VerticalTitleAlignmentProperty); }
            set { SetValue(VerticalTitleAlignmentProperty, value); }
        }

        /// <summary>
        /// Identifies the <see cref="DW.WPFToolkit.Controls.TitledItem.VerticalTitleAlignment" /> dependency property.
        /// </summary>
        public static readonly DependencyProperty VerticalTitleAlignmentProperty =
            DependencyProperty.Register("VerticalTitleAlignment", typeof(VerticalAlignment), typeof(TitledItem), new UIPropertyMetadata(VerticalAlignment.Center));

        /// <summary>
        /// Gets or sets the horizontal alignment of the title.
        /// </summary>
        [DefaultValue(HorizontalAlignment.Right)]
        public HorizontalAlignment HorizontalTitleAlignment
        {
            get { return (HorizontalAlignment)GetValue(HorizontalTitleAlignmentProperty); }
            set { SetValue(HorizontalTitleAlignmentProperty, value); }
        }

        /// <summary>
        /// Identifies the <see cref="DW.WPFToolkit.Controls.TitledItem.HorizontalTitleAlignment" /> dependency property.
        /// </summary>
        public static readonly DependencyProperty HorizontalTitleAlignmentProperty =
            DependencyProperty.Register("HorizontalTitleAlignment", typeof(HorizontalAlignment), typeof(TitledItem), new UIPropertyMetadata(HorizontalAlignment.Right));

        /// <summary>
        /// Gets or sets the margin of the title.
        /// </summary>
        public Thickness TitleMargin
        {
            get { return (Thickness)GetValue(TitleMarginProperty); }
            set { SetValue(TitleMarginProperty, value); }
        }

        /// <summary>
        /// Identifies the <see cref="DW.WPFToolkit.Controls.TitledItem.TitleMargin" /> dependency property.
        /// </summary>
        public static readonly DependencyProperty TitleMarginProperty =
            DependencyProperty.Register("TitleMargin", typeof(Thickness), typeof(TitledItem), new UIPropertyMetadata(new Thickness(5, 0, 5, 0)));

        /// <summary>
        /// Gets or sets the margin of the content.
        /// </summary>
        public Thickness ContentMargin
        {
            get { return (Thickness)GetValue(ContentMarginProperty); }
            set { SetValue(ContentMarginProperty, value); }
        }

        /// <summary>
        /// Identifies the <see cref="DW.WPFToolkit.Controls.TitledItem.ContentMargin" /> dependency property.
        /// </summary>
        public static readonly DependencyProperty ContentMarginProperty =
            DependencyProperty.Register("ContentMargin", typeof(Thickness), typeof(TitledItem), new UIPropertyMetadata(new Thickness(0, 2, 0, 2)));
    }
}
