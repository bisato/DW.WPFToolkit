using System.ComponentModel;
using System.Windows;
using System.Windows.Controls.Primitives;

namespace DW.WPFToolkit.Controls
{
    /// <summary>
    /// Represents a up or down button shown in the <see cref="DW.WPFToolkit.Controls.NumberBox" /> control.
    /// </summary>
    public class UpDownButton : RepeatButton
    {
        static UpDownButton()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(UpDownButton), new FrameworkPropertyMetadata(typeof(UpDownButton)));
#if TRIAL
            License1.License.Display();
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
        /// Identifies the <see cref="UpDownButton.Direction" /> dependency property.
        /// </summary>
        public static readonly DependencyProperty DirectionProperty =
            DependencyProperty.Register("Direction", typeof(UpDownDirections), typeof(UpDownButton), new UIPropertyMetadata(UpDownDirections.Up));
    }
}
