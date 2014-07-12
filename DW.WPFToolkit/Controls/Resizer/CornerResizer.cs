using System.ComponentModel;
using System.Windows;
using System.Windows.Controls.Primitives;

namespace DW.WPFToolkit.Controls
{
    /// <summary>
    /// Represents a element in the corners of the <see cref="DW.WPFToolkit.Controls.Resizer" /> to hold and drag in a specific direction.
    /// </summary>
    public class CornerResizer : Thumb
    {
        static CornerResizer()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(CornerResizer), new FrameworkPropertyMetadata(typeof(CornerResizer)));
        }

        /// <summary>
        /// Gets or sets the direction where the corner resizer can be moved.
        /// </summary>
        [DefaultValue(CornerResizerDirections.NEtoSW)]
        public CornerResizerDirections Direction
        {
            get { return (CornerResizerDirections)GetValue(DirectionProperty); }
            set { SetValue(DirectionProperty, value); }
        }

        /// <summary>
        /// Identifies the <see cref="DW.WPFToolkit.Controls.CornerResizer.Direction" /> dependency property.
        /// </summary>
        public static readonly DependencyProperty DirectionProperty =
            DependencyProperty.Register("Direction", typeof(CornerResizerDirections), typeof(CornerResizer), new UIPropertyMetadata(CornerResizerDirections.NEtoSW));

        /// <summary>
        /// Gets or sets the position of the corner resizer inside the <see cref="DW.WPFToolkit.Controls.Resizer" /> control.
        /// </summary>
        [DefaultValue(CornerResizerPositions.NW)]
        public CornerResizerPositions Position
        {
            get { return (CornerResizerPositions)GetValue(PositionProperty); }
            set { SetValue(PositionProperty, value); }
        }

        /// <summary>
        /// Identifies the <see cref="DW.WPFToolkit.Controls.CornerResizer.Position" /> dependency property.
        /// </summary>
        public static readonly DependencyProperty PositionProperty =
            DependencyProperty.Register("Position", typeof(CornerResizerPositions), typeof(CornerResizer), new UIPropertyMetadata(CornerResizerPositions.NW));
    }
}
