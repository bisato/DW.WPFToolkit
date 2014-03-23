using System.Windows;
using System.Windows.Controls.Primitives;

namespace DW.WPFToolkit.Controls
{
    public class NumericUpDownButton : RepeatButton
    {
        static NumericUpDownButton()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(NumericUpDownButton), new FrameworkPropertyMetadata(typeof(NumericUpDownButton)));
        }

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
