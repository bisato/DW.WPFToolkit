using System.Collections.Generic;
using System.Windows;
using System.Windows.Media;
using System.Windows.Shapes;

namespace DW.WPFToolkit.Controls
{
    /// <summary>
    /// Implements the <see cref="DW.WPFToolkit.Controls.IItemsFactory" /> and provides line items to the <see cref="DW.WPFToolkit.Controls.EllipsedProgressBar" />
    /// </summary>
    public class LineItemsFactory : IItemsFactory
    {
        public PenLineCap Caps { get; set; }

        public Brush Color { get; set; }

        public int ItemsCount { get; set; }

        public double Length { get; set; }

        public double OpacityShrinking { get; set; }

        public double Thickness { get; set; }

        public LineItemsFactory()
        {
            Caps = PenLineCap.Round;
            Color = new SolidColorBrush(Colors.Blue);
            ItemsCount = 10;
            Length = 10;
            OpacityShrinking = 0.1;
            Thickness = 4;
        }

        public IEnumerable<UIElement> GenerateItems(bool forIndeterminate)
        {
            var collection = new List<Line>();
            var opacity = 1.0;
            for (int i = 0; i < ItemsCount; i++)
            {
                collection.Add(CreateLine(forIndeterminate ? opacity : 1));
                opacity -= OpacityShrinking;
            }
            collection.Reverse();
            return collection;
        }

        public void EditItemsForValue(IEnumerable<UIElement> items, double mininum, double maximum, double value)
        {
            var lines = (List<Line>)items;

            var step = 1.0m / lines.Count;
            var percent = new decimal((value - mininum) / (maximum - mininum));

            var j = 0;
            for (var i = step; i <= percent; i += step, ++j)
                lines[j].Visibility = Visibility.Visible;
            for (; j < lines.Count; ++j)
                lines[j].Visibility = Visibility.Collapsed;
        }

        private Line CreateLine(double opacity)
        {
            return new Line
            {
                X1 = 0,
                Y1 = 0,
                X2 = 0,
                Y2 = Length,
                Opacity = opacity,
                StrokeThickness = Thickness,
                Stroke = Color,
                StrokeEndLineCap = Caps,
                StrokeStartLineCap = Caps
            };
        }
    }
}
