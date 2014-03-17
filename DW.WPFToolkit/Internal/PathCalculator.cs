using System.Linq;
using System.Windows.Media;

namespace DW.WPFToolkit.Internal
{
    public static class PathCalculator
    {
        public static double GetPathFigureLength(PathFigure pathFigure)
        {
            if (pathFigure == null)
                return 0;

            var isAlreadyFlattened = pathFigure.Segments.All(pathSegment => (pathSegment is PolyLineSegment) || (pathSegment is LineSegment));

            var pathFigureFlattened = isAlreadyFlattened ? pathFigure : pathFigure.GetFlattenedPathFigure();
            double length = 0;
            var pt1 = pathFigureFlattened.StartPoint;

            foreach (var pathSegment in pathFigureFlattened.Segments)
            {
                if (pathSegment is LineSegment)
                {
                    var pt2 = ((LineSegment)pathSegment).Point;
                    length += (pt2 - pt1).Length;
                    pt1 = pt2;
                }
                else if (pathSegment is PolyLineSegment)
                {
                    var pointCollection = ((PolyLineSegment)pathSegment).Points;
                    foreach (var pt2 in pointCollection)
                    {
                        length += (pt2 - pt1).Length;
                        pt1 = pt2;
                    }
                }
            }
            return length;
        }
    }
}
