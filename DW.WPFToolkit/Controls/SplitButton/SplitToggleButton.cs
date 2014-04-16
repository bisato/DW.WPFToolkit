using System.ComponentModel;
using System.Windows;
using System.Windows.Controls.Primitives;

namespace DW.WPFToolkit.Controls
{
    /// <summary>
    /// Represents the button on the side of the <see cref="DW.WPFToolkit.Controls.SplitButton" /> to expand or collapse the child items.
    /// </summary>
    public class SplitToggleButton : ToggleButton
    {
        static SplitToggleButton()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(SplitToggleButton), new FrameworkPropertyMetadata(typeof(SplitToggleButton)));
#if TRIAL
            License1.LicenseChecker.Validate();
#endif
        }

        /// <summary>
        /// Gets or sets the outher radius of the button in the template.
        /// </summary>
        public CornerRadius OutherCornerRadius
        {
            get { return (CornerRadius)GetValue(OutherCornerRadiusProperty); }
            set { SetValue(OutherCornerRadiusProperty, value); }
        }

        /// <summary>
        /// Identifies the <see cref="DW.WPFToolkit.Controls.SplitToggleButton.OutherCornerRadius" /> dependency property.
        /// </summary>
        public static readonly DependencyProperty OutherCornerRadiusProperty =
            DependencyProperty.Register("OutherCornerRadius", typeof(CornerRadius), typeof(SplitToggleButton));

        /// <summary>
        /// Gets or sets the inner radius of the buttion in the template.
        /// </summary>
        public CornerRadius InnerCornerRadius
        {
            get { return (CornerRadius)GetValue(InnerCornerRadiusProperty); }
            set { SetValue(InnerCornerRadiusProperty, value); }
        }

        /// <summary>
        /// Identifies the <see cref="DW.WPFToolkit.Controls.SplitToggleButton.InnerCornerRadius" /> dependency property.
        /// </summary>
        public static readonly DependencyProperty InnerCornerRadiusProperty =
            DependencyProperty.Register("InnerCornerRadius", typeof(CornerRadius), typeof(SplitToggleButton));

        /// <summary>
        /// Gets or sets the thickness of the other border in the template.
        /// </summary>
        public Thickness OutherBorderThickness
        {
            get { return (Thickness)GetValue(OutherBorderThicknessProperty); }
            set { SetValue(OutherBorderThicknessProperty, value); }
        }

        /// <summary>
        /// Identifies the <see cref="DW.WPFToolkit.Controls.SplitToggleButton.OutherBorderThickness" /> dependency property.
        /// </summary>
        public static readonly DependencyProperty OutherBorderThicknessProperty =
            DependencyProperty.Register("OutherBorderThickness", typeof(Thickness), typeof(SplitToggleButton));

        /// <summary>
        /// Gets or sets the thickness of the inner border in the template.
        /// </summary>
        public Thickness InnerBorderThickness
        {
            get { return (Thickness)GetValue(InnerBorderThicknessProperty); }
            set { SetValue(InnerBorderThicknessProperty, value); }
        }

        /// <summary>
        /// Identifies the <see cref="DW.WPFToolkit.Controls.SplitToggleButton.InnerBorderThickness" /> dependency property.
        /// </summary>
        public static readonly DependencyProperty InnerBorderThicknessProperty =
            DependencyProperty.Register("InnerBorderThickness", typeof(Thickness), typeof(SplitToggleButton));
    }
}
