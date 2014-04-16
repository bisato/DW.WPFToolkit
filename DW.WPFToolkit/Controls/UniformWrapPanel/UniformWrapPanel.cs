using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;

namespace DW.WPFToolkit.Controls
{
    /// <summary>
    /// Enhances the <see cref="System.Windows.Controls.WrapPanel" /> by the feature that all items will have the same size.
    /// </summary>
    public class UniformWrapPanel : WrapPanel
    {
#if TRIAL
        static UniformWrapPanel()
        {
            License1.License.Display();
        }
#endif

        /// <summary>
        /// Gets or sets a value that defines if the common height or width will be taken by the biggest child element.
        /// </summary>
        [DefaultValue(true)]
        public bool IsAutoUniform
        {
            get { return (bool)GetValue(IsAutoUniformProperty); }
            set { SetValue(IsAutoUniformProperty, value); }
        }

        /// <summary>
        /// Identifies the <see cref="DW.WPFToolkit.Controls.UniformWrapPanel.IsAutoUniform" /> dependency property.
        /// </summary>
        public static readonly DependencyProperty IsAutoUniformProperty =
            DependencyProperty.Register("IsAutoUniform", typeof(bool), typeof(UniformWrapPanel), new UIPropertyMetadata(true, IsAutoUniformChanged));

        private static void IsAutoUniformChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            var panel = sender as UniformWrapPanel;
            if (panel != null)
                panel.InvalidateVisual();
        }

        /// <summary>
        /// Gets or sets the minimum width of the items.
        /// </summary>
        [DefaultValue(0.0)]
        public double MinItemWidth
        {
            get { return (double)GetValue(MinItemWidthProperty); }
            set { SetValue(MinItemWidthProperty, value); }
        }

        /// <summary>
        /// Identifies the <see cref="DW.WPFToolkit.Controls.UniformWrapPanel.MinItemWidth" /> dependency property.
        /// </summary>
        public static readonly DependencyProperty MinItemWidthProperty =
            DependencyProperty.Register("MinItemWidth", typeof(double), typeof(UniformWrapPanel), new UIPropertyMetadata(0.0));

        /// <summary>
        /// Gets or sets the minimum height of the items.
        /// </summary>
        [DefaultValue(0.0)]
        public double MinItemHeight
        {
            get { return (double)GetValue(MinItemHeightProperty); }
            set { SetValue(MinItemHeightProperty, value); }
        }

        /// <summary>
        /// Identifies the <see cref="DW.WPFToolkit.Controls.UniformWrapPanel.MinItemHeight" /> dependency property.
        /// </summary>
        public static readonly DependencyProperty MinItemHeightProperty =
            DependencyProperty.Register("MinItemHeight", typeof(double), typeof(UniformWrapPanel), new UIPropertyMetadata(0.0));

        /// <summary>
        /// Lets each child calculating is needed size.
        /// </summary>
        /// <param name="availableSize">The available space by the parent control.</param>
        /// <returns>The calculated size needed for the control.</returns>
        protected override Size MeasureOverride(Size availableSize)
        {
            if (Children.Count > 0 &&
                IsAutoUniform)
            {
                foreach (UIElement el in Children)
                {
                    el.Measure(availableSize);
                    if (Orientation == Orientation.Vertical)
                        ItemHeight = MeasureItem(ItemHeight, el.DesiredSize.Height, MinItemHeight);
                    else
                        ItemWidth = MeasureItem(ItemWidth, el.DesiredSize.Width, MinItemWidth);
                }
            }
            return base.MeasureOverride(availableSize);
        }

        private double MeasureItem(double finalItemSize, double currentItemSize, double minimumSize)
        {
            if (double.IsNaN(finalItemSize))
                finalItemSize = 0;
            if (!(double.IsInfinity(currentItemSize) ||
                  double.IsNaN(currentItemSize)))
            {
                finalItemSize = Math.Max(finalItemSize, currentItemSize);
                if (finalItemSize < minimumSize)
                    finalItemSize = minimumSize;
            }
            return finalItemSize;
        }
    }
}
