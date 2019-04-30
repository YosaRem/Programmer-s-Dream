using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dream
{
	public class Enemy
	{
		public Rectangle Location { get; set; }
		public List<Point> Track { get; set; }
		public Point CurrentDestinationPoint { get; set; }

		public Enemy(Point location, List<Point> track)
		{
			Location = new Rectangle(location.X, location.Y, 25, 25);
			Track = track;
			CurrentDestinationPoint = Track[0];
		}

		public void DrawEnemy(Graphics graphics)
		{

		}	

		public virtual void Move()
		{

		}
	}
}
