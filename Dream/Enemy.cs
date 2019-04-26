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
		public Point Location { get; set; }
		public Size EnemySize { get; set; }
		public List<Point> Track { get; set; }
		public Image EnemySprite { get; set; }

		public Enemy(Point location)
		{
			Location = location;
		}

		public void DrawEnemy(Graphics graphics)
		{

		}	
	}
}
