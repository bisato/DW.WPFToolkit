using System.Windows;
using System.Windows.Controls.Primitives;

namespace DW.WPFToolkit.Controls
{
    public class CornerResizer : Thumb
    {
        static CornerResizer()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(CornerResizer), new FrameworkPropertyMetadata(typeof(CornerResizer)));
        }

        public CornerResizerDirections Direction
        {
            get { return (CornerResizerDirections)GetValue(DirectionProperty); }
            set { SetValue(DirectionProperty, value); }
        }

        public static readonly DependencyProperty DirectionProperty =
            DependencyProperty.Register("Direction", typeof(CornerResizerDirections), typeof(CornerResizer), new UIPropertyMetadata(CornerResizerDirections.NEtoSW));

        public CornerResizerPositions Position
        {
            get { return (CornerResizerPositions)GetValue(PositionProperty); }
            set { SetValue(PositionProperty, value); }
        }

        public static readonly DependencyProperty PositionProperty =
            DependencyProperty.Register("Position", typeof(CornerResizerPositions), typeof(CornerResizer), new UIPropertyMetadata(CornerResizerPositions.NW));
    }
}
