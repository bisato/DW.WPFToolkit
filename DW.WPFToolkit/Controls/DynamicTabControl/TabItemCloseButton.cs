using System.Windows;
using System.Windows.Controls;

namespace DW.WPFToolkit.Controls
{
    /// <summary>
    /// Represents the close Button shown in the <see cref="DW.WPFToolkit.Controls.DynamicTabControl" />.
    /// </summary>
    public class TabItemCloseButton : Button
    {
        static TabItemCloseButton()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(TabItemCloseButton), new FrameworkPropertyMetadata(typeof(TabItemCloseButton)));
        }

        public double StrokeThickness
        {
            get { return (double)GetValue(StrokeThicknessProperty); }
            set { SetValue(StrokeThicknessProperty, value); }
        }

        /// <summary>
        /// Identifies the <see cref="DW.WPFToolkit.Controls.TabItemCloseButton.StrokeThickness" /> dependency property.
        /// </summary>
        public static readonly DependencyProperty StrokeThicknessProperty =
            DependencyProperty.Register("StrokeThickness", typeof(double), typeof(TabItemCloseButton), new UIPropertyMetadata(1.5));
    }
}
