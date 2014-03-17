using System.Windows;
using System.Windows.Controls.Primitives;

namespace DW.WPFToolkit.Controls
{
    public class FrameResizer : Thumb
    {
        static FrameResizer()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(FrameResizer), new FrameworkPropertyMetadata(typeof(FrameResizer)));
        }

        public FrameResizerDirections Direction
        {
            get { return (FrameResizerDirections)GetValue(DirectionProperty); }
            set { SetValue(DirectionProperty, value); }
        }

        public static readonly DependencyProperty DirectionProperty =
            DependencyProperty.Register("Direction", typeof(FrameResizerDirections), typeof(FrameResizer), new UIPropertyMetadata(FrameResizerDirections.LeftRight));

        public FrameResizerPositions Position
        {
            get { return (FrameResizerPositions)GetValue(PositionProperty); }
            set { SetValue(PositionProperty, value); }
        }

        public static readonly DependencyProperty PositionProperty =
            DependencyProperty.Register("Position", typeof(FrameResizerPositions), typeof(FrameResizer), new UIPropertyMetadata(FrameResizerPositions.Right));
    }
}
