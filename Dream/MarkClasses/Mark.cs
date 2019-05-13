using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dream
{
    public class Mark
    {
        public Rectangle Location { get; set; }
        public MarkEnum MarkType { get; set; }

        public Mark(Point start, Point end)
        {
            Location = new Rectangle(start.X, start.Y, 1, end.Y - start.Y);
        }
    }
}
