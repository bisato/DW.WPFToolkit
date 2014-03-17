using System.Windows;
using System.Windows.Controls.Primitives;

namespace DW.WPFToolkit.Controls
{
    public class SplitToggleButton : ToggleButton
    {
        static SplitToggleButton()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(SplitToggleButton), new FrameworkPropertyMetadata(typeof(SplitToggleButton)));
        }

        public CornerRadius OutherCornerRadius
        {
            get { return (CornerRadius)GetValue(OutherCornerRadiusProperty); }
            set { SetValue(OutherCornerRadiusProperty, value); }
        }

        public static readonly DependencyProperty OutherCornerRadiusProperty =
            DependencyProperty.Register("OutherCornerRadius", typeof(CornerRadius), typeof(SplitToggleButton), new UIPropertyMetadata(null));

        public CornerRadius InnerCornerRadius
        {
            get { return (CornerRadius)GetValue(InnerCornerRadiusProperty); }
            set { SetValue(InnerCornerRadiusProperty, value); }
        }

        public static readonly DependencyProperty InnerCornerRadiusProperty =
            DependencyProperty.Register("InnerCornerRadius", typeof(CornerRadius), typeof(SplitToggleButton), new UIPropertyMetadata(null));

        public Thickness OutherBorderThickness
        {
            get { return (Thickness)GetValue(OutherBorderThicknessProperty); }
            set { SetValue(OutherBorderThicknessProperty, value); }
        }

        public static readonly DependencyProperty OutherBorderThicknessProperty =
            DependencyProperty.Register("OutherBorderThickness", typeof(Thickness), typeof(SplitToggleButton), new UIPropertyMetadata(null));

        public Thickness InnerBorderThickness
        {
            get { return (Thickness)GetValue(InnerBorderThicknessProperty); }
            set { SetValue(InnerBorderThicknessProperty, value); }
        }

        public static readonly DependencyProperty InnerBorderThicknessProperty =
            DependencyProperty.Register("InnerBorderThickness", typeof(Thickness), typeof(SplitToggleButton), new UIPropertyMetadata(null));
    }
}
