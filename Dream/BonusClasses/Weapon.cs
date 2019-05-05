using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dream.BonusClasses
{
    public class Weapon : Mark
    {
        public Image Image { get; set; }

        public Weapon(Point start, Point end) : base(start, end)
        {
        }
    }
}
