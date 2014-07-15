using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace map_gen
{
    class HexCell : Cell
    {
        // For a regular hexagon, height = this factor times size
        private double sqrt3DividedBy2 = Math.Pow(3, .5) / 2;
        //private double sqrt3DividedBy4 = 0.866;
        private PointCollection _points;

        public override PointCollection Points
        {
            get
            {
                return _points;
            }
        }

        public HexCell(int x, int y, int size) : base(x, y, size)
        {
            //Regular hexagon, so once we know the size we can create the points
            _points = new PointCollection();

            _points.Add(new Point(Size, 0));    // Right
            _points.Add(new Point(Size/2, sqrt3DividedBy2*Size));    // Bottom-right
            _points.Add(new Point(-Size/2, sqrt3DividedBy2*Size));    // Bottom-left
            _points.Add(new Point(-Size, 0));    // Left
            _points.Add(new Point(-Size/2, -sqrt3DividedBy2*Size));    // Top-left
            _points.Add(new Point(Size/2, -sqrt3DividedBy2*Size));    // Top-right
        }
    }
}
