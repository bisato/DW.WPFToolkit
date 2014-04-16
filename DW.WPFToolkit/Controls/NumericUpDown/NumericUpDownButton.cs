using System.ComponentModel;
using System.Windows;
using System.Windows.Controls.Primitives;

namespace DW.WPFToolkit.Controls
{
    /// <summary>
    /// Represents a up or down button shown in the <see cref="DW.WPFToolkit.Controls.NumericUpDown" /> control.
    /// </summary>
    public class NumericUpDownButton : RepeatButton
    {
        static NumericUpDownButton()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(NumericUpDownButton), new FrameworkPropertyMetadata(typeof(NumericUpDownButton)));
#if TRIAL
            License1.LicenseChecker.Validate();
#endif
        }

        /// <summary>
        /// Gets or sets a value which indicates in which direction the button is pointing to.
        /// </summary>
        [DefaultValue(UpDownDirections.Up)]
        public UpDownDirections Direction
        {
            get { return (UpDownDirections)GetValue(DirectionProperty); }
            set { SetValue(DirectionProperty, value); }
        }

        /// <summary>
        /// Identifies the <see cref="DW.WPFToolkit.Controls.NumericUpDownButton.Direction" /> dependency property.
        /// </summary>
        public static readonly DependencyProperty DirectionProperty =
            DependencyProperty.Register("Direction", typeof(UpDownDirections), typeof(NumericUpDownButton), new UIPropertyMetadata(UpDownDirections.Up));
    }
}
