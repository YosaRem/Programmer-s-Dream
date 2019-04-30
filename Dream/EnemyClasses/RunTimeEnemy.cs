using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dream.EnemyClasses
{
	public class RunTimeEnemy : Enemy
	{
		public RunTimeEnemy(Point location, List<Point> track) : base(location, track)
		{
		}

		public override void Move()
		{
			base.Move();
		}
	}
}
