using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Dream
{
    public class Triangle
    {
        public PointF[] Points { get; set; }
        public Rectangle Location { get; set; }

        public Triangle(Point location)
        {
            var delta = 15;
            Points = new PointF[]
            {
                location,
                new PointF(location.X + delta / 2, location.Y - delta),
                new PointF(location.X + delta, location.Y)
            };
            Location = new Rectangle(location.X + delta/2, location.Y - delta, 3, 3);
        }
    }
}
