#region License
/*
The MIT License (MIT)

Copyright (c) 2009-2014 David Wendland

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in
all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
THE SOFTWARE
*/
#endregion License

using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace DW.WPFToolkit.Controls
{
    public class NavigationBarPanel : Panel
    {
        public static bool GetIsExpanded(DependencyObject obj)
        {
            return (bool)obj.GetValue(IsExpandedProperty);
        }

        public static void SetIsExpanded(DependencyObject obj, bool value)
        {
            obj.SetValue(IsExpandedProperty, value);
        }

        public static readonly DependencyProperty IsExpandedProperty =
            DependencyProperty.RegisterAttached("IsExpanded", typeof(bool), typeof(NavigationBarPanel), new PropertyMetadata(false));

        public Orientation Orientation
        {
            get { return (Orientation)GetValue(OrientationProperty); }
            set { SetValue(OrientationProperty, value); }
        }

        public static readonly DependencyProperty OrientationProperty =
            DependencyProperty.Register("Orientation", typeof(Orientation), typeof(NavigationBarPanel), new PropertyMetadata(Orientation.Vertical));

        protected override Size MeasureOverride(Size constraint)
        {
            var maximumWidth = 0.0;
            var maximumHeight = 0.0;
            var childWidths = 0.0;
            var childHeights = 0.0;

            var skippedObjects = new List<UIElement>();

            foreach (UIElement element in InternalChildren)
            {
                if (element == null)
                    continue;

                var availableSize = new Size(Math.Max(0.0, constraint.Width - childWidths),
                                             Math.Max(0.0, constraint.Height - childHeights));
                element.Measure(availableSize);

                if (GetIsExpanded(element))
                {
                    skippedObjects.Add(element);
                    continue;
                }

                var desiredSize = element.DesiredSize;
                switch (Orientation)
                {
                    case Orientation.Horizontal:
                        maximumHeight = Math.Max(maximumHeight, childHeights + desiredSize.Height);
                        childWidths += desiredSize.Width;
                        break;

                    case Orientation.Vertical:
                        maximumWidth = Math.Max(maximumWidth, childWidths + desiredSize.Width);
                        childHeights += desiredSize.Height;
                        break;
                }
            }

            var sizeLeft = new Size(Math.Max(0.0, constraint.Width - childWidths),
                                    Math.Max(0.0, constraint.Height - childHeights));
            switch (Orientation)
            {
                case Orientation.Horizontal:
                    sizeLeft.Width /= Math.Max(skippedObjects.Count, 1.0);
                    break;
                case Orientation.Vertical:
                    sizeLeft.Height /= Math.Max(skippedObjects.Count, 1.0);
                    break;
            }

            foreach (var element in skippedObjects)
            {
                element.Measure(sizeLeft);
                if (Orientation == Orientation.Horizontal)
                    childWidths += element.DesiredSize.Width;
                else
                    childHeights += element.DesiredSize.Height;
            }

            return new Size(childWidths, childHeights);
        }

        protected override Size ArrangeOverride(Size arrangeSize)
        {
            var sizes = new Size[InternalChildren.Count];
            for (var i = 0; i < InternalChildren.Count; ++i)
            {
                var element = InternalChildren[i];
                if (element == null)
                    continue;

                sizes[i] = element.DesiredSize;
                var isSharing = GetIsExpanded(element);
                switch (Orientation)
                {
                    case Orientation.Horizontal:
                        if (isSharing)
                            sizes[i].Width = 0;
                        sizes[i].Height = arrangeSize.Height;
                        break;
                    case Orientation.Vertical:
                        if (isSharing)
                            sizes[i].Height = 0;
                        sizes[i].Width = arrangeSize.Width;
                        break;
                }
            }

            var heightLeft = arrangeSize.Height;
            var widthLeft = arrangeSize.Width;
            for (var i = 0; i < InternalChildren.Count; ++i)
            {
                var element = InternalChildren[i];
                if (element == null)
                    continue;

                var isSharing = GetIsExpanded(element);
                if (!isSharing && Orientation == Orientation.Horizontal)
                    widthLeft -= sizes[i].Width;
                else if (!isSharing && Orientation == Orientation.Vertical)
                    heightLeft -= sizes[i].Height;
            }

            double heightItemsCout = sizes.Count(i => i.Height == 0);
            double widthItemsCout = sizes.Count(i => i.Width == 0);

            var missingItemHeight = heightLeft / Math.Max(heightItemsCout, 1);
            var missingItemWidth = widthLeft / Math.Max(widthItemsCout, 1);

            for (var i = 0; i < InternalChildren.Count; ++i)
            {
                var element = InternalChildren[i];
                if (element == null)
                    continue;

                if (sizes[i].Height == 0)
                    sizes[i].Height = missingItemHeight;
                if (sizes[i].Width == 0)
                    sizes[i].Width = missingItemWidth;
            }

            var x = 0.0;
            var y = 0.0;
            for (var i = 0; i < InternalChildren.Count; ++i)
            {
                var element = InternalChildren[i];
                if (element == null)
                    continue;

                var size = sizes[i];
                var position = new Rect(x, y, size.Width, size.Height);
                element.Arrange(position);

                if (Orientation == Orientation.Horizontal)
                    x += size.Width;
                else
                    y += size.Height;
            }

            return arrangeSize;
        }
    }
}