using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using DW.WPFToolkit.Internal;

namespace DW.WPFToolkit.Controls
{
    public class EllipsePanel : Panel
    {
        private readonly EllipseGeometry _ellipse = new EllipseGeometry();

        public bool RotateElements
        {
            get { return (bool)GetValue(RotateElementsProperty); }
            set { SetValue(RotateElementsProperty, value); }
        }

        public static readonly DependencyProperty RotateElementsProperty =
            DependencyProperty.Register("RotateElements", typeof(bool), typeof(EllipsePanel), new PropertyMetadata(false, ValueChanged));

        public ElementsRotateDirection ElementsRotateDirection
        {
            get { return (ElementsRotateDirection)GetValue(ElementsRotateDirectionProperty); }
            set { SetValue(ElementsRotateDirectionProperty, value); }
        }

        public static readonly DependencyProperty ElementsRotateDirectionProperty =
            DependencyProperty.Register("ElementsRotateDirection", typeof(ElementsRotateDirection), typeof(EllipsePanel), new PropertyMetadata(ValueChanged));

        public SweepDirection EllipseRotateDirection
        {
            get { return (SweepDirection)GetValue(EllipseRotateDirectionProperty); }
            set { SetValue(EllipseRotateDirectionProperty, value); }
        }

        public static readonly DependencyProperty EllipseRotateDirectionProperty =
            DependencyProperty.Register("EllipseRotateDirection", typeof(SweepDirection), typeof(EllipsePanel), new PropertyMetadata(ValueChanged));

        public ElementStartPosition ElementStartPosition
        {
            get { return (ElementStartPosition)GetValue(ElementStartPositionProperty); }
            set { SetValue(ElementStartPositionProperty, value); }
        }

        public static readonly DependencyProperty ElementStartPositionProperty =
            DependencyProperty.Register("ElementStartPosition", typeof(ElementStartPosition), typeof(EllipsePanel), new PropertyMetadata(ValueChanged));

        private static void ValueChanged(DependencyObject obj, DependencyPropertyChangedEventArgs args)
        {
            var control = (EllipsePanel)obj;
            control.InvalidateArrange();
        }

        protected override Size MeasureOverride(Size availableSize)
        {
            foreach (UIElement child in InternalChildren)
                child.Measure(new Size(double.PositiveInfinity, double.PositiveInfinity));
            return base.MeasureOverride(availableSize);
        }

        protected override Size ArrangeOverride(Size finalSize)
        {
            if (finalSize.Height <= 0 ||
                finalSize.Width <= 0)
                return finalSize;

            if (InternalChildren.Count > 0)
            {
                ResetEllipse(finalSize);

                var figure = _ellipse.GetOutlinedPathGeometry().Figures[0];
                var pathLength = PathCalculator.GetPathFigureLength(figure);
                var pathGeometry = new PathGeometry(new PathFigure[] { figure });

                var points = new List<Point>();
                var tangents = new List<Point>();
                var distance = (double)1 / (double)InternalChildren.Count;
                var position = GetElementStartPositionValue();
                foreach (var child in InternalChildren)
                {
                    Point point, tangent;
                    pathGeometry.GetPointAtFractionLength(position, out point, out tangent);
                    points.Add(point);
                    tangents.Add(tangent);
                    position += distance;
                    if (position > 1)
                        position -= 1;
                }

                if (EllipseRotateDirection == SweepDirection.Counterclockwise)
                {
                    points.Reverse();
                    tangents.Reverse();
                    var point = points.Last();
                    points.Remove(point);
                    points.Insert(0, point);

                    var tangent = tangents.Last();
                    tangents.Remove(tangent);
                    tangents.Insert(0, tangent);
                }

                int pos = 0;
                foreach (UIElement child in InternalChildren)
                {
                    var childSize = child.DesiredSize;
                    var elementPos = points[pos];
                    elementPos.X -= childSize.Width / 2;
                    elementPos.Y -= childSize.Height / 2;
                    child.SnapsToDevicePixels = true;
                    child.Arrange(new Rect(elementPos, childSize));
                    if (RotateElements)
                    {
                        var elementCenter = new Size(childSize.Width / 2, childSize.Height / 2);
                        var transforms = new TransformGroup();

                        var centerPoint = new Point(finalSize.Width / 2, finalSize.Height / 2);
                        var angle = CalculatePileToPlayerAngle(elementPos, centerPoint);
                        transforms.Children.Add(new RotateTransform(angle, elementCenter.Width, elementCenter.Height));

                        //transforms.Children.Add(new RotateTransform((Math.Atan2(tangents[pos].Y, tangents[pos].X)
                        //                                                * 180
                        //                                                / Math.PI)
                        //                                                + GetElementsRotateDirectionValue(),
                        //                                            elementCenter.Width,
                        //                                            elementCenter.Height));
                        child.RenderTransform = transforms;
                    }
                    else
                        child.RenderTransform = null;
                    ++pos;
                }
            }
            return base.ArrangeOverride(finalSize);
        }

        private double CalculatePileToPlayerAngle(Point start, Point end)
        {
            var angle = 0.0;

            end.X = end.X - start.X;
            end.Y = end.Y - start.Y;
            angle = Math.Atan2(end.Y, end.X) / (Math.PI / 180);

            angle += 90;
            if (angle < 0)
                angle += 360;
            if (angle >= 360)
                angle %= 360;
            return angle;
        }

        private double GetElementStartPositionValue()
        {
            switch (ElementStartPosition)
            {
                case ElementStartPosition.Left:
                    return 0.75;
                case ElementStartPosition.Top:
                    return 0;
                case ElementStartPosition.Right:
                    return 0.25;
                case ElementStartPosition.Bottom:
                    return 0.5;
            }
            return 0;
        }

        private double GetElementsRotateDirectionValue()
        {
            switch (ElementsRotateDirection)
            {
                case ElementsRotateDirection.Introversive:
                    return 0;
                case ElementsRotateDirection.Outroversive:
                    return 180;
                case ElementsRotateDirection.Clockwise:
                    return 90;
                case ElementsRotateDirection.Counterclockwise:
                    return -90;
            }
            return 0;
        }

        private void ResetEllipse(Size finalSize)
        {
            _ellipse.RadiusX = finalSize.Width / 2;
            _ellipse.RadiusY = finalSize.Height / 2;
            _ellipse.Center = new Point(finalSize.Width / 2, finalSize.Height / 2);
        }
    }
}
