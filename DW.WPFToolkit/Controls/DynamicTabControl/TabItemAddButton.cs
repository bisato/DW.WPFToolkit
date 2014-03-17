using System.Windows;
using System.Windows.Controls;

namespace DW.WPFToolkit.Controls
{
    public class TabItemAddButton : Button
    {
        static TabItemAddButton()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(TabItemAddButton), new FrameworkPropertyMetadata(typeof(TabItemAddButton)));
        }

        public double StrokeThickness
        {
            get { return (double)GetValue(StrokeThicknessProperty); }
            set { SetValue(StrokeThicknessProperty, value); }
        }

        public static readonly DependencyProperty StrokeThicknessProperty =
            DependencyProperty.Register("StrokeThickness", typeof(double), typeof(TabItemAddButton), new UIPropertyMetadata(1.5));
    }
}
