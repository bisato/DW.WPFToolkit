using System;
using System.Windows;
using System.Windows.Controls;

namespace DW.WPFToolkit.Controls
{
    public class UniformWrapPanel : WrapPanel
    {
        public bool IsAutoUniform
        {
            get { return (bool)GetValue(IsAutoUniformProperty); }
            set { SetValue(IsAutoUniformProperty, value); }
        }

        public static readonly DependencyProperty IsAutoUniformProperty =
            DependencyProperty.Register("IsAutoUniform", typeof(bool), typeof(UniformWrapPanel), new UIPropertyMetadata(true, IsAutoUniformChanged));

        private static void IsAutoUniformChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            if (sender is UniformWrapPanel)
                ((UniformWrapPanel)sender).InvalidateVisual();
        }

        public double MinItemWidth
        {
            get { return (double)GetValue(MinItemWidthProperty); }
            set { SetValue(MinItemWidthProperty, value); }
        }

        public static readonly DependencyProperty MinItemWidthProperty =
            DependencyProperty.Register("MinItemWidth", typeof(double), typeof(UniformWrapPanel), new UIPropertyMetadata(0.0));

        public double MinItenHeight
        {
            get { return (double)GetValue(MinItenHeightProperty); }
            set { SetValue(MinItenHeightProperty, value); }
        }

        public static readonly DependencyProperty MinItenHeightProperty =
            DependencyProperty.Register("MinItenHeight", typeof(double), typeof(UniformWrapPanel), new UIPropertyMetadata(0.0));

        protected override Size MeasureOverride(Size availableSize)
        {
            if (Children.Count > 0 &&
                IsAutoUniform)
            {
                foreach (UIElement el in Children)
                {
                    el.Measure(availableSize);
                    if (Orientation == Orientation.Vertical)
                        ItemHeight = MeasureItem(ItemHeight, el.DesiredSize.Height, MinItenHeight);
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
