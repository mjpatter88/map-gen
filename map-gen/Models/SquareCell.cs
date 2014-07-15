using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace map_gen
{
    class SquareCell : Cell
    {
        public override PointCollection Points
        {
            get
            {
                throw new NotImplementedException();
            }
        }
        public override double PixLocX
        {
            get { throw new NotImplementedException(); }
        }
        public override double PixLocY
        {
            get { throw new NotImplementedException(); }
        }
        public override double NegPixLocX
        {
            get { throw new NotImplementedException(); }
        }
        public override double NegPixLocY
        {
            get { throw new NotImplementedException(); }
        }
    }
}
