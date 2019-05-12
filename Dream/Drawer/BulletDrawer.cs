using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dream
{
	public class BulletDrawer
	{
		public void Draw(Bullet bullet, Graphics graphics)
		{
			graphics.DrawEllipse(new Pen(Color.Black, 2), new Rectangle(bullet.Location.X, bullet.Location.Y, 5, 5));
		}
	}
}
