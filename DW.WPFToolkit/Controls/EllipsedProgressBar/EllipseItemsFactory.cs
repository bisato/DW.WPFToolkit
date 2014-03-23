using System.Collections.Generic;
using System.Windows;
using System.Windows.Media;
using System.Windows.Shapes;

namespace DW.WPFToolkit.Controls
{
    /// <summary>
    /// Implements the <see cref="DW.WPFToolkit.Controls.IItemsFactory" /> and provides ellipse items to the <see cref="DW.WPFToolkit.Controls.EllipsedProgressBar" />
    /// </summary>
    public class EllipseItemsFactory : IItemsFactory
    {
        public Brush Color { get; set; }

        public int ItemsCount { get; set; }

        public double OpacityShrinking { get; set; }

        public double Size { get; set; }

        public EllipseItemsFactory()
        {
            Color = new SolidColorBrush(Colors.Red);
            ItemsCount = 10;
            OpacityShrinking = 0.1;
            Size = 8;
        }

        public IEnumerable<UIElement> GenerateItems(bool forIndeterminate)
        {
            var collection = new List<Ellipse>();
            var opacity = 1.0;
            for (int i = 0; i < ItemsCount; i++)
            {
                collection.Add(CreateEllipse(forIndeterminate ? opacity : 1));
                opacity -= OpacityShrinking;
            }
            collection.Reverse();
            return collection;
        }

        public void EditItemsForValue(IEnumerable<UIElement> items, double mininum, double maximum, double value)
        {
            var ellipses = (List<Ellipse>)items;

            var step = 1.0m / ellipses.Count;
            var percent = new decimal((value - mininum) / (maximum - mininum));

            var j = 0;
            for (var i = step; i <= percent; i += step, ++j)
                ellipses[j].Visibility = Visibility.Visible;
            for (; j < ellipses.Count; ++j)
                ellipses[j].Visibility = Visibility.Collapsed;
        }

        private Ellipse CreateEllipse(double opacity)
        {
            return new Ellipse { Height = Size, Width = Size, Fill = Color, Opacity = opacity };
        }
    }
}
