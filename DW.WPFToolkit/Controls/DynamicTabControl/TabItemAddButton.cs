using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;

namespace DW.WPFToolkit.Controls
{
    /// <summary>
    /// Represents the add new tab Button shown in the <see cref="DW.WPFToolkit.Controls.DynamicTabControl" />.
    /// </summary>
    public class TabItemAddButton : Button
    {
        static TabItemAddButton()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(TabItemAddButton), new FrameworkPropertyMetadata(typeof(TabItemAddButton)));
#if TRIAL
            License1.LicenseChecker.Validate();
#endif
        }

        /// <summary>
        /// Gets or sets the stroke thickness of the plus icon shown in the template.
        /// </summary>
        [DefaultValue(1.5)]
        public double StrokeThickness
        {
            get { return (double)GetValue(StrokeThicknessProperty); }
            set { SetValue(StrokeThicknessProperty, value); }
        }

        /// <summary>
        /// Identifies the <see cref="DW.WPFToolkit.Controls.TabItemAddButton.StrokeThickness" /> dependency property.
        /// </summary>
        public static readonly DependencyProperty StrokeThicknessProperty =
            DependencyProperty.Register("StrokeThickness", typeof(double), typeof(TabItemAddButton), new UIPropertyMetadata(1.5));
    }
}
