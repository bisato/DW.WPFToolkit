using System.Windows;
using System.Windows.Controls;

namespace DW.WPFToolkit.Controls
{
    public class DynamicTabItem : TabItem
    {
        static DynamicTabItem()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(DynamicTabItem), new FrameworkPropertyMetadata(typeof(DynamicTabItem)));
        }

        public Dock CloseButtonPosition
        {
            get { return (Dock)GetValue(CloseButtonPositionProperty); }
            set { SetValue(CloseButtonPositionProperty, value); }
        }

        /// <summary>
        /// Identifies the <see cref="DW.WPFToolkit.Controls.DynamicTabItem.CloseButtonPosition" /> dependency property.
        /// </summary>
        public static readonly DependencyProperty CloseButtonPositionProperty =
            DependencyProperty.Register("CloseButtonPosition", typeof(Dock), typeof(DynamicTabItem), new UIPropertyMetadata(Dock.Right));

        public Thickness CloseButtonMargin
        {
            get { return (Thickness)GetValue(CloseButtonMarginProperty); }
            set { SetValue(CloseButtonMarginProperty, value); }
        }

        /// <summary>
        /// Identifies the <see cref="DW.WPFToolkit.Controls.DynamicTabItem.CloseButtonMargin" /> dependency property.
        /// </summary>
        public static readonly DependencyProperty CloseButtonMarginProperty =
            DependencyProperty.Register("CloseButtonMargin", typeof(Thickness), typeof(DynamicTabItem), new UIPropertyMetadata(new Thickness(5, 0, 0, 0)));

        public HorizontalAlignment HorizontalCloseButtonAlignment
        {
            get { return (HorizontalAlignment)GetValue(HorizontalCloseButtonAlignmentProperty); }
            set { SetValue(HorizontalCloseButtonAlignmentProperty, value); }
        }

        /// <summary>
        /// Identifies the <see cref="DW.WPFToolkit.Controls.DynamicTabItem.HorizontalCloseButtonAlignment" /> dependency property.
        /// </summary>
        public static readonly DependencyProperty HorizontalCloseButtonAlignmentProperty =
            DependencyProperty.Register("HorizontalCloseButtonAlignment", typeof(HorizontalAlignment), typeof(DynamicTabItem), new UIPropertyMetadata(HorizontalAlignment.Center));

        public VerticalAlignment VerticalCloseButtonAlignment
        {
            get { return (VerticalAlignment)GetValue(VerticalCloseButtonAlignmentProperty); }
            set { SetValue(VerticalCloseButtonAlignmentProperty, value); }
        }

        /// <summary>
        /// Identifies the <see cref="DW.WPFToolkit.Controls.DynamicTabItem.VerticalCloseButtonAlignment" /> dependency property.
        /// </summary>
        public static readonly DependencyProperty VerticalCloseButtonAlignmentProperty =
            DependencyProperty.Register("VerticalCloseButtonAlignment", typeof(VerticalAlignment), typeof(DynamicTabItem), new UIPropertyMetadata(VerticalAlignment.Center));

        public double CloseButtonHeight
        {
            get { return (double)GetValue(CloseButtonHeightProperty); }
            set { SetValue(CloseButtonHeightProperty, value); }
        }

        /// <summary>
        /// Identifies the <see cref="DW.WPFToolkit.Controls.DynamicTabItem.CloseButtonHeight" /> dependency property.
        /// </summary>
        public static readonly DependencyProperty CloseButtonHeightProperty =
            DependencyProperty.Register("CloseButtonHeight", typeof(double), typeof(DynamicTabItem), new UIPropertyMetadata(14.0));

        public double CloseButtonWidth
        {
            get { return (double)GetValue(CloseButtonWidthProperty); }
            set { SetValue(CloseButtonWidthProperty, value); }
        }

        /// <summary>
        /// Identifies the <see cref="DW.WPFToolkit.Controls.DynamicTabItem.CloseButtonWidth" /> dependency property.
        /// </summary>
        public static readonly DependencyProperty CloseButtonWidthProperty =
            DependencyProperty.Register("CloseButtonWidth", typeof(double), typeof(DynamicTabItem), new UIPropertyMetadata(14.0));

        public bool ShowCloseButton
        {
            get { return (bool)GetValue(ShowCloseButtonProperty); }
            set { SetValue(ShowCloseButtonProperty, value); }
        }

        /// <summary>
        /// Identifies the <see cref="DW.WPFToolkit.Controls.DynamicTabItem.ShowCloseButton" /> dependency property.
        /// </summary>
        public static readonly DependencyProperty ShowCloseButtonProperty =
            DependencyProperty.Register("ShowCloseButton", typeof(bool), typeof(DynamicTabItem), new UIPropertyMetadata(true));
    }
}
