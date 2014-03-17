using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using DW.WPFToolkit.Internal;

namespace DW.WPFToolkit.Controls
{
    public class ArcPanel : Panel
    {
        private readonly PathFigure _figure = new PathFigure();

        public bool RotateElements
        {
            get { return (bool)GetValue(RotateElementsProperty); }
            set { SetValue(RotateElementsProperty, value); }
        }

        public static readonly DependencyProperty RotateElementsProperty =
            DependencyProperty.Register("RotateElements", typeof(bool), typeof(ArcPanel), new FrameworkPropertyMetadata(true, FrameworkPropertyMetadataOptions.AffectsArrange));

        public double Bend
        {
            get { return (double)GetValue(BendProperty); }
            set { SetValue(BendProperty, value); }
        }

        public static readonly DependencyProperty BendProperty =
            DependencyProperty.Register("Bend", typeof(double), typeof(ArcPanel), new FrameworkPropertyMetadata(1.0, FrameworkPropertyMetadataOptions.AffectsArrange));

        public ArcPanel()
        {
            _figure.StartPoint = new Point(0, 10);
            _figure.Segments.Add(new ArcSegment(new Point(200, 10), new Size(300, 150), 0, false, SweepDirection.Clockwise, false));
        }

        protected override Size MeasureOverride(Size availableSize)
        {
            foreach (UIElement child in InternalChildren)
                child.Measure(new Size(double.PositiveInfinity, double.PositiveInfinity));
            return base.MeasureOverride(availableSize);
        }

        protected override Size ArrangeOverride(Size finalSize)
        {
            if (InternalChildren.Count > 0 &&
                finalSize.Width > 0)
            {
                ResetArc(finalSize);

                var pathLength = PathCalculator.GetPathFigureLength(_figure);
                var pathGeometry = new PathGeometry(new PathFigure[] { _figure });
                var distance = (double)1 / (double)(InternalChildren.Count + 1);
                var position = distance;
                foreach (UIElement child in InternalChildren)
                {
                    Point point, tangent;
                    pathGeometry.GetPointAtFractionLength(position, out point, out tangent);

                    Size childSize = child.DesiredSize;
                    point.X -= childSize.Width / 2;
                    point.Y -= childSize.Height;
                    child.Arrange(new Rect(point, childSize));

                    if (RotateElements)
                    {
                        var elementCenter = new Size(childSize.Width / 2, childSize.Height / 2);
                        var transforms = new TransformGroup();
                        transforms.Children.Add(new RotateTransform((Math.Atan2(tangent.Y, tangent.X)
                                                                        * 180
                                                                        / Math.PI),
                                                                    elementCenter.Width,
                                                                    elementCenter.Height));
                        child.RenderTransform = transforms;
                    }
                    else
                        child.RenderTransform = null;
                    
                    position += distance;
                }
            }
            return base.ArrangeOverride(finalSize);
        }

        private void ResetArc(Size finalSize)
        {
            var segment = (ArcSegment)_figure.Segments[0];
            _figure.StartPoint = new Point(0, finalSize.Height);
            segment.Point = new Point(finalSize.Width, finalSize.Height);
            segment.Size = new Size(finalSize.Width, finalSize.Height * Bend);
        }
    }
}
