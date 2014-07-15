using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace map_gen
{
    class CartesianCanvas : Canvas
    {
        public CartesianCanvas()
        {
            LayoutTransform = new ScaleTransform() { ScaleX = 1, ScaleY = 1 };
        }

        protected override System.Windows.Size ArrangeOverride(Size arrangeSize)
        {
            Point middle = new Point(arrangeSize.Width / 2, arrangeSize.Height / 2);

            foreach (UIElement element in base.InternalChildren)
            {
                if (element == null)
                {
                    continue;
                }
                double x = 0.0;
                double y = 0.0;
                double left = GetLeft(element);
                if (!double.IsNaN(left))
                {
                    x = left;
                }

                double top = GetTop(element);
                if (!double.IsNaN(top))
                {
                    y = top;
                }

                // This is really the only change as we position things relative to the middle, 
                // not relative to the top left as done in the standard canvas control.
                element.Arrange(new Rect(new Point(middle.X + x, middle.Y + y), element.DesiredSize));
            }
            return arrangeSize;
        }
    }
}
